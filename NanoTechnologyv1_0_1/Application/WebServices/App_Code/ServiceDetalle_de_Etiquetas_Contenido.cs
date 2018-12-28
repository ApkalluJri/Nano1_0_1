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
public class objectBussinessDetalle_de_Etiquetas_Contenido : System.Web.Services.WebService
{
    public int iProcess = 30049;
    private TTTraductor.Traductor MyTraductor;
    


    [WebMethod]
    public string ListaGetFullQuery(string sWhere,string sOrder)
    {
	Detalle_de_Etiquetas_ContenidoCS.objectBussinessDetalle_de_Etiquetas_Contenido myDetalle_de_Etiquetas_Contenido = new Detalle_de_Etiquetas_ContenidoCS.objectBussinessDetalle_de_Etiquetas_Contenido();
        string result = myDetalle_de_Etiquetas_Contenido.GetFullQuery(sWhere, sOrder);
	myDetalle_de_Etiquetas_Contenido.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ListaSelAll(int startRowIndex,int maximumRows,string where,string Order)
    {
	Detalle_de_Etiquetas_ContenidoCS.objectBussinessDetalle_de_Etiquetas_Contenido myDetalle_de_Etiquetas_Contenido = new Detalle_de_Etiquetas_ContenidoCS.objectBussinessDetalle_de_Etiquetas_Contenido();
        DataSet result = myDetalle_de_Etiquetas_Contenido.SelAll(startRowIndex, maximumRows, where, Order);
	myDetalle_de_Etiquetas_Contenido.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ImpresionSelAll(string where, string Order)
    {
	Detalle_de_Etiquetas_ContenidoCS.objectBussinessDetalle_de_Etiquetas_Contenido myDetalle_de_Etiquetas_Contenido = new Detalle_de_Etiquetas_ContenidoCS.objectBussinessDetalle_de_Etiquetas_Contenido();
        DataSet result = myDetalle_de_Etiquetas_Contenido.SelAll(where, Order);
	myDetalle_de_Etiquetas_Contenido.Dispose();
        return result;
    }

    [WebMethod]
    public int ListaSelCount(string where)
    {
	Detalle_de_Etiquetas_ContenidoCS.objectBussinessDetalle_de_Etiquetas_Contenido myDetalle_de_Etiquetas_Contenido = new Detalle_de_Etiquetas_ContenidoCS.objectBussinessDetalle_de_Etiquetas_Contenido();
        int result = myDetalle_de_Etiquetas_Contenido.SelCount(where);
	myDetalle_de_Etiquetas_Contenido.Dispose();
        return result;
    }


    [WebMethod]
    public Int32 SelCount()
    {
	Detalle_de_Etiquetas_ContenidoCS.objectBussinessDetalle_de_Etiquetas_Contenido myDetalle_de_Etiquetas_Contenido = new Detalle_de_Etiquetas_ContenidoCS.objectBussinessDetalle_de_Etiquetas_Contenido();
        Int32 result = myDetalle_de_Etiquetas_Contenido.SelCount();
	myDetalle_de_Etiquetas_Contenido.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
	Detalle_de_Etiquetas_ContenidoCS.objectBussinessDetalle_de_Etiquetas_Contenido myDetalle_de_Etiquetas_Contenido = new Detalle_de_Etiquetas_ContenidoCS.objectBussinessDetalle_de_Etiquetas_Contenido();
        DataSet result = myDetalle_de_Etiquetas_Contenido.SelAll(ConRelaciones);
	myDetalle_de_Etiquetas_Contenido.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, Detalle_de_Etiquetas_ContenidoCS.Detalle_de_Etiquetas_ContenidoFilters[] myFilters)
    {
        Detalle_de_Etiquetas_ContenidoCS.objectBussinessDetalle_de_Etiquetas_Contenido myDetalle_de_Etiquetas_Contenido = new Detalle_de_Etiquetas_ContenidoCS.objectBussinessDetalle_de_Etiquetas_Contenido();
        myDetalle_de_Etiquetas_Contenido.Filters = myFilters;
        DataSet result = myDetalle_de_Etiquetas_Contenido.SelAll(ConRelaciones);
        myDetalle_de_Etiquetas_Contenido.Filters = null;
        myDetalle_de_Etiquetas_Contenido.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        Detalle_de_Etiquetas_ContenidoCS.objectBussinessDetalle_de_Etiquetas_Contenido myDetalle_de_Etiquetas_Contenido = new Detalle_de_Etiquetas_ContenidoCS.objectBussinessDetalle_de_Etiquetas_Contenido();
        DataSet ds = new DataSet();
        ds.Tables.Add(myDetalle_de_Etiquetas_Contenido.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        myDetalle_de_Etiquetas_Contenido.Dispose(); 
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, String varDescripcion)
    {
        Detalle_de_Etiquetas_ContenidoCS.objectBussinessDetalle_de_Etiquetas_Contenido  myDetalle_de_Etiquetas_Contenido = new Detalle_de_Etiquetas_ContenidoCS.objectBussinessDetalle_de_Etiquetas_Contenido();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myDetalle_de_Etiquetas_Contenido.Descripcion = varDescripcion;

        String sMsg = "";
        if (!ValidaDataToSave(myDetalle_de_Etiquetas_Contenido, out sMsg))
        {
            myDetalle_de_Etiquetas_Contenido.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myDetalle_de_Etiquetas_Contenido, out sMsg))
        {
            myDetalle_de_Etiquetas_Contenido.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        myDetalle_de_Etiquetas_Contenido.Insert(globalInfo, dr);
        myDetalle_de_Etiquetas_Contenido.Dispose();
        dr = null;
        globalInfo = null;
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, String varDescripcion)
    {
        Detalle_de_Etiquetas_ContenidoCS.objectBussinessDetalle_de_Etiquetas_Contenido  myDetalle_de_Etiquetas_Contenido= new Detalle_de_Etiquetas_ContenidoCS.objectBussinessDetalle_de_Etiquetas_Contenido();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myDetalle_de_Etiquetas_Contenido.Descripcion = varDescripcion;

        String sMsg = "";
        if (!ValidaDataToSave(myDetalle_de_Etiquetas_Contenido, out sMsg))
        {
            myDetalle_de_Etiquetas_Contenido.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myDetalle_de_Etiquetas_Contenido, out sMsg))
        {
            myDetalle_de_Etiquetas_Contenido.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        object result=myDetalle_de_Etiquetas_Contenido.InsertWithReturnValue(globalInfo, dr);
        myDetalle_de_Etiquetas_Contenido.Dispose();
        dr = null;
        globalInfo = null;
        return result;
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varClave, String varDescripcion)
    {
        Detalle_de_Etiquetas_ContenidoCS.objectBussinessDetalle_de_Etiquetas_Contenido myDetalle_de_Etiquetas_Contenido = new Detalle_de_Etiquetas_ContenidoCS.objectBussinessDetalle_de_Etiquetas_Contenido();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myDetalle_de_Etiquetas_Contenido.Clave = varClave;
        myDetalle_de_Etiquetas_Contenido.Descripcion = varDescripcion;

            String sMsg = "";
            if (!ValidaDataToSave(myDetalle_de_Etiquetas_Contenido, out sMsg))
            {
                myDetalle_de_Etiquetas_Contenido.Dispose();
                dr = null;
                globalInfo = null;
                throw new Exception(sMsg);
            }
            myDetalle_de_Etiquetas_Contenido.Update(globalInfo, dr);
            myDetalle_de_Etiquetas_Contenido.Dispose();
            dr = null;
            globalInfo = null;
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyClave)
    {
        Detalle_de_Etiquetas_ContenidoCS.objectBussinessDetalle_de_Etiquetas_Contenido myDetalle_de_Etiquetas_Contenido = new Detalle_de_Etiquetas_ContenidoCS.objectBussinessDetalle_de_Etiquetas_Contenido();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        bool result = myDetalle_de_Etiquetas_Contenido.Delete(KeyClave, globalInfo, dr);
        myDetalle_de_Etiquetas_Contenido.Dispose();
        dr = null;
        return result;
    }

    [WebMethod]
    public Detalle_de_Etiquetas_ContenidoCS.objectBussinessDetalle_de_Etiquetas_Contenido GetByKey(int? KeyClave, Boolean ConRelaciones)
    {
        Detalle_de_Etiquetas_ContenidoCS.objectBussinessDetalle_de_Etiquetas_Contenido myDetalle_de_Etiquetas_Contenido = new Detalle_de_Etiquetas_ContenidoCS.objectBussinessDetalle_de_Etiquetas_Contenido();
        myDetalle_de_Etiquetas_Contenido.GetByKey(KeyClave, ConRelaciones);;
        return myDetalle_de_Etiquetas_Contenido;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyClave)
    {
        Detalle_de_Etiquetas_ContenidoCS.objectBussinessDetalle_de_Etiquetas_Contenido myDetalle_de_Etiquetas_Contenido = new Detalle_de_Etiquetas_ContenidoCS.objectBussinessDetalle_de_Etiquetas_Contenido();
        Int32 result = myDetalle_de_Etiquetas_Contenido.CurrentPosicion(KeyClave);
        return result;
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyClave)
    {
        Detalle_de_Etiquetas_ContenidoCS.objectBussinessDetalle_de_Etiquetas_Contenido myDetalle_de_Etiquetas_Contenido = new Detalle_de_Etiquetas_ContenidoCS.objectBussinessDetalle_de_Etiquetas_Contenido();
        Boolean result = myDetalle_de_Etiquetas_Contenido.ValidaExistencia(KeyClave);
        myDetalle_de_Etiquetas_Contenido.Dispose();
        return result;
    }

    private bool ValidaDataToSave(Detalle_de_Etiquetas_ContenidoCS.objectBussinessDetalle_de_Etiquetas_Contenido MyDataDetalle_de_Etiquetas_Contenido, out String sMsg)
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

    public bool ValidaDataDuplication(Detalle_de_Etiquetas_ContenidoCS.objectBussinessDetalle_de_Etiquetas_Contenido MyDataDetalle_de_Etiquetas_Contenido, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataDetalle_de_Etiquetas_Contenido.Clave == -1)
        {
            if (MyDataDetalle_de_Etiquetas_Contenido.ValidaExistencia(MyDataDetalle_de_Etiquetas_Contenido.Clave))
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
