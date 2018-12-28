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
public class objectBussinessTTFormatos : System.Web.Services.WebService
{
    public int iProcess = 17499;
    private TTTraductor.Traductor MyTraductor;
    public TTFormatosCS.objectBussinessTTFormatos myTTFormatos = new TTFormatosCS.objectBussinessTTFormatos();

    [WebMethod]
    public Int32 SelCount()
    {
        return myTTFormatos.SelCount();
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
        return myTTFormatos.SelAll(ConRelaciones);
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, TTFormatosCS.TTFormatosFilters[] myFilters)
    {
        myTTFormatos.Filters = myFilters;
        return myTTFormatos.SelAll(ConRelaciones);
        myTTFormatos.Filters = null;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTFormatos.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varProcesoId, int? varColumna, String varNombre, String varCabecero, String varFormato, String varPie)
    {
        TTFormatosCS.objectBussinessTTFormatos  myTTFormatos= new TTFormatosCS.objectBussinessTTFormatos();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTFormatos.ProcesoId = varProcesoId;
        myTTFormatos.Columna = varColumna;
        myTTFormatos.Nombre = varNombre;
        myTTFormatos.Cabecero = varCabecero;
        myTTFormatos.Formato = varFormato;
        myTTFormatos.Pie = varPie;

        String sMsg = "";
        if (!ValidaDataToSave(myTTFormatos, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTFormatos, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTFormatos.Insert(globalInfo, dr);
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, int? varProcesoId, int? varColumna, String varNombre, String varCabecero, String varFormato, String varPie)
    {
        TTFormatosCS.objectBussinessTTFormatos  myTTFormatos= new TTFormatosCS.objectBussinessTTFormatos();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTFormatos.ProcesoId = varProcesoId;
        myTTFormatos.Columna = varColumna;
        myTTFormatos.Nombre = varNombre;
        myTTFormatos.Cabecero = varCabecero;
        myTTFormatos.Formato = varFormato;
        myTTFormatos.Pie = varPie;

        String sMsg = "";
        if (!ValidaDataToSave(myTTFormatos, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTFormatos, out sMsg))
        {
            throw new Exception(sMsg);
        }
        return myTTFormatos.InsertWithReturnValue(globalInfo, dr);
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varidFormato, int? varProcesoId, int? varColumna, String varNombre, String varCabecero, String varFormato, String varPie)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myTTFormatos.idFormato = varidFormato;
        myTTFormatos.ProcesoId = varProcesoId;
        myTTFormatos.Columna = varColumna;
        myTTFormatos.Nombre = varNombre;
        myTTFormatos.Cabecero = varCabecero;
        myTTFormatos.Formato = varFormato;
        myTTFormatos.Pie = varPie;

            String sMsg = "";
            if (!ValidaDataToSave(myTTFormatos, out sMsg))
            {
                throw new Exception(sMsg);
            }
            myTTFormatos.Update(globalInfo, dr);
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyidFormato)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
         return myTTFormatos.Delete(KeyidFormato, globalInfo, dr);
    }

    [WebMethod]
    public TTFormatosCS.objectBussinessTTFormatos GetByKey(int? KeyidFormato, Boolean ConRelaciones)
    {
        myTTFormatos.GetByKey(KeyidFormato, ConRelaciones);;
        return myTTFormatos;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyidFormato)
    {
        return myTTFormatos.CurrentPosicion(KeyidFormato);
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyidFormato)
    {
        return myTTFormatos.ValidaExistencia(KeyidFormato);
    }

    private bool ValidaDataToSave(TTFormatosCS.objectBussinessTTFormatos MyDataTTFormatos, out String sMsg)
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

    public bool ValidaDataDuplication(TTFormatosCS.objectBussinessTTFormatos MyDataTTFormatos, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTTFormatos.idFormato == -1)
        {
            if (MyDataTTFormatos.ValidaExistencia(MyDataTTFormatos.idFormato))
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
    public DataSet FillDataProcesoId(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTFormatos.FillDataProcesoId().Copy());
        else
            ds.Tables.Add(myTTFormatos.FillDataProcesoId(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataProcesoIdCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTFormatos.FillDataProcesoId();

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
    public DataSet FillDataColumnawithParent(int Key)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTFormatos.FillDataColumna(Key).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet FillDataColumna()
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTFormatos.FillDataColumna().Copy());
        return ds;
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataColumnaCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTFormatos.FillDataColumna();

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
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataColumnawithParentCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);

        int value;
        if (!kv.ContainsKey("ProcesoId") || !Int32.TryParse(kv["ProcesoId"], out value))
            return null;

        try
        {
            DataTable dt = new DataTable();
            dt = myTTFormatos.FillDataColumna(value);

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