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
using System.Reflection; /*Nuevo Código Freelancer*/

public delegate void DelegateFillDataControl(object obj, DataSet ds);
public delegate DataSet DelegateDataSet();
public delegate DataSet DelegateDataSetWithIntKey(int key);
public delegate DataSet DelegateDataSetWithStringKey(string key);

public partial class FormsSystem_TTbuttonCatalogo : System.Web.UI.UserControl
{
    /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 02/Diciembre/2013 */
    /*OBJETIVO: Extender Web User Control TTbuttonCatalogo con las opciones de modificar y borrar. */
    #region IDCODMANUAL:
    public struct SecurityAccess
    {
        public bool CanAdd;
        public bool CanModify;
        public bool CanDelete;
        public string UrlAdd;
        public string UrlModify;
        public string UrlDelete;
    }
    #endregion

    public SecurityAccess SecurityAccessArgs = new SecurityAccess(); /*Nuevo Código Freelancer*/
    private TTSecurity.Security MySecurity = new TTSecurity.Security();
    private TTFunctions.Functions myFunctions = new TTFunctions.Functions();

    private DelegateFillDataControl fillDataControlFunction;
    public DelegateFillDataControl FillDataControlFunction
    {
        get { return fillDataControlFunction; }
        set { fillDataControlFunction = value; }
    }

    private DelegateDataSet getControlDataSetFunction;
    public DelegateDataSet GetControlDataSetFunction
    {
        get { return getControlDataSetFunction; }
        set { getControlDataSetFunction = value; }
    }

    private DelegateDataSetWithIntKey getControlDataSetFunctionWithInt;
    public DelegateDataSetWithIntKey GetControlDataSetFunctionWithInt
    {
        get { return getControlDataSetFunctionWithInt; }
        set { getControlDataSetFunctionWithInt = value; }
    }

    private DelegateDataSetWithStringKey getControlDataSetFunctionWithString;
    public DelegateDataSetWithStringKey GetControlDataSetFunctionWithString
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

