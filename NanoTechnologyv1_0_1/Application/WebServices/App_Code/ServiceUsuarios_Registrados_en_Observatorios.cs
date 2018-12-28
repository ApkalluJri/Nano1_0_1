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
public class objectBussinessUsuarios_Registrados_en_Observatorios : System.Web.Services.WebService
{
    public int iProcess = 30330;
    private TTTraductor.Traductor MyTraductor;
    


    [WebMethod]
    public string ListaGetFullQuery(string sWhere,string sOrder)
    {
	Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios myUsuarios_Registrados_en_Observatorios = new Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios();
        string result = myUsuarios_Registrados_en_Observatorios.GetFullQuery(sWhere, sOrder);
	myUsuarios_Registrados_en_Observatorios.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ListaSelAll(int startRowIndex,int maximumRows,string where,string Order)
    {
	Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios myUsuarios_Registrados_en_Observatorios = new Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios();
        DataSet result = myUsuarios_Registrados_en_Observatorios.SelAll(startRowIndex, maximumRows, where, Order);
	myUsuarios_Registrados_en_Observatorios.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ImpresionSelAll(string where, string Order)
    {
	Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios myUsuarios_Registrados_en_Observatorios = new Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios();
        DataSet result = myUsuarios_Registrados_en_Observatorios.SelAll(where, Order);
	myUsuarios_Registrados_en_Observatorios.Dispose();
        return result;
    }

    [WebMethod]
    public int ListaSelCount(string where)
    {
	Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios myUsuarios_Registrados_en_Observatorios = new Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios();
        int result = myUsuarios_Registrados_en_Observatorios.SelCount(where);
	myUsuarios_Registrados_en_Observatorios.Dispose();
        return result;
    }


    [WebMethod]
    public Int32 SelCount()
    {
	Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios myUsuarios_Registrados_en_Observatorios = new Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios();
        Int32 result = myUsuarios_Registrados_en_Observatorios.SelCount();
	myUsuarios_Registrados_en_Observatorios.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
	Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios myUsuarios_Registrados_en_Observatorios = new Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios();
        DataSet result = myUsuarios_Registrados_en_Observatorios.SelAll(ConRelaciones);
	myUsuarios_Registrados_en_Observatorios.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, Usuarios_Registrados_en_ObservatoriosCS.Usuarios_Registrados_en_ObservatoriosFilters[] myFilters)
    {
        Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios myUsuarios_Registrados_en_Observatorios = new Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios();
        myUsuarios_Registrados_en_Observatorios.Filters = myFilters;
        DataSet result = myUsuarios_Registrados_en_Observatorios.SelAll(ConRelaciones);
        myUsuarios_Registrados_en_Observatorios.Filters = null;
        myUsuarios_Registrados_en_Observatorios.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios myUsuarios_Registrados_en_Observatorios = new Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios();
        DataSet ds = new DataSet();
        ds.Tables.Add(myUsuarios_Registrados_en_Observatorios.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        myUsuarios_Registrados_en_Observatorios.Dispose(); 
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varObservatorio, int? varUsuario, String varNombre, String varCorreo, String varContrasena, DateTime? varFecha_de_Ingreso, String varToken, String varIdentificador_Dispositivo, int? varTipo_de_Dispositivo, Boolean varEstado_Token)
    {
        Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios  myUsuarios_Registrados_en_Observatorios = new Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myUsuarios_Registrados_en_Observatorios.Observatorio = varObservatorio;
        myUsuarios_Registrados_en_Observatorios.Usuario = varUsuario;
        myUsuarios_Registrados_en_Observatorios.Nombre = varNombre;
        myUsuarios_Registrados_en_Observatorios.Correo = varCorreo;
        myUsuarios_Registrados_en_Observatorios.Contrasena = varContrasena;
        myUsuarios_Registrados_en_Observatorios.Fecha_de_Ingreso = varFecha_de_Ingreso;
        myUsuarios_Registrados_en_Observatorios.Token = varToken;
        myUsuarios_Registrados_en_Observatorios.Identificador_Dispositivo = varIdentificador_Dispositivo;
        myUsuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo = varTipo_de_Dispositivo;
        myUsuarios_Registrados_en_Observatorios.Estado_Token = varEstado_Token;

        String sMsg = "";
        if (!ValidaDataToSave(myUsuarios_Registrados_en_Observatorios, out sMsg))
        {
            myUsuarios_Registrados_en_Observatorios.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myUsuarios_Registrados_en_Observatorios, out sMsg))
        {
            myUsuarios_Registrados_en_Observatorios.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        myUsuarios_Registrados_en_Observatorios.Insert(globalInfo, dr);
        myUsuarios_Registrados_en_Observatorios.Dispose();
        dr = null;
        globalInfo = null;
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, int? varObservatorio, int? varUsuario, String varNombre, String varCorreo, String varContrasena, DateTime? varFecha_de_Ingreso, String varToken, String varIdentificador_Dispositivo, int? varTipo_de_Dispositivo, Boolean varEstado_Token)
    {
        Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios  myUsuarios_Registrados_en_Observatorios= new Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myUsuarios_Registrados_en_Observatorios.Observatorio = varObservatorio;
        myUsuarios_Registrados_en_Observatorios.Usuario = varUsuario;
        myUsuarios_Registrados_en_Observatorios.Nombre = varNombre;
        myUsuarios_Registrados_en_Observatorios.Correo = varCorreo;
        myUsuarios_Registrados_en_Observatorios.Contrasena = varContrasena;
        myUsuarios_Registrados_en_Observatorios.Fecha_de_Ingreso = varFecha_de_Ingreso;
        myUsuarios_Registrados_en_Observatorios.Token = varToken;
        myUsuarios_Registrados_en_Observatorios.Identificador_Dispositivo = varIdentificador_Dispositivo;
        myUsuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo = varTipo_de_Dispositivo;
        myUsuarios_Registrados_en_Observatorios.Estado_Token = varEstado_Token;

        String sMsg = "";
        if (!ValidaDataToSave(myUsuarios_Registrados_en_Observatorios, out sMsg))
        {
            myUsuarios_Registrados_en_Observatorios.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myUsuarios_Registrados_en_Observatorios, out sMsg))
        {
            myUsuarios_Registrados_en_Observatorios.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        object result=myUsuarios_Registrados_en_Observatorios.InsertWithReturnValue(globalInfo, dr);
        myUsuarios_Registrados_en_Observatorios.Dispose();
        dr = null;
        globalInfo = null;
        return result;
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varClave, int? varObservatorio, int? varUsuario, String varNombre, String varCorreo, String varContrasena, DateTime? varFecha_de_Ingreso, String varToken, String varIdentificador_Dispositivo, int? varTipo_de_Dispositivo, Boolean varEstado_Token)
    {
        Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios myUsuarios_Registrados_en_Observatorios = new Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myUsuarios_Registrados_en_Observatorios.Clave = varClave;
        myUsuarios_Registrados_en_Observatorios.Observatorio = varObservatorio;
        myUsuarios_Registrados_en_Observatorios.Usuario = varUsuario;
        myUsuarios_Registrados_en_Observatorios.Nombre = varNombre;
        myUsuarios_Registrados_en_Observatorios.Correo = varCorreo;
        myUsuarios_Registrados_en_Observatorios.Contrasena = varContrasena;
        myUsuarios_Registrados_en_Observatorios.Fecha_de_Ingreso = varFecha_de_Ingreso;
        myUsuarios_Registrados_en_Observatorios.Token = varToken;
        myUsuarios_Registrados_en_Observatorios.Identificador_Dispositivo = varIdentificador_Dispositivo;
        myUsuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo = varTipo_de_Dispositivo;
        myUsuarios_Registrados_en_Observatorios.Estado_Token = varEstado_Token;

            String sMsg = "";
            if (!ValidaDataToSave(myUsuarios_Registrados_en_Observatorios, out sMsg))
            {
                myUsuarios_Registrados_en_Observatorios.Dispose();
                dr = null;
                globalInfo = null;
                throw new Exception(sMsg);
            }
            myUsuarios_Registrados_en_Observatorios.Update(globalInfo, dr);
            myUsuarios_Registrados_en_Observatorios.Dispose();
            dr = null;
            globalInfo = null;
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyClave)
    {
        Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios myUsuarios_Registrados_en_Observatorios = new Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        bool result = myUsuarios_Registrados_en_Observatorios.Delete(KeyClave, globalInfo, dr);
        myUsuarios_Registrados_en_Observatorios.Dispose();
        dr = null;
        return result;
    }

    [WebMethod]
    public Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios GetByKey(int? KeyClave, Boolean ConRelaciones)
    {
        Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios myUsuarios_Registrados_en_Observatorios = new Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios();
        myUsuarios_Registrados_en_Observatorios.GetByKey(KeyClave, ConRelaciones);;
        return myUsuarios_Registrados_en_Observatorios;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyClave)
    {
        Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios myUsuarios_Registrados_en_Observatorios = new Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios();
        Int32 result = myUsuarios_Registrados_en_Observatorios.CurrentPosicion(KeyClave);
        return result;
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyClave)
    {
        Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios myUsuarios_Registrados_en_Observatorios = new Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios();
        Boolean result = myUsuarios_Registrados_en_Observatorios.ValidaExistencia(KeyClave);
        myUsuarios_Registrados_en_Observatorios.Dispose();
        return result;
    }

    private bool ValidaDataToSave(Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios MyDataUsuarios_Registrados_en_Observatorios, out String sMsg)
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

    public bool ValidaDataDuplication(Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios MyDataUsuarios_Registrados_en_Observatorios, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataUsuarios_Registrados_en_Observatorios.Clave == -1)
        {
            if (MyDataUsuarios_Registrados_en_Observatorios.ValidaExistencia(MyDataUsuarios_Registrados_en_Observatorios.Clave))
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
        Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios myUsuarios_Registrados_en_Observatorios = new Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myUsuarios_Registrados_en_Observatorios.FillDataObservatorio().Copy());
        else
            ds.Tables.Add(myUsuarios_Registrados_en_Observatorios.FillDataObservatorio(sFiltro).Copy());
        myUsuarios_Registrados_en_Observatorios.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataObservatorioCDD(string knownCategoryValues, string category)
    {
        Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios myUsuarios_Registrados_en_Observatorios = new Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myUsuarios_Registrados_en_Observatorios.FillDataObservatorio();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["Clave"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myUsuarios_Registrados_en_Observatorios.Dispose();
        return values.ToArray();
    }    [WebMethod]
    public DataSet FillDataUsuario(String sFiltro)
    {
        Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios myUsuarios_Registrados_en_Observatorios = new Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myUsuarios_Registrados_en_Observatorios.FillDataUsuario().Copy());
        else
            ds.Tables.Add(myUsuarios_Registrados_en_Observatorios.FillDataUsuario(sFiltro).Copy());
        myUsuarios_Registrados_en_Observatorios.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataUsuarioCDD(string knownCategoryValues, string category)
    {
        Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios myUsuarios_Registrados_en_Observatorios = new Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myUsuarios_Registrados_en_Observatorios.FillDataUsuario();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["Folio"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myUsuarios_Registrados_en_Observatorios.Dispose();
        return values.ToArray();
    }    [WebMethod]
    public DataSet FillDataTipo_de_Dispositivo(String sFiltro)
    {
        Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios myUsuarios_Registrados_en_Observatorios = new Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myUsuarios_Registrados_en_Observatorios.FillDataTipo_de_Dispositivo().Copy());
        else
            ds.Tables.Add(myUsuarios_Registrados_en_Observatorios.FillDataTipo_de_Dispositivo(sFiltro).Copy());
        myUsuarios_Registrados_en_Observatorios.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataTipo_de_DispositivoCDD(string knownCategoryValues, string category)
    {
        Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios myUsuarios_Registrados_en_Observatorios = new Usuarios_Registrados_en_ObservatoriosCS.objectBussinessUsuarios_Registrados_en_Observatorios();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myUsuarios_Registrados_en_Observatorios.FillDataTipo_de_Dispositivo();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Tipo"].ToString(), dRow["Clave"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myUsuarios_Registrados_en_Observatorios.Dispose();
        return values.ToArray();
    }
}
