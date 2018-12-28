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
namespace FormsSystem.TTReportes
{
public partial class FormsSystem_TTBusquedaAvanzada : System.Web.UI.Page, ICallbackEventHandler 
{
    private TTFunctions.Functions myFunctions = new TTFunctions.Functions();
    private String scallBackReturnVariable = null;

    public void RaiseCallbackEvent(String eventargument)
    {
        ArrayList arr = myFunctions.ReturnInArray(eventargument, "¬");
        if (arr.Count > 1)
        {
            String Where = arr[0].ToString();
            String DTId = arr[1].ToString();
            String Renglon = arr[2].ToString();
            String Tipo = arr[3].ToString();

            if (Tipo == "3")
            {
                if (Where != "")
                {
                    Where = " AND (" + Where.Substring(4) + ")";
                }
            }
            DataRow dr = ((DataTable)Session["Store"]).Rows[Int32.Parse(Renglon)];
            dr[1] = Where;

            
        
        }

    }
    public String GetCallbackResult()
    {
        return scallBackReturnVariable;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        ClientScriptManager cm = Page.ClientScript;
        String cbRef = cm.GetCallbackEventReference(this, "arg", "ReceiveServerData", "context");
        String callbackscript = "function callserver(arg,context) {" + cbRef + "}";
        cm.RegisterClientScriptBlock(this.GetType(), "CallServer", callbackscript, true);
        if (!Page.IsPostBack)
        {
            cmdCerrar.Attributes.Add("onclick", "history.back();");

            //Recibir Clave de Proceso para trabajar
            Session["idProceso"] = Page.Request["idProceso"].ToString();
            Session.Add("Where", "");
            //Crear dataset temporal para guardar los queries
            DataTable Store = new DataTable();
            Store.Columns.Add(new DataColumn("DTID", typeof(String)));
            Store.Columns.Add(new DataColumn("WHERE", typeof(String)));
            Session["Store"] = Store;
            GeneraPantalla();
        }
        

    }

    protected void GeneraPantalla()
    {
        DataRow dr;
        String sSql = "";
        HtmlTable tb = new HtmlTable();
        tb.ID = "Tabla";
        tb.Align = "center";
        tb.Border = 1;

        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand("spGetDatosBusquedattMetadata");
        com.Parameters.Add("@idProceso",SqlDbType.Int).Value=Int32.Parse(Session["idProceso"].ToString());
        com.CommandType = CommandType.StoredProcedure;
        DataSet ds = db.Consulta(com);
        DataTable dtb = ds.Tables[0];
        if (dtb.Rows.Count > 0)
        {
            DataTable dt = (DataTable)Session["Store"];
            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                dr=dtb.Rows[i];

                //Lenar dataset temporal para el generado del query
                DataRow nuevo = dt.NewRow();
                nuevo[0] = dr["dtid"].ToString(); nuevo[1] = "";
                dt.Rows.Add(nuevo);
                Session["Store"] = dt;

                switch (dr["Tipo_de_Dato"].ToString())
                {
                    case "1": case "2": case "4": case "5": //Decimal, Numerico, Moneda, Moneda
                    {
                        
                        //Si es dependiente entonces generar la lista multiselección
                        if (Boolean.Parse(dr["Dependiente"].ToString()) == true)
                        {
                            //Crear query para llenar lista multiseleccion
                            sSql = "Select " + GeneraNombre(dr["ClaveDependiente"].ToString()) + "," + GeneraNombre(dr["DescripcionDependiente"].ToString()) + " from " + GeneraNombre(dr["TablaDependiente"].ToString()) + " order by " + GeneraNombre(dr["DescripcionDependiente"].ToString());
                            AgregaRenglonDependiente(tb, dr["dtid"].ToString(), GeneraNombre(dr["tabla"].ToString()), GeneraNombre(dr["nombre"].ToString()), dr["Descr"].ToString(), sSql,i.ToString());
                        }
                        else
                        {
                            AgregaRenglonNumerico(tb, dr["dtid"].ToString(), GeneraNombre(dr["tabla"].ToString()), GeneraNombre(dr["nombre"].ToString()), dr["Descr"].ToString(),i.ToString());
                        }
                        break;
                    }
                    case "3": //Texto
                    {
                        AgregaRenglonTexto(tb, dr["dtid"].ToString(), GeneraNombre( dr["tabla"].ToString()),GeneraNombre(dr["nombre"].ToString()), dr["Descr"].ToString(),i.ToString());
                       break;
                    }
                case "7": //fecha
                    {
                        AgregaRenglonFecha(tb, dr["dtid"].ToString(), GeneraNombre(dr["tabla"].ToString()), GeneraNombre(dr["nombre"].ToString()), dr["Descr"].ToString(),i.ToString());
                        break;
                    }
                }

            }

        }
        Panel1.Controls.Add(tb);
    }

