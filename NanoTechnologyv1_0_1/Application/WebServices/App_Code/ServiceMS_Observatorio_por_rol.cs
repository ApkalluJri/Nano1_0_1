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
public class objectBussinessMS_Observatorio_por_rol : System.Web.Services.WebService
{
    public int iProcess = 30401;
    private TTTraductor.Traductor MyTraductor;
    


    [WebMethod]
    public string ListaGetFullQuery(string sWhere,string sOrder)
    {
	MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol myMS_Observatorio_por_rol = new MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol();
        string result = myMS_Observatorio_por_rol.GetFullQuery(sWhere, sOrder);
	myMS_Observatorio_por_rol.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ListaSelAll(int startRowIndex,int maximumRows,string where,string Order)
    {
	MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol myMS_Observatorio_por_rol = new MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol();
        DataSet result = myMS_Observatorio_por_rol.SelAll(startRowIndex, maximumRows, where, Order);
	myMS_Observatorio_por_rol.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ImpresionSelAll(string where, string Order)
    {
	MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol myMS_Observatorio_por_rol = new MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol();
        DataSet result = myMS_Observatorio_por_rol.SelAll(where, Order);
	myMS_Observatorio_por_rol.Dispose();
        return result;
    }

    [WebMethod]
    public int ListaSelCount(string where)
    {
	MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol myMS_Observatorio_por_rol = new MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol();
        int result = myMS_Observatorio_por_rol.SelCount(where);
	myMS_Observatorio_por_rol.Dispose();
        return result;
    }


    [WebMethod]
    public Int32 SelCount()
    {
	MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol myMS_Observatorio_por_rol = new MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol();
        Int32 result = myMS_Observatorio_por_rol.SelCount();
	myMS_Observatorio_por_rol.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
	MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol myMS_Observatorio_por_rol = new MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol();
        DataSet result = myMS_Observatorio_por_rol.SelAll(ConRelaciones);
	myMS_Observatorio_por_rol.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, MS_Observatorio_por_rolCS.MS_Observatorio_por_rolFilters[] myFilters)
    {
        MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol myMS_Observatorio_por_rol = new MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol();
        myMS_Observatorio_por_rol.Filters = myFilters;
        DataSet result = myMS_Observatorio_por_rol.SelAll(ConRelaciones);
        myMS_Observatorio_por_rol.Filters = null;
        myMS_Observatorio_por_rol.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol myMS_Observatorio_por_rol = new MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol();
        DataSet ds = new DataSet();
        ds.Tables.Add(myMS_Observatorio_por_rol.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        myMS_Observatorio_por_rol.Dispose(); 
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varClave, int? varObservatorio)
    {
        MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol  myMS_Observatorio_por_rol = new MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myMS_Observatorio_por_rol.Clave = varClave;
        myMS_Observatorio_por_rol.Observatorio = varObservatorio;

        String sMsg = "";
        if (!ValidaDataToSave(myMS_Observatorio_por_rol, out sMsg))
        {
            myMS_Observatorio_por_rol.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myMS_Observatorio_por_rol, out sMsg))
        {
            myMS_Observatorio_por_rol.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        myMS_Observatorio_por_rol.Insert(globalInfo, dr);
        myMS_Observatorio_por_rol.Dispose();
        dr = null;
        globalInfo = null;
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, int? varClave, int? varObservatorio)
    {
        MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol  myMS_Observatorio_por_rol= new MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myMS_Observatorio_por_rol.Clave = varClave;
        myMS_Observatorio_por_rol.Observatorio = varObservatorio;

        String sMsg = "";
        if (!ValidaDataToSave(myMS_Observatorio_por_rol, out sMsg))
        {
            myMS_Observatorio_por_rol.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myMS_Observatorio_por_rol, out sMsg))
        {
            myMS_Observatorio_por_rol.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        object result=myMS_Observatorio_por_rol.InsertWithReturnValue(globalInfo, dr);
        myMS_Observatorio_por_rol.Dispose();
        dr = null;
        globalInfo = null;
        return result;
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varClave, int? varObservatorio)
    {
        MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol myMS_Observatorio_por_rol = new MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myMS_Observatorio_por_rol.Clave = varClave;
        myMS_Observatorio_por_rol.Observatorio = varObservatorio;

            String sMsg = "";
            if (!ValidaDataToSave(myMS_Observatorio_por_rol, out sMsg))
            {
                myMS_Observatorio_por_rol.Dispose();
                dr = null;
                globalInfo = null;
                throw new Exception(sMsg);
            }
            myMS_Observatorio_por_rol.Update(globalInfo, dr);
            myMS_Observatorio_por_rol.Dispose();
            dr = null;
            globalInfo = null;
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyClave, int? KeyObservatorio)
    {
        MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol myMS_Observatorio_por_rol = new MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        bool result = myMS_Observatorio_por_rol.Delete(KeyClave, KeyObservatorio, globalInfo, dr);
        myMS_Observatorio_por_rol.Dispose();
        dr = null;
        return result;
    }

    [WebMethod]
    public MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol GetByKey(int? KeyClave, int? KeyObservatorio, Boolean ConRelaciones)
    {
        MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol myMS_Observatorio_por_rol = new MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol();
        myMS_Observatorio_por_rol.GetByKey(KeyClave, KeyObservatorio, ConRelaciones);;
        return myMS_Observatorio_por_rol;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyClave, int? KeyObservatorio)
    {
        MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol myMS_Observatorio_por_rol = new MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol();
        Int32 result = myMS_Observatorio_por_rol.CurrentPosicion(KeyClave, KeyObservatorio);
        return result;
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyClave, int? KeyObservatorio)
    {
        MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol myMS_Observatorio_por_rol = new MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol();
        Boolean result = myMS_Observatorio_por_rol.ValidaExistencia(KeyClave, KeyObservatorio);
        myMS_Observatorio_por_rol.Dispose();
        return result;
    }

    private bool ValidaDataToSave(MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol MyDataMS_Observatorio_por_rol, out String sMsg)
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

    public bool ValidaDataDuplication(MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol MyDataMS_Observatorio_por_rol, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataMS_Observatorio_por_rol.Clave != null&& MyDataMS_Observatorio_por_rol.Observatorio != null)
        {
            if (MyDataMS_Observatorio_por_rol.ValidaExistencia(MyDataMS_Observatorio_por_rol.Clave, MyDataMS_Observatorio_por_rol.Observatorio))
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
        MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol myMS_Observatorio_por_rol = new MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myMS_Observatorio_por_rol.FillDataClave().Copy());
        else
            ds.Tables.Add(myMS_Observatorio_por_rol.FillDataClave(sFiltro).Copy());
        myMS_Observatorio_por_rol.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataClaveCDD(string knownCategoryValues, string category)
    {
        MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol myMS_Observatorio_por_rol = new MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myMS_Observatorio_por_rol.FillDataClave();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Folio"].ToString(), dRow["Folio"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myMS_Observatorio_por_rol.Dispose();
        return values.ToArray();
    }    [WebMethod]
    public DataSet FillDataObservatorio(String sFiltro)
    {
        MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol myMS_Observatorio_por_rol = new MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myMS_Observatorio_por_rol.FillDataObservatorio().Copy());
        else
            ds.Tables.Add(myMS_Observatorio_por_rol.FillDataObservatorio(sFiltro).Copy());
        myMS_Observatorio_por_rol.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataObservatorioCDD(string knownCategoryValues, string category)
    {
        MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol myMS_Observatorio_por_rol = new MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myMS_Observatorio_por_rol.FillDataObservatorio();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["Clave"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myMS_Observatorio_por_rol.Dispose();
        return values.ToArray();
    }
}
