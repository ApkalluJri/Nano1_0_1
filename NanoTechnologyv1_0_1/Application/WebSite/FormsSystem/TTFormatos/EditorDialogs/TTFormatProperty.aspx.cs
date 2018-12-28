using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Reflection;
using Telerik.Web.UI;

public partial class FormsSystem_TTFormatos_TTFormatProperty : System.Web.UI.Page
{
    protected int reportItemIndex = 0;
    protected string reportItemType = string.Empty;
    private object myFormat = new object();
  
    protected void Page_Load(object sender, EventArgs e)
    {
        myFormat = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<object>(Request["format"].ToString());
        reportItemType = ((Dictionary<String, Object>)myFormat)["type"].ToString();

        if (!IsPostBack)
        { 
            GetItemProperties();
        }
    }

    private void GetItemProperties()
    {
        switch (reportItemType)
        {
            case "TTFormatsConfigurationsDate":
                TTFormatosCS.TTFormatsConfigurationsDate dColFun = new TTFormatosCS.TTFormatsConfigurationsDate();                
                GenerarGrid(dColFun);
                break;
            case "TTFormatsConfigurationsCurrency":
                TTFormatosCS.TTFormatsConfigurationsCurrency FMoneda = new TTFormatosCS.TTFormatsConfigurationsCurrency();
                GenerarGrid(FMoneda);
                break;
            case "TTFormatsConfigurationsNumbers":
                TTFormatosCS.TTFormatsConfigurationsNumbers FNumero = new TTFormatosCS.TTFormatsConfigurationsNumbers();
                GenerarGrid(FNumero);
                break;
            case "TTFormatsConfigurationsString":
                TTFormatosCS.TTFormatsConfigurationsString FTexto = new TTFormatosCS.TTFormatsConfigurationsString();
                GenerarGrid(FTexto);
                break;
            case "TTFormatsConfigurationsTime":
                TTFormatosCS.TTFormatsConfigurationsTime FHora = new TTFormatosCS.TTFormatsConfigurationsTime();
                GenerarGrid(FHora);
                break;
            default:
                break;
        }
    }

    private void GenerarGrid(object objeto)
    {
        foreach (KeyValuePair<string, object> elem in ((Dictionary<String, Object>)this.myFormat))
        {
            PropertyInfo pi = objeto.GetType().GetProperty(elem.Key);
            if (pi != null)
            {
                pi.SetValue(objeto, elem.Value, null);
            }
        }

        PropertyInfo[] prColFun = objeto.GetType().GetProperties();
        List<Propiedad> pColFun = new List<Propiedad>();
        foreach (PropertyInfo pi in prColFun)
        {
            object valor = objeto.GetType().GetProperty(pi.Name).GetValue(objeto, null);
            string tipo = objeto.GetType().GetProperty(pi.Name).PropertyType.ToString();
            string svalor = valor == null ? "" : valor.ToString();

            Propiedad p = new Propiedad(pi.Name, svalor, tipo.ToString(), reportItemIndex, reportItemType, 0);
            pColFun.Add(p);
        }
        grdProperties.DataSource = pColFun;
        grdProperties.DataBind();
    }

