using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class FormsSystem_TTPermisos_TTPermisos_por_modulo_Lista : TTBasePage.TTBasePage
{
    private TTPermisos_por_moduloCS.objectBussinessTTPermisos_por_modulo MyDataTTPermisos_Por_Modulo = new TTPermisos_por_moduloCS.objectBussinessTTPermisos_por_modulo();
    private TTFunctions.FillGridFunctions MyFillGridFunctions = new TTFunctions.FillGridFunctions();
    public int iProcess = 6326;

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadSecurityPage();
        MyTraductor = new TTTraductor.Traductor(myUserData.GetHashCode());
        SetupGrid();

        if (!IsPostBack)
        {
            Label lblTitulo = (Label)this.Page.Master.FindControl("lblTitulo");
            lblTitulo.Text = "Permisos por Módulo";
            lblTitulo.DataBind();
            this.Title = lblTitulo.Text;
        }
    }

    private void SetupGrid()
    {
        grvPermisos.Columns.Clear();
        TTFunctions.FillGridFunctions.GridCrossField Column = new TTFunctions.FillGridFunctions.GridCrossField();
        Column.Command = new SqlCommand("sp_selAllTTGrupo_de_Usuario");
        Column.ColumnDisplay = "Descripcion";
        Column.ColumnValue = "IdGrupoUsuario";
        TTFunctions.FillGridFunctions.GridCrossField Row = new TTFunctions.FillGridFunctions.GridCrossField();
        Row.Command = new SqlCommand("sp_selAllTTModulo");
        Row.ColumnDisplay = "Nombre";
        Row.ColumnValue = "IdModulo";
        FillGridCross(Column, Row);
    }

    private void FillGridCross(TTFunctions.FillGridFunctions.GridCrossField Column, TTFunctions.FillGridFunctions.GridCrossField Row)
    {
        DataSet dsPermisosPorModulo, dsPermisosUsuario, dsOperaciones;
        DataTable dtGrid = new DataTable();
        DataColumn dtColumn; 
        
        TTPermisos_por_moduloCS.TTPermisos_por_moduloFilters filter = new TTPermisos_por_moduloCS.TTPermisos_por_moduloFilters();
        MyDataTTPermisos_Por_Modulo.Filters = new TTPermisos_por_moduloCS.TTPermisos_por_moduloFilters[1];
        MyDataTTPermisos_Por_Modulo.Filters[0] = filter;
        dsPermisosUsuario = MyDataTTPermisos_Por_Modulo.SelAll(true);  

        TTDataLayerCS.BD MyConexion = new TTDataLayerCS.BD();
        dsPermisosPorModulo = MyConexion.Consulta(Column.Command); 
        dsOperaciones = MyConexion.Consulta(Row.Command);

        //------------Crea las columnas...----------------------
        foreach (DataColumn dc in dsPermisosPorModulo.Tables[0].Columns)
        {
            dtColumn = new DataColumn(dc.ColumnName);
            dtGrid.Columns.Add(dtColumn);
        }
        CreateTemplateLabelColumn("IdGrupoUsuario", "IdGrupoUsuario", false);
        CreateTemplateLabelColumn("Descripcion", "Descripcion", true);
        //------------------------------------------------------
        foreach (DataRow drOp in dsOperaciones.Tables[0].Rows)
        {
            dtColumn = new DataColumn(drOp["Nombre"].ToString());
            dtGrid.Columns.Add(dtColumn);
            dtColumn = new DataColumn("Id" + drOp["Nombre"].ToString());
            dtGrid.Columns.Add(dtColumn);

            CreateTemplateLabelColumn("Id" + drOp["Nombre"].ToString(), drOp["Nombre"].ToString(), false);
            CreateTemplateCheckBoxColumn(drOp["Nombre"].ToString(), "Id" + drOp["Nombre"].ToString(), true, true);
        }
        //------------------------------------------------------
        foreach (DataRow dr in dsPermisosPorModulo.Tables[0].Rows)
        {
            DataRow dtRow = dtGrid.NewRow();

            foreach (DataColumn dc in dsPermisosPorModulo.Tables[0].Columns)
                dtRow[dc.ColumnName] = dr[dc.ColumnName];

            foreach (DataRow drc in dsOperaciones.Tables[0].Rows)
            {
                string IdRow = "Id" + drc["Nombre"].ToString();
                dtRow[IdRow] = drc["IdModulo"].ToString();
                dtRow[drc["Nombre"].ToString()] = false;
                foreach (DataRow drPermisos in dsPermisosUsuario.Tables[0].Rows)
                    if (
                        dr["IdGrupoUsuario"].ToString().TrimEnd(' ') == drPermisos["TTPermisos_por_modulo_IdGrupoUsuario"].ToString().TrimEnd(' ')
                        && drc["IdModulo"].ToString().TrimEnd(' ') == drPermisos["TTPermisos_por_modulo_IdModulo"].ToString().TrimEnd(' '))
                        dtRow[drc["Nombre"].ToString()] = true;
            }
            dtGrid.Rows.Add(dtRow);
        }
        //------------------------------------------------------
        grvPermisos.DataSource = dtGrid;
        grvPermisos.DataBind();
    }

    protected void cmdAcept_Click(object sender, EventArgs e)
    {
        string result = Save();
        if (result != "")
            ShowAlert(result);
        else
            Response.Redirect("~/FormsSystem/DefaultAdministracion.aspx");

        SetupGrid();
    }

    private string Save()
    {
        try
        {
            LoadSecurityPage();
            TTDataLayerCS.BD MyConexion = new TTDataLayerCS.BD();
            MyConexion.EjecutaDelete(new SqlCommand("Delete From TTPermisos_por_Modulo"), myUserData, new TTDataLayerCS.DataLayerFieldsBitacora("", iProcess));

            CheckBox checkBoxModulo;
            Label labelModulo;
            string idGrupoUsuario, idModulo;

            foreach (Telerik.Web.UI.GridDataItem gvrow in grvPermisos.Items)
            {
                idGrupoUsuario = ((Label)gvrow.FindControl("lblIdGrupoUsuarioIT")).Text;

                for (int i = 4; i < gvrow.Cells.Count; i += 2)
                {
                    labelModulo = (Label)gvrow.Cells[i].Controls[0];
                    checkBoxModulo = (CheckBox)gvrow.Cells[i + 1].Controls[0];

                    if (labelModulo != null && checkBoxModulo != null)
                    {
                        idModulo = labelModulo.Text;
                        if (checkBoxModulo.Checked)
                            SaveRowDataPermisos(idGrupoUsuario, idModulo);
                    }
                }
            }

            return "¡Datos guardados satisfactoriamente!";
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
    }

    private void SaveRowDataPermisos(string idGrupoUsuario, string idModulo)
    {
        MyDataTTPermisos_Por_Modulo.IdGrupoUsuario = MyFunctions.FormatNumberNull(idGrupoUsuario);
        MyDataTTPermisos_Por_Modulo.IdModulo = MyFunctions.FormatNumberNull(idModulo);
        MyDataTTPermisos_Por_Modulo.Insert(myUserData, new TTDataLayerCS.DataLayerFieldsBitacora("", iProcess));

    }

    private void CreateTemplateControlColumn(string header, string dataField, Control control, bool checkBoxHeaderVisible, bool visible)
    {
        Telerik.Web.UI.GridTemplateColumn gridColumn = new Telerik.Web.UI.GridTemplateColumn();

        gridColumn.HeaderTemplate = new GridViewTemplate(ListItemType.Header, header, control, checkBoxHeaderVisible);
        gridColumn.ItemTemplate = new GridViewTemplate(ListItemType.Item, dataField, header, control, checkBoxHeaderVisible);
        gridColumn.Visible = visible;

        grvPermisos.MasterTableView.Columns.Add(gridColumn);
    }

    private void CreateTemplateLabelColumn(string header, string dataField, bool visible)
    {
        Telerik.Web.UI.GridTemplateColumn gridColumn = new Telerik.Web.UI.GridTemplateColumn();

        gridColumn.HeaderTemplate = new LabelTemplate(ListItemType.Header, header);
        gridColumn.ItemTemplate = new LabelTemplate(ListItemType.Item, dataField, header);
        gridColumn.Visible = visible;

        grvPermisos.MasterTableView.Columns.Add(gridColumn);
    }

    private void CreateTemplateCheckBoxColumn(string header, string dataField, bool checkBoxHeaderVisible, bool visible)
    {
        Telerik.Web.UI.GridTemplateColumn gridColumn = new Telerik.Web.UI.GridTemplateColumn();

        gridColumn.HeaderTemplate = new CheckBoxTemplate(ListItemType.Header, header, checkBoxHeaderVisible);
        gridColumn.ItemTemplate = new CheckBoxTemplate(ListItemType.Item, dataField, header, checkBoxHeaderVisible);
        gridColumn.Visible = visible;

        grvPermisos.MasterTableView.Columns.Add(gridColumn);
    }

    protected void cmdCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/FormsSystem/DefaultAdministracion.aspx");
    }
}

