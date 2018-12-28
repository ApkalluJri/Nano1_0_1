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
public class objectBussinessRol_de_Usuario : System.Web.Services.WebService
{
    public int iProcess = 30352;
    private TTTraductor.Traductor MyTraductor;
    


    [WebMethod]
    public string ListaGetFullQuery(string sWhere,string sOrder)
    {
	Rol_de_UsuarioCS.objectBussinessRol_de_Usuario myRol_de_Usuario = new Rol_de_UsuarioCS.objectBussinessRol_de_Usuario();
        string result = myRol_de_Usuario.GetFullQuery(sWhere, sOrder);
	myRol_de_Usuario.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ListaSelAll(int startRowIndex,int maximumRows,string where,string Order)
    {
	Rol_de_UsuarioCS.objectBussinessRol_de_Usuario myRol_de_Usuario = new Rol_de_UsuarioCS.objectBussinessRol_de_Usuario();
        DataSet result = myRol_de_Usuario.SelAll(startRowIndex, maximumRows, where, Order);
	myRol_de_Usuario.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ImpresionSelAll(string where, string Order)
    {
	Rol_de_UsuarioCS.objectBussinessRol_de_Usuario myRol_de_Usuario = new Rol_de_UsuarioCS.objectBussinessRol_de_Usuario();
        DataSet result = myRol_de_Usuario.SelAll(where, Order);
	myRol_de_Usuario.Dispose();
        return result;
    }

    [WebMethod]
    public int ListaSelCount(string where)
    {
	Rol_de_UsuarioCS.objectBussinessRol_de_Usuario myRol_de_Usuario = new Rol_de_UsuarioCS.objectBussinessRol_de_Usuario();
        int result = myRol_de_Usuario.SelCount(where);
	myRol_de_Usuario.Dispose();
        return result;
    }


    [WebMethod]
    public Int32 SelCount()
    {
	Rol_de_UsuarioCS.objectBussinessRol_de_Usuario myRol_de_Usuario = new Rol_de_UsuarioCS.objectBussinessRol_de_Usuario();
        Int32 result = myRol_de_Usuario.SelCount();
	myRol_de_Usuario.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
	Rol_de_UsuarioCS.objectBussinessRol_de_Usuario myRol_de_Usuario = new Rol_de_UsuarioCS.objectBussinessRol_de_Usuario();
        DataSet result = myRol_de_Usuario.SelAll(ConRelaciones);
	myRol_de_Usuario.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, Rol_de_UsuarioCS.Rol_de_UsuarioFilters[] myFilters)
    {
        Rol_de_UsuarioCS.objectBussinessRol_de_Usuario myRol_de_Usuario = new Rol_de_UsuarioCS.objectBussinessRol_de_Usuario();
        myRol_de_Usuario.Filters = myFilters;
        DataSet result = myRol_de_Usuario.SelAll(ConRelaciones);
        myRol_de_Usuario.Filters = null;
        myRol_de_Usuario.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        Rol_de_UsuarioCS.objectBussinessRol_de_Usuario myRol_de_Usuario = new Rol_de_UsuarioCS.objectBussinessRol_de_Usuario();
        DataSet ds = new DataSet();
        ds.Tables.Add(myRol_de_Usuario.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        myRol_de_Usuario.Dispose(); 
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varClave, String varDescripcion)
    {
        Rol_de_UsuarioCS.objectBussinessRol_de_Usuario  myRol_de_Usuario = new Rol_de_UsuarioCS.objectBussinessRol_de_Usuario();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myRol_de_Usuario.Clave = varClave;
        myRol_de_Usuario.Descripcion = varDescripcion;

        String sMsg = "";
        if (!ValidaDataToSave(myRol_de_Usuario, out sMsg))
        {
            myRol_de_Usuario.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myRol_de_Usuario, out sMsg))
        {
            myRol_de_Usuario.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        myRol_de_Usuario.Insert(globalInfo, dr);
        myRol_de_Usuario.Dispose();
        dr = null;
        globalInfo = null;
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, int? varClave, String varDescripcion)
    {
        Rol_de_UsuarioCS.objectBussinessRol_de_Usuario  myRol_de_Usuario= new Rol_de_UsuarioCS.objectBussinessRol_de_Usuario();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myRol_de_Usuario.Clave = varClave;
        myRol_de_Usuario.Descripcion = varDescripcion;

        String sMsg = "";
        if (!ValidaDataToSave(myRol_de_Usuario, out sMsg))
        {
            myRol_de_Usuario.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myRol_de_Usuario, out sMsg))
        {
            myRol_de_Usuario.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        object result=myRol_de_Usuario.InsertWithReturnValue(globalInfo, dr);
        myRol_de_Usuario.Dispose();
        dr = null;
        globalInfo = null;
        return result;
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varClave, String varDescripcion)
    {
        Rol_de_UsuarioCS.objectBussinessRol_de_Usuario myRol_de_Usuario = new Rol_de_UsuarioCS.objectBussinessRol_de_Usuario();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myRol_de_Usuario.Clave = varClave;
        myRol_de_Usuario.Descripcion = varDescripcion;

            String sMsg = "";
            if (!ValidaDataToSave(myRol_de_Usuario, out sMsg))
            {
                myRol_de_Usuario.Dispose();
                dr = null;
                globalInfo = null;
                throw new Exception(sMsg);
            }
            myRol_de_Usuario.Update(globalInfo, dr);
            myRol_de_Usuario.Dispose();
            dr = null;
            globalInfo = null;
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyClave)
    {
        Rol_de_UsuarioCS.objectBussinessRol_de_Usuario myRol_de_Usuario = new Rol_de_UsuarioCS.objectBussinessRol_de_Usuario();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        bool result = myRol_de_Usuario.Delete(KeyClave, globalInfo, dr);
        myRol_de_Usuario.Dispose();
        dr = null;
        return result;
    }

    [WebMethod]
    public Rol_de_UsuarioCS.objectBussinessRol_de_Usuario GetByKey(int? KeyClave, Boolean ConRelaciones)
    {
        Rol_de_UsuarioCS.objectBussinessRol_de_Usuario myRol_de_Usuario = new Rol_de_UsuarioCS.objectBussinessRol_de_Usuario();
        myRol_de_Usuario.GetByKey(KeyClave, ConRelaciones);;
        return myRol_de_Usuario;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyClave)
    {
        Rol_de_UsuarioCS.objectBussinessRol_de_Usuario myRol_de_Usuario = new Rol_de_UsuarioCS.objectBussinessRol_de_Usuario();
        Int32 result = myRol_de_Usuario.CurrentPosicion(KeyClave);
        return result;
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyClave)
    {
        Rol_de_UsuarioCS.objectBussinessRol_de_Usuario myRol_de_Usuario = new Rol_de_UsuarioCS.objectBussinessRol_de_Usuario();
        Boolean result = myRol_de_Usuario.ValidaExistencia(KeyClave);
        myRol_de_Usuario.Dispose();
        return result;
    }

    private bool ValidaDataToSave(Rol_de_UsuarioCS.objectBussinessRol_de_Usuario MyDataRol_de_Usuario, out String sMsg)
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

    public bool ValidaDataDuplication(Rol_de_UsuarioCS.objectBussinessRol_de_Usuario MyDataRol_de_Usuario, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataRol_de_Usuario.Clave != null)
        {
            if (MyDataRol_de_Usuario.ValidaExistencia(MyDataRol_de_Usuario.Clave))
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
