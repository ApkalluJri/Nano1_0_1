using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Telerik.Web.UI;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Web.Script.Services;
using System.Web.Services;
using AjaxControlToolkit;
using System.IO;
using TTReportes;

public partial class FormsSystem_TTReportes_TTReportes_Catalogo : TTBasePage.TTBasePage
{
    #region variables globales
    public int iProcess = 6799;

    public int? idReport;
    public TTReportes.objectBussinessTTReportes objRep = new TTReportes.objectBussinessTTReportes();
    private System.Collections.ArrayList myColumnsFunctions = new System.Collections.ArrayList();
    private System.Collections.ArrayList myColumns = new System.Collections.ArrayList();
    private System.Collections.ArrayList myRows = new System.Collections.ArrayList();
    private List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>> myRowsH = new List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>();
    private List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>> myColumnsH = new List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>();

    private List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>> myRowsFooter = new List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>();
    private List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>> myColumnsFooter = new List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>();

    #endregion

    private List<TTReportes.DockStateWithTemplate> CurrentDockStates
    {
        get
        {
            //Store the info about the added docks in the session. For real life
            // applications we recommend using database or other storage medium
            // for persisting this information.
            List<TTReportes.DockStateWithTemplate> _currentDockStates = (List<TTReportes.DockStateWithTemplate>)Session["CurrentDockStatesDynamicDocks"];
            if (Object.Equals(_currentDockStates, null))
            {
                _currentDockStates = new List<TTReportes.DockStateWithTemplate>();
                Session["CurrentDockStatesDynamicDocks"] = _currentDockStates;
            }
            return _currentDockStates;
        }
        set
        {
            Session["CurrentDockStatesDynamicDocks"] = value;
        }
    }

    private List<string> Matriz
    {
        get
        {
            List<string> _matriz = (List<string>)Session["Matriz"];
            if (Object.Equals(_matriz, null))
            {
                _matriz = new List<string>();
                Session["Matriz"] = _matriz;
            }
            return _matriz;
        }
        set
        {
            Session["Matriz"] = value;
        }
    }

    private List<TTReportes.CeldaHtml> Celdas
    {
        get
        {
            List<TTReportes.CeldaHtml> _Celdas = (List<TTReportes.CeldaHtml>)Session["Celdas"];
            if (Object.Equals(_Celdas, null))
            {
                _Celdas = new List<TTReportes.CeldaHtml>();
                Session["Celdas"] = _Celdas;
            }
            return _Celdas;
        }
        set
        {
            Session["Celdas"] = value;
        }
    }

    private List<KeyValuePair<string, string>> CurrentDockZoneIds
    {
        get
        {
            List<KeyValuePair<string, string>> _currentDockZoneIds = (List<KeyValuePair<string, string>>)Session["CurrentDockZoneIds"];
            if (Object.Equals(_currentDockZoneIds, null))
            {
                _currentDockZoneIds = new List<KeyValuePair<string, string>>();
                Session["CurrentDockZoneIds"] = _currentDockZoneIds;
            }
            return _currentDockZoneIds;
        }
        set
        {
            Session["CurrentDockZoneIds"] = value;
        }
    }

    private List<TTReportes.DockStateWithTemplate> CurrentDockStatesFooter
    {
        get
        {
            //Store the info about the added docks in the session. For real life
            // applications we recommend using database or other storage medium
            // for persisting this information.
            List<TTReportes.DockStateWithTemplate> _currentDockStatesFooter = (List<TTReportes.DockStateWithTemplate>)Session["CurrentDockStatesDynamicDocksFooter"];
            if (Object.Equals(_currentDockStatesFooter, null))
            {
                _currentDockStatesFooter = new List<TTReportes.DockStateWithTemplate>();
                Session["CurrentDockStatesDynamicDocksFooter"] = _currentDockStatesFooter;
            }
            return _currentDockStatesFooter;
        }
        set
        {
            Session["CurrentDockStatesDynamicDocksFooter"] = value;
        }
    }

    private List<string> MatrizFooter
    {
        get
        {
            List<string> _matrizFooter = (List<string>)Session["MatrizFooter"];
            if (Object.Equals(_matrizFooter, null))
            {
                _matrizFooter = new List<string>();
                Session["MatrizFooter"] = _matrizFooter;
            }
            return _matrizFooter;
        }
        set
        {
            Session["MatrizFooter"] = value;
        }
    }

    private List<TTReportes.CeldaHtml> CeldasFooter
    {
        get
        {
            List<TTReportes.CeldaHtml> _CeldasFooter = (List<TTReportes.CeldaHtml>)Session["CeldasFooter"];
            if (Object.Equals(_CeldasFooter, null))
            {
                _CeldasFooter = new List<TTReportes.CeldaHtml>();
                Session["CeldasFooter"] = _CeldasFooter;
            }
            return _CeldasFooter;
        }
        set
        {
            Session["CeldasFooter"] = value;
        }
    }

    private List<KeyValuePair<string, string>> CurrentDockZoneIdsFooter
    {
        get
        {
            List<KeyValuePair<string, string>> _currentDockZoneIdsFooter = (List<KeyValuePair<string, string>>)Session["CurrentDockZoneIdsFooter"];
            if (Object.Equals(_currentDockZoneIdsFooter, null))
            {
                _currentDockZoneIdsFooter = new List<KeyValuePair<string, string>>();
                Session["CurrentDockZoneIdsFooter"] = _currentDockZoneIdsFooter;
            }
            return _currentDockZoneIdsFooter;
        }
        set
        {
            Session["CurrentDockZoneIdsFooter"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Form.Enctype = "multipart/form-data";
        if (Session["UserGlobalInformation"] == null)
            Response.Redirect("~/FormsSystem/Default.aspx");

        Session["Store"] = null;

        if (Request["IdReporte"] != null)
            idReport = int.Parse(Request["IdReporte"].ToString());
        if (!IsPostBack)
        {
            Session["myRows"] = null;
            Session["myColumns"] = null;
            Session["myColumnsFunctions"] = null;
            Session["myRowsH"] = null;
            Session["myColumnsH"] = null;
            Session["myRowsFooter"] = null;
            Session["myColumnsFooter"] = null;
            myColumns.Clear();
            myColumnsFunctions.Clear();
            myRows.Clear();
            myRowsH.Clear();
            myColumnsH.Clear();
            myRowsFooter.Clear();
            myColumnsFooter.Clear();
            fillDataControls();
            if (Session["Tipo_Transaccion"].ToString() == "New")
            {
                LimpiarControles();
                PopulateGrids();
                New();
            }
            else if (Session["Tipo_Transaccion"].ToString() == "Update")
                Modification(idReport);
        }

        string sProceso = ddlProceso.Text == String.Empty ? "0" : ddlProceso.Text;
        //-------------------------------------------------------------------------------------------------------------
        if (Session["Tipo_Transaccion"] == "Consult")
        {
            Panel1.Enabled = false;
            Panel2.Enabled = false;
            btnFilters.Enabled = false;
            btnPreview.Enabled = false;
            BtnSaveCopy.Enabled = false;
            BtnSaveNew.Enabled = false;
            BtnSave.Enabled = false;
            BtnClose.Enabled = true;
            BtnClean.Enabled = false;
            btnReset.Enabled = false;
            Modification(idReport);
        }
    }

    override protected void OnInit(EventArgs e)
    {
        LoadSecurityPage();
        //-------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------
        MyTraductor = new TTTraductor.Traductor(myUserData.Language.GetHashCode());
        objRep.GlobalInformation = myUserData;
        ActualizaGridVision();
        //-------------------------------------------------------------------------------------------------------------
        base.OnInit(e);
    }

    private void fillDataControls()
    {
        MyFunctions.FillDataControl(ddlTipoPresentacion, objRep.FillDataTipoPresentacionDS());
        cbIdModulo_DataBound();
    }

    protected void btnSelProcess_Click()
    {
        //----------------------------------------------------------------------------------------------------
        WSTTProceso.objectBussinessTTProceso1 dsTemp;
        if (ddlProceso.Text != "")
        {
            WSTTProceso.objectBussinessTTProceso MyDataTTProceso = new WSTTProceso.objectBussinessTTProceso();
            if (MyFunctions.FormatNumberNull(ddlProceso.Text) != null)
            {
                dsTemp = MyDataTTProceso.GetByKey(MyFunctions.FormatNumberNull(ddlProceso.Text), true);
                if (dsTemp.Nombre != null)
                {
                    lblProcesoDesc.Text = dsTemp.Nombre;
                    FillTreeView();
                }
                else
                    lblProcesoDesc.Text = "";
            }
            else
                lblProcesoDesc.Text = "";
        }
        else
            lblProcesoDesc.Text = "";
        //----------------------------------------------------------------------------------------------------
    }

    private void FillTreeView()
    {
        int? idProceso = MyFunctions.FormatNumberNull(ddlProceso.Text);
        TTMetadata.Metadata myMeta = new TTMetadata.Metadata(myUserData);
        TTMetadata.MetadataDatosDNT[] myDNTs = myMeta.GetAllDNTs(idProceso.Value);
        RadTreeView1.Nodes.Clear();
        foreach (TTMetadata.MetadataDatosDNT dnt in myDNTs)
        {
            Telerik.Web.UI.RadTreeNode node = new Telerik.Web.UI.RadTreeNode(dnt.Descripcion, dnt.DNTID.ToString());
            FillTreeViewChild(ref node, dnt.DNTID.ToString(), dnt.DNTID, null);
            RadTreeView1.Nodes.Add(node);

            MyFunctions.FillDataControl(ddlStoreRelationDT, objRep.FillDataStoreRelationDTDS(dnt.DNTID.Value));
        }
        if (myFilter != null)
        {
            if (myFilter.ProcesoID != idProceso.Value)
            {
                myFilter = new ControlsLibrary.objectBussinessTTFiltro();
                myFilter.GlobalInformation = myUserData;
                Session["Filter"] = myFilter;
            }
            else
                myFilter.GlobalInformation = myUserData;
        }
        //RadTreeView1.ExpandAllNodes();
    }

    private void FillTreeViewChild(ref Telerik.Web.UI.RadTreeNode treeDNTs, String nodeParent, int? dntid, int? dntFather)
    {
        TTMetadata.Metadata myMeta = new TTMetadata.Metadata(myUserData);
        TTMetadata.MetadataDatos[] myDTs = myMeta.GetDatosDNT(dntid.Value);
        foreach (TTMetadata.MetadataDatos dt in myDTs)
        {
            bool DTMultiRenglonLlaveDependiente = false;
            if (dt.Dependiente && dt.Identificador)
                DTMultiRenglonLlaveDependiente = true;

            if (!DTMultiRenglonLlaveDependiente)
            {
                Telerik.Web.UI.RadTreeNode childnode = new Telerik.Web.UI.RadTreeNode(dt.Descripcion, nodeParent + "." + dt.DatoID.ToString());

                treeDNTs.Nodes.Add(childnode);
                bool yaestaba = false;
                foreach (string valor in nodeParent.Split('.'))
                {
                    if (valor == dt.DatoID.ToString())
                    {
                        yaestaba = true;
                        break;
                    }
                }
                //if (dt.Dependiente && dt.DependienteTabla != dntFather && !yaestaba)//Si es multirenglon evitar el ciclo
                if (dt.Dependiente && !yaestaba)
                    FillTreeViewChild(ref childnode, nodeParent + "." + dt.DatoID.ToString(), dt.DependienteTabla, dt.DNTID);
            }
        }
    }


    public void New()
    {
        Session["objRep"] = null;
        Session["Filter"] = null;
    }

    protected void ddlTipoPresentacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTipoPresentacion.SelectedValue != string.Empty)
        {
            int? key = MyFunctions.FormatNumberNull(ddlTipoPresentacion.SelectedValue.ToString()).Value;
            DataSet ds = objRep.FillDataSubtipoPresentacionDS(int.Parse(key.ToString()));
            MyFunctions.FillDataControl(ddlSubTipoPresentacion, ds);
        }
    }

