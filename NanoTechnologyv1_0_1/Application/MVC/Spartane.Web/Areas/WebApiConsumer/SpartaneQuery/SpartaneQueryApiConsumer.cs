using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.SpartaneQuery
{
    public class SpartaneQueryApiConsumer : BaseApiConsumer, ISpartaneQueryApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public SpartaneQueryApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Spartan_Query";
        }

        public ApiResponse<object> ExecuteQuery(string query)
        {
            try
            {
               // var varRecords = RestApiHelper.InvokeApi<string>(baseApi, ApiControllerUrl + "/Get?query=" + query,
                //      Method.GET, ApiHeader);

                var varRecords = RestApiHelper.InvokeApi<string>(baseApi, ApiControllerUrl + "/Post",
                      Method.POST, ApiHeader, new { query = query });

                return new ApiResponse<object>(true, varRecords);
            }
            catch (Exception)
            {
                return new ApiResponse<object>(false, null);
            }
        }
        public ApiResponse<Dictionary<string, string>> ExecuteQueryDictionary(string query)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Dictionary<string, string>>(baseApi, ApiControllerUrl + "/GetDictionary",
                       Method.POST, ApiHeader, new { query = query });

                return new ApiResponse<Dictionary<string, string>>(true, varRecords);
            }
            catch (Exception)
            {
                return new ApiResponse<Dictionary<string, string>>(false, null);
            }
        }
        public ApiResponse<string> ExecuteRawQuery(string query)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<string>(baseApi, ApiControllerUrl + "/GetRawQuery?query=" + query,
                      Method.GET, ApiHeader);

                return new ApiResponse<string>(true, varRecords);
            }
            catch (Exception)
            {
                return new ApiResponse<string>(false, null);
            }
        }
        public ApiResponse<string> ExecuteQueryTable(string query)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<string>(baseApi, ApiControllerUrl + "/GetTable?query=" + query,
                      Method.GET, ApiHeader);

                return new ApiResponse<string>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<string>(false, null);
            }
        }

    }
}