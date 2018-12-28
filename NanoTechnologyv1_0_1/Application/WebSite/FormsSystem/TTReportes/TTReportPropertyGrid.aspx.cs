using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Reflection;
using Telerik.Web.UI;

public partial class FormsSystem_TTReportes_TTReportPropertyGrid : System.Web.UI.Page
{
    protected int reportItemIndex = 0;
    protected string reportItemType = string.Empty;
    private System.Collections.ArrayList myColumnsFunctions = new System.Collections.ArrayList();
    private System.Collections.ArrayList myColumns = new System.Collections.ArrayList();
    private System.Collections.ArrayList myRows = new System.Collections.ArrayList();
    private List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>> myRowsH = new List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>();
    private List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>> myColumnsH = new List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>();
    private List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>> myRowsFooter = new List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>();
    private List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>> myColumnsFooter = new List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>();

    protected void Page_Load(object sender, EventArgs e)
    {   
        reportItemType = Request["itemType"].ToString();
        reportItemIndex = int.Parse(Request["itemIndex"].ToString());

        if (!IsPostBack)
        {
            myRows = Session["myRows"] == null ? new ArrayList() : (ArrayList)Session["myRows"];
            myColumns = Session["myColumns"] == null ? new ArrayList() : (ArrayList)Session["myColumns"];
            myColumnsFunctions = Session["myColumnsFunctions"] == null ? new ArrayList() : (ArrayList)Session["myColumnsFunctions"];
            myRowsH = Session["myRowsH"] == null ? new List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>() : (List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>)Session["myRowsH"];
            myColumnsH = Session["myColumnsH"] == null ? new List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>() : (List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>)Session["myColumnsH"];
            myRowsFooter = Session["myRowsFooter"] == null ? new List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>() : (List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>)Session["myRowsFooter"];
            myColumnsFooter = Session["myColumnsFooter"] == null ? new List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>() : (List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>)Session["myColumnsFooter"];

            GetItemProperties();
        }
    }

