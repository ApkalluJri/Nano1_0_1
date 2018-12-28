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
public class objectBussinessTTPermisos_por_modulo : System.Web.Services.WebService
{
    public int iProcess = 6397;
    private TTTraductor.Traductor MyTraductor;
    public TTPermisos_por_moduloCS.objectBussinessTTPermisos_por_modulo myTTPermisos_por_modulo = new TTPermisos_por_moduloCS.objectBussinessTTPermisos_por_modulo();

    [WebMethod]
    public Int32 SelCount()
    {
        return myTTPermisos_por_modulo.SelCount();
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
        return myTTPermisos_por_modulo.SelAll(ConRelaciones);
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, TTPermisos_por_moduloCS.TTPermisos_por_moduloFilters[] myFilters)
    {
        myTTPermisos_por_modulo.Filters = myFilters;
        return myTTPermisos_por_modulo.SelAll(ConRelaciones);
        myTTPermisos_por_modulo.Filters = null;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTPermisos_por_modulo.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varIdGrupoUsuario, int? varIdModulo)
    {
        TTPermisos_por_moduloCS.objectBussinessTTPermisos_por_modulo  myTTPermisos_por_modulo= new TTPermisos_por_moduloCS.objectBussinessTTPermisos_por_modulo();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTPermisos_por_modulo.IdGrupoUsuario = varIdGrupoUsuario;
        myTTPermisos_por_modulo.IdModulo = varIdModulo;

        String sMsg = "";
        if (!ValidaDataToSave(myTTPermisos_por_modulo, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTPermisos_por_modulo, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTPermisos_por_modulo.Insert(globalInfo, dr);
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, int? varIdGrupoUsuario, int? varIdModulo)
    {
        TTPermisos_por_moduloCS.objectBussinessTTPermisos_por_modulo  myTTPermisos_por_modulo= new TTPermisos_por_moduloCS.objectBussinessTTPermisos_por_modulo();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTPermisos_por_modulo.IdGrupoUsuario = varIdGrupoUsuario;
        myTTPermisos_por_modulo.IdModulo = varIdModulo;

        String sMsg = "";
        if (!ValidaDataToSave(myTTPermisos_por_modulo, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTPermisos_por_modulo, out sMsg))
        {
            throw new Exception(sMsg);
        }
        return myTTPermisos_por_modulo.InsertWithReturnValue(globalInfo, dr);
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varIdGrupoUsuario, int? varIdModulo)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myTTPermisos_por_modulo.IdGrupoUsuario = varIdGrupoUsuario;
        myTTPermisos_por_modulo.IdModulo = varIdModulo;

            String sMsg = "";
            if (!ValidaDataToSave(myTTPermisos_por_modulo, out sMsg))
            {
                throw new Exception(sMsg);
            }
            myTTPermisos_por_modulo.Update(globalInfo, dr);
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyIdGrupoUsuario, int? KeyIdModulo)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
         return myTTPermisos_por_modulo.Delete(KeyIdGrupoUsuario, KeyIdModulo, globalInfo, dr);
    }

    [WebMethod]
    public TTPermisos_por_moduloCS.objectBussinessTTPermisos_por_modulo GetByKey(int? KeyIdGrupoUsuario, int? KeyIdModulo, Boolean ConRelaciones)
    {
        myTTPermisos_por_modulo.GetByKey(KeyIdGrupoUsuario, KeyIdModulo, ConRelaciones);;
        return myTTPermisos_por_modulo;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyIdGrupoUsuario, int? KeyIdModulo)
    {
        return myTTPermisos_por_modulo.CurrentPosicion(KeyIdGrupoUsuario, KeyIdModulo);
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyIdGrupoUsuario, int? KeyIdModulo)
    {
        return myTTPermisos_por_modulo.ValidaExistencia(KeyIdGrupoUsuario, KeyIdModulo);
    }

    private bool ValidaDataToSave(TTPermisos_por_moduloCS.objectBussinessTTPermisos_por_modulo MyDataTTPermisos_por_modulo, out String sMsg)
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

    public bool ValidaDataDuplication(TTPermisos_por_moduloCS.objectBussinessTTPermisos_por_modulo MyDataTTPermisos_por_modulo, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTTPermisos_por_modulo.IdGrupoUsuario != null&& MyDataTTPermisos_por_modulo.IdModulo != null)
        {
            if (MyDataTTPermisos_por_modulo.ValidaExistencia(MyDataTTPermisos_por_modulo.IdGrupoUsuario, MyDataTTPermisos_por_modulo.IdModulo))
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
    public DataSet FillDataIdGrupoUsuario(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTPermisos_por_modulo.FillDataIdGrupoUsuario().Copy());
        else
            ds.Tables.Add(myTTPermisos_por_modulo.FillDataIdGrupoUsuario(sFiltro).Copy());
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
            dt = myTTPermisos_por_modulo.FillDataIdGrupoUsuario();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Descripcion"].ToString(), dRow["IdGrupoUsuario"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }
    [WebMethod]
    public DataSet FillDataIdModulo(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTPermisos_por_modulo.FillDataIdModulo().Copy());
        else
            ds.Tables.Add(myTTPermisos_por_modulo.FillDataIdModulo(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataIdModuloCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTPermisos_por_modulo.FillDataIdModulo();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["IdModulo"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }

}