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
public class objectBussinessTTProceso_del_Modulo : System.Web.Services.WebService
{
    public int iProcess = 6392;
    private TTTraductor.Traductor MyTraductor;
    public TTProceso_del_ModuloCS.objectBussinessTTProceso_del_Modulo myTTProceso_del_Modulo = new TTProceso_del_ModuloCS.objectBussinessTTProceso_del_Modulo();

    [WebMethod]
    public Int32 SelCount()
    {
        return myTTProceso_del_Modulo.SelCount();
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
        return myTTProceso_del_Modulo.SelAll(ConRelaciones);
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, TTProceso_del_ModuloCS.TTProceso_del_ModuloFilters[] myFilters)
    {
        myTTProceso_del_Modulo.Filters = myFilters;
        return myTTProceso_del_Modulo.SelAll(ConRelaciones);
        myTTProceso_del_Modulo.Filters = null;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTProceso_del_Modulo.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        return ds;
    }
    [WebMethod]
    public void Insert(int? varIdModulo, int? varIdProceso)
    {
        TTProceso_del_ModuloCS.objectBussinessTTProceso_del_Modulo  myTTProceso_del_Modulo= new TTProceso_del_ModuloCS.objectBussinessTTProceso_del_Modulo();
        TTSecurity.GlobalData gb = new TTSecurity.GlobalData();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("",0);
        gb.UserID = 1;
        gb.ComputerName = "gg";
        gb.ServidorName = "gg";
        gb.DatabaseName = "rr";
        gb.WindowsVersion = "jk";
        gb.Language = TTSecurity.GlobalDataLanguages.Default;
        MyTraductor= new TTTraductor.Traductor(gb.Language.GetHashCode());
        myTTProceso_del_Modulo.IdModulo = varIdModulo;
        myTTProceso_del_Modulo.IdProceso = varIdProceso;

        String sMsg = "";
        if (!ValidaDataToSave(myTTProceso_del_Modulo, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTProceso_del_Modulo, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTProceso_del_Modulo.Insert(gb, dr);
    }
    [WebMethod]
    public void Update(int? varIdModulo, int? varIdProceso)
    {
        TTSecurity.GlobalData gb = new TTSecurity.GlobalData();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        gb.UserID = 1;
        gb.ComputerName = "gg";
        gb.ServidorName = "gg";
        gb.DatabaseName = "rr";
        gb.WindowsVersion = "jk";
        myTTProceso_del_Modulo.IdModulo = varIdModulo;
        myTTProceso_del_Modulo.IdProceso = varIdProceso;

        String sMsg = "";
        if (!ValidaDataToSave(myTTProceso_del_Modulo, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTProceso_del_Modulo.Update(gb, dr);
    }
    [WebMethod]
    public bool Delete(int? KeyIdModulo, int? KeyIdProceso)
    {
        TTSecurity.GlobalData gb = new TTSecurity.GlobalData();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        gb.UserID = 1;
        gb.ComputerName = "gg";
        gb.ServidorName = "gg";
        gb.DatabaseName = "rr";
        gb.WindowsVersion = "jk";
        return myTTProceso_del_Modulo.Delete(KeyIdModulo, KeyIdProceso, gb, dr);
    }

    [WebMethod]
    public DataSet GetByKey(int? KeyIdModulo, int? KeyIdProceso, Boolean ConRelaciones)
    {
        return myTTProceso_del_Modulo.GetByKey(KeyIdModulo, KeyIdProceso, ConRelaciones);
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyIdModulo, int? KeyIdProceso)
    {
        return myTTProceso_del_Modulo.CurrentPosicion(KeyIdModulo, KeyIdProceso);
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyIdModulo, int? KeyIdProceso)
    {
        return myTTProceso_del_Modulo.ValidaExistencia(KeyIdModulo, KeyIdProceso);
    }

    private bool ValidaDataToSave(TTProceso_del_ModuloCS.objectBussinessTTProceso_del_Modulo MyDataTTProceso_del_Modulo, out String sMsg)
    {
        //Validaciones
        sMsg = "";
            if (MyDataTTProceso_del_Modulo.IdModulo != null)
            {
                TTModuloCS.objectBussinessTTModulo MyDataTTModuloTemp = new TTModuloCS.objectBussinessTTModulo();
                if (!MyDataTTModuloTemp.ValidaExistencia(MyDataTTProceso_del_Modulo.IdModulo))
                {
                    sMsg = sMsg + "El Campo Clave del Modulo no existe\n";
                }
            }
            if (MyDataTTProceso_del_Modulo.IdProceso != null)
            {
                TTProcesoCS.objectBussinessTTProceso MyDataTTProcesoTemp = new TTProcesoCS.objectBussinessTTProceso();
                if (!MyDataTTProcesoTemp.ValidaExistencia(MyDataTTProceso_del_Modulo.IdProceso))
                {
                    sMsg = sMsg + "El Campo Clave del Proceso no existe\n";
                }
            }

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

    public bool ValidaDataDuplication(TTProceso_del_ModuloCS.objectBussinessTTProceso_del_Modulo MyDataTTProceso_del_Modulo, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTTProceso_del_Modulo.IdModulo != null&& MyDataTTProceso_del_Modulo.IdProceso != null)
        {
            if (MyDataTTProceso_del_Modulo.ValidaExistencia(MyDataTTProceso_del_Modulo.IdModulo, MyDataTTProceso_del_Modulo.IdProceso))
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
    public DataSet FillDataIdModulo(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTProceso_del_Modulo.FillDataIdModulo().Copy());
        else
            ds.Tables.Add(myTTProceso_del_Modulo.FillDataIdModulo(sFiltro).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet FillDataIdProceso(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTProceso_del_Modulo.FillDataIdProceso().Copy());
        else
            ds.Tables.Add(myTTProceso_del_Modulo.FillDataIdProceso(sFiltro).Copy());
        return ds;
    }

}
