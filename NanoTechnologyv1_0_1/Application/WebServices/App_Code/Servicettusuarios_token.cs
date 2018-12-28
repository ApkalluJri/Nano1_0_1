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
public class objectBussinessttusuarios_token : System.Web.Services.WebService
{
    public int iProcess = 34793;
    private TTTraductor.Traductor MyTraductor;
    


    [WebMethod]
    public string ListaGetFullQuery(string sWhere,string sOrder)
    {
	ttusuarios_tokenCS.objectBussinessttusuarios_token myttusuarios_token = new ttusuarios_tokenCS.objectBussinessttusuarios_token();
        string result = myttusuarios_token.GetFullQuery(sWhere, sOrder);
	myttusuarios_token.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ListaSelAll(int startRowIndex,int maximumRows,string where,string Order)
    {
	ttusuarios_tokenCS.objectBussinessttusuarios_token myttusuarios_token = new ttusuarios_tokenCS.objectBussinessttusuarios_token();
        DataSet result = myttusuarios_token.SelAll(startRowIndex, maximumRows, where, Order);
	myttusuarios_token.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ImpresionSelAll(string where, string Order)
    {
	ttusuarios_tokenCS.objectBussinessttusuarios_token myttusuarios_token = new ttusuarios_tokenCS.objectBussinessttusuarios_token();
        DataSet result = myttusuarios_token.SelAll(where, Order);
	myttusuarios_token.Dispose();
        return result;
    }

    [WebMethod]
    public int ListaSelCount(string where)
    {
	ttusuarios_tokenCS.objectBussinessttusuarios_token myttusuarios_token = new ttusuarios_tokenCS.objectBussinessttusuarios_token();
        int result = myttusuarios_token.SelCount(where);
	myttusuarios_token.Dispose();
        return result;
    }


    [WebMethod]
    public Int32 SelCount()
    {
	ttusuarios_tokenCS.objectBussinessttusuarios_token myttusuarios_token = new ttusuarios_tokenCS.objectBussinessttusuarios_token();
        Int32 result = myttusuarios_token.SelCount();
	myttusuarios_token.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
	ttusuarios_tokenCS.objectBussinessttusuarios_token myttusuarios_token = new ttusuarios_tokenCS.objectBussinessttusuarios_token();
        DataSet result = myttusuarios_token.SelAll(ConRelaciones);
	myttusuarios_token.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, ttusuarios_tokenCS.ttusuarios_tokenFilters[] myFilters)
    {
        ttusuarios_tokenCS.objectBussinessttusuarios_token myttusuarios_token = new ttusuarios_tokenCS.objectBussinessttusuarios_token();
        myttusuarios_token.Filters = myFilters;
        DataSet result = myttusuarios_token.SelAll(ConRelaciones);
        myttusuarios_token.Filters = null;
        myttusuarios_token.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        ttusuarios_tokenCS.objectBussinessttusuarios_token myttusuarios_token = new ttusuarios_tokenCS.objectBussinessttusuarios_token();
        DataSet ds = new DataSet();
        ds.Tables.Add(myttusuarios_token.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        myttusuarios_token.Dispose(); 
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varUsuario_Token_Campo, int? varId_Usuario, String varToken, String varIdentificador, Boolean varEstado_Logico, int? varTipoDispositivo, int? varId_Usuario_TTUsuarios, int? varId)
    {
        ttusuarios_tokenCS.objectBussinessttusuarios_token  myttusuarios_token = new ttusuarios_tokenCS.objectBussinessttusuarios_token();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myttusuarios_token.Usuario_Token_Campo = varUsuario_Token_Campo;
        myttusuarios_token.Id_Usuario = varId_Usuario;
        myttusuarios_token.Token = varToken;
        myttusuarios_token.Identificador = varIdentificador;
        myttusuarios_token.Estado_Logico = varEstado_Logico;
        myttusuarios_token.TipoDispositivo = varTipoDispositivo;
        myttusuarios_token.Id_Usuario_TTUsuarios = varId_Usuario_TTUsuarios;
        myttusuarios_token.Id = varId;

        String sMsg = "";
        if (!ValidaDataToSave(myttusuarios_token, out sMsg))
        {
            myttusuarios_token.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myttusuarios_token, out sMsg))
        {
            myttusuarios_token.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        myttusuarios_token.Insert(globalInfo, dr);
        myttusuarios_token.Dispose();
        dr = null;
        globalInfo = null;
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, int? varUsuario_Token_Campo, int? varId_Usuario, String varToken, String varIdentificador, Boolean varEstado_Logico, int? varTipoDispositivo, int? varId_Usuario_TTUsuarios, int? varId)
    {
        ttusuarios_tokenCS.objectBussinessttusuarios_token  myttusuarios_token= new ttusuarios_tokenCS.objectBussinessttusuarios_token();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myttusuarios_token.Usuario_Token_Campo = varUsuario_Token_Campo;
        myttusuarios_token.Id_Usuario = varId_Usuario;
        myttusuarios_token.Token = varToken;
        myttusuarios_token.Identificador = varIdentificador;
        myttusuarios_token.Estado_Logico = varEstado_Logico;
        myttusuarios_token.TipoDispositivo = varTipoDispositivo;
        myttusuarios_token.Id_Usuario_TTUsuarios = varId_Usuario_TTUsuarios;
        myttusuarios_token.Id = varId;

        String sMsg = "";
        if (!ValidaDataToSave(myttusuarios_token, out sMsg))
        {
            myttusuarios_token.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myttusuarios_token, out sMsg))
        {
            myttusuarios_token.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        object result=myttusuarios_token.InsertWithReturnValue(globalInfo, dr);
        myttusuarios_token.Dispose();
        dr = null;
        globalInfo = null;
        return result;
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varFolio, int? varUsuario_Token_Campo, int? varId_Usuario, String varToken, String varIdentificador, Boolean varEstado_Logico, int? varTipoDispositivo, int? varId_Usuario_TTUsuarios, int? varId)
    {
        ttusuarios_tokenCS.objectBussinessttusuarios_token myttusuarios_token = new ttusuarios_tokenCS.objectBussinessttusuarios_token();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myttusuarios_token.Folio = varFolio;
        myttusuarios_token.Usuario_Token_Campo = varUsuario_Token_Campo;
        myttusuarios_token.Id_Usuario = varId_Usuario;
        myttusuarios_token.Token = varToken;
        myttusuarios_token.Identificador = varIdentificador;
        myttusuarios_token.Estado_Logico = varEstado_Logico;
        myttusuarios_token.TipoDispositivo = varTipoDispositivo;
        myttusuarios_token.Id_Usuario_TTUsuarios = varId_Usuario_TTUsuarios;
        myttusuarios_token.Id = varId;

            String sMsg = "";
            if (!ValidaDataToSave(myttusuarios_token, out sMsg))
            {
                myttusuarios_token.Dispose();
                dr = null;
                globalInfo = null;
                throw new Exception(sMsg);
            }
            myttusuarios_token.Update(globalInfo, dr);
            myttusuarios_token.Dispose();
            dr = null;
            globalInfo = null;
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyFolio)
    {
        ttusuarios_tokenCS.objectBussinessttusuarios_token myttusuarios_token = new ttusuarios_tokenCS.objectBussinessttusuarios_token();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        bool result = myttusuarios_token.Delete(KeyFolio, globalInfo, dr);
        myttusuarios_token.Dispose();
        dr = null;
        return result;
    }

    [WebMethod]
    public ttusuarios_tokenCS.objectBussinessttusuarios_token GetByKey(int? KeyFolio, Boolean ConRelaciones)
    {
        ttusuarios_tokenCS.objectBussinessttusuarios_token myttusuarios_token = new ttusuarios_tokenCS.objectBussinessttusuarios_token();
        myttusuarios_token.GetByKey(KeyFolio, ConRelaciones);;
        return myttusuarios_token;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyFolio)
    {
        ttusuarios_tokenCS.objectBussinessttusuarios_token myttusuarios_token = new ttusuarios_tokenCS.objectBussinessttusuarios_token();
        Int32 result = myttusuarios_token.CurrentPosicion(KeyFolio);
        return result;
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyFolio)
    {
        ttusuarios_tokenCS.objectBussinessttusuarios_token myttusuarios_token = new ttusuarios_tokenCS.objectBussinessttusuarios_token();
        Boolean result = myttusuarios_token.ValidaExistencia(KeyFolio);
        myttusuarios_token.Dispose();
        return result;
    }

    private bool ValidaDataToSave(ttusuarios_tokenCS.objectBussinessttusuarios_token MyDatattusuarios_token, out String sMsg)
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

    public bool ValidaDataDuplication(ttusuarios_tokenCS.objectBussinessttusuarios_token MyDatattusuarios_token, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDatattusuarios_token.Folio == -1)
        {
            if (MyDatattusuarios_token.ValidaExistencia(MyDatattusuarios_token.Folio))
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
    public DataSet FillDataId_Usuario_TTUsuarios(String sFiltro)
    {
        ttusuarios_tokenCS.objectBussinessttusuarios_token myttusuarios_token = new ttusuarios_tokenCS.objectBussinessttusuarios_token();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myttusuarios_token.FillDataId_Usuario_TTUsuarios().Copy());
        else
            ds.Tables.Add(myttusuarios_token.FillDataId_Usuario_TTUsuarios(sFiltro).Copy());
        myttusuarios_token.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataId_Usuario_TTUsuariosCDD(string knownCategoryValues, string category)
    {
        ttusuarios_tokenCS.objectBussinessttusuarios_token myttusuarios_token = new ttusuarios_tokenCS.objectBussinessttusuarios_token();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myttusuarios_token.FillDataId_Usuario_TTUsuarios();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["IdUsuario"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myttusuarios_token.Dispose();
        return values.ToArray();
    }
}
