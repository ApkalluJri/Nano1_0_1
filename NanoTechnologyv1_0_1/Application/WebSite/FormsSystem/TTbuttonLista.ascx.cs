using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

using System.Data;
using System.Globalization;
using System.Drawing;
using System.Collections;
using System.Data.SqlClient;

public partial class FormsSystem_TTbuttonLista : System.Web.UI.UserControl
{
    private TTSecurity.Security MySecurity = new TTSecurity.Security();
    private TTFunctions.Functions myFunctions = new TTFunctions.Functions();

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

    private string dTId;
    public string DTId
    {
        get { return dTId; }
        set { dTId = value; }
    }

    public ImageButton ImgButton
    {
        get { return this.cmdLista; }
        set { this.cmdLista = value; }
    }

    public Telerik.Web.UI.RadWindow WindowLista
    {
        get { return this.windowLista; }
        set { this.windowLista = value; }
    }

    private System.Web.UI.Control webControl;
    public System.Web.UI.Control WebControl
    {
        get { return webControl; }
        set { webControl = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "CloseWindow" + cmdLista.ClientID, @GenerateCloseWindowScript());
    }

    override protected void OnInit(EventArgs e)
    {
        this.cmdLista.Visible = SetSecurityAccess();
        base.OnInit(e);
    }

