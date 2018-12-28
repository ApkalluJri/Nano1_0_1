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
public class objectBussinessTipo_de_Dispositivo : System.Web.Services.WebService
{
    public int iProcess = 32545;
    private TTTraductor.Traductor MyTraductor;
    


    [WebMethod]
    public string ListaGetFullQuery(string sWhere,string sOrder)
    {
	Tipo_de_DispositivoCS.objectBussinessTipo_de_Dispositivo myTipo_de_Dispositivo = new Tipo_de_DispositivoCS.objectBussinessTipo_de_Dispositivo();
        string result = myTipo_de_Dispositivo.GetFullQuery(sWhere, sOrder);
	myTipo_de_Dispositivo.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ListaSelAll(int startRowIndex,int maximumRows,string where,string Order)
    {
	Tipo_de_DispositivoCS.objectBussinessTipo_de_Dispositivo myTipo_de_Dispositivo = new Tipo_de_DispositivoCS.objectBussinessTipo_de_Dispositivo();
        DataSet result = myTipo_de_Dispositivo.SelAll(startRowIndex, maximumRows, where, Order);
	myTipo_de_Dispositivo.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ImpresionSelAll(string where, string Order)
    {
	Tipo_de_DispositivoCS.objectBussinessTipo_de_Dispositivo myTipo_de_Dispositivo = new Tipo_de_DispositivoCS.objectBussinessTipo_de_Dispositivo();
        DataSet result = myTipo_de_Dispositivo.SelAll(where, Order);
	myTipo_de_Dispositivo.Dispose();
        return result;
    }

    [WebMethod]
    public int ListaSelCount(string where)
    {
	Tipo_de_DispositivoCS.objectBussinessTipo_de_Dispositivo myTipo_de_Dispositivo = new Tipo_de_DispositivoCS.objectBussinessTipo_de_Dispositivo();
        int result = myTipo_de_Dispositivo.SelCount(where);
	myTipo_de_Dispositivo.Dispose();
        return result;
    }


    [WebMethod]
    public Int32 SelCount()
    {
	Tipo_de_DispositivoCS.objectBussinessTipo_de_Dispositivo myTipo_de_Dispositivo = new Tipo_de_DispositivoCS.objectBussinessTipo_de_Dispositivo();
        Int32 result = myTipo_de_Dispositivo.SelCount();
	myTipo_de_Dispositivo.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
	Tipo_de_DispositivoCS.objectBussinessTipo_de_Dispositivo myTipo_de_Dispositivo = new Tipo_de_DispositivoCS.objectBussinessTipo_de_Dispositivo();
        DataSet result = myTipo_de_Dispositivo.SelAll(ConRelaciones);
	myTipo_de_Dispositivo.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, Tipo_de_DispositivoCS.Tipo_de_DispositivoFilters[] myFilters)
    {
        Tipo_de_DispositivoCS.objectBussinessTipo_de_Dispositivo myTipo_de_Dispositivo = new Tipo_de_DispositivoCS.objectBussinessTipo_de_Dispositivo();
        myTipo_de_Dispositivo.Filters = myFilters;
        DataSet result = myTipo_de_Dispositivo.SelAll(ConRelaciones);
        myTipo_de_Dispositivo.Filters = null;
        myTipo_de_Dispositivo.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        Tipo_de_DispositivoCS.objectBussinessTipo_de_Dispositivo myTipo_de_Dispositivo = new Tipo_de_DispositivoCS.objectBussinessTipo_de_Dispositivo();
        DataSet ds = new DataSet();
        ds.Tables.Add(myTipo_de_Dispositivo.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        myTipo_de_Dispositivo.Dispose(); 
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, String varTipo)
    {
        Tipo_de_DispositivoCS.objectBussinessTipo_de_Dispositivo  myTipo_de_Dispositivo = new Tipo_de_DispositivoCS.objectBussinessTipo_de_Dispositivo();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTipo_de_Dispositivo.Tipo = varTipo;

        String sMsg = "";
        if (!ValidaDataToSave(myTipo_de_Dispositivo, out sMsg))
        {
            myTipo_de_Dispositivo.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTipo_de_Dispositivo, out sMsg))
        {
            myTipo_de_Dispositivo.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        myTipo_de_Dispositivo.Insert(globalInfo, dr);
        myTipo_de_Dispositivo.Dispose();
        dr = null;
        globalInfo = null;
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, String varTipo)
    {
        Tipo_de_DispositivoCS.objectBussinessTipo_de_Dispositivo  myTipo_de_Dispositivo= new Tipo_de_DispositivoCS.objectBussinessTipo_de_Dispositivo();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTipo_de_Dispositivo.Tipo = varTipo;

        String sMsg = "";
        if (!ValidaDataToSave(myTipo_de_Dispositivo, out sMsg))
        {
            myTipo_de_Dispositivo.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTipo_de_Dispositivo, out sMsg))
        {
            myTipo_de_Dispositivo.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        object result=myTipo_de_Dispositivo.InsertWithReturnValue(globalInfo, dr);
        myTipo_de_Dispositivo.Dispose();
        dr = null;
        globalInfo = null;
        return result;
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varClave, String varTipo)
    {
        Tipo_de_DispositivoCS.objectBussinessTipo_de_Dispositivo myTipo_de_Dispositivo = new Tipo_de_DispositivoCS.objectBussinessTipo_de_Dispositivo();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myTipo_de_Dispositivo.Clave = varClave;
        myTipo_de_Dispositivo.Tipo = varTipo;

            String sMsg = "";
            if (!ValidaDataToSave(myTipo_de_Dispositivo, out sMsg))
            {
                myTipo_de_Dispositivo.Dispose();
                dr = null;
                globalInfo = null;
                throw new Exception(sMsg);
            }
            myTipo_de_Dispositivo.Update(globalInfo, dr);
            myTipo_de_Dispositivo.Dispose();
            dr = null;
            globalInfo = null;
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyClave)
    {
        Tipo_de_DispositivoCS.objectBussinessTipo_de_Dispositivo myTipo_de_Dispositivo = new Tipo_de_DispositivoCS.objectBussinessTipo_de_Dispositivo();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        bool result = myTipo_de_Dispositivo.Delete(KeyClave, globalInfo, dr);
        myTipo_de_Dispositivo.Dispose();
        dr = null;
        return result;
    }

    [WebMethod]
    public Tipo_de_DispositivoCS.objectBussinessTipo_de_Dispositivo GetByKey(int? KeyClave, Boolean ConRelaciones)
    {
        Tipo_de_DispositivoCS.objectBussinessTipo_de_Dispositivo myTipo_de_Dispositivo = new Tipo_de_DispositivoCS.objectBussinessTipo_de_Dispositivo();
        myTipo_de_Dispositivo.GetByKey(KeyClave, ConRelaciones);;
        return myTipo_de_Dispositivo;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyClave)
    {
        Tipo_de_DispositivoCS.objectBussinessTipo_de_Dispositivo myTipo_de_Dispositivo = new Tipo_de_DispositivoCS.objectBussinessTipo_de_Dispositivo();
        Int32 result = myTipo_de_Dispositivo.CurrentPosicion(KeyClave);
        return result;
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyClave)
    {
        Tipo_de_DispositivoCS.objectBussinessTipo_de_Dispositivo myTipo_de_Dispositivo = new Tipo_de_DispositivoCS.objectBussinessTipo_de_Dispositivo();
        Boolean result = myTipo_de_Dispositivo.ValidaExistencia(KeyClave);
        myTipo_de_Dispositivo.Dispose();
        return result;
    }

    private bool ValidaDataToSave(Tipo_de_DispositivoCS.objectBussinessTipo_de_Dispositivo MyDataTipo_de_Dispositivo, out String sMsg)
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

    public bool ValidaDataDuplication(Tipo_de_DispositivoCS.objectBussinessTipo_de_Dispositivo MyDataTipo_de_Dispositivo, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTipo_de_Dispositivo.Clave == -1)
        {
            if (MyDataTipo_de_Dispositivo.ValidaExistencia(MyDataTipo_de_Dispositivo.Clave))
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
