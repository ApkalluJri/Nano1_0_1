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
public class objectBussinessTTWorkFlow_Condiciones_por_Estado : System.Web.Services.WebService
{
    public int iProcess = 15815;
    private TTTraductor.Traductor MyTraductor;
    public TTWorkFlow_Condiciones_por_EstadoCS.objectBussinessTTWorkFlow_Condiciones_por_Estado myTTWorkFlow_Condiciones_por_Estado = new TTWorkFlow_Condiciones_por_EstadoCS.objectBussinessTTWorkFlow_Condiciones_por_Estado();

    [WebMethod]
    public Int32 SelCount()
    {
        return myTTWorkFlow_Condiciones_por_Estado.SelCount();
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
        return myTTWorkFlow_Condiciones_por_Estado.SelAll(ConRelaciones);
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, TTWorkFlow_Condiciones_por_EstadoCS.TTWorkFlow_Condiciones_por_EstadoFilters[] myFilters)
    {
        myTTWorkFlow_Condiciones_por_Estado.Filters = myFilters;
        return myTTWorkFlow_Condiciones_por_Estado.SelAll(ConRelaciones);
        myTTWorkFlow_Condiciones_por_Estado.Filters = null;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Condiciones_por_Estado.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varTTWorkFlow, int? varFase, int? varEstado, int? varOperador_de_Condicion, int? varProceso, int? varCampo, int? varCondicion, int? varOperador, String varValor_Operador, int? varPrioridad)
    {
        TTWorkFlow_Condiciones_por_EstadoCS.objectBussinessTTWorkFlow_Condiciones_por_Estado  myTTWorkFlow_Condiciones_por_Estado= new TTWorkFlow_Condiciones_por_EstadoCS.objectBussinessTTWorkFlow_Condiciones_por_Estado();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTWorkFlow_Condiciones_por_Estado.TTWorkFlow = varTTWorkFlow;
        myTTWorkFlow_Condiciones_por_Estado.Fase = varFase;
        myTTWorkFlow_Condiciones_por_Estado.Estado = varEstado;
        myTTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion = varOperador_de_Condicion;
        myTTWorkFlow_Condiciones_por_Estado.Proceso = varProceso;
        myTTWorkFlow_Condiciones_por_Estado.Campo = varCampo;
        myTTWorkFlow_Condiciones_por_Estado.Condicion = varCondicion;
        myTTWorkFlow_Condiciones_por_Estado.Operador = varOperador;
        myTTWorkFlow_Condiciones_por_Estado.Valor_Operador = varValor_Operador;
        myTTWorkFlow_Condiciones_por_Estado.Prioridad = varPrioridad;

        String sMsg = "";
        if (!ValidaDataToSave(myTTWorkFlow_Condiciones_por_Estado, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTWorkFlow_Condiciones_por_Estado, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTWorkFlow_Condiciones_por_Estado.Insert(globalInfo, dr);
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, int? varTTWorkFlow, int? varFase, int? varEstado, int? varOperador_de_Condicion, int? varProceso, int? varCampo, int? varCondicion, int? varOperador, String varValor_Operador, int? varPrioridad)
    {
        TTWorkFlow_Condiciones_por_EstadoCS.objectBussinessTTWorkFlow_Condiciones_por_Estado  myTTWorkFlow_Condiciones_por_Estado= new TTWorkFlow_Condiciones_por_EstadoCS.objectBussinessTTWorkFlow_Condiciones_por_Estado();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTWorkFlow_Condiciones_por_Estado.TTWorkFlow = varTTWorkFlow;
        myTTWorkFlow_Condiciones_por_Estado.Fase = varFase;
        myTTWorkFlow_Condiciones_por_Estado.Estado = varEstado;
        myTTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion = varOperador_de_Condicion;
        myTTWorkFlow_Condiciones_por_Estado.Proceso = varProceso;
        myTTWorkFlow_Condiciones_por_Estado.Campo = varCampo;
        myTTWorkFlow_Condiciones_por_Estado.Condicion = varCondicion;
        myTTWorkFlow_Condiciones_por_Estado.Operador = varOperador;
        myTTWorkFlow_Condiciones_por_Estado.Valor_Operador = varValor_Operador;
        myTTWorkFlow_Condiciones_por_Estado.Prioridad = varPrioridad;

        String sMsg = "";
        if (!ValidaDataToSave(myTTWorkFlow_Condiciones_por_Estado, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTWorkFlow_Condiciones_por_Estado, out sMsg))
        {
            throw new Exception(sMsg);
        }
        return myTTWorkFlow_Condiciones_por_Estado.InsertWithReturnValue(globalInfo, dr);
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varTTWorkFlow, int? varFolio, int? varFase, int? varEstado, int? varOperador_de_Condicion, int? varProceso, int? varCampo, int? varCondicion, int? varOperador, String varValor_Operador, int? varPrioridad)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myTTWorkFlow_Condiciones_por_Estado.TTWorkFlow = varTTWorkFlow;
        myTTWorkFlow_Condiciones_por_Estado.Folio = varFolio;
        myTTWorkFlow_Condiciones_por_Estado.Fase = varFase;
        myTTWorkFlow_Condiciones_por_Estado.Estado = varEstado;
        myTTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion = varOperador_de_Condicion;
        myTTWorkFlow_Condiciones_por_Estado.Proceso = varProceso;
        myTTWorkFlow_Condiciones_por_Estado.Campo = varCampo;
        myTTWorkFlow_Condiciones_por_Estado.Condicion = varCondicion;
        myTTWorkFlow_Condiciones_por_Estado.Operador = varOperador;
        myTTWorkFlow_Condiciones_por_Estado.Valor_Operador = varValor_Operador;
        myTTWorkFlow_Condiciones_por_Estado.Prioridad = varPrioridad;

            String sMsg = "";
            if (!ValidaDataToSave(myTTWorkFlow_Condiciones_por_Estado, out sMsg))
            {
                throw new Exception(sMsg);
            }
            myTTWorkFlow_Condiciones_por_Estado.Update(globalInfo, dr);
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyTTWorkFlow, int? KeyFolio)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
         return myTTWorkFlow_Condiciones_por_Estado.Delete(KeyTTWorkFlow, KeyFolio, globalInfo, dr);
    }