    private bool SetSecurityAccess()
    {
        if (idProceso == "")
            idProceso = "6395";
        bool returnValue = false;
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        try
        {
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "GetProcesoBL";
            com.Parameters.AddWithValue("@IdUsuario", Session["globalUsuarioClave"].ToString());
            com.Parameters.AddWithValue("@IdProceso", idProceso);

            DataSet ds = db.Consulta(com);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (idProceso == "6395")
                    url = "~/FormsSystem/TTUsuarios/TTUsuarios_Lista.aspx?MenuVisible=false";
                else
                    url = "~/WebForms/" + myFunctions.GenerateName(dr["Nombre_Tabla"].ToString()) + "_Lista.aspx?MenuVisible=false";
                windowLista.NavigateUrl = url;
                returnValue = true;
return true;
            }
        }
        catch
        { }
        return true;
    }

    public string GenerateCloseWindowScript()
    {
        String result, callScript;

        result = "<script type='text/javascript'> ";
        result += "function " + cmdLista.ClientID + "OnClientClose(oWnd,args){ ";
        result += " var button = $get('" + cmdLista.ClientID + "'); ";
        result += " button.click(); ";
        result += "}";
        result += "</script> ";

        callScript = cmdLista.ClientID + "OnClientClose";
        windowLista.OnClientClose = callScript;

        return result;
    }     

    protected void cmdLista_Click(object sender, ImageClickEventArgs e)
    {
	Session["PageLoad"] = "1";
        windowLista.NavigateUrl = url;
        bool operacion = !windowLista.VisibleOnPageLoad;

        if (webControl.GetType() == typeof(TextBox))
            if (!windowLista.VisibleOnPageLoad && FindSearch(((TextBox)webControl).Text))
                return;

        if (webControl.GetType() == typeof(Telerik.Web.UI.RadComboBox))
            if (!windowLista.VisibleOnPageLoad && FindSearch(((Telerik.Web.UI.RadComboBox)webControl).Text))
                return;

        windowLista.VisibleOnPageLoad = operacion;

        if (webControl.GetType() == typeof(DropDownList))
        {
            if (operacion)
            {
                Session["tmpClaveLista"] = Session["ClaveLista"];
                ViewState["ComboValue"] = ((DropDownList)webControl).SelectedValue;
            }
            else
            {
                string listValue = string.Empty;
                if (Session["ClaveLista"] == null)
                    listValue = ViewState["ComboValue"].ToString();
                else
                    listValue = Session["ClaveLista"].ToString();
                Session["ClaveLista"] = Session["tmpClaveLista"];
                try
                {
                    ((DropDownList)webControl).SelectedValue = listValue;
                }
                catch
                {
                    ((DropDownList)webControl).SelectedValue = ViewState["ComboValue"].ToString();
                }
                ViewState["ComboValue"] = null;
            }
        }
        //-------------------------------------------------------------------------------------------
        if (webControl.GetType() == typeof(TextBox))
        {
            if (operacion)
            {
                Session["tmpClaveLista"] = Session["ClaveLista"];
                ViewState["ComboValue"] = ((TextBox)webControl).Text;
            }
            else
            {
                string listValue = string.Empty;
                if (Session["ClaveLista"] == null)
                    listValue = ViewState["ComboValue"].ToString();
                else
                    listValue = Session["ClaveLista"].ToString();
                Session["ClaveLista"] = Session["tmpClaveLista"];
                try
                {
                    if (!FindSearch(listValue))
                    {
                        ((TextBox)webControl).Text = string.Empty;
                        lblDescripcion.Text = string.Empty;
                    }
                }
                catch
                {
                    ((TextBox)webControl).Text = ViewState["ComboValue"].ToString();
                }
                ViewState["ComboValue"] = null;

                try
                {
                    (webControl as IPostBackDataHandler).RaisePostDataChangedEvent();
					ScriptManager.RegisterStartupScript(this, this.GetType(), "scriptFireEvent", string.Format(" fireEventFromServer('{0}'); ", ((TextBox)webControl).ClientID), true);
                }
                catch { }
            }
        }
        //-----------------------------------------------------------------------------        
        if (webControl.GetType() == typeof(Telerik.Web.UI.RadComboBox))
        {
            if (operacion)
            {
                Session["tmpClaveLista"] = Session["ClaveLista"];
                ViewState["ComboValue"] = ((Telerik.Web.UI.RadComboBox)webControl).Text;
            }
            else
            {
                string listValue = string.Empty;
                if (Session["ClaveLista"] == null)
                    listValue = ViewState["ComboValue"].ToString();
                else
                    listValue = Session["ClaveLista"].ToString();
                Session["ClaveLista"] = Session["tmpClaveLista"];
                try
                {
                    if (!FindSearch(listValue))
                    {
                        ((Telerik.Web.UI.RadComboBox)webControl).Text = string.Empty;
                        lblDescripcion.Text = string.Empty;
                    }
                }
                catch
                {
                    ((Telerik.Web.UI.RadComboBox)webControl).Text = ViewState["ComboValue"].ToString();
                }
                ViewState["ComboValue"] = null;

                try
                {
                    (webControl as IPostBackDataHandler).RaisePostDataChangedEvent();
                }
                catch { }
            }
        }
    }

    public bool FindSearch(string Text)
    {
        TTMetadata.Metadata meta = new TTMetadata.Metadata(new TTSecurity.GlobalData());
        TTMetadata.MetadataDatos dato = meta.GetDatosDT(Convert.ToInt32(DTId));

        TTMetadata.MetadataDatos datoClave = meta.GetDatosDT(dato.DependienteClave.Value);
        TTMetadata.MetadataDatos datoDescripcion = meta.GetDatosDT(dato.DependienteDescripcion.Value);

        string Clave = myFunctions.GenerateName(datoClave.Nombre);
        int longitud, decimales;
        string Descripcion = myFunctions.GenerateName(datoDescripcion.Nombre);
        bool executeQuery = false;

        try
        {
            TTFunctions.TypeData dataType = datoClave.TipodeDato;
            switch (dataType)
            {
                case TTFunctions.TypeData.Decimal:
                case TTFunctions.TypeData.Moneda:
                    //-------------------------------------------------
                    longitud = datoClave.Longitud.Value;
                    decimales = datoClave.Decimales.Value;
                    if (Text.Length > longitud + decimales)
                        Text = Text.Substring(0, longitud + decimales);
                    decimal outValue;
                    executeQuery = decimal.TryParse(Text, out outValue);
                    break;
                //-------------------------------------------------
                case TTFunctions.TypeData.Numerico:
                    //-------------------------------------------------
                    longitud = datoClave.Longitud.Value;
                    double sLength = Math.Truncate(Math.Pow(2, longitud * 8) / 2);
                    double outValued;
                    executeQuery = double.TryParse(Text, out outValued);
                    if (outValued > sLength)
                        Text = (sLength - 1).ToString();
                    break;
                //-------------------------------------------------
                default:
                    executeQuery = true;
                    break;
            }

            if (executeQuery)
            {
                string NombreTabla = myFunctions.GenerateName(datoDescripcion.NombreTabla);
                string sqlQuery = @"Select {0},{1} from {2} Where ( {0} = '{3}' )";
                Text = Text.Trim();
                Clave = myFunctions.GenerateName(Clave);
                Descripcion = myFunctions.GenerateName(Descripcion);

                sqlQuery = string.Format(sqlQuery, Clave, Descripcion, NombreTabla, Text.Replace("\'", string.Empty));
                DataSet ds = Funcion.RegresaDataSet(sqlQuery);

                if (ds.Tables.Count > 0)
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        if (webControl.GetType() == typeof(Telerik.Web.UI.RadComboBox))
                        {
                            ((Telerik.Web.UI.RadComboBox)webControl).Text = ds.Tables[0].Rows[0][Clave].ToString();
                            ((Telerik.Web.UI.RadComboBox)webControl).Text = ((Telerik.Web.UI.RadComboBox)webControl).Text.Trim();
                        }
                        else if (webControl.GetType() == typeof(TextBox))
                        {
                            ((TextBox)webControl).Text = ds.Tables[0].Rows[0][Clave].ToString();
                            ((TextBox)webControl).Text = ((TextBox)webControl).Text.Trim();
                        }
                        lblDescripcion.Text = ds.Tables[0].Rows[0][Descripcion].ToString();
                        lblDescripcion.Text = lblDescripcion.Text.Trim();
                        return true;
                    }
            }
        }
        catch
        {
            return false;
        }

        return false;
    }

    public bool RelatedValueExists()
    {
        bool resultado = false;
        string keyValue = string.Empty;
        if (webControl.GetType() == (typeof(Telerik.Web.UI.RadComboBox)))
            keyValue = (webControl as Telerik.Web.UI.RadComboBox).SelectedValue;
        else if (webControl.GetType() == (typeof(TextBox)))
            keyValue = (webControl as TextBox).Text;

        if (keyValue != "")
        {
            //------------------------------------------------------------------------------
            TTMetadata.Metadata meta = new TTMetadata.Metadata(new TTSecurity.GlobalData());
            TTMetadata.MetadataDatos dato = meta.GetDatosDT(Convert.ToInt32(DTId));
            //------------------------------------------------------------------------------
            TTMetadata.MetadataDatos datoClave = meta.GetDatosDT(dato.DependienteClave.Value);
            TTMetadata.MetadataDatos datoDescripcion = meta.GetDatosDT(dato.DependienteDescripcion.Value);
            //------------------------------------------------------------------------------
            string Clave = datoClave.Nombre;
            string Descripcion = datoDescripcion.Nombre;
            bool executeQuery = false;
            //------------------------------------------------------------------------------
            TTFunctions.TypeData dataType = datoClave.TipodeDato;
            switch (dataType)
            {
                case TTFunctions.TypeData.Decimal:
                case TTFunctions.TypeData.Moneda:
                    decimal outValue;
                    executeQuery = decimal.TryParse(keyValue, out outValue);
                    break;
                case TTFunctions.TypeData.Numerico:
                    double outValued;
                    executeQuery = double.TryParse(keyValue, out outValued);
                    break;
                default:
                    executeQuery = true;
                    break;
            }
            if (executeQuery)
            {
                try
                {
                    string NombreTabla = myFunctions.GenerateName(datoDescripcion.NombreTabla);
                    keyValue = keyValue.Trim();
                    Clave = myFunctions.GenerateName(Clave);
                    Descripcion = myFunctions.GenerateName(Descripcion);

                    string sqlQuery = @"Select {0} from {1} Where ( {0} = '{2}' )";

                    sqlQuery = string.Format(sqlQuery, Clave, NombreTabla, keyValue);
                    DataSet ds = Funcion.RegresaDataSet(sqlQuery);

                    if (ds.Tables.Count > 0)
                        if (ds.Tables[0].Rows.Count == 1)
                            resultado = true;
                }
                catch
                {
                    resultado = false;
                }
            }
        }
        else
        {
            resultado = true;
        }
        return resultado;
    }

}