    protected void btnGrdPropertiesSave_Click(object sender, ImageClickEventArgs e)
    {
        Label txtArrayName;
        string regreso = Request["format"].ToString();
        if (grdProperties.Rows.Count > 0)
        {
            txtArrayName = (Label)grdProperties.Rows[0].FindControl("lblArrayNameIT");

            switch (txtArrayName.Text)
            {
                case "TTFormatsConfigurationsDate":
                    TTFormatosCS.TTFormatsConfigurationsDate dColFun = new TTFormatosCS.TTFormatsConfigurationsDate();
                    regreso = setProperties(dColFun, txtArrayName.Text);
                    break;
                case "TTFormatsConfigurationsCurrency":
                    TTFormatosCS.TTFormatsConfigurationsCurrency Moneda = new TTFormatosCS.TTFormatsConfigurationsCurrency();
                    regreso = setProperties(Moneda, txtArrayName.Text);
                    break;
                case "TTFormatsConfigurationsNumbers":
                    TTFormatosCS.TTFormatsConfigurationsNumbers Numero = new TTFormatosCS.TTFormatsConfigurationsNumbers();
                    regreso = setProperties(Numero, txtArrayName.Text);
                    break;
                case "TTFormatsConfigurationsString":
                    TTFormatosCS.TTFormatsConfigurationsString Texto = new TTFormatosCS.TTFormatsConfigurationsString();
                    regreso = setProperties(Texto, txtArrayName.Text);
                    break;
                case "TTFormatsConfigurationsTime":
                    TTFormatosCS.TTFormatsConfigurationsTime Hora = new TTFormatosCS.TTFormatsConfigurationsTime();
                    regreso = setProperties(Hora, txtArrayName.Text);
                    break;
                default:
                    break;
            }
            grdProperties.DataBind();
        }
        ClientScript.RegisterStartupScript(typeof(Page), "script", "<script language='javascript'>updateFromOpener('" + regreso + "');</script>");
    }

    private string setProperties(object objeto,string Tipo)
    {
        TextBox txtValor;
        Label txtTipo, txtNombre;
        foreach (GridViewRow grRow in grdProperties.Rows)
        {
            txtValor = (TextBox)grRow.FindControl("txtValorIT");
            txtTipo = (Label)grRow.FindControl("lblTipoIT");
            txtNombre = (Label)grRow.FindControl("lblNombreIT");
            object value = FormatByType(txtTipo.Text, txtValor.Text);
            objeto.GetType().GetProperty(txtNombre.Text).SetValue(objeto, value, null);
        }
        System.Web.Script.Serialization.JavaScriptSerializer oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        return oSerializer.Serialize(objeto).Replace("{", "{\"type\":\"" + Tipo + "\",");
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
        else if (type == "TTFormatosCS.TTFormatsConfigurationsEnumDatePositions")
            res = Enum.Parse(typeof(TTFormatosCS.TTFormatsConfigurationsEnumDatePositions), value, true);
        else if (type == "TTFormatosCS.TTFormatsConfigurationsEnumCurrencyLimit")
            res = Enum.Parse(typeof(TTFormatosCS.TTFormatsConfigurationsEnumCurrencyLimit), value, true);
        else if (type == "TTFormatosCS.TTFormatsConfigurationsEnumTimeFormat")
            res = Enum.Parse(typeof(TTFormatosCS.TTFormatsConfigurationsEnumTimeFormat), value, true);
        else
            res = null;

        return res;
    }

    protected void btnGrdPropertiesDel_Click(object sender, ImageClickEventArgs e)
    {
        string regreso = Request["format"].ToString();
        ClientScript.RegisterStartupScript(typeof(Page), "script", "<script language='javascript'>updateFromOpener('" + regreso + "');</script>");
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
                if (txtTipo.Text == "TTFormatosCS.TTFormatsConfigurationsEnumDatePositions")
                    ddlValor.DataSource = Enum.GetValues(typeof(TTFormatosCS.TTFormatsConfigurationsEnumDatePositions));
                else if (txtTipo.Text == "TTFormatosCS.TTFormatsConfigurationsEnumCurrencyLimit")
                    ddlValor.DataSource = Enum.GetValues(typeof(TTFormatosCS.TTFormatsConfigurationsEnumCurrencyLimit));
                else if (txtTipo.Text == "TTFormatosCS.TTFormatsConfigurationsEnumTimeFormat")
                    ddlValor.DataSource = Enum.GetValues(typeof(TTFormatosCS.TTFormatsConfigurationsEnumTimeFormat));
         
                ddlValor.DataBind();
                ddlValor.SelectedValue = txtValor.Text;
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

        public Propiedad(string n, object v, string t, int i, string an, double vd)
        {
            this._Nombre = n;
            this._Valor = v;
            this._Tipo = t;
            this._ArrayIndex = i;
            this._ArrayName = an;
            this._Valord = vd;
        }
    }
}

