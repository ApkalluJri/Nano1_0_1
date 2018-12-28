using System;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Services.Protocols;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class objectBussinessTTGrupo_Reporte : System.Web.Services.WebService
{
    public int iProcess = 16336;
    private TTTraductor.Traductor MyTraductor;
    public TTGrupo_ReporteCS.objectBussinessTTGrupo_Reporte myTTGrupo_Reporte = new TTGrupo_ReporteCS.objectBussinessTTGrupo_Reporte();

    [WebMethod]
    public Int32 SelCount()
    {
        return myTTGrupo_Reporte.SelCount();
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
        return myTTGrupo_Reporte.SelAll(ConRelaciones);
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, TTGrupo_ReporteCS.TTGrupo_ReporteFilters[] myFilters)
    {
        myTTGrupo_Reporte.Filters = myFilters;
        return myTTGrupo_Reporte.SelAll(ConRelaciones);
        myTTGrupo_Reporte.Filters = null;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTGrupo_Reporte.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varIdGrupoReporte, String varNombre, DateTime? varFechaCreacion)
    {
        TTGrupo_ReporteCS.objectBussinessTTGrupo_Reporte  myTTGrupo_Reporte= new TTGrupo_ReporteCS.objectBussinessTTGrupo_Reporte();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTGrupo_Reporte.IdGrupoReporte = varIdGrupoReporte;
        myTTGrupo_Reporte.Nombre = varNombre;
        myTTGrupo_Reporte.FechaCreacion = varFechaCreacion;

        String sMsg = "";
        if (!ValidaDataToSave(myTTGrupo_Reporte, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTGrupo_Reporte, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTGrupo_Reporte.Insert(globalInfo, dr);
    }
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varIdGrupoReporte, String varNombre, DateTime? varFechaCreacion)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myTTGrupo_Reporte.IdGrupoReporte = varIdGrupoReporte;
        myTTGrupo_Reporte.Nombre = varNombre;
        myTTGrupo_Reporte.FechaCreacion = varFechaCreacion;

            String sMsg = "";
            if (!ValidaDataToSave(myTTGrupo_Reporte, out sMsg))
            {
                throw new Exception(sMsg);
            }
            myTTGrupo_Reporte.Update(globalInfo, dr);
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyIdGrupoReporte)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
         return myTTGrupo_Reporte.Delete(KeyIdGrupoReporte, globalInfo, dr);
    }

    [WebMethod]
    public TTGrupo_ReporteCS.objectBussinessTTGrupo_Reporte GetByKey(int? KeyIdGrupoReporte, Boolean ConRelaciones)
    {
        myTTGrupo_Reporte.GetByKey(KeyIdGrupoReporte, ConRelaciones);;
        return myTTGrupo_Reporte;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyIdGrupoReporte)
    {
        return myTTGrupo_Reporte.CurrentPosicion(KeyIdGrupoReporte);
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyIdGrupoReporte)
    {
        return myTTGrupo_Reporte.ValidaExistencia(KeyIdGrupoReporte);
    }

    private bool ValidaDataToSave(TTGrupo_ReporteCS.objectBussinessTTGrupo_Reporte MyDataTTGrupo_Reporte, out String sMsg)
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

    public bool ValidaDataDuplication(TTGrupo_ReporteCS.objectBussinessTTGrupo_Reporte MyDataTTGrupo_Reporte, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTTGrupo_Reporte.IdGrupoReporte != null)
        {
            if (MyDataTTGrupo_Reporte.ValidaExistencia(MyDataTTGrupo_Reporte.IdGrupoReporte))
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

}