    private void GetItemProperties()
    {
        switch (reportItemType)
        {
            case "myColumns":
                TTReportes.TTReportsConfigurationsColumns dCol;
                dCol = ((TTReportes.TTReportsConfigurationsColumns)myColumns[reportItemIndex]);
                PropertyInfo[] prCol = dCol.GetType().GetProperties();
                List<Propiedad> pCols = new List<Propiedad>();
                foreach (PropertyInfo pi in prCol)
                {
                    object valor = dCol.GetType().GetProperty(pi.Name).GetValue(dCol, null);
                    string tipo = typeof(TTReportes.TTReportsConfigurationsColumns).GetProperty(pi.Name).PropertyType.ToString();
                    string svalor = valor == null ? "" : valor.ToString();

                    Propiedad p = new Propiedad(pi.Name, svalor, tipo.ToString(), reportItemIndex, reportItemType,0);
                    pCols.Add(p);
                }
                grdProperties.DataSource = pCols;
                grdProperties.DataBind();

                break;
            case "myRows":
                TTReportes.TTReportsConfigurationsRows dRow;
                dRow = ((TTReportes.TTReportsConfigurationsRows)myRows[reportItemIndex]);
                PropertyInfo[] prRow = dRow.GetType().GetProperties();
                List<Propiedad> pRows = new List<Propiedad>();
                foreach (PropertyInfo pi in prRow)
                {
                    object valor = dRow.GetType().GetProperty(pi.Name).GetValue(dRow, null);
                    string tipo = typeof(TTReportes.TTReportsConfigurationsRows).GetProperty(pi.Name).PropertyType.ToString();
                    string svalor = valor == null ? "" : valor.ToString();
                    Propiedad p = new Propiedad(pi.Name, svalor, tipo.ToString(), reportItemIndex, reportItemType,0);
                    pRows.Add(p);
                }
                grdProperties.DataSource = pRows;
                grdProperties.DataBind();

                break;
            case "myColumnsFunctions":
                TTReportes.TTReportsConfigurationsFunctions dColFun;
                dColFun = ((TTReportes.TTReportsConfigurationsFunctions)myColumnsFunctions[reportItemIndex]);
                PropertyInfo[] prColFun = dColFun.GetType().GetProperties();
                List<Propiedad> pColFun = new List<Propiedad>();
                foreach (PropertyInfo pi in prColFun)
                {
                    object valor = dColFun.GetType().GetProperty(pi.Name).GetValue(dColFun, null);
                    string tipo = typeof(TTReportes.TTReportsConfigurationsFunctions).GetProperty(pi.Name).PropertyType.ToString();
                    string svalor = valor == null ? "" : valor.ToString();
                    Propiedad p = new Propiedad(pi.Name, svalor, tipo.ToString(), reportItemIndex, reportItemType,0);
                    pColFun.Add(p);
                }
                grdProperties.DataSource = pColFun;
                grdProperties.DataBind();

                break;

            case "myRowsHeader":
                TTReportes.TTReportsConfigurationscells dRowH;
                KeyValuePair<string,TTReportes.TTReportsConfigurationscells> kv = myRowsH.Where(x => x.Key == reportItemIndex.ToString()).FirstOrDefault();
                if (kv.Value == null)
                    dRowH = new TTReportes.TTReportsConfigurationscells();
                else
                    dRowH = kv.Value;
                PropertyInfo[] prRowH = dRowH.GetType().GetProperties();
                List<Propiedad> pRowH = new List<Propiedad>();
                foreach (PropertyInfo pi in prRowH)
                {
                    object valor = dRowH.GetType().GetProperty(pi.Name).GetValue(dRowH, null);
                    string tipo = typeof(TTReportes.TTReportsConfigurationscells).GetProperty(pi.Name).PropertyType.ToString();
                    
                    Propiedad p = new Propiedad(pi.Name, valor, tipo.ToString(), reportItemIndex, reportItemType,Convert.ToDouble(valor));
                    pRowH.Add(p);
                }
                grdProperties.DataSource = pRowH;
                grdProperties.DataBind();

                break;

            case "myColumnsHeader":
                TTReportes.TTReportsConfigurationscells dcolH;
                kv = myColumnsH.Where(x => x.Key == reportItemIndex.ToString()).FirstOrDefault();
                if (kv.Value == null)
                    dcolH = new TTReportes.TTReportsConfigurationscells();
                else
                    dcolH = kv.Value;
                PropertyInfo[] prColH = dcolH.GetType().GetProperties();
                List<Propiedad> pColH = new List<Propiedad>();
                foreach (PropertyInfo pi in prColH)
                {
                    object valor = dcolH.GetType().GetProperty(pi.Name).GetValue(dcolH, null);
                    string tipo = typeof(TTReportes.TTReportsConfigurationscells).GetProperty(pi.Name).PropertyType.ToString();
                    
                    Propiedad p = new Propiedad(pi.Name, valor, tipo.ToString(), reportItemIndex, reportItemType,Convert.ToDouble(valor));
                    pColH.Add(p);
                }
                grdProperties.DataSource = pColH;
                grdProperties.DataBind();

                break;
            case "myRowsFooter":
                TTReportes.TTReportsConfigurationscells dRowF;
                KeyValuePair<string, TTReportes.TTReportsConfigurationscells> kv2 = myRowsFooter.Where(x => x.Key == reportItemIndex.ToString()).FirstOrDefault();
                if (kv2.Value == null)
                    dRowF = new TTReportes.TTReportsConfigurationscells();
                else
                    dRowF = kv2.Value;
                PropertyInfo[] prRowF = dRowF.GetType().GetProperties();
                List<Propiedad> pRowF = new List<Propiedad>();
                foreach (PropertyInfo pi in prRowF)
                {
                    object valor = dRowF.GetType().GetProperty(pi.Name).GetValue(dRowF, null);
                    string tipo = typeof(TTReportes.TTReportsConfigurationscells).GetProperty(pi.Name).PropertyType.ToString();

                    Propiedad p = new Propiedad(pi.Name, valor, tipo.ToString(), reportItemIndex, reportItemType, Convert.ToDouble(valor));
                    pRowF.Add(p);
                }
                grdProperties.DataSource = pRowF;
                grdProperties.DataBind();

                break;
            case "myColumnsFooter":
                TTReportes.TTReportsConfigurationscells dcolF;
                kv2 = myColumnsFooter.Where(x => x.Key == reportItemIndex.ToString()).FirstOrDefault();
                if (kv2.Value == null)
                    dcolF = new TTReportes.TTReportsConfigurationscells();
                else
                    dcolF = kv2.Value;
                PropertyInfo[] prColF = dcolF.GetType().GetProperties();
                List<Propiedad> pColF = new List<Propiedad>();
                foreach (PropertyInfo pi in prColF)
                {
                    object valor = dcolF.GetType().GetProperty(pi.Name).GetValue(dcolF, null);
                    string tipo = typeof(TTReportes.TTReportsConfigurationscells).GetProperty(pi.Name).PropertyType.ToString();

                    Propiedad p = new Propiedad(pi.Name, valor, tipo.ToString(), reportItemIndex, reportItemType, Convert.ToDouble(valor));
                    pColF.Add(p);
                }
                grdProperties.DataSource = pColF;
                grdProperties.DataBind();

                break;
            default:
                break;
        }
        //ActualizaGridVision();
    }

