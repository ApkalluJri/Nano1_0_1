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

public partial class FormsSystem_TTConfiguracion : TTBasePage.TTBasePage, ICallbackEventHandler 
{
    private String scallBackReturnVariable = null;
    private Int32 idProceso = 0;

    public void RaiseCallbackEvent(String eventargument)
    {
        ArrayList arr = MyFunctions.ReturnInArray(eventargument, "@");
        if (arr.Count > 1)
        {
            String Valor = arr[0].ToString();
            String Columna = arr[1].ToString();
            String Renglon = arr[2].ToString();
            String Tipo = arr[3].ToString();

            DataRow dr = ((DataTable)Session["Store"]).Rows[Int32.Parse(Renglon)];
            if (Tipo == "1") //valor boolean
            {
                dr[Int32.Parse(Columna)] = Boolean.Parse(Valor);
            }
            if (Tipo == "2") //valor texto
            {
                dr[Int32.Parse(Columna)] = Valor;
            }
        }

    }
    public String GetCallbackResult()
    {
        return scallBackReturnVariable;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadSecurityPage();
        ClientScriptManager cm = Page.ClientScript;
        String cbRef = cm.GetCallbackEventReference(this, "arg", "ReceiveServerData", "context");
        String callbackscript = "function callserver(arg,context) {" + cbRef + "}";
        cm.RegisterClientScriptBlock(this.GetType(), "CallServer", callbackscript, true);
        if (!Page.IsPostBack)
        {
            idProceso = Int32.Parse(Page.Request["idProceso"].ToString());
            //Crear dataset temporal para guardar los queries
            DataTable Store = new DataTable();
            Store.Columns.Add(new DataColumn("DTID", typeof(String)));
            Store.Columns.Add(new DataColumn("OBLIGATORIO", typeof(Boolean)));
            Store.Columns.Add(new DataColumn("VISIBLE", typeof(Boolean)));
            Store.Columns.Add(new DataColumn("SOLO_LECTURA", typeof(Boolean)));
            Store.Columns.Add(new DataColumn("FILTRO", typeof(Boolean)));
            Store.Columns.Add(new DataColumn("VALOR_POR_DEFECTO", typeof(String)));
            Store.Columns.Add(new DataColumn("TEXTO_AYUDA", typeof(String)));
            Session["Store"] = Store;

            GeneraPantalla();
            SetLanguage();
        }
    }

    private void SetLanguage()
    {
        try
        {
            TTProcesoCS.objectBussinessTTProceso myProceso = new TTProcesoCS.objectBussinessTTProceso();
            DataSet ds = myProceso.GetByKeyIdProceso(idProceso);
            string sProcessName = ds.Tables[0].Rows[0]["TTProceso_Nombre"].ToString();

            string sTitle = string.Format(MyTraductor.getMessage(26, this.Title), MyTraductor.getTextProcess(idProceso, MyFunctions.GenerateName(sProcessName)));

            Label lblTitulo = (Label)this.Page.Master.FindControl("lblTitulo");
            lblTitulo.Text = sTitle;
            this.Title = sTitle;
            
            lblGuardar.Text = MyTraductor.getMessage(34, lblGuardar.Text);
            lblCancelar.Text = MyTraductor.getMessage(35, lblCancelar.Text);
        }
        catch { }
    }

