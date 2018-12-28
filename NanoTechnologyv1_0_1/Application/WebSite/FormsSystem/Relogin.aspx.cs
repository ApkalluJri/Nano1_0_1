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

public partial class WebForms_Relogin : TTBasePage.TTBasePage
{
    private TTVersion.VersionData MyVersionData = new TTVersion.VersionData(TTVersion.VersionDataModules.Produccion, 1.5M);
    private TTSecurity.Security MySecurity = new TTSecurity.Security();

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Relogin"] = true;
        foreach (object obj in Session)
            obj.ToString();
        if (!IsPostBack)
        {
            txtUser.Text = Funcion.RegresaDato("select Clave_de_Acceso from TTUsuarios where IdUsuario=" + (string)Session["globalUsuarioClave"]);
            txtUser.Attributes.Add("readonly", "readonly");            
        }
    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        
        TTSecurity.GlobalData globalInformation;
        try
        {
            if (MySecurity.Login(txtUser.Text, txtPassword.Text, out globalInformation, MyVersionData, 1)) // cbLanguage.SelectedIndex + 1))
            {
                Session["Relogin"] = null;
                globalInformation.Language = TTSecurity.GlobalDataLanguages.Default; //(TTSecurity.GlobalDataLanguages)cbLanguage.SelectedIndex + 1;
                Session.Timeout = 30;
                Session.Add("UserGlobalInformation", globalInformation);
                Session["Proy"] = null;
                Session["MinutesToTimeOut"] = "25";

                //Session.Add("NombreDNT", "");
                //Session.Add("Where", "");
                Session.Add("globalUsuarioClave", globalInformation.UserID.ToString());
                Session.Add("globalUsuarioNombre", globalInformation.UserName.ToString());
                //Session.Add("carga", "");
                foreach (TTSecurity.UserGroupsSystem users in globalInformation.UserGroups())
                {
                    Session.Add("globalTipoUsuario", users.GetHashCode().ToString());
                    ClientScript.RegisterStartupScript(typeof(Page), "script", "<script language='javascript'>updateFromOpener(" + true.ToString().ToLower() + ", 'ctl00_loginWindow');</script>");                                    
                }

            }
        }
        catch (Exception ex)
        {
            ShowAlert(ex.Message.ToString());
            //idDivErrPassword.Visible = true;
            //            <div id="idDivErrPassword" runat= "server" align="center" style="font-size: 20pt; color: red" visible="false" >
            //    Usuario o contraseña incorrectos
            //</div>
        }
    }
    protected void AbandonButton_Click(object sender, EventArgs e)
    {
        PasswordRequired.Enabled = false;
        Session.Abandon();
        ClientScript.RegisterStartupScript(typeof(Page), "script", "<script language='javascript'>updateFromOpener(" + false.ToString().ToLower() + ", 'ctl00_loginWindow');</script>");
       
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









