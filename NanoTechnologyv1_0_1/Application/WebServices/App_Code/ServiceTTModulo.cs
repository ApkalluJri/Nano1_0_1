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
public class objectBussinessTTModulo : System.Web.Services.WebService
{
    public int iProcess = 6393;
    private TTTraductor.Traductor MyTraductor;
    public TTModuloCS.objectBussinessTTModulo myTTModulo = new TTModuloCS.objectBussinessTTModulo();

    [WebMethod]
    public Int32 SelCount()
    {
        return myTTModulo.SelCount();
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
        return myTTModulo.SelAll(ConRelaciones);
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, TTModuloCS.TTModuloFilters[] myFilters)
    {
        myTTModulo.Filters = myFilters;
        return myTTModulo.SelAll(ConRelaciones);
        myTTModulo.Filters = null;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTModulo.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, String varNombre, int?[] varProcesos)
    {
        TTModuloCS.objectBussinessTTModulo  myTTModulo= new TTModuloCS.objectBussinessTTModulo();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTModulo.Nombre = varNombre;
        myTTModulo.Procesos =  new TTProceso_del_ModuloCS.objectBussinessTTProceso_del_Modulo[varProcesos.Length];
        for(int i = 0;i< varProcesos.Length ;i++)
        {
            myTTModulo.Procesos[i] = new TTProceso_del_ModuloCS.objectBussinessTTProceso_del_Modulo();
            myTTModulo.Procesos[i].IdProceso = varProcesos[i];
        }

        String sMsg = "";
        if (!ValidaDataToSave(myTTModulo, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTModulo, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTModulo.Insert(globalInfo, dr);
    }
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varIdModulo, String varNombre, int?[] varProcesos)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myTTModulo.IdModulo = varIdModulo;
        myTTModulo.Nombre = varNombre;
        myTTModulo.Procesos =  new TTProceso_del_ModuloCS.objectBussinessTTProceso_del_Modulo[varProcesos.Length];
        for(int i = 0;i< varProcesos.Length ;i++)
        {
            myTTModulo.Procesos[i] = new TTProceso_del_ModuloCS.objectBussinessTTProceso_del_Modulo();
            myTTModulo.Procesos[i].IdProceso = varProcesos[i];
        }

            String sMsg = "";
            if (!ValidaDataToSave(myTTModulo, out sMsg))
            {
                throw new Exception(sMsg);
            }
            myTTModulo.Update(globalInfo, dr);
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyIdModulo)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
         return myTTModulo.Delete(KeyIdModulo, globalInfo, dr);
    }

    [WebMethod]
    public TTModuloCS.objectBussinessTTModulo GetByKey(int? KeyIdModulo, Boolean ConRelaciones)
    {
        myTTModulo.GetByKey(KeyIdModulo, ConRelaciones);;
        return myTTModulo;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyIdModulo)
    {
        return myTTModulo.CurrentPosicion(KeyIdModulo);
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyIdModulo)
    {
        return myTTModulo.ValidaExistencia(KeyIdModulo);
    }

    private bool ValidaDataToSave(TTModuloCS.objectBussinessTTModulo MyDataTTModulo, out String sMsg)
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

    public bool ValidaDataDuplication(TTModuloCS.objectBussinessTTModulo MyDataTTModulo, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTTModulo.IdModulo == -1)
        {
            if (MyDataTTModulo.ValidaExistencia(MyDataTTModulo.IdModulo))
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
    public DataSet FillDataProcesos()
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTModulo.FillDataProcesos().Copy());
        return ds;
    }

}
