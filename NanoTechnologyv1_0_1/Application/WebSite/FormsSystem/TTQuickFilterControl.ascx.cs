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
using Telerik.Web.UI;

public partial class FormsSystem_TTQuickFilterControl : System.Web.UI.UserControl
{
    private TTFunctions.Functions MyFunctions = new TTFunctions.Functions();
    private int ProcessId;
    private int? idView;

    private TTSecurity.GlobalData MyUserData
    {
        get { return System.Web.HttpContext.Current.Session["UserGlobalInformation"] as TTSecurity.GlobalData; }
    }

    private bool modoConsulta = true;
    public bool ModoConsulta
    {
        get { return modoConsulta; }
        set { modoConsulta = value; }
    }

    private bool isDetail = false;
    public bool IsDetail
    {
        get { return isDetail; }
        set { isDetail = value; }
    }

    private ControlsLibrary.objectBussinessTTFiltro.TTFiltersAdvancedEntryType entryType = ControlsLibrary.objectBussinessTTFiltro.TTFiltersAdvancedEntryType.FilterAdvanced;
    public ControlsLibrary.objectBussinessTTFiltro.TTFiltersAdvancedEntryType EntryType
    {
        get { return entryType; }
        set { entryType = value; }
    }

    private ControlsLibrary.objectBussinessTTFiltro myFilter;
    public ControlsLibrary.objectBussinessTTFiltro MyFilter
    {
        get { return myFilter; }
        set { myFilter = value; }
    }
    private TTTraductor.Traductor MyTraductor;
    private int CountDTs = 0;
    private Label[] vlblDTSearch;
    private Label[] vlblFromSearch;
    private Label[] vlblToSearch;
    private RadComboBox[] vtxtFromNumericSearch;
    private RadComboBox[] vtxtToNumericSearch;
    private RadComboBox[] vtxtFromDecimalSearch;
    private RadComboBox[] vtxtToDecimalSearch;
    private RadComboBox[] vtxtFromMoneySearch;
    private RadComboBox[] vtxtToMoneySearch;
    private TextBox[] vtxtFromHourSearch;
    private TextBox[] vtxtToHourSearch;
    //private DropDownList[] vcbTextSearch;
    private RadComboBox[] vtxtTextSearch;
    //---------------------------------
    private TextBox[] vdtFromDateSearch;
    private TextBox[] vdtToDateSearch;
    private Telerik.Web.UI.RadDatePicker[] vRadFromDate;
    private Telerik.Web.UI.RadDatePicker[] vRadToDate;
    //---------------------------------
    private DropDownList[] vcbLogicSearch;
    private RadComboBox[] vlstListSearch;//private ListBox[] vlstListSearch;
    private DropDownList[] vcbSearchDep;
    private Button[] vcmdSearchDetails;
    private Button[] vcmdClearSearchDetails;
    private CheckBox[] vchkQuestion;    
    private Boolean isQuestionable = false;
    public Boolean IsQuestionable
    {
        get { return isQuestionable; }
        set { isQuestionable = value; }
    }
    private Boolean imQuestion = false;
    public Boolean ImQuestion
    {
        get { return imQuestion; }
        set { imQuestion = value; }
    }

    public void New(int iProcess)
    {
        ProcessId = iProcess;
        if (entryType == ControlsLibrary.objectBussinessTTFiltro.TTFiltersAdvancedEntryType.FilterAdvanced)
            ShowControls(ProcessId, MyUserData);
        else if (entryType == ControlsLibrary.objectBussinessTTFiltro.TTFiltersAdvancedEntryType.QuickFilter)
            ShowQuickControls(ProcessId, MyUserData);
    }
    private void modification(int? Key)
    {
        idView = Key;
    }

    public void ShowControls(int Process, TTSecurity.GlobalData UserData)
    {
        ProcessId = Process;
        MyTraductor = new TTTraductor.Traductor(MyUserData.Language.GetHashCode());
        configurationLanguageScreen();

        tbl1.Rows.Clear();
        GetActiveFilters(myFilter);
        CreateHtmlControls(TotalFilters);

        DataSet ds;
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "spTtMetadata_X_Process";
        com.CommandType = CommandType.StoredProcedure;

        foreach (ObjectFilterWithIndexAndProcess item in FilterList)
        {
            com.Parameters.Clear();
            com.Parameters.AddWithValue("@ProcesoId", item.ProcessId);
            com.Parameters.AddWithValue("@UserID", UserData.UserID);
            com.Parameters.AddWithValue("@Idioma", UserData.Language.GetHashCode());

            ds = db.Consulta(com);

            DataRow[] drDesc;
            drDesc = ds.Tables[0].Select("DNTID = '" + item.ObjFilter.Filtro_Detalle[item.Index].DNTFiltro + "' and DTID = '" + item.ObjFilter.Filtro_Detalle[item.Index].Dt_Filtro + "'");
            if (drDesc.Length > 0)
            {
                AddRowDTSearch(drDesc[0], item.ObjFilter.Filtro_Detalle[item.Index]);
                item.TableIndex = CountDTs;
                Panel panel = (Panel)Funcion.FindControlRecursive(Page, "panel" + item.ProcessId.ToString());
                panel.GroupingText = drDesc[0]["NombreTabla"].ToString();
            }
        }

        Session["FilterList"] = FilterList;
    }

