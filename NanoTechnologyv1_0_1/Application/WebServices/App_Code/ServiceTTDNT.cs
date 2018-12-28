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
public class objectBussinessTTDNT : System.Web.Services.WebService
{
    public int iProcess = 6403;
    private TTTraductor.Traductor MyTraductor;
    public TTDNTCS.objectBussinessTTDNT myTTDNT = new TTDNTCS.objectBussinessTTDNT();

    [WebMethod]
    public Int32 SelCount()
    {
        return myTTDNT.SelCount();
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
        return myTTDNT.SelAll(ConRelaciones);
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, TTDNTCS.TTDNTFilters[] myFilters)
    {
        myTTDNT.Filters = myFilters;
        return myTTDNT.SelAll(ConRelaciones);
        myTTDNT.Filters = null;
    }
    [WebMethod]
    public DataTable SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        return myTTDNT.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32);
    }
    [WebMethod]
    public void Insert(int? varDNTID, String varNombre_Tabla, int? varrenglones_maximo, int? varrenglones_minimo)
    {
        TTDNTCS.objectBussinessTTDNT  myTTDNT= new TTDNTCS.objectBussinessTTDNT();
        TTSecurity.GlobalData gb = new TTSecurity.GlobalData();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("",0);
        gb.UserID = 1;
        gb.ComputerName = "gg";
        gb.ServidorName = "gg";
        gb.DatabaseName = "rr";
        gb.WindowsVersion = "jk";
        gb.Language = TTSecurity.GlobalDataLanguages.Default;
        MyTraductor= new TTTraductor.Traductor(gb.Language.GetHashCode());
        myTTDNT.DNTID = varDNTID;
        myTTDNT.Nombre_Tabla = varNombre_Tabla;
        myTTDNT.renglones_maximo = varrenglones_maximo;
        myTTDNT.renglones_minimo = varrenglones_minimo;

        String sMsg = "";
        if (!ValidaDataToSave(myTTDNT, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTDNT, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTDNT.Insert(gb, dr);
    }
    [WebMethod]
    public void Update(int? varDNTID, String varNombre_Tabla, int? varrenglones_maximo, int? varrenglones_minimo)
    {
        TTSecurity.GlobalData gb = new TTSecurity.GlobalData();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        gb.UserID = 1;
        gb.ComputerName = "gg";
        gb.ServidorName = "gg";
        gb.DatabaseName = "rr";
        gb.WindowsVersion = "jk";
        myTTDNT.DNTID = varDNTID;
        myTTDNT.Nombre_Tabla = varNombre_Tabla;
        myTTDNT.renglones_maximo = varrenglones_maximo;
        myTTDNT.renglones_minimo = varrenglones_minimo;

        String sMsg = "";
        if (!ValidaDataToSave(myTTDNT, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTDNT.Update(gb, dr);
    }
    [WebMethod]
    public bool Delete(int? KeyDNTID)
    {
        TTSecurity.GlobalData gb = new TTSecurity.GlobalData();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        gb.UserID = 1;
        gb.ComputerName = "gg";
        gb.ServidorName = "gg";
        gb.DatabaseName = "rr";
        gb.WindowsVersion = "jk";
        return myTTDNT.Delete(KeyDNTID, gb, dr);
    }

    [WebMethod]
    public DataSet GetByKey(int? KeyDNTID, Boolean ConRelaciones)
    {
        return myTTDNT.GetByKey(KeyDNTID, ConRelaciones);
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyDNTID)
    {
        return myTTDNT.CurrentPosicion(KeyDNTID);
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyDNTID)
    {
        return myTTDNT.ValidaExistencia(KeyDNTID);
    }

    private bool ValidaDataToSave(TTDNTCS.objectBussinessTTDNT MyDataTTDNT, out String sMsg)
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

    public bool ValidaDataDuplication(TTDNTCS.objectBussinessTTDNT MyDataTTDNT, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTTDNT.DNTID != null)
        {
            if (MyDataTTDNT.ValidaExistencia(MyDataTTDNT.DNTID))
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
