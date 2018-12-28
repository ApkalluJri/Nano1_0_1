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
public class objectBussinessTTOperacion : System.Web.Services.WebService
{
    public int iProcess = 6399;
    private TTTraductor.Traductor MyTraductor;
    public TTOperacionCS.objectBussinessTTOperacion myTTOperacion = new TTOperacionCS.objectBussinessTTOperacion();

    [WebMethod]
    public Int32 SelCount()
    {
        return myTTOperacion.SelCount();
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
        return myTTOperacion.SelAll(ConRelaciones);
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, TTOperacionCS.TTOperacionFilters[] myFilters)
    {
        myTTOperacion.Filters = myFilters;
        return myTTOperacion.SelAll(ConRelaciones);
        myTTOperacion.Filters = null;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTOperacion.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, String varDescripcion)
    {
        TTOperacionCS.objectBussinessTTOperacion  myTTOperacion= new TTOperacionCS.objectBussinessTTOperacion();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTOperacion.Descripcion = varDescripcion;

        String sMsg = "";
        if (!ValidaDataToSave(myTTOperacion, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTOperacion, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTOperacion.Insert(globalInfo, dr);
    }
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varIdOperacion, String varDescripcion)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myTTOperacion.IdOperacion = varIdOperacion;
        myTTOperacion.Descripcion = varDescripcion;

            String sMsg = "";
            if (!ValidaDataToSave(myTTOperacion, out sMsg))
            {
                throw new Exception(sMsg);
            }
            myTTOperacion.Update(globalInfo, dr);
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyIdOperacion)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
         return myTTOperacion.Delete(KeyIdOperacion, globalInfo, dr);
    }

    [WebMethod]
    public TTOperacionCS.objectBussinessTTOperacion GetByKey(int? KeyIdOperacion, Boolean ConRelaciones)
    {
        myTTOperacion.GetByKey(KeyIdOperacion, ConRelaciones);;
        return myTTOperacion;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyIdOperacion)
    {
        return myTTOperacion.CurrentPosicion(KeyIdOperacion);
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyIdOperacion)
    {
        return myTTOperacion.ValidaExistencia(KeyIdOperacion);
    }

    private bool ValidaDataToSave(TTOperacionCS.objectBussinessTTOperacion MyDataTTOperacion, out String sMsg)
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

    public bool ValidaDataDuplication(TTOperacionCS.objectBussinessTTOperacion MyDataTTOperacion, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTTOperacion.IdOperacion == -1)
        {
            if (MyDataTTOperacion.ValidaExistencia(MyDataTTOperacion.IdOperacion))
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