    public void ShowQuickControls(int Process, TTSecurity.GlobalData UserData)
    {
        ProcessId = Process;
        myFilter.ProcesoID = ProcessId;
        MyTraductor = new TTTraductor.Traductor(MyUserData.Language.GetHashCode());
        configurationLanguageScreen();

        DataSet ds;
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "spTtMetadata_X_ProcessQuickFilter";
        com.Parameters.AddWithValue("@ProcesoId", ProcessId);
        com.Parameters.AddWithValue("@UserID", UserData.UserID);
        com.Parameters.AddWithValue("@Idioma", UserData.Language.GetHashCode());
        com.CommandType = CommandType.StoredProcedure;
        ds = db.Consulta(com);
        if (myFilter.Filtro_Detalle == null)
        {
            myFilter.Filtro_Detalle = new ControlsLibrary.objectBussinessTTFiltro_Detalle[ds.Tables[0].Rows.Count];
            for (int i = 0; i < myFilter.Filtro_Detalle.Length; i++)
            {
                myFilter.Filtro_Detalle[i] = new ControlsLibrary.objectBussinessTTFiltro_Detalle();
                myFilter.Filtro_Detalle[i].Question = true;
            }
        }
        else if (myFilter.Filtro_Detalle.Length != ds.Tables[0].Rows.Count)
        {
            myFilter.Filtro_Detalle = new ControlsLibrary.objectBussinessTTFiltro_Detalle[ds.Tables[0].Rows.Count];
            for (int i = 0; i < myFilter.Filtro_Detalle.Length; i++)
            {
                myFilter.Filtro_Detalle[i] = new ControlsLibrary.objectBussinessTTFiltro_Detalle();
                myFilter.Filtro_Detalle[i].Question = true;
            }
        }
        tbl1.Rows.Clear();
        GetActiveFilters(myFilter);
        CreateHtmlControls(TotalFilters);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ObjectFilterWithIndexAndProcess item = (ObjectFilterWithIndexAndProcess)FilterList[i];
            AddRowDTSearch(ds.Tables[0].Rows[i], item.ObjFilter.Filtro_Detalle[item.Index]);
            item.TableIndex = CountDTs;
            Panel panel = (Panel)Funcion.FindControlRecursive(Page, "panel" + item.ProcessId.ToString());
            panel.GroupingText = ds.Tables[0].Rows[i]["NombreTabla"].ToString();

            myFilter.Filtro_Detalle[i].DNTFiltro = MyFunctions.FormatNumberNull(ds.Tables[0].Rows[i]["DNTID"]);
            myFilter.Filtro_Detalle[i].Dt_Filtro = MyFunctions.FormatNumberNull(ds.Tables[0].Rows[i]["DTID"]);

            if (ds.Tables[0].Rows[i]["Dependiente"].ToString() == "True")
            {
                myFilter.Filtro_Detalle[i].TipoDeControlBusqueda = ControlsLibrary.TypeControlSearchAdvanced.Dependiente;
            }
            else
                switch (ds.Tables[0].Rows[i]["Tipo_de_Dato"].ToString())
                {
                    case "1"://Caracter                            
                    case "3"://Texto
                    case "4"://Alfanumerico 
                        myFilter.Filtro_Detalle[i].TipoDeControlBusqueda = ControlsLibrary.TypeControlSearchAdvanced.Text;
                        break;
                    case "2"://Numerico
                        myFilter.Filtro_Detalle[i].TipoDeControlBusqueda = ControlsLibrary.TypeControlSearchAdvanced.Numeric;
                        break;
                    case "5"://Moneda
                        myFilter.Filtro_Detalle[i].TipoDeControlBusqueda = ControlsLibrary.TypeControlSearchAdvanced.Money;
                        break;
                    case "10": //FechaHora
                    case "7":  //Fecha
                        myFilter.Filtro_Detalle[i].TipoDeControlBusqueda = ControlsLibrary.TypeControlSearchAdvanced.Date;
                        break;
                    case "6": //Logico
                        myFilter.Filtro_Detalle[i].TipoDeControlBusqueda = ControlsLibrary.TypeControlSearchAdvanced.Logic;
                        break;
                    case "8"://Hora
                        myFilter.Filtro_Detalle[i].TipoDeControlBusqueda = ControlsLibrary.TypeControlSearchAdvanced.Hour;
                        break;
                    case "11"://Color
                        myFilter.Filtro_Detalle[i].TipoDeControlBusqueda = ControlsLibrary.TypeControlSearchAdvanced.Color;
                        break;
                    default:
                        break;
                }
        }

