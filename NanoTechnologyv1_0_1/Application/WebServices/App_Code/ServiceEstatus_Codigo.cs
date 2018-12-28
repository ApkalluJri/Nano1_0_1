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
public class objectBussinessEstatus_Codigo : System.Web.Services.WebService
{
    public int iProcess = 30070;
    private TTTraductor.Traductor MyTraductor;
    


    [WebMethod]
    public string ListaGetFullQuery(string sWhere,string sOrder)
    {
	Estatus_CodigoCS.objectBussinessEstatus_Codigo myEstatus_Codigo = new Estatus_CodigoCS.objectBussinessEstatus_Codigo();
        string result = myEstatus_Codigo.GetFullQuery(sWhere, sOrder);
	myEstatus_Codigo.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ListaSelAll(int startRowIndex,int maximumRows,string where,string Order)
    {
	Estatus_CodigoCS.objectBussinessEstatus_Codigo myEstatus_Codigo = new Estatus_CodigoCS.objectBussinessEstatus_Codigo();
        DataSet result = myEstatus_Codigo.SelAll(startRowIndex, maximumRows, where, Order);
	myEstatus_Codigo.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ImpresionSelAll(string where, string Order)
    {
	Estatus_CodigoCS.objectBussinessEstatus_Codigo myEstatus_Codigo = new Estatus_CodigoCS.objectBussinessEstatus_Codigo();
        DataSet result = myEstatus_Codigo.SelAll(where, Order);
	myEstatus_Codigo.Dispose();
        return result;
    }

    [WebMethod]
    public int ListaSelCount(string where)
    {
	Estatus_CodigoCS.objectBussinessEstatus_Codigo myEstatus_Codigo = new Estatus_CodigoCS.objectBussinessEstatus_Codigo();
        int result = myEstatus_Codigo.SelCount(where);
	myEstatus_Codigo.Dispose();
        return result;
    }


    [WebMethod]
    public Int32 SelCount()
    {
	Estatus_CodigoCS.objectBussinessEstatus_Codigo myEstatus_Codigo = new Estatus_CodigoCS.objectBussinessEstatus_Codigo();
        Int32 result = myEstatus_Codigo.SelCount();
	myEstatus_Codigo.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
	Estatus_CodigoCS.objectBussinessEstatus_Codigo myEstatus_Codigo = new Estatus_CodigoCS.objectBussinessEstatus_Codigo();
        DataSet result = myEstatus_Codigo.SelAll(ConRelaciones);
	myEstatus_Codigo.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, Estatus_CodigoCS.Estatus_CodigoFilters[] myFilters)
    {
        Estatus_CodigoCS.objectBussinessEstatus_Codigo myEstatus_Codigo = new Estatus_CodigoCS.objectBussinessEstatus_Codigo();
        myEstatus_Codigo.Filters = myFilters;
        DataSet result = myEstatus_Codigo.SelAll(ConRelaciones);
        myEstatus_Codigo.Filters = null;
        myEstatus_Codigo.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        Estatus_CodigoCS.objectBussinessEstatus_Codigo myEstatus_Codigo = new Estatus_CodigoCS.objectBussinessEstatus_Codigo();
        DataSet ds = new DataSet();
        ds.Tables.Add(myEstatus_Codigo.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        myEstatus_Codigo.Dispose(); 
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, String varDescripcion)
    {
        Estatus_CodigoCS.objectBussinessEstatus_Codigo  myEstatus_Codigo = new Estatus_CodigoCS.objectBussinessEstatus_Codigo();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myEstatus_Codigo.Descripcion = varDescripcion;

        String sMsg = "";
        if (!ValidaDataToSave(myEstatus_Codigo, out sMsg))
        {
            myEstatus_Codigo.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myEstatus_Codigo, out sMsg))
        {
            myEstatus_Codigo.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        myEstatus_Codigo.Insert(globalInfo, dr);
        myEstatus_Codigo.Dispose();
        dr = null;
        globalInfo = null;
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, String varDescripcion)
    {
        Estatus_CodigoCS.objectBussinessEstatus_Codigo  myEstatus_Codigo= new Estatus_CodigoCS.objectBussinessEstatus_Codigo();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myEstatus_Codigo.Descripcion = varDescripcion;

        String sMsg = "";
        if (!ValidaDataToSave(myEstatus_Codigo, out sMsg))
        {
            myEstatus_Codigo.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myEstatus_Codigo, out sMsg))
        {
            myEstatus_Codigo.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        object result=myEstatus_Codigo.InsertWithReturnValue(globalInfo, dr);
        myEstatus_Codigo.Dispose();
        dr = null;
        globalInfo = null;
        return result;
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varClave, String varDescripcion)
    {
        Estatus_CodigoCS.objectBussinessEstatus_Codigo myEstatus_Codigo = new Estatus_CodigoCS.objectBussinessEstatus_Codigo();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myEstatus_Codigo.Clave = varClave;
        myEstatus_Codigo.Descripcion = varDescripcion;

            String sMsg = "";
            if (!ValidaDataToSave(myEstatus_Codigo, out sMsg))
            {
                myEstatus_Codigo.Dispose();
                dr = null;
                globalInfo = null;
                throw new Exception(sMsg);
            }
            myEstatus_Codigo.Update(globalInfo, dr);
            myEstatus_Codigo.Dispose();
            dr = null;
            globalInfo = null;
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyClave)
    {
        Estatus_CodigoCS.objectBussinessEstatus_Codigo myEstatus_Codigo = new Estatus_CodigoCS.objectBussinessEstatus_Codigo();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        bool result = myEstatus_Codigo.Delete(KeyClave, globalInfo, dr);
        myEstatus_Codigo.Dispose();
        dr = null;
        return result;
    }

    [WebMethod]
    public Estatus_CodigoCS.objectBussinessEstatus_Codigo GetByKey(int? KeyClave, Boolean ConRelaciones)
    {
        Estatus_CodigoCS.objectBussinessEstatus_Codigo myEstatus_Codigo = new Estatus_CodigoCS.objectBussinessEstatus_Codigo();
        myEstatus_Codigo.GetByKey(KeyClave, ConRelaciones);;
        return myEstatus_Codigo;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyClave)
    {
        Estatus_CodigoCS.objectBussinessEstatus_Codigo myEstatus_Codigo = new Estatus_CodigoCS.objectBussinessEstatus_Codigo();
        Int32 result = myEstatus_Codigo.CurrentPosicion(KeyClave);
        return result;
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyClave)
    {
        Estatus_CodigoCS.objectBussinessEstatus_Codigo myEstatus_Codigo = new Estatus_CodigoCS.objectBussinessEstatus_Codigo();
        Boolean result = myEstatus_Codigo.ValidaExistencia(KeyClave);
        myEstatus_Codigo.Dispose();
        return result;
    }

    private bool ValidaDataToSave(Estatus_CodigoCS.objectBussinessEstatus_Codigo MyDataEstatus_Codigo, out String sMsg)
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

    public bool ValidaDataDuplication(Estatus_CodigoCS.objectBussinessEstatus_Codigo MyDataEstatus_Codigo, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataEstatus_Codigo.Clave == -1)
        {
            if (MyDataEstatus_Codigo.ValidaExistencia(MyDataEstatus_Codigo.Clave))
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
