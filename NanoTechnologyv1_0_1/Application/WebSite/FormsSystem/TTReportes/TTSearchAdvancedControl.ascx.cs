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

public partial class TTSearchAdvancedControl : System.Web.UI.UserControl
{
    public enum TTFiltersAdvancedEntryType
    {
        QuickFilter = 1,
        FilterAdvanced = 2
    }
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

    private TTFiltersAdvancedEntryType entryType = TTFiltersAdvancedEntryType.FilterAdvanced;
    public TTFiltersAdvancedEntryType EntryType
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
    private TextBox[] vtxtFromNumericSearch;
    private TextBox[] vtxtToNumericSearch;
    private TextBox[] vtxtFromDecimalSearch;
    private TextBox[] vtxtToDecimalSearch;
    private TextBox[] vtxtFromMoneySearch;
    private TextBox[] vtxtToMoneySearch;
    private TextBox[] vtxtFromHourSearch;
    private TextBox[] vtxtToHourSearch;
    private DropDownList[] vcbTextSearch;
    private TextBox[] vtxtTextSearch;
    //---------------------------------
    private TextBox[] vdtFromDateSearch;
    private TextBox[] vdtToDateSearch;
    private Telerik.Web.UI.RadDatePicker[] vRadFromDate;
    private Telerik.Web.UI.RadDatePicker[] vRadToDate;
    //---------------------------------
    private DropDownList[] vcbLogicSearch;
    private ListBox[] vlstListSearch;
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
    //isQuestionalble /habilita el checkbox para Preguntar
    //imQuestion /Solo muestra los que son questionable
    private Boolean imQuestion = false;
    public Boolean ImQuestion
    {
        get { return imQuestion; }
        set { imQuestion = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }
    public void New(int iProcess)
    {
        ProcessId = iProcess;
        if (EntryType == TTFiltersAdvancedEntryType.FilterAdvanced)
            ShowControls(ProcessId, MyUserData);
        else
            ShowQuickControls(ProcessId, MyUserData);
    }
    private void modification(int? Key)
    {
        idView = Key;
    }

    private void showControls(DataSet ds)
    {
        if (myFilter.Filtro_Detalle == null)
            myFilter.Filtro_Detalle = new ControlsLibrary.objectBussinessTTFiltro_Detalle[ds.Tables[0].Rows.Count];

        if (myFilter.Filtro_Detalle != null)
        {
            if (myFilter.Filtro_Detalle.Length == 0 || myFilter.Filtro_Detalle.Length != ds.Tables[0].Rows.Count)
                myFilter.Filtro_Detalle = new ControlsLibrary.objectBussinessTTFiltro_Detalle[ds.Tables[0].Rows.Count];

            vlblDTSearch = new Label[ds.Tables[0].Rows.Count];
            vlblFromSearch = new Label[ds.Tables[0].Rows.Count];
            vlblToSearch = new Label[ds.Tables[0].Rows.Count];
            vtxtFromNumericSearch = new TextBox[ds.Tables[0].Rows.Count];
            vtxtToNumericSearch = new TextBox[ds.Tables[0].Rows.Count];
            vtxtFromDecimalSearch = new TextBox[ds.Tables[0].Rows.Count];
            vtxtToDecimalSearch = new TextBox[ds.Tables[0].Rows.Count];
            vtxtFromMoneySearch = new TextBox[ds.Tables[0].Rows.Count];
            vtxtToMoneySearch = new TextBox[ds.Tables[0].Rows.Count];
            vtxtFromHourSearch = new TextBox[ds.Tables[0].Rows.Count];
            vtxtToHourSearch = new TextBox[ds.Tables[0].Rows.Count];
            vcbTextSearch = new DropDownList[ds.Tables[0].Rows.Count];
            vtxtTextSearch = new TextBox[ds.Tables[0].Rows.Count];
            vdtFromDateSearch = new TextBox[ds.Tables[0].Rows.Count];
            vdtToDateSearch = new TextBox[ds.Tables[0].Rows.Count];
            vcbLogicSearch = new DropDownList[ds.Tables[0].Rows.Count];
            vlstListSearch = new ListBox[ds.Tables[0].Rows.Count];
            vcbSearchDep = new DropDownList[ds.Tables[0].Rows.Count];
            vchkQuestion = new CheckBox[ds.Tables[0].Rows.Count];
            vcmdSearchDetails = new Button[ds.Tables[0].Rows.Count];
            vcmdClearSearchDetails = new Button[ds.Tables[0].Rows.Count];
            //-----------------------------------------------------------
            vRadFromDate = new Telerik.Web.UI.RadDatePicker[ds.Tables[0].Rows.Count];
            vRadToDate = new Telerik.Web.UI.RadDatePicker[ds.Tables[0].Rows.Count];
            //-----------------------------------------------------------
            CountDTs = 0;
            tbl1.Rows.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (myFilter.Filtro_Detalle[i] != null)
                {
                    DataRow[] drDesc;
                    drDesc = ds.Tables[0].Select("DNTID = '" + myFilter.Filtro_Detalle[i].DNTFiltro + "' and DTID = '" + myFilter.Filtro_Detalle[i].Dt_Filtro + "'");
                    if (drDesc.Length > 0)
                        AddNewRowDTSearch(drDesc[0]);
                    else
                        AddNewRowDTSearch(ds.Tables[0].Rows[i]);
                }
                else
                {
                    myFilter.Filtro_Detalle[i] = new ControlsLibrary.objectBussinessTTFiltro_Detalle();
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

                    AddNewRowDTSearch(ds.Tables[0].Rows[i]);
                    myFilter.Filtro_Detalle[i].DNTFiltro = MyFunctions.FormatNumberNull(ds.Tables[0].Rows[i]["DNTID"]);
                    myFilter.Filtro_Detalle[i].Dt_Filtro = MyFunctions.FormatNumberNull(ds.Tables[0].Rows[i]["DTID"]);
                }
            }

            if (!isDetail)
                Session["Filter"] = myFilter;
            else
            {
                myFilter.ProcesoID = ProcessId;
                Session["Filter" + ProcessId.ToString()] = myFilter;
                ViewState["IsDetail"] = true;
            }
        }
    }
    public void ShowQuickControls(int Process, TTSecurity.GlobalData UserData)
    {
        myFilter.Filtro_Detalle = null;
        EntryType = TTFiltersAdvancedEntryType.QuickFilter;
        ProcessId = Process;
        DataSet ds;
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "spTtMetadata_X_ProcessQuickFilter";
        com.Parameters.AddWithValue("@ProcesoId", ProcessId);
        com.Parameters.AddWithValue("@UserID", UserData.UserID);
        com.Parameters.AddWithValue("@Idioma", UserData.Language.GetHashCode());
        com.CommandType = CommandType.StoredProcedure;
        ds = db.Consulta(com);
        showControls(ds);
    }
    public void ShowControls(int Process, TTSecurity.GlobalData UserData)
    {
        EntryType = TTFiltersAdvancedEntryType.FilterAdvanced;
        ProcessId = Process;
        MyTraductor = new TTTraductor.Traductor(MyUserData.Language.GetHashCode());
        configurationLanguageScreen();
        DataSet ds;
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "spTtMetadata_X_Process";
        com.Parameters.AddWithValue("@ProcesoId", ProcessId);
        com.Parameters.AddWithValue("@UserID", UserData.UserID);
        com.Parameters.AddWithValue("@Idioma", UserData.Language.GetHashCode());
        com.CommandType = CommandType.StoredProcedure;
        ds = db.Consulta(com);
        showControls(ds);
    }
    private void AddNewRowDTSearch(DataRow dr)
    {
        string sDescrption = dr["DescripcionIdioma"].ToString().TrimEnd(' ');
        if (sDescrption == "")
            sDescrption = dr["Descripcion"].ToString().TrimEnd(' ');
        string sNombre = dr["Nombre"].ToString().TrimEnd(' ');
        if (sDescrption == "")
            sDescrption = sNombre;
        sNombre = MyFunctions.GenerateName(sNombre);
        CountDTs++;

        HtmlTableRow PicRow = new HtmlTableRow();
        HtmlTableCell PicCel = new HtmlTableCell();
        PicRow.VAlign = "Middle";

        switch (MyFunctions.ObtenTipoControl(dr["DNTID"].ToString(), dr["DTID"].ToString(), dr["DependienteTabla"].ToString(), dr["DependienteClave"].ToString()))
        {
            case TTFunctions.TypeControl.MultiRenglon:
                {
                    myFilter.Filtro_Detalle[CountDTs - 1].RutaDNTs = myFilter.Filtro_Detalle[CountDTs - 1].RutaDNTs == null ? "" : myFilter.Filtro_Detalle[CountDTs - 1].RutaDNTs;

                    TTMetadata.Metadata MyMeta = new TTMetadata.Metadata(MyUserData);
                    TTMetadata.MetadataDatos MyMetadatos = MyMeta.GetDatosDT(MyFunctions.FormatNumberNull(dr["DTID"].ToString()).Value);
                    TTMetadata.MetadataDatos MyMetadatosDep = MyMeta.GetDatosDT(MyMetadatos.DependienteClave.Value);
                    TTMetadata.MetadataDatos MyMetadatosDepDesc = MyMeta.GetDatosDT(MyMetadatos.DependienteDescripcion.Value);

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
                    if (myFilter.Filtro_Detalle[CountDTs - 1] != null)
                        vchkQuestion[CountDTs - 1].Checked = myFilter.Filtro_Detalle[CountDTs - 1].Question;
                    vchkQuestion[CountDTs - 1].Enabled = true;//!Convert.ToBoolean(dr["Secuencial"]);
                    //vchkQuestion[CountDTs - 1].Tag = CountDTs - 1;
                    PicCel = new HtmlTableCell();
                    PicCel.Controls.Add(vchkQuestion[CountDTs - 1]);

                    vcmdSearchDetails[CountDTs - 1] = new Button();
                    vcmdSearchDetails[CountDTs - 1].ID = "cmdDetails" + dr["DTID"].ToString();
                    vcmdSearchDetails[CountDTs - 1].Text = cmdDetails.Text;
                    vcmdSearchDetails[CountDTs - 1].Width = cmdDetails.Width;
                    vcmdSearchDetails[CountDTs - 1].Visible = true;
                    vcmdSearchDetails[CountDTs - 1].Enabled = true;//!Convert.ToBoolean(dr["Secuencial"]);
                    vcmdSearchDetails[CountDTs - 1].CommandArgument = dr["DTID"].ToString();//MyMetadatosDep.ProcesoId.ToString();
                    vcmdSearchDetails[CountDTs - 1].CommandName = (CountDTs - 1).ToString();
                    //vcmdSearchDetails[CountDTs - 1].Tag = CountDTs - 1;
                    vcmdSearchDetails[CountDTs - 1].Click += new System.EventHandler(this.cmdDetails_Click);

                    vcmdClearSearchDetails[CountDTs - 1] = new Button();
                    vcmdClearSearchDetails[CountDTs - 1].ID = "cmdClearDetails" + dr["DTID"].ToString();
                    vcmdClearSearchDetails[CountDTs - 1].Text = cmdClearDetails.Text;
                    vcmdClearSearchDetails[CountDTs - 1].Width = cmdClearDetails.Width;
                    vcmdClearSearchDetails[CountDTs - 1].Visible = true;
                    vcmdClearSearchDetails[CountDTs - 1].Enabled = true;//!Convert.ToBoolean(dr["Secuencial"]);
                    //vcmdClearSearchDetails[CountDTs - 1].Tag = CountDTs - 1;
                    vcmdClearSearchDetails[CountDTs - 1].Click += new System.EventHandler(this.cmdClearDetails_Click);

                    PicCel.Controls.Add(vcmdSearchDetails[CountDTs - 1]);
                    PicCel.Controls.Add(vcmdClearSearchDetails[CountDTs - 1]);

                    break;
                }
            case TTFunctions.TypeControl.Normal:
                {
                    myFilter.Filtro_Detalle[CountDTs - 1].RutaDNTs = myFilter.Filtro_Detalle[CountDTs - 1].RutaDNTs == null ? "" : myFilter.Filtro_Detalle[CountDTs - 1].RutaDNTs;

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
                    vchkQuestion[CountDTs - 1].Enabled = true;//!Convert.ToBoolean(dr["Secuencial"]);
                    if (myFilter.Filtro_Detalle[CountDTs - 1] != null)
                        vchkQuestion[CountDTs - 1].Checked = myFilter.Filtro_Detalle[CountDTs - 1].Question;
                    //vchkQuestion[CountDTs - 1].Tag = CountDTs - 1;
                    PicCel = new HtmlTableCell();
                    PicCel.Controls.Add(vchkQuestion[CountDTs - 1]);

                    if (dr["Dependiente_NombreTabla"].ToString().TrimEnd(' ') != "")
                    {
                        switch (EntryType)
                        {
                            case TTFiltersAdvancedEntryType.QuickFilter:
                            case TTFiltersAdvancedEntryType.FilterAdvanced:
                                {
                                    vlstListSearch[CountDTs - 1] = new ListBox();
                                    vlstListSearch[CountDTs - 1].ID = "lstDep" + dr["DTID"].ToString();
                                    vlstListSearch[CountDTs - 1].Width = lstDep.Width;
                                    vlstListSearch[CountDTs - 1].Height = lstDep.Height;
                                    vlstListSearch[CountDTs - 1].SelectionMode = lstDep.SelectionMode;
                                    vlstListSearch[CountDTs - 1].Visible = true;
                                    //vlstListSearch[CountDTs - 1].Tag = CountDTs - 1;
                                    PicCel.Controls.Add(vlstListSearch[CountDTs - 1]);
                                    break;
                                }
                            //case TTFiltersAdvancedEntryType.QuickFilter:
                            //    {
                            //        vcbSearchDep[CountDTs - 1] = new DropDownList();
                            //        vcbSearchDep[CountDTs - 1].ID = "ddlDep" + dr["DTID"].ToString();
                            //        vcbSearchDep[CountDTs - 1].Width = ddlDep.Width;
                            //        //vcbSearchDep[CountDTs - 1].DropDownStyle = ComboBoxStyle.DropDownList;
                            //        vcbSearchDep[CountDTs - 1].Visible = true;
                            //        //vcbSearchDep[CountDTs - 1].Tag = CountDTs - 1;
                            //        //vcbSearchDep[CountDTs - 1].KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbLogicSearch_KeyDown);
                            //        PicCel.Controls.Add(vcbSearchDep[CountDTs - 1]);
                            //        break;
                            //    }
                        }

                        TTMetadata.Metadata MyMeta = new TTMetadata.Metadata(MyUserData);
                        TTMetadata.MetadataDatos MyMetadatos = MyMeta.GetDatosDT(MyFunctions.FormatNumberNull(dr["DTID"].ToString()).Value);
                        TTMetadata.MetadataDatos MyMetadatosDep = MyMeta.GetDatosDT(MyMetadatos.DependienteClave.Value);
                        TTMetadata.MetadataDatos MyMetadatosDepDesc = MyMeta.GetDatosDT(MyMetadatos.DependienteDescripcion.Value);

                        vcmdSearchDetails[CountDTs - 1] = new Button();
                        vcmdSearchDetails[CountDTs - 1].ID = "cmdDetails" + dr["DTID"].ToString();
                        vcmdSearchDetails[CountDTs - 1].Text = cmdDetails.Text;
                        vcmdSearchDetails[CountDTs - 1].Width = cmdDetails.Width;
                        vcmdSearchDetails[CountDTs - 1].Visible = true;
                        vcmdSearchDetails[CountDTs - 1].Enabled = true;//!Convert.ToBoolean(dr["Secuencial"]);
                        //vcmdSearchDetails[CountDTs - 1].Tag = CountDTs - 1;
                        vcmdSearchDetails[CountDTs - 1].CommandArgument = dr["DTID"].ToString(); // MyMetadatosDep.ProcesoId.ToString();
                        vcmdSearchDetails[CountDTs - 1].CommandName = (CountDTs - 1).ToString();
                        vcmdSearchDetails[CountDTs - 1].Click += new System.EventHandler(this.cmdDetails_Click);

                        PicCel.Controls.Add(vcmdSearchDetails[CountDTs - 1]);

                        vcmdClearSearchDetails[CountDTs - 1] = new Button();
                        vcmdClearSearchDetails[CountDTs - 1].ID = "cmdClearDetails" + dr["DTID"].ToString();
                        vcmdClearSearchDetails[CountDTs - 1].Text = cmdClearDetails.Text;
                        vcmdClearSearchDetails[CountDTs - 1].Width = cmdClearDetails.Width;
                        vcmdClearSearchDetails[CountDTs - 1].Visible = true;
                        vcmdClearSearchDetails[CountDTs - 1].Enabled = true;//!Convert.ToBoolean(dr["Secuencial"]);
                        vcmdClearSearchDetails[CountDTs - 1].CommandArgument = "lstDep" + dr["DTID"].ToString();
                        //vcmdClearSearchDetails[CountDTs - 1].Tag = CountDTs - 1;
                        vcmdClearSearchDetails[CountDTs - 1].Click += new System.EventHandler(this.cmdClearDetails_Click);
                        PicCel.Controls.Add(vcmdClearSearchDetails[CountDTs - 1]);

                        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                        SqlCommand com = new SqlCommand("Select " + MyFunctions.GenerateName(MyMetadatosDep.Nombre) + "," + MyFunctions.GenerateName(MyMetadatosDepDesc.Nombre) + " From " + MyFunctions.GenerateName(MyMetadatosDep.NombreTabla));
                        DataTable dt = db.Consulta(com).Tables[0];

                        switch (EntryType)
                        {
                            case TTFiltersAdvancedEntryType.QuickFilter:
                                {
                                    vlstListSearch[CountDTs - 1].DataSource = dt;
                                    vlstListSearch[CountDTs - 1].DataTextField = MyFunctions.GenerateName(MyMetadatosDepDesc.Nombre);
                                    vlstListSearch[CountDTs - 1].DataValueField = MyFunctions.GenerateName(MyMetadatosDep.Nombre);
                                    vlstListSearch[CountDTs - 1].DataBind();
                                    break;
                                }
                            case TTFiltersAdvancedEntryType.FilterAdvanced:
                                {
                                    vlstListSearch[CountDTs - 1].DataSource = dt;
                                    vlstListSearch[CountDTs - 1].DataTextField = MyFunctions.GenerateName(MyMetadatosDepDesc.Nombre);
                                    vlstListSearch[CountDTs - 1].DataValueField = MyFunctions.GenerateName(MyMetadatosDep.Nombre);
                                    vlstListSearch[CountDTs - 1].DataBind();
                                    if (MyFilter.Filtro_Detalle[CountDTs - 1] != null && MyFilter.Filtro_Detalle[CountDTs - 1].Filtro_Dependientes != null)
                                        SetListBoxSelectedItems(vlstListSearch[CountDTs - 1], MyFilter.Filtro_Detalle[CountDTs - 1].Filtro_Dependientes);
                                    break;
                                }
                        }
                        //vpicRowSepDTSearch[CountDTs - 1].Tag = TypeControlSearchAdvanced.Dependiente;
                    }
                    else
                        switch (dr["Tipo_de_Dato"].ToString())
                        {
                            case "1"://Caracter
                            case "3"://Texto
                            case "4"://Alfanumerico 
                                {
                                    vcbTextSearch[CountDTs - 1] = new DropDownList();
                                    vcbTextSearch[CountDTs - 1].ID = "ddlText" + dr["DTID"].ToString();
                                    vcbTextSearch[CountDTs - 1].Width = ddlText.Width;
                                    //vcbTextSearch[CountDTs - 1].DropDownStyle = ComboBoxStyle.DropDownList;
                                    //vcbTextSearch[CountDTs - 1].Items.Add(ddlText.Items[0]);
                                    //vcbTextSearch[CountDTs - 1].Items.Add(ddlText.Items[1]);
                                    //vcbTextSearch[CountDTs - 1].Items.Add(ddlText.Items[2]);
                                    //vcbTextSearch[CountDTs - 1].Items.Add(ddlText.Items[3]);
                                    vcbTextSearch[CountDTs - 1].DataSource = Enum.GetValues(typeof(TTClassSpecials.FiltersTypes.TypesTextFilter));
                                    vcbTextSearch[CountDTs - 1].DataBind();
                                    if (MyFilter.Filtro_Detalle[CountDTs - 1] != null)
                                        vcbTextSearch[CountDTs - 1].SelectedValue = MyFilter.Filtro_Detalle[CountDTs - 1].CondicionTexto.ToString();
                                    vcbTextSearch[CountDTs - 1].Visible = true;
                                    //vcbTextSearch[CountDTs - 1].Tag = CountDTs - 1;
                                    //vcbTextSearch[CountDTs - 1].KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbTextSearch_KeyDown);
                                    PicCel.Controls.Add(vcbTextSearch[CountDTs - 1]);

                                    vtxtTextSearch[CountDTs - 1] = new TextBox();
                                    vtxtTextSearch[CountDTs - 1].ID = "txtText" + dr["DTID"].ToString();
                                    vtxtTextSearch[CountDTs - 1].Width = txtText.Width;
                                    vtxtTextSearch[CountDTs - 1].Visible = true;
                                    if (MyFilter.Filtro_Detalle[CountDTs - 1] != null)
                                        vtxtTextSearch[CountDTs - 1].Text = MyFilter.Filtro_Detalle[CountDTs - 1].DesdeTexto;
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
                                        vtxtFromNumericSearch[CountDTs - 1] = new TextBox();
                                        vtxtFromNumericSearch[CountDTs - 1].ID = "txtFromNumeric" + dr["DTID"].ToString();
                                        vtxtFromNumericSearch[CountDTs - 1].Width = txtFromNumeric.Width;
                                        vtxtFromNumericSearch[CountDTs - 1].Visible = true;
                                        if (MyFilter.Filtro_Detalle[CountDTs - 1] != null)
                                            vtxtFromNumericSearch[CountDTs - 1].Text = MyFilter.Filtro_Detalle[CountDTs - 1].DesdeNumerico.ToString();
                                        //vtxtFromNumericSearch[CountDTs - 1].KeyPress += new KeyPressEventHandler(txtFromNumericSearch_KeyPress);
                                        PicCel.Controls.Add(vtxtFromNumericSearch[CountDTs - 1]);
                                        PicCel.Controls.Add(vlblToSearch[CountDTs - 1]);

                                        vtxtToNumericSearch[CountDTs - 1] = new TextBox();
                                        vtxtToNumericSearch[CountDTs - 1].ID = "txtToNumeric" + dr["DTID"].ToString();
                                        vtxtToNumericSearch[CountDTs - 1].Width = txtToNumeric.Width;
                                        vtxtToNumericSearch[CountDTs - 1].Visible = true;
                                        if (MyFilter.Filtro_Detalle[CountDTs - 1] != null)
                                            vtxtToNumericSearch[CountDTs - 1].Text = MyFilter.Filtro_Detalle[CountDTs - 1].HastaNumerico.ToString();
                                        //vtxtToNumericSearch[CountDTs - 1].KeyPress += new KeyPressEventHandler(txtFromNumericSearch_KeyPress);
                                        PicCel.Controls.Add(vtxtToNumericSearch[CountDTs - 1]);
                                    }
                                    else
                                    {
                                        vtxtFromDecimalSearch[CountDTs - 1] = new TextBox();
                                        vtxtFromDecimalSearch[CountDTs - 1].ID = "txtFromDecimal" + dr["DTID"].ToString();
                                        vtxtFromDecimalSearch[CountDTs - 1].Width = txtFromDecimal.Width;
                                        vtxtFromDecimalSearch[CountDTs - 1].Visible = true;
                                        if (MyFilter.Filtro_Detalle[CountDTs - 1] != null)
                                            vtxtFromDecimalSearch[CountDTs - 1].Text = MyFilter.Filtro_Detalle[CountDTs - 1].DesdeDecimal.ToString();

                                        PicCel.Controls.Add(vtxtFromDecimalSearch[CountDTs - 1]);
                                        PicCel.Controls.Add(vlblToSearch[CountDTs - 1]);

                                        vtxtToDecimalSearch[CountDTs - 1] = new TextBox();
                                        vtxtToDecimalSearch[CountDTs - 1].ID = "txtToDecimal" + dr["DTID"].ToString();
                                        vtxtToDecimalSearch[CountDTs - 1].Width = txtToDecimal.Width;
                                        vtxtToDecimalSearch[CountDTs - 1].Visible = true;
                                        if (MyFilter.Filtro_Detalle[CountDTs - 1] != null)
                                            vtxtToDecimalSearch[CountDTs - 1].Text = MyFilter.Filtro_Detalle[CountDTs - 1].HastaDecimal.ToString();

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

                                    vtxtFromMoneySearch[CountDTs - 1] = new TextBox();
                                    vtxtFromMoneySearch[CountDTs - 1].ID = "txtFromMoney" + dr["DTID"].ToString();
                                    vtxtFromMoneySearch[CountDTs - 1].Width = txtFromMoney.Width;
                                    vtxtFromMoneySearch[CountDTs - 1].Visible = true;
                                    if (MyFilter.Filtro_Detalle[CountDTs - 1] != null)
                                        vtxtFromMoneySearch[CountDTs - 1].Text = MyFilter.Filtro_Detalle[CountDTs - 1].DesdeDecimal.ToString();
                                    PicCel.Controls.Add(vtxtFromMoneySearch[CountDTs - 1]);

                                    vlblToSearch[CountDTs - 1] = new Label();
                                    vlblToSearch[CountDTs - 1].ID = "lblTo" + dr["DTID"].ToString();
                                    vlblToSearch[CountDTs - 1].Text = lblTo.Text;
                                    vlblToSearch[CountDTs - 1].Width = lblTo.Width;
                                    vlblToSearch[CountDTs - 1].Visible = true;
                                    PicCel.Controls.Add(vlblToSearch[CountDTs - 1]);

                                    vtxtToMoneySearch[CountDTs - 1] = new TextBox();
                                    vtxtToMoneySearch[CountDTs - 1].ID = "txtToMoney" + dr["DTID"].ToString();
                                    vtxtToMoneySearch[CountDTs - 1].Width = txtToMoney.Width;
                                    vtxtToMoneySearch[CountDTs - 1].Visible = true;
                                    if (MyFilter.Filtro_Detalle[CountDTs - 1] != null)
                                        vtxtToMoneySearch[CountDTs - 1].Text = MyFilter.Filtro_Detalle[CountDTs - 1].HastaDecimal.ToString();
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

                                    if (MyFilter.Filtro_Detalle[CountDTs - 1] != null)
                                        if (MyFilter.Filtro_Detalle[CountDTs - 1].HastaDate != null)
                                            vRadFromDate[CountDTs - 1].SelectedDate = MyFilter.Filtro_Detalle[CountDTs - 1].DesdeDate;
                                    //System.String.Format("{0:MM/dd/yyyy 23:59:59}", MyFilter.Filtro_Detalle[CountDTs - 1].DesdeDate);

                                    //PicCel.Controls.Add(vdtFromDateSearch[CountDTs - 1]);
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

                                    if (MyFilter.Filtro_Detalle[CountDTs - 1] != null)
                                        if (MyFilter.Filtro_Detalle[CountDTs - 1].HastaDate != null)
                                            vRadToDate[CountDTs - 1].SelectedDate = MyFilter.Filtro_Detalle[CountDTs - 1].HastaDate;
                                    //if (vdtToDateSearch[CountDTs - 1]!=null)
                                    //    vdtToDateSearch[CountDTs - 1].Text = System.String.Format("{0:MM/dd/yyyy 23:59:59}", MyFilter.Filtro_Detalle[CountDTs - 1].HastaDate);
                                    //PicCel.Controls.Add(vdtToDateSearch[CountDTs - 1]);
                                    PicCel.Controls.Add(vRadToDate[CountDTs - 1]);

                                    break;
                                }
                            case "6": //Logico
                                {
                                    vcbLogicSearch[CountDTs - 1] = new DropDownList();
                                    vcbLogicSearch[CountDTs - 1].ID = "cbLogic" + dr["DTID"].ToString();
                                    vcbLogicSearch[CountDTs - 1].Width = cbLogic.Width;
                                    //vcbLogicSearch[CountDTs - 1].DropDownStyle = ComboBoxStyle.DropDownList;
                                    //vcbLogicSearch[CountDTs - 1].Items.Add(cbLogic.Items[0]);
                                    //vcbLogicSearch[CountDTs - 1].Items.Add(cbLogic.Items[1]);
                                    //vcbLogicSearch[CountDTs - 1].Items.Add(cbLogic.Items[2]);                                    
                                    vcbLogicSearch[CountDTs - 1].Items.Add(new ListItem(""));
                                    vcbLogicSearch[CountDTs - 1].Items.Add(new ListItem("Si", "1"));
                                    vcbLogicSearch[CountDTs - 1].Items.Add(new ListItem("No", "0"));                                    
                                    vcbLogicSearch[CountDTs - 1].Visible = true;
                                    //vcbLogicSearch[CountDTs - 1].Tag = CountDTs - 1;
                                    //vcbLogicSearch[CountDTs - 1].KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbLogicSearch_KeyDown);

                                    if (MyFilter.Filtro_Detalle[CountDTs - 1] != null)
                                        if (MyFilter.Filtro_Detalle[CountDTs - 1].Si_No != null)
                                            vcbLogicSearch[CountDTs - 1].SelectedValue = MyFilter.Filtro_Detalle[CountDTs - 1].Si_No.ToString();

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
                                    //vcbTextSearch[CountDTs - 1] = new ComboBox();
                                    //vcbTextSearch[CountDTs - 1].Name = "cbTextSearch" + dr["DTID"].ToString();
                                    //vcbTextSearch[CountDTs - 1].Anchor = cbTextSearch.Anchor;
                                    //vcbTextSearch[CountDTs - 1].Location = cbTextSearch.Location;
                                    //vcbTextSearch[CountDTs - 1].Top = txtFromSearch.Top;
                                    //vcbTextSearch[CountDTs - 1].Size = cbTextSearch.Size;
                                    //vcbTextSearch[CountDTs - 1].DropDownStyle = cbTextSearch.DropDownStyle;
                                    //vcbTextSearch[CountDTs - 1].Items.Add(cbTextSearch.Items[0]);
                                    //vcbTextSearch[CountDTs - 1].Items.Add(cbTextSearch.Items[1]);
                                    //vcbTextSearch[CountDTs - 1].Items.Add(cbTextSearch.Items[2]);
                                    //vcbTextSearch[CountDTs - 1].Items.Add(cbTextSearch.Items[3]);
                                    //vcbTextSearch[CountDTs - 1].Visible = true;
                                    //vcbTextSearch[CountDTs - 1].Tag = CountDTs - 1;
                                    //vcbTextSearch[CountDTs - 1].KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbTextSearch_KeyDown);
                                    //vpicRowDTSearch[CountDTs - 1].Controls.Add(vcbTextSearch[CountDTs - 1]);

                                    //vtxtTextSearch[CountDTs - 1] = new TextBox();
                                    //vtxtTextSearch[CountDTs - 1].Name = "txtTextSearch" + dr["DTID"].ToString();
                                    //vtxtTextSearch[CountDTs - 1].Anchor = txtTextSearch.Anchor;
                                    //vtxtTextSearch[CountDTs - 1].Location = txtTextSearch.Location;
                                    //vtxtTextSearch[CountDTs - 1].Top = txtFromSearch.Top;
                                    //vtxtTextSearch[CountDTs - 1].Size = txtTextSearch.Size;
                                    //vtxtTextSearch[CountDTs - 1].Visible = true;
                                    //vpicRowDTSearch[CountDTs - 1].Controls.Add(vtxtTextSearch[CountDTs - 1]);

                                    break;
                                }
                        }
                    if (dr["IsPermited"].ToString() == "0")
                        PicRow.Visible = false;

                    break;
                }
        }

        //if (modoConsulta && myFilter.Filtro_Detalle[CountDTs - 1].Question)

        if (modoConsulta)
        {
            if (myFilter.Filtro_Detalle[CountDTs - 1] != null)
            {
                if (myFilter.Filtro_Detalle[CountDTs - 1].Question || isDetail)
                {
                    PicRow.Cells.Add(PicCel);
                    PicCel = new HtmlTableCell();
                    PicRow.Cells.Add(PicCel);
                    tbl1.Rows.Add(PicRow);
                }
            }
            else
            {
                if (myFilter.Filtro_Detalle[CountDTs - 1] == null)
                    myFilter.Filtro_Detalle[CountDTs - 1] = new ControlsLibrary.objectBussinessTTFiltro_Detalle();
                myFilter.Filtro_Detalle[CountDTs - 1].Question = IsQuestionable;

                PicRow.Cells.Add(PicCel);
                PicCel = new HtmlTableCell();
                PicRow.Cells.Add(PicCel);
                tbl1.Rows.Add(PicRow);
            }
        }
        else
        {
            PicRow.Cells.Add(PicCel);
            PicCel = new HtmlTableCell();
            PicRow.Cells.Add(PicCel);
            tbl1.Rows.Add(PicRow);
        }
    }
    private void configurationLanguageScreen()
    {
    }