        Session["FilterList"] = FilterList;
        Session["Filter"] = MyFilter;
    }

    private void AddRowDTSearch(DataRow dr, ControlsLibrary.objectBussinessTTFiltro_Detalle objFilterDetalle)
    {
        string sDescrption = dr["DescripcionIdioma"].ToString().TrimEnd(' ');
        string sNombre = dr["Nombre"].ToString().TrimEnd(' ');

        sDescrption = sDescrption == "" ? dr["Descripcion"].ToString().TrimEnd(' ') : sDescrption;
        sDescrption = sDescrption == "" ? sNombre : sDescrption;
        sNombre = MyFunctions.GenerateName(sNombre);
        CountDTs++;

        HtmlTableRow PicRow = new HtmlTableRow();
        HtmlTableCell PicCel = new HtmlTableCell();
        PicRow.VAlign = "Middle";

        TTMetadata.Metadata MyMeta = new TTMetadata.Metadata(MyUserData);
        TTMetadata.MetadataDatos MyMetadatos = MyMeta.GetDatosDT(MyFunctions.FormatNumberNull(dr["DTID"].ToString()).Value);
        TTMetadata.MetadataDatos MyMetadatosDep = new TTMetadata.MetadataDatos();
        TTMetadata.MetadataDatos MyMetadatosDepDesc = new TTMetadata.MetadataDatos();

        if (MyMetadatos.DependienteClave != null)
        {
            MyMetadatosDep = MyMeta.GetDatosDT(MyMetadatos.DependienteClave.Value);
            MyMetadatosDepDesc = MyMeta.GetDatosDT(MyMetadatos.DependienteDescripcion.Value);
        }

        switch (MyFunctions.ObtenTipoControl(dr["DNTID"].ToString(), dr["DTID"].ToString(), dr["DependienteTabla"].ToString(), dr["DependienteClave"].ToString()))
        {
            case TTFunctions.TypeControl.MultiRenglon:
                {
                    vlblDTSearch[CountDTs - 1] = new Label();
                    vlblDTSearch[CountDTs - 1].ID = "lblDT" + dr["DTID"].ToString();
                    vlblDTSearch[CountDTs - 1].Text = sDescrption;
                    vlblDTSearch[CountDTs - 1].Width = lblDT.Width;
                    vlblDTSearch[CountDTs - 1].Visible = true;
                    PicCel = new HtmlTableCell();
                    PicCel.Controls.Add(vlblDTSearch[CountDTs - 1]);
                    PicRow.Cells.Add(PicCel);

                    vchkQuestion[CountDTs - 1] = new CheckBox();
                    vchkQuestion[CountDTs - 1].ID = "chkQuestion" + dr["DTID"].ToString();
                    vchkQuestion[CountDTs - 1].Text = chkQuestion.Text;
                    vchkQuestion[CountDTs - 1].Width = chkQuestion.Width;
                    vchkQuestion[CountDTs - 1].Visible = isQuestionable;
                    if (objFilterDetalle != null)
                        vchkQuestion[CountDTs - 1].Checked = objFilterDetalle.Question;
                    vchkQuestion[CountDTs - 1].Enabled = true;
                    PicCel = new HtmlTableCell();
                    PicCel.Controls.Add(vchkQuestion[CountDTs - 1]);

                    //vcmdSearchDetails[CountDTs - 1] = new Button();
                    //vcmdSearchDetails[CountDTs - 1].ID = "cmdDetails" + dr["DTID"].ToString();
                    //vcmdSearchDetails[CountDTs - 1].Text = cmdDetails.Text;
                    //vcmdSearchDetails[CountDTs - 1].Width = cmdDetails.Width;
                    //vcmdSearchDetails[CountDTs - 1].Visible = true;
                    //vcmdSearchDetails[CountDTs - 1].Enabled = true;
                    //vcmdSearchDetails[CountDTs - 1].CommandArgument = dr["DTID"].ToString();
                    //vcmdSearchDetails[CountDTs - 1].CommandName = (CountDTs - 1).ToString();
                    //vcmdSearchDetails[CountDTs - 1].Click += new System.EventHandler(this.cmdDetails_Click);
                    //PicCel.Controls.Add(vcmdSearchDetails[CountDTs - 1]);

                    /*vcmdClearSearchDetails[CountDTs - 1] = new Button();
                    vcmdClearSearchDetails[CountDTs - 1].ID = "cmdClearDetails" + dr["DTID"].ToString();
                    vcmdClearSearchDetails[CountDTs - 1].Text = cmdClearDetails.Text;
                    vcmdClearSearchDetails[CountDTs - 1].Width = cmdClearDetails.Width;
                    vcmdClearSearchDetails[CountDTs - 1].Visible = true;
                    vcmdClearSearchDetails[CountDTs - 1].Enabled = true;
                    vcmdClearSearchDetails[CountDTs - 1].Click += new System.EventHandler(this.cmdClearDetails_Click);
                    PicCel.Controls.Add(vcmdClearSearchDetails[CountDTs - 1]);*/

                    break;
                }
            case TTFunctions.TypeControl.Normal:
                {
                    vlblDTSearch[CountDTs - 1] = new Label();
                    vlblDTSearch[CountDTs - 1].ID = "lblDT" + dr["DTID"].ToString();
                    vlblDTSearch[CountDTs - 1].Text = sDescrption;
                    vlblDTSearch[CountDTs - 1].Width = lblDT.Width;
                    vlblDTSearch[CountDTs - 1].Visible = true;
                    PicCel = new HtmlTableCell();
                    PicCel.Controls.Add(vlblDTSearch[CountDTs - 1]);
                    PicRow.Cells.Add(PicCel);

                    vchkQuestion[CountDTs - 1] = new CheckBox();
                    vchkQuestion[CountDTs - 1].ID = "chkQuestion" + dr["DTID"].ToString();
                    vchkQuestion[CountDTs - 1].Text = chkQuestion.Text;
                    vchkQuestion[CountDTs - 1].Width = chkQuestion.Width;
                    vchkQuestion[CountDTs - 1].Visible = isQuestionable;
                    vchkQuestion[CountDTs - 1].Enabled = true;
                    if (objFilterDetalle != null)
                        vchkQuestion[CountDTs - 1].Checked = objFilterDetalle.Question;
                    PicCel = new HtmlTableCell();
                    PicCel.Controls.Add(vchkQuestion[CountDTs - 1]);

                    if (dr["Dependiente_NombreTabla"].ToString().TrimEnd(' ') != "")
                    {
                        switch (EntryType)
                        {
                            case ControlsLibrary.objectBussinessTTFiltro.TTFiltersAdvancedEntryType.FilterAdvanced:
                            case ControlsLibrary.objectBussinessTTFiltro.TTFiltersAdvancedEntryType.QuickFilter:
                                {
                                    vlstListSearch[CountDTs - 1] = new Telerik.Web.UI.RadComboBox();// new ListBox();
                                    vlstListSearch[CountDTs - 1].ID = "lstDep" + dr["DTID"].ToString();
                                    vlstListSearch[CountDTs - 1].Width = lstDep.Width;
                                    vlstListSearch[CountDTs - 1].Height = lstDep.Height;
                                    //vlstListSearch[CountDTs - 1].SelectionMode = lstDep.SelectionMode;
                                    vlstListSearch[CountDTs - 1].Visible = true;
                                    vlstListSearch[CountDTs - 1].Attributes["DTID"] = dr["DTID"].ToString();
                                    vlstListSearch[CountDTs - 1].EnableLoadOnDemand = true;
                                    //vlstListSearch[CountDTs - 1].MarkFirstMatch = true;
                                    vlstListSearch[CountDTs - 1].AllowCustomText = false;                                    
                                    vlstListSearch[CountDTs - 1].ItemsRequested += new RadComboBoxItemsRequestedEventHandler(RadComboBox_OnItemsRequested);
                                    //vlstListSearch[CountDTs - 1].SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(RadComboBox_SelectedIndexChanged);

                                    PicCel.Controls.Add(vlstListSearch[CountDTs - 1]);
                                    break;
                                }
                            //{
                            //    vcbSearchDep[CountDTs - 1] = new DropDownList();
                            //    vcbSearchDep[CountDTs - 1].ID = "ddlDep" + dr["DTID"].ToString();
                            //    vcbSearchDep[CountDTs - 1].Width = ddlDep.Width;
                            //    vcbSearchDep[CountDTs - 1].Visible = true;
                            //    PicCel.Controls.Add(vcbSearchDep[CountDTs - 1]);
                            //    break;
                            //}
                        }

                        //vcmdSearchDetails[CountDTs - 1] = new Button();
                        //vcmdSearchDetails[CountDTs - 1].ID = "cmdDetails" + dr["DTID"].ToString();
                        //vcmdSearchDetails[CountDTs - 1].Text = cmdDetails.Text;
                        //vcmdSearchDetails[CountDTs - 1].Width = cmdDetails.Width;
                        //vcmdSearchDetails[CountDTs - 1].Visible = true;
                        //vcmdSearchDetails[CountDTs - 1].Enabled = true;
                        //vcmdSearchDetails[CountDTs - 1].CommandArgument = dr["DTID"].ToString(); 
                        //vcmdSearchDetails[CountDTs - 1].CommandName = (CountDTs - 1).ToString();
                        //vcmdSearchDetails[CountDTs - 1].Click += new System.EventHandler(this.cmdDetails_Click);
                        //PicCel.Controls.Add(vcmdSearchDetails[CountDTs - 1]);

                        /*vcmdClearSearchDetails[CountDTs - 1] = new Button();
                        vcmdClearSearchDetails[CountDTs - 1].ID = "cmdClearDetails" + dr["DTID"].ToString();
                        vcmdClearSearchDetails[CountDTs - 1].Text = cmdClearDetails.Text;
                        vcmdClearSearchDetails[CountDTs - 1].Width = cmdClearDetails.Width;
                        vcmdClearSearchDetails[CountDTs - 1].Visible = true;
                        vcmdClearSearchDetails[CountDTs - 1].Enabled = true;
                        vcmdClearSearchDetails[CountDTs - 1].CommandArgument = "lstDep" + dr["DTID"].ToString();
                        vcmdClearSearchDetails[CountDTs - 1].Click += new System.EventHandler(this.cmdClearDetails_Click);
                        PicCel.Controls.Add(vcmdClearSearchDetails[CountDTs - 1]);*/

                        
                        switch (EntryType)
                        {
                            case ControlsLibrary.objectBussinessTTFiltro.TTFiltersAdvancedEntryType.FilterAdvanced:
                            case ControlsLibrary.objectBussinessTTFiltro.TTFiltersAdvancedEntryType.QuickFilter:
                                {
                                    
                                    vlstListSearch[CountDTs - 1].DataTextField = MyFunctions.GenerateName(MyMetadatosDepDesc.Nombre);
                                    vlstListSearch[CountDTs - 1].DataValueField = MyFunctions.GenerateName(MyMetadatosDep.Nombre);
                                    
                                    if (objFilterDetalle != null && objFilterDetalle.Filtro_Dependientes != null)
                                    {
                                        if (objFilterDetalle.Filtro_Dependientes.Length > 0)
                                        {
                                            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                                            SqlCommand com = new SqlCommand("Select " + MyFunctions.GenerateName(MyMetadatosDep.Nombre) + "," + MyFunctions.GenerateName(MyMetadatosDepDesc.Nombre) + " From " + MyFunctions.GenerateName(MyMetadatosDep.NombreTabla));
                                            DataTable dt = db.Consulta(com).Tables[0];
                                            vlstListSearch[CountDTs - 1].DataSource = dt;
                                            vlstListSearch[CountDTs - 1].DataBind();

                                            SetListBoxSelectedItems(vlstListSearch[CountDTs - 1], objFilterDetalle.Filtro_Dependientes);
                                        }
                                    }
                                    break;
                                }
                            //{
                            //    vcbSearchDep[CountDTs - 1].DataSource = dt;
                            //    vcbSearchDep[CountDTs - 1].DataTextField = MyFunctions.GenerateName(MyMetadatosDepDesc.Nombre);
                            //    vcbSearchDep[CountDTs - 1].DataValueField = MyFunctions.GenerateName(MyMetadatosDep.Nombre);
                            //    vcbSearchDep[CountDTs - 1].SelectedValue = null;
                            //    vcbSearchDep[CountDTs - 1].DataBind();
                            //    break;
                            //}
                        }
                    }
                    else
                        switch (dr["Tipo_de_Dato"].ToString())
                        {
                            case "1"://Caracter
                            case "3"://Texto
                            case "4"://Alfanumerico 
                                {
                                    //vcbTextSearch[CountDTs - 1] = new DropDownList();
                                    //vcbTextSearch[CountDTs - 1].ID = "ddlText" + dr["DTID"].ToString();
                                    //vcbTextSearch[CountDTs - 1].Width = ddlText.Width;
                                    //vcbTextSearch[CountDTs - 1].DataSource = Enum.GetValues(typeof(TTClassSpecials.FiltersTypes.TypesTextFilter));
                                    //vcbTextSearch[CountDTs - 1].DataBind();
                                    //if (objFilterDetalle != null)
                                    //    vcbTextSearch[CountDTs - 1].SelectedValue = objFilterDetalle.CondicionTexto.ToString();
                                    //vcbTextSearch[CountDTs - 1].Visible = true;
                                    //PicCel.Controls.Add(vcbTextSearch[CountDTs - 1]);

                                    vtxtTextSearch[CountDTs - 1] = new RadComboBox();
                                    vtxtTextSearch[CountDTs - 1].ID = "txtText" + dr["DTID"].ToString();
                                    vtxtTextSearch[CountDTs - 1].Width = txtText.Width;
                                    vtxtTextSearch[CountDTs - 1].Visible = true;
                                    if (objFilterDetalle != null)
                                        vtxtTextSearch[CountDTs - 1].Text = objFilterDetalle.DesdeTexto;

                                    vtxtTextSearch[CountDTs - 1].Attributes["DTID"] = dr["DTID"].ToString();
                                    vtxtTextSearch[CountDTs - 1].EnableLoadOnDemand = true;
                                    vtxtTextSearch[CountDTs - 1].ItemsRequested += new RadComboBoxItemsRequestedEventHandler(RadComboBoxText_OnItemsRequested);
                                    
                                    PicCel.Controls.Add(vtxtTextSearch[CountDTs - 1]);
                                    break;
                                }
                            case "2"://Numerico
                                {
                                    vlblFromSearch[CountDTs - 1] = new Label();
                                    vlblFromSearch[CountDTs - 1].ID = "lblFrom" + dr["DTID"].ToString();
                                    vlblFromSearch[CountDTs - 1].Text = lblFrom.Text;
                                    vlblFromSearch[CountDTs - 1].Width = lblFrom.Width;
                                    vlblFromSearch[CountDTs - 1].Visible = true;
                                    PicCel.Controls.Add(vlblFromSearch[CountDTs - 1]);

                                    vlblToSearch[CountDTs - 1] = new Label();
                                    vlblToSearch[CountDTs - 1].ID = "lblTo" + dr["DTID"].ToString();
                                    vlblToSearch[CountDTs - 1].Text = lblTo.Text;
                                    vlblToSearch[CountDTs - 1].Width = lblTo.Width;
                                    vlblToSearch[CountDTs - 1].Visible = true;

                                    if (dr["Decimal"] == DBNull.Value || MyFunctions.FormatNumberNull(dr["Decimal"].ToString()) == 0)
                                    {
                                        vtxtFromNumericSearch[CountDTs - 1] = new RadComboBox();
                                        vtxtFromNumericSearch[CountDTs - 1].ID = "txtFromNumeric" + dr["DTID"].ToString();
                                        vtxtFromNumericSearch[CountDTs - 1].Width = txtFromNumeric.Width;
                                        vtxtFromNumericSearch[CountDTs - 1].Visible = true;
                                        vtxtFromNumericSearch[CountDTs - 1].Attributes["DTID"] = dr["DTID"].ToString();
                                        vtxtFromNumericSearch[CountDTs - 1].EnableLoadOnDemand = true;
                                        vtxtFromNumericSearch[CountDTs - 1].AllowCustomText = false;
                                        vtxtFromNumericSearch[CountDTs - 1].ItemsRequested += new RadComboBoxItemsRequestedEventHandler(RadComboBoxText_OnItemsRequested);
                                        if (objFilterDetalle != null)
                                            vtxtFromNumericSearch[CountDTs - 1].Text = objFilterDetalle.DesdeNumerico.ToString();
                                        PicCel.Controls.Add(vtxtFromNumericSearch[CountDTs - 1]);
                                        PicCel.Controls.Add(vlblToSearch[CountDTs - 1]);

                                        vtxtToNumericSearch[CountDTs - 1] = new RadComboBox();
                                        vtxtToNumericSearch[CountDTs - 1].ID = "txtToNumeric" + dr["DTID"].ToString();
                                        vtxtToNumericSearch[CountDTs - 1].Width = txtToNumeric.Width;
                                        vtxtToNumericSearch[CountDTs - 1].Visible = true;
                                        vtxtToNumericSearch[CountDTs - 1].Attributes["DTID"] = dr["DTID"].ToString();
                                        vtxtToNumericSearch[CountDTs - 1].EnableLoadOnDemand = true;
                                        vtxtToNumericSearch[CountDTs - 1].AllowCustomText = false;
                                        vtxtToNumericSearch[CountDTs - 1].ItemsRequested += new RadComboBoxItemsRequestedEventHandler(RadComboBoxText_OnItemsRequested);
                                        if (objFilterDetalle != null)
                                            vtxtToNumericSearch[CountDTs - 1].Text = objFilterDetalle.HastaNumerico.ToString();
                                        PicCel.Controls.Add(vtxtToNumericSearch[CountDTs - 1]);
                                    }
                                    else
                                    {
                                        vtxtFromDecimalSearch[CountDTs - 1] = new RadComboBox();
                                        vtxtFromDecimalSearch[CountDTs - 1].ID = "txtFromDecimal" + dr["DTID"].ToString();
                                        vtxtFromDecimalSearch[CountDTs - 1].Width = txtFromDecimal.Width;
                                        vtxtFromDecimalSearch[CountDTs - 1].Visible = true;
                                        vtxtFromDecimalSearch[CountDTs - 1].Attributes["DTID"] = dr["DTID"].ToString();
                                        vtxtFromDecimalSearch[CountDTs - 1].EnableLoadOnDemand = true;
                                        vtxtFromDecimalSearch[CountDTs - 1].AllowCustomText = false;
                                        vtxtFromDecimalSearch[CountDTs - 1].ItemsRequested += new RadComboBoxItemsRequestedEventHandler(RadComboBoxText_OnItemsRequested);
                                        if (objFilterDetalle != null)
                                            vtxtFromDecimalSearch[CountDTs - 1].Text = objFilterDetalle.DesdeDecimal.ToString();

                                        PicCel.Controls.Add(vtxtFromDecimalSearch[CountDTs - 1]);
                                        PicCel.Controls.Add(vlblToSearch[CountDTs - 1]);

                                        vtxtToDecimalSearch[CountDTs - 1] = new RadComboBox();
                                        vtxtToDecimalSearch[CountDTs - 1].ID = "txtToDecimal" + dr["DTID"].ToString();
                                        vtxtToDecimalSearch[CountDTs - 1].Width = txtToDecimal.Width;
                                        vtxtToDecimalSearch[CountDTs - 1].Visible = true;
                                        vtxtToDecimalSearch[CountDTs - 1].Attributes["DTID"] = dr["DTID"].ToString();
                                        vtxtToDecimalSearch[CountDTs - 1].EnableLoadOnDemand = true;
                                        vtxtToDecimalSearch[CountDTs - 1].AllowCustomText = false;
                                        vtxtToDecimalSearch[CountDTs - 1].ItemsRequested += new RadComboBoxItemsRequestedEventHandler(RadComboBoxText_OnItemsRequested);
                                        if (objFilterDetalle != null)
                                            vtxtToDecimalSearch[CountDTs - 1].Text = objFilterDetalle.HastaDecimal.ToString();

                                        PicCel.Controls.Add(vtxtToDecimalSearch[CountDTs - 1]);
                                    }
                                    break;
                                }
                            case "5"://Moneda
                                {
                                    vlblFromSearch[CountDTs - 1] = new Label();
                                    vlblFromSearch[CountDTs - 1].ID = "lblFrom" + dr["DTID"].ToString();
                                    vlblFromSearch[CountDTs - 1].Text = lblFrom.Text;
                                    vlblFromSearch[CountDTs - 1].Width = lblFrom.Width;
                                    vlblFromSearch[CountDTs - 1].Visible = true;
                                    PicCel.Controls.Add(vlblFromSearch[CountDTs - 1]);

                                    vtxtFromMoneySearch[CountDTs - 1] = new RadComboBox();
                                    vtxtFromMoneySearch[CountDTs - 1].ID = "txtFromMoney" + dr["DTID"].ToString();
                                    vtxtFromMoneySearch[CountDTs - 1].Width = txtFromMoney.Width;
                                    vtxtFromMoneySearch[CountDTs - 1].Visible = true;
                                    vtxtFromMoneySearch[CountDTs - 1].Attributes["DTID"] = dr["DTID"].ToString();
                                    vtxtFromMoneySearch[CountDTs - 1].EnableLoadOnDemand = true;
                                    vtxtFromMoneySearch[CountDTs - 1].AllowCustomText = false;
                                    vtxtFromMoneySearch[CountDTs - 1].ItemsRequested += new RadComboBoxItemsRequestedEventHandler(RadComboBoxText_OnItemsRequested);
                                    if (objFilterDetalle != null)
                                        vtxtFromMoneySearch[CountDTs - 1].Text = objFilterDetalle.DesdeDecimal.ToString();
                                    PicCel.Controls.Add(vtxtFromMoneySearch[CountDTs - 1]);

                                    vlblToSearch[CountDTs - 1] = new Label();
                                    vlblToSearch[CountDTs - 1].ID = "lblTo" + dr["DTID"].ToString();
                                    vlblToSearch[CountDTs - 1].Text = lblTo.Text;
                                    vlblToSearch[CountDTs - 1].Width = lblTo.Width;
                                    vlblToSearch[CountDTs - 1].Visible = true;
                                    PicCel.Controls.Add(vlblToSearch[CountDTs - 1]);

                                    vtxtToMoneySearch[CountDTs - 1] = new RadComboBox();
                                    vtxtToMoneySearch[CountDTs - 1].ID = "txtToMoney" + dr["DTID"].ToString();
                                    vtxtToMoneySearch[CountDTs - 1].Width = txtToMoney.Width;
                                    vtxtToMoneySearch[CountDTs - 1].Visible = true;
                                    vtxtToMoneySearch[CountDTs - 1].Attributes["DTID"] = dr["DTID"].ToString();
                                    vtxtToMoneySearch[CountDTs - 1].EnableLoadOnDemand = true;
                                    vtxtToMoneySearch[CountDTs - 1].AllowCustomText = false;
                                    vtxtToMoneySearch[CountDTs - 1].ItemsRequested += new RadComboBoxItemsRequestedEventHandler(RadComboBoxText_OnItemsRequested);
                                    if (objFilterDetalle != null)
                                        vtxtToMoneySearch[CountDTs - 1].Text = objFilterDetalle.HastaDecimal.ToString();
                                    PicCel.Controls.Add(vtxtToMoneySearch[CountDTs - 1]);

                                    break;
                                }
                            case "10": //FechaHora
                            case "7":  //Fecha
                                {
                                    vlblFromSearch[CountDTs - 1] = new Label();
                                    vlblFromSearch[CountDTs - 1].ID = "lblFrom" + dr["DTID"].ToString();
                                    vlblFromSearch[CountDTs - 1].Text = lblFrom.Text;
                                    vlblFromSearch[CountDTs - 1].Width = lblFrom.Width;
                                    vlblFromSearch[CountDTs - 1].Visible = true;
                                    PicCel.Controls.Add(vlblFromSearch[CountDTs - 1]);

                                    vdtFromDateSearch[CountDTs - 1] = new TextBox();
                                    vdtFromDateSearch[CountDTs - 1].ID = "txtFromDate" + dr["DTID"].ToString();
                                    vdtFromDateSearch[CountDTs - 1].Width = txtFromDate.Width;
                                    vdtFromDateSearch[CountDTs - 1].Visible = true;

                                    vRadFromDate[CountDTs - 1] = new Telerik.Web.UI.RadDatePicker();
                                    vRadFromDate[CountDTs - 1].ID = "radFromDate" + dr["DTID"].ToString();
                                    vRadFromDate[CountDTs - 1].Visible = true;
                                    vRadFromDate[CountDTs - 1].DateInput.DateFormat = "yyyy/MM/dd";

                                    if (objFilterDetalle != null)
                                        if (objFilterDetalle.DesdeDate != null)
                                            vRadFromDate[CountDTs - 1].SelectedDate = objFilterDetalle.DesdeDate;
                                    PicCel.Controls.Add(vRadFromDate[CountDTs - 1]);

                                    vlblToSearch[CountDTs - 1] = new Label();
                                    vlblToSearch[CountDTs - 1].ID = "lblToSearch" + dr["DTID"].ToString();
                                    vlblToSearch[CountDTs - 1].Text = lblTo.Text;
                                    vlblToSearch[CountDTs - 1].Width = lblTo.Width;
                                    vlblToSearch[CountDTs - 1].Visible = true;
                                    PicCel.Controls.Add(vlblToSearch[CountDTs - 1]);

                                    vdtToDateSearch[CountDTs - 1] = new TextBox();
                                    vdtToDateSearch[CountDTs - 1].ID = "txtToDate" + dr["DTID"].ToString();
                                    vdtToDateSearch[CountDTs - 1].Width = txtToDate.Width;
                                    vdtToDateSearch[CountDTs - 1].Visible = true;

                                    vRadToDate[CountDTs - 1] = new Telerik.Web.UI.RadDatePicker();
                                    vRadToDate[CountDTs - 1].ID = "radToDate" + dr["DTID"].ToString();
                                    vRadToDate[CountDTs - 1].Visible = true;
                                    vRadToDate[CountDTs - 1].DateInput.DateFormat = "yyyy/MM/dd";

                                    if (objFilterDetalle != null)
                                        if (objFilterDetalle.HastaDate != null)
                                            vRadToDate[CountDTs - 1].SelectedDate = objFilterDetalle.HastaDate;
                                    PicCel.Controls.Add(vRadToDate[CountDTs - 1]);

                                    break;
                                }
                            case "6": //Logico
                                {
                                    vcbLogicSearch[CountDTs - 1] = new DropDownList();
                                    vcbLogicSearch[CountDTs - 1].ID = "cbLogic" + dr["DTID"].ToString();
                                    vcbLogicSearch[CountDTs - 1].Width = cbLogic.Width;
                                    vcbLogicSearch[CountDTs - 1].Items.Add(cbLogic.Items[0]);
                                    vcbLogicSearch[CountDTs - 1].Items.Add(cbLogic.Items[1]);
                                    vcbLogicSearch[CountDTs - 1].Items.Add(cbLogic.Items[2]);
                                    vcbLogicSearch[CountDTs - 1].Visible = true;

                                    if (objFilterDetalle != null)
                                        if (objFilterDetalle.Si_No != null)
                                            vcbLogicSearch[CountDTs - 1].SelectedValue = objFilterDetalle.Si_No.ToString();

                                    PicCel.Controls.Add(vcbLogicSearch[CountDTs - 1]);
                                    break;
                                }
                            case "8"://Hora
                                {
                                    vlblFromSearch[CountDTs - 1] = new Label();
                                    vlblFromSearch[CountDTs - 1].ID = "lblFrom" + dr["DTID"].ToString();
                                    vlblFromSearch[CountDTs - 1].Text = lblFrom.Text;
                                    vlblFromSearch[CountDTs - 1].Width = lblFrom.Width;
                                    vlblFromSearch[CountDTs - 1].Visible = true;
                                    PicCel.Controls.Add(vlblFromSearch[CountDTs - 1]);

                                    vtxtFromHourSearch[CountDTs - 1] = new TextBox();
                                    vtxtFromHourSearch[CountDTs - 1].ID = "txtFromHour" + dr["DTID"].ToString();
                                    vtxtFromHourSearch[CountDTs - 1].Width = txtFromHour.Width;
                                    vtxtFromHourSearch[CountDTs - 1].Visible = true;
                                    PicCel.Controls.Add(vtxtFromHourSearch[CountDTs - 1]);

                                    vlblToSearch[CountDTs - 1] = new Label();
                                    vlblToSearch[CountDTs - 1].ID = "lblTo" + dr["DTID"].ToString();
                                    vlblToSearch[CountDTs - 1].Text = lblTo.Text;
                                    vlblToSearch[CountDTs - 1].Width = lblTo.Width;
                                    vlblToSearch[CountDTs - 1].Visible = true;
                                    PicCel.Controls.Add(vlblToSearch[CountDTs - 1]);

                                    vtxtToHourSearch[CountDTs - 1] = new TextBox();
                                    vtxtToHourSearch[CountDTs - 1].ID = "txtToHour" + dr["DTID"].ToString();
                                    vtxtToHourSearch[CountDTs - 1].Width = txtToHour.Width;
                                    vtxtToHourSearch[CountDTs - 1].Visible = true;
                                    PicCel.Controls.Add(vtxtToHourSearch[CountDTs - 1]);

                                    break;
                                }
                            case "11"://Color
                                {
                                    break;
                                }
                        }
                    if (dr["IsPermited"].ToString() == "0")
                        PicRow.Visible = false;

                    break;
                }
        }

        HtmlTable tablePanel = (HtmlTable)Funcion.FindControlRecursive(Page, "table" + MyMetadatos.ProcesoId.ToString());
        //Page.FindControl("table" + ProcessId.ToString());

        if (modoConsulta)
        {
            if (objFilterDetalle != null)
            {
                if (objFilterDetalle.Question || isDetail)
                {
                    PicRow.Cells.Add(PicCel);
                    PicCel = new HtmlTableCell();
                    PicRow.Cells.Add(PicCel);
                    //tbl1.Rows.Add(PicRow);
                    tablePanel.Rows.Add(PicRow);
                }
            }
            else
            {
                if (objFilterDetalle == null)
                    objFilterDetalle = new ControlsLibrary.objectBussinessTTFiltro_Detalle();
                objFilterDetalle.Question = IsQuestionable;

                PicRow.Cells.Add(PicCel);
                PicCel = new HtmlTableCell();
                PicRow.Cells.Add(PicCel);
                //tbl1.Rows.Add(PicRow);
                tablePanel.Rows.Add(PicRow);
            }
        }
        else
        {
            PicRow.Cells.Add(PicCel);
            PicCel = new HtmlTableCell();
            PicRow.Cells.Add(PicCel);
            //tbl1.Rows.Add(PicRow);
            tablePanel.Rows.Add(PicRow);
        }
    }

    private void CreateHtmlControls(int TotalControls)
    {
        vlblDTSearch = new Label[TotalControls];
        vlblFromSearch = new Label[TotalControls];
        vlblToSearch = new Label[TotalControls];
        vtxtFromNumericSearch = new RadComboBox[TotalControls];
        vtxtToNumericSearch = new RadComboBox[TotalControls];
        vtxtFromDecimalSearch = new RadComboBox[TotalControls];
        vtxtToDecimalSearch = new RadComboBox[TotalControls];
        vtxtFromMoneySearch = new RadComboBox[TotalControls];
        vtxtToMoneySearch = new RadComboBox[TotalControls];
        vtxtFromHourSearch = new TextBox[TotalControls];
        vtxtToHourSearch = new TextBox[TotalControls];
        vtxtTextSearch = new RadComboBox[TotalControls];
        vdtFromDateSearch = new TextBox[TotalControls];
        vdtToDateSearch = new TextBox[TotalControls];
        vcbLogicSearch = new DropDownList[TotalControls];
        vlstListSearch = new RadComboBox[TotalControls];
        vcbSearchDep = new DropDownList[TotalControls];
        vchkQuestion = new CheckBox[TotalControls];
        vcmdSearchDetails = new Button[TotalControls];
        vcmdClearSearchDetails = new Button[TotalControls];
        //-----------------------------------------------------------
        vRadFromDate = new Telerik.Web.UI.RadDatePicker[TotalControls];
        vRadToDate = new Telerik.Web.UI.RadDatePicker[TotalControls];
    }

    int TotalFilters = 0;
    public ArrayList FilterList = new ArrayList();

    private void GetActiveFilters(ControlsLibrary.objectBussinessTTFiltro objFiltro)
    {
        if (objFiltro.Filtro_Detalle != null)
            foreach (ControlsLibrary.objectBussinessTTFiltro_Detalle objSubFilter in objFiltro.Filtro_Detalle)
            {
                int index = Array.IndexOf(objFiltro.Filtro_Detalle, objSubFilter);
                if (objSubFilter.Question)
                {
                    TotalFilters++;
                    FilterList.Add(new ObjectFilterWithIndexAndProcess(objFiltro, index, (int)objFiltro.ProcesoID));
                    InsertTablePanelByProcessId((int)objFiltro.ProcesoID);
                }
                if (objSubFilter.Filtro_Detalle != null)
                    GetActiveFilters(objSubFilter.Filtro_Detalle);
            }
    }

    private void InsertTablePanelByProcessId(int processId)
    {

        HtmlTableRow PicRow = new HtmlTableRow();
        HtmlTableCell PicCell = new HtmlTableCell();
        HtmlTable tablePanel = new HtmlTable();
        Panel panel;

        panel = (Panel)Funcion.FindControlRecursive(Page, "panel" + processId.ToString());

        if (panel == null)
        {
            panel = new Panel();
            tablePanel.ID = "table" + processId.ToString();
            panel.ID = "panel" + processId.ToString();

            panel.Controls.Add(tablePanel);
            PicCell.Controls.Add(panel);
            PicRow.Controls.Add(PicCell);

            tbl1.Rows.Add(PicRow);
        }
    }

    public class ObjectFilterWithIndexAndProcess
    {
        private ControlsLibrary.objectBussinessTTFiltro objFilter;
        public ControlsLibrary.objectBussinessTTFiltro ObjFilter
        {
            get { return objFilter; }
            set { objFilter = value; }
        }

        private int index, processId, tableIndex;

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        public int ProcessId
        {
            get { return processId; }
            set { processId = value; }
        }

        public int TableIndex
        {
            get { return tableIndex; }
            set { tableIndex = value; }
        }

        public ObjectFilterWithIndexAndProcess()
        {
        }

        public ObjectFilterWithIndexAndProcess(ControlsLibrary.objectBussinessTTFiltro _objFilter, int _index, int _processId)
        {
            this.objFilter = _objFilter;
            this.index = _index;
            this.processId = _processId;
        }
    }

    private void configurationLanguageScreen()
    {
    }

    protected void cmdClearDetails_Click(object sender, EventArgs e)
    {
        Button buttonClear = (Button)sender;
        string idList = buttonClear.CommandArgument;
        ListBox listDetails = (ListBox)tbl1.FindControl(idList);
        if (listDetails != null)
        {
            foreach (ListItem item in listDetails.Items)
                item.Selected = false;
        }
    }

    public void SaveChanges()
    {
        FilterList = (ArrayList)Session["FilterList"];
        MyFilter = (ControlsLibrary.objectBussinessTTFiltro)Session["Filter"];

        foreach (ObjectFilterWithIndexAndProcess item in FilterList)
        {
            if (item.TableIndex <= item.ObjFilter.Filtro_Detalle.Length)
            {
                GetFilterValueFromTable(item.ObjFilter.Filtro_Detalle[item.Index], item.TableIndex - 1);
                SetFiltersByProcessAndIndex(MyFilter, item);
            }
        }
    }

    private void SetFiltersByProcessAndIndex(ControlsLibrary.objectBussinessTTFiltro objFiltro, ObjectFilterWithIndexAndProcess itemFilter)
    {
        if (objFiltro.Filtro_Detalle != null)
            if (objFiltro.ProcesoID == itemFilter.ProcessId)
                objFiltro.Filtro_Detalle[itemFilter.Index] = itemFilter.ObjFilter.Filtro_Detalle[itemFilter.Index];
            else
                foreach (ControlsLibrary.objectBussinessTTFiltro_Detalle objSubFilter in objFiltro.Filtro_Detalle)
                    if (objSubFilter.Filtro_Detalle != null)
                        SetFiltersByProcessAndIndex(objSubFilter.Filtro_Detalle, itemFilter);
    }

    private void GetFilterValueFromTable(ControlsLibrary.objectBussinessTTFiltro_Detalle objFiltro, int pos)
    {
        object tableControl;
        string value;

        objFiltro.DesdeTexto = null;
        objFiltro.HastaTexto = null; 
        objFiltro.Filtro_Dependientes = new ControlsLibrary.objectBussinessTTFiltro_Dependientes[0];

        //tableControl = vcbTextSearch[pos] == null ? null : vcbTextSearch[pos];//objTable.FindControl("TTSearchAdvancedControl1_ddlText" + objFiltro.Dt_Filtro.ToString());
        //if (tableControl != null)
        //{
        //    value = tableControl == null ? null : ((DropDownList)tableControl).SelectedValue;
        //    tableControl = Enum.Parse(typeof(TTClassSpecials.FiltersTypes.TypesTextFilter), value, true);
        //}
        tableControl = vtxtTextSearch[pos] == null ? null : vtxtTextSearch[pos];//objTable.FindControl("TTSearchAdvancedControl1_txtText" + objFiltro.Dt_Filtro.ToString());
        if (tableControl != null)
        {
            objFiltro.CondicionTexto = TTClassSpecials.FiltersTypes.TypesTextFilter.Contenga;
            value = tableControl == null ? null : ((RadComboBox)tableControl).Text;
            objFiltro.DesdeTexto = value;
        }
        tableControl = vtxtFromNumericSearch[pos] == null ? null : vtxtFromNumericSearch[pos];//objTable.FindControl("TTSearchAdvancedControl1_txtFromNumeric" + objFiltro.Dt_Filtro.ToString());
        if (tableControl != null)
        {
            value = tableControl == null ? null : ((RadComboBox)tableControl).Text;
            objFiltro.DesdeNumerico = MyFunctions.FormatNumberNull(value);
        }
        tableControl = vtxtToNumericSearch[pos] == null ? null : vtxtToNumericSearch[pos];//objTable.FindControl("TTSearchAdvancedControl1_txtToNumeric" + objFiltro.Dt_Filtro.ToString());
        if (tableControl != null)
        {
            value = tableControl == null ? null : ((RadComboBox)tableControl).Text;
            objFiltro.HastaNumerico = MyFunctions.FormatNumberNull(value);
        }
        tableControl = vtxtFromDecimalSearch[pos] == null ? null : vtxtFromDecimalSearch[pos];// objTable.FindControl("TTSearchAdvancedControl1_txtFromDecimal" + objFiltro.Dt_Filtro.ToString());
        if (tableControl != null)
        {
            value = tableControl == null ? null : ((RadComboBox)tableControl).Text;
            objFiltro.DesdeDecimal = MyFunctions.FormatNumberNull(value);
        }
        tableControl = vtxtToDecimalSearch[pos] == null ? null : vtxtToDecimalSearch[pos];// objTable.FindControl("TTSearchAdvancedControl1_txtToDecimal" + objFiltro.Dt_Filtro.ToString());
        if (tableControl != null)
        {
            value = tableControl == null ? null : ((RadComboBox)tableControl).Text;
            objFiltro.HastaDecimal = MyFunctions.FormatNumberNull(value);
        }
        //-----------------------------------------------------------------
        tableControl = vtxtFromMoneySearch[pos] == null ? null : vtxtFromMoneySearch[pos];// objTable.FindControl("TTSearchAdvancedControl1_txtFromDecimal" + objFiltro.Dt_Filtro.ToString());
        if (tableControl != null)
        {
            value = tableControl == null ? null : ((RadComboBox)tableControl).Text;
            //objFiltro.DesdeDecimal = MyFunctions.FormatMoneyNull(value);
            decimal fromMoney;
            if (decimal.TryParse(value, out fromMoney))
                objFiltro.DesdeDecimal = fromMoney;  //MyFunctions.FormatMoneyNull(value);
            else
                objFiltro.DesdeDecimal = null;
        }
        tableControl = vtxtToMoneySearch[pos] == null ? null : vtxtToMoneySearch[pos];// objTable.FindControl("TTSearchAdvancedControl1_txtToDecimal" + objFiltro.Dt_Filtro.ToString());
        if (tableControl != null)
        {
            value = tableControl == null ? null : ((RadComboBox)tableControl).Text;
            //objFiltro.HastaDecimal = MyFunctions.FormatMoneyNull(value);
            decimal toMoney;
            if (decimal.TryParse(value, out toMoney))
                objFiltro.HastaDecimal = toMoney; //MyFunctions.FormatMoneyNull(value);
            else
                objFiltro.HastaDecimal = null;
        }
        //-----------------------------------------------------------------
        tableControl = vRadFromDate[pos] == null ? null : vRadFromDate[pos];
        //vdtFromDateSearch[pos] == null ? null : vdtFromDateSearch[pos];// objTable.FindControl("TTSearchAdvancedControl1_txtFromDate" + objFiltro.Dt_Filtro.ToString());
        if (tableControl != null)
        {
            //value = tableControl == null ? null : ((Telerik.Web.UI.RadDatePicker)tableControl).SelectedDate;
            //objFiltro.DesdeDate = MyFunctions.FormatDateNull(value);
            objFiltro.DesdeDate = vRadFromDate[pos].SelectedDate;
        }
        tableControl = vRadToDate[pos] == null ? null : vRadToDate[pos];
        //vdtToDateSearch[pos] == null ? null : vdtToDateSearch[pos];// objTable.FindControl("TTSearchAdvancedControl1_txtToDate" + objFiltro.Dt_Filtro.ToString());
        if (tableControl != null)
        {
            DateTime? dt = null;
            //value = tableControl == null ? null : ((Telerik.Web.UI.RadDatePicker)tableControl).SelectedDate.Value.ToString();
            if (vRadToDate[pos].SelectedDate != null)
                dt = DateTime.ParseExact(vRadToDate[pos].SelectedDate.Value.ToString("yyyy/MM/dd") + "T23:59:59", "yyyy/MM/ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            //objFiltro.HastaDate = MyFunctions.FormatDateNull(value);
            //objFiltro.HastaDate = vRadToDate[pos].SelectedDate;
            objFiltro.HastaDate = dt;
        }
        tableControl = vcbLogicSearch[pos] == null ? null : vcbLogicSearch[pos];// objTable.FindControl("TTSearchAdvancedControl1_cbLogic" + objFiltro.Dt_Filtro.ToString());
        if (tableControl != null)
        {
            value = tableControl == null ? null : ((DropDownList)tableControl).SelectedValue;
            objFiltro.Si_No = MyFunctions.FormatNumberNull(value);
        }
        tableControl = vchkQuestion[pos] == null ? null : vchkQuestion[pos];// objTable.FindControl("TTSearchAdvancedControl1_chkQuestion" + objFiltro.Dt_Filtro.ToString());
        if (tableControl != null)
        {
            objFiltro.Question = tableControl == null ? false : ((CheckBox)tableControl).Checked;
        }
        //------------------------------------------------
        tableControl = vlstListSearch[pos] == null ? null : vlstListSearch[pos];
        if (tableControl != null)
        {
            /*int filterLenght = 0;
            for (int i = 0; i < vlstListSearch[pos].Items.Count; i++)
                if (vlstListSearch[pos].Items[i].Selected)
                    filterLenght++;
            objFiltro.Filtro_Dependientes = new ControlsLibrary.objectBussinessTTFiltro_Dependientes[filterLenght];
            filterLenght = 0;
            for (int i = 0; i < vlstListSearch[pos].Items.Count; i++)
                if (vlstListSearch[pos].Items[i].Selected)
                {
                    objFiltro.Filtro_Dependientes[filterLenght] = new ControlsLibrary.objectBussinessTTFiltro_Dependientes();
                    objFiltro.Filtro_Dependientes[filterLenght].Valor = vlstListSearch[pos].Items[i].Value;
                    objFiltro.Filtro_Dependientes[filterLenght].DT = objFiltro.Dt_Filtro;
                    filterLenght++;
                }*/

            if (vlstListSearch[pos].Text != string.Empty)
            {
                objFiltro.Filtro_Dependientes = new ControlsLibrary.objectBussinessTTFiltro_Dependientes[1];
                objFiltro.Filtro_Dependientes[0] = new ControlsLibrary.objectBussinessTTFiltro_Dependientes();
                objFiltro.Filtro_Dependientes[0].Valor = vlstListSearch[pos].SelectedValue;
                objFiltro.Filtro_Dependientes[0].DT = objFiltro.Dt_Filtro;
            }                            
        }
    }

    private void SetListBoxSelectedItems(ListBox list, ControlsLibrary.objectBussinessTTFiltro_Dependientes[] filtros)
    {
        foreach (ControlsLibrary.objectBussinessTTFiltro_Dependientes filtro in filtros)
        {
            list.Items.FindByValue(filtro.Valor).Selected = true;
        }
    }

    private void SetListBoxSelectedItems(RadComboBox list, ControlsLibrary.objectBussinessTTFiltro_Dependientes[] filtros)
    {
        foreach (ControlsLibrary.objectBussinessTTFiltro_Dependientes filtro in filtros)
        {
          //  list.Text = filtro.Valor;
            list.Items.FindItemByValue(filtro.Valor).Selected = true;
        }
    }

    protected void RadComboBox_OnItemsRequested(object o,RadComboBoxItemsRequestedEventArgs e)
    {
        RadComboBox combo = (RadComboBox)o;
        combo.Items.Clear();
        string dtid = combo.Attributes["DTID"].ToString();
        AutoComplete(dtid, e.Text.Replace("\'", string.Empty), combo);
    }

    protected void RadComboBoxText_OnItemsRequested(object o, RadComboBoxItemsRequestedEventArgs e)
    {
        RadComboBox combo = (RadComboBox)o;
        combo.Items.Clear();
        string dtid = combo.Attributes["DTID"].ToString();
        AutoCompleteTextBox(dtid, e.Text.Replace("\'", string.Empty), combo);
    }        
    
    protected void AutoComplete(string DTID, string Text, Telerik.Web.UI.RadComboBox control)
    {
        TTSecurity.GlobalData globalData = (TTSecurity.GlobalData)Session["UserGlobalInformation"];
        TTMetadata.Metadata meta = new TTMetadata.Metadata(globalData);
        TTMetadata.MetadataDatos dato = meta.GetDatosDT(Convert.ToInt32(DTID));
        string Clave = meta.GetDatosDT(Convert.ToInt32(dato.DependienteClave)).Nombre;
        string Descripcion = meta.GetDatosDT(Convert.ToInt32(dato.DependienteDescripcion)).Nombre;
        string NombreTabla = meta.GetDatosDT(Convert.ToInt32(dato.DependienteDescripcion)).NombreTabla.Replace(" ", "_");

        Clave = MyFunctions.GenerateName(Clave);
        Descripcion = MyFunctions.GenerateName(Descripcion);
        NombreTabla = MyFunctions.GenerateName(NombreTabla);
        
        //string Tabla = data
        string sqlQuery = @"Select Top 25 [{0}],[{1}] from {2}
                          Where ( [{1}] like '%{3}%'
	                        Or [{0}] like '{3}%' )";
        sqlQuery = string.Format(sqlQuery, Clave, Descripcion, NombreTabla, Text.Replace("\'", string.Empty));
        DataSet ds = Funcion.RegresaDataSet(sqlQuery);
        Telerik.Web.UI.RadComboBox comboBox = control;
        comboBox.Items.Clear();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            RadComboBoxItem item = new RadComboBoxItem();
            item.Text = row[1].ToString();
            item.Value = row[0].ToString();

            comboBox.Items.Add(item);
            item.DataBind();
        }

    }

    protected void AutoCompleteTextBox(string DTID, string Text, Telerik.Web.UI.RadComboBox control)
    {
        TTSecurity.GlobalData globalData = (TTSecurity.GlobalData)Session["UserGlobalInformation"];
        TTMetadata.Metadata meta = new TTMetadata.Metadata(globalData);
        TTMetadata.MetadataDatos dato = meta.GetDatosDT(Convert.ToInt32(DTID));
        string Clave = MyFunctions.GenerateName(dato.Nombre);
        string NombreTabla = MyFunctions.GenerateName(dato.NombreTabla).Replace(" ", "_");

        string sqlQuery = @"Select Distinct Top 25 [{0}] from {1}
                          Where ( [{0}] like '%{2}%' )";
        sqlQuery = string.Format(sqlQuery, Clave, NombreTabla, Text.Replace("\'", string.Empty));
        DataSet ds = Funcion.RegresaDataSet(sqlQuery);
        Telerik.Web.UI.RadComboBox comboBox = control;
        comboBox.Items.Clear();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            RadComboBoxItem item = new RadComboBoxItem();
            item.Text = row[0].ToString();
            item.Value = row[0].ToString();

            comboBox.Items.Add(item);
            item.DataBind();
        }
    }
}








