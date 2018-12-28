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
public class objectBussinessObservatorio : System.Web.Services.WebService
{
    public int iProcess = 29984;
    private TTTraductor.Traductor MyTraductor;
    


    [WebMethod]
    public string ListaGetFullQuery(string sWhere,string sOrder)
    {
	ObservatorioCS.objectBussinessObservatorio myObservatorio = new ObservatorioCS.objectBussinessObservatorio();
        string result = myObservatorio.GetFullQuery(sWhere, sOrder);
	myObservatorio.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ListaSelAll(int startRowIndex,int maximumRows,string where,string Order)
    {
	ObservatorioCS.objectBussinessObservatorio myObservatorio = new ObservatorioCS.objectBussinessObservatorio();
        DataSet result = myObservatorio.SelAll(startRowIndex, maximumRows, where, Order);
	myObservatorio.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ImpresionSelAll(string where, string Order)
    {
	ObservatorioCS.objectBussinessObservatorio myObservatorio = new ObservatorioCS.objectBussinessObservatorio();
        DataSet result = myObservatorio.SelAll(where, Order);
	myObservatorio.Dispose();
        return result;
    }

    [WebMethod]
    public int ListaSelCount(string where)
    {
	ObservatorioCS.objectBussinessObservatorio myObservatorio = new ObservatorioCS.objectBussinessObservatorio();
        int result = myObservatorio.SelCount(where);
	myObservatorio.Dispose();
        return result;
    }


    [WebMethod]
    public Int32 SelCount()
    {
	ObservatorioCS.objectBussinessObservatorio myObservatorio = new ObservatorioCS.objectBussinessObservatorio();
        Int32 result = myObservatorio.SelCount();
	myObservatorio.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
	ObservatorioCS.objectBussinessObservatorio myObservatorio = new ObservatorioCS.objectBussinessObservatorio();
        DataSet result = myObservatorio.SelAll(ConRelaciones);
	myObservatorio.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, ObservatorioCS.ObservatorioFilters[] myFilters)
    {
        ObservatorioCS.objectBussinessObservatorio myObservatorio = new ObservatorioCS.objectBussinessObservatorio();
        myObservatorio.Filters = myFilters;
        DataSet result = myObservatorio.SelAll(ConRelaciones);
        myObservatorio.Filters = null;
        myObservatorio.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        ObservatorioCS.objectBussinessObservatorio myObservatorio = new ObservatorioCS.objectBussinessObservatorio();
        DataSet ds = new DataSet();
        ds.Tables.Add(myObservatorio.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        myObservatorio.Dispose(); 
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, String varNombre, int? varIcono, int? varColor, int? varTipo_de_Observatorio, String[] varCodigosCodigo, int?[] varCodigosEstatus, DateTime?[] varCodigosExpiracion, int?[] varCodigosAccesos, int? varAdministrador, int?[] varEquipo_de_TrabajoNombre, int?[] varEquipo_de_TrabajoRol)
    {
        ObservatorioCS.objectBussinessObservatorio  myObservatorio = new ObservatorioCS.objectBussinessObservatorio();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myObservatorio.Nombre = varNombre;
        myObservatorio.Icono = varIcono;
        myObservatorio.Color = varColor;
        myObservatorio.Tipo_de_Observatorio = varTipo_de_Observatorio;
            if(varCodigosCodigo != null)
            {
                myObservatorio.Codigos = new Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado[varCodigosCodigo.Length];
                for (int i = 0; i < varCodigosCodigo.Length; i++)
                {
                    myObservatorio.Codigos[i] = new Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado();
                myObservatorio.Codigos[i].Codigo = varCodigosCodigo[i];
                myObservatorio.Codigos[i].Estatus = varCodigosEstatus[i];
                myObservatorio.Codigos[i].Expiracion = varCodigosExpiracion[i];
                myObservatorio.Codigos[i].Accesos = varCodigosAccesos[i];

                }
            }
        myObservatorio.Administrador = varAdministrador;
            if(varEquipo_de_TrabajoNombre != null)
            {
                myObservatorio.Equipo_de_Trabajo = new Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio[varEquipo_de_TrabajoNombre.Length];
                for (int i = 0; i < varEquipo_de_TrabajoNombre.Length; i++)
                {
                    myObservatorio.Equipo_de_Trabajo[i] = new Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio();
                myObservatorio.Equipo_de_Trabajo[i].Nombre = varEquipo_de_TrabajoNombre[i];
                myObservatorio.Equipo_de_Trabajo[i].Rol = varEquipo_de_TrabajoRol[i];

                }
            }

        String sMsg = "";
        if (!ValidaDataToSave(myObservatorio, out sMsg))
        {
            myObservatorio.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myObservatorio, out sMsg))
        {
            myObservatorio.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        myObservatorio.Insert(globalInfo, dr);
        myObservatorio.Dispose();
        dr = null;
        globalInfo = null;
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, String varNombre, int? varIcono, int? varColor, int? varTipo_de_Observatorio, String[] varCodigosCodigo, int?[] varCodigosEstatus, DateTime?[] varCodigosExpiracion, int?[] varCodigosAccesos, int? varAdministrador, int?[] varEquipo_de_TrabajoNombre, int?[] varEquipo_de_TrabajoRol)
    {
        ObservatorioCS.objectBussinessObservatorio  myObservatorio= new ObservatorioCS.objectBussinessObservatorio();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myObservatorio.Nombre = varNombre;
        myObservatorio.Icono = varIcono;
        myObservatorio.Color = varColor;
        myObservatorio.Tipo_de_Observatorio = varTipo_de_Observatorio;
            if(varCodigosCodigo != null)
            {
                myObservatorio.Codigos = new Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado[varCodigosCodigo.Length];
                for (int i = 0; i < varCodigosCodigo.Length; i++)
                {
                    myObservatorio.Codigos[i] = new Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado();
                myObservatorio.Codigos[i].Codigo = varCodigosCodigo[i];
                myObservatorio.Codigos[i].Estatus = varCodigosEstatus[i];
                myObservatorio.Codigos[i].Expiracion = varCodigosExpiracion[i];
                myObservatorio.Codigos[i].Accesos = varCodigosAccesos[i];

                }
            }
        myObservatorio.Administrador = varAdministrador;
            if(varEquipo_de_TrabajoNombre != null)
            {
                myObservatorio.Equipo_de_Trabajo = new Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio[varEquipo_de_TrabajoNombre.Length];
                for (int i = 0; i < varEquipo_de_TrabajoNombre.Length; i++)
                {
                    myObservatorio.Equipo_de_Trabajo[i] = new Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio();
                myObservatorio.Equipo_de_Trabajo[i].Nombre = varEquipo_de_TrabajoNombre[i];
                myObservatorio.Equipo_de_Trabajo[i].Rol = varEquipo_de_TrabajoRol[i];

                }
            }

        String sMsg = "";
        if (!ValidaDataToSave(myObservatorio, out sMsg))
        {
            myObservatorio.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myObservatorio, out sMsg))
        {
            myObservatorio.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        object result=myObservatorio.InsertWithReturnValue(globalInfo, dr);
        myObservatorio.Dispose();
        dr = null;
        globalInfo = null;
        return result;
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varClave, String varNombre, int? varIcono, int? varColor, int? varTipo_de_Observatorio, int?[] varCodigosClave, int?[] varCodigosObservatorio, String[] varCodigosCodigo, int?[] varCodigosEstatus, DateTime?[] varCodigosExpiracion, int?[] varCodigosAccesos, int? varAdministrador, int?[] varEquipo_de_TrabajoClave, int?[] varEquipo_de_TrabajoObservatorio, int?[] varEquipo_de_TrabajoNombre, int?[] varEquipo_de_TrabajoRol)
    {
        ObservatorioCS.objectBussinessObservatorio myObservatorio = new ObservatorioCS.objectBussinessObservatorio();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myObservatorio.Clave = varClave;
        myObservatorio.Nombre = varNombre;
        myObservatorio.Icono = varIcono;
        myObservatorio.Color = varColor;
        myObservatorio.Tipo_de_Observatorio = varTipo_de_Observatorio;
            if(varCodigosExpiracion != null)
            {
                myObservatorio.Codigos = new Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado[varCodigosExpiracion.Length];
                for (int i = 0; i < varCodigosExpiracion.Length; i++)
                {
                    myObservatorio.Codigos[i] = new Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado();
                myObservatorio.Codigos[i].Clave = varCodigosClave[i];
                myObservatorio.Codigos[i].Observatorio = varCodigosObservatorio[i];
                myObservatorio.Codigos[i].Codigo = varCodigosCodigo[i];
                myObservatorio.Codigos[i].Estatus = varCodigosEstatus[i];
                myObservatorio.Codigos[i].Expiracion = varCodigosExpiracion[i];
                myObservatorio.Codigos[i].Accesos = varCodigosAccesos[i];

                }
            }
        myObservatorio.Administrador = varAdministrador;
            if(varEquipo_de_TrabajoRol != null)
            {
                myObservatorio.Equipo_de_Trabajo = new Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio[varEquipo_de_TrabajoRol.Length];
                for (int i = 0; i < varEquipo_de_TrabajoRol.Length; i++)
                {
                    myObservatorio.Equipo_de_Trabajo[i] = new Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio();
                myObservatorio.Equipo_de_Trabajo[i].Clave = varEquipo_de_TrabajoClave[i];
                myObservatorio.Equipo_de_Trabajo[i].Observatorio = varEquipo_de_TrabajoObservatorio[i];
                myObservatorio.Equipo_de_Trabajo[i].Nombre = varEquipo_de_TrabajoNombre[i];
                myObservatorio.Equipo_de_Trabajo[i].Rol = varEquipo_de_TrabajoRol[i];

                }
            }

            String sMsg = "";
            if (!ValidaDataToSave(myObservatorio, out sMsg))
            {
                myObservatorio.Dispose();
                dr = null;
                globalInfo = null;
                throw new Exception(sMsg);
            }
            myObservatorio.Update(globalInfo, dr);
            myObservatorio.Dispose();
            dr = null;
            globalInfo = null;
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyClave)
    {
        ObservatorioCS.objectBussinessObservatorio myObservatorio = new ObservatorioCS.objectBussinessObservatorio();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        bool result = myObservatorio.Delete(KeyClave, globalInfo, dr);
        myObservatorio.Dispose();
        dr = null;
        return result;
    }

    [WebMethod]
    public ObservatorioCS.objectBussinessObservatorio GetByKey(int? KeyClave, Boolean ConRelaciones)
    {
        ObservatorioCS.objectBussinessObservatorio myObservatorio = new ObservatorioCS.objectBussinessObservatorio();
        myObservatorio.GetByKey(KeyClave, ConRelaciones);;
        return myObservatorio;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyClave)
    {
        ObservatorioCS.objectBussinessObservatorio myObservatorio = new ObservatorioCS.objectBussinessObservatorio();
        Int32 result = myObservatorio.CurrentPosicion(KeyClave);
        return result;
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyClave)
    {
        ObservatorioCS.objectBussinessObservatorio myObservatorio = new ObservatorioCS.objectBussinessObservatorio();
        Boolean result = myObservatorio.ValidaExistencia(KeyClave);
        myObservatorio.Dispose();
        return result;
    }

    private bool ValidaDataToSave(ObservatorioCS.objectBussinessObservatorio MyDataObservatorio, out String sMsg)
    {
        //Validaciones
        sMsg = "";
            if(MyDataObservatorio.Codigos != null)
            {
                for (int i = 0; i < MyDataObservatorio.Codigos.Length; i++)
                {
                    if (MyDataObservatorio.Codigos[i].Estatus != null)
                    {
                        Estatus_CodigoCS.objectBussinessEstatus_Codigo MyDataEstatus_CodigoTemp = new Estatus_CodigoCS.objectBussinessEstatus_Codigo();
                        if (!MyDataEstatus_CodigoTemp.ValidaExistencia(MyDataObservatorio.Codigos[i].Estatus))
                        {
                            sMsg = sMsg + "El Campo Estatus no existe\n";
                        }
                    }
                }
            }
            if(MyDataObservatorio.Equipo_de_Trabajo != null)
            {
                for (int i = 0; i < MyDataObservatorio.Equipo_de_Trabajo.Length; i++)
                {
                    if (MyDataObservatorio.Equipo_de_Trabajo[i].Nombre != null)
                    {
                        Registro_de_RolesCS.objectBussinessRegistro_de_Roles MyDataRegistro_de_RolesTemp = new Registro_de_RolesCS.objectBussinessRegistro_de_Roles();
                        if (!MyDataRegistro_de_RolesTemp.ValidaExistencia(MyDataObservatorio.Equipo_de_Trabajo[i].Nombre))
                        {
                            sMsg = sMsg + "El Campo Nombre no existe\n";
                        }
                    }
                }
            }
            if(MyDataObservatorio.Equipo_de_Trabajo != null)
            {
                for (int i = 0; i < MyDataObservatorio.Equipo_de_Trabajo.Length; i++)
                {
                    if (MyDataObservatorio.Equipo_de_Trabajo[i].Rol != null)
                    {
                        Rol_de_UsuarioCS.objectBussinessRol_de_Usuario MyDataRol_de_UsuarioTemp = new Rol_de_UsuarioCS.objectBussinessRol_de_Usuario();
                        if (!MyDataRol_de_UsuarioTemp.ValidaExistencia(MyDataObservatorio.Equipo_de_Trabajo[i].Rol))
                        {
                            sMsg = sMsg + "El Campo Rol no existe\n";
                        }
                    }
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

    public bool ValidaDataDuplication(ObservatorioCS.objectBussinessObservatorio MyDataObservatorio, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataObservatorio.Clave == -1)
        {
            if (MyDataObservatorio.ValidaExistencia(MyDataObservatorio.Clave))
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
    public DataSet FillDataColor(String sFiltro)
    {
        ObservatorioCS.objectBussinessObservatorio myObservatorio = new ObservatorioCS.objectBussinessObservatorio();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myObservatorio.FillDataColor().Copy());
        else
            ds.Tables.Add(myObservatorio.FillDataColor(sFiltro).Copy());
        myObservatorio.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataColorCDD(string knownCategoryValues, string category)
    {
        ObservatorioCS.objectBussinessObservatorio myObservatorio = new ObservatorioCS.objectBussinessObservatorio();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myObservatorio.FillDataColor();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Descripcion"].ToString(), dRow["Clave"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myObservatorio.Dispose();
        return values.ToArray();
    }    [WebMethod]
    public DataSet FillDataTipo_de_Observatorio(String sFiltro)
    {
        ObservatorioCS.objectBussinessObservatorio myObservatorio = new ObservatorioCS.objectBussinessObservatorio();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myObservatorio.FillDataTipo_de_Observatorio().Copy());
        else
            ds.Tables.Add(myObservatorio.FillDataTipo_de_Observatorio(sFiltro).Copy());
        myObservatorio.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataTipo_de_ObservatorioCDD(string knownCategoryValues, string category)
    {
        ObservatorioCS.objectBussinessObservatorio myObservatorio = new ObservatorioCS.objectBussinessObservatorio();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myObservatorio.FillDataTipo_de_Observatorio();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Descripcion"].ToString(), dRow["Clave"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myObservatorio.Dispose();
        return values.ToArray();
    }    [WebMethod]
    public DataSet FillDataAdministrador(String sFiltro)
    {
        ObservatorioCS.objectBussinessObservatorio myObservatorio = new ObservatorioCS.objectBussinessObservatorio();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myObservatorio.FillDataAdministrador().Copy());
        else
            ds.Tables.Add(myObservatorio.FillDataAdministrador(sFiltro).Copy());
        myObservatorio.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataAdministradorCDD(string knownCategoryValues, string category)
    {
        ObservatorioCS.objectBussinessObservatorio myObservatorio = new ObservatorioCS.objectBussinessObservatorio();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myObservatorio.FillDataAdministrador();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["Folio"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myObservatorio.Dispose();
        return values.ToArray();
    }
}