    protected void btnGrdPropertiesSave_Click(object sender, ImageClickEventArgs e)
    {
        TextBox txtValor;
        Label txtTipo, txtArrayIndex, txtArrayName, txtNombre;

        if (grdProperties.Rows.Count > 0)
        {
            txtArrayIndex = (Label)grdProperties.Rows[0].FindControl("lblArrayIndexIT");
            txtArrayName = (Label)grdProperties.Rows[0].FindControl("lblArrayNameIT");

            switch (txtArrayName.Text)
            {
                case "myColumns":
                    int iCols = int.Parse(txtArrayIndex.Text);
                    myColumns = Session["myColumns"] == null ? new ArrayList() : (ArrayList)Session["myColumns"];
                    TTReportes.TTReportsConfigurationsColumns dCol;
                    dCol = ((TTReportes.TTReportsConfigurationsColumns)myColumns[iCols]);

                    foreach (GridViewRow grRow in grdProperties.Rows)
                    {
                        txtValor = (TextBox)grRow.FindControl("txtValorIT");
                        txtTipo = (Label)grRow.FindControl("lblTipoIT");
                        txtNombre = (Label)grRow.FindControl("lblNombreIT");
                        object value = FormatByType(txtTipo.Text, txtValor.Text);
                        dCol.GetType().GetProperty(txtNombre.Text).SetValue(dCol, value, null);
                    }
                    myColumns[iCols] = dCol;
                    Session["myColumns"] = myColumns;
                    break;
                case "myRows":
                    int iRows = int.Parse(txtArrayIndex.Text);
                    TTReportes.TTReportsConfigurationsRows dRow;
                    myRows = Session["myRows"] == null ? new ArrayList() : (ArrayList)Session["myRows"];
                    dRow = ((TTReportes.TTReportsConfigurationsRows)myRows[iRows]);

                    foreach (GridViewRow grRow in grdProperties.Rows)
                    {
                        txtValor = (TextBox)grRow.FindControl("txtValorIT");
                        txtTipo = (Label)grRow.FindControl("lblTipoIT");
                        txtNombre = (Label)grRow.FindControl("lblNombreIT");
                        object value = FormatByType(txtTipo.Text, txtValor.Text);
                        dRow.GetType().GetProperty(txtNombre.Text).SetValue(dRow, value, null);
                    }
                    myRows[iRows] = dRow;
                    Session["myRows"] = myRows;
                    break;
                case "myColumnsFunctions":
                    int iColFun = int.Parse(txtArrayIndex.Text);
                    TTReportes.TTReportsConfigurationsFunctions dColFun;
                    myColumnsFunctions = Session["myColumnsFunctions"] == null ? new ArrayList() : (ArrayList)Session["myColumnsFunctions"];
                    dColFun = ((TTReportes.TTReportsConfigurationsFunctions)myColumnsFunctions[iColFun]);

                    foreach (GridViewRow grRow in grdProperties.Rows)
                    {
                        txtValor = (TextBox)grRow.FindControl("txtValorIT");
                        txtTipo = (Label)grRow.FindControl("lblTipoIT");
                        txtNombre = (Label)grRow.FindControl("lblNombreIT");
                        object value = FormatByType(txtTipo.Text, txtValor.Text);
                        dColFun.GetType().GetProperty(txtNombre.Text).SetValue(dColFun, value, null);
                    }
                    myColumnsFunctions[iColFun] = dColFun;
                    Session["myColumnsFunctions"] = myColumnsFunctions;

                    break;
                case "myRowsHeader":
                    int iRowsHeader = int.Parse(txtArrayIndex.Text);
                    KeyValuePair<string, TTReportes.TTReportsConfigurationscells> dRowH;
                    myRowsH = Session["myRowsH"] == null ? new List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>() : (List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>)Session["myRowsH"];
                    KeyValuePair<string, TTReportes.TTReportsConfigurationscells> kv = myRowsH.Where(x => x.Key == iRowsHeader.ToString()).FirstOrDefault();

                    if (kv.Value == null)
                        dRowH = new KeyValuePair<string, TTReportes.TTReportsConfigurationscells>(iRowsHeader.ToString(), new TTReportes.TTReportsConfigurationscells());
                    else
                        dRowH = kv;

                    foreach (GridViewRow grRow in grdProperties.Rows)
                    {
                        txtTipo = (Label)grRow.FindControl("lblTipoIT");
                        txtNombre = (Label)grRow.FindControl("lblNombreIT");
                        object value = FormatByType(txtTipo.Text, ((RadNumericTextBox)grRow.FindControl("radValorIT")).Text);
                        dRowH.Value.GetType().GetProperty(txtNombre.Text).SetValue(dRowH.Value, value, null);
                    }
                    if (kv.Value == null)
                        myRowsH.Add(dRowH);
                    Session["myRowsH"] = myRowsH;
                    break;
                case "myColumnsHeader":
                    int iColsHeader = int.Parse(txtArrayIndex.Text);
                    KeyValuePair<string, TTReportes.TTReportsConfigurationscells> dColH;
                    myColumnsH = Session["myColumnsH"] == null ? new List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>() : (List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>)Session["myColumnsH"];
                    kv = myColumnsH.Where(x => x.Key == iColsHeader.ToString()).FirstOrDefault();

                    if (kv.Value == null)
                        dColH = new KeyValuePair<string, TTReportes.TTReportsConfigurationscells>(iColsHeader.ToString(), new TTReportes.TTReportsConfigurationscells());
                    else
                        dColH = kv;

                    foreach (GridViewRow grRow in grdProperties.Rows)
                    {
                        txtTipo = (Label)grRow.FindControl("lblTipoIT");
                        txtNombre = (Label)grRow.FindControl("lblNombreIT");
                        object value = FormatByType(txtTipo.Text, ((RadNumericTextBox)grRow.FindControl("radValorIT")).Text);
                        dColH.Value.GetType().GetProperty(txtNombre.Text).SetValue(dColH.Value, value, null);
                    }
                    if (kv.Value == null)
                        myColumnsH.Add(dColH);
                    Session["myColumnsH"] = myColumnsH;
                    break;
                case "myRowsFooter":
                    int iRowsFooter = int.Parse(txtArrayIndex.Text);
                    KeyValuePair<string, TTReportes.TTReportsConfigurationscells> dRowF;
                    myRowsFooter = Session["myRowsFooter"] == null ? new List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>() : (List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>)Session["myRowsFooter"];
                    KeyValuePair<string, TTReportes.TTReportsConfigurationscells> kv2 = myRowsFooter.Where(x => x.Key == iRowsFooter.ToString()).FirstOrDefault();

                    if (kv2.Value == null)
                        dRowF = new KeyValuePair<string, TTReportes.TTReportsConfigurationscells>(iRowsFooter.ToString(), new TTReportes.TTReportsConfigurationscells());
                    else
                        dRowF = kv2;

                    foreach (GridViewRow grRow in grdProperties.Rows)
                    {
                        txtTipo = (Label)grRow.FindControl("lblTipoIT");
                        txtNombre = (Label)grRow.FindControl("lblNombreIT");
                        object value = FormatByType(txtTipo.Text, ((RadNumericTextBox)grRow.FindControl("radValorIT")).Text);
                        dRowF.Value.GetType().GetProperty(txtNombre.Text).SetValue(dRowF.Value, value, null);
                    }
                    if (kv2.Value == null)
                        myRowsFooter.Add(dRowF);
                    Session["myRowsFooter"] = myRowsFooter;
                    break;
                case "myColumnsFooter":
                    int iColsFooter = int.Parse(txtArrayIndex.Text);
                    KeyValuePair<string, TTReportes.TTReportsConfigurationscells> dColF;
                    myColumnsFooter = Session["myColumnsFooter"] == null ? new List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>() : (List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>)Session["myColumnsFooter"];
                    kv = myColumnsFooter.Where(x => x.Key == iColsFooter.ToString()).FirstOrDefault();

                    if (kv.Value == null)
                        dColF = new KeyValuePair<string, TTReportes.TTReportsConfigurationscells>(iColsFooter.ToString(), new TTReportes.TTReportsConfigurationscells());
                    else
                        dColF = kv;

                    foreach (GridViewRow grRow in grdProperties.Rows)
                    {
                        txtTipo = (Label)grRow.FindControl("lblTipoIT");
                        txtNombre = (Label)grRow.FindControl("lblNombreIT");
                        object value = FormatByType(txtTipo.Text, ((RadNumericTextBox)grRow.FindControl("radValorIT")).Text);
                        dColF.Value.GetType().GetProperty(txtNombre.Text).SetValue(dColF.Value, value, null);
                    }
                    if (kv.Value == null)
                        myColumnsFooter.Add(dColF);
                    Session["myColumnsFooter"] = myColumnsFooter;
                    break;
                default:
                    break;
            }
            grdProperties.DataBind();
        }
        ClientScript.RegisterStartupScript(typeof(Page), "script", "<script language='javascript'>updateFromOpener();</script>");
        //GetItemProperties();
    }

