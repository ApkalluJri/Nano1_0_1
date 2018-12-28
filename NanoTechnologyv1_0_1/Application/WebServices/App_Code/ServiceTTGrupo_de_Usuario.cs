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
public class objectBussinessTTGrupo_de_Usuario : System.Web.Services.WebService
{
    public int iProcess = 6394;
    private TTTraductor.Traductor MyTraductor;
    public TTGrupo_de_UsuarioCS.objectBussinessTTGrupo_de_Usuario myTTGrupo_de_Usuario = new TTGrupo_de_UsuarioCS.objectBussinessTTGrupo_de_Usuario();

    [WebMethod]
    public Int32 SelCount()
    {
        return myTTGrupo_de_Usuario.SelCount();
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
        return myTTGrupo_de_Usuario.SelAll(ConRelaciones);
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, TTGrupo_de_UsuarioCS.TTGrupo_de_UsuarioFilters[] myFilters)
    {
        myTTGrupo_de_Usuario.Filters = myFilters;
        return myTTGrupo_de_Usuario.SelAll(ConRelaciones);
        myTTGrupo_de_Usuario.Filters = null;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTGrupo_de_Usuario.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varIdGrupoUsuario, String varDescripcion, Boolean varActivo)
    {
        TTGrupo_de_UsuarioCS.objectBussinessTTGrupo_de_Usuario  myTTGrupo_de_Usuario= new TTGrupo_de_UsuarioCS.objectBussinessTTGrupo_de_Usuario();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTGrupo_de_Usuario.IdGrupoUsuario = varIdGrupoUsuario;
        myTTGrupo_de_Usuario.Descripcion = varDescripcion;
        myTTGrupo_de_Usuario.Activo = varActivo;

        String sMsg = "";
        if (!ValidaDataToSave(myTTGrupo_de_Usuario, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTGrupo_de_Usuario, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTGrupo_de_Usuario.Insert(globalInfo, dr);
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, int? varIdGrupoUsuario, String varDescripcion, Boolean varActivo)
    {
        TTGrupo_de_UsuarioCS.objectBussinessTTGrupo_de_Usuario  myTTGrupo_de_Usuario= new TTGrupo_de_UsuarioCS.objectBussinessTTGrupo_de_Usuario();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTGrupo_de_Usuario.IdGrupoUsuario = varIdGrupoUsuario;
        myTTGrupo_de_Usuario.Descripcion = varDescripcion;
        myTTGrupo_de_Usuario.Activo = varActivo;

        String sMsg = "";
        if (!ValidaDataToSave(myTTGrupo_de_Usuario, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTGrupo_de_Usuario, out sMsg))
        {
            throw new Exception(sMsg);
        }
        return myTTGrupo_de_Usuario.InsertWithReturnValue(globalInfo, dr);
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varIdGrupoUsuario, String varDescripcion, Boolean varActivo)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myTTGrupo_de_Usuario.IdGrupoUsuario = varIdGrupoUsuario;
        myTTGrupo_de_Usuario.Descripcion = varDescripcion;
        myTTGrupo_de_Usuario.Activo = varActivo;

            String sMsg = "";
            if (!ValidaDataToSave(myTTGrupo_de_Usuario, out sMsg))
            {
                throw new Exception(sMsg);
            }
            myTTGrupo_de_Usuario.Update(globalInfo, dr);
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyIdGrupoUsuario)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
         return myTTGrupo_de_Usuario.Delete(KeyIdGrupoUsuario, globalInfo, dr);
    }

    [WebMethod]
    public TTGrupo_de_UsuarioCS.objectBussinessTTGrupo_de_Usuario GetByKey(int? KeyIdGrupoUsuario, Boolean ConRelaciones)
    {
        myTTGrupo_de_Usuario.GetByKey(KeyIdGrupoUsuario, ConRelaciones);;
        return myTTGrupo_de_Usuario;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyIdGrupoUsuario)
    {
        return myTTGrupo_de_Usuario.CurrentPosicion(KeyIdGrupoUsuario);
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyIdGrupoUsuario)
    {
        return myTTGrupo_de_Usuario.ValidaExistencia(KeyIdGrupoUsuario);
    }

    private bool ValidaDataToSave(TTGrupo_de_UsuarioCS.objectBussinessTTGrupo_de_Usuario MyDataTTGrupo_de_Usuario, out String sMsg)
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

    public bool ValidaDataDuplication(TTGrupo_de_UsuarioCS.objectBussinessTTGrupo_de_Usuario MyDataTTGrupo_de_Usuario, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTTGrupo_de_Usuario.IdGrupoUsuario != null)
        {
            if (MyDataTTGrupo_de_Usuario.ValidaExistencia(MyDataTTGrupo_de_Usuario.IdGrupoUsuario))
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