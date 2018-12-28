using System;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Services.Protocols;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class objectBussinessTTMetadata : System.Web.Services.WebService
{
    public int iProcess = 6386;
    private TTTraductor.Traductor MyTraductor;
    public TTMetadataCS.objectBussinessTTMetadata myTTMetadata = new TTMetadataCS.objectBussinessTTMetadata();

    [WebMethod]
    public Int32 SelCount()
    {
        return myTTMetadata.SelCount();
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
        return myTTMetadata.SelAll(ConRelaciones);
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, TTMetadataCS.TTMetadataFilters[] myFilters)
    {
        myTTMetadata.Filters = myFilters;
        return myTTMetadata.SelAll(ConRelaciones);
        myTTMetadata.Filters = null;
    }
    [WebMethod]
    public DataTable SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        return myTTMetadata.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32);
    }
    [WebMethod]
    public void Insert(int? varDTID, int? varDNTID, int? varProcesoId, String varNombre, String varDescripcion, int? varTipo_de_Dato, int? varLongitud, int? varDecimal, int? varRenglones, Boolean varIdentificador, Boolean varSecuencial, Boolean varObligatorio, String varValor_por_defecto, Boolean varVisible, String varTexto_Ayuda, Boolean varDependiente, int? varDependienteTabla, int? varDependienteClave, int? varDependienteDescripcion, Boolean varSolo_Lectura, int? varOrden, int? varCarpeta, int? varColumna, Boolean varTotal, Boolean varFiltro, int? varTipo_de_Control)
    {
        TTMetadataCS.objectBussinessTTMetadata  myTTMetadata= new TTMetadataCS.objectBussinessTTMetadata();
        TTSecurity.GlobalData gb = new TTSecurity.GlobalData();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("",0);
        gb.UserID = 1;
        gb.ComputerName = "gg";
        gb.ServidorName = "gg";
        gb.DatabaseName = "rr";
        gb.WindowsVersion = "jk";
        gb.Language = TTSecurity.GlobalDataLanguages.Default;
        MyTraductor= new TTTraductor.Traductor(gb.Language.GetHashCode());
        myTTMetadata.DTID = varDTID;
        myTTMetadata.DNTID = varDNTID;
        myTTMetadata.ProcesoId = varProcesoId;
        myTTMetadata.Nombre = varNombre;
        myTTMetadata.Descripcion = varDescripcion;
        myTTMetadata.Tipo_de_Dato = varTipo_de_Dato;
        myTTMetadata.Longitud = varLongitud;
        myTTMetadata.Decimal = varDecimal;
        myTTMetadata.Renglones = varRenglones;
        myTTMetadata.Identificador = varIdentificador;
        myTTMetadata.Secuencial = varSecuencial;
        myTTMetadata.Obligatorio = varObligatorio;
        myTTMetadata.Valor_por_defecto = varValor_por_defecto;
        myTTMetadata.Visible = varVisible;
        myTTMetadata.Texto_Ayuda = varTexto_Ayuda;
        myTTMetadata.Dependiente = varDependiente;
        myTTMetadata.DependienteTabla = varDependienteTabla;
        myTTMetadata.DependienteClave = varDependienteClave;
        myTTMetadata.DependienteDescripcion = varDependienteDescripcion;
        myTTMetadata.Solo_Lectura = varSolo_Lectura;
        myTTMetadata.Orden = varOrden;
        myTTMetadata.Carpeta = varCarpeta;
        myTTMetadata.Columna = varColumna;
        myTTMetadata.Total = varTotal;
        myTTMetadata.Filtro = varFiltro;
        myTTMetadata.Tipo_de_Control = varTipo_de_Control;

        String sMsg = "";
        if (!ValidaDataToSave(myTTMetadata, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTMetadata, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTMetadata.Insert(gb, dr);
    }
    [WebMethod]
    public void Update(int? varDTID, int? varDNTID, int? varProcesoId, String varNombre, String varDescripcion, int? varTipo_de_Dato, int? varLongitud, int? varDecimal, int? varRenglones, Boolean varIdentificador, Boolean varSecuencial, Boolean varObligatorio, String varValor_por_defecto, Boolean varVisible, String varTexto_Ayuda, Boolean varDependiente, int? varDependienteTabla, int? varDependienteClave, int? varDependienteDescripcion, Boolean varSolo_Lectura, int? varOrden, int? varCarpeta, int? varColumna, Boolean varTotal, Boolean varFiltro, int? varTipo_de_Control)
    {
        TTSecurity.GlobalData gb = new TTSecurity.GlobalData();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        gb.UserID = 1;
        gb.ComputerName = "gg";
        gb.ServidorName = "gg";
        gb.DatabaseName = "rr";
        gb.WindowsVersion = "jk";
        myTTMetadata.DTID = varDTID;
        myTTMetadata.DNTID = varDNTID;
        myTTMetadata.ProcesoId = varProcesoId;
        myTTMetadata.Nombre = varNombre;
        myTTMetadata.Descripcion = varDescripcion;
        myTTMetadata.Tipo_de_Dato = varTipo_de_Dato;
        myTTMetadata.Longitud = varLongitud;
        myTTMetadata.Decimal = varDecimal;
        myTTMetadata.Renglones = varRenglones;
        myTTMetadata.Identificador = varIdentificador;
        myTTMetadata.Secuencial = varSecuencial;
        myTTMetadata.Obligatorio = varObligatorio;
        myTTMetadata.Valor_por_defecto = varValor_por_defecto;
        myTTMetadata.Visible = varVisible;
        myTTMetadata.Texto_Ayuda = varTexto_Ayuda;
        myTTMetadata.Dependiente = varDependiente;
        myTTMetadata.DependienteTabla = varDependienteTabla;
        myTTMetadata.DependienteClave = varDependienteClave;
        myTTMetadata.DependienteDescripcion = varDependienteDescripcion;
        myTTMetadata.Solo_Lectura = varSolo_Lectura;
        myTTMetadata.Orden = varOrden;
        myTTMetadata.Carpeta = varCarpeta;
        myTTMetadata.Columna = varColumna;
        myTTMetadata.Total = varTotal;
        myTTMetadata.Filtro = varFiltro;
        myTTMetadata.Tipo_de_Control = varTipo_de_Control;

        String sMsg = "";
        if (!ValidaDataToSave(myTTMetadata, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTMetadata.Update(gb, dr);
    }
    [WebMethod]
    public bool Delete(int? KeyDTID)
    {
        TTSecurity.GlobalData gb = new TTSecurity.GlobalData();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        gb.UserID = 1;
        gb.ComputerName = "gg";
        gb.ServidorName = "gg";
        gb.DatabaseName = "rr";
        gb.WindowsVersion = "jk";
        return myTTMetadata.Delete(KeyDTID, gb, dr);
    }

    [WebMethod]
    public DataSet GetByKey(int? KeyDTID, Boolean ConRelaciones)
    {
        return myTTMetadata.GetByKey(KeyDTID, ConRelaciones);
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyDTID)
    {
        return myTTMetadata.CurrentPosicion(KeyDTID);
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyDTID)
    {
        return myTTMetadata.ValidaExistencia(KeyDTID);
    }

    private bool ValidaDataToSave(TTMetadataCS.objectBussinessTTMetadata MyDataTTMetadata, out String sMsg)
    {
        //Validaciones
        sMsg = "";
            if (MyDataTTMetadata.DNTID != null)
            {
                TTDNTCS.objectBussinessTTDNT MyDataTTDNTTemp = new TTDNTCS.objectBussinessTTDNT();
                if (!MyDataTTDNTTemp.ValidaExistencia(MyDataTTMetadata.DNTID))
                {
                    sMsg = sMsg + "El Campo DNTID no existe\n";
                }
            }
            if (MyDataTTMetadata.ProcesoId != null)
            {
                TTProcesoCS.objectBussinessTTProceso MyDataTTProcesoTemp = new TTProcesoCS.objectBussinessTTProceso();
                if (!MyDataTTProcesoTemp.ValidaExistencia(MyDataTTMetadata.ProcesoId))
                {
                    sMsg = sMsg + "El Campo ProcesoId no existe\n";
                }
            }
            if (MyDataTTMetadata.DependienteTabla != null)
            {
                TTDNTCS.objectBussinessTTDNT MyDataTTDNTTemp = new TTDNTCS.objectBussinessTTDNT();
                if (!MyDataTTDNTTemp.ValidaExistencia(MyDataTTMetadata.DependienteTabla))
                {
                    sMsg = sMsg + "El Campo DependienteTabla no existe\n";
                }
            }
            if (MyDataTTMetadata.DependienteClave != null)
            {
                TTMetadataCS.objectBussinessTTMetadata MyDataTTMetadataTemp = new TTMetadataCS.objectBussinessTTMetadata();
                if (!MyDataTTMetadataTemp.ValidaExistencia(MyDataTTMetadata.DependienteClave))
                {
                    sMsg = sMsg + "El Campo DependienteClave no existe\n";
                }
            }
            if (MyDataTTMetadata.DependienteDescripcion != null)
            {
                TTMetadataCS.objectBussinessTTMetadata MyDataTTMetadataTemp = new TTMetadataCS.objectBussinessTTMetadata();
                if (!MyDataTTMetadataTemp.ValidaExistencia(MyDataTTMetadata.DependienteDescripcion))
                {
                    sMsg = sMsg + "El Campo DependienteDescripcion no existe\n";
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

    public bool ValidaDataDuplication(TTMetadataCS.objectBussinessTTMetadata MyDataTTMetadata, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTTMetadata.DTID != null)
        {
            if (MyDataTTMetadata.ValidaExistencia(MyDataTTMetadata.DTID))
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
