using RestSharp;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spartane.Web.Areas.WebApiConsumer.GeneratePDF
{
    public class GeneratePDFApiConsumer : BaseApiConsumer, IGeneratePDFApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public GeneratePDFApiConsumer()
            : base(string.Empty)
        {
            baseApi = ApiUrlManager.BaseUrl;
            ApiControllerUrl = "/api/GeneratePDF";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<byte[]> GeneratePDF(int idFormat, string RecordId)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<byte[]>(baseApi, ApiControllerUrl + "/GeneratePDF?idFormat=" + idFormat + "&RecordId=" + RecordId,  Method.GET, ApiHeader);
                return new ApiResponse<byte[]>(true, varRecords);
            }
            catch (Exception)
            {
                return new ApiResponse<byte[]>(false, null);
            }
        }
    }
}