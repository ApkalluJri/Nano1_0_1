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

namespace Spartane.WebApi.Controllers
{
    
    public class PDFGeneratorController : BaseApiController
    {
        #region Variables
        public  static string ApiControllerUrl { get; set; }
        public string baseApi;
        public string URLPDFGenerator;
        #endregion Variables

        #region Constructor
        //TODO: Global Data y Data Rerence tienen que estar en un controlador base
        public PDFGeneratorController()
        {
            baseApi = ConfigurationManager.AppSettings["DBBaseURL"].ToString();
            URLPDFGenerator = ConfigurationManager.AppSettings["URLPDFGenerator"].ToString(); 
            ApiControllerUrl = "api/PDFGenerator";
            
        }
        #endregion Constructor


        #region API Methods
        [Authorize]
        [HttpGet]
        public HttpResponseMessage GeneratePDF(string processid,string recordid,string formatid,string user,string password)
        {
            var client = new System.Net.WebClient();
            client.Encoding = Encoding.UTF8;
            var result = client.DownloadString(URLPDFGenerator + "?idProceso=" + processid + "&IDM=" + recordid + "&Imprimir=1&Formato=" + formatid + "&usuario=" + user + "&password=" + password);
            int start = result.IndexOf("<span id=\"lblRutaArchivo\">") + 26;
            int end = result.IndexOf("</span>", start);
            string URL = result.Substring(start, end - start);
            return Request.CreateResponse(HttpStatusCode.OK, URL, Configuration.Formatters.JsonFormatter);
        }

        #endregion API Methods

        #region TunnelMethod

        /// <summary>
        /// WebAPI GeneratePDFTunnel
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GeneratePDFTunnel(string processid, string recordid, string formatid, string user, string password)
        {
                //var client = new System.Net.WebClient();
                //client.Headers = TokenManager.GetAuthenticationHeader(user,password);
                //client.Encoding = Encoding.UTF8;
                //var result = client.DownloadString(baseApi + ApiControllerUrl + "/GeneratePDF?idProceso=" + processid + "&IDM=" + recordid + "&Imprimir=1&Formato=" + formatid + "&usuario=" + user + "&password=" + password);
                //return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
            var client = new System.Net.WebClient();
            client.Encoding = Encoding.UTF8;
            var result = client.DownloadString(URLPDFGenerator + "?idProceso=" + processid + "&IDM=" + recordid + "&Imprimir=1&Formato=" + formatid + "&usuario=" + user + "&password=" + password);
            int start = result.IndexOf("<span id=\"lblRutaArchivo\">") + 26;
            int end = result.IndexOf("</span>", start);
            string URL = result.Substring(start, end - start);
            return Request.CreateResponse(HttpStatusCode.OK, URL, Configuration.Formatters.JsonFormatter);

        }


        #endregion TunnelMethod

    }
}


