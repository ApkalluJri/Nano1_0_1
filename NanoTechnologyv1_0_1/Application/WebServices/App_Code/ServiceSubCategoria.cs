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
public class objectBussinessSubCategoria : System.Web.Services.WebService
{
    public int iProcess = 30053;
    private TTTraductor.Traductor MyTraductor;
    


    [WebMethod]
    public string ListaGetFullQuery(string sWhere,string sOrder)
    {
	SubCategoriaCS.objectBussinessSubCategoria mySubCategoria = new SubCategoriaCS.objectBussinessSubCategoria();
        string result = mySubCategoria.GetFullQuery(sWhere, sOrder);
	mySubCategoria.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ListaSelAll(int startRowIndex,int maximumRows,string where,string Order)
    {
	SubCategoriaCS.objectBussinessSubCategoria mySubCategoria = new SubCategoriaCS.objectBussinessSubCategoria();
        DataSet result = mySubCategoria.SelAll(startRowIndex, maximumRows, where, Order);
	mySubCategoria.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ImpresionSelAll(string where, string Order)
    {
	SubCategoriaCS.objectBussinessSubCategoria mySubCategoria = new SubCategoriaCS.objectBussinessSubCategoria();
        DataSet result = mySubCategoria.SelAll(where, Order);
	mySubCategoria.Dispose();
        return result;
    }

    [WebMethod]
    public int ListaSelCount(string where)
    {
	SubCategoriaCS.objectBussinessSubCategoria mySubCategoria = new SubCategoriaCS.objectBussinessSubCategoria();
        int result = mySubCategoria.SelCount(where);
	mySubCategoria.Dispose();
        return result;
    }


    [WebMethod]
    public Int32 SelCount()
    {
	SubCategoriaCS.objectBussinessSubCategoria mySubCategoria = new SubCategoriaCS.objectBussinessSubCategoria();
        Int32 result = mySubCategoria.SelCount();
	mySubCategoria.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
	SubCategoriaCS.objectBussinessSubCategoria mySubCategoria = new SubCategoriaCS.objectBussinessSubCategoria();
        DataSet result = mySubCategoria.SelAll(ConRelaciones);
	mySubCategoria.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, SubCategoriaCS.SubCategoriaFilters[] myFilters)
    {
        SubCategoriaCS.objectBussinessSubCategoria mySubCategoria = new SubCategoriaCS.objectBussinessSubCategoria();
        mySubCategoria.Filters = myFilters;
        DataSet result = mySubCategoria.SelAll(ConRelaciones);
        mySubCategoria.Filters = null;
        mySubCategoria.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        SubCategoriaCS.objectBussinessSubCategoria mySubCategoria = new SubCategoriaCS.objectBussinessSubCategoria();
        DataSet ds = new DataSet();
        ds.Tables.Add(mySubCategoria.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        mySubCategoria.Dispose(); 
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, String varDescripcion, int? varCategoria)
    {
        SubCategoriaCS.objectBussinessSubCategoria  mySubCategoria = new SubCategoriaCS.objectBussinessSubCategoria();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        mySubCategoria.Descripcion = varDescripcion;
        mySubCategoria.Categoria = varCategoria;

        String sMsg = "";
        if (!ValidaDataToSave(mySubCategoria, out sMsg))
        {
            mySubCategoria.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(mySubCategoria, out sMsg))
        {
            mySubCategoria.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        mySubCategoria.Insert(globalInfo, dr);
        mySubCategoria.Dispose();
        dr = null;
        globalInfo = null;
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, String varDescripcion, int? varCategoria)
    {
        SubCategoriaCS.objectBussinessSubCategoria  mySubCategoria= new SubCategoriaCS.objectBussinessSubCategoria();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        mySubCategoria.Descripcion = varDescripcion;
        mySubCategoria.Categoria = varCategoria;

        String sMsg = "";
        if (!ValidaDataToSave(mySubCategoria, out sMsg))
        {
            mySubCategoria.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(mySubCategoria, out sMsg))
        {
            mySubCategoria.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        object result=mySubCategoria.InsertWithReturnValue(globalInfo, dr);
        mySubCategoria.Dispose();
        dr = null;
        globalInfo = null;
        return result;
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varClave, String varDescripcion, int? varCategoria)
    {
        SubCategoriaCS.objectBussinessSubCategoria mySubCategoria = new SubCategoriaCS.objectBussinessSubCategoria();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        mySubCategoria.Clave = varClave;
        mySubCategoria.Descripcion = varDescripcion;
        mySubCategoria.Categoria = varCategoria;

            String sMsg = "";
            if (!ValidaDataToSave(mySubCategoria, out sMsg))
            {
                mySubCategoria.Dispose();
                dr = null;
                globalInfo = null;
                throw new Exception(sMsg);
            }
            mySubCategoria.Update(globalInfo, dr);
            mySubCategoria.Dispose();
            dr = null;
            globalInfo = null;
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyClave)
    {
        SubCategoriaCS.objectBussinessSubCategoria mySubCategoria = new SubCategoriaCS.objectBussinessSubCategoria();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        bool result = mySubCategoria.Delete(KeyClave, globalInfo, dr);
        mySubCategoria.Dispose();
        dr = null;
        return result;
    }

    [WebMethod]
    public SubCategoriaCS.objectBussinessSubCategoria GetByKey(int? KeyClave, Boolean ConRelaciones)
    {
        SubCategoriaCS.objectBussinessSubCategoria mySubCategoria = new SubCategoriaCS.objectBussinessSubCategoria();
        mySubCategoria.GetByKey(KeyClave, ConRelaciones);;
        return mySubCategoria;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyClave)
    {
        SubCategoriaCS.objectBussinessSubCategoria mySubCategoria = new SubCategoriaCS.objectBussinessSubCategoria();
        Int32 result = mySubCategoria.CurrentPosicion(KeyClave);
        return result;
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyClave)
    {
        SubCategoriaCS.objectBussinessSubCategoria mySubCategoria = new SubCategoriaCS.objectBussinessSubCategoria();
        Boolean result = mySubCategoria.ValidaExistencia(KeyClave);
        mySubCategoria.Dispose();
        return result;
    }

    private bool ValidaDataToSave(SubCategoriaCS.objectBussinessSubCategoria MyDataSubCategoria, out String sMsg)
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

    public bool ValidaDataDuplication(SubCategoriaCS.objectBussinessSubCategoria MyDataSubCategoria, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataSubCategoria.Clave == -1)
        {
            if (MyDataSubCategoria.ValidaExistencia(MyDataSubCategoria.Clave))
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
    public DataSet FillDataCategoria(String sFiltro)
    {
        SubCategoriaCS.objectBussinessSubCategoria mySubCategoria = new SubCategoriaCS.objectBussinessSubCategoria();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(mySubCategoria.FillDataCategoria().Copy());
        else
            ds.Tables.Add(mySubCategoria.FillDataCategoria(sFiltro).Copy());
        mySubCategoria.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataCategoriaCDD(string knownCategoryValues, string category)
    {
        SubCategoriaCS.objectBussinessSubCategoria mySubCategoria = new SubCategoriaCS.objectBussinessSubCategoria();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = mySubCategoria.FillDataCategoria();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Descripcion"].ToString(), dRow["Clave"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        mySubCategoria.Dispose();
        return values.ToArray();
    }
}
