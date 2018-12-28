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
using System.Text.RegularExpressions;

public partial class WebForms_CambiarPassword : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		txtUsuario.Focus();
	}

	protected void IbtnGuardar_Click(object sender, ImageClickEventArgs e)
	{
		lblError.Visible = false;
		TTDataLayerCS.BD db = new TTDataLayerCS.BD();
		SqlCommand com;
		DataSet ds;

		//Validar que el usuario y contraseña actual sean correctos
		String ClaveUsuario = Funcion.RegresaDato("Select idUsuario from TTUsuarios where rtrim(Clave_de_Acceso)='" + txtUsuario.Text.Trim() + "' and rtrim(Contrasena) = '" + txtContrasenia.Text.Trim() + "'");
		if (ClaveUsuario == "")
		{
			lblError.Text = "El usuario y contraseña actual no son válidos";
			lblError.Visible = true;
			txtContrasenia.Text = "";
			txtContrasenia.Focus();
			return;
		}

		//Validar que la contraseña nueva y la confirmación sean iguales
		if (txtContrasenia1.Text.Trim() != txtContrasenia2.Text.Trim())
		{
			lblError.Text = "La nueva contraseña y la confirmación no coinciden";
			lblError.Visible = true;
			txtContrasenia2.Text = "";
			txtContrasenia1.Focus();
			return;
		}

		//Validar que la contraseña nueva no se igual a la anterior
		if (txtContrasenia1.Text.Trim() == txtContrasenia.Text.Trim())
		{
			lblError.Text = "La nueva contraseña debe ser diferente a la antigua";
			lblError.Visible = true;
			txtContrasenia1.Text = "";
			txtContrasenia2.Text = "";
			txtContrasenia1.Focus();
			return;
		}

		//Validar que la contraseña tenga como minimo 5 caracteres
		if (txtContrasenia1.Text.Trim().Length < 8)
		{
			lblError.Text = "La nueva contraseña debe tener mínimo 8 caracteres alfanuméricos, favor de verificarlo";
			lblError.Visible = true;
			return;
		}

        if (IsAlpha(txtContrasenia1.Text) || IsNumeric(txtContrasenia1.Text))
        {
            lblError.Text = "La nueva contraseña debe contener letras y números";
			lblError.Visible = true;
			return;
		}
        		
		//Actualizar la nueva contraseña
		com = new SqlCommand("Update TTUsuarios set contrasena = '" + txtContrasenia1.Text.Trim() + "' where idUsuario=" + ClaveUsuario);
		ds = db.Consulta(com);
		ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(Page), "mensaje", "alert('Su contraseña ha sido cambiada satisfactoriamente'); window.navigate('Default.aspx');", true);
	}
	protected void IbtnCancelar_Click(object sender, ImageClickEventArgs e)
	{
		Response.Redirect("Default.aspx");
	}
    
    protected bool IsAlpha(String strToCheck)
    {
        Regex objAlphaPattern=new Regex("[^a-zA-Z]");
        return !objAlphaPattern.IsMatch(strToCheck);
    }

    protected bool IsNumeric(String strToCheck)
    {
        Regex objNumericPattern = new Regex("[^0-9]");
        return !objNumericPattern.IsMatch(strToCheck);
    }

}







