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
public class objectBussinessEstatus_de_Solicitud_Via_App : System.Web.Services.WebService
{
    public int iProcess = 30328;
    private TTTraductor.Traductor MyTraductor;
    


    [WebMethod]
    public string ListaGetFullQuery(string sWhere,string sOrder)
    {
	Estatus_de_Solicitud_Via_AppCS.objectBussinessEstatus_de_Solicitud_Via_App myEstatus_de_Solicitud_Via_App = new Estatus_de_Solicitud_Via_AppCS.objectBussinessEstatus_de_Solicitud_Via_App();
        string result = myEstatus_de_Solicitud_Via_App.GetFullQuery(sWhere, sOrder);
	myEstatus_de_Solicitud_Via_App.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ListaSelAll(int startRowIndex,int maximumRows,string where,string Order)
    {
	Estatus_de_Solicitud_Via_AppCS.objectBussinessEstatus_de_Solicitud_Via_App myEstatus_de_Solicitud_Via_App = new Estatus_de_Solicitud_Via_AppCS.objectBussinessEstatus_de_Solicitud_Via_App();
        DataSet result = myEstatus_de_Solicitud_Via_App.SelAll(startRowIndex, maximumRows, where, Order);
	myEstatus_de_Solicitud_Via_App.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ImpresionSelAll(string where, string Order)
    {
	Estatus_de_Solicitud_Via_AppCS.objectBussinessEstatus_de_Solicitud_Via_App myEstatus_de_Solicitud_Via_App = new Estatus_de_Solicitud_Via_AppCS.objectBussinessEstatus_de_Solicitud_Via_App();
        DataSet result = myEstatus_de_Solicitud_Via_App.SelAll(where, Order);
	myEstatus_de_Solicitud_Via_App.Dispose();
        return result;
    }

    [WebMethod]
    public int ListaSelCount(string where)
    {
	Estatus_de_Solicitud_Via_AppCS.objectBussinessEstatus_de_Solicitud_Via_App myEstatus_de_Solicitud_Via_App = new Estatus_de_Solicitud_Via_AppCS.objectBussinessEstatus_de_Solicitud_Via_App();
        int result = myEstatus_de_Solicitud_Via_App.SelCount(where);
	myEstatus_de_Solicitud_Via_App.Dispose();
        return result;
    }


    [WebMethod]
    public Int32 SelCount()
    {
	Estatus_de_Solicitud_Via_AppCS.objectBussinessEstatus_de_Solicitud_Via_App myEstatus_de_Solicitud_Via_App = new Estatus_de_Solicitud_Via_AppCS.objectBussinessEstatus_de_Solicitud_Via_App();
        Int32 result = myEstatus_de_Solicitud_Via_App.SelCount();
	myEstatus_de_Solicitud_Via_App.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
	Estatus_de_Solicitud_Via_AppCS.objectBussinessEstatus_de_Solicitud_Via_App myEstatus_de_Solicitud_Via_App = new Estatus_de_Solicitud_Via_AppCS.objectBussinessEstatus_de_Solicitud_Via_App();
        DataSet result = myEstatus_de_Solicitud_Via_App.SelAll(ConRelaciones);
	myEstatus_de_Solicitud_Via_App.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, Estatus_de_Solicitud_Via_AppCS.Estatus_de_Solicitud_Via_AppFilters[] myFilters)
    {
        Estatus_de_Solicitud_Via_AppCS.objectBussinessEstatus_de_Solicitud_Via_App myEstatus_de_Solicitud_Via_App = new Estatus_de_Solicitud_Via_AppCS.objectBussinessEstatus_de_Solicitud_Via_App();
        myEstatus_de_Solicitud_Via_App.Filters = myFilters;
        DataSet result = myEstatus_de_Solicitud_Via_App.SelAll(ConRelaciones);
        myEstatus_de_Solicitud_Via_App.Filters = null;
        myEstatus_de_Solicitud_Via_App.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        Estatus_de_Solicitud_Via_AppCS.objectBussinessEstatus_de_Solicitud_Via_App myEstatus_de_Solicitud_Via_App = new Estatus_de_Solicitud_Via_AppCS.objectBussinessEstatus_de_Solicitud_Via_App();
        DataSet ds = new DataSet();
        ds.Tables.Add(myEstatus_de_Solicitud_Via_App.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        myEstatus_de_Solicitud_Via_App.Dispose(); 
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, String varDescripcion)
    {
        Estatus_de_Solicitud_Via_AppCS.objectBussinessEstatus_de_Solicitud_Via_App  myEstatus_de_Solicitud_Via_App = new Estatus_de_Solicitud_Via_AppCS.objectBussinessEstatus_de_Solicitud_Via_App();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myEstatus_de_Solicitud_Via_App.Descripcion = varDescripcion;

        String sMsg = "";
        if (!ValidaDataToSave(myEstatus_de_Solicitud_Via_App, out sMsg))
        {
            myEstatus_de_Solicitud_Via_App.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myEstatus_de_Solicitud_Via_App, out sMsg))
        {
            myEstatus_de_Solicitud_Via_App.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        myEstatus_de_Solicitud_Via_App.Insert(globalInfo, dr);
        myEstatus_de_Solicitud_Via_App.Dispose();
        dr = null;
        globalInfo = null;
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, String varDescripcion)
    {
        Estatus_de_Solicitud_Via_AppCS.objectBussinessEstatus_de_Solicitud_Via_App  myEstatus_de_Solicitud_Via_App= new Estatus_de_Solicitud_Via_AppCS.objectBussinessEstatus_de_Solicitud_Via_App();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myEstatus_de_Solicitud_Via_App.Descripcion = varDescripcion;

        String sMsg = "";
        if (!ValidaDataToSave(myEstatus_de_Solicitud_Via_App, out sMsg))
        {
            myEstatus_de_Solicitud_Via_App.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myEstatus_de_Solicitud_Via_App, out sMsg))
        {
            myEstatus_de_Solicitud_Via_App.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        object result=myEstatus_de_Solicitud_Via_App.InsertWithReturnValue(globalInfo, dr);
        myEstatus_de_Solicitud_Via_App.Dispose();
        dr = null;
        globalInfo = null;
        return result;
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varClave, String varDescripcion)
    {
        Estatus_de_Solicitud_Via_AppCS.objectBussinessEstatus_de_Solicitud_Via_App myEstatus_de_Solicitud_Via_App = new Estatus_de_Solicitud_Via_AppCS.objectBussinessEstatus_de_Solicitud_Via_App();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myEstatus_de_Solicitud_Via_App.Clave = varClave;
        myEstatus_de_Solicitud_Via_App.Descripcion = varDescripcion;

            String sMsg = "";
            if (!ValidaDataToSave(myEstatus_de_Solicitud_Via_App, out sMsg))
            {
                myEstatus_de_Solicitud_Via_App.Dispose();
                dr = null;
                globalInfo = null;
                throw new Exception(sMsg);
            }
            myEstatus_de_Solicitud_Via_App.Update(globalInfo, dr);
            myEstatus_de_Solicitud_Via_App.Dispose();
            dr = null;
            globalInfo = null;
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyClave)
    {
        Estatus_de_Solicitud_Via_AppCS.objectBussinessEstatus_de_Solicitud_Via_App myEstatus_de_Solicitud_Via_App = new Estatus_de_Solicitud_Via_AppCS.objectBussinessEstatus_de_Solicitud_Via_App();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        bool result = myEstatus_de_Solicitud_Via_App.Delete(KeyClave, globalInfo, dr);
        myEstatus_de_Solicitud_Via_App.Dispose();
        dr = null;
        return result;
    }

    [WebMethod]
    public Estatus_de_Solicitud_Via_AppCS.objectBussinessEstatus_de_Solicitud_Via_App GetByKey(int? KeyClave, Boolean ConRelaciones)
    {
        Estatus_de_Solicitud_Via_AppCS.objectBussinessEstatus_de_Solicitud_Via_App myEstatus_de_Solicitud_Via_App = new Estatus_de_Solicitud_Via_AppCS.objectBussinessEstatus_de_Solicitud_Via_App();
        myEstatus_de_Solicitud_Via_App.GetByKey(KeyClave, ConRelaciones);;
        return myEstatus_de_Solicitud_Via_App;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyClave)
    {
        Estatus_de_Solicitud_Via_AppCS.objectBussinessEstatus_de_Solicitud_Via_App myEstatus_de_Solicitud_Via_App = new Estatus_de_Solicitud_Via_AppCS.objectBussinessEstatus_de_Solicitud_Via_App();
        Int32 result = myEstatus_de_Solicitud_Via_App.CurrentPosicion(KeyClave);
        return result;
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyClave)
    {
        Estatus_de_Solicitud_Via_AppCS.objectBussinessEstatus_de_Solicitud_Via_App myEstatus_de_Solicitud_Via_App = new Estatus_de_Solicitud_Via_AppCS.objectBussinessEstatus_de_Solicitud_Via_App();
        Boolean result = myEstatus_de_Solicitud_Via_App.ValidaExistencia(KeyClave);
        myEstatus_de_Solicitud_Via_App.Dispose();
        return result;
    }

    private bool ValidaDataToSave(Estatus_de_Solicitud_Via_AppCS.objectBussinessEstatus_de_Solicitud_Via_App MyDataEstatus_de_Solicitud_Via_App, out String sMsg)
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

    public bool ValidaDataDuplication(Estatus_de_Solicitud_Via_AppCS.objectBussinessEstatus_de_Solicitud_Via_App MyDataEstatus_de_Solicitud_Via_App, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataEstatus_de_Solicitud_Via_App.Clave == -1)
        {
            if (MyDataEstatus_de_Solicitud_Via_App.ValidaExistencia(MyDataEstatus_de_Solicitud_Via_App.Clave))
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

}
