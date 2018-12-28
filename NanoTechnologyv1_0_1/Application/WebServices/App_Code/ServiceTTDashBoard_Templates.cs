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
public class objectBussinessTTDashBoard_Templates : System.Web.Services.WebService
{
    public int iProcess = 6808;
    private TTTraductor.Traductor MyTraductor;
    public TTDashBoard_TemplatesCS.objectBussinessTTDashBoard_Templates myTTDashBoard_Templates = new TTDashBoard_TemplatesCS.objectBussinessTTDashBoard_Templates();

    [WebMethod]
    public Int32 SelCount()
    {
        return myTTDashBoard_Templates.SelCount();
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
        return myTTDashBoard_Templates.SelAll(ConRelaciones);
    }
    [WebMethod]
    public DataTable SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        return myTTDashBoard_Templates.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32);
    }
    [WebMethod]
    public void Insert(String varDescripcion, int? varImageTemplate, int? varPosicionX1, int? varPosicionY1, int? varPosicionX2, int? varPosicionY2, int?[] varComponentesidTipoComponente, int?[] varComponentesPosicionX1, int?[] varComponentesPosicionY1, int?[] varComponentesPosicionX2, int?[] varComponentesPosicionY2, int? varImageExpanded, int? varFullScreen_X1, int? varFullScreen_Y1, int? varFullScreen_X2, int? varFullScreen_Y2)
    {
        TTDashBoard_TemplatesCS.objectBussinessTTDashBoard_Templates  myTTDashBoard_Templates= new TTDashBoard_TemplatesCS.objectBussinessTTDashBoard_Templates();
        TTSecurity.GlobalData gb = new TTSecurity.GlobalData();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("",0);
        gb.UserID = 1;
        gb.ComputerName = "gg";
        gb.ServidorName = "gg";
        gb.DatabaseName = "rr";
        gb.WindowsVersion = "jk";
        gb.Language = TTSecurity.GlobalDataLanguages.Default;
        MyTraductor= new TTTraductor.Traductor(gb.Language.GetHashCode());
        myTTDashBoard_Templates.Descripcion = varDescripcion;
        myTTDashBoard_Templates.ImageTemplate = varImageTemplate;
        myTTDashBoard_Templates.PosicionX1 = varPosicionX1;
        myTTDashBoard_Templates.PosicionY1 = varPosicionY1;
        myTTDashBoard_Templates.PosicionX2 = varPosicionX2;
        myTTDashBoard_Templates.PosicionY2 = varPosicionY2;
            myTTDashBoard_Templates.Componentes = new TTDashBoard_TemplatesRelacionComponenteCS.objectBussinessTTDashBoard_TemplatesRelacionComponente[varComponentesidTipoComponente.Length];
            for (int i = 0; i < varComponentesidTipoComponente.Length; i++)
            {
                myTTDashBoard_Templates.Componentes[i] = new TTDashBoard_TemplatesRelacionComponenteCS.objectBussinessTTDashBoard_TemplatesRelacionComponente();
                myTTDashBoard_Templates.Componentes[i].idTipoComponente = varComponentesidTipoComponente[i];
                myTTDashBoard_Templates.Componentes[i].PosicionX1 = varComponentesPosicionX1[i];
                myTTDashBoard_Templates.Componentes[i].PosicionY1 = varComponentesPosicionY1[i];
                myTTDashBoard_Templates.Componentes[i].PosicionX2 = varComponentesPosicionX2[i];
                myTTDashBoard_Templates.Componentes[i].PosicionY2 = varComponentesPosicionY2[i];

            }
        myTTDashBoard_Templates.ImageExpanded = varImageExpanded;
        myTTDashBoard_Templates.FullScreen_X1 = varFullScreen_X1;
        myTTDashBoard_Templates.FullScreen_Y1 = varFullScreen_Y1;
        myTTDashBoard_Templates.FullScreen_X2 = varFullScreen_X2;
        myTTDashBoard_Templates.FullScreen_Y2 = varFullScreen_Y2;

        String sMsg = "";
        if (!ValidaDataToSave(myTTDashBoard_Templates, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTDashBoard_Templates, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTDashBoard_Templates.Insert(gb, dr);
    }
    [WebMethod]
    public void Update(int? varidTemplate, String varDescripcion, int? varImageTemplate, int? varPosicionX1, int? varPosicionY1, int? varPosicionX2, int? varPosicionY2, int?[] varComponentesidTipoComponente, int?[] varComponentesPosicionX1, int?[] varComponentesPosicionY1, int?[] varComponentesPosicionX2, int?[] varComponentesPosicionY2, int? varImageExpanded, int? varFullScreen_X1, int? varFullScreen_Y1, int? varFullScreen_X2, int? varFullScreen_Y2)
    {
        TTSecurity.GlobalData gb = new TTSecurity.GlobalData();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        gb.UserID = 1;
        gb.ComputerName = "gg";
        gb.ServidorName = "gg";
        gb.DatabaseName = "rr";
        gb.WindowsVersion = "jk";
        myTTDashBoard_Templates.idTemplate = varidTemplate;
        myTTDashBoard_Templates.Descripcion = varDescripcion;
        myTTDashBoard_Templates.ImageTemplate = varImageTemplate;
        myTTDashBoard_Templates.PosicionX1 = varPosicionX1;
        myTTDashBoard_Templates.PosicionY1 = varPosicionY1;
        myTTDashBoard_Templates.PosicionX2 = varPosicionX2;
        myTTDashBoard_Templates.PosicionY2 = varPosicionY2;
            myTTDashBoard_Templates.Componentes = new TTDashBoard_TemplatesRelacionComponenteCS.objectBussinessTTDashBoard_TemplatesRelacionComponente[varComponentesidTipoComponente.Length];
            for (int i = 0; i < varComponentesidTipoComponente.Length; i++)
            {
                myTTDashBoard_Templates.Componentes[i] = new TTDashBoard_TemplatesRelacionComponenteCS.objectBussinessTTDashBoard_TemplatesRelacionComponente();
                myTTDashBoard_Templates.Componentes[i].idTipoComponente = varComponentesidTipoComponente[i];
                myTTDashBoard_Templates.Componentes[i].PosicionX1 = varComponentesPosicionX1[i];
                myTTDashBoard_Templates.Componentes[i].PosicionY1 = varComponentesPosicionY1[i];
                myTTDashBoard_Templates.Componentes[i].PosicionX2 = varComponentesPosicionX2[i];
                myTTDashBoard_Templates.Componentes[i].PosicionY2 = varComponentesPosicionY2[i];

            }
        myTTDashBoard_Templates.ImageExpanded = varImageExpanded;
        myTTDashBoard_Templates.FullScreen_X1 = varFullScreen_X1;
        myTTDashBoard_Templates.FullScreen_Y1 = varFullScreen_Y1;
        myTTDashBoard_Templates.FullScreen_X2 = varFullScreen_X2;
        myTTDashBoard_Templates.FullScreen_Y2 = varFullScreen_Y2;

        String sMsg = "";
        if (!ValidaDataToSave(myTTDashBoard_Templates, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTDashBoard_Templates, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTDashBoard_Templates.Update(gb, dr);
    }
    [WebMethod]
    public bool Delete(int? Key1)
    {
        TTSecurity.GlobalData gb = new TTSecurity.GlobalData();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        gb.UserID = 1;
        gb.ComputerName = "gg";
        gb.ServidorName = "gg";
        gb.DatabaseName = "rr";
        gb.WindowsVersion = "jk";
        return myTTDashBoard_Templates.Delete(Key1, gb, dr);
    }

    [WebMethod]
    public DataSet GetByKey(int? Key1, Boolean ConRelaciones)
    {
        return myTTDashBoard_Templates.GetByKey(Key1, ConRelaciones);
    }
    [WebMethod]
    public TTDashBoard_TemplatesCS.objectBussinessTTDashBoard_Templates GetByKeyReturnBusiness(int? Key1, Boolean ConRelaciones)
    {
        myTTDashBoard_Templates.GetByKey(Key1, ConRelaciones);
        return myTTDashBoard_Templates;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? Key1)
    {
        return myTTDashBoard_Templates.CurrentPosicion(Key1);
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? Key1)
    {
        return myTTDashBoard_Templates.ValidaExistencia(Key1);
    }

    private bool ValidaDataToSave(TTDashBoard_TemplatesCS.objectBussinessTTDashBoard_Templates MyDataTTDashBoard_Templates, out String sMsg)
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

    public bool ValidaDataDuplication(TTDashBoard_TemplatesCS.objectBussinessTTDashBoard_Templates MyDataTTDashBoard_Templates, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTTDashBoard_Templates.idTemplate == -1)
        {
            if (MyDataTTDashBoard_Templates.ValidaExistencia(MyDataTTDashBoard_Templates.idTemplate))
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