    protected object FormatByType(string type, string value)
    {
        object res = null;

        if (type.Contains("Boolean"))
            res = Boolean.Parse(value);
        else if (type.Contains("Nullable") && value == String.Empty)
            res = null;
        else if (type.Contains("Int"))
            res = int.Parse(value);
        else if (type.Contains("Decimal"))
            res = Decimal.Parse(value);
        else if (type.Contains("Double"))
            res = double.Parse(value);
        else if (type.Contains("String"))
            res = value;
        else if (type == "TTReportes.TTReportsConfigurationsEnumFormatDate")
            res = Enum.Parse(typeof(TTReportes.TTReportsConfigurationsEnumFormatDate), value, true);
        else if (type == "TTReportes.TTReportsConfigurationsEnumfunctions")
            res = Enum.Parse(typeof(TTReportes.TTReportsConfigurationsEnumfunctions), value, true);
        else if (type == "TTReportes.TTReportsConfigurationsEnumOrderBy")
            res = Enum.Parse(typeof(TTReportes.TTReportsConfigurationsEnumOrderBy), value, true);
        else
            res = null;

        return res;
    }

    protected void btnGrdPropertiesDel_Click(object sender, ImageClickEventArgs e)
    {
        Label txtArrayIndex, txtArrayName;

        if (grdProperties.Rows.Count > 0)
        {
            txtArrayIndex = (Label)grdProperties.Rows[0].FindControl("lblArrayIndexIT");
            txtArrayName = (Label)grdProperties.Rows[0].FindControl("lblArrayNameIT");

            switch (txtArrayName.Text)
            {
                case "myColumns":
                    int iCols = int.Parse(txtArrayIndex.Text);
                    myColumns = Session["myColumns"] == null ? new ArrayList() : (ArrayList)Session["myColumns"];
                    myColumns.RemoveAt(iCols);
                    Session["myColumns"] = myColumns;
                    break;
                case "myRows":
                    int iRows = int.Parse(txtArrayIndex.Text);
                    myRows = Session["myRows"] == null ? new ArrayList() : (ArrayList)Session["myRows"];
                    myRows.RemoveAt(iRows);
                    Session["myRows"] = myRows;
                    break;
                case "myColumnsFunctions":
                    int iColFun = int.Parse(txtArrayIndex.Text);
                    myColumnsFunctions = Session["myColumnsFunctions"] == null ? new ArrayList() : (ArrayList)Session["myColumnsFunctions"];
                    myColumnsFunctions.RemoveAt(iColFun);
                    Session["myColumnsFunctions"] = myColumnsFunctions;
                    break;
                case "myRowsHeader":
                    int iRowsH = int.Parse(txtArrayIndex.Text);
                    myRowsH = Session["myRowsH"] == null ? new List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>() : (List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>)Session["myRowsH"];
                    myRowsH.RemoveAll(x => x.Key == iRowsH.ToString());
                    Session["myRowsH"] = myRowsH;
                    break;
                case "myColumnsHeader":
                    int iColsH = int.Parse(txtArrayIndex.Text);
                    myColumnsH = Session["myColumnsH"] == null ? new List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>() : (List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>)Session["myColumnsH"];
                    myColumnsH.RemoveAll(x => x.Key == iColsH.ToString());
                    Session["myColumnsH"] = myColumnsH;
                    break;
                case "myRowsFooter":
                    int iRowsF = int.Parse(txtArrayIndex.Text);
                    myRowsFooter = Session["myRowsFooter"] == null ? new List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>() : (List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>)Session["myRowsFooter"];
                    myRowsFooter.RemoveAll(x => x.Key == iRowsF.ToString());
                    Session["myRowsFooter"] = myRowsFooter;
                    break;
                case "myColumnsFooter":
                    int iColsF = int.Parse(txtArrayIndex.Text);
                    myColumnsFooter = Session["myColumnsFooter"] == null ? new List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>() : (List<KeyValuePair<string, TTReportes.TTReportsConfigurationscells>>)Session["myColumnsFooter"];
                    myColumnsFooter.RemoveAll(x => x.Key == iColsF.ToString());
                    Session["myColumnsFooter"] = myColumnsFooter;
                    break;
                default:
                    break;
            }
            grdProperties.DataBind();
        }
        ClientScript.RegisterStartupScript(typeof(Page), "script", "<script language='javascript'>updateFromOpener();</script>");
        //GetItemProperties();
    }

