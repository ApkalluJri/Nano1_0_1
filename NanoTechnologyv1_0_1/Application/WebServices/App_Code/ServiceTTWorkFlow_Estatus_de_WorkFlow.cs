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
public class objectBussinessTTWorkFlow_Estatus_de_WorkFlow : System.Web.Services.WebService
{
    public int iProcess = 15800;
    private TTTraductor.Traductor MyTraductor;
    public TTWorkFlow_Estatus_de_WorkFlowCS.objectBussinessTTWorkFlow_Estatus_de_WorkFlow myTTWorkFlow_Estatus_de_WorkFlow = new TTWorkFlow_Estatus_de_WorkFlowCS.objectBussinessTTWorkFlow_Estatus_de_WorkFlow();

    [WebMethod]
    public Int32 SelCount()
    {
        return myTTWorkFlow_Estatus_de_WorkFlow.SelCount();
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
        return myTTWorkFlow_Estatus_de_WorkFlow.SelAll(ConRelaciones);
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, TTWorkFlow_Estatus_de_WorkFlowCS.TTWorkFlow_Estatus_de_WorkFlowFilters[] myFilters)
    {
        myTTWorkFlow_Estatus_de_WorkFlow.Filters = myFilters;
        return myTTWorkFlow_Estatus_de_WorkFlow.SelAll(ConRelaciones);
        myTTWorkFlow_Estatus_de_WorkFlow.Filters = null;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Estatus_de_WorkFlow.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, String varDescripcion)
    {
        TTWorkFlow_Estatus_de_WorkFlowCS.objectBussinessTTWorkFlow_Estatus_de_WorkFlow  myTTWorkFlow_Estatus_de_WorkFlow= new TTWorkFlow_Estatus_de_WorkFlowCS.objectBussinessTTWorkFlow_Estatus_de_WorkFlow();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTWorkFlow_Estatus_de_WorkFlow.Descripcion = varDescripcion;

        String sMsg = "";
        if (!ValidaDataToSave(myTTWorkFlow_Estatus_de_WorkFlow, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTWorkFlow_Estatus_de_WorkFlow, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTWorkFlow_Estatus_de_WorkFlow.Insert(globalInfo, dr);
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, String varDescripcion)
    {
        TTWorkFlow_Estatus_de_WorkFlowCS.objectBussinessTTWorkFlow_Estatus_de_WorkFlow  myTTWorkFlow_Estatus_de_WorkFlow= new TTWorkFlow_Estatus_de_WorkFlowCS.objectBussinessTTWorkFlow_Estatus_de_WorkFlow();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTWorkFlow_Estatus_de_WorkFlow.Descripcion = varDescripcion;

        String sMsg = "";
        if (!ValidaDataToSave(myTTWorkFlow_Estatus_de_WorkFlow, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTWorkFlow_Estatus_de_WorkFlow, out sMsg))
        {
            throw new Exception(sMsg);
        }
        return myTTWorkFlow_Estatus_de_WorkFlow.InsertWithReturnValue(globalInfo, dr);
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varClave, String varDescripcion)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myTTWorkFlow_Estatus_de_WorkFlow.Clave = varClave;
        myTTWorkFlow_Estatus_de_WorkFlow.Descripcion = varDescripcion;

            String sMsg = "";
            if (!ValidaDataToSave(myTTWorkFlow_Estatus_de_WorkFlow, out sMsg))
            {
                throw new Exception(sMsg);
            }
            myTTWorkFlow_Estatus_de_WorkFlow.Update(globalInfo, dr);
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyClave)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
         return myTTWorkFlow_Estatus_de_WorkFlow.Delete(KeyClave, globalInfo, dr);
    }

    [WebMethod]
    public TTWorkFlow_Estatus_de_WorkFlowCS.objectBussinessTTWorkFlow_Estatus_de_WorkFlow GetByKey(int? KeyClave, Boolean ConRelaciones)
    {
        myTTWorkFlow_Estatus_de_WorkFlow.GetByKey(KeyClave, ConRelaciones);;
        return myTTWorkFlow_Estatus_de_WorkFlow;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyClave)
    {
        return myTTWorkFlow_Estatus_de_WorkFlow.CurrentPosicion(KeyClave);
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyClave)
    {
        return myTTWorkFlow_Estatus_de_WorkFlow.ValidaExistencia(KeyClave);
    }

    private bool ValidaDataToSave(TTWorkFlow_Estatus_de_WorkFlowCS.objectBussinessTTWorkFlow_Estatus_de_WorkFlow MyDataTTWorkFlow_Estatus_de_WorkFlow, out String sMsg)
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

    public bool ValidaDataDuplication(TTWorkFlow_Estatus_de_WorkFlowCS.objectBussinessTTWorkFlow_Estatus_de_WorkFlow MyDataTTWorkFlow_Estatus_de_WorkFlow, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTTWorkFlow_Estatus_de_WorkFlow.Clave == -1)
        {
            if (MyDataTTWorkFlow_Estatus_de_WorkFlow.ValidaExistencia(MyDataTTWorkFlow_Estatus_de_WorkFlow.Clave))
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