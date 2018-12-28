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
public class objectBussinessTTWorkFlow_Fases : System.Web.Services.WebService
{
    public int iProcess = 15801;
    private TTTraductor.Traductor MyTraductor;
    public TTWorkFlow_FasesCS.objectBussinessTTWorkFlow_Fases myTTWorkFlow_Fases = new TTWorkFlow_FasesCS.objectBussinessTTWorkFlow_Fases();

    [WebMethod]
    public Int32 SelCount()
    {
        return myTTWorkFlow_Fases.SelCount();
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
        return myTTWorkFlow_Fases.SelAll(ConRelaciones);
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, TTWorkFlow_FasesCS.TTWorkFlow_FasesFilters[] myFilters)
    {
        myTTWorkFlow_Fases.Filters = myFilters;
        return myTTWorkFlow_Fases.SelAll(ConRelaciones);
        myTTWorkFlow_Fases.Filters = null;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Fases.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varWorkFlow, int? varNumero_de_Fase, String varNombre, int? varTipo_de_Fase, int? varTipo_de_Distribucion_de_Trabajo, int? varTipo_de_Control_de_Flujo, int? varEstatus_de_Fase)
    {
        TTWorkFlow_FasesCS.objectBussinessTTWorkFlow_Fases  myTTWorkFlow_Fases= new TTWorkFlow_FasesCS.objectBussinessTTWorkFlow_Fases();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTWorkFlow_Fases.WorkFlow = varWorkFlow;
        myTTWorkFlow_Fases.Numero_de_Fase = varNumero_de_Fase;
        myTTWorkFlow_Fases.Nombre = varNombre;
        myTTWorkFlow_Fases.Tipo_de_Fase = varTipo_de_Fase;
        myTTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo = varTipo_de_Distribucion_de_Trabajo;
        myTTWorkFlow_Fases.Tipo_de_Control_de_Flujo = varTipo_de_Control_de_Flujo;
        myTTWorkFlow_Fases.Estatus_de_Fase = varEstatus_de_Fase;

        String sMsg = "";
        if (!ValidaDataToSave(myTTWorkFlow_Fases, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTWorkFlow_Fases, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTWorkFlow_Fases.Insert(globalInfo, dr);
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, int? varWorkFlow, int? varNumero_de_Fase, String varNombre, int? varTipo_de_Fase, int? varTipo_de_Distribucion_de_Trabajo, int? varTipo_de_Control_de_Flujo, int? varEstatus_de_Fase)
    {
        TTWorkFlow_FasesCS.objectBussinessTTWorkFlow_Fases  myTTWorkFlow_Fases= new TTWorkFlow_FasesCS.objectBussinessTTWorkFlow_Fases();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTWorkFlow_Fases.WorkFlow = varWorkFlow;
        myTTWorkFlow_Fases.Numero_de_Fase = varNumero_de_Fase;
        myTTWorkFlow_Fases.Nombre = varNombre;
        myTTWorkFlow_Fases.Tipo_de_Fase = varTipo_de_Fase;
        myTTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo = varTipo_de_Distribucion_de_Trabajo;
        myTTWorkFlow_Fases.Tipo_de_Control_de_Flujo = varTipo_de_Control_de_Flujo;
        myTTWorkFlow_Fases.Estatus_de_Fase = varEstatus_de_Fase;

        String sMsg = "";
        if (!ValidaDataToSave(myTTWorkFlow_Fases, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTWorkFlow_Fases, out sMsg))
        {
            throw new Exception(sMsg);
        }
        return myTTWorkFlow_Fases.InsertWithReturnValue(globalInfo, dr);
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varWorkFlow, int? varFolio, int? varNumero_de_Fase, String varNombre, int? varTipo_de_Fase, int? varTipo_de_Distribucion_de_Trabajo, int? varTipo_de_Control_de_Flujo, int? varEstatus_de_Fase)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myTTWorkFlow_Fases.WorkFlow = varWorkFlow;
        myTTWorkFlow_Fases.Folio = varFolio;
        myTTWorkFlow_Fases.Numero_de_Fase = varNumero_de_Fase;
        myTTWorkFlow_Fases.Nombre = varNombre;
        myTTWorkFlow_Fases.Tipo_de_Fase = varTipo_de_Fase;
        myTTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo = varTipo_de_Distribucion_de_Trabajo;
        myTTWorkFlow_Fases.Tipo_de_Control_de_Flujo = varTipo_de_Control_de_Flujo;
        myTTWorkFlow_Fases.Estatus_de_Fase = varEstatus_de_Fase;

            String sMsg = "";
            if (!ValidaDataToSave(myTTWorkFlow_Fases, out sMsg))
            {
                throw new Exception(sMsg);
            }
            myTTWorkFlow_Fases.Update(globalInfo, dr);
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyWorkFlow, int? KeyFolio)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
         return myTTWorkFlow_Fases.Delete(KeyWorkFlow, KeyFolio, globalInfo, dr);
    }

