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
public class objectBussinessTTPermisos_por_proceso : System.Web.Services.WebService
{
    public int iProcess = 6398;
    private TTTraductor.Traductor MyTraductor;
    public TTPermisos_por_procesoCS.objectBussinessTTPermisos_por_proceso myTTPermisos_por_proceso = new TTPermisos_por_procesoCS.objectBussinessTTPermisos_por_proceso();

    [WebMethod]
    public Int32 SelCount()
    {
        return myTTPermisos_por_proceso.SelCount();
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
        return myTTPermisos_por_proceso.SelAll(ConRelaciones);
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, TTPermisos_por_procesoCS.TTPermisos_por_procesoFilters[] myFilters)
    {
        myTTPermisos_por_proceso.Filters = myFilters;
        return myTTPermisos_por_proceso.SelAll(ConRelaciones);
        myTTPermisos_por_proceso.Filters = null;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTPermisos_por_proceso.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varIdGrupoUsuario, int? varIdProceso, int? varIdOperacion, int? varidModulo)
    {
        TTPermisos_por_procesoCS.objectBussinessTTPermisos_por_proceso  myTTPermisos_por_proceso= new TTPermisos_por_procesoCS.objectBussinessTTPermisos_por_proceso();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTPermisos_por_proceso.IdGrupoUsuario = varIdGrupoUsuario;
        myTTPermisos_por_proceso.IdProceso = varIdProceso;
        myTTPermisos_por_proceso.IdOperacion = varIdOperacion;
        myTTPermisos_por_proceso.idModulo = varidModulo;

        String sMsg = "";
        if (!ValidaDataToSave(myTTPermisos_por_proceso, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTPermisos_por_proceso, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTPermisos_por_proceso.Insert(globalInfo, dr);
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, int? varIdGrupoUsuario, int? varIdProceso, int? varIdOperacion, int? varidModulo)
    {
        TTPermisos_por_procesoCS.objectBussinessTTPermisos_por_proceso  myTTPermisos_por_proceso= new TTPermisos_por_procesoCS.objectBussinessTTPermisos_por_proceso();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTPermisos_por_proceso.IdGrupoUsuario = varIdGrupoUsuario;
        myTTPermisos_por_proceso.IdProceso = varIdProceso;
        myTTPermisos_por_proceso.IdOperacion = varIdOperacion;
        myTTPermisos_por_proceso.idModulo = varidModulo;

        String sMsg = "";
        if (!ValidaDataToSave(myTTPermisos_por_proceso, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTPermisos_por_proceso, out sMsg))
        {
            throw new Exception(sMsg);
        }
        return myTTPermisos_por_proceso.InsertWithReturnValue(globalInfo, dr);
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varIdGrupoUsuario, int? varIdProceso, int? varIdOperacion, int? varidModulo)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myTTPermisos_por_proceso.IdGrupoUsuario = varIdGrupoUsuario;
        myTTPermisos_por_proceso.IdProceso = varIdProceso;
        myTTPermisos_por_proceso.IdOperacion = varIdOperacion;
        myTTPermisos_por_proceso.idModulo = varidModulo;

            String sMsg = "";
            if (!ValidaDataToSave(myTTPermisos_por_proceso, out sMsg))
            {
                throw new Exception(sMsg);
            }
            myTTPermisos_por_proceso.Update(globalInfo, dr);
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyIdGrupoUsuario, int? KeyIdProceso, int? KeyIdOperacion, int? KeyidModulo)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
         return myTTPermisos_por_proceso.Delete(KeyIdGrupoUsuario, KeyIdProceso, KeyIdOperacion, KeyidModulo, globalInfo, dr);
    }

    [WebMethod]
    public TTPermisos_por_procesoCS.objectBussinessTTPermisos_por_proceso GetByKey(int? KeyIdGrupoUsuario, int? KeyIdProceso, int? KeyIdOperacion, int? KeyidModulo, Boolean ConRelaciones)
    {
        myTTPermisos_por_proceso.GetByKey(KeyIdGrupoUsuario, KeyIdProceso, KeyIdOperacion, KeyidModulo, ConRelaciones);;
        return myTTPermisos_por_proceso;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyIdGrupoUsuario, int? KeyIdProceso, int? KeyIdOperacion, int? KeyidModulo)
    {
        return myTTPermisos_por_proceso.CurrentPosicion(KeyIdGrupoUsuario, KeyIdProceso, KeyIdOperacion, KeyidModulo);
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyIdGrupoUsuario, int? KeyIdProceso, int? KeyIdOperacion, int? KeyidModulo)
    {
        return myTTPermisos_por_proceso.ValidaExistencia(KeyIdGrupoUsuario, KeyIdProceso, KeyIdOperacion, KeyidModulo);
    }

    private bool ValidaDataToSave(TTPermisos_por_procesoCS.objectBussinessTTPermisos_por_proceso MyDataTTPermisos_por_proceso, out String sMsg)
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

    public bool ValidaDataDuplication(TTPermisos_por_procesoCS.objectBussinessTTPermisos_por_proceso MyDataTTPermisos_por_proceso, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTTPermisos_por_proceso.IdGrupoUsuario != null&& MyDataTTPermisos_por_proceso.IdProceso != null&& MyDataTTPermisos_por_proceso.IdOperacion != null&& MyDataTTPermisos_por_proceso.idModulo != null)
        {
            if (MyDataTTPermisos_por_proceso.ValidaExistencia(MyDataTTPermisos_por_proceso.IdGrupoUsuario, MyDataTTPermisos_por_proceso.IdProceso, MyDataTTPermisos_por_proceso.IdOperacion, MyDataTTPermisos_por_proceso.idModulo))
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
            ds.Tables.Add(myTTPermisos_por_proceso.FillDataIdGrupoUsuario().Copy());
        else
            ds.Tables.Add(myTTPermisos_por_proceso.FillDataIdGrupoUsuario(sFiltro).Copy());
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
            dt = myTTPermisos_por_proceso.FillDataIdGrupoUsuario();

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
    public DataSet FillDataIdProceso(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTPermisos_por_proceso.FillDataIdProceso().Copy());
        else
            ds.Tables.Add(myTTPermisos_por_proceso.FillDataIdProceso(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataIdProcesoCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTPermisos_por_proceso.FillDataIdProceso();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["IdProceso"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }
    [WebMethod]
    public DataSet FillDataIdOperacion(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTPermisos_por_proceso.FillDataIdOperacion().Copy());
        else
            ds.Tables.Add(myTTPermisos_por_proceso.FillDataIdOperacion(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataIdOperacionCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTPermisos_por_proceso.FillDataIdOperacion();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Descripcion"].ToString(), dRow["IdOperacion"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }
    [WebMethod]
    public DataSet FillDataidModulo(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTPermisos_por_proceso.FillDataidModulo().Copy());
        else
            ds.Tables.Add(myTTPermisos_por_proceso.FillDataidModulo(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataidModuloCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTPermisos_por_proceso.FillDataidModulo();

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