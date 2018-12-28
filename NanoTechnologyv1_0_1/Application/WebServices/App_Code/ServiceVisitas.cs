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
public class objectBussinessVisitas : System.Web.Services.WebService
{
    public int iProcess = 41560;
    private TTTraductor.Traductor MyTraductor;
    


    [WebMethod]
    public string ListaGetFullQuery(string sWhere,string sOrder)
    {
	VisitasCS.objectBussinessVisitas myVisitas = new VisitasCS.objectBussinessVisitas();
        string result = myVisitas.GetFullQuery(sWhere, sOrder);
	myVisitas.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ListaSelAll(int startRowIndex,int maximumRows,string where,string Order)
    {
	VisitasCS.objectBussinessVisitas myVisitas = new VisitasCS.objectBussinessVisitas();
        DataSet result = myVisitas.SelAll(startRowIndex, maximumRows, where, Order);
	myVisitas.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ImpresionSelAll(string where, string Order)
    {
	VisitasCS.objectBussinessVisitas myVisitas = new VisitasCS.objectBussinessVisitas();
        DataSet result = myVisitas.SelAll(where, Order);
	myVisitas.Dispose();
        return result;
    }

    [WebMethod]
    public int ListaSelCount(string where)
    {
	VisitasCS.objectBussinessVisitas myVisitas = new VisitasCS.objectBussinessVisitas();
        int result = myVisitas.SelCount(where);
	myVisitas.Dispose();
        return result;
    }


    [WebMethod]
    public Int32 SelCount()
    {
	VisitasCS.objectBussinessVisitas myVisitas = new VisitasCS.objectBussinessVisitas();
        Int32 result = myVisitas.SelCount();
	myVisitas.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
	VisitasCS.objectBussinessVisitas myVisitas = new VisitasCS.objectBussinessVisitas();
        DataSet result = myVisitas.SelAll(ConRelaciones);
	myVisitas.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, VisitasCS.VisitasFilters[] myFilters)
    {
        VisitasCS.objectBussinessVisitas myVisitas = new VisitasCS.objectBussinessVisitas();
        myVisitas.Filters = myFilters;
        DataSet result = myVisitas.SelAll(ConRelaciones);
        myVisitas.Filters = null;
        myVisitas.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        VisitasCS.objectBussinessVisitas myVisitas = new VisitasCS.objectBussinessVisitas();
        DataSet ds = new DataSet();
        ds.Tables.Add(myVisitas.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        myVisitas.Dispose(); 
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varFolio, DateTime? varFecha_de_visita, String varHora_de_visita, int? varContenidoId, int? varUsuarioId)
    {
        VisitasCS.objectBussinessVisitas  myVisitas = new VisitasCS.objectBussinessVisitas();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myVisitas.Folio = varFolio;
        myVisitas.Fecha_de_visita = varFecha_de_visita;
        myVisitas.Hora_de_visita = varHora_de_visita;
        myVisitas.ContenidoId = varContenidoId;
        myVisitas.UsuarioId = varUsuarioId;

        String sMsg = "";
        if (!ValidaDataToSave(myVisitas, out sMsg))
        {
            myVisitas.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myVisitas, out sMsg))
        {
            myVisitas.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        myVisitas.Insert(globalInfo, dr);
        myVisitas.Dispose();
        dr = null;
        globalInfo = null;
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, int? varFolio, DateTime? varFecha_de_visita, String varHora_de_visita, int? varContenidoId, int? varUsuarioId)
    {
        VisitasCS.objectBussinessVisitas  myVisitas= new VisitasCS.objectBussinessVisitas();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myVisitas.Folio = varFolio;
        myVisitas.Fecha_de_visita = varFecha_de_visita;
        myVisitas.Hora_de_visita = varHora_de_visita;
        myVisitas.ContenidoId = varContenidoId;
        myVisitas.UsuarioId = varUsuarioId;

        String sMsg = "";
        if (!ValidaDataToSave(myVisitas, out sMsg))
        {
            myVisitas.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myVisitas, out sMsg))
        {
            myVisitas.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        object result=myVisitas.InsertWithReturnValue(globalInfo, dr);
        myVisitas.Dispose();
        dr = null;
        globalInfo = null;
        return result;
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varFolio, DateTime? varFecha_de_visita, String varHora_de_visita, int? varContenidoId, int? varUsuarioId)
    {
        VisitasCS.objectBussinessVisitas myVisitas = new VisitasCS.objectBussinessVisitas();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myVisitas.Folio = varFolio;
        myVisitas.Fecha_de_visita = varFecha_de_visita;
        myVisitas.Hora_de_visita = varHora_de_visita;
        myVisitas.ContenidoId = varContenidoId;
        myVisitas.UsuarioId = varUsuarioId;

            String sMsg = "";
            if (!ValidaDataToSave(myVisitas, out sMsg))
            {
                myVisitas.Dispose();
                dr = null;
                globalInfo = null;
                throw new Exception(sMsg);
            }
            myVisitas.Update(globalInfo, dr);
            myVisitas.Dispose();
            dr = null;
            globalInfo = null;
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyFolio)
    {
        VisitasCS.objectBussinessVisitas myVisitas = new VisitasCS.objectBussinessVisitas();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        bool result = myVisitas.Delete(KeyFolio, globalInfo, dr);
        myVisitas.Dispose();
        dr = null;
        return result;
    }

    [WebMethod]
    public VisitasCS.objectBussinessVisitas GetByKey(int? KeyFolio, Boolean ConRelaciones)
    {
        VisitasCS.objectBussinessVisitas myVisitas = new VisitasCS.objectBussinessVisitas();
        myVisitas.GetByKey(KeyFolio, ConRelaciones);;
        return myVisitas;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyFolio)
    {
        VisitasCS.objectBussinessVisitas myVisitas = new VisitasCS.objectBussinessVisitas();
        Int32 result = myVisitas.CurrentPosicion(KeyFolio);
        return result;
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyFolio)
    {
        VisitasCS.objectBussinessVisitas myVisitas = new VisitasCS.objectBussinessVisitas();
        Boolean result = myVisitas.ValidaExistencia(KeyFolio);
        myVisitas.Dispose();
        return result;
    }

    private bool ValidaDataToSave(VisitasCS.objectBussinessVisitas MyDataVisitas, out String sMsg)
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

    public bool ValidaDataDuplication(VisitasCS.objectBussinessVisitas MyDataVisitas, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataVisitas.Folio != null)
        {
            if (MyDataVisitas.ValidaExistencia(MyDataVisitas.Folio))
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
    public DataSet FillDataContenidoId(String sFiltro)
    {
        VisitasCS.objectBussinessVisitas myVisitas = new VisitasCS.objectBussinessVisitas();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myVisitas.FillDataContenidoId().Copy());
        else
            ds.Tables.Add(myVisitas.FillDataContenidoId(sFiltro).Copy());
        myVisitas.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataContenidoIdCDD(string knownCategoryValues, string category)
    {
        VisitasCS.objectBussinessVisitas myVisitas = new VisitasCS.objectBussinessVisitas();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myVisitas.FillDataContenidoId();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Descripcion"].ToString(), dRow["Folio"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myVisitas.Dispose();
        return values.ToArray();
    }    [WebMethod]
    public DataSet FillDataUsuarioId(String sFiltro)
    {
        VisitasCS.objectBussinessVisitas myVisitas = new VisitasCS.objectBussinessVisitas();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myVisitas.FillDataUsuarioId().Copy());
        else
            ds.Tables.Add(myVisitas.FillDataUsuarioId(sFiltro).Copy());
        myVisitas.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataUsuarioIdCDD(string knownCategoryValues, string category)
    {
        VisitasCS.objectBussinessVisitas myVisitas = new VisitasCS.objectBussinessVisitas();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myVisitas.FillDataUsuarioId();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre_Completo"].ToString(), dRow["Folio"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myVisitas.Dispose();
        return values.ToArray();
    }
}
