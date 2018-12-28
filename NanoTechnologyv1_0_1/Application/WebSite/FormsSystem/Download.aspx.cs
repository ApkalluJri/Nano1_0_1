using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FormsSystem_Download : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string filePath = Request["FilePath"];
            string fileName = Request["FileName"];
            Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.ContentType = "text/plain";
            Response.WriteFile(filePath);
        }
        catch (Exception ex)
        {
            Response.Write(@ex.Message.ToString());
        }
    }    
}








