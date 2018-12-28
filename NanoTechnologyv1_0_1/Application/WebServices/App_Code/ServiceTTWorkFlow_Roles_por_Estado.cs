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
public class objectBussinessTTWorkFlow_Roles_por_Estado : System.Web.Services.WebService
{
    public int iProcess = 15812;
    private TTTraductor.Traductor MyTraductor;
    public TTWorkFlow_Roles_por_EstadoCS.objectBussinessTTWorkFlow_Roles_por_Estado myTTWorkFlow_Roles_por_Estado = new TTWorkFlow_Roles_por_EstadoCS.objectBussinessTTWorkFlow_Roles_por_Estado();

    [WebMethod]
    public Int32 SelCount()
    {
        return myTTWorkFlow_Roles_por_Estado.SelCount();
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
        return myTTWorkFlow_Roles_por_Estado.SelAll(ConRelaciones);
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, TTWorkFlow_Roles_por_EstadoCS.TTWorkFlow_Roles_por_EstadoFilters[] myFilters)
    {
        myTTWorkFlow_Roles_por_Estado.Filters = myFilters;
        return myTTWorkFlow_Roles_por_Estado.SelAll(ConRelaciones);
        myTTWorkFlow_Roles_por_Estado.Filters = null;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Roles_por_Estado.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varTTWorkFlow, int? varFase, int? varEstado, int? varRol_de_Usuario, int? varTransicion_de_Fase, int? varPermiso_Consultar, int? varPermiso_Nuevo, int? varPermiso_Modificar, int? varPermiso_Eliminar, int? varPermiso_Exportar, int? varPermiso_Imprimir, int? varPermiso_Configuracion)
    {
        TTWorkFlow_Roles_por_EstadoCS.objectBussinessTTWorkFlow_Roles_por_Estado  myTTWorkFlow_Roles_por_Estado= new TTWorkFlow_Roles_por_EstadoCS.objectBussinessTTWorkFlow_Roles_por_Estado();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTWorkFlow_Roles_por_Estado.TTWorkFlow = varTTWorkFlow;
        myTTWorkFlow_Roles_por_Estado.Fase = varFase;
        myTTWorkFlow_Roles_por_Estado.Estado = varEstado;
        myTTWorkFlow_Roles_por_Estado.Rol_de_Usuario = varRol_de_Usuario;
        myTTWorkFlow_Roles_por_Estado.Transicion_de_Fase = varTransicion_de_Fase;
        myTTWorkFlow_Roles_por_Estado.Permiso_Consultar = varPermiso_Consultar;
        myTTWorkFlow_Roles_por_Estado.Permiso_Nuevo = varPermiso_Nuevo;
        myTTWorkFlow_Roles_por_Estado.Permiso_Modificar = varPermiso_Modificar;
        myTTWorkFlow_Roles_por_Estado.Permiso_Eliminar = varPermiso_Eliminar;
        myTTWorkFlow_Roles_por_Estado.Permiso_Exportar = varPermiso_Exportar;
        myTTWorkFlow_Roles_por_Estado.Permiso_Imprimir = varPermiso_Imprimir;
        myTTWorkFlow_Roles_por_Estado.Permiso_Configuracion = varPermiso_Configuracion;

        String sMsg = "";
        if (!ValidaDataToSave(myTTWorkFlow_Roles_por_Estado, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTWorkFlow_Roles_por_Estado, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTWorkFlow_Roles_por_Estado.Insert(globalInfo, dr);
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, int? varTTWorkFlow, int? varFase, int? varEstado, int? varRol_de_Usuario, int? varTransicion_de_Fase, int? varPermiso_Consultar, int? varPermiso_Nuevo, int? varPermiso_Modificar, int? varPermiso_Eliminar, int? varPermiso_Exportar, int? varPermiso_Imprimir, int? varPermiso_Configuracion)
    {
        TTWorkFlow_Roles_por_EstadoCS.objectBussinessTTWorkFlow_Roles_por_Estado  myTTWorkFlow_Roles_por_Estado= new TTWorkFlow_Roles_por_EstadoCS.objectBussinessTTWorkFlow_Roles_por_Estado();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTWorkFlow_Roles_por_Estado.TTWorkFlow = varTTWorkFlow;
        myTTWorkFlow_Roles_por_Estado.Fase = varFase;
        myTTWorkFlow_Roles_por_Estado.Estado = varEstado;
        myTTWorkFlow_Roles_por_Estado.Rol_de_Usuario = varRol_de_Usuario;
        myTTWorkFlow_Roles_por_Estado.Transicion_de_Fase = varTransicion_de_Fase;
        myTTWorkFlow_Roles_por_Estado.Permiso_Consultar = varPermiso_Consultar;
        myTTWorkFlow_Roles_por_Estado.Permiso_Nuevo = varPermiso_Nuevo;
        myTTWorkFlow_Roles_por_Estado.Permiso_Modificar = varPermiso_Modificar;
        myTTWorkFlow_Roles_por_Estado.Permiso_Eliminar = varPermiso_Eliminar;
        myTTWorkFlow_Roles_por_Estado.Permiso_Exportar = varPermiso_Exportar;
        myTTWorkFlow_Roles_por_Estado.Permiso_Imprimir = varPermiso_Imprimir;
        myTTWorkFlow_Roles_por_Estado.Permiso_Configuracion = varPermiso_Configuracion;

        String sMsg = "";
        if (!ValidaDataToSave(myTTWorkFlow_Roles_por_Estado, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTWorkFlow_Roles_por_Estado, out sMsg))
        {
            throw new Exception(sMsg);
        }
        return myTTWorkFlow_Roles_por_Estado.InsertWithReturnValue(globalInfo, dr);
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varTTWorkFlow, int? varFolio, int? varFase, int? varEstado, int? varRol_de_Usuario, int? varTransicion_de_Fase, int? varPermiso_Consultar, int? varPermiso_Nuevo, int? varPermiso_Modificar, int? varPermiso_Eliminar, int? varPermiso_Exportar, int? varPermiso_Imprimir, int? varPermiso_Configuracion)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myTTWorkFlow_Roles_por_Estado.TTWorkFlow = varTTWorkFlow;
        myTTWorkFlow_Roles_por_Estado.Folio = varFolio;
        myTTWorkFlow_Roles_por_Estado.Fase = varFase;
        myTTWorkFlow_Roles_por_Estado.Estado = varEstado;
        myTTWorkFlow_Roles_por_Estado.Rol_de_Usuario = varRol_de_Usuario;
        myTTWorkFlow_Roles_por_Estado.Transicion_de_Fase = varTransicion_de_Fase;
        myTTWorkFlow_Roles_por_Estado.Permiso_Consultar = varPermiso_Consultar;
        myTTWorkFlow_Roles_por_Estado.Permiso_Nuevo = varPermiso_Nuevo;
        myTTWorkFlow_Roles_por_Estado.Permiso_Modificar = varPermiso_Modificar;
        myTTWorkFlow_Roles_por_Estado.Permiso_Eliminar = varPermiso_Eliminar;
        myTTWorkFlow_Roles_por_Estado.Permiso_Exportar = varPermiso_Exportar;
        myTTWorkFlow_Roles_por_Estado.Permiso_Imprimir = varPermiso_Imprimir;
        myTTWorkFlow_Roles_por_Estado.Permiso_Configuracion = varPermiso_Configuracion;

            String sMsg = "";
            if (!ValidaDataToSave(myTTWorkFlow_Roles_por_Estado, out sMsg))
            {
                throw new Exception(sMsg);
            }
            myTTWorkFlow_Roles_por_Estado.Update(globalInfo, dr);
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyTTWorkFlow, int? KeyFolio)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
         return myTTWorkFlow_Roles_por_Estado.Delete(KeyTTWorkFlow, KeyFolio, globalInfo, dr);
    }

