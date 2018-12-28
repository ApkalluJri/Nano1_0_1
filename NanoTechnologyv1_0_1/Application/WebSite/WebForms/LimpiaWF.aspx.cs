using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace WebForms
{
    public partial class LimpiaWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Where"] = "";
            Session["Estatus"] = "";
            Session["Fase"] = "";
            Session["WhereWorflow"] = "";
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 26/Marzo/2014*/
            /*OBJETIVO: Aplicar determinado filtro en una pantalla de tipo Lista.*/
            Session["WhereFromBR"] = "";
            Session.Remove("WhereFromBR");
            Session.Remove("WhereWorflow");
            Session.Remove("dsGrid");
            Session.Remove("GridState");
            string Fase = "?Fase=" + Page.Request["Fase"].ToString();
            string pf = "";
            if (Page.Request["pf"] != null)
            {
                if (Page.Request["pf"].ToString() != "")
                {
                    pf = "&pf=" + Page.Request["pf"].ToString();
                }
            }
            
            Response.Redirect(Page.Request["Pagina"].ToString() + Fase + pf );
        }
    }
}








