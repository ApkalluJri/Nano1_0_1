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
public class objectBussinessTTLanguage : System.Web.Services.WebService
{
    public int iProcess = 6834;
    private TTTraductor.Traductor MyTraductor;
    public TTLanguageCS.objectBussinessTTLanguage myTTLanguage = new TTLanguageCS.objectBussinessTTLanguage();

    [WebMethod]
    public Int32 SelCount()
    {
        return myTTLanguage.SelCount();
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
        return myTTLanguage.SelAll(ConRelaciones);
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, TTLanguageCS.TTLanguageFilters[] myFilters)
    {
        myTTLanguage.Filters = myFilters;
        return myTTLanguage.SelAll(ConRelaciones);
        myTTLanguage.Filters = null;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTLanguage.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, String varIdioma, int? varBandera, String varAbreviatura)
    {
        TTLanguageCS.objectBussinessTTLanguage  myTTLanguage= new TTLanguageCS.objectBussinessTTLanguage();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTLanguage.Idioma = varIdioma;
        myTTLanguage.Bandera = varBandera;
        myTTLanguage.Abreviatura = varAbreviatura;

        String sMsg = "";
        if (!ValidaDataToSave(myTTLanguage, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTLanguage, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTLanguage.Insert(globalInfo, dr);
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, String varIdioma, int? varBandera, String varAbreviatura)
    {
        TTLanguageCS.objectBussinessTTLanguage  myTTLanguage= new TTLanguageCS.objectBussinessTTLanguage();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTLanguage.Idioma = varIdioma;
        myTTLanguage.Bandera = varBandera;
        myTTLanguage.Abreviatura = varAbreviatura;

        String sMsg = "";
        if (!ValidaDataToSave(myTTLanguage, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTLanguage, out sMsg))
        {
            throw new Exception(sMsg);
        }
        return myTTLanguage.InsertWithReturnValue(globalInfo, dr);
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varidLanguage, String varIdioma, int? varBandera, String varAbreviatura)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myTTLanguage.idLanguage = varidLanguage;
        myTTLanguage.Idioma = varIdioma;
        myTTLanguage.Bandera = varBandera;
        myTTLanguage.Abreviatura = varAbreviatura;

            String sMsg = "";
            if (!ValidaDataToSave(myTTLanguage, out sMsg))
            {
                throw new Exception(sMsg);
            }
            myTTLanguage.Update(globalInfo, dr);
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyidLanguage)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
         return myTTLanguage.Delete(KeyidLanguage, globalInfo, dr);
    }

    [WebMethod]
    public TTLanguageCS.objectBussinessTTLanguage GetByKey(int? KeyidLanguage, Boolean ConRelaciones)
    {
        myTTLanguage.GetByKey(KeyidLanguage, ConRelaciones);;
        return myTTLanguage;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyidLanguage)
    {
        return myTTLanguage.CurrentPosicion(KeyidLanguage);
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyidLanguage)
    {
        return myTTLanguage.ValidaExistencia(KeyidLanguage);
    }

    private bool ValidaDataToSave(TTLanguageCS.objectBussinessTTLanguage MyDataTTLanguage, out String sMsg)
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

    public bool ValidaDataDuplication(TTLanguageCS.objectBussinessTTLanguage MyDataTTLanguage, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTTLanguage.idLanguage == -1)
        {
            if (MyDataTTLanguage.ValidaExistencia(MyDataTTLanguage.idLanguage))
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