    [WebMethod]
    public TTWorkFlow_Condiciones_por_EstadoCS.objectBussinessTTWorkFlow_Condiciones_por_Estado GetByKey(int? KeyTTWorkFlow, int? KeyFolio, Boolean ConRelaciones)
    {
        myTTWorkFlow_Condiciones_por_Estado.GetByKey(KeyTTWorkFlow, KeyFolio, ConRelaciones);;
        return myTTWorkFlow_Condiciones_por_Estado;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyTTWorkFlow, int? KeyFolio)
    {
        return myTTWorkFlow_Condiciones_por_Estado.CurrentPosicion(KeyTTWorkFlow, KeyFolio);
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyTTWorkFlow, int? KeyFolio)
    {
        return myTTWorkFlow_Condiciones_por_Estado.ValidaExistencia(KeyTTWorkFlow, KeyFolio);
    }

    private bool ValidaDataToSave(TTWorkFlow_Condiciones_por_EstadoCS.objectBussinessTTWorkFlow_Condiciones_por_Estado MyDataTTWorkFlow_Condiciones_por_Estado, out String sMsg)
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

    public bool ValidaDataDuplication(TTWorkFlow_Condiciones_por_EstadoCS.objectBussinessTTWorkFlow_Condiciones_por_Estado MyDataTTWorkFlow_Condiciones_por_Estado, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTTWorkFlow_Condiciones_por_Estado.TTWorkFlow != null&& MyDataTTWorkFlow_Condiciones_por_Estado.Folio == -1)
        {
            if (MyDataTTWorkFlow_Condiciones_por_Estado.ValidaExistencia(MyDataTTWorkFlow_Condiciones_por_Estado.TTWorkFlow, MyDataTTWorkFlow_Condiciones_por_Estado.Folio))
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
        ds.Tables.Add(myTTWorkFlow_Condiciones_por_Estado.FillDataTTWorkFlow(Key).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet FillDataTTWorkFlow()
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Condiciones_por_Estado.FillDataTTWorkFlow().Copy());
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
            dt = myTTWorkFlow_Condiciones_por_Estado.FillDataTTWorkFlow();

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
            dt = myTTWorkFlow_Condiciones_por_Estado.FillDataTTWorkFlow(value);

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
        ds.Tables.Add(myTTWorkFlow_Condiciones_por_Estado.FillDataFase(Key).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet FillDataFase()
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Condiciones_por_Estado.FillDataFase().Copy());
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
            dt = myTTWorkFlow_Condiciones_por_Estado.FillDataFase();

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
            dt = myTTWorkFlow_Condiciones_por_Estado.FillDataFase(value);

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
        ds.Tables.Add(myTTWorkFlow_Condiciones_por_Estado.FillDataEstado(Key,0).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet FillDataEstado()
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Condiciones_por_Estado.FillDataEstado().Copy());
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
            dt = myTTWorkFlow_Condiciones_por_Estado.FillDataEstado();

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
    public CascadingDropDownNameValue[] FillDataEstadowithParentCDD2(string knownCategoryValues, string category, string contextKey)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);

