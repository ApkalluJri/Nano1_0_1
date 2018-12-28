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
using Telerik.Web.UI;
using System.Web.Services;

public partial class FormsSystem_MasterPageAdministracion : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Timeout1.TimeoutMinutes = this.Session.Timeout;
            Timeout1.AboutToTimeoutMinutes = this.Session.Timeout - 1;
        }
        if (Request["MenuVisible"] != null)
        {
            MenuAdministracion.VisibleMenu = false;
            Timeout1.Enabled = false;
        }
    }


    private object Content(string p)
    {
        throw new NotImplementedException();
    }
}








