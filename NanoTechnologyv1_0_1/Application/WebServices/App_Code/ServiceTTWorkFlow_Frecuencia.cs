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
public class objectBussinessTTWorkFlow_Frecuencia : System.Web.Services.WebService
{
    public int iProcess = 15808;
    private TTTraductor.Traductor MyTraductor;
    public TTWorkFlow_FrecuenciaCS.objectBussinessTTWorkFlow_Frecuencia myTTWorkFlow_Frecuencia = new TTWorkFlow_FrecuenciaCS.objectBussinessTTWorkFlow_Frecuencia();

    [WebMethod]
    public Int32 SelCount()
    {
        return myTTWorkFlow_Frecuencia.SelCount();
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
        return myTTWorkFlow_Frecuencia.SelAll(ConRelaciones);
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, TTWorkFlow_FrecuenciaCS.TTWorkFlow_FrecuenciaFilters[] myFilters)
    {
        myTTWorkFlow_Frecuencia.Filters = myFilters;
        return myTTWorkFlow_Frecuencia.SelAll(ConRelaciones);
        myTTWorkFlow_Frecuencia.Filters = null;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Frecuencia.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, String varNombre)
    {
        TTWorkFlow_FrecuenciaCS.objectBussinessTTWorkFlow_Frecuencia  myTTWorkFlow_Frecuencia= new TTWorkFlow_FrecuenciaCS.objectBussinessTTWorkFlow_Frecuencia();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTWorkFlow_Frecuencia.Nombre = varNombre;

        String sMsg = "";
        if (!ValidaDataToSave(myTTWorkFlow_Frecuencia, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTWorkFlow_Frecuencia, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTWorkFlow_Frecuencia.Insert(globalInfo, dr);
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, String varNombre)
    {
        TTWorkFlow_FrecuenciaCS.objectBussinessTTWorkFlow_Frecuencia  myTTWorkFlow_Frecuencia= new TTWorkFlow_FrecuenciaCS.objectBussinessTTWorkFlow_Frecuencia();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTWorkFlow_Frecuencia.Nombre = varNombre;

        String sMsg = "";
        if (!ValidaDataToSave(myTTWorkFlow_Frecuencia, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTWorkFlow_Frecuencia, out sMsg))
        {
            throw new Exception(sMsg);
        }
        return myTTWorkFlow_Frecuencia.InsertWithReturnValue(globalInfo, dr);
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varClave, String varNombre)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myTTWorkFlow_Frecuencia.Clave = varClave;
        myTTWorkFlow_Frecuencia.Nombre = varNombre;

            String sMsg = "";
            if (!ValidaDataToSave(myTTWorkFlow_Frecuencia, out sMsg))
            {
                throw new Exception(sMsg);
            }
            myTTWorkFlow_Frecuencia.Update(globalInfo, dr);
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyClave)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
         return myTTWorkFlow_Frecuencia.Delete(KeyClave, globalInfo, dr);
    }

    [WebMethod]
    public TTWorkFlow_FrecuenciaCS.objectBussinessTTWorkFlow_Frecuencia GetByKey(int? KeyClave, Boolean ConRelaciones)
    {
        myTTWorkFlow_Frecuencia.GetByKey(KeyClave, ConRelaciones);;
        return myTTWorkFlow_Frecuencia;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyClave)
    {
        return myTTWorkFlow_Frecuencia.CurrentPosicion(KeyClave);
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyClave)
    {
        return myTTWorkFlow_Frecuencia.ValidaExistencia(KeyClave);
    }

    private bool ValidaDataToSave(TTWorkFlow_FrecuenciaCS.objectBussinessTTWorkFlow_Frecuencia MyDataTTWorkFlow_Frecuencia, out String sMsg)
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

    public bool ValidaDataDuplication(TTWorkFlow_FrecuenciaCS.objectBussinessTTWorkFlow_Frecuencia MyDataTTWorkFlow_Frecuencia, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTTWorkFlow_Frecuencia.Clave == -1)
        {
            if (MyDataTTWorkFlow_Frecuencia.ValidaExistencia(MyDataTTWorkFlow_Frecuencia.Clave))
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