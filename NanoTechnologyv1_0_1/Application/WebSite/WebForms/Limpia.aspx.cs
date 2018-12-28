using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebForms_Limpia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Where"] = "";
        Session["Estatus"] = "";
        Session["Fase"] = "";
        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 26/Marzo/2014*/
        /*OBJETIVO: Aplicar determinado filtro en una pantalla de tipo Lista.*/
        Session["WhereFromBR"] = "";
        Session.Remove("WhereFromBR");
        Session.Remove("dsGrid");
        Session.Remove("GridState");

        Response.Redirect(Page.Request["Pagina"].ToString());
    }
}