    [WebMethod]
    public TTWorkFlow_Roles_por_EstadoCS.objectBussinessTTWorkFlow_Roles_por_Estado GetByKey(int? KeyTTWorkFlow, int? KeyFolio, Boolean ConRelaciones)
    {
        myTTWorkFlow_Roles_por_Estado.GetByKey(KeyTTWorkFlow, KeyFolio, ConRelaciones);;
        return myTTWorkFlow_Roles_por_Estado;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyTTWorkFlow, int? KeyFolio)
    {
        return myTTWorkFlow_Roles_por_Estado.CurrentPosicion(KeyTTWorkFlow, KeyFolio);
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyTTWorkFlow, int? KeyFolio)
    {
        return myTTWorkFlow_Roles_por_Estado.ValidaExistencia(KeyTTWorkFlow, KeyFolio);
    }

    private bool ValidaDataToSave(TTWorkFlow_Roles_por_EstadoCS.objectBussinessTTWorkFlow_Roles_por_Estado MyDataTTWorkFlow_Roles_por_Estado, out String sMsg)
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

    public bool ValidaDataDuplication(TTWorkFlow_Roles_por_EstadoCS.objectBussinessTTWorkFlow_Roles_por_Estado MyDataTTWorkFlow_Roles_por_Estado, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTTWorkFlow_Roles_por_Estado.TTWorkFlow != null&& MyDataTTWorkFlow_Roles_por_Estado.Folio == -1)
        {
            if (MyDataTTWorkFlow_Roles_por_Estado.ValidaExistencia(MyDataTTWorkFlow_Roles_por_Estado.TTWorkFlow, MyDataTTWorkFlow_Roles_por_Estado.Folio))
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
    public DataSet FillDataTTWorkFlowwithParent(int Key)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Roles_por_Estado.FillDataTTWorkFlow(Key).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet FillDataTTWorkFlow()
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Roles_por_Estado.FillDataTTWorkFlow().Copy());
        return ds;
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataTTWorkFlowCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Roles_por_Estado.FillDataTTWorkFlow();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["Folio"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataTTWorkFlowwithParentCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);

