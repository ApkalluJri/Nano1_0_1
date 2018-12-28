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
using System.Reflection;

public delegate void DelegateFillDataControlMultiConsult();
public delegate DataSet DelegateDataSetMultiConsult();
public delegate DataSet DelegateDataSetWithIntKeyMultiConsult(int key);
public delegate DataSet DelegateDataSetWithStringKeyMultiConsult(string key);

public partial class FormsSystem_TTbuttonCatalogoMultiConsult : System.Web.UI.UserControl
{
    private TTSecurity.Security MySecurity = new TTSecurity.Security();
    private TTFunctions.Functions myFunctions = new TTFunctions.Functions();

    private DelegateFillDataControlMultiConsult fillDataControlFunction;
    public DelegateFillDataControlMultiConsult FillDataControlFunction
    {
        get { return fillDataControlFunction; }
        set { fillDataControlFunction = value; }
    }

    private DelegateDataSetMultiConsult getControlDataSetFunction;
    public DelegateDataSetMultiConsult GetControlDataSetFunction
    {
        get { return getControlDataSetFunction; }
        set { getControlDataSetFunction = value; }
    }

    private DelegateDataSetWithIntKeyMultiConsult getControlDataSetFunctionWithInt;
    public DelegateDataSetWithIntKeyMultiConsult GetControlDataSetFunctionWithInt
    {
        get { return getControlDataSetFunctionWithInt; }
        set { getControlDataSetFunctionWithInt = value; }
    }

    private DelegateDataSetWithStringKeyMultiConsult getControlDataSetFunctionWithString;
    public DelegateDataSetWithStringKeyMultiConsult GetControlDataSetFunctionWithString
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

    private string idLlaveModificar;
    public string IdLlaveModificar
    {
        get { return idLlaveModificar; }
        set { idLlaveModificar = value; }
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
    [Category("Controls"), TypeConverter(typeof(WebControlConverterMultiConsult))]
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
        string NombrePantalla = Funcion.RegresaDato("SELECT top 1 dnt.Nombre_Tabla FROM TTProceso p inner join ttmetadata m on p.idproceso=m.procesoid inner join ttdnt dnt on m.dntid=dnt.dntid WHERE p.idProceso = " + this.IdProceso);
        windowCatalogo.NavigateUrl = "~/WebForms/" + myFunctions.GenerateName(NombrePantalla) + "_Catalogo.aspx?MenuVisible=false";
        this.cmdCatalogo.Visible = true;
        this.Visible = true;
        Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "CloseWindow" + cmdCatalogo.ClientID, @GenerateCloseWindowScript());
        base.OnInit(e);
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
        string LlaveSecuencial = "";
        bool operacion = !windowCatalogo.VisibleOnPageLoad;
        windowCatalogo.VisibleOnPageLoad = operacion;
        if (operacion)
        {
            Session[IdProceso + "Tipo_Transaccion"] = Session["Tipo_Transaccion"];
            LlaveDependiente = Funcion.RegresaDato("SELECT Nombre FROM TTMetadata WHERE ProcesoId = " + this.IdProceso + " AND Identificador = 1 AND Dependiente = 1");
            LlaveSecuencial = Funcion.RegresaDato("SELECT Nombre FROM TTMetadata WHERE ProcesoId = " + this.IdProceso + " AND Identificador = 1 AND Dependiente = 0 and secuencial=1");
            LlavePantallaPrincipal = Funcion.RegresaDato("SELECT Nombre FROM TTMetadata WHERE ProcesoId = " + this.IdProcesoPrincipal + " AND Identificador = 1 AND Dependiente = 0");
            Session[IdProceso + myFunctions.GenerateName(LlavePantallaPrincipal)] = Session[myFunctions.GenerateName(LlavePantallaPrincipal)];
            Session[myFunctions.GenerateName(LlaveDependiente)] = Session[myFunctions.GenerateName(LlavePantallaPrincipal)];
            Session[myFunctions.GenerateName(LlaveSecuencial)] = this.IdLlaveModificar;
            Session["Tipo_Transaccion"] = "Consult";
            Session["KeyValueInserted"] = null;
        }
        else
        {
            Session["Tipo_Transaccion"] = Session[IdProceso + "Tipo_Transaccion"];
            LlavePantallaPrincipal = Funcion.RegresaDato("SELECT Nombre FROM TTMetadata WHERE ProcesoId = " + this.IdProcesoPrincipal + " AND Identificador = 1 AND Dependiente = 0");
            Session[myFunctions.GenerateName(LlavePantallaPrincipal)] = Session[IdProceso + myFunctions.GenerateName(LlavePantallaPrincipal)];
            ViewState["ComboValue"] = null;
            ViewState["ComboDS"] = null;
        }
    }

    public void Catalogo_Click(string Llave)
    {
        this.IdLlaveModificar = Llave;
        Type t = typeof(ImageButton);
        object[] p = new object[1];
        p[0] = new System.Web.UI.ImageClickEventArgs(0, 0);
        MethodInfo m = t.GetMethod("OnClick", BindingFlags.NonPublic | BindingFlags.Instance);
        m.Invoke(cmdCatalogo, p);

    }

    protected void SetDdlValueFromKeyValue(DropDownList ddl, AjaxControlToolkit.CascadingDropDown cddCtrl)
    {
        ddl.SelectedValue = Session["KeyValueInserted"].ToString();
        if (cddCtrl != null)
            cddCtrl.SelectedValue = Session["KeyValueInserted"].ToString();
    }
}

#region TypeConverter
public class WebControlConverterMultiConsult : StringConverter
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