    public void Modification(int? Key)
    {
        objRep = new TTReportes.objectBussinessTTReportes();
        objRep.GlobalInformation = myUserData;
        objRep.GetByKey(Key, true);

        Session["objRep"] = objRep;
        Session["Filter"] = objRep.FiltroId;

        txtFolio.Text = objRep.idReporte.ToString();
        TxtNombre.Text = objRep.Nombre;
        ddlProceso.Text = objRep.ProcesoId.ToString();
        cbIdModulo.SelectedValue = Funcion.RegresaDato(String.Format("select IdModulo from dbo.TTProceso_del_Modulo where IdProceso = {0}", objRep.ProcesoId.ToString()));

        btnSelProcess_Click();

        if (Session["Filter"] != null)
        {
            myFilter = (ControlsLibrary.objectBussinessTTFiltro)Session["Filter"];
        }
        else
        {
            myFilter = objRep.FiltroId;
            myFilter.ProcesoID = MyFunctions.FormatNumberNull(ddlProceso.Text);
        }
        if (objRep.TipoPresentacion != null)
        {
            MyFunctions.SetComboControl(ref ddlTipoPresentacion, objRep.TipoPresentacion);
            ddlTipoPresentacion_SelectedIndexChanged(ddlTipoPresentacion, new EventArgs());
        }
        if (objRep.SubtipoPresentacion != TTReportes.TTReportsConfigurationsEnumSubPresentation.None)
            MyFunctions.SetComboControl(ref ddlSubTipoPresentacion, objRep.SubtipoPresentacion.GetHashCode());
        chkDistinct.Checked = objRep.Distinct;
        if (objRep.TopList != null)
            txtTop.Text = MyFunctions.FormatNumberNull(objRep.TopList.Value.ToString()) < 0 ? "0" : objRep.TopList.Value.ToString();
        //txtTop.Text = objRep.TopList.Value.ToString();
        else
            txtTop.Text = "0";
        txtProcedimientoAlmacenado.Text = objRep.StoreProcedure;
        //Application.DoEvents();
        if (objRep.StoreRelationDT != null)
            MyFunctions.SetComboControl(ref ddlStoreRelationDT, objRep.StoreRelationDT);
        MyFunctions.SetComboControl(ref ddlGrupoReporte, objRep.IdGrupoReporte);

        if (objRep.TotalesColumna != null)
            chkTotalColumna.Checked = objRep.TotalesColumna.Value;
        if (objRep.TotalesRenglon != null)
            chkTotalRenglon.Checked = objRep.TotalesRenglon.Value;
        if (objRep.Contador != null)
            chkContador.Checked = objRep.Contador.Value;

        if (objRep.ColumnasId != null)
            for (int i = 0; i < objRep.ColumnasId.Length; i++)
            {
                TTReportes.TTReportsConfigurationsColumns myCol = new TTReportes.TTReportsConfigurationsColumns();
                myCol.FullPath = objRep.ColumnasId[i].FullPath;
                myCol.FullPathDT = objRep.ColumnasId[i].FullPathDT;
                myCol.Text = objRep.ColumnasId[i].Text;
                myCol.Function = objRep.ColumnasId[i].Funciones;
                myCol.SubTotal = objRep.ColumnasId[i].Subtotal;
                myCol.Total = objRep.ColumnasId[i].Total;
                myCol.Minimo_Alerta = objRep.ColumnasId[i].Minimo_Alerta;
                myCol.Maximo_Alerta = objRep.ColumnasId[i].Maximo_Alerta;
                myCol.Mostrar_Vacios = objRep.ColumnasId[i].Mostrar_Vacios;
                myCol.Format = objRep.ColumnasId[i].Format;
                myCol.OrderBy = objRep.ColumnasId[i].OrderBy;
                myCol.Rango = objRep.ColumnasId[i].Rango;
                myColumns.Add(myCol);
            }
        if (objRep.FilasId != null)
            for (int i = 0; i < objRep.FilasId.Length; i++)
            {
                TTReportes.TTReportsConfigurationsRows myRow = new TTReportes.TTReportsConfigurationsRows();
                myRow.FullPath = objRep.FilasId[i].FullPath;
                myRow.FullPathDT = objRep.FilasId[i].FullPathDT;
                myRow.Text = objRep.FilasId[i].Text;
                myRow.Format = objRep.FilasId[i].Format;
                myRow.OrderBy = objRep.FilasId[i].OrderBy;
                myRow.Rango = objRep.FilasId[i].Rango;
                myRows.Add(myRow);
            }
        if (objRep.FuncionesId != null)
            for (int i = 0; i < objRep.FuncionesId.Length; i++)
            {
                TTReportes.TTReportsConfigurationsFunctions myColF = new TTReportes.TTReportsConfigurationsFunctions();
                myColF.FullPath = objRep.FuncionesId[i].FullPath;
                myColF.FullPathDT = objRep.FuncionesId[i].FullPathDT;
                myColF.Text = objRep.FuncionesId[i].Text;
                myColF.Function = objRep.FuncionesId[i].Funcion;
                myColF.Minimo_Alerta = objRep.FuncionesId[i].Minimo_Alerta;
                myColF.Maximo_Alerta = objRep.FuncionesId[i].Maximo_Alerta;
                myColF.Mostrar_Vacios = objRep.FuncionesId[i].Mostrar_Vacios;
                myColF.Format = objRep.FuncionesId[i].Format;
                myColF.OrderBy = objRep.FuncionesId[i].OrderBy;
                myColumnsFunctions.Add(myColF);
            }

        if (objRep.MatrizHeader.Count > 0)
        {
            btnBorrarFila_Click(null, null);
        }

        if (objRep.FilasHeader != null)
            for (int i = 0; i < objRep.FilasHeader.Count; i++)
            {
                TTReportes.TTReportsConfigurationscells myFilaH = new TTReportes.TTReportsConfigurationscells();
                myFilaH.CM = objRep.FilasHeader[i].Value.CM;
                myRowsH.Add(new KeyValuePair<string, TTReportes.TTReportsConfigurationscells>(objRep.FilasHeader[i].Key, myFilaH));
            }

        if (objRep.ColumnasHeader != null)
            for (int i = 0; i < objRep.ColumnasHeader.Count; i++)
            {
                TTReportes.TTReportsConfigurationscells myColumnaH = new TTReportes.TTReportsConfigurationscells();
                myColumnaH.CM = objRep.ColumnasHeader[i].Value.CM;
                myColumnsH.Add(new KeyValuePair<string, TTReportes.TTReportsConfigurationscells>(objRep.ColumnasHeader[i].Key, myColumnaH));
            }

        if (objRep.MatrizHeader.Count > 0)
        {
            Matriz.Clear();
            if (objRep.MatrizHeader != null)
                for (int i = 0; i < objRep.MatrizHeader.Count; i++)
                    Matriz.Add(objRep.MatrizHeader[i]);

            Celdas.Clear();
            if (objRep.CeldasHeader != null)
                for (int i = 0; i < objRep.CeldasHeader.Count; i++)
                    Celdas.Add(objRep.CeldasHeader[i]);

            CurrentDockZoneIds.Clear();
            if (objRep.ZonesHeader != null)
                for (int i = 0; i < objRep.ZonesHeader.Count; i++)
                    CurrentDockZoneIds.Add(objRep.ZonesHeader[i]);

            CurrentDockStates.Clear();
            if (objRep.DocksHeader != null)
                for (int i = 0; i < objRep.DocksHeader.Count; i++)
                    CurrentDockStates.Add(objRep.DocksHeader[i]);
            ActualizaHeader();
        }

        if (objRep.MatrizFooter.Count > 0)
        {
            btnBorrarFilaFooter_Click(null, null);
        }

        if (objRep.FilasFooter != null)
            for (int i = 0; i < objRep.FilasFooter.Count; i++)
            {
                TTReportes.TTReportsConfigurationscells myFilaFooter = new TTReportes.TTReportsConfigurationscells();
                myFilaFooter.CM = objRep.FilasFooter[i].Value.CM;
                myRowsFooter.Add(new KeyValuePair<string, TTReportes.TTReportsConfigurationscells>(objRep.FilasFooter[i].Key, myFilaFooter));
            }

        if (objRep.ColumnasFooter != null)
            for (int i = 0; i < objRep.ColumnasFooter.Count; i++)
            {
                TTReportes.TTReportsConfigurationscells myColumnaFooter = new TTReportes.TTReportsConfigurationscells();
                myColumnaFooter.CM = objRep.ColumnasFooter[i].Value.CM;
                myColumnsFooter.Add(new KeyValuePair<string, TTReportes.TTReportsConfigurationscells>(objRep.ColumnasFooter[i].Key, myColumnaFooter));
            }

        if (objRep.MatrizFooter.Count > 0)
        {
            MatrizFooter.Clear();
            if (objRep.MatrizFooter != null)
                for (int i = 0; i < objRep.MatrizFooter.Count; i++)
                    MatrizFooter.Add(objRep.MatrizFooter[i]);

            CeldasFooter.Clear();
            if (objRep.CeldasFooter != null)
                for (int i = 0; i < objRep.CeldasFooter.Count; i++)
                    CeldasFooter.Add(objRep.CeldasFooter[i]);

            CurrentDockZoneIdsFooter.Clear();
            if (objRep.ZonesFooter != null)
                for (int i = 0; i < objRep.ZonesFooter.Count; i++)
                    CurrentDockZoneIdsFooter.Add(objRep.ZonesFooter[i]);

            CurrentDockStatesFooter.Clear();
            if (objRep.DocksFooter != null)
                for (int i = 0; i < objRep.DocksFooter.Count; i++)
                    CurrentDockStatesFooter.Add(objRep.DocksFooter[i]);

            ActualizaFooter();
        }

        btnPreview.Visible = true;
        Session["myRows"] = myRows;
        Session["myColumns"] = myColumns;
        Session["myColumnsFunctions"] = myColumnsFunctions;
        Session["myRowsH"] = myRowsH;
        Session["myColumnsH"] = myColumnsH;
        Session["myRowsFooter"] = myRowsFooter;
        Session["myColumnsFooter"] = myColumnsFooter;
        ActualizaGridVision();
    }

    private void ActualizaGridVision()
    {
        int xPos = -1;
        int yPos = -1;

        TTReportes.TTReportsConfigurationsFunctions dColFun;
        TTReportes.TTReportsConfigurationsColumns dCol;
        TTReportes.TTReportsConfigurationsRows dRow;

        myRows = Session["myRows"] == null ? new ArrayList() : (ArrayList)Session["myRows"];
        myColumns = Session["myColumns"] == null ? new ArrayList() : (ArrayList)Session["myColumns"];
        myColumnsFunctions = Session["myColumnsFunctions"] == null ? new ArrayList() : (ArrayList)Session["myColumnsFunctions"];

        int y = 0;
        int x = 0;
        y = myRows.Count + 1;
        if (y < 2) y = 2;
        x = myColumns.Count + 1;
        if (x < 2) x = 2;
        dgReport.Rows.Clear();
        for (int i = 0; i < y; i++)
        {
            HtmlTableRow picRow = new HtmlTableRow();
            for (int o = 0; o < x; o++)
            {
                HtmlTableCell piCell = new HtmlTableCell();
                picRow.Cells.Add(piCell);
            }
            dgReport.Rows.Add(picRow);
        }
        x = 1; y = 1;

        for (int i = 0; i < myColumns.Count; i++)
        {
            dCol = ((TTReportes.TTReportsConfigurationsColumns)myColumns[i]);
            Button btn = new Button();
            btn.Visible = true;
            btn.CausesValidation = false;
            btn.CommandName = "myColumns";
            btn.CommandArgument = i.ToString();
            btn.OnClientClick = "OpenPropertyWindow('" + btn.CommandName + "', '" + btn.CommandArgument + "');";
            btn.Attributes.Add("Style", "color:Black;background-color:#D0D0D0;border-style:None;font-size:X-Small;font-weight:normal;text-decoration:none;width:100%;");

            if (dCol.Function != TTReportes.TTReportsConfigurationsEnumfunctions.None)
                btn.Text = dCol.Function.ToString() + "(" + dCol.Text + ")";
            else
                btn.Text = dCol.Text;
            dgReport.Rows[0].Cells[i + 1].Controls.Add(btn);
        }
        for (int i = 0; i < myRows.Count; i++)
        {
            dRow = ((TTReportes.TTReportsConfigurationsRows)myRows[i]);
            Button btn = new Button();
            btn.Visible = true;
            btn.CausesValidation = false;
            btn.CommandName = "myRows";
            btn.CommandArgument = i.ToString();
            btn.OnClientClick = "OpenPropertyWindow('" + btn.CommandName + "', '" + btn.CommandArgument + "');";
            btn.Attributes.Add("Style", "color:Black;background-color:#F0F0F0;border-style:None;font-size:X-Small;font-weight:normal;text-decoration:none;width:100%;");
            btn.Text = dRow.Text;
            dgReport.Rows[i + 1].Cells[0].Controls.Add(btn);
        }

        for (int i = 0; i < myColumnsFunctions.Count; i++)
        {
            dColFun = ((TTReportes.TTReportsConfigurationsFunctions)myColumnsFunctions[i]);
            if (x == dgReport.Rows[0].Cells.Count)
            {
                x = 1;
                y++;
                if (y == dgReport.Rows.Count)
                {
                    HtmlTableRow picRow = new HtmlTableRow();
                    for (int o = 0; o < dgReport.Rows[0].Cells.Count; o++)
                    {
                        HtmlTableCell picCell = new HtmlTableCell();
                        picRow.Cells.Add(picCell);
                    }
                    dgReport.Rows.Add(picRow);
                }
            }

            Button btn = new Button();
            btn.Visible = true;
            btn.CausesValidation = false;
            btn.CommandName = "myColumnsFunctions";
            btn.CommandArgument = i.ToString();
            btn.OnClientClick = "OpenPropertyWindow('" + btn.CommandName + "', '" + btn.CommandArgument + "');";
            btn.Attributes.Add("Style", "color:Black;background-color:#B0B0B0;border-style:None;font-size:X-Small;font-weight:normal;text-decoration:none;width:100%;");

            if (dColFun.Function != TTReportes.TTReportsConfigurationsEnumfunctions.None)
                btn.Text = dColFun.Function.ToString() + "(" + dColFun.Text + ")";
            else
                btn.Text = dColFun.Text;
            dgReport.Rows[y].Cells[x].Controls.Add(btn);
            x++;
        }
        dgReport.Rows[0].Cells[0].InnerText = "";

        if (myRows.Count == 0)
            dgReport.Rows[1].Cells[0].InnerText = MyTraductor.getMessage(56);
        if (myColumns.Count == 0)
        {
            dgReport.Rows[0].Cells[1].InnerText = MyTraductor.getMessage(57);
        }
        if (yPos > -1 && xPos > -1)
        {
        }
    }