public class GridViewTemplate : ITemplate
{
    ListItemType _templateType;
    string _columnName;
    public System.Web.UI.Control _webControl;// = new Control();
    bool _headerCheckBoxVisible = false;
    string _bindColumn;

    public GridViewTemplate(ListItemType type, string colname, System.Web.UI.Control webControl, bool headerVisible)
    {
        _templateType = type;
        _columnName = colname;
        _webControl = webControl;
        _headerCheckBoxVisible = headerVisible;
    }

    public GridViewTemplate(ListItemType type, string colname, string bindColumn, System.Web.UI.Control webControl, bool headerVisible)
    {
        _templateType = type;
        _columnName = colname;
        _webControl = webControl;
        _headerCheckBoxVisible = headerVisible;
        _bindColumn = bindColumn;
    }

    void ITemplate.InstantiateIn(System.Web.UI.Control container)
    {
        switch (_templateType)
        {
            case ListItemType.Header:
                //----------------------------------------------------
                CheckBox chkbox = new CheckBox();
                chkbox.Attributes.Add("onclick", "ToggleCheck(this, this.checked)");
                chkbox.ID = "chkbox" + _columnName + "Header";
                chkbox.Visible = _headerCheckBoxVisible;
                container.Controls.Add(chkbox);
                //----------------------------------------------------
                Label lbl = new Label();
                lbl.Text = _columnName;
                lbl.ID = "lbl" + _columnName + "Header";
                container.Controls.Add(lbl);
                break;
            case ListItemType.AlternatingItem:
            case ListItemType.Item:                
                _webControl.ID = (_webControl.ID == String.Empty || _webControl.ID == null) ? "webCtl" + _columnName + "IT" : _webControl.ID;
                _webControl.DataBinding += new EventHandler(webControl_DataBinding);
                _webControl.EnableViewState = true;
                container.Controls.Add(_webControl);
                //----------------------------------------------------
                //CheckBox chkbox1 = new CheckBox();
                //chkbox1.ID = (_webControl.ID == String.Empty || _webControl.ID == null) ? "webCtl" + _columnName + "IT" : _webControl.ID;
                //chkbox1.DataBinding += new EventHandler(webControl_DataBinding);
                //chkbox1.EnableViewState = true;
                //container.Controls.Add(chkbox1);
                //----------------------------------------------------
                break;
            case ListItemType.EditItem:
                break;
            case ListItemType.Footer:
                break;
        }
    }

