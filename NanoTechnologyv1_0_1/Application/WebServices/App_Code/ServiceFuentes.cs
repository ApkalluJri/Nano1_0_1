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
public class objectBussinessFuentes : System.Web.Services.WebService
{
    public int iProcess = 30048;
    private TTTraductor.Traductor MyTraductor;
    


    [WebMethod]
    public string ListaGetFullQuery(string sWhere,string sOrder)
    {
	FuentesCS.objectBussinessFuentes myFuentes = new FuentesCS.objectBussinessFuentes();
        string result = myFuentes.GetFullQuery(sWhere, sOrder);
	myFuentes.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ListaSelAll(int startRowIndex,int maximumRows,string where,string Order)
    {
	FuentesCS.objectBussinessFuentes myFuentes = new FuentesCS.objectBussinessFuentes();
        DataSet result = myFuentes.SelAll(startRowIndex, maximumRows, where, Order);
	myFuentes.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ImpresionSelAll(string where, string Order)
    {
	FuentesCS.objectBussinessFuentes myFuentes = new FuentesCS.objectBussinessFuentes();
        DataSet result = myFuentes.SelAll(where, Order);
	myFuentes.Dispose();
        return result;
    }

    [WebMethod]
    public int ListaSelCount(string where)
    {
	FuentesCS.objectBussinessFuentes myFuentes = new FuentesCS.objectBussinessFuentes();
        int result = myFuentes.SelCount(where);
	myFuentes.Dispose();
        return result;
    }


    [WebMethod]
    public Int32 SelCount()
    {
	FuentesCS.objectBussinessFuentes myFuentes = new FuentesCS.objectBussinessFuentes();
        Int32 result = myFuentes.SelCount();
	myFuentes.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
	FuentesCS.objectBussinessFuentes myFuentes = new FuentesCS.objectBussinessFuentes();
        DataSet result = myFuentes.SelAll(ConRelaciones);
	myFuentes.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, FuentesCS.FuentesFilters[] myFilters)
    {
        FuentesCS.objectBussinessFuentes myFuentes = new FuentesCS.objectBussinessFuentes();
        myFuentes.Filters = myFilters;
        DataSet result = myFuentes.SelAll(ConRelaciones);
        myFuentes.Filters = null;
        myFuentes.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        FuentesCS.objectBussinessFuentes myFuentes = new FuentesCS.objectBussinessFuentes();
        DataSet ds = new DataSet();
        ds.Tables.Add(myFuentes.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        myFuentes.Dispose(); 
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varArticulo, String varFuente)
    {
        FuentesCS.objectBussinessFuentes  myFuentes = new FuentesCS.objectBussinessFuentes();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myFuentes.Articulo = varArticulo;
        myFuentes.Fuente = varFuente;

        String sMsg = "";
        if (!ValidaDataToSave(myFuentes, out sMsg))
        {
            myFuentes.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myFuentes, out sMsg))
        {
            myFuentes.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        myFuentes.Insert(globalInfo, dr);
        myFuentes.Dispose();
        dr = null;
        globalInfo = null;
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, int? varArticulo, String varFuente)
    {
        FuentesCS.objectBussinessFuentes  myFuentes= new FuentesCS.objectBussinessFuentes();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myFuentes.Articulo = varArticulo;
        myFuentes.Fuente = varFuente;

        String sMsg = "";
        if (!ValidaDataToSave(myFuentes, out sMsg))
        {
            myFuentes.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myFuentes, out sMsg))
        {
            myFuentes.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        object result=myFuentes.InsertWithReturnValue(globalInfo, dr);
        myFuentes.Dispose();
        dr = null;
        globalInfo = null;
        return result;
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varClave, int? varArticulo, String varFuente)
    {
        FuentesCS.objectBussinessFuentes myFuentes = new FuentesCS.objectBussinessFuentes();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myFuentes.Clave = varClave;
        myFuentes.Articulo = varArticulo;
        myFuentes.Fuente = varFuente;

            String sMsg = "";
            if (!ValidaDataToSave(myFuentes, out sMsg))
            {
                myFuentes.Dispose();
                dr = null;
                globalInfo = null;
                throw new Exception(sMsg);
            }
            myFuentes.Update(globalInfo, dr);
            myFuentes.Dispose();
            dr = null;
            globalInfo = null;
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyClave, int? KeyArticulo)
    {
        FuentesCS.objectBussinessFuentes myFuentes = new FuentesCS.objectBussinessFuentes();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        bool result = myFuentes.Delete(KeyClave, KeyArticulo, globalInfo, dr);
        myFuentes.Dispose();
        dr = null;
        return result;
    }

    [WebMethod]
    public FuentesCS.objectBussinessFuentes GetByKey(int? KeyClave, int? KeyArticulo, Boolean ConRelaciones)
    {
        FuentesCS.objectBussinessFuentes myFuentes = new FuentesCS.objectBussinessFuentes();
        myFuentes.GetByKey(KeyClave, KeyArticulo, ConRelaciones);;
        return myFuentes;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyClave, int? KeyArticulo)
    {
        FuentesCS.objectBussinessFuentes myFuentes = new FuentesCS.objectBussinessFuentes();
        Int32 result = myFuentes.CurrentPosicion(KeyClave, KeyArticulo);
        return result;
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyClave, int? KeyArticulo)
    {
        FuentesCS.objectBussinessFuentes myFuentes = new FuentesCS.objectBussinessFuentes();
        Boolean result = myFuentes.ValidaExistencia(KeyClave, KeyArticulo);
        myFuentes.Dispose();
        return result;
    }

    private bool ValidaDataToSave(FuentesCS.objectBussinessFuentes MyDataFuentes, out String sMsg)
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

    public bool ValidaDataDuplication(FuentesCS.objectBussinessFuentes MyDataFuentes, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataFuentes.Clave == -1&& MyDataFuentes.Articulo != null)
        {
            if (MyDataFuentes.ValidaExistencia(MyDataFuentes.Clave, MyDataFuentes.Articulo))
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
    public DataSet FillDataArticulo(String sFiltro)
    {
        FuentesCS.objectBussinessFuentes myFuentes = new FuentesCS.objectBussinessFuentes();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myFuentes.FillDataArticulo().Copy());
        else
            ds.Tables.Add(myFuentes.FillDataArticulo(sFiltro).Copy());
        myFuentes.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataArticuloCDD(string knownCategoryValues, string category)
    {
        FuentesCS.objectBussinessFuentes myFuentes = new FuentesCS.objectBussinessFuentes();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myFuentes.FillDataArticulo();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Folio"].ToString(), dRow["Folio"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myFuentes.Dispose();
        return values.ToArray();
    }
}
