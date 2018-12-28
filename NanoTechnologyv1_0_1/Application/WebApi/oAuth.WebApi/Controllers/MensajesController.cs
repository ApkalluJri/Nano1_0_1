using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ModelBinding;
using Spartane.Core.Exceptions.Service;
using System.Web;
using System.Data;
using System.Web.Script.Serialization;
using oAuth.WebAPI.Consumer;
using oAuth.WebApi.Helpers;
using System.Configuration;
using System.Text;
using System.IO;
using PushSharp;
using PushSharp.Core;
using PushSharp.Apple;
using PushSharp.Google;
using Newtonsoft.Json.Linq;

namespace Spartane.WebApi.Controllers
{
    
    public class MensajesController : BaseApiController
    {
        #region Variables
        public  static string ApiControllerUrl { get; set; }
        public string IOS_Ambiente;
        public string IOS_NombreCertificado;
        public string IOS_PasswordCertificado;
        public string Android_PasswordCertificado;

        #endregion Variables

        #region Constructor
        //TODO: Global Data y Data Rerence tienen que estar en un controlador base
        public MensajesController()
        {
            IOS_Ambiente = ConfigurationManager.AppSettings["IOS_Ambiente"].ToString();
            IOS_NombreCertificado = ConfigurationManager.AppSettings["IOS_NombreCertificado"].ToString();
            IOS_PasswordCertificado = ConfigurationManager.AppSettings["IOS_PasswordCertificado"].ToString(); 
            Android_PasswordCertificado = ConfigurationManager.AppSettings["Android_PasswordCertificado"].ToString();
            ApiControllerUrl = "api/Mensajes";
        }
        #endregion Constructor


        #region API Methods
        [Authorize]
        [HttpGet]
        public HttpResponseMessage Push(string TokenDispositivo,string Mensaje,int TipoDispositivo)
        {
            string result = "";
            try
            {
                if (TipoDispositivo == 1) {
                    ///////////////////////////////// SECCION Android //////////////////////////////////////

                    GcmServiceBroker gcmBroker = new GcmServiceBroker(new GcmConfiguration(Android_PasswordCertificado));

                    gcmBroker.OnNotificationFailed += (notification, aggregateEx) =>
                    {
                        aggregateEx.Handle(ex =>
                        {

                            // See what kind of exception it was to further diagnose
                            if (ex is GcmNotificationException)
                            {
                                var notificationException = (GcmNotificationException)ex;

                                // Deal with the failed notification
                                var gcmNotification = notificationException.Notification;
                                var description = notificationException.Description;

                                result += "|GCM Notification Failed 1: ID={" + gcmNotification.MessageId + "}, Desc={" + description + "}";
                            }
                            else if (ex is GcmMulticastResultException)
                            {
                                var multicastException = (GcmMulticastResultException)ex;

                                foreach (var succeededNotification in multicastException.Succeeded)
                                {
                                    result += "|GCM Notification Failed 2: ID={" + succeededNotification.MessageId + "}";
                                }

                                foreach (var failedKvp in multicastException.Failed)
                                {
                                    var n = failedKvp.Key;
                                    var e = failedKvp.Value;

                                    result += "|GCM Notification Failed 3: ID={" + n.MessageId + "}, Desc={" + e.Message + "}";
                                }

                            }
                            else if (ex is DeviceSubscriptionExpiredException)
                            {
                                var expiredException = (DeviceSubscriptionExpiredException)ex;

                                var oldId = expiredException.OldSubscriptionId;
                                var newId = expiredException.NewSubscriptionId;

                                result += "|Device RegistrationId Expired: {" + oldId + "}";

                                if (!string.IsNullOrWhiteSpace(newId))
                                {
                                    // If this value isn't null, our subscription changed and we should update our database
                                    result += "|Device RegistrationId Changed To: {" + newId + "}";
                                }
                            }
                            else if (ex is RetryAfterException)
                            {
                                var retryException = (RetryAfterException)ex;
                                // If you get rate limited, you should stop sending messages until after the RetryAfterUtc date
                                result += "|GCM Rate Limited, don't send more until after {" + retryException.RetryAfterUtc + "}";
                            }
                            else
                            {
                                result += "|GCM Notification Failed for some unknown reason";
                            }

                            // Mark it as handled
                            return true;
                        });


                        result += "|Error en el envío";

                    };

                    gcmBroker.OnNotificationSucceeded += (notification) =>
                    {
                        result += "|GCM Notification Sent!";
                        result += "|Mensajes enviados";
                    };

                    gcmBroker.Start();

                    gcmBroker.QueueNotification(new GcmNotification
                    {
                        RegistrationIds = new List<string> { TokenDispositivo },
                        Data = JObject.Parse("{\"title\":\"Notificación\",\"message\":\"" + Mensaje + "\",\"badge\":-1}")
                    });

                    gcmBroker.Stop();
                }
                else if(TipoDispositivo == 2){

                    ///////////////////////////////// SECCION iOS //////////////////////////////////////

                    string ruta = HttpContext.Current.Server.MapPath("~/Certificates/" + IOS_NombreCertificado);
                    ApnsServiceBroker apnsBroker = new ApnsServiceBroker(new ApnsConfiguration(ApnsConfiguration.ApnsServerEnvironment.Sandbox, File.ReadAllBytes(ruta), IOS_PasswordCertificado, false));

                    if (IOS_Ambiente == "1") //Desarrollo
                        apnsBroker = new ApnsServiceBroker(new ApnsConfiguration(ApnsConfiguration.ApnsServerEnvironment.Sandbox, File.ReadAllBytes(ruta), IOS_PasswordCertificado, false));

                    if (IOS_Ambiente == "2") //Producción
                        apnsBroker = new ApnsServiceBroker(new ApnsConfiguration(ApnsConfiguration.ApnsServerEnvironment.Production, File.ReadAllBytes(ruta), IOS_PasswordCertificado, false));

                    apnsBroker.OnNotificationFailed += (notification, aggregateEx) =>
                    {
                        result = "ERROR: " + aggregateEx.Message; //Console.WriteLine("Error");
                    };

                    apnsBroker.OnNotificationSucceeded += (notification) =>
                    {
                        result = "Mensaje enviado";  //Console.WriteLine("Sent");
                    };

                    apnsBroker.Start();

                    apnsBroker.QueueNotification(new ApnsNotification
                    {
                        DeviceToken = TokenDispositivo,
                        Payload = JObject.Parse("{\"aps\":{\"alert\":{\"title\":\"\",\"body\":\"" + Mensaje + "\"},\"badge\":-1,\"sound\":\"chime.aiff\"}}")
                    });

                    apnsBroker.Stop();

                    result = "Mensaje enviado";
                    }
            }
            catch (Exception ex)
            {

                result = "ERROR: " + ex.Message;
            }
            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

        #endregion API Methods

 

    }
}


