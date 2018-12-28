using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for Login
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Login : System.Web.Services.WebService {

    public Login () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public TTSecurity.GlobalData ValidaAcceso(string Usuario,string Password)
    {
        TTVersion.VersionData MyVersionData = new TTVersion.VersionData(TTVersion.VersionDataModules.Produccion, 1.5M);
        TTSecurity.Security MySecurity = new TTSecurity.Security();
        TTSecurity.GlobalData globalInformation = new TTSecurity.GlobalData();
        TTFunctions.Functions functions = new TTFunctions.Functions();
        try
        {
            if (MySecurity.Login(Usuario, Password, out globalInformation, MyVersionData, 1))
            {
                globalInformation.Language = TTSecurity.GlobalDataLanguages.Default;
            }
            else
            {
                throw new System.ArgumentException("Usuario y/o Password inválido", "Acceso");
            }
        }
        catch (Exception ex)
        {
            throw;
        }
        return globalInformation;
    }
}

