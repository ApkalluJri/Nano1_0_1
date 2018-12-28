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
public class objectBussinessRegistro_de_Usuario : System.Web.Services.WebService
{
    public int iProcess = 29981;
    private TTTraductor.Traductor MyTraductor;
    


    [WebMethod]
    public string ListaGetFullQuery(string sWhere,string sOrder)
    {
	Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario myRegistro_de_Usuario = new Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario();
        string result = myRegistro_de_Usuario.GetFullQuery(sWhere, sOrder);
	myRegistro_de_Usuario.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ListaSelAll(int startRowIndex,int maximumRows,string where,string Order)
    {
	Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario myRegistro_de_Usuario = new Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario();
        DataSet result = myRegistro_de_Usuario.SelAll(startRowIndex, maximumRows, where, Order);
	myRegistro_de_Usuario.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ImpresionSelAll(string where, string Order)
    {
	Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario myRegistro_de_Usuario = new Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario();
        DataSet result = myRegistro_de_Usuario.SelAll(where, Order);
	myRegistro_de_Usuario.Dispose();
        return result;
    }

    [WebMethod]
    public int ListaSelCount(string where)
    {
	Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario myRegistro_de_Usuario = new Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario();
        int result = myRegistro_de_Usuario.SelCount(where);
	myRegistro_de_Usuario.Dispose();
        return result;
    }


    [WebMethod]
    public Int32 SelCount()
    {
	Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario myRegistro_de_Usuario = new Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario();
        Int32 result = myRegistro_de_Usuario.SelCount();
	myRegistro_de_Usuario.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
	Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario myRegistro_de_Usuario = new Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario();
        DataSet result = myRegistro_de_Usuario.SelAll(ConRelaciones);
	myRegistro_de_Usuario.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, Registro_de_UsuarioCS.Registro_de_UsuarioFilters[] myFilters)
    {
        Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario myRegistro_de_Usuario = new Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario();
        myRegistro_de_Usuario.Filters = myFilters;
        DataSet result = myRegistro_de_Usuario.SelAll(ConRelaciones);
        myRegistro_de_Usuario.Filters = null;
        myRegistro_de_Usuario.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario myRegistro_de_Usuario = new Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario();
        DataSet ds = new DataSet();
        ds.Tables.Add(myRegistro_de_Usuario.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        myRegistro_de_Usuario.Dispose(); 
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varUsuario_que_Registra, DateTime? varFecha_de_Registro, String varHora_de_Registro, String varNombre, String varApellido, String varNombre_Completo, String varCorreo, String varContrasena, String varConfirmar_Contrasena, Boolean varAcepta_Terminos, int? varFoto_de_Perfil, int? varUsuario_del_Sistema)
    {
        Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario  myRegistro_de_Usuario = new Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myRegistro_de_Usuario.Usuario_que_Registra = varUsuario_que_Registra;
        myRegistro_de_Usuario.Fecha_de_Registro = varFecha_de_Registro;
        myRegistro_de_Usuario.Hora_de_Registro = varHora_de_Registro;
        myRegistro_de_Usuario.Nombre = varNombre;
        myRegistro_de_Usuario.Apellido = varApellido;
        myRegistro_de_Usuario.Nombre_Completo = varNombre_Completo;
        myRegistro_de_Usuario.Correo = varCorreo;
        myRegistro_de_Usuario.Contrasena = varContrasena;
        myRegistro_de_Usuario.Confirmar_Contrasena = varConfirmar_Contrasena;
        myRegistro_de_Usuario.Acepta_Terminos = varAcepta_Terminos;
        myRegistro_de_Usuario.Foto_de_Perfil = varFoto_de_Perfil;
        myRegistro_de_Usuario.Usuario_del_Sistema = varUsuario_del_Sistema;

        String sMsg = "";
        if (!ValidaDataToSave(myRegistro_de_Usuario, out sMsg))
        {
            myRegistro_de_Usuario.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myRegistro_de_Usuario, out sMsg))
        {
            myRegistro_de_Usuario.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        myRegistro_de_Usuario.Insert(globalInfo, dr);
        myRegistro_de_Usuario.Dispose();
        dr = null;
        globalInfo = null;
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, int? varUsuario_que_Registra, DateTime? varFecha_de_Registro, String varHora_de_Registro, String varNombre, String varApellido, String varNombre_Completo, String varCorreo, String varContrasena, String varConfirmar_Contrasena, Boolean varAcepta_Terminos, int? varFoto_de_Perfil, int? varUsuario_del_Sistema)
    {
        Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario  myRegistro_de_Usuario= new Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myRegistro_de_Usuario.Usuario_que_Registra = varUsuario_que_Registra;
        myRegistro_de_Usuario.Fecha_de_Registro = varFecha_de_Registro;
        myRegistro_de_Usuario.Hora_de_Registro = varHora_de_Registro;
        myRegistro_de_Usuario.Nombre = varNombre;
        myRegistro_de_Usuario.Apellido = varApellido;
        myRegistro_de_Usuario.Nombre_Completo = varNombre_Completo;
        myRegistro_de_Usuario.Correo = varCorreo;
        myRegistro_de_Usuario.Contrasena = varContrasena;
        myRegistro_de_Usuario.Confirmar_Contrasena = varConfirmar_Contrasena;
        myRegistro_de_Usuario.Acepta_Terminos = varAcepta_Terminos;
        myRegistro_de_Usuario.Foto_de_Perfil = varFoto_de_Perfil;
        myRegistro_de_Usuario.Usuario_del_Sistema = varUsuario_del_Sistema;

        String sMsg = "";
        if (!ValidaDataToSave(myRegistro_de_Usuario, out sMsg))
        {
            myRegistro_de_Usuario.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myRegistro_de_Usuario, out sMsg))
        {
            myRegistro_de_Usuario.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        object result=myRegistro_de_Usuario.InsertWithReturnValue(globalInfo, dr);
        myRegistro_de_Usuario.Dispose();
        dr = null;
        globalInfo = null;
        return result;
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varFolio, int? varUsuario_que_Registra, DateTime? varFecha_de_Registro, String varHora_de_Registro, String varNombre, String varApellido, String varNombre_Completo, String varCorreo, String varContrasena, String varConfirmar_Contrasena, Boolean varAcepta_Terminos, int? varFoto_de_Perfil, int? varUsuario_del_Sistema)
    {
        Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario myRegistro_de_Usuario = new Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myRegistro_de_Usuario.Folio = varFolio;
        myRegistro_de_Usuario.Usuario_que_Registra = varUsuario_que_Registra;
        myRegistro_de_Usuario.Fecha_de_Registro = varFecha_de_Registro;
        myRegistro_de_Usuario.Hora_de_Registro = varHora_de_Registro;
        myRegistro_de_Usuario.Nombre = varNombre;
        myRegistro_de_Usuario.Apellido = varApellido;
        myRegistro_de_Usuario.Nombre_Completo = varNombre_Completo;
        myRegistro_de_Usuario.Correo = varCorreo;
        myRegistro_de_Usuario.Contrasena = varContrasena;
        myRegistro_de_Usuario.Confirmar_Contrasena = varConfirmar_Contrasena;
        myRegistro_de_Usuario.Acepta_Terminos = varAcepta_Terminos;
        myRegistro_de_Usuario.Foto_de_Perfil = varFoto_de_Perfil;
        myRegistro_de_Usuario.Usuario_del_Sistema = varUsuario_del_Sistema;

            String sMsg = "";
            if (!ValidaDataToSave(myRegistro_de_Usuario, out sMsg))
            {
                myRegistro_de_Usuario.Dispose();
                dr = null;
                globalInfo = null;
                throw new Exception(sMsg);
            }
            myRegistro_de_Usuario.Update(globalInfo, dr);
            myRegistro_de_Usuario.Dispose();
            dr = null;
            globalInfo = null;
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyFolio)
    {
        Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario myRegistro_de_Usuario = new Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        bool result = myRegistro_de_Usuario.Delete(KeyFolio, globalInfo, dr);
        myRegistro_de_Usuario.Dispose();
        dr = null;
        return result;
    }

    [WebMethod]
    public Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario GetByKey(int? KeyFolio, Boolean ConRelaciones)
    {
        Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario myRegistro_de_Usuario = new Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario();
        myRegistro_de_Usuario.GetByKey(KeyFolio, ConRelaciones);;
        return myRegistro_de_Usuario;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyFolio)
    {
        Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario myRegistro_de_Usuario = new Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario();
        Int32 result = myRegistro_de_Usuario.CurrentPosicion(KeyFolio);
        return result;
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyFolio)
    {
        Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario myRegistro_de_Usuario = new Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario();
        Boolean result = myRegistro_de_Usuario.ValidaExistencia(KeyFolio);
        myRegistro_de_Usuario.Dispose();
        return result;
    }

    private bool ValidaDataToSave(Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario MyDataRegistro_de_Usuario, out String sMsg)
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

    public bool ValidaDataDuplication(Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario MyDataRegistro_de_Usuario, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataRegistro_de_Usuario.Folio == -1)
        {
            if (MyDataRegistro_de_Usuario.ValidaExistencia(MyDataRegistro_de_Usuario.Folio))
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
        Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario myRegistro_de_Usuario = new Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myRegistro_de_Usuario.FillDataUsuario_que_Registra().Copy());
        else
            ds.Tables.Add(myRegistro_de_Usuario.FillDataUsuario_que_Registra(sFiltro).Copy());
        myRegistro_de_Usuario.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataUsuario_que_RegistraCDD(string knownCategoryValues, string category)
    {
        Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario myRegistro_de_Usuario = new Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myRegistro_de_Usuario.FillDataUsuario_que_Registra();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["IdUsuario"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myRegistro_de_Usuario.Dispose();
        return values.ToArray();
    }    [WebMethod]
    public DataSet FillDataUsuario_del_Sistema(String sFiltro)
    {
        Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario myRegistro_de_Usuario = new Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myRegistro_de_Usuario.FillDataUsuario_del_Sistema().Copy());
        else
            ds.Tables.Add(myRegistro_de_Usuario.FillDataUsuario_del_Sistema(sFiltro).Copy());
        myRegistro_de_Usuario.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataUsuario_del_SistemaCDD(string knownCategoryValues, string category)
    {
        Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario myRegistro_de_Usuario = new Registro_de_UsuarioCS.objectBussinessRegistro_de_Usuario();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myRegistro_de_Usuario.FillDataUsuario_del_Sistema();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["IdUsuario"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myRegistro_de_Usuario.Dispose();
        return values.ToArray();
    }
}
