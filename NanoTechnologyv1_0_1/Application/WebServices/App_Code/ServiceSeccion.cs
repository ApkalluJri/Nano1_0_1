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
public class objectBussinessSeccion : System.Web.Services.WebService
{
    public int iProcess = 30054;
    private TTTraductor.Traductor MyTraductor;
    


    [WebMethod]
    public string ListaGetFullQuery(string sWhere,string sOrder)
    {
	SeccionCS.objectBussinessSeccion mySeccion = new SeccionCS.objectBussinessSeccion();
        string result = mySeccion.GetFullQuery(sWhere, sOrder);
	mySeccion.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ListaSelAll(int startRowIndex,int maximumRows,string where,string Order)
    {
	SeccionCS.objectBussinessSeccion mySeccion = new SeccionCS.objectBussinessSeccion();
        DataSet result = mySeccion.SelAll(startRowIndex, maximumRows, where, Order);
	mySeccion.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ImpresionSelAll(string where, string Order)
    {
	SeccionCS.objectBussinessSeccion mySeccion = new SeccionCS.objectBussinessSeccion();
        DataSet result = mySeccion.SelAll(where, Order);
	mySeccion.Dispose();
        return result;
    }

    [WebMethod]
    public int ListaSelCount(string where)
    {
	SeccionCS.objectBussinessSeccion mySeccion = new SeccionCS.objectBussinessSeccion();
        int result = mySeccion.SelCount(where);
	mySeccion.Dispose();
        return result;
    }


    [WebMethod]
    public Int32 SelCount()
    {
	SeccionCS.objectBussinessSeccion mySeccion = new SeccionCS.objectBussinessSeccion();
        Int32 result = mySeccion.SelCount();
	mySeccion.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
	SeccionCS.objectBussinessSeccion mySeccion = new SeccionCS.objectBussinessSeccion();
        DataSet result = mySeccion.SelAll(ConRelaciones);
	mySeccion.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, SeccionCS.SeccionFilters[] myFilters)
    {
        SeccionCS.objectBussinessSeccion mySeccion = new SeccionCS.objectBussinessSeccion();
        mySeccion.Filters = myFilters;
        DataSet result = mySeccion.SelAll(ConRelaciones);
        mySeccion.Filters = null;
        mySeccion.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        SeccionCS.objectBussinessSeccion mySeccion = new SeccionCS.objectBussinessSeccion();
        DataSet ds = new DataSet();
        ds.Tables.Add(mySeccion.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        mySeccion.Dispose(); 
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, String varDescripcion)
    {
        SeccionCS.objectBussinessSeccion  mySeccion = new SeccionCS.objectBussinessSeccion();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        mySeccion.Descripcion = varDescripcion;

        String sMsg = "";
        if (!ValidaDataToSave(mySeccion, out sMsg))
        {
            mySeccion.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(mySeccion, out sMsg))
        {
            mySeccion.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        mySeccion.Insert(globalInfo, dr);
        mySeccion.Dispose();
        dr = null;
        globalInfo = null;
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, String varDescripcion)
    {
        SeccionCS.objectBussinessSeccion  mySeccion= new SeccionCS.objectBussinessSeccion();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        mySeccion.Descripcion = varDescripcion;

        String sMsg = "";
        if (!ValidaDataToSave(mySeccion, out sMsg))
        {
            mySeccion.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(mySeccion, out sMsg))
        {
            mySeccion.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        object result=mySeccion.InsertWithReturnValue(globalInfo, dr);
        mySeccion.Dispose();
        dr = null;
        globalInfo = null;
        return result;
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varClave, String varDescripcion)
    {
        SeccionCS.objectBussinessSeccion mySeccion = new SeccionCS.objectBussinessSeccion();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        mySeccion.Clave = varClave;
        mySeccion.Descripcion = varDescripcion;

            String sMsg = "";
            if (!ValidaDataToSave(mySeccion, out sMsg))
            {
                mySeccion.Dispose();
                dr = null;
                globalInfo = null;
                throw new Exception(sMsg);
            }
            mySeccion.Update(globalInfo, dr);
            mySeccion.Dispose();
            dr = null;
            globalInfo = null;
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyClave)
    {
        SeccionCS.objectBussinessSeccion mySeccion = new SeccionCS.objectBussinessSeccion();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        bool result = mySeccion.Delete(KeyClave, globalInfo, dr);
        mySeccion.Dispose();
        dr = null;
        return result;
    }

    [WebMethod]
    public SeccionCS.objectBussinessSeccion GetByKey(int? KeyClave, Boolean ConRelaciones)
    {
        SeccionCS.objectBussinessSeccion mySeccion = new SeccionCS.objectBussinessSeccion();
        mySeccion.GetByKey(KeyClave, ConRelaciones);;
        return mySeccion;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyClave)
    {
        SeccionCS.objectBussinessSeccion mySeccion = new SeccionCS.objectBussinessSeccion();
        Int32 result = mySeccion.CurrentPosicion(KeyClave);
        return result;
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyClave)
    {
        SeccionCS.objectBussinessSeccion mySeccion = new SeccionCS.objectBussinessSeccion();
        Boolean result = mySeccion.ValidaExistencia(KeyClave);
        mySeccion.Dispose();
        return result;
    }

    private bool ValidaDataToSave(SeccionCS.objectBussinessSeccion MyDataSeccion, out String sMsg)
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

    public bool ValidaDataDuplication(SeccionCS.objectBussinessSeccion MyDataSeccion, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataSeccion.Clave == -1)
        {
            if (MyDataSeccion.ValidaExistencia(MyDataSeccion.Clave))
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
