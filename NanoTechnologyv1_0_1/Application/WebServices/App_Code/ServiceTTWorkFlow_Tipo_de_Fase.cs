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
public class objectBussinessTTWorkFlow_Tipo_de_Fase : System.Web.Services.WebService
{
    public int iProcess = 15802;
    private TTTraductor.Traductor MyTraductor;
    public TTWorkFlow_Tipo_de_FaseCS.objectBussinessTTWorkFlow_Tipo_de_Fase myTTWorkFlow_Tipo_de_Fase = new TTWorkFlow_Tipo_de_FaseCS.objectBussinessTTWorkFlow_Tipo_de_Fase();

    [WebMethod]
    public Int32 SelCount()
    {
        return myTTWorkFlow_Tipo_de_Fase.SelCount();
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
        return myTTWorkFlow_Tipo_de_Fase.SelAll(ConRelaciones);
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, TTWorkFlow_Tipo_de_FaseCS.TTWorkFlow_Tipo_de_FaseFilters[] myFilters)
    {
        myTTWorkFlow_Tipo_de_Fase.Filters = myFilters;
        return myTTWorkFlow_Tipo_de_Fase.SelAll(ConRelaciones);
        myTTWorkFlow_Tipo_de_Fase.Filters = null;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow_Tipo_de_Fase.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, String varDescripcion)
    {
        TTWorkFlow_Tipo_de_FaseCS.objectBussinessTTWorkFlow_Tipo_de_Fase  myTTWorkFlow_Tipo_de_Fase= new TTWorkFlow_Tipo_de_FaseCS.objectBussinessTTWorkFlow_Tipo_de_Fase();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTWorkFlow_Tipo_de_Fase.Descripcion = varDescripcion;

        String sMsg = "";
        if (!ValidaDataToSave(myTTWorkFlow_Tipo_de_Fase, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTWorkFlow_Tipo_de_Fase, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTWorkFlow_Tipo_de_Fase.Insert(globalInfo, dr);
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, String varDescripcion)
    {
        TTWorkFlow_Tipo_de_FaseCS.objectBussinessTTWorkFlow_Tipo_de_Fase  myTTWorkFlow_Tipo_de_Fase= new TTWorkFlow_Tipo_de_FaseCS.objectBussinessTTWorkFlow_Tipo_de_Fase();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTWorkFlow_Tipo_de_Fase.Descripcion = varDescripcion;

        String sMsg = "";
        if (!ValidaDataToSave(myTTWorkFlow_Tipo_de_Fase, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTWorkFlow_Tipo_de_Fase, out sMsg))
        {
            throw new Exception(sMsg);
        }
        return myTTWorkFlow_Tipo_de_Fase.InsertWithReturnValue(globalInfo, dr);
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varClave, String varDescripcion)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myTTWorkFlow_Tipo_de_Fase.Clave = varClave;
        myTTWorkFlow_Tipo_de_Fase.Descripcion = varDescripcion;

            String sMsg = "";
            if (!ValidaDataToSave(myTTWorkFlow_Tipo_de_Fase, out sMsg))
            {
                throw new Exception(sMsg);
            }
            myTTWorkFlow_Tipo_de_Fase.Update(globalInfo, dr);
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyClave)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
         return myTTWorkFlow_Tipo_de_Fase.Delete(KeyClave, globalInfo, dr);
    }

    [WebMethod]
    public TTWorkFlow_Tipo_de_FaseCS.objectBussinessTTWorkFlow_Tipo_de_Fase GetByKey(int? KeyClave, Boolean ConRelaciones)
    {
        myTTWorkFlow_Tipo_de_Fase.GetByKey(KeyClave, ConRelaciones);;
        return myTTWorkFlow_Tipo_de_Fase;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyClave)
    {
        return myTTWorkFlow_Tipo_de_Fase.CurrentPosicion(KeyClave);
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyClave)
    {
        return myTTWorkFlow_Tipo_de_Fase.ValidaExistencia(KeyClave);
    }

    private bool ValidaDataToSave(TTWorkFlow_Tipo_de_FaseCS.objectBussinessTTWorkFlow_Tipo_de_Fase MyDataTTWorkFlow_Tipo_de_Fase, out String sMsg)
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

    public bool ValidaDataDuplication(TTWorkFlow_Tipo_de_FaseCS.objectBussinessTTWorkFlow_Tipo_de_Fase MyDataTTWorkFlow_Tipo_de_Fase, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTTWorkFlow_Tipo_de_Fase.Clave == -1)
        {
            if (MyDataTTWorkFlow_Tipo_de_Fase.ValidaExistencia(MyDataTTWorkFlow_Tipo_de_Fase.Clave))
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