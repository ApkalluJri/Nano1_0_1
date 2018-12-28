using Spartane.Services.Spartan_Query;
using Spartane.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace oAuth.WebApi.Controllers
{
    public class Spartan_QueryController : BaseApiController
    {
        #region Variables
        private ISpartan_QueryService service = null;
        public static string ApiControllerUrl { get; set; }
        public string baseApi;
        #endregion Variables

        #region Constructor
        //TODO: Global Data y Data Rerence tienen que estar en un controlador base
        public Spartan_QueryController(ISpartan_QueryService service)
        {
            this.service = service;
            baseApi = ConfigurationManager.AppSettings["DBBaseURL"].ToString();
            ApiControllerUrl = "api/Spartan_Query";
            
        }
        #endregion Constructor

        #region API Methods
        [Authorize]
        public HttpResponseMessage Get(string query)
        {
            var entity = this.service.ExecuteQuery(query);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        [Authorize]
        [HttpPost]
        public HttpResponseMessage Post(q query)
        {
            var entity = this.service.ExecuteQuery(query.query);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        //CAMBIOS MANUALES
        [Authorize]
        [HttpPost]
        public HttpResponseMessage GetDictionary(q query)
        {
            var entity = this.service.ExecuteQueryDictionary(query.query);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        public HttpResponseMessage GetRawQuery(string query)
        {
            query = query.Replace("\r\n", " ").Replace("\t", " ");
            var entity = this.service.ExecuteRawQuery(query);
            return Request.CreateResponse(HttpStatusCode.OK, entity);
        }
          [Authorize]
        public HttpResponseMessage GetTable(string query)
        {
            var entity = this.service.ExecuteQueryTable(query);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }
      
        #endregion
    }

    public class q
    {
        public string query { get; set; }
    }
}
