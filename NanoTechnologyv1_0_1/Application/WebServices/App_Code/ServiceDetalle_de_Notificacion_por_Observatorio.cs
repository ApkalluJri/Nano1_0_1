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
public class objectBussinessDetalle_de_Notificacion_por_Observatorio : System.Web.Services.WebService
{
    public int iProcess = 31010;
    private TTTraductor.Traductor MyTraductor;
    


    [WebMethod]
    public string ListaGetFullQuery(string sWhere,string sOrder)
    {
	Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio myDetalle_de_Notificacion_por_Observatorio = new Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio();
        string result = myDetalle_de_Notificacion_por_Observatorio.GetFullQuery(sWhere, sOrder);
	myDetalle_de_Notificacion_por_Observatorio.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ListaSelAll(int startRowIndex,int maximumRows,string where,string Order)
    {
	Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio myDetalle_de_Notificacion_por_Observatorio = new Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio();
        DataSet result = myDetalle_de_Notificacion_por_Observatorio.SelAll(startRowIndex, maximumRows, where, Order);
	myDetalle_de_Notificacion_por_Observatorio.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ImpresionSelAll(string where, string Order)
    {
	Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio myDetalle_de_Notificacion_por_Observatorio = new Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio();
        DataSet result = myDetalle_de_Notificacion_por_Observatorio.SelAll(where, Order);
	myDetalle_de_Notificacion_por_Observatorio.Dispose();
        return result;
    }

    [WebMethod]
    public int ListaSelCount(string where)
    {
	Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio myDetalle_de_Notificacion_por_Observatorio = new Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio();
        int result = myDetalle_de_Notificacion_por_Observatorio.SelCount(where);
	myDetalle_de_Notificacion_por_Observatorio.Dispose();
        return result;
    }


    [WebMethod]
    public Int32 SelCount()
    {
	Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio myDetalle_de_Notificacion_por_Observatorio = new Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio();
        Int32 result = myDetalle_de_Notificacion_por_Observatorio.SelCount();
	myDetalle_de_Notificacion_por_Observatorio.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
	Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio myDetalle_de_Notificacion_por_Observatorio = new Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio();
        DataSet result = myDetalle_de_Notificacion_por_Observatorio.SelAll(ConRelaciones);
	myDetalle_de_Notificacion_por_Observatorio.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, Detalle_de_Notificacion_por_ObservatorioCS.Detalle_de_Notificacion_por_ObservatorioFilters[] myFilters)
    {
        Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio myDetalle_de_Notificacion_por_Observatorio = new Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio();
        myDetalle_de_Notificacion_por_Observatorio.Filters = myFilters;
        DataSet result = myDetalle_de_Notificacion_por_Observatorio.SelAll(ConRelaciones);
        myDetalle_de_Notificacion_por_Observatorio.Filters = null;
        myDetalle_de_Notificacion_por_Observatorio.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio myDetalle_de_Notificacion_por_Observatorio = new Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio();
        DataSet ds = new DataSet();
        ds.Tables.Add(myDetalle_de_Notificacion_por_Observatorio.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        myDetalle_de_Notificacion_por_Observatorio.Dispose(); 
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varContenido, Boolean varNotificar, int? varObservatorio)
    {
        Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio  myDetalle_de_Notificacion_por_Observatorio = new Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myDetalle_de_Notificacion_por_Observatorio.Contenido = varContenido;
        myDetalle_de_Notificacion_por_Observatorio.Notificar = varNotificar;
        myDetalle_de_Notificacion_por_Observatorio.Observatorio = varObservatorio;

        String sMsg = "";
        if (!ValidaDataToSave(myDetalle_de_Notificacion_por_Observatorio, out sMsg))
        {
            myDetalle_de_Notificacion_por_Observatorio.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myDetalle_de_Notificacion_por_Observatorio, out sMsg))
        {
            myDetalle_de_Notificacion_por_Observatorio.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        myDetalle_de_Notificacion_por_Observatorio.Insert(globalInfo, dr);
        myDetalle_de_Notificacion_por_Observatorio.Dispose();
        dr = null;
        globalInfo = null;
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, int? varContenido, Boolean varNotificar, int? varObservatorio)
    {
        Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio  myDetalle_de_Notificacion_por_Observatorio= new Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myDetalle_de_Notificacion_por_Observatorio.Contenido = varContenido;
        myDetalle_de_Notificacion_por_Observatorio.Notificar = varNotificar;
        myDetalle_de_Notificacion_por_Observatorio.Observatorio = varObservatorio;

        String sMsg = "";
        if (!ValidaDataToSave(myDetalle_de_Notificacion_por_Observatorio, out sMsg))
        {
            myDetalle_de_Notificacion_por_Observatorio.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myDetalle_de_Notificacion_por_Observatorio, out sMsg))
        {
            myDetalle_de_Notificacion_por_Observatorio.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        object result=myDetalle_de_Notificacion_por_Observatorio.InsertWithReturnValue(globalInfo, dr);
        myDetalle_de_Notificacion_por_Observatorio.Dispose();
        dr = null;
        globalInfo = null;
        return result;
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varClave, int? varContenido, Boolean varNotificar, int? varObservatorio)
    {
        Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio myDetalle_de_Notificacion_por_Observatorio = new Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myDetalle_de_Notificacion_por_Observatorio.Clave = varClave;
        myDetalle_de_Notificacion_por_Observatorio.Contenido = varContenido;
        myDetalle_de_Notificacion_por_Observatorio.Notificar = varNotificar;
        myDetalle_de_Notificacion_por_Observatorio.Observatorio = varObservatorio;

            String sMsg = "";
            if (!ValidaDataToSave(myDetalle_de_Notificacion_por_Observatorio, out sMsg))
            {
                myDetalle_de_Notificacion_por_Observatorio.Dispose();
                dr = null;
                globalInfo = null;
                throw new Exception(sMsg);
            }
            myDetalle_de_Notificacion_por_Observatorio.Update(globalInfo, dr);
            myDetalle_de_Notificacion_por_Observatorio.Dispose();
            dr = null;
            globalInfo = null;
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyClave, int? KeyContenido)
    {
        Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio myDetalle_de_Notificacion_por_Observatorio = new Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        bool result = myDetalle_de_Notificacion_por_Observatorio.Delete(KeyClave, KeyContenido, globalInfo, dr);
        myDetalle_de_Notificacion_por_Observatorio.Dispose();
        dr = null;
        return result;
    }

    [WebMethod]
    public Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio GetByKey(int? KeyClave, int? KeyContenido, Boolean ConRelaciones)
    {
        Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio myDetalle_de_Notificacion_por_Observatorio = new Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio();
        myDetalle_de_Notificacion_por_Observatorio.GetByKey(KeyClave, KeyContenido, ConRelaciones);;
        return myDetalle_de_Notificacion_por_Observatorio;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyClave, int? KeyContenido)
    {
        Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio myDetalle_de_Notificacion_por_Observatorio = new Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio();
        Int32 result = myDetalle_de_Notificacion_por_Observatorio.CurrentPosicion(KeyClave, KeyContenido);
        return result;
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyClave, int? KeyContenido)
    {
        Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio myDetalle_de_Notificacion_por_Observatorio = new Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio();
        Boolean result = myDetalle_de_Notificacion_por_Observatorio.ValidaExistencia(KeyClave, KeyContenido);
        myDetalle_de_Notificacion_por_Observatorio.Dispose();
        return result;
    }

    private bool ValidaDataToSave(Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio MyDataDetalle_de_Notificacion_por_Observatorio, out String sMsg)
    {
        //Validaciones
        sMsg = "";
            if (MyDataDetalle_de_Notificacion_por_Observatorio.Observatorio != null)
            {
                ObservatorioCS.objectBussinessObservatorio MyDataObservatorioTemp = new ObservatorioCS.objectBussinessObservatorio();
                if (!MyDataObservatorioTemp.ValidaExistencia(MyDataDetalle_de_Notificacion_por_Observatorio.Observatorio))
                {
                    sMsg = sMsg + "El Campo Observatorio no existe\n";
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

    public bool ValidaDataDuplication(Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio MyDataDetalle_de_Notificacion_por_Observatorio, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataDetalle_de_Notificacion_por_Observatorio.Clave == -1&& MyDataDetalle_de_Notificacion_por_Observatorio.Contenido != null)
        {
            if (MyDataDetalle_de_Notificacion_por_Observatorio.ValidaExistencia(MyDataDetalle_de_Notificacion_por_Observatorio.Clave, MyDataDetalle_de_Notificacion_por_Observatorio.Contenido))
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
    public DataSet FillDataContenido(String sFiltro)
    {
        Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio myDetalle_de_Notificacion_por_Observatorio = new Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myDetalle_de_Notificacion_por_Observatorio.FillDataContenido().Copy());
        else
            ds.Tables.Add(myDetalle_de_Notificacion_por_Observatorio.FillDataContenido(sFiltro).Copy());
        myDetalle_de_Notificacion_por_Observatorio.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataContenidoCDD(string knownCategoryValues, string category)
    {
        Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio myDetalle_de_Notificacion_por_Observatorio = new Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myDetalle_de_Notificacion_por_Observatorio.FillDataContenido();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Folio"].ToString(), dRow["Folio"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myDetalle_de_Notificacion_por_Observatorio.Dispose();
        return values.ToArray();
    }    [WebMethod]
    public DataSet FillDataObservatorio(String sFiltro)
    {
        Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio myDetalle_de_Notificacion_por_Observatorio = new Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myDetalle_de_Notificacion_por_Observatorio.FillDataObservatorio().Copy());
        else
            ds.Tables.Add(myDetalle_de_Notificacion_por_Observatorio.FillDataObservatorio(sFiltro).Copy());
        myDetalle_de_Notificacion_por_Observatorio.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataObservatorioCDD(string knownCategoryValues, string category)
    {
        Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio myDetalle_de_Notificacion_por_Observatorio = new Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myDetalle_de_Notificacion_por_Observatorio.FillDataObservatorio();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["Clave"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myDetalle_de_Notificacion_por_Observatorio.Dispose();
        return values.ToArray();
    }
}