    void webControl_DataBinding(object sender, EventArgs e)
    {
        Control _webControl = (Control)sender;
        Telerik.Web.UI.GridDataItem container = (Telerik.Web.UI.GridDataItem)_webControl.NamingContainer;
        object dataValue = DataBinder.Eval(container.DataItem, _bindColumn == String.Empty ? _columnName : _bindColumn);
        if (dataValue != DBNull.Value && dataValue != null)
        {
            if (sender is TextBox)
                (sender as TextBox).Text = dataValue.ToString();
            else if (sender is Label)
                (sender as Label).Text = dataValue.ToString();
            else if (sender is CheckBox)
            {
                bool isChecked;
                if (bool.TryParse(dataValue.ToString(), out isChecked))
                    (sender as CheckBox).Checked = isChecked;
            }
        }
    }
}

public class LabelTemplate : ITemplate
{
    ListItemType _templateType;
    string _columnName;        
    string _bindColumn;

    public LabelTemplate(ListItemType type, string colname)
    {
        _templateType = type;
        _columnName = colname;                
    }

    public LabelTemplate(ListItemType type, string colname, string bindColumn)
    {
        _templateType = type;
        _columnName = colname;                
        _bindColumn = bindColumn;
    }

    void ITemplate.InstantiateIn(System.Web.UI.Control container)
    {
        switch (_templateType)
        {
            case ListItemType.Header:
                //----------------------------------------------------
                Label lbl = new Label();
                lbl.Text = _columnName;
                lbl.ID = "lbl" + _columnName + "Header";
                container.Controls.Add(lbl);
                break;
            case ListItemType.AlternatingItem:
            case ListItemType.Item:
                //----------------------------------------------------
                Label lblItem = new Label();
                lblItem.ID = "lbl" + _columnName + "IT";
                lblItem.DataBinding += new EventHandler(webControl_DataBinding);
                lblItem.EnableViewState = true;
                container.Controls.Add(lblItem);
                //----------------------------------------------------
                break;
            case ListItemType.EditItem:
                break;
            case ListItemType.Footer:
                break;
        }
    }

