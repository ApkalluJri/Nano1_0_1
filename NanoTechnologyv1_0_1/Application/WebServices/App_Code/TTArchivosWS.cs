using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.IO;

/// <summary>
/// Summary description for TTArchivosWS
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class TTArchivosWS : System.Web.Services.WebService {

    public TTArchivosWS () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string UploadFile(int UserId, string FileName, byte[] Archivo,int Folio)
    {
        string Result = "";
        string TipoTransaccion="";
        if (Folio == 0)
            TipoTransaccion = "New";
        else
            TipoTransaccion = "Update";

        try
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand("spInsTTArchivo");
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@Nombre", SqlDbType.NVarChar, 300).Value = FileName;
            com.Parameters.Add("@Tamano", SqlDbType.Decimal).Value = Decimal.Parse(Archivo.Length.ToString());
            com.Parameters.Add("@Pc", SqlDbType.NVarChar, 300).Value = "WebApi";
            com.Parameters.Add("@Ruta", SqlDbType.NVarChar, 1000).Value = Server.MapPath("TempFiles/");
            com.Parameters.Add("@Usuario", SqlDbType.Int).Value = UserId;
            com.Parameters.Add("@Proceso", SqlDbType.Int).Value = DBNull.Value;
            com.Parameters.Add("@Operacion", SqlDbType.SmallInt).Value = 0; ;
            com.Parameters.Add("@FolioProceso", SqlDbType.NVarChar, 200).Value = ""; ;
            com.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = DateTime.Parse(DateTime.Now.ToShortDateString());
            com.Parameters.Add("@Archivo", SqlDbType.Image).Value = Archivo;
            com.Parameters.Add("@Accion", SqlDbType.NVarChar, 10).Value = TipoTransaccion;
            com.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio;
            DataSet ds = db.Consulta(com);

            if (TipoTransaccion != "Update" || Folio == 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                    Result = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                else
                    Result = "Error";
            }
            if (File.Exists(Server.MapPath("TempFiles/") + FileName))
                File.Delete(Server.MapPath("TempFiles/") + FileName);
        }
        catch (Exception ex)
        {
            Result = "ERROR: " + ex.Message;
        }
        return Result;
    }

    [WebMethod]
    public DataSet GetById(int Folio)
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand("Select Archivo,Nombre from TTArchivos with(nolock) where Folio=" + Folio.ToString());
        com.CommandType = CommandType.Text;
        DataSet ds = db.Consulta(com);
        return ds;
    }

    [WebMethod]
    public string GetURLById(int Folio)
    {
        string URL = "";
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand("Select Archivo,Nombre from TTArchivos where Folio=" + Folio);
        com.CommandType = CommandType.Text;
        string NombreArchivo = "";
        DataSet ds = db.Consulta(com);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //Crear y guardar archivo 					
            if (!File.Exists(Server.MapPath("TempFiles/" + ds.Tables[0].Rows[0].ItemArray[1].ToString())))
                //File.Delete(Server.MapPath("TempFiles/" + ds.Tables[0].Rows[0].ItemArray[1].ToString()));
	    {	
	            FileStream fs = File.Create(Server.MapPath("TempFiles/" + ds.Tables[0].Rows[0].ItemArray[1].ToString()));
        	    Byte[] Bytes = (Byte[])ds.Tables[0].Rows[0].ItemArray[0];
	            NombreArchivo = ds.Tables[0].Rows[0].ItemArray[1].ToString();
	            foreach (byte b in Bytes)
	                fs.WriteByte(b);

	            fs.Flush();//liberando recursos				
        	    fs.Close();
	    }
            URL = HttpContext.Current.Request.Url.AbsoluteUri.ToUpper().Replace("TTARCHIVOSWS.ASMX/GETURLBYID", "") + "TempFiles/" + ds.Tables[0].Rows[0].ItemArray[1].ToString();
        }
        db.Dispose();
        ds.Dispose();
        com.Dispose();
        return URL;
    }

    
    
}

