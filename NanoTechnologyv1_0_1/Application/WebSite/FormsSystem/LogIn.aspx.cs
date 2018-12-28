using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class LogIn : System.Web.UI.Page
{
    private TTVersion.VersionData MyVersionData = new TTVersion.VersionData(TTVersion.VersionDataModules.Produccion, 1.5M);
    private TTSecurity.Security MySecurity = new TTSecurity.Security();
    protected void Page_Load(object sender, EventArgs e)
    {
        //LoadWelcomeMessage();
        SetLanguage(); 
        Session["UserGlobalInformation"] = null;
        txtUser.Focus();
        txtUser.Attributes.Add(
            "onkeydown",
            "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txtUser.ClientID + "').click();return false;}} else {return true}; ");
        txtPassword.Attributes.Add(
            "onkeydown",
            "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + LoginButton.ClientID + "').click();return false;}} else {return true}; ");
    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        bool OK = false;
        TTSecurity.GlobalData globalInformation;
        TTFunctions.Functions functions = new TTFunctions.Functions();
        int? iLanguage = functions.FormatNumberNull(ddlLanguage.SelectedValue);
        iLanguage = iLanguage == null ? 1 : iLanguage;
        string sError = "";
        try
        {
            string sErrorTemp;
            if (MySecurity.Login(txtUser.Text, txtPassword.Text, out globalInformation, MyVersionData, iLanguage.Value, out sErrorTemp, false)) // cbLanguage.SelectedIndex + 1))
            {
                OK = true;
                globalInformation.Language = TTSecurity.GlobalDataLanguages.Default; //(TTSecurity.GlobalDataLanguages)cbLanguage.SelectedIndex + 1;
                //Session.Timeout = 30;
                Session.Add("UserGlobalInformation", globalInformation);
                Session["Proy"] = null;

                Session.Add("NombreDNT", "");
                Session.Add("Where", "");
                Session.Add("globalUsuarioClave", globalInformation.UserID.ToString());
                Session.Add("globalUsuarioNombre", globalInformation.UserName.ToString());
                Session.Add("carga", "");
                Session.Add("Language", ddlLanguage.SelectedValue);

                foreach (TTSecurity.UserGroupsSystem users in globalInformation.UserGroups())
                {
                    Session.Add("globalTipoUsuario", users.GetHashCode().ToString());                    
                }

                Response.Redirect("~/FormsSystem/Default.aspx");
            }
            sError = sErrorTemp;
        }
        catch (Exception ex)
        {
            // No obtiene nada
            //lblAtencion.Text = ex.Message.ToString();
            sError = ex.Message.ToString();
        }
        finally
        {
            if (!OK)
            {
                txtUser.Text = "";
                txtPassword.Text = "";
                //Mensaje anterior de TTSecurity.Security.Login()
                //TTTraductor.Traductor myTraductor = new TTTraductor.Traductor(iLanguage.Value);
                //MessageBox.Show(myTraductor.getMessage(87), myTraductor.getMessage(86), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                if (sError.Trim().Length > 0)
                    lblAtencion.Text = sError + ".";
                else
                    lblAtencion.Text = "Acceso denegado, por favor intente de nuevo.";
            }
        }
    }

    private void SetLanguage() 
    {
        TTFunctions.Functions functions = new TTFunctions.Functions();
        int? iLanguage = functions.FormatNumberNull(ddlLanguage.SelectedValue);
        TTTraductor.Traductor traductor = new TTTraductor.Traductor(iLanguage == null ? 1 : iLanguage.Value );

        this.Title = traductor.getMessage(36, this.Title);
        lblLogin.Text = traductor.getMessage(36, lblLogin.Text);
        lblUsuario.Text = traductor.getMessage(37, lblUsuario.Text);
        lblPassword.Text = traductor.getMessage(38, lblPassword.Text);
        lblLanguage.Text = traductor.getMessage(40, lblLanguage.Text);
        UserNameRequired.Text = traductor.getMessage(50, UserNameRequired.Text);
        UserNameRequired.ToolTip = traductor.getMessage(50, UserNameRequired.ToolTip);
        PasswordRequired.Text = traductor.getMessage(51, PasswordRequired.Text);
        PasswordRequired.ToolTip = traductor.getMessage(51, PasswordRequired.ToolTip);
    }

    private void LoadWelcomeMessage()
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand("select Nombre, FormatoFechas, FormatoFechasGrid from TTProyecto");
        com.CommandType = CommandType.Text;
        DataSet ds = db.Consulta(com);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            //lblBienvdenido.Text = "Bienvenido al " + dr["Nombre"].ToString() + " – Acceso al Sistema";
            Session.Add("FormatoFechas", dr["FormatoFechas"].ToString());
            Session.Add("FormatoFechasGrid", dr["FormatoFechasGrid"].ToString());
        }
        if (Session["FormatoFechas"] == null)
            Session["FormatoFechas"] = "yyyy/MM/dd";
        if (Session["FormatoFechasGrid"] == null)
            Session["FormatoFechasGrid"] = "yyyy/MM/dd";
    }

}








