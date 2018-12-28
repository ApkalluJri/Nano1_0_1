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
public class objectBussinessEstatus_de_Contenido : System.Web.Services.WebService
{
    public int iProcess = 30050;
    private TTTraductor.Traductor MyTraductor;
    


    [WebMethod]
    public string ListaGetFullQuery(string sWhere,string sOrder)
    {
	Estatus_de_ContenidoCS.objectBussinessEstatus_de_Contenido myEstatus_de_Contenido = new Estatus_de_ContenidoCS.objectBussinessEstatus_de_Contenido();
        string result = myEstatus_de_Contenido.GetFullQuery(sWhere, sOrder);
	myEstatus_de_Contenido.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ListaSelAll(int startRowIndex,int maximumRows,string where,string Order)
    {
	Estatus_de_ContenidoCS.objectBussinessEstatus_de_Contenido myEstatus_de_Contenido = new Estatus_de_ContenidoCS.objectBussinessEstatus_de_Contenido();
        DataSet result = myEstatus_de_Contenido.SelAll(startRowIndex, maximumRows, where, Order);
	myEstatus_de_Contenido.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ImpresionSelAll(string where, string Order)
    {
	Estatus_de_ContenidoCS.objectBussinessEstatus_de_Contenido myEstatus_de_Contenido = new Estatus_de_ContenidoCS.objectBussinessEstatus_de_Contenido();
        DataSet result = myEstatus_de_Contenido.SelAll(where, Order);
	myEstatus_de_Contenido.Dispose();
        return result;
    }

    [WebMethod]
    public int ListaSelCount(string where)
    {
	Estatus_de_ContenidoCS.objectBussinessEstatus_de_Contenido myEstatus_de_Contenido = new Estatus_de_ContenidoCS.objectBussinessEstatus_de_Contenido();
        int result = myEstatus_de_Contenido.SelCount(where);
	myEstatus_de_Contenido.Dispose();
        return result;
    }


    [WebMethod]
    public Int32 SelCount()
    {
	Estatus_de_ContenidoCS.objectBussinessEstatus_de_Contenido myEstatus_de_Contenido = new Estatus_de_ContenidoCS.objectBussinessEstatus_de_Contenido();
        Int32 result = myEstatus_de_Contenido.SelCount();
	myEstatus_de_Contenido.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
	Estatus_de_ContenidoCS.objectBussinessEstatus_de_Contenido myEstatus_de_Contenido = new Estatus_de_ContenidoCS.objectBussinessEstatus_de_Contenido();
        DataSet result = myEstatus_de_Contenido.SelAll(ConRelaciones);
	myEstatus_de_Contenido.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, Estatus_de_ContenidoCS.Estatus_de_ContenidoFilters[] myFilters)
    {
        Estatus_de_ContenidoCS.objectBussinessEstatus_de_Contenido myEstatus_de_Contenido = new Estatus_de_ContenidoCS.objectBussinessEstatus_de_Contenido();
        myEstatus_de_Contenido.Filters = myFilters;
        DataSet result = myEstatus_de_Contenido.SelAll(ConRelaciones);
        myEstatus_de_Contenido.Filters = null;
        myEstatus_de_Contenido.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        Estatus_de_ContenidoCS.objectBussinessEstatus_de_Contenido myEstatus_de_Contenido = new Estatus_de_ContenidoCS.objectBussinessEstatus_de_Contenido();
        DataSet ds = new DataSet();
        ds.Tables.Add(myEstatus_de_Contenido.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        myEstatus_de_Contenido.Dispose(); 
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, String varDescripcion)
    {
        Estatus_de_ContenidoCS.objectBussinessEstatus_de_Contenido  myEstatus_de_Contenido = new Estatus_de_ContenidoCS.objectBussinessEstatus_de_Contenido();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myEstatus_de_Contenido.Descripcion = varDescripcion;

        String sMsg = "";
        if (!ValidaDataToSave(myEstatus_de_Contenido, out sMsg))
        {
            myEstatus_de_Contenido.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myEstatus_de_Contenido, out sMsg))
        {
            myEstatus_de_Contenido.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        myEstatus_de_Contenido.Insert(globalInfo, dr);
        myEstatus_de_Contenido.Dispose();
        dr = null;
        globalInfo = null;
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, String varDescripcion)
    {
        Estatus_de_ContenidoCS.objectBussinessEstatus_de_Contenido  myEstatus_de_Contenido= new Estatus_de_ContenidoCS.objectBussinessEstatus_de_Contenido();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myEstatus_de_Contenido.Descripcion = varDescripcion;

        String sMsg = "";
        if (!ValidaDataToSave(myEstatus_de_Contenido, out sMsg))
        {
            myEstatus_de_Contenido.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myEstatus_de_Contenido, out sMsg))
        {
            myEstatus_de_Contenido.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        object result=myEstatus_de_Contenido.InsertWithReturnValue(globalInfo, dr);
        myEstatus_de_Contenido.Dispose();
        dr = null;
        globalInfo = null;
        return result;
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varClave, String varDescripcion)
    {
        Estatus_de_ContenidoCS.objectBussinessEstatus_de_Contenido myEstatus_de_Contenido = new Estatus_de_ContenidoCS.objectBussinessEstatus_de_Contenido();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myEstatus_de_Contenido.Clave = varClave;
        myEstatus_de_Contenido.Descripcion = varDescripcion;

            String sMsg = "";
            if (!ValidaDataToSave(myEstatus_de_Contenido, out sMsg))
            {
                myEstatus_de_Contenido.Dispose();
                dr = null;
                globalInfo = null;
                throw new Exception(sMsg);
            }
            myEstatus_de_Contenido.Update(globalInfo, dr);
            myEstatus_de_Contenido.Dispose();
            dr = null;
            globalInfo = null;
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyClave)
    {
        Estatus_de_ContenidoCS.objectBussinessEstatus_de_Contenido myEstatus_de_Contenido = new Estatus_de_ContenidoCS.objectBussinessEstatus_de_Contenido();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        bool result = myEstatus_de_Contenido.Delete(KeyClave, globalInfo, dr);
        myEstatus_de_Contenido.Dispose();
        dr = null;
        return result;
    }

    [WebMethod]
    public Estatus_de_ContenidoCS.objectBussinessEstatus_de_Contenido GetByKey(int? KeyClave, Boolean ConRelaciones)
    {
        Estatus_de_ContenidoCS.objectBussinessEstatus_de_Contenido myEstatus_de_Contenido = new Estatus_de_ContenidoCS.objectBussinessEstatus_de_Contenido();
        myEstatus_de_Contenido.GetByKey(KeyClave, ConRelaciones);;
        return myEstatus_de_Contenido;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyClave)
    {
        Estatus_de_ContenidoCS.objectBussinessEstatus_de_Contenido myEstatus_de_Contenido = new Estatus_de_ContenidoCS.objectBussinessEstatus_de_Contenido();
        Int32 result = myEstatus_de_Contenido.CurrentPosicion(KeyClave);
        return result;
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyClave)
    {
        Estatus_de_ContenidoCS.objectBussinessEstatus_de_Contenido myEstatus_de_Contenido = new Estatus_de_ContenidoCS.objectBussinessEstatus_de_Contenido();
        Boolean result = myEstatus_de_Contenido.ValidaExistencia(KeyClave);
        myEstatus_de_Contenido.Dispose();
        return result;
    }

    private bool ValidaDataToSave(Estatus_de_ContenidoCS.objectBussinessEstatus_de_Contenido MyDataEstatus_de_Contenido, out String sMsg)
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

    public bool ValidaDataDuplication(Estatus_de_ContenidoCS.objectBussinessEstatus_de_Contenido MyDataEstatus_de_Contenido, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataEstatus_de_Contenido.Clave == -1)
        {
            if (MyDataEstatus_de_Contenido.ValidaExistencia(MyDataEstatus_de_Contenido.Clave))
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
