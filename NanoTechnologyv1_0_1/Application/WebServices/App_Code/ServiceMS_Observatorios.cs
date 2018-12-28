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
public class objectBussinessMS_Observatorios : System.Web.Services.WebService
{
    public int iProcess = 30329;
    private TTTraductor.Traductor MyTraductor;
    


    [WebMethod]
    public string ListaGetFullQuery(string sWhere,string sOrder)
    {
	MS_ObservatoriosCS.objectBussinessMS_Observatorios myMS_Observatorios = new MS_ObservatoriosCS.objectBussinessMS_Observatorios();
        string result = myMS_Observatorios.GetFullQuery(sWhere, sOrder);
	myMS_Observatorios.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ListaSelAll(int startRowIndex,int maximumRows,string where,string Order)
    {
	MS_ObservatoriosCS.objectBussinessMS_Observatorios myMS_Observatorios = new MS_ObservatoriosCS.objectBussinessMS_Observatorios();
        DataSet result = myMS_Observatorios.SelAll(startRowIndex, maximumRows, where, Order);
	myMS_Observatorios.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ImpresionSelAll(string where, string Order)
    {
	MS_ObservatoriosCS.objectBussinessMS_Observatorios myMS_Observatorios = new MS_ObservatoriosCS.objectBussinessMS_Observatorios();
        DataSet result = myMS_Observatorios.SelAll(where, Order);
	myMS_Observatorios.Dispose();
        return result;
    }

    [WebMethod]
    public int ListaSelCount(string where)
    {
	MS_ObservatoriosCS.objectBussinessMS_Observatorios myMS_Observatorios = new MS_ObservatoriosCS.objectBussinessMS_Observatorios();
        int result = myMS_Observatorios.SelCount(where);
	myMS_Observatorios.Dispose();
        return result;
    }


    [WebMethod]
    public Int32 SelCount()
    {
	MS_ObservatoriosCS.objectBussinessMS_Observatorios myMS_Observatorios = new MS_ObservatoriosCS.objectBussinessMS_Observatorios();
        Int32 result = myMS_Observatorios.SelCount();
	myMS_Observatorios.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
	MS_ObservatoriosCS.objectBussinessMS_Observatorios myMS_Observatorios = new MS_ObservatoriosCS.objectBussinessMS_Observatorios();
        DataSet result = myMS_Observatorios.SelAll(ConRelaciones);
	myMS_Observatorios.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, MS_ObservatoriosCS.MS_ObservatoriosFilters[] myFilters)
    {
        MS_ObservatoriosCS.objectBussinessMS_Observatorios myMS_Observatorios = new MS_ObservatoriosCS.objectBussinessMS_Observatorios();
        myMS_Observatorios.Filters = myFilters;
        DataSet result = myMS_Observatorios.SelAll(ConRelaciones);
        myMS_Observatorios.Filters = null;
        myMS_Observatorios.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        MS_ObservatoriosCS.objectBussinessMS_Observatorios myMS_Observatorios = new MS_ObservatoriosCS.objectBussinessMS_Observatorios();
        DataSet ds = new DataSet();
        ds.Tables.Add(myMS_Observatorios.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        myMS_Observatorios.Dispose(); 
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varClave, int? varObservatorio)
    {
        MS_ObservatoriosCS.objectBussinessMS_Observatorios  myMS_Observatorios = new MS_ObservatoriosCS.objectBussinessMS_Observatorios();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myMS_Observatorios.Clave = varClave;
        myMS_Observatorios.Observatorio = varObservatorio;

        String sMsg = "";
        if (!ValidaDataToSave(myMS_Observatorios, out sMsg))
        {
            myMS_Observatorios.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myMS_Observatorios, out sMsg))
        {
            myMS_Observatorios.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        myMS_Observatorios.Insert(globalInfo, dr);
        myMS_Observatorios.Dispose();
        dr = null;
        globalInfo = null;
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, int? varClave, int? varObservatorio)
    {
        MS_ObservatoriosCS.objectBussinessMS_Observatorios  myMS_Observatorios= new MS_ObservatoriosCS.objectBussinessMS_Observatorios();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myMS_Observatorios.Clave = varClave;
        myMS_Observatorios.Observatorio = varObservatorio;

        String sMsg = "";
        if (!ValidaDataToSave(myMS_Observatorios, out sMsg))
        {
            myMS_Observatorios.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myMS_Observatorios, out sMsg))
        {
            myMS_Observatorios.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        object result=myMS_Observatorios.InsertWithReturnValue(globalInfo, dr);
        myMS_Observatorios.Dispose();
        dr = null;
        globalInfo = null;
        return result;
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varClave, int? varObservatorio)
    {
        MS_ObservatoriosCS.objectBussinessMS_Observatorios myMS_Observatorios = new MS_ObservatoriosCS.objectBussinessMS_Observatorios();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myMS_Observatorios.Clave = varClave;
        myMS_Observatorios.Observatorio = varObservatorio;

            String sMsg = "";
            if (!ValidaDataToSave(myMS_Observatorios, out sMsg))
            {
                myMS_Observatorios.Dispose();
                dr = null;
                globalInfo = null;
                throw new Exception(sMsg);
            }
            myMS_Observatorios.Update(globalInfo, dr);
            myMS_Observatorios.Dispose();
            dr = null;
            globalInfo = null;
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyClave, int? KeyObservatorio)
    {
        MS_ObservatoriosCS.objectBussinessMS_Observatorios myMS_Observatorios = new MS_ObservatoriosCS.objectBussinessMS_Observatorios();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        bool result = myMS_Observatorios.Delete(KeyClave, KeyObservatorio, globalInfo, dr);
        myMS_Observatorios.Dispose();
        dr = null;
        return result;
    }

    [WebMethod]
    public MS_ObservatoriosCS.objectBussinessMS_Observatorios GetByKey(int? KeyClave, int? KeyObservatorio, Boolean ConRelaciones)
    {
        MS_ObservatoriosCS.objectBussinessMS_Observatorios myMS_Observatorios = new MS_ObservatoriosCS.objectBussinessMS_Observatorios();
        myMS_Observatorios.GetByKey(KeyClave, KeyObservatorio, ConRelaciones);;
        return myMS_Observatorios;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyClave, int? KeyObservatorio)
    {
        MS_ObservatoriosCS.objectBussinessMS_Observatorios myMS_Observatorios = new MS_ObservatoriosCS.objectBussinessMS_Observatorios();
        Int32 result = myMS_Observatorios.CurrentPosicion(KeyClave, KeyObservatorio);
        return result;
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyClave, int? KeyObservatorio)
    {
        MS_ObservatoriosCS.objectBussinessMS_Observatorios myMS_Observatorios = new MS_ObservatoriosCS.objectBussinessMS_Observatorios();
        Boolean result = myMS_Observatorios.ValidaExistencia(KeyClave, KeyObservatorio);
        myMS_Observatorios.Dispose();
        return result;
    }

    private bool ValidaDataToSave(MS_ObservatoriosCS.objectBussinessMS_Observatorios MyDataMS_Observatorios, out String sMsg)
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

    public bool ValidaDataDuplication(MS_ObservatoriosCS.objectBussinessMS_Observatorios MyDataMS_Observatorios, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataMS_Observatorios.Clave != null&& MyDataMS_Observatorios.Observatorio != null)
        {
            if (MyDataMS_Observatorios.ValidaExistencia(MyDataMS_Observatorios.Clave, MyDataMS_Observatorios.Observatorio))
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
    public DataSet FillDataClave(String sFiltro)
    {
        MS_ObservatoriosCS.objectBussinessMS_Observatorios myMS_Observatorios = new MS_ObservatoriosCS.objectBussinessMS_Observatorios();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myMS_Observatorios.FillDataClave().Copy());
        else
            ds.Tables.Add(myMS_Observatorios.FillDataClave(sFiltro).Copy());
        myMS_Observatorios.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataClaveCDD(string knownCategoryValues, string category)
    {
        MS_ObservatoriosCS.objectBussinessMS_Observatorios myMS_Observatorios = new MS_ObservatoriosCS.objectBussinessMS_Observatorios();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myMS_Observatorios.FillDataClave();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Folio"].ToString(), dRow["Folio"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myMS_Observatorios.Dispose();
        return values.ToArray();
    }    [WebMethod]
    public DataSet FillDataObservatorio(String sFiltro)
    {
        MS_ObservatoriosCS.objectBussinessMS_Observatorios myMS_Observatorios = new MS_ObservatoriosCS.objectBussinessMS_Observatorios();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myMS_Observatorios.FillDataObservatorio().Copy());
        else
            ds.Tables.Add(myMS_Observatorios.FillDataObservatorio(sFiltro).Copy());
        myMS_Observatorios.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataObservatorioCDD(string knownCategoryValues, string category)
    {
        MS_ObservatoriosCS.objectBussinessMS_Observatorios myMS_Observatorios = new MS_ObservatoriosCS.objectBussinessMS_Observatorios();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myMS_Observatorios.FillDataObservatorio();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["Clave"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myMS_Observatorios.Dispose();
        return values.ToArray();
    }
}