    private Control ccdControl 
    {
        get { return  Funcion.FindControlRecursive(this.Page , cddID);  }
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
    [Category("Controls"), TypeConverter(typeof(WebControlConverter))]
    public System.Web.UI.Control WebControl
    {
        get { return webControl; }
        set { webControl = value;
        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 02/Diciembre/2013 */
        /*OBJETIVO: Extender Web User Control TTbuttonCatalogo con las opciones de modificar y borrar. */
        #region IDCODMANUAL:
        cmdCatalogoDelete.OnClientClick = GenerateDeleteScript(cmdCatalogoDelete.ClientID);
        RFVCatalogModify.ClientValidationFunction = GenerateReqValitateScript(cmdCatalogoModify.ClientID, "modificar");
        RFVCatalogDelete.ClientValidationFunction = GenerateReqValitateScript(cmdCatalogoDelete.ClientID, "borrar");
        #endregion
        }
    }
    
    override protected void OnInit(EventArgs e)
    {
        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 02/Diciembre/2013 */
        /*OBJETIVO: Extender Web User Control TTbuttonCatalogo con las opciones de modificar y borrar. */
        #region IDCODMANUAL:
        SetSecurityAccess();
        this.cmdCatalogo.Visible = SecurityAccessArgs.CanAdd;
        this.cmdCatalogoModify.Visible = SecurityAccessArgs.CanModify;
        this.cmdCatalogoDelete.Visible = SecurityAccessArgs.CanDelete;
        #endregion
        Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "CloseWindow" + cmdCatalogo.ClientID, @GenerateCloseWindowScript());

        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 02/Diciembre/2013 */
        /*OBJETIVO: Extender Web User Control TTbuttonCatalogo con las opciones de modificar y borrar. */
        #region IDCODMANUAL:
        RFVCatalogModify.ValidationGroup = "valgrp" + cmdCatalogoModify.ClientID;
        RFVCatalogDelete.ValidationGroup = "valgrp" + cmdCatalogoDelete.ClientID;
        SummaryCatalogModify.ValidationGroup = "valgrp" + cmdCatalogoModify.ClientID;
        SummaryCatalogDelete.ValidationGroup = "valgrp" + cmdCatalogoDelete.ClientID;
        cmdCatalogoModify.ValidationGroup = "valgrp" + cmdCatalogoModify.ClientID;
        cmdCatalogoDelete.ValidationGroup = "valgrp" + cmdCatalogoDelete.ClientID;
        #endregion
        base.OnInit(e);
    }
    /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 02/Diciembre/2013 */
    /*OBJETIVO: Extender Web User Control TTbuttonCatalogo con las opciones de modificar y borrar. */
    #region IDCODMANUAL:
    private void SetSecurityAccess() /*Nuevo Código Freelancer bool => void*/
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        try
        {
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "[dbo].[GetPermisosPorProcesoUsuario]";
            com.Parameters.AddWithValue("@IdUsuario", Session["globalUsuarioClave"].ToString());
            com.Parameters.AddWithValue("@IdProceso", idProceso);

            DataSet ds = db.Consulta(com);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                /*Nuevo Código Freelancer*/
                #region
                switch (dr["IdOperacion"].ToString())
                {
                    case "1": //-----Tiene permisos para agregar en el Catálogo
                        if (dr["dntid"].ToString() == "2348" || dr["dntid"].ToString() == "2349") //Catálogo de usuario y grupo de usuario
                        {
                            SecurityAccessArgs.UrlAdd = "~/FormsSystem/TTUsuarios/" + myFunctions.GenerateName(dr["Nombre_Tabla"].ToString()) + "_Catalogo.aspx?MenuVisible=false";
                        }
                        else
                        {
                            SecurityAccessArgs.UrlAdd = "~/WebForms/" + myFunctions.GenerateName(dr["Nombre_Tabla"].ToString()) + "_Catalogo.aspx?MenuVisible=false";
                        }
                        SecurityAccessArgs.CanAdd = true;
                        break;
                    case "2": //-----Tiene permisos para modificar en el Catálogo
                        if (dr["dntid"].ToString() == "2348" || dr["dntid"].ToString() == "2349") //Catálogo de usuario y grupo de usuario
                        {
                            SecurityAccessArgs.UrlAdd = "~/FormsSystem/TTUsuarios/" + myFunctions.GenerateName(dr["Nombre_Tabla"].ToString()) + "_Catalogo.aspx?MenuVisible=false";
                        }
                        else
                        {
                            SecurityAccessArgs.UrlModify = "~/WebForms/" + myFunctions.GenerateName(dr["Nombre_Tabla"].ToString()) + "_Catalogo.aspx?MenuVisible=false";
                        }
                        SecurityAccessArgs.CanModify = true;
                        break;
                    case "3": //-----Tiene permisos para eliminar en el Catálogo
                        if (dr["dntid"].ToString() == "2348" || dr["dntid"].ToString() == "2349") //Catálogo de usuario y grupo de usuario
                        {
                            SecurityAccessArgs.UrlAdd = "~/FormsSystem/TTUsuarios/" + myFunctions.GenerateName(dr["Nombre_Tabla"].ToString()) + "_Catalogo.aspx?MenuVisible=false";
                        }
                        else
                        {
                            SecurityAccessArgs.UrlDelete = myFunctions.GenerateName(dr["Nombre_Tabla"].ToString()) + "_Lista.aspx/Delete_Row";
                        }
                        SecurityAccessArgs.CanDelete = true;
                        break;
                    default:
                        break;
                }
                #endregion
            }
        }
        catch
        { }
    }
    #endregion

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

    /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 02/Diciembre/2013 */
    /*OBJETIVO: Extender Web User Control TTbuttonCatalogo con las opciones de modificar y borrar. */
    #region IDCODMANUAL:
    public string GenerateReqValitateScript(string functionId, string modo)
    {
        string result = string.Empty;
        functionId = string.Format("RFVCatalog{0}", functionId);

        
        if (webControl.GetType() == typeof(DropDownList))
        {
            result = "<script type='text/javascript'>";
            result += string.Format(" function {0}(source, args){{", functionId);
            result += string.Format(" var oCombo = document.getElementById('{0}');", webControl.ClientID);
            result += " if (oCombo != null && (oCombo.selectedIndex == -1 || oCombo[oCombo.selectedIndex].value == ''))";
            result += " {";
            result += string.Format(" source.errormessage = 'Debe seleccionar la opción a {0}';", modo);
            result += " args.IsValid = false;";
            result += " return;";
            result += " }";
            result += " args.IsValid = true;";
            result += " }";
            result += " </script> ";
        }

        if (webControl.GetType() == typeof(ListBox))
        {
            result = "<script type='text/javascript'>";
            result += string.Format(" function {0}(source, args){{", functionId);
            result += string.Format(" var oCombo = document.getElementById('{0}');", webControl.ClientID);
            result += " if (oCombo != null && (oCombo.selectedIndex == -1 || oCombo[oCombo.selectedIndex].value == ''))";
            result += " {";
            result += string.Format(" source.errormessage = 'Debe seleccionar la opción a {0}';", modo);
            result += " args.IsValid = false;";
            result += " return;";
            result += " }";
            result += " if (oCombo != null )";
            result += " {";
            result += " var count = 0;";
            result += " for (var i = 0; i < oCombo.options.length; i++)";
            result += "     if (oCombo.options[i].selected) count++;";
            result += " if (count > 1){";
            result += string.Format(" source.errormessage = 'Debe seleccionar una sola opción a {0}';", modo);
            result += " args.IsValid = false;";
            result += " return;";
            result += " }";
            result += " }";
            result += " args.IsValid = true;";
            result += " }";
            result += " </script> ";
        }

        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script_" + functionId, result);
        return functionId ;
    }
    #endregion

    /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 02/Diciembre/2013 */
    /*OBJETIVO: Extender Web User Control TTbuttonCatalogo con las opciones de modificar y borrar. */
    #region IDCODMANUAL:
    public string GenerateDeleteScript(string functionId)
    {
        string result;
        string groupVal = "valgrp" + functionId;
        functionId = string.Format("DeleteClientClick{0}", functionId);

        
        result = "<script type='text/javascript'>";
        result += string.Format(" function {0}() {{", string.Format("{0}", functionId));
        result += "if (Page_ClientValidate('" + groupVal + "')){";
        result += " var returnVal = confirm('¿Está seguro que desea borrar el registro seleccionado?');";
        result += " if (returnVal == false)";
        result += " return false;";
        result += string.Format(" var oCombo = document.getElementById('{0}');", webControl.ClientID );
        result += " var sdata = '{ Folio: \"' + oCombo[oCombo.selectedIndex].value + '\" , startRowIndex: 0 , maximumRows: 0 , sortExpression: {\"_array\":[]} , filterExpression: {\"_array\":[]}, faseworkflow: \"\" }';";
        result += " jQuery.ajax({";
        result += " type: 'POST',";
        result += " contentType: 'application/json; charset=utf-8',";
        result += " data: sdata,";
        result += " dataType: 'json',";
        result += string.Format(" url: '{0}'", SecurityAccessArgs.UrlDelete);
        result += " });";
        result += " return true;";
        result += " } ";
        result += " } ";
        result += " </script> ";
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script_" + functionId, result);

        return string.Format("return {0}();", functionId);
    }
    #endregion

    /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 02/Diciembre/2013 */
    /*OBJETIVO: Extender Web User Control TTbuttonCatalogo con las opciones de modificar y borrar. */
    #region IDCODMANUAL:
    protected void cmdCatalogo_Click(object sender, ImageClickEventArgs e)
    {
        Session["PageLoad"] = "1";
        Session["PageLoad"] = "1"; 
        if (webControl.GetType() == typeof(DropDownList))
            DropDownList(sender);

        if (webControl.GetType() == typeof(ListBox))
            Listbox(sender);

        if (webControl.GetType() == typeof(TextBox))
        {
            if (Session["TextBoxValue"] != null)
                ((TextBox)webControl).Text = Session["TextBoxValue"].ToString();
            Session["TextBoxValue"] = null;
        }
    }
    #endregion

    /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 02/Diciembre/2013 */
    /*OBJETIVO: Extender Web User Control TTbuttonCatalogo con las opciones de modificar y borrar. */
    #region IDCODMANUAL:
    private void DropDownList(object sender)
    {
        bool operacion = !windowCatalogo.VisibleOnPageLoad && (((ImageButton)sender).CommandArgument == "1" || ((ImageButton)sender).CommandArgument == "2");
        windowCatalogo.VisibleOnPageLoad = operacion;

        if (operacion)
        {
            Session[IdProceso + "Tipo_Transaccion"] = Session["Tipo_Transaccion"];
            switch (((ImageButton)sender).CommandArgument)
            {
                case "1":
                    windowCatalogo.NavigateUrl = SecurityAccessArgs.UrlAdd;
                    Session["Tipo_Transaccion"] = "New";
                    break;
                case "2":
                    if (((DropDownList)webControl).SelectedIndex == -1 || string.IsNullOrEmpty(((DropDownList)webControl).SelectedValue))
                    {
                        windowCatalogo.VisibleOnPageLoad = false;
                    }
                    else
                    {
                        string identifier = Funcion.RegresaDato("SELECT Nombre FROM TTMetadata WHERE ProcesoId = " + this.IdProceso + " AND Identificador = 1 AND Dependiente = 0");
                        identifier = myFunctions.GenerateName(identifier);
                        windowCatalogo.NavigateUrl = SecurityAccessArgs.UrlModify;
                        Session[identifier] = ((DropDownList)webControl).SelectedValue;
                        Session["Tipo_Transaccion"] = "Update";
                        windowCatalogo.Enabled = true;
                    }
                    break;
            }



            ViewState["ComboValue"] = ((DropDownList)webControl).SelectedValue;
            Session["KeyValueInserted"] = null;
        }
        else
        {
            Session["Tipo_Transaccion"] = Session[IdProceso + "Tipo_Transaccion"];
            Session.Remove(IdProceso + "Tipo_Transaccion");
            try
            {
                if (GetControlDataSetFunction != null)
                {
                    fillDataControlFunction(webControl, GetControlDataSetFunction());
                }
                else if (GetControlDataSetFunctionWithInt != null)
                {
                    if (parentWebControl != null)
                    {
                        int keyValue;
                        if (int.TryParse((parentWebControl as DropDownList).SelectedValue.ToString(), out keyValue))
                            fillDataControlFunction(webControl, GetControlDataSetFunctionWithInt(keyValue));
                    }
                    else
                        fillDataControlFunction(webControl, GetControlDataSetFunctionWithInt(0));
                }
                else if (GetControlDataSetFunctionWithString != null)
                {
                    if (parentWebControl != null)
                        fillDataControlFunction(webControl, GetControlDataSetFunctionWithString((parentWebControl as DropDownList).SelectedValue.ToString()));
                    else
                        fillDataControlFunction(webControl, GetControlDataSetFunctionWithString(string.Empty));
                }
                //---------------------------------------------------------------------------------------------------
                if (ViewState["ComboValue"] != null || Session["KeyValueInserted"] != null)
                {
                    //DataTable dtNew = Funcion.SaveComboBoxItemsToTable(webControl as DropDownList);
                    DropDownList control = (DropDownList)webControl;
                    if (control.Attributes["Tag"] != "" && control.Attributes["Tag"] != null)
                    {
                        DataSet dt = Funcion.RegresaDataSet(control.Attributes["Tag"]);
                        control.Items.Clear();
                        control.Items.Add("");
                        foreach (DataRow rowItem in dt.Tables[0].Rows)
                        {
                            control.Items.Add(new ListItem(rowItem[1].ToString(), rowItem[0].ToString()));
                        }

                    }

                    if (Session["KeyValueInserted"] != null)
                        SetDdlValueFromKeyValue(webControl as DropDownList, ccdControl as AjaxControlToolkit.CascadingDropDown, Session["KeyValueInserted"].ToString());
                    else
                        SetDdlValueFromKeyValue(webControl as DropDownList, ccdControl as AjaxControlToolkit.CascadingDropDown, ViewState["ComboValue"].ToString());

                    
                }
            }
            catch { }
            ViewState["ComboValue"] = null;
            ViewState["ComboDS"] = null;
        }
    }
    #endregion

    /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 02/Diciembre/2013 */
    /*OBJETIVO: Extender Web User Control TTbuttonCatalogo con las opciones de modificar y borrar. */
    #region IDCODMANUAL:
    private void Listbox(object sender)
    {
        bool operacion = !windowCatalogo.VisibleOnPageLoad && (((ImageButton)sender).CommandArgument == "1" || ((ImageButton)sender).CommandArgument == "2");
        windowCatalogo.VisibleOnPageLoad = operacion;

        if (operacion)
        {
            Session[IdProceso + "Tipo_Transaccion"] = Session["Tipo_Transaccion"];

            switch (((ImageButton)sender).CommandArgument)
            {
                case "1":
                    windowCatalogo.NavigateUrl = SecurityAccessArgs.UrlAdd;
                    Session["Tipo_Transaccion"] = "New";
                    break;
                case "2":
                    if (((ListBox)webControl).SelectedIndex == -1 || string.IsNullOrEmpty(((ListBox)webControl).SelectedValue))
                    {
                        windowCatalogo.VisibleOnPageLoad = false;
                    }
                    else
                    {
                        string identifier = Funcion.RegresaDato("SELECT Nombre FROM TTMetadata WHERE ProcesoId = " + this.IdProceso + " AND Identificador = 1 AND Dependiente = 0");
                        identifier = myFunctions.GenerateName(identifier);
                        windowCatalogo.NavigateUrl = SecurityAccessArgs.UrlModify;
                        Session[identifier] = ((ListBox)webControl).SelectedValue;
                        Session["Tipo_Transaccion"] = "Update";
                        windowCatalogo.Enabled = true;
                    }
                    break;
            }

            ViewState["ControlValue"] = ((ListBox)webControl).SelectedValue;
            Session["KeyValueInserted"] = null;
        }
        else
        {
            Session["Tipo_Transaccion"] = Session[IdProceso + "Tipo_Transaccion"];
            Session.Remove(IdProceso + "Tipo_Transaccion");
            try
            {
                if (GetControlDataSetFunction != null)
                {
                    fillDataControlFunction(webControl, GetControlDataSetFunction());
                }
                else if (GetControlDataSetFunctionWithInt != null)
                {
                    if (parentWebControl != null)
                    {
                        int keyValue;
                        if (int.TryParse((parentWebControl as ListBox).SelectedValue.ToString(), out keyValue))
                            fillDataControlFunction(webControl, GetControlDataSetFunctionWithInt(keyValue));
                    }
                    else
                        fillDataControlFunction(webControl, GetControlDataSetFunctionWithInt(0));
                }
                else if (GetControlDataSetFunctionWithString != null)
                {
                    if (parentWebControl != null)
                        fillDataControlFunction(webControl, GetControlDataSetFunctionWithString((parentWebControl as ListBox).SelectedValue.ToString()));
                    else
                        fillDataControlFunction(webControl, GetControlDataSetFunctionWithString(string.Empty));
                }
                //---------------------------------------------------------------------------------------------------
                if (ViewState["ControlValue"] != null || Session["KeyValueInserted"] != null)
                {
                    //DataTable dtNew = Funcion.SaveListBoxItemsToTable(webControl as ListBox);
                    ListBox control = (ListBox)webControl;
                    if (control.Attributes["Tag"] != "" && control.Attributes["Tag"] != null)
                    {
                        DataSet dt = Funcion.RegresaDataSet(control.Attributes["Tag"]);
                        control.Items.Clear();
                        control.Items.Add("");
                        foreach (DataRow rowItem in dt.Tables[0].Rows)
                        {
                            control.Items.Add(new ListItem(rowItem[1].ToString(), rowItem[0].ToString()));
                        }

                    }
                    if (Session["KeyValueInserted"] != null)
                        SetDdlValueFromKeyValue(webControl as ListBox, ccdControl as AjaxControlToolkit.CascadingDropDown, Session["KeyValueInserted"].ToString());
                    else
                        SetDdlValueFromKeyValue(webControl as ListBox, ccdControl as AjaxControlToolkit.CascadingDropDown, ViewState["ControlValue"].ToString());
                }
            }
            catch { }
            ViewState["ControlValue"] = null;
            ViewState["ComboDS"] = null;
        }
    }
    #endregion


    /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 02/Diciembre/2013 */
    /*OBJETIVO: Extender Web User Control TTbuttonCatalogo con las opciones de modificar y borrar. */
    #region IDCODMANUAL:
    protected void SetDdlValueFromKeyValue(DropDownList ddl, AjaxControlToolkit.CascadingDropDown cddCtrl, string value)
    {
        ddl.SelectedValue = value;
        if (cddCtrl != null)
            cddCtrl.SelectedValue = value;
        (ddl as IPostBackDataHandler).RaisePostDataChangedEvent();
    }
    #endregion

    /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 02/Diciembre/2013 */
    /*OBJETIVO: Extender Web User Control TTbuttonCatalogo con las opciones de modificar y borrar. */
    #region IDCODMANUAL:
    protected void SetDdlValueFromKeyValue(ListBox ddl, AjaxControlToolkit.CascadingDropDown cddCtrl, string value)
    {
        ddl.SelectedValue = value;
        if (cddCtrl != null)
            cddCtrl.SelectedValue = value;
        (ddl as IPostBackDataHandler).RaisePostDataChangedEvent();
    }
    #endregion
}

#region TypeConverter
public class WebControlConverter : StringConverter
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
            case "System.Web.UI.WebControls.TextBox":
                ReturnedVal = true;
                break;
        }
        return ReturnedVal;
    }
}
#endregion










