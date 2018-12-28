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
public class objectBussinessRegistro_de_Roles : System.Web.Services.WebService
{
    public int iProcess = 30351;
    private TTTraductor.Traductor MyTraductor;
    


    [WebMethod]
    public string ListaGetFullQuery(string sWhere,string sOrder)
    {
	Registro_de_RolesCS.objectBussinessRegistro_de_Roles myRegistro_de_Roles = new Registro_de_RolesCS.objectBussinessRegistro_de_Roles();
        string result = myRegistro_de_Roles.GetFullQuery(sWhere, sOrder);
	myRegistro_de_Roles.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ListaSelAll(int startRowIndex,int maximumRows,string where,string Order)
    {
	Registro_de_RolesCS.objectBussinessRegistro_de_Roles myRegistro_de_Roles = new Registro_de_RolesCS.objectBussinessRegistro_de_Roles();
        DataSet result = myRegistro_de_Roles.SelAll(startRowIndex, maximumRows, where, Order);
	myRegistro_de_Roles.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ImpresionSelAll(string where, string Order)
    {
	Registro_de_RolesCS.objectBussinessRegistro_de_Roles myRegistro_de_Roles = new Registro_de_RolesCS.objectBussinessRegistro_de_Roles();
        DataSet result = myRegistro_de_Roles.SelAll(where, Order);
	myRegistro_de_Roles.Dispose();
        return result;
    }

    [WebMethod]
    public int ListaSelCount(string where)
    {
	Registro_de_RolesCS.objectBussinessRegistro_de_Roles myRegistro_de_Roles = new Registro_de_RolesCS.objectBussinessRegistro_de_Roles();
        int result = myRegistro_de_Roles.SelCount(where);
	myRegistro_de_Roles.Dispose();
        return result;
    }


    [WebMethod]
    public Int32 SelCount()
    {
	Registro_de_RolesCS.objectBussinessRegistro_de_Roles myRegistro_de_Roles = new Registro_de_RolesCS.objectBussinessRegistro_de_Roles();
        Int32 result = myRegistro_de_Roles.SelCount();
	myRegistro_de_Roles.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
	Registro_de_RolesCS.objectBussinessRegistro_de_Roles myRegistro_de_Roles = new Registro_de_RolesCS.objectBussinessRegistro_de_Roles();
        DataSet result = myRegistro_de_Roles.SelAll(ConRelaciones);
	myRegistro_de_Roles.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, Registro_de_RolesCS.Registro_de_RolesFilters[] myFilters)
    {
        Registro_de_RolesCS.objectBussinessRegistro_de_Roles myRegistro_de_Roles = new Registro_de_RolesCS.objectBussinessRegistro_de_Roles();
        myRegistro_de_Roles.Filters = myFilters;
        DataSet result = myRegistro_de_Roles.SelAll(ConRelaciones);
        myRegistro_de_Roles.Filters = null;
        myRegistro_de_Roles.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        Registro_de_RolesCS.objectBussinessRegistro_de_Roles myRegistro_de_Roles = new Registro_de_RolesCS.objectBussinessRegistro_de_Roles();
        DataSet ds = new DataSet();
        ds.Tables.Add(myRegistro_de_Roles.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        myRegistro_de_Roles.Dispose(); 
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varUsuario_que_Registra, DateTime? varFecha_de_Registro, String varHora_de_Registro, String varNombre, String varClave_de_Acceso, String varContrasena, String varCorreo, int? varRol, int? varUsuario_de_Sistema, int?[] varObservatorio, String varObservatorios)
    {
        Registro_de_RolesCS.objectBussinessRegistro_de_Roles  myRegistro_de_Roles = new Registro_de_RolesCS.objectBussinessRegistro_de_Roles();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myRegistro_de_Roles.Usuario_que_Registra = varUsuario_que_Registra;
        myRegistro_de_Roles.Fecha_de_Registro = varFecha_de_Registro;
        myRegistro_de_Roles.Hora_de_Registro = varHora_de_Registro;
        myRegistro_de_Roles.Nombre = varNombre;
        myRegistro_de_Roles.Clave_de_Acceso = varClave_de_Acceso;
        myRegistro_de_Roles.Contrasena = varContrasena;
        myRegistro_de_Roles.Correo = varCorreo;
        myRegistro_de_Roles.Rol = varRol;
        myRegistro_de_Roles.Usuario_de_Sistema = varUsuario_de_Sistema;
        myRegistro_de_Roles.Observatorio =  new MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol[varObservatorio.Length];
        for(int i = 0;i< varObservatorio.Length ;i++)
        {
            myRegistro_de_Roles.Observatorio[i] = new MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol();
            myRegistro_de_Roles.Observatorio[i].Observatorio = varObservatorio[i];
        }
        myRegistro_de_Roles.Observatorios = varObservatorios;

        String sMsg = "";
        if (!ValidaDataToSave(myRegistro_de_Roles, out sMsg))
        {
            myRegistro_de_Roles.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myRegistro_de_Roles, out sMsg))
        {
            myRegistro_de_Roles.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        myRegistro_de_Roles.Insert(globalInfo, dr);
        myRegistro_de_Roles.Dispose();
        dr = null;
        globalInfo = null;
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, int? varUsuario_que_Registra, DateTime? varFecha_de_Registro, String varHora_de_Registro, String varNombre, String varClave_de_Acceso, String varContrasena, String varCorreo, int? varRol, int? varUsuario_de_Sistema, int?[] varObservatorio, String varObservatorios)
    {
        Registro_de_RolesCS.objectBussinessRegistro_de_Roles  myRegistro_de_Roles= new Registro_de_RolesCS.objectBussinessRegistro_de_Roles();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myRegistro_de_Roles.Usuario_que_Registra = varUsuario_que_Registra;
        myRegistro_de_Roles.Fecha_de_Registro = varFecha_de_Registro;
        myRegistro_de_Roles.Hora_de_Registro = varHora_de_Registro;
        myRegistro_de_Roles.Nombre = varNombre;
        myRegistro_de_Roles.Clave_de_Acceso = varClave_de_Acceso;
        myRegistro_de_Roles.Contrasena = varContrasena;
        myRegistro_de_Roles.Correo = varCorreo;
        myRegistro_de_Roles.Rol = varRol;
        myRegistro_de_Roles.Usuario_de_Sistema = varUsuario_de_Sistema;
        myRegistro_de_Roles.Observatorio =  new MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol[varObservatorio.Length];
        for(int i = 0;i< varObservatorio.Length ;i++)
        {
            myRegistro_de_Roles.Observatorio[i] = new MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol();
            myRegistro_de_Roles.Observatorio[i].Observatorio = varObservatorio[i];
        }
        myRegistro_de_Roles.Observatorios = varObservatorios;

        String sMsg = "";
        if (!ValidaDataToSave(myRegistro_de_Roles, out sMsg))
        {
            myRegistro_de_Roles.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myRegistro_de_Roles, out sMsg))
        {
            myRegistro_de_Roles.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        object result=myRegistro_de_Roles.InsertWithReturnValue(globalInfo, dr);
        myRegistro_de_Roles.Dispose();
        dr = null;
        globalInfo = null;
        return result;
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varFolio, int? varUsuario_que_Registra, DateTime? varFecha_de_Registro, String varHora_de_Registro, String varNombre, String varClave_de_Acceso, String varContrasena, String varCorreo, int? varRol, int? varUsuario_de_Sistema, int?[] varObservatorio, String varObservatorios)
    {
        Registro_de_RolesCS.objectBussinessRegistro_de_Roles myRegistro_de_Roles = new Registro_de_RolesCS.objectBussinessRegistro_de_Roles();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myRegistro_de_Roles.Folio = varFolio;
        myRegistro_de_Roles.Usuario_que_Registra = varUsuario_que_Registra;
        myRegistro_de_Roles.Fecha_de_Registro = varFecha_de_Registro;
        myRegistro_de_Roles.Hora_de_Registro = varHora_de_Registro;
        myRegistro_de_Roles.Nombre = varNombre;
        myRegistro_de_Roles.Clave_de_Acceso = varClave_de_Acceso;
        myRegistro_de_Roles.Contrasena = varContrasena;
        myRegistro_de_Roles.Correo = varCorreo;
        myRegistro_de_Roles.Rol = varRol;
        myRegistro_de_Roles.Usuario_de_Sistema = varUsuario_de_Sistema;
        myRegistro_de_Roles.Observatorio =  new MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol[varObservatorio.Length];
        for(int i = 0;i< varObservatorio.Length ;i++)
        {
            myRegistro_de_Roles.Observatorio[i] = new MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol();
            myRegistro_de_Roles.Observatorio[i].Observatorio = varObservatorio[i];
        }
        myRegistro_de_Roles.Observatorios = varObservatorios;

            String sMsg = "";
            if (!ValidaDataToSave(myRegistro_de_Roles, out sMsg))
            {
                myRegistro_de_Roles.Dispose();
                dr = null;
                globalInfo = null;
                throw new Exception(sMsg);
            }
            myRegistro_de_Roles.Update(globalInfo, dr);
            myRegistro_de_Roles.Dispose();
            dr = null;
            globalInfo = null;
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyFolio)
    {
        Registro_de_RolesCS.objectBussinessRegistro_de_Roles myRegistro_de_Roles = new Registro_de_RolesCS.objectBussinessRegistro_de_Roles();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        bool result = myRegistro_de_Roles.Delete(KeyFolio, globalInfo, dr);
        myRegistro_de_Roles.Dispose();
        dr = null;
        return result;
    }

    [WebMethod]
    public Registro_de_RolesCS.objectBussinessRegistro_de_Roles GetByKey(int? KeyFolio, Boolean ConRelaciones)
    {
        Registro_de_RolesCS.objectBussinessRegistro_de_Roles myRegistro_de_Roles = new Registro_de_RolesCS.objectBussinessRegistro_de_Roles();
        myRegistro_de_Roles.GetByKey(KeyFolio, ConRelaciones);;
        return myRegistro_de_Roles;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyFolio)
    {
        Registro_de_RolesCS.objectBussinessRegistro_de_Roles myRegistro_de_Roles = new Registro_de_RolesCS.objectBussinessRegistro_de_Roles();
        Int32 result = myRegistro_de_Roles.CurrentPosicion(KeyFolio);
        return result;
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyFolio)
    {
        Registro_de_RolesCS.objectBussinessRegistro_de_Roles myRegistro_de_Roles = new Registro_de_RolesCS.objectBussinessRegistro_de_Roles();
        Boolean result = myRegistro_de_Roles.ValidaExistencia(KeyFolio);
        myRegistro_de_Roles.Dispose();
        return result;
    }

    private bool ValidaDataToSave(Registro_de_RolesCS.objectBussinessRegistro_de_Roles MyDataRegistro_de_Roles, out String sMsg)
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

    public bool ValidaDataDuplication(Registro_de_RolesCS.objectBussinessRegistro_de_Roles MyDataRegistro_de_Roles, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataRegistro_de_Roles.Folio == -1)
        {
            if (MyDataRegistro_de_Roles.ValidaExistencia(MyDataRegistro_de_Roles.Folio))
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
        Registro_de_RolesCS.objectBussinessRegistro_de_Roles myRegistro_de_Roles = new Registro_de_RolesCS.objectBussinessRegistro_de_Roles();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myRegistro_de_Roles.FillDataUsuario_que_Registra().Copy());
        else
            ds.Tables.Add(myRegistro_de_Roles.FillDataUsuario_que_Registra(sFiltro).Copy());
        myRegistro_de_Roles.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataUsuario_que_RegistraCDD(string knownCategoryValues, string category)
    {
        Registro_de_RolesCS.objectBussinessRegistro_de_Roles myRegistro_de_Roles = new Registro_de_RolesCS.objectBussinessRegistro_de_Roles();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myRegistro_de_Roles.FillDataUsuario_que_Registra();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["IdUsuario"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myRegistro_de_Roles.Dispose();
        return values.ToArray();
    }    [WebMethod]
    public DataSet FillDataRol(String sFiltro)
    {
        Registro_de_RolesCS.objectBussinessRegistro_de_Roles myRegistro_de_Roles = new Registro_de_RolesCS.objectBussinessRegistro_de_Roles();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myRegistro_de_Roles.FillDataRol().Copy());
        else
            ds.Tables.Add(myRegistro_de_Roles.FillDataRol(sFiltro).Copy());
        myRegistro_de_Roles.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataRolCDD(string knownCategoryValues, string category)
    {
        Registro_de_RolesCS.objectBussinessRegistro_de_Roles myRegistro_de_Roles = new Registro_de_RolesCS.objectBussinessRegistro_de_Roles();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myRegistro_de_Roles.FillDataRol();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Descripcion"].ToString(), dRow["Clave"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myRegistro_de_Roles.Dispose();
        return values.ToArray();
    }    [WebMethod]
    public DataSet FillDataUsuario_de_Sistema(String sFiltro)
    {
        Registro_de_RolesCS.objectBussinessRegistro_de_Roles myRegistro_de_Roles = new Registro_de_RolesCS.objectBussinessRegistro_de_Roles();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myRegistro_de_Roles.FillDataUsuario_de_Sistema().Copy());
        else
            ds.Tables.Add(myRegistro_de_Roles.FillDataUsuario_de_Sistema(sFiltro).Copy());
        myRegistro_de_Roles.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataUsuario_de_SistemaCDD(string knownCategoryValues, string category)
    {
        Registro_de_RolesCS.objectBussinessRegistro_de_Roles myRegistro_de_Roles = new Registro_de_RolesCS.objectBussinessRegistro_de_Roles();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myRegistro_de_Roles.FillDataUsuario_de_Sistema();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["IdUsuario"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myRegistro_de_Roles.Dispose();
        return values.ToArray();
    }    [WebMethod]
    public DataSet FillDataObservatorio()
    {
        Registro_de_RolesCS.objectBussinessRegistro_de_Roles myRegistro_de_Roles = new Registro_de_RolesCS.objectBussinessRegistro_de_Roles();
        DataSet ds = new DataSet();
        ds.Tables.Add(myRegistro_de_Roles.FillDataObservatorio().Copy());
        myRegistro_de_Roles.Dispose();
        return ds;
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataObservatorioCDD(string knownCategoryValues, string category)
    {
        Registro_de_RolesCS.objectBussinessRegistro_de_Roles myRegistro_de_Roles = new Registro_de_RolesCS.objectBussinessRegistro_de_Roles();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myRegistro_de_Roles.FillDataObservatorio();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Clave"].ToString(), dRow["Clave"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myRegistro_de_Roles.Dispose();
        return values.ToArray();
    }
}
