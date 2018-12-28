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
public class objectBussinessSolicitudes_Via_App : System.Web.Services.WebService
{
    public int iProcess = 29990;
    private TTTraductor.Traductor MyTraductor;
    


    [WebMethod]
    public string ListaGetFullQuery(string sWhere,string sOrder)
    {
	Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App mySolicitudes_Via_App = new Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App();
        string result = mySolicitudes_Via_App.GetFullQuery(sWhere, sOrder);
	mySolicitudes_Via_App.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ListaSelAll(int startRowIndex,int maximumRows,string where,string Order)
    {
	Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App mySolicitudes_Via_App = new Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App();
        DataSet result = mySolicitudes_Via_App.SelAll(startRowIndex, maximumRows, where, Order);
	mySolicitudes_Via_App.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ImpresionSelAll(string where, string Order)
    {
	Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App mySolicitudes_Via_App = new Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App();
        DataSet result = mySolicitudes_Via_App.SelAll(where, Order);
	mySolicitudes_Via_App.Dispose();
        return result;
    }

    [WebMethod]
    public int ListaSelCount(string where)
    {
	Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App mySolicitudes_Via_App = new Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App();
        int result = mySolicitudes_Via_App.SelCount(where);
	mySolicitudes_Via_App.Dispose();
        return result;
    }


    [WebMethod]
    public Int32 SelCount()
    {
	Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App mySolicitudes_Via_App = new Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App();
        Int32 result = mySolicitudes_Via_App.SelCount();
	mySolicitudes_Via_App.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
	Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App mySolicitudes_Via_App = new Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App();
        DataSet result = mySolicitudes_Via_App.SelAll(ConRelaciones);
	mySolicitudes_Via_App.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, Solicitudes_Via_AppCS.Solicitudes_Via_AppFilters[] myFilters)
    {
        Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App mySolicitudes_Via_App = new Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App();
        mySolicitudes_Via_App.Filters = myFilters;
        DataSet result = mySolicitudes_Via_App.SelAll(ConRelaciones);
        mySolicitudes_Via_App.Filters = null;
        mySolicitudes_Via_App.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App mySolicitudes_Via_App = new Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App();
        DataSet ds = new DataSet();
        ds.Tables.Add(mySolicitudes_Via_App.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        mySolicitudes_Via_App.Dispose(); 
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varUsuario_que_Registra, DateTime? varFecha_de_Registro, String varHora_de_Registro, String varNombre, String varCorreo, int? varOpcion, String varDescripcion, String varLada, String varTelefono, int? varEstatus, int? varObservatorio)
    {
        Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App  mySolicitudes_Via_App = new Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        mySolicitudes_Via_App.Usuario_que_Registra = varUsuario_que_Registra;
        mySolicitudes_Via_App.Fecha_de_Registro = varFecha_de_Registro;
        mySolicitudes_Via_App.Hora_de_Registro = varHora_de_Registro;
        mySolicitudes_Via_App.Nombre = varNombre;
        mySolicitudes_Via_App.Correo = varCorreo;
        mySolicitudes_Via_App.Opcion = varOpcion;
        mySolicitudes_Via_App.Descripcion = varDescripcion;
        mySolicitudes_Via_App.Lada = varLada;
        mySolicitudes_Via_App.Telefono = varTelefono;
        mySolicitudes_Via_App.Estatus = varEstatus;
        mySolicitudes_Via_App.Observatorio = varObservatorio;

        String sMsg = "";
        if (!ValidaDataToSave(mySolicitudes_Via_App, out sMsg))
        {
            mySolicitudes_Via_App.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(mySolicitudes_Via_App, out sMsg))
        {
            mySolicitudes_Via_App.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        mySolicitudes_Via_App.Insert(globalInfo, dr);
        mySolicitudes_Via_App.Dispose();
        dr = null;
        globalInfo = null;
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, int? varUsuario_que_Registra, DateTime? varFecha_de_Registro, String varHora_de_Registro, String varNombre, String varCorreo, int? varOpcion, String varDescripcion, String varLada, String varTelefono, int? varEstatus, int? varObservatorio)
    {
        Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App  mySolicitudes_Via_App= new Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        mySolicitudes_Via_App.Usuario_que_Registra = varUsuario_que_Registra;
        mySolicitudes_Via_App.Fecha_de_Registro = varFecha_de_Registro;
        mySolicitudes_Via_App.Hora_de_Registro = varHora_de_Registro;
        mySolicitudes_Via_App.Nombre = varNombre;
        mySolicitudes_Via_App.Correo = varCorreo;
        mySolicitudes_Via_App.Opcion = varOpcion;
        mySolicitudes_Via_App.Descripcion = varDescripcion;
        mySolicitudes_Via_App.Lada = varLada;
        mySolicitudes_Via_App.Telefono = varTelefono;
        mySolicitudes_Via_App.Estatus = varEstatus;
        mySolicitudes_Via_App.Observatorio = varObservatorio;

        String sMsg = "";
        if (!ValidaDataToSave(mySolicitudes_Via_App, out sMsg))
        {
            mySolicitudes_Via_App.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(mySolicitudes_Via_App, out sMsg))
        {
            mySolicitudes_Via_App.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        object result=mySolicitudes_Via_App.InsertWithReturnValue(globalInfo, dr);
        mySolicitudes_Via_App.Dispose();
        dr = null;
        globalInfo = null;
        return result;
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varFolio, int? varUsuario_que_Registra, DateTime? varFecha_de_Registro, String varHora_de_Registro, String varNombre, String varCorreo, int? varOpcion, String varDescripcion, String varLada, String varTelefono, int? varEstatus, int? varObservatorio)
    {
        Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App mySolicitudes_Via_App = new Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        mySolicitudes_Via_App.Folio = varFolio;
        mySolicitudes_Via_App.Usuario_que_Registra = varUsuario_que_Registra;
        mySolicitudes_Via_App.Fecha_de_Registro = varFecha_de_Registro;
        mySolicitudes_Via_App.Hora_de_Registro = varHora_de_Registro;
        mySolicitudes_Via_App.Nombre = varNombre;
        mySolicitudes_Via_App.Correo = varCorreo;
        mySolicitudes_Via_App.Opcion = varOpcion;
        mySolicitudes_Via_App.Descripcion = varDescripcion;
        mySolicitudes_Via_App.Lada = varLada;
        mySolicitudes_Via_App.Telefono = varTelefono;
        mySolicitudes_Via_App.Estatus = varEstatus;
        mySolicitudes_Via_App.Observatorio = varObservatorio;

            String sMsg = "";
            if (!ValidaDataToSave(mySolicitudes_Via_App, out sMsg))
            {
                mySolicitudes_Via_App.Dispose();
                dr = null;
                globalInfo = null;
                throw new Exception(sMsg);
            }
            mySolicitudes_Via_App.Update(globalInfo, dr);
            mySolicitudes_Via_App.Dispose();
            dr = null;
            globalInfo = null;
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyFolio)
    {
        Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App mySolicitudes_Via_App = new Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        bool result = mySolicitudes_Via_App.Delete(KeyFolio, globalInfo, dr);
        mySolicitudes_Via_App.Dispose();
        dr = null;
        return result;
    }

    [WebMethod]
    public Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App GetByKey(int? KeyFolio, Boolean ConRelaciones)
    {
        Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App mySolicitudes_Via_App = new Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App();
        mySolicitudes_Via_App.GetByKey(KeyFolio, ConRelaciones);;
        return mySolicitudes_Via_App;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyFolio)
    {
        Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App mySolicitudes_Via_App = new Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App();
        Int32 result = mySolicitudes_Via_App.CurrentPosicion(KeyFolio);
        return result;
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyFolio)
    {
        Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App mySolicitudes_Via_App = new Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App();
        Boolean result = mySolicitudes_Via_App.ValidaExistencia(KeyFolio);
        mySolicitudes_Via_App.Dispose();
        return result;
    }

    private bool ValidaDataToSave(Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App MyDataSolicitudes_Via_App, out String sMsg)
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

    public bool ValidaDataDuplication(Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App MyDataSolicitudes_Via_App, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataSolicitudes_Via_App.Folio == -1)
        {
            if (MyDataSolicitudes_Via_App.ValidaExistencia(MyDataSolicitudes_Via_App.Folio))
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
    public DataSet FillDataUsuario_que_Registra(String sFiltro)
    {
        Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App mySolicitudes_Via_App = new Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(mySolicitudes_Via_App.FillDataUsuario_que_Registra().Copy());
        else
            ds.Tables.Add(mySolicitudes_Via_App.FillDataUsuario_que_Registra(sFiltro).Copy());
        mySolicitudes_Via_App.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataUsuario_que_RegistraCDD(string knownCategoryValues, string category)
    {
        Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App mySolicitudes_Via_App = new Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = mySolicitudes_Via_App.FillDataUsuario_que_Registra();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["IdUsuario"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        mySolicitudes_Via_App.Dispose();
        return values.ToArray();
    }    [WebMethod]
    public DataSet FillDataOpcion(String sFiltro)
    {
        Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App mySolicitudes_Via_App = new Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(mySolicitudes_Via_App.FillDataOpcion().Copy());
        else
            ds.Tables.Add(mySolicitudes_Via_App.FillDataOpcion(sFiltro).Copy());
        mySolicitudes_Via_App.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataOpcionCDD(string knownCategoryValues, string category)
    {
        Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App mySolicitudes_Via_App = new Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = mySolicitudes_Via_App.FillDataOpcion();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Descripcion"].ToString(), dRow["Clave"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        mySolicitudes_Via_App.Dispose();
        return values.ToArray();
    }    [WebMethod]
    public DataSet FillDataEstatus(String sFiltro)
    {
        Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App mySolicitudes_Via_App = new Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(mySolicitudes_Via_App.FillDataEstatus().Copy());
        else
            ds.Tables.Add(mySolicitudes_Via_App.FillDataEstatus(sFiltro).Copy());
        mySolicitudes_Via_App.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataEstatusCDD(string knownCategoryValues, string category)
    {
        Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App mySolicitudes_Via_App = new Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = mySolicitudes_Via_App.FillDataEstatus();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Descripcion"].ToString(), dRow["Clave"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        mySolicitudes_Via_App.Dispose();
        return values.ToArray();
    }    [WebMethod]
    public DataSet FillDataObservatorio(String sFiltro)
    {
        Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App mySolicitudes_Via_App = new Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(mySolicitudes_Via_App.FillDataObservatorio().Copy());
        else
            ds.Tables.Add(mySolicitudes_Via_App.FillDataObservatorio(sFiltro).Copy());
        mySolicitudes_Via_App.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataObservatorioCDD(string knownCategoryValues, string category)
    {
        Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App mySolicitudes_Via_App = new Solicitudes_Via_AppCS.objectBussinessSolicitudes_Via_App();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = mySolicitudes_Via_App.FillDataObservatorio();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["Clave"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        mySolicitudes_Via_App.Dispose();
        return values.ToArray();
    }
}
