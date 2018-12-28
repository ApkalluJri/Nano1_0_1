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
public class objectBussinessCodigos_por_Cliente : System.Web.Services.WebService
{
    public int iProcess = 30071;
    private TTTraductor.Traductor MyTraductor;
    


    [WebMethod]
    public string ListaGetFullQuery(string sWhere,string sOrder)
    {
	Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente myCodigos_por_Cliente = new Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente();
        string result = myCodigos_por_Cliente.GetFullQuery(sWhere, sOrder);
	myCodigos_por_Cliente.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ListaSelAll(int startRowIndex,int maximumRows,string where,string Order)
    {
	Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente myCodigos_por_Cliente = new Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente();
        DataSet result = myCodigos_por_Cliente.SelAll(startRowIndex, maximumRows, where, Order);
	myCodigos_por_Cliente.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ImpresionSelAll(string where, string Order)
    {
	Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente myCodigos_por_Cliente = new Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente();
        DataSet result = myCodigos_por_Cliente.SelAll(where, Order);
	myCodigos_por_Cliente.Dispose();
        return result;
    }

    [WebMethod]
    public int ListaSelCount(string where)
    {
	Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente myCodigos_por_Cliente = new Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente();
        int result = myCodigos_por_Cliente.SelCount(where);
	myCodigos_por_Cliente.Dispose();
        return result;
    }


    [WebMethod]
    public Int32 SelCount()
    {
	Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente myCodigos_por_Cliente = new Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente();
        Int32 result = myCodigos_por_Cliente.SelCount();
	myCodigos_por_Cliente.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
	Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente myCodigos_por_Cliente = new Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente();
        DataSet result = myCodigos_por_Cliente.SelAll(ConRelaciones);
	myCodigos_por_Cliente.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, Codigos_por_ClienteCS.Codigos_por_ClienteFilters[] myFilters)
    {
        Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente myCodigos_por_Cliente = new Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente();
        myCodigos_por_Cliente.Filters = myFilters;
        DataSet result = myCodigos_por_Cliente.SelAll(ConRelaciones);
        myCodigos_por_Cliente.Filters = null;
        myCodigos_por_Cliente.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente myCodigos_por_Cliente = new Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente();
        DataSet ds = new DataSet();
        ds.Tables.Add(myCodigos_por_Cliente.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        myCodigos_por_Cliente.Dispose(); 
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varUsuario_que_Registra, DateTime? varFecha_de_Registro, String varHora_de_Registro, String varCliente, String varContacto, String varCorreo, int?[] varDetalle_de_CodigosObservatorio, String[] varDetalle_de_CodigosCodigo, int?[] varDetalle_de_CodigosEstatus, DateTime?[] varDetalle_de_CodigosExpiracion, int?[] varDetalle_de_CodigosAccesos)
    {
        Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente  myCodigos_por_Cliente = new Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myCodigos_por_Cliente.Usuario_que_Registra = varUsuario_que_Registra;
        myCodigos_por_Cliente.Fecha_de_Registro = varFecha_de_Registro;
        myCodigos_por_Cliente.Hora_de_Registro = varHora_de_Registro;
        myCodigos_por_Cliente.Cliente = varCliente;
        myCodigos_por_Cliente.Contacto = varContacto;
        myCodigos_por_Cliente.Correo = varCorreo;
            if(varDetalle_de_CodigosCodigo != null)
            {
                myCodigos_por_Cliente.Detalle_de_Codigos = new Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente[varDetalle_de_CodigosCodigo.Length];
                for (int i = 0; i < varDetalle_de_CodigosCodigo.Length; i++)
                {
                    myCodigos_por_Cliente.Detalle_de_Codigos[i] = new Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente();
                myCodigos_por_Cliente.Detalle_de_Codigos[i].Observatorio = varDetalle_de_CodigosObservatorio[i];
                myCodigos_por_Cliente.Detalle_de_Codigos[i].Codigo = varDetalle_de_CodigosCodigo[i];
                myCodigos_por_Cliente.Detalle_de_Codigos[i].Estatus = varDetalle_de_CodigosEstatus[i];
                myCodigos_por_Cliente.Detalle_de_Codigos[i].Expiracion = varDetalle_de_CodigosExpiracion[i];
                myCodigos_por_Cliente.Detalle_de_Codigos[i].Accesos = varDetalle_de_CodigosAccesos[i];

                }
            }

        String sMsg = "";
        if (!ValidaDataToSave(myCodigos_por_Cliente, out sMsg))
        {
            myCodigos_por_Cliente.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myCodigos_por_Cliente, out sMsg))
        {
            myCodigos_por_Cliente.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        myCodigos_por_Cliente.Insert(globalInfo, dr);
        myCodigos_por_Cliente.Dispose();
        dr = null;
        globalInfo = null;
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, int? varUsuario_que_Registra, DateTime? varFecha_de_Registro, String varHora_de_Registro, String varCliente, String varContacto, String varCorreo, int?[] varDetalle_de_CodigosObservatorio, String[] varDetalle_de_CodigosCodigo, int?[] varDetalle_de_CodigosEstatus, DateTime?[] varDetalle_de_CodigosExpiracion, int?[] varDetalle_de_CodigosAccesos)
    {
        Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente  myCodigos_por_Cliente= new Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myCodigos_por_Cliente.Usuario_que_Registra = varUsuario_que_Registra;
        myCodigos_por_Cliente.Fecha_de_Registro = varFecha_de_Registro;
        myCodigos_por_Cliente.Hora_de_Registro = varHora_de_Registro;
        myCodigos_por_Cliente.Cliente = varCliente;
        myCodigos_por_Cliente.Contacto = varContacto;
        myCodigos_por_Cliente.Correo = varCorreo;
            if(varDetalle_de_CodigosCodigo != null)
            {
                myCodigos_por_Cliente.Detalle_de_Codigos = new Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente[varDetalle_de_CodigosCodigo.Length];
                for (int i = 0; i < varDetalle_de_CodigosCodigo.Length; i++)
                {
                    myCodigos_por_Cliente.Detalle_de_Codigos[i] = new Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente();
                myCodigos_por_Cliente.Detalle_de_Codigos[i].Observatorio = varDetalle_de_CodigosObservatorio[i];
                myCodigos_por_Cliente.Detalle_de_Codigos[i].Codigo = varDetalle_de_CodigosCodigo[i];
                myCodigos_por_Cliente.Detalle_de_Codigos[i].Estatus = varDetalle_de_CodigosEstatus[i];
                myCodigos_por_Cliente.Detalle_de_Codigos[i].Expiracion = varDetalle_de_CodigosExpiracion[i];
                myCodigos_por_Cliente.Detalle_de_Codigos[i].Accesos = varDetalle_de_CodigosAccesos[i];

                }
            }

        String sMsg = "";
        if (!ValidaDataToSave(myCodigos_por_Cliente, out sMsg))
        {
            myCodigos_por_Cliente.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myCodigos_por_Cliente, out sMsg))
        {
            myCodigos_por_Cliente.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        object result=myCodigos_por_Cliente.InsertWithReturnValue(globalInfo, dr);
        myCodigos_por_Cliente.Dispose();
        dr = null;
        globalInfo = null;
        return result;
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varFolio, int? varUsuario_que_Registra, DateTime? varFecha_de_Registro, String varHora_de_Registro, String varCliente, String varContacto, String varCorreo, int?[] varDetalle_de_CodigosClave, int?[] varDetalle_de_CodigosCliente, int?[] varDetalle_de_CodigosObservatorio, String[] varDetalle_de_CodigosCodigo, int?[] varDetalle_de_CodigosEstatus, DateTime?[] varDetalle_de_CodigosExpiracion, int?[] varDetalle_de_CodigosAccesos)
    {
        Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente myCodigos_por_Cliente = new Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myCodigos_por_Cliente.Folio = varFolio;
        myCodigos_por_Cliente.Usuario_que_Registra = varUsuario_que_Registra;
        myCodigos_por_Cliente.Fecha_de_Registro = varFecha_de_Registro;
        myCodigos_por_Cliente.Hora_de_Registro = varHora_de_Registro;
        myCodigos_por_Cliente.Cliente = varCliente;
        myCodigos_por_Cliente.Contacto = varContacto;
        myCodigos_por_Cliente.Correo = varCorreo;
            if(varDetalle_de_CodigosObservatorio != null)
            {
                myCodigos_por_Cliente.Detalle_de_Codigos = new Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente[varDetalle_de_CodigosObservatorio.Length];
                for (int i = 0; i < varDetalle_de_CodigosObservatorio.Length; i++)
                {
                    myCodigos_por_Cliente.Detalle_de_Codigos[i] = new Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente();
                myCodigos_por_Cliente.Detalle_de_Codigos[i].Clave = varDetalle_de_CodigosClave[i];
                myCodigos_por_Cliente.Detalle_de_Codigos[i].Cliente = varDetalle_de_CodigosCliente[i];
                myCodigos_por_Cliente.Detalle_de_Codigos[i].Observatorio = varDetalle_de_CodigosObservatorio[i];
                myCodigos_por_Cliente.Detalle_de_Codigos[i].Codigo = varDetalle_de_CodigosCodigo[i];
                myCodigos_por_Cliente.Detalle_de_Codigos[i].Estatus = varDetalle_de_CodigosEstatus[i];
                myCodigos_por_Cliente.Detalle_de_Codigos[i].Expiracion = varDetalle_de_CodigosExpiracion[i];
                myCodigos_por_Cliente.Detalle_de_Codigos[i].Accesos = varDetalle_de_CodigosAccesos[i];

                }
            }

            String sMsg = "";
            if (!ValidaDataToSave(myCodigos_por_Cliente, out sMsg))
            {
                myCodigos_por_Cliente.Dispose();
                dr = null;
                globalInfo = null;
                throw new Exception(sMsg);
            }
            myCodigos_por_Cliente.Update(globalInfo, dr);
            myCodigos_por_Cliente.Dispose();
            dr = null;
            globalInfo = null;
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyFolio)
    {
        Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente myCodigos_por_Cliente = new Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        bool result = myCodigos_por_Cliente.Delete(KeyFolio, globalInfo, dr);
        myCodigos_por_Cliente.Dispose();
        dr = null;
        return result;
    }

    [WebMethod]
    public Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente GetByKey(int? KeyFolio, Boolean ConRelaciones)
    {
        Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente myCodigos_por_Cliente = new Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente();
        myCodigos_por_Cliente.GetByKey(KeyFolio, ConRelaciones);;
        return myCodigos_por_Cliente;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyFolio)
    {
        Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente myCodigos_por_Cliente = new Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente();
        Int32 result = myCodigos_por_Cliente.CurrentPosicion(KeyFolio);
        return result;
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyFolio)
    {
        Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente myCodigos_por_Cliente = new Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente();
        Boolean result = myCodigos_por_Cliente.ValidaExistencia(KeyFolio);
        myCodigos_por_Cliente.Dispose();
        return result;
    }

    private bool ValidaDataToSave(Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente MyDataCodigos_por_Cliente, out String sMsg)
    {
        //Validaciones
        sMsg = "";
            if(MyDataCodigos_por_Cliente.Detalle_de_Codigos != null)
            {
                for (int i = 0; i < MyDataCodigos_por_Cliente.Detalle_de_Codigos.Length; i++)
                {
                    if (MyDataCodigos_por_Cliente.Detalle_de_Codigos[i].Observatorio != null)
                    {
                        ObservatorioCS.objectBussinessObservatorio MyDataObservatorioTemp = new ObservatorioCS.objectBussinessObservatorio();
                        if (!MyDataObservatorioTemp.ValidaExistencia(MyDataCodigos_por_Cliente.Detalle_de_Codigos[i].Observatorio))
                        {
                            sMsg = sMsg + "El Campo Observatorio no existe\n";
                        }
                    }
                }
            }
            if(MyDataCodigos_por_Cliente.Detalle_de_Codigos != null)
            {
                for (int i = 0; i < MyDataCodigos_por_Cliente.Detalle_de_Codigos.Length; i++)
                {
                    if (MyDataCodigos_por_Cliente.Detalle_de_Codigos[i].Estatus != null)
                    {
                        Estatus_CodigoCS.objectBussinessEstatus_Codigo MyDataEstatus_CodigoTemp = new Estatus_CodigoCS.objectBussinessEstatus_Codigo();
                        if (!MyDataEstatus_CodigoTemp.ValidaExistencia(MyDataCodigos_por_Cliente.Detalle_de_Codigos[i].Estatus))
                        {
                            sMsg = sMsg + "El Campo Estatus no existe\n";
                        }
                    }
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

    public bool ValidaDataDuplication(Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente MyDataCodigos_por_Cliente, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataCodigos_por_Cliente.Folio == -1)
        {
            if (MyDataCodigos_por_Cliente.ValidaExistencia(MyDataCodigos_por_Cliente.Folio))
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
    public DataSet FillDataUsuario_que_Registra(String sFiltro)
    {
        Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente myCodigos_por_Cliente = new Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myCodigos_por_Cliente.FillDataUsuario_que_Registra().Copy());
        else
            ds.Tables.Add(myCodigos_por_Cliente.FillDataUsuario_que_Registra(sFiltro).Copy());
        myCodigos_por_Cliente.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataUsuario_que_RegistraCDD(string knownCategoryValues, string category)
    {
        Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente myCodigos_por_Cliente = new Codigos_por_ClienteCS.objectBussinessCodigos_por_Cliente();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myCodigos_por_Cliente.FillDataUsuario_que_Registra();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["IdUsuario"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myCodigos_por_Cliente.Dispose();
        return values.ToArray();
    }
}