    protected void btnPreview_Click(object sender, EventArgs e)
    {
        if (txtFolio.Text != "")
        {
            if (MyFunctions.FormatNumberNull(txtFolio.Text) != null)
            {
                try
                {
                    int idReport = (int)MyFunctions.FormatNumberNull(txtFolio.Text);
                    TTControlRepPreview.CallShowReport(idReport);
                    radTabStrip.SelectedIndex = radMultiPage.SelectedIndex = 1;
                }
                catch (Exception ex)
                {
                    ShowAlert(ex.Message.ToString());
                }

            }
        }
    }

    protected void cmdNew_Click(object sender, EventArgs e)
    {
        New();
    }

    protected void BindGridsWithSessionData()
    {

    }

    private void ConfigWithMetadata()
    {
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (Save())
        {
            ShowAlert("Datos Guardados Correctamente.");
        }
    }
    protected void BtnSaveNew_Click(object sender, EventArgs e)
    {
        if (Save())
        {
            Session["myRows"] = null;
            Session["myColumns"] = null;
            Session["myColumnsFunctions"] = null;
            ShowAlert("Datos Guardados Exitosamente");
        }
        LimpiarControles();
    }
    protected void BtnSaveCopy_Click(object sender, EventArgs e)
    {
        if (Save())
        {
            ShowAlert("Datos Guardados Exitosamente, Folio : " + objRep.idReporte.Value);

            objRep.idReporte = null;
            txtFolio.Text = string.Empty;
            objRep.Nombre = string.Empty;
            TxtNombre.Text = string.Empty;
            Session["objRep"] = objRep;
        }
    }

    protected void BtnClose_Click(object sender, EventArgs e)
    {
        Session["myRows"] = null;
        Session["myColumns"] = null;
        Session["myColumnsFunctions"] = null;
        Session["myRowsH"] = null;
        Session["myColumnsH"] = null;
        Matriz = null;
        Celdas = null;
        CurrentDockZoneIds = null;
        CurrentDockStates = null;
        Response.Redirect("TTReportes_Lista.aspx");
    }
    protected void BtnClean_Click(object sender, EventArgs e)
    {
        Session["myRows"] = null;
        Session["myColumns"] = null;
        Session["myColumnsFunctions"] = null;

        LimpiarControles();
    }
    protected void LimpiarControles()
    {
        lblProcesoDesc.Text = "";
        ddlGrupoReporte.SelectedIndex = 0;
        cbIdModulo.SelectedIndex = 0;
        txtFolio.Text = "";
        ddlProceso.Text = "";
        TxtNombre.Text = "";
        ddlTipoPresentacion.SelectedIndex = 0;
        ddlSubTipoPresentacion.SelectedIndex = 0;
        txtProcedimientoAlmacenado.Text = "";
        ddlStoreRelationDT.SelectedIndex = 0;
        chkDistinct.Checked = false;
        txtTop.Text = "0";

        chkTotalColumna.Checked = false;
        chkTotalRenglon.Checked = false;
        chkContador.Checked = false;

        RadGCenter.DataSource = "";
        RadGCenter.DataBind();
        RadGColumns.DataSource = "";
        RadGColumns.DataBind();
        RadGRows.DataSource = "";
        RadGRows.DataBind();
        RadTreeView1.DataSource = "";
        RadTreeView1.DataBind();
        ActualizaGridVision();
    }

    protected void RadTreeView1_HandleDrop(object sender, RadTreeNodeDragDropEventArgs e)
    {
        RadTreeNode sourceNode = e.SourceDragNode;
        RadTreeNode destNode = e.DestDragNode;
        RadTreeViewDropPosition dropPosition = e.DropPosition;

        if (destNode != null) //drag&drop is performed between trees
        {
            if (sourceNode.TreeView.SelectedNodes.Count <= 1)
            {
                if (!sourceNode.IsAncestorOf(destNode))
                {
                    sourceNode.Owner.Nodes.Remove(sourceNode);
                    destNode.Nodes.Add(sourceNode);
                }
            }
            else if (sourceNode.TreeView.SelectedNodes.Count > 1)
            {
                foreach (RadTreeNode node in RadTreeView1.SelectedNodes)
                {
                    if (!node.IsAncestorOf(destNode))
                    {
                        node.Owner.Nodes.Remove(node);
                        destNode.Nodes.Add(node);
                    }
                }
            }
            //}

            destNode.Expanded = true;
            sourceNode.TreeView.ClearSelectedNodes();
        }
        else
        {
            foreach (RadTreeNode node in e.DraggedNodes)
            {
                AddRowToGrid(node, e.HtmlElementID);
            }
        }
    }

    private void PopulateGrids()
    {
        string[] values = { "" };

        DataTable dt = new DataTable();
        dt.Columns.Add("");
        dt.Rows.Add(values);
        //-------------------------
        ViewState["TableCenter"] = dt;
        RadGCenter.DataSource = dt;
        RadGCenter.DataBind();
        //-------------------------
        ViewState["TableRows"] = dt;
        RadGRows.DataSource = dt;
        RadGRows.DataBind();
        //-------------------------
        ViewState["TableColumns"] = dt;
        RadGColumns.DataSource = dt;
        RadGColumns.DataBind();

    }

    private TTReportes.TTReportsConfigurationsEnumFormatDate formatDataType(String dtRoot)
    {
        dtRoot = dtRoot.Substring(dtRoot.LastIndexOf(".") + 1);
        TTMetadata.Metadata myMeta = new TTMetadata.Metadata(myUserData);
        TTMetadata.MetadataDatos myData = myMeta.GetDatosDT(MyFunctions.FormatNumberNull(dtRoot).Value);
        switch (myData.TipodeDato)
        {
            case TTFunctions.TypeData.Fecha:
            case TTFunctions.TypeData.FechaHora:
                {
                    return TTReportes.TTReportsConfigurationsEnumFormatDate.AñoMesDia;
                }
        }
        return TTReportes.TTReportsConfigurationsEnumFormatDate.None;
    }

    private void AddRowToGrid(RadTreeNode node, string controlId)
    {
        switch (controlId)
        {
            case "ctl00_MainContent_txtFunctions": //"tcReports_tpConfiguracion_txtFunctions":
                TTReportes.TTReportsConfigurationsFunctions dCell = new TTReportes.TTReportsConfigurationsFunctions();
                dCell.Text = node.Text;
                dCell.Function = TTReportes.TTReportsConfigurationsEnumfunctions.Conteo;
                dCell.FullPath = node.FullPath;
                dCell.FullPathDT = node.Value.ToString();
                dCell.Format = formatDataType(dCell.FullPathDT);
                dCell.Mostrar_Vacios = true;
                myColumnsFunctions.Add(dCell);
                Session["myColumnsFunctions"] = myColumnsFunctions;

                break;
            case "ctl00_MainContent_txtColumns": //"tcReports_tpConfiguracion_txtColumns":
                TTReportes.TTReportsConfigurationsColumns dCol = new TTReportes.TTReportsConfigurationsColumns();
                dCol.Text = node.Text;
                dCol.FullPath = node.FullPath;
                dCol.FullPathDT = node.Value.ToString();
                dCol.Format = formatDataType(dCol.FullPathDT);
                dCol.Mostrar_Vacios = true;
                myColumns.Add(dCol);
                Session["myColumns"] = myColumns;

                break;
            case "ctl00_MainContent_txtRows": //"tcReports_tpConfiguracion_txtRows":
                TTReportes.TTReportsConfigurationsRows dRow = new TTReportes.TTReportsConfigurationsRows();
                dRow.Text = node.Text;
                dRow.FullPath = node.FullPath;
                dRow.FullPathDT = node.Value.ToString();
                dRow.Format = formatDataType(dRow.FullPathDT);
                myRows.Add(dRow);
                Session["myRows"] = myRows;
                break;
            default:
                break;
        }
        ActualizaGridVision();
    }

    protected void BtnColumnsProperties_Click(object sender, TTReportes.TTReportsConfigurationsColumns e)
    {
        myRows = Session["myRows"] == null ? new ArrayList() : (ArrayList)Session["myRows"];
    }

    protected void BtnRowsProperties_Click(object sender, TTReportes.TTReportsConfigurationsRows e)
    {
        myRows = Session["myRows"] == null ? new ArrayList() : (ArrayList)Session["myRows"];
    }

    protected void BtnColumnsProperties_Click(object sender, TTReportes.TTReportsConfigurationsFunctions e)
    {
        myColumnsFunctions = Session["myColumnsFunctions"] == null ? new ArrayList() : (ArrayList)Session["myColumnsFunctions"];
    }