    protected void ddlValorIT_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlValor = (DropDownList)sender;
        GridViewRow gvrow = (GridViewRow)ddlValor.NamingContainer;
        TextBox txtValor = (TextBox)gvrow.FindControl("txtValorIT");

        txtValor.Text = ddlValor.SelectedValue.ToString();
    }

    protected void grdProperties_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txtValor = (TextBox)e.Row.FindControl("txtValorIT");
            Label txtTipo = (Label)e.Row.FindControl("lblTipoIT");
            DropDownList ddlValor = (DropDownList)e.Row.FindControl("ddlValorIT");
            AjaxControlToolkit.MaskedEditExtender meeValor = (AjaxControlToolkit.MaskedEditExtender)e.Row.FindControl("meeValorIT");
            RadNumericTextBox radnumeric = (RadNumericTextBox)e.Row.FindControl("radValorIT");

            if (txtTipo.Text == "System.String")
            {
                radnumeric.Value = 0;
                meeValor.Enabled = false;
                txtValor.Visible = true;
                ddlValor.Visible = false;
                radnumeric.Visible = false;
            }
            else if (txtTipo.Text == "System.Boolean")
            {
                radnumeric.Value = 0;
                meeValor.Enabled = false;
                txtValor.Visible = false;
                ddlValor.Visible = true;
                radnumeric.Visible = false;
                ddlValor.Items.Add(new ListItem(Boolean.TrueString));
                ddlValor.Items.Add(new ListItem(Boolean.FalseString));

                ddlValor.SelectedValue = txtValor.Text;
            }
            else if (txtTipo.Text.Contains("Decimal") )
            {
                radnumeric.Value = 0;
                radnumeric.Visible = false;
                txtValor.Visible = true;
                ddlValor.Visible = false;
                meeValor.TargetControlID = txtValor.ID;
                meeValor.MaskType = AjaxControlToolkit.MaskedEditType.Number;
                meeValor.Mask = "9999999999.99";
                meeValor.AutoComplete = false;
                meeValor.InputDirection = AjaxControlToolkit.MaskedEditInputDirection.LeftToRight;
                meeValor.Enabled = true;

            }
            else if(txtTipo.Text.Contains("Double"))
            {
                radnumeric.Visible = true;
                txtValor.Visible = false;
                ddlValor.Visible = false;
                meeValor.Enabled = false;

            }
            else if (txtTipo.Text.Contains("Int"))
            {
                radnumeric.Value = 0;
                radnumeric.Visible = false;
                txtValor.Visible = true;
                ddlValor.Visible = false;
                meeValor.TargetControlID = txtValor.ID;
                meeValor.MaskType = AjaxControlToolkit.MaskedEditType.Number;
                meeValor.Mask = "9999999999";
                meeValor.AutoComplete = false;
                meeValor.InputDirection = AjaxControlToolkit.MaskedEditInputDirection.LeftToRight;
                meeValor.Enabled = true;
            }
            else
            {
                radnumeric.Value = 0;
                radnumeric.Visible = false;
                txtValor.Visible = false;
                ddlValor.Visible = true;
                meeValor.Enabled = false;
                if (txtTipo.Text == "TTReportes.TTReportsConfigurationsEnumFormatDate")
                    ddlValor.DataSource = Enum.GetValues(typeof(TTReportes.TTReportsConfigurationsEnumFormatDate));
                else if (txtTipo.Text == "TTReportes.TTReportsConfigurationsEnumfunctions")
                    ddlValor.DataSource = Enum.GetValues(typeof(TTReportes.TTReportsConfigurationsEnumfunctions));
                else if (txtTipo.Text == "TTReportes.TTReportsConfigurationsEnumOrderBy")
                    ddlValor.DataSource = Enum.GetValues(typeof(TTReportes.TTReportsConfigurationsEnumOrderBy));

                ddlValor.DataBind();
                ddlValor.SelectedValue = txtValor.Text;
            }
        }
    }
}

public class Propiedad
{
    private string _Nombre;
    public string Nombre
    {
        get
        {
            return _Nombre;
        }
        set
        {
            this._Nombre = value;
        }
    }

    private object _Valor;
    public object Valor
    {
        get
        {
            return _Valor;
        }
        set
        {
            this._Valor = value;
        }
    }

    private double _Valord;
    public double Valord
    {
        get
        {
            return _Valord;
        }
        set
        {
            this._Valord = value;
        }
    }

    private string _Tipo;
    public string Tipo
    {
        get
        {
            return _Tipo;
        }
        set
        {
            this._Tipo = value;
        }
    }

    private int _ArrayIndex;
    public int ArrayIndex
    {
        get
        {
            return _ArrayIndex;
        }
        set
        {
            this._ArrayIndex = value;
        }
    }

    private string _ArrayName;
    public string ArrayName
    {
        get
        {
            return _ArrayName;
        }
        set
        {
            this._ArrayName = value;
        }
    }

    public Propiedad()
    { }

    public Propiedad(string n, object v, string t, int i, string an,double vd)
    {
        this._Nombre = n;
        this._Valor = v;
        this._Tipo = t;
        this._ArrayIndex = i;
        this._ArrayName = an;
        this._Valord = vd;
    }
}