        int value;
        if (!kv.ContainsKey("Estado") || !Int32.TryParse(kv["Estado"], out value))
            return null;

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Roles_por_Estado.FillDataTTWorkFlow(value);

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["Folio"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }
    [WebMethod]
    public DataSet FillDataFasewithParent(int Key)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Roles_por_Estado.FillDataFase(Key).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet FillDataFase()
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Roles_por_Estado.FillDataFase().Copy());
        return ds;
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataFaseCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Roles_por_Estado.FillDataFase();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["Numero_de_Fase"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataFasewithParentCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);

        int value;
        if (!kv.ContainsKey("TTWorkFlow") || !Int32.TryParse(kv["TTWorkFlow"], out value))
            return null;

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Roles_por_Estado.FillDataFase(value);

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["Numero_de_Fase"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }
    [WebMethod]
    public DataSet FillDataEstadowithParent(int Key)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Roles_por_Estado.FillDataEstado(Key).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet FillDataEstado()
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Roles_por_Estado.FillDataEstado().Copy());
        return ds;
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataEstadoCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Roles_por_Estado.FillDataEstado();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["Codigo_Estado"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataEstadowithParentCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);

        int value;
        if (!kv.ContainsKey("Fase") || !Int32.TryParse(kv["Fase"], out value))
            return null;

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Roles_por_Estado.FillDataEstado(value);

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["Codigo_Estado"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }
    [WebMethod]
    public DataSet FillDataRol_de_Usuario(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTWorkFlow_Roles_por_Estado.FillDataRol_de_Usuario().Copy());
        else
            ds.Tables.Add(myTTWorkFlow_Roles_por_Estado.FillDataRol_de_Usuario(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataRol_de_UsuarioCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Roles_por_Estado.FillDataRol_de_Usuario();

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
    public DataSet FillDataTransicion_de_Fase(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTWorkFlow_Roles_por_Estado.FillDataTransicion_de_Fase().Copy());
        else
            ds.Tables.Add(myTTWorkFlow_Roles_por_Estado.FillDataTransicion_de_Fase(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataTransicion_de_FaseCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Roles_por_Estado.FillDataTransicion_de_Fase();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["Clave"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }
    [WebMethod]
    public DataSet FillDataPermiso_Consultar(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTWorkFlow_Roles_por_Estado.FillDataPermiso_Consultar().Copy());
        else
            ds.Tables.Add(myTTWorkFlow_Roles_por_Estado.FillDataPermiso_Consultar(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataPermiso_ConsultarCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Roles_por_Estado.FillDataPermiso_Consultar();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Descripcion"].ToString(), dRow["Clave"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }
    [WebMethod]
    public DataSet FillDataPermiso_Nuevo(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTWorkFlow_Roles_por_Estado.FillDataPermiso_Nuevo().Copy());
        else
            ds.Tables.Add(myTTWorkFlow_Roles_por_Estado.FillDataPermiso_Nuevo(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataPermiso_NuevoCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Roles_por_Estado.FillDataPermiso_Nuevo();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Descripcion"].ToString(), dRow["Clave"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }
    [WebMethod]
    public DataSet FillDataPermiso_Modificar(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTWorkFlow_Roles_por_Estado.FillDataPermiso_Modificar().Copy());
        else
            ds.Tables.Add(myTTWorkFlow_Roles_por_Estado.FillDataPermiso_Modificar(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataPermiso_ModificarCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Roles_por_Estado.FillDataPermiso_Modificar();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Descripcion"].ToString(), dRow["Clave"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }
    [WebMethod]
    public DataSet FillDataPermiso_Eliminar(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTWorkFlow_Roles_por_Estado.FillDataPermiso_Eliminar().Copy());
        else
            ds.Tables.Add(myTTWorkFlow_Roles_por_Estado.FillDataPermiso_Eliminar(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataPermiso_EliminarCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Roles_por_Estado.FillDataPermiso_Eliminar();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Descripcion"].ToString(), dRow["Clave"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }
    [WebMethod]
    public DataSet FillDataPermiso_Exportar(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTWorkFlow_Roles_por_Estado.FillDataPermiso_Exportar().Copy());
        else
            ds.Tables.Add(myTTWorkFlow_Roles_por_Estado.FillDataPermiso_Exportar(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataPermiso_ExportarCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Roles_por_Estado.FillDataPermiso_Exportar();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Descripcion"].ToString(), dRow["Clave"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }
    [WebMethod]
    public DataSet FillDataPermiso_Imprimir(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTWorkFlow_Roles_por_Estado.FillDataPermiso_Imprimir().Copy());
        else
            ds.Tables.Add(myTTWorkFlow_Roles_por_Estado.FillDataPermiso_Imprimir(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataPermiso_ImprimirCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Roles_por_Estado.FillDataPermiso_Imprimir();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Descripcion"].ToString(), dRow["Clave"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }
    [WebMethod]
    public DataSet FillDataPermiso_Configuracion(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTWorkFlow_Roles_por_Estado.FillDataPermiso_Configuracion().Copy());
        else
            ds.Tables.Add(myTTWorkFlow_Roles_por_Estado.FillDataPermiso_Configuracion(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataPermiso_ConfiguracionCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Roles_por_Estado.FillDataPermiso_Configuracion();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Descripcion"].ToString(), dRow["Clave"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }

}