    [WebMethod]
    public TTWorkFlow_FasesCS.objectBussinessTTWorkFlow_Fases GetByKey(int? KeyWorkFlow, int? KeyFolio, Boolean ConRelaciones)
    {
        myTTWorkFlow_Fases.GetByKey(KeyWorkFlow, KeyFolio, ConRelaciones);;
        return myTTWorkFlow_Fases;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyWorkFlow, int? KeyFolio)
    {
        return myTTWorkFlow_Fases.CurrentPosicion(KeyWorkFlow, KeyFolio);
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyWorkFlow, int? KeyFolio)
    {
        return myTTWorkFlow_Fases.ValidaExistencia(KeyWorkFlow, KeyFolio);
    }

    private bool ValidaDataToSave(TTWorkFlow_FasesCS.objectBussinessTTWorkFlow_Fases MyDataTTWorkFlow_Fases, out String sMsg)
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

    public bool ValidaDataDuplication(TTWorkFlow_FasesCS.objectBussinessTTWorkFlow_Fases MyDataTTWorkFlow_Fases, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTTWorkFlow_Fases.WorkFlow != null&& MyDataTTWorkFlow_Fases.Folio == -1)
        {
            if (MyDataTTWorkFlow_Fases.ValidaExistencia(MyDataTTWorkFlow_Fases.WorkFlow, MyDataTTWorkFlow_Fases.Folio))
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
    public DataSet FillDataWorkFlow(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTWorkFlow_Fases.FillDataWorkFlow().Copy());
        else
            ds.Tables.Add(myTTWorkFlow_Fases.FillDataWorkFlow(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataWorkFlowCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Fases.FillDataWorkFlow();

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
    public DataSet FillDataTipo_de_Fase(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTWorkFlow_Fases.FillDataTipo_de_Fase().Copy());
        else
            ds.Tables.Add(myTTWorkFlow_Fases.FillDataTipo_de_Fase(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataTipo_de_FaseCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Fases.FillDataTipo_de_Fase();

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
    public DataSet FillDataTipo_de_Distribucion_de_Trabajo(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTWorkFlow_Fases.FillDataTipo_de_Distribucion_de_Trabajo().Copy());
        else
            ds.Tables.Add(myTTWorkFlow_Fases.FillDataTipo_de_Distribucion_de_Trabajo(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataTipo_de_Distribucion_de_TrabajoCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Fases.FillDataTipo_de_Distribucion_de_Trabajo();

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
    public DataSet FillDataTipo_de_Control_de_Flujo(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTWorkFlow_Fases.FillDataTipo_de_Control_de_Flujo().Copy());
        else
            ds.Tables.Add(myTTWorkFlow_Fases.FillDataTipo_de_Control_de_Flujo(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataTipo_de_Control_de_FlujoCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Fases.FillDataTipo_de_Control_de_Flujo();

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
    public DataSet FillDataEstatus_de_Fase(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTWorkFlow_Fases.FillDataEstatus_de_Fase().Copy());
        else
            ds.Tables.Add(myTTWorkFlow_Fases.FillDataEstatus_de_Fase(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataEstatus_de_FaseCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow_Fases.FillDataEstatus_de_Fase();

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