    protected void AgregaRenglonTexto(HtmlTable tabla, String sDTId, String sTabla, String sCampo, string sDescripcion, String Renglon)
    {
        HtmlTableRow tr = new HtmlTableRow();
        HtmlTableCell td = new HtmlTableCell();
        Label lbl = new Label();
        TextBox txt = new TextBox();
        DropDownList ddl = new DropDownList();

        tr = new HtmlTableRow();

        //Agregar etiqueta
        td = new HtmlTableCell();
        lbl = new Label();
        lbl.ID = "Etiqueta_" + sDTId;
        lbl.Font.Bold = true;
        lbl.Text = sDescripcion + " :";
        td.Controls.Add(lbl);
        tr.Cells.Add(td);

        //Agregar Combo para opciones de texto
        td = new HtmlTableCell();
        ddl = new DropDownList();
        ddl.ID = "Opciones_" + sDTId;
        ddl.Items.Add("Que empieze");
        ddl.Items.Add("Que contenga");
        ddl.Items.Add("Que termine");
        ddl.Items.Add("Palabra Exacta");
        ddl.SelectedIndex = 1;
        td.Controls.Add(ddl);
       


        //Agregar Control
        txt = new TextBox();
        txt.ID = "CampoValor_" + sDTId;
        txt.Width = 200;
        txt.Attributes.Add("runat", "Server");
        txt.Attributes.Add("OnFocusOut", "processText('" + txt.ID + "','2','" + sDTId + "','" + sTabla + "','" + sCampo + "','" + Renglon + "')");
        txt.EnableViewState = false;
        td.Controls.Add(txt);
        tr.Cells.Add(td);

        //Agregar Control con los datos del DTId
        td = new HtmlTableCell();
        txt = new TextBox();
        txt.ID = "Config_" + sDTId;
        txt.Text = sTabla + "@" + sDTId;
        txt.Visible = false;
        td.Controls.Add(txt);
        tr.Cells.Add(td);


        tabla.Rows.Add(tr);
    }

    protected void AgregaRenglonDependiente(HtmlTable tabla, String sDTId, String sTabla, String sCampo, String sDescripcion,String Query,String Renglon)
    {
        HtmlTableRow tr = new HtmlTableRow();
        HtmlTableCell td = new HtmlTableCell();
        Label lbl = new Label();
        TextBox txt = new TextBox();
        DropDownList ddl = new DropDownList();
        ListBox lb = new ListBox();
        tr = new HtmlTableRow();

        //Agregar etiqueta
        td = new HtmlTableCell();
        lbl = new Label();
        lbl.ID = "Etiqueta_" + sDTId;
        lbl.Font.Bold = true;
        lbl.Text = sDescripcion + " :";
        td.Controls.Add(lbl);
        tr.Cells.Add(td);

        //Agregar Combo para opciones de texto
        td = new HtmlTableCell();
        lb = new ListBox();
        lb.ID = "Opciones_" + sDTId;
        lb.Rows = 8;
        lb.SelectionMode = ListSelectionMode.Multiple;
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand(Query);
        com.CommandType = CommandType.Text;
        DataSet ds = db.Consulta(com);
        myFunctions.FillDataControl(lb, ds);
        lb.Attributes.Add("runat", "Server");
        lb.Attributes.Add("OnClick", "processText('" + lb.ID + "','3','" + sDTId + "','" + sTabla + "','" + sCampo + "','" + Renglon + "')");
        lb.EnableViewState = false;
        td.Controls.Add(lb);
        tr.Cells.Add(td);

        //Agregar Control con los datos del DTId
        td = new HtmlTableCell();
        txt = new TextBox();
        txt.ID = "Config_" + sDTId;
        txt.Text = sTabla + "@" + sDTId;
        txt.Visible = false;
        td.Controls.Add(txt);
        tr.Cells.Add(td);


        tabla.Rows.Add(tr);
    }