    private Boolean Save()
    {
        LoadSecurityPage();
        myRows = Session["myRows"] == null ? new ArrayList() : (ArrayList)Session["myRows"];
        myColumns = Session["myColumns"] == null ? new ArrayList() : (ArrayList)Session["myColumns"];
        myColumnsFunctions = Session["myColumnsFunctions"] == null ? new ArrayList() : (ArrayList)Session["myColumnsFunctions"];
        myRowsH = Session["myRowsH"] == null ? new List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>() : (List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>)Session["myRowsH"];
        myColumnsH = Session["myColumnsH"] == null ? new List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>() : (List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>)Session["myColumnsH"];
        myRowsFooter = Session["myRowsFooter"] == null ? new List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>() : (List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>)Session["myRowsFooter"];
        myColumnsFooter = Session["myColumnsFooter"] == null ? new List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>() : (List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>)Session["myColumnsFooter"];

        myFilter = (ControlsLibrary.objectBussinessTTFiltro)Session["Filter"];
        if (myFilter != null)
            myFilter.GlobalInformation = myUserData;

        if (Session["objRep"] == null)
            objRep = new TTReportes.objectBussinessTTReportes();
        else
            objRep = (TTReportes.objectBussinessTTReportes)Session["objRep"];

        objRep.GlobalInformation = myUserData;
        objRep.idReporte = MyFunctions.FormatNumberNull(txtFolio.Text);
        objRep.Nombre = TxtNombre.Text;
        objRep.ProcesoId = MyFunctions.FormatNumberNull(ddlProceso.Text);

        if (myFilter != null)
        {
            if (myFilter.iProcess == 0 || myFilter.iProcess == null)
                myFilter = new ControlsLibrary.objectBussinessTTFiltro();
            else
                objRep.FiltroId = myFilter;
        }
        else
            myFilter = new ControlsLibrary.objectBussinessTTFiltro();
        objRep.ColumnasId = new TTReportes.objectBussinessTTReportes_Columnas[myColumns.Count];
        objRep.FilasId = new TTReportes.objectBussinessTTReportes_Filas[myRows.Count];
        objRep.FuncionesId = new TTReportes.objectBussinessTTReportes_Funciones[myColumnsFunctions.Count];
        objRep.TipoPresentacion = MyFunctions.FormatNumberNull(ddlTipoPresentacion.SelectedValue);
        objRep.SubtipoPresentacion = (TTReportes.TTReportsConfigurationsEnumSubPresentation)MyFunctions.FormatNumberNull(ddlSubTipoPresentacion.SelectedValue);
        objRep.Distinct = chkDistinct.Checked;
        objRep.TopList = MyFunctions.FormatNumberNull(txtTop.Text) < 0 ? 0 : MyFunctions.FormatNumberNull(txtTop.Text);
        objRep.StoreProcedure = txtProcedimientoAlmacenado.Text;
        objRep.StoreRelationDT = MyFunctions.FormatNumberNull(ddlStoreRelationDT.SelectedValue);
        objRep.IdGrupoReporte = MyFunctions.FormatNumberNull(ddlGrupoReporte.SelectedValue);

        objRep.TotalesColumna = chkTotalColumna.Checked;
        objRep.TotalesRenglon = chkTotalRenglon.Checked;
        objRep.Contador = chkContador.Checked;

        for (int i = 0; i < myColumns.Count; i++)
        {
            TTReportes.TTReportsConfigurationsColumns myCol = (TTReportes.TTReportsConfigurationsColumns)myColumns[i];
            objRep.ColumnasId[i] = new TTReportes.objectBussinessTTReportes_Columnas();
            objRep.ColumnasId[i].FullPath = myCol.FullPath.Replace("/", "\\");
            objRep.ColumnasId[i].FullPathDT = myCol.FullPathDT;
            objRep.ColumnasId[i].Text = myCol.Text;
            objRep.ColumnasId[i].Funciones = myCol.Function;
            objRep.ColumnasId[i].Subtotal = myCol.SubTotal;
            objRep.ColumnasId[i].Total = myCol.Total;
            objRep.ColumnasId[i].Minimo_Alerta = myCol.Minimo_Alerta;
            objRep.ColumnasId[i].Maximo_Alerta = myCol.Maximo_Alerta;
            objRep.ColumnasId[i].Format = myCol.Format;
            objRep.ColumnasId[i].Rango = myCol.Rango;
            objRep.ColumnasId[i].Mostrar_Vacios = myCol.Mostrar_Vacios;
            objRep.ColumnasId[i].OrderBy = myCol.OrderBy;
        }
        for (int i = 0; i < myRows.Count; i++)
        {
            TTReportes.TTReportsConfigurationsRows myRow = (TTReportes.TTReportsConfigurationsRows)myRows[i];
            objRep.FilasId[i] = new TTReportes.objectBussinessTTReportes_Filas();
            objRep.FilasId[i].FullPath = myRow.FullPath.Replace("/", "\\");
            objRep.FilasId[i].FullPathDT = myRow.FullPathDT;
            objRep.FilasId[i].Text = myRow.Text;
            objRep.FilasId[i].Format = myRow.Format;
            objRep.FilasId[i].Rango = myRow.Rango;
            objRep.FilasId[i].OrderBy = myRow.OrderBy;
        }
        for (int i = 0; i < myColumnsFunctions.Count; i++)
        {
            TTReportes.TTReportsConfigurationsFunctions myColF = (TTReportes.TTReportsConfigurationsFunctions)myColumnsFunctions[i];
            objRep.FuncionesId[i] = new TTReportes.objectBussinessTTReportes_Funciones();
            objRep.FuncionesId[i].FullPath = myColF.FullPath.Replace("/", "\\");
            objRep.FuncionesId[i].FullPathDT = myColF.FullPathDT;
            objRep.FuncionesId[i].Text = myColF.Text;
            objRep.FuncionesId[i].Funcion = myColF.Function;
            objRep.FuncionesId[i].Minimo_Alerta = myColF.Minimo_Alerta;
            objRep.FuncionesId[i].Maximo_Alerta = myColF.Maximo_Alerta;
            objRep.FuncionesId[i].Format = myColF.Format;
            objRep.FuncionesId[i].Mostrar_Vacios = myColF.Mostrar_Vacios;
            objRep.FuncionesId[i].OrderBy = myColF.OrderBy;
        }
        objRep.FilasHeader = new List<KeyValuePair<string, TTReportsConfigurationscells>>();
        for (int i = 0; i < myRowsH.Count; i++)
        {
            KeyValuePair<string, TTReportes.TTReportsConfigurationscells> myRowHe = (KeyValuePair<string, TTReportes.TTReportsConfigurationscells>)myRowsH[i];
            objRep.FilasHeader.Add(myRowHe);
        }
        objRep.ColumnasHeader = new List<KeyValuePair<string, TTReportsConfigurationscells>>();
        for (int i = 0; i < myColumnsH.Count; i++)
        {
            KeyValuePair<string, TTReportes.TTReportsConfigurationscells> myColHe = (KeyValuePair<string, TTReportes.TTReportsConfigurationscells>)myColumnsH[i];
            objRep.ColumnasHeader.Add(myColHe);
        }

        objRep.MatrizHeader = new List<string>();
        for (int i = 0; i < Matriz.Count; i++)
        {
            objRep.MatrizHeader.Add(Matriz[i]);
        }

        objRep.CeldasHeader = new List<CeldaHtml>();
        for (int i = 0; i < Celdas.Count; i++)
        {
            objRep.CeldasHeader.Add(Celdas[i]);
        }

        objRep.ZonesHeader = new List<KeyValuePair<string, string>>();
        for (int i = 0; i < CurrentDockZoneIds.Count; i++)
        {
            objRep.ZonesHeader.Add(CurrentDockZoneIds[i]);
        }

        objRep.DocksHeader = new List<DockStateWithTemplate>();
        for (int i = 0; i < CurrentDockStates.Count; i++)
        {
            objRep.DocksHeader.Add(CurrentDockStates[i]);
        }

        objRep.FilasFooter = new List<KeyValuePair<string, TTReportsConfigurationscells>>();
        for (int i = 0; i < myRowsFooter.Count; i++)
        {
            KeyValuePair<string, TTReportes.TTReportsConfigurationscells> myRowFo = (KeyValuePair<string, TTReportes.TTReportsConfigurationscells>)myRowsFooter[i];
            objRep.FilasFooter.Add(myRowFo);
        }
        objRep.ColumnasFooter = new List<KeyValuePair<string, TTReportsConfigurationscells>>();
        for (int i = 0; i < myColumnsFooter.Count; i++)
        {
            KeyValuePair<string, TTReportes.TTReportsConfigurationscells> myColFo = (KeyValuePair<string, TTReportes.TTReportsConfigurationscells>)myColumnsFooter[i];
            objRep.ColumnasFooter.Add(myColFo);
        }

        objRep.MatrizFooter = new List<string>();
        for (int i = 0; i < MatrizFooter.Count; i++)
        {
            objRep.MatrizFooter.Add(MatrizFooter[i]);
        }

        objRep.CeldasFooter = new List<CeldaHtml>();
        for (int i = 0; i < CeldasFooter.Count; i++)
        {
            objRep.CeldasFooter.Add(CeldasFooter[i]);
        }

        objRep.ZonesFooter = new List<KeyValuePair<string, string>>();
        for (int i = 0; i < CurrentDockZoneIdsFooter.Count; i++)
        {
            objRep.ZonesFooter.Add(CurrentDockZoneIdsFooter[i]);
        }

        objRep.DocksFooter = new List<DockStateWithTemplate>();
        for (int i = 0; i < CurrentDockStatesFooter.Count; i++)
        {
            objRep.DocksFooter.Add(CurrentDockStatesFooter[i]);
        }

        int proceso = int.Parse(ddlProceso.Text);
        TTDataLayerCS.DataLayerFieldsBitacora DataReference = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);

