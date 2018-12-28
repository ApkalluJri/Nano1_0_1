using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
//--------------------------
using System.ComponentModel;
using System.Globalization;
using System.Drawing;
using System.Collections;
using System.Data.SqlClient;

public delegate void DelegateFillDataControlMulti();
public delegate DataSet DelegateDataSetMulti();
public delegate DataSet DelegateDataSetWithIntKeyMulti(int key);
public delegate DataSet DelegateDataSetWithStringKeyMulti(string key);

public partial class FormsSystem_TTbuttonCatalogoMulti : System.Web.UI.UserControl
{
    private TTSecurity.Security MySecurity = new TTSecurity.Security();
    private TTFunctions.Functions myFunctions = new TTFunctions.Functions();

    private DelegateFillDataControlMulti fillDataControlFunction;
    public DelegateFillDataControlMulti FillDataControlFunction
    {
        get { return fillDataControlFunction; }
        set { fillDataControlFunction = value; }
    }

    private DelegateDataSetMulti getControlDataSetFunction;
    public DelegateDataSetMulti GetControlDataSetFunction
    {
        get { return getControlDataSetFunction; }
        set { getControlDataSetFunction = value; }
    }

    private DelegateDataSetWithIntKeyMulti getControlDataSetFunctionWithInt;
    public DelegateDataSetWithIntKeyMulti GetControlDataSetFunctionWithInt
    {
        get { return getControlDataSetFunctionWithInt; }
        set { getControlDataSetFunctionWithInt = value; }
    }

    private DelegateDataSetWithStringKeyMulti getControlDataSetFunctionWithString;
    public DelegateDataSetWithStringKeyMulti GetControlDataSetFunctionWithString
    {
        get { return getControlDataSetFunctionWithString; }
        set { getControlDataSetFunctionWithString = value; }
    }

    private System.Web.UI.Control parentWebControl;
    public System.Web.UI.Control ParentWebControl
    {
        get { return parentWebControl; }
        set { parentWebControl = value; }
    }

    private string url;

    private string idProceso;
    public string IdProceso
    {
        get { return idProceso; }
        set { idProceso = value; }
    }

    private string idProcesoPrincipal;
    public string IdProcesoPrincipal
    {
        get { return idProcesoPrincipal; }
        set { idProcesoPrincipal = value; }
    }

    private Control ccdControl
    {
        get { return Funcion.FindControlRecursive(this.Page, cddID); }
    }

    private string cddID;
    public string CDDId
    {
        get { return cddID; }
        set { cddID = value; }
    }

    private bool panelControlesVisible;
    public bool PanelControlesVisible
    {
        get { return panelControlesVisible; }
        set { panelControlesVisible = value; }
    }

    public ImageButton ImgButton
    {
        get { return this.cmdCatalogo; }
        set { this.cmdCatalogo = value; }
    }

    public Telerik.Web.UI.RadWindow WindowCatalogo
    {
        get { return this.windowCatalogo; }
        set { this.windowCatalogo = value; }
    }

