using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace FormsSystem
{
    public partial class TTConsultaSQL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEjecutar_Click(object sender, EventArgs e)
        {
            txtError.Visible = false;
            grdResultado.Visible = false;
            pnlResultado.Visible = false;
            txtError.Text = "";
            if (txtQuery.Text == "")
            {
                MuestraError("Debe proporcionar una instrucción SQL a ejecutar");
                return;    
            }

            if (!ValidaQuery("DROP"))
                return;
            if (!ValidaQuery("ALTER TABLE"))
                return;
            if (!ValidaQuery("ALTER DATABASE"))
                return;
            if (!ValidaQuery("CREATE TABLE"))
                return;
            if (!ValidaQuery("CREATE DATABASE"))
                return;

            try 
            {
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand(txtQuery.Text);
                com.CommandType = CommandType.Text;
                DataSet ds = db.Consulta(com);
                MuestraResultado(ds);
            }
            catch (Exception ex)
            {
                MuestraError(ex.Message);
            }
        }

        protected bool ValidaQuery(string Sentencia)
        {
            bool result = true;
            if (txtQuery.Text.ToUpper().IndexOf(Sentencia) != -1)
            {
                MuestraError("La sentencia " + Sentencia + " no es válida para TTConsultaSQL");
                result = false;
            }
            return result;
        }

        protected void MuestraError(string Error)
        {
            grdResultado.Visible = false;
            pnlResultado.Visible = false;
            txtError.Visible = true;
            txtError.Text = Error;
            txtError.Width = txtQuery.Width;
        }

        protected void GuardaBitacora()
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand("sp_Insttbitacorasql");
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@IdUsuario",SqlDbType.SmallInt).Value=int.Parse(Session["globalusuarioclave"].ToString());
            
            com.Parameters.Add("@TipoSQL",SqlDbType.VarChar).Value="TTConsulta";
            
            com.Parameters.Add("@FechaHora",SqlDbType.DateTime).Value= DateTime.Parse(Funcion.RegresaDato("select getdate() as fecha"));
        	
            com.Parameters.Add("@ComputerName",SqlDbType.VarChar).Value=Request.ServerVariables["REMOTE_ADDR"].ToString();
	        
            com.Parameters.Add("@Servername",SqlDbType.VarChar).Value="";
	        
            com.Parameters.Add("@DatabaseName",SqlDbType.VarChar).Value="";
	        
            com.Parameters.Add("@SystemName",SqlDbType.VarChar).Value="";
            
            com.Parameters.Add("@SystemVersion",SqlDbType.Decimal).Value=1.0;
	        
            com.Parameters.Add("@WindowsVersion",SqlDbType.VarChar).Value="";
            
            com.Parameters.Add("@CommandSQL",SqlDbType.VarChar).Value=txtQuery.Text.Replace("'","''");
            
            com.Parameters.Add("@FolioSQL",SqlDbType.VarChar).Value="";
            
            com.Parameters.Add("@ProcesoID",SqlDbType.SmallInt).Value=995;
            db.Consulta(com);
        }

        protected void MuestraResultado(DataSet ds)
        {
            txtError.Visible = false;
            grdResultado.Visible = true;
            pnlResultado.Visible = true;
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count != 0)
                {
                    if (ds.Tables[0].Rows.Count > 10000)
                    {
                        MuestraError("La consulta trae mas de 10,000 registros y no puede ser mostrada en esta pantalla, utilice la instrucción TOP 10000 para limitar la cantidad de registros mostrados.");
                    }
                    else
                    {
                        grdResultado.DataSource = ds;
                        grdResultado.DataBind();
                        pnlResultado.Width = txtQuery.Width;
                        grdResultado.Width = txtQuery.Width;
                        GuardaBitacora();
                    }
                }
            }
            else
            {
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand("Select 'La sentencia ha sido ejecutada satisfactoriamente!' as Resultado");
                com.CommandType = CommandType.Text;
                DataSet ds2 = db.Consulta(com);
                MuestraResultado(ds2);
            }
        }
    }
}








