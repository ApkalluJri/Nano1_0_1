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
public class objectBussinessOpciones_de_Solicitud_via_App : System.Web.Services.WebService
{
    public int iProcess = 29991;
    private TTTraductor.Traductor MyTraductor;
    


    [WebMethod]
    public string ListaGetFullQuery(string sWhere,string sOrder)
    {
	Opciones_de_Solicitud_via_AppCS.objectBussinessOpciones_de_Solicitud_via_App myOpciones_de_Solicitud_via_App = new Opciones_de_Solicitud_via_AppCS.objectBussinessOpciones_de_Solicitud_via_App();
        string result = myOpciones_de_Solicitud_via_App.GetFullQuery(sWhere, sOrder);
	myOpciones_de_Solicitud_via_App.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ListaSelAll(int startRowIndex,int maximumRows,string where,string Order)
    {
	Opciones_de_Solicitud_via_AppCS.objectBussinessOpciones_de_Solicitud_via_App myOpciones_de_Solicitud_via_App = new Opciones_de_Solicitud_via_AppCS.objectBussinessOpciones_de_Solicitud_via_App();
        DataSet result = myOpciones_de_Solicitud_via_App.SelAll(startRowIndex, maximumRows, where, Order);
	myOpciones_de_Solicitud_via_App.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ImpresionSelAll(string where, string Order)
    {
	Opciones_de_Solicitud_via_AppCS.objectBussinessOpciones_de_Solicitud_via_App myOpciones_de_Solicitud_via_App = new Opciones_de_Solicitud_via_AppCS.objectBussinessOpciones_de_Solicitud_via_App();
        DataSet result = myOpciones_de_Solicitud_via_App.SelAll(where, Order);
	myOpciones_de_Solicitud_via_App.Dispose();
        return result;
    }

    [WebMethod]
    public int ListaSelCount(string where)
    {
	Opciones_de_Solicitud_via_AppCS.objectBussinessOpciones_de_Solicitud_via_App myOpciones_de_Solicitud_via_App = new Opciones_de_Solicitud_via_AppCS.objectBussinessOpciones_de_Solicitud_via_App();
        int result = myOpciones_de_Solicitud_via_App.SelCount(where);
	myOpciones_de_Solicitud_via_App.Dispose();
        return result;
    }


    [WebMethod]
    public Int32 SelCount()
    {
	Opciones_de_Solicitud_via_AppCS.objectBussinessOpciones_de_Solicitud_via_App myOpciones_de_Solicitud_via_App = new Opciones_de_Solicitud_via_AppCS.objectBussinessOpciones_de_Solicitud_via_App();
        Int32 result = myOpciones_de_Solicitud_via_App.SelCount();
	myOpciones_de_Solicitud_via_App.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
	Opciones_de_Solicitud_via_AppCS.objectBussinessOpciones_de_Solicitud_via_App myOpciones_de_Solicitud_via_App = new Opciones_de_Solicitud_via_AppCS.objectBussinessOpciones_de_Solicitud_via_App();
        DataSet result = myOpciones_de_Solicitud_via_App.SelAll(ConRelaciones);
	myOpciones_de_Solicitud_via_App.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, Opciones_de_Solicitud_via_AppCS.Opciones_de_Solicitud_via_AppFilters[] myFilters)
    {
        Opciones_de_Solicitud_via_AppCS.objectBussinessOpciones_de_Solicitud_via_App myOpciones_de_Solicitud_via_App = new Opciones_de_Solicitud_via_AppCS.objectBussinessOpciones_de_Solicitud_via_App();
        myOpciones_de_Solicitud_via_App.Filters = myFilters;
        DataSet result = myOpciones_de_Solicitud_via_App.SelAll(ConRelaciones);
        myOpciones_de_Solicitud_via_App.Filters = null;
        myOpciones_de_Solicitud_via_App.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        Opciones_de_Solicitud_via_AppCS.objectBussinessOpciones_de_Solicitud_via_App myOpciones_de_Solicitud_via_App = new Opciones_de_Solicitud_via_AppCS.objectBussinessOpciones_de_Solicitud_via_App();
        DataSet ds = new DataSet();
        ds.Tables.Add(myOpciones_de_Solicitud_via_App.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        myOpciones_de_Solicitud_via_App.Dispose(); 
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, String varDescripcion)
    {
        Opciones_de_Solicitud_via_AppCS.objectBussinessOpciones_de_Solicitud_via_App  myOpciones_de_Solicitud_via_App = new Opciones_de_Solicitud_via_AppCS.objectBussinessOpciones_de_Solicitud_via_App();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myOpciones_de_Solicitud_via_App.Descripcion = varDescripcion;

        String sMsg = "";
        if (!ValidaDataToSave(myOpciones_de_Solicitud_via_App, out sMsg))
        {
            myOpciones_de_Solicitud_via_App.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myOpciones_de_Solicitud_via_App, out sMsg))
        {
            myOpciones_de_Solicitud_via_App.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        myOpciones_de_Solicitud_via_App.Insert(globalInfo, dr);
        myOpciones_de_Solicitud_via_App.Dispose();
        dr = null;
        globalInfo = null;
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, String varDescripcion)
    {
        Opciones_de_Solicitud_via_AppCS.objectBussinessOpciones_de_Solicitud_via_App  myOpciones_de_Solicitud_via_App= new Opciones_de_Solicitud_via_AppCS.objectBussinessOpciones_de_Solicitud_via_App();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myOpciones_de_Solicitud_via_App.Descripcion = varDescripcion;

        String sMsg = "";
        if (!ValidaDataToSave(myOpciones_de_Solicitud_via_App, out sMsg))
        {
            myOpciones_de_Solicitud_via_App.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myOpciones_de_Solicitud_via_App, out sMsg))
        {
            myOpciones_de_Solicitud_via_App.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        object result=myOpciones_de_Solicitud_via_App.InsertWithReturnValue(globalInfo, dr);
        myOpciones_de_Solicitud_via_App.Dispose();
        dr = null;
        globalInfo = null;
        return result;
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varClave, String varDescripcion)
    {
        Opciones_de_Solicitud_via_AppCS.objectBussinessOpciones_de_Solicitud_via_App myOpciones_de_Solicitud_via_App = new Opciones_de_Solicitud_via_AppCS.objectBussinessOpciones_de_Solicitud_via_App();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myOpciones_de_Solicitud_via_App.Clave = varClave;
        myOpciones_de_Solicitud_via_App.Descripcion = varDescripcion;

            String sMsg = "";
            if (!ValidaDataToSave(myOpciones_de_Solicitud_via_App, out sMsg))
            {
                myOpciones_de_Solicitud_via_App.Dispose();
                dr = null;
                globalInfo = null;
                throw new Exception(sMsg);
            }
            myOpciones_de_Solicitud_via_App.Update(globalInfo, dr);
            myOpciones_de_Solicitud_via_App.Dispose();
            dr = null;
            globalInfo = null;
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyClave)
    {
        Opciones_de_Solicitud_via_AppCS.objectBussinessOpciones_de_Solicitud_via_App myOpciones_de_Solicitud_via_App = new Opciones_de_Solicitud_via_AppCS.objectBussinessOpciones_de_Solicitud_via_App();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        bool result = myOpciones_de_Solicitud_via_App.Delete(KeyClave, globalInfo, dr);
        myOpciones_de_Solicitud_via_App.Dispose();
        dr = null;
        return result;
    }

    [WebMethod]
    public Opciones_de_Solicitud_via_AppCS.objectBussinessOpciones_de_Solicitud_via_App GetByKey(int? KeyClave, Boolean ConRelaciones)
    {
        Opciones_de_Solicitud_via_AppCS.objectBussinessOpciones_de_Solicitud_via_App myOpciones_de_Solicitud_via_App = new Opciones_de_Solicitud_via_AppCS.objectBussinessOpciones_de_Solicitud_via_App();
        myOpciones_de_Solicitud_via_App.GetByKey(KeyClave, ConRelaciones);;
        return myOpciones_de_Solicitud_via_App;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyClave)
    {
        Opciones_de_Solicitud_via_AppCS.objectBussinessOpciones_de_Solicitud_via_App myOpciones_de_Solicitud_via_App = new Opciones_de_Solicitud_via_AppCS.objectBussinessOpciones_de_Solicitud_via_App();
        Int32 result = myOpciones_de_Solicitud_via_App.CurrentPosicion(KeyClave);
        return result;
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyClave)
    {
        Opciones_de_Solicitud_via_AppCS.objectBussinessOpciones_de_Solicitud_via_App myOpciones_de_Solicitud_via_App = new Opciones_de_Solicitud_via_AppCS.objectBussinessOpciones_de_Solicitud_via_App();
        Boolean result = myOpciones_de_Solicitud_via_App.ValidaExistencia(KeyClave);
        myOpciones_de_Solicitud_via_App.Dispose();
        return result;
    }

    private bool ValidaDataToSave(Opciones_de_Solicitud_via_AppCS.objectBussinessOpciones_de_Solicitud_via_App MyDataOpciones_de_Solicitud_via_App, out String sMsg)
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

    public bool ValidaDataDuplication(Opciones_de_Solicitud_via_AppCS.objectBussinessOpciones_de_Solicitud_via_App MyDataOpciones_de_Solicitud_via_App, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataOpciones_de_Solicitud_via_App.Clave == -1)
        {
            if (MyDataOpciones_de_Solicitud_via_App.ValidaExistencia(MyDataOpciones_de_Solicitud_via_App.Clave))
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
