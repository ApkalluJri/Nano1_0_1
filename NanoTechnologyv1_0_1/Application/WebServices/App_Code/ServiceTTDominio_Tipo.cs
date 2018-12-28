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
public class objectBussinessTTDominio_Tipo : System.Web.Services.WebService
{
    public int iProcess = 6836;
    private TTTraductor.Traductor MyTraductor;
    public TTDominio_TipoCS.objectBussinessTTDominio_Tipo myTTDominio_Tipo = new TTDominio_TipoCS.objectBussinessTTDominio_Tipo();

    [WebMethod]
    public Int32 SelCount()
    {
        return myTTDominio_Tipo.SelCount();
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
        return myTTDominio_Tipo.SelAll(ConRelaciones);
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, TTDominio_TipoCS.TTDominio_TipoFilters[] myFilters)
    {
        myTTDominio_Tipo.Filters = myFilters;
        return myTTDominio_Tipo.SelAll(ConRelaciones);
        myTTDominio_Tipo.Filters = null;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTDominio_Tipo.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, String varDescripcion)
    {
        TTDominio_TipoCS.objectBussinessTTDominio_Tipo  myTTDominio_Tipo= new TTDominio_TipoCS.objectBussinessTTDominio_Tipo();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTDominio_Tipo.Descripcion = varDescripcion;

        String sMsg = "";
        if (!ValidaDataToSave(myTTDominio_Tipo, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTDominio_Tipo, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTDominio_Tipo.Insert(globalInfo, dr);
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, String varDescripcion)
    {
        TTDominio_TipoCS.objectBussinessTTDominio_Tipo  myTTDominio_Tipo= new TTDominio_TipoCS.objectBussinessTTDominio_Tipo();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTDominio_Tipo.Descripcion = varDescripcion;

        String sMsg = "";
        if (!ValidaDataToSave(myTTDominio_Tipo, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTDominio_Tipo, out sMsg))
        {
            throw new Exception(sMsg);
        }
        return myTTDominio_Tipo.InsertWithReturnValue(globalInfo, dr);
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varFolio, String varDescripcion)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myTTDominio_Tipo.Folio = varFolio;
        myTTDominio_Tipo.Descripcion = varDescripcion;

            String sMsg = "";
            if (!ValidaDataToSave(myTTDominio_Tipo, out sMsg))
            {
                throw new Exception(sMsg);
            }
            myTTDominio_Tipo.Update(globalInfo, dr);
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyFolio)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
         return myTTDominio_Tipo.Delete(KeyFolio, globalInfo, dr);
    }

    [WebMethod]
    public TTDominio_TipoCS.objectBussinessTTDominio_Tipo GetByKey(int? KeyFolio, Boolean ConRelaciones)
    {
        myTTDominio_Tipo.GetByKey(KeyFolio, ConRelaciones);;
        return myTTDominio_Tipo;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyFolio)
    {
        return myTTDominio_Tipo.CurrentPosicion(KeyFolio);
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyFolio)
    {
        return myTTDominio_Tipo.ValidaExistencia(KeyFolio);
    }

    private bool ValidaDataToSave(TTDominio_TipoCS.objectBussinessTTDominio_Tipo MyDataTTDominio_Tipo, out String sMsg)
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

    public bool ValidaDataDuplication(TTDominio_TipoCS.objectBussinessTTDominio_Tipo MyDataTTDominio_Tipo, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTTDominio_Tipo.Folio == -1)
        {
            if (MyDataTTDominio_Tipo.ValidaExistencia(MyDataTTDominio_Tipo.Folio))
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