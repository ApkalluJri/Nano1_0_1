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
public class objectBussinessTTWorkFlow_Matriz_de_Estados : System.Web.Services.WebService
{
    public int iProcess = 15810;
    private TTTraductor.Traductor MyTraductor;
    public TTWorkFlow_Matriz_de_EstadosCS.objectBussinessTTWorkFlow_Matriz_de_Estados myTTWorkFlow_Matriz_de_Estados = new TTWorkFlow_Matriz_de_EstadosCS.objectBussinessTTWorkFlow_Matriz_de_Estados();

    [WebMethod]
    public Int32 SelCount()
    {
        return myTTWorkFlow_Matriz_de_Estados.SelCount();
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
        return myTTWorkFlow_Matriz_de_Estados.SelAll(ConRelaciones);
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, TTWorkFlow_Matriz_de_EstadosCS.TTWorkFlow_Matriz_de_EstadosFilters[] myFilters)
    {
        myTTWorkFlow_Matriz_de_Estados.Filters = myFilters;
        return myTTWorkFlow_Matriz_de_Estados.SelAll(ConRelaciones);
        myTTWorkFlow_Matriz_de_Estados.Filters = null;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Matriz_de_Estados.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varTTWorkFlow, int? varFase, int? varEstado, int? varProceso, int? varCampo, int? varVisible, int? varObligatorio, int? varSolo_Lectura, String varEtiqueta, String varValor_por_Defecto, String varTexto_de_Ayuda)
    {
        TTWorkFlow_Matriz_de_EstadosCS.objectBussinessTTWorkFlow_Matriz_de_Estados  myTTWorkFlow_Matriz_de_Estados= new TTWorkFlow_Matriz_de_EstadosCS.objectBussinessTTWorkFlow_Matriz_de_Estados();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTWorkFlow_Matriz_de_Estados.TTWorkFlow = varTTWorkFlow;
        myTTWorkFlow_Matriz_de_Estados.Fase = varFase;
        myTTWorkFlow_Matriz_de_Estados.Estado = varEstado;
        myTTWorkFlow_Matriz_de_Estados.Proceso = varProceso;
        myTTWorkFlow_Matriz_de_Estados.Campo = varCampo;
        myTTWorkFlow_Matriz_de_Estados.Visible = varVisible;
        myTTWorkFlow_Matriz_de_Estados.Obligatorio = varObligatorio;
        myTTWorkFlow_Matriz_de_Estados.Solo_Lectura = varSolo_Lectura;
        myTTWorkFlow_Matriz_de_Estados.Etiqueta = varEtiqueta;
        myTTWorkFlow_Matriz_de_Estados.Valor_por_Defecto = varValor_por_Defecto;
        myTTWorkFlow_Matriz_de_Estados.Texto_de_Ayuda = varTexto_de_Ayuda;

        String sMsg = "";
        if (!ValidaDataToSave(myTTWorkFlow_Matriz_de_Estados, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTWorkFlow_Matriz_de_Estados, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTWorkFlow_Matriz_de_Estados.Insert(globalInfo, dr);
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, int? varTTWorkFlow, int? varFase, int? varEstado, int? varProceso, int? varCampo, int? varVisible, int? varObligatorio, int? varSolo_Lectura, String varEtiqueta, String varValor_por_Defecto, String varTexto_de_Ayuda)
    {
        TTWorkFlow_Matriz_de_EstadosCS.objectBussinessTTWorkFlow_Matriz_de_Estados  myTTWorkFlow_Matriz_de_Estados= new TTWorkFlow_Matriz_de_EstadosCS.objectBussinessTTWorkFlow_Matriz_de_Estados();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTWorkFlow_Matriz_de_Estados.TTWorkFlow = varTTWorkFlow;
        myTTWorkFlow_Matriz_de_Estados.Fase = varFase;
        myTTWorkFlow_Matriz_de_Estados.Estado = varEstado;
        myTTWorkFlow_Matriz_de_Estados.Proceso = varProceso;
        myTTWorkFlow_Matriz_de_Estados.Campo = varCampo;
        myTTWorkFlow_Matriz_de_Estados.Visible = varVisible;
        myTTWorkFlow_Matriz_de_Estados.Obligatorio = varObligatorio;
        myTTWorkFlow_Matriz_de_Estados.Solo_Lectura = varSolo_Lectura;
        myTTWorkFlow_Matriz_de_Estados.Etiqueta = varEtiqueta;
        myTTWorkFlow_Matriz_de_Estados.Valor_por_Defecto = varValor_por_Defecto;
        myTTWorkFlow_Matriz_de_Estados.Texto_de_Ayuda = varTexto_de_Ayuda;

        String sMsg = "";
        if (!ValidaDataToSave(myTTWorkFlow_Matriz_de_Estados, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTWorkFlow_Matriz_de_Estados, out sMsg))
        {
            throw new Exception(sMsg);
        }
        return myTTWorkFlow_Matriz_de_Estados.InsertWithReturnValue(globalInfo, dr);
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varTTWorkFlow, int? varFolio, int? varFase, int? varEstado, int? varProceso, int? varCampo, int? varVisible, int? varObligatorio, int? varSolo_Lectura, String varEtiqueta, String varValor_por_Defecto, String varTexto_de_Ayuda)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myTTWorkFlow_Matriz_de_Estados.TTWorkFlow = varTTWorkFlow;
        myTTWorkFlow_Matriz_de_Estados.Folio = varFolio;
        myTTWorkFlow_Matriz_de_Estados.Fase = varFase;
        myTTWorkFlow_Matriz_de_Estados.Estado = varEstado;
        myTTWorkFlow_Matriz_de_Estados.Proceso = varProceso;
        myTTWorkFlow_Matriz_de_Estados.Campo = varCampo;
        myTTWorkFlow_Matriz_de_Estados.Visible = varVisible;
        myTTWorkFlow_Matriz_de_Estados.Obligatorio = varObligatorio;
        myTTWorkFlow_Matriz_de_Estados.Solo_Lectura = varSolo_Lectura;
        myTTWorkFlow_Matriz_de_Estados.Etiqueta = varEtiqueta;
        myTTWorkFlow_Matriz_de_Estados.Valor_por_Defecto = varValor_por_Defecto;
        myTTWorkFlow_Matriz_de_Estados.Texto_de_Ayuda = varTexto_de_Ayuda;

            String sMsg = "";
            if (!ValidaDataToSave(myTTWorkFlow_Matriz_de_Estados, out sMsg))
            {
                throw new Exception(sMsg);
            }
            myTTWorkFlow_Matriz_de_Estados.Update(globalInfo, dr);
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyTTWorkFlow, int? KeyFolio)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
         return myTTWorkFlow_Matriz_de_Estados.Delete(KeyTTWorkFlow, KeyFolio, globalInfo, dr);
    }

