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
public class objectBussinessAutorizacion : System.Web.Services.WebService
{
    public int iProcess = 30073;
    private TTTraductor.Traductor MyTraductor;
    


    [WebMethod]
    public string ListaGetFullQuery(string sWhere,string sOrder)
    {
	AutorizacionCS.objectBussinessAutorizacion myAutorizacion = new AutorizacionCS.objectBussinessAutorizacion();
        string result = myAutorizacion.GetFullQuery(sWhere, sOrder);
	myAutorizacion.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ListaSelAll(int startRowIndex,int maximumRows,string where,string Order)
    {
	AutorizacionCS.objectBussinessAutorizacion myAutorizacion = new AutorizacionCS.objectBussinessAutorizacion();
        DataSet result = myAutorizacion.SelAll(startRowIndex, maximumRows, where, Order);
	myAutorizacion.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ImpresionSelAll(string where, string Order)
    {
	AutorizacionCS.objectBussinessAutorizacion myAutorizacion = new AutorizacionCS.objectBussinessAutorizacion();
        DataSet result = myAutorizacion.SelAll(where, Order);
	myAutorizacion.Dispose();
        return result;
    }

    [WebMethod]
    public int ListaSelCount(string where)
    {
	AutorizacionCS.objectBussinessAutorizacion myAutorizacion = new AutorizacionCS.objectBussinessAutorizacion();
        int result = myAutorizacion.SelCount(where);
	myAutorizacion.Dispose();
        return result;
    }


    [WebMethod]
    public Int32 SelCount()
    {
	AutorizacionCS.objectBussinessAutorizacion myAutorizacion = new AutorizacionCS.objectBussinessAutorizacion();
        Int32 result = myAutorizacion.SelCount();
	myAutorizacion.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
	AutorizacionCS.objectBussinessAutorizacion myAutorizacion = new AutorizacionCS.objectBussinessAutorizacion();
        DataSet result = myAutorizacion.SelAll(ConRelaciones);
	myAutorizacion.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, AutorizacionCS.AutorizacionFilters[] myFilters)
    {
        AutorizacionCS.objectBussinessAutorizacion myAutorizacion = new AutorizacionCS.objectBussinessAutorizacion();
        myAutorizacion.Filters = myFilters;
        DataSet result = myAutorizacion.SelAll(ConRelaciones);
        myAutorizacion.Filters = null;
        myAutorizacion.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        AutorizacionCS.objectBussinessAutorizacion myAutorizacion = new AutorizacionCS.objectBussinessAutorizacion();
        DataSet ds = new DataSet();
        ds.Tables.Add(myAutorizacion.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        myAutorizacion.Dispose(); 
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, String varDescripcion)
    {
        AutorizacionCS.objectBussinessAutorizacion  myAutorizacion = new AutorizacionCS.objectBussinessAutorizacion();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myAutorizacion.Descripcion = varDescripcion;

        String sMsg = "";
        if (!ValidaDataToSave(myAutorizacion, out sMsg))
        {
            myAutorizacion.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myAutorizacion, out sMsg))
        {
            myAutorizacion.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        myAutorizacion.Insert(globalInfo, dr);
        myAutorizacion.Dispose();
        dr = null;
        globalInfo = null;
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, String varDescripcion)
    {
        AutorizacionCS.objectBussinessAutorizacion  myAutorizacion= new AutorizacionCS.objectBussinessAutorizacion();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myAutorizacion.Descripcion = varDescripcion;

        String sMsg = "";
        if (!ValidaDataToSave(myAutorizacion, out sMsg))
        {
            myAutorizacion.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myAutorizacion, out sMsg))
        {
            myAutorizacion.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        object result=myAutorizacion.InsertWithReturnValue(globalInfo, dr);
        myAutorizacion.Dispose();
        dr = null;
        globalInfo = null;
        return result;
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varClave, String varDescripcion)
    {
        AutorizacionCS.objectBussinessAutorizacion myAutorizacion = new AutorizacionCS.objectBussinessAutorizacion();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myAutorizacion.Clave = varClave;
        myAutorizacion.Descripcion = varDescripcion;

            String sMsg = "";
            if (!ValidaDataToSave(myAutorizacion, out sMsg))
            {
                myAutorizacion.Dispose();
                dr = null;
                globalInfo = null;
                throw new Exception(sMsg);
            }
            myAutorizacion.Update(globalInfo, dr);
            myAutorizacion.Dispose();
            dr = null;
            globalInfo = null;
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyClave)
    {
        AutorizacionCS.objectBussinessAutorizacion myAutorizacion = new AutorizacionCS.objectBussinessAutorizacion();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        bool result = myAutorizacion.Delete(KeyClave, globalInfo, dr);
        myAutorizacion.Dispose();
        dr = null;
        return result;
    }

    [WebMethod]
    public AutorizacionCS.objectBussinessAutorizacion GetByKey(int? KeyClave, Boolean ConRelaciones)
    {
        AutorizacionCS.objectBussinessAutorizacion myAutorizacion = new AutorizacionCS.objectBussinessAutorizacion();
        myAutorizacion.GetByKey(KeyClave, ConRelaciones);;
        return myAutorizacion;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyClave)
    {
        AutorizacionCS.objectBussinessAutorizacion myAutorizacion = new AutorizacionCS.objectBussinessAutorizacion();
        Int32 result = myAutorizacion.CurrentPosicion(KeyClave);
        return result;
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyClave)
    {
        AutorizacionCS.objectBussinessAutorizacion myAutorizacion = new AutorizacionCS.objectBussinessAutorizacion();
        Boolean result = myAutorizacion.ValidaExistencia(KeyClave);
        myAutorizacion.Dispose();
        return result;
    }

    private bool ValidaDataToSave(AutorizacionCS.objectBussinessAutorizacion MyDataAutorizacion, out String sMsg)
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

    public bool ValidaDataDuplication(AutorizacionCS.objectBussinessAutorizacion MyDataAutorizacion, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataAutorizacion.Clave == -1)
        {
            if (MyDataAutorizacion.ValidaExistencia(MyDataAutorizacion.Clave))
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
