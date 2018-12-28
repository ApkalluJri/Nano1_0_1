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
public class objectBussinessDetalle_de_Notificacion_por_Usuario : System.Web.Services.WebService
{
    public int iProcess = 31011;
    private TTTraductor.Traductor MyTraductor;
    


    [WebMethod]
    public string ListaGetFullQuery(string sWhere,string sOrder)
    {
	Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario myDetalle_de_Notificacion_por_Usuario = new Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario();
        string result = myDetalle_de_Notificacion_por_Usuario.GetFullQuery(sWhere, sOrder);
	myDetalle_de_Notificacion_por_Usuario.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ListaSelAll(int startRowIndex,int maximumRows,string where,string Order)
    {
	Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario myDetalle_de_Notificacion_por_Usuario = new Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario();
        DataSet result = myDetalle_de_Notificacion_por_Usuario.SelAll(startRowIndex, maximumRows, where, Order);
	myDetalle_de_Notificacion_por_Usuario.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ImpresionSelAll(string where, string Order)
    {
	Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario myDetalle_de_Notificacion_por_Usuario = new Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario();
        DataSet result = myDetalle_de_Notificacion_por_Usuario.SelAll(where, Order);
	myDetalle_de_Notificacion_por_Usuario.Dispose();
        return result;
    }

    [WebMethod]
    public int ListaSelCount(string where)
    {
	Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario myDetalle_de_Notificacion_por_Usuario = new Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario();
        int result = myDetalle_de_Notificacion_por_Usuario.SelCount(where);
	myDetalle_de_Notificacion_por_Usuario.Dispose();
        return result;
    }


    [WebMethod]
    public Int32 SelCount()
    {
	Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario myDetalle_de_Notificacion_por_Usuario = new Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario();
        Int32 result = myDetalle_de_Notificacion_por_Usuario.SelCount();
	myDetalle_de_Notificacion_por_Usuario.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
	Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario myDetalle_de_Notificacion_por_Usuario = new Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario();
        DataSet result = myDetalle_de_Notificacion_por_Usuario.SelAll(ConRelaciones);
	myDetalle_de_Notificacion_por_Usuario.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, Detalle_de_Notificacion_por_UsuarioCS.Detalle_de_Notificacion_por_UsuarioFilters[] myFilters)
    {
        Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario myDetalle_de_Notificacion_por_Usuario = new Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario();
        myDetalle_de_Notificacion_por_Usuario.Filters = myFilters;
        DataSet result = myDetalle_de_Notificacion_por_Usuario.SelAll(ConRelaciones);
        myDetalle_de_Notificacion_por_Usuario.Filters = null;
        myDetalle_de_Notificacion_por_Usuario.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario myDetalle_de_Notificacion_por_Usuario = new Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario();
        DataSet ds = new DataSet();
        ds.Tables.Add(myDetalle_de_Notificacion_por_Usuario.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        myDetalle_de_Notificacion_por_Usuario.Dispose(); 
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varContenido, Boolean varNotificar, int? varObservatorio, int? varID_del_Cliente, String varNombre)
    {
        Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario  myDetalle_de_Notificacion_por_Usuario = new Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myDetalle_de_Notificacion_por_Usuario.Contenido = varContenido;
        myDetalle_de_Notificacion_por_Usuario.Notificar = varNotificar;
        myDetalle_de_Notificacion_por_Usuario.Observatorio = varObservatorio;
        myDetalle_de_Notificacion_por_Usuario.ID_del_Cliente = varID_del_Cliente;
        myDetalle_de_Notificacion_por_Usuario.Nombre = varNombre;

        String sMsg = "";
        if (!ValidaDataToSave(myDetalle_de_Notificacion_por_Usuario, out sMsg))
        {
            myDetalle_de_Notificacion_por_Usuario.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myDetalle_de_Notificacion_por_Usuario, out sMsg))
        {
            myDetalle_de_Notificacion_por_Usuario.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        myDetalle_de_Notificacion_por_Usuario.Insert(globalInfo, dr);
        myDetalle_de_Notificacion_por_Usuario.Dispose();
        dr = null;
        globalInfo = null;
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, int? varContenido, Boolean varNotificar, int? varObservatorio, int? varID_del_Cliente, String varNombre)
    {
        Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario  myDetalle_de_Notificacion_por_Usuario= new Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myDetalle_de_Notificacion_por_Usuario.Contenido = varContenido;
        myDetalle_de_Notificacion_por_Usuario.Notificar = varNotificar;
        myDetalle_de_Notificacion_por_Usuario.Observatorio = varObservatorio;
        myDetalle_de_Notificacion_por_Usuario.ID_del_Cliente = varID_del_Cliente;
        myDetalle_de_Notificacion_por_Usuario.Nombre = varNombre;

        String sMsg = "";
        if (!ValidaDataToSave(myDetalle_de_Notificacion_por_Usuario, out sMsg))
        {
            myDetalle_de_Notificacion_por_Usuario.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myDetalle_de_Notificacion_por_Usuario, out sMsg))
        {
            myDetalle_de_Notificacion_por_Usuario.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        object result=myDetalle_de_Notificacion_por_Usuario.InsertWithReturnValue(globalInfo, dr);
        myDetalle_de_Notificacion_por_Usuario.Dispose();
        dr = null;
        globalInfo = null;
        return result;
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varClave, int? varContenido, Boolean varNotificar, int? varObservatorio, int? varID_del_Cliente, String varNombre)
    {
        Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario myDetalle_de_Notificacion_por_Usuario = new Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myDetalle_de_Notificacion_por_Usuario.Clave = varClave;
        myDetalle_de_Notificacion_por_Usuario.Contenido = varContenido;
        myDetalle_de_Notificacion_por_Usuario.Notificar = varNotificar;
        myDetalle_de_Notificacion_por_Usuario.Observatorio = varObservatorio;
        myDetalle_de_Notificacion_por_Usuario.ID_del_Cliente = varID_del_Cliente;
        myDetalle_de_Notificacion_por_Usuario.Nombre = varNombre;

            String sMsg = "";
            if (!ValidaDataToSave(myDetalle_de_Notificacion_por_Usuario, out sMsg))
            {
                myDetalle_de_Notificacion_por_Usuario.Dispose();
                dr = null;
                globalInfo = null;
                throw new Exception(sMsg);
            }
            myDetalle_de_Notificacion_por_Usuario.Update(globalInfo, dr);
            myDetalle_de_Notificacion_por_Usuario.Dispose();
            dr = null;
            globalInfo = null;
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyClave, int? KeyContenido)
    {
        Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario myDetalle_de_Notificacion_por_Usuario = new Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        bool result = myDetalle_de_Notificacion_por_Usuario.Delete(KeyClave, KeyContenido, globalInfo, dr);
        myDetalle_de_Notificacion_por_Usuario.Dispose();
        dr = null;
        return result;
    }

    [WebMethod]
    public Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario GetByKey(int? KeyClave, int? KeyContenido, Boolean ConRelaciones)
    {
        Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario myDetalle_de_Notificacion_por_Usuario = new Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario();
        myDetalle_de_Notificacion_por_Usuario.GetByKey(KeyClave, KeyContenido, ConRelaciones);;
        return myDetalle_de_Notificacion_por_Usuario;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyClave, int? KeyContenido)
    {
        Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario myDetalle_de_Notificacion_por_Usuario = new Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario();
        Int32 result = myDetalle_de_Notificacion_por_Usuario.CurrentPosicion(KeyClave, KeyContenido);
        return result;
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyClave, int? KeyContenido)
    {
        Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario myDetalle_de_Notificacion_por_Usuario = new Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario();
        Boolean result = myDetalle_de_Notificacion_por_Usuario.ValidaExistencia(KeyClave, KeyContenido);
        myDetalle_de_Notificacion_por_Usuario.Dispose();
        return result;
    }

    private bool ValidaDataToSave(Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario MyDataDetalle_de_Notificacion_por_Usuario, out String sMsg)
    {
        //Validaciones
        sMsg = "";
            if (MyDataDetalle_de_Notificacion_por_Usuario.Observatorio != null)
            {
                ObservatorioCS.objectBussinessObservatorio MyDataObservatorioTemp = new ObservatorioCS.objectBussinessObservatorio();
                if (!MyDataObservatorioTemp.ValidaExistencia(MyDataDetalle_de_Notificacion_por_Usuario.Observatorio))
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

    public bool ValidaDataDuplication(Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario MyDataDetalle_de_Notificacion_por_Usuario, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataDetalle_de_Notificacion_por_Usuario.Clave == -1&& MyDataDetalle_de_Notificacion_por_Usuario.Contenido != null)
        {
            if (MyDataDetalle_de_Notificacion_por_Usuario.ValidaExistencia(MyDataDetalle_de_Notificacion_por_Usuario.Clave, MyDataDetalle_de_Notificacion_por_Usuario.Contenido))
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
        Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario myDetalle_de_Notificacion_por_Usuario = new Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myDetalle_de_Notificacion_por_Usuario.FillDataContenido().Copy());
        else
            ds.Tables.Add(myDetalle_de_Notificacion_por_Usuario.FillDataContenido(sFiltro).Copy());
        myDetalle_de_Notificacion_por_Usuario.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataContenidoCDD(string knownCategoryValues, string category)
    {
        Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario myDetalle_de_Notificacion_por_Usuario = new Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myDetalle_de_Notificacion_por_Usuario.FillDataContenido();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Folio"].ToString(), dRow["Folio"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myDetalle_de_Notificacion_por_Usuario.Dispose();
        return values.ToArray();
    }    [WebMethod]
    public DataSet FillDataObservatorio(String sFiltro)
    {
        Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario myDetalle_de_Notificacion_por_Usuario = new Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myDetalle_de_Notificacion_por_Usuario.FillDataObservatorio().Copy());
        else
            ds.Tables.Add(myDetalle_de_Notificacion_por_Usuario.FillDataObservatorio(sFiltro).Copy());
        myDetalle_de_Notificacion_por_Usuario.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataObservatorioCDD(string knownCategoryValues, string category)
    {
        Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario myDetalle_de_Notificacion_por_Usuario = new Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myDetalle_de_Notificacion_por_Usuario.FillDataObservatorio();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["Clave"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myDetalle_de_Notificacion_por_Usuario.Dispose();
        return values.ToArray();
    }
}
