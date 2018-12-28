/**************************************************************************************************
Creador:          TOTALCASE                           
Fecha Creación:   YYYY-MM-DD                   
Descripción:      Pantalla Catalogo TTGrupo_Reporte
**************************************************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Subgurim.Controles;
using System.IO;
using App_Code.TTBusinessRules;

public partial class TTGrupo_Reporte_Catalogo : TTBasePage.TTBasePage, ICallbackEventHandler
{
    private WSTTGrupo_Reporte.objectBussinessTTGrupo_Reporte myTTGrupo_Reporte = new WSTTGrupo_Reporte.objectBussinessTTGrupo_Reporte();
    private WSTTGrupo_Reporte.GlobalData userData;
    public int iProcess = 16336;
    private String scallBackReturnVariable = null;

    #region CallBackAsincrono
    public void RaiseCallbackEvent(String eventargument)
    {
        ArrayList arr = MyFunctions.ReturnInArray(eventargument, "@");
        String multiRenlgonName = arr[0].ToString();
        String columName = arr[1].ToString();
        int indexRow = MyFunctions.FormatNumberNull(arr[2].ToString()).Value;
        String ValueData;
        if (arr.Count > 3)
            ValueData = arr[3].ToString();
        else
            ValueData = "";

    }
    public String GetCallbackResult()
    {
        return "";
    }
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        ClientScriptManager cm = Page.ClientScript;
        String cbRef = cm.GetCallbackEventReference(this, "arg", "ReceiveServerData", "context");
        String callbackscript = "function callserver(arg,context) {" + cbRef + "}";
        cm.RegisterClientScriptBlock(this.GetType(), "CallServer", callbackscript, true);

        //CEFechaCreacion.Format = System.Configuration.ConfigurationSettings.AppSettings["FormatoFecha"].ToString();


        System.Web.UI.ScriptManager ajaxSM = (System.Web.UI.ScriptManager)this.Page.Master.FindControl("ScriptManager1");
        if (ajaxSM != null)
            ajaxSM.AsyncPostBackTimeout = 3600;



        if (Session["UserGlobalInformation"] == null)
            Response.Redirect("~/FormsSystem/Default.aspx");

        if (!Page.IsPostBack)
        {

            Session["CambiarArchivo"] = 0;
            RevisaLoadArchivo();
            ConfigWithMetadata();
            FillDataControls();
            if (Session["Tipo_Transaccion"].ToString() == "New")
            {
                New();
                ApplyBusinessRules(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.OpenWindows, iProcess);
            }
            if (Session["Tipo_Transaccion"].ToString() == "Update")
            {
                Modification();
                ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.OpenWindows, iProcess);
            }
            if (Session["Tipo_Transaccion"].ToString() == "Consult")
            {
                Modification();
                DisableControls();
                ApplyBusinessRules(TTenumBusinessRules_Operacion.Consult, TTenumBusinessRules_ProcessEvent.OpenWindows, iProcess);
            }

        }



    }

    protected override void OnUnload(EventArgs e)
    {
        //-----------------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.AfterClose, iProcess);
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.AfterClose, iProcess);
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Consult, TTenumBusinessRules_ProcessEvent.AfterClose, iProcess);
        //-----------------------------------------------------------------------------------------------------------------------
    }

    protected void RevisaLoadArchivo()
    {
        if (Session["CambiarArchivo"] != null)
            if (Session["CambiarArchivo"].ToString() == "0")
            {

                Session["CambiarArchivo"] = 0;
            }
    }

    protected void DisableControls()
    {
        txtIdGrupoReporte.Enabled = false;
        txtNombre.Enabled = false;
        RDTFecha.Enabled = false;


        cmdClear.Visible = false;
        cmdHelp.Visible = false;
        cmdSave.Visible = false;
        cmdSaveCopy.Visible = false;
        cmdSaveNew.Visible = false;
    }

    override protected void OnInit(EventArgs e)
    {
        LoadSecurityPage();
        //-------------------------------------------------------------------------------------------------------------
        userData = new WSTTGrupo_Reporte.GlobalData();
        userData.AppToTempFiles = MyUserData.AppToTempFiles;
        userData.ComputerName = MyUserData.ComputerName;
        userData.DatabaseName = MyUserData.DatabaseName;
        userData.Folio = MyUserData.Folio;
        userData.Language = (WSTTGrupo_Reporte.GlobalDataLanguages)MyUserData.Language;
        userData.ServidorName = MyUserData.ServidorName;
        userData.ServidorNameComputer = MyUserData.ServidorNameComputer;
        userData.UserID = MyUserData.UserID;
        userData.UserName = MyUserData.UserName;
        userData.WindowsVersion = MyUserData.WindowsVersion;
        //-------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_FieldEvent.LostFocus, iProcess);
        //-------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------
        base.OnInit(e);
    }

    protected void Page_Prerender(object sender, EventArgs e)
    {
        refreshMultiRenglones();

    }

    private void FillDataControls()
    {

    }
    private void New()
    {
    }
    private void Modification()
    {
        WSTTGrupo_Reporte.objectBussinessTTGrupo_Reporte1 myDataTTGrupo_Reporte = myTTGrupo_Reporte.GetByKey(MyFunctions.FormatNumberNull(Session["IdGrupoReporte"].ToString()), true);
        if (myDataTTGrupo_Reporte.IdGrupoReporte.HasValue)
            txtIdGrupoReporte.Text = myDataTTGrupo_Reporte.IdGrupoReporte.ToString();
        txtNombre.Text = myDataTTGrupo_Reporte.Nombre;
        if (myDataTTGrupo_Reporte.FechaCreacion.HasValue)
            RDTFecha.SelectedDate = DateTime.ParseExact(myDataTTGrupo_Reporte.FechaCreacion.Value.ToString("dd/MM/yyyyyTHH:mm:ss"), "dd/MM/yyyyyTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

        txtIdGrupoReporte.Enabled = false;
    }
    public void ConfigWithMetadata()
    {
        //Boolean Foco = false;
        //WSTTMetadata.objectBussinessTTMetadata myMetadata = new WSTTMetadata.objectBussinessTTMetadata();
        //WSTTMetadata.TTMetadataFilters[] myFiltro = new WSTTMetadata.TTMetadataFilters[1];
        //myFiltro[0] = new WSTTMetadata.TTMetadataFilters();
        //myFiltro[0].ProcesoId = new WSTTMetadata.Dependientes();
        //myFiltro[0].ProcesoId.List = new string[1];
        //myFiltro[0].ProcesoId.List[0] = iProcess.ToString();

        //DataSet ds_controles = new DataSet();
        //ds_controles = myMetadata.SelAllwithFilters(true, myFiltro);
        //DataView dv = new DataView(ds_controles.Tables[0]);

        //dv.RowFilter = "TTMetadata_DTID = " + 38989;
        //if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
        //    lblIdGrupoReporte.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        //else
        //    lblIdGrupoReporte.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        //txtIdGrupoReporte.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        //txtIdGrupoReporte.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        //txtIdGrupoReporte.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        //if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
        //{
        //    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
        //    {
        //        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
        //        {
        //            txtIdGrupoReporte.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
        //        }
        //        else
        //        {
        //            txtIdGrupoReporte.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
        //        }
        //    }
        //    else
        //    {
        //        txtIdGrupoReporte.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
        //    }
        //}
        //else
        //{
        //    txtIdGrupoReporte.Text = "";
        //}
        //imgOblIdGrupoReporte.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        //RFVIdGrupoReporte.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        //trIdGrupoReporte.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        //if (Foco == false && txtIdGrupoReporte.Enabled == true)
        //{
        //    GetFocus(txtIdGrupoReporte);
        //    Foco = true;
        //} dv.RowFilter = "TTMetadata_DTID = " + 38990;
        //if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
        //    lblNombre.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        //else
        //    lblNombre.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        //txtNombre.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        //txtNombre.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        //txtNombre.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        //if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
        //{
        //    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
        //    {
        //        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
        //        {
        //            txtNombre.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
        //        }
        //        else
        //        {
        //            txtNombre.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
        //        }
        //    }
        //    else
        //    {
        //        txtNombre.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
        //    }
        //}
        //else
        //{
        //    txtNombre.Text = "";
        //}
        //imgOblNombre.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        //RFVNombre.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        //trNombre.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        //if (Foco == false && txtNombre.Enabled == true)
        //{
        //    GetFocus(txtNombre);
        //    Foco = true;
        //} dv.RowFilter = "TTMetadata_DTID = " + 38991;
        //if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
        //    lblFechaCreacion.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        //else
        //    lblFechaCreacion.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        //RDTFecha.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        //RDTFecha.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        //RDTFecha.SelectedDate = DateTime.Now;

        //imgOblFechaCreacion.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        //RFVFechaCreacion.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        //trFechaCreacion.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        //if (Foco == false && RDTFecha.Enabled == true)
        //{
        //    GetFocus(RDTFecha);
        //    Foco = true;
        //}

        txtIdGrupoReporte.MaxLength = 9;
        txtNombre.MaxLength = 80;

        RDTFecha.SelectedDate = DateTime.Now;
        UpdatePanel1.Update();
    }
    public Boolean Insert_row()
    {


        try
        {

            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            ApplyBusinessRules(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.BeforeSave, iProcess);
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            myTTGrupo_Reporte.Insert(userData, MyFunctions.FormatNumberNull(txtIdGrupoReporte.Text), txtNombre.Text, MyFunctions.FormatDateNull(RDTFecha.SelectedDate.ToString()));
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            ApplyBusinessRules(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.AfterSave, iProcess);
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------           
            return true;
        }
        catch (Exception exception)
        {
            ShowAlert(exception.Message);
            return false;
        }
    }

    public Boolean Update_row()
    {


        try
        {

            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.BeforeSave, iProcess);
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            myTTGrupo_Reporte.Update(userData, MyFunctions.FormatNumberNull(txtIdGrupoReporte.Text), txtNombre.Text, MyFunctions.FormatDateNull(RDTFecha.SelectedDate.ToString()));
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.AfterSave, iProcess);
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            return true;
        }
        catch (Exception exception)
        {
            ShowAlert(exception.Message);
            return false;
        }
    }



    public void Clear_All()
    {
        txtIdGrupoReporte.Text = "";
        txtNombre.Text = "";
        RDTFecha.Clear();
    }
    protected void cmdSaveCopy_Click(object sender, ImageClickEventArgs e)
    {


        Boolean OperationCompleted = false;
        if (Session["Tipo_Transaccion"].ToString() == "New")
        {
            OperationCompleted = Insert_row();
        }
        else if (Session["Tipo_Transaccion"].ToString() == "Update")
        {
            OperationCompleted = Update_row();
        }
        else if (Session["Tipo_Transaccion"].ToString() == "Search")
        {
            //Search_row();
        }
        if (OperationCompleted)
        {
            Session["Tipo_Transaccion"] = "New";
            Session["CambiarArchivo"] = 1;
        }
    }
    protected void cmdSaveNew_Click(object sender, ImageClickEventArgs e)
    {


        Boolean OperationCompleted = false;
        if (Session["Tipo_Transaccion"].ToString() == "New")
        {
            OperationCompleted = Insert_row();
        }
        else if (Session["Tipo_Transaccion"].ToString() == "Update")
        {
            OperationCompleted = Update_row();
        }
        else if (Session["Tipo_Transaccion"].ToString() == "Search")
        {
            //Search_row();
        }
        if (OperationCompleted)
        {
            Clear_All();
            ConfigWithMetadata();
            Session["Tipo_Transaccion"] = "New";
        }
        Session["CambiarArchivo"] = 0;
    }
    protected void cmdSave_Click(object sender, ImageClickEventArgs e)
    {


        Boolean OperationCompleted = false;
        if (Session["Tipo_Transaccion"].ToString() == "New")
        {
            OperationCompleted = Insert_row();
        }
        else if (Session["Tipo_Transaccion"].ToString() == "Update")
        {
            OperationCompleted = Update_row();
        }
        else if (Session["Tipo_Transaccion"].ToString() == "Search")
        {
            //Search_row();
        }
        if (OperationCompleted)
        {
            Session["Tipo_Transaccion"] = "Update";
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            ApplyBusinessRules(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.BeforeClose, iProcess);
            ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.BeforeClose, iProcess);
            ApplyBusinessRules(TTenumBusinessRules_Operacion.Consult, TTenumBusinessRules_ProcessEvent.BeforeClose, iProcess);
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            Response.Redirect("TTGrupo_Reporte_Lista.aspx");
        }
    }
    protected void cmdClose_Click(object sender, ImageClickEventArgs e)
    {
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.BeforeClose, iProcess);
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.BeforeClose, iProcess);
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Consult, TTenumBusinessRules_ProcessEvent.BeforeClose, iProcess);
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Response.Redirect("TTGrupo_Reporte_Lista.aspx");
    }
    protected void cmdClear_Click(object sender, ImageClickEventArgs e)
    {
        Clear_All();
        ConfigWithMetadata();
    }
    protected void cmdHelp_Click(object sender, ImageClickEventArgs e)
    {

    }


    private void refreshMultiRenglones()
    {

    }

    void AgregaCeldaTextBox(HtmlTableRow trRenglon, String sID, String sTexto, Int32 iRenglon, String sCarpeta, String MultiRenglon, Boolean Multilinea)
    {
        HtmlTableCell td = new HtmlTableCell();
        TextBox txt = new TextBox();
        if (Multilinea == true)
        {
            txt.TextMode = TextBoxMode.MultiLine;
            txt.Columns = 40;
            txt.Rows = 5;
        }
        else
        {
            txt.Width = 100;
        }
        txt.ID = sID + iRenglon;
        txt.Text = sTexto;
        txt.Attributes.Add("runat", "Server");
        txt.Attributes.Add("OnFocusOut", "processText('" + MultiRenglon + "','ctl00_MainContent_TabControls_tabPag" + sCarpeta + "_" + sID + "','" + iRenglon + "')");
        txt.EnableViewState = false;

        td.Controls.Add(txt);
        trRenglon.Cells.Add(td);
    }

    void AgregaCeldaComboBox(HtmlTableRow trRenglon, String sID, String sTexto, Int32 iRenglon, DataSet dsFill, String sCarpeta, String MultiRenglon)
    {
        HtmlTableCell td = new HtmlTableCell();
        DropDownList ddl = new DropDownList();
        ddl.ID = sID + iRenglon;
        MyFunctions.FillDataControl(ddl, dsFill);
        if (sTexto != "")
            ddl.SelectedValue = sTexto;

        ddl.Attributes.Add("runat", "Server");
        ddl.Attributes.Add("OnFocusOut", "processText('" + MultiRenglon + "','ctl00_MainContent_TabControls_tabPag" + sCarpeta + "_" + sID + "','" + iRenglon + "')");
        ddl.EnableViewState = false;
        ddl.Width = 150;
        td.Controls.Add(ddl);
        trRenglon.Cells.Add(td);

    }
    void AgregaCeldaAjaxCalendar(HtmlTableRow trRenglon, String sID, String sTexto, Int32 iRenglon, String sCarpeta, String MultiRenglon)
    {
        //Agregamos el TexBox
        HtmlTableCell td = new HtmlTableCell();
        TextBox txt = new TextBox();
        txt.ID = sID + iRenglon;
        if (sTexto != "")
        {
            DateTime fecha = DateTime.Parse(sTexto);
            txt.Text = String.Format("{0:MM/dd/yyyy}", fecha);
        }
        else
        {
            txt.Text = sTexto;
        }
        txt.Enabled = true;
        txt.Attributes.Add("runat", "Server");
        txt.Attributes.Add("onchange", "processText('" + MultiRenglon + "','ctl00_MainContent_TabControls_tabPag" + sCarpeta + "_" + sID + "','" + iRenglon + "')");
        txt.EnableViewState = false;
        txt.Width = 100;

        //Agregamos la imagen del calendario
        Image ImgCalendar = new Image();
        ImgCalendar.ID = "ImgCalendar" + sID + iRenglon;
        ImgCalendar.ImageUrl = "~/Images/greyscale_38.gif";
        ImgCalendar.Height = 20;
        ImgCalendar.Width = 22;
        ImgCalendar.Visible = true;
        ImgCalendar.Attributes.Add("runat", "Server");

        //Agregamos el objeto Calendar Ajax
        AjaxControlToolkit.CalendarExtender calendario = new AjaxControlToolkit.CalendarExtender();
        calendario.ID = "Calendario" + sID + iRenglon;
        calendario.Animated = true;
        //calendario.BehaviorID = "crl14_CalendarExtender" + sID + iRenglon;
        calendario.Enabled = true;
        calendario.EnabledOnClient = true;
        calendario.EnableViewState = true;
        calendario.Format = System.Configuration.ConfigurationSettings.AppSettings["FormatoFecha"].ToString();
        calendario.PopupButtonID = "ImgCalendar" + sID + iRenglon;
        calendario.TargetControlID = sID + iRenglon; //nombe del txt

        //Agregamos los controles a la celda
        td.Controls.Add(txt);
        td.Controls.Add(ImgCalendar);
        td.Controls.Add(calendario);

        //agregamos la celda  al renglon
        trRenglon.Cells.Add(td);
    }

    public static void GetFocus(Control control)
    {
    }

    protected byte[] ReadFile(string filePath)
    {
        byte[] buffer;
        FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        try
        {
            int length = (int)fileStream.Length;  // get file length
            buffer = new byte[length];            // create buffer
            int count;                            // actual number of bytes read
            int sum = 0;                          // total number of bytes read

            // read until Read method returns 0 (end of the stream has been reached)
            while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                sum += count;  // sum is a buffer offset for next reading
        }
        finally
        {
            fileStream.Close();
        }
        return buffer;
    }





}