    protected void cmdDetails_Click(object sender, EventArgs e)
    {
        Button btnDetails = (Button)sender;

        TTMetadata.Metadata MyMeta = new TTMetadata.Metadata(MyUserData);
        TTMetadata.MetadataDatos MyMetadatos = MyMeta.GetDatosDT(MyFunctions.FormatNumberNull(btnDetails.CommandArgument.ToString()).Value);
        TTMetadata.MetadataDatos MyMetadatosDep = MyMeta.GetDatosDT(MyMetadatos.DependienteClave.Value);
        TTMetadata.MetadataDatos MyMetadatosDepDesc = MyMeta.GetDatosDT(MyMetadatos.DependienteDescripcion.Value);

        int proceso = MyMetadatosDep.ProcesoId == null ? 0 : (int)MyMetadatosDep.ProcesoId;//int.Parse(btnDetails.CommandArgument.ToString());
        int pos = int.Parse(btnDetails.CommandName.ToString());

        if (ViewState["IsDetail"] != null)
            isDetail = (System.Boolean)ViewState["IsDetail"];

        Page.ClientScript.RegisterStartupScript(typeof(Page), "script", "<script language='javascript'>OpenDetailsWindow('" + proceso.ToString() + "', '" + pos.ToString() + "', '" + ProcessId.ToString() + "');</script>");
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
        if (ViewState["IsDetail"] != null)
            isDetail = (System.Boolean)ViewState["IsDetail"];

        if (!isDetail)
            MyFilter = (ControlsLibrary.objectBussinessTTFiltro)Session["Filter"]; //objRep.FiltroId;
        else
            MyFilter = (ControlsLibrary.objectBussinessTTFiltro)Session["Filter" + ProcessId.ToString()];

        for (int i = 0; i < MyFilter.Filtro_Detalle.Length; i++)
            GetFilterValueFromTable(MyFilter.Filtro_Detalle[i], i);

    }

