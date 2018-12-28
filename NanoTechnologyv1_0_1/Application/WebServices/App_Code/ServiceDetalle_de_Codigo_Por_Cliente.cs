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
public class objectBussinessDetalle_de_Codigo_Por_Cliente : System.Web.Services.WebService
{
    public int iProcess = 30072;
    private TTTraductor.Traductor MyTraductor;
    


    [WebMethod]
    public string ListaGetFullQuery(string sWhere,string sOrder)
    {
	Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente myDetalle_de_Codigo_Por_Cliente = new Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente();
        string result = myDetalle_de_Codigo_Por_Cliente.GetFullQuery(sWhere, sOrder);
	myDetalle_de_Codigo_Por_Cliente.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ListaSelAll(int startRowIndex,int maximumRows,string where,string Order)
    {
	Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente myDetalle_de_Codigo_Por_Cliente = new Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente();
        DataSet result = myDetalle_de_Codigo_Por_Cliente.SelAll(startRowIndex, maximumRows, where, Order);
	myDetalle_de_Codigo_Por_Cliente.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ImpresionSelAll(string where, string Order)
    {
	Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente myDetalle_de_Codigo_Por_Cliente = new Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente();
        DataSet result = myDetalle_de_Codigo_Por_Cliente.SelAll(where, Order);
	myDetalle_de_Codigo_Por_Cliente.Dispose();
        return result;
    }

    [WebMethod]
    public int ListaSelCount(string where)
    {
	Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente myDetalle_de_Codigo_Por_Cliente = new Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente();
        int result = myDetalle_de_Codigo_Por_Cliente.SelCount(where);
	myDetalle_de_Codigo_Por_Cliente.Dispose();
        return result;
    }


    [WebMethod]
    public Int32 SelCount()
    {
	Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente myDetalle_de_Codigo_Por_Cliente = new Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente();
        Int32 result = myDetalle_de_Codigo_Por_Cliente.SelCount();
	myDetalle_de_Codigo_Por_Cliente.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
	Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente myDetalle_de_Codigo_Por_Cliente = new Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente();
        DataSet result = myDetalle_de_Codigo_Por_Cliente.SelAll(ConRelaciones);
	myDetalle_de_Codigo_Por_Cliente.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, Detalle_de_Codigo_Por_ClienteCS.Detalle_de_Codigo_Por_ClienteFilters[] myFilters)
    {
        Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente myDetalle_de_Codigo_Por_Cliente = new Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente();
        myDetalle_de_Codigo_Por_Cliente.Filters = myFilters;
        DataSet result = myDetalle_de_Codigo_Por_Cliente.SelAll(ConRelaciones);
        myDetalle_de_Codigo_Por_Cliente.Filters = null;
        myDetalle_de_Codigo_Por_Cliente.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente myDetalle_de_Codigo_Por_Cliente = new Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente();
        DataSet ds = new DataSet();
        ds.Tables.Add(myDetalle_de_Codigo_Por_Cliente.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        myDetalle_de_Codigo_Por_Cliente.Dispose(); 
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varCliente, int? varObservatorio, String varCodigo, int? varEstatus, DateTime? varExpiracion, int? varAccesos)
    {
        Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente  myDetalle_de_Codigo_Por_Cliente = new Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myDetalle_de_Codigo_Por_Cliente.Cliente = varCliente;
        myDetalle_de_Codigo_Por_Cliente.Observatorio = varObservatorio;
        myDetalle_de_Codigo_Por_Cliente.Codigo = varCodigo;
        myDetalle_de_Codigo_Por_Cliente.Estatus = varEstatus;
        myDetalle_de_Codigo_Por_Cliente.Expiracion = varExpiracion;
        myDetalle_de_Codigo_Por_Cliente.Accesos = varAccesos;

        String sMsg = "";
        if (!ValidaDataToSave(myDetalle_de_Codigo_Por_Cliente, out sMsg))
        {
            myDetalle_de_Codigo_Por_Cliente.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myDetalle_de_Codigo_Por_Cliente, out sMsg))
        {
            myDetalle_de_Codigo_Por_Cliente.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        myDetalle_de_Codigo_Por_Cliente.Insert(globalInfo, dr);
        myDetalle_de_Codigo_Por_Cliente.Dispose();
        dr = null;
        globalInfo = null;
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, int? varCliente, int? varObservatorio, String varCodigo, int? varEstatus, DateTime? varExpiracion, int? varAccesos)
    {
        Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente  myDetalle_de_Codigo_Por_Cliente= new Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myDetalle_de_Codigo_Por_Cliente.Cliente = varCliente;
        myDetalle_de_Codigo_Por_Cliente.Observatorio = varObservatorio;
        myDetalle_de_Codigo_Por_Cliente.Codigo = varCodigo;
        myDetalle_de_Codigo_Por_Cliente.Estatus = varEstatus;
        myDetalle_de_Codigo_Por_Cliente.Expiracion = varExpiracion;
        myDetalle_de_Codigo_Por_Cliente.Accesos = varAccesos;

        String sMsg = "";
        if (!ValidaDataToSave(myDetalle_de_Codigo_Por_Cliente, out sMsg))
        {
            myDetalle_de_Codigo_Por_Cliente.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myDetalle_de_Codigo_Por_Cliente, out sMsg))
        {
            myDetalle_de_Codigo_Por_Cliente.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        object result=myDetalle_de_Codigo_Por_Cliente.InsertWithReturnValue(globalInfo, dr);
        myDetalle_de_Codigo_Por_Cliente.Dispose();
        dr = null;
        globalInfo = null;
        return result;
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varClave, int? varCliente, int? varObservatorio, String varCodigo, int? varEstatus, DateTime? varExpiracion, int? varAccesos)
    {
        Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente myDetalle_de_Codigo_Por_Cliente = new Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myDetalle_de_Codigo_Por_Cliente.Clave = varClave;
        myDetalle_de_Codigo_Por_Cliente.Cliente = varCliente;
        myDetalle_de_Codigo_Por_Cliente.Observatorio = varObservatorio;
        myDetalle_de_Codigo_Por_Cliente.Codigo = varCodigo;
        myDetalle_de_Codigo_Por_Cliente.Estatus = varEstatus;
        myDetalle_de_Codigo_Por_Cliente.Expiracion = varExpiracion;
        myDetalle_de_Codigo_Por_Cliente.Accesos = varAccesos;

            String sMsg = "";
            if (!ValidaDataToSave(myDetalle_de_Codigo_Por_Cliente, out sMsg))
            {
                myDetalle_de_Codigo_Por_Cliente.Dispose();
                dr = null;
                globalInfo = null;
                throw new Exception(sMsg);
            }
            myDetalle_de_Codigo_Por_Cliente.Update(globalInfo, dr);
            myDetalle_de_Codigo_Por_Cliente.Dispose();
            dr = null;
            globalInfo = null;
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyClave, int? KeyCliente)
    {
        Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente myDetalle_de_Codigo_Por_Cliente = new Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        bool result = myDetalle_de_Codigo_Por_Cliente.Delete(KeyClave, KeyCliente, globalInfo, dr);
        myDetalle_de_Codigo_Por_Cliente.Dispose();
        dr = null;
        return result;
    }

    [WebMethod]
    public Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente GetByKey(int? KeyClave, int? KeyCliente, Boolean ConRelaciones)
    {
        Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente myDetalle_de_Codigo_Por_Cliente = new Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente();
        myDetalle_de_Codigo_Por_Cliente.GetByKey(KeyClave, KeyCliente, ConRelaciones);;
        return myDetalle_de_Codigo_Por_Cliente;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyClave, int? KeyCliente)
    {
        Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente myDetalle_de_Codigo_Por_Cliente = new Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente();
        Int32 result = myDetalle_de_Codigo_Por_Cliente.CurrentPosicion(KeyClave, KeyCliente);
        return result;
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyClave, int? KeyCliente)
    {
        Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente myDetalle_de_Codigo_Por_Cliente = new Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente();
        Boolean result = myDetalle_de_Codigo_Por_Cliente.ValidaExistencia(KeyClave, KeyCliente);
        myDetalle_de_Codigo_Por_Cliente.Dispose();
        return result;
    }

    private bool ValidaDataToSave(Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente MyDataDetalle_de_Codigo_Por_Cliente, out String sMsg)
    {
        //Validaciones
        sMsg = "";
            if (MyDataDetalle_de_Codigo_Por_Cliente.Observatorio != null)
            {
                ObservatorioCS.objectBussinessObservatorio MyDataObservatorioTemp = new ObservatorioCS.objectBussinessObservatorio();
                if (!MyDataObservatorioTemp.ValidaExistencia(MyDataDetalle_de_Codigo_Por_Cliente.Observatorio))
                {
                    sMsg = sMsg + "El Campo Observatorio no existe\n";
                }
            }
            if (MyDataDetalle_de_Codigo_Por_Cliente.Estatus != null)
            {
                Estatus_CodigoCS.objectBussinessEstatus_Codigo MyDataEstatus_CodigoTemp = new Estatus_CodigoCS.objectBussinessEstatus_Codigo();
                if (!MyDataEstatus_CodigoTemp.ValidaExistencia(MyDataDetalle_de_Codigo_Por_Cliente.Estatus))
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

    public bool ValidaDataDuplication(Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente MyDataDetalle_de_Codigo_Por_Cliente, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataDetalle_de_Codigo_Por_Cliente.Clave == -1&& MyDataDetalle_de_Codigo_Por_Cliente.Cliente != null)
        {
            if (MyDataDetalle_de_Codigo_Por_Cliente.ValidaExistencia(MyDataDetalle_de_Codigo_Por_Cliente.Clave, MyDataDetalle_de_Codigo_Por_Cliente.Cliente))
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
    public DataSet FillDataCliente(String sFiltro)
    {
        Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente myDetalle_de_Codigo_Por_Cliente = new Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myDetalle_de_Codigo_Por_Cliente.FillDataCliente().Copy());
        else
            ds.Tables.Add(myDetalle_de_Codigo_Por_Cliente.FillDataCliente(sFiltro).Copy());
        myDetalle_de_Codigo_Por_Cliente.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataClienteCDD(string knownCategoryValues, string category)
    {
        Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente myDetalle_de_Codigo_Por_Cliente = new Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myDetalle_de_Codigo_Por_Cliente.FillDataCliente();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Folio"].ToString(), dRow["Folio"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myDetalle_de_Codigo_Por_Cliente.Dispose();
        return values.ToArray();
    }    [WebMethod]
    public DataSet FillDataObservatorio(String sFiltro)
    {
        Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente myDetalle_de_Codigo_Por_Cliente = new Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myDetalle_de_Codigo_Por_Cliente.FillDataObservatorio().Copy());
        else
            ds.Tables.Add(myDetalle_de_Codigo_Por_Cliente.FillDataObservatorio(sFiltro).Copy());
        myDetalle_de_Codigo_Por_Cliente.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataObservatorioCDD(string knownCategoryValues, string category)
    {
        Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente myDetalle_de_Codigo_Por_Cliente = new Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myDetalle_de_Codigo_Por_Cliente.FillDataObservatorio();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["Clave"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myDetalle_de_Codigo_Por_Cliente.Dispose();
        return values.ToArray();
    }    [WebMethod]
    public DataSet FillDataEstatus(String sFiltro)
    {
        Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente myDetalle_de_Codigo_Por_Cliente = new Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myDetalle_de_Codigo_Por_Cliente.FillDataEstatus().Copy());
        else
            ds.Tables.Add(myDetalle_de_Codigo_Por_Cliente.FillDataEstatus(sFiltro).Copy());
        myDetalle_de_Codigo_Por_Cliente.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataEstatusCDD(string knownCategoryValues, string category)
    {
        Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente myDetalle_de_Codigo_Por_Cliente = new Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myDetalle_de_Codigo_Por_Cliente.FillDataEstatus();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Descripcion"].ToString(), dRow["Clave"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myDetalle_de_Codigo_Por_Cliente.Dispose();
        return values.ToArray();
    }
}
