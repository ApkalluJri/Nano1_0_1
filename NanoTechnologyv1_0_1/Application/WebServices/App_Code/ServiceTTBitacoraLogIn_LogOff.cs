using System;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Services.Protocols;
using AjaxControlToolkit;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService()]
public class objectBussinessTTBitacoraLogIn_LogOff : System.Web.Services.WebService
{
    public int iProcess = 6400;
    private TTTraductor.Traductor MyTraductor;
    public TTBitacoraLogIn_LogOffCS.objectBussinessTTBitacoraLogIn_LogOff myTTBitacoraLogIn_LogOff = new TTBitacoraLogIn_LogOffCS.objectBussinessTTBitacoraLogIn_LogOff();

    [WebMethod]
    public Int32 SelCount()
    {
        return myTTBitacoraLogIn_LogOff.SelCount();
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
        return myTTBitacoraLogIn_LogOff.SelAll(ConRelaciones);
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, TTBitacoraLogIn_LogOffCS.TTBitacoraLogIn_LogOffFilters[] myFilters)
    {
        myTTBitacoraLogIn_LogOff.Filters = myFilters;
        return myTTBitacoraLogIn_LogOff.SelAll(ConRelaciones);
        myTTBitacoraLogIn_LogOff.Filters = null;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTBitacoraLogIn_LogOff.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varIdUsuario, DateTime? varFechaHora_Entrada, DateTime? varFechaHora_Salida, String varComputerName, String varServerName, String varDatabaseName, String varSystemName, Decimal varSystemVersion, String varWindowsVersion)
    {
        TTBitacoraLogIn_LogOffCS.objectBussinessTTBitacoraLogIn_LogOff  myTTBitacoraLogIn_LogOff= new TTBitacoraLogIn_LogOffCS.objectBussinessTTBitacoraLogIn_LogOff();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTBitacoraLogIn_LogOff.IdUsuario = varIdUsuario;
        myTTBitacoraLogIn_LogOff.FechaHora_Entrada = varFechaHora_Entrada;
        myTTBitacoraLogIn_LogOff.FechaHora_Salida = varFechaHora_Salida;
        myTTBitacoraLogIn_LogOff.ComputerName = varComputerName;
        myTTBitacoraLogIn_LogOff.ServerName = varServerName;
        myTTBitacoraLogIn_LogOff.DatabaseName = varDatabaseName;
        myTTBitacoraLogIn_LogOff.SystemName = varSystemName;
        myTTBitacoraLogIn_LogOff.SystemVersion = varSystemVersion;
        myTTBitacoraLogIn_LogOff.WindowsVersion = varWindowsVersion;

        String sMsg = "";
        if (!ValidaDataToSave(myTTBitacoraLogIn_LogOff, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTBitacoraLogIn_LogOff, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTBitacoraLogIn_LogOff.Insert(globalInfo, dr);
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, int? varIdUsuario, DateTime? varFechaHora_Entrada, DateTime? varFechaHora_Salida, String varComputerName, String varServerName, String varDatabaseName, String varSystemName, Decimal varSystemVersion, String varWindowsVersion)
    {
        TTBitacoraLogIn_LogOffCS.objectBussinessTTBitacoraLogIn_LogOff  myTTBitacoraLogIn_LogOff= new TTBitacoraLogIn_LogOffCS.objectBussinessTTBitacoraLogIn_LogOff();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTBitacoraLogIn_LogOff.IdUsuario = varIdUsuario;
        myTTBitacoraLogIn_LogOff.FechaHora_Entrada = varFechaHora_Entrada;
        myTTBitacoraLogIn_LogOff.FechaHora_Salida = varFechaHora_Salida;
        myTTBitacoraLogIn_LogOff.ComputerName = varComputerName;
        myTTBitacoraLogIn_LogOff.ServerName = varServerName;
        myTTBitacoraLogIn_LogOff.DatabaseName = varDatabaseName;
        myTTBitacoraLogIn_LogOff.SystemName = varSystemName;
        myTTBitacoraLogIn_LogOff.SystemVersion = varSystemVersion;
        myTTBitacoraLogIn_LogOff.WindowsVersion = varWindowsVersion;

        String sMsg = "";
        if (!ValidaDataToSave(myTTBitacoraLogIn_LogOff, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTBitacoraLogIn_LogOff, out sMsg))
        {
            throw new Exception(sMsg);
        }
        return myTTBitacoraLogIn_LogOff.InsertWithReturnValue(globalInfo, dr);
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varFolio, int? varIdUsuario, DateTime? varFechaHora_Entrada, DateTime? varFechaHora_Salida, String varComputerName, String varServerName, String varDatabaseName, String varSystemName, Decimal varSystemVersion, String varWindowsVersion)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myTTBitacoraLogIn_LogOff.Folio = varFolio;
        myTTBitacoraLogIn_LogOff.IdUsuario = varIdUsuario;
        myTTBitacoraLogIn_LogOff.FechaHora_Entrada = varFechaHora_Entrada;
        myTTBitacoraLogIn_LogOff.FechaHora_Salida = varFechaHora_Salida;
        myTTBitacoraLogIn_LogOff.ComputerName = varComputerName;
        myTTBitacoraLogIn_LogOff.ServerName = varServerName;
        myTTBitacoraLogIn_LogOff.DatabaseName = varDatabaseName;
        myTTBitacoraLogIn_LogOff.SystemName = varSystemName;
        myTTBitacoraLogIn_LogOff.SystemVersion = varSystemVersion;
        myTTBitacoraLogIn_LogOff.WindowsVersion = varWindowsVersion;

            String sMsg = "";
            if (!ValidaDataToSave(myTTBitacoraLogIn_LogOff, out sMsg))
            {
                throw new Exception(sMsg);
            }
            myTTBitacoraLogIn_LogOff.Update(globalInfo, dr);
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyFolio)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
         return myTTBitacoraLogIn_LogOff.Delete(KeyFolio, globalInfo, dr);
    }