        int value, workflow;
        if (!Int32.TryParse(contextKey, out workflow) && kv.ContainsKey("TTWorkFlow"))
            Int32.TryParse(kv["TTWorkFlow"], out workflow);

        if (!kv.ContainsKey("Fase") || !Int32.TryParse(kv["Fase"], out value)
            || workflow == 0)
            return null;

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Condiciones_por_Estado.FillDataEstado(value, workflow);

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

        int value, workflow;
        if (!kv.ContainsKey("Fase") || !Int32.TryParse(kv["Fase"], out value))
            return null;

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Condiciones_por_Estado.FillDataEstado(value,0);

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
    public DataSet FillDataOperador_de_Condicion(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTWorkFlow_Condiciones_por_Estado.FillDataOperador_de_Condicion().Copy());
        else
            ds.Tables.Add(myTTWorkFlow_Condiciones_por_Estado.FillDataOperador_de_Condicion(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataOperador_de_CondicionCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Condiciones_por_Estado.FillDataOperador_de_Condicion();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Descripcion"].ToString(), dRow["idOperator"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }
    [WebMethod]
    public DataSet FillDataProceso(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTWorkFlow_Condiciones_por_Estado.FillDataProceso().Copy());
        else
            ds.Tables.Add(myTTWorkFlow_Condiciones_por_Estado.FillDataProceso(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataProcesoCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Condiciones_por_Estado.FillDataProceso();

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
    public DataSet FillDataCampowithParent(int Key)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Condiciones_por_Estado.FillDataCampo(Key).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet FillDataCampo()
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Condiciones_por_Estado.FillDataCampo().Copy());
        return ds;
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataCampoCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Condiciones_por_Estado.FillDataCampo();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["DTID"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataCampowithParentCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);

        int value;
        if (!kv.ContainsKey("Proceso") || !Int32.TryParse(kv["Proceso"], out value))
            return null;

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Condiciones_por_Estado.FillDataCampo(value);

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["DTID"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }
    [WebMethod]
    public DataSet FillDataCondicion(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTWorkFlow_Condiciones_por_Estado.FillDataCondicion().Copy());
        else
            ds.Tables.Add(myTTWorkFlow_Condiciones_por_Estado.FillDataCondicion(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataCondicionCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Condiciones_por_Estado.FillDataCondicion();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Descripcion"].ToString(), dRow["idCondicion"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }
    [WebMethod]
    public DataSet FillDataOperador(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTWorkFlow_Condiciones_por_Estado.FillDataOperador().Copy());
        else
            ds.Tables.Add(myTTWorkFlow_Condiciones_por_Estado.FillDataOperador(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataOperadorCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Condiciones_por_Estado.FillDataOperador();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Descripcion"].ToString(), dRow["idOperator"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }

}