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
public class objectBussinessTTWorkFlow_Respuesta : System.Web.Services.WebService
{
    public int iProcess = 15811;
    private TTTraductor.Traductor MyTraductor;
    public TTWorkFlow_RespuestaCS.objectBussinessTTWorkFlow_Respuesta myTTWorkFlow_Respuesta = new TTWorkFlow_RespuestaCS.objectBussinessTTWorkFlow_Respuesta();

    [WebMethod]
    public Int32 SelCount()
    {
        return myTTWorkFlow_Respuesta.SelCount();
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
        return myTTWorkFlow_Respuesta.SelAll(ConRelaciones);
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, TTWorkFlow_RespuestaCS.TTWorkFlow_RespuestaFilters[] myFilters)
    {
        myTTWorkFlow_Respuesta.Filters = myFilters;
        return myTTWorkFlow_Respuesta.SelAll(ConRelaciones);
        myTTWorkFlow_Respuesta.Filters = null;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Respuesta.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varClave, String varDescripcion)
    {
        TTWorkFlow_RespuestaCS.objectBussinessTTWorkFlow_Respuesta  myTTWorkFlow_Respuesta= new TTWorkFlow_RespuestaCS.objectBussinessTTWorkFlow_Respuesta();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTWorkFlow_Respuesta.Clave = varClave;
        myTTWorkFlow_Respuesta.Descripcion = varDescripcion;

        String sMsg = "";
        if (!ValidaDataToSave(myTTWorkFlow_Respuesta, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTWorkFlow_Respuesta, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTWorkFlow_Respuesta.Insert(globalInfo, dr);
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, int? varClave, String varDescripcion)
    {
        TTWorkFlow_RespuestaCS.objectBussinessTTWorkFlow_Respuesta  myTTWorkFlow_Respuesta= new TTWorkFlow_RespuestaCS.objectBussinessTTWorkFlow_Respuesta();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTWorkFlow_Respuesta.Clave = varClave;
        myTTWorkFlow_Respuesta.Descripcion = varDescripcion;

        String sMsg = "";
        if (!ValidaDataToSave(myTTWorkFlow_Respuesta, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTWorkFlow_Respuesta, out sMsg))
        {
            throw new Exception(sMsg);
        }
        return myTTWorkFlow_Respuesta.InsertWithReturnValue(globalInfo, dr);
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varClave, String varDescripcion)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myTTWorkFlow_Respuesta.Clave = varClave;
        myTTWorkFlow_Respuesta.Descripcion = varDescripcion;

            String sMsg = "";
            if (!ValidaDataToSave(myTTWorkFlow_Respuesta, out sMsg))
            {
                throw new Exception(sMsg);
            }
            myTTWorkFlow_Respuesta.Update(globalInfo, dr);
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyClave)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
         return myTTWorkFlow_Respuesta.Delete(KeyClave, globalInfo, dr);
    }

    [WebMethod]
    public TTWorkFlow_RespuestaCS.objectBussinessTTWorkFlow_Respuesta GetByKey(int? KeyClave, Boolean ConRelaciones)
    {
        myTTWorkFlow_Respuesta.GetByKey(KeyClave, ConRelaciones);;
        return myTTWorkFlow_Respuesta;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyClave)
    {
        return myTTWorkFlow_Respuesta.CurrentPosicion(KeyClave);
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyClave)
    {
        return myTTWorkFlow_Respuesta.ValidaExistencia(KeyClave);
    }

    private bool ValidaDataToSave(TTWorkFlow_RespuestaCS.objectBussinessTTWorkFlow_Respuesta MyDataTTWorkFlow_Respuesta, out String sMsg)
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

    public bool ValidaDataDuplication(TTWorkFlow_RespuestaCS.objectBussinessTTWorkFlow_Respuesta MyDataTTWorkFlow_Respuesta, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTTWorkFlow_Respuesta.Clave != null)
        {
            if (MyDataTTWorkFlow_Respuesta.ValidaExistencia(MyDataTTWorkFlow_Respuesta.Clave))
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