    private void GetFilterValueFromTable(ControlsLibrary.objectBussinessTTFiltro_Detalle objFiltro, int pos)
    {
        object tableControl;
        string value;

        objFiltro.DesdeTexto = null;
        objFiltro.HastaTexto = null;

        tableControl = vcbTextSearch[pos] == null ? null : vcbTextSearch[pos];//objTable.FindControl("TTSearchAdvancedControl1_ddlText" + objFiltro.Dt_Filtro.ToString());
        if (tableControl != null)
        {
            value = tableControl == null ? null : ((DropDownList)tableControl).SelectedValue;
            tableControl = Enum.Parse(typeof(TTClassSpecials.FiltersTypes.TypesTextFilter), value, true);
            objFiltro.CondicionTexto = (TTClassSpecials.FiltersTypes.TypesTextFilter)tableControl;

        }
        tableControl = vtxtTextSearch[pos] == null ? null : vtxtTextSearch[pos];//objTable.FindControl("TTSearchAdvancedControl1_txtText" + objFiltro.Dt_Filtro.ToString());
        if (tableControl != null)
        {
            value = tableControl == null ? null : ((TextBox)tableControl).Text;
            objFiltro.DesdeTexto = value;
        }
        tableControl = vtxtFromNumericSearch[pos] == null ? null : vtxtFromNumericSearch[pos];//objTable.FindControl("TTSearchAdvancedControl1_txtFromNumeric" + objFiltro.Dt_Filtro.ToString());
        if (tableControl != null)
        {
            value = tableControl == null ? null : ((TextBox)tableControl).Text;
            objFiltro.DesdeNumerico = MyFunctions.FormatNumberNull(value);
        }
        tableControl = vtxtToNumericSearch[pos] == null ? null : vtxtToNumericSearch[pos];//objTable.FindControl("TTSearchAdvancedControl1_txtToNumeric" + objFiltro.Dt_Filtro.ToString());
        if (tableControl != null)
        {
            value = tableControl == null ? null : ((TextBox)tableControl).Text;
            objFiltro.HastaNumerico = MyFunctions.FormatNumberNull(value);
        }
        tableControl = vtxtFromDecimalSearch[pos] == null ? null : vtxtFromDecimalSearch[pos];// objTable.FindControl("TTSearchAdvancedControl1_txtFromDecimal" + objFiltro.Dt_Filtro.ToString());
        if (tableControl != null)
        {
            value = tableControl == null ? null : ((TextBox)tableControl).Text;
            objFiltro.DesdeDecimal = MyFunctions.FormatNumberNull(value);
        }
        tableControl = vtxtToDecimalSearch[pos] == null ? null : vtxtToDecimalSearch[pos];// objTable.FindControl("TTSearchAdvancedControl1_txtToDecimal" + objFiltro.Dt_Filtro.ToString());
        if (tableControl != null)
        {
            value = tableControl == null ? null : ((TextBox)tableControl).Text;
            objFiltro.HastaDecimal = MyFunctions.FormatNumberNull(value);
        }
        //-----------------------------------------------------------------
        tableControl = vtxtFromMoneySearch[pos] == null ? null : vtxtFromMoneySearch[pos];// objTable.FindControl("TTSearchAdvancedControl1_txtFromDecimal" + objFiltro.Dt_Filtro.ToString());
        if (tableControl != null)
        {
            value = tableControl == null ? null : ((TextBox)tableControl).Text;
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
            value = tableControl == null ? null : ((TextBox)tableControl).Text;
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
            DateTime? dt = null;
            //value = tableControl == null ? null : ((Telerik.Web.UI.RadDatePicker)tableControl).SelectedDate;
            //objFiltro.DesdeDate = MyFunctions.FormatDateNull(value);
            if (vRadFromDate[pos].SelectedDate != null)
                dt = DateTime.ParseExact(vRadFromDate[pos].SelectedDate.Value.ToString("yyyy/MM/dd") + "T00:00:00", "yyyy/MM/ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            objFiltro.DesdeDate = dt;
        }

        tableControl = vRadToDate[pos] == null ? null : vRadToDate[pos];

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
            int filterLenght = 0;
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
}








