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
public class objectBussinessEstilo_de_Articulo : System.Web.Services.WebService
{
    public int iProcess = 29987;
    private TTTraductor.Traductor MyTraductor;
    


    [WebMethod]
    public string ListaGetFullQuery(string sWhere,string sOrder)
    {
	Estilo_de_ArticuloCS.objectBussinessEstilo_de_Articulo myEstilo_de_Articulo = new Estilo_de_ArticuloCS.objectBussinessEstilo_de_Articulo();
        string result = myEstilo_de_Articulo.GetFullQuery(sWhere, sOrder);
	myEstilo_de_Articulo.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ListaSelAll(int startRowIndex,int maximumRows,string where,string Order)
    {
	Estilo_de_ArticuloCS.objectBussinessEstilo_de_Articulo myEstilo_de_Articulo = new Estilo_de_ArticuloCS.objectBussinessEstilo_de_Articulo();
        DataSet result = myEstilo_de_Articulo.SelAll(startRowIndex, maximumRows, where, Order);
	myEstilo_de_Articulo.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ImpresionSelAll(string where, string Order)
    {
	Estilo_de_ArticuloCS.objectBussinessEstilo_de_Articulo myEstilo_de_Articulo = new Estilo_de_ArticuloCS.objectBussinessEstilo_de_Articulo();
        DataSet result = myEstilo_de_Articulo.SelAll(where, Order);
	myEstilo_de_Articulo.Dispose();
        return result;
    }

    [WebMethod]
    public int ListaSelCount(string where)
    {
	Estilo_de_ArticuloCS.objectBussinessEstilo_de_Articulo myEstilo_de_Articulo = new Estilo_de_ArticuloCS.objectBussinessEstilo_de_Articulo();
        int result = myEstilo_de_Articulo.SelCount(where);
	myEstilo_de_Articulo.Dispose();
        return result;
    }


    [WebMethod]
    public Int32 SelCount()
    {
	Estilo_de_ArticuloCS.objectBussinessEstilo_de_Articulo myEstilo_de_Articulo = new Estilo_de_ArticuloCS.objectBussinessEstilo_de_Articulo();
        Int32 result = myEstilo_de_Articulo.SelCount();
	myEstilo_de_Articulo.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
	Estilo_de_ArticuloCS.objectBussinessEstilo_de_Articulo myEstilo_de_Articulo = new Estilo_de_ArticuloCS.objectBussinessEstilo_de_Articulo();
        DataSet result = myEstilo_de_Articulo.SelAll(ConRelaciones);
	myEstilo_de_Articulo.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, Estilo_de_ArticuloCS.Estilo_de_ArticuloFilters[] myFilters)
    {
        Estilo_de_ArticuloCS.objectBussinessEstilo_de_Articulo myEstilo_de_Articulo = new Estilo_de_ArticuloCS.objectBussinessEstilo_de_Articulo();
        myEstilo_de_Articulo.Filters = myFilters;
        DataSet result = myEstilo_de_Articulo.SelAll(ConRelaciones);
        myEstilo_de_Articulo.Filters = null;
        myEstilo_de_Articulo.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        Estilo_de_ArticuloCS.objectBussinessEstilo_de_Articulo myEstilo_de_Articulo = new Estilo_de_ArticuloCS.objectBussinessEstilo_de_Articulo();
        DataSet ds = new DataSet();
        ds.Tables.Add(myEstilo_de_Articulo.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        myEstilo_de_Articulo.Dispose(); 
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, String varDescripcion)
    {
        Estilo_de_ArticuloCS.objectBussinessEstilo_de_Articulo  myEstilo_de_Articulo = new Estilo_de_ArticuloCS.objectBussinessEstilo_de_Articulo();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myEstilo_de_Articulo.Descripcion = varDescripcion;

        String sMsg = "";
        if (!ValidaDataToSave(myEstilo_de_Articulo, out sMsg))
        {
            myEstilo_de_Articulo.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myEstilo_de_Articulo, out sMsg))
        {
            myEstilo_de_Articulo.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        myEstilo_de_Articulo.Insert(globalInfo, dr);
        myEstilo_de_Articulo.Dispose();
        dr = null;
        globalInfo = null;
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, String varDescripcion)
    {
        Estilo_de_ArticuloCS.objectBussinessEstilo_de_Articulo  myEstilo_de_Articulo= new Estilo_de_ArticuloCS.objectBussinessEstilo_de_Articulo();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myEstilo_de_Articulo.Descripcion = varDescripcion;

        String sMsg = "";
        if (!ValidaDataToSave(myEstilo_de_Articulo, out sMsg))
        {
            myEstilo_de_Articulo.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myEstilo_de_Articulo, out sMsg))
        {
            myEstilo_de_Articulo.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        object result=myEstilo_de_Articulo.InsertWithReturnValue(globalInfo, dr);
        myEstilo_de_Articulo.Dispose();
        dr = null;
        globalInfo = null;
        return result;
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varClave, String varDescripcion)
    {
        Estilo_de_ArticuloCS.objectBussinessEstilo_de_Articulo myEstilo_de_Articulo = new Estilo_de_ArticuloCS.objectBussinessEstilo_de_Articulo();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myEstilo_de_Articulo.Clave = varClave;
        myEstilo_de_Articulo.Descripcion = varDescripcion;

            String sMsg = "";
            if (!ValidaDataToSave(myEstilo_de_Articulo, out sMsg))
            {
                myEstilo_de_Articulo.Dispose();
                dr = null;
                globalInfo = null;
                throw new Exception(sMsg);
            }
            myEstilo_de_Articulo.Update(globalInfo, dr);
            myEstilo_de_Articulo.Dispose();
            dr = null;
            globalInfo = null;
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyClave)
    {
        Estilo_de_ArticuloCS.objectBussinessEstilo_de_Articulo myEstilo_de_Articulo = new Estilo_de_ArticuloCS.objectBussinessEstilo_de_Articulo();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        bool result = myEstilo_de_Articulo.Delete(KeyClave, globalInfo, dr);
        myEstilo_de_Articulo.Dispose();
        dr = null;
        return result;
    }

    [WebMethod]
    public Estilo_de_ArticuloCS.objectBussinessEstilo_de_Articulo GetByKey(int? KeyClave, Boolean ConRelaciones)
    {
        Estilo_de_ArticuloCS.objectBussinessEstilo_de_Articulo myEstilo_de_Articulo = new Estilo_de_ArticuloCS.objectBussinessEstilo_de_Articulo();
        myEstilo_de_Articulo.GetByKey(KeyClave, ConRelaciones);;
        return myEstilo_de_Articulo;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyClave)
    {
        Estilo_de_ArticuloCS.objectBussinessEstilo_de_Articulo myEstilo_de_Articulo = new Estilo_de_ArticuloCS.objectBussinessEstilo_de_Articulo();
        Int32 result = myEstilo_de_Articulo.CurrentPosicion(KeyClave);
        return result;
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyClave)
    {
        Estilo_de_ArticuloCS.objectBussinessEstilo_de_Articulo myEstilo_de_Articulo = new Estilo_de_ArticuloCS.objectBussinessEstilo_de_Articulo();
        Boolean result = myEstilo_de_Articulo.ValidaExistencia(KeyClave);
        myEstilo_de_Articulo.Dispose();
        return result;
    }

    private bool ValidaDataToSave(Estilo_de_ArticuloCS.objectBussinessEstilo_de_Articulo MyDataEstilo_de_Articulo, out String sMsg)
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

    public bool ValidaDataDuplication(Estilo_de_ArticuloCS.objectBussinessEstilo_de_Articulo MyDataEstilo_de_Articulo, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataEstilo_de_Articulo.Clave == -1)
        {
            if (MyDataEstilo_de_Articulo.ValidaExistencia(MyDataEstilo_de_Articulo.Clave))
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
