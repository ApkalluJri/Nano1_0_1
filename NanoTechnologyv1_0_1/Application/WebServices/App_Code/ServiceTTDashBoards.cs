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
public class objectBussinessTTDashBoards : System.Web.Services.WebService
{
    public int iProcess = 6811;
    private TTTraductor.Traductor MyTraductor;
    public TTDashBoardsCS.objectBussinessTTDashBoards myTTDashBoards = new TTDashBoardsCS.objectBussinessTTDashBoards();

    [WebMethod]
    public Int32 SelCount()
    {
        return myTTDashBoards.SelCount();
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
        return myTTDashBoards.SelAll(ConRelaciones);
    }
    [WebMethod]
    public DataTable SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        return myTTDashBoards.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32);
    }
    [WebMethod]
    public void Insert(String varTitulo, int? varidTemplate, int? varTiempoRefrescar, int?[] varComponentesidComponente, int? varUsuario, int?[] varGrupoUsuario)
    {
        TTDashBoardsCS.objectBussinessTTDashBoards  myTTDashBoards= new TTDashBoardsCS.objectBussinessTTDashBoards();
        TTSecurity.GlobalData gb = new TTSecurity.GlobalData();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("",0);
        gb.UserID = 1;
        gb.ComputerName = "gg";
        gb.ServidorName = "gg";
        gb.DatabaseName = "rr";
        gb.WindowsVersion = "jk";
        gb.Language = TTSecurity.GlobalDataLanguages.Default;
        MyTraductor= new TTTraductor.Traductor(gb.Language.GetHashCode());
        myTTDashBoards.Titulo = varTitulo;
        myTTDashBoards.idTemplate = varidTemplate;
        myTTDashBoards.TiempoRefrescar = varTiempoRefrescar;
            myTTDashBoards.Componentes = new TTDashBoards_RelacionComponentesCS.objectBussinessTTDashBoards_RelacionComponentes[varComponentesidComponente.Length];
            for (int i = 0; i < varComponentesidComponente.Length; i++)
            {
                myTTDashBoards.Componentes[i] = new TTDashBoards_RelacionComponentesCS.objectBussinessTTDashBoards_RelacionComponentes();
                myTTDashBoards.Componentes[i].idComponente = varComponentesidComponente[i];

            }
        myTTDashBoards.Usuario = varUsuario;
        myTTDashBoards.GrupoUsuario =  new TTDashBoards_RelacionGrupoUsuariosCS.objectBussinessTTDashBoards_RelacionGrupoUsuarios[varGrupoUsuario.Length];
        for(int i = 0;i< varGrupoUsuario.Length ;i++)
        {
            myTTDashBoards.GrupoUsuario[i] = new TTDashBoards_RelacionGrupoUsuariosCS.objectBussinessTTDashBoards_RelacionGrupoUsuarios();
            myTTDashBoards.GrupoUsuario[i].idGrupoUsuario = varGrupoUsuario[i];
        }

        String sMsg = "";
        if (!ValidaDataToSave(myTTDashBoards, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTDashBoards, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTDashBoards.Insert(gb, dr);
    }
    [WebMethod]
    public void Update(int? varidDashBorad, String varTitulo, int? varidTemplate, int? varTiempoRefrescar, int?[] varComponentesidComponente, int? varUsuario, int?[] varGrupoUsuario)
    {
        TTSecurity.GlobalData gb = new TTSecurity.GlobalData();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        gb.UserID = 1;
        gb.ComputerName = "gg";
        gb.ServidorName = "gg";
        gb.DatabaseName = "rr";
        gb.WindowsVersion = "jk";
        myTTDashBoards.idDashBorad = varidDashBorad;
        myTTDashBoards.Titulo = varTitulo;
        myTTDashBoards.idTemplate = varidTemplate;
        myTTDashBoards.TiempoRefrescar = varTiempoRefrescar;
            myTTDashBoards.Componentes = new TTDashBoards_RelacionComponentesCS.objectBussinessTTDashBoards_RelacionComponentes[varComponentesidComponente.Length];
            for (int i = 0; i < varComponentesidComponente.Length; i++)
            {
                myTTDashBoards.Componentes[i] = new TTDashBoards_RelacionComponentesCS.objectBussinessTTDashBoards_RelacionComponentes();
                myTTDashBoards.Componentes[i].idComponente = varComponentesidComponente[i];

            }
        myTTDashBoards.Usuario = varUsuario;
        myTTDashBoards.GrupoUsuario =  new TTDashBoards_RelacionGrupoUsuariosCS.objectBussinessTTDashBoards_RelacionGrupoUsuarios[varGrupoUsuario.Length];
        for(int i = 0;i< varGrupoUsuario.Length ;i++)
        {
            myTTDashBoards.GrupoUsuario[i] = new TTDashBoards_RelacionGrupoUsuariosCS.objectBussinessTTDashBoards_RelacionGrupoUsuarios();
            myTTDashBoards.GrupoUsuario[i].idGrupoUsuario = varGrupoUsuario[i];
        }

        String sMsg = "";
        if (!ValidaDataToSave(myTTDashBoards, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTDashBoards, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTDashBoards.Update(gb, dr);
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
        return myTTDashBoards.Delete(Key1, gb, dr);
    }

    [WebMethod]
    public DataSet GetByKey(int? Key1, Boolean ConRelaciones)
    {
        return myTTDashBoards.GetByKey(Key1, ConRelaciones);
    }
    [WebMethod]
    public TTDashBoardsCS.objectBussinessTTDashBoards GetByKeyReturnBusiness(int? Key1, Boolean ConRelaciones)
    {
        myTTDashBoards.GetByKey(Key1, ConRelaciones);
        return myTTDashBoards;
    }

    [WebMethod]
    public Int32 CurrentPosicion(int? Key1)
    {
        return myTTDashBoards.CurrentPosicion(Key1);
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? Key1)
    {
        return myTTDashBoards.ValidaExistencia(Key1);
    }

    private bool ValidaDataToSave(TTDashBoardsCS.objectBussinessTTDashBoards MyDataTTDashBoards, out String sMsg)
    {
        //Validaciones
        sMsg = "";
            if (MyDataTTDashBoards.idTemplate != null)
            {
                TTDashBoard_TemplatesCS.objectBussinessTTDashBoard_Templates MyDataTTDashBoard_TemplatesTemp = new TTDashBoard_TemplatesCS.objectBussinessTTDashBoard_Templates();
                if (!MyDataTTDashBoard_TemplatesTemp.ValidaExistencia(MyDataTTDashBoards.idTemplate))
                {
                    sMsg = sMsg + "El Campo Template no existe\n";
                }
            }
            if (MyDataTTDashBoards.Usuario != null)
            {
                TTUsuariosCS.objectBussinessTTUsuarios MyDataTTUsuariosTemp = new TTUsuariosCS.objectBussinessTTUsuarios();
                if (!MyDataTTUsuariosTemp.ValidaExistencia(MyDataTTDashBoards.Usuario))
                {
                    sMsg = sMsg + "El Campo Usuario no existe\n";
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

    public bool ValidaDataDuplication(TTDashBoardsCS.objectBussinessTTDashBoards MyDataTTDashBoards, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTTDashBoards.idDashBorad == -1)
        {
            if (MyDataTTDashBoards.ValidaExistencia(MyDataTTDashBoards.idDashBorad))
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
