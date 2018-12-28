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
using Spartane.Core.Classes.TTArchivos;
using Spartane.Services.TTArchivos;
using System.Data;
using System.Web.Script.Serialization;
using oAuth.WebAPI.Consumer;
using oAuth.WebApi.Helpers;
using System.Configuration;
using System.Text;
using Spartane.Core.Classes.InputFile;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;


namespace Spartane.WebApi.Controllers
{
    public class TTArchivosController : BaseApiController
    {
        #region Variables
        private ITTArchivosService service = null;
        public  static string ApiControllerUrl { get; set; }
        public string baseApi;
        #endregion Variables

        #region Constructor
        //TODO: Global Data y Data Rerence tienen que estar en un controlador base
        public TTArchivosController(ITTArchivosService service)
        {
            this.service = service;
            baseApi = ConfigurationManager.AppSettings["DBBaseURL"].ToString();
            ApiControllerUrl = "api/TTArchivos";
        }
        #endregion Constructor

        #region API Methods

        /// <summary>
        /// Insert list of Archivos
        /// </summary>
        /// <param name="InputFileList"></param>
        /// <returns></returns>
        [Authorize]
        public HttpResponseMessage Insert(List<Spartane.Core.Classes.InputFile.InputFile> InputFileList)
        {
            if (ModelState.IsValid)
            {
                var data = new List<Spartane.Core.Classes.TTArchivos.TTArchivos>();
                try
                {
                    //Stream tempstream;
                    //System.Drawing.Image tempimage = null;
                    try
                    {
                        for (int i = 0; i < InputFileList.Count; i++)
                        {
                            string UniqueFileName = DateTime.Now.Ticks.ToString() + "_" + InputFileList[i].FileName;
                            InputFileList[i].FileName = UniqueFileName;
                            //using (MemoryStream mStream = new MemoryStream(InputFileList[i].FileArray))
                            //{
                            //    Image img = Image.FromStream(mStream);
                            //    img.Save(HttpContext.Current.Server.MapPath("~" + Convert.ToString(ConfigurationManager.AppSettings["ArchivosFiles"]) + InputFileList[i].FileName));
                            //}
                            using (FileStream o = new FileStream(HttpContext.Current.Server.MapPath("~" + Convert.ToString(ConfigurationManager.AppSettings["ArchivosFiles"]) + InputFileList[i].FileName), FileMode.CreateNew))
                            {
                                o.Write(InputFileList[i].FileArray, 0, InputFileList[i].FileArray.Length);
                            }

                        }
                        data = this.service.Insert(InputFileList); //, globalData, dataReference);
                    }
                    catch (Exception ex)
                    {
                        return Request.CreateResponse(HttpStatusCode.ExpectationFailed, ex.Message);
                    }                    
                }
                catch (ServiceException ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(error => error.ErrorMessage);
                return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }


        /// <summary>
        /// Get List of Archivos
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public HttpResponseMessage Get(string FolioId)
        {
            IList<GetTTArchivos> entity = new List<GetTTArchivos>(); ;
            try
            {
                try
                {
                    List<GetTTArchivos> ArchivosList = new JavaScriptSerializer().Deserialize<List<GetTTArchivos>>(FolioId);

                    string strFolioId = string.Empty;
                    for (int j = 0; j < ArchivosList.Count; j++)
                    {
                        strFolioId += Convert.ToString(ArchivosList[j].Folio) + ",";
                    }
                    if (!string.IsNullOrEmpty(strFolioId))
                    {
                        // remove last character from string
                        strFolioId = strFolioId.Substring(0, strFolioId.Length - 1);
                    }

                    entity = this.service.SelAll(false, strFolioId);

                    for (int i = 0; i < entity.Count; i++)
                    {
                        if (File.Exists(HttpContext.Current.Server.MapPath("~" + Convert.ToString(ConfigurationManager.AppSettings["ArchivosFiles"]) + entity[i].Nombre)))
                        {
                            entity[i].ArchivoURL = Request.RequestUri.GetLeftPart(UriPartial.Authority) + Convert.ToString(ConfigurationManager.AppSettings["ArchivosFiles"]) + entity[i].Nombre;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.ExpectationFailed, Convert.ToString(ex.Message));
                }
            }
            catch (ServiceException ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Convert.ToString(ex.Message));
            }
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        /// <summary>
        /// Update list of Archivos
        /// </summary>
        /// <param name="InputFileList"></param>
        /// <returns></returns>
        [Authorize]
        public HttpResponseMessage Update(List<Spartane.Core.Classes.TTArchivos.TTArchivos> InputFileList)
        {
            if (ModelState.IsValid)
            {
                var data = new List<Spartane.Core.Classes.TTArchivos.TTArchivos>();
                try
                {
                    string FolioId = string.Empty;

                    for (int i = 0; i < InputFileList.Count; i++)
                    {
                        // Set Folio Id in string for get multiple existing record from database
                        FolioId += Convert.ToString(InputFileList[i].Folio) + ",";

                        // set unique file name
                        string UniqueFileName = DateTime.Now.Ticks.ToString() + "_" + InputFileList[i].Nombre;
                        InputFileList[i].Nombre = UniqueFileName;
                        using (FileStream o = new FileStream(HttpContext.Current.Server.MapPath("~" + Convert.ToString(ConfigurationManager.AppSettings["ArchivosFiles"]) + InputFileList[i].Nombre), FileMode.CreateNew))
                        {
                            // write file using byte with physical path
                            o.Write(InputFileList[i].Archivo, 0, InputFileList[i].Archivo.Length);
                        }
                    }

                    if (!string.IsNullOrEmpty(FolioId))
                    {
                        // remove last character from string
                        FolioId = FolioId.Substring(0, FolioId.Length - 1);
                    }
                    var ExistingImages = this.service.SelAll(false, FolioId);
                    for (int i = 0; i < ExistingImages.Count; i++)
                    {
                        // check old file exist with physical path
                        if (File.Exists(HttpContext.Current.Server.MapPath("~" + Convert.ToString(ConfigurationManager.AppSettings["ArchivosFiles"]) + Convert.ToString(ExistingImages[i].Nombre))))
                        {
                            // Delete existing file from physical path
                            File.Delete(HttpContext.Current.Server.MapPath("~" + Convert.ToString(ConfigurationManager.AppSettings["ArchivosFiles"]) + Convert.ToString(ExistingImages[i].Nombre)));
                        }
                    }


                    data = this.service.Update(InputFileList); //, globalData, dataReference);


                }
                catch (ServiceException ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(error => error.ErrorMessage);
                return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }

        #endregion API Methods

        #region TunnelMethod
       
        /// <summary>
        /// WebAPI PostTunnel
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage InsertTunnel(string user, string password, List<Spartane.Core.Classes.InputFile.InputFile> InputFileList)
        {

                var client = new System.Net.WebClient();
                client.Headers = TokenManager.GetAuthenticationHeader(user,password);client.Encoding = Encoding.UTF8;

                client.Headers["Content-Type"] = "application/json";
                var dataString = new JavaScriptSerializer().Serialize(InputFileList);

                var result = client.UploadString(new Uri(baseApi + ApiControllerUrl + "/Insert"), "POST",
                    dataString);

                return Request.CreateResponse(HttpStatusCode.OK, new JavaScriptSerializer().Deserialize<List<TTArchivos>>(result), Configuration.Formatters.JsonFormatter);            
        }

        [HttpGet]
        public HttpResponseMessage GetTunnel(string FolioId, string user, string password)
        {
            var client = new System.Net.WebClient();
            client.Headers = TokenManager.GetAuthenticationHeader(user, password); client.Encoding = Encoding.UTF8;
            client.Headers["Content-Type"] = "application/json";
            //var dataString = new JavaScriptSerializer().Serialize();
            var result = client.DownloadString(new Uri(baseApi + ApiControllerUrl + "/Get?FolioId=" + FolioId));
            return Request.CreateResponse(HttpStatusCode.OK, new JavaScriptSerializer().Deserialize<List<TTArchivos>>(result), Configuration.Formatters.JsonFormatter);
        }

        [HttpPost]
        public HttpResponseMessage UpdateTunnel(string user, string password, List<Spartane.Core.Classes.TTArchivos.TTArchivos> InputFileList)
        {
            var client = new System.Net.WebClient();
            client.Headers = TokenManager.GetAuthenticationHeader(user, password); client.Encoding = Encoding.UTF8;

            client.Headers["Content-Type"] = "application/json";
            var dataString = new JavaScriptSerializer().Serialize(InputFileList);

            var result = client.UploadString(new Uri(baseApi + ApiControllerUrl + "/Update"), "POST",
                dataString);

            return Request.CreateResponse(HttpStatusCode.OK, new JavaScriptSerializer().Deserialize<List<TTArchivos>>(result), Configuration.Formatters.JsonFormatter);
        }

        #endregion TunnelMethod

    }
}


