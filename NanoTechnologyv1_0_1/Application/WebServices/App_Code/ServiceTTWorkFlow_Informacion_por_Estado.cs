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
public class objectBussinessTTWorkFlow_Informacion_por_Estado : System.Web.Services.WebService
{
    public int iProcess = 15814;
    private TTTraductor.Traductor MyTraductor;
    public TTWorkFlow_Informacion_por_EstadoCS.objectBussinessTTWorkFlow_Informacion_por_Estado myTTWorkFlow_Informacion_por_Estado = new TTWorkFlow_Informacion_por_EstadoCS.objectBussinessTTWorkFlow_Informacion_por_Estado();

    [WebMethod]
    public Int32 SelCount()
    {
        return myTTWorkFlow_Informacion_por_Estado.SelCount();
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
        return myTTWorkFlow_Informacion_por_Estado.SelAll(ConRelaciones);
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, TTWorkFlow_Informacion_por_EstadoCS.TTWorkFlow_Informacion_por_EstadoFilters[] myFilters)
    {
        myTTWorkFlow_Informacion_por_Estado.Filters = myFilters;
        return myTTWorkFlow_Informacion_por_Estado.SelAll(ConRelaciones);
        myTTWorkFlow_Informacion_por_Estado.Filters = null;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Informacion_por_Estado.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varTTWorkFlow, int? varFase, int? varEstado, int? varProceso, int? varCarpeta, int? varVisible, int? varSolo_Lectura, int? varObligatorios, String varEtiqueta)
    {
        TTWorkFlow_Informacion_por_EstadoCS.objectBussinessTTWorkFlow_Informacion_por_Estado  myTTWorkFlow_Informacion_por_Estado= new TTWorkFlow_Informacion_por_EstadoCS.objectBussinessTTWorkFlow_Informacion_por_Estado();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTWorkFlow_Informacion_por_Estado.TTWorkFlow = varTTWorkFlow;
        myTTWorkFlow_Informacion_por_Estado.Fase = varFase;
        myTTWorkFlow_Informacion_por_Estado.Estado = varEstado;
        myTTWorkFlow_Informacion_por_Estado.Proceso = varProceso;
        myTTWorkFlow_Informacion_por_Estado.Carpeta = varCarpeta;
        myTTWorkFlow_Informacion_por_Estado.Visible = varVisible;
        myTTWorkFlow_Informacion_por_Estado.Solo_Lectura = varSolo_Lectura;
        myTTWorkFlow_Informacion_por_Estado.Obligatorios = varObligatorios;
        myTTWorkFlow_Informacion_por_Estado.Etiqueta = varEtiqueta;

        String sMsg = "";
        if (!ValidaDataToSave(myTTWorkFlow_Informacion_por_Estado, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTWorkFlow_Informacion_por_Estado, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTWorkFlow_Informacion_por_Estado.Insert(globalInfo, dr);
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, int? varTTWorkFlow, int? varFase, int? varEstado, int? varProceso, int? varCarpeta, int? varVisible, int? varSolo_Lectura, int? varObligatorios, String varEtiqueta)
    {
        TTWorkFlow_Informacion_por_EstadoCS.objectBussinessTTWorkFlow_Informacion_por_Estado  myTTWorkFlow_Informacion_por_Estado= new TTWorkFlow_Informacion_por_EstadoCS.objectBussinessTTWorkFlow_Informacion_por_Estado();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTWorkFlow_Informacion_por_Estado.TTWorkFlow = varTTWorkFlow;
        myTTWorkFlow_Informacion_por_Estado.Fase = varFase;
        myTTWorkFlow_Informacion_por_Estado.Estado = varEstado;
        myTTWorkFlow_Informacion_por_Estado.Proceso = varProceso;
        myTTWorkFlow_Informacion_por_Estado.Carpeta = varCarpeta;
        myTTWorkFlow_Informacion_por_Estado.Visible = varVisible;
        myTTWorkFlow_Informacion_por_Estado.Solo_Lectura = varSolo_Lectura;
        myTTWorkFlow_Informacion_por_Estado.Obligatorios = varObligatorios;
        myTTWorkFlow_Informacion_por_Estado.Etiqueta = varEtiqueta;

        String sMsg = "";
        if (!ValidaDataToSave(myTTWorkFlow_Informacion_por_Estado, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTWorkFlow_Informacion_por_Estado, out sMsg))
        {
            throw new Exception(sMsg);
        }
        return myTTWorkFlow_Informacion_por_Estado.InsertWithReturnValue(globalInfo, dr);
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varTTWorkFlow, int? varFolio, int? varFase, int? varEstado, int? varProceso, int? varCarpeta, int? varVisible, int? varSolo_Lectura, int? varObligatorios, String varEtiqueta)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myTTWorkFlow_Informacion_por_Estado.TTWorkFlow = varTTWorkFlow;
        myTTWorkFlow_Informacion_por_Estado.Folio = varFolio;
        myTTWorkFlow_Informacion_por_Estado.Fase = varFase;
        myTTWorkFlow_Informacion_por_Estado.Estado = varEstado;
        myTTWorkFlow_Informacion_por_Estado.Proceso = varProceso;
        myTTWorkFlow_Informacion_por_Estado.Carpeta = varCarpeta;
        myTTWorkFlow_Informacion_por_Estado.Visible = varVisible;
        myTTWorkFlow_Informacion_por_Estado.Solo_Lectura = varSolo_Lectura;
        myTTWorkFlow_Informacion_por_Estado.Obligatorios = varObligatorios;
        myTTWorkFlow_Informacion_por_Estado.Etiqueta = varEtiqueta;

            String sMsg = "";
            if (!ValidaDataToSave(myTTWorkFlow_Informacion_por_Estado, out sMsg))
            {
                throw new Exception(sMsg);
            }
            myTTWorkFlow_Informacion_por_Estado.Update(globalInfo, dr);
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyTTWorkFlow, int? KeyFolio)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
         return myTTWorkFlow_Informacion_por_Estado.Delete(KeyTTWorkFlow, KeyFolio, globalInfo, dr);
    }

