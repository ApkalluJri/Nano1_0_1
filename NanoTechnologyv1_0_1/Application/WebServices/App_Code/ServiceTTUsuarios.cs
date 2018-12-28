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
public class objectBussinessTTUsuarios : System.Web.Services.WebService
{
    public int iProcess = 6395;
    private TTTraductor.Traductor MyTraductor;
    public TTUsuariosCS.objectBussinessTTUsuarios myTTUsuarios = new TTUsuariosCS.objectBussinessTTUsuarios();

    [WebMethod]
    public Int32 SelCount()
    {
        return myTTUsuarios.SelCount();
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
        return myTTUsuarios.SelAll(ConRelaciones);
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, TTUsuariosCS.TTUsuariosFilters[] myFilters)
    {
        myTTUsuarios.Filters = myFilters;
        return myTTUsuarios.SelAll(ConRelaciones);
        myTTUsuarios.Filters = null;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTUsuarios.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, String varNombre, String varClave_de_Acceso, String varContrasena, Boolean varActivo, int? varidGrupoUsuarios)
    {
        TTUsuariosCS.objectBussinessTTUsuarios  myTTUsuarios= new TTUsuariosCS.objectBussinessTTUsuarios();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTUsuarios.Nombre = varNombre;
        myTTUsuarios.Clave_de_Acceso = varClave_de_Acceso;
        myTTUsuarios.Contrasena = varContrasena;
        myTTUsuarios.Activo = varActivo;
        myTTUsuarios.idGrupoUsuarios = varidGrupoUsuarios;

        String sMsg = "";
        if (!ValidaDataToSave(myTTUsuarios, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTUsuarios, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTUsuarios.Insert(globalInfo, dr);
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, String varNombre, String varClave_de_Acceso, String varContrasena, Boolean varActivo, int? varidGrupoUsuarios)
    {
        TTUsuariosCS.objectBussinessTTUsuarios  myTTUsuarios= new TTUsuariosCS.objectBussinessTTUsuarios();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTUsuarios.Nombre = varNombre;
        myTTUsuarios.Clave_de_Acceso = varClave_de_Acceso;
        myTTUsuarios.Contrasena = varContrasena;
        myTTUsuarios.Activo = varActivo;
        myTTUsuarios.idGrupoUsuarios = varidGrupoUsuarios;

        String sMsg = "";
        if (!ValidaDataToSave(myTTUsuarios, out sMsg))
        {
            //throw new Exception(sMsg);
            return sMsg;
        }
        if (!ValidaDataDuplication(myTTUsuarios, out sMsg))
        {
            //throw new Exception(sMsg);
            return sMsg;
        }
        return myTTUsuarios.InsertWithReturnValue(globalInfo, dr);
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varIdUsuario, String varNombre, String varClave_de_Acceso, String varContrasena, Boolean varActivo, int? varidGrupoUsuarios)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myTTUsuarios.IdUsuario = varIdUsuario;
        myTTUsuarios.Nombre = varNombre;
        myTTUsuarios.Clave_de_Acceso = varClave_de_Acceso;
        myTTUsuarios.Contrasena = varContrasena;
        myTTUsuarios.Activo = varActivo;
        myTTUsuarios.idGrupoUsuarios = varidGrupoUsuarios;

            String sMsg = "";
            if (!ValidaDataToSave(myTTUsuarios, out sMsg))
            {
                throw new Exception(sMsg);
            }
            myTTUsuarios.Update(globalInfo, dr);
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyIdUsuario)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
         return myTTUsuarios.Delete(KeyIdUsuario, globalInfo, dr);
    }

    [WebMethod]
    public TTUsuariosCS.objectBussinessTTUsuarios GetByKey(int? KeyIdUsuario, Boolean ConRelaciones)
    {
        myTTUsuarios.GetByKey(KeyIdUsuario, ConRelaciones);;
        return myTTUsuarios;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyIdUsuario)
    {
        return myTTUsuarios.CurrentPosicion(KeyIdUsuario);
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyIdUsuario)
    {
        return myTTUsuarios.ValidaExistencia(KeyIdUsuario);
    }

    private bool ValidaDataToSave(TTUsuariosCS.objectBussinessTTUsuarios MyDataTTUsuarios, out String sMsg)
    {
        //Validaciones
        sMsg = "";
        if ((MyDataTTUsuarios.IdUsuario == null && myTTUsuarios.GetByKeyClave_de_Acceso(MyDataTTUsuarios.Clave_de_Acceso).Tables[0].Rows.Count > 0))
            sMsg = "La clavee de acceso ya existe";

        if (sMsg != "")
        {
            //sMsg = MyTraductor.getMessage(15) + "\n" + sMsg + "\n" + MyTraductor.getMessage(7);
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool ValidaDataDuplication(TTUsuariosCS.objectBussinessTTUsuarios MyDataTTUsuarios, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTTUsuarios.IdUsuario != null)
        {
            if (MyDataTTUsuarios.ValidaExistencia(MyDataTTUsuarios.IdUsuario))
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
    public DataSet FillDataidGrupoUsuarios(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTUsuarios.FillDataidGrupoUsuarios().Copy());
        else
            ds.Tables.Add(myTTUsuarios.FillDataidGrupoUsuarios(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataidGrupoUsuariosCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTUsuarios.FillDataidGrupoUsuarios();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["IdUsuario"].ToString(), dRow["IdUsuario"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }

}