    protected void AgregaRenglonNumerico(HtmlTable tabla, String sDTId, String sTabla, String sCampo, String sDescripcion,String Renglon)
    {
        HtmlTableRow tr = new HtmlTableRow();
        HtmlTableCell td = new HtmlTableCell();
        Label lbl = new Label();
        TextBox txt = new TextBox();
        DropDownList ddl = new DropDownList();
        tr = new HtmlTableRow();

        //Agregar etiqueta
        td = new HtmlTableCell();
        lbl = new Label();
        lbl.ID = "Etiqueta_" + sDTId;
        lbl.Text = sDescripcion + " :";
        lbl.Font.Bold = true;
        td.Controls.Add(lbl);
        tr.Cells.Add(td);

        //Agregar Control
        td = new HtmlTableCell();
        
            //Desde
            lbl = new Label();
            lbl.ID = "EtiquetaDesde_" + sDTId;
            lbl.Text = "Desde : ";
            td.Controls.Add(lbl);

            txt = new TextBox();
            txt.ID = "CampoValorDesde_" + sDTId;
            txt.Attributes.Add("runat", "Server");
            txt.Attributes.Add("OnFocusOut", "processText('" + txt.ID + "','1','" + sDTId + "','" + sTabla + "','" + sCampo + "','" + Renglon + "')");
            txt.EnableViewState = false;
            txt.Width = 100;
            td.Controls.Add(txt);

            //Hasta
            lbl = new Label();
            lbl.ID = "EtiquetaHasta_" + sDTId;
            lbl.Text = " Hasta : ";
            td.Controls.Add(lbl);

            txt = new TextBox();
            txt.ID = "CampoValorHasta_" + sDTId;
            txt.Attributes.Add("runat", "Server");
            txt.Attributes.Add("OnFocusOut", "processText('" + txt.ID + "','1','" + sDTId + "','" + sTabla + "','" + sCampo + "','" + Renglon + "')");
            txt.EnableViewState = false;
            txt.Width = 100;
            td.Controls.Add(txt);

        tr.Cells.Add(td);

        //Agregar Control con los datos del DTId
        td = new HtmlTableCell();
        txt = new TextBox();
        txt.ID = "Config_" + sDTId;
        txt.Text = sTabla + "@" + sDTId;
        txt.Visible = false;
        td.Controls.Add(txt);
        tr.Cells.Add(td);


        tabla.Rows.Add(tr);
    }