    [WebMethod]
    public TTWorkFlow_Informacion_por_EstadoCS.objectBussinessTTWorkFlow_Informacion_por_Estado GetByKey(int? KeyTTWorkFlow, int? KeyFolio, Boolean ConRelaciones)
    {
        myTTWorkFlow_Informacion_por_Estado.GetByKey(KeyTTWorkFlow, KeyFolio, ConRelaciones);;
        return myTTWorkFlow_Informacion_por_Estado;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyTTWorkFlow, int? KeyFolio)
    {
        return myTTWorkFlow_Informacion_por_Estado.CurrentPosicion(KeyTTWorkFlow, KeyFolio);
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyTTWorkFlow, int? KeyFolio)
    {
        return myTTWorkFlow_Informacion_por_Estado.ValidaExistencia(KeyTTWorkFlow, KeyFolio);
    }

    private bool ValidaDataToSave(TTWorkFlow_Informacion_por_EstadoCS.objectBussinessTTWorkFlow_Informacion_por_Estado MyDataTTWorkFlow_Informacion_por_Estado, out String sMsg)
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

    public bool ValidaDataDuplication(TTWorkFlow_Informacion_por_EstadoCS.objectBussinessTTWorkFlow_Informacion_por_Estado MyDataTTWorkFlow_Informacion_por_Estado, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTTWorkFlow_Informacion_por_Estado.TTWorkFlow != null&& MyDataTTWorkFlow_Informacion_por_Estado.Folio == -1)
        {
            if (MyDataTTWorkFlow_Informacion_por_Estado.ValidaExistencia(MyDataTTWorkFlow_Informacion_por_Estado.TTWorkFlow, MyDataTTWorkFlow_Informacion_por_Estado.Folio))
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
        ds.Tables.Add(myTTWorkFlow_Informacion_por_Estado.FillDataTTWorkFlow(Key).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet FillDataTTWorkFlow()
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Informacion_por_Estado.FillDataTTWorkFlow().Copy());
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
            dt = myTTWorkFlow_Informacion_por_Estado.FillDataTTWorkFlow();

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
            dt = myTTWorkFlow_Informacion_por_Estado.FillDataTTWorkFlow(value);

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
        ds.Tables.Add(myTTWorkFlow_Informacion_por_Estado.FillDataFase(Key).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet FillDataFase()
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Informacion_por_Estado.FillDataFase().Copy());
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
            dt = myTTWorkFlow_Informacion_por_Estado.FillDataFase();

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
            dt = myTTWorkFlow_Informacion_por_Estado.FillDataFase(value);

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
        ds.Tables.Add(myTTWorkFlow_Informacion_por_Estado.FillDataEstado(Key).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet FillDataEstado()
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Informacion_por_Estado.FillDataEstado().Copy());
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
            dt = myTTWorkFlow_Informacion_por_Estado.FillDataEstado();

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
            dt = myTTWorkFlow_Informacion_por_Estado.FillDataEstado(value);

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
            ds.Tables.Add(myTTWorkFlow_Informacion_por_Estado.FillDataProceso().Copy());
        else
            ds.Tables.Add(myTTWorkFlow_Informacion_por_Estado.FillDataProceso(sFiltro).Copy());
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
            dt = myTTWorkFlow_Informacion_por_Estado.FillDataProceso();

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
    public DataSet FillDataCarpeta(String sFiltro)
    {
        DataSet ds = new DataSet();
        //if (sFiltro=="")
            ds.Tables.Add(myTTWorkFlow_Informacion_por_Estado.FillDataCarpeta().Copy());
        //else
          //  ds.Tables.Add(myTTWorkFlow_Informacion_por_Estado.FillDataCarpeta(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataCarpetaCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Informacion_por_Estado.FillDataCarpeta();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Descripcion"].ToString(), dRow["Folio"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataCarpetawithParentCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);

        int value;
        if (!kv.ContainsKey("Proceso") || !Int32.TryParse(kv["Proceso"], out value))
            return null;

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Informacion_por_Estado.FillDataCarpeta(value);

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Descripcion"].ToString(), dRow["Folio"].ToString()));
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
            ds.Tables.Add(myTTWorkFlow_Informacion_por_Estado.FillDataVisible().Copy());
        else
            ds.Tables.Add(myTTWorkFlow_Informacion_por_Estado.FillDataVisible(sFiltro).Copy());
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
            dt = myTTWorkFlow_Informacion_por_Estado.FillDataVisible();

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
            ds.Tables.Add(myTTWorkFlow_Informacion_por_Estado.FillDataSolo_Lectura().Copy());
        else
            ds.Tables.Add(myTTWorkFlow_Informacion_por_Estado.FillDataSolo_Lectura(sFiltro).Copy());
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
            dt = myTTWorkFlow_Informacion_por_Estado.FillDataSolo_Lectura();

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
    public DataSet FillDataObligatorios(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTWorkFlow_Informacion_por_Estado.FillDataObligatorios().Copy());
        else
            ds.Tables.Add(myTTWorkFlow_Informacion_por_Estado.FillDataObligatorios(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataObligatoriosCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Informacion_por_Estado.FillDataObligatorios();

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