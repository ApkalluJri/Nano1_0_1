using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

namespace TTDataLayerCS
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class BD
	{
		private SqlConnection db = new SqlConnection();
        private SqlTransaction myTrans;
        public BD()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public String ServidorNameComputer
        {
            get
            {
                String sReturn = "";
				//Microsoft.Win32.RegistryKey regkey;/* new Microsoft.Win32 Registry Key */
				//regkey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"Software\TotalTech\AgendaPolitica");
				//string[] valnames = regkey.GetValueNames();
				//for (int i = 0; i < valnames.Length; i++)
				//    if (valnames[i].ToUpper() == "SERVIDORCOMPUTER")
				//        sReturn = (string)regkey.GetValue(valnames[i]);
                return sReturn;
            }
            set
            {
				//Microsoft.Win32.RegistryKey regkey;/* new Microsoft.Win32 Registry Key */
				//regkey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"Software\TotalTech\AgendaPolitica");
				//regkey.SetValue("SERVIDORCOMPUTER", value);
            }
        }
        public String DataBase
        {
            get
            {
                String sReturn="";
				//Microsoft.Win32.RegistryKey regkey;/* new Microsoft.Win32 Registry Key */
				//regkey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"Software\TotalTech\AgendaPolitica");
				//string[] valnames = regkey.GetValueNames();
				//for (int i = 0; i < valnames.Length; i++)
				//    if (valnames[i].ToUpper() == "BASEDATOS")
				//        sReturn= (string)regkey.GetValue(valnames[i]);
                return sReturn;
            }
            set
            {
				//Microsoft.Win32.RegistryKey regkey;/* new Microsoft.Win32 Registry Key */
				//regkey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"Software\TotalTech\AgendaPolitica");
				//regkey.SetValue("BASEDATOS", value);
            }
        }
        public String Server 
        {
            get
            {
                String sReturn = "";
				//Microsoft.Win32.RegistryKey regkey;/* new Microsoft.Win32 Registry Key */
				//regkey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"Software\TotalTech\AgendaPolitica");
				//string[] valnames = regkey.GetValueNames();
				//for (int i = 0; i < valnames.Length; i++)
				//    if (valnames[i].ToUpper() == "SERVIDOR")
				//        sReturn = (string)regkey.GetValue(valnames[i]);
                return sReturn;
            }
            set
            {
				//Microsoft.Win32.RegistryKey regkey;/* new Microsoft.Win32 Registry Key */
				//regkey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"Software\TotalTech\AgendaPolitica");
				//regkey.SetValue("SERVIDOR", value);
            }
        }
        public String Password
        {
            get
            {
                String sReturn = "";
				//Microsoft.Win32.RegistryKey regkey;/* new Microsoft.Win32 Registry Key */
				//regkey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"Software\TotalTech\AgendaPolitica");
				//string[] valnames = regkey.GetValueNames();
				//for (int i = 0; i < valnames.Length; i++)
				//    if (valnames[i].ToUpper() == "PASSWORD")
				//        sReturn = (string)regkey.GetValue(valnames[i]);
                return sReturn;
            }
            set
            {
				//Microsoft.Win32.RegistryKey regkey;/* new Microsoft.Win32 Registry Key */
				//regkey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"Software\TotalTech\AgendaPolitica");
				//regkey.SetValue("PASSWORD", value);
            }
        }
        public String User
        {
            get 
            {
                String sReturn = "";
				//Microsoft.Win32.RegistryKey regkey;/* new Microsoft.Win32 Registry Key */
				//regkey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"Software\TotalTech\AgendaPolitica");
				//string[] valnames = regkey.GetValueNames();
				//for (int i = 0; i < valnames.Length; i++)
				//    if (valnames[i].ToUpper()=="USER")
				//        sReturn = (string)regkey.GetValue(valnames[i]);
                return sReturn;
            }
            set {
				//Microsoft.Win32.RegistryKey regkey;/* new Microsoft.Win32 Registry Key */
				//regkey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"Software\TotalTech\AgendaPolitica");
				//regkey.SetValue("USER", value);

            }
        }
        public Boolean TrustedConexion
        {
            get
            {
                Boolean  sReturn = false;
				//Microsoft.Win32.RegistryKey regkey;/* new Microsoft.Win32 Registry Key */
				//regkey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"Software\TotalTech\AgendaPolitica");
				//string[] valnames = regkey.GetValueNames();
				//for (int i = 0; i < valnames.Length; i++)
				//    if (valnames[i].ToUpper() == "TRUSTEDCONEXION")
				//        sReturn = Boolean.Parse(regkey.GetValue(valnames[i],false).ToString());
                return sReturn;
            }
            set
            {
				//Microsoft.Win32.RegistryKey regkey;/* new Microsoft.Win32 Registry Key */
				//regkey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"Software\TotalTech\AgendaPolitica");
				//regkey.SetValue("TrustedConexion", value);
            }
        }
        public Boolean isConfigurated()
        {
			//if (DataBase == "" || Server == "")
			//    return false;
            
            try {
                SqlConnection MyDBTemp = new SqlConnection(connectionString);
                MyDBTemp.Open();
                return true;
            }
            catch 
            {
                return false;
            }
            
        }
        private String connectionString
        {
            get { return @"@@CONNECTION_STRING@@"; }
        }
        public void Connect()
        {
            if (db.State == ConnectionState.Open)
                db.Close();
            db.ConnectionString = connectionString;
            db.Open();
        }
		public string ServidorName()
        {
            string databaseName;
            Connect();
            databaseName = db.DataSource;
            Disconnect();
            return databaseName;
        }
        public string DatabaseName()
        {
            string databaseName;
            Connect();
            databaseName = db.Database;
            Disconnect();
            return databaseName;
        }
        public void Disconnect()
		{			
			db.Close();
		}
        private bool checkErrConectionAndResponse(SqlException ex)
        {
            String sMsjErr = "";
            switch (ex.Number)
            {
                case 233:
                    {
                        //MessageBox.Show(ex.GetHashCode().ToString() + "\n"+ex.Message );
                        //Clipboard.SetDataObject(ex.GetHashCode().ToString() + "\n" + ex.Message);
                        sMsjErr = "Se perdio la conexion con el servidor\nServidor : "+ Server ;
                        break;
                    }
                default:
                    {
                        //MessageBox.Show("Error en tablas\n\n" + ex.Message);
                        //return false;
                        sMsjErr = ex.Message;
                        break; 
                    }
            }
            if (MessageBoxEx.Show(sMsjErr + "\nDecea reintentar conexion?", "Error de Conexion - Intentando reconexion cada 30 seg", MessageBoxButtons.RetryCancel , MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, 30000) ==  DialogResult.Retry)
                return true;
            else
                return false;
        }

        public DataSet Consulta(SqlCommand sc)
        {
            DataSet ds = new DataSet();
            Boolean bFailedConexion = true;
            while (bFailedConexion)
                try
                {
                    Connect();
                    SqlDataAdapter da;
                    da = new SqlDataAdapter(sc);
                    da.SelectCommand.Connection = db;
                    da.Fill(ds);
                    Disconnect();
                    bFailedConexion = false;
                }
                catch (SqlException ex)
                {
                    throw ex;
                    CreaArchivoError(ex);
                    //if (checkErrConectionAndResponse(ex))
                    //    bFailedConexion = true;
                    //else
                    //{
                    //    bFailedConexion = false;
                    //    ds.Tables.Add();
                    //}
                }
            return ds;

        }
        public DataSet Consulta(SqlCommand sc,Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
        {
            DataSet ds = new DataSet();
            Boolean bFailedConexion = true;
            while (bFailedConexion)
                try
                {
                    Connect();
                    SqlDataAdapter da;
                    da = new SqlDataAdapter(sc);
                    da.SelectCommand.Connection = db;
                    da.Fill(ds, CurrentRecordInt32, RecordsDisplayedInt32, "");
                    Disconnect();
                    bFailedConexion = false;
                }
                catch (SqlException ex)
                {
                    throw ex;
                    CreaArchivoError(ex);
                    //if (checkErrConectionAndResponse(ex))
                    //    bFailedConexion = true;
                    //else
                    //{
                    //    bFailedConexion = false;
                    //    ds.Tables.Add();
                    //}
                }
            return ds;
        }

		public DataSet ConsultaFiltro(String sSql,String sFilter)
		{	
            DataSet ds = new DataSet();
            Boolean bFailedConexion = true;
            while (bFailedConexion)
                try
                {
                    Connect();
                    Disconnect();
                    bFailedConexion = false;
                }
                catch (SqlException ex)
                {
                    throw ex;
                    CreaArchivoError(ex);
                    //if (checkErrConectionAndResponse(ex))
                    //    bFailedConexion = true;
                    //else
                    //{
                    //    bFailedConexion = false;
                    //    ds.Tables.Add();
                    //}
                }
			return ds;
		}

        public object ExecuteScalar(SqlCommand sc)
        {
            Connect();
            sc.Connection = this.db;
            object result = sc.ExecuteScalar();
            Disconnect();
            return result;            
        }

        public Int32 GetCount(SqlCommand sc)
        {
            Int32 Count = 0;
            Boolean bFailedConexion = true;
            while (bFailedConexion)
                try
                {
                    Connect();
                    sc.Connection = db;
                    Count = Int32.Parse(sc.ExecuteScalar().ToString());
                    Disconnect();
                    bFailedConexion = false;
                }
                catch (SqlException ex)
                {
                    throw ex;
                    CreaArchivoError(ex);
                    //if (checkErrConectionAndResponse(ex))
                    //    bFailedConexion = true;
                    //else
                    //    bFailedConexion = false;
                }
            return Count;
        }

        public String Insert(SqlCommand sc)
        {
            string sLlave = "";
            DataSet ds = new DataSet();
                try
                {
                    if (myTrans != null)
                    {
                        sc.Connection = db;
                        sc.Transaction = myTrans;
                        object obj = sc.ExecuteScalar();
                        if (obj!= null)
                            sLlave = obj.ToString();
                    }
                    else
                    {
                        Connect();
                        sc.Connection = db;
                        sc.Transaction = myTrans;
                        object obj = sc.ExecuteScalar();
                        if (obj != null)
                            sLlave = obj.ToString();
                        Disconnect();
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                    CreaArchivoError(ex);
                }
            return sLlave;
        }

        public bool Delete(SqlCommand sc)
        {
            bool result = false;
            DataSet ds = new DataSet();
                try
                {
                    if (myTrans != null)
                    {
                        sc.Connection = db;
                        sc.Transaction = myTrans;
                        sc.ExecuteNonQuery();
                        result = true;
                    }
                    else
                    {
                        Connect();
                        sc.Connection = db;
                        sc.Transaction = myTrans;
                        sc.ExecuteNonQuery();
                        result = true;
                        Disconnect();
                    }
                }
                catch (SqlException ex)
                {
                    result = false;
                    throw ex;
                    CreaArchivoError(ex);
                }
            return result;
        }

        private String EjecutaInsert(SqlCommand sc, TTSecurity.GlobalData UserInformation, DataLayerFieldsBitacora DataReference, Boolean Reconect)
        {
            string sLlave = "";
            DataSet ds = new DataSet();
            Boolean bFailedConexion = true;
            while (bFailedConexion )
                try
                {
                    if (myTrans != null)
                    {
                        sc.Connection = db;
                        sc.Transaction = myTrans;
                        sLlave = sc.ExecuteScalar().ToString();
                        DataReference.Folio = sLlave;
                        InsertIntoBitacora(DataLayerModeBitacora.Insert, UserInformation, sc, DataReference);
                    }
                    else
                    {
                        Connect();
                        sc.Connection = db;
                        sc.Transaction = myTrans;
                        sLlave = sc.ExecuteScalar().ToString();
                        DataReference.Folio = sLlave;
                        InsertIntoBitacora(DataLayerModeBitacora.Insert, UserInformation, sc, DataReference);
                        Disconnect();
                    }
                    bFailedConexion = false;
                }
                catch (SqlException ex)
                {
                    throw ex;
                    CreaArchivoError(ex);
                    //if (!Reconect)
                    //    throw ex;
                    //else
                    //    if (checkErrConectionAndResponse(ex))
                    //        bFailedConexion = true;
                    //    else
                    //    {
                    //        bFailedConexion = false;
                    //        ds.Tables.Add();
                    //    }
                }
            return sLlave;
        }
        public String EjecutaInsert(SqlCommand sc, TTSecurity.GlobalData UserInformation, DataLayerFieldsBitacora DataReference)
		{
            return EjecutaInsert(sc, UserInformation, DataReference, true);
		}
        public String EjecutaInsertWhitOutReconect(SqlCommand sc, TTSecurity.GlobalData UserInformation, DataLayerFieldsBitacora DataReference)
        {
            return EjecutaInsert(sc, UserInformation, DataReference, false);
        }

        public bool EjecutaDelete(SqlCommand sc, TTSecurity.GlobalData UserInformation, DataLayerFieldsBitacora DataReference)
		{
            bool result=false;
            DataSet ds = new DataSet();
            Boolean bFailedConexion = true;
            while (bFailedConexion)
                try
                {
                    if (myTrans != null)
                    {
                        sc.Connection = db;
                        sc.Transaction = myTrans;
                        sc.ExecuteNonQuery();
                        result = true;
                        DataReference.Folio = "";
                        InsertIntoBitacora(DataLayerModeBitacora.Delete, UserInformation, sc, DataReference);
                    }
                    else
                    {
                        Connect();
                        sc.Connection = db;
                        sc.Transaction = myTrans;
                        sc.ExecuteNonQuery();
                        result = false;
                        DataReference.Folio = "";
                        InsertIntoBitacora(DataLayerModeBitacora.Delete, UserInformation, sc, DataReference);
                        Disconnect();
                    }
                    bFailedConexion = false;
                }
                catch (SqlException ex)
                {
                    throw ex;
                    CreaArchivoError(ex);
                    //if (checkErrConectionAndResponse(ex))
                    //    bFailedConexion = true;
                    //else
                    //{
                    //    bFailedConexion = false;
                    //    ds.Tables.Add();
                    //}
                }
            return result;
        }

        public String EjecutaUpdate(SqlCommand sc, TTSecurity.GlobalData UserInformation, DataLayerFieldsBitacora DataReference )
		{
            string sLlave = "";
            DataSet ds = new DataSet();
            Boolean bFailedConexion = true;
            while (bFailedConexion)
                try
                {
                    if (myTrans != null)
                    {
                        sc.Connection = db;
                        sc.Transaction = myTrans;
                        sLlave = sc.ExecuteScalar().ToString();
                        DataReference.Folio = sLlave;
                        InsertIntoBitacora(DataLayerModeBitacora.Update, UserInformation, sc, DataReference);
                    }
                    else
                    {
                        Connect();
                        sc.Connection = db;
                        sc.Transaction = myTrans;
                        sLlave = sc.ExecuteScalar().ToString();
                        DataReference.Folio = sLlave;
                        InsertIntoBitacora(DataLayerModeBitacora.Update, UserInformation, sc, DataReference);
                        Disconnect();
                    }
                    bFailedConexion = false;
                }
                catch (SqlException ex)
                {
                    throw ex;
                    CreaArchivoError(ex);
                    //if (checkErrConectionAndResponse(ex))
                    //    bFailedConexion = true;
                    //else
                    //{
                    //    bFailedConexion = false;
                    //    ds.Tables.Add();
                    //}
                }

			return sLlave;
		}

        public Boolean EjecutaQuery(SqlCommand sc, TTSecurity.GlobalData UserInformation, DataLayerFieldsBitacora DataReference)
        {
            string sLlave = "";
            DataSet ds = new DataSet();
            Boolean bFailedConexion = true;
            while (bFailedConexion)
                try
                {
                    if (myTrans != null)
                    {
                        sc.Connection = db;
                        sc.Transaction = myTrans;
                        sc.ExecuteNonQuery();
                        DataReference.Folio = sLlave;
                        InsertIntoBitacora(DataLayerModeBitacora.Update, UserInformation, sc, DataReference);
                    }
                    else
                    {
                        Connect();
                        sc.Connection = db;
                        sc.Transaction = myTrans;
                        sc.ExecuteNonQuery();
                        DataReference.Folio = sLlave;
                        InsertIntoBitacora(DataLayerModeBitacora.Update, UserInformation, sc, DataReference);
                        Disconnect();
                    }
                    bFailedConexion = false;
                }
                catch (SqlException ex)
                {
                    throw ex;
                    CreaArchivoError(ex);
                    //if (checkErrConectionAndResponse(ex))
                    //    bFailedConexion = true;
                    //else
                    //{
                    //    bFailedConexion = false;
                    //    ds.Tables.Add();
                    //}
                }

            return true;
        }

        public Boolean BeginTransaction(String transName)
        {
            Boolean bReturn = false;
            Boolean bFailedConexion = true;
            while (bFailedConexion)
                try
                {
                    Connect();
                    if (transName.Length > 32)
                        transName = transName.Substring(32);
                    myTrans = db.BeginTransaction(transName);
                    bFailedConexion = false;
                    bReturn =true;
                }
                catch (SqlException ex)
                {
                    throw ex;
                    CreaArchivoError(ex);
                    //if (checkErrConectionAndResponse(ex))
                    //    bFailedConexion = true;
                    //else
                    //{
                    //    bFailedConexion = false;
                    //    bReturn = false;
                    //}
                }
            return bReturn;
        }
        public Boolean CommitTransaction()
        {
            Boolean bReturn = false;
            Boolean bFailedConexion = true;
            while (bFailedConexion)
                try
                {
                    myTrans.Commit();
                    myTrans = null;
                    Disconnect();
                    bFailedConexion = false;
                    bReturn = true;
                }
                catch (SqlException ex)
                {
                    throw ex;
                    CreaArchivoError(ex);
                    //if (checkErrConectionAndResponse(ex))
                    //    bFailedConexion = true;
                    //else
                    //{
                    //    bFailedConexion = false;
                    //    bReturn = false;
                    //}
                }
            return bReturn;
        }
        public Boolean  RollBackTransaction(String transName)
        {
            if (myTrans == null)
                return false;
            Boolean bReturn = false;
            Boolean bFailedConexion = true;
            while (bFailedConexion)
                try
                {
                    if (transName.Length > 32)
                        transName = transName.Substring(32);
                    myTrans.Rollback(transName);
                    myTrans = null;
                    Disconnect();
                    bReturn = true;
                }
                catch (SqlException ex)
                {
                    throw ex;
                    CreaArchivoError(ex);
                    //if (checkErrConectionAndResponse(ex))
                    //    bFailedConexion = true;
                    //else
                    //{
                    //    bFailedConexion = false;
                    //    bReturn = false;
                    //}
                }
            return bReturn;
        }

        private void CreaArchivoError(Exception exce)
        {
            StreamWriter archivo = File.CreateText("Error_" + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() +  ".txt");
            archivo.WriteLine("Error: " + exce.Message.ToString());
            archivo.Close();
        }

        private void InsertIntoBitacora(DataLayerModeBitacora Mode, TTSecurity.GlobalData UserInformation, SqlCommand sc, DataLayerFieldsBitacora DataReference)
        {
            SqlCommand com = new SqlCommand("spTTDataLayer_InsertIntoBitacora");
            com.Parameters.AddWithValue("@FolioSQL", DataReference.Folio);
            com.Parameters.AddWithValue("@ProcesoID", DataReference.Proceso);
            com.Parameters.AddWithValue("@UserID", UserInformation.UserID);
            com.Parameters.AddWithValue("@ModeSQL", Mode.ToString());
            com.Parameters.AddWithValue("@ComputerName", UserInformation.ComputerName);
            com.Parameters.AddWithValue("@ServerName", UserInformation.ServidorName);
            com.Parameters.AddWithValue("@DatabaseName", UserInformation.DatabaseName);
            com.Parameters.AddWithValue("@SystemName", UserInformation.SystemVersion.SystemName);
            com.Parameters.AddWithValue("@SystemVersion", UserInformation.SystemVersion.SystemVersion);
            com.Parameters.AddWithValue("@WindowsVersion", UserInformation.WindowsVersion);
            String sqlComm = sc.CommandText;
            foreach (SqlParameter par in sc.Parameters)
                sqlComm += " " + par.ParameterName + "="+ par.Value.ToString() + ","; 
            com.Parameters.AddWithValue("@CommandSQL", sqlComm);

            com.CommandType = CommandType.StoredProcedure;

            //Connect();
            string sLlave = "";
            DataSet ds = new DataSet();
            Boolean bFailedConexion = true;
            while (bFailedConexion)
                try
                {
                    com.Connection = db;
                    com.Transaction = myTrans;
                    sLlave = com.ExecuteScalar().ToString();
                    //GeneraBitacora(
                    bFailedConexion = false;
                }
                catch (SqlException ex)
                {
                    throw ex;
                    CreaArchivoError(ex);
                    //if (checkErrConectionAndResponse(ex))
                    //    bFailedConexion = true;
                    //else
                    //{
                    //    bFailedConexion = false;
                    //    ds.Tables.Add();
                    //}
                }
            //Disconnect();
        }

        enum DataLayerModeBitacora
        {
            Insert = 1,
            Update = 2,
            Delete = 3
        }
	}

    public class DataLayerFieldsBitacora
    {
        public DataLayerFieldsBitacora(String sFolio,int iProceso )
        {
            Folio = sFolio;
            Proceso= iProceso;
        }
        private String folio;
        private int proceso;
        public String Folio
        {
            get { return folio; }
            set { folio = value; }
        }
        public int Proceso
        {
            get { return proceso; }
            set { proceso = value; }
        }
    }


}
