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
public class objectBussinessTTTipo_de_Control : System.Web.Services.WebService
{
    public int iProcess = 6798;
    private TTTraductor.Traductor MyTraductor;
    public TTTipo_de_ControlCS.objectBussinessTTTipo_de_Control myTTTipo_de_Control = new TTTipo_de_ControlCS.objectBussinessTTTipo_de_Control();

    [WebMethod]
    public Int32 SelCount()
    {
        return myTTTipo_de_Control.SelCount();
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
        return myTTTipo_de_Control.SelAll(ConRelaciones);
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, TTTipo_de_ControlCS.TTTipo_de_ControlFilters[] myFilters)
    {
        myTTTipo_de_Control.Filters = myFilters;
        return myTTTipo_de_Control.SelAll(ConRelaciones);
        myTTTipo_de_Control.Filters = null;
    }
    [WebMethod]
    public DataTable SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        return myTTTipo_de_Control.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32);
    }
    [WebMethod]
    public void Insert(String varDescripcion)
    {
        TTTipo_de_ControlCS.objectBussinessTTTipo_de_Control  myTTTipo_de_Control= new TTTipo_de_ControlCS.objectBussinessTTTipo_de_Control();
        TTSecurity.GlobalData gb = new TTSecurity.GlobalData();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("",0);
        gb.UserID = 1;
        gb.ComputerName = "gg";
        gb.ServidorName = "gg";
        gb.DatabaseName = "rr";
        gb.WindowsVersion = "jk";
        gb.Language = TTSecurity.GlobalDataLanguages.Default;
        MyTraductor= new TTTraductor.Traductor(gb.Language.GetHashCode());
        myTTTipo_de_Control.Descripcion = varDescripcion;

        String sMsg = "";
        if (!ValidaDataToSave(myTTTipo_de_Control, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTTipo_de_Control, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTTipo_de_Control.Insert(gb, dr);
    }
    [WebMethod]
    public void Update(int? varIdTipoControl, String varDescripcion)
    {
        TTSecurity.GlobalData gb = new TTSecurity.GlobalData();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        gb.UserID = 1;
        gb.ComputerName = "gg";
        gb.ServidorName = "gg";
        gb.DatabaseName = "rr";
        gb.WindowsVersion = "jk";
        myTTTipo_de_Control.IdTipoControl = varIdTipoControl;
        myTTTipo_de_Control.Descripcion = varDescripcion;

        String sMsg = "";
        if (!ValidaDataToSave(myTTTipo_de_Control, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTTipo_de_Control.Update(gb, dr);
    }
    [WebMethod]
    public bool Delete(int? KeyIdTipoControl)
    {
        TTSecurity.GlobalData gb = new TTSecurity.GlobalData();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        gb.UserID = 1;
        gb.ComputerName = "gg";
        gb.ServidorName = "gg";
        gb.DatabaseName = "rr";
        gb.WindowsVersion = "jk";
        return myTTTipo_de_Control.Delete(KeyIdTipoControl, gb, dr);
    }

    [WebMethod]
    public DataSet GetByKey(int? KeyIdTipoControl, Boolean ConRelaciones)
    {
        return myTTTipo_de_Control.GetByKey(KeyIdTipoControl, ConRelaciones);
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyIdTipoControl)
    {
        return myTTTipo_de_Control.CurrentPosicion(KeyIdTipoControl);
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyIdTipoControl)
    {
        return myTTTipo_de_Control.ValidaExistencia(KeyIdTipoControl);
    }

    private bool ValidaDataToSave(TTTipo_de_ControlCS.objectBussinessTTTipo_de_Control MyDataTTTipo_de_Control, out String sMsg)
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

    public bool ValidaDataDuplication(TTTipo_de_ControlCS.objectBussinessTTTipo_de_Control MyDataTTTipo_de_Control, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTTTipo_de_Control.IdTipoControl == -1)
        {
            if (MyDataTTTipo_de_Control.ValidaExistencia(MyDataTTTipo_de_Control.IdTipoControl))
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
