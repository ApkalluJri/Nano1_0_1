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
public class objectBussinessTTBitacoraSQL : System.Web.Services.WebService
{
    public int iProcess = 6402;
    private TTTraductor.Traductor MyTraductor;
    public TTBitacoraSQLCS.objectBussinessTTBitacoraSQL myTTBitacoraSQL = new TTBitacoraSQLCS.objectBussinessTTBitacoraSQL();

    [WebMethod]
    public Int32 SelCount()
    {
        return myTTBitacoraSQL.SelCount();
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
        return myTTBitacoraSQL.SelAll(ConRelaciones);
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, TTBitacoraSQLCS.TTBitacoraSQLFilters[] myFilters)
    {
        myTTBitacoraSQL.Filters = myFilters;
        return myTTBitacoraSQL.SelAll(ConRelaciones);
        myTTBitacoraSQL.Filters = null;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTBitacoraSQL.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varIdUsuario, String varTipoSQL, DateTime? varFechaHora, String varComputerName, String varServerName, String varDatabaseName, String varSystemName, Decimal varSystemVersion, String varWindowsVersion, String varCommandSQL, String varFolioSQL, int? varProcesoID)
    {
        TTBitacoraSQLCS.objectBussinessTTBitacoraSQL  myTTBitacoraSQL= new TTBitacoraSQLCS.objectBussinessTTBitacoraSQL();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTBitacoraSQL.IdUsuario = varIdUsuario;
        myTTBitacoraSQL.TipoSQL = varTipoSQL;
        myTTBitacoraSQL.FechaHora = varFechaHora;
        myTTBitacoraSQL.ComputerName = varComputerName;
        myTTBitacoraSQL.ServerName = varServerName;
        myTTBitacoraSQL.DatabaseName = varDatabaseName;
        myTTBitacoraSQL.SystemName = varSystemName;
        myTTBitacoraSQL.SystemVersion = varSystemVersion;
        myTTBitacoraSQL.WindowsVersion = varWindowsVersion;
        myTTBitacoraSQL.CommandSQL = varCommandSQL;
        myTTBitacoraSQL.FolioSQL = varFolioSQL;
        myTTBitacoraSQL.ProcesoID = varProcesoID;

        String sMsg = "";
        if (!ValidaDataToSave(myTTBitacoraSQL, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTBitacoraSQL, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTBitacoraSQL.Insert(globalInfo, dr);
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, int? varIdUsuario, String varTipoSQL, DateTime? varFechaHora, String varComputerName, String varServerName, String varDatabaseName, String varSystemName, Decimal varSystemVersion, String varWindowsVersion, String varCommandSQL, String varFolioSQL, int? varProcesoID)
    {
        TTBitacoraSQLCS.objectBussinessTTBitacoraSQL  myTTBitacoraSQL= new TTBitacoraSQLCS.objectBussinessTTBitacoraSQL();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTBitacoraSQL.IdUsuario = varIdUsuario;
        myTTBitacoraSQL.TipoSQL = varTipoSQL;
        myTTBitacoraSQL.FechaHora = varFechaHora;
        myTTBitacoraSQL.ComputerName = varComputerName;
        myTTBitacoraSQL.ServerName = varServerName;
        myTTBitacoraSQL.DatabaseName = varDatabaseName;
        myTTBitacoraSQL.SystemName = varSystemName;
        myTTBitacoraSQL.SystemVersion = varSystemVersion;
        myTTBitacoraSQL.WindowsVersion = varWindowsVersion;
        myTTBitacoraSQL.CommandSQL = varCommandSQL;
        myTTBitacoraSQL.FolioSQL = varFolioSQL;
        myTTBitacoraSQL.ProcesoID = varProcesoID;

        String sMsg = "";
        if (!ValidaDataToSave(myTTBitacoraSQL, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTBitacoraSQL, out sMsg))
        {
            throw new Exception(sMsg);
        }
        return myTTBitacoraSQL.InsertWithReturnValue(globalInfo, dr);
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varFolio, int? varIdUsuario, String varTipoSQL, DateTime? varFechaHora, String varComputerName, String varServerName, String varDatabaseName, String varSystemName, Decimal varSystemVersion, String varWindowsVersion, String varCommandSQL, String varFolioSQL, int? varProcesoID)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myTTBitacoraSQL.Folio = varFolio;
        myTTBitacoraSQL.IdUsuario = varIdUsuario;
        myTTBitacoraSQL.TipoSQL = varTipoSQL;
        myTTBitacoraSQL.FechaHora = varFechaHora;
        myTTBitacoraSQL.ComputerName = varComputerName;
        myTTBitacoraSQL.ServerName = varServerName;
        myTTBitacoraSQL.DatabaseName = varDatabaseName;
        myTTBitacoraSQL.SystemName = varSystemName;
        myTTBitacoraSQL.SystemVersion = varSystemVersion;
        myTTBitacoraSQL.WindowsVersion = varWindowsVersion;
        myTTBitacoraSQL.CommandSQL = varCommandSQL;
        myTTBitacoraSQL.FolioSQL = varFolioSQL;
        myTTBitacoraSQL.ProcesoID = varProcesoID;

            String sMsg = "";
            if (!ValidaDataToSave(myTTBitacoraSQL, out sMsg))
            {
                throw new Exception(sMsg);
            }
            myTTBitacoraSQL.Update(globalInfo, dr);
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyFolio)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
         return myTTBitacoraSQL.Delete(KeyFolio, globalInfo, dr);
    }

    [WebMethod]
    public TTBitacoraSQLCS.objectBussinessTTBitacoraSQL GetByKey(int? KeyFolio, Boolean ConRelaciones)
    {
        myTTBitacoraSQL.GetByKey(KeyFolio, ConRelaciones);;
        return myTTBitacoraSQL;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyFolio)
    {
        return myTTBitacoraSQL.CurrentPosicion(KeyFolio);
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyFolio)
    {
        return myTTBitacoraSQL.ValidaExistencia(KeyFolio);
    }

    private bool ValidaDataToSave(TTBitacoraSQLCS.objectBussinessTTBitacoraSQL MyDataTTBitacoraSQL, out String sMsg)
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

    public bool ValidaDataDuplication(TTBitacoraSQLCS.objectBussinessTTBitacoraSQL MyDataTTBitacoraSQL, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTTBitacoraSQL.Folio == -1)
        {
            if (MyDataTTBitacoraSQL.ValidaExistencia(MyDataTTBitacoraSQL.Folio))
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
            ds.Tables.Add(myTTBitacoraSQL.FillDataIdUsuario().Copy());
        else
            ds.Tables.Add(myTTBitacoraSQL.FillDataIdUsuario(sFiltro).Copy());
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
            dt = myTTBitacoraSQL.FillDataIdUsuario();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["IdUsuario"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }
    [WebMethod]
    public DataSet FillDataProcesoID(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTBitacoraSQL.FillDataProcesoID().Copy());
        else
            ds.Tables.Add(myTTBitacoraSQL.FillDataProcesoID(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataProcesoIDCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTBitacoraSQL.FillDataProcesoID();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["IdProceso"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }

}