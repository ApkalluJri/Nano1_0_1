using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class DefaultMaster_Default : System.Web.UI.MasterPage
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblcase.InnerText = "TotalCase " + System.Configuration.ConfigurationSettings.AppSettings["VersionTotalCase"].ToString();
            lblversion.InnerText = "V" + System.Configuration.ConfigurationSettings.AppSettings["VersionSistema"].ToString();
        }
    }
    
    
    
}