        try
        {
            if (txtFolio.Text == "")
                txtFolio.Text = objRep.Insert(myUserData, DataReference).ToString();
            else
                txtFolio.Text = objRep.Update(myUserData, DataReference).ToString();

            objRep.GetByKey(int.Parse(txtFolio.Text), true);
            Session["objRep"] = objRep;
        }
        catch (Exception e)
        {
            ShowAlert(e.Message.ToString());
        }
        return true;
    }

    private void ActualizaRadGrid()
    {
        myRows = Session["myRows"] == null ? new ArrayList() : (ArrayList)Session["myRows"];
        myColumns = Session["myColumns"] == null ? new ArrayList() : (ArrayList)Session["myColumns"];
        myColumnsFunctions = Session["myColumnsFunctions"] == null ? new ArrayList() : (ArrayList)Session["myColumnsFunctions"];
    }

    protected void btnFilters_Click(object sender, EventArgs e)
    {
    }

    protected void ddlProceso_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        string sqlQuery;
        RadComboBox comboBox;
        if (cbIdModulo.SelectedValue == null || cbIdModulo.SelectedIndex == 0)
        {
            sqlQuery = @"Select Top 50         
                        TTProceso.IdProceso As TTProceso_IdProceso,        
                        TTProceso.Nombre As TTProceso_Nombre,        
                        TTProceso.Pantalla As TTProceso_Pantalla   
                        From  TTProceso          	
                        Where TTProceso.IdProceso in (
                        select TTProceso_del_Modulo.IdProceso from TTProceso_del_Modulo
                        where TTProceso_del_Modulo.IdModulo in(
                        select TTPermisos_por_modulo.IdModulo as IdModulo
                        from TTPermisos_por_modulo 
                        where IdGrupoUsuario = (select TTUsuarios_Por_Grupo.IdGrupoUsuario 
                        from TTUsuarios_Por_Grupo where IdUsuario=" + MyUserData.UserID.ToString() + ")))Order by TTProceso.Nombre";
            comboBox = (RadComboBox)ddlProceso;
        }
        else
        {
            sqlQuery = @"Select Top 50         
                        TTProceso.IdProceso As TTProceso_IdProceso,        
                        TTProceso.Nombre As TTProceso_Nombre,        
                        TTProceso.Pantalla As TTProceso_Pantalla   
                        From  TTProceso          	
                        Where TTProceso.IdProceso in (
                        select TTProceso_del_Modulo.IdProceso from TTProceso_del_Modulo
                        WHERE ( TTProceso.Nombre like '%{0}%'
	                        Or TTProceso.IdProceso like '{0}%' )
                        AND TTProceso_del_Modulo.IdModulo in(
                        select TTPermisos_por_modulo.IdModulo as IdModulo
                        from TTPermisos_por_modulo 
                        where IdGrupoUsuario = (select TTUsuarios_Por_Grupo.IdGrupoUsuario 
                        from TTUsuarios_Por_Grupo where 
                        IdUsuario={1})and IdModulo={2}))Order by TTProceso.Nombre";

            sqlQuery = string.Format(sqlQuery, e.Text.Replace("\'", string.Empty), MyUserData.UserID.ToString(), cbIdModulo.SelectedValue.ToString());

            comboBox = (RadComboBox)ddlProceso;

            DataSet ds = Funcion.RegresaDataSet(sqlQuery);
            comboBox.Items.Clear();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                RadComboBoxItem item = new RadComboBoxItem();
                item.Text = row["TTProceso_IdProceso"].ToString();
                item.Value = row["TTProceso_IdProceso"].ToString();

                item.Attributes.Add("TTProceso_Nombre", row["TTProceso_Nombre"].ToString());
                item.Attributes.Add("TTProceso_IdProceso", row["TTProceso_IdProceso"].ToString());

                comboBox.Items.Add(item);
                item.DataBind();
            }
        }
    }
    protected void cbIdModulo_SelectedIndexChanged(object sender, EventArgs e)
    {
        RadComboBox comboBox = (RadComboBox)ddlProceso;
        comboBox.ClearSelection();
        comboBox.Text = "";
    }
    protected void cbIdModulo_DataBound()
    {
        DropDownList ddl = (DropDownList)cbIdModulo;
        string sqlQuery = @"select TTModulo.IdModulo as IdModulo,
	        TTModulo.Nombre as Nombre 
	        from TTModulo
	        where TTmodulo.IdModulo in
	        (select TTPermisos_por_modulo.IdModulo as IdModulo
	        from TTPermisos_por_modulo 
	        where IdGrupoUsuario = (select TTUsuarios_Por_Grupo.IdGrupoUsuario from TTUsuarios_Por_Grupo where IdUsuario=" + MyUserData.UserID.ToString() + "))";
        DataSet ds = Funcion.RegresaDataSet(sqlQuery);
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            ListItem item = new ListItem();
            item.Text = row["Nombre"].ToString();
            item.Value = row["IdModulo"].ToString();
            ddl.Items.Add(item);
            ddl.DataBind();
        }
        ddl.Items.Insert(0, new ListItem("-Seleccionar Módulo-", ""));
    }

    protected void ddlProceso_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        btnSelProcess_Click();

        myRows = new ArrayList();
        myColumns = new ArrayList();
        myColumnsFunctions = new ArrayList();

        Session["myRows"] = myRows;
        Session["myColumns"] = myColumns;
        Session["myColumnsFunctions"] = myColumnsFunctions;
        ActualizaGridVision();
    }
    protected void BtnRefresh_Click(object sender, EventArgs e)
    {

    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Session["Filter"] = null;
    }
    protected void ddlGrupoReporte_Databound(object sender, EventArgs e)
    {
        ddlGrupoReporte.Items.Insert(0, new ListItem("-Seleccionar Grupo de Reportes-", ""));
    }

    private void ActualizaHeader()
    {
        for (int i = 0; i < Matriz.Count; i++)
            CreateRow(Matriz[i]);

        for (int i = 0; i < Celdas.Count; i++)
            CreateCelda(Celdas[i].Key, Celdas[i].Row, null);

        for (int i = 0; i < CurrentDockZoneIds.Count; i++)
            createRadDockZone(CurrentDockZoneIds[i].Key, CurrentDockZoneIds[i].Value, null);

        for (int i = 0; i < CurrentDockStates.Count; i++)
        {
            RadDock dock = CreateRadDockFromState(CurrentDockStates[i], "RadDock");
            dock.Height = new Unit();
            dock.ForbiddenZones = CurrentDockZoneIdsFooter.Select(x => x.Key).ToArray();
            RadDockLayout1.Controls.Add(dock);
            CreateSaveStateTrigger(dock);
        }

        if (Celdas.Count > 0)
        {
            HtmlTableRow RR = new HtmlTableRow();
            for (int i = 0; i < Celdas.Count / Matriz.Count; i++)
            {

                HtmlTableCell cll = new HtmlTableCell();

                Button btn = new Button();
                btn.Visible = true;
                btn.CausesValidation = false;
                btn.CommandName = "myColumnsHeader";
                btn.CommandArgument = i.ToString();
                btn.OnClientClick = "OpenPropertyWindow('" + btn.CommandName + "', '" + btn.CommandArgument + "');";
                btn.CssClass = "btnConfigurar";

                btn.Text = "Configurar";
                cll.Controls.Add(btn);
                RR.Controls.Add(cll);
            }

            tableDock.Rows.Insert(0, RR);
            tableDock.Rows[0].Cells.Insert(0, new HtmlTableCell());
            for (int i = 0; i < Matriz.Count; i++)
            {
                HtmlTableCell cll = new HtmlTableCell();

                Button btn = new Button();
                btn.Visible = true;
                btn.CausesValidation = false;
                btn.CommandName = "myRowsHeader";
                btn.CommandArgument = i.ToString();
                btn.OnClientClick = "OpenPropertyWindow('" + btn.CommandName + "', '" + btn.CommandArgument + "');";
                btn.CssClass = "btnConfigurar";
                btn.Text = "Configurar";
                cll.Controls.Add(btn);
                ((HtmlTableRow)tableDock.FindControl(Matriz[i])).Cells.Insert(0, cll);
            }
        }
        else
            tableDock.Rows.Clear();
    }

    private void ActualizaFooter()
    {
        for (int i = 0; i < MatrizFooter.Count; i++)
            CreateRowFooter(MatrizFooter[i]);

        for (int i = 0; i < CeldasFooter.Count; i++)
            CreateCeldaFooter(CeldasFooter[i].Key, CeldasFooter[i].Row, null);

        for (int i = 0; i < CurrentDockZoneIdsFooter.Count; i++)
            createRadDockZoneFooter(CurrentDockZoneIdsFooter[i].Key, CurrentDockZoneIdsFooter[i].Value, null);

        for (int i = 0; i < CurrentDockStatesFooter.Count; i++)
        {
            RadDock dock = CreateRadDockFromState(CurrentDockStatesFooter[i], "RadDockFooter");
            dock.Height = new Unit();
            dock.ForbiddenZones = CurrentDockZoneIds.Select(x => x.Key).ToArray();
            RadDockLayout1.Controls.Add(dock);
            CreateSaveStateTrigger(dock);
        }

        if (CeldasFooter.Count > 0)
        {
            HtmlTableRow RR = new HtmlTableRow();
            for (int i = 0; i < CeldasFooter.Count / MatrizFooter.Count; i++)
            {

                HtmlTableCell cll = new HtmlTableCell();

                Button btn = new Button();
                btn.Visible = true;
                btn.CausesValidation = false;
                btn.CommandName = "myColumnsFooter";
                btn.CommandArgument = i.ToString();
                btn.OnClientClick = "OpenPropertyWindow('" + btn.CommandName + "', '" + btn.CommandArgument + "');";
                btn.CssClass = "btnConfigurar";

                btn.Text = "Configurar";
                cll.Controls.Add(btn);
                RR.Controls.Add(cll);
            }

            tableDockFooter.Rows.Insert(0, RR);
            tableDockFooter.Rows[0].Cells.Insert(0, new HtmlTableCell());
            for (int i = 0; i < MatrizFooter.Count; i++)
            {
                HtmlTableCell cll = new HtmlTableCell();

                Button btn = new Button();
                btn.Visible = true;
                btn.CausesValidation = false;
                btn.CommandName = "myRowsFooter";
                btn.CommandArgument = i.ToString();
                btn.OnClientClick = "OpenPropertyWindow('" + btn.CommandName + "', '" + btn.CommandArgument + "');";
                btn.CssClass = "btnConfigurar";
                btn.Text = "Configurar";
                cll.Controls.Add(btn);
                ((HtmlTableRow)tableDockFooter.FindControl(MatrizFooter[i])).Cells.Insert(0, cll);
            }
        }
        else
            tableDockFooter.Rows.Clear();
    }

    private RadDock CreateRadDockFromState(DockStateWithTemplate state, string nombre)
    {
        RadDock dock = new RadDock();
        dock.DockMode = DockMode.Docked;
        dock.DockHandle = DockHandle.TitleBar;
        dock.ID = string.Format(nombre + "{0}", state.UniqueName);
        if (state.WithTemplate)
        {
            if (state.Text != "")
                state.Title = state.Text;
            state.Text = "";
            dock.ApplyState(state);
            dock.TitlebarTemplate = new DockTitleTemplate(dock, state.esTexto, this);
        }
        else
            dock.ApplyState(state);
        dock.Commands.Add(new DockCloseCommand());


        return dock;
    }


    private RadDock CreateRadDock(string descripcion, string nombre)
    {
        int docksCount = CurrentDockStates.Count;

        RadDock dock = new RadDock();
        dock.DockMode = DockMode.Docked;
        dock.DockHandle = DockHandle.TitleBar;
        dock.UniqueName = descripcion + Guid.NewGuid().ToString();
        dock.ID = string.Format(nombre + "{0}", dock.UniqueName);
        dock.Title = descripcion;
        dock.Width = Unit.Pixel(150);
        dock.Commands.Add(new DockCloseCommand());

        return dock;
    }


    private RadDock CreateRadDock(string descripcion, bool esTexto, string nombre)
    {
        int docksCount = CurrentDockStates.Count;

        RadDock dock = new RadDock();
        dock.DockMode = DockMode.Docked;
        dock.DockHandle = DockHandle.TitleBar;
        dock.UniqueName = (esTexto ? descripcion : "Imagen") + Guid.NewGuid().ToString();
        dock.ID = string.Format(nombre + "{0}", dock.UniqueName);
        dock.Title = descripcion;
        dock.Width = Unit.Pixel(150);
        dock.Commands.Add(new DockCloseCommand());
        dock.TitlebarTemplate = new DockTitleTemplate(dock, esTexto, this);

        return dock;
    }

    private void CreateSaveStateTrigger(RadDock dock)
    {
        //Ensure that the RadDock control will initiate postback
        // when its position changes on the client or any of the commands is clicked.
        //Using the trigger we will "ajaxify" that postback.
        dock.AutoPostBack = true;
        dock.CommandsAutoPostBack = true;

        AsyncPostBackTrigger saveStateTrigger = new AsyncPostBackTrigger();
        saveStateTrigger.ControlID = dock.ID;
        saveStateTrigger.EventName = "DockPositionChanged";
        UpdatePanel1.Triggers.Add(saveStateTrigger);

        saveStateTrigger = new AsyncPostBackTrigger();
        saveStateTrigger.ControlID = dock.ID;
        saveStateTrigger.EventName = "Command";
        UpdatePanel1.Triggers.Add(saveStateTrigger);
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Matriz = null;
            Celdas = null;
            CurrentDockZoneIds = null;
            CurrentDockStates = null;
            MatrizFooter = null;
            CeldasFooter = null;
            CurrentDockZoneIdsFooter = null;
            CurrentDockStatesFooter = null;
        }
        if (!Page.IsPostBack && Matriz.Count == 0)
        {
            Matriz = new List<string>();
            Matriz.Add("ctl00_MainContent_R1");
            Celdas = new List<CeldaHtml>();
            Celdas.Add(new CeldaHtml(0, "ctl00_MainContent_C1", 1, 1, "ctl00_MainContent_R1"));
            CurrentDockZoneIds = new List<KeyValuePair<string, string>>();
            CurrentDockZoneIds.Add(new KeyValuePair<string, string>("ctl00_MainContent_RadDockZone1", "ctl00_MainContent_C1"));
            CurrentDockStates = new List<DockStateWithTemplate>();
        }

        if (!Page.IsPostBack && MatrizFooter.Count == 0)
        {
            MatrizFooter = new List<string>();
            MatrizFooter.Add("ctl00_MainContent_R1Footer");
            CeldasFooter = new List<CeldaHtml>();
            CeldasFooter.Add(new CeldaHtml(0, "ctl00_MainContent_C1Footer", 1, 1, "ctl00_MainContent_R1Footer"));
            CurrentDockZoneIdsFooter = new List<KeyValuePair<string, string>>();
            CurrentDockZoneIdsFooter.Add(new KeyValuePair<string, string>("ctl00_MainContent_RadDockZone1Footer", "ctl00_MainContent_C1Footer"));
            CurrentDockStatesFooter = new List<DockStateWithTemplate>();
        }

        ActualizaHeader();
        ActualizaFooter();
    }

    private void CreateRow(string id)
    {
        HtmlTableRow row = new HtmlTableRow();
        if (id != null)
        {
            row.ID = id;
        }
        else
        {
            row.ID = Guid.NewGuid().ToString();
            Matriz.Add(row.ID);
        }
        tableDock.Rows.Add(row);

        if (id == null)
        {
            int R = Matriz.Count - 1;
            int C = Celdas.Sum(x => x.rowspan * x.colspan);
            if (R > 0)
                for (int i = 0; i < C / R; i++)
                    CreateCelda(null, row.ID, null);
            else
                CreateCelda(null, row.ID, null);
        }
    }

    private void CreateRowFooter(string id)
    {
        HtmlTableRow row = new HtmlTableRow();
        if (id != null)
        {
            row.ID = id;
        }
        else
        {
            row.ID = Guid.NewGuid().ToString();
            MatrizFooter.Add(row.ID);
        }
        tableDockFooter.Rows.Add(row);

        if (id == null)
        {
            int R = MatrizFooter.Count - 1;
            int C = CeldasFooter.Sum(x => x.rowspan * x.colspan);
            if (R > 0)
                for (int i = 0; i < C / R; i++)
                    CreateCeldaFooter(null, row.ID, null);
            else
                CreateCeldaFooter(null, row.ID, null);
        }
    }

    private void CreateCelda(string id, string row, int? rowid)
    {
        HtmlTableCell celd = new HtmlTableCell();
        if (id != null)
        {
            celd.ID = id;
        }
        else
        {
            celd.ID = Guid.NewGuid().ToString();
            Celdas.Add(new CeldaHtml(0, celd.ID.ToString(), 1, 1, row));
        }
        tableDock.FindControl(row).Controls.Add(celd);

        if (id == null)
        {
            createRadDockZone(null, celd.ID, rowid);
        }
    }

    private void CreateCeldaFooter(string id, string row, int? rowid)
    {
        HtmlTableCell celd = new HtmlTableCell();
        if (id != null)
        {
            celd.ID = id;
        }
        else
        {
            celd.ID = Guid.NewGuid().ToString();
            CeldasFooter.Add(new CeldaHtml(0, celd.ID.ToString(), 1, 1, row));
        }
        tableDockFooter.FindControl(row).Controls.Add(celd);

        if (id == null)
        {
            createRadDockZoneFooter(null, celd.ID, rowid);
        }
    }

    private void createRadDockZone(string id, string celda, int? row)
    {
        RadDockZone zone1 = new RadDockZone();
        if (id != null)
        {
            zone1.ID = id;
        }
        else
        {
            zone1.ID = Guid.NewGuid().ToString();
            if (CurrentDockZoneIds.Count > 0 && row != null)
            {
                List<KeyValuePair<string, string>> Nuevo = new List<KeyValuePair<string, string>>();
                for (int i = 0; i <= CurrentDockZoneIds.Count; i++)
                {
                    if (i == (((CurrentDockZoneIds.Count + Matriz.Count - row + 1) / Matriz.Count) * row) - 1)
                    {
                        Nuevo.Add(new KeyValuePair<string, string>(zone1.ID.ToString(), celda));
                        if (i < CurrentDockZoneIds.Count)
                            Nuevo.Add(CurrentDockZoneIds[i]);
                        //break;
                    }
                    else if (i < CurrentDockZoneIds.Count)
                        Nuevo.Add(CurrentDockZoneIds[i]);
                }
                CurrentDockZoneIds = Nuevo;
            }
            else
                CurrentDockZoneIds.Add(new KeyValuePair<string, string>(zone1.ID.ToString(), celda));

        }
        zone1.FitDocks = false;
        tableDock.FindControl(celda).Controls.Add(zone1);
        //RadDockLayout1.Controls.Add(zone1);
    }

    private void createRadDockZoneFooter(string id, string celda, int? row)
    {
        RadDockZone zone1 = new RadDockZone();
        if (id != null)
        {
            zone1.ID = id;
        }
        else
        {
            zone1.ID = "Footer" + Guid.NewGuid().ToString();
            if (CurrentDockZoneIdsFooter.Count > 0 && row != null)
            {
                List<KeyValuePair<string, string>> Nuevo = new List<KeyValuePair<string, string>>();
                for (int i = 0; i <= CurrentDockZoneIdsFooter.Count; i++)
                {
                    if (i == (((CurrentDockZoneIdsFooter.Count + MatrizFooter.Count - row + 1) / MatrizFooter.Count) * row) - 1)
                    {
                        Nuevo.Add(new KeyValuePair<string, string>(zone1.ID.ToString(), celda));
                        if (i < CurrentDockZoneIdsFooter.Count)
                            Nuevo.Add(CurrentDockZoneIdsFooter[i]);
                        //break;
                    }
                    else if (i < CurrentDockZoneIdsFooter.Count)
                        Nuevo.Add(CurrentDockZoneIdsFooter[i]);
                }
                CurrentDockZoneIdsFooter = Nuevo;
            }
            else
                CurrentDockZoneIdsFooter.Add(new KeyValuePair<string, string>(zone1.ID.ToString(), celda));

        }
        zone1.FitDocks = false;
        tableDockFooter.FindControl(celda).Controls.Add(zone1);
        //RadDockLayout1.Controls.Add(zone1);
    }

    protected void RadDockLayout1_LoadDockLayout(object sender, DockLayoutEventArgs e)
    {
        //Populate the event args with the state information. The RadDockLayout control
        // will automatically move the docks according that information.
        foreach (DockStateWithTemplate state in CurrentDockStates)
        {
            e.Positions[state.UniqueName] = state.DockZoneID;
            e.Indices[state.UniqueName] = state.Index;
        }

        foreach (DockStateWithTemplate state in CurrentDockStatesFooter)
        {
            e.Positions[state.UniqueName] = state.DockZoneID;
            e.Indices[state.UniqueName] = state.Index;
        }
    }

    protected void RadDockLayout1_SaveDockLayout(object sender, DockLayoutEventArgs e)
    {
        //Save the dock state in the page Session. This will enable us
        // to recreate the dock in the next Page_Init.
        CurrentDockStates.Clear();
        CurrentDockStatesFooter.Clear();
        List<DockState> Lista = RadDockLayout1.GetRegisteredDocksState();
        foreach (DockState State in Lista.Where(x => !x.DockZoneID.Contains("Footer")))
        {
            CurrentDockStates.Add(new DockStateWithTemplate(0, State.Closed, State.Collapsed, State.DockZoneID, State.ExpandedHeight,
                State.Height, State.Index, State.Left, State.Pinned, State.Resizable, State.Tag, State.Text, State.Title, State.Top,
                State.UniqueName, State.Width, State.UniqueName.Contains("Texto") || State.UniqueName.Contains("Imagen"),
                !State.UniqueName.Contains("Imagen")));
        }
        foreach (DockState State in Lista.Where(x => x.DockZoneID.Contains("Footer")))
        {
            CurrentDockStatesFooter.Add(new DockStateWithTemplate(0, State.Closed, State.Collapsed, State.DockZoneID, State.ExpandedHeight,
                State.Height, State.Index, State.Left, State.Pinned, State.Resizable, State.Tag, State.Text, State.Title, State.Top,
                State.UniqueName, State.Width, State.UniqueName.Contains("Texto") || State.UniqueName.Contains("Imagen"),
                !State.UniqueName.Contains("Imagen")));
        }
        //CurrentDockStates = RadDockLayout1.RegisteredDocks .GetRegisteredDocksState();
    }

    protected void btnFecha_Click(object sender, EventArgs e)
    {
        if (CurrentDockZoneIds.Count > 0)
        {
            RadDockZone RadDockZone1 = (RadDockZone)tableDock.FindControl(CurrentDockZoneIds[0].Key);
            if (RadDockZone1 != null)
            {
                RadDock dock = CreateRadDock("Fecha", "RadDock");
                dock.ForbiddenZones = CurrentDockZoneIdsFooter.Select(x => x.Key).ToArray();
                RadDockZone1.Controls.Add(dock);
                CreateSaveStateTrigger(dock);
            }
        }
    }

    protected void btnFechaFooter_Click(object sender, EventArgs e)
    {
        if (CurrentDockZoneIdsFooter.Count > 0)
        {
            RadDockZone RadDockZone1 = (RadDockZone)tableDockFooter.FindControl(CurrentDockZoneIdsFooter[0].Key);
            if (RadDockZone1 != null)
            {
                RadDock dock = CreateRadDock("Fecha", "RadDockFooter");
                dock.ForbiddenZones = CurrentDockZoneIds.Select(x => x.Key).ToArray();
                RadDockZone1.Controls.Add(dock);
                CreateSaveStateTrigger(dock);
            }
        }
    }

    protected void btnHora_Click(object sender, EventArgs e)
    {
        if (CurrentDockZoneIds.Count > 0)
        {
            RadDockZone RadDockZone1 = (RadDockZone)tableDock.FindControl(CurrentDockZoneIds[0].Key);
            if (RadDockZone1 != null)
            {
                RadDock dock = CreateRadDock("Hora", "RadDock");
                dock.ForbiddenZones = CurrentDockZoneIdsFooter.Select(x => x.Key).ToArray();
                RadDockZone1.Controls.Add(dock);
                CreateSaveStateTrigger(dock);
            }
        }
    }

    protected void btnHoraFooter_Click(object sender, EventArgs e)
    {
        if (CurrentDockZoneIdsFooter.Count > 0)
        {
            RadDockZone RadDockZone1 = (RadDockZone)tableDockFooter.FindControl(CurrentDockZoneIdsFooter[0].Key);
            if (RadDockZone1 != null)
            {
                RadDock dock = CreateRadDock("Hora", "RadDockFooter");
                dock.ForbiddenZones = CurrentDockZoneIds.Select(x => x.Key).ToArray();
                RadDockZone1.Controls.Add(dock);
                CreateSaveStateTrigger(dock);
            }
        }
    }

    protected void btnNumero_Click(object sender, EventArgs e)
    {
        if (CurrentDockZoneIds.Count > 0)
        {
            RadDockZone RadDockZone1 = (RadDockZone)tableDock.FindControl(CurrentDockZoneIds[0].Key);
            if (RadDockZone1 != null)
            {
                RadDock dock = CreateRadDock("Numero", "RadDock");
                dock.ForbiddenZones = CurrentDockZoneIdsFooter.Select(x => x.Key).ToArray();
                RadDockZone1.Controls.Add(dock);
                CreateSaveStateTrigger(dock);
            }
        }
    }

    protected void btnNumeroFooter_Click(object sender, EventArgs e)
    {
        if (CurrentDockZoneIdsFooter.Count > 0)
        {
            RadDockZone RadDockZone1 = (RadDockZone)tableDockFooter.FindControl(CurrentDockZoneIdsFooter[0].Key);
            if (RadDockZone1 != null)
            {
                RadDock dock = CreateRadDock("Numero", "RadDockFooter");
                dock.ForbiddenZones = CurrentDockZoneIds.Select(x => x.Key).ToArray();
                RadDockZone1.Controls.Add(dock);
                CreateSaveStateTrigger(dock);
            }
        }
    }

    protected void btnUsuario_Click(object sender, EventArgs e)
    {
        if (CurrentDockZoneIds.Count > 0)
        {
            RadDockZone RadDockZone1 = (RadDockZone)tableDock.FindControl(CurrentDockZoneIds[0].Key);
            if (RadDockZone1 != null)
            {
                RadDock dock = CreateRadDock("Usuario", "RadDock");
                dock.ForbiddenZones = CurrentDockZoneIdsFooter.Select(x => x.Key).ToArray();
                RadDockZone1.Controls.Add(dock);
                CreateSaveStateTrigger(dock);
            }
        }
    }

    protected void btnUsuarioFooter_Click(object sender, EventArgs e)
    {
        if (CurrentDockZoneIdsFooter.Count > 0)
        {
            RadDockZone RadDockZone1 = (RadDockZone)tableDockFooter.FindControl(CurrentDockZoneIdsFooter[0].Key);
            if (RadDockZone1 != null)
            {
                RadDock dock = CreateRadDock("Usuario", "RadDockFooter");
                dock.ForbiddenZones = CurrentDockZoneIds.Select(x => x.Key).ToArray();
                RadDockZone1.Controls.Add(dock);
                CreateSaveStateTrigger(dock);
            }
        }
    }

    protected void btnTexto_Click(object sender, EventArgs e)
    {
        if (CurrentDockZoneIds.Count > 0)
        {
            RadDockZone RadDockZone1 = (RadDockZone)tableDock.FindControl(CurrentDockZoneIds[0].Key);
            if (RadDockZone1 != null)
            {
                RadDock dock = CreateRadDock("Texto", true, "RadDock");
                dock.ForbiddenZones = CurrentDockZoneIdsFooter.Select(x => x.Key).ToArray();
                RadDockZone1.Controls.Add(dock);
                CreateSaveStateTrigger(dock);
            }
        }
    }

    protected void btnTextoFooter_Click(object sender, EventArgs e)
    {
        if (CurrentDockZoneIdsFooter.Count > 0)
        {
            RadDockZone RadDockZone1 = (RadDockZone)tableDockFooter.FindControl(CurrentDockZoneIdsFooter[0].Key);
            if (RadDockZone1 != null)
            {
                RadDock dock = CreateRadDock("Texto", true, "RadDockFooter");
                dock.ForbiddenZones = CurrentDockZoneIds.Select(x => x.Key).ToArray();
                RadDockZone1.Controls.Add(dock);
                CreateSaveStateTrigger(dock);
            }
        }
    }

    protected void btnImagen_Click(object sender, EventArgs e)
    {
        if (CurrentDockZoneIds.Count > 0)
        {
            RadDockZone RadDockZone1 = (RadDockZone)tableDock.FindControl(CurrentDockZoneIds[0].Key);
            if (RadDockZone1 != null)
            {
                RadDock dock = CreateRadDock("../../Images/tit_tt_70.jpg", false, "RadDock");
                dock.ForbiddenZones = CurrentDockZoneIdsFooter.Select(x => x.Key).ToArray();
                RadDockZone1.Controls.Add(dock);
                CreateSaveStateTrigger(dock);
            }
        }
    }

    protected void btnImagenFooter_Click(object sender, EventArgs e)
    {
        if (CurrentDockZoneIdsFooter.Count > 0)
        {
            RadDockZone RadDockZone1 = (RadDockZone)tableDockFooter.FindControl(CurrentDockZoneIdsFooter[0].Key);
            if (RadDockZone1 != null)
            {
                RadDock dock = CreateRadDock("../../Images/tit_tt_70.jpg", false, "RadDockFooter");
                dock.ForbiddenZones = CurrentDockZoneIds.Select(x => x.Key).ToArray();
                RadDockZone1.Controls.Add(dock);
                CreateSaveStateTrigger(dock);
            }
        }
    }

    protected void btnFila_Click(object sender, EventArgs e)
    {
        CreateRow(null);
        HtmlTableCell cll = new HtmlTableCell();
        Button btn = new Button();
        btn.Visible = true;
        btn.CausesValidation = false;
        btn.CommandName = "myRowsHeader";
        btn.CommandArgument = (Matriz.Count - 1).ToString();
        btn.OnClientClick = "OpenPropertyWindow('" + btn.CommandName + "', '" + btn.CommandArgument + "');";
        btn.CssClass = "btnConfigurar";
        btn.Text = "Configurar";
        cll.Controls.Add(btn);
        if (tableDock.Rows.Count == 1)
        {
            HtmlTableRow RR = new HtmlTableRow();
            RR.Cells.Add(new HtmlTableCell());
            RR.Cells.Add(cll);
            cll = new HtmlTableCell();
            btn = new Button();
            btn.Visible = true;
            btn.CausesValidation = false;
            btn.CommandName = "myRowsHeader";
            btn.CommandArgument = "0";
            btn.OnClientClick = "OpenPropertyWindow('" + btn.CommandName + "', '" + btn.CommandArgument + "');";
            btn.CssClass = "btnConfigurar";
            btn.Text = "Configurar";
            cll.Controls.Add(btn);
            tableDock.Rows.Insert(0, RR);
            tableDock.Rows[1].Cells.Insert(0, cll);
        }
        else
            ((HtmlTableRow)tableDock.FindControl(Matriz[Matriz.Count - 1])).Cells.Insert(0, cll);
    }

    protected void btnFilaFooter_Click(object sender, EventArgs e)
    {
        CreateRowFooter(null);
        HtmlTableCell cll = new HtmlTableCell();
        Button btn = new Button();
        btn.Visible = true;
        btn.CausesValidation = false;
        btn.CommandName = "myRowsFooter";
        btn.CommandArgument = (MatrizFooter.Count - 1).ToString();
        btn.OnClientClick = "OpenPropertyWindow('" + btn.CommandName + "', '" + btn.CommandArgument + "');";
        btn.CssClass = "btnConfigurar";
        btn.Text = "Configurar";
        cll.Controls.Add(btn);
        if (tableDockFooter.Rows.Count == 1)
        {
            HtmlTableRow RR = new HtmlTableRow();
            RR.Cells.Add(new HtmlTableCell());
            RR.Cells.Add(cll);
            cll = new HtmlTableCell();
            btn = new Button();
            btn.Visible = true;
            btn.CausesValidation = false;
            btn.CommandName = "myRowsFooter";
            btn.CommandArgument = "0";
            btn.OnClientClick = "OpenPropertyWindow('" + btn.CommandName + "', '" + btn.CommandArgument + "');";
            btn.CssClass = "btnConfigurar";
            btn.Text = "Configurar";
            cll.Controls.Add(btn);
            tableDockFooter.Rows.Insert(0, RR);
            tableDockFooter.Rows[1].Cells.Insert(0, cll);
        }
        else
            ((HtmlTableRow)tableDockFooter.FindControl(MatrizFooter[MatrizFooter.Count - 1])).Cells.Insert(0, cll);
    }

    protected void btnColumna_Click(object sender, EventArgs e)
    {
        if (Matriz.Count == 0)
            CreateRow(null);
        else
            for (int i = 0; i < Matriz.Count; i++)
                CreateCelda(null, Matriz[i], i + 1);
        HtmlTableCell cll = new HtmlTableCell();
        Button btn = new Button();
        btn.Visible = true;
        btn.CausesValidation = false;
        btn.CommandName = "myColumnsHeader";
        btn.CommandArgument = (Celdas.Count / Matriz.Count - 1).ToString();
        btn.OnClientClick = "OpenPropertyWindow('" + btn.CommandName + "', '" + btn.CommandArgument + "');";
        btn.CssClass = "btnConfigurar";
        btn.Text = "Configurar";
        cll.Controls.Add(btn);
        if (Celdas.Count == 1)
        {
            HtmlTableRow RR = new HtmlTableRow();
            RR.Cells.Add(new HtmlTableCell());
            RR.Cells.Add(cll);
            cll = new HtmlTableCell();
            btn = new Button();
            btn.Visible = true;
            btn.CausesValidation = false;
            btn.CommandName = "myColumnsHeader";
            btn.CommandArgument = "0";
            btn.OnClientClick = "OpenPropertyWindow('" + btn.CommandName + "', '" + btn.CommandArgument + "');";
            btn.CssClass = "btnConfigurar";
            btn.Text = "Configurar";
            cll.Controls.Add(btn);
            tableDock.Rows.Insert(0, RR);
            tableDock.Rows[1].Cells.Insert(0, cll);
        }
        else
            tableDock.Rows[0].Controls.Add(cll);
    }

    protected void btnColumnaFooter_Click(object sender, EventArgs e)
    {
        if (MatrizFooter.Count == 0)
            CreateRowFooter(null);
        else
            for (int i = 0; i < MatrizFooter.Count; i++)
                CreateCeldaFooter(null, MatrizFooter[i], i + 1);
        HtmlTableCell cll = new HtmlTableCell();
        Button btn = new Button();
        btn.Visible = true;
        btn.CausesValidation = false;
        btn.CommandName = "myColumnsFooter";
        btn.CommandArgument = (Celdas.Count / Matriz.Count - 1).ToString();
        btn.OnClientClick = "OpenPropertyWindow('" + btn.CommandName + "', '" + btn.CommandArgument + "');";
        btn.CssClass = "btnConfigurar";
        btn.Text = "Configurar";
        cll.Controls.Add(btn);
        if (CeldasFooter.Count == 1)
        {
            HtmlTableRow RR = new HtmlTableRow();
            RR.Cells.Add(new HtmlTableCell());
            RR.Cells.Add(cll);
            cll = new HtmlTableCell();
            btn = new Button();
            btn.Visible = true;
            btn.CausesValidation = false;
            btn.CommandName = "myColumnsFooter";
            btn.CommandArgument = "0";
            btn.OnClientClick = "OpenPropertyWindow('" + btn.CommandName + "', '" + btn.CommandArgument + "');";
            btn.CssClass = "btnConfigurar";
            btn.Text = "Configurar";
            cll.Controls.Add(btn);
            tableDockFooter.Rows.Insert(0, RR);
            tableDockFooter.Rows[1].Cells.Insert(0, cll);
        }
        else
            tableDockFooter.Rows[0].Controls.Add(cll);
    }

    protected void btnBorrarFila_Click(object sender, EventArgs e)
    {
        if (Matriz.Count > 0)
        {
            string ID = Matriz[Matriz.Count - 1];
            if (Celdas.GroupBy(x => x.Row).Select(x => new { Count = x.Count() }).Max(x => x.Count)
                == Celdas.Where(x => x.Row == ID && x.rowspan == 1 && x.colspan == 1).Count())
            {
                Matriz.Remove(ID);
                HtmlTableRow Fila = (HtmlTableRow)tableDock.FindControl(ID);
            Again:
                foreach (CeldaHtml Celda in Celdas)
                {
                    if (Celda.Row == ID)
                    {
                        HtmlTableCell Columna = (HtmlTableCell)Fila.FindControl(Celda.Key);
                        foreach (KeyValuePair<string, string> dockZ in CurrentDockZoneIds)
                        {
                            if (dockZ.Value == Celda.Key)
                            {
                                RadDockZone dz = (RadDockZone)Columna.FindControl(dockZ.Key);
                            AgainDock:
                                foreach (DockStateWithTemplate dock in CurrentDockStates)
                                {
                                    if (dockZ.Key == dock.DockZoneID.Remove(0, 18))
                                    {
                                        RadDockLayout1.Controls.Remove(RadDockLayout1.FindControl("RadDock" + dock.UniqueName));
                                        CurrentDockStates.Remove(dock);
                                        goto AgainDock;
                                    }
                                }
                                dz.Docks.Clear();
                                CurrentDockZoneIds.Remove(dockZ);
                                Columna.Controls.Remove(dz);
                                break;
                            }
                        }
                        Celdas.Remove(Celda);
                        Fila.Controls.Remove(Columna);
                        goto Again;
                    }
                }
                myRowsH = Session["myRowsH"] == null ? new List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>() : (List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>)Session["myRowsH"];
                myRowsH.RemoveAll(x => x.Key == (Matriz.Count - 1).ToString());
                Session["myRowsH"] = myRowsH;
                if (Celdas.Count == 0)
                {
                    myColumnsH = Session["myColumnsH"] == null ? new List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>() : (List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>)Session["myColumnsH"];
                    myColumnsH.Clear();
                    Session["myColumnsH"] = myColumnsH;
                    tableDock.Rows.Clear();
                }
                tableDock.Controls.Remove(Fila);
            }

        }
    }

    protected void btnBorrarFilaFooter_Click(object sender, EventArgs e)
    {
        if (MatrizFooter.Count > 0)
        {
            string ID = MatrizFooter[MatrizFooter.Count - 1];
            if (CeldasFooter.GroupBy(x => x.Row).Select(x => new { Count = x.Count() }).Max(x => x.Count)
                == CeldasFooter.Where(x => x.Row == ID && x.rowspan == 1 && x.colspan == 1).Count())
            {
                MatrizFooter.Remove(ID);
                HtmlTableRow Fila = (HtmlTableRow)tableDockFooter.FindControl(ID);
            Again:
                foreach (CeldaHtml Celda in CeldasFooter)
                {
                    if (Celda.Row == ID)
                    {
                        HtmlTableCell Columna = (HtmlTableCell)Fila.FindControl(Celda.Key);
                        foreach (KeyValuePair<string, string> dockZ in CurrentDockZoneIdsFooter)
                        {
                            if (dockZ.Value == Celda.Key)
                            {
                                RadDockZone dz = (RadDockZone)Columna.FindControl(dockZ.Key);
                            AgainDock:
                                foreach (DockStateWithTemplate dock in CurrentDockStatesFooter)
                                {
                                    if (dockZ.Key == dock.DockZoneID.Remove(0, 18))
                                    {
                                        RadDockLayout1.Controls.Remove(RadDockLayout1.FindControl("RadDockFooter" + dock.UniqueName));
                                        CurrentDockStatesFooter.Remove(dock);
                                        goto AgainDock;
                                    }
                                }
                                dz.Docks.Clear();
                                CurrentDockZoneIdsFooter.Remove(dockZ);
                                Columna.Controls.Remove(dz);
                                break;
                            }
                        }
                        CeldasFooter.Remove(Celda);
                        Fila.Controls.Remove(Columna);
                        goto Again;
                    }
                }
                myRowsFooter = Session["myRowsFooter"] == null ? new List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>() : (List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>)Session["myRowsFooter"];
                myRowsFooter.RemoveAll(x => x.Key == (MatrizFooter.Count - 1).ToString());
                Session["myRowsFooter"] = myRowsFooter;
                if (CeldasFooter.Count == 0)
                {
                    myColumnsFooter = Session["myColumnsFooter"] == null ? new List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>() : (List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>)Session["myColumnsFooter"];
                    myColumnsFooter.Clear();
                    Session["myColumnsFooter"] = myColumnsFooter;
                    tableDockFooter.Rows.Clear();
                }
                tableDockFooter.Controls.Remove(Fila);
            }

        }
    }

    protected void BtnBorrarColumna_Click(object sender, EventArgs e)
    {
        if (Celdas.Count > 0)
        {

            int R = Matriz.Count;
            int C = Celdas.Sum(x => x.rowspan * x.colspan);
            List<CeldaHtml> Listado = new List<CeldaHtml>();
            for (int i = 0; i <= C; i += C / R)
            {
                int sum = 0;
                foreach (CeldaHtml cell in Celdas)
                {
                    sum += cell.colspan * cell.rowspan;
                    if (sum == i)
                    {
                        Listado.Add(cell);
                        break;
                    }
                }
            }
            if (Listado.Count == Matriz.Count)
            {
                myColumnsH = Session["myColumnsH"] == null ? new List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>() : (List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>)Session["myColumnsH"];
                myRowsH = Session["myRowsH"] == null ? new List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>() : (List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>)Session["myRowsH"];
                EliminarCeldas(Listado);
                myColumnsH.RemoveAll(x => x.Key == (C / R - 1).ToString());
                tableDock.Rows[0].Cells.RemoveAt(tableDock.Rows[0].Cells.Count - 1);
                if (Celdas.Count == 0)
                {
                    foreach (string ID in Matriz)
                    {
                        HtmlTableRow Fila = (HtmlTableRow)tableDock.FindControl(ID);
                        tableDock.Controls.Remove(Fila);
                    }
                    myRowsH.Clear();
                    myColumnsH.Clear();
                    Matriz.Clear();
                    tableDock.Rows.Clear();
                }
                Session["myRowsH"] = myRowsH;
                Session["myColumnsH"] = myColumnsH;
            }

        }
    }

    protected void BtnBorrarColumnaFooter_Click(object sender, EventArgs e)
    {
        if (CeldasFooter.Count > 0)
        {

            int R = MatrizFooter.Count;
            int C = CeldasFooter.Sum(x => x.rowspan * x.colspan);
            List<CeldaHtml> Listado = new List<CeldaHtml>();
            for (int i = 0; i <= C; i += C / R)
            {
                int sum = 0;
                foreach (CeldaHtml cell in CeldasFooter)
                {
                    sum += cell.colspan * cell.rowspan;
                    if (sum == i)
                    {
                        Listado.Add(cell);
                        break;
                    }
                }
            }
            if (Listado.Count == MatrizFooter.Count)
            {
                myColumnsFooter = Session["myColumnsFooter"] == null ? new List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>() : (List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>)Session["myColumnsFooter"];
                myRowsFooter = Session["myRowsFooter"] == null ? new List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>() : (List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>)Session["myRowsFooter"];
                EliminarCeldasFooter(Listado);
                myColumnsFooter.RemoveAll(x => x.Key == (C / R - 1).ToString());
                tableDockFooter.Rows[0].Cells.RemoveAt(tableDockFooter.Rows[0].Cells.Count - 1);
                if (CeldasFooter.Count == 0)
                {
                    foreach (string ID in MatrizFooter)
                    {
                        HtmlTableRow Fila = (HtmlTableRow)tableDockFooter.FindControl(ID);
                        tableDockFooter.Controls.Remove(Fila);
                    }
                    myRowsFooter.Clear();
                    myColumnsFooter.Clear();
                    MatrizFooter.Clear();
                    tableDockFooter.Rows.Clear();
                }
                Session["myRowsFooter"] = myRowsFooter;
                Session["myColumnsFooter"] = myColumnsFooter;
            }

        }
    }

    private void EliminarCeldas(List<CeldaHtml> Listado)
    {
        foreach (CeldaHtml Celda in Listado)
        {
            HtmlTableRow Fila = (HtmlTableRow)tableDock.FindControl(Celda.Row);
            HtmlTableCell Columna = (HtmlTableCell)Fila.FindControl(Celda.Key);
            foreach (KeyValuePair<string, string> dockZ in CurrentDockZoneIds)
            {
                if (dockZ.Value == Celda.Key)
                {
                    RadDockZone dz = (RadDockZone)Columna.FindControl(dockZ.Key);
                AgainDock:
                    foreach (DockStateWithTemplate dock in CurrentDockStates)
                    {
                        if (dockZ.Key == dock.DockZoneID.Remove(0, 18))
                        {
                            RadDockLayout1.Controls.Remove(RadDockLayout1.FindControl("RadDock" + dock.UniqueName));
                            CurrentDockStates.Remove(dock);
                            goto AgainDock;
                        }
                    }
                    dz.Docks.Clear();
                    CurrentDockZoneIds.Remove(dockZ);
                    Columna.Controls.Remove(dz);
                    break;
                }
            }
            Celdas.Remove(Celda);
            Fila.Controls.Remove(Columna);
        }
    }

    private void EliminarCeldasFooter(List<CeldaHtml> Listado)
    {
        foreach (CeldaHtml Celda in Listado)
        {
            HtmlTableRow Fila = (HtmlTableRow)tableDockFooter.FindControl(Celda.Row);
            HtmlTableCell Columna = (HtmlTableCell)Fila.FindControl(Celda.Key);
            foreach (KeyValuePair<string, string> dockZ in CurrentDockZoneIdsFooter)
            {
                if (dockZ.Value == Celda.Key)
                {
                    RadDockZone dz = (RadDockZone)Columna.FindControl(dockZ.Key);
                AgainDock:
                    foreach (DockStateWithTemplate dock in CurrentDockStatesFooter)
                    {
                        if (dockZ.Key == dock.DockZoneID.Remove(0, 18))
                        {
                            RadDockLayout1.Controls.Remove(RadDockLayout1.FindControl("RadDockFooter" + dock.UniqueName));
                            CurrentDockStatesFooter.Remove(dock);
                            goto AgainDock;
                        }
                    }
                    dz.Docks.Clear();
                    CurrentDockZoneIdsFooter.Remove(dockZ);
                    Columna.Controls.Remove(dz);
                    break;
                }
            }
            CeldasFooter.Remove(Celda);
            Fila.Controls.Remove(Columna);
        }
    }

    /*protected void btnMerge_Click(object sender, EventArgs e)
    {
        if (btnMerge.Text != "Aceptar")
        {
            pnlElemento.Enabled = false;
            btnBorrarFila.Enabled = false;
            BtnBorrarColumna.Enabled = false;
            btnFila.Enabled = false;
            btnColumna.Enabled = false;
            btnMerge.Text = "Aceptar";
            foreach (RadDock dock in RadDockLayout1.RegisteredDocks)
            {
                dock.Visible = false;
            }
            foreach (RadDockZone dockZone in RadDockLayout1.RegisteredZones)
            {
                dockZone.CssClass = "Celdas";
                dockZone.Attributes.Add("onclick", "selectMerge(this);");
            }
        }
        else
        {
            string[] seleccionados = hfSeleccionados.Value.Split(',');
            bool par = (seleccionados.Length - 1) / 2 == (seleccionados.Length - 1) / 2.0;
            hfSeleccionados.Value = "";
            List<KeyValuePair<int, string>> zones = new List<KeyValuePair<int, string>>();
            for (int i = 0; i < CurrentDockZoneIds.Count; i++)
            {
                zones.Add(new KeyValuePair<int, string>(i, CurrentDockZoneIds[i].Key));
            }
            var all = zones.SelectMany(x => seleccionados.Where(y => y != "").Where(y => x.Value == y.Remove(0, 18)), (x, y) => new KeyValuePair<int,string>(x.Key,x.Value)).ToList();
            int R =Matriz.Count;
            int C = Celdas.Sum(x => x.rowspan * x.colspan);

            List<CeldaHtmlMerge> agregados = new List<CeldaHtmlMerge>();
            foreach (KeyValuePair<int, string> elemento in all)
            {
                if (agregados.Count == 0)
                {
                    agregados.Add(new CeldaHtmlMerge(elemento.Key,elemento.Value,false,false,false,false));
                }
                else
                {
                    bool cumple = false;
                    foreach (CeldaHtmlMerge a in agregados)
                    {
                        if (elemento.Key == a.ID + 1)
                        {
                            cumple = true;
                            a.Right = true;
                            agregados.Add(new CeldaHtmlMerge(elemento.Key, elemento.Value, false, false, true, false));
                            break;
                        }
                        else if (elemento.Key == a.ID + C / R)
                        {
                            cumple = true;
                            a.Down = true;
                            agregados.Add(new CeldaHtmlMerge(elemento.Key, elemento.Value,true , false, false, false));
                            break;
                        }
                        
                    }
                    if (!cumple)
                        return;
                }
            }
            foreach (CeldaHtmlMerge a in agregados)
            {
                foreach (CeldaHtmlMerge elemento in agregados)
                {
                    if (elemento.ID == a.ID - 1)
                        a.Left = true;
                    else if (elemento.ID == a.ID - C / R)
                        a.Up = true;
                    else if (elemento.ID == a.ID + 1)
                        a.Right = true;
                    else if (elemento.ID == a.ID + C / R)
                        a.Down = true;
                }
            }
            if (agregados.Where(x => x.caras >= 2).Count() == agregados.Count())
            {
            }
            else if(agregados[0].caras == 1 && agregados[agregados.Count - 1].caras == 1
                    && agregados.Where(x => x.caras >= 2).Count() == agregados.Count() - 2)
            {
                for (int i = 1; i < agregados.Count - 2; i++)
                {
                    CeldaHtmlMerge primero = agregados[i];
                    CeldaHtmlMerge siguiente =  agregados[i+1];
                    if (primero.Up == siguiente.Up && primero.Right == siguiente.Right && primero.Down == siguiente.Down && primero.Left == siguiente.Left)
                    {
                    }
                    else
                        return;
                }
                if ((agregados[0].Down && agregados[agregados.Count - 1].Up)
                    || (agregados[0].Up && agregados[agregados.Count - 1].Down)
                    || (agregados[0].Left && agregados[agregados.Count - 1].Right)
                    || (agregados[0].Right && agregados[agregados.Count - 1].Left)
                    )
                {
                }
                else
                    return;
            }
            else
                return;
            

            int renglon = 0;
            int restante = agregados[0].ID;
            while (restante - C / R > 0)
            {
                restante -= C / R;
                renglon++;
            }
            renglon++;

            int colspan = agregados.Where(x => x.ID > agregados[0].ID && x.ID <= (C / R)* renglon - 1).Count();
            int rowspan = 0;
            int posicion = agregados[0].ID + C / R;

            while (agregados.Where(X => X.ID == posicion).Count() > 0 )
            {
                posicion += C / R;
                rowspan++;
            }
            CeldaHtml cell = Celdas.Where(x => x.Key == CurrentDockZoneIds.Where(y => y.Key == agregados[0].Key).FirstOrDefault().Value).FirstOrDefault();
            cell.colspan += colspan;
            cell.rowspan += rowspan;

            HtmlTableCell CeldaH = ((HtmlTableCell)tableDock.FindControl(cell.Row).FindControl(cell.Key));
            CeldaH.ColSpan = cell.colspan;
            CeldaH.RowSpan = cell.rowspan;

            EliminarCeldas(Celdas.Where(x => CurrentDockZoneIds.Where(y => agregados.Select(z => z.Key).Contains(y.Key) && y.Key != agregados[0].Key).Select(w => w.Value).Contains(x.Key)).ToList());
        }
    }*/

    protected void btnCancelar_Click(object sender, EventArgs e)
    {

    }

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod(EnableSession = true)]
    public static JsonResult guardarTexto(string id, string texto)
    {
        try
        {
            List<DockStateWithTemplate> docks;
            DockStateWithTemplate d;
            if (id.Contains("Footer"))
            {
                docks = HttpContext.Current.Session["CurrentDockStatesDynamicDocksFooter"] == null ? new List<DockStateWithTemplate>() : (List<DockStateWithTemplate>)HttpContext.Current.Session["CurrentDockStatesDynamicDocksFooter"];
                d = docks.Where(x => x.UniqueName == id.Replace("ctl00_MainContent_RadDockFooter", "")).FirstOrDefault();
                d.Text = texto;
                HttpContext.Current.Session["CurrentDockStatesDynamicDocksFooter"] = docks;
            }
            else
            {
                docks = HttpContext.Current.Session["CurrentDockStatesDynamicDocks"] == null ? new List<DockStateWithTemplate>() : (List<DockStateWithTemplate>)HttpContext.Current.Session["CurrentDockStatesDynamicDocks"];
                d = docks.Where(x => x.UniqueName == id.Replace("ctl00_MainContent_RadDock", "")).FirstOrDefault();
                d.Text = texto;
                HttpContext.Current.Session["CurrentDockStatesDynamicDocks"] = docks;
            }
            return new JsonResult(id, true, null);
        }
        catch (Exception ex)
        {
            return new JsonResult(null, false, ex.Message.ToString());
        }

    }


}

