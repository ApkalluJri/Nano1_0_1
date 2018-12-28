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
public class objectBussinessEtiquetas : System.Web.Services.WebService
{
    public int iProcess = 29988;
    private TTTraductor.Traductor MyTraductor;
    


    [WebMethod]
    public string ListaGetFullQuery(string sWhere,string sOrder)
    {
	EtiquetasCS.objectBussinessEtiquetas myEtiquetas = new EtiquetasCS.objectBussinessEtiquetas();
        string result = myEtiquetas.GetFullQuery(sWhere, sOrder);
	myEtiquetas.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ListaSelAll(int startRowIndex,int maximumRows,string where,string Order)
    {
	EtiquetasCS.objectBussinessEtiquetas myEtiquetas = new EtiquetasCS.objectBussinessEtiquetas();
        DataSet result = myEtiquetas.SelAll(startRowIndex, maximumRows, where, Order);
	myEtiquetas.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ImpresionSelAll(string where, string Order)
    {
	EtiquetasCS.objectBussinessEtiquetas myEtiquetas = new EtiquetasCS.objectBussinessEtiquetas();
        DataSet result = myEtiquetas.SelAll(where, Order);
	myEtiquetas.Dispose();
        return result;
    }

    [WebMethod]
    public int ListaSelCount(string where)
    {
	EtiquetasCS.objectBussinessEtiquetas myEtiquetas = new EtiquetasCS.objectBussinessEtiquetas();
        int result = myEtiquetas.SelCount(where);
	myEtiquetas.Dispose();
        return result;
    }


    [WebMethod]
    public Int32 SelCount()
    {
	EtiquetasCS.objectBussinessEtiquetas myEtiquetas = new EtiquetasCS.objectBussinessEtiquetas();
        Int32 result = myEtiquetas.SelCount();
	myEtiquetas.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
	EtiquetasCS.objectBussinessEtiquetas myEtiquetas = new EtiquetasCS.objectBussinessEtiquetas();
        DataSet result = myEtiquetas.SelAll(ConRelaciones);
	myEtiquetas.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, EtiquetasCS.EtiquetasFilters[] myFilters)
    {
        EtiquetasCS.objectBussinessEtiquetas myEtiquetas = new EtiquetasCS.objectBussinessEtiquetas();
        myEtiquetas.Filters = myFilters;
        DataSet result = myEtiquetas.SelAll(ConRelaciones);
        myEtiquetas.Filters = null;
        myEtiquetas.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        EtiquetasCS.objectBussinessEtiquetas myEtiquetas = new EtiquetasCS.objectBussinessEtiquetas();
        DataSet ds = new DataSet();
        ds.Tables.Add(myEtiquetas.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        myEtiquetas.Dispose(); 
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, String varDescripcion)
    {
        EtiquetasCS.objectBussinessEtiquetas  myEtiquetas = new EtiquetasCS.objectBussinessEtiquetas();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myEtiquetas.Descripcion = varDescripcion;

        String sMsg = "";
        if (!ValidaDataToSave(myEtiquetas, out sMsg))
        {
            myEtiquetas.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myEtiquetas, out sMsg))
        {
            myEtiquetas.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        myEtiquetas.Insert(globalInfo, dr);
        myEtiquetas.Dispose();
        dr = null;
        globalInfo = null;
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, String varDescripcion)
    {
        EtiquetasCS.objectBussinessEtiquetas  myEtiquetas= new EtiquetasCS.objectBussinessEtiquetas();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myEtiquetas.Descripcion = varDescripcion;

        String sMsg = "";
        if (!ValidaDataToSave(myEtiquetas, out sMsg))
        {
            myEtiquetas.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myEtiquetas, out sMsg))
        {
            myEtiquetas.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        object result=myEtiquetas.InsertWithReturnValue(globalInfo, dr);
        myEtiquetas.Dispose();
        dr = null;
        globalInfo = null;
        return result;
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varClave, String varDescripcion)
    {
        EtiquetasCS.objectBussinessEtiquetas myEtiquetas = new EtiquetasCS.objectBussinessEtiquetas();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myEtiquetas.Clave = varClave;
        myEtiquetas.Descripcion = varDescripcion;

            String sMsg = "";
            if (!ValidaDataToSave(myEtiquetas, out sMsg))
            {
                myEtiquetas.Dispose();
                dr = null;
                globalInfo = null;
                throw new Exception(sMsg);
            }
            myEtiquetas.Update(globalInfo, dr);
            myEtiquetas.Dispose();
            dr = null;
            globalInfo = null;
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyClave)
    {
        EtiquetasCS.objectBussinessEtiquetas myEtiquetas = new EtiquetasCS.objectBussinessEtiquetas();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        bool result = myEtiquetas.Delete(KeyClave, globalInfo, dr);
        myEtiquetas.Dispose();
        dr = null;
        return result;
    }

    [WebMethod]
    public EtiquetasCS.objectBussinessEtiquetas GetByKey(int? KeyClave, Boolean ConRelaciones)
    {
        EtiquetasCS.objectBussinessEtiquetas myEtiquetas = new EtiquetasCS.objectBussinessEtiquetas();
        myEtiquetas.GetByKey(KeyClave, ConRelaciones);;
        return myEtiquetas;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyClave)
    {
        EtiquetasCS.objectBussinessEtiquetas myEtiquetas = new EtiquetasCS.objectBussinessEtiquetas();
        Int32 result = myEtiquetas.CurrentPosicion(KeyClave);
        return result;
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyClave)
    {
        EtiquetasCS.objectBussinessEtiquetas myEtiquetas = new EtiquetasCS.objectBussinessEtiquetas();
        Boolean result = myEtiquetas.ValidaExistencia(KeyClave);
        myEtiquetas.Dispose();
        return result;
    }

    private bool ValidaDataToSave(EtiquetasCS.objectBussinessEtiquetas MyDataEtiquetas, out String sMsg)
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

    public bool ValidaDataDuplication(EtiquetasCS.objectBussinessEtiquetas MyDataEtiquetas, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataEtiquetas.Clave == -1)
        {
            if (MyDataEtiquetas.ValidaExistencia(MyDataEtiquetas.Clave))
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
