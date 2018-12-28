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
public class objectBussinessTTWorkFlow_Metas_de_Fase : System.Web.Services.WebService
{
    public int iProcess = 15806;
    private TTTraductor.Traductor MyTraductor;
    public TTWorkFlow_Metas_de_FaseCS.objectBussinessTTWorkFlow_Metas_de_Fase myTTWorkFlow_Metas_de_Fase = new TTWorkFlow_Metas_de_FaseCS.objectBussinessTTWorkFlow_Metas_de_Fase();

    [WebMethod]
    public Int32 SelCount()
    {
        return myTTWorkFlow_Metas_de_Fase.SelCount();
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
        return myTTWorkFlow_Metas_de_Fase.SelAll(ConRelaciones);
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, TTWorkFlow_Metas_de_FaseCS.TTWorkFlow_Metas_de_FaseFilters[] myFilters)
    {
        myTTWorkFlow_Metas_de_Fase.Filters = myFilters;
        return myTTWorkFlow_Metas_de_Fase.SelAll(ConRelaciones);
        myTTWorkFlow_Metas_de_Fase.Filters = null;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Metas_de_Fase.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varTTWorkFlow, int? varFase, int? varTipo_de_Meta, int? varProceso, int? varCampo, Decimal varMeta, int? varFrecuencia, Decimal varValor_Minimo_para_Alerta, Decimal varValor_Maximo_para_Alerta, int? varGrupo_Funcional_para_Alerta)
    {
        TTWorkFlow_Metas_de_FaseCS.objectBussinessTTWorkFlow_Metas_de_Fase  myTTWorkFlow_Metas_de_Fase= new TTWorkFlow_Metas_de_FaseCS.objectBussinessTTWorkFlow_Metas_de_Fase();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTWorkFlow_Metas_de_Fase.TTWorkFlow = varTTWorkFlow;
        myTTWorkFlow_Metas_de_Fase.Fase = varFase;
        myTTWorkFlow_Metas_de_Fase.Tipo_de_Meta = varTipo_de_Meta;
        myTTWorkFlow_Metas_de_Fase.Proceso = varProceso;
        myTTWorkFlow_Metas_de_Fase.Campo = varCampo;
        myTTWorkFlow_Metas_de_Fase.Meta = varMeta;
        myTTWorkFlow_Metas_de_Fase.Frecuencia = varFrecuencia;
        myTTWorkFlow_Metas_de_Fase.Valor_Minimo_para_Alerta = varValor_Minimo_para_Alerta;
        myTTWorkFlow_Metas_de_Fase.Valor_Maximo_para_Alerta = varValor_Maximo_para_Alerta;
        myTTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta = varGrupo_Funcional_para_Alerta;

        String sMsg = "";
        if (!ValidaDataToSave(myTTWorkFlow_Metas_de_Fase, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTWorkFlow_Metas_de_Fase, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTWorkFlow_Metas_de_Fase.Insert(globalInfo, dr);
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, int? varTTWorkFlow, int? varFase, int? varTipo_de_Meta, int? varProceso, int? varCampo, Decimal varMeta, int? varFrecuencia, Decimal varValor_Minimo_para_Alerta, Decimal varValor_Maximo_para_Alerta, int? varGrupo_Funcional_para_Alerta)
    {
        TTWorkFlow_Metas_de_FaseCS.objectBussinessTTWorkFlow_Metas_de_Fase  myTTWorkFlow_Metas_de_Fase= new TTWorkFlow_Metas_de_FaseCS.objectBussinessTTWorkFlow_Metas_de_Fase();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTWorkFlow_Metas_de_Fase.TTWorkFlow = varTTWorkFlow;
        myTTWorkFlow_Metas_de_Fase.Fase = varFase;
        myTTWorkFlow_Metas_de_Fase.Tipo_de_Meta = varTipo_de_Meta;
        myTTWorkFlow_Metas_de_Fase.Proceso = varProceso;
        myTTWorkFlow_Metas_de_Fase.Campo = varCampo;
        myTTWorkFlow_Metas_de_Fase.Meta = varMeta;
        myTTWorkFlow_Metas_de_Fase.Frecuencia = varFrecuencia;
        myTTWorkFlow_Metas_de_Fase.Valor_Minimo_para_Alerta = varValor_Minimo_para_Alerta;
        myTTWorkFlow_Metas_de_Fase.Valor_Maximo_para_Alerta = varValor_Maximo_para_Alerta;
        myTTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta = varGrupo_Funcional_para_Alerta;

        String sMsg = "";
        if (!ValidaDataToSave(myTTWorkFlow_Metas_de_Fase, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTWorkFlow_Metas_de_Fase, out sMsg))
        {
            throw new Exception(sMsg);
        }
        return myTTWorkFlow_Metas_de_Fase.InsertWithReturnValue(globalInfo, dr);
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varTTWorkFlow, int? varFolio, int? varFase, int? varTipo_de_Meta, int? varProceso, int? varCampo, Decimal varMeta, int? varFrecuencia, Decimal varValor_Minimo_para_Alerta, Decimal varValor_Maximo_para_Alerta, int? varGrupo_Funcional_para_Alerta)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myTTWorkFlow_Metas_de_Fase.TTWorkFlow = varTTWorkFlow;
        myTTWorkFlow_Metas_de_Fase.Folio = varFolio;
        myTTWorkFlow_Metas_de_Fase.Fase = varFase;
        myTTWorkFlow_Metas_de_Fase.Tipo_de_Meta = varTipo_de_Meta;
        myTTWorkFlow_Metas_de_Fase.Proceso = varProceso;
        myTTWorkFlow_Metas_de_Fase.Campo = varCampo;
        myTTWorkFlow_Metas_de_Fase.Meta = varMeta;
        myTTWorkFlow_Metas_de_Fase.Frecuencia = varFrecuencia;
        myTTWorkFlow_Metas_de_Fase.Valor_Minimo_para_Alerta = varValor_Minimo_para_Alerta;
        myTTWorkFlow_Metas_de_Fase.Valor_Maximo_para_Alerta = varValor_Maximo_para_Alerta;
        myTTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta = varGrupo_Funcional_para_Alerta;

            String sMsg = "";
            if (!ValidaDataToSave(myTTWorkFlow_Metas_de_Fase, out sMsg))
            {
                throw new Exception(sMsg);
            }
            myTTWorkFlow_Metas_de_Fase.Update(globalInfo, dr);
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyTTWorkFlow, int? KeyFolio)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
         return myTTWorkFlow_Metas_de_Fase.Delete(KeyTTWorkFlow, KeyFolio, globalInfo, dr);
    }

