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
public class objectBussinessDetalle_de_Etiquetas : System.Web.Services.WebService
{
    public int iProcess = 29989;
    private TTTraductor.Traductor MyTraductor;
    


    [WebMethod]
    public string ListaGetFullQuery(string sWhere,string sOrder)
    {
	Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas myDetalle_de_Etiquetas = new Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas();
        string result = myDetalle_de_Etiquetas.GetFullQuery(sWhere, sOrder);
	myDetalle_de_Etiquetas.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ListaSelAll(int startRowIndex,int maximumRows,string where,string Order)
    {
	Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas myDetalle_de_Etiquetas = new Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas();
        DataSet result = myDetalle_de_Etiquetas.SelAll(startRowIndex, maximumRows, where, Order);
	myDetalle_de_Etiquetas.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ImpresionSelAll(string where, string Order)
    {
	Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas myDetalle_de_Etiquetas = new Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas();
        DataSet result = myDetalle_de_Etiquetas.SelAll(where, Order);
	myDetalle_de_Etiquetas.Dispose();
        return result;
    }

    [WebMethod]
    public int ListaSelCount(string where)
    {
	Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas myDetalle_de_Etiquetas = new Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas();
        int result = myDetalle_de_Etiquetas.SelCount(where);
	myDetalle_de_Etiquetas.Dispose();
        return result;
    }


    [WebMethod]
    public Int32 SelCount()
    {
	Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas myDetalle_de_Etiquetas = new Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas();
        Int32 result = myDetalle_de_Etiquetas.SelCount();
	myDetalle_de_Etiquetas.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
	Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas myDetalle_de_Etiquetas = new Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas();
        DataSet result = myDetalle_de_Etiquetas.SelAll(ConRelaciones);
	myDetalle_de_Etiquetas.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, Detalle_de_EtiquetasCS.Detalle_de_EtiquetasFilters[] myFilters)
    {
        Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas myDetalle_de_Etiquetas = new Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas();
        myDetalle_de_Etiquetas.Filters = myFilters;
        DataSet result = myDetalle_de_Etiquetas.SelAll(ConRelaciones);
        myDetalle_de_Etiquetas.Filters = null;
        myDetalle_de_Etiquetas.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas myDetalle_de_Etiquetas = new Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas();
        DataSet ds = new DataSet();
        ds.Tables.Add(myDetalle_de_Etiquetas.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        myDetalle_de_Etiquetas.Dispose(); 
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varArticulo, int? varEtiqueta)
    {
        Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas  myDetalle_de_Etiquetas = new Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myDetalle_de_Etiquetas.Articulo = varArticulo;
        myDetalle_de_Etiquetas.Etiqueta = varEtiqueta;

        String sMsg = "";
        if (!ValidaDataToSave(myDetalle_de_Etiquetas, out sMsg))
        {
            myDetalle_de_Etiquetas.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myDetalle_de_Etiquetas, out sMsg))
        {
            myDetalle_de_Etiquetas.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        myDetalle_de_Etiquetas.Insert(globalInfo, dr);
        myDetalle_de_Etiquetas.Dispose();
        dr = null;
        globalInfo = null;
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, int? varArticulo, int? varEtiqueta)
    {
        Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas  myDetalle_de_Etiquetas= new Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myDetalle_de_Etiquetas.Articulo = varArticulo;
        myDetalle_de_Etiquetas.Etiqueta = varEtiqueta;

        String sMsg = "";
        if (!ValidaDataToSave(myDetalle_de_Etiquetas, out sMsg))
        {
            myDetalle_de_Etiquetas.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myDetalle_de_Etiquetas, out sMsg))
        {
            myDetalle_de_Etiquetas.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        object result=myDetalle_de_Etiquetas.InsertWithReturnValue(globalInfo, dr);
        myDetalle_de_Etiquetas.Dispose();
        dr = null;
        globalInfo = null;
        return result;
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varClave, int? varArticulo, int? varEtiqueta)
    {
        Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas myDetalle_de_Etiquetas = new Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myDetalle_de_Etiquetas.Clave = varClave;
        myDetalle_de_Etiquetas.Articulo = varArticulo;
        myDetalle_de_Etiquetas.Etiqueta = varEtiqueta;

            String sMsg = "";
            if (!ValidaDataToSave(myDetalle_de_Etiquetas, out sMsg))
            {
                myDetalle_de_Etiquetas.Dispose();
                dr = null;
                globalInfo = null;
                throw new Exception(sMsg);
            }
            myDetalle_de_Etiquetas.Update(globalInfo, dr);
            myDetalle_de_Etiquetas.Dispose();
            dr = null;
            globalInfo = null;
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyClave, int? KeyArticulo)
    {
        Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas myDetalle_de_Etiquetas = new Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        bool result = myDetalle_de_Etiquetas.Delete(KeyClave, KeyArticulo, globalInfo, dr);
        myDetalle_de_Etiquetas.Dispose();
        dr = null;
        return result;
    }

    [WebMethod]
    public Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas GetByKey(int? KeyClave, int? KeyArticulo, Boolean ConRelaciones)
    {
        Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas myDetalle_de_Etiquetas = new Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas();
        myDetalle_de_Etiquetas.GetByKey(KeyClave, KeyArticulo, ConRelaciones);;
        return myDetalle_de_Etiquetas;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyClave, int? KeyArticulo)
    {
        Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas myDetalle_de_Etiquetas = new Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas();
        Int32 result = myDetalle_de_Etiquetas.CurrentPosicion(KeyClave, KeyArticulo);
        return result;
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyClave, int? KeyArticulo)
    {
        Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas myDetalle_de_Etiquetas = new Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas();
        Boolean result = myDetalle_de_Etiquetas.ValidaExistencia(KeyClave, KeyArticulo);
        myDetalle_de_Etiquetas.Dispose();
        return result;
    }

    private bool ValidaDataToSave(Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas MyDataDetalle_de_Etiquetas, out String sMsg)
    {
        //Validaciones
        sMsg = "";
            if (MyDataDetalle_de_Etiquetas.Etiqueta != null)
            {
                EtiquetasCS.objectBussinessEtiquetas MyDataEtiquetasTemp = new EtiquetasCS.objectBussinessEtiquetas();
                if (!MyDataEtiquetasTemp.ValidaExistencia(MyDataDetalle_de_Etiquetas.Etiqueta))
                {
                    sMsg = sMsg + "El Campo Etiqueta no existe\n";
                }
            }

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

    public bool ValidaDataDuplication(Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas MyDataDetalle_de_Etiquetas, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataDetalle_de_Etiquetas.Clave == -1&& MyDataDetalle_de_Etiquetas.Articulo != null)
        {
            if (MyDataDetalle_de_Etiquetas.ValidaExistencia(MyDataDetalle_de_Etiquetas.Clave, MyDataDetalle_de_Etiquetas.Articulo))
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
        Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas myDetalle_de_Etiquetas = new Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myDetalle_de_Etiquetas.FillDataArticulo().Copy());
        else
            ds.Tables.Add(myDetalle_de_Etiquetas.FillDataArticulo(sFiltro).Copy());
        myDetalle_de_Etiquetas.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataArticuloCDD(string knownCategoryValues, string category)
    {
        Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas myDetalle_de_Etiquetas = new Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myDetalle_de_Etiquetas.FillDataArticulo();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Folio"].ToString(), dRow["Folio"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myDetalle_de_Etiquetas.Dispose();
        return values.ToArray();
    }    [WebMethod]
    public DataSet FillDataEtiqueta(String sFiltro)
    {
        Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas myDetalle_de_Etiquetas = new Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myDetalle_de_Etiquetas.FillDataEtiqueta().Copy());
        else
            ds.Tables.Add(myDetalle_de_Etiquetas.FillDataEtiqueta(sFiltro).Copy());
        myDetalle_de_Etiquetas.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataEtiquetaCDD(string knownCategoryValues, string category)
    {
        Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas myDetalle_de_Etiquetas = new Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myDetalle_de_Etiquetas.FillDataEtiqueta();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Descripcion"].ToString(), dRow["Clave"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myDetalle_de_Etiquetas.Dispose();
        return values.ToArray();
    }
}
