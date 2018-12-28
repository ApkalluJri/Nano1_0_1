using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace Registro_de_ContenidoCS
{
    public class Registro_de_ContenidoFilters
    {
        private Boolean obligatory;
        private Boolean defaultview;
        private Boolean vacia;
        public Boolean Obligatory 
        {
            get { return obligatory; }
            set { obligatory = value; }
        }
        public Boolean Defaultview
        {
            get { return defaultview; }
            set { defaultview = value; }
        }
        public Boolean Vacia
        {
            get { return vacia; }
            set { vacia = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric  varFolio =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric Folio{
            get { return varFolio; }
            set { varFolio = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varUsuario_que_Registra =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTUsuariosCS.TTUsuariosFilters[] varUsuario_que_Registra;
        public TTClassSpecials.FiltersTypes.Dependientes Usuario_que_Registra{
            get { return varUsuario_que_Registra; }
            set { varUsuario_que_Registra = value; }
        }
        private TTClassSpecials.FiltersTypes.filDate  varFecha_de_Registro =new TTClassSpecials.FiltersTypes.filDate();
        public TTClassSpecials.FiltersTypes.filDate Fecha_de_Registro{
            get { return varFecha_de_Registro; }
            set { varFecha_de_Registro = value; }
        }
        private TTClassSpecials.FiltersTypes.String varHora_de_Registro = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Hora_de_Registro
        {
            get { return varHora_de_Registro; }
            set { varHora_de_Registro = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varObservatorio =new TTClassSpecials.FiltersTypes.Dependientes();
//        private MS_ObservatoriosCS.MS_ObservatoriosFilters[] varObservatorio;
        public TTClassSpecials.FiltersTypes.Dependientes Observatorio{
            get { return varObservatorio; }
            set { varObservatorio = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varCategoria =new TTClassSpecials.FiltersTypes.Dependientes();
//        private CategoriaCS.CategoriaFilters[] varCategoria;
        public TTClassSpecials.FiltersTypes.Dependientes Categoria{
            get { return varCategoria; }
            set { varCategoria = value; }
        }
        private TTClassSpecials.FiltersTypes.String varDescripcion_de_Solicitud = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Descripcion_de_Solicitud
        {
            get { return varDescripcion_de_Solicitud; }
            set { varDescripcion_de_Solicitud = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varReportero_Asignado =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTUsuariosCS.TTUsuariosFilters[] varReportero_Asignado;
        public TTClassSpecials.FiltersTypes.Dependientes Reportero_Asignado{
            get { return varReportero_Asignado; }
            set { varReportero_Asignado = value; }
        }
        private TTClassSpecials.FiltersTypes.filDate  varFecha_de_Compromiso =new TTClassSpecials.FiltersTypes.filDate();
        public TTClassSpecials.FiltersTypes.filDate Fecha_de_Compromiso{
            get { return varFecha_de_Compromiso; }
            set { varFecha_de_Compromiso = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varEstatus =new TTClassSpecials.FiltersTypes.Dependientes();
//        private Estatus_de_ContenidoCS.Estatus_de_ContenidoFilters[] varEstatus;
        public TTClassSpecials.FiltersTypes.Dependientes Estatus{
            get { return varEstatus; }
            set { varEstatus = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varAdministrador_de_Observatorio =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTUsuariosCS.TTUsuariosFilters[] varAdministrador_de_Observatorio;
        public TTClassSpecials.FiltersTypes.Dependientes Administrador_de_Observatorio{
            get { return varAdministrador_de_Observatorio; }
            set { varAdministrador_de_Observatorio = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varReportero =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTUsuariosCS.TTUsuariosFilters[] varReportero;
        public TTClassSpecials.FiltersTypes.Dependientes Reportero{
            get { return varReportero; }
            set { varReportero = value; }
        }
        private TTClassSpecials.FiltersTypes.String varTitulo = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Titulo
        {
            get { return varTitulo; }
            set { varTitulo = value; }
        }
        private TTClassSpecials.FiltersTypes.String varDescripcion = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Descripcion
        {
            get { return varDescripcion; }
            set { varDescripcion = value; }
        }
        private TTClassSpecials.FiltersTypes.String varContenido = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Contenido
        {
            get { return varContenido; }
            set { varContenido = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric  varImagen =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric Imagen{
            get { return varImagen; }
            set { varImagen = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric  varImagen_Miniatura =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric Imagen_Miniatura{
            get { return varImagen_Miniatura; }
            set { varImagen_Miniatura = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varEstilo =new TTClassSpecials.FiltersTypes.Dependientes();
//        private Estilo_de_ArticuloCS.Estilo_de_ArticuloFilters[] varEstilo;
        public TTClassSpecials.FiltersTypes.Dependientes Estilo{
            get { return varEstilo; }
            set { varEstilo = value; }
        }
        private Detalle_de_EtiquetasCS.Detalle_de_EtiquetasFilters varEtiquetas =new Detalle_de_EtiquetasCS.Detalle_de_EtiquetasFilters();
        public Detalle_de_EtiquetasCS.Detalle_de_EtiquetasFilters Etiquetas{
            get { return varEtiquetas; }
            set { varEtiquetas = value; }
        }
        private FuentesCS.FuentesFilters varFuentes =new FuentesCS.FuentesFilters();
        public FuentesCS.FuentesFilters Fuentes{
            get { return varFuentes; }
            set { varFuentes = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric  varAdjuntar_PDF =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric Adjuntar_PDF{
            get { return varAdjuntar_PDF; }
            set { varAdjuntar_PDF = value; }
        }
        private TTClassSpecials.FiltersTypes.Logic varCaptura_Terminada = new TTClassSpecials.FiltersTypes.Logic();
        public TTClassSpecials.FiltersTypes.Logic Captura_Terminada
        {
            get { return varCaptura_Terminada; }
            set { varCaptura_Terminada = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varAutorizado_por =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTUsuariosCS.TTUsuariosFilters[] varAutorizado_por;
        public TTClassSpecials.FiltersTypes.Dependientes Autorizado_por{
            get { return varAutorizado_por; }
            set { varAutorizado_por = value; }
        }
        private TTClassSpecials.FiltersTypes.filDate  varFecha_de_Revision =new TTClassSpecials.FiltersTypes.filDate();
        public TTClassSpecials.FiltersTypes.filDate Fecha_de_Revision{
            get { return varFecha_de_Revision; }
            set { varFecha_de_Revision = value; }
        }
        private TTClassSpecials.FiltersTypes.String varHora_de_Revision = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Hora_de_Revision
        {
            get { return varHora_de_Revision; }
            set { varHora_de_Revision = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varAutorizacion =new TTClassSpecials.FiltersTypes.Dependientes();
//        private AutorizacionCS.AutorizacionFilters[] varAutorizacion;
        public TTClassSpecials.FiltersTypes.Dependientes Autorizacion{
            get { return varAutorizacion; }
            set { varAutorizacion = value; }
        }
        private TTClassSpecials.FiltersTypes.String varMotivo_de_Rechazo = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Motivo_de_Rechazo
        {
            get { return varMotivo_de_Rechazo; }
            set { varMotivo_de_Rechazo = value; }
        }
        private TTClassSpecials.FiltersTypes.filDate  varFecha_de_Inicio_de_Publicacion =new TTClassSpecials.FiltersTypes.filDate();
        public TTClassSpecials.FiltersTypes.filDate Fecha_de_Inicio_de_Publicacion{
            get { return varFecha_de_Inicio_de_Publicacion; }
            set { varFecha_de_Inicio_de_Publicacion = value; }
        }
        private TTClassSpecials.FiltersTypes.filDate  varFecha_de_Termino =new TTClassSpecials.FiltersTypes.filDate();
        public TTClassSpecials.FiltersTypes.filDate Fecha_de_Termino{
            get { return varFecha_de_Termino; }
            set { varFecha_de_Termino = value; }
        }
        private TTClassSpecials.FiltersTypes.Logic varSeleccionar_Todos_los_Observatorios = new TTClassSpecials.FiltersTypes.Logic();
        public TTClassSpecials.FiltersTypes.Logic Seleccionar_Todos_los_Observatorios
        {
            get { return varSeleccionar_Todos_los_Observatorios; }
            set { varSeleccionar_Todos_los_Observatorios = value; }
        }
        private Detalle_de_Notificacion_por_ObservatorioCS.Detalle_de_Notificacion_por_ObservatorioFilters varNotificaciones_por_Observatorios =new Detalle_de_Notificacion_por_ObservatorioCS.Detalle_de_Notificacion_por_ObservatorioFilters();
        public Detalle_de_Notificacion_por_ObservatorioCS.Detalle_de_Notificacion_por_ObservatorioFilters Notificaciones_por_Observatorios{
            get { return varNotificaciones_por_Observatorios; }
            set { varNotificaciones_por_Observatorios = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varFiltrar_Usuarios_por_Observatorio =new TTClassSpecials.FiltersTypes.Dependientes();
//        private ObservatorioCS.ObservatorioFilters[] varFiltrar_Usuarios_por_Observatorio;
        public TTClassSpecials.FiltersTypes.Dependientes Filtrar_Usuarios_por_Observatorio{
            get { return varFiltrar_Usuarios_por_Observatorio; }
            set { varFiltrar_Usuarios_por_Observatorio = value; }
        }
        private Detalle_de_Notificacion_por_UsuarioCS.Detalle_de_Notificacion_por_UsuarioFilters varNotificaciones_por_Usuario =new Detalle_de_Notificacion_por_UsuarioCS.Detalle_de_Notificacion_por_UsuarioFilters();
        public Detalle_de_Notificacion_por_UsuarioCS.Detalle_de_Notificacion_por_UsuarioFilters Notificaciones_por_Usuario{
            get { return varNotificaciones_por_Usuario; }
            set { varNotificaciones_por_Usuario = value; }
        }

    }
public class objectBussinessRegistro_de_Contenido : IDisposable
{
    public int iProcess = 29982;
    private TTFunctions.Functions Function = new TTFunctions.Functions();
    private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
    private Registro_de_ContenidoFilters[] filters; 
    private ControlsLibrary.objectBussinessTTFiltro[] myFilters;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumns;
    private ControlsLibrary.objectBussinessTTFiltro[] myFiltersObligatories;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumnsObligatories;
    private ControlsLibrary.objectBussinessTTFiltro myFiltersQuick;
	private int? varFolio;
	private int? varUsuario_que_Registra;
	private DateTime? varFecha_de_Registro;
	private String varHora_de_Registro;
	private MS_ObservatoriosCS.objectBussinessMS_Observatorios[] varObservatorio;
	private int? varCategoria;
	private String varDescripcion_de_Solicitud;
	private int? varReportero_Asignado;
	private DateTime? varFecha_de_Compromiso;
	private int? varEstatus;
	private int? varAdministrador_de_Observatorio;
	private int? varReportero;
	private String varTitulo;
	private String varDescripcion;
	private String varContenido;
	private int? varImagen;
	private int? varImagen_Miniatura;
	private int? varEstilo;
    private Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas[] varEtiquetas;
    private FuentesCS.objectBussinessFuentes[] varFuentes;
	private int? varAdjuntar_PDF;
	private Boolean varCaptura_Terminada;
	private int? varAutorizado_por;
	private DateTime? varFecha_de_Revision;
	private String varHora_de_Revision;
	private int? varAutorizacion;
	private String varMotivo_de_Rechazo;
	private DateTime? varFecha_de_Inicio_de_Publicacion;
	private DateTime? varFecha_de_Termino;
	private Boolean varSeleccionar_Todos_los_Observatorios;
    private Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio[] varNotificaciones_por_Observatorios;
	private int? varFiltrar_Usuarios_por_Observatorio;
    private Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario[] varNotificaciones_por_Usuario;


    bool disposed;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                //dispose managed ressources
            }
        }
        //dispose unmanaged ressources
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }		
    private String varOrderClickHeaderCellType="";
    private String varOrderClickHeaderCell="";
    public String OrderClickHeaderCell
    {
        get { return varOrderClickHeaderCell; }
        set { varOrderClickHeaderCell = value; }
    }
    public String OrderClickHeaderCellType
    {
        get { return varOrderClickHeaderCellType; }
        set { varOrderClickHeaderCellType = value; }
    }
    public ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] MyConfigurationColumns
    {
        get { return myConfigurationColumns; }
        set { myConfigurationColumns = value; }
    }
    public ControlsLibrary.objectBussinessTTFiltro[] MyFilters
    {
        get { return myFilters;} 
        set { myFilters = value;}
    }
    public ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] MyConfigurationColumnsObligatories
    {
        get { return myConfigurationColumnsObligatories; }
        set { myConfigurationColumnsObligatories = value; }
    }
    public ControlsLibrary.objectBussinessTTFiltro[] MyFiltersObligatories
    {
        get { return myFiltersObligatories; }
        set { myFiltersObligatories = value; }
    }
    public ControlsLibrary.objectBussinessTTFiltro MyFiltersQuick
    {
        get { return myFiltersQuick; }
        set { myFiltersQuick = value; }
    }

    public Registro_de_ContenidoFilters[] Filters
    {
        get { return filters; }
        set { filters = value; }
    }
    public Registro_de_ContenidoFilters Filter
    {
        ///Cuando es llamada desde las relaciones de algun catalago
        set
        {
            filters = new Registro_de_ContenidoFilters[1];
            filters[0] = value;
        }
    }

    public int? Folio{
        get { return varFolio;}
        set { varFolio = value;}
    }
    public int? Usuario_que_Registra{
        get { return varUsuario_que_Registra;}
        set { varUsuario_que_Registra = value;}
    }
    public DateTime? Fecha_de_Registro{
        get { return varFecha_de_Registro;}
        set { varFecha_de_Registro = value;}
    }
    public String Hora_de_Registro{
        get { return varHora_de_Registro;}
        set { varHora_de_Registro = value;}
    }
    public MS_ObservatoriosCS.objectBussinessMS_Observatorios[] Observatorio{
        get { return varObservatorio;}
        set { varObservatorio = value;}
    }
    public int? Categoria{
        get { return varCategoria;}
        set { varCategoria = value;}
    }
    public String Descripcion_de_Solicitud{
        get { return varDescripcion_de_Solicitud;}
        set { varDescripcion_de_Solicitud = value;}
    }
    public int? Reportero_Asignado{
        get { return varReportero_Asignado;}
        set { varReportero_Asignado = value;}
    }
    public DateTime? Fecha_de_Compromiso{
        get { return varFecha_de_Compromiso;}
        set { varFecha_de_Compromiso = value;}
    }
    public int? Estatus{
        get { return varEstatus;}
        set { varEstatus = value;}
    }
    public int? Administrador_de_Observatorio{
        get { return varAdministrador_de_Observatorio;}
        set { varAdministrador_de_Observatorio = value;}
    }
    public int? Reportero{
        get { return varReportero;}
        set { varReportero = value;}
    }
    public String Titulo{
        get { return varTitulo;}
        set { varTitulo = value;}
    }
    public String Descripcion{
        get { return varDescripcion;}
        set { varDescripcion = value;}
    }
    public String Contenido{
        get { return varContenido;}
        set { varContenido = value;}
    }
    public int? Imagen{
        get { return varImagen;}
        set { varImagen = value;}
    }
    public int? Imagen_Miniatura{
        get { return varImagen_Miniatura;}
        set { varImagen_Miniatura = value;}
    }
    public int? Estilo{
        get { return varEstilo;}
        set { varEstilo = value;}
    }
    public Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas[] Etiquetas{
        get { return varEtiquetas;}
        set { varEtiquetas = value;}
    }
    public FuentesCS.objectBussinessFuentes[] Fuentes{
        get { return varFuentes;}
        set { varFuentes = value;}
    }
    public int? Adjuntar_PDF{
        get { return varAdjuntar_PDF;}
        set { varAdjuntar_PDF = value;}
    }
    public Boolean Captura_Terminada{
        get { return varCaptura_Terminada;}
        set { varCaptura_Terminada = value;}
    }
    public int? Autorizado_por{
        get { return varAutorizado_por;}
        set { varAutorizado_por = value;}
    }
    public DateTime? Fecha_de_Revision{
        get { return varFecha_de_Revision;}
        set { varFecha_de_Revision = value;}
    }
    public String Hora_de_Revision{
        get { return varHora_de_Revision;}
        set { varHora_de_Revision = value;}
    }
    public int? Autorizacion{
        get { return varAutorizacion;}
        set { varAutorizacion = value;}
    }
    public String Motivo_de_Rechazo{
        get { return varMotivo_de_Rechazo;}
        set { varMotivo_de_Rechazo = value;}
    }
    public DateTime? Fecha_de_Inicio_de_Publicacion{
        get { return varFecha_de_Inicio_de_Publicacion;}
        set { varFecha_de_Inicio_de_Publicacion = value;}
    }
    public DateTime? Fecha_de_Termino{
        get { return varFecha_de_Termino;}
        set { varFecha_de_Termino = value;}
    }
    public Boolean Seleccionar_Todos_los_Observatorios{
        get { return varSeleccionar_Todos_los_Observatorios;}
        set { varSeleccionar_Todos_los_Observatorios = value;}
    }
    public Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio[] Notificaciones_por_Observatorios{
        get { return varNotificaciones_por_Observatorios;}
        set { varNotificaciones_por_Observatorios = value;}
    }
    public int? Filtrar_Usuarios_por_Observatorio{
        get { return varFiltrar_Usuarios_por_Observatorio;}
        set { varFiltrar_Usuarios_por_Observatorio = value;}
    }
    public Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario[] Notificaciones_por_Usuario{
        get { return varNotificaciones_por_Usuario;}
        set { varNotificaciones_por_Usuario = value;}
    }


    private String swhere = String.Empty;
    public String sWhere
    {
        get { return swhere; }
        set { swhere = value; }
    }
    private String fullQuery = @"SELECT {0} ORDER BY {1} ";
    public String FullQuery
    {
        get { return fullQuery; }            
    }
    private String fullQueryForExport = @"SELECT {0} ORDER BY {1} ";
    public String FullQueryForExport
    {
        get { return fullQueryForExport; }            
    }
    private int fullQueryCount = 0;
    public int FullQueryCount
    {
        get { return fullQueryCount; }
    }

    public Int32 SelCount()
    {
            DataSet ds;
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            string swhere = "";
        if (this.myFilters!=null)
            foreach (ControlsLibrary.objectBussinessTTFiltro fil in this.myFilters)
            {
                String sWhereT = fil.GenerateWhereWithOutLeftJoin(null);
                if (sWhereT != "")
                    if (swhere == "")
                        swhere = sWhereT;
                    else
                        swhere += " and " + sWhereT;
            }
        if (this.myFiltersObligatories != null)
            foreach (ControlsLibrary.objectBussinessTTFiltro fil in this.myFiltersObligatories)
            {
                String sWhereT = fil.GenerateWhereWithOutLeftJoin(null);
                if (sWhereT != "")
                    if (swhere == "")
                        swhere = sWhereT;
                    else
                        swhere += " and " + sWhereT;
            }
        if (this.myFiltersQuick != null)
            if (swhere == "")
                swhere += this.myFiltersQuick.GenerateWhereWithOutLeftJoin(null);
            else
                swhere += " and " + this.myFiltersQuick.GenerateWhereWithOutLeftJoin(null);
        if (swhere.Length >= 4)
            if (swhere.Substring(swhere.Length - 4) == "and ")
                swhere = swhere.Substring(0, swhere.Length - 4);

        if (swhere != "")
        {
            com.Parameters.AddWithValue("@Filter"," where " + swhere);
            com.CommandText = "sp_SelAllComplete_Registro_de_Contenido_WithFilter";
        }else 
            com.CommandText = "sp_SelAllComplete_Registro_de_Contenido";

            ds = db.Consulta(com);
            swhere = "";


            if (this.filters !=null)
                foreach (Registro_de_ContenidoCS.Registro_de_ContenidoFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Registro_de_Contenido", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);

            DataSet ds2 = new DataSet();
            ds2.Tables.Add(Function.SelectDataTable(ds.Tables[0], swhere, ""));
            return ds2.Tables[0].Rows.Count;
    }

    public DataSet SelAll(Boolean ConRelaciones)
    {
                DataSet ds;
        TTDataLayerCS.BD db =new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandType=CommandType.StoredProcedure;

        String swhere="";
        String sOrderBy = "";
        if (this.myFilters!=null)
            foreach (ControlsLibrary.objectBussinessTTFiltro fil in this.myFilters)
            {
                String sWhereT = fil.GenerateWhereWithOutLeftJoin(null);
                if (sWhereT != "")
                    if (swhere == "")
                        swhere = sWhereT;
                    else
                        swhere += " and " + sWhereT;
            }
        if (this.myConfigurationColumns != null)
            foreach (ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn fil in this.myConfigurationColumns)
                if (sOrderBy == "")
                    sOrderBy += fil.GenerateOrderBy();
                //else
                    //sOrderBy += "," + fil.GenerateOrderBy();
        if (this.myFiltersObligatories != null)
            foreach (ControlsLibrary.objectBussinessTTFiltro fil in this.myFiltersObligatories)
            {
                String sWhereT = fil.GenerateWhereWithOutLeftJoin(null);
                if (sWhereT != "")
                    if (swhere == "")
                        swhere = sWhereT;
                    else
                        swhere += " and " + sWhereT;
            }
        if (this.myConfigurationColumnsObligatories != null)
            foreach (ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn fil in this.myConfigurationColumnsObligatories)
                if (sOrderBy=="")
                    sOrderBy += fil.GenerateOrderBy();
                //else
                    //sOrderBy += ","+fil.GenerateOrderBy();
        if (this.myFiltersQuick != null)
            if (swhere == "")
                swhere += this.myFiltersQuick.GenerateWhereWithOutLeftJoin(null);
            else
                swhere += " and " + this.myFiltersQuick.GenerateWhereWithOutLeftJoin(null);
        if (swhere.Length >= 4)
            if (swhere.Substring(swhere.Length - 4) == "and ")
                swhere = swhere.Substring(0, swhere.Length - 4);

        if (ConRelaciones ==true)
            if (swhere != "")
            {
                com.Parameters.AddWithValue("@Filter"," where " + swhere);
                com.CommandText = "sp_SelAllComplete_Registro_de_Contenido_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_Registro_de_Contenido";
        else
            com.CommandText="sp_SelAllRegistro_de_Contenido";
            ds = db.Consulta(com);

        swhere = "";
            if (this.filters !=null)
                foreach (Registro_de_ContenidoCS.Registro_de_ContenidoFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Registro_de_Contenido", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("Registro_de_Contenido", fil);
                    if (sOrderByT != "")
                        sOrderBy = sOrderByT;
                }
        if (swhere != "")
            swhere = swhere.Substring(4);
        if (varOrderClickHeaderCell!="")
        {
            if (varOrderClickHeaderCellType !=" Desc")
                sOrderBy = varOrderClickHeaderCell + " Asc";
            else
                sOrderBy = varOrderClickHeaderCell + " Desc";
        }

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            object keyRegistro_de_Contenido = dr["Registro_de_Contenido_Folio"];

            MS_ObservatoriosCS.objectBussinessMS_Observatorios MyDataObservatorio = new MS_ObservatoriosCS.objectBussinessMS_Observatorios();
            MS_ObservatoriosCS.MS_ObservatoriosFilters MyDataFilterObservatorio = new MS_ObservatoriosCS.MS_ObservatoriosFilters();
            
            MyDataFilterObservatorio.Clave.List = new String[1];
            MyDataFilterObservatorio.Clave.List[0] = keyRegistro_de_Contenido.ToString();
            
            MyDataObservatorio.Filters = new MS_ObservatoriosCS.MS_ObservatoriosFilters[1];
            MyDataObservatorio.Filters[0] = MyDataFilterObservatorio;
            DataSet dsListBox = MyDataObservatorio.SelAll(true);

            int columnIndex = 0;
            if (dsListBox.Tables[0].Columns.Count >= 4)
                columnIndex = 3;
            else if (dsListBox.Tables[0].Columns.Count >= 2)
                columnIndex = 1;

            try
            {
                foreach (DataRow drlist in dsListBox.Tables[0].Rows)
                    dr["Registro_de_Contenido_Observatorio"] +=  (dr["Registro_de_Contenido_Observatorio"].ToString() == string.Empty ? string.Empty : ", ") +  drlist[columnIndex].ToString();
            }
            catch{}
        }


            DataSet ds2 = new DataSet();
            ds2.Tables.Add(Function.SelectDataTable(ds.Tables[0], swhere, sOrderBy));
            return ds2;
    }

    //-----------------------------------------------------------Métodos para paginación--------------------------------------------------------------
    public int SelCount(string sortDirection, string sortExpression, int maximumRows, int startRowIndex)
    {
            DataSet ds;
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            
        if (this.myFilters!=null)
            foreach (ControlsLibrary.objectBussinessTTFiltro fil in this.myFilters)
            {
                String sWhereT = fil.GenerateWhereWithOutLeftJoin(null);
                if (sWhereT != "")
                    if (swhere == "")
                        swhere = sWhereT;
                    else
                        swhere += " and " + sWhereT;
            }
        if (this.myFiltersObligatories != null)
            foreach (ControlsLibrary.objectBussinessTTFiltro fil in this.myFiltersObligatories)
            {
                String sWhereT = fil.GenerateWhereWithOutLeftJoin(null);
                if (sWhereT != "")
                    if (swhere == "")
                        swhere = sWhereT;
                    else
                        swhere += " and " + sWhereT;
            }
        if (this.myFiltersQuick != null)
            if (swhere == "")
                swhere += this.myFiltersQuick.GenerateWhereWithOutLeftJoin(null);
            else
                swhere += " and " + this.myFiltersQuick.GenerateWhereWithOutLeftJoin(null);
        if (swhere.Length >= 4)
            if (swhere.Substring(swhere.Length - 4) == "and ")
                swhere = swhere.Substring(0, swhere.Length - 4);

        
        if (swhere != string.Empty)
                swhere = (!swhere.ToLower().Trim().StartsWith("where") ? " WHERE " + swhere : swhere);

        string sPagingCountTemplate = @"SELECT COUNT(*) {0}";
                  string from = " from ((((((((((((( Registro_de_Contenido WITH(NoLock) LEFT JOIN TTUsuarios as Usuario_que_Registra WITH(NoLock) ON Usuario_que_Registra.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria as Categoria WITH(NoLock) ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as Reportero_Asignado WITH(NoLock) ON Reportero_Asignado.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido as Estatus WITH(NoLock) ON Estatus.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as Administrador_de_Observatorio WITH(NoLock) ON Administrador_de_Observatorio.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as Reportero WITH(NoLock) ON Reportero.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos as Imagen WITH(NoLock) ON Imagen.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as Imagen_Miniatura WITH(NoLock) ON Imagen_Miniatura.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo as Estilo WITH(NoLock) ON Estilo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as Adjuntar_PDF WITH(NoLock) ON Adjuntar_PDF.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as Autorizado_por WITH(NoLock) ON Autorizado_por.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion as Autorizacion WITH(NoLock) ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio as Filtrar_Usuarios_por_Observatorio WITH(NoLock) ON Filtrar_Usuarios_por_Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)        " + swhere; 

        sPagingCountTemplate = string.Format(sPagingCountTemplate, from);

        com.CommandText = sPagingCountTemplate;

        ds = db.Consulta(com);
        fullQueryCount = int.Parse(ds.Tables[0].Rows[0][0].ToString());
        return fullQueryCount;
    }

    public DataSet SelAll(string sortDirection, string sortExpression, int maximumRows, int startRowIndex)
    {
        DataSet ds;
        TTDataLayerCS.BD db =new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandType=CommandType.Text;
        
        String sOrderBy = "";
        if (this.myFilters!=null)
            foreach (ControlsLibrary.objectBussinessTTFiltro fil in this.myFilters)
            {
                String sWhereT = fil.GenerateWhereWithOutLeftJoin(null);
                if (sWhereT != "")
                    if (swhere == "")
                        swhere = sWhereT;
                    else
                        swhere += " and " + sWhereT;
            }
        if (this.myConfigurationColumns != null)
            foreach (ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn fil in this.myConfigurationColumns)
                if (sOrderBy == "")
                    sOrderBy += fil.GenerateOrderBy();
        //-------------------------------------------------------
        if (this.myFiltersObligatories != null)
            foreach (ControlsLibrary.objectBussinessTTFiltro fil in this.myFiltersObligatories)
            {
                String sWhereT = fil.GenerateWhereWithOutLeftJoin(null);
                if (sWhereT != "")
                    if (swhere == "")
                        swhere = sWhereT;
                    else
                        swhere += " and " + sWhereT;
            }
        if (this.myConfigurationColumnsObligatories != null)
            foreach (ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn fil in this.myConfigurationColumnsObligatories)
                if (sOrderBy=="")
                    sOrderBy += fil.GenerateOrderBy();
        //-------------------------------------------------------
        if (this.myFiltersQuick != null)
            if (swhere == "")
                swhere += this.myFiltersQuick.GenerateWhereWithOutLeftJoin(null);
            else
                swhere += " and " + this.myFiltersQuick.GenerateWhereWithOutLeftJoin(null);
        if (swhere.Length >= 4)
            if (swhere.Substring(swhere.Length - 4) == "and ")
                swhere = swhere.Substring(0, swhere.Length - 4);

        if (swhere != string.Empty)
            swhere = (!swhere.ToLower().Trim().StartsWith("where") ? " WHERE " + swhere : swhere);

                    switch (sortExpression)             {                 case "Registro_de_Contenido_Folio": sortExpression = "Registro_de_Contenido.Folio"; break;  case "Registro_de_Contenido_Usuario_que_Registra": sortExpression = "Registro_de_Contenido.Usuario_que_Registra"; break;  case "Usuario_que_Registra_Nombre": sortExpression = "Usuario_que_Registra.Nombre"; break;  case "Registro_de_Contenido_Fecha_de_Registro": sortExpression = "Registro_de_Contenido.Fecha_de_Registro"; break;  case "Registro_de_Contenido_Hora_de_Registro": sortExpression = "Registro_de_Contenido.Hora_de_Registro"; break;  case "Registro_de_Contenido_Categoria": sortExpression = "Registro_de_Contenido.Categoria"; break;  case "Categoria_Descripcion": sortExpression = "Categoria.Descripcion"; break;  case "Registro_de_Contenido_Descripcion_de_Solicitud": sortExpression = "Registro_de_Contenido.Descripcion_de_Solicitud"; break;  case "Registro_de_Contenido_Reportero_Asignado": sortExpression = "Registro_de_Contenido.Reportero_Asignado"; break;  case "Reportero_Asignado_Nombre": sortExpression = "Reportero_Asignado.Nombre"; break;  case "Registro_de_Contenido_Fecha_de_Compromiso": sortExpression = "Registro_de_Contenido.Fecha_de_Compromiso"; break;  case "Registro_de_Contenido_Estatus": sortExpression = "Registro_de_Contenido.Estatus"; break;  case "Estatus_Descripcion": sortExpression = "Estatus.Descripcion"; break;  case "Registro_de_Contenido_Administrador_de_Observatorio": sortExpression = "Registro_de_Contenido.Administrador_de_Observatorio"; break;  case "Administrador_de_Observatorio_Nombre": sortExpression = "Administrador_de_Observatorio.Nombre"; break;  case "Registro_de_Contenido_Reportero": sortExpression = "Registro_de_Contenido.Reportero"; break;  case "Reportero_Nombre": sortExpression = "Reportero.Nombre"; break;  case "Registro_de_Contenido_Titulo": sortExpression = "Registro_de_Contenido.Titulo"; break;  case "Registro_de_Contenido_Descripcion": sortExpression = "Registro_de_Contenido.Descripcion"; break;  case "Registro_de_Contenido_Contenido": sortExpression = "Registro_de_Contenido.Contenido"; break;  case "Registro_de_Contenido_Imagen": sortExpression = "Registro_de_Contenido.Imagen"; break;  case "Imagen_Nombre": sortExpression = "Imagen.Nombre"; break;  case "Registro_de_Contenido_Imagen_Miniatura": sortExpression = "Registro_de_Contenido.Imagen_Miniatura"; break;  case "Imagen_Miniatura_Nombre": sortExpression = "Imagen_Miniatura.Nombre"; break;  case "Registro_de_Contenido_Estilo": sortExpression = "Registro_de_Contenido.Estilo"; break;  case "Estilo_Descripcion": sortExpression = "Estilo.Descripcion"; break;  case "Registro_de_Contenido_Adjuntar_PDF": sortExpression = "Registro_de_Contenido.Adjuntar_PDF"; break;  case "Adjuntar_PDF_Nombre": sortExpression = "Adjuntar_PDF.Nombre"; break;  case "Registro_de_Contenido_Captura_Terminada": sortExpression = "Registro_de_Contenido.Captura_Terminada"; break;  case "Registro_de_Contenido_Autorizado_por": sortExpression = "Registro_de_Contenido.Autorizado_por"; break;  case "Autorizado_por_Nombre": sortExpression = "Autorizado_por.Nombre"; break;  case "Registro_de_Contenido_Fecha_de_Revision": sortExpression = "Registro_de_Contenido.Fecha_de_Revision"; break;  case "Registro_de_Contenido_Hora_de_Revision": sortExpression = "Registro_de_Contenido.Hora_de_Revision"; break;  case "Registro_de_Contenido_Autorizacion": sortExpression = "Registro_de_Contenido.Autorizacion"; break;  case "Autorizacion_Descripcion": sortExpression = "Autorizacion.Descripcion"; break;  case "Registro_de_Contenido_Motivo_de_Rechazo": sortExpression = "Registro_de_Contenido.Motivo_de_Rechazo"; break;  case "Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion": sortExpression = "Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion"; break;  case "Registro_de_Contenido_Fecha_de_Termino": sortExpression = "Registro_de_Contenido.Fecha_de_Termino"; break;  case "Registro_de_Contenido_Seleccionar_Todos_los_Observatorios": sortExpression = "Registro_de_Contenido.Seleccionar_Todos_los_Observatorios"; break;  case "Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio": sortExpression = "Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio"; break;  case "Filtrar_Usuarios_por_Observatorio_Nombre": sortExpression = "Filtrar_Usuarios_por_Observatorio.Nombre"; break;                               }              sortExpression = (sortExpression == string.Empty || sortExpression == null ? "Registro_de_Contenido.Folio, Registro_de_Contenido.Usuario_que_Registra, Usuario_que_Registra.Nombre, Registro_de_Contenido.Fecha_de_Registro, Registro_de_Contenido.Hora_de_Registro, Registro_de_Contenido.Categoria, Categoria.Descripcion, Registro_de_Contenido.Descripcion_de_Solicitud, Registro_de_Contenido.Reportero_Asignado, Reportero_Asignado.Nombre, Registro_de_Contenido.Fecha_de_Compromiso, Registro_de_Contenido.Estatus, Estatus.Descripcion, Registro_de_Contenido.Administrador_de_Observatorio, Administrador_de_Observatorio.Nombre, Registro_de_Contenido.Reportero, Reportero.Nombre, Registro_de_Contenido.Titulo, Registro_de_Contenido.Descripcion, Registro_de_Contenido.Contenido, Registro_de_Contenido.Imagen, Imagen.Nombre, Registro_de_Contenido.Imagen_Miniatura, Imagen_Miniatura.Nombre, Registro_de_Contenido.Estilo, Estilo.Descripcion, Registro_de_Contenido.Adjuntar_PDF, Adjuntar_PDF.Nombre, Registro_de_Contenido.Captura_Terminada, Registro_de_Contenido.Autorizado_por, Autorizado_por.Nombre, Registro_de_Contenido.Fecha_de_Revision, Registro_de_Contenido.Hora_de_Revision, Registro_de_Contenido.Autorizacion, Autorizacion.Descripcion, Registro_de_Contenido.Motivo_de_Rechazo, Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion, Registro_de_Contenido.Fecha_de_Termino, Registro_de_Contenido.Seleccionar_Todos_los_Observatorios, Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio, Filtrar_Usuarios_por_Observatorio.Nombre" : sortExpression);             if (sortDirection != string.Empty)                 sortDirection = (sortDirection.ToLower() == "ascending" ? "Asc" : "Desc");             string fieldsWithAlias = " Registro_de_Contenido.Folio As Registro_de_Contenido_Folio,        Registro_de_Contenido.Usuario_que_Registra AS Registro_de_Contenido_Usuario_que_Registra,        Usuario_que_Registra.Nombre AS Usuario_que_Registra_Nombre,        Registro_de_Contenido.Fecha_de_Registro As Registro_de_Contenido_Fecha_de_Registro,        Registro_de_Contenido.Hora_de_Registro As Registro_de_Contenido_Hora_de_Registro,        '' AS Registro_de_Contenido_Observatorio,        Registro_de_Contenido.Categoria AS Registro_de_Contenido_Categoria,        Categoria.Descripcion AS Categoria_Descripcion,        Registro_de_Contenido.Descripcion_de_Solicitud As Registro_de_Contenido_Descripcion_de_Solicitud,        Registro_de_Contenido.Reportero_Asignado AS Registro_de_Contenido_Reportero_Asignado,        Reportero_Asignado.Nombre AS Reportero_Asignado_Nombre,        Registro_de_Contenido.Fecha_de_Compromiso As Registro_de_Contenido_Fecha_de_Compromiso,        Registro_de_Contenido.Estatus AS Registro_de_Contenido_Estatus,        Estatus.Descripcion AS Estatus_Descripcion,        Registro_de_Contenido.Administrador_de_Observatorio AS Registro_de_Contenido_Administrador_de_Observatorio,        Administrador_de_Observatorio.Nombre AS Administrador_de_Observatorio_Nombre,        Registro_de_Contenido.Reportero AS Registro_de_Contenido_Reportero,        Reportero.Nombre AS Reportero_Nombre,        Registro_de_Contenido.Titulo As Registro_de_Contenido_Titulo,        Registro_de_Contenido.Descripcion As Registro_de_Contenido_Descripcion,        Registro_de_Contenido.Contenido As Registro_de_Contenido_Contenido,        Registro_de_Contenido.Imagen AS Registro_de_Contenido_Imagen,        Imagen.Nombre AS Imagen_Nombre,        Registro_de_Contenido.Imagen_Miniatura AS Registro_de_Contenido_Imagen_Miniatura,        Imagen_Miniatura.Nombre AS Imagen_Miniatura_Nombre,        Registro_de_Contenido.Estilo AS Registro_de_Contenido_Estilo,        Estilo.Descripcion AS Estilo_Descripcion,        Registro_de_Contenido.Adjuntar_PDF AS Registro_de_Contenido_Adjuntar_PDF,        Adjuntar_PDF.Nombre AS Adjuntar_PDF_Nombre,        Registro_de_Contenido.Captura_Terminada As Registro_de_Contenido_Captura_Terminada,        Registro_de_Contenido.Autorizado_por AS Registro_de_Contenido_Autorizado_por,        Autorizado_por.Nombre AS Autorizado_por_Nombre,        Registro_de_Contenido.Fecha_de_Revision As Registro_de_Contenido_Fecha_de_Revision,        Registro_de_Contenido.Hora_de_Revision As Registro_de_Contenido_Hora_de_Revision,        Registro_de_Contenido.Autorizacion AS Registro_de_Contenido_Autorizacion,        Autorizacion.Descripcion AS Autorizacion_Descripcion,        Registro_de_Contenido.Motivo_de_Rechazo As Registro_de_Contenido_Motivo_de_Rechazo,        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,        Registro_de_Contenido.Fecha_de_Termino As Registro_de_Contenido_Fecha_de_Termino,        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As Registro_de_Contenido_Seleccionar_Todos_los_Observatorios,        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,        Filtrar_Usuarios_por_Observatorio.Nombre AS Filtrar_Usuarios_por_Observatorio_Nombre ";             string fieldsForExport = " Registro_de_Contenido.Folio As [Folio],        Registro_de_Contenido.Usuario_que_Registra AS [Usuario que Registra],        Usuario_que_Registra.Nombre AS [Usuario que Registra Nombre],        Registro_de_Contenido.Fecha_de_Registro As [Fecha de Registro],        Registro_de_Contenido.Hora_de_Registro As [Hora de Registro],        '' AS [Observatorio],        Registro_de_Contenido.Categoria AS [Categoria],        Categoria.Descripcion AS [Categoria Descripcion],        Registro_de_Contenido.Descripcion_de_Solicitud As [Descripcion de Solicitud],        Registro_de_Contenido.Reportero_Asignado AS [Reportero Asignado],        Reportero_Asignado.Nombre AS [Reportero Asignado Nombre],        Registro_de_Contenido.Fecha_de_Compromiso As [Fecha de Compromiso],        Registro_de_Contenido.Estatus AS [Estatus],        Estatus.Descripcion AS [Estatus Descripcion],        Registro_de_Contenido.Administrador_de_Observatorio AS [Administrador de Observatorio],        Administrador_de_Observatorio.Nombre AS [Administrador de Observatorio Nombre],        Registro_de_Contenido.Reportero AS [Reportero],        Reportero.Nombre AS [Reportero Nombre],        Registro_de_Contenido.Titulo As [Titulo],        Registro_de_Contenido.Descripcion As [Descripcion],        Registro_de_Contenido.Contenido As [Contenido],        Registro_de_Contenido.Imagen AS [Imagen],        Imagen.Nombre AS [Imagen Nombre],        Registro_de_Contenido.Imagen_Miniatura AS [Imagen Miniatura],        Imagen_Miniatura.Nombre AS [Imagen Miniatura Nombre],        Registro_de_Contenido.Estilo AS [Estilo],        Estilo.Descripcion AS [Estilo Descripcion],        Registro_de_Contenido.Adjuntar_PDF AS [Adjuntar PDF],        Adjuntar_PDF.Nombre AS [Adjuntar PDF Nombre],        Registro_de_Contenido.Captura_Terminada As [Captura Terminada],        Registro_de_Contenido.Autorizado_por AS [Autorizado por],        Autorizado_por.Nombre AS [Autorizado por Nombre],        Registro_de_Contenido.Fecha_de_Revision As [Fecha de Revision],        Registro_de_Contenido.Hora_de_Revision As [Hora de Revision],        Registro_de_Contenido.Autorizacion AS [Autorizacion],        Autorizacion.Descripcion AS [Autorizacion Descripcion],        Registro_de_Contenido.Motivo_de_Rechazo As [Motivo de Rechazo],        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As [Fecha de Inicio de Publicacion],        Registro_de_Contenido.Fecha_de_Termino As [Fecha de Termino],        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As [Seleccionar Todos los Observatorios],        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS [Filtrar Usuarios por Observatorio],        Filtrar_Usuarios_por_Observatorio.Nombre AS [Filtrar Usuarios por Observatorio Nombre] ";             string from = " from ((((((((((((( Registro_de_Contenido WITH(NoLock) LEFT JOIN TTUsuarios as Usuario_que_Registra WITH(NoLock) ON Usuario_que_Registra.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria as Categoria WITH(NoLock) ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as Reportero_Asignado WITH(NoLock) ON Reportero_Asignado.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido as Estatus WITH(NoLock) ON Estatus.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as Administrador_de_Observatorio WITH(NoLock) ON Administrador_de_Observatorio.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as Reportero WITH(NoLock) ON Reportero.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos as Imagen WITH(NoLock) ON Imagen.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as Imagen_Miniatura WITH(NoLock) ON Imagen_Miniatura.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo as Estilo WITH(NoLock) ON Estilo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as Adjuntar_PDF WITH(NoLock) ON Adjuntar_PDF.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as Autorizado_por WITH(NoLock) ON Autorizado_por.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion as Autorizacion WITH(NoLock) ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio as Filtrar_Usuarios_por_Observatorio WITH(NoLock) ON Filtrar_Usuarios_por_Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)        " + swhere; 

        string sPagingTemplate = @"WITH ResultSet AS 
                          (SELECT 
                          ROW_NUMBER() OVER (ORDER BY {0}) as RowNumber,
                          {1} ) 
                            SELECT * FROM ResultSet 
                            WHERE RowNumber BETWEEN ({2}+1) and {2} + {3}";


        sPagingTemplate = string.Format(sPagingTemplate, sortExpression + " " + sortDirection, fieldsWithAlias + " " + from, startRowIndex, maximumRows);

        fullQuery = string.Format(fullQuery, fieldsWithAlias + " " + from, sortExpression + " " + sortDirection);
        fullQueryForExport = string.Format(fullQueryForExport, fieldsForExport + " " + from, sortExpression + " " + sortDirection);

        com.CommandText = sPagingTemplate;

        ds = db.Consulta(com);

                foreach (DataRow dr in ds.Tables[0].Rows)
        {
            object keyRegistro_de_Contenido = dr["Registro_de_Contenido_Folio"];

            MS_ObservatoriosCS.objectBussinessMS_Observatorios MyDataObservatorio = new MS_ObservatoriosCS.objectBussinessMS_Observatorios();
            MS_ObservatoriosCS.MS_ObservatoriosFilters MyDataFilterObservatorio = new MS_ObservatoriosCS.MS_ObservatoriosFilters();
            
            MyDataFilterObservatorio.Clave.List = new String[1];
            MyDataFilterObservatorio.Clave.List[0] = keyRegistro_de_Contenido.ToString();
            
            MyDataObservatorio.Filters = new MS_ObservatoriosCS.MS_ObservatoriosFilters[1];
            MyDataObservatorio.Filters[0] = MyDataFilterObservatorio;
            DataSet dsListBox = MyDataObservatorio.SelAll(true);

            int columnIndex = 0;
            if (dsListBox.Tables[0].Columns.Count >= 4)
                columnIndex = 3;
            else if (dsListBox.Tables[0].Columns.Count >= 2)
                columnIndex = 1;

            try
            {
                foreach (DataRow drlist in dsListBox.Tables[0].Rows)
                    dr["Registro_de_Contenido_Observatorio"] +=  (dr["Registro_de_Contenido_Observatorio"].ToString() == string.Empty ? string.Empty : ", ") +  drlist[columnIndex].ToString();
            }
            catch{}
        }


        return ds;
    }
    

    //-----------------------------------------------------------Métodos para rad Grid----------------------------------------------------------------
    public string GetFullQuery(string where, string Order)
    {
        	swhere = where; 	string fieldsWithAlias = " Registro_de_Contenido.Folio As Registro_de_Contenido_Folio,        Registro_de_Contenido.Usuario_que_Registra AS Registro_de_Contenido_Usuario_que_Registra,        Usuario_que_Registra.Nombre AS Usuario_que_Registra_Nombre,        Registro_de_Contenido.Fecha_de_Registro As Registro_de_Contenido_Fecha_de_Registro,        Registro_de_Contenido.Hora_de_Registro As Registro_de_Contenido_Hora_de_Registro,        '' AS Registro_de_Contenido_Observatorio,        Registro_de_Contenido.Categoria AS Registro_de_Contenido_Categoria,        Categoria.Descripcion AS Categoria_Descripcion,        Registro_de_Contenido.Descripcion_de_Solicitud As Registro_de_Contenido_Descripcion_de_Solicitud,        Registro_de_Contenido.Reportero_Asignado AS Registro_de_Contenido_Reportero_Asignado,        Reportero_Asignado.Nombre AS Reportero_Asignado_Nombre,        Registro_de_Contenido.Fecha_de_Compromiso As Registro_de_Contenido_Fecha_de_Compromiso,        Registro_de_Contenido.Estatus AS Registro_de_Contenido_Estatus,        Estatus.Descripcion AS Estatus_Descripcion,        Registro_de_Contenido.Administrador_de_Observatorio AS Registro_de_Contenido_Administrador_de_Observatorio,        Administrador_de_Observatorio.Nombre AS Administrador_de_Observatorio_Nombre,        Registro_de_Contenido.Reportero AS Registro_de_Contenido_Reportero,        Reportero.Nombre AS Reportero_Nombre,        Registro_de_Contenido.Titulo As Registro_de_Contenido_Titulo,        Registro_de_Contenido.Descripcion As Registro_de_Contenido_Descripcion,        Registro_de_Contenido.Contenido As Registro_de_Contenido_Contenido,        Registro_de_Contenido.Imagen AS Registro_de_Contenido_Imagen,        Imagen.Nombre AS Imagen_Nombre,        Registro_de_Contenido.Imagen_Miniatura AS Registro_de_Contenido_Imagen_Miniatura,        Imagen_Miniatura.Nombre AS Imagen_Miniatura_Nombre,        Registro_de_Contenido.Estilo AS Registro_de_Contenido_Estilo,        Estilo.Descripcion AS Estilo_Descripcion,        Registro_de_Contenido.Adjuntar_PDF AS Registro_de_Contenido_Adjuntar_PDF,        Adjuntar_PDF.Nombre AS Adjuntar_PDF_Nombre,        Registro_de_Contenido.Captura_Terminada As Registro_de_Contenido_Captura_Terminada,        Registro_de_Contenido.Autorizado_por AS Registro_de_Contenido_Autorizado_por,        Autorizado_por.Nombre AS Autorizado_por_Nombre,        Registro_de_Contenido.Fecha_de_Revision As Registro_de_Contenido_Fecha_de_Revision,        Registro_de_Contenido.Hora_de_Revision As Registro_de_Contenido_Hora_de_Revision,        Registro_de_Contenido.Autorizacion AS Registro_de_Contenido_Autorizacion,        Autorizacion.Descripcion AS Autorizacion_Descripcion,        Registro_de_Contenido.Motivo_de_Rechazo As Registro_de_Contenido_Motivo_de_Rechazo,        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,        Registro_de_Contenido.Fecha_de_Termino As Registro_de_Contenido_Fecha_de_Termino,        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As Registro_de_Contenido_Seleccionar_Todos_los_Observatorios,        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,        Filtrar_Usuarios_por_Observatorio.Nombre AS Filtrar_Usuarios_por_Observatorio_Nombre ";         Order = (Order == string.Empty || Order == null ? "Registro_de_Contenido.Folio, Registro_de_Contenido.Usuario_que_Registra, Usuario_que_Registra.Nombre, Registro_de_Contenido.Fecha_de_Registro, Registro_de_Contenido.Hora_de_Registro, Registro_de_Contenido.Categoria, Categoria.Descripcion, Registro_de_Contenido.Descripcion_de_Solicitud, Registro_de_Contenido.Reportero_Asignado, Reportero_Asignado.Nombre, Registro_de_Contenido.Fecha_de_Compromiso, Registro_de_Contenido.Estatus, Estatus.Descripcion, Registro_de_Contenido.Administrador_de_Observatorio, Administrador_de_Observatorio.Nombre, Registro_de_Contenido.Reportero, Reportero.Nombre, Registro_de_Contenido.Titulo, Registro_de_Contenido.Descripcion, Registro_de_Contenido.Contenido, Registro_de_Contenido.Imagen, Imagen.Nombre, Registro_de_Contenido.Imagen_Miniatura, Imagen_Miniatura.Nombre, Registro_de_Contenido.Estilo, Estilo.Descripcion, Registro_de_Contenido.Adjuntar_PDF, Adjuntar_PDF.Nombre, Registro_de_Contenido.Captura_Terminada, Registro_de_Contenido.Autorizado_por, Autorizado_por.Nombre, Registro_de_Contenido.Fecha_de_Revision, Registro_de_Contenido.Hora_de_Revision, Registro_de_Contenido.Autorizacion, Autorizacion.Descripcion, Registro_de_Contenido.Motivo_de_Rechazo, Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion, Registro_de_Contenido.Fecha_de_Termino, Registro_de_Contenido.Seleccionar_Todos_los_Observatorios, Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio, Filtrar_Usuarios_por_Observatorio.Nombre" : Order);         string from = " from ((((((((((((( Registro_de_Contenido WITH(NoLock) LEFT JOIN TTUsuarios as Usuario_que_Registra WITH(NoLock) ON Usuario_que_Registra.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria as Categoria WITH(NoLock) ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as Reportero_Asignado WITH(NoLock) ON Reportero_Asignado.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido as Estatus WITH(NoLock) ON Estatus.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as Administrador_de_Observatorio WITH(NoLock) ON Administrador_de_Observatorio.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as Reportero WITH(NoLock) ON Reportero.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos as Imagen WITH(NoLock) ON Imagen.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as Imagen_Miniatura WITH(NoLock) ON Imagen_Miniatura.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo as Estilo WITH(NoLock) ON Estilo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as Adjuntar_PDF WITH(NoLock) ON Adjuntar_PDF.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as Autorizado_por WITH(NoLock) ON Autorizado_por.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion as Autorizacion WITH(NoLock) ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio as Filtrar_Usuarios_por_Observatorio WITH(NoLock) ON Filtrar_Usuarios_por_Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)        " + swhere;
        return string.Format(this.fullQueryForExport,  fieldsWithAlias + " " + from,Order);
    }

    public DataSet SelAll(int startRowIndex, int maximumRows, string where, string Order)
    {
        DataSet ds;
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.Text;
        string sPagingTemplate = @"WITH ResultSet AS 
                          (SELECT 
                          ROW_NUMBER() OVER (ORDER BY {0}) as RowNumber,
                          {1} ) 
                            SELECT * FROM ResultSet 
                            WHERE RowNumber BETWEEN ({2}+1) and {2} + {3}";

       	swhere = where; 	string fieldsWithAlias = " Registro_de_Contenido.Folio As Registro_de_Contenido_Folio,        Registro_de_Contenido.Usuario_que_Registra AS Registro_de_Contenido_Usuario_que_Registra,        Usuario_que_Registra.Nombre AS Usuario_que_Registra_Nombre,        Registro_de_Contenido.Fecha_de_Registro As Registro_de_Contenido_Fecha_de_Registro,        Registro_de_Contenido.Hora_de_Registro As Registro_de_Contenido_Hora_de_Registro,        '' AS Registro_de_Contenido_Observatorio,        Registro_de_Contenido.Categoria AS Registro_de_Contenido_Categoria,        Categoria.Descripcion AS Categoria_Descripcion,        Registro_de_Contenido.Descripcion_de_Solicitud As Registro_de_Contenido_Descripcion_de_Solicitud,        Registro_de_Contenido.Reportero_Asignado AS Registro_de_Contenido_Reportero_Asignado,        Reportero_Asignado.Nombre AS Reportero_Asignado_Nombre,        Registro_de_Contenido.Fecha_de_Compromiso As Registro_de_Contenido_Fecha_de_Compromiso,        Registro_de_Contenido.Estatus AS Registro_de_Contenido_Estatus,        Estatus.Descripcion AS Estatus_Descripcion,        Registro_de_Contenido.Administrador_de_Observatorio AS Registro_de_Contenido_Administrador_de_Observatorio,        Administrador_de_Observatorio.Nombre AS Administrador_de_Observatorio_Nombre,        Registro_de_Contenido.Reportero AS Registro_de_Contenido_Reportero,        Reportero.Nombre AS Reportero_Nombre,        Registro_de_Contenido.Titulo As Registro_de_Contenido_Titulo,        Registro_de_Contenido.Descripcion As Registro_de_Contenido_Descripcion,        Registro_de_Contenido.Contenido As Registro_de_Contenido_Contenido,        Registro_de_Contenido.Imagen AS Registro_de_Contenido_Imagen,        Imagen.Nombre AS Imagen_Nombre,        Registro_de_Contenido.Imagen_Miniatura AS Registro_de_Contenido_Imagen_Miniatura,        Imagen_Miniatura.Nombre AS Imagen_Miniatura_Nombre,        Registro_de_Contenido.Estilo AS Registro_de_Contenido_Estilo,        Estilo.Descripcion AS Estilo_Descripcion,        Registro_de_Contenido.Adjuntar_PDF AS Registro_de_Contenido_Adjuntar_PDF,        Adjuntar_PDF.Nombre AS Adjuntar_PDF_Nombre,        Registro_de_Contenido.Captura_Terminada As Registro_de_Contenido_Captura_Terminada,        Registro_de_Contenido.Autorizado_por AS Registro_de_Contenido_Autorizado_por,        Autorizado_por.Nombre AS Autorizado_por_Nombre,        Registro_de_Contenido.Fecha_de_Revision As Registro_de_Contenido_Fecha_de_Revision,        Registro_de_Contenido.Hora_de_Revision As Registro_de_Contenido_Hora_de_Revision,        Registro_de_Contenido.Autorizacion AS Registro_de_Contenido_Autorizacion,        Autorizacion.Descripcion AS Autorizacion_Descripcion,        Registro_de_Contenido.Motivo_de_Rechazo As Registro_de_Contenido_Motivo_de_Rechazo,        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,        Registro_de_Contenido.Fecha_de_Termino As Registro_de_Contenido_Fecha_de_Termino,        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As Registro_de_Contenido_Seleccionar_Todos_los_Observatorios,        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,        Filtrar_Usuarios_por_Observatorio.Nombre AS Filtrar_Usuarios_por_Observatorio_Nombre ";         Order = (Order == string.Empty || Order == null ? "Registro_de_Contenido.Folio, Registro_de_Contenido.Usuario_que_Registra, Usuario_que_Registra.Nombre, Registro_de_Contenido.Fecha_de_Registro, Registro_de_Contenido.Hora_de_Registro, Registro_de_Contenido.Categoria, Categoria.Descripcion, Registro_de_Contenido.Descripcion_de_Solicitud, Registro_de_Contenido.Reportero_Asignado, Reportero_Asignado.Nombre, Registro_de_Contenido.Fecha_de_Compromiso, Registro_de_Contenido.Estatus, Estatus.Descripcion, Registro_de_Contenido.Administrador_de_Observatorio, Administrador_de_Observatorio.Nombre, Registro_de_Contenido.Reportero, Reportero.Nombre, Registro_de_Contenido.Titulo, Registro_de_Contenido.Descripcion, Registro_de_Contenido.Contenido, Registro_de_Contenido.Imagen, Imagen.Nombre, Registro_de_Contenido.Imagen_Miniatura, Imagen_Miniatura.Nombre, Registro_de_Contenido.Estilo, Estilo.Descripcion, Registro_de_Contenido.Adjuntar_PDF, Adjuntar_PDF.Nombre, Registro_de_Contenido.Captura_Terminada, Registro_de_Contenido.Autorizado_por, Autorizado_por.Nombre, Registro_de_Contenido.Fecha_de_Revision, Registro_de_Contenido.Hora_de_Revision, Registro_de_Contenido.Autorizacion, Autorizacion.Descripcion, Registro_de_Contenido.Motivo_de_Rechazo, Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion, Registro_de_Contenido.Fecha_de_Termino, Registro_de_Contenido.Seleccionar_Todos_los_Observatorios, Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio, Filtrar_Usuarios_por_Observatorio.Nombre" : Order);         string from = " from ((((((((((((( Registro_de_Contenido WITH(NoLock) LEFT JOIN TTUsuarios as Usuario_que_Registra WITH(NoLock) ON Usuario_que_Registra.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria as Categoria WITH(NoLock) ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as Reportero_Asignado WITH(NoLock) ON Reportero_Asignado.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido as Estatus WITH(NoLock) ON Estatus.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as Administrador_de_Observatorio WITH(NoLock) ON Administrador_de_Observatorio.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as Reportero WITH(NoLock) ON Reportero.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos as Imagen WITH(NoLock) ON Imagen.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as Imagen_Miniatura WITH(NoLock) ON Imagen_Miniatura.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo as Estilo WITH(NoLock) ON Estilo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as Adjuntar_PDF WITH(NoLock) ON Adjuntar_PDF.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as Autorizado_por WITH(NoLock) ON Autorizado_por.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion as Autorizacion WITH(NoLock) ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio as Filtrar_Usuarios_por_Observatorio WITH(NoLock) ON Filtrar_Usuarios_por_Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)        " + swhere;

        sPagingTemplate = string.Format(sPagingTemplate, Order, fieldsWithAlias + " " + from, startRowIndex, maximumRows);

        com.CommandText = sPagingTemplate;

        ds = db.Consulta(com);

        return ds;
    }

    public DataSet SelAll(string where, string Order)
    {
        DataSet ds;
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.Text;
        string sPagingTemplate = @"WITH ResultSet AS 
                          (SELECT 
                          ROW_NUMBER() OVER (ORDER BY {0}) as RowNumber,
                          {1} ) 
                            SELECT * FROM ResultSet 
                            ";

        	swhere = where; 	string fieldsWithAlias = " Registro_de_Contenido.Folio As Registro_de_Contenido_Folio,        Registro_de_Contenido.Usuario_que_Registra AS Registro_de_Contenido_Usuario_que_Registra,        Usuario_que_Registra.Nombre AS Usuario_que_Registra_Nombre,        Registro_de_Contenido.Fecha_de_Registro As Registro_de_Contenido_Fecha_de_Registro,        Registro_de_Contenido.Hora_de_Registro As Registro_de_Contenido_Hora_de_Registro,        '' AS Registro_de_Contenido_Observatorio,        Registro_de_Contenido.Categoria AS Registro_de_Contenido_Categoria,        Categoria.Descripcion AS Categoria_Descripcion,        Registro_de_Contenido.Descripcion_de_Solicitud As Registro_de_Contenido_Descripcion_de_Solicitud,        Registro_de_Contenido.Reportero_Asignado AS Registro_de_Contenido_Reportero_Asignado,        Reportero_Asignado.Nombre AS Reportero_Asignado_Nombre,        Registro_de_Contenido.Fecha_de_Compromiso As Registro_de_Contenido_Fecha_de_Compromiso,        Registro_de_Contenido.Estatus AS Registro_de_Contenido_Estatus,        Estatus.Descripcion AS Estatus_Descripcion,        Registro_de_Contenido.Administrador_de_Observatorio AS Registro_de_Contenido_Administrador_de_Observatorio,        Administrador_de_Observatorio.Nombre AS Administrador_de_Observatorio_Nombre,        Registro_de_Contenido.Reportero AS Registro_de_Contenido_Reportero,        Reportero.Nombre AS Reportero_Nombre,        Registro_de_Contenido.Titulo As Registro_de_Contenido_Titulo,        Registro_de_Contenido.Descripcion As Registro_de_Contenido_Descripcion,        Registro_de_Contenido.Contenido As Registro_de_Contenido_Contenido,        Registro_de_Contenido.Imagen AS Registro_de_Contenido_Imagen,        Imagen.Nombre AS Imagen_Nombre,        Registro_de_Contenido.Imagen_Miniatura AS Registro_de_Contenido_Imagen_Miniatura,        Imagen_Miniatura.Nombre AS Imagen_Miniatura_Nombre,        Registro_de_Contenido.Estilo AS Registro_de_Contenido_Estilo,        Estilo.Descripcion AS Estilo_Descripcion,        Registro_de_Contenido.Adjuntar_PDF AS Registro_de_Contenido_Adjuntar_PDF,        Adjuntar_PDF.Nombre AS Adjuntar_PDF_Nombre,        Registro_de_Contenido.Captura_Terminada As Registro_de_Contenido_Captura_Terminada,        Registro_de_Contenido.Autorizado_por AS Registro_de_Contenido_Autorizado_por,        Autorizado_por.Nombre AS Autorizado_por_Nombre,        Registro_de_Contenido.Fecha_de_Revision As Registro_de_Contenido_Fecha_de_Revision,        Registro_de_Contenido.Hora_de_Revision As Registro_de_Contenido_Hora_de_Revision,        Registro_de_Contenido.Autorizacion AS Registro_de_Contenido_Autorizacion,        Autorizacion.Descripcion AS Autorizacion_Descripcion,        Registro_de_Contenido.Motivo_de_Rechazo As Registro_de_Contenido_Motivo_de_Rechazo,        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,        Registro_de_Contenido.Fecha_de_Termino As Registro_de_Contenido_Fecha_de_Termino,        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As Registro_de_Contenido_Seleccionar_Todos_los_Observatorios,        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,        Filtrar_Usuarios_por_Observatorio.Nombre AS Filtrar_Usuarios_por_Observatorio_Nombre ";         Order = (Order == string.Empty || Order == null ? "Registro_de_Contenido.Folio, Registro_de_Contenido.Usuario_que_Registra, Usuario_que_Registra.Nombre, Registro_de_Contenido.Fecha_de_Registro, Registro_de_Contenido.Hora_de_Registro, Registro_de_Contenido.Categoria, Categoria.Descripcion, Registro_de_Contenido.Descripcion_de_Solicitud, Registro_de_Contenido.Reportero_Asignado, Reportero_Asignado.Nombre, Registro_de_Contenido.Fecha_de_Compromiso, Registro_de_Contenido.Estatus, Estatus.Descripcion, Registro_de_Contenido.Administrador_de_Observatorio, Administrador_de_Observatorio.Nombre, Registro_de_Contenido.Reportero, Reportero.Nombre, Registro_de_Contenido.Titulo, Registro_de_Contenido.Descripcion, Registro_de_Contenido.Contenido, Registro_de_Contenido.Imagen, Imagen.Nombre, Registro_de_Contenido.Imagen_Miniatura, Imagen_Miniatura.Nombre, Registro_de_Contenido.Estilo, Estilo.Descripcion, Registro_de_Contenido.Adjuntar_PDF, Adjuntar_PDF.Nombre, Registro_de_Contenido.Captura_Terminada, Registro_de_Contenido.Autorizado_por, Autorizado_por.Nombre, Registro_de_Contenido.Fecha_de_Revision, Registro_de_Contenido.Hora_de_Revision, Registro_de_Contenido.Autorizacion, Autorizacion.Descripcion, Registro_de_Contenido.Motivo_de_Rechazo, Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion, Registro_de_Contenido.Fecha_de_Termino, Registro_de_Contenido.Seleccionar_Todos_los_Observatorios, Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio, Filtrar_Usuarios_por_Observatorio.Nombre" : Order);         string from = " from ((((((((((((( Registro_de_Contenido WITH(NoLock) LEFT JOIN TTUsuarios as Usuario_que_Registra WITH(NoLock) ON Usuario_que_Registra.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria as Categoria WITH(NoLock) ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as Reportero_Asignado WITH(NoLock) ON Reportero_Asignado.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido as Estatus WITH(NoLock) ON Estatus.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as Administrador_de_Observatorio WITH(NoLock) ON Administrador_de_Observatorio.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as Reportero WITH(NoLock) ON Reportero.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos as Imagen WITH(NoLock) ON Imagen.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as Imagen_Miniatura WITH(NoLock) ON Imagen_Miniatura.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo as Estilo WITH(NoLock) ON Estilo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as Adjuntar_PDF WITH(NoLock) ON Adjuntar_PDF.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as Autorizado_por WITH(NoLock) ON Autorizado_por.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion as Autorizacion WITH(NoLock) ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio as Filtrar_Usuarios_por_Observatorio WITH(NoLock) ON Filtrar_Usuarios_por_Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)        " + swhere;

        sPagingTemplate = string.Format(sPagingTemplate, Order, fieldsWithAlias + " " + from);

        com.CommandText = sPagingTemplate;

        ds = db.Consulta(com);

        return ds;
    }

    public int SelCount(string where)
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.Text;
        string sPagingTemplate = @"SELECT COUNT(*) {0}" ;
        string Order="";
        	swhere = where; 	string fieldsWithAlias = " Registro_de_Contenido.Folio As Registro_de_Contenido_Folio,        Registro_de_Contenido.Usuario_que_Registra AS Registro_de_Contenido_Usuario_que_Registra,        Usuario_que_Registra.Nombre AS Usuario_que_Registra_Nombre,        Registro_de_Contenido.Fecha_de_Registro As Registro_de_Contenido_Fecha_de_Registro,        Registro_de_Contenido.Hora_de_Registro As Registro_de_Contenido_Hora_de_Registro,        '' AS Registro_de_Contenido_Observatorio,        Registro_de_Contenido.Categoria AS Registro_de_Contenido_Categoria,        Categoria.Descripcion AS Categoria_Descripcion,        Registro_de_Contenido.Descripcion_de_Solicitud As Registro_de_Contenido_Descripcion_de_Solicitud,        Registro_de_Contenido.Reportero_Asignado AS Registro_de_Contenido_Reportero_Asignado,        Reportero_Asignado.Nombre AS Reportero_Asignado_Nombre,        Registro_de_Contenido.Fecha_de_Compromiso As Registro_de_Contenido_Fecha_de_Compromiso,        Registro_de_Contenido.Estatus AS Registro_de_Contenido_Estatus,        Estatus.Descripcion AS Estatus_Descripcion,        Registro_de_Contenido.Administrador_de_Observatorio AS Registro_de_Contenido_Administrador_de_Observatorio,        Administrador_de_Observatorio.Nombre AS Administrador_de_Observatorio_Nombre,        Registro_de_Contenido.Reportero AS Registro_de_Contenido_Reportero,        Reportero.Nombre AS Reportero_Nombre,        Registro_de_Contenido.Titulo As Registro_de_Contenido_Titulo,        Registro_de_Contenido.Descripcion As Registro_de_Contenido_Descripcion,        Registro_de_Contenido.Contenido As Registro_de_Contenido_Contenido,        Registro_de_Contenido.Imagen AS Registro_de_Contenido_Imagen,        Imagen.Nombre AS Imagen_Nombre,        Registro_de_Contenido.Imagen_Miniatura AS Registro_de_Contenido_Imagen_Miniatura,        Imagen_Miniatura.Nombre AS Imagen_Miniatura_Nombre,        Registro_de_Contenido.Estilo AS Registro_de_Contenido_Estilo,        Estilo.Descripcion AS Estilo_Descripcion,        Registro_de_Contenido.Adjuntar_PDF AS Registro_de_Contenido_Adjuntar_PDF,        Adjuntar_PDF.Nombre AS Adjuntar_PDF_Nombre,        Registro_de_Contenido.Captura_Terminada As Registro_de_Contenido_Captura_Terminada,        Registro_de_Contenido.Autorizado_por AS Registro_de_Contenido_Autorizado_por,        Autorizado_por.Nombre AS Autorizado_por_Nombre,        Registro_de_Contenido.Fecha_de_Revision As Registro_de_Contenido_Fecha_de_Revision,        Registro_de_Contenido.Hora_de_Revision As Registro_de_Contenido_Hora_de_Revision,        Registro_de_Contenido.Autorizacion AS Registro_de_Contenido_Autorizacion,        Autorizacion.Descripcion AS Autorizacion_Descripcion,        Registro_de_Contenido.Motivo_de_Rechazo As Registro_de_Contenido_Motivo_de_Rechazo,        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,        Registro_de_Contenido.Fecha_de_Termino As Registro_de_Contenido_Fecha_de_Termino,        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As Registro_de_Contenido_Seleccionar_Todos_los_Observatorios,        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,        Filtrar_Usuarios_por_Observatorio.Nombre AS Filtrar_Usuarios_por_Observatorio_Nombre ";         Order = (Order == string.Empty || Order == null ? "Registro_de_Contenido.Folio, Registro_de_Contenido.Usuario_que_Registra, Usuario_que_Registra.Nombre, Registro_de_Contenido.Fecha_de_Registro, Registro_de_Contenido.Hora_de_Registro, Registro_de_Contenido.Categoria, Categoria.Descripcion, Registro_de_Contenido.Descripcion_de_Solicitud, Registro_de_Contenido.Reportero_Asignado, Reportero_Asignado.Nombre, Registro_de_Contenido.Fecha_de_Compromiso, Registro_de_Contenido.Estatus, Estatus.Descripcion, Registro_de_Contenido.Administrador_de_Observatorio, Administrador_de_Observatorio.Nombre, Registro_de_Contenido.Reportero, Reportero.Nombre, Registro_de_Contenido.Titulo, Registro_de_Contenido.Descripcion, Registro_de_Contenido.Contenido, Registro_de_Contenido.Imagen, Imagen.Nombre, Registro_de_Contenido.Imagen_Miniatura, Imagen_Miniatura.Nombre, Registro_de_Contenido.Estilo, Estilo.Descripcion, Registro_de_Contenido.Adjuntar_PDF, Adjuntar_PDF.Nombre, Registro_de_Contenido.Captura_Terminada, Registro_de_Contenido.Autorizado_por, Autorizado_por.Nombre, Registro_de_Contenido.Fecha_de_Revision, Registro_de_Contenido.Hora_de_Revision, Registro_de_Contenido.Autorizacion, Autorizacion.Descripcion, Registro_de_Contenido.Motivo_de_Rechazo, Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion, Registro_de_Contenido.Fecha_de_Termino, Registro_de_Contenido.Seleccionar_Todos_los_Observatorios, Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio, Filtrar_Usuarios_por_Observatorio.Nombre" : Order);         string from = " from ((((((((((((( Registro_de_Contenido WITH(NoLock) LEFT JOIN TTUsuarios as Usuario_que_Registra WITH(NoLock) ON Usuario_que_Registra.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria as Categoria WITH(NoLock) ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as Reportero_Asignado WITH(NoLock) ON Reportero_Asignado.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido as Estatus WITH(NoLock) ON Estatus.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as Administrador_de_Observatorio WITH(NoLock) ON Administrador_de_Observatorio.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as Reportero WITH(NoLock) ON Reportero.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos as Imagen WITH(NoLock) ON Imagen.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as Imagen_Miniatura WITH(NoLock) ON Imagen_Miniatura.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo as Estilo WITH(NoLock) ON Estilo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as Adjuntar_PDF WITH(NoLock) ON Adjuntar_PDF.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as Autorizado_por WITH(NoLock) ON Autorizado_por.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion as Autorizacion WITH(NoLock) ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio as Filtrar_Usuarios_por_Observatorio WITH(NoLock) ON Filtrar_Usuarios_por_Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)        " + swhere;

        sPagingTemplate = string.Format(sPagingTemplate, from);

        com.CommandText = sPagingTemplate;

        return (int)db.ExecuteScalar(com);
   }
    //------------------------------------------------------------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------------------------------------------------------------------------------
    public DataTable SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        DataSet ds;
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        String sOrderBy = "";
        String swhere="";
        if (this.myFilters!=null)
            foreach (ControlsLibrary.objectBussinessTTFiltro fil in this.myFilters)
            {
                String sWhereT = fil.GenerateWhereWithOutLeftJoin(null);
                if (sWhereT != "")
                    if (swhere == "")
                        swhere = sWhereT;
                    else
                        swhere += " and " + sWhereT;
            }
        if (this.myConfigurationColumns != null)
            foreach (ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn fil in this.myConfigurationColumns)
                if (sOrderBy == "")
                    sOrderBy += fil.GenerateOrderBy();
                //else
                    //sOrderBy += "," + fil.GenerateOrderBy();
        if (this.myFiltersObligatories != null)
            foreach (ControlsLibrary.objectBussinessTTFiltro fil in this.myFiltersObligatories)
            {
                String sWhereT = fil.GenerateWhereWithOutLeftJoin(null);
                if (sWhereT != "")
                    if (swhere == "")
                        swhere = sWhereT;
                    else
                        swhere += " and " + sWhereT;
            }
        if (this.myConfigurationColumnsObligatories != null)
            foreach (ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn fil in this.myConfigurationColumnsObligatories)
                if (sOrderBy=="")
                    sOrderBy += fil.GenerateOrderBy();
                //else
                    //sOrderBy += ","+fil.GenerateOrderBy();
        if (this.myFiltersQuick != null)
            if (swhere == "")
                swhere += this.myFiltersQuick.GenerateWhereWithOutLeftJoin(null);
            else
                swhere += " and " + this.myFiltersQuick.GenerateWhereWithOutLeftJoin(null);
        if (swhere.Length >= 4)
            if (swhere.Substring(swhere.Length - 4) == "and ")
                swhere = swhere.Substring(0, swhere.Length - 4);



        if (ConRelaciones ==true)
            if (swhere != "")
            {
                com.Parameters.AddWithValue("@Filter"," where " + swhere);
                com.CommandText = "sp_SelAllComplete_Registro_de_Contenido_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_Registro_de_Contenido";
        else
            com.CommandText="sp_SelAllRegistro_de_Contenido";
            ds = db.Consulta(com);

        swhere = "";

            if (this.filters !=null)
                foreach (Registro_de_ContenidoCS.Registro_de_ContenidoFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Registro_de_Contenido", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("Registro_de_Contenido", fil);
                    if (sOrderByT != "")
                        sOrderBy = sOrderByT;
                }
        if (swhere != "")
            swhere = swhere.Substring(4);
        if (varOrderClickHeaderCell!="")
        {
            if (varOrderClickHeaderCellType !=" Desc")
                sOrderBy = varOrderClickHeaderCell + " Asc";
            else
                sOrderBy = varOrderClickHeaderCell + " Desc";
        }
        return Function.SelectDataTable(ds.Tables[0], swhere, sOrderBy, CurrentRecordInt32, RecordsDisplayedInt32);
    }

    private String Convierte(String Valor,Int32 Convierte){
        String ValorConvertido = "";
        if (Convierte == 1)
        {
                ValorConvertido = Valor.ToUpper();
        }else{
                ValorConvertido = Valor;
        }
        return ValorConvertido;
    }

    public void Insert(TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
        TTDataLayerCS.BD db =new TTDataLayerCS.BD();

        SqlCommand coma = new SqlCommand("Select Conversion_a_Mayusculas from ttConfiguracionProyecto");
        coma.CommandType = CommandType.Text;
        DataSet dsa = db.Consulta(coma);
        Int32 ConvierteAMayusculas = Int32.Parse(dsa.Tables[0].Rows[0].ItemArray[0].ToString());

        db.BeginTransaction("Registro_de_Contenido");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsRegistro_de_Contenido";
            com.Parameters.AddWithValue("@Usuario_que_Registra",Conversion.FormatNull(varUsuario_que_Registra));
            com.Parameters.AddWithValue("@Fecha_de_Registro",Conversion.FormatNull(varFecha_de_Registro));
            if (varHora_de_Registro!=null)
                com.Parameters.AddWithValue("@Hora_de_Registro",varHora_de_Registro);
            else
                com.Parameters.AddWithValue("@Hora_de_Registro", DBNull.Value);
            com.Parameters.AddWithValue("@Categoria",Conversion.FormatNull(varCategoria));
            if (varDescripcion_de_Solicitud!=null)
            {
                if (varDescripcion_de_Solicitud != "")
                    com.Parameters.AddWithValue("@Descripcion_de_Solicitud", Convierte(varDescripcion_de_Solicitud, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Descripcion_de_Solicitud", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Descripcion_de_Solicitud", DBNull.Value);
            }            com.Parameters.AddWithValue("@Reportero_Asignado",Conversion.FormatNull(varReportero_Asignado));
            com.Parameters.AddWithValue("@Fecha_de_Compromiso",Conversion.FormatNull(varFecha_de_Compromiso));
            com.Parameters.AddWithValue("@Estatus",Conversion.FormatNull(varEstatus));
            com.Parameters.AddWithValue("@Administrador_de_Observatorio",Conversion.FormatNull(varAdministrador_de_Observatorio));
            com.Parameters.AddWithValue("@Reportero",Conversion.FormatNull(varReportero));
            if (varTitulo!=null)
            {
                if (varTitulo != "")
                    com.Parameters.AddWithValue("@Titulo", Convierte(varTitulo, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Titulo", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Titulo", DBNull.Value);
            }            if (varDescripcion!=null)
            {
                if (varDescripcion != "")
                    com.Parameters.AddWithValue("@Descripcion", Convierte(varDescripcion, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Descripcion", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Descripcion", DBNull.Value);
            }            if (varContenido!=null)
            {
                if (varContenido != "")
                    com.Parameters.AddWithValue("@Contenido", Convierte(varContenido, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Contenido", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Contenido", DBNull.Value);
            }            com.Parameters.AddWithValue("@Imagen",Conversion.FormatNull(varImagen));
            com.Parameters.AddWithValue("@Imagen_Miniatura",Conversion.FormatNull(varImagen_Miniatura));
            com.Parameters.AddWithValue("@Estilo",Conversion.FormatNull(varEstilo));
            com.Parameters.AddWithValue("@Adjuntar_PDF",Conversion.FormatNull(varAdjuntar_PDF));
            com.Parameters.AddWithValue("@Captura_Terminada", varCaptura_Terminada);
            com.Parameters.AddWithValue("@Autorizado_por",Conversion.FormatNull(varAutorizado_por));
            com.Parameters.AddWithValue("@Fecha_de_Revision",Conversion.FormatNull(varFecha_de_Revision));
            if (varHora_de_Revision!=null)
                com.Parameters.AddWithValue("@Hora_de_Revision",varHora_de_Revision);
            else
                com.Parameters.AddWithValue("@Hora_de_Revision", DBNull.Value);
            com.Parameters.AddWithValue("@Autorizacion",Conversion.FormatNull(varAutorizacion));
            if (varMotivo_de_Rechazo!=null)
            {
                if (varMotivo_de_Rechazo != "")
                    com.Parameters.AddWithValue("@Motivo_de_Rechazo", Convierte(varMotivo_de_Rechazo, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Motivo_de_Rechazo", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Motivo_de_Rechazo", DBNull.Value);
            }            com.Parameters.AddWithValue("@Fecha_de_Inicio_de_Publicacion",Conversion.FormatNull(varFecha_de_Inicio_de_Publicacion));
            com.Parameters.AddWithValue("@Fecha_de_Termino",Conversion.FormatNull(varFecha_de_Termino));
            com.Parameters.AddWithValue("@Seleccionar_Todos_los_Observatorios", varSeleccionar_Todos_los_Observatorios);
            com.Parameters.AddWithValue("@Filtrar_Usuarios_por_Observatorio",Conversion.FormatNull(varFiltrar_Usuarios_por_Observatorio));

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varFolio = sKeyFolio;
            
            if(varEtiquetas != null)
            {
                for (int i = 0;i< varEtiquetas.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsDetalle_de_Etiquetas";
                    com.Parameters.AddWithValue("@Articulo", sKeyFolio);
                com.Parameters.AddWithValue("@Etiqueta", Conversion.FormatNull(varEtiquetas[i].Etiqueta));

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
            }
            if(varFuentes != null)
            {
                for (int i = 0;i< varFuentes.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsFuentes";
                    com.Parameters.AddWithValue("@Articulo", sKeyFolio);
            if (varFuentes[i].Fuente!=null)
            {
                if (varFuentes[i].Fuente != "")
                    com.Parameters.AddWithValue("@Fuente", Convierte(varFuentes[i].Fuente, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Fuente", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Fuente", DBNull.Value);
            }
                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
            }
            if(varNotificaciones_por_Observatorios != null)
            {
                for (int i = 0;i< varNotificaciones_por_Observatorios.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsDetalle_de_Notificacion_por_Observatorio";
                    com.Parameters.AddWithValue("@Contenido", sKeyFolio);
                com.Parameters.AddWithValue("@Notificar", varNotificaciones_por_Observatorios[i].Notificar);
                com.Parameters.AddWithValue("@Observatorio", Conversion.FormatNull(varNotificaciones_por_Observatorios[i].Observatorio));

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
            }
            if(varNotificaciones_por_Usuario != null)
            {
                for (int i = 0;i< varNotificaciones_por_Usuario.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsDetalle_de_Notificacion_por_Usuario";
                    com.Parameters.AddWithValue("@Contenido", sKeyFolio);
                com.Parameters.AddWithValue("@Notificar", varNotificaciones_por_Usuario[i].Notificar);
                com.Parameters.AddWithValue("@Observatorio", Conversion.FormatNull(varNotificaciones_por_Usuario[i].Observatorio));
                com.Parameters.AddWithValue("@ID_del_Cliente", Conversion.FormatNull(varNotificaciones_por_Usuario[i].ID_del_Cliente));
            if (varNotificaciones_por_Usuario[i].Nombre!=null)
            {
                if (varNotificaciones_por_Usuario[i].Nombre != "")
                    com.Parameters.AddWithValue("@Nombre", Convierte(varNotificaciones_por_Usuario[i].Nombre, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Nombre", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Nombre", DBNull.Value);
            }
                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
            }

            if(varObservatorio != null)
            {
                for (int i = 0;i< varObservatorio.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsMS_Observatorios";
                    com.Parameters.AddWithValue("@Clave", sKeyFolio);
                    com.Parameters.AddWithValue("@Observatorio", varObservatorio[i].Observatorio );
//@@DatosDT.ParametrosInsertListBox@@
                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
            }

            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("Registro_de_Contenido");
            }
            catch{}
            throw ex; 
        }
        //return sKey;
    }
    
    public object InsertWithReturnValue(TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
        TTDataLayerCS.BD db =new TTDataLayerCS.BD();

        SqlCommand coma = new SqlCommand("Select Conversion_a_Mayusculas from ttConfiguracionProyecto");
        coma.CommandType = CommandType.Text;
        DataSet dsa = db.Consulta(coma);
        Int32 ConvierteAMayusculas = Int32.Parse(dsa.Tables[0].Rows[0].ItemArray[0].ToString());

        db.BeginTransaction("Registro_de_Contenido");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsRegistro_de_Contenido";
            com.Parameters.AddWithValue("@Usuario_que_Registra",Conversion.FormatNull(varUsuario_que_Registra));
            com.Parameters.AddWithValue("@Fecha_de_Registro",Conversion.FormatNull(varFecha_de_Registro));
            if (varHora_de_Registro!=null)
                com.Parameters.AddWithValue("@Hora_de_Registro",varHora_de_Registro);
            else
                com.Parameters.AddWithValue("@Hora_de_Registro", DBNull.Value);
            com.Parameters.AddWithValue("@Categoria",Conversion.FormatNull(varCategoria));
            if (varDescripcion_de_Solicitud!=null)
            {
                if (varDescripcion_de_Solicitud != "")
                    com.Parameters.AddWithValue("@Descripcion_de_Solicitud", Convierte(varDescripcion_de_Solicitud, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Descripcion_de_Solicitud", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Descripcion_de_Solicitud", DBNull.Value);
            }            com.Parameters.AddWithValue("@Reportero_Asignado",Conversion.FormatNull(varReportero_Asignado));
            com.Parameters.AddWithValue("@Fecha_de_Compromiso",Conversion.FormatNull(varFecha_de_Compromiso));
            com.Parameters.AddWithValue("@Estatus",Conversion.FormatNull(varEstatus));
            com.Parameters.AddWithValue("@Administrador_de_Observatorio",Conversion.FormatNull(varAdministrador_de_Observatorio));
            com.Parameters.AddWithValue("@Reportero",Conversion.FormatNull(varReportero));
            if (varTitulo!=null)
            {
                if (varTitulo != "")
                    com.Parameters.AddWithValue("@Titulo", Convierte(varTitulo, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Titulo", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Titulo", DBNull.Value);
            }            if (varDescripcion!=null)
            {
                if (varDescripcion != "")
                    com.Parameters.AddWithValue("@Descripcion", Convierte(varDescripcion, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Descripcion", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Descripcion", DBNull.Value);
            }            if (varContenido!=null)
            {
                if (varContenido != "")
                    com.Parameters.AddWithValue("@Contenido", Convierte(varContenido, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Contenido", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Contenido", DBNull.Value);
            }            com.Parameters.AddWithValue("@Imagen",Conversion.FormatNull(varImagen));
            com.Parameters.AddWithValue("@Imagen_Miniatura",Conversion.FormatNull(varImagen_Miniatura));
            com.Parameters.AddWithValue("@Estilo",Conversion.FormatNull(varEstilo));
            com.Parameters.AddWithValue("@Adjuntar_PDF",Conversion.FormatNull(varAdjuntar_PDF));
            com.Parameters.AddWithValue("@Captura_Terminada", varCaptura_Terminada);
            com.Parameters.AddWithValue("@Autorizado_por",Conversion.FormatNull(varAutorizado_por));
            com.Parameters.AddWithValue("@Fecha_de_Revision",Conversion.FormatNull(varFecha_de_Revision));
            if (varHora_de_Revision!=null)
                com.Parameters.AddWithValue("@Hora_de_Revision",varHora_de_Revision);
            else
                com.Parameters.AddWithValue("@Hora_de_Revision", DBNull.Value);
            com.Parameters.AddWithValue("@Autorizacion",Conversion.FormatNull(varAutorizacion));
            if (varMotivo_de_Rechazo!=null)
            {
                if (varMotivo_de_Rechazo != "")
                    com.Parameters.AddWithValue("@Motivo_de_Rechazo", Convierte(varMotivo_de_Rechazo, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Motivo_de_Rechazo", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Motivo_de_Rechazo", DBNull.Value);
            }            com.Parameters.AddWithValue("@Fecha_de_Inicio_de_Publicacion",Conversion.FormatNull(varFecha_de_Inicio_de_Publicacion));
            com.Parameters.AddWithValue("@Fecha_de_Termino",Conversion.FormatNull(varFecha_de_Termino));
            com.Parameters.AddWithValue("@Seleccionar_Todos_los_Observatorios", varSeleccionar_Todos_los_Observatorios);
            com.Parameters.AddWithValue("@Filtrar_Usuarios_por_Observatorio",Conversion.FormatNull(varFiltrar_Usuarios_por_Observatorio));

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varFolio = sKeyFolio;
            
            if(varEtiquetas != null)
            {
                for (int i = 0;i< varEtiquetas.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsDetalle_de_Etiquetas";
                    com.Parameters.AddWithValue("@Articulo", sKeyFolio);
                com.Parameters.AddWithValue("@Etiqueta", Conversion.FormatNull(varEtiquetas[i].Etiqueta));

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
            }
            if(varFuentes != null)
            {
                for (int i = 0;i< varFuentes.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsFuentes";
                    com.Parameters.AddWithValue("@Articulo", sKeyFolio);
            if (varFuentes[i].Fuente!=null)
            {
                if (varFuentes[i].Fuente != "")
                    com.Parameters.AddWithValue("@Fuente", Convierte(varFuentes[i].Fuente, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Fuente", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Fuente", DBNull.Value);
            }
                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
            }
            if(varNotificaciones_por_Observatorios != null)
            {
                for (int i = 0;i< varNotificaciones_por_Observatorios.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsDetalle_de_Notificacion_por_Observatorio";
                    com.Parameters.AddWithValue("@Contenido", sKeyFolio);
                com.Parameters.AddWithValue("@Notificar", varNotificaciones_por_Observatorios[i].Notificar);
                com.Parameters.AddWithValue("@Observatorio", Conversion.FormatNull(varNotificaciones_por_Observatorios[i].Observatorio));

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
            }
            if(varNotificaciones_por_Usuario != null)
            {
                for (int i = 0;i< varNotificaciones_por_Usuario.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsDetalle_de_Notificacion_por_Usuario";
                    com.Parameters.AddWithValue("@Contenido", sKeyFolio);
                com.Parameters.AddWithValue("@Notificar", varNotificaciones_por_Usuario[i].Notificar);
                com.Parameters.AddWithValue("@Observatorio", Conversion.FormatNull(varNotificaciones_por_Usuario[i].Observatorio));
                com.Parameters.AddWithValue("@ID_del_Cliente", Conversion.FormatNull(varNotificaciones_por_Usuario[i].ID_del_Cliente));
            if (varNotificaciones_por_Usuario[i].Nombre!=null)
            {
                if (varNotificaciones_por_Usuario[i].Nombre != "")
                    com.Parameters.AddWithValue("@Nombre", Convierte(varNotificaciones_por_Usuario[i].Nombre, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Nombre", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Nombre", DBNull.Value);
            }
                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
            }

            if(varObservatorio != null)
            {
                for (int i = 0;i< varObservatorio.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsMS_Observatorios";
                    com.Parameters.AddWithValue("@Clave", sKeyFolio);
                    com.Parameters.AddWithValue("@Observatorio", varObservatorio[i].Observatorio );
//@@DatosDT.ParametrosInsertListBox@@
                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
            }

            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("Registro_de_Contenido");
            }
            catch{}
            throw ex; 
        }
        return sKeyFolio;
    }
    
    public void Update(TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
        TTDataLayerCS.BD db =new TTDataLayerCS.BD();

        SqlCommand coma = new SqlCommand("Select Conversion_a_Mayusculas from ttConfiguracionProyecto");
        coma.CommandType = CommandType.Text;
        DataSet dsa = db.Consulta(coma);
        Int32 ConvierteAMayusculas = Int32.Parse(dsa.Tables[0].Rows[0].ItemArray[0].ToString());

        db.BeginTransaction("Registro_de_Contenido");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_UpdRegistro_de_Contenido";
            com.Parameters.AddWithValue("@Folio",Conversion.FormatNull(varFolio));
            com.Parameters.AddWithValue("@Usuario_que_Registra",Conversion.FormatNull(varUsuario_que_Registra));
            com.Parameters.AddWithValue("@Fecha_de_Registro",Conversion.FormatNull(varFecha_de_Registro));
            if (varHora_de_Registro!=null)
                com.Parameters.AddWithValue("@Hora_de_Registro", varHora_de_Registro);
            else
                com.Parameters.AddWithValue("@Hora_de_Registro", DBNull.Value);
            com.Parameters.AddWithValue("@Categoria",Conversion.FormatNull(varCategoria));
            if (varDescripcion_de_Solicitud!=null)
            {
                if (varDescripcion_de_Solicitud != "")
                    com.Parameters.AddWithValue("@Descripcion_de_Solicitud", Convierte(varDescripcion_de_Solicitud, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Descripcion_de_Solicitud", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Descripcion_de_Solicitud", DBNull.Value);
            }            com.Parameters.AddWithValue("@Reportero_Asignado",Conversion.FormatNull(varReportero_Asignado));
            com.Parameters.AddWithValue("@Fecha_de_Compromiso",Conversion.FormatNull(varFecha_de_Compromiso));
            com.Parameters.AddWithValue("@Estatus",Conversion.FormatNull(varEstatus));
            com.Parameters.AddWithValue("@Administrador_de_Observatorio",Conversion.FormatNull(varAdministrador_de_Observatorio));
            com.Parameters.AddWithValue("@Reportero",Conversion.FormatNull(varReportero));
            if (varTitulo!=null)
            {
                if (varTitulo != "")
                    com.Parameters.AddWithValue("@Titulo", Convierte(varTitulo, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Titulo", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Titulo", DBNull.Value);
            }            if (varDescripcion!=null)
            {
                if (varDescripcion != "")
                    com.Parameters.AddWithValue("@Descripcion", Convierte(varDescripcion, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Descripcion", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Descripcion", DBNull.Value);
            }            if (varContenido!=null)
            {
                if (varContenido != "")
                    com.Parameters.AddWithValue("@Contenido", Convierte(varContenido, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Contenido", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Contenido", DBNull.Value);
            }            com.Parameters.AddWithValue("@Imagen",Conversion.FormatNull(varImagen));
            com.Parameters.AddWithValue("@Imagen_Miniatura",Conversion.FormatNull(varImagen_Miniatura));
            com.Parameters.AddWithValue("@Estilo",Conversion.FormatNull(varEstilo));
            com.Parameters.AddWithValue("@Adjuntar_PDF",Conversion.FormatNull(varAdjuntar_PDF));
            com.Parameters.AddWithValue("@Captura_Terminada", varCaptura_Terminada);
            com.Parameters.AddWithValue("@Autorizado_por",Conversion.FormatNull(varAutorizado_por));
            com.Parameters.AddWithValue("@Fecha_de_Revision",Conversion.FormatNull(varFecha_de_Revision));
            if (varHora_de_Revision!=null)
                com.Parameters.AddWithValue("@Hora_de_Revision", varHora_de_Revision);
            else
                com.Parameters.AddWithValue("@Hora_de_Revision", DBNull.Value);
            com.Parameters.AddWithValue("@Autorizacion",Conversion.FormatNull(varAutorizacion));
            if (varMotivo_de_Rechazo!=null)
            {
                if (varMotivo_de_Rechazo != "")
                    com.Parameters.AddWithValue("@Motivo_de_Rechazo", Convierte(varMotivo_de_Rechazo, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Motivo_de_Rechazo", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Motivo_de_Rechazo", DBNull.Value);
            }            com.Parameters.AddWithValue("@Fecha_de_Inicio_de_Publicacion",Conversion.FormatNull(varFecha_de_Inicio_de_Publicacion));
            com.Parameters.AddWithValue("@Fecha_de_Termino",Conversion.FormatNull(varFecha_de_Termino));
            com.Parameters.AddWithValue("@Seleccionar_Todos_los_Observatorios", varSeleccionar_Todos_los_Observatorios);
            com.Parameters.AddWithValue("@Filtrar_Usuarios_por_Observatorio",Conversion.FormatNull(varFiltrar_Usuarios_por_Observatorio));

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaUpdate(com, UserInformation, DataReference));
//            varFolio = sKeyFolio;
        //TODO Falta Saber como borrar los campos
        {
            DataReference.Folio = sKeyFolio.ToString();
            TTDataLayerCS.BD dbMulti = new TTDataLayerCS.BD();
            DataTable drs = dbMulti.Consulta(new SqlCommand("Select Clave from Detalle_de_Etiquetas Where Articulo = '" + sKeyFolio.ToString() + "'")).Tables[0];
            System.Collections.ArrayList arrRegistry = new System.Collections.ArrayList();
            if(varEtiquetas != null)
            {
                for (int i = 0;i< varEtiquetas.Length; i++)
                {
                    Boolean existe = false;
                    foreach(DataRow dr in drs.Rows)
                    {
                        if (varEtiquetas[i].Clave.ToString() == dr[0].ToString())
                        {
                            existe = true;
                            break;
                        }
                    }
                    com = new SqlCommand();
                    com.Parameters.AddWithValue("@Articulo", sKeyFolio);
                com.Parameters.AddWithValue("@Etiqueta", Conversion.FormatNull(varEtiquetas[i].Etiqueta));

                    com.CommandType = CommandType.StoredProcedure;
                    if (!existe) //Insert 
                    {
                        com.CommandText = "sp_InsDetalle_de_Etiquetas";
                        arrRegistry.Add(db.EjecutaInsert(com, UserInformation, DataReference));
                    }
                    else
                    {
                        com.CommandText = "sp_UpdDetalle_de_Etiquetas";
                        com.Parameters.AddWithValue("@Clave", varEtiquetas[i].Clave);
                        db.EjecutaInsert(com, UserInformation, DataReference);
                        arrRegistry.Add(varEtiquetas[i].Clave);
                    }
                }
            }
            //Borrar los registro que estan de mas
            String FiltroDelete = "";
            foreach (DataRow dr in drs.Rows )
            {
                Boolean existe = false;
                foreach( object arr in arrRegistry)
                if (arr.ToString() == dr[0].ToString())
                {
                    existe = true;
                    break;
                }
            if (!existe)
                FiltroDelete += ", '" + dr[0].ToString() + "'";
            }
            if (FiltroDelete != "")
            {
                FiltroDelete =" Where Clave in (" + FiltroDelete.Substring(2) + ")";
                db.EjecutaDelete(new SqlCommand("Delete from Detalle_de_Etiquetas " + FiltroDelete), UserInformation, DataReference);
            }
        }
        //TODO Falta Saber como borrar los campos
        {
            DataReference.Folio = sKeyFolio.ToString();
            TTDataLayerCS.BD dbMulti = new TTDataLayerCS.BD();
            DataTable drs = dbMulti.Consulta(new SqlCommand("Select Clave from Fuentes Where Articulo = '" + sKeyFolio.ToString() + "'")).Tables[0];
            System.Collections.ArrayList arrRegistry = new System.Collections.ArrayList();
            if(varFuentes != null)
            {
                for (int i = 0;i< varFuentes.Length; i++)
                {
                    Boolean existe = false;
                    foreach(DataRow dr in drs.Rows)
                    {
                        if (varFuentes[i].Clave.ToString() == dr[0].ToString())
                        {
                            existe = true;
                            break;
                        }
                    }
                    com = new SqlCommand();
                    com.Parameters.AddWithValue("@Articulo", sKeyFolio);
            if (varFuentes[i].Fuente!=null)
            {
                if (varFuentes[i].Fuente != "")
                    com.Parameters.AddWithValue("@Fuente", Convierte(varFuentes[i].Fuente, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Fuente", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Fuente", DBNull.Value);
            }
                    com.CommandType = CommandType.StoredProcedure;
                    if (!existe) //Insert 
                    {
                        com.CommandText = "sp_InsFuentes";
                        arrRegistry.Add(db.EjecutaInsert(com, UserInformation, DataReference));
                    }
                    else
                    {
                        com.CommandText = "sp_UpdFuentes";
                        com.Parameters.AddWithValue("@Clave", varFuentes[i].Clave);
                        db.EjecutaInsert(com, UserInformation, DataReference);
                        arrRegistry.Add(varFuentes[i].Clave);
                    }
                }
            }
            //Borrar los registro que estan de mas
            String FiltroDelete = "";
            foreach (DataRow dr in drs.Rows )
            {
                Boolean existe = false;
                foreach( object arr in arrRegistry)
                if (arr.ToString() == dr[0].ToString())
                {
                    existe = true;
                    break;
                }
            if (!existe)
                FiltroDelete += ", '" + dr[0].ToString() + "'";
            }
            if (FiltroDelete != "")
            {
                FiltroDelete =" Where Clave in (" + FiltroDelete.Substring(2) + ")";
                db.EjecutaDelete(new SqlCommand("Delete from Fuentes " + FiltroDelete), UserInformation, DataReference);
            }
        }
        //TODO Falta Saber como borrar los campos
        {
            DataReference.Folio = sKeyFolio.ToString();
            TTDataLayerCS.BD dbMulti = new TTDataLayerCS.BD();
            DataTable drs = dbMulti.Consulta(new SqlCommand("Select Clave from Detalle_de_Notificacion_por_Observatorio Where Contenido = '" + sKeyFolio.ToString() + "'")).Tables[0];
            System.Collections.ArrayList arrRegistry = new System.Collections.ArrayList();
            if(varNotificaciones_por_Observatorios != null)
            {
                for (int i = 0;i< varNotificaciones_por_Observatorios.Length; i++)
                {
                    Boolean existe = false;
                    foreach(DataRow dr in drs.Rows)
                    {
                        if (varNotificaciones_por_Observatorios[i].Clave.ToString() == dr[0].ToString())
                        {
                            existe = true;
                            break;
                        }
                    }
                    com = new SqlCommand();
                    com.Parameters.AddWithValue("@Contenido", sKeyFolio);
                com.Parameters.AddWithValue("@Notificar", varNotificaciones_por_Observatorios[i].Notificar);
                com.Parameters.AddWithValue("@Observatorio", Conversion.FormatNull(varNotificaciones_por_Observatorios[i].Observatorio));

                    com.CommandType = CommandType.StoredProcedure;
                    if (!existe) //Insert 
                    {
                        com.CommandText = "sp_InsDetalle_de_Notificacion_por_Observatorio";
                        arrRegistry.Add(db.EjecutaInsert(com, UserInformation, DataReference));
                    }
                    else
                    {
                        com.CommandText = "sp_UpdDetalle_de_Notificacion_por_Observatorio";
                        com.Parameters.AddWithValue("@Clave", varNotificaciones_por_Observatorios[i].Clave);
                        db.EjecutaInsert(com, UserInformation, DataReference);
                        arrRegistry.Add(varNotificaciones_por_Observatorios[i].Clave);
                    }
                }
            }
            //Borrar los registro que estan de mas
            String FiltroDelete = "";
            foreach (DataRow dr in drs.Rows )
            {
                Boolean existe = false;
                foreach( object arr in arrRegistry)
                if (arr.ToString() == dr[0].ToString())
                {
                    existe = true;
                    break;
                }
            if (!existe)
                FiltroDelete += ", '" + dr[0].ToString() + "'";
            }
            if (FiltroDelete != "")
            {
                FiltroDelete =" Where Clave in (" + FiltroDelete.Substring(2) + ")";
                db.EjecutaDelete(new SqlCommand("Delete from Detalle_de_Notificacion_por_Observatorio " + FiltroDelete), UserInformation, DataReference);
            }
        }
        //TODO Falta Saber como borrar los campos
        {
            DataReference.Folio = sKeyFolio.ToString();
            TTDataLayerCS.BD dbMulti = new TTDataLayerCS.BD();
            DataTable drs = dbMulti.Consulta(new SqlCommand("Select Clave from Detalle_de_Notificacion_por_Usuario Where Contenido = '" + sKeyFolio.ToString() + "'")).Tables[0];
            System.Collections.ArrayList arrRegistry = new System.Collections.ArrayList();
            if(varNotificaciones_por_Usuario != null)
            {
                for (int i = 0;i< varNotificaciones_por_Usuario.Length; i++)
                {
                    Boolean existe = false;
                    foreach(DataRow dr in drs.Rows)
                    {
                        if (varNotificaciones_por_Usuario[i].Clave.ToString() == dr[0].ToString())
                        {
                            existe = true;
                            break;
                        }
                    }
                    com = new SqlCommand();
                    com.Parameters.AddWithValue("@Contenido", sKeyFolio);
                com.Parameters.AddWithValue("@Notificar", varNotificaciones_por_Usuario[i].Notificar);
                com.Parameters.AddWithValue("@Observatorio", Conversion.FormatNull(varNotificaciones_por_Usuario[i].Observatorio));
                com.Parameters.AddWithValue("@ID_del_Cliente", Conversion.FormatNull(varNotificaciones_por_Usuario[i].ID_del_Cliente));
            if (varNotificaciones_por_Usuario[i].Nombre!=null)
            {
                if (varNotificaciones_por_Usuario[i].Nombre != "")
                    com.Parameters.AddWithValue("@Nombre", Convierte(varNotificaciones_por_Usuario[i].Nombre, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Nombre", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Nombre", DBNull.Value);
            }
                    com.CommandType = CommandType.StoredProcedure;
                    if (!existe) //Insert 
                    {
                        com.CommandText = "sp_InsDetalle_de_Notificacion_por_Usuario";
                        arrRegistry.Add(db.EjecutaInsert(com, UserInformation, DataReference));
                    }
                    else
                    {
                        com.CommandText = "sp_UpdDetalle_de_Notificacion_por_Usuario";
                        com.Parameters.AddWithValue("@Clave", varNotificaciones_por_Usuario[i].Clave);
                        db.EjecutaInsert(com, UserInformation, DataReference);
                        arrRegistry.Add(varNotificaciones_por_Usuario[i].Clave);
                    }
                }
            }
            //Borrar los registro que estan de mas
            String FiltroDelete = "";
            foreach (DataRow dr in drs.Rows )
            {
                Boolean existe = false;
                foreach( object arr in arrRegistry)
                if (arr.ToString() == dr[0].ToString())
                {
                    existe = true;
                    break;
                }
            if (!existe)
                FiltroDelete += ", '" + dr[0].ToString() + "'";
            }
            if (FiltroDelete != "")
            {
                FiltroDelete =" Where Clave in (" + FiltroDelete.Substring(2) + ")";
                db.EjecutaDelete(new SqlCommand("Delete from Detalle_de_Notificacion_por_Usuario " + FiltroDelete), UserInformation, DataReference);
            }
        }

        //TODO Falta Saber como borrar los campos
        DataReference.Folio = sKeyFolio.ToString();
        db.EjecutaDelete(new SqlCommand("Delete from MS_Observatorios Where Clave = '" + sKeyFolio.ToString() + "'"), UserInformation, DataReference);
            if(varObservatorio != null)
            {
                for (int i = 0;i< varObservatorio.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsMS_Observatorios";
                    com.Parameters.AddWithValue("@Clave", sKeyFolio);
                    com.Parameters.AddWithValue("@Observatorio", varObservatorio[i].Observatorio );
//@@DatosDT.ParametrosUpdateListBox@@
                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
            }

            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("Registro_de_Contenido");
            }
            catch{}
            throw ex; 
        }
    }

    public bool Delete(int? KeyFolio, TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
            Boolean result;
            string Error = "";
            DataReference.Folio =  KeyFolio.ToString();
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            db.BeginTransaction("Registro_de_Contenido");
            try
            {
                DataReference.Folio = KeyFolio.ToString();
                TTDataLayerCS.BD dbDetalle_de_Etiquetas = new TTDataLayerCS.BD();
                DataSet recordsDetalle_de_Etiquetas = dbDetalle_de_Etiquetas.Consulta(new SqlCommand("Select Count(*) From Detalle_de_Etiquetas Where Articulo = '" + KeyFolio.ToString() + "'"));
                if (recordsDetalle_de_Etiquetas.Tables.Count > 0)
                    if (recordsDetalle_de_Etiquetas.Tables[0].Rows.Count > 0)
                    {
                        int totalrecordsDetalle_de_Etiquetas = int.Parse(recordsDetalle_de_Etiquetas.Tables[0].Rows[0][0].ToString());
                        if (totalrecordsDetalle_de_Etiquetas > 0)
                            Error = Error + "- Detalle de Etiquetas \r\n"; 
                    }
                dbDetalle_de_Etiquetas.Disconnect();                DataReference.Folio = KeyFolio.ToString();
                TTDataLayerCS.BD dbFuentes = new TTDataLayerCS.BD();
                DataSet recordsFuentes = dbFuentes.Consulta(new SqlCommand("Select Count(*) From Fuentes Where Articulo = '" + KeyFolio.ToString() + "'"));
                if (recordsFuentes.Tables.Count > 0)
                    if (recordsFuentes.Tables[0].Rows.Count > 0)
                    {
                        int totalrecordsFuentes = int.Parse(recordsFuentes.Tables[0].Rows[0][0].ToString());
                        if (totalrecordsFuentes > 0)
                            Error = Error + "- Fuentes \r\n"; 
                    }
                dbFuentes.Disconnect();                DataReference.Folio = KeyFolio.ToString();
                TTDataLayerCS.BD dbDetalle_de_Notificacion_por_Observatorio = new TTDataLayerCS.BD();
                DataSet recordsDetalle_de_Notificacion_por_Observatorio = dbDetalle_de_Notificacion_por_Observatorio.Consulta(new SqlCommand("Select Count(*) From Detalle_de_Notificacion_por_Observatorio Where Contenido = '" + KeyFolio.ToString() + "'"));
                if (recordsDetalle_de_Notificacion_por_Observatorio.Tables.Count > 0)
                    if (recordsDetalle_de_Notificacion_por_Observatorio.Tables[0].Rows.Count > 0)
                    {
                        int totalrecordsDetalle_de_Notificacion_por_Observatorio = int.Parse(recordsDetalle_de_Notificacion_por_Observatorio.Tables[0].Rows[0][0].ToString());
                        if (totalrecordsDetalle_de_Notificacion_por_Observatorio > 0)
                            Error = Error + "- Detalle de Notificación por Observatorio \r\n"; 
                    }
                dbDetalle_de_Notificacion_por_Observatorio.Disconnect();                DataReference.Folio = KeyFolio.ToString();
                TTDataLayerCS.BD dbDetalle_de_Notificacion_por_Usuario = new TTDataLayerCS.BD();
                DataSet recordsDetalle_de_Notificacion_por_Usuario = dbDetalle_de_Notificacion_por_Usuario.Consulta(new SqlCommand("Select Count(*) From Detalle_de_Notificacion_por_Usuario Where Contenido = '" + KeyFolio.ToString() + "'"));
                if (recordsDetalle_de_Notificacion_por_Usuario.Tables.Count > 0)
                    if (recordsDetalle_de_Notificacion_por_Usuario.Tables[0].Rows.Count > 0)
                    {
                        int totalrecordsDetalle_de_Notificacion_por_Usuario = int.Parse(recordsDetalle_de_Notificacion_por_Usuario.Tables[0].Rows[0][0].ToString());
                        if (totalrecordsDetalle_de_Notificacion_por_Usuario > 0)
                            Error = Error + "- Detalle de Notificación por Usuario \r\n"; 
                    }
                dbDetalle_de_Notificacion_por_Usuario.Disconnect();
                DataReference.Folio = KeyFolio.ToString();
                TTDataLayerCS.BD dbMS_Observatorios = new TTDataLayerCS.BD();
                DataSet recordsMS_Observatorios = dbMS_Observatorios.Consulta(new SqlCommand("Select Count(*) From MS_Observatorios Where Clave = '" + KeyFolio.ToString() + "'"));
                if (recordsMS_Observatorios.Tables.Count > 0)
                    if (recordsMS_Observatorios.Tables[0].Rows.Count > 0)
                    {
                        int totalrecordsMS_Observatorios = int.Parse(recordsMS_Observatorios.Tables[0].Rows[0][0].ToString());
                        if (totalrecordsMS_Observatorios > 0)
                            Error = Error + "- MS_Observatorios \r\n"; 
                    }
                dbMS_Observatorios.Disconnect();
                if (Error != "")
                {
                    throw new Exception("No es posible borrar el registro ya que tiene información relacionada con: \r\n" + Error + " \r\nFavor de borrar la información relacionada antes de borrar este registro.");
                }
                SqlCommand com = new SqlCommand();
                com.CommandText="sp_DelRegistro_de_Contenido";
com.Parameters.AddWithValue("@Folio",KeyFolio);
                com.CommandType =CommandType.StoredProcedure;
                db.EjecutaDelete(com, UserInformation, DataReference);
                db.CommitTransaction();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                try
                {
                    db.RollBackTransaction("Registro_de_Contenido");
                }
                catch{}
                throw ex; 
            }
            return result;
        //}
    }
    private DataSet GetByKey(DataSet ds)
    {
            if (ds.Tables[0].Rows.Count > 0)
            {
            Folio = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Registro_de_Contenido_Folio"]);
            Usuario_que_Registra = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Registro_de_Contenido_Usuario_que_Registra"]);
            Fecha_de_Registro = Conversion.CambiaToDatetime(ds.Tables[0].Rows[0]["Registro_de_Contenido_Fecha_de_Registro"]);
            Hora_de_Registro = ds.Tables[0].Rows[0]["Registro_de_Contenido_Hora_de_Registro"].ToString().TrimEnd(' ');
                {
                    MS_ObservatoriosCS.objectBussinessMS_Observatorios MyDataObservatorio = new MS_ObservatoriosCS.objectBussinessMS_Observatorios();
                    MS_ObservatoriosCS.MS_ObservatoriosFilters MyDataFilterObservatorio = new MS_ObservatoriosCS.MS_ObservatoriosFilters();
                    MyDataFilterObservatorio.Clave.List = new String[1];
                    MyDataFilterObservatorio.Clave.List[0] = Folio.Value.ToString();
                    MyDataObservatorio.Filters = new MS_ObservatoriosCS.MS_ObservatoriosFilters[1];
                    MyDataObservatorio.Filters[0] = MyDataFilterObservatorio;
                    DataSet dsListBox = MyDataObservatorio.SelAll(true);
                    Observatorio = new MS_ObservatoriosCS.objectBussinessMS_Observatorios[dsListBox.Tables[0].Rows.Count];
                    for (int i =0;i<dsListBox.Tables[0].Rows.Count;i++)
                    {
                        Observatorio[i] = new MS_ObservatoriosCS.objectBussinessMS_Observatorios();
                    Observatorio[i].Observatorio = Function.FormatNumberNull(dsListBox.Tables[0].Rows[i]["MS_Observatorios_Observatorio"].ToString());

                    }
                }
            Categoria = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Registro_de_Contenido_Categoria"]);
            Descripcion_de_Solicitud = ds.Tables[0].Rows[0]["Registro_de_Contenido_Descripcion_de_Solicitud"].ToString();
            Reportero_Asignado = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Registro_de_Contenido_Reportero_Asignado"]);
            Fecha_de_Compromiso = Conversion.CambiaToDatetime(ds.Tables[0].Rows[0]["Registro_de_Contenido_Fecha_de_Compromiso"]);
            Estatus = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Registro_de_Contenido_Estatus"]);
            Administrador_de_Observatorio = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Registro_de_Contenido_Administrador_de_Observatorio"]);
            Reportero = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Registro_de_Contenido_Reportero"]);
            Titulo = ds.Tables[0].Rows[0]["Registro_de_Contenido_Titulo"].ToString();
            Descripcion = ds.Tables[0].Rows[0]["Registro_de_Contenido_Descripcion"].ToString();
            Contenido = ds.Tables[0].Rows[0]["Registro_de_Contenido_Contenido"].ToString();
            Imagen = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Registro_de_Contenido_Imagen"]);
            Imagen_Miniatura = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Registro_de_Contenido_Imagen_Miniatura"]);
            Estilo = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Registro_de_Contenido_Estilo"]);
            Adjuntar_PDF = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Registro_de_Contenido_Adjuntar_PDF"]);
            if (ds.Tables[0].Rows[0]["Registro_de_Contenido_Captura_Terminada"] != DBNull.Value)
                Captura_Terminada = Convert.ToBoolean(ds.Tables[0].Rows[0]["Registro_de_Contenido_Captura_Terminada"]);
            Autorizado_por = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Registro_de_Contenido_Autorizado_por"]);
            Fecha_de_Revision = Conversion.CambiaToDatetime(ds.Tables[0].Rows[0]["Registro_de_Contenido_Fecha_de_Revision"]);
            Hora_de_Revision = ds.Tables[0].Rows[0]["Registro_de_Contenido_Hora_de_Revision"].ToString().TrimEnd(' ');
            Autorizacion = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Registro_de_Contenido_Autorizacion"]);
            Motivo_de_Rechazo = ds.Tables[0].Rows[0]["Registro_de_Contenido_Motivo_de_Rechazo"].ToString();
            Fecha_de_Inicio_de_Publicacion = Conversion.CambiaToDatetime(ds.Tables[0].Rows[0]["Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion"]);
            Fecha_de_Termino = Conversion.CambiaToDatetime(ds.Tables[0].Rows[0]["Registro_de_Contenido_Fecha_de_Termino"]);
            if (ds.Tables[0].Rows[0]["Registro_de_Contenido_Seleccionar_Todos_los_Observatorios"] != DBNull.Value)
                Seleccionar_Todos_los_Observatorios = Convert.ToBoolean(ds.Tables[0].Rows[0]["Registro_de_Contenido_Seleccionar_Todos_los_Observatorios"]);
            Filtrar_Usuarios_por_Observatorio = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio"]);

                {
                    Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas MyDataEtiquetas = new Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas();
                    Detalle_de_EtiquetasCS.Detalle_de_EtiquetasFilters MyDataFilterEtiquetas = new Detalle_de_EtiquetasCS.Detalle_de_EtiquetasFilters();
                    MyDataFilterEtiquetas.Articulo.List = new String[1];
                    MyDataFilterEtiquetas.Articulo.List[0] = Folio.Value.ToString();
                    MyDataEtiquetas.Filters = new Detalle_de_EtiquetasCS.Detalle_de_EtiquetasFilters[1];
                    MyDataEtiquetas.Filters[0] = MyDataFilterEtiquetas;
                    DataSet dsMulti = MyDataEtiquetas.SelAll(true);
                    Etiquetas = new Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas[dsMulti.Tables[0].Rows.Count];
                    for (int i =0;i<dsMulti.Tables[0].Rows.Count;i++)
                    {
                        Etiquetas[i] = new Detalle_de_EtiquetasCS.objectBussinessDetalle_de_Etiquetas();
                    Etiquetas[i].Clave = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["Detalle_de_Etiquetas_Clave"]);
                    Etiquetas[i].Articulo = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["Detalle_de_Etiquetas_Articulo"]);
                    Etiquetas[i].Etiqueta = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["Detalle_de_Etiquetas_Etiqueta"]);

                    }
               }    
                {
                    FuentesCS.objectBussinessFuentes MyDataFuentes = new FuentesCS.objectBussinessFuentes();
                    FuentesCS.FuentesFilters MyDataFilterFuentes = new FuentesCS.FuentesFilters();
                    MyDataFilterFuentes.Articulo.List = new String[1];
                    MyDataFilterFuentes.Articulo.List[0] = Folio.Value.ToString();
                    MyDataFuentes.Filters = new FuentesCS.FuentesFilters[1];
                    MyDataFuentes.Filters[0] = MyDataFilterFuentes;
                    DataSet dsMulti = MyDataFuentes.SelAll(true);
                    Fuentes = new FuentesCS.objectBussinessFuentes[dsMulti.Tables[0].Rows.Count];
                    for (int i =0;i<dsMulti.Tables[0].Rows.Count;i++)
                    {
                        Fuentes[i] = new FuentesCS.objectBussinessFuentes();
                    Fuentes[i].Clave = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["Fuentes_Clave"]);
                    Fuentes[i].Articulo = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["Fuentes_Articulo"]);
                    Fuentes[i].Fuente = dsMulti.Tables[0].Rows[i]["Fuentes_Fuente"].ToString().TrimEnd(' ');

                    }
               }    
                {
                    Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio MyDataNotificaciones_por_Observatorios = new Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio();
                    Detalle_de_Notificacion_por_ObservatorioCS.Detalle_de_Notificacion_por_ObservatorioFilters MyDataFilterNotificaciones_por_Observatorios = new Detalle_de_Notificacion_por_ObservatorioCS.Detalle_de_Notificacion_por_ObservatorioFilters();
                    MyDataFilterNotificaciones_por_Observatorios.Contenido.List = new String[1];
                    MyDataFilterNotificaciones_por_Observatorios.Contenido.List[0] = Folio.Value.ToString();
                    MyDataNotificaciones_por_Observatorios.Filters = new Detalle_de_Notificacion_por_ObservatorioCS.Detalle_de_Notificacion_por_ObservatorioFilters[1];
                    MyDataNotificaciones_por_Observatorios.Filters[0] = MyDataFilterNotificaciones_por_Observatorios;
                    DataSet dsMulti = MyDataNotificaciones_por_Observatorios.SelAll(true);
                    Notificaciones_por_Observatorios = new Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio[dsMulti.Tables[0].Rows.Count];
                    for (int i =0;i<dsMulti.Tables[0].Rows.Count;i++)
                    {
                        Notificaciones_por_Observatorios[i] = new Detalle_de_Notificacion_por_ObservatorioCS.objectBussinessDetalle_de_Notificacion_por_Observatorio();
                    Notificaciones_por_Observatorios[i].Clave = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["Detalle_de_Notificacion_por_Observatorio_Clave"]);
                    Notificaciones_por_Observatorios[i].Contenido = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["Detalle_de_Notificacion_por_Observatorio_Contenido"]);
                if(dsMulti.Tables[0].Rows[i]["Detalle_de_Notificacion_por_Observatorio_Notificar"] != DBNull.Value)
                    Notificaciones_por_Observatorios[i].Notificar = Convert.ToBoolean(dsMulti.Tables[0].Rows[i]["Detalle_de_Notificacion_por_Observatorio_Notificar"]);
                    Notificaciones_por_Observatorios[i].Observatorio = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["Detalle_de_Notificacion_por_Observatorio_Observatorio"]);

                    }
               }    
                {
                    Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario MyDataNotificaciones_por_Usuario = new Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario();
                    Detalle_de_Notificacion_por_UsuarioCS.Detalle_de_Notificacion_por_UsuarioFilters MyDataFilterNotificaciones_por_Usuario = new Detalle_de_Notificacion_por_UsuarioCS.Detalle_de_Notificacion_por_UsuarioFilters();
                    MyDataFilterNotificaciones_por_Usuario.Contenido.List = new String[1];
                    MyDataFilterNotificaciones_por_Usuario.Contenido.List[0] = Folio.Value.ToString();
                    MyDataNotificaciones_por_Usuario.Filters = new Detalle_de_Notificacion_por_UsuarioCS.Detalle_de_Notificacion_por_UsuarioFilters[1];
                    MyDataNotificaciones_por_Usuario.Filters[0] = MyDataFilterNotificaciones_por_Usuario;
                    DataSet dsMulti = MyDataNotificaciones_por_Usuario.SelAll(true);
                    Notificaciones_por_Usuario = new Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario[dsMulti.Tables[0].Rows.Count];
                    for (int i =0;i<dsMulti.Tables[0].Rows.Count;i++)
                    {
                        Notificaciones_por_Usuario[i] = new Detalle_de_Notificacion_por_UsuarioCS.objectBussinessDetalle_de_Notificacion_por_Usuario();
                    Notificaciones_por_Usuario[i].Clave = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["Detalle_de_Notificacion_por_Usuario_Clave"]);
                    Notificaciones_por_Usuario[i].Contenido = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["Detalle_de_Notificacion_por_Usuario_Contenido"]);
                if(dsMulti.Tables[0].Rows[i]["Detalle_de_Notificacion_por_Usuario_Notificar"] != DBNull.Value)
                    Notificaciones_por_Usuario[i].Notificar = Convert.ToBoolean(dsMulti.Tables[0].Rows[i]["Detalle_de_Notificacion_por_Usuario_Notificar"]);
                    Notificaciones_por_Usuario[i].Observatorio = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["Detalle_de_Notificacion_por_Usuario_Observatorio"]);
                    Notificaciones_por_Usuario[i].ID_del_Cliente = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["Detalle_de_Notificacion_por_Usuario_ID_del_Cliente"]);
                    Notificaciones_por_Usuario[i].Nombre = dsMulti.Tables[0].Rows[i]["Detalle_de_Notificacion_por_Usuario_Nombre"].ToString().TrimEnd(' ');

                    }
               }    


            }
        return ds;
    }
    public DataSet GetByKey(int? KeyFolio, Boolean ConRelaciones){
        DataSet ds;
        if (KeyFolio == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            if (ConRelaciones==true)
                com.CommandText="sp_GetComplete_Registro_de_Contenido";
            else
                com.CommandText="sp_GetRegistro_de_Contenido";
com.Parameters.AddWithValue("@Folio",KeyFolio);

            com.CommandType=CommandType.StoredProcedure;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyFolio(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Contenido.Folio As Registro_de_Contenido_Folio,        Registro_de_Contenido.Usuario_que_Registra AS Registro_de_Contenido_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Contenido.Fecha_de_Registro As Registro_de_Contenido_Fecha_de_Registro,        Registro_de_Contenido.Hora_de_Registro As Registro_de_Contenido_Hora_de_Registro,        '' AS Registro_de_Contenido_Observatorio,        Registro_de_Contenido.Categoria AS Registro_de_Contenido_Categoria,        Categoria.Descripcion AS Categoria_Descripcion,        Registro_de_Contenido.Descripcion_de_Solicitud As Registro_de_Contenido_Descripcion_de_Solicitud,        Registro_de_Contenido.Reportero_Asignado AS Registro_de_Contenido_Reportero_Asignado,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        Registro_de_Contenido.Fecha_de_Compromiso As Registro_de_Contenido_Fecha_de_Compromiso,        Registro_de_Contenido.Estatus AS Registro_de_Contenido_Estatus,        Estatus_de_Contenido.Descripcion AS Estatus_de_Contenido_Descripcion,        Registro_de_Contenido.Administrador_de_Observatorio AS Registro_de_Contenido_Administrador_de_Observatorio,        TTUsuarios2.Nombre AS TTUsuarios2_Nombre,        Registro_de_Contenido.Reportero AS Registro_de_Contenido_Reportero,        TTUsuarios3.Nombre AS TTUsuarios3_Nombre,        Registro_de_Contenido.Titulo As Registro_de_Contenido_Titulo,        Registro_de_Contenido.Descripcion As Registro_de_Contenido_Descripcion,        Registro_de_Contenido.Contenido As Registro_de_Contenido_Contenido,        Registro_de_Contenido.Imagen AS Registro_de_Contenido_Imagen,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Contenido.Imagen_Miniatura AS Registro_de_Contenido_Imagen_Miniatura,        TTArchivos1.Nombre AS TTArchivos1_Nombre,        Registro_de_Contenido.Estilo AS Registro_de_Contenido_Estilo,        Estilo_de_Articulo.Descripcion AS Estilo_de_Articulo_Descripcion,        Registro_de_Contenido.Adjuntar_PDF AS Registro_de_Contenido_Adjuntar_PDF,        TTArchivos2.Nombre AS TTArchivos2_Nombre,        Registro_de_Contenido.Captura_Terminada As Registro_de_Contenido_Captura_Terminada,        Registro_de_Contenido.Autorizado_por AS Registro_de_Contenido_Autorizado_por,        TTUsuarios4.Nombre AS TTUsuarios4_Nombre,        Registro_de_Contenido.Fecha_de_Revision As Registro_de_Contenido_Fecha_de_Revision,        Registro_de_Contenido.Hora_de_Revision As Registro_de_Contenido_Hora_de_Revision,        Registro_de_Contenido.Autorizacion AS Registro_de_Contenido_Autorizacion,        Autorizacion.Descripcion AS Autorizacion_Descripcion,        Registro_de_Contenido.Motivo_de_Rechazo As Registro_de_Contenido_Motivo_de_Rechazo,        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,        Registro_de_Contenido.Fecha_de_Termino As Registro_de_Contenido_Fecha_de_Termino,        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As Registro_de_Contenido_Seleccionar_Todos_los_Observatorios,        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from ((((((((((((( Registro_de_Contenido       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido ON Estatus_de_Contenido.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as TTUsuarios2 ON TTUsuarios2.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as TTUsuarios3 ON TTUsuarios3.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as TTArchivos1 ON TTArchivos1.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo ON Estilo_de_Articulo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as TTArchivos2 ON TTArchivos2.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as TTUsuarios4 ON TTUsuarios4.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio ON Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)           Where Registro_de_Contenido.Folio = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyUsuario_que_Registra(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Contenido.Folio As Registro_de_Contenido_Folio,        Registro_de_Contenido.Usuario_que_Registra AS Registro_de_Contenido_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Contenido.Fecha_de_Registro As Registro_de_Contenido_Fecha_de_Registro,        Registro_de_Contenido.Hora_de_Registro As Registro_de_Contenido_Hora_de_Registro,        '' AS Registro_de_Contenido_Observatorio,        Registro_de_Contenido.Categoria AS Registro_de_Contenido_Categoria,        Categoria.Descripcion AS Categoria_Descripcion,        Registro_de_Contenido.Descripcion_de_Solicitud As Registro_de_Contenido_Descripcion_de_Solicitud,        Registro_de_Contenido.Reportero_Asignado AS Registro_de_Contenido_Reportero_Asignado,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        Registro_de_Contenido.Fecha_de_Compromiso As Registro_de_Contenido_Fecha_de_Compromiso,        Registro_de_Contenido.Estatus AS Registro_de_Contenido_Estatus,        Estatus_de_Contenido.Descripcion AS Estatus_de_Contenido_Descripcion,        Registro_de_Contenido.Administrador_de_Observatorio AS Registro_de_Contenido_Administrador_de_Observatorio,        TTUsuarios2.Nombre AS TTUsuarios2_Nombre,        Registro_de_Contenido.Reportero AS Registro_de_Contenido_Reportero,        TTUsuarios3.Nombre AS TTUsuarios3_Nombre,        Registro_de_Contenido.Titulo As Registro_de_Contenido_Titulo,        Registro_de_Contenido.Descripcion As Registro_de_Contenido_Descripcion,        Registro_de_Contenido.Contenido As Registro_de_Contenido_Contenido,        Registro_de_Contenido.Imagen AS Registro_de_Contenido_Imagen,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Contenido.Imagen_Miniatura AS Registro_de_Contenido_Imagen_Miniatura,        TTArchivos1.Nombre AS TTArchivos1_Nombre,        Registro_de_Contenido.Estilo AS Registro_de_Contenido_Estilo,        Estilo_de_Articulo.Descripcion AS Estilo_de_Articulo_Descripcion,        Registro_de_Contenido.Adjuntar_PDF AS Registro_de_Contenido_Adjuntar_PDF,        TTArchivos2.Nombre AS TTArchivos2_Nombre,        Registro_de_Contenido.Captura_Terminada As Registro_de_Contenido_Captura_Terminada,        Registro_de_Contenido.Autorizado_por AS Registro_de_Contenido_Autorizado_por,        TTUsuarios4.Nombre AS TTUsuarios4_Nombre,        Registro_de_Contenido.Fecha_de_Revision As Registro_de_Contenido_Fecha_de_Revision,        Registro_de_Contenido.Hora_de_Revision As Registro_de_Contenido_Hora_de_Revision,        Registro_de_Contenido.Autorizacion AS Registro_de_Contenido_Autorizacion,        Autorizacion.Descripcion AS Autorizacion_Descripcion,        Registro_de_Contenido.Motivo_de_Rechazo As Registro_de_Contenido_Motivo_de_Rechazo,        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,        Registro_de_Contenido.Fecha_de_Termino As Registro_de_Contenido_Fecha_de_Termino,        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As Registro_de_Contenido_Seleccionar_Todos_los_Observatorios,        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from ((((((((((((( Registro_de_Contenido       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido ON Estatus_de_Contenido.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as TTUsuarios2 ON TTUsuarios2.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as TTUsuarios3 ON TTUsuarios3.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as TTArchivos1 ON TTArchivos1.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo ON Estilo_de_Articulo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as TTArchivos2 ON TTArchivos2.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as TTUsuarios4 ON TTUsuarios4.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio ON Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)           Where Registro_de_Contenido.Usuario_que_Registra = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyFecha_de_Registro(DateTime Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Contenido.Folio As Registro_de_Contenido_Folio,        Registro_de_Contenido.Usuario_que_Registra AS Registro_de_Contenido_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Contenido.Fecha_de_Registro As Registro_de_Contenido_Fecha_de_Registro,        Registro_de_Contenido.Hora_de_Registro As Registro_de_Contenido_Hora_de_Registro,        '' AS Registro_de_Contenido_Observatorio,        Registro_de_Contenido.Categoria AS Registro_de_Contenido_Categoria,        Categoria.Descripcion AS Categoria_Descripcion,        Registro_de_Contenido.Descripcion_de_Solicitud As Registro_de_Contenido_Descripcion_de_Solicitud,        Registro_de_Contenido.Reportero_Asignado AS Registro_de_Contenido_Reportero_Asignado,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        Registro_de_Contenido.Fecha_de_Compromiso As Registro_de_Contenido_Fecha_de_Compromiso,        Registro_de_Contenido.Estatus AS Registro_de_Contenido_Estatus,        Estatus_de_Contenido.Descripcion AS Estatus_de_Contenido_Descripcion,        Registro_de_Contenido.Administrador_de_Observatorio AS Registro_de_Contenido_Administrador_de_Observatorio,        TTUsuarios2.Nombre AS TTUsuarios2_Nombre,        Registro_de_Contenido.Reportero AS Registro_de_Contenido_Reportero,        TTUsuarios3.Nombre AS TTUsuarios3_Nombre,        Registro_de_Contenido.Titulo As Registro_de_Contenido_Titulo,        Registro_de_Contenido.Descripcion As Registro_de_Contenido_Descripcion,        Registro_de_Contenido.Contenido As Registro_de_Contenido_Contenido,        Registro_de_Contenido.Imagen AS Registro_de_Contenido_Imagen,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Contenido.Imagen_Miniatura AS Registro_de_Contenido_Imagen_Miniatura,        TTArchivos1.Nombre AS TTArchivos1_Nombre,        Registro_de_Contenido.Estilo AS Registro_de_Contenido_Estilo,        Estilo_de_Articulo.Descripcion AS Estilo_de_Articulo_Descripcion,        Registro_de_Contenido.Adjuntar_PDF AS Registro_de_Contenido_Adjuntar_PDF,        TTArchivos2.Nombre AS TTArchivos2_Nombre,        Registro_de_Contenido.Captura_Terminada As Registro_de_Contenido_Captura_Terminada,        Registro_de_Contenido.Autorizado_por AS Registro_de_Contenido_Autorizado_por,        TTUsuarios4.Nombre AS TTUsuarios4_Nombre,        Registro_de_Contenido.Fecha_de_Revision As Registro_de_Contenido_Fecha_de_Revision,        Registro_de_Contenido.Hora_de_Revision As Registro_de_Contenido_Hora_de_Revision,        Registro_de_Contenido.Autorizacion AS Registro_de_Contenido_Autorizacion,        Autorizacion.Descripcion AS Autorizacion_Descripcion,        Registro_de_Contenido.Motivo_de_Rechazo As Registro_de_Contenido_Motivo_de_Rechazo,        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,        Registro_de_Contenido.Fecha_de_Termino As Registro_de_Contenido_Fecha_de_Termino,        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As Registro_de_Contenido_Seleccionar_Todos_los_Observatorios,        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from ((((((((((((( Registro_de_Contenido       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido ON Estatus_de_Contenido.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as TTUsuarios2 ON TTUsuarios2.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as TTUsuarios3 ON TTUsuarios3.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as TTArchivos1 ON TTArchivos1.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo ON Estilo_de_Articulo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as TTArchivos2 ON TTArchivos2.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as TTUsuarios4 ON TTUsuarios4.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio ON Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)           Where Registro_de_Contenido.Fecha_de_Registro = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyHora_de_Registro(String Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Contenido.Folio As Registro_de_Contenido_Folio,        Registro_de_Contenido.Usuario_que_Registra AS Registro_de_Contenido_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Contenido.Fecha_de_Registro As Registro_de_Contenido_Fecha_de_Registro,        Registro_de_Contenido.Hora_de_Registro As Registro_de_Contenido_Hora_de_Registro,        '' AS Registro_de_Contenido_Observatorio,        Registro_de_Contenido.Categoria AS Registro_de_Contenido_Categoria,        Categoria.Descripcion AS Categoria_Descripcion,        Registro_de_Contenido.Descripcion_de_Solicitud As Registro_de_Contenido_Descripcion_de_Solicitud,        Registro_de_Contenido.Reportero_Asignado AS Registro_de_Contenido_Reportero_Asignado,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        Registro_de_Contenido.Fecha_de_Compromiso As Registro_de_Contenido_Fecha_de_Compromiso,        Registro_de_Contenido.Estatus AS Registro_de_Contenido_Estatus,        Estatus_de_Contenido.Descripcion AS Estatus_de_Contenido_Descripcion,        Registro_de_Contenido.Administrador_de_Observatorio AS Registro_de_Contenido_Administrador_de_Observatorio,        TTUsuarios2.Nombre AS TTUsuarios2_Nombre,        Registro_de_Contenido.Reportero AS Registro_de_Contenido_Reportero,        TTUsuarios3.Nombre AS TTUsuarios3_Nombre,        Registro_de_Contenido.Titulo As Registro_de_Contenido_Titulo,        Registro_de_Contenido.Descripcion As Registro_de_Contenido_Descripcion,        Registro_de_Contenido.Contenido As Registro_de_Contenido_Contenido,        Registro_de_Contenido.Imagen AS Registro_de_Contenido_Imagen,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Contenido.Imagen_Miniatura AS Registro_de_Contenido_Imagen_Miniatura,        TTArchivos1.Nombre AS TTArchivos1_Nombre,        Registro_de_Contenido.Estilo AS Registro_de_Contenido_Estilo,        Estilo_de_Articulo.Descripcion AS Estilo_de_Articulo_Descripcion,        Registro_de_Contenido.Adjuntar_PDF AS Registro_de_Contenido_Adjuntar_PDF,        TTArchivos2.Nombre AS TTArchivos2_Nombre,        Registro_de_Contenido.Captura_Terminada As Registro_de_Contenido_Captura_Terminada,        Registro_de_Contenido.Autorizado_por AS Registro_de_Contenido_Autorizado_por,        TTUsuarios4.Nombre AS TTUsuarios4_Nombre,        Registro_de_Contenido.Fecha_de_Revision As Registro_de_Contenido_Fecha_de_Revision,        Registro_de_Contenido.Hora_de_Revision As Registro_de_Contenido_Hora_de_Revision,        Registro_de_Contenido.Autorizacion AS Registro_de_Contenido_Autorizacion,        Autorizacion.Descripcion AS Autorizacion_Descripcion,        Registro_de_Contenido.Motivo_de_Rechazo As Registro_de_Contenido_Motivo_de_Rechazo,        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,        Registro_de_Contenido.Fecha_de_Termino As Registro_de_Contenido_Fecha_de_Termino,        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As Registro_de_Contenido_Seleccionar_Todos_los_Observatorios,        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from ((((((((((((( Registro_de_Contenido       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido ON Estatus_de_Contenido.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as TTUsuarios2 ON TTUsuarios2.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as TTUsuarios3 ON TTUsuarios3.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as TTArchivos1 ON TTArchivos1.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo ON Estilo_de_Articulo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as TTArchivos2 ON TTArchivos2.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as TTUsuarios4 ON TTUsuarios4.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio ON Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)           Where Registro_de_Contenido.Hora_de_Registro = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyObservatorio(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Contenido.Folio As Registro_de_Contenido_Folio,        Registro_de_Contenido.Usuario_que_Registra AS Registro_de_Contenido_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Contenido.Fecha_de_Registro As Registro_de_Contenido_Fecha_de_Registro,        Registro_de_Contenido.Hora_de_Registro As Registro_de_Contenido_Hora_de_Registro,        '' AS Registro_de_Contenido_Observatorio,        Registro_de_Contenido.Categoria AS Registro_de_Contenido_Categoria,        Categoria.Descripcion AS Categoria_Descripcion,        Registro_de_Contenido.Descripcion_de_Solicitud As Registro_de_Contenido_Descripcion_de_Solicitud,        Registro_de_Contenido.Reportero_Asignado AS Registro_de_Contenido_Reportero_Asignado,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        Registro_de_Contenido.Fecha_de_Compromiso As Registro_de_Contenido_Fecha_de_Compromiso,        Registro_de_Contenido.Estatus AS Registro_de_Contenido_Estatus,        Estatus_de_Contenido.Descripcion AS Estatus_de_Contenido_Descripcion,        Registro_de_Contenido.Administrador_de_Observatorio AS Registro_de_Contenido_Administrador_de_Observatorio,        TTUsuarios2.Nombre AS TTUsuarios2_Nombre,        Registro_de_Contenido.Reportero AS Registro_de_Contenido_Reportero,        TTUsuarios3.Nombre AS TTUsuarios3_Nombre,        Registro_de_Contenido.Titulo As Registro_de_Contenido_Titulo,        Registro_de_Contenido.Descripcion As Registro_de_Contenido_Descripcion,        Registro_de_Contenido.Contenido As Registro_de_Contenido_Contenido,        Registro_de_Contenido.Imagen AS Registro_de_Contenido_Imagen,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Contenido.Imagen_Miniatura AS Registro_de_Contenido_Imagen_Miniatura,        TTArchivos1.Nombre AS TTArchivos1_Nombre,        Registro_de_Contenido.Estilo AS Registro_de_Contenido_Estilo,        Estilo_de_Articulo.Descripcion AS Estilo_de_Articulo_Descripcion,        Registro_de_Contenido.Adjuntar_PDF AS Registro_de_Contenido_Adjuntar_PDF,        TTArchivos2.Nombre AS TTArchivos2_Nombre,        Registro_de_Contenido.Captura_Terminada As Registro_de_Contenido_Captura_Terminada,        Registro_de_Contenido.Autorizado_por AS Registro_de_Contenido_Autorizado_por,        TTUsuarios4.Nombre AS TTUsuarios4_Nombre,        Registro_de_Contenido.Fecha_de_Revision As Registro_de_Contenido_Fecha_de_Revision,        Registro_de_Contenido.Hora_de_Revision As Registro_de_Contenido_Hora_de_Revision,        Registro_de_Contenido.Autorizacion AS Registro_de_Contenido_Autorizacion,        Autorizacion.Descripcion AS Autorizacion_Descripcion,        Registro_de_Contenido.Motivo_de_Rechazo As Registro_de_Contenido_Motivo_de_Rechazo,        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,        Registro_de_Contenido.Fecha_de_Termino As Registro_de_Contenido_Fecha_de_Termino,        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As Registro_de_Contenido_Seleccionar_Todos_los_Observatorios,        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from ((((((((((((( Registro_de_Contenido       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido ON Estatus_de_Contenido.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as TTUsuarios2 ON TTUsuarios2.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as TTUsuarios3 ON TTUsuarios3.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as TTArchivos1 ON TTArchivos1.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo ON Estilo_de_Articulo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as TTArchivos2 ON TTArchivos2.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as TTUsuarios4 ON TTUsuarios4.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio ON Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)           Where Registro_de_Contenido.Observatorio = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyCategoria(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Contenido.Folio As Registro_de_Contenido_Folio,        Registro_de_Contenido.Usuario_que_Registra AS Registro_de_Contenido_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Contenido.Fecha_de_Registro As Registro_de_Contenido_Fecha_de_Registro,        Registro_de_Contenido.Hora_de_Registro As Registro_de_Contenido_Hora_de_Registro,        '' AS Registro_de_Contenido_Observatorio,        Registro_de_Contenido.Categoria AS Registro_de_Contenido_Categoria,        Categoria.Descripcion AS Categoria_Descripcion,        Registro_de_Contenido.Descripcion_de_Solicitud As Registro_de_Contenido_Descripcion_de_Solicitud,        Registro_de_Contenido.Reportero_Asignado AS Registro_de_Contenido_Reportero_Asignado,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        Registro_de_Contenido.Fecha_de_Compromiso As Registro_de_Contenido_Fecha_de_Compromiso,        Registro_de_Contenido.Estatus AS Registro_de_Contenido_Estatus,        Estatus_de_Contenido.Descripcion AS Estatus_de_Contenido_Descripcion,        Registro_de_Contenido.Administrador_de_Observatorio AS Registro_de_Contenido_Administrador_de_Observatorio,        TTUsuarios2.Nombre AS TTUsuarios2_Nombre,        Registro_de_Contenido.Reportero AS Registro_de_Contenido_Reportero,        TTUsuarios3.Nombre AS TTUsuarios3_Nombre,        Registro_de_Contenido.Titulo As Registro_de_Contenido_Titulo,        Registro_de_Contenido.Descripcion As Registro_de_Contenido_Descripcion,        Registro_de_Contenido.Contenido As Registro_de_Contenido_Contenido,        Registro_de_Contenido.Imagen AS Registro_de_Contenido_Imagen,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Contenido.Imagen_Miniatura AS Registro_de_Contenido_Imagen_Miniatura,        TTArchivos1.Nombre AS TTArchivos1_Nombre,        Registro_de_Contenido.Estilo AS Registro_de_Contenido_Estilo,        Estilo_de_Articulo.Descripcion AS Estilo_de_Articulo_Descripcion,        Registro_de_Contenido.Adjuntar_PDF AS Registro_de_Contenido_Adjuntar_PDF,        TTArchivos2.Nombre AS TTArchivos2_Nombre,        Registro_de_Contenido.Captura_Terminada As Registro_de_Contenido_Captura_Terminada,        Registro_de_Contenido.Autorizado_por AS Registro_de_Contenido_Autorizado_por,        TTUsuarios4.Nombre AS TTUsuarios4_Nombre,        Registro_de_Contenido.Fecha_de_Revision As Registro_de_Contenido_Fecha_de_Revision,        Registro_de_Contenido.Hora_de_Revision As Registro_de_Contenido_Hora_de_Revision,        Registro_de_Contenido.Autorizacion AS Registro_de_Contenido_Autorizacion,        Autorizacion.Descripcion AS Autorizacion_Descripcion,        Registro_de_Contenido.Motivo_de_Rechazo As Registro_de_Contenido_Motivo_de_Rechazo,        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,        Registro_de_Contenido.Fecha_de_Termino As Registro_de_Contenido_Fecha_de_Termino,        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As Registro_de_Contenido_Seleccionar_Todos_los_Observatorios,        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from ((((((((((((( Registro_de_Contenido       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido ON Estatus_de_Contenido.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as TTUsuarios2 ON TTUsuarios2.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as TTUsuarios3 ON TTUsuarios3.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as TTArchivos1 ON TTArchivos1.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo ON Estilo_de_Articulo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as TTArchivos2 ON TTArchivos2.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as TTUsuarios4 ON TTUsuarios4.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio ON Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)           Where Registro_de_Contenido.Categoria = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyDescripcion_de_Solicitud(String Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Contenido.Folio As Registro_de_Contenido_Folio,        Registro_de_Contenido.Usuario_que_Registra AS Registro_de_Contenido_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Contenido.Fecha_de_Registro As Registro_de_Contenido_Fecha_de_Registro,        Registro_de_Contenido.Hora_de_Registro As Registro_de_Contenido_Hora_de_Registro,        '' AS Registro_de_Contenido_Observatorio,        Registro_de_Contenido.Categoria AS Registro_de_Contenido_Categoria,        Categoria.Descripcion AS Categoria_Descripcion,        Registro_de_Contenido.Descripcion_de_Solicitud As Registro_de_Contenido_Descripcion_de_Solicitud,        Registro_de_Contenido.Reportero_Asignado AS Registro_de_Contenido_Reportero_Asignado,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        Registro_de_Contenido.Fecha_de_Compromiso As Registro_de_Contenido_Fecha_de_Compromiso,        Registro_de_Contenido.Estatus AS Registro_de_Contenido_Estatus,        Estatus_de_Contenido.Descripcion AS Estatus_de_Contenido_Descripcion,        Registro_de_Contenido.Administrador_de_Observatorio AS Registro_de_Contenido_Administrador_de_Observatorio,        TTUsuarios2.Nombre AS TTUsuarios2_Nombre,        Registro_de_Contenido.Reportero AS Registro_de_Contenido_Reportero,        TTUsuarios3.Nombre AS TTUsuarios3_Nombre,        Registro_de_Contenido.Titulo As Registro_de_Contenido_Titulo,        Registro_de_Contenido.Descripcion As Registro_de_Contenido_Descripcion,        Registro_de_Contenido.Contenido As Registro_de_Contenido_Contenido,        Registro_de_Contenido.Imagen AS Registro_de_Contenido_Imagen,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Contenido.Imagen_Miniatura AS Registro_de_Contenido_Imagen_Miniatura,        TTArchivos1.Nombre AS TTArchivos1_Nombre,        Registro_de_Contenido.Estilo AS Registro_de_Contenido_Estilo,        Estilo_de_Articulo.Descripcion AS Estilo_de_Articulo_Descripcion,        Registro_de_Contenido.Adjuntar_PDF AS Registro_de_Contenido_Adjuntar_PDF,        TTArchivos2.Nombre AS TTArchivos2_Nombre,        Registro_de_Contenido.Captura_Terminada As Registro_de_Contenido_Captura_Terminada,        Registro_de_Contenido.Autorizado_por AS Registro_de_Contenido_Autorizado_por,        TTUsuarios4.Nombre AS TTUsuarios4_Nombre,        Registro_de_Contenido.Fecha_de_Revision As Registro_de_Contenido_Fecha_de_Revision,        Registro_de_Contenido.Hora_de_Revision As Registro_de_Contenido_Hora_de_Revision,        Registro_de_Contenido.Autorizacion AS Registro_de_Contenido_Autorizacion,        Autorizacion.Descripcion AS Autorizacion_Descripcion,        Registro_de_Contenido.Motivo_de_Rechazo As Registro_de_Contenido_Motivo_de_Rechazo,        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,        Registro_de_Contenido.Fecha_de_Termino As Registro_de_Contenido_Fecha_de_Termino,        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As Registro_de_Contenido_Seleccionar_Todos_los_Observatorios,        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from ((((((((((((( Registro_de_Contenido       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido ON Estatus_de_Contenido.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as TTUsuarios2 ON TTUsuarios2.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as TTUsuarios3 ON TTUsuarios3.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as TTArchivos1 ON TTArchivos1.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo ON Estilo_de_Articulo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as TTArchivos2 ON TTArchivos2.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as TTUsuarios4 ON TTUsuarios4.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio ON Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)           Where Registro_de_Contenido.Descripcion_de_Solicitud = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyReportero_Asignado(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Contenido.Folio As Registro_de_Contenido_Folio,        Registro_de_Contenido.Usuario_que_Registra AS Registro_de_Contenido_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Contenido.Fecha_de_Registro As Registro_de_Contenido_Fecha_de_Registro,        Registro_de_Contenido.Hora_de_Registro As Registro_de_Contenido_Hora_de_Registro,        '' AS Registro_de_Contenido_Observatorio,        Registro_de_Contenido.Categoria AS Registro_de_Contenido_Categoria,        Categoria.Descripcion AS Categoria_Descripcion,        Registro_de_Contenido.Descripcion_de_Solicitud As Registro_de_Contenido_Descripcion_de_Solicitud,        Registro_de_Contenido.Reportero_Asignado AS Registro_de_Contenido_Reportero_Asignado,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        Registro_de_Contenido.Fecha_de_Compromiso As Registro_de_Contenido_Fecha_de_Compromiso,        Registro_de_Contenido.Estatus AS Registro_de_Contenido_Estatus,        Estatus_de_Contenido.Descripcion AS Estatus_de_Contenido_Descripcion,        Registro_de_Contenido.Administrador_de_Observatorio AS Registro_de_Contenido_Administrador_de_Observatorio,        TTUsuarios2.Nombre AS TTUsuarios2_Nombre,        Registro_de_Contenido.Reportero AS Registro_de_Contenido_Reportero,        TTUsuarios3.Nombre AS TTUsuarios3_Nombre,        Registro_de_Contenido.Titulo As Registro_de_Contenido_Titulo,        Registro_de_Contenido.Descripcion As Registro_de_Contenido_Descripcion,        Registro_de_Contenido.Contenido As Registro_de_Contenido_Contenido,        Registro_de_Contenido.Imagen AS Registro_de_Contenido_Imagen,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Contenido.Imagen_Miniatura AS Registro_de_Contenido_Imagen_Miniatura,        TTArchivos1.Nombre AS TTArchivos1_Nombre,        Registro_de_Contenido.Estilo AS Registro_de_Contenido_Estilo,        Estilo_de_Articulo.Descripcion AS Estilo_de_Articulo_Descripcion,        Registro_de_Contenido.Adjuntar_PDF AS Registro_de_Contenido_Adjuntar_PDF,        TTArchivos2.Nombre AS TTArchivos2_Nombre,        Registro_de_Contenido.Captura_Terminada As Registro_de_Contenido_Captura_Terminada,        Registro_de_Contenido.Autorizado_por AS Registro_de_Contenido_Autorizado_por,        TTUsuarios4.Nombre AS TTUsuarios4_Nombre,        Registro_de_Contenido.Fecha_de_Revision As Registro_de_Contenido_Fecha_de_Revision,        Registro_de_Contenido.Hora_de_Revision As Registro_de_Contenido_Hora_de_Revision,        Registro_de_Contenido.Autorizacion AS Registro_de_Contenido_Autorizacion,        Autorizacion.Descripcion AS Autorizacion_Descripcion,        Registro_de_Contenido.Motivo_de_Rechazo As Registro_de_Contenido_Motivo_de_Rechazo,        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,        Registro_de_Contenido.Fecha_de_Termino As Registro_de_Contenido_Fecha_de_Termino,        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As Registro_de_Contenido_Seleccionar_Todos_los_Observatorios,        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from ((((((((((((( Registro_de_Contenido       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido ON Estatus_de_Contenido.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as TTUsuarios2 ON TTUsuarios2.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as TTUsuarios3 ON TTUsuarios3.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as TTArchivos1 ON TTArchivos1.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo ON Estilo_de_Articulo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as TTArchivos2 ON TTArchivos2.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as TTUsuarios4 ON TTUsuarios4.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio ON Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)           Where Registro_de_Contenido.Reportero_Asignado = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyFecha_de_Compromiso(DateTime Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Contenido.Folio As Registro_de_Contenido_Folio,        Registro_de_Contenido.Usuario_que_Registra AS Registro_de_Contenido_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Contenido.Fecha_de_Registro As Registro_de_Contenido_Fecha_de_Registro,        Registro_de_Contenido.Hora_de_Registro As Registro_de_Contenido_Hora_de_Registro,        '' AS Registro_de_Contenido_Observatorio,        Registro_de_Contenido.Categoria AS Registro_de_Contenido_Categoria,        Categoria.Descripcion AS Categoria_Descripcion,        Registro_de_Contenido.Descripcion_de_Solicitud As Registro_de_Contenido_Descripcion_de_Solicitud,        Registro_de_Contenido.Reportero_Asignado AS Registro_de_Contenido_Reportero_Asignado,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        Registro_de_Contenido.Fecha_de_Compromiso As Registro_de_Contenido_Fecha_de_Compromiso,        Registro_de_Contenido.Estatus AS Registro_de_Contenido_Estatus,        Estatus_de_Contenido.Descripcion AS Estatus_de_Contenido_Descripcion,        Registro_de_Contenido.Administrador_de_Observatorio AS Registro_de_Contenido_Administrador_de_Observatorio,        TTUsuarios2.Nombre AS TTUsuarios2_Nombre,        Registro_de_Contenido.Reportero AS Registro_de_Contenido_Reportero,        TTUsuarios3.Nombre AS TTUsuarios3_Nombre,        Registro_de_Contenido.Titulo As Registro_de_Contenido_Titulo,        Registro_de_Contenido.Descripcion As Registro_de_Contenido_Descripcion,        Registro_de_Contenido.Contenido As Registro_de_Contenido_Contenido,        Registro_de_Contenido.Imagen AS Registro_de_Contenido_Imagen,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Contenido.Imagen_Miniatura AS Registro_de_Contenido_Imagen_Miniatura,        TTArchivos1.Nombre AS TTArchivos1_Nombre,        Registro_de_Contenido.Estilo AS Registro_de_Contenido_Estilo,        Estilo_de_Articulo.Descripcion AS Estilo_de_Articulo_Descripcion,        Registro_de_Contenido.Adjuntar_PDF AS Registro_de_Contenido_Adjuntar_PDF,        TTArchivos2.Nombre AS TTArchivos2_Nombre,        Registro_de_Contenido.Captura_Terminada As Registro_de_Contenido_Captura_Terminada,        Registro_de_Contenido.Autorizado_por AS Registro_de_Contenido_Autorizado_por,        TTUsuarios4.Nombre AS TTUsuarios4_Nombre,        Registro_de_Contenido.Fecha_de_Revision As Registro_de_Contenido_Fecha_de_Revision,        Registro_de_Contenido.Hora_de_Revision As Registro_de_Contenido_Hora_de_Revision,        Registro_de_Contenido.Autorizacion AS Registro_de_Contenido_Autorizacion,        Autorizacion.Descripcion AS Autorizacion_Descripcion,        Registro_de_Contenido.Motivo_de_Rechazo As Registro_de_Contenido_Motivo_de_Rechazo,        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,        Registro_de_Contenido.Fecha_de_Termino As Registro_de_Contenido_Fecha_de_Termino,        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As Registro_de_Contenido_Seleccionar_Todos_los_Observatorios,        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from ((((((((((((( Registro_de_Contenido       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido ON Estatus_de_Contenido.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as TTUsuarios2 ON TTUsuarios2.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as TTUsuarios3 ON TTUsuarios3.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as TTArchivos1 ON TTArchivos1.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo ON Estilo_de_Articulo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as TTArchivos2 ON TTArchivos2.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as TTUsuarios4 ON TTUsuarios4.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio ON Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)           Where Registro_de_Contenido.Fecha_de_Compromiso = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyEstatus(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Contenido.Folio As Registro_de_Contenido_Folio,        Registro_de_Contenido.Usuario_que_Registra AS Registro_de_Contenido_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Contenido.Fecha_de_Registro As Registro_de_Contenido_Fecha_de_Registro,        Registro_de_Contenido.Hora_de_Registro As Registro_de_Contenido_Hora_de_Registro,        '' AS Registro_de_Contenido_Observatorio,        Registro_de_Contenido.Categoria AS Registro_de_Contenido_Categoria,        Categoria.Descripcion AS Categoria_Descripcion,        Registro_de_Contenido.Descripcion_de_Solicitud As Registro_de_Contenido_Descripcion_de_Solicitud,        Registro_de_Contenido.Reportero_Asignado AS Registro_de_Contenido_Reportero_Asignado,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        Registro_de_Contenido.Fecha_de_Compromiso As Registro_de_Contenido_Fecha_de_Compromiso,        Registro_de_Contenido.Estatus AS Registro_de_Contenido_Estatus,        Estatus_de_Contenido.Descripcion AS Estatus_de_Contenido_Descripcion,        Registro_de_Contenido.Administrador_de_Observatorio AS Registro_de_Contenido_Administrador_de_Observatorio,        TTUsuarios2.Nombre AS TTUsuarios2_Nombre,        Registro_de_Contenido.Reportero AS Registro_de_Contenido_Reportero,        TTUsuarios3.Nombre AS TTUsuarios3_Nombre,        Registro_de_Contenido.Titulo As Registro_de_Contenido_Titulo,        Registro_de_Contenido.Descripcion As Registro_de_Contenido_Descripcion,        Registro_de_Contenido.Contenido As Registro_de_Contenido_Contenido,        Registro_de_Contenido.Imagen AS Registro_de_Contenido_Imagen,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Contenido.Imagen_Miniatura AS Registro_de_Contenido_Imagen_Miniatura,        TTArchivos1.Nombre AS TTArchivos1_Nombre,        Registro_de_Contenido.Estilo AS Registro_de_Contenido_Estilo,        Estilo_de_Articulo.Descripcion AS Estilo_de_Articulo_Descripcion,        Registro_de_Contenido.Adjuntar_PDF AS Registro_de_Contenido_Adjuntar_PDF,        TTArchivos2.Nombre AS TTArchivos2_Nombre,        Registro_de_Contenido.Captura_Terminada As Registro_de_Contenido_Captura_Terminada,        Registro_de_Contenido.Autorizado_por AS Registro_de_Contenido_Autorizado_por,        TTUsuarios4.Nombre AS TTUsuarios4_Nombre,        Registro_de_Contenido.Fecha_de_Revision As Registro_de_Contenido_Fecha_de_Revision,        Registro_de_Contenido.Hora_de_Revision As Registro_de_Contenido_Hora_de_Revision,        Registro_de_Contenido.Autorizacion AS Registro_de_Contenido_Autorizacion,        Autorizacion.Descripcion AS Autorizacion_Descripcion,        Registro_de_Contenido.Motivo_de_Rechazo As Registro_de_Contenido_Motivo_de_Rechazo,        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,        Registro_de_Contenido.Fecha_de_Termino As Registro_de_Contenido_Fecha_de_Termino,        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As Registro_de_Contenido_Seleccionar_Todos_los_Observatorios,        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from ((((((((((((( Registro_de_Contenido       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido ON Estatus_de_Contenido.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as TTUsuarios2 ON TTUsuarios2.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as TTUsuarios3 ON TTUsuarios3.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as TTArchivos1 ON TTArchivos1.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo ON Estilo_de_Articulo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as TTArchivos2 ON TTArchivos2.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as TTUsuarios4 ON TTUsuarios4.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio ON Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)           Where Registro_de_Contenido.Estatus = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyAdministrador_de_Observatorio(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Contenido.Folio As Registro_de_Contenido_Folio,        Registro_de_Contenido.Usuario_que_Registra AS Registro_de_Contenido_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Contenido.Fecha_de_Registro As Registro_de_Contenido_Fecha_de_Registro,        Registro_de_Contenido.Hora_de_Registro As Registro_de_Contenido_Hora_de_Registro,        '' AS Registro_de_Contenido_Observatorio,        Registro_de_Contenido.Categoria AS Registro_de_Contenido_Categoria,        Categoria.Descripcion AS Categoria_Descripcion,        Registro_de_Contenido.Descripcion_de_Solicitud As Registro_de_Contenido_Descripcion_de_Solicitud,        Registro_de_Contenido.Reportero_Asignado AS Registro_de_Contenido_Reportero_Asignado,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        Registro_de_Contenido.Fecha_de_Compromiso As Registro_de_Contenido_Fecha_de_Compromiso,        Registro_de_Contenido.Estatus AS Registro_de_Contenido_Estatus,        Estatus_de_Contenido.Descripcion AS Estatus_de_Contenido_Descripcion,        Registro_de_Contenido.Administrador_de_Observatorio AS Registro_de_Contenido_Administrador_de_Observatorio,        TTUsuarios2.Nombre AS TTUsuarios2_Nombre,        Registro_de_Contenido.Reportero AS Registro_de_Contenido_Reportero,        TTUsuarios3.Nombre AS TTUsuarios3_Nombre,        Registro_de_Contenido.Titulo As Registro_de_Contenido_Titulo,        Registro_de_Contenido.Descripcion As Registro_de_Contenido_Descripcion,        Registro_de_Contenido.Contenido As Registro_de_Contenido_Contenido,        Registro_de_Contenido.Imagen AS Registro_de_Contenido_Imagen,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Contenido.Imagen_Miniatura AS Registro_de_Contenido_Imagen_Miniatura,        TTArchivos1.Nombre AS TTArchivos1_Nombre,        Registro_de_Contenido.Estilo AS Registro_de_Contenido_Estilo,        Estilo_de_Articulo.Descripcion AS Estilo_de_Articulo_Descripcion,        Registro_de_Contenido.Adjuntar_PDF AS Registro_de_Contenido_Adjuntar_PDF,        TTArchivos2.Nombre AS TTArchivos2_Nombre,        Registro_de_Contenido.Captura_Terminada As Registro_de_Contenido_Captura_Terminada,        Registro_de_Contenido.Autorizado_por AS Registro_de_Contenido_Autorizado_por,        TTUsuarios4.Nombre AS TTUsuarios4_Nombre,        Registro_de_Contenido.Fecha_de_Revision As Registro_de_Contenido_Fecha_de_Revision,        Registro_de_Contenido.Hora_de_Revision As Registro_de_Contenido_Hora_de_Revision,        Registro_de_Contenido.Autorizacion AS Registro_de_Contenido_Autorizacion,        Autorizacion.Descripcion AS Autorizacion_Descripcion,        Registro_de_Contenido.Motivo_de_Rechazo As Registro_de_Contenido_Motivo_de_Rechazo,        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,        Registro_de_Contenido.Fecha_de_Termino As Registro_de_Contenido_Fecha_de_Termino,        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As Registro_de_Contenido_Seleccionar_Todos_los_Observatorios,        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from ((((((((((((( Registro_de_Contenido       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido ON Estatus_de_Contenido.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as TTUsuarios2 ON TTUsuarios2.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as TTUsuarios3 ON TTUsuarios3.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as TTArchivos1 ON TTArchivos1.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo ON Estilo_de_Articulo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as TTArchivos2 ON TTArchivos2.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as TTUsuarios4 ON TTUsuarios4.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio ON Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)           Where Registro_de_Contenido.Administrador_de_Observatorio = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyReportero(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Contenido.Folio As Registro_de_Contenido_Folio,        Registro_de_Contenido.Usuario_que_Registra AS Registro_de_Contenido_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Contenido.Fecha_de_Registro As Registro_de_Contenido_Fecha_de_Registro,        Registro_de_Contenido.Hora_de_Registro As Registro_de_Contenido_Hora_de_Registro,        '' AS Registro_de_Contenido_Observatorio,        Registro_de_Contenido.Categoria AS Registro_de_Contenido_Categoria,        Categoria.Descripcion AS Categoria_Descripcion,        Registro_de_Contenido.Descripcion_de_Solicitud As Registro_de_Contenido_Descripcion_de_Solicitud,        Registro_de_Contenido.Reportero_Asignado AS Registro_de_Contenido_Reportero_Asignado,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        Registro_de_Contenido.Fecha_de_Compromiso As Registro_de_Contenido_Fecha_de_Compromiso,        Registro_de_Contenido.Estatus AS Registro_de_Contenido_Estatus,        Estatus_de_Contenido.Descripcion AS Estatus_de_Contenido_Descripcion,        Registro_de_Contenido.Administrador_de_Observatorio AS Registro_de_Contenido_Administrador_de_Observatorio,        TTUsuarios2.Nombre AS TTUsuarios2_Nombre,        Registro_de_Contenido.Reportero AS Registro_de_Contenido_Reportero,        TTUsuarios3.Nombre AS TTUsuarios3_Nombre,        Registro_de_Contenido.Titulo As Registro_de_Contenido_Titulo,        Registro_de_Contenido.Descripcion As Registro_de_Contenido_Descripcion,        Registro_de_Contenido.Contenido As Registro_de_Contenido_Contenido,        Registro_de_Contenido.Imagen AS Registro_de_Contenido_Imagen,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Contenido.Imagen_Miniatura AS Registro_de_Contenido_Imagen_Miniatura,        TTArchivos1.Nombre AS TTArchivos1_Nombre,        Registro_de_Contenido.Estilo AS Registro_de_Contenido_Estilo,        Estilo_de_Articulo.Descripcion AS Estilo_de_Articulo_Descripcion,        Registro_de_Contenido.Adjuntar_PDF AS Registro_de_Contenido_Adjuntar_PDF,        TTArchivos2.Nombre AS TTArchivos2_Nombre,        Registro_de_Contenido.Captura_Terminada As Registro_de_Contenido_Captura_Terminada,        Registro_de_Contenido.Autorizado_por AS Registro_de_Contenido_Autorizado_por,        TTUsuarios4.Nombre AS TTUsuarios4_Nombre,        Registro_de_Contenido.Fecha_de_Revision As Registro_de_Contenido_Fecha_de_Revision,        Registro_de_Contenido.Hora_de_Revision As Registro_de_Contenido_Hora_de_Revision,        Registro_de_Contenido.Autorizacion AS Registro_de_Contenido_Autorizacion,        Autorizacion.Descripcion AS Autorizacion_Descripcion,        Registro_de_Contenido.Motivo_de_Rechazo As Registro_de_Contenido_Motivo_de_Rechazo,        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,        Registro_de_Contenido.Fecha_de_Termino As Registro_de_Contenido_Fecha_de_Termino,        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As Registro_de_Contenido_Seleccionar_Todos_los_Observatorios,        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from ((((((((((((( Registro_de_Contenido       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido ON Estatus_de_Contenido.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as TTUsuarios2 ON TTUsuarios2.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as TTUsuarios3 ON TTUsuarios3.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as TTArchivos1 ON TTArchivos1.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo ON Estilo_de_Articulo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as TTArchivos2 ON TTArchivos2.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as TTUsuarios4 ON TTUsuarios4.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio ON Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)           Where Registro_de_Contenido.Reportero = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyTitulo(String Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Contenido.Folio As Registro_de_Contenido_Folio,        Registro_de_Contenido.Usuario_que_Registra AS Registro_de_Contenido_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Contenido.Fecha_de_Registro As Registro_de_Contenido_Fecha_de_Registro,        Registro_de_Contenido.Hora_de_Registro As Registro_de_Contenido_Hora_de_Registro,        '' AS Registro_de_Contenido_Observatorio,        Registro_de_Contenido.Categoria AS Registro_de_Contenido_Categoria,        Categoria.Descripcion AS Categoria_Descripcion,        Registro_de_Contenido.Descripcion_de_Solicitud As Registro_de_Contenido_Descripcion_de_Solicitud,        Registro_de_Contenido.Reportero_Asignado AS Registro_de_Contenido_Reportero_Asignado,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        Registro_de_Contenido.Fecha_de_Compromiso As Registro_de_Contenido_Fecha_de_Compromiso,        Registro_de_Contenido.Estatus AS Registro_de_Contenido_Estatus,        Estatus_de_Contenido.Descripcion AS Estatus_de_Contenido_Descripcion,        Registro_de_Contenido.Administrador_de_Observatorio AS Registro_de_Contenido_Administrador_de_Observatorio,        TTUsuarios2.Nombre AS TTUsuarios2_Nombre,        Registro_de_Contenido.Reportero AS Registro_de_Contenido_Reportero,        TTUsuarios3.Nombre AS TTUsuarios3_Nombre,        Registro_de_Contenido.Titulo As Registro_de_Contenido_Titulo,        Registro_de_Contenido.Descripcion As Registro_de_Contenido_Descripcion,        Registro_de_Contenido.Contenido As Registro_de_Contenido_Contenido,        Registro_de_Contenido.Imagen AS Registro_de_Contenido_Imagen,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Contenido.Imagen_Miniatura AS Registro_de_Contenido_Imagen_Miniatura,        TTArchivos1.Nombre AS TTArchivos1_Nombre,        Registro_de_Contenido.Estilo AS Registro_de_Contenido_Estilo,        Estilo_de_Articulo.Descripcion AS Estilo_de_Articulo_Descripcion,        Registro_de_Contenido.Adjuntar_PDF AS Registro_de_Contenido_Adjuntar_PDF,        TTArchivos2.Nombre AS TTArchivos2_Nombre,        Registro_de_Contenido.Captura_Terminada As Registro_de_Contenido_Captura_Terminada,        Registro_de_Contenido.Autorizado_por AS Registro_de_Contenido_Autorizado_por,        TTUsuarios4.Nombre AS TTUsuarios4_Nombre,        Registro_de_Contenido.Fecha_de_Revision As Registro_de_Contenido_Fecha_de_Revision,        Registro_de_Contenido.Hora_de_Revision As Registro_de_Contenido_Hora_de_Revision,        Registro_de_Contenido.Autorizacion AS Registro_de_Contenido_Autorizacion,        Autorizacion.Descripcion AS Autorizacion_Descripcion,        Registro_de_Contenido.Motivo_de_Rechazo As Registro_de_Contenido_Motivo_de_Rechazo,        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,        Registro_de_Contenido.Fecha_de_Termino As Registro_de_Contenido_Fecha_de_Termino,        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As Registro_de_Contenido_Seleccionar_Todos_los_Observatorios,        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from ((((((((((((( Registro_de_Contenido       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido ON Estatus_de_Contenido.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as TTUsuarios2 ON TTUsuarios2.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as TTUsuarios3 ON TTUsuarios3.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as TTArchivos1 ON TTArchivos1.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo ON Estilo_de_Articulo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as TTArchivos2 ON TTArchivos2.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as TTUsuarios4 ON TTUsuarios4.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio ON Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)           Where Registro_de_Contenido.Titulo = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyDescripcion(String Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Contenido.Folio As Registro_de_Contenido_Folio,        Registro_de_Contenido.Usuario_que_Registra AS Registro_de_Contenido_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Contenido.Fecha_de_Registro As Registro_de_Contenido_Fecha_de_Registro,        Registro_de_Contenido.Hora_de_Registro As Registro_de_Contenido_Hora_de_Registro,        '' AS Registro_de_Contenido_Observatorio,        Registro_de_Contenido.Categoria AS Registro_de_Contenido_Categoria,        Categoria.Descripcion AS Categoria_Descripcion,        Registro_de_Contenido.Descripcion_de_Solicitud As Registro_de_Contenido_Descripcion_de_Solicitud,        Registro_de_Contenido.Reportero_Asignado AS Registro_de_Contenido_Reportero_Asignado,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        Registro_de_Contenido.Fecha_de_Compromiso As Registro_de_Contenido_Fecha_de_Compromiso,        Registro_de_Contenido.Estatus AS Registro_de_Contenido_Estatus,        Estatus_de_Contenido.Descripcion AS Estatus_de_Contenido_Descripcion,        Registro_de_Contenido.Administrador_de_Observatorio AS Registro_de_Contenido_Administrador_de_Observatorio,        TTUsuarios2.Nombre AS TTUsuarios2_Nombre,        Registro_de_Contenido.Reportero AS Registro_de_Contenido_Reportero,        TTUsuarios3.Nombre AS TTUsuarios3_Nombre,        Registro_de_Contenido.Titulo As Registro_de_Contenido_Titulo,        Registro_de_Contenido.Descripcion As Registro_de_Contenido_Descripcion,        Registro_de_Contenido.Contenido As Registro_de_Contenido_Contenido,        Registro_de_Contenido.Imagen AS Registro_de_Contenido_Imagen,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Contenido.Imagen_Miniatura AS Registro_de_Contenido_Imagen_Miniatura,        TTArchivos1.Nombre AS TTArchivos1_Nombre,        Registro_de_Contenido.Estilo AS Registro_de_Contenido_Estilo,        Estilo_de_Articulo.Descripcion AS Estilo_de_Articulo_Descripcion,        Registro_de_Contenido.Adjuntar_PDF AS Registro_de_Contenido_Adjuntar_PDF,        TTArchivos2.Nombre AS TTArchivos2_Nombre,        Registro_de_Contenido.Captura_Terminada As Registro_de_Contenido_Captura_Terminada,        Registro_de_Contenido.Autorizado_por AS Registro_de_Contenido_Autorizado_por,        TTUsuarios4.Nombre AS TTUsuarios4_Nombre,        Registro_de_Contenido.Fecha_de_Revision As Registro_de_Contenido_Fecha_de_Revision,        Registro_de_Contenido.Hora_de_Revision As Registro_de_Contenido_Hora_de_Revision,        Registro_de_Contenido.Autorizacion AS Registro_de_Contenido_Autorizacion,        Autorizacion.Descripcion AS Autorizacion_Descripcion,        Registro_de_Contenido.Motivo_de_Rechazo As Registro_de_Contenido_Motivo_de_Rechazo,        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,        Registro_de_Contenido.Fecha_de_Termino As Registro_de_Contenido_Fecha_de_Termino,        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As Registro_de_Contenido_Seleccionar_Todos_los_Observatorios,        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from ((((((((((((( Registro_de_Contenido       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido ON Estatus_de_Contenido.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as TTUsuarios2 ON TTUsuarios2.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as TTUsuarios3 ON TTUsuarios3.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as TTArchivos1 ON TTArchivos1.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo ON Estilo_de_Articulo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as TTArchivos2 ON TTArchivos2.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as TTUsuarios4 ON TTUsuarios4.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio ON Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)           Where Registro_de_Contenido.Descripcion = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyContenido(String Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Contenido.Folio As Registro_de_Contenido_Folio,        Registro_de_Contenido.Usuario_que_Registra AS Registro_de_Contenido_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Contenido.Fecha_de_Registro As Registro_de_Contenido_Fecha_de_Registro,        Registro_de_Contenido.Hora_de_Registro As Registro_de_Contenido_Hora_de_Registro,        '' AS Registro_de_Contenido_Observatorio,        Registro_de_Contenido.Categoria AS Registro_de_Contenido_Categoria,        Categoria.Descripcion AS Categoria_Descripcion,        Registro_de_Contenido.Descripcion_de_Solicitud As Registro_de_Contenido_Descripcion_de_Solicitud,        Registro_de_Contenido.Reportero_Asignado AS Registro_de_Contenido_Reportero_Asignado,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        Registro_de_Contenido.Fecha_de_Compromiso As Registro_de_Contenido_Fecha_de_Compromiso,        Registro_de_Contenido.Estatus AS Registro_de_Contenido_Estatus,        Estatus_de_Contenido.Descripcion AS Estatus_de_Contenido_Descripcion,        Registro_de_Contenido.Administrador_de_Observatorio AS Registro_de_Contenido_Administrador_de_Observatorio,        TTUsuarios2.Nombre AS TTUsuarios2_Nombre,        Registro_de_Contenido.Reportero AS Registro_de_Contenido_Reportero,        TTUsuarios3.Nombre AS TTUsuarios3_Nombre,        Registro_de_Contenido.Titulo As Registro_de_Contenido_Titulo,        Registro_de_Contenido.Descripcion As Registro_de_Contenido_Descripcion,        Registro_de_Contenido.Contenido As Registro_de_Contenido_Contenido,        Registro_de_Contenido.Imagen AS Registro_de_Contenido_Imagen,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Contenido.Imagen_Miniatura AS Registro_de_Contenido_Imagen_Miniatura,        TTArchivos1.Nombre AS TTArchivos1_Nombre,        Registro_de_Contenido.Estilo AS Registro_de_Contenido_Estilo,        Estilo_de_Articulo.Descripcion AS Estilo_de_Articulo_Descripcion,        Registro_de_Contenido.Adjuntar_PDF AS Registro_de_Contenido_Adjuntar_PDF,        TTArchivos2.Nombre AS TTArchivos2_Nombre,        Registro_de_Contenido.Captura_Terminada As Registro_de_Contenido_Captura_Terminada,        Registro_de_Contenido.Autorizado_por AS Registro_de_Contenido_Autorizado_por,        TTUsuarios4.Nombre AS TTUsuarios4_Nombre,        Registro_de_Contenido.Fecha_de_Revision As Registro_de_Contenido_Fecha_de_Revision,        Registro_de_Contenido.Hora_de_Revision As Registro_de_Contenido_Hora_de_Revision,        Registro_de_Contenido.Autorizacion AS Registro_de_Contenido_Autorizacion,        Autorizacion.Descripcion AS Autorizacion_Descripcion,        Registro_de_Contenido.Motivo_de_Rechazo As Registro_de_Contenido_Motivo_de_Rechazo,        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,        Registro_de_Contenido.Fecha_de_Termino As Registro_de_Contenido_Fecha_de_Termino,        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As Registro_de_Contenido_Seleccionar_Todos_los_Observatorios,        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from ((((((((((((( Registro_de_Contenido       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido ON Estatus_de_Contenido.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as TTUsuarios2 ON TTUsuarios2.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as TTUsuarios3 ON TTUsuarios3.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as TTArchivos1 ON TTArchivos1.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo ON Estilo_de_Articulo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as TTArchivos2 ON TTArchivos2.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as TTUsuarios4 ON TTUsuarios4.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio ON Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)           Where Registro_de_Contenido.Contenido = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyImagen(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Contenido.Folio As Registro_de_Contenido_Folio,        Registro_de_Contenido.Usuario_que_Registra AS Registro_de_Contenido_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Contenido.Fecha_de_Registro As Registro_de_Contenido_Fecha_de_Registro,        Registro_de_Contenido.Hora_de_Registro As Registro_de_Contenido_Hora_de_Registro,        '' AS Registro_de_Contenido_Observatorio,        Registro_de_Contenido.Categoria AS Registro_de_Contenido_Categoria,        Categoria.Descripcion AS Categoria_Descripcion,        Registro_de_Contenido.Descripcion_de_Solicitud As Registro_de_Contenido_Descripcion_de_Solicitud,        Registro_de_Contenido.Reportero_Asignado AS Registro_de_Contenido_Reportero_Asignado,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        Registro_de_Contenido.Fecha_de_Compromiso As Registro_de_Contenido_Fecha_de_Compromiso,        Registro_de_Contenido.Estatus AS Registro_de_Contenido_Estatus,        Estatus_de_Contenido.Descripcion AS Estatus_de_Contenido_Descripcion,        Registro_de_Contenido.Administrador_de_Observatorio AS Registro_de_Contenido_Administrador_de_Observatorio,        TTUsuarios2.Nombre AS TTUsuarios2_Nombre,        Registro_de_Contenido.Reportero AS Registro_de_Contenido_Reportero,        TTUsuarios3.Nombre AS TTUsuarios3_Nombre,        Registro_de_Contenido.Titulo As Registro_de_Contenido_Titulo,        Registro_de_Contenido.Descripcion As Registro_de_Contenido_Descripcion,        Registro_de_Contenido.Contenido As Registro_de_Contenido_Contenido,        Registro_de_Contenido.Imagen AS Registro_de_Contenido_Imagen,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Contenido.Imagen_Miniatura AS Registro_de_Contenido_Imagen_Miniatura,        TTArchivos1.Nombre AS TTArchivos1_Nombre,        Registro_de_Contenido.Estilo AS Registro_de_Contenido_Estilo,        Estilo_de_Articulo.Descripcion AS Estilo_de_Articulo_Descripcion,        Registro_de_Contenido.Adjuntar_PDF AS Registro_de_Contenido_Adjuntar_PDF,        TTArchivos2.Nombre AS TTArchivos2_Nombre,        Registro_de_Contenido.Captura_Terminada As Registro_de_Contenido_Captura_Terminada,        Registro_de_Contenido.Autorizado_por AS Registro_de_Contenido_Autorizado_por,        TTUsuarios4.Nombre AS TTUsuarios4_Nombre,        Registro_de_Contenido.Fecha_de_Revision As Registro_de_Contenido_Fecha_de_Revision,        Registro_de_Contenido.Hora_de_Revision As Registro_de_Contenido_Hora_de_Revision,        Registro_de_Contenido.Autorizacion AS Registro_de_Contenido_Autorizacion,        Autorizacion.Descripcion AS Autorizacion_Descripcion,        Registro_de_Contenido.Motivo_de_Rechazo As Registro_de_Contenido_Motivo_de_Rechazo,        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,        Registro_de_Contenido.Fecha_de_Termino As Registro_de_Contenido_Fecha_de_Termino,        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As Registro_de_Contenido_Seleccionar_Todos_los_Observatorios,        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from ((((((((((((( Registro_de_Contenido       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido ON Estatus_de_Contenido.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as TTUsuarios2 ON TTUsuarios2.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as TTUsuarios3 ON TTUsuarios3.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as TTArchivos1 ON TTArchivos1.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo ON Estilo_de_Articulo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as TTArchivos2 ON TTArchivos2.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as TTUsuarios4 ON TTUsuarios4.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio ON Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)           Where Registro_de_Contenido.Imagen = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyImagen_Miniatura(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Contenido.Folio As Registro_de_Contenido_Folio,        Registro_de_Contenido.Usuario_que_Registra AS Registro_de_Contenido_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Contenido.Fecha_de_Registro As Registro_de_Contenido_Fecha_de_Registro,        Registro_de_Contenido.Hora_de_Registro As Registro_de_Contenido_Hora_de_Registro,        '' AS Registro_de_Contenido_Observatorio,        Registro_de_Contenido.Categoria AS Registro_de_Contenido_Categoria,        Categoria.Descripcion AS Categoria_Descripcion,        Registro_de_Contenido.Descripcion_de_Solicitud As Registro_de_Contenido_Descripcion_de_Solicitud,        Registro_de_Contenido.Reportero_Asignado AS Registro_de_Contenido_Reportero_Asignado,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        Registro_de_Contenido.Fecha_de_Compromiso As Registro_de_Contenido_Fecha_de_Compromiso,        Registro_de_Contenido.Estatus AS Registro_de_Contenido_Estatus,        Estatus_de_Contenido.Descripcion AS Estatus_de_Contenido_Descripcion,        Registro_de_Contenido.Administrador_de_Observatorio AS Registro_de_Contenido_Administrador_de_Observatorio,        TTUsuarios2.Nombre AS TTUsuarios2_Nombre,        Registro_de_Contenido.Reportero AS Registro_de_Contenido_Reportero,        TTUsuarios3.Nombre AS TTUsuarios3_Nombre,        Registro_de_Contenido.Titulo As Registro_de_Contenido_Titulo,        Registro_de_Contenido.Descripcion As Registro_de_Contenido_Descripcion,        Registro_de_Contenido.Contenido As Registro_de_Contenido_Contenido,        Registro_de_Contenido.Imagen AS Registro_de_Contenido_Imagen,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Contenido.Imagen_Miniatura AS Registro_de_Contenido_Imagen_Miniatura,        TTArchivos1.Nombre AS TTArchivos1_Nombre,        Registro_de_Contenido.Estilo AS Registro_de_Contenido_Estilo,        Estilo_de_Articulo.Descripcion AS Estilo_de_Articulo_Descripcion,        Registro_de_Contenido.Adjuntar_PDF AS Registro_de_Contenido_Adjuntar_PDF,        TTArchivos2.Nombre AS TTArchivos2_Nombre,        Registro_de_Contenido.Captura_Terminada As Registro_de_Contenido_Captura_Terminada,        Registro_de_Contenido.Autorizado_por AS Registro_de_Contenido_Autorizado_por,        TTUsuarios4.Nombre AS TTUsuarios4_Nombre,        Registro_de_Contenido.Fecha_de_Revision As Registro_de_Contenido_Fecha_de_Revision,        Registro_de_Contenido.Hora_de_Revision As Registro_de_Contenido_Hora_de_Revision,        Registro_de_Contenido.Autorizacion AS Registro_de_Contenido_Autorizacion,        Autorizacion.Descripcion AS Autorizacion_Descripcion,        Registro_de_Contenido.Motivo_de_Rechazo As Registro_de_Contenido_Motivo_de_Rechazo,        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,        Registro_de_Contenido.Fecha_de_Termino As Registro_de_Contenido_Fecha_de_Termino,        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As Registro_de_Contenido_Seleccionar_Todos_los_Observatorios,        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from ((((((((((((( Registro_de_Contenido       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido ON Estatus_de_Contenido.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as TTUsuarios2 ON TTUsuarios2.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as TTUsuarios3 ON TTUsuarios3.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as TTArchivos1 ON TTArchivos1.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo ON Estilo_de_Articulo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as TTArchivos2 ON TTArchivos2.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as TTUsuarios4 ON TTUsuarios4.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio ON Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)           Where Registro_de_Contenido.Imagen_Miniatura = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyEstilo(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Contenido.Folio As Registro_de_Contenido_Folio,        Registro_de_Contenido.Usuario_que_Registra AS Registro_de_Contenido_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Contenido.Fecha_de_Registro As Registro_de_Contenido_Fecha_de_Registro,        Registro_de_Contenido.Hora_de_Registro As Registro_de_Contenido_Hora_de_Registro,        '' AS Registro_de_Contenido_Observatorio,        Registro_de_Contenido.Categoria AS Registro_de_Contenido_Categoria,        Categoria.Descripcion AS Categoria_Descripcion,        Registro_de_Contenido.Descripcion_de_Solicitud As Registro_de_Contenido_Descripcion_de_Solicitud,        Registro_de_Contenido.Reportero_Asignado AS Registro_de_Contenido_Reportero_Asignado,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        Registro_de_Contenido.Fecha_de_Compromiso As Registro_de_Contenido_Fecha_de_Compromiso,        Registro_de_Contenido.Estatus AS Registro_de_Contenido_Estatus,        Estatus_de_Contenido.Descripcion AS Estatus_de_Contenido_Descripcion,        Registro_de_Contenido.Administrador_de_Observatorio AS Registro_de_Contenido_Administrador_de_Observatorio,        TTUsuarios2.Nombre AS TTUsuarios2_Nombre,        Registro_de_Contenido.Reportero AS Registro_de_Contenido_Reportero,        TTUsuarios3.Nombre AS TTUsuarios3_Nombre,        Registro_de_Contenido.Titulo As Registro_de_Contenido_Titulo,        Registro_de_Contenido.Descripcion As Registro_de_Contenido_Descripcion,        Registro_de_Contenido.Contenido As Registro_de_Contenido_Contenido,        Registro_de_Contenido.Imagen AS Registro_de_Contenido_Imagen,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Contenido.Imagen_Miniatura AS Registro_de_Contenido_Imagen_Miniatura,        TTArchivos1.Nombre AS TTArchivos1_Nombre,        Registro_de_Contenido.Estilo AS Registro_de_Contenido_Estilo,        Estilo_de_Articulo.Descripcion AS Estilo_de_Articulo_Descripcion,        Registro_de_Contenido.Adjuntar_PDF AS Registro_de_Contenido_Adjuntar_PDF,        TTArchivos2.Nombre AS TTArchivos2_Nombre,        Registro_de_Contenido.Captura_Terminada As Registro_de_Contenido_Captura_Terminada,        Registro_de_Contenido.Autorizado_por AS Registro_de_Contenido_Autorizado_por,        TTUsuarios4.Nombre AS TTUsuarios4_Nombre,        Registro_de_Contenido.Fecha_de_Revision As Registro_de_Contenido_Fecha_de_Revision,        Registro_de_Contenido.Hora_de_Revision As Registro_de_Contenido_Hora_de_Revision,        Registro_de_Contenido.Autorizacion AS Registro_de_Contenido_Autorizacion,        Autorizacion.Descripcion AS Autorizacion_Descripcion,        Registro_de_Contenido.Motivo_de_Rechazo As Registro_de_Contenido_Motivo_de_Rechazo,        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,        Registro_de_Contenido.Fecha_de_Termino As Registro_de_Contenido_Fecha_de_Termino,        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As Registro_de_Contenido_Seleccionar_Todos_los_Observatorios,        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from ((((((((((((( Registro_de_Contenido       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido ON Estatus_de_Contenido.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as TTUsuarios2 ON TTUsuarios2.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as TTUsuarios3 ON TTUsuarios3.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as TTArchivos1 ON TTArchivos1.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo ON Estilo_de_Articulo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as TTArchivos2 ON TTArchivos2.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as TTUsuarios4 ON TTUsuarios4.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio ON Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)           Where Registro_de_Contenido.Estilo = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyAdjuntar_PDF(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Contenido.Folio As Registro_de_Contenido_Folio,        Registro_de_Contenido.Usuario_que_Registra AS Registro_de_Contenido_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Contenido.Fecha_de_Registro As Registro_de_Contenido_Fecha_de_Registro,        Registro_de_Contenido.Hora_de_Registro As Registro_de_Contenido_Hora_de_Registro,        '' AS Registro_de_Contenido_Observatorio,        Registro_de_Contenido.Categoria AS Registro_de_Contenido_Categoria,        Categoria.Descripcion AS Categoria_Descripcion,        Registro_de_Contenido.Descripcion_de_Solicitud As Registro_de_Contenido_Descripcion_de_Solicitud,        Registro_de_Contenido.Reportero_Asignado AS Registro_de_Contenido_Reportero_Asignado,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        Registro_de_Contenido.Fecha_de_Compromiso As Registro_de_Contenido_Fecha_de_Compromiso,        Registro_de_Contenido.Estatus AS Registro_de_Contenido_Estatus,        Estatus_de_Contenido.Descripcion AS Estatus_de_Contenido_Descripcion,        Registro_de_Contenido.Administrador_de_Observatorio AS Registro_de_Contenido_Administrador_de_Observatorio,        TTUsuarios2.Nombre AS TTUsuarios2_Nombre,        Registro_de_Contenido.Reportero AS Registro_de_Contenido_Reportero,        TTUsuarios3.Nombre AS TTUsuarios3_Nombre,        Registro_de_Contenido.Titulo As Registro_de_Contenido_Titulo,        Registro_de_Contenido.Descripcion As Registro_de_Contenido_Descripcion,        Registro_de_Contenido.Contenido As Registro_de_Contenido_Contenido,        Registro_de_Contenido.Imagen AS Registro_de_Contenido_Imagen,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Contenido.Imagen_Miniatura AS Registro_de_Contenido_Imagen_Miniatura,        TTArchivos1.Nombre AS TTArchivos1_Nombre,        Registro_de_Contenido.Estilo AS Registro_de_Contenido_Estilo,        Estilo_de_Articulo.Descripcion AS Estilo_de_Articulo_Descripcion,        Registro_de_Contenido.Adjuntar_PDF AS Registro_de_Contenido_Adjuntar_PDF,        TTArchivos2.Nombre AS TTArchivos2_Nombre,        Registro_de_Contenido.Captura_Terminada As Registro_de_Contenido_Captura_Terminada,        Registro_de_Contenido.Autorizado_por AS Registro_de_Contenido_Autorizado_por,        TTUsuarios4.Nombre AS TTUsuarios4_Nombre,        Registro_de_Contenido.Fecha_de_Revision As Registro_de_Contenido_Fecha_de_Revision,        Registro_de_Contenido.Hora_de_Revision As Registro_de_Contenido_Hora_de_Revision,        Registro_de_Contenido.Autorizacion AS Registro_de_Contenido_Autorizacion,        Autorizacion.Descripcion AS Autorizacion_Descripcion,        Registro_de_Contenido.Motivo_de_Rechazo As Registro_de_Contenido_Motivo_de_Rechazo,        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,        Registro_de_Contenido.Fecha_de_Termino As Registro_de_Contenido_Fecha_de_Termino,        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As Registro_de_Contenido_Seleccionar_Todos_los_Observatorios,        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from ((((((((((((( Registro_de_Contenido       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido ON Estatus_de_Contenido.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as TTUsuarios2 ON TTUsuarios2.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as TTUsuarios3 ON TTUsuarios3.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as TTArchivos1 ON TTArchivos1.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo ON Estilo_de_Articulo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as TTArchivos2 ON TTArchivos2.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as TTUsuarios4 ON TTUsuarios4.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio ON Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)           Where Registro_de_Contenido.Adjuntar_PDF = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyCaptura_Terminada(Boolean Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Contenido.Folio As Registro_de_Contenido_Folio,        Registro_de_Contenido.Usuario_que_Registra AS Registro_de_Contenido_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Contenido.Fecha_de_Registro As Registro_de_Contenido_Fecha_de_Registro,        Registro_de_Contenido.Hora_de_Registro As Registro_de_Contenido_Hora_de_Registro,        '' AS Registro_de_Contenido_Observatorio,        Registro_de_Contenido.Categoria AS Registro_de_Contenido_Categoria,        Categoria.Descripcion AS Categoria_Descripcion,        Registro_de_Contenido.Descripcion_de_Solicitud As Registro_de_Contenido_Descripcion_de_Solicitud,        Registro_de_Contenido.Reportero_Asignado AS Registro_de_Contenido_Reportero_Asignado,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        Registro_de_Contenido.Fecha_de_Compromiso As Registro_de_Contenido_Fecha_de_Compromiso,        Registro_de_Contenido.Estatus AS Registro_de_Contenido_Estatus,        Estatus_de_Contenido.Descripcion AS Estatus_de_Contenido_Descripcion,        Registro_de_Contenido.Administrador_de_Observatorio AS Registro_de_Contenido_Administrador_de_Observatorio,        TTUsuarios2.Nombre AS TTUsuarios2_Nombre,        Registro_de_Contenido.Reportero AS Registro_de_Contenido_Reportero,        TTUsuarios3.Nombre AS TTUsuarios3_Nombre,        Registro_de_Contenido.Titulo As Registro_de_Contenido_Titulo,        Registro_de_Contenido.Descripcion As Registro_de_Contenido_Descripcion,        Registro_de_Contenido.Contenido As Registro_de_Contenido_Contenido,        Registro_de_Contenido.Imagen AS Registro_de_Contenido_Imagen,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Contenido.Imagen_Miniatura AS Registro_de_Contenido_Imagen_Miniatura,        TTArchivos1.Nombre AS TTArchivos1_Nombre,        Registro_de_Contenido.Estilo AS Registro_de_Contenido_Estilo,        Estilo_de_Articulo.Descripcion AS Estilo_de_Articulo_Descripcion,        Registro_de_Contenido.Adjuntar_PDF AS Registro_de_Contenido_Adjuntar_PDF,        TTArchivos2.Nombre AS TTArchivos2_Nombre,        Registro_de_Contenido.Captura_Terminada As Registro_de_Contenido_Captura_Terminada,        Registro_de_Contenido.Autorizado_por AS Registro_de_Contenido_Autorizado_por,        TTUsuarios4.Nombre AS TTUsuarios4_Nombre,        Registro_de_Contenido.Fecha_de_Revision As Registro_de_Contenido_Fecha_de_Revision,        Registro_de_Contenido.Hora_de_Revision As Registro_de_Contenido_Hora_de_Revision,        Registro_de_Contenido.Autorizacion AS Registro_de_Contenido_Autorizacion,        Autorizacion.Descripcion AS Autorizacion_Descripcion,        Registro_de_Contenido.Motivo_de_Rechazo As Registro_de_Contenido_Motivo_de_Rechazo,        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,        Registro_de_Contenido.Fecha_de_Termino As Registro_de_Contenido_Fecha_de_Termino,        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As Registro_de_Contenido_Seleccionar_Todos_los_Observatorios,        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from ((((((((((((( Registro_de_Contenido       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido ON Estatus_de_Contenido.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as TTUsuarios2 ON TTUsuarios2.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as TTUsuarios3 ON TTUsuarios3.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as TTArchivos1 ON TTArchivos1.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo ON Estilo_de_Articulo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as TTArchivos2 ON TTArchivos2.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as TTUsuarios4 ON TTUsuarios4.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio ON Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)           Where Registro_de_Contenido.Captura_Terminada = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyAutorizado_por(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Contenido.Folio As Registro_de_Contenido_Folio,        Registro_de_Contenido.Usuario_que_Registra AS Registro_de_Contenido_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Contenido.Fecha_de_Registro As Registro_de_Contenido_Fecha_de_Registro,        Registro_de_Contenido.Hora_de_Registro As Registro_de_Contenido_Hora_de_Registro,        '' AS Registro_de_Contenido_Observatorio,        Registro_de_Contenido.Categoria AS Registro_de_Contenido_Categoria,        Categoria.Descripcion AS Categoria_Descripcion,        Registro_de_Contenido.Descripcion_de_Solicitud As Registro_de_Contenido_Descripcion_de_Solicitud,        Registro_de_Contenido.Reportero_Asignado AS Registro_de_Contenido_Reportero_Asignado,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        Registro_de_Contenido.Fecha_de_Compromiso As Registro_de_Contenido_Fecha_de_Compromiso,        Registro_de_Contenido.Estatus AS Registro_de_Contenido_Estatus,        Estatus_de_Contenido.Descripcion AS Estatus_de_Contenido_Descripcion,        Registro_de_Contenido.Administrador_de_Observatorio AS Registro_de_Contenido_Administrador_de_Observatorio,        TTUsuarios2.Nombre AS TTUsuarios2_Nombre,        Registro_de_Contenido.Reportero AS Registro_de_Contenido_Reportero,        TTUsuarios3.Nombre AS TTUsuarios3_Nombre,        Registro_de_Contenido.Titulo As Registro_de_Contenido_Titulo,        Registro_de_Contenido.Descripcion As Registro_de_Contenido_Descripcion,        Registro_de_Contenido.Contenido As Registro_de_Contenido_Contenido,        Registro_de_Contenido.Imagen AS Registro_de_Contenido_Imagen,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Contenido.Imagen_Miniatura AS Registro_de_Contenido_Imagen_Miniatura,        TTArchivos1.Nombre AS TTArchivos1_Nombre,        Registro_de_Contenido.Estilo AS Registro_de_Contenido_Estilo,        Estilo_de_Articulo.Descripcion AS Estilo_de_Articulo_Descripcion,        Registro_de_Contenido.Adjuntar_PDF AS Registro_de_Contenido_Adjuntar_PDF,        TTArchivos2.Nombre AS TTArchivos2_Nombre,        Registro_de_Contenido.Captura_Terminada As Registro_de_Contenido_Captura_Terminada,        Registro_de_Contenido.Autorizado_por AS Registro_de_Contenido_Autorizado_por,        TTUsuarios4.Nombre AS TTUsuarios4_Nombre,        Registro_de_Contenido.Fecha_de_Revision As Registro_de_Contenido_Fecha_de_Revision,        Registro_de_Contenido.Hora_de_Revision As Registro_de_Contenido_Hora_de_Revision,        Registro_de_Contenido.Autorizacion AS Registro_de_Contenido_Autorizacion,        Autorizacion.Descripcion AS Autorizacion_Descripcion,        Registro_de_Contenido.Motivo_de_Rechazo As Registro_de_Contenido_Motivo_de_Rechazo,        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,        Registro_de_Contenido.Fecha_de_Termino As Registro_de_Contenido_Fecha_de_Termino,        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As Registro_de_Contenido_Seleccionar_Todos_los_Observatorios,        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from ((((((((((((( Registro_de_Contenido       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido ON Estatus_de_Contenido.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as TTUsuarios2 ON TTUsuarios2.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as TTUsuarios3 ON TTUsuarios3.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as TTArchivos1 ON TTArchivos1.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo ON Estilo_de_Articulo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as TTArchivos2 ON TTArchivos2.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as TTUsuarios4 ON TTUsuarios4.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio ON Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)           Where Registro_de_Contenido.Autorizado_por = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyFecha_de_Revision(DateTime Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Contenido.Folio As Registro_de_Contenido_Folio,        Registro_de_Contenido.Usuario_que_Registra AS Registro_de_Contenido_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Contenido.Fecha_de_Registro As Registro_de_Contenido_Fecha_de_Registro,        Registro_de_Contenido.Hora_de_Registro As Registro_de_Contenido_Hora_de_Registro,        '' AS Registro_de_Contenido_Observatorio,        Registro_de_Contenido.Categoria AS Registro_de_Contenido_Categoria,        Categoria.Descripcion AS Categoria_Descripcion,        Registro_de_Contenido.Descripcion_de_Solicitud As Registro_de_Contenido_Descripcion_de_Solicitud,        Registro_de_Contenido.Reportero_Asignado AS Registro_de_Contenido_Reportero_Asignado,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        Registro_de_Contenido.Fecha_de_Compromiso As Registro_de_Contenido_Fecha_de_Compromiso,        Registro_de_Contenido.Estatus AS Registro_de_Contenido_Estatus,        Estatus_de_Contenido.Descripcion AS Estatus_de_Contenido_Descripcion,        Registro_de_Contenido.Administrador_de_Observatorio AS Registro_de_Contenido_Administrador_de_Observatorio,        TTUsuarios2.Nombre AS TTUsuarios2_Nombre,        Registro_de_Contenido.Reportero AS Registro_de_Contenido_Reportero,        TTUsuarios3.Nombre AS TTUsuarios3_Nombre,        Registro_de_Contenido.Titulo As Registro_de_Contenido_Titulo,        Registro_de_Contenido.Descripcion As Registro_de_Contenido_Descripcion,        Registro_de_Contenido.Contenido As Registro_de_Contenido_Contenido,        Registro_de_Contenido.Imagen AS Registro_de_Contenido_Imagen,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Contenido.Imagen_Miniatura AS Registro_de_Contenido_Imagen_Miniatura,        TTArchivos1.Nombre AS TTArchivos1_Nombre,        Registro_de_Contenido.Estilo AS Registro_de_Contenido_Estilo,        Estilo_de_Articulo.Descripcion AS Estilo_de_Articulo_Descripcion,        Registro_de_Contenido.Adjuntar_PDF AS Registro_de_Contenido_Adjuntar_PDF,        TTArchivos2.Nombre AS TTArchivos2_Nombre,        Registro_de_Contenido.Captura_Terminada As Registro_de_Contenido_Captura_Terminada,        Registro_de_Contenido.Autorizado_por AS Registro_de_Contenido_Autorizado_por,        TTUsuarios4.Nombre AS TTUsuarios4_Nombre,        Registro_de_Contenido.Fecha_de_Revision As Registro_de_Contenido_Fecha_de_Revision,        Registro_de_Contenido.Hora_de_Revision As Registro_de_Contenido_Hora_de_Revision,        Registro_de_Contenido.Autorizacion AS Registro_de_Contenido_Autorizacion,        Autorizacion.Descripcion AS Autorizacion_Descripcion,        Registro_de_Contenido.Motivo_de_Rechazo As Registro_de_Contenido_Motivo_de_Rechazo,        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,        Registro_de_Contenido.Fecha_de_Termino As Registro_de_Contenido_Fecha_de_Termino,        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As Registro_de_Contenido_Seleccionar_Todos_los_Observatorios,        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from ((((((((((((( Registro_de_Contenido       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido ON Estatus_de_Contenido.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as TTUsuarios2 ON TTUsuarios2.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as TTUsuarios3 ON TTUsuarios3.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as TTArchivos1 ON TTArchivos1.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo ON Estilo_de_Articulo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as TTArchivos2 ON TTArchivos2.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as TTUsuarios4 ON TTUsuarios4.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio ON Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)           Where Registro_de_Contenido.Fecha_de_Revision = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyHora_de_Revision(String Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Contenido.Folio As Registro_de_Contenido_Folio,        Registro_de_Contenido.Usuario_que_Registra AS Registro_de_Contenido_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Contenido.Fecha_de_Registro As Registro_de_Contenido_Fecha_de_Registro,        Registro_de_Contenido.Hora_de_Registro As Registro_de_Contenido_Hora_de_Registro,        '' AS Registro_de_Contenido_Observatorio,        Registro_de_Contenido.Categoria AS Registro_de_Contenido_Categoria,        Categoria.Descripcion AS Categoria_Descripcion,        Registro_de_Contenido.Descripcion_de_Solicitud As Registro_de_Contenido_Descripcion_de_Solicitud,        Registro_de_Contenido.Reportero_Asignado AS Registro_de_Contenido_Reportero_Asignado,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        Registro_de_Contenido.Fecha_de_Compromiso As Registro_de_Contenido_Fecha_de_Compromiso,        Registro_de_Contenido.Estatus AS Registro_de_Contenido_Estatus,        Estatus_de_Contenido.Descripcion AS Estatus_de_Contenido_Descripcion,        Registro_de_Contenido.Administrador_de_Observatorio AS Registro_de_Contenido_Administrador_de_Observatorio,        TTUsuarios2.Nombre AS TTUsuarios2_Nombre,        Registro_de_Contenido.Reportero AS Registro_de_Contenido_Reportero,        TTUsuarios3.Nombre AS TTUsuarios3_Nombre,        Registro_de_Contenido.Titulo As Registro_de_Contenido_Titulo,        Registro_de_Contenido.Descripcion As Registro_de_Contenido_Descripcion,        Registro_de_Contenido.Contenido As Registro_de_Contenido_Contenido,        Registro_de_Contenido.Imagen AS Registro_de_Contenido_Imagen,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Contenido.Imagen_Miniatura AS Registro_de_Contenido_Imagen_Miniatura,        TTArchivos1.Nombre AS TTArchivos1_Nombre,        Registro_de_Contenido.Estilo AS Registro_de_Contenido_Estilo,        Estilo_de_Articulo.Descripcion AS Estilo_de_Articulo_Descripcion,        Registro_de_Contenido.Adjuntar_PDF AS Registro_de_Contenido_Adjuntar_PDF,        TTArchivos2.Nombre AS TTArchivos2_Nombre,        Registro_de_Contenido.Captura_Terminada As Registro_de_Contenido_Captura_Terminada,        Registro_de_Contenido.Autorizado_por AS Registro_de_Contenido_Autorizado_por,        TTUsuarios4.Nombre AS TTUsuarios4_Nombre,        Registro_de_Contenido.Fecha_de_Revision As Registro_de_Contenido_Fecha_de_Revision,        Registro_de_Contenido.Hora_de_Revision As Registro_de_Contenido_Hora_de_Revision,        Registro_de_Contenido.Autorizacion AS Registro_de_Contenido_Autorizacion,        Autorizacion.Descripcion AS Autorizacion_Descripcion,        Registro_de_Contenido.Motivo_de_Rechazo As Registro_de_Contenido_Motivo_de_Rechazo,        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,        Registro_de_Contenido.Fecha_de_Termino As Registro_de_Contenido_Fecha_de_Termino,        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As Registro_de_Contenido_Seleccionar_Todos_los_Observatorios,        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from ((((((((((((( Registro_de_Contenido       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido ON Estatus_de_Contenido.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as TTUsuarios2 ON TTUsuarios2.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as TTUsuarios3 ON TTUsuarios3.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as TTArchivos1 ON TTArchivos1.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo ON Estilo_de_Articulo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as TTArchivos2 ON TTArchivos2.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as TTUsuarios4 ON TTUsuarios4.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio ON Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)           Where Registro_de_Contenido.Hora_de_Revision = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyAutorizacion(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Contenido.Folio As Registro_de_Contenido_Folio,        Registro_de_Contenido.Usuario_que_Registra AS Registro_de_Contenido_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Contenido.Fecha_de_Registro As Registro_de_Contenido_Fecha_de_Registro,        Registro_de_Contenido.Hora_de_Registro As Registro_de_Contenido_Hora_de_Registro,        '' AS Registro_de_Contenido_Observatorio,        Registro_de_Contenido.Categoria AS Registro_de_Contenido_Categoria,        Categoria.Descripcion AS Categoria_Descripcion,        Registro_de_Contenido.Descripcion_de_Solicitud As Registro_de_Contenido_Descripcion_de_Solicitud,        Registro_de_Contenido.Reportero_Asignado AS Registro_de_Contenido_Reportero_Asignado,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        Registro_de_Contenido.Fecha_de_Compromiso As Registro_de_Contenido_Fecha_de_Compromiso,        Registro_de_Contenido.Estatus AS Registro_de_Contenido_Estatus,        Estatus_de_Contenido.Descripcion AS Estatus_de_Contenido_Descripcion,        Registro_de_Contenido.Administrador_de_Observatorio AS Registro_de_Contenido_Administrador_de_Observatorio,        TTUsuarios2.Nombre AS TTUsuarios2_Nombre,        Registro_de_Contenido.Reportero AS Registro_de_Contenido_Reportero,        TTUsuarios3.Nombre AS TTUsuarios3_Nombre,        Registro_de_Contenido.Titulo As Registro_de_Contenido_Titulo,        Registro_de_Contenido.Descripcion As Registro_de_Contenido_Descripcion,        Registro_de_Contenido.Contenido As Registro_de_Contenido_Contenido,        Registro_de_Contenido.Imagen AS Registro_de_Contenido_Imagen,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Contenido.Imagen_Miniatura AS Registro_de_Contenido_Imagen_Miniatura,        TTArchivos1.Nombre AS TTArchivos1_Nombre,        Registro_de_Contenido.Estilo AS Registro_de_Contenido_Estilo,        Estilo_de_Articulo.Descripcion AS Estilo_de_Articulo_Descripcion,        Registro_de_Contenido.Adjuntar_PDF AS Registro_de_Contenido_Adjuntar_PDF,        TTArchivos2.Nombre AS TTArchivos2_Nombre,        Registro_de_Contenido.Captura_Terminada As Registro_de_Contenido_Captura_Terminada,        Registro_de_Contenido.Autorizado_por AS Registro_de_Contenido_Autorizado_por,        TTUsuarios4.Nombre AS TTUsuarios4_Nombre,        Registro_de_Contenido.Fecha_de_Revision As Registro_de_Contenido_Fecha_de_Revision,        Registro_de_Contenido.Hora_de_Revision As Registro_de_Contenido_Hora_de_Revision,        Registro_de_Contenido.Autorizacion AS Registro_de_Contenido_Autorizacion,        Autorizacion.Descripcion AS Autorizacion_Descripcion,        Registro_de_Contenido.Motivo_de_Rechazo As Registro_de_Contenido_Motivo_de_Rechazo,        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,        Registro_de_Contenido.Fecha_de_Termino As Registro_de_Contenido_Fecha_de_Termino,        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As Registro_de_Contenido_Seleccionar_Todos_los_Observatorios,        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from ((((((((((((( Registro_de_Contenido       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido ON Estatus_de_Contenido.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as TTUsuarios2 ON TTUsuarios2.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as TTUsuarios3 ON TTUsuarios3.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as TTArchivos1 ON TTArchivos1.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo ON Estilo_de_Articulo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as TTArchivos2 ON TTArchivos2.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as TTUsuarios4 ON TTUsuarios4.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio ON Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)           Where Registro_de_Contenido.Autorizacion = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyMotivo_de_Rechazo(String Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Contenido.Folio As Registro_de_Contenido_Folio,        Registro_de_Contenido.Usuario_que_Registra AS Registro_de_Contenido_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Contenido.Fecha_de_Registro As Registro_de_Contenido_Fecha_de_Registro,        Registro_de_Contenido.Hora_de_Registro As Registro_de_Contenido_Hora_de_Registro,        '' AS Registro_de_Contenido_Observatorio,        Registro_de_Contenido.Categoria AS Registro_de_Contenido_Categoria,        Categoria.Descripcion AS Categoria_Descripcion,        Registro_de_Contenido.Descripcion_de_Solicitud As Registro_de_Contenido_Descripcion_de_Solicitud,        Registro_de_Contenido.Reportero_Asignado AS Registro_de_Contenido_Reportero_Asignado,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        Registro_de_Contenido.Fecha_de_Compromiso As Registro_de_Contenido_Fecha_de_Compromiso,        Registro_de_Contenido.Estatus AS Registro_de_Contenido_Estatus,        Estatus_de_Contenido.Descripcion AS Estatus_de_Contenido_Descripcion,        Registro_de_Contenido.Administrador_de_Observatorio AS Registro_de_Contenido_Administrador_de_Observatorio,        TTUsuarios2.Nombre AS TTUsuarios2_Nombre,        Registro_de_Contenido.Reportero AS Registro_de_Contenido_Reportero,        TTUsuarios3.Nombre AS TTUsuarios3_Nombre,        Registro_de_Contenido.Titulo As Registro_de_Contenido_Titulo,        Registro_de_Contenido.Descripcion As Registro_de_Contenido_Descripcion,        Registro_de_Contenido.Contenido As Registro_de_Contenido_Contenido,        Registro_de_Contenido.Imagen AS Registro_de_Contenido_Imagen,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Contenido.Imagen_Miniatura AS Registro_de_Contenido_Imagen_Miniatura,        TTArchivos1.Nombre AS TTArchivos1_Nombre,        Registro_de_Contenido.Estilo AS Registro_de_Contenido_Estilo,        Estilo_de_Articulo.Descripcion AS Estilo_de_Articulo_Descripcion,        Registro_de_Contenido.Adjuntar_PDF AS Registro_de_Contenido_Adjuntar_PDF,        TTArchivos2.Nombre AS TTArchivos2_Nombre,        Registro_de_Contenido.Captura_Terminada As Registro_de_Contenido_Captura_Terminada,        Registro_de_Contenido.Autorizado_por AS Registro_de_Contenido_Autorizado_por,        TTUsuarios4.Nombre AS TTUsuarios4_Nombre,        Registro_de_Contenido.Fecha_de_Revision As Registro_de_Contenido_Fecha_de_Revision,        Registro_de_Contenido.Hora_de_Revision As Registro_de_Contenido_Hora_de_Revision,        Registro_de_Contenido.Autorizacion AS Registro_de_Contenido_Autorizacion,        Autorizacion.Descripcion AS Autorizacion_Descripcion,        Registro_de_Contenido.Motivo_de_Rechazo As Registro_de_Contenido_Motivo_de_Rechazo,        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,        Registro_de_Contenido.Fecha_de_Termino As Registro_de_Contenido_Fecha_de_Termino,        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As Registro_de_Contenido_Seleccionar_Todos_los_Observatorios,        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from ((((((((((((( Registro_de_Contenido       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido ON Estatus_de_Contenido.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as TTUsuarios2 ON TTUsuarios2.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as TTUsuarios3 ON TTUsuarios3.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as TTArchivos1 ON TTArchivos1.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo ON Estilo_de_Articulo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as TTArchivos2 ON TTArchivos2.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as TTUsuarios4 ON TTUsuarios4.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio ON Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)           Where Registro_de_Contenido.Motivo_de_Rechazo = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyFecha_de_Inicio_de_Publicacion(DateTime Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Contenido.Folio As Registro_de_Contenido_Folio,        Registro_de_Contenido.Usuario_que_Registra AS Registro_de_Contenido_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Contenido.Fecha_de_Registro As Registro_de_Contenido_Fecha_de_Registro,        Registro_de_Contenido.Hora_de_Registro As Registro_de_Contenido_Hora_de_Registro,        '' AS Registro_de_Contenido_Observatorio,        Registro_de_Contenido.Categoria AS Registro_de_Contenido_Categoria,        Categoria.Descripcion AS Categoria_Descripcion,        Registro_de_Contenido.Descripcion_de_Solicitud As Registro_de_Contenido_Descripcion_de_Solicitud,        Registro_de_Contenido.Reportero_Asignado AS Registro_de_Contenido_Reportero_Asignado,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        Registro_de_Contenido.Fecha_de_Compromiso As Registro_de_Contenido_Fecha_de_Compromiso,        Registro_de_Contenido.Estatus AS Registro_de_Contenido_Estatus,        Estatus_de_Contenido.Descripcion AS Estatus_de_Contenido_Descripcion,        Registro_de_Contenido.Administrador_de_Observatorio AS Registro_de_Contenido_Administrador_de_Observatorio,        TTUsuarios2.Nombre AS TTUsuarios2_Nombre,        Registro_de_Contenido.Reportero AS Registro_de_Contenido_Reportero,        TTUsuarios3.Nombre AS TTUsuarios3_Nombre,        Registro_de_Contenido.Titulo As Registro_de_Contenido_Titulo,        Registro_de_Contenido.Descripcion As Registro_de_Contenido_Descripcion,        Registro_de_Contenido.Contenido As Registro_de_Contenido_Contenido,        Registro_de_Contenido.Imagen AS Registro_de_Contenido_Imagen,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Contenido.Imagen_Miniatura AS Registro_de_Contenido_Imagen_Miniatura,        TTArchivos1.Nombre AS TTArchivos1_Nombre,        Registro_de_Contenido.Estilo AS Registro_de_Contenido_Estilo,        Estilo_de_Articulo.Descripcion AS Estilo_de_Articulo_Descripcion,        Registro_de_Contenido.Adjuntar_PDF AS Registro_de_Contenido_Adjuntar_PDF,        TTArchivos2.Nombre AS TTArchivos2_Nombre,        Registro_de_Contenido.Captura_Terminada As Registro_de_Contenido_Captura_Terminada,        Registro_de_Contenido.Autorizado_por AS Registro_de_Contenido_Autorizado_por,        TTUsuarios4.Nombre AS TTUsuarios4_Nombre,        Registro_de_Contenido.Fecha_de_Revision As Registro_de_Contenido_Fecha_de_Revision,        Registro_de_Contenido.Hora_de_Revision As Registro_de_Contenido_Hora_de_Revision,        Registro_de_Contenido.Autorizacion AS Registro_de_Contenido_Autorizacion,        Autorizacion.Descripcion AS Autorizacion_Descripcion,        Registro_de_Contenido.Motivo_de_Rechazo As Registro_de_Contenido_Motivo_de_Rechazo,        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,        Registro_de_Contenido.Fecha_de_Termino As Registro_de_Contenido_Fecha_de_Termino,        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As Registro_de_Contenido_Seleccionar_Todos_los_Observatorios,        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from ((((((((((((( Registro_de_Contenido       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido ON Estatus_de_Contenido.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as TTUsuarios2 ON TTUsuarios2.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as TTUsuarios3 ON TTUsuarios3.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as TTArchivos1 ON TTArchivos1.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo ON Estilo_de_Articulo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as TTArchivos2 ON TTArchivos2.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as TTUsuarios4 ON TTUsuarios4.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio ON Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)           Where Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyFecha_de_Termino(DateTime Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Contenido.Folio As Registro_de_Contenido_Folio,        Registro_de_Contenido.Usuario_que_Registra AS Registro_de_Contenido_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Contenido.Fecha_de_Registro As Registro_de_Contenido_Fecha_de_Registro,        Registro_de_Contenido.Hora_de_Registro As Registro_de_Contenido_Hora_de_Registro,        '' AS Registro_de_Contenido_Observatorio,        Registro_de_Contenido.Categoria AS Registro_de_Contenido_Categoria,        Categoria.Descripcion AS Categoria_Descripcion,        Registro_de_Contenido.Descripcion_de_Solicitud As Registro_de_Contenido_Descripcion_de_Solicitud,        Registro_de_Contenido.Reportero_Asignado AS Registro_de_Contenido_Reportero_Asignado,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        Registro_de_Contenido.Fecha_de_Compromiso As Registro_de_Contenido_Fecha_de_Compromiso,        Registro_de_Contenido.Estatus AS Registro_de_Contenido_Estatus,        Estatus_de_Contenido.Descripcion AS Estatus_de_Contenido_Descripcion,        Registro_de_Contenido.Administrador_de_Observatorio AS Registro_de_Contenido_Administrador_de_Observatorio,        TTUsuarios2.Nombre AS TTUsuarios2_Nombre,        Registro_de_Contenido.Reportero AS Registro_de_Contenido_Reportero,        TTUsuarios3.Nombre AS TTUsuarios3_Nombre,        Registro_de_Contenido.Titulo As Registro_de_Contenido_Titulo,        Registro_de_Contenido.Descripcion As Registro_de_Contenido_Descripcion,        Registro_de_Contenido.Contenido As Registro_de_Contenido_Contenido,        Registro_de_Contenido.Imagen AS Registro_de_Contenido_Imagen,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Contenido.Imagen_Miniatura AS Registro_de_Contenido_Imagen_Miniatura,        TTArchivos1.Nombre AS TTArchivos1_Nombre,        Registro_de_Contenido.Estilo AS Registro_de_Contenido_Estilo,        Estilo_de_Articulo.Descripcion AS Estilo_de_Articulo_Descripcion,        Registro_de_Contenido.Adjuntar_PDF AS Registro_de_Contenido_Adjuntar_PDF,        TTArchivos2.Nombre AS TTArchivos2_Nombre,        Registro_de_Contenido.Captura_Terminada As Registro_de_Contenido_Captura_Terminada,        Registro_de_Contenido.Autorizado_por AS Registro_de_Contenido_Autorizado_por,        TTUsuarios4.Nombre AS TTUsuarios4_Nombre,        Registro_de_Contenido.Fecha_de_Revision As Registro_de_Contenido_Fecha_de_Revision,        Registro_de_Contenido.Hora_de_Revision As Registro_de_Contenido_Hora_de_Revision,        Registro_de_Contenido.Autorizacion AS Registro_de_Contenido_Autorizacion,        Autorizacion.Descripcion AS Autorizacion_Descripcion,        Registro_de_Contenido.Motivo_de_Rechazo As Registro_de_Contenido_Motivo_de_Rechazo,        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,        Registro_de_Contenido.Fecha_de_Termino As Registro_de_Contenido_Fecha_de_Termino,        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As Registro_de_Contenido_Seleccionar_Todos_los_Observatorios,        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from ((((((((((((( Registro_de_Contenido       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido ON Estatus_de_Contenido.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as TTUsuarios2 ON TTUsuarios2.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as TTUsuarios3 ON TTUsuarios3.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as TTArchivos1 ON TTArchivos1.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo ON Estilo_de_Articulo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as TTArchivos2 ON TTArchivos2.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as TTUsuarios4 ON TTUsuarios4.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio ON Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)           Where Registro_de_Contenido.Fecha_de_Termino = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeySeleccionar_Todos_los_Observatorios(Boolean Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Contenido.Folio As Registro_de_Contenido_Folio,        Registro_de_Contenido.Usuario_que_Registra AS Registro_de_Contenido_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Contenido.Fecha_de_Registro As Registro_de_Contenido_Fecha_de_Registro,        Registro_de_Contenido.Hora_de_Registro As Registro_de_Contenido_Hora_de_Registro,        '' AS Registro_de_Contenido_Observatorio,        Registro_de_Contenido.Categoria AS Registro_de_Contenido_Categoria,        Categoria.Descripcion AS Categoria_Descripcion,        Registro_de_Contenido.Descripcion_de_Solicitud As Registro_de_Contenido_Descripcion_de_Solicitud,        Registro_de_Contenido.Reportero_Asignado AS Registro_de_Contenido_Reportero_Asignado,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        Registro_de_Contenido.Fecha_de_Compromiso As Registro_de_Contenido_Fecha_de_Compromiso,        Registro_de_Contenido.Estatus AS Registro_de_Contenido_Estatus,        Estatus_de_Contenido.Descripcion AS Estatus_de_Contenido_Descripcion,        Registro_de_Contenido.Administrador_de_Observatorio AS Registro_de_Contenido_Administrador_de_Observatorio,        TTUsuarios2.Nombre AS TTUsuarios2_Nombre,        Registro_de_Contenido.Reportero AS Registro_de_Contenido_Reportero,        TTUsuarios3.Nombre AS TTUsuarios3_Nombre,        Registro_de_Contenido.Titulo As Registro_de_Contenido_Titulo,        Registro_de_Contenido.Descripcion As Registro_de_Contenido_Descripcion,        Registro_de_Contenido.Contenido As Registro_de_Contenido_Contenido,        Registro_de_Contenido.Imagen AS Registro_de_Contenido_Imagen,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Contenido.Imagen_Miniatura AS Registro_de_Contenido_Imagen_Miniatura,        TTArchivos1.Nombre AS TTArchivos1_Nombre,        Registro_de_Contenido.Estilo AS Registro_de_Contenido_Estilo,        Estilo_de_Articulo.Descripcion AS Estilo_de_Articulo_Descripcion,        Registro_de_Contenido.Adjuntar_PDF AS Registro_de_Contenido_Adjuntar_PDF,        TTArchivos2.Nombre AS TTArchivos2_Nombre,        Registro_de_Contenido.Captura_Terminada As Registro_de_Contenido_Captura_Terminada,        Registro_de_Contenido.Autorizado_por AS Registro_de_Contenido_Autorizado_por,        TTUsuarios4.Nombre AS TTUsuarios4_Nombre,        Registro_de_Contenido.Fecha_de_Revision As Registro_de_Contenido_Fecha_de_Revision,        Registro_de_Contenido.Hora_de_Revision As Registro_de_Contenido_Hora_de_Revision,        Registro_de_Contenido.Autorizacion AS Registro_de_Contenido_Autorizacion,        Autorizacion.Descripcion AS Autorizacion_Descripcion,        Registro_de_Contenido.Motivo_de_Rechazo As Registro_de_Contenido_Motivo_de_Rechazo,        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,        Registro_de_Contenido.Fecha_de_Termino As Registro_de_Contenido_Fecha_de_Termino,        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As Registro_de_Contenido_Seleccionar_Todos_los_Observatorios,        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from ((((((((((((( Registro_de_Contenido       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido ON Estatus_de_Contenido.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as TTUsuarios2 ON TTUsuarios2.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as TTUsuarios3 ON TTUsuarios3.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as TTArchivos1 ON TTArchivos1.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo ON Estilo_de_Articulo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as TTArchivos2 ON TTArchivos2.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as TTUsuarios4 ON TTUsuarios4.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio ON Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)           Where Registro_de_Contenido.Seleccionar_Todos_los_Observatorios = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyFiltrar_Usuarios_por_Observatorio(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Contenido.Folio As Registro_de_Contenido_Folio,        Registro_de_Contenido.Usuario_que_Registra AS Registro_de_Contenido_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Contenido.Fecha_de_Registro As Registro_de_Contenido_Fecha_de_Registro,        Registro_de_Contenido.Hora_de_Registro As Registro_de_Contenido_Hora_de_Registro,        '' AS Registro_de_Contenido_Observatorio,        Registro_de_Contenido.Categoria AS Registro_de_Contenido_Categoria,        Categoria.Descripcion AS Categoria_Descripcion,        Registro_de_Contenido.Descripcion_de_Solicitud As Registro_de_Contenido_Descripcion_de_Solicitud,        Registro_de_Contenido.Reportero_Asignado AS Registro_de_Contenido_Reportero_Asignado,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        Registro_de_Contenido.Fecha_de_Compromiso As Registro_de_Contenido_Fecha_de_Compromiso,        Registro_de_Contenido.Estatus AS Registro_de_Contenido_Estatus,        Estatus_de_Contenido.Descripcion AS Estatus_de_Contenido_Descripcion,        Registro_de_Contenido.Administrador_de_Observatorio AS Registro_de_Contenido_Administrador_de_Observatorio,        TTUsuarios2.Nombre AS TTUsuarios2_Nombre,        Registro_de_Contenido.Reportero AS Registro_de_Contenido_Reportero,        TTUsuarios3.Nombre AS TTUsuarios3_Nombre,        Registro_de_Contenido.Titulo As Registro_de_Contenido_Titulo,        Registro_de_Contenido.Descripcion As Registro_de_Contenido_Descripcion,        Registro_de_Contenido.Contenido As Registro_de_Contenido_Contenido,        Registro_de_Contenido.Imagen AS Registro_de_Contenido_Imagen,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Contenido.Imagen_Miniatura AS Registro_de_Contenido_Imagen_Miniatura,        TTArchivos1.Nombre AS TTArchivos1_Nombre,        Registro_de_Contenido.Estilo AS Registro_de_Contenido_Estilo,        Estilo_de_Articulo.Descripcion AS Estilo_de_Articulo_Descripcion,        Registro_de_Contenido.Adjuntar_PDF AS Registro_de_Contenido_Adjuntar_PDF,        TTArchivos2.Nombre AS TTArchivos2_Nombre,        Registro_de_Contenido.Captura_Terminada As Registro_de_Contenido_Captura_Terminada,        Registro_de_Contenido.Autorizado_por AS Registro_de_Contenido_Autorizado_por,        TTUsuarios4.Nombre AS TTUsuarios4_Nombre,        Registro_de_Contenido.Fecha_de_Revision As Registro_de_Contenido_Fecha_de_Revision,        Registro_de_Contenido.Hora_de_Revision As Registro_de_Contenido_Hora_de_Revision,        Registro_de_Contenido.Autorizacion AS Registro_de_Contenido_Autorizacion,        Autorizacion.Descripcion AS Autorizacion_Descripcion,        Registro_de_Contenido.Motivo_de_Rechazo As Registro_de_Contenido_Motivo_de_Rechazo,        Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion As Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,        Registro_de_Contenido.Fecha_de_Termino As Registro_de_Contenido_Fecha_de_Termino,        Registro_de_Contenido.Seleccionar_Todos_los_Observatorios As Registro_de_Contenido_Seleccionar_Todos_los_Observatorios,        Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio AS Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from ((((((((((((( Registro_de_Contenido       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Contenido.Usuario_que_Registra)       LEFT JOIN Categoria ON Categoria.Clave=Registro_de_Contenido.Categoria)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Contenido.Reportero_Asignado)       LEFT JOIN Estatus_de_Contenido ON Estatus_de_Contenido.Clave=Registro_de_Contenido.Estatus)       LEFT JOIN TTUsuarios as TTUsuarios2 ON TTUsuarios2.IdUsuario=Registro_de_Contenido.Administrador_de_Observatorio)       LEFT JOIN TTUsuarios as TTUsuarios3 ON TTUsuarios3.IdUsuario=Registro_de_Contenido.Reportero)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Contenido.Imagen)       LEFT JOIN TTArchivos as TTArchivos1 ON TTArchivos1.Folio=Registro_de_Contenido.Imagen_Miniatura)       LEFT JOIN Estilo_de_Articulo ON Estilo_de_Articulo.Clave=Registro_de_Contenido.Estilo)       LEFT JOIN TTArchivos as TTArchivos2 ON TTArchivos2.Folio=Registro_de_Contenido.Adjuntar_PDF)       LEFT JOIN TTUsuarios as TTUsuarios4 ON TTUsuarios4.IdUsuario=Registro_de_Contenido.Autorizado_por)       LEFT JOIN Autorizacion ON Autorizacion.Clave=Registro_de_Contenido.Autorizacion)       LEFT JOIN Observatorio ON Observatorio.Clave=Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio)           Where Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }

    public Int32 CurrentPosicion(int? KeyFolio)
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_SelAllComplete_Registro_de_Contenido";
        com.CommandType = CommandType.StoredProcedure;
        DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters !=null)
                foreach (Registro_de_ContenidoCS.Registro_de_ContenidoFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Registro_de_Contenido", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Function.FormatNumberNull(dt.Rows[i]["Registro_de_Contenido_Folio"]) == KeyFolio)
                return i;
        }
        return -1;
    }
    public Boolean ValidaExistencia(int? KeyFolio){
        Boolean result;
        DataSet ds;
//        if (Key == null ){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
//            return false;
//        }
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_GetRegistro_de_Contenido";
com.Parameters.AddWithValue("@Folio",KeyFolio);
        com.CommandType = CommandType.StoredProcedure;
        ds = db.Consulta(com);
        if (ds.Tables[0].Rows.Count == 0)
            result = false;
        else
            result = true;
        return result;
    }

/*            private void FillDataUsuario_que_RegistraControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Nombre";
                        ((ComboBox)ctr).ValueMember = "IdUsuario";
                        ((ComboBox)ctr).SelectedItem = null;
                        if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                            foreach (DataRow dr in ((DataTable)((ComboBox)ctr).DataSource).Rows)
                                ls.Add(dr["Nombre"].ToString());
                            ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                        }
                }
                else if (ctr.GetType() == typeof(ListBox))
                {
                        ((ListBox)ctr).DataSource = dt;
                        ((ListBox)ctr).DisplayMember = "Nombre";
                        ((ListBox)ctr).ValueMember = "IdUsuario";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Nombre";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "IdUsuario";
                }
            }
*///            public DataTable FillDataUsuario_que_Registra(Object ctr, String Filtro){
            public DataTable FillDataUsuario_que_Registra(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Contenido_Relacion_TTUsuarios";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataUsuario_que_RegistraControl(ctr, dt);
                return dt;
            }
//            public void FillDataUsuario_que_Registra(Object ctr){
            public DataTable FillDataUsuario_que_Registra(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Contenido_Relacion_TTUsuarios";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataUsuario_que_RegistraControl(ctr, dt);
                return dt;
            }
        	public DataTable FillDataObservatorio(){
        		DataSet ds;
        		TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        		SqlCommand com = new SqlCommand();
        		com.CommandText = "sp_selMS_Observatorios_Relacion_Observatorio";
        		com.CommandType = CommandType.StoredProcedure;
        		//ctr.Items.Clear();
        		ds = db.Consulta(com);
                                return ds.Tables[0];
//                if (ctr.GetType() == typeof(ComboBox))
//                {
//                        ((ComboBox)ctr).DataSource = ds.Tables[0];
//                        ((ComboBox)ctr).DisplayMember = "Nombre";
//                        ((ComboBox)ctr).ValueMember = "Clave";
//                        ((ComboBox)ctr).SelectedItem = null;
//                }
//                else if (ctr.GetType() == typeof(ListBox))
//                {
//                        ((ListBox)ctr).DataSource = ds.Tables[0];
//                        ((ListBox)ctr).DisplayMember = "Nombre";
//                        ((ListBox)ctr).ValueMember = "Clave";
//                        ((ListBox)ctr).ClearSelected();
//                }
//                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
//                {
//                        ((DataGridViewComboBoxColumn)ctr).DataSource = ds.Tables[0];
//                       ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Nombre";
//                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "Clave";
//                }
            }
/*            private void FillDataCategoriaControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Descripcion";
                        ((ComboBox)ctr).ValueMember = "Clave";
                        ((ComboBox)ctr).SelectedItem = null;
                        if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                            foreach (DataRow dr in ((DataTable)((ComboBox)ctr).DataSource).Rows)
                                ls.Add(dr["Descripcion"].ToString());
                            ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                        }
                }
                else if (ctr.GetType() == typeof(ListBox))
                {
                        ((ListBox)ctr).DataSource = dt;
                        ((ListBox)ctr).DisplayMember = "Descripcion";
                        ((ListBox)ctr).ValueMember = "Clave";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Descripcion";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "Clave";
                }
            }
*///            public DataTable FillDataCategoria(Object ctr, String Filtro){
            public DataTable FillDataCategoria(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Contenido_Relacion_Categoria";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataCategoriaControl(ctr, dt);
                return dt;
            }
//            public void FillDataCategoria(Object ctr){
            public DataTable FillDataCategoria(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Contenido_Relacion_Categoria";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataCategoriaControl(ctr, dt);
                return dt;
            }
/*            private void FillDataReportero_AsignadoControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Nombre";
                        ((ComboBox)ctr).ValueMember = "IdUsuario";
                        ((ComboBox)ctr).SelectedItem = null;
                        if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                            foreach (DataRow dr in ((DataTable)((ComboBox)ctr).DataSource).Rows)
                                ls.Add(dr["Nombre"].ToString());
                            ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                        }
                }
                else if (ctr.GetType() == typeof(ListBox))
                {
                        ((ListBox)ctr).DataSource = dt;
                        ((ListBox)ctr).DisplayMember = "Nombre";
                        ((ListBox)ctr).ValueMember = "IdUsuario";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Nombre";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "IdUsuario";
                }
            }
*///            public DataTable FillDataReportero_Asignado(Object ctr, String Filtro){
            public DataTable FillDataReportero_Asignado(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Contenido_Relacion_TTUsuarios";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataReportero_AsignadoControl(ctr, dt);
                return dt;
            }
//            public void FillDataReportero_Asignado(Object ctr){
            public DataTable FillDataReportero_Asignado(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Contenido_Relacion_TTUsuarios";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataReportero_AsignadoControl(ctr, dt);
                return dt;
            }
/*            private void FillDataEstatusControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Descripcion";
                        ((ComboBox)ctr).ValueMember = "Clave";
                        ((ComboBox)ctr).SelectedItem = null;
                        if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                            foreach (DataRow dr in ((DataTable)((ComboBox)ctr).DataSource).Rows)
                                ls.Add(dr["Descripcion"].ToString());
                            ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                        }
                }
                else if (ctr.GetType() == typeof(ListBox))
                {
                        ((ListBox)ctr).DataSource = dt;
                        ((ListBox)ctr).DisplayMember = "Descripcion";
                        ((ListBox)ctr).ValueMember = "Clave";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Descripcion";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "Clave";
                }
            }
*///            public DataTable FillDataEstatus(Object ctr, String Filtro){
            public DataTable FillDataEstatus(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Contenido_Relacion_Estatus_de_Contenido";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataEstatusControl(ctr, dt);
                return dt;
            }
//            public void FillDataEstatus(Object ctr){
            public DataTable FillDataEstatus(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Contenido_Relacion_Estatus_de_Contenido";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataEstatusControl(ctr, dt);
                return dt;
            }
/*            private void FillDataAdministrador_de_ObservatorioControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Nombre";
                        ((ComboBox)ctr).ValueMember = "IdUsuario";
                        ((ComboBox)ctr).SelectedItem = null;
                        if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                            foreach (DataRow dr in ((DataTable)((ComboBox)ctr).DataSource).Rows)
                                ls.Add(dr["Nombre"].ToString());
                            ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                        }
                }
                else if (ctr.GetType() == typeof(ListBox))
                {
                        ((ListBox)ctr).DataSource = dt;
                        ((ListBox)ctr).DisplayMember = "Nombre";
                        ((ListBox)ctr).ValueMember = "IdUsuario";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Nombre";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "IdUsuario";
                }
            }
*///            public DataTable FillDataAdministrador_de_Observatorio(Object ctr, String Filtro){
            public DataTable FillDataAdministrador_de_Observatorio(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Contenido_Relacion_TTUsuarios";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataAdministrador_de_ObservatorioControl(ctr, dt);
                return dt;
            }
//            public void FillDataAdministrador_de_Observatorio(Object ctr){
            public DataTable FillDataAdministrador_de_Observatorio(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Contenido_Relacion_TTUsuarios";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataAdministrador_de_ObservatorioControl(ctr, dt);
                return dt;
            }
/*            private void FillDataReporteroControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Nombre";
                        ((ComboBox)ctr).ValueMember = "IdUsuario";
                        ((ComboBox)ctr).SelectedItem = null;
                        if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                            foreach (DataRow dr in ((DataTable)((ComboBox)ctr).DataSource).Rows)
                                ls.Add(dr["Nombre"].ToString());
                            ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                        }
                }
                else if (ctr.GetType() == typeof(ListBox))
                {
                        ((ListBox)ctr).DataSource = dt;
                        ((ListBox)ctr).DisplayMember = "Nombre";
                        ((ListBox)ctr).ValueMember = "IdUsuario";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Nombre";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "IdUsuario";
                }
            }
*///            public DataTable FillDataReportero(Object ctr, String Filtro){
            public DataTable FillDataReportero(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Contenido_Relacion_TTUsuarios";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataReporteroControl(ctr, dt);
                return dt;
            }
//            public void FillDataReportero(Object ctr){
            public DataTable FillDataReportero(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Contenido_Relacion_TTUsuarios";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataReporteroControl(ctr, dt);
                return dt;
            }
/*            private void FillDataEstiloControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Descripcion";
                        ((ComboBox)ctr).ValueMember = "Clave";
                        ((ComboBox)ctr).SelectedItem = null;
                        if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                            foreach (DataRow dr in ((DataTable)((ComboBox)ctr).DataSource).Rows)
                                ls.Add(dr["Descripcion"].ToString());
                            ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                        }
                }
                else if (ctr.GetType() == typeof(ListBox))
                {
                        ((ListBox)ctr).DataSource = dt;
                        ((ListBox)ctr).DisplayMember = "Descripcion";
                        ((ListBox)ctr).ValueMember = "Clave";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Descripcion";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "Clave";
                }
            }
*///            public DataTable FillDataEstilo(Object ctr, String Filtro){
            public DataTable FillDataEstilo(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Contenido_Relacion_Estilo_de_Articulo";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataEstiloControl(ctr, dt);
                return dt;
            }
//            public void FillDataEstilo(Object ctr){
            public DataTable FillDataEstilo(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Contenido_Relacion_Estilo_de_Articulo";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataEstiloControl(ctr, dt);
                return dt;
            }
/*            private void FillDataEtiquetasControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Clave";
                        ((ComboBox)ctr).ValueMember = "Clave";
                        ((ComboBox)ctr).SelectedItem = null;
                        if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                            foreach (DataRow dr in ((DataTable)((ComboBox)ctr).DataSource).Rows)
                                ls.Add(dr["Clave"].ToString());
                            ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                        }
                }
                else if (ctr.GetType() == typeof(ListBox))
                {
                        ((ListBox)ctr).DataSource = dt;
                        ((ListBox)ctr).DisplayMember = "Clave";
                        ((ListBox)ctr).ValueMember = "Clave";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Clave";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "Clave";
                }
            }
*///            public DataTable FillDataEtiquetas(Object ctr, String Filtro){
            public DataTable FillDataEtiquetas(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Contenido_Relacion_Detalle_de_Etiquetas";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataEtiquetasControl(ctr, dt);
                return dt;
            }
//            public void FillDataEtiquetas(Object ctr){
            public DataTable FillDataEtiquetas(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Contenido_Relacion_Detalle_de_Etiquetas";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataEtiquetasControl(ctr, dt);
                return dt;
            }
/*            private void FillDataFuentesControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Clave";
                        ((ComboBox)ctr).ValueMember = "Clave";
                        ((ComboBox)ctr).SelectedItem = null;
                        if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                            foreach (DataRow dr in ((DataTable)((ComboBox)ctr).DataSource).Rows)
                                ls.Add(dr["Clave"].ToString());
                            ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                        }
                }
                else if (ctr.GetType() == typeof(ListBox))
                {
                        ((ListBox)ctr).DataSource = dt;
                        ((ListBox)ctr).DisplayMember = "Clave";
                        ((ListBox)ctr).ValueMember = "Clave";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Clave";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "Clave";
                }
            }
*///            public DataTable FillDataFuentes(Object ctr, String Filtro){
            public DataTable FillDataFuentes(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Contenido_Relacion_Fuentes";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataFuentesControl(ctr, dt);
                return dt;
            }
//            public void FillDataFuentes(Object ctr){
            public DataTable FillDataFuentes(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Contenido_Relacion_Fuentes";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataFuentesControl(ctr, dt);
                return dt;
            }
/*            private void FillDataAutorizado_porControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Nombre";
                        ((ComboBox)ctr).ValueMember = "IdUsuario";
                        ((ComboBox)ctr).SelectedItem = null;
                        if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                            foreach (DataRow dr in ((DataTable)((ComboBox)ctr).DataSource).Rows)
                                ls.Add(dr["Nombre"].ToString());
                            ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                        }
                }
                else if (ctr.GetType() == typeof(ListBox))
                {
                        ((ListBox)ctr).DataSource = dt;
                        ((ListBox)ctr).DisplayMember = "Nombre";
                        ((ListBox)ctr).ValueMember = "IdUsuario";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Nombre";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "IdUsuario";
                }
            }
*///            public DataTable FillDataAutorizado_por(Object ctr, String Filtro){
            public DataTable FillDataAutorizado_por(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Contenido_Relacion_TTUsuarios";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataAutorizado_porControl(ctr, dt);
                return dt;
            }
//            public void FillDataAutorizado_por(Object ctr){
            public DataTable FillDataAutorizado_por(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Contenido_Relacion_TTUsuarios";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataAutorizado_porControl(ctr, dt);
                return dt;
            }
/*            private void FillDataAutorizacionControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Descripcion";
                        ((ComboBox)ctr).ValueMember = "Clave";
                        ((ComboBox)ctr).SelectedItem = null;
                        if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                            foreach (DataRow dr in ((DataTable)((ComboBox)ctr).DataSource).Rows)
                                ls.Add(dr["Descripcion"].ToString());
                            ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                        }
                }
                else if (ctr.GetType() == typeof(ListBox))
                {
                        ((ListBox)ctr).DataSource = dt;
                        ((ListBox)ctr).DisplayMember = "Descripcion";
                        ((ListBox)ctr).ValueMember = "Clave";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Descripcion";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "Clave";
                }
            }
*///            public DataTable FillDataAutorizacion(Object ctr, String Filtro){
            public DataTable FillDataAutorizacion(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Contenido_Relacion_Autorizacion";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataAutorizacionControl(ctr, dt);
                return dt;
            }
//            public void FillDataAutorizacion(Object ctr){
            public DataTable FillDataAutorizacion(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Contenido_Relacion_Autorizacion";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataAutorizacionControl(ctr, dt);
                return dt;
            }
/*            private void FillDataNotificaciones_por_ObservatoriosControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Clave";
                        ((ComboBox)ctr).ValueMember = "Clave";
                        ((ComboBox)ctr).SelectedItem = null;
                        if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                            foreach (DataRow dr in ((DataTable)((ComboBox)ctr).DataSource).Rows)
                                ls.Add(dr["Clave"].ToString());
                            ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                        }
                }
                else if (ctr.GetType() == typeof(ListBox))
                {
                        ((ListBox)ctr).DataSource = dt;
                        ((ListBox)ctr).DisplayMember = "Clave";
                        ((ListBox)ctr).ValueMember = "Clave";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Clave";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "Clave";
                }
            }
*///            public DataTable FillDataNotificaciones_por_Observatorios(Object ctr, String Filtro){
            public DataTable FillDataNotificaciones_por_Observatorios(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Contenido_Relacion_Detalle_de_Notificacion_por_Observatorio";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataNotificaciones_por_ObservatoriosControl(ctr, dt);
                return dt;
            }
//            public void FillDataNotificaciones_por_Observatorios(Object ctr){
            public DataTable FillDataNotificaciones_por_Observatorios(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Contenido_Relacion_Detalle_de_Notificacion_por_Observatorio";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataNotificaciones_por_ObservatoriosControl(ctr, dt);
                return dt;
            }
/*            private void FillDataFiltrar_Usuarios_por_ObservatorioControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Nombre";
                        ((ComboBox)ctr).ValueMember = "Clave";
                        ((ComboBox)ctr).SelectedItem = null;
                        if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                            foreach (DataRow dr in ((DataTable)((ComboBox)ctr).DataSource).Rows)
                                ls.Add(dr["Nombre"].ToString());
                            ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                        }
                }
                else if (ctr.GetType() == typeof(ListBox))
                {
                        ((ListBox)ctr).DataSource = dt;
                        ((ListBox)ctr).DisplayMember = "Nombre";
                        ((ListBox)ctr).ValueMember = "Clave";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Nombre";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "Clave";
                }
            }
*///            public DataTable FillDataFiltrar_Usuarios_por_Observatorio(Object ctr, String Filtro){
            public DataTable FillDataFiltrar_Usuarios_por_Observatorio(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Contenido_Relacion_Observatorio";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataFiltrar_Usuarios_por_ObservatorioControl(ctr, dt);
                return dt;
            }
//            public void FillDataFiltrar_Usuarios_por_Observatorio(Object ctr){
            public DataTable FillDataFiltrar_Usuarios_por_Observatorio(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Contenido_Relacion_Observatorio";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataFiltrar_Usuarios_por_ObservatorioControl(ctr, dt);
                return dt;
            }
/*            private void FillDataNotificaciones_por_UsuarioControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Clave";
                        ((ComboBox)ctr).ValueMember = "Clave";
                        ((ComboBox)ctr).SelectedItem = null;
                        if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                            foreach (DataRow dr in ((DataTable)((ComboBox)ctr).DataSource).Rows)
                                ls.Add(dr["Clave"].ToString());
                            ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                        }
                }
                else if (ctr.GetType() == typeof(ListBox))
                {
                        ((ListBox)ctr).DataSource = dt;
                        ((ListBox)ctr).DisplayMember = "Clave";
                        ((ListBox)ctr).ValueMember = "Clave";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Clave";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "Clave";
                }
            }
*///            public DataTable FillDataNotificaciones_por_Usuario(Object ctr, String Filtro){
            public DataTable FillDataNotificaciones_por_Usuario(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Contenido_Relacion_Detalle_de_Notificacion_por_Usuario";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataNotificaciones_por_UsuarioControl(ctr, dt);
                return dt;
            }
//            public void FillDataNotificaciones_por_Usuario(Object ctr){
            public DataTable FillDataNotificaciones_por_Usuario(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Contenido_Relacion_Detalle_de_Notificacion_por_Usuario";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataNotificaciones_por_UsuarioControl(ctr, dt);
                return dt;
            }


        public void applyFilterToObject(Prismaproj.TTSearchAdvancedDataDetails tTSearchAdvancedDataDetails, int indexFilter)
        {
            switch (tTSearchAdvancedDataDetails.ControlScreenSearchAdvanced)
            {
                case ControlsLibrary.TypeControlSearchAdvanced.Text:
                    {
                        #region Variable Filter del Bussiness Object para Textos
                        TTClassSpecials.FiltersTypes.String filter = new TTClassSpecials.FiltersTypes.String();
                        filter.Order = (TTClassSpecials.FiltersTypes.FiltersPropertiesModeOrderFields)tTSearchAdvancedDataDetails.Order;
                        if (tTSearchAdvancedDataDetails.ConditionText != TTClassSpecials.FiltersTypes.TypesTextFilter.None)
                        {
                            if (tTSearchAdvancedDataDetails.From != "" && tTSearchAdvancedDataDetails.ConditionText != TTClassSpecials.FiltersTypes.TypesTextFilter.None)
                            {
                                switch (tTSearchAdvancedDataDetails.ConditionText)
                                {
                                    case TTClassSpecials.FiltersTypes.TypesTextFilter.Igual:
                                        {
                                            filter.FilterType = TTClassSpecials.FiltersTypes.TypesTextFilter.Igual;
                                            break;
                                        }
                                    case TTClassSpecials.FiltersTypes.TypesTextFilter.Contenga:
                                        {
                                            filter.FilterType = TTClassSpecials.FiltersTypes.TypesTextFilter.Contenga;
                                            break;
                                        }
                                    case TTClassSpecials.FiltersTypes.TypesTextFilter.Empieze:
                                        {
                                            filter.FilterType = TTClassSpecials.FiltersTypes.TypesTextFilter.Empieze;
                                            break;
                                        }
                                    case TTClassSpecials.FiltersTypes.TypesTextFilter.Termine:
                                        {
                                            filter.FilterType = TTClassSpecials.FiltersTypes.TypesTextFilter.Termine;
                                            break;
                                        }
                                }
                                filter.Text = tTSearchAdvancedDataDetails.From;
                            }
                        }
                        #endregion
                        break;
                    }
                case ControlsLibrary.TypeControlSearchAdvanced.Numeric:
                    {
                        #region Variable Filter del Bussiness Object para Numericos
                        TTClassSpecials.FiltersTypes.Numeric filter = new TTClassSpecials.FiltersTypes.Numeric();
                        filter.Order = (TTClassSpecials.FiltersTypes.FiltersPropertiesModeOrderFields)tTSearchAdvancedDataDetails.Order;
                        if ((tTSearchAdvancedDataDetails.ConditionText == TTClassSpecials.FiltersTypes.TypesTextFilter.None) && (tTSearchAdvancedDataDetails.From != "" || tTSearchAdvancedDataDetails.To != ""))
                        {
                            if (tTSearchAdvancedDataDetails.From != "")
                                filter.From = Conversion.CambiaToShort(tTSearchAdvancedDataDetails.From);
                            if (tTSearchAdvancedDataDetails.To != "")
                                filter.To = Conversion.CambiaToShort(tTSearchAdvancedDataDetails.To);
                        }
                        #endregion
                        break;
                    }
                case ControlsLibrary.TypeControlSearchAdvanced.Logic:
                    {
                        #region Variable Filter del Bussiness Object para Logicos
                        TTClassSpecials.FiltersTypes.Logic filter = new TTClassSpecials.FiltersTypes.Logic();
                        filter.Order = (TTClassSpecials.FiltersTypes.FiltersPropertiesModeOrderFields)tTSearchAdvancedDataDetails.Order;
                        if (tTSearchAdvancedDataDetails.Yes_Not != null)
                            filter.Active = tTSearchAdvancedDataDetails.Yes_Not;
                        #endregion
                        break;
                    }
                case ControlsLibrary.TypeControlSearchAdvanced.Money:
                    {
                        #region Variable Filter del Bussiness Object para Decimal
                        TTClassSpecials.FiltersTypes.filDecimal filter = new TTClassSpecials.FiltersTypes.filDecimal();
                        filter.Order = (TTClassSpecials.FiltersTypes.FiltersPropertiesModeOrderFields)tTSearchAdvancedDataDetails.Order;
                        if (tTSearchAdvancedDataDetails.From != "" || tTSearchAdvancedDataDetails.To != "")
                        {
                            if (tTSearchAdvancedDataDetails.From != "")
                                filter.From = Conversion.CambiaToDecimal(tTSearchAdvancedDataDetails.From);
                            if (tTSearchAdvancedDataDetails.To != "")
                                filter.To = Conversion.CambiaToDecimal(tTSearchAdvancedDataDetails.To);
                        }
                        #endregion
                        break;
                    }
                case ControlsLibrary.TypeControlSearchAdvanced.Hour:
                    {
                        break;
                    }
                case ControlsLibrary.TypeControlSearchAdvanced.Dependiente:
                    {
                        #region Variable Filter del Bussiness Object para Dependientes
                        TTClassSpecials.FiltersTypes.Dependientes filter = new TTClassSpecials.FiltersTypes.Dependientes();
                        filter.Order = (TTClassSpecials.FiltersTypes.FiltersPropertiesModeOrderFields)tTSearchAdvancedDataDetails.Order;
                        if (tTSearchAdvancedDataDetails.ListaDependientes.Length >0)
                        {
                            filter.List = new String[tTSearchAdvancedDataDetails.ListaDependientes.Length];
                            for (int i = 0; i < tTSearchAdvancedDataDetails.ListaDependientes.Length; i++)
                                filter.List[i] = tTSearchAdvancedDataDetails.ListaDependientes[i];
                        }
                        #endregion
                        break;
                    }
                case ControlsLibrary.TypeControlSearchAdvanced.Decimal:
                    {
                        #region Variable Filter del Bussiness Object para Decimal
                        TTClassSpecials.FiltersTypes.filDecimal filter = new TTClassSpecials.FiltersTypes.filDecimal();
                        filter.Order = (TTClassSpecials.FiltersTypes.FiltersPropertiesModeOrderFields)tTSearchAdvancedDataDetails.Order;
                        if (tTSearchAdvancedDataDetails.From != "" || tTSearchAdvancedDataDetails.To != "")
                        {
                            if (tTSearchAdvancedDataDetails.From != "")
                                filter.From = Conversion.CambiaToDecimal(tTSearchAdvancedDataDetails.From);
                            if (tTSearchAdvancedDataDetails.To != "")
                                filter.To = Conversion.CambiaToDecimal(tTSearchAdvancedDataDetails.To);
                        }
                        #endregion
                        break;
                    }
                case ControlsLibrary.TypeControlSearchAdvanced.Date:
                    {
                        #region Variable Filter del Bussiness Object para Dates
                        TTClassSpecials.FiltersTypes.filDate filter = new TTClassSpecials.FiltersTypes.filDate();
                        filter.Order = (TTClassSpecials.FiltersTypes.FiltersPropertiesModeOrderFields)tTSearchAdvancedDataDetails.Order;
                        if (tTSearchAdvancedDataDetails.FromDate != null || tTSearchAdvancedDataDetails.ToDate != null)
                        {
                            if (tTSearchAdvancedDataDetails.FromDate != null)
                                filter.From = tTSearchAdvancedDataDetails.FromDate;
                            if (tTSearchAdvancedDataDetails.ToDate != null)
                                filter.To = (tTSearchAdvancedDataDetails.ToDate);
                        }
                        #endregion
                        break;
                    }
                case ControlsLibrary.TypeControlSearchAdvanced.Color:
                    {
                        break;
                    }
            }
        }
        public void FiltersObligatories(TTSecurity.GlobalData GlobalInformation)
        {
            DataTable dt;
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "spTtVistasObligatories_X_ProcessAndUser";
            com.Parameters.AddWithValue("@ProcessId", iProcess);
            com.Parameters.AddWithValue("@UserID", GlobalInformation.UserID);
            com.CommandType = CommandType.StoredProcedure;
            dt = db.Consulta(com).Tables[0];
            MyFiltersObligatories = new ControlsLibrary.objectBussinessTTFiltro[dt.Rows.Count];
            MyConfigurationColumnsObligatories = new ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[dt.Rows.Count];
            for (int iViews = 0; iViews < dt.Rows.Count; iViews++)
            {
                int iVistaID = Conversion.CambiaToShort(dt.Rows[iViews]["VistaID"]).Value;
                //Prismaproj.TTSearchAdvanced MySearchAdvanced = new Prismaproj.TTSearchAdvanced();
                //Prismaproj.TTSearchAdvancedData MySearch = MySearchAdvanced.GetStructView(iVistaID);
                //MyFiltersObligatories[iViews] = MySearch.Filter;
                //MyConfigurationColumnsObligatories[iViews] = MySearch.Configuration;
            }
        }
    }
}