public class CeldaHtmlMerge
{
    public int ID { get; set; }
    public string Key { get; set; }
    public bool Up { get; set; }
    public bool Right { get; set; }
    public bool Left { get; set; }
    public bool Down { get; set; }
    public int caras
    {
        get
        {
            return (this.Up ? 1 : 0) + (this.Down ? 1 : 0) + (this.Left ? 1 : 0) + (this.Right ? 1 : 0);
        }
    }

    public CeldaHtmlMerge(int prID, string prKey, bool prUp, bool prRight, bool prLeft, bool prDown)
    {
        this.ID = prID;
        this.Key = prKey;
        this.Up = prUp;
        this.Right = prRight;
        this.Left = prLeft;
        this.Down = prDown;
    }
}

public class Dzones
{
    public int ID { get; set; }
    public string Key { get; set; }
    public string celda { get; set; }

    public Dzones(int prID, string prKey, string prCelda)
    {
        this.ID = prID;
        this.Key = prKey;
        this.celda = prCelda;
    }
}

public class DockTitleTemplate : ITemplate // creating a class, implementing the ITemplate interface
{
    TextBox txt = new TextBox();
    Button btn = new Button();
    LinkButton lnk = new LinkButton();
    RadDock dock;
    bool esTexto;
    Page pagina;

