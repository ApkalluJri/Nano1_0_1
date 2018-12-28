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
public class objectBussinessTipo_de_Observatorio : System.Web.Services.WebService
{
    public int iProcess = 29985;
    private TTTraductor.Traductor MyTraductor;
    


    [WebMethod]
    public string ListaGetFullQuery(string sWhere,string sOrder)
    {
	Tipo_de_ObservatorioCS.objectBussinessTipo_de_Observatorio myTipo_de_Observatorio = new Tipo_de_ObservatorioCS.objectBussinessTipo_de_Observatorio();
        string result = myTipo_de_Observatorio.GetFullQuery(sWhere, sOrder);
	myTipo_de_Observatorio.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ListaSelAll(int startRowIndex,int maximumRows,string where,string Order)
    {
	Tipo_de_ObservatorioCS.objectBussinessTipo_de_Observatorio myTipo_de_Observatorio = new Tipo_de_ObservatorioCS.objectBussinessTipo_de_Observatorio();
        DataSet result = myTipo_de_Observatorio.SelAll(startRowIndex, maximumRows, where, Order);
	myTipo_de_Observatorio.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ImpresionSelAll(string where, string Order)
    {
	Tipo_de_ObservatorioCS.objectBussinessTipo_de_Observatorio myTipo_de_Observatorio = new Tipo_de_ObservatorioCS.objectBussinessTipo_de_Observatorio();
        DataSet result = myTipo_de_Observatorio.SelAll(where, Order);
	myTipo_de_Observatorio.Dispose();
        return result;
    }

    [WebMethod]
    public int ListaSelCount(string where)
    {
	Tipo_de_ObservatorioCS.objectBussinessTipo_de_Observatorio myTipo_de_Observatorio = new Tipo_de_ObservatorioCS.objectBussinessTipo_de_Observatorio();
        int result = myTipo_de_Observatorio.SelCount(where);
	myTipo_de_Observatorio.Dispose();
        return result;
    }


    [WebMethod]
    public Int32 SelCount()
    {
	Tipo_de_ObservatorioCS.objectBussinessTipo_de_Observatorio myTipo_de_Observatorio = new Tipo_de_ObservatorioCS.objectBussinessTipo_de_Observatorio();
        Int32 result = myTipo_de_Observatorio.SelCount();
	myTipo_de_Observatorio.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
	Tipo_de_ObservatorioCS.objectBussinessTipo_de_Observatorio myTipo_de_Observatorio = new Tipo_de_ObservatorioCS.objectBussinessTipo_de_Observatorio();
        DataSet result = myTipo_de_Observatorio.SelAll(ConRelaciones);
	myTipo_de_Observatorio.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, Tipo_de_ObservatorioCS.Tipo_de_ObservatorioFilters[] myFilters)
    {
        Tipo_de_ObservatorioCS.objectBussinessTipo_de_Observatorio myTipo_de_Observatorio = new Tipo_de_ObservatorioCS.objectBussinessTipo_de_Observatorio();
        myTipo_de_Observatorio.Filters = myFilters;
        DataSet result = myTipo_de_Observatorio.SelAll(ConRelaciones);
        myTipo_de_Observatorio.Filters = null;
        myTipo_de_Observatorio.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        Tipo_de_ObservatorioCS.objectBussinessTipo_de_Observatorio myTipo_de_Observatorio = new Tipo_de_ObservatorioCS.objectBussinessTipo_de_Observatorio();
        DataSet ds = new DataSet();
        ds.Tables.Add(myTipo_de_Observatorio.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        myTipo_de_Observatorio.Dispose(); 
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, String varDescripcion)
    {
        Tipo_de_ObservatorioCS.objectBussinessTipo_de_Observatorio  myTipo_de_Observatorio = new Tipo_de_ObservatorioCS.objectBussinessTipo_de_Observatorio();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTipo_de_Observatorio.Descripcion = varDescripcion;

        String sMsg = "";
        if (!ValidaDataToSave(myTipo_de_Observatorio, out sMsg))
        {
            myTipo_de_Observatorio.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTipo_de_Observatorio, out sMsg))
        {
            myTipo_de_Observatorio.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        myTipo_de_Observatorio.Insert(globalInfo, dr);
        myTipo_de_Observatorio.Dispose();
        dr = null;
        globalInfo = null;
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, String varDescripcion)
    {
        Tipo_de_ObservatorioCS.objectBussinessTipo_de_Observatorio  myTipo_de_Observatorio= new Tipo_de_ObservatorioCS.objectBussinessTipo_de_Observatorio();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTipo_de_Observatorio.Descripcion = varDescripcion;

        String sMsg = "";
        if (!ValidaDataToSave(myTipo_de_Observatorio, out sMsg))
        {
            myTipo_de_Observatorio.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTipo_de_Observatorio, out sMsg))
        {
            myTipo_de_Observatorio.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        object result=myTipo_de_Observatorio.InsertWithReturnValue(globalInfo, dr);
        myTipo_de_Observatorio.Dispose();
        dr = null;
        globalInfo = null;
        return result;
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varClave, String varDescripcion)
    {
        Tipo_de_ObservatorioCS.objectBussinessTipo_de_Observatorio myTipo_de_Observatorio = new Tipo_de_ObservatorioCS.objectBussinessTipo_de_Observatorio();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myTipo_de_Observatorio.Clave = varClave;
        myTipo_de_Observatorio.Descripcion = varDescripcion;

            String sMsg = "";
            if (!ValidaDataToSave(myTipo_de_Observatorio, out sMsg))
            {
                myTipo_de_Observatorio.Dispose();
                dr = null;
                globalInfo = null;
                throw new Exception(sMsg);
            }
            myTipo_de_Observatorio.Update(globalInfo, dr);
            myTipo_de_Observatorio.Dispose();
            dr = null;
            globalInfo = null;
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyClave)
    {
        Tipo_de_ObservatorioCS.objectBussinessTipo_de_Observatorio myTipo_de_Observatorio = new Tipo_de_ObservatorioCS.objectBussinessTipo_de_Observatorio();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        bool result = myTipo_de_Observatorio.Delete(KeyClave, globalInfo, dr);
        myTipo_de_Observatorio.Dispose();
        dr = null;
        return result;
    }

    [WebMethod]
    public Tipo_de_ObservatorioCS.objectBussinessTipo_de_Observatorio GetByKey(int? KeyClave, Boolean ConRelaciones)
    {
        Tipo_de_ObservatorioCS.objectBussinessTipo_de_Observatorio myTipo_de_Observatorio = new Tipo_de_ObservatorioCS.objectBussinessTipo_de_Observatorio();
        myTipo_de_Observatorio.GetByKey(KeyClave, ConRelaciones);;
        return myTipo_de_Observatorio;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyClave)
    {
        Tipo_de_ObservatorioCS.objectBussinessTipo_de_Observatorio myTipo_de_Observatorio = new Tipo_de_ObservatorioCS.objectBussinessTipo_de_Observatorio();
        Int32 result = myTipo_de_Observatorio.CurrentPosicion(KeyClave);
        return result;
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyClave)
    {
        Tipo_de_ObservatorioCS.objectBussinessTipo_de_Observatorio myTipo_de_Observatorio = new Tipo_de_ObservatorioCS.objectBussinessTipo_de_Observatorio();
        Boolean result = myTipo_de_Observatorio.ValidaExistencia(KeyClave);
        myTipo_de_Observatorio.Dispose();
        return result;
    }

    private bool ValidaDataToSave(Tipo_de_ObservatorioCS.objectBussinessTipo_de_Observatorio MyDataTipo_de_Observatorio, out String sMsg)
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

    public bool ValidaDataDuplication(Tipo_de_ObservatorioCS.objectBussinessTipo_de_Observatorio MyDataTipo_de_Observatorio, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTipo_de_Observatorio.Clave == -1)
        {
            if (MyDataTipo_de_Observatorio.ValidaExistencia(MyDataTipo_de_Observatorio.Clave))
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