    void webControl_DataBinding(object sender, EventArgs e)
    {
        Control _webControl = (Control)sender;
        Telerik.Web.UI.GridDataItem container = (Telerik.Web.UI.GridDataItem)_webControl.NamingContainer;
        object dataValue = DataBinder.Eval(container.DataItem, _bindColumn == String.Empty ? _columnName : _bindColumn);
        if (dataValue != DBNull.Value && dataValue != null)
        {
            if (sender is TextBox)
                (sender as TextBox).Text = dataValue.ToString();
            else if (sender is Label)
                (sender as Label).Text = dataValue.ToString();
            else if (sender is CheckBox)
            {
                bool isChecked;
                if (bool.TryParse(dataValue.ToString(), out isChecked))
                    (sender as CheckBox).Checked = isChecked;
            }
        }
    }
}

public class CheckBoxTemplate : ITemplate
{
    ListItemType _templateType;
    string _columnName;
    bool _headerCheckBoxVisible = false;
    string _bindColumn;

    public CheckBoxTemplate(ListItemType type, string colname, bool headerVisible)
    {
        _templateType = type;
        _columnName = colname;
        _headerCheckBoxVisible = headerVisible;
    }

    public CheckBoxTemplate(ListItemType type, string colname, string bindColumn, bool headerVisible)
    {
        _templateType = type;
        _columnName = colname;
        _headerCheckBoxVisible = headerVisible;
        _bindColumn = bindColumn;
    }

    void ITemplate.InstantiateIn(System.Web.UI.Control container)
    {
        switch (_templateType)
        {
            case ListItemType.Header:
                //----------------------------------------------------
                CheckBox chkbox = new CheckBox();
                chkbox.Attributes.Add("onclick", "ToggleCheck(this, this.checked)");
                chkbox.ID = "chkbox" + _columnName + "Header";
                chkbox.Visible = _headerCheckBoxVisible;
                container.Controls.Add(chkbox);
                //----------------------------------------------------
                Label lbl = new Label();
                lbl.Text = _columnName;
                lbl.ID = "lbl" + _columnName + "Header";
                container.Controls.Add(lbl);
                break;
            case ListItemType.AlternatingItem:
            case ListItemType.Item:
                //----------------------------------------------------
                CheckBox chkItem = new CheckBox();
                chkItem.ID = "chk" + _columnName + "IT";
                chkItem.DataBinding += new EventHandler(webControl_DataBinding);
                chkItem.EnableViewState = true;
                container.Controls.Add(chkItem);
                //----------------------------------------------------
                break;
            case ListItemType.EditItem:
                break;
            case ListItemType.Footer:
                break;
        }
    }

    void webControl_DataBinding(object sender, EventArgs e)
    {
        Control _webControl = (Control)sender;
        Telerik.Web.UI.GridDataItem container = (Telerik.Web.UI.GridDataItem)_webControl.NamingContainer;
        object dataValue = DataBinder.Eval(container.DataItem, _bindColumn == String.Empty ? _columnName : _bindColumn);
        if (dataValue != DBNull.Value && dataValue != null)
        {
            if (sender is TextBox)
                (sender as TextBox).Text = dataValue.ToString();
            else if (sender is Label)
                (sender as Label).Text = dataValue.ToString();
            else if (sender is CheckBox)
            {
                bool isChecked;
                if (bool.TryParse(dataValue.ToString(), out isChecked))
                    (sender as CheckBox).Checked = isChecked;
            }
        }
    }
}