    protected void GeneraPantalla()
    {
        DataRow dr;
        HtmlTableRow tr;
        HtmlTableCell td;
        Label lbl;
        HtmlTable tb = new HtmlTable();
        tb.ID = "Tabla";
        tb.Align = "center";
        tb.Border = 1;

        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand("spGetDatosConfiguracionttMetadata");
        com.Parameters.Add("@idProceso", SqlDbType.Int).Value = idProceso;
        com.CommandType = CommandType.StoredProcedure;
        DataSet ds = db.Consulta(com);
        DataTable dtb = ds.Tables[0];
        if (dtb.Rows.Count > 0)
        {
            DataTable dt = (DataTable)Session["Store"];

            //Agregar Titulos a la tabla
            AgregaTitulos(tb);

            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                tr = new HtmlTableRow();

                dr = dtb.Rows[i];

                //Lenar dataset temporal para guardar la información
                DataRow nuevo = dt.NewRow();
                nuevo[0] = dr["dtid"];
                nuevo[1] = dr["obligatorio"];
                nuevo[2] = dr["visible"];
                nuevo[3] = dr["solo_lectura"];
                nuevo[4] = dr["filtro"];
                nuevo[5] = dr["valor_por_defecto"];
                nuevo[6] = dr["texto_ayuda"]; 

                dt.Rows.Add(nuevo);
                Session["Store"] = dt;
                //************************************************

                
                //Agregar Descripción
                td = new HtmlTableCell();
                td.Align = "left";
                lbl = new Label();
                lbl.ID = "Etiqueta_" + dr["dtid"].ToString();
                lbl.Text = dr["Descr"].ToString();
                lbl.Font.Bold = true;
                td.Controls.Add(lbl);
                tr.Cells.Add(td);


                AgregaCeldaCheckBox(tr, "Obligatorio", dr["dtid"].ToString(), Boolean.Parse(dr["obligatorio"].ToString()),Boolean.Parse(dr["identificador"].ToString()),i.ToString(),"1");
                AgregaCeldaCheckBox(tr, "Visible", dr["dtid"].ToString(), Boolean.Parse(dr["visible"].ToString()), Boolean.Parse(dr["identificador"].ToString()),i.ToString(),"2");
                AgregaCeldaCheckBox(tr, "Solo_Lectura", dr["dtid"].ToString(), Boolean.Parse(dr["solo_lectura"].ToString()),Boolean.Parse(dr["identificador"].ToString()), i.ToString(),"3");
                AgregaCeldaCheckBox(tr, "filtro", dr["dtid"].ToString(), Boolean.Parse(dr["filtro"].ToString()), Boolean.Parse(dr["identificador"].ToString()), i.ToString(), "4");
                AgregaCeldaValorDefecto(tr, "Valor_por_Defecto", dr["dtid"].ToString(), dr["valor_por_defecto"].ToString(), Boolean.Parse(dr["identificador"].ToString()), i.ToString(), "5");
                AgregaCeldaTextoAyuda(tr, "Texto_Ayuda", dr["dtid"].ToString(), dr["texto_ayuda"].ToString(), i.ToString(), "6");


                tb.Rows.Add(tr);
                
            }

        }
        Panel1.Controls.Add(tb);
    }

    private void AgregaCeldaCheckBox(HtmlTableRow ren, String Campo, String DTId, Boolean Valor,Boolean Identificador,String Renglon,String Columna)
    {
        CheckBox chk;
        HtmlTableCell td;

        //Agregar Obligatorio
        td = new HtmlTableCell();
        td.Align = "center";
        chk = new CheckBox();
        chk.ID = Campo + "_" + DTId;
        chk.Checked = Valor;
        if (Identificador == true && Columna != "2" && Columna != "4")
            chk.Enabled = false;
        chk.Attributes.Add("runat", "Server");
        chk.Attributes.Add("OnClick", "processText('" + chk.ID + "','" + Columna + "','" + Renglon + "','1')");
        chk.EnableViewState = false;
        td.Controls.Add(chk);
        ren.Cells.Add(td);
    }

    private void AgregaCeldaValorDefecto(HtmlTableRow ren, String Campo, String DTId, String Valor, Boolean Identificador, String Renglon, String Columna)
    {
        TextBox txt;
        HtmlTableCell td;

        //Agregar Obligatorio
        td = new HtmlTableCell();
        td.Align = "left";
        txt = new TextBox();
        txt.ID = Campo + "_" + DTId;
        txt.Text = Valor;
        txt.MaxLength = 150;
        if (Identificador == true)
            txt.Enabled = false;
        txt.Attributes.Add("runat", "Server");
        txt.Attributes.Add("OnFocusOut", "processText('" + txt.ID + "','" + Columna + "','" + Renglon + "','2')");
        txt.EnableViewState = false;
        td.Controls.Add(txt);
        ren.Cells.Add(td);
    }

    private void AgregaCeldaTextoAyuda(HtmlTableRow ren, String Campo, String DTId, String Valor, String Renglon, String Columna)
    {
        TextBox txt;
        HtmlTableCell td;

        //Agregar Obligatorio
        td = new HtmlTableCell();
        td.Align = "left";
        txt = new TextBox();
        txt.ID = Campo + "_" + DTId;
        txt.TextMode = TextBoxMode.MultiLine;
        txt.Rows = 2;
        txt.Columns = 30;
        txt.MaxLength = 150;
        txt.Text = Valor;
        txt.Attributes.Add("runat", "Server");
        txt.Attributes.Add("OnFocusOut", "processText('" + txt.ID + "','" + Columna + "','" + Renglon + "','2')");
        txt.EnableViewState = false;
        td.Controls.Add(txt);
        ren.Cells.Add(td);
    }
    private void AgregaTitulos(HtmlTable tabla)
    {
        HtmlTableRow tr;
        HtmlTableCell td;
        Label lbl;

        tr = new HtmlTableRow();
        tr.Attributes["class"] = "GridHeaderStyle";

        td = new HtmlTableCell();
        td.Align = "center";
        lbl = new Label(); 
        lbl.Text = MyTraductor.getMessage(27, "Campo"); 
        lbl.Font.Bold = true;
        td.Controls.Add(lbl);
        tr.Cells.Add(td);

        td = new HtmlTableCell();
        td.Align = "center";
        lbl = new Label(); 
        lbl.Text = MyTraductor.getMessage(28, "Obligatorio"); 
        lbl.Font.Bold = true;
        td.Controls.Add(lbl);
        tr.Cells.Add(td);

        td = new HtmlTableCell();
        td.Align = "center";
        lbl = new Label(); 
        lbl.Text = MyTraductor.getMessage(29, "Visible"); 
        lbl.Font.Bold = true;
        td.Controls.Add(lbl);
        tr.Cells.Add(td);

        td = new HtmlTableCell();
        td.Align = "center";
        lbl = new Label(); 
        lbl.Text = MyTraductor.getMessage(30, "Solo Lectura"); 
        lbl.Font.Bold = true;
        td.Controls.Add(lbl);
        tr.Cells.Add(td);

        td = new HtmlTableCell();
        td.Align = "center";
        lbl = new Label(); 
        lbl.Text = MyTraductor.getMessage(31, "Filtro Rápido"); 
        lbl.Font.Bold = true;
        td.Controls.Add(lbl);
        tr.Cells.Add(td);

        td = new HtmlTableCell();
        td.Align = "center";
        lbl = new Label(); 
        lbl.Text = MyTraductor.getMessage(32, "Valor por Defecto"); 
        lbl.Font.Bold = true;
        td.Controls.Add(lbl);
        tr.Cells.Add(td);

        td = new HtmlTableCell();
        td.Align = "center";
        lbl = new Label(); 
        lbl.Text = MyTraductor.getMessage(33, "Texto de Ayuda"); 
        lbl.Font.Bold = true;
        td.Controls.Add(lbl);
        tr.Cells.Add(td);
        tabla.Rows.Add(tr);
    }

    private String GeneraNombre(String sCampo)
    {
        sCampo = sCampo.Trim();
        sCampo = sCampo.Replace(" ", "_");
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
    protected void cmdGrabar_Click(object sender, EventArgs e)
    {
        //Grabar las modificaciones en el Metadata
        String sSql = "";
        DataTable dt = (DataTable)Session["Store"];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataRow dr = dt.Rows[i];
            sSql = "set nocount on; Update ttmetadata set obligatorio=" + Funcion.CambiaLogico(dr["obligatorio"].ToString()).ToString() + ",visible=" + Funcion.CambiaLogico(dr["visible"].ToString()).ToString() + ",solo_lectura=" + Funcion.CambiaLogico(dr["solo_lectura"].ToString()).ToString() + ",filtro=" + Funcion.CambiaLogico(dr["filtro"].ToString()).ToString() + ",valor_por_defecto='" + dr["valor_por_defecto"].ToString() + "',texto_ayuda='" + dr["texto_ayuda"].ToString() + "' where dtid=" + dr["DTID"].ToString() + "; select @@identity";

            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            TTDataLayerCS.DataLayerFieldsBitacora bitacora = new TTDataLayerCS.DataLayerFieldsBitacora("1", 1);
            SqlCommand com = new SqlCommand(sSql);
            com.CommandType = CommandType.Text;
            db.EjecutaUpdate(com, (TTSecurity.GlobalData)Session["UserGlobalInformation"], bitacora);
        }
        Response.Redirect(ObtenTablaProceso() + "_lista.aspx");
    }
    protected void cmdCancelar_Click(object sender, EventArgs e)
    {
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