    [WebMethod]
    public TTWorkFlow_Matriz_de_EstadosCS.objectBussinessTTWorkFlow_Matriz_de_Estados GetByKey(int? KeyTTWorkFlow, int? KeyFolio, Boolean ConRelaciones)
    {
        myTTWorkFlow_Matriz_de_Estados.GetByKey(KeyTTWorkFlow, KeyFolio, ConRelaciones);;
        return myTTWorkFlow_Matriz_de_Estados;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyTTWorkFlow, int? KeyFolio)
    {
        return myTTWorkFlow_Matriz_de_Estados.CurrentPosicion(KeyTTWorkFlow, KeyFolio);
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyTTWorkFlow, int? KeyFolio)
    {
        return myTTWorkFlow_Matriz_de_Estados.ValidaExistencia(KeyTTWorkFlow, KeyFolio);
    }

    private bool ValidaDataToSave(TTWorkFlow_Matriz_de_EstadosCS.objectBussinessTTWorkFlow_Matriz_de_Estados MyDataTTWorkFlow_Matriz_de_Estados, out String sMsg)
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

    public bool ValidaDataDuplication(TTWorkFlow_Matriz_de_EstadosCS.objectBussinessTTWorkFlow_Matriz_de_Estados MyDataTTWorkFlow_Matriz_de_Estados, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTTWorkFlow_Matriz_de_Estados.TTWorkFlow != null&& MyDataTTWorkFlow_Matriz_de_Estados.Folio == -1)
        {
            if (MyDataTTWorkFlow_Matriz_de_Estados.ValidaExistencia(MyDataTTWorkFlow_Matriz_de_Estados.TTWorkFlow, MyDataTTWorkFlow_Matriz_de_Estados.Folio))
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
        ds.Tables.Add(myTTWorkFlow_Matriz_de_Estados.FillDataTTWorkFlow(Key).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet FillDataTTWorkFlow()
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Matriz_de_Estados.FillDataTTWorkFlow().Copy());
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
            dt = myTTWorkFlow_Matriz_de_Estados.FillDataTTWorkFlow();

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
            dt = myTTWorkFlow_Matriz_de_Estados.FillDataTTWorkFlow(value);

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
        ds.Tables.Add(myTTWorkFlow_Matriz_de_Estados.FillDataFase(Key).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet FillDataFase()
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Matriz_de_Estados.FillDataFase().Copy());
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
            dt = myTTWorkFlow_Matriz_de_Estados.FillDataFase();

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
            dt = myTTWorkFlow_Matriz_de_Estados.FillDataFase(value);

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
        ds.Tables.Add(myTTWorkFlow_Matriz_de_Estados.FillDataEstado(Key).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet FillDataEstado()
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Matriz_de_Estados.FillDataEstado().Copy());
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
            dt = myTTWorkFlow_Matriz_de_Estados.FillDataEstado();

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
            dt = myTTWorkFlow_Matriz_de_Estados.FillDataEstado(value);

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
    public DataSet FillDataProceso(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTWorkFlow_Matriz_de_Estados.FillDataProceso().Copy());
        else
            ds.Tables.Add(myTTWorkFlow_Matriz_de_Estados.FillDataProceso(sFiltro).Copy());
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
            dt = myTTWorkFlow_Matriz_de_Estados.FillDataProceso();

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
        ds.Tables.Add(myTTWorkFlow_Matriz_de_Estados.FillDataCampo(Key).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet FillDataCampo()
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Matriz_de_Estados.FillDataCampo().Copy());
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
            dt = myTTWorkFlow_Matriz_de_Estados.FillDataCampo();

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
            dt = myTTWorkFlow_Matriz_de_Estados.FillDataCampo(value);

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
    public DataSet FillDataVisible(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTWorkFlow_Matriz_de_Estados.FillDataVisible().Copy());
        else
            ds.Tables.Add(myTTWorkFlow_Matriz_de_Estados.FillDataVisible(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataVisibleCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Matriz_de_Estados.FillDataVisible();

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
    public DataSet FillDataObligatorio(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTWorkFlow_Matriz_de_Estados.FillDataObligatorio().Copy());
        else
            ds.Tables.Add(myTTWorkFlow_Matriz_de_Estados.FillDataObligatorio(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataObligatorioCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Matriz_de_Estados.FillDataObligatorio();

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
    public DataSet FillDataSolo_Lectura(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTWorkFlow_Matriz_de_Estados.FillDataSolo_Lectura().Copy());
        else
            ds.Tables.Add(myTTWorkFlow_Matriz_de_Estados.FillDataSolo_Lectura(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataSolo_LecturaCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Matriz_de_Estados.FillDataSolo_Lectura();

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