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
public class objectBussinessDetalle_de_Observatorio_Privado : System.Web.Services.WebService
{
    public int iProcess = 29986;
    private TTTraductor.Traductor MyTraductor;
    


    [WebMethod]
    public string ListaGetFullQuery(string sWhere,string sOrder)
    {
	Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado myDetalle_de_Observatorio_Privado = new Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado();
        string result = myDetalle_de_Observatorio_Privado.GetFullQuery(sWhere, sOrder);
	myDetalle_de_Observatorio_Privado.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ListaSelAll(int startRowIndex,int maximumRows,string where,string Order)
    {
	Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado myDetalle_de_Observatorio_Privado = new Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado();
        DataSet result = myDetalle_de_Observatorio_Privado.SelAll(startRowIndex, maximumRows, where, Order);
	myDetalle_de_Observatorio_Privado.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ImpresionSelAll(string where, string Order)
    {
	Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado myDetalle_de_Observatorio_Privado = new Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado();
        DataSet result = myDetalle_de_Observatorio_Privado.SelAll(where, Order);
	myDetalle_de_Observatorio_Privado.Dispose();
        return result;
    }

    [WebMethod]
    public int ListaSelCount(string where)
    {
	Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado myDetalle_de_Observatorio_Privado = new Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado();
        int result = myDetalle_de_Observatorio_Privado.SelCount(where);
	myDetalle_de_Observatorio_Privado.Dispose();
        return result;
    }


    [WebMethod]
    public Int32 SelCount()
    {
	Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado myDetalle_de_Observatorio_Privado = new Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado();
        Int32 result = myDetalle_de_Observatorio_Privado.SelCount();
	myDetalle_de_Observatorio_Privado.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
	Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado myDetalle_de_Observatorio_Privado = new Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado();
        DataSet result = myDetalle_de_Observatorio_Privado.SelAll(ConRelaciones);
	myDetalle_de_Observatorio_Privado.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, Detalle_de_Observatorio_PrivadoCS.Detalle_de_Observatorio_PrivadoFilters[] myFilters)
    {
        Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado myDetalle_de_Observatorio_Privado = new Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado();
        myDetalle_de_Observatorio_Privado.Filters = myFilters;
        DataSet result = myDetalle_de_Observatorio_Privado.SelAll(ConRelaciones);
        myDetalle_de_Observatorio_Privado.Filters = null;
        myDetalle_de_Observatorio_Privado.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado myDetalle_de_Observatorio_Privado = new Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado();
        DataSet ds = new DataSet();
        ds.Tables.Add(myDetalle_de_Observatorio_Privado.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        myDetalle_de_Observatorio_Privado.Dispose(); 
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varObservatorio, String varCodigo, int? varEstatus, DateTime? varExpiracion, int? varAccesos)
    {
        Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado  myDetalle_de_Observatorio_Privado = new Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myDetalle_de_Observatorio_Privado.Observatorio = varObservatorio;
        myDetalle_de_Observatorio_Privado.Codigo = varCodigo;
        myDetalle_de_Observatorio_Privado.Estatus = varEstatus;
        myDetalle_de_Observatorio_Privado.Expiracion = varExpiracion;
        myDetalle_de_Observatorio_Privado.Accesos = varAccesos;

        String sMsg = "";
        if (!ValidaDataToSave(myDetalle_de_Observatorio_Privado, out sMsg))
        {
            myDetalle_de_Observatorio_Privado.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myDetalle_de_Observatorio_Privado, out sMsg))
        {
            myDetalle_de_Observatorio_Privado.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        myDetalle_de_Observatorio_Privado.Insert(globalInfo, dr);
        myDetalle_de_Observatorio_Privado.Dispose();
        dr = null;
        globalInfo = null;
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, int? varObservatorio, String varCodigo, int? varEstatus, DateTime? varExpiracion, int? varAccesos)
    {
        Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado  myDetalle_de_Observatorio_Privado= new Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myDetalle_de_Observatorio_Privado.Observatorio = varObservatorio;
        myDetalle_de_Observatorio_Privado.Codigo = varCodigo;
        myDetalle_de_Observatorio_Privado.Estatus = varEstatus;
        myDetalle_de_Observatorio_Privado.Expiracion = varExpiracion;
        myDetalle_de_Observatorio_Privado.Accesos = varAccesos;

        String sMsg = "";
        if (!ValidaDataToSave(myDetalle_de_Observatorio_Privado, out sMsg))
        {
            myDetalle_de_Observatorio_Privado.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myDetalle_de_Observatorio_Privado, out sMsg))
        {
            myDetalle_de_Observatorio_Privado.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        object result=myDetalle_de_Observatorio_Privado.InsertWithReturnValue(globalInfo, dr);
        myDetalle_de_Observatorio_Privado.Dispose();
        dr = null;
        globalInfo = null;
        return result;
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varClave, int? varObservatorio, String varCodigo, int? varEstatus, DateTime? varExpiracion, int? varAccesos)
    {
        Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado myDetalle_de_Observatorio_Privado = new Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myDetalle_de_Observatorio_Privado.Clave = varClave;
        myDetalle_de_Observatorio_Privado.Observatorio = varObservatorio;
        myDetalle_de_Observatorio_Privado.Codigo = varCodigo;
        myDetalle_de_Observatorio_Privado.Estatus = varEstatus;
        myDetalle_de_Observatorio_Privado.Expiracion = varExpiracion;
        myDetalle_de_Observatorio_Privado.Accesos = varAccesos;

            String sMsg = "";
            if (!ValidaDataToSave(myDetalle_de_Observatorio_Privado, out sMsg))
            {
                myDetalle_de_Observatorio_Privado.Dispose();
                dr = null;
                globalInfo = null;
                throw new Exception(sMsg);
            }
            myDetalle_de_Observatorio_Privado.Update(globalInfo, dr);
            myDetalle_de_Observatorio_Privado.Dispose();
            dr = null;
            globalInfo = null;
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyClave, int? KeyObservatorio)
    {
        Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado myDetalle_de_Observatorio_Privado = new Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        bool result = myDetalle_de_Observatorio_Privado.Delete(KeyClave, KeyObservatorio, globalInfo, dr);
        myDetalle_de_Observatorio_Privado.Dispose();
        dr = null;
        return result;
    }

    [WebMethod]
    public Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado GetByKey(int? KeyClave, int? KeyObservatorio, Boolean ConRelaciones)
    {
        Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado myDetalle_de_Observatorio_Privado = new Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado();
        myDetalle_de_Observatorio_Privado.GetByKey(KeyClave, KeyObservatorio, ConRelaciones);;
        return myDetalle_de_Observatorio_Privado;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyClave, int? KeyObservatorio)
    {
        Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado myDetalle_de_Observatorio_Privado = new Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado();
        Int32 result = myDetalle_de_Observatorio_Privado.CurrentPosicion(KeyClave, KeyObservatorio);
        return result;
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyClave, int? KeyObservatorio)
    {
        Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado myDetalle_de_Observatorio_Privado = new Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado();
        Boolean result = myDetalle_de_Observatorio_Privado.ValidaExistencia(KeyClave, KeyObservatorio);
        myDetalle_de_Observatorio_Privado.Dispose();
        return result;
    }

    private bool ValidaDataToSave(Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado MyDataDetalle_de_Observatorio_Privado, out String sMsg)
    {
        //Validaciones
        sMsg = "";
            if (MyDataDetalle_de_Observatorio_Privado.Estatus != null)
            {
                Estatus_CodigoCS.objectBussinessEstatus_Codigo MyDataEstatus_CodigoTemp = new Estatus_CodigoCS.objectBussinessEstatus_Codigo();
                if (!MyDataEstatus_CodigoTemp.ValidaExistencia(MyDataDetalle_de_Observatorio_Privado.Estatus))
                {
                    sMsg = sMsg + "El Campo Estatus no existe\n";
                }
            }

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

    public bool ValidaDataDuplication(Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado MyDataDetalle_de_Observatorio_Privado, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataDetalle_de_Observatorio_Privado.Clave == -1&& MyDataDetalle_de_Observatorio_Privado.Observatorio != null)
        {
            if (MyDataDetalle_de_Observatorio_Privado.ValidaExistencia(MyDataDetalle_de_Observatorio_Privado.Clave, MyDataDetalle_de_Observatorio_Privado.Observatorio))
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
    public DataSet FillDataObservatorio(String sFiltro)
    {
        Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado myDetalle_de_Observatorio_Privado = new Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myDetalle_de_Observatorio_Privado.FillDataObservatorio().Copy());
        else
            ds.Tables.Add(myDetalle_de_Observatorio_Privado.FillDataObservatorio(sFiltro).Copy());
        myDetalle_de_Observatorio_Privado.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataObservatorioCDD(string knownCategoryValues, string category)
    {
        Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado myDetalle_de_Observatorio_Privado = new Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myDetalle_de_Observatorio_Privado.FillDataObservatorio();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Clave"].ToString(), dRow["Clave"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myDetalle_de_Observatorio_Privado.Dispose();
        return values.ToArray();
    }    [WebMethod]
    public DataSet FillDataEstatus(String sFiltro)
    {
        Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado myDetalle_de_Observatorio_Privado = new Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myDetalle_de_Observatorio_Privado.FillDataEstatus().Copy());
        else
            ds.Tables.Add(myDetalle_de_Observatorio_Privado.FillDataEstatus(sFiltro).Copy());
        myDetalle_de_Observatorio_Privado.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataEstatusCDD(string knownCategoryValues, string category)
    {
        Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado myDetalle_de_Observatorio_Privado = new Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myDetalle_de_Observatorio_Privado.FillDataEstatus();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Descripcion"].ToString(), dRow["Clave"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myDetalle_de_Observatorio_Privado.Dispose();
        return values.ToArray();
    }
}
