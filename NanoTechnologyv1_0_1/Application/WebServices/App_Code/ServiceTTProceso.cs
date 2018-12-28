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
public class objectBussinessTTProceso : System.Web.Services.WebService
{
    public int iProcess = 6391;
    private TTTraductor.Traductor MyTraductor;
    public TTProcesoCS.objectBussinessTTProceso myTTProceso = new TTProcesoCS.objectBussinessTTProceso();

    [WebMethod]
    public Int32 SelCount()
    {
        return myTTProceso.SelCount();
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
        return myTTProceso.SelAll(ConRelaciones);
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, TTProcesoCS.TTProcesoFilters[] myFilters)
    {
        myTTProceso.Filters = myFilters;
        return myTTProceso.SelAll(ConRelaciones);
        myTTProceso.Filters = null;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTProceso.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varIdProceso, String varNombre, String varPantalla)
    {
        TTProcesoCS.objectBussinessTTProceso  myTTProceso= new TTProcesoCS.objectBussinessTTProceso();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTProceso.IdProceso = varIdProceso;
        myTTProceso.Nombre = varNombre;
        myTTProceso.Pantalla = varPantalla;

        String sMsg = "";
        if (!ValidaDataToSave(myTTProceso, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTProceso, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTProceso.Insert(globalInfo, dr);
    }
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varIdProceso, String varNombre, String varPantalla)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myTTProceso.IdProceso = varIdProceso;
        myTTProceso.Nombre = varNombre;
        myTTProceso.Pantalla = varPantalla;

            String sMsg = "";
            if (!ValidaDataToSave(myTTProceso, out sMsg))
            {
                throw new Exception(sMsg);
            }
            myTTProceso.Update(globalInfo, dr);
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyIdProceso)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
         return myTTProceso.Delete(KeyIdProceso, globalInfo, dr);
    }

    [WebMethod]
    public TTProcesoCS.objectBussinessTTProceso GetByKey(int? KeyIdProceso, Boolean ConRelaciones)
    {
        myTTProceso.GetByKey(KeyIdProceso, ConRelaciones);;
        return myTTProceso;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyIdProceso)
    {
        return myTTProceso.CurrentPosicion(KeyIdProceso);
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyIdProceso)
    {
        return myTTProceso.ValidaExistencia(KeyIdProceso);
    }

    private bool ValidaDataToSave(TTProcesoCS.objectBussinessTTProceso MyDataTTProceso, out String sMsg)
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

    public bool ValidaDataDuplication(TTProcesoCS.objectBussinessTTProceso MyDataTTProceso, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTTProceso.IdProceso != null)
        {
            if (MyDataTTProceso.ValidaExistencia(MyDataTTProceso.IdProceso))
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
