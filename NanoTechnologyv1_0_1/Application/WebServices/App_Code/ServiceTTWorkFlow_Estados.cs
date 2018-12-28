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
public class objectBussinessTTWorkFlow_Estados : System.Web.Services.WebService
{
    public int iProcess = 15809;
    private TTTraductor.Traductor MyTraductor;
    public TTWorkFlow_EstadosCS.objectBussinessTTWorkFlow_Estados myTTWorkFlow_Estados = new TTWorkFlow_EstadosCS.objectBussinessTTWorkFlow_Estados();

    [WebMethod]
    public Int32 SelCount()
    {
        return myTTWorkFlow_Estados.SelCount();
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
        return myTTWorkFlow_Estados.SelAll(ConRelaciones);
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, TTWorkFlow_EstadosCS.TTWorkFlow_EstadosFilters[] myFilters)
    {
        myTTWorkFlow_Estados.Filters = myFilters;
        return myTTWorkFlow_Estados.SelAll(ConRelaciones);
        myTTWorkFlow_Estados.Filters = null;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Estados.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varTTWorkFlow, int? varFase, int? varProceso, int? varCampo, int? varCodigo_Estado, String varNombre, int? varValor, String varTexto)
    {
        TTWorkFlow_EstadosCS.objectBussinessTTWorkFlow_Estados  myTTWorkFlow_Estados= new TTWorkFlow_EstadosCS.objectBussinessTTWorkFlow_Estados();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTWorkFlow_Estados.TTWorkFlow = varTTWorkFlow;
        myTTWorkFlow_Estados.Fase = varFase;
        myTTWorkFlow_Estados.Proceso = varProceso;
        myTTWorkFlow_Estados.Campo = varCampo;
        myTTWorkFlow_Estados.Codigo_Estado = varCodigo_Estado;
        myTTWorkFlow_Estados.Nombre = varNombre;
        myTTWorkFlow_Estados.Valor = varValor;
        myTTWorkFlow_Estados.Texto = varTexto;

        String sMsg = "";
        if (!ValidaDataToSave(myTTWorkFlow_Estados, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTWorkFlow_Estados, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTWorkFlow_Estados.Insert(globalInfo, dr);
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, int? varTTWorkFlow, int? varFase, int? varProceso, int? varCampo, int? varCodigo_Estado, String varNombre, int? varValor, String varTexto)
    {
        TTWorkFlow_EstadosCS.objectBussinessTTWorkFlow_Estados  myTTWorkFlow_Estados= new TTWorkFlow_EstadosCS.objectBussinessTTWorkFlow_Estados();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTWorkFlow_Estados.TTWorkFlow = varTTWorkFlow;
        myTTWorkFlow_Estados.Fase = varFase;
        myTTWorkFlow_Estados.Proceso = varProceso;
        myTTWorkFlow_Estados.Campo = varCampo;
        myTTWorkFlow_Estados.Codigo_Estado = varCodigo_Estado;
        myTTWorkFlow_Estados.Nombre = varNombre;
        myTTWorkFlow_Estados.Valor = varValor;
        myTTWorkFlow_Estados.Texto = varTexto;

        String sMsg = "";
        if (!ValidaDataToSave(myTTWorkFlow_Estados, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTWorkFlow_Estados, out sMsg))
        {
            throw new Exception(sMsg);
        }
        return myTTWorkFlow_Estados.InsertWithReturnValue(globalInfo, dr);
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varTTWorkFlow, int? varFolio, int? varFase, int? varProceso, int? varCampo, int? varCodigo_Estado, String varNombre, int? varValor, String varTexto)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myTTWorkFlow_Estados.TTWorkFlow = varTTWorkFlow;
        myTTWorkFlow_Estados.Folio = varFolio;
        myTTWorkFlow_Estados.Fase = varFase;
        myTTWorkFlow_Estados.Proceso = varProceso;
        myTTWorkFlow_Estados.Campo = varCampo;
        myTTWorkFlow_Estados.Codigo_Estado = varCodigo_Estado;
        myTTWorkFlow_Estados.Nombre = varNombre;
        myTTWorkFlow_Estados.Valor = varValor;
        myTTWorkFlow_Estados.Texto = varTexto;

            String sMsg = "";
            if (!ValidaDataToSave(myTTWorkFlow_Estados, out sMsg))
            {
                throw new Exception(sMsg);
            }
            myTTWorkFlow_Estados.Update(globalInfo, dr);
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyTTWorkFlow, int? KeyFolio)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
         return myTTWorkFlow_Estados.Delete(KeyTTWorkFlow, KeyFolio, globalInfo, dr);
    }

    [WebMethod]
    public TTWorkFlow_EstadosCS.objectBussinessTTWorkFlow_Estados GetByKey(int? KeyTTWorkFlow, int? KeyFolio, Boolean ConRelaciones)
    {
        myTTWorkFlow_Estados.GetByKey(KeyTTWorkFlow, KeyFolio, ConRelaciones);;
        return myTTWorkFlow_Estados;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyTTWorkFlow, int? KeyFolio)
    {
        return myTTWorkFlow_Estados.CurrentPosicion(KeyTTWorkFlow, KeyFolio);
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyTTWorkFlow, int? KeyFolio)
    {
        return myTTWorkFlow_Estados.ValidaExistencia(KeyTTWorkFlow, KeyFolio);
    }

    private bool ValidaDataToSave(TTWorkFlow_EstadosCS.objectBussinessTTWorkFlow_Estados MyDataTTWorkFlow_Estados, out String sMsg)
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

    public bool ValidaDataDuplication(TTWorkFlow_EstadosCS.objectBussinessTTWorkFlow_Estados MyDataTTWorkFlow_Estados, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTTWorkFlow_Estados.TTWorkFlow != null&& MyDataTTWorkFlow_Estados.Folio == -1)
        {
            if (MyDataTTWorkFlow_Estados.ValidaExistencia(MyDataTTWorkFlow_Estados.TTWorkFlow, MyDataTTWorkFlow_Estados.Folio))
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
        ds.Tables.Add(myTTWorkFlow_Estados.FillDataTTWorkFlow(Key).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet FillDataTTWorkFlow()
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Estados.FillDataTTWorkFlow().Copy());
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
            dt = myTTWorkFlow_Estados.FillDataTTWorkFlow();

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
            dt = myTTWorkFlow_Estados.FillDataTTWorkFlow(value);

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
        ds.Tables.Add(myTTWorkFlow_Estados.FillDataFase(Key).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet FillDataFase()
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Estados.FillDataFase().Copy());
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
            dt = myTTWorkFlow_Estados.FillDataFase();

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
            dt = myTTWorkFlow_Estados.FillDataFase(value);

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
    public DataSet FillDataProceso(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTWorkFlow_Estados.FillDataProceso().Copy());
        else
            ds.Tables.Add(myTTWorkFlow_Estados.FillDataProceso(sFiltro).Copy());
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
            dt = myTTWorkFlow_Estados.FillDataProceso();

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
        ds.Tables.Add(myTTWorkFlow_Estados.FillDataCampo(Key).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet FillDataCampo()
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Estados.FillDataCampo().Copy());
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
            dt = myTTWorkFlow_Estados.FillDataCampo();

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
            dt = myTTWorkFlow_Estados.FillDataCampo(value);

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["DTID"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }

}