    public DockTitleTemplate(RadDock dock, bool texto, Page pp)
    {
        this.dock = dock;
        this.esTexto = texto;
        this.pagina = pp;
    }

    public void InstantiateIn(Control container)
    {
        if (esTexto)
        {
            lnk.ID = "lnk1" + Guid.NewGuid().ToString();
            lnk.Text = this.dock.Title;
            lnk.CssClass = "LinkTitle";
            lnk.OnClientClick = "mostrarTexto(this);return false;";

            txt.ID = "txt1" + Guid.NewGuid().ToString();
            txt.Text = this.dock.Title;
            txt.Attributes.Add("style", "visibility:hidden");
            txt.TextMode = TextBoxMode.MultiLine;

            btn.ID = "btn1" + Guid.NewGuid().ToString();
            btn.Text = "OK";
            btn.OnClientClick = "ocultarTexto(this);return false;";
            btn.Attributes.Add("style", "visibility:hidden");

            container.Controls.Add(txt);
            container.Controls.Add(lnk);
            container.Controls.Add(btn);
        }
        else
        {
            string id = "File" + Guid.NewGuid().ToString();
            string ids = "span" + Guid.NewGuid().ToString();
            string idm = "img" + Guid.NewGuid().ToString();

            Literal File = new Literal();
            File.ID = "Li" + Guid.NewGuid().ToString();
            File.Text = "<div id='" + id + "' class='upload' >" + "<img id='" + idm + "' src='" + dock.Title + "' alt='' />" +
                "</div>" +
                "<span id='" + ids + "' class='status' ></span>";//+
            container.Controls.Add(File);

            string script = "<script type='text/javascript'>" +
                "$(function() {" +
                    "var btnUpload = $('#" + id + "');" +
                    "var status = $('#" + ids + "');" +
                    "new AjaxUpload(btnUpload, {" +
                    "action: 'FileUpload.ashx'," +
                    "name: 'uploadfile'," +
                    "onSubmit: function(file, ext) {" +
                        "if (!(ext && /^(jpg|png|jpeg|gif)$/.test(ext))) {" +
                            "alert ('Solo JPG, PNG o GIF');" +
                            "return false;" +
                        "}" +
                        "status.text('Uploading...');" +
                    "}," +
                    "onComplete: function(file, response) {" +
                        "status.text('');" +
                        "if (response.toUpperCase() === '<PRE>SUCCESS</PRE>') {" +
                            "$('#" + idm + "').attr('src'," + (char)34 + "Imagenes/" + (char)34 + " + file);" +
                            "guardarImagen(btnUpload," + (char)34 + "Imagenes/" + (char)34 + " + file);" +
                        "}" +
                     "}" +
                    "});" +
                    "});" +
                "</script>";

            dock.DockMode = DockMode.Docked;
            dock.TitlebarContainer.Attributes.Add("style", "height:auto;");
            ScriptManager.RegisterStartupScript(pagina, pagina.GetType(), "Script" + id, script, false);
        }
    }
}












