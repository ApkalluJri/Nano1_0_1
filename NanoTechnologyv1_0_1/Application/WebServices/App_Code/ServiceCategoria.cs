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
public class objectBussinessCategoria : System.Web.Services.WebService
{
    public int iProcess = 29983;
    private TTTraductor.Traductor MyTraductor;
    


    [WebMethod]
    public string ListaGetFullQuery(string sWhere,string sOrder)
    {
	CategoriaCS.objectBussinessCategoria myCategoria = new CategoriaCS.objectBussinessCategoria();
        string result = myCategoria.GetFullQuery(sWhere, sOrder);
	myCategoria.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ListaSelAll(int startRowIndex,int maximumRows,string where,string Order)
    {
	CategoriaCS.objectBussinessCategoria myCategoria = new CategoriaCS.objectBussinessCategoria();
        DataSet result = myCategoria.SelAll(startRowIndex, maximumRows, where, Order);
	myCategoria.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ImpresionSelAll(string where, string Order)
    {
	CategoriaCS.objectBussinessCategoria myCategoria = new CategoriaCS.objectBussinessCategoria();
        DataSet result = myCategoria.SelAll(where, Order);
	myCategoria.Dispose();
        return result;
    }

    [WebMethod]
    public int ListaSelCount(string where)
    {
	CategoriaCS.objectBussinessCategoria myCategoria = new CategoriaCS.objectBussinessCategoria();
        int result = myCategoria.SelCount(where);
	myCategoria.Dispose();
        return result;
    }


    [WebMethod]
    public Int32 SelCount()
    {
	CategoriaCS.objectBussinessCategoria myCategoria = new CategoriaCS.objectBussinessCategoria();
        Int32 result = myCategoria.SelCount();
	myCategoria.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
	CategoriaCS.objectBussinessCategoria myCategoria = new CategoriaCS.objectBussinessCategoria();
        DataSet result = myCategoria.SelAll(ConRelaciones);
	myCategoria.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, CategoriaCS.CategoriaFilters[] myFilters)
    {
        CategoriaCS.objectBussinessCategoria myCategoria = new CategoriaCS.objectBussinessCategoria();
        myCategoria.Filters = myFilters;
        DataSet result = myCategoria.SelAll(ConRelaciones);
        myCategoria.Filters = null;
        myCategoria.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        CategoriaCS.objectBussinessCategoria myCategoria = new CategoriaCS.objectBussinessCategoria();
        DataSet ds = new DataSet();
        ds.Tables.Add(myCategoria.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        myCategoria.Dispose(); 
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, String varDescripcion, int? varIcono, int? varColor_Franja, int? varImagen)
    {
        CategoriaCS.objectBussinessCategoria  myCategoria = new CategoriaCS.objectBussinessCategoria();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myCategoria.Descripcion = varDescripcion;
        myCategoria.Icono = varIcono;
        myCategoria.Color_Franja = varColor_Franja;
        myCategoria.Imagen = varImagen;

        String sMsg = "";
        if (!ValidaDataToSave(myCategoria, out sMsg))
        {
            myCategoria.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myCategoria, out sMsg))
        {
            myCategoria.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        myCategoria.Insert(globalInfo, dr);
        myCategoria.Dispose();
        dr = null;
        globalInfo = null;
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, String varDescripcion, int? varIcono, int? varColor_Franja, int? varImagen)
    {
        CategoriaCS.objectBussinessCategoria  myCategoria= new CategoriaCS.objectBussinessCategoria();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myCategoria.Descripcion = varDescripcion;
        myCategoria.Icono = varIcono;
        myCategoria.Color_Franja = varColor_Franja;
        myCategoria.Imagen = varImagen;

        String sMsg = "";
        if (!ValidaDataToSave(myCategoria, out sMsg))
        {
            myCategoria.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myCategoria, out sMsg))
        {
            myCategoria.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        object result=myCategoria.InsertWithReturnValue(globalInfo, dr);
        myCategoria.Dispose();
        dr = null;
        globalInfo = null;
        return result;
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varClave, String varDescripcion, int? varIcono, int? varColor_Franja, int? varImagen)
    {
        CategoriaCS.objectBussinessCategoria myCategoria = new CategoriaCS.objectBussinessCategoria();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myCategoria.Clave = varClave;
        myCategoria.Descripcion = varDescripcion;
        myCategoria.Icono = varIcono;
        myCategoria.Color_Franja = varColor_Franja;
        myCategoria.Imagen = varImagen;

            String sMsg = "";
            if (!ValidaDataToSave(myCategoria, out sMsg))
            {
                myCategoria.Dispose();
                dr = null;
                globalInfo = null;
                throw new Exception(sMsg);
            }
            myCategoria.Update(globalInfo, dr);
            myCategoria.Dispose();
            dr = null;
            globalInfo = null;
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyClave)
    {
        CategoriaCS.objectBussinessCategoria myCategoria = new CategoriaCS.objectBussinessCategoria();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        bool result = myCategoria.Delete(KeyClave, globalInfo, dr);
        myCategoria.Dispose();
        dr = null;
        return result;
    }

    [WebMethod]
    public CategoriaCS.objectBussinessCategoria GetByKey(int? KeyClave, Boolean ConRelaciones)
    {
        CategoriaCS.objectBussinessCategoria myCategoria = new CategoriaCS.objectBussinessCategoria();
        myCategoria.GetByKey(KeyClave, ConRelaciones);;
        return myCategoria;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyClave)
    {
        CategoriaCS.objectBussinessCategoria myCategoria = new CategoriaCS.objectBussinessCategoria();
        Int32 result = myCategoria.CurrentPosicion(KeyClave);
        return result;
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyClave)
    {
        CategoriaCS.objectBussinessCategoria myCategoria = new CategoriaCS.objectBussinessCategoria();
        Boolean result = myCategoria.ValidaExistencia(KeyClave);
        myCategoria.Dispose();
        return result;
    }

    private bool ValidaDataToSave(CategoriaCS.objectBussinessCategoria MyDataCategoria, out String sMsg)
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

    public bool ValidaDataDuplication(CategoriaCS.objectBussinessCategoria MyDataCategoria, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataCategoria.Clave == -1)
        {
            if (MyDataCategoria.ValidaExistencia(MyDataCategoria.Clave))
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
    public DataSet FillDataColor_Franja(String sFiltro)
    {
        CategoriaCS.objectBussinessCategoria myCategoria = new CategoriaCS.objectBussinessCategoria();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myCategoria.FillDataColor_Franja().Copy());
        else
            ds.Tables.Add(myCategoria.FillDataColor_Franja(sFiltro).Copy());
        myCategoria.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataColor_FranjaCDD(string knownCategoryValues, string category)
    {
        CategoriaCS.objectBussinessCategoria myCategoria = new CategoriaCS.objectBussinessCategoria();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myCategoria.FillDataColor_Franja();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Descripcion"].ToString(), dRow["Clave"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myCategoria.Dispose();
        return values.ToArray();
    }
}
