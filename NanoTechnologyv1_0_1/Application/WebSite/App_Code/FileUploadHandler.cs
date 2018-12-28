using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.SessionState;

public class FileUploadHandler : IHttpHandler
{
    #region IHttpHandler Members
    public bool IsReusable
    {
        get { return false; }
    }

    public void ProcessRequest(HttpContext context)
    {
        //Uploaded File Deletion
        if (context.Request.QueryString.Count > 0)
        {
            string filePath = context.Server.MapPath(@"~\Webforms\TempFiles") + @"\" + context.Request.QueryString["del"];

            if (File.Exists(filePath))
                File.Delete(filePath);
        }
        //File Upload
        else
        {
            string fileName = Path.GetFileName(context.Request.Files[0].FileName);

            string location = context.Server.MapPath(@"~\Webforms\TempFiles") + @"\";
            if (File.Exists(location + fileName))
                File.Delete(location + fileName);
            context.Request.Files[0].SaveAs(location + fileName);
        }
    }
    #endregion
}