    private System.Web.UI.Control webControl;
    [Category("Controls"), TypeConverter(typeof(WebControlConverterMulti))]
    public System.Web.UI.Control WebControl
    {
        get { return webControl; }
        set { webControl = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    override protected void OnInit(EventArgs e)
    {
        this.cmdCatalogo.Visible = SetSecurityAccess();
        this.Visible = this.cmdCatalogo.Visible;
        Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "CloseWindow" + cmdCatalogo.ClientID, @GenerateCloseWindowScript());
        base.OnInit(e);
    }

    private bool SetSecurityAccess()
    {
        bool returnValue = false;
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        try
        {
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "[dbo].[GetDatosAgregarMultirenglonPopup]";
            com.Parameters.AddWithValue("@IdProceso", idProceso);
            DataSet ds = db.Consulta(com);
            if (ds.Tables[0].Rows.Count > 0)
            {
                url = "~/WebForms/" + myFunctions.GenerateName(ds.Tables[0].Rows[0]["Nombre_Tabla"].ToString()) + "_Catalogo.aspx?MenuVisible=false";
                windowCatalogo.NavigateUrl = url;
                returnValue = true;
            }
        }
        catch
        { }
        return returnValue;
    }

    public string GenerateCloseWindowScript()
    {
        String result, callScript;

        result = "<script type='text/javascript'> ";
        result += "function " + cmdCatalogo.ClientID + "OnClientClose(oWnd,args){ ";
        result += " var button = $get('" + cmdCatalogo.ClientID + "'); ";
        result += " button.click(); } ";
        result += "</script> ";

        callScript = cmdCatalogo.ClientID + "OnClientClose";
        windowCatalogo.OnClientClose = callScript;

        return result;
    }

    protected void cmdCatalogo_Click(object sender, ImageClickEventArgs e)
    {
        Session["PageLoad"] = "1";
        Session["PageLoad"] = "1"; 
        string LlaveDependiente = "";
        string LlavePantallaPrincipal = "";
        bool operacion = !windowCatalogo.VisibleOnPageLoad;
        windowCatalogo.VisibleOnPageLoad = operacion;
        if (operacion)
        {
            Session[IdProceso + "Tipo_Transaccion"] = Session["Tipo_Transaccion"];
            LlaveDependiente = Funcion.RegresaDato("SELECT Nombre FROM TTMetadata WHERE ProcesoId = " + this.IdProceso + " AND Identificador = 1 AND Dependiente = 1");
            LlavePantallaPrincipal = Funcion.RegresaDato("SELECT Nombre FROM TTMetadata WHERE ProcesoId = " + this.IdProcesoPrincipal + " AND Identificador = 1 AND Dependiente = 0");
            Session[myFunctions.GenerateName(LlaveDependiente)] = Session[myFunctions.GenerateName(LlavePantallaPrincipal)];
            Session["Tipo_Transaccion"] = "New";
            Session["KeyValueInserted"] = null;
        }
        else
        {
            Session["Tipo_Transaccion"] = Session[IdProceso + "Tipo_Transaccion"];
            fillDataControlFunction();
            ViewState["ComboValue"] = null;
            ViewState["ComboDS"] = null;
        }
    }

    public void Catalogo_Click()
    {
        bool operacion = !windowCatalogo.VisibleOnPageLoad;
        windowCatalogo.VisibleOnPageLoad = operacion;
        if (operacion)
        {
            Session["tmpTipo_Transaccion"] = Session["Tipo_Transaccion"];
            Session["Tipo_Transaccion"] = "New";
            //ViewState["ComboValue"] = ((DropDownList)webControl).SelectedValue;
            Session["KeyValueInserted"] = null;
        }
        else
        {
            Session["Tipo_Transaccion"] = Session["tmpTipo_Transaccion"];
            fillDataControlFunction();
            ViewState["ComboValue"] = null;
            ViewState["ComboDS"] = null;
        }
    }

    protected void SetDdlValueFromKeyValue(DropDownList ddl, AjaxControlToolkit.CascadingDropDown cddCtrl)
    {
        ddl.SelectedValue = Session["KeyValueInserted"].ToString();
        if (cddCtrl != null)
            cddCtrl.SelectedValue = Session["KeyValueInserted"].ToString();
    }
}

#region TypeConverter
public class WebControlConverterMulti : StringConverter
{
    public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
    {
        return true;
    }
    public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
    {
        return false;
    }
    public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
    {
        if ((context == null) || (context.Container == null))
        {
            return null;
        }
        Object[] serverControls = this.GetControls(context.Container);
        if (serverControls != null)
        {
            return new StandardValuesCollection(serverControls);
        }
        return null;
    }
    private object[] GetControls(IContainer container)
    {
        ArrayList availableControls = new ArrayList();
        foreach (IComponent component in container.Components)
        {
            Control serverControl = component as Control;
            if (serverControl != null &&
            !(serverControl is Page) &&
            serverControl.ID != null &&
            serverControl.ID.Length != 0 &&
            IncludeControl(serverControl)
            )
            {
                availableControls.Add(serverControl.ID);
            }
        }
        availableControls.Sort(Comparer.Default);
        return availableControls.ToArray();
    }
    private bool IncludeControl(Control serverControl)
    {
        bool ReturnedVal = false;
        string ControlType = serverControl.GetType().ToString();
        switch (ControlType)
        {
            case "System.Web.UI.WebControls.DropDownList":
                ReturnedVal = true;
                break;
            case "System.Web.UI.WebControls.GridView":
                ReturnedVal = true;
                break;
            case "System.Web.UI.WebControls.TextBox":
                ReturnedVal = true;
                break;
        }
        return ReturnedVal;
    }
}
#endregion










