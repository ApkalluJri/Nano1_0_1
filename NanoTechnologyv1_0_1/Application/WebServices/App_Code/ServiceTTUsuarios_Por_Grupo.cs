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
public class objectBussinessTTUsuarios_Por_Grupo : System.Web.Services.WebService
{
    public int iProcess = 6396;
    private TTTraductor.Traductor MyTraductor;
    public TTUsuarios_Por_GrupoCS.objectBussinessTTUsuarios_Por_Grupo myTTUsuarios_Por_Grupo = new TTUsuarios_Por_GrupoCS.objectBussinessTTUsuarios_Por_Grupo();

    [WebMethod]
    public Int32 SelCount()
    {
        return myTTUsuarios_Por_Grupo.SelCount();
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
        return myTTUsuarios_Por_Grupo.SelAll(ConRelaciones);
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, TTUsuarios_Por_GrupoCS.TTUsuarios_Por_GrupoFilters[] myFilters)
    {
        myTTUsuarios_Por_Grupo.Filters = myFilters;
        return myTTUsuarios_Por_Grupo.SelAll(ConRelaciones);
        myTTUsuarios_Por_Grupo.Filters = null;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTUsuarios_Por_Grupo.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varIdUsuario, int? varIdGrupoUsuario)
    {
        TTUsuarios_Por_GrupoCS.objectBussinessTTUsuarios_Por_Grupo  myTTUsuarios_Por_Grupo= new TTUsuarios_Por_GrupoCS.objectBussinessTTUsuarios_Por_Grupo();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTUsuarios_Por_Grupo.IdUsuario = varIdUsuario;
        myTTUsuarios_Por_Grupo.IdGrupoUsuario = varIdGrupoUsuario;

        String sMsg = "";
        if (!ValidaDataToSave(myTTUsuarios_Por_Grupo, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTUsuarios_Por_Grupo, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTUsuarios_Por_Grupo.Insert(globalInfo, dr);
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, int? varIdUsuario, int? varIdGrupoUsuario)
    {
        TTUsuarios_Por_GrupoCS.objectBussinessTTUsuarios_Por_Grupo  myTTUsuarios_Por_Grupo= new TTUsuarios_Por_GrupoCS.objectBussinessTTUsuarios_Por_Grupo();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTUsuarios_Por_Grupo.IdUsuario = varIdUsuario;
        myTTUsuarios_Por_Grupo.IdGrupoUsuario = varIdGrupoUsuario;

        String sMsg = "";
        if (!ValidaDataToSave(myTTUsuarios_Por_Grupo, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTUsuarios_Por_Grupo, out sMsg))
        {
            throw new Exception(sMsg);
        }
        return myTTUsuarios_Por_Grupo.InsertWithReturnValue(globalInfo, dr);
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varIdUsuario, int? varIdGrupoUsuario)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myTTUsuarios_Por_Grupo.IdUsuario = varIdUsuario;
        myTTUsuarios_Por_Grupo.IdGrupoUsuario = varIdGrupoUsuario;

            String sMsg = "";
            if (!ValidaDataToSave(myTTUsuarios_Por_Grupo, out sMsg))
            {
                throw new Exception(sMsg);
            }
            myTTUsuarios_Por_Grupo.Update(globalInfo, dr);
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyIdUsuario, int? KeyIdGrupoUsuario)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
         return myTTUsuarios_Por_Grupo.Delete(KeyIdUsuario, KeyIdGrupoUsuario, globalInfo, dr);
    }

    [WebMethod]
    public TTUsuarios_Por_GrupoCS.objectBussinessTTUsuarios_Por_Grupo GetByKey(int? KeyIdUsuario, int? KeyIdGrupoUsuario, Boolean ConRelaciones)
    {
        myTTUsuarios_Por_Grupo.GetByKey(KeyIdUsuario, KeyIdGrupoUsuario, ConRelaciones);;
        return myTTUsuarios_Por_Grupo;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyIdUsuario, int? KeyIdGrupoUsuario)
    {
        return myTTUsuarios_Por_Grupo.CurrentPosicion(KeyIdUsuario, KeyIdGrupoUsuario);
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyIdUsuario, int? KeyIdGrupoUsuario)
    {
        return myTTUsuarios_Por_Grupo.ValidaExistencia(KeyIdUsuario, KeyIdGrupoUsuario);
    }

    private bool ValidaDataToSave(TTUsuarios_Por_GrupoCS.objectBussinessTTUsuarios_Por_Grupo MyDataTTUsuarios_Por_Grupo, out String sMsg)
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

    public bool ValidaDataDuplication(TTUsuarios_Por_GrupoCS.objectBussinessTTUsuarios_Por_Grupo MyDataTTUsuarios_Por_Grupo, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTTUsuarios_Por_Grupo.IdUsuario != null&& MyDataTTUsuarios_Por_Grupo.IdGrupoUsuario != null)
        {
            if (MyDataTTUsuarios_Por_Grupo.ValidaExistencia(MyDataTTUsuarios_Por_Grupo.IdUsuario, MyDataTTUsuarios_Por_Grupo.IdGrupoUsuario))
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
    public DataSet FillDataIdUsuario(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTUsuarios_Por_Grupo.FillDataIdUsuario().Copy());
        else
            ds.Tables.Add(myTTUsuarios_Por_Grupo.FillDataIdUsuario(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataIdUsuarioCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTUsuarios_Por_Grupo.FillDataIdUsuario();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["IdUsuario"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }
    [WebMethod]
    public DataSet FillDataIdGrupoUsuario(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTUsuarios_Por_Grupo.FillDataIdGrupoUsuario().Copy());
        else
            ds.Tables.Add(myTTUsuarios_Por_Grupo.FillDataIdGrupoUsuario(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataIdGrupoUsuarioCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTUsuarios_Por_Grupo.FillDataIdGrupoUsuario();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Descripcion"].ToString(), dRow["IdGrupoUsuario"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }

}