    protected void AgregaRenglonFecha(HtmlTable tabla, String sDTId, String sTabla, String sCampo, String sDescripcion,String Renglon)
    {
        HtmlTableRow tr = new HtmlTableRow();
        HtmlTableCell td = new HtmlTableCell();
        Label lbl = new Label();
        TextBox txt = new TextBox();
        ImageButton img=new ImageButton();
        AjaxControlToolkit.CalendarExtender cal = new AjaxControlToolkit.CalendarExtender();
        tr = new HtmlTableRow();

        //Agregar etiqueta
        td = new HtmlTableCell();
        lbl = new Label();
        lbl.ID = "Etiqueta_" + sDTId;
        lbl.Text = sDescripcion + " (MM/dd/yyyy):";
        lbl.Font.Bold = true;
        td.Controls.Add(lbl);
        tr.Cells.Add(td);

        //Agregar Control
        td = new HtmlTableCell();

        //Desde
        lbl = new Label();
        lbl.ID = "EtiquetaDesde_" + sDTId;
        lbl.Text = "Desde : ";
        td.Controls.Add(lbl);

        txt = new TextBox();
        txt.ID = "CampoValorDesde_" + sDTId;
        txt.Attributes.Add("runat", "Server");
        txt.Attributes.Add("OnChange", "processText('" + txt.ID + "','4','" + sDTId + "','" + sTabla + "','" + sCampo + "','" + Renglon + "')");
        txt.EnableViewState = false;
        txt.Width = 100;
        td.Controls.Add(txt);

        img = new ImageButton();
        img.ID = "IBtnFechaDesde" + sDTId;
        img.ImageUrl="~/images/greyscale_38.gif";
        img.CausesValidation=false;
        img.Height=22;
        img.Width=28;
        td.Controls.Add(img);

        cal = new AjaxControlToolkit.CalendarExtender();
        cal.ID = "CEFechaDesde" + sDTId;
        cal.PopupButtonID = "IBtnFechaDesde" + sDTId;
        cal.TargetControlID = "CampoValorDesde_" + sDTId;
        td.Controls.Add(cal);

        //Hasta
        lbl = new Label();
        lbl.ID = "EtiquetaHasta_" + sDTId;
        lbl.Text = " Hasta : ";
        td.Controls.Add(lbl);

        txt = new TextBox();
        txt.ID = "CampoValorHasta_" + sDTId;
        txt.Attributes.Add("runat", "Server");
        txt.Attributes.Add("OnChange", "processText('" + txt.ID + "','4','" + sDTId + "','" + sTabla + "','" + sCampo + "','" + Renglon + "')");
        txt.EnableViewState = false;
        txt.Width = 100;
        td.Controls.Add(txt);

        img = new ImageButton();
        img.ID = "IBtnFechaHasta" + sDTId;
        img.ImageUrl = "~/images/greyscale_38.gif";
        img.CausesValidation = false;
        img.Height = 22;
        img.Width = 28;
        td.Controls.Add(img);

        cal = new AjaxControlToolkit.CalendarExtender();
        cal.ID = "CEFechaHasta" + sDTId;
        cal.PopupButtonID = "IBtnFechaHasta" + sDTId;
        cal.TargetControlID = "CampoValorHasta_" + sDTId;
        td.Controls.Add(cal);

        tr.Cells.Add(td);

        //Agregar Control con los datos del DTId
        td = new HtmlTableCell();
        txt = new TextBox();
        txt.ID = "Config_" + sDTId;
        txt.Text = sTabla + "@" + sDTId;
        txt.Visible = false;
        td.Controls.Add(txt);
        tr.Cells.Add(td);


        tabla.Rows.Add(tr);
    }
    private String GeneraNombre(String sCampo)
    {
        sCampo = sCampo.Trim();
        sCampo=sCampo.Replace(" ", "_");
        sCampo = sCampo.Replace(",", "_");
        sCampo = sCampo.Replace(".", "_");
        sCampo = sCampo.Replace(":", "_");
        sCampo = sCampo.Replace(";", "_");
        sCampo = sCampo.Replace("á", "a");
        sCampo = sCampo.Replace("é", "e");
        sCampo = sCampo.Replace("í", "i");
        sCampo = sCampo.Replace("ó", "o");
        sCampo = sCampo.Replace("ú", "u");
        sCampo = sCampo.Replace("ñ", "n");
        sCampo = sCampo.Replace("Á", "A");
        sCampo = sCampo.Replace("É", "E");
        sCampo = sCampo.Replace("Í", "I");
        sCampo = sCampo.Replace("Ó", "O");
        sCampo = sCampo.Replace("Ú", "U");
        sCampo = sCampo.Replace("Ñ", "N");
        return sCampo;
    }

    protected void cmdBuscar_Click(object sender, EventArgs e)
    {
        
    }
    protected void cmdBuscar_Click1(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)Session["Store"];
        String Where = "";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i].ItemArray[1].ToString() != "")
            {
                Where = Where + dt.Rows[i].ItemArray[1].ToString();
            }
        }
        if (Where != "")
        {
            Where = Where.Substring(4);
        }
        Session["Where"] = Where;
        String NombreProceso = ObtenTablaProceso();
        Session["NombreDNT"] = NombreProceso;
        Response.Redirect(NombreProceso + "_lista.aspx");
    }
    protected void cmdCerrar_Click(object sender, EventArgs e)
    {
        Session["NombreDNT"] = "";
        Session["Where"] = "";
        Response.Redirect(ObtenTablaProceso() + "_lista.aspx");
    }

    private String ObtenTablaProceso()
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand("Select distinct dnt.nombre_tabla from ttdnt dnt inner join ttmetadata tt on dnt.dntid = tt.dntid where tt.procesoid=" + Page.Request["idProceso"].ToString());
        com.CommandType = CommandType.Text;
        DataSet ds = db.Consulta(com);
        return GeneraNombre(ds.Tables[0].Rows[0].ItemArray[0].ToString());
    }
	
}
}