    [WebMethod]
    public TTWorkFlow_Metas_de_FaseCS.objectBussinessTTWorkFlow_Metas_de_Fase GetByKey(int? KeyTTWorkFlow, int? KeyFolio, Boolean ConRelaciones)
    {
        myTTWorkFlow_Metas_de_Fase.GetByKey(KeyTTWorkFlow, KeyFolio, ConRelaciones);;
        return myTTWorkFlow_Metas_de_Fase;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyTTWorkFlow, int? KeyFolio)
    {
        return myTTWorkFlow_Metas_de_Fase.CurrentPosicion(KeyTTWorkFlow, KeyFolio);
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyTTWorkFlow, int? KeyFolio)
    {
        return myTTWorkFlow_Metas_de_Fase.ValidaExistencia(KeyTTWorkFlow, KeyFolio);
    }

    private bool ValidaDataToSave(TTWorkFlow_Metas_de_FaseCS.objectBussinessTTWorkFlow_Metas_de_Fase MyDataTTWorkFlow_Metas_de_Fase, out String sMsg)
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

    public bool ValidaDataDuplication(TTWorkFlow_Metas_de_FaseCS.objectBussinessTTWorkFlow_Metas_de_Fase MyDataTTWorkFlow_Metas_de_Fase, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTTWorkFlow_Metas_de_Fase.TTWorkFlow != null&& MyDataTTWorkFlow_Metas_de_Fase.Folio == -1)
        {
            if (MyDataTTWorkFlow_Metas_de_Fase.ValidaExistencia(MyDataTTWorkFlow_Metas_de_Fase.TTWorkFlow, MyDataTTWorkFlow_Metas_de_Fase.Folio))
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
        ds.Tables.Add(myTTWorkFlow_Metas_de_Fase.FillDataTTWorkFlow(Key).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet FillDataTTWorkFlow()
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Metas_de_Fase.FillDataTTWorkFlow().Copy());
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
            dt = myTTWorkFlow_Metas_de_Fase.FillDataTTWorkFlow();

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
        if (!kv.ContainsKey("Fase") || !Int32.TryParse(kv["Fase"], out value))
            return null;

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Metas_de_Fase.FillDataTTWorkFlow(value);

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
        ds.Tables.Add(myTTWorkFlow_Metas_de_Fase.FillDataFase(Key).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet FillDataFase()
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Metas_de_Fase.FillDataFase().Copy());
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
            dt = myTTWorkFlow_Metas_de_Fase.FillDataFase();

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
            dt = myTTWorkFlow_Metas_de_Fase.FillDataFase(value);

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
    public DataSet FillDataTipo_de_Meta(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTWorkFlow_Metas_de_Fase.FillDataTipo_de_Meta().Copy());
        else
            ds.Tables.Add(myTTWorkFlow_Metas_de_Fase.FillDataTipo_de_Meta(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataTipo_de_MetaCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Metas_de_Fase.FillDataTipo_de_Meta();

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
    public DataSet FillDataProceso(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTWorkFlow_Metas_de_Fase.FillDataProceso().Copy());
        else
            ds.Tables.Add(myTTWorkFlow_Metas_de_Fase.FillDataProceso(sFiltro).Copy());
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
            dt = myTTWorkFlow_Metas_de_Fase.FillDataProceso();

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
        ds.Tables.Add(myTTWorkFlow_Metas_de_Fase.FillDataCampo(Key).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet FillDataCampo()
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Metas_de_Fase.FillDataCampo().Copy());
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
            dt = myTTWorkFlow_Metas_de_Fase.FillDataCampo();

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
            dt = myTTWorkFlow_Metas_de_Fase.FillDataCampo(value);

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
    public DataSet FillDataFrecuencia(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTWorkFlow_Metas_de_Fase.FillDataFrecuencia().Copy());
        else
            ds.Tables.Add(myTTWorkFlow_Metas_de_Fase.FillDataFrecuencia(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataFrecuenciaCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Metas_de_Fase.FillDataFrecuencia();

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
    public DataSet FillDataGrupo_Funcional_para_Alerta(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTWorkFlow_Metas_de_Fase.FillDataGrupo_Funcional_para_Alerta().Copy());
        else
            ds.Tables.Add(myTTWorkFlow_Metas_de_Fase.FillDataGrupo_Funcional_para_Alerta(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataGrupo_Funcional_para_AlertaCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Metas_de_Fase.FillDataGrupo_Funcional_para_Alerta();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["idGrupo"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }

}