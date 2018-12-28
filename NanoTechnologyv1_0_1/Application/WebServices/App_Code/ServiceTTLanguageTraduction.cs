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
public class objectBussinessTTLanguageTraduction : System.Web.Services.WebService
{
    public int iProcess = 6833;
    private TTTraductor.Traductor MyTraductor;
    public TTLanguageTraductionCS.objectBussinessTTLanguageTraduction myTTLanguageTraduction = new TTLanguageTraductionCS.objectBussinessTTLanguageTraduction();

    [WebMethod]
    public Int32 SelCount()
    {
        return myTTLanguageTraduction.SelCount();
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
        return myTTLanguageTraduction.SelAll(ConRelaciones);
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, TTLanguageTraductionCS.TTLanguageTraductionFilters[] myFilters)
    {
        myTTLanguageTraduction.Filters = myFilters;
        return myTTLanguageTraduction.SelAll(ConRelaciones);
        myTTLanguageTraduction.Filters = null;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTLanguageTraduction.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, String varTexto, int? varIdioma, int? varRelacionProceso, int? varRelacionDominio, int? varRelacionDT, int? varRelacionMessage)
    {
        TTLanguageTraductionCS.objectBussinessTTLanguageTraduction  myTTLanguageTraduction= new TTLanguageTraductionCS.objectBussinessTTLanguageTraduction();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTLanguageTraduction.Texto = varTexto;
        myTTLanguageTraduction.Idioma = varIdioma;
        myTTLanguageTraduction.RelacionProceso = varRelacionProceso;
        myTTLanguageTraduction.RelacionDominio = varRelacionDominio;
        myTTLanguageTraduction.RelacionDT = varRelacionDT;
        myTTLanguageTraduction.RelacionMessage = varRelacionMessage;

        String sMsg = "";
        if (!ValidaDataToSave(myTTLanguageTraduction, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTLanguageTraduction, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTLanguageTraduction.Insert(globalInfo, dr);
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, String varTexto, int? varIdioma, int? varRelacionProceso, int? varRelacionDominio, int? varRelacionDT, int? varRelacionMessage)
    {
        TTLanguageTraductionCS.objectBussinessTTLanguageTraduction  myTTLanguageTraduction= new TTLanguageTraductionCS.objectBussinessTTLanguageTraduction();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTLanguageTraduction.Texto = varTexto;
        myTTLanguageTraduction.Idioma = varIdioma;
        myTTLanguageTraduction.RelacionProceso = varRelacionProceso;
        myTTLanguageTraduction.RelacionDominio = varRelacionDominio;
        myTTLanguageTraduction.RelacionDT = varRelacionDT;
        myTTLanguageTraduction.RelacionMessage = varRelacionMessage;

        String sMsg = "";
        if (!ValidaDataToSave(myTTLanguageTraduction, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTLanguageTraduction, out sMsg))
        {
            throw new Exception(sMsg);
        }
        return myTTLanguageTraduction.InsertWithReturnValue(globalInfo, dr);
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varidTraduction, String varTexto, int? varIdioma, int? varRelacionProceso, int? varRelacionDominio, int? varRelacionDT, int? varRelacionMessage)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myTTLanguageTraduction.idTraduction = varidTraduction;
        myTTLanguageTraduction.Texto = varTexto;
        myTTLanguageTraduction.Idioma = varIdioma;
        myTTLanguageTraduction.RelacionProceso = varRelacionProceso;
        myTTLanguageTraduction.RelacionDominio = varRelacionDominio;
        myTTLanguageTraduction.RelacionDT = varRelacionDT;
        myTTLanguageTraduction.RelacionMessage = varRelacionMessage;

            String sMsg = "";
            if (!ValidaDataToSave(myTTLanguageTraduction, out sMsg))
            {
                throw new Exception(sMsg);
            }
            myTTLanguageTraduction.Update(globalInfo, dr);
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyidTraduction)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
         return myTTLanguageTraduction.Delete(KeyidTraduction, globalInfo, dr);
    }

    [WebMethod]
    public TTLanguageTraductionCS.objectBussinessTTLanguageTraduction GetByKey(int? KeyidTraduction, Boolean ConRelaciones)
    {
        myTTLanguageTraduction.GetByKey(KeyidTraduction, ConRelaciones);;
        return myTTLanguageTraduction;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyidTraduction)
    {
        return myTTLanguageTraduction.CurrentPosicion(KeyidTraduction);
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyidTraduction)
    {
        return myTTLanguageTraduction.ValidaExistencia(KeyidTraduction);
    }

    private bool ValidaDataToSave(TTLanguageTraductionCS.objectBussinessTTLanguageTraduction MyDataTTLanguageTraduction, out String sMsg)
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

    public bool ValidaDataDuplication(TTLanguageTraductionCS.objectBussinessTTLanguageTraduction MyDataTTLanguageTraduction, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTTLanguageTraduction.idTraduction == -1)
        {
            if (MyDataTTLanguageTraduction.ValidaExistencia(MyDataTTLanguageTraduction.idTraduction))
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
    [WebMethod]
    public DataSet FillDataIdioma(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTLanguageTraduction.FillDataIdioma().Copy());
        else
            ds.Tables.Add(myTTLanguageTraduction.FillDataIdioma(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataIdiomaCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTLanguageTraduction.FillDataIdioma();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Idioma"].ToString(), dRow["idLanguage"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }
    [WebMethod]
    public DataSet FillDataRelacionProceso(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTLanguageTraduction.FillDataRelacionProceso().Copy());
        else
            ds.Tables.Add(myTTLanguageTraduction.FillDataRelacionProceso(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataRelacionProcesoCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTLanguageTraduction.FillDataRelacionProceso();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["IdProceso"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }
    [WebMethod]
    public DataSet FillDataRelacionDominio(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTLanguageTraduction.FillDataRelacionDominio().Copy());
        else
            ds.Tables.Add(myTTLanguageTraduction.FillDataRelacionDominio(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataRelacionDominioCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTLanguageTraduction.FillDataRelacionDominio();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre_Tabla"].ToString(), dRow["DNTID"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }
    [WebMethod]
    public DataSet FillDataRelacionDTwithParent(int Key)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTLanguageTraduction.FillDataRelacionDT(Key).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet FillDataRelacionDT()
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTLanguageTraduction.FillDataRelacionDT().Copy());
        return ds;
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataRelacionDTwithParentCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);

        int value;
        if (!kv.ContainsKey("RelacionDominio") || !Int32.TryParse(kv["RelacionDominio"], out value))
            return null;

        try
        {
            DataTable dt = new DataTable();
            dt = myTTLanguageTraduction.FillDataRelacionDT(value);

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["DTID"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }

}