    [WebMethod]
    public TTBitacoraLogIn_LogOffCS.objectBussinessTTBitacoraLogIn_LogOff GetByKey(int? KeyFolio, Boolean ConRelaciones)
    {
        myTTBitacoraLogIn_LogOff.GetByKey(KeyFolio, ConRelaciones);;
        return myTTBitacoraLogIn_LogOff;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyFolio)
    {
        return myTTBitacoraLogIn_LogOff.CurrentPosicion(KeyFolio);
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyFolio)
    {
        return myTTBitacoraLogIn_LogOff.ValidaExistencia(KeyFolio);
    }

    private bool ValidaDataToSave(TTBitacoraLogIn_LogOffCS.objectBussinessTTBitacoraLogIn_LogOff MyDataTTBitacoraLogIn_LogOff, out String sMsg)
    {
        //Validaciones
        sMsg = "";

        if (sMsg != "")
        {
            sMsg = MyTraductor.getMessage(15) + "\n" + sMsg + "\n" + MyTraductor.getMessage(7);
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool ValidaDataDuplication(TTBitacoraLogIn_LogOffCS.objectBussinessTTBitacoraLogIn_LogOff MyDataTTBitacoraLogIn_LogOff, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTTBitacoraLogIn_LogOff.Folio == -1)
        {
            if (MyDataTTBitacoraLogIn_LogOff.ValidaExistencia(MyDataTTBitacoraLogIn_LogOff.Folio))
            {
                sMsg = sMsg + MyTraductor.getMessage(84)+"\n";
            }
        }
        if (sMsg != "")
        {
            sMsg = MyTraductor.getMessage(6) + "\n" + sMsg + "\n" + MyTraductor.getMessage(7);
            return false;
        }
        else
        {
            return true;
        }
    }
    [WebMethod]
    public DataSet FillDataIdUsuario(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTBitacoraLogIn_LogOff.FillDataIdUsuario().Copy());
        else
            ds.Tables.Add(myTTBitacoraLogIn_LogOff.FillDataIdUsuario(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataIdUsuarioCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTBitacoraLogIn_LogOff.FillDataIdUsuario();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["IdUsuario"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }

}