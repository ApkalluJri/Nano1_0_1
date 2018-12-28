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
public class objectBussinessRegistro_de_Contenido : System.Web.Services.WebService
{
    public int iProcess = 29982;
    private TTTraductor.Traductor MyTraductor;
    


    [WebMethod]
    public string ListaGetFullQuery(string sWhere,string sOrder)
    {
	Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        string result = myRegistro_de_Contenido.GetFullQuery(sWhere, sOrder);
	myRegistro_de_Contenido.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ListaSelAll(int startRowIndex,int maximumRows,string where,string Order)
    {
	Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        DataSet result = myRegistro_de_Contenido.SelAll(startRowIndex, maximumRows, where, Order);
	myRegistro_de_Contenido.Dispose();
        return result;
    }

    [WebMethod]
    public DataSet ImpresionSelAll(string where, string Order)
    {
	Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        DataSet result = myRegistro_de_Contenido.SelAll(where, Order);
	myRegistro_de_Contenido.Dispose();
        return result;
    }

    [WebMethod]
    public int ListaSelCount(string where)
    {
	Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        int result = myRegistro_de_Contenido.SelCount(where);
	myRegistro_de_Contenido.Dispose();
        return result;
    }


    [WebMethod]
    public Int32 SelCount()
    {
	Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        Int32 result = myRegistro_de_Contenido.SelCount();
	myRegistro_de_Contenido.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
	Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        DataSet result = myRegistro_de_Contenido.SelAll(ConRelaciones);
	myRegistro_de_Contenido.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, Registro_de_ContenidoCS.Registro_de_ContenidoFilters[] myFilters)
    {
        Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        myRegistro_de_Contenido.Filters = myFilters;
        DataSet result = myRegistro_de_Contenido.SelAll(ConRelaciones);
        myRegistro_de_Contenido.Filters = null;
        myRegistro_de_Contenido.Dispose();
        return result;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        DataSet ds = new DataSet();
        ds.Tables.Add(myRegistro_de_Contenido.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        myRegistro_de_Contenido.Dispose(); 
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, int? varUsuario_que_Registra, DateTime? varFecha_de_Registro, String varHora_de_Registro, int?[] varObservatorio, int? varCategoria, String varDescripcion_de_Solicitud, int? varReportero_Asignado, DateTime? varFecha_de_Compromiso, int? varEstatus, int? varAdministrador_de_Observatorio, int? varReportero, String varTitulo, String varDescripcion, String varContenido, int? varImagen, int? varImagen_Miniatura, int? varEstilo, int?[] varEtiquetasEtiqueta, String[] varFuentesFuente, int? varAdjuntar_PDF, Boolean varCaptura_Terminada, int? varAutorizado_por, DateTime? varFecha_de_Revision, String varHora_de_Revision, int? varAutorizacion, String varMotivo_de_Rechazo, DateTime? varFecha_de_Inicio_de_Publicacion, DateTime? varFecha_de_Termino, Boolean varSeleccionar_Todos_los_Observatorios, Boolean[] varNotificaciones_por_ObservatoriosNotificar, int?[] varNotificaciones_por_ObservatoriosObservatorio, int? varFiltrar_Usuarios_por_Observatorio, Boolean[] varNotificaciones_por_UsuarioNotificar, int?[] varNotificaciones_por_UsuarioObservatorio, int?[] varNotificaciones_por_UsuarioID_del_Cliente, String[] varNotificaciones_por_UsuarioNombre)
    {
        Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido  myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myRegistro_de_Contenido.Usuario_que_Registra = varUsuario_que_Registra;
        myRegistro_de_Contenido.Fecha_de_Registro = varFecha_de_Registro;
        myRegistro_de_Contenido.Hora_de_Registro = varHora_de_Registro;
        myRegistro_de_Contenido.Observatorio =  new MS_ObservatoriosCS.objectBussinessMS_Observatorios[varObservatorio.Length];
        for(int i = 0;i< varObservatorio.Length ;i++)
        {
            myRegistro_de_Contenido.Observatorio[i] = new MS_ObservatoriosCS.objectBussinessMS_Observatorios();
            myRegistro_de_Contenido.Observatorio[i].Observatorio = varObservatorio[i];
        }
        myRegistro_de_Contenido.Categoria = varCategoria;
        myRegistro_de_Contenido.Descripcion_de_Solicitud = varDescripcion_de_Solicitud;
        myRegistro_de_Contenido.Reportero_Asignado = varReportero_Asignado;
        myRegistro_de_Contenido.Fecha_de_Compromiso = varFecha_de_Compromiso;
        myRegistro_de_Contenido.Estatus = varEstatus;
        myRegistro_de_Contenido.Administrador_de_Observatorio = varAdministrador_de_Observatorio;
        myRegistro_de_Contenido.Reportero = varReportero;
        myRegistro_de_Contenido.Titulo = varTitulo;
        myRegistro_de_Contenido.Descripcion = varDescripcion;
        myRegistro_de_Contenido.Contenido = varContenido;
        myRegistro_de_Contenido.Imagen = varImagen;
        myRegistro_de_Contenido.Imagen_Miniatura = varImagen_Miniatura;
        myRegistro_de_Contenido.Estilo = varEstilo;
            if(varEtiquetasEtiqueta != null)
            {
                myRegistro_de_Contenido.Etiquetas = new Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas[varEtiquetasEtiqueta.Length];
                for (int i = 0; i < varEtiquetasEtiqueta.Length; i++)
                {
                    myRegistro_de_Contenido.Etiquetas[i] = new Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas();
                myRegistro_de_Contenido.Etiquetas[i].Etiqueta = varEtiquetasEtiqueta[i];

                }
            }
            if(varFuentesFuente != null)
            {
                myRegistro_de_Contenido.Fuentes = new FuentesCS.objectBussinessFuentes[varFuentesFuente.Length];
                for (int i = 0; i < varFuentesFuente.Length; i++)
                {
                    myRegistro_de_Contenido.Fuentes[i] = new FuentesCS.objectBussinessFuentes();
                myRegistro_de_Contenido.Fuentes[i].Fuente = varFuentesFuente[i];

                }
            }
        myRegistro_de_Contenido.Adjuntar_PDF = varAdjuntar_PDF;
        myRegistro_de_Contenido.Captura_Terminada = varCaptura_Terminada;
        myRegistro_de_Contenido.Autorizado_por = varAutorizado_por;
        myRegistro_de_Contenido.Fecha_de_Revision = varFecha_de_Revision;
        myRegistro_de_Contenido.Hora_de_Revision = varHora_de_Revision;
        myRegistro_de_Contenido.Autorizacion = varAutorizacion;
        myRegistro_de_Contenido.Motivo_de_Rechazo = varMotivo_de_Rechazo;
        myRegistro_de_Contenido.Fecha_de_Inicio_de_Publicacion = varFecha_de_Inicio_de_Publicacion;
        myRegistro_de_Contenido.Fecha_de_Termino = varFecha_de_Termino;
        myRegistro_de_Contenido.Seleccionar_Todos_los_Observatorios = varSeleccionar_Todos_los_Observatorios;
            if(varNotificaciones_por_ObservatoriosNotificar != null)
            {
                myRegistro_de_Contenido.Notificaciones_por_Observatorios = new Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio[varNotificaciones_por_ObservatoriosNotificar.Length];
                for (int i = 0; i < varNotificaciones_por_ObservatoriosNotificar.Length; i++)
                {
                    myRegistro_de_Contenido.Notificaciones_por_Observatorios[i] = new Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio();
                myRegistro_de_Contenido.Notificaciones_por_Observatorios[i].Notificar = varNotificaciones_por_ObservatoriosNotificar[i];
                myRegistro_de_Contenido.Notificaciones_por_Observatorios[i].Observatorio = varNotificaciones_por_ObservatoriosObservatorio[i];

                }
            }
        myRegistro_de_Contenido.Filtrar_Usuarios_por_Observatorio = varFiltrar_Usuarios_por_Observatorio;
            if(varNotificaciones_por_UsuarioNotificar != null)
            {
                myRegistro_de_Contenido.Notificaciones_por_Usuario = new Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario[varNotificaciones_por_UsuarioNotificar.Length];
                for (int i = 0; i < varNotificaciones_por_UsuarioNotificar.Length; i++)
                {
                    myRegistro_de_Contenido.Notificaciones_por_Usuario[i] = new Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario();
                myRegistro_de_Contenido.Notificaciones_por_Usuario[i].Notificar = varNotificaciones_por_UsuarioNotificar[i];
                myRegistro_de_Contenido.Notificaciones_por_Usuario[i].Observatorio = varNotificaciones_por_UsuarioObservatorio[i];
                myRegistro_de_Contenido.Notificaciones_por_Usuario[i].ID_del_Cliente = varNotificaciones_por_UsuarioID_del_Cliente[i];
                myRegistro_de_Contenido.Notificaciones_por_Usuario[i].Nombre = varNotificaciones_por_UsuarioNombre[i];

                }
            }

        String sMsg = "";
        if (!ValidaDataToSave(myRegistro_de_Contenido, out sMsg))
        {
            myRegistro_de_Contenido.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myRegistro_de_Contenido, out sMsg))
        {
            myRegistro_de_Contenido.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        myRegistro_de_Contenido.Insert(globalInfo, dr);
        myRegistro_de_Contenido.Dispose();
        dr = null;
        globalInfo = null;
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, int? varUsuario_que_Registra, DateTime? varFecha_de_Registro, String varHora_de_Registro, int?[] varObservatorio, int? varCategoria, String varDescripcion_de_Solicitud, int? varReportero_Asignado, DateTime? varFecha_de_Compromiso, int? varEstatus, int? varAdministrador_de_Observatorio, int? varReportero, String varTitulo, String varDescripcion, String varContenido, int? varImagen, int? varImagen_Miniatura, int? varEstilo, int?[] varEtiquetasEtiqueta, String[] varFuentesFuente, int? varAdjuntar_PDF, Boolean varCaptura_Terminada, int? varAutorizado_por, DateTime? varFecha_de_Revision, String varHora_de_Revision, int? varAutorizacion, String varMotivo_de_Rechazo, DateTime? varFecha_de_Inicio_de_Publicacion, DateTime? varFecha_de_Termino, Boolean varSeleccionar_Todos_los_Observatorios, Boolean[] varNotificaciones_por_ObservatoriosNotificar, int?[] varNotificaciones_por_ObservatoriosObservatorio, int? varFiltrar_Usuarios_por_Observatorio, Boolean[] varNotificaciones_por_UsuarioNotificar, int?[] varNotificaciones_por_UsuarioObservatorio, int?[] varNotificaciones_por_UsuarioID_del_Cliente, String[] varNotificaciones_por_UsuarioNombre)
    {
        Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido  myRegistro_de_Contenido= new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myRegistro_de_Contenido.Usuario_que_Registra = varUsuario_que_Registra;
        myRegistro_de_Contenido.Fecha_de_Registro = varFecha_de_Registro;
        myRegistro_de_Contenido.Hora_de_Registro = varHora_de_Registro;
        myRegistro_de_Contenido.Observatorio =  new MS_ObservatoriosCS.objectBussinessMS_Observatorios[varObservatorio.Length];
        for(int i = 0;i< varObservatorio.Length ;i++)
        {
            myRegistro_de_Contenido.Observatorio[i] = new MS_ObservatoriosCS.objectBussinessMS_Observatorios();
            myRegistro_de_Contenido.Observatorio[i].Observatorio = varObservatorio[i];
        }
        myRegistro_de_Contenido.Categoria = varCategoria;
        myRegistro_de_Contenido.Descripcion_de_Solicitud = varDescripcion_de_Solicitud;
        myRegistro_de_Contenido.Reportero_Asignado = varReportero_Asignado;
        myRegistro_de_Contenido.Fecha_de_Compromiso = varFecha_de_Compromiso;
        myRegistro_de_Contenido.Estatus = varEstatus;
        myRegistro_de_Contenido.Administrador_de_Observatorio = varAdministrador_de_Observatorio;
        myRegistro_de_Contenido.Reportero = varReportero;
        myRegistro_de_Contenido.Titulo = varTitulo;
        myRegistro_de_Contenido.Descripcion = varDescripcion;
        myRegistro_de_Contenido.Contenido = varContenido;
        myRegistro_de_Contenido.Imagen = varImagen;
        myRegistro_de_Contenido.Imagen_Miniatura = varImagen_Miniatura;
        myRegistro_de_Contenido.Estilo = varEstilo;
            if(varEtiquetasEtiqueta != null)
            {
                myRegistro_de_Contenido.Etiquetas = new Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas[varEtiquetasEtiqueta.Length];
                for (int i = 0; i < varEtiquetasEtiqueta.Length; i++)
                {
                    myRegistro_de_Contenido.Etiquetas[i] = new Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas();
                myRegistro_de_Contenido.Etiquetas[i].Etiqueta = varEtiquetasEtiqueta[i];

                }
            }
            if(varFuentesFuente != null)
            {
                myRegistro_de_Contenido.Fuentes = new FuentesCS.objectBussinessFuentes[varFuentesFuente.Length];
                for (int i = 0; i < varFuentesFuente.Length; i++)
                {
                    myRegistro_de_Contenido.Fuentes[i] = new FuentesCS.objectBussinessFuentes();
                myRegistro_de_Contenido.Fuentes[i].Fuente = varFuentesFuente[i];

                }
            }
        myRegistro_de_Contenido.Adjuntar_PDF = varAdjuntar_PDF;
        myRegistro_de_Contenido.Captura_Terminada = varCaptura_Terminada;
        myRegistro_de_Contenido.Autorizado_por = varAutorizado_por;
        myRegistro_de_Contenido.Fecha_de_Revision = varFecha_de_Revision;
        myRegistro_de_Contenido.Hora_de_Revision = varHora_de_Revision;
        myRegistro_de_Contenido.Autorizacion = varAutorizacion;
        myRegistro_de_Contenido.Motivo_de_Rechazo = varMotivo_de_Rechazo;
        myRegistro_de_Contenido.Fecha_de_Inicio_de_Publicacion = varFecha_de_Inicio_de_Publicacion;
        myRegistro_de_Contenido.Fecha_de_Termino = varFecha_de_Termino;
        myRegistro_de_Contenido.Seleccionar_Todos_los_Observatorios = varSeleccionar_Todos_los_Observatorios;
            if(varNotificaciones_por_ObservatoriosNotificar != null)
            {
                myRegistro_de_Contenido.Notificaciones_por_Observatorios = new Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio[varNotificaciones_por_ObservatoriosNotificar.Length];
                for (int i = 0; i < varNotificaciones_por_ObservatoriosNotificar.Length; i++)
                {
                    myRegistro_de_Contenido.Notificaciones_por_Observatorios[i] = new Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio();
                myRegistro_de_Contenido.Notificaciones_por_Observatorios[i].Notificar = varNotificaciones_por_ObservatoriosNotificar[i];
                myRegistro_de_Contenido.Notificaciones_por_Observatorios[i].Observatorio = varNotificaciones_por_ObservatoriosObservatorio[i];

                }
            }
        myRegistro_de_Contenido.Filtrar_Usuarios_por_Observatorio = varFiltrar_Usuarios_por_Observatorio;
            if(varNotificaciones_por_UsuarioNotificar != null)
            {
                myRegistro_de_Contenido.Notificaciones_por_Usuario = new Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario[varNotificaciones_por_UsuarioNotificar.Length];
                for (int i = 0; i < varNotificaciones_por_UsuarioNotificar.Length; i++)
                {
                    myRegistro_de_Contenido.Notificaciones_por_Usuario[i] = new Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario();
                myRegistro_de_Contenido.Notificaciones_por_Usuario[i].Notificar = varNotificaciones_por_UsuarioNotificar[i];
                myRegistro_de_Contenido.Notificaciones_por_Usuario[i].Observatorio = varNotificaciones_por_UsuarioObservatorio[i];
                myRegistro_de_Contenido.Notificaciones_por_Usuario[i].ID_del_Cliente = varNotificaciones_por_UsuarioID_del_Cliente[i];
                myRegistro_de_Contenido.Notificaciones_por_Usuario[i].Nombre = varNotificaciones_por_UsuarioNombre[i];

                }
            }

        String sMsg = "";
        if (!ValidaDataToSave(myRegistro_de_Contenido, out sMsg))
        {
            myRegistro_de_Contenido.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myRegistro_de_Contenido, out sMsg))
        {
            myRegistro_de_Contenido.Dispose();
            dr = null;
            globalInfo = null;
            throw new Exception(sMsg);
        }
        object result=myRegistro_de_Contenido.InsertWithReturnValue(globalInfo, dr);
        myRegistro_de_Contenido.Dispose();
        dr = null;
        globalInfo = null;
        return result;
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varFolio, int? varUsuario_que_Registra, DateTime? varFecha_de_Registro, String varHora_de_Registro, int?[] varObservatorio, int? varCategoria, String varDescripcion_de_Solicitud, int? varReportero_Asignado, DateTime? varFecha_de_Compromiso, int? varEstatus, int? varAdministrador_de_Observatorio, int? varReportero, String varTitulo, String varDescripcion, String varContenido, int? varImagen, int? varImagen_Miniatura, int? varEstilo, int?[] varEtiquetasClave, int?[] varEtiquetasArticulo, int?[] varEtiquetasEtiqueta, int?[] varFuentesClave, int?[] varFuentesArticulo, String[] varFuentesFuente, int? varAdjuntar_PDF, Boolean varCaptura_Terminada, int? varAutorizado_por, DateTime? varFecha_de_Revision, String varHora_de_Revision, int? varAutorizacion, String varMotivo_de_Rechazo, DateTime? varFecha_de_Inicio_de_Publicacion, DateTime? varFecha_de_Termino, Boolean varSeleccionar_Todos_los_Observatorios, int?[] varNotificaciones_por_ObservatoriosClave, int?[] varNotificaciones_por_ObservatoriosContenido, Boolean[] varNotificaciones_por_ObservatoriosNotificar, int?[] varNotificaciones_por_ObservatoriosObservatorio, int? varFiltrar_Usuarios_por_Observatorio, int?[] varNotificaciones_por_UsuarioClave, int?[] varNotificaciones_por_UsuarioContenido, Boolean[] varNotificaciones_por_UsuarioNotificar, int?[] varNotificaciones_por_UsuarioObservatorio, int?[] varNotificaciones_por_UsuarioID_del_Cliente, String[] varNotificaciones_por_UsuarioNombre)
    {
        Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myRegistro_de_Contenido.Folio = varFolio;
        myRegistro_de_Contenido.Usuario_que_Registra = varUsuario_que_Registra;
        myRegistro_de_Contenido.Fecha_de_Registro = varFecha_de_Registro;
        myRegistro_de_Contenido.Hora_de_Registro = varHora_de_Registro;
        myRegistro_de_Contenido.Observatorio =  new MS_ObservatoriosCS.objectBussinessMS_Observatorios[varObservatorio.Length];
        for(int i = 0;i< varObservatorio.Length ;i++)
        {
            myRegistro_de_Contenido.Observatorio[i] = new MS_ObservatoriosCS.objectBussinessMS_Observatorios();
            myRegistro_de_Contenido.Observatorio[i].Observatorio = varObservatorio[i];
        }
        myRegistro_de_Contenido.Categoria = varCategoria;
        myRegistro_de_Contenido.Descripcion_de_Solicitud = varDescripcion_de_Solicitud;
        myRegistro_de_Contenido.Reportero_Asignado = varReportero_Asignado;
        myRegistro_de_Contenido.Fecha_de_Compromiso = varFecha_de_Compromiso;
        myRegistro_de_Contenido.Estatus = varEstatus;
        myRegistro_de_Contenido.Administrador_de_Observatorio = varAdministrador_de_Observatorio;
        myRegistro_de_Contenido.Reportero = varReportero;
        myRegistro_de_Contenido.Titulo = varTitulo;
        myRegistro_de_Contenido.Descripcion = varDescripcion;
        myRegistro_de_Contenido.Contenido = varContenido;
        myRegistro_de_Contenido.Imagen = varImagen;
        myRegistro_de_Contenido.Imagen_Miniatura = varImagen_Miniatura;
        myRegistro_de_Contenido.Estilo = varEstilo;
            if(varEtiquetasEtiqueta != null)
            {
                myRegistro_de_Contenido.Etiquetas = new Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas[varEtiquetasEtiqueta.Length];
                for (int i = 0; i < varEtiquetasEtiqueta.Length; i++)
                {
                    myRegistro_de_Contenido.Etiquetas[i] = new Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas();
                myRegistro_de_Contenido.Etiquetas[i].Clave = varEtiquetasClave[i];
                myRegistro_de_Contenido.Etiquetas[i].Articulo = varEtiquetasArticulo[i];
                myRegistro_de_Contenido.Etiquetas[i].Etiqueta = varEtiquetasEtiqueta[i];

                }
            }
            if(varFuentesFuente != null)
            {
                myRegistro_de_Contenido.Fuentes = new FuentesCS.objectBussinessFuentes[varFuentesFuente.Length];
                for (int i = 0; i < varFuentesFuente.Length; i++)
                {
                    myRegistro_de_Contenido.Fuentes[i] = new FuentesCS.objectBussinessFuentes();
                myRegistro_de_Contenido.Fuentes[i].Clave = varFuentesClave[i];
                myRegistro_de_Contenido.Fuentes[i].Articulo = varFuentesArticulo[i];
                myRegistro_de_Contenido.Fuentes[i].Fuente = varFuentesFuente[i];

                }
            }
        myRegistro_de_Contenido.Adjuntar_PDF = varAdjuntar_PDF;
        myRegistro_de_Contenido.Captura_Terminada = varCaptura_Terminada;
        myRegistro_de_Contenido.Autorizado_por = varAutorizado_por;
        myRegistro_de_Contenido.Fecha_de_Revision = varFecha_de_Revision;
        myRegistro_de_Contenido.Hora_de_Revision = varHora_de_Revision;
        myRegistro_de_Contenido.Autorizacion = varAutorizacion;
        myRegistro_de_Contenido.Motivo_de_Rechazo = varMotivo_de_Rechazo;
        myRegistro_de_Contenido.Fecha_de_Inicio_de_Publicacion = varFecha_de_Inicio_de_Publicacion;
        myRegistro_de_Contenido.Fecha_de_Termino = varFecha_de_Termino;
        myRegistro_de_Contenido.Seleccionar_Todos_los_Observatorios = varSeleccionar_Todos_los_Observatorios;
            if(varNotificaciones_por_ObservatoriosNotificar != null)
            {
                myRegistro_de_Contenido.Notificaciones_por_Observatorios = new Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio[varNotificaciones_por_ObservatoriosNotificar.Length];
                for (int i = 0; i < varNotificaciones_por_ObservatoriosNotificar.Length; i++)
                {
                    myRegistro_de_Contenido.Notificaciones_por_Observatorios[i] = new Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio();
                myRegistro_de_Contenido.Notificaciones_por_Observatorios[i].Clave = varNotificaciones_por_ObservatoriosClave[i];
                myRegistro_de_Contenido.Notificaciones_por_Observatorios[i].Contenido = varNotificaciones_por_ObservatoriosContenido[i];
                myRegistro_de_Contenido.Notificaciones_por_Observatorios[i].Notificar = varNotificaciones_por_ObservatoriosNotificar[i];
                myRegistro_de_Contenido.Notificaciones_por_Observatorios[i].Observatorio = varNotificaciones_por_ObservatoriosObservatorio[i];

                }
            }
        myRegistro_de_Contenido.Filtrar_Usuarios_por_Observatorio = varFiltrar_Usuarios_por_Observatorio;
            if(varNotificaciones_por_UsuarioObservatorio != null)
            {
                myRegistro_de_Contenido.Notificaciones_por_Usuario = new Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario[varNotificaciones_por_UsuarioObservatorio.Length];
                for (int i = 0; i < varNotificaciones_por_UsuarioObservatorio.Length; i++)
                {
                    myRegistro_de_Contenido.Notificaciones_por_Usuario[i] = new Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario();
                myRegistro_de_Contenido.Notificaciones_por_Usuario[i].Clave = varNotificaciones_por_UsuarioClave[i];
                myRegistro_de_Contenido.Notificaciones_por_Usuario[i].Contenido = varNotificaciones_por_UsuarioContenido[i];
                myRegistro_de_Contenido.Notificaciones_por_Usuario[i].Notificar = varNotificaciones_por_UsuarioNotificar[i];
                myRegistro_de_Contenido.Notificaciones_por_Usuario[i].Observatorio = varNotificaciones_por_UsuarioObservatorio[i];
                myRegistro_de_Contenido.Notificaciones_por_Usuario[i].ID_del_Cliente = varNotificaciones_por_UsuarioID_del_Cliente[i];
                myRegistro_de_Contenido.Notificaciones_por_Usuario[i].Nombre = varNotificaciones_por_UsuarioNombre[i];

                }
            }

            String sMsg = "";
            if (!ValidaDataToSave(myRegistro_de_Contenido, out sMsg))
            {
                myRegistro_de_Contenido.Dispose();
                dr = null;
                globalInfo = null;
                throw new Exception(sMsg);
            }
            myRegistro_de_Contenido.Update(globalInfo, dr);
            myRegistro_de_Contenido.Dispose();
            dr = null;
            globalInfo = null;
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyFolio)
    {
        Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        bool result = myRegistro_de_Contenido.Delete(KeyFolio, globalInfo, dr);
        myRegistro_de_Contenido.Dispose();
        dr = null;
        return result;
    }

    [WebMethod]
    public Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido GetByKey(int? KeyFolio, Boolean ConRelaciones)
    {
        Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        myRegistro_de_Contenido.GetByKey(KeyFolio, ConRelaciones);;
        return myRegistro_de_Contenido;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyFolio)
    {
        Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        Int32 result = myRegistro_de_Contenido.CurrentPosicion(KeyFolio);
        return result;
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyFolio)
    {
        Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        Boolean result = myRegistro_de_Contenido.ValidaExistencia(KeyFolio);
        myRegistro_de_Contenido.Dispose();
        return result;
    }

    private bool ValidaDataToSave(Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido MyDataRegistro_de_Contenido, out String sMsg)
    {
        //Validaciones
        sMsg = "";
            if(MyDataRegistro_de_Contenido.Etiquetas != null)
            {
                for (int i = 0; i < MyDataRegistro_de_Contenido.Etiquetas.Length; i++)
                {
                    if (MyDataRegistro_de_Contenido.Etiquetas[i].Etiqueta != null)
                    {
                        EtiquetasCS.objectBussinessEtiquetas MyDataEtiquetasTemp = new EtiquetasCS.objectBussinessEtiquetas();
                        if (!MyDataEtiquetasTemp.ValidaExistencia(MyDataRegistro_de_Contenido.Etiquetas[i].Etiqueta))
                        {
                            sMsg = sMsg + "El Campo Etiqueta no existe\n";
                        }
                    }
                }
            }
            if(MyDataRegistro_de_Contenido.Notificaciones_por_Observatorios != null)
            {
                for (int i = 0; i < MyDataRegistro_de_Contenido.Notificaciones_por_Observatorios.Length; i++)
                {
                    if (MyDataRegistro_de_Contenido.Notificaciones_por_Observatorios[i].Observatorio != null)
                    {
                        ObservatorioCS.objectBussinessObservatorio MyDataObservatorioTemp = new ObservatorioCS.objectBussinessObservatorio();
                        if (!MyDataObservatorioTemp.ValidaExistencia(MyDataRegistro_de_Contenido.Notificaciones_por_Observatorios[i].Observatorio))
                        {
                            sMsg = sMsg + "El Campo Observatorio no existe\n";
                        }
                    }
                }
            }
            if(MyDataRegistro_de_Contenido.Notificaciones_por_Usuario != null)
            {
                for (int i = 0; i < MyDataRegistro_de_Contenido.Notificaciones_por_Usuario.Length; i++)
                {
                    if (MyDataRegistro_de_Contenido.Notificaciones_por_Usuario[i].Observatorio != null)
                    {
                        ObservatorioCS.objectBussinessObservatorio MyDataObservatorioTemp = new ObservatorioCS.objectBussinessObservatorio();
                        if (!MyDataObservatorioTemp.ValidaExistencia(MyDataRegistro_de_Contenido.Notificaciones_por_Usuario[i].Observatorio))
                        {
                            sMsg = sMsg + "El Campo Observatorio no existe\n";
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

    public bool ValidaDataDuplication(Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido MyDataRegistro_de_Contenido, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataRegistro_de_Contenido.Folio == -1)
        {
            if (MyDataRegistro_de_Contenido.ValidaExistencia(MyDataRegistro_de_Contenido.Folio))
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
        Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myRegistro_de_Contenido.FillDataUsuario_que_Registra().Copy());
        else
            ds.Tables.Add(myRegistro_de_Contenido.FillDataUsuario_que_Registra(sFiltro).Copy());
        myRegistro_de_Contenido.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataUsuario_que_RegistraCDD(string knownCategoryValues, string category)
    {
        Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myRegistro_de_Contenido.FillDataUsuario_que_Registra();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["IdUsuario"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myRegistro_de_Contenido.Dispose();
        return values.ToArray();
    }    [WebMethod]
    public DataSet FillDataObservatorio()
    {
        Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        DataSet ds = new DataSet();
        ds.Tables.Add(myRegistro_de_Contenido.FillDataObservatorio().Copy());
        myRegistro_de_Contenido.Dispose();
        return ds;
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataObservatorioCDD(string knownCategoryValues, string category)
    {
        Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myRegistro_de_Contenido.FillDataObservatorio();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Clave"].ToString(), dRow["Clave"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myRegistro_de_Contenido.Dispose();
        return values.ToArray();
    }    [WebMethod]
    public DataSet FillDataCategoria(String sFiltro)
    {
        Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myRegistro_de_Contenido.FillDataCategoria().Copy());
        else
            ds.Tables.Add(myRegistro_de_Contenido.FillDataCategoria(sFiltro).Copy());
        myRegistro_de_Contenido.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataCategoriaCDD(string knownCategoryValues, string category)
    {
        Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myRegistro_de_Contenido.FillDataCategoria();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Descripcion"].ToString(), dRow["Clave"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myRegistro_de_Contenido.Dispose();
        return values.ToArray();
    }    [WebMethod]
    public DataSet FillDataReportero_Asignado(String sFiltro)
    {
        Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myRegistro_de_Contenido.FillDataReportero_Asignado().Copy());
        else
            ds.Tables.Add(myRegistro_de_Contenido.FillDataReportero_Asignado(sFiltro).Copy());
        myRegistro_de_Contenido.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataReportero_AsignadoCDD(string knownCategoryValues, string category)
    {
        Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myRegistro_de_Contenido.FillDataReportero_Asignado();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["IdUsuario"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myRegistro_de_Contenido.Dispose();
        return values.ToArray();
    }    [WebMethod]
    public DataSet FillDataEstatus(String sFiltro)
    {
        Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myRegistro_de_Contenido.FillDataEstatus().Copy());
        else
            ds.Tables.Add(myRegistro_de_Contenido.FillDataEstatus(sFiltro).Copy());
        myRegistro_de_Contenido.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataEstatusCDD(string knownCategoryValues, string category)
    {
        Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myRegistro_de_Contenido.FillDataEstatus();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Descripcion"].ToString(), dRow["Clave"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myRegistro_de_Contenido.Dispose();
        return values.ToArray();
    }    [WebMethod]
    public DataSet FillDataAdministrador_de_Observatorio(String sFiltro)
    {
        Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myRegistro_de_Contenido.FillDataAdministrador_de_Observatorio().Copy());
        else
            ds.Tables.Add(myRegistro_de_Contenido.FillDataAdministrador_de_Observatorio(sFiltro).Copy());
        myRegistro_de_Contenido.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataAdministrador_de_ObservatorioCDD(string knownCategoryValues, string category)
    {
        Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myRegistro_de_Contenido.FillDataAdministrador_de_Observatorio();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["IdUsuario"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myRegistro_de_Contenido.Dispose();
        return values.ToArray();
    }    [WebMethod]
    public DataSet FillDataReportero(String sFiltro)
    {
        Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myRegistro_de_Contenido.FillDataReportero().Copy());
        else
            ds.Tables.Add(myRegistro_de_Contenido.FillDataReportero(sFiltro).Copy());
        myRegistro_de_Contenido.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataReporteroCDD(string knownCategoryValues, string category)
    {
        Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myRegistro_de_Contenido.FillDataReportero();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["IdUsuario"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myRegistro_de_Contenido.Dispose();
        return values.ToArray();
    }    [WebMethod]
    public DataSet FillDataEstilo(String sFiltro)
    {
        Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myRegistro_de_Contenido.FillDataEstilo().Copy());
        else
            ds.Tables.Add(myRegistro_de_Contenido.FillDataEstilo(sFiltro).Copy());
        myRegistro_de_Contenido.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataEstiloCDD(string knownCategoryValues, string category)
    {
        Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myRegistro_de_Contenido.FillDataEstilo();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Descripcion"].ToString(), dRow["Clave"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myRegistro_de_Contenido.Dispose();
        return values.ToArray();
    }    [WebMethod]
    public DataSet FillDataAutorizado_por(String sFiltro)
    {
        Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myRegistro_de_Contenido.FillDataAutorizado_por().Copy());
        else
            ds.Tables.Add(myRegistro_de_Contenido.FillDataAutorizado_por(sFiltro).Copy());
        myRegistro_de_Contenido.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataAutorizado_porCDD(string knownCategoryValues, string category)
    {
        Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myRegistro_de_Contenido.FillDataAutorizado_por();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["IdUsuario"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myRegistro_de_Contenido.Dispose();
        return values.ToArray();
    }    [WebMethod]
    public DataSet FillDataAutorizacion(String sFiltro)
    {
        Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myRegistro_de_Contenido.FillDataAutorizacion().Copy());
        else
            ds.Tables.Add(myRegistro_de_Contenido.FillDataAutorizacion(sFiltro).Copy());
        myRegistro_de_Contenido.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataAutorizacionCDD(string knownCategoryValues, string category)
    {
        Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myRegistro_de_Contenido.FillDataAutorizacion();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Descripcion"].ToString(), dRow["Clave"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myRegistro_de_Contenido.Dispose();
        return values.ToArray();
    }    [WebMethod]
    public DataSet FillDataFiltrar_Usuarios_por_Observatorio(String sFiltro)
    {
        Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myRegistro_de_Contenido.FillDataFiltrar_Usuarios_por_Observatorio().Copy());
        else
            ds.Tables.Add(myRegistro_de_Contenido.FillDataFiltrar_Usuarios_por_Observatorio(sFiltro).Copy());
        myRegistro_de_Contenido.Dispose();
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataFiltrar_Usuarios_por_ObservatorioCDD(string knownCategoryValues, string category)
    {
        Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new Registro_de_ContenidoCS.objectBussinessRegistro_de_Contenido();
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myRegistro_de_Contenido.FillDataFiltrar_Usuarios_por_Observatorio();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Nombre"].ToString(), dRow["Clave"].ToString()));
            }
            dt.Dispose();
        }
        catch
        { }
        myRegistro_de_Contenido.Dispose();
        return values.ToArray();
    }
}
