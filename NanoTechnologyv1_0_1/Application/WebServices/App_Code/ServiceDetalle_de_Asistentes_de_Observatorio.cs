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
public class objectBussinessDetalle_de_Asistentes_de_Observatorio : System.Web.Services.WebService
{
    public int iProcess = 30353;
    private TTTraductor.Traductor MyTraductor;
    


    [WebMethod]
    public string ListaGetFullQuery(string sWhere,string sOrder)
    {
	Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio myDetalle_de_Asistentes_de_Observatorio = new Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio();
        string result = myDetalle_de_Asistentes_de_Observatorio.GetFullQuery(sWhere, sOrder);
	myDetalle_de_Asistentes_de_Observatorio.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ListaSelAll(int startRowIndex,int maximumRows,string where,string Order)
    {
	Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio myDetalle_de_Asistentes_de_Observatorio = new Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio();
        DataSet result = myDetalle_de_Asistentes_de_Observatorio.SelAll(startRowIndex, maximumRows, where, Order);
	myDetalle_de_Asistentes_de_Observatorio.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ImpresionSelAll(string where, string Order)
    {
	Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio myDetalle_de_Asistentes_de_Observatorio = new Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio();
        DataSet result = myDetalle_de_Asistentes_de_Observatorio.SelAll(where, Order);
	myDetalle_de_Asistentes_de_Observatorio.Dispose();
        return result;
    }

    [WebMethod]
    public int ListaSelCount(string where)
    {
	Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio myDetalle_de_Asistentes_de_Observatorio = new Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio();
        int result = myDetalle_de_Asistentes_de_Observatorio.SelCount(where);
	myDetalle_de_Asistentes_de_Observatorio.Dispose();
        return result;
    }


    [WebMethod]
    public Int32 SelCount()
    {
	Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio myDetalle_de_Asistentes_de_Observatorio = new Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio();
        Int32 result = myDetalle_de_Asistentes_de_Observatorio.SelCount();
	myDetalle_de_Asistentes_de_Observatorio.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
	Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio myDetalle_de_Asistentes_de_Observatorio = new Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio();
        DataSet result = myDetalle_de_Asistentes_de_Observatorio.SelAll(ConRelaciones);
	myDetalle_de_Asistentes_de_Observatorio.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, Detalle_de_Asistentes_de_ObservatorioCS.Detalle_de_Asistentes_de_ObservatorioFilters[] myFilters)
    {
        Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio myDetalle_de_Asistentes_de_Observatorio = new Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio();
        myDetalle_de_Asistentes_de_Observatorio.Filters = myFilters;
        DataSet result = myDetalle_de_Asistentes_de_Observatorio.SelAll(ConRelaciones);
        myDetalle_de_Asistentes_de_Observatorio.Filters = null;
        myDetalle_de_Asistentes_de_Observatorio.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio myDetalle_de_Asistentes_de_Observatorio = new Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio();
        DataSet ds = new DataSet();
        ds.Tables.Add(myDetalle_de_Asistentes_de_Observatorio.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        myDetalle_de_Asistentes_de_Observatorio.Dispose(); 
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varObservatorio, int? varNombre, int? varRol)
    {
        Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio  myDetalle_de_Asistentes_de_Observatorio = new Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myDetalle_de_Asistentes_de_Observatorio.Observatorio = varObservatorio;
        myDetalle_de_Asistentes_de_Observatorio.Nombre = varNombre;
        myDetalle_de_Asistentes_de_Observatorio.Rol = varRol;

        String sMsg = "";
        if (!ValidaDataToSave(myDetalle_de_Asistentes_de_Observatorio, out sMsg))
        {
            myDetalle_de_Asistentes_de_Observatorio.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myDetalle_de_Asistentes_de_Observatorio, out sMsg))
        {
            myDetalle_de_Asistentes_de_Observatorio.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        myDetalle_de_Asistentes_de_Observatorio.Insert(globalInfo, dr);
        myDetalle_de_Asistentes_de_Observatorio.Dispose();
        dr = null;
        globalInfo = null;
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, int? varObservatorio, int? varNombre, int? varRol)
    {
        Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio  myDetalle_de_Asistentes_de_Observatorio= new Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myDetalle_de_Asistentes_de_Observatorio.Observatorio = varObservatorio;
        myDetalle_de_Asistentes_de_Observatorio.Nombre = varNombre;
        myDetalle_de_Asistentes_de_Observatorio.Rol = varRol;

        String sMsg = "";
        if (!ValidaDataToSave(myDetalle_de_Asistentes_de_Observatorio, out sMsg))
        {
            myDetalle_de_Asistentes_de_Observatorio.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myDetalle_de_Asistentes_de_Observatorio, out sMsg))
        {
            myDetalle_de_Asistentes_de_Observatorio.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        object result=myDetalle_de_Asistentes_de_Observatorio.InsertWithReturnValue(globalInfo, dr);
        myDetalle_de_Asistentes_de_Observatorio.Dispose();
        dr = null;
        globalInfo = null;
        return result;
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varClave, int? varObservatorio, int? varNombre, int? varRol)
    {
        Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio myDetalle_de_Asistentes_de_Observatorio = new Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myDetalle_de_Asistentes_de_Observatorio.Clave = varClave;
        myDetalle_de_Asistentes_de_Observatorio.Observatorio = varObservatorio;
        myDetalle_de_Asistentes_de_Observatorio.Nombre = varNombre;
        myDetalle_de_Asistentes_de_Observatorio.Rol = varRol;

            String sMsg = "";
            if (!ValidaDataToSave(myDetalle_de_Asistentes_de_Observatorio, out sMsg))
            {
                myDetalle_de_Asistentes_de_Observatorio.Dispose();
                dr = null;
                globalInfo = null;
                throw new Exception(sMsg);
            }
            myDetalle_de_Asistentes_de_Observatorio.Update(globalInfo, dr);
            myDetalle_de_Asistentes_de_Observatorio.Dispose();
            dr = null;
            globalInfo = null;
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyClave, int? KeyObservatorio)
    {
        Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio myDetalle_de_Asistentes_de_Observatorio = new Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        bool result = myDetalle_de_Asistentes_de_Observatorio.Delete(KeyClave, KeyObservatorio, globalInfo, dr);
        myDetalle_de_Asistentes_de_Observatorio.Dispose();
        dr = null;
        return result;
    }

    [WebMethod]
    public Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio GetByKey(int? KeyClave, int? KeyObservatorio, Boolean ConRelaciones)
    {
        Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio myDetalle_de_Asistentes_de_Observatorio = new Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio();
        myDetalle_de_Asistentes_de_Observatorio.GetByKey(KeyClave, KeyObservatorio, ConRelaciones);;
        return myDetalle_de_Asistentes_de_Observatorio;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyClave, int? KeyObservatorio)
    {
        Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio myDetalle_de_Asistentes_de_Observatorio = new Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio();
        Int32 result = myDetalle_de_Asistentes_de_Observatorio.CurrentPosicion(KeyClave, KeyObservatorio);
        return result;
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyClave, int? KeyObservatorio)
    {
        Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio myDetalle_de_Asistentes_de_Observatorio = new Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio();
        Boolean result = myDetalle_de_Asistentes_de_Observatorio.ValidaExistencia(KeyClave, KeyObservatorio);
        myDetalle_de_Asistentes_de_Observatorio.Dispose();
        return result;
    }

    private bool ValidaDataToSave(Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio MyDataDetalle_de_Asistentes_de_Observatorio, out String sMsg)
    {
        //Validaciones
        sMsg = "";
            if (MyDataDetalle_de_Asistentes_de_Observatorio.Nombre != null)
            {
                Registro_de_RolesCS.objectBussinessRegistro_de_Roles MyDataRegistro_de_RolesTemp = new Registro_de_RolesCS.objectBussinessRegistro_de_Roles();
                if (!MyDataRegistro_de_RolesTemp.ValidaExistencia(MyDataDetalle_de_Asistentes_de_Observatorio.Nombre))
                {
                    sMsg = sMsg + "El Campo Nombre no existe\n";
                }
            }
            if (MyDataDetalle_de_Asistentes_de_Observatorio.Rol != null)
            {
                Rol_de_UsuarioCS.objectBussinessRol_de_Usuario MyDataRol_de_UsuarioTemp = new Rol_de_UsuarioCS.objectBussinessRol_de_Usuario();
                if (!MyDataRol_de_UsuarioTemp.ValidaExistencia(MyDataDetalle_de_Asistentes_de_Observatorio.Rol))
                {
                    sMsg = sMsg + "El Campo Rol no existe\n";
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

    public bool ValidaDataDuplication(Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio MyDataDetalle_de_Asistentes_de_Observatorio, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataDetalle_de_Asistentes_de_Observatorio.Clave == -1&& MyDataDetalle_de_Asistentes_de_Observatorio.Observatorio != null)
        {
            if (MyDataDetalle_de_Asistentes_de_Observatorio.ValidaExistencia(MyDataDetalle_de_Asistentes_de_Observatorio.Clave, MyDataDetalle_de_Asistentes_de_Observatorio.Observatorio))
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
        Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio myDetalle_de_Asistentes_de_Observatorio = new Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myDetalle_de_Asistentes_de_Observatorio.FillDataObservatorio().Copy());
        else
            ds.Tables.Add(myDetalle_de_Asistentes_de_Observatorio.FillDataObservatorio(sFiltro).Copy());
        myDetalle_de_Asistentes_de_Observatorio.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataObservatorioCDD(string knownCategoryValues, string category)
    {
        Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio myDetalle_de_Asistentes_de_Observatorio = new Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myDetalle_de_Asistentes_de_Observatorio.FillDataObservatorio();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Clave"].ToString(), dRow["Clave"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myDetalle_de_Asistentes_de_Observatorio.Dispose();
        return values.ToArray();
    }    [WebMethod]
    public DataSet FillDataNombre(String sFiltro)
    {
        Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio myDetalle_de_Asistentes_de_Observatorio = new Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myDetalle_de_Asistentes_de_Observatorio.FillDataNombre().Copy());
        else
            ds.Tables.Add(myDetalle_de_Asistentes_de_Observatorio.FillDataNombre(sFiltro).Copy());
        myDetalle_de_Asistentes_de_Observatorio.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataNombreCDD(string knownCategoryValues, string category)
    {
        Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio myDetalle_de_Asistentes_de_Observatorio = new Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myDetalle_de_Asistentes_de_Observatorio.FillDataNombre();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["Folio"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myDetalle_de_Asistentes_de_Observatorio.Dispose();
        return values.ToArray();
    }    [WebMethod]
    public DataSet FillDataRol(String sFiltro)
    {
        Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio myDetalle_de_Asistentes_de_Observatorio = new Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myDetalle_de_Asistentes_de_Observatorio.FillDataRol().Copy());
        else
            ds.Tables.Add(myDetalle_de_Asistentes_de_Observatorio.FillDataRol(sFiltro).Copy());
        myDetalle_de_Asistentes_de_Observatorio.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataRolCDD(string knownCategoryValues, string category)
    {
        Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio myDetalle_de_Asistentes_de_Observatorio = new Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myDetalle_de_Asistentes_de_Observatorio.FillDataRol();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Descripcion"].ToString(), dRow["Clave"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myDetalle_de_Asistentes_de_Observatorio.Dispose();
        return values.ToArray();
    }
}
