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
public class objectBussinessTTDominio : System.Web.Services.WebService
{
    public int iProcess = 6835;
    private TTTraductor.Traductor MyTraductor;
    public TTDominioCS.objectBussinessTTDominio myTTDominio = new TTDominioCS.objectBussinessTTDominio();

    [WebMethod]
    public Int32 SelCount()
    {
        return myTTDominio.SelCount();
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
        return myTTDominio.SelAll(ConRelaciones);
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, TTDominioCS.TTDominioFilters[] myFilters)
    {
        myTTDominio.Filters = myFilters;
        return myTTDominio.SelAll(ConRelaciones);
        myTTDominio.Filters = null;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTDominio.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, String varDescripcion, int? varTipo, int? varRelacionDT, int? varRelacionDNT)
    {
        TTDominioCS.objectBussinessTTDominio  myTTDominio= new TTDominioCS.objectBussinessTTDominio();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTDominio.Descripcion = varDescripcion;
        myTTDominio.Tipo = varTipo;
        myTTDominio.RelacionDT = varRelacionDT;
        myTTDominio.RelacionDNT = varRelacionDNT;

        String sMsg = "";
        if (!ValidaDataToSave(myTTDominio, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTDominio, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTDominio.Insert(globalInfo, dr);
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, String varDescripcion, int? varTipo, int? varRelacionDT, int? varRelacionDNT)
    {
        TTDominioCS.objectBussinessTTDominio  myTTDominio= new TTDominioCS.objectBussinessTTDominio();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTDominio.Descripcion = varDescripcion;
        myTTDominio.Tipo = varTipo;
        myTTDominio.RelacionDT = varRelacionDT;
        myTTDominio.RelacionDNT = varRelacionDNT;

        String sMsg = "";
        if (!ValidaDataToSave(myTTDominio, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTDominio, out sMsg))
        {
            throw new Exception(sMsg);
        }
        return myTTDominio.InsertWithReturnValue(globalInfo, dr);
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varFolio, String varDescripcion, int? varTipo, int? varRelacionDT, int? varRelacionDNT)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myTTDominio.Folio = varFolio;
        myTTDominio.Descripcion = varDescripcion;
        myTTDominio.Tipo = varTipo;
        myTTDominio.RelacionDT = varRelacionDT;
        myTTDominio.RelacionDNT = varRelacionDNT;

            String sMsg = "";
            if (!ValidaDataToSave(myTTDominio, out sMsg))
            {
                throw new Exception(sMsg);
            }
            myTTDominio.Update(globalInfo, dr);
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyFolio)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
         return myTTDominio.Delete(KeyFolio, globalInfo, dr);
    }

    [WebMethod]
    public TTDominioCS.objectBussinessTTDominio GetByKey(int? KeyFolio, Boolean ConRelaciones)
    {
        myTTDominio.GetByKey(KeyFolio, ConRelaciones);;
        return myTTDominio;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyFolio)
    {
        return myTTDominio.CurrentPosicion(KeyFolio);
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyFolio)
    {
        return myTTDominio.ValidaExistencia(KeyFolio);
    }

    private bool ValidaDataToSave(TTDominioCS.objectBussinessTTDominio MyDataTTDominio, out String sMsg)
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

    public bool ValidaDataDuplication(TTDominioCS.objectBussinessTTDominio MyDataTTDominio, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTTDominio.Folio == -1)
        {
            if (MyDataTTDominio.ValidaExistencia(MyDataTTDominio.Folio))
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
    public DataSet FillDataTipo(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTDominio.FillDataTipo().Copy());
        else
            ds.Tables.Add(myTTDominio.FillDataTipo(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataTipoCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTDominio.FillDataTipo();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Descripcion"].ToString(), dRow["Folio"].ToString()));
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
        ds.Tables.Add(myTTDominio.FillDataRelacionDT(Key).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet FillDataRelacionDT()
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTDominio.FillDataRelacionDT().Copy());
        return ds;
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataRelacionDTwithParentCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);

        int value;
        if (!kv.ContainsKey("RelacionDNT") || !Int32.TryParse(kv["RelacionDNT"], out value))
            return null;

        try
        {
            DataTable dt = new DataTable();
            dt = myTTDominio.FillDataRelacionDT(value);

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["DTID"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }
    [WebMethod]
    public DataSet FillDataRelacionDNT(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTDominio.FillDataRelacionDNT().Copy());
        else
            ds.Tables.Add(myTTDominio.FillDataRelacionDNT(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataRelacionDNTCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTDominio.FillDataRelacionDNT();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre_Tabla"].ToString(), dRow["DNTID"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }

}