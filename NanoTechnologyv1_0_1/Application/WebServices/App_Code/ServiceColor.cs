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
public class objectBussinessColor : System.Web.Services.WebService
{
    public int iProcess = 29992;
    private TTTraductor.Traductor MyTraductor;
    


    [WebMethod]
    public string ListaGetFullQuery(string sWhere,string sOrder)
    {
	ColorCS.objectBussinessColor myColor = new ColorCS.objectBussinessColor();
        string result = myColor.GetFullQuery(sWhere, sOrder);
	myColor.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ListaSelAll(int startRowIndex,int maximumRows,string where,string Order)
    {
	ColorCS.objectBussinessColor myColor = new ColorCS.objectBussinessColor();
        DataSet result = myColor.SelAll(startRowIndex, maximumRows, where, Order);
	myColor.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ImpresionSelAll(string where, string Order)
    {
	ColorCS.objectBussinessColor myColor = new ColorCS.objectBussinessColor();
        DataSet result = myColor.SelAll(where, Order);
	myColor.Dispose();
        return result;
    }

    [WebMethod]
    public int ListaSelCount(string where)
    {
	ColorCS.objectBussinessColor myColor = new ColorCS.objectBussinessColor();
        int result = myColor.SelCount(where);
	myColor.Dispose();
        return result;
    }


    [WebMethod]
    public Int32 SelCount()
    {
	ColorCS.objectBussinessColor myColor = new ColorCS.objectBussinessColor();
        Int32 result = myColor.SelCount();
	myColor.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
	ColorCS.objectBussinessColor myColor = new ColorCS.objectBussinessColor();
        DataSet result = myColor.SelAll(ConRelaciones);
	myColor.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, ColorCS.ColorFilters[] myFilters)
    {
        ColorCS.objectBussinessColor myColor = new ColorCS.objectBussinessColor();
        myColor.Filters = myFilters;
        DataSet result = myColor.SelAll(ConRelaciones);
        myColor.Filters = null;
        myColor.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        ColorCS.objectBussinessColor myColor = new ColorCS.objectBussinessColor();
        DataSet ds = new DataSet();
        ds.Tables.Add(myColor.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        myColor.Dispose(); 
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, String varDescripcion, String varCodigo_RGB)
    {
        ColorCS.objectBussinessColor  myColor = new ColorCS.objectBussinessColor();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myColor.Descripcion = varDescripcion;
        myColor.Codigo_RGB = varCodigo_RGB;

        String sMsg = "";
        if (!ValidaDataToSave(myColor, out sMsg))
        {
            myColor.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myColor, out sMsg))
        {
            myColor.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        myColor.Insert(globalInfo, dr);
        myColor.Dispose();
        dr = null;
        globalInfo = null;
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, String varDescripcion, String varCodigo_RGB)
    {
        ColorCS.objectBussinessColor  myColor= new ColorCS.objectBussinessColor();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myColor.Descripcion = varDescripcion;
        myColor.Codigo_RGB = varCodigo_RGB;

        String sMsg = "";
        if (!ValidaDataToSave(myColor, out sMsg))
        {
            myColor.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myColor, out sMsg))
        {
            myColor.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        object result=myColor.InsertWithReturnValue(globalInfo, dr);
        myColor.Dispose();
        dr = null;
        globalInfo = null;
        return result;
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varClave, String varDescripcion, String varCodigo_RGB)
    {
        ColorCS.objectBussinessColor myColor = new ColorCS.objectBussinessColor();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myColor.Clave = varClave;
        myColor.Descripcion = varDescripcion;
        myColor.Codigo_RGB = varCodigo_RGB;

            String sMsg = "";
            if (!ValidaDataToSave(myColor, out sMsg))
            {
                myColor.Dispose();
                dr = null;
                globalInfo = null;
                throw new Exception(sMsg);
            }
            myColor.Update(globalInfo, dr);
            myColor.Dispose();
            dr = null;
            globalInfo = null;
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyClave)
    {
        ColorCS.objectBussinessColor myColor = new ColorCS.objectBussinessColor();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        bool result = myColor.Delete(KeyClave, globalInfo, dr);
        myColor.Dispose();
        dr = null;
        return result;
    }

    [WebMethod]
    public ColorCS.objectBussinessColor GetByKey(int? KeyClave, Boolean ConRelaciones)
    {
        ColorCS.objectBussinessColor myColor = new ColorCS.objectBussinessColor();
        myColor.GetByKey(KeyClave, ConRelaciones);;
        return myColor;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyClave)
    {
        ColorCS.objectBussinessColor myColor = new ColorCS.objectBussinessColor();
        Int32 result = myColor.CurrentPosicion(KeyClave);
        return result;
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyClave)
    {
        ColorCS.objectBussinessColor myColor = new ColorCS.objectBussinessColor();
        Boolean result = myColor.ValidaExistencia(KeyClave);
        myColor.Dispose();
        return result;
    }

    private bool ValidaDataToSave(ColorCS.objectBussinessColor MyDataColor, out String sMsg)
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

    public bool ValidaDataDuplication(ColorCS.objectBussinessColor MyDataColor, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataColor.Clave == -1)
        {
            if (MyDataColor.ValidaExistencia(MyDataColor.Clave))
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
