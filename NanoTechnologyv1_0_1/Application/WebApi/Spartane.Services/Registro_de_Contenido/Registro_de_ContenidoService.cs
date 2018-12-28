using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Registro_de_Contenido;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Registro_de_Contenido
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Registro_de_ContenidoService : IRegistro_de_ContenidoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Registro_de_Contenido.Registro_de_Contenido> _Registro_de_ContenidoRepository;
        #endregion

        #region Ctor
        public Registro_de_ContenidoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Registro_de_Contenido.Registro_de_Contenido> Registro_de_ContenidoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Registro_de_ContenidoRepository = Registro_de_ContenidoRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Registro_de_ContenidoRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Registro_de_Contenido.Registro_de_Contenido> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Registro_de_Contenido.Registro_de_Contenido>("sp_SelAllRegistro_de_Contenido");
        }

        public IList<Core.Classes.Registro_de_Contenido.Registro_de_Contenido> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallRegistro_de_Contenido_Complete>("sp_SelAllComplete_Registro_de_Contenido");
            return data.Select(m => new Core.Classes.Registro_de_Contenido.Registro_de_Contenido
            {
                Folio = m.Folio
                ,Usuario_que_Registra_TTUsuarios = new Core.Classes.TTUsuarios.TTUsuarios() { IdUsuario = m.Usuario_que_Registra.GetValueOrDefault(), Nombre = m.Usuario_que_Registra_Nombre }
                ,Fecha_de_Registro = m.Fecha_de_Registro
                ,Hora_de_Registro = m.Hora_de_Registro
                ,Categoria_Categoria = new Core.Classes.Categoria.Categoria() { Clave = m.Categoria.GetValueOrDefault(), Descripcion = m.Categoria_Descripcion }
                ,Descripcion_de_Solicitud = m.Descripcion_de_Solicitud
                ,Reportero_Asignado_TTUsuarios = new Core.Classes.TTUsuarios.TTUsuarios() { IdUsuario = m.Reportero_Asignado.GetValueOrDefault(), Nombre = m.Reportero_Asignado_Nombre }
                ,Fecha_de_Compromiso = m.Fecha_de_Compromiso
                ,Estatus_Estatus_de_Contenido = new Core.Classes.Estatus_de_Contenido.Estatus_de_Contenido() { Clave = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }
                ,Administrador_de_Observatorio_TTUsuarios = new Core.Classes.TTUsuarios.TTUsuarios() { IdUsuario = m.Administrador_de_Observatorio.GetValueOrDefault(), Nombre = m.Administrador_de_Observatorio_Nombre }
                ,Reportero_TTUsuarios = new Core.Classes.TTUsuarios.TTUsuarios() { IdUsuario = m.Reportero.GetValueOrDefault(), Nombre = m.Reportero_Nombre }
                ,Titulo = m.Titulo
                ,Descripcion = m.Descripcion
                ,Contenido = m.Contenido
                ,Imagen_TTArchivos = new Core.Classes.TTArchivos.TTArchivos() { Folio = m.Imagen.GetValueOrDefault(), Nombre = m.Imagen_Nombre }
                ,Imagen_Miniatura_TTArchivos = new Core.Classes.TTArchivos.TTArchivos() { Folio = m.Imagen_Miniatura.GetValueOrDefault(), Nombre = m.Imagen_Miniatura_Nombre }
                ,Estilo_Estilo_de_Articulo = new Core.Classes.Estilo_de_Articulo.Estilo_de_Articulo() { Clave = m.Estilo.GetValueOrDefault(), Descripcion = m.Estilo_Descripcion }
                ,Adjuntar_PDF_TTArchivos = new Core.Classes.TTArchivos.TTArchivos() { Folio = m.Adjuntar_PDF.GetValueOrDefault(), Nombre = m.Adjuntar_PDF_Nombre }
                ,Captura_Terminada = m.Captura_Terminada.GetValueOrDefault()
                ,Autorizado_por_TTUsuarios = new Core.Classes.TTUsuarios.TTUsuarios() { IdUsuario = m.Autorizado_por.GetValueOrDefault(), Nombre = m.Autorizado_por_Nombre }
                ,Fecha_de_Revision = m.Fecha_de_Revision
                ,Hora_de_Revision = m.Hora_de_Revision
                ,Autorizacion_Autorizacion = new Core.Classes.Autorizacion.Autorizacion() { Clave = m.Autorizacion.GetValueOrDefault(), Descripcion = m.Autorizacion_Descripcion }
                ,Motivo_de_Rechazo = m.Motivo_de_Rechazo
                ,Fecha_de_Inicio_de_Publicacion = m.Fecha_de_Inicio_de_Publicacion
                ,Fecha_de_Termino = m.Fecha_de_Termino
                ,Seleccionar_Todos_los_Observatorios = m.Seleccionar_Todos_los_Observatorios.GetValueOrDefault()
                ,Filtrar_Usuarios_por_Observatorio_Observatorio = new Core.Classes.Observatorio.Observatorio() { Clave = m.Filtrar_Usuarios_por_Observatorio.GetValueOrDefault(), Nombre = m.Filtrar_Usuarios_por_Observatorio_Nombre }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Registro_de_Contenido>("sp_ListSelCount_Registro_de_Contenido", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Registro_de_Contenido.Registro_de_Contenido> SelAll(bool ConRelaciones, string Where, string Order)
        {
            try
            {
                var padreWhere = _dataProvider.GetParameter();
                padreWhere.ParameterName = "Where";
                padreWhere.DbType = DbType.String;

                padreWhere.Value = Where;

                var padreOrderBy = _dataProvider.GetParameter();
                padreOrderBy.ParameterName = "Order";
                padreOrderBy.DbType = DbType.String;
                padreOrderBy.Value = Order;


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllRegistro_de_Contenido>("sp_ListSelAll_Registro_de_Contenido", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Registro_de_Contenido.Registro_de_Contenido
                {
                    Folio = m.Registro_de_Contenido_Folio,
                    Usuario_que_Registra = m.Registro_de_Contenido_Usuario_que_Registra,
                    Fecha_de_Registro = m.Registro_de_Contenido_Fecha_de_Registro,
                    Hora_de_Registro = m.Registro_de_Contenido_Hora_de_Registro,
                    Categoria = m.Registro_de_Contenido_Categoria,
                    Descripcion_de_Solicitud = m.Registro_de_Contenido_Descripcion_de_Solicitud,
                    Reportero_Asignado = m.Registro_de_Contenido_Reportero_Asignado,
                    Fecha_de_Compromiso = m.Registro_de_Contenido_Fecha_de_Compromiso,
                    Estatus = m.Registro_de_Contenido_Estatus,
                    Administrador_de_Observatorio = m.Registro_de_Contenido_Administrador_de_Observatorio,
                    Reportero = m.Registro_de_Contenido_Reportero,
                    Titulo = m.Registro_de_Contenido_Titulo,
                    Descripcion = m.Registro_de_Contenido_Descripcion,
                    Contenido = m.Registro_de_Contenido_Contenido,
                    Imagen = m.Registro_de_Contenido_Imagen,
                    Imagen_Miniatura = m.Registro_de_Contenido_Imagen_Miniatura,
                    Estilo = m.Registro_de_Contenido_Estilo,
                    Adjuntar_PDF = m.Registro_de_Contenido_Adjuntar_PDF,
                    Captura_Terminada = m.Registro_de_Contenido_Captura_Terminada ?? false,
                    Autorizado_por = m.Registro_de_Contenido_Autorizado_por,
                    Fecha_de_Revision = m.Registro_de_Contenido_Fecha_de_Revision,
                    Hora_de_Revision = m.Registro_de_Contenido_Hora_de_Revision,
                    Autorizacion = m.Registro_de_Contenido_Autorizacion,
                    Motivo_de_Rechazo = m.Registro_de_Contenido_Motivo_de_Rechazo,
                    Fecha_de_Inicio_de_Publicacion = m.Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion,
                    Fecha_de_Termino = m.Registro_de_Contenido_Fecha_de_Termino,
                    Seleccionar_Todos_los_Observatorios = m.Registro_de_Contenido_Seleccionar_Todos_los_Observatorios ?? false,
                    Filtrar_Usuarios_por_Observatorio = m.Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio,

                    //Id = m.Id,
                }).ToList();
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

        }

        public IList<Spartane.Core.Classes.Registro_de_Contenido.Registro_de_Contenido> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Registro_de_ContenidoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Registro_de_Contenido.Registro_de_Contenido> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Registro_de_ContenidoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Registro_de_Contenido.Registro_de_ContenidoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            var padstartRowIndex = _dataProvider.GetParameter();
            padstartRowIndex.ParameterName = "startRowIndex";
            padstartRowIndex.DbType = DbType.Int32;
            padstartRowIndex.Value = startRowIndex;

            var padmaximumRows = _dataProvider.GetParameter();
            padmaximumRows.ParameterName = "maximumRows";
            padmaximumRows.DbType = DbType.Int32;
            padmaximumRows.Value = maximumRows;

            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var padOrder = _dataProvider.GetParameter();
            padOrder.ParameterName = "Order";
            padOrder.DbType = DbType.String;
            padOrder.Value = Order;

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllRegistro_de_Contenido>("sp_ListSelAll_Registro_de_Contenido", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Registro_de_ContenidoPagingModel result = null;

            if (data != null)
            {
                result = new Registro_de_ContenidoPagingModel
                {
                    Registro_de_Contenidos =
                        data.Select(m => new Spartane.Core.Classes.Registro_de_Contenido.Registro_de_Contenido
                {
                    Folio = m.Registro_de_Contenido_Folio
                    ,Usuario_que_Registra = m.Registro_de_Contenido_Usuario_que_Registra
                    ,Usuario_que_Registra_TTUsuarios = new Core.Classes.TTUsuarios.TTUsuarios() { IdUsuario = m.Registro_de_Contenido_Usuario_que_Registra.GetValueOrDefault(), Nombre = m.Registro_de_Contenido_Usuario_que_Registra_Nombre }
                    ,Fecha_de_Registro = m.Registro_de_Contenido_Fecha_de_Registro
                    ,Hora_de_Registro = m.Registro_de_Contenido_Hora_de_Registro
                    ,Categoria = m.Registro_de_Contenido_Categoria
                    ,Categoria_Categoria = new Core.Classes.Categoria.Categoria() { Clave = m.Registro_de_Contenido_Categoria.GetValueOrDefault(), Descripcion = m.Registro_de_Contenido_Categoria_Descripcion }
                    ,Descripcion_de_Solicitud = m.Registro_de_Contenido_Descripcion_de_Solicitud
                    ,Reportero_Asignado = m.Registro_de_Contenido_Reportero_Asignado
                    ,Reportero_Asignado_TTUsuarios = new Core.Classes.TTUsuarios.TTUsuarios() { IdUsuario = m.Registro_de_Contenido_Reportero_Asignado.GetValueOrDefault(), Nombre = m.Registro_de_Contenido_Reportero_Asignado_Nombre }
                    ,Fecha_de_Compromiso = m.Registro_de_Contenido_Fecha_de_Compromiso
                    ,Estatus = m.Registro_de_Contenido_Estatus
                    ,Estatus_Estatus_de_Contenido = new Core.Classes.Estatus_de_Contenido.Estatus_de_Contenido() { Clave = m.Registro_de_Contenido_Estatus.GetValueOrDefault(), Descripcion = m.Registro_de_Contenido_Estatus_Descripcion }
                    ,Administrador_de_Observatorio = m.Registro_de_Contenido_Administrador_de_Observatorio
                    ,Administrador_de_Observatorio_TTUsuarios = new Core.Classes.TTUsuarios.TTUsuarios() { IdUsuario = m.Registro_de_Contenido_Administrador_de_Observatorio.GetValueOrDefault(), Nombre = m.Registro_de_Contenido_Administrador_de_Observatorio_Nombre }
                    ,Reportero = m.Registro_de_Contenido_Reportero
                    ,Reportero_TTUsuarios = new Core.Classes.TTUsuarios.TTUsuarios() { IdUsuario = m.Registro_de_Contenido_Reportero.GetValueOrDefault(), Nombre = m.Registro_de_Contenido_Reportero_Nombre }
                    ,Titulo = m.Registro_de_Contenido_Titulo
                    ,Descripcion = m.Registro_de_Contenido_Descripcion
                    ,Contenido = m.Registro_de_Contenido_Contenido
                    ,Imagen = m.Registro_de_Contenido_Imagen
                    ,Imagen_TTArchivos = new Core.Classes.TTArchivos.TTArchivos() { Folio = m.Registro_de_Contenido_Imagen.GetValueOrDefault(), Nombre = m.Registro_de_Contenido_Imagen_Nombre }
                    ,Imagen_Miniatura = m.Registro_de_Contenido_Imagen_Miniatura
                    ,Imagen_Miniatura_TTArchivos = new Core.Classes.TTArchivos.TTArchivos() { Folio = m.Registro_de_Contenido_Imagen_Miniatura.GetValueOrDefault(), Nombre = m.Registro_de_Contenido_Imagen_Miniatura_Nombre }
                    ,Estilo = m.Registro_de_Contenido_Estilo
                    ,Estilo_Estilo_de_Articulo = new Core.Classes.Estilo_de_Articulo.Estilo_de_Articulo() { Clave = m.Registro_de_Contenido_Estilo.GetValueOrDefault(), Descripcion = m.Registro_de_Contenido_Estilo_Descripcion }
                    ,Adjuntar_PDF = m.Registro_de_Contenido_Adjuntar_PDF
                    ,Adjuntar_PDF_TTArchivos = new Core.Classes.TTArchivos.TTArchivos() { Folio = m.Registro_de_Contenido_Adjuntar_PDF.GetValueOrDefault(), Nombre = m.Registro_de_Contenido_Adjuntar_PDF_Nombre }
                    ,Captura_Terminada = m.Registro_de_Contenido_Captura_Terminada ?? false
                    ,Autorizado_por = m.Registro_de_Contenido_Autorizado_por
                    ,Autorizado_por_TTUsuarios = new Core.Classes.TTUsuarios.TTUsuarios() { IdUsuario = m.Registro_de_Contenido_Autorizado_por.GetValueOrDefault(), Nombre = m.Registro_de_Contenido_Autorizado_por_Nombre }
                    ,Fecha_de_Revision = m.Registro_de_Contenido_Fecha_de_Revision
                    ,Hora_de_Revision = m.Registro_de_Contenido_Hora_de_Revision
                    ,Autorizacion = m.Registro_de_Contenido_Autorizacion
                    ,Autorizacion_Autorizacion = new Core.Classes.Autorizacion.Autorizacion() { Clave = m.Registro_de_Contenido_Autorizacion.GetValueOrDefault(), Descripcion = m.Registro_de_Contenido_Autorizacion_Descripcion }
                    ,Motivo_de_Rechazo = m.Registro_de_Contenido_Motivo_de_Rechazo
                    ,Fecha_de_Inicio_de_Publicacion = m.Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion
                    ,Fecha_de_Termino = m.Registro_de_Contenido_Fecha_de_Termino
                    ,Seleccionar_Todos_los_Observatorios = m.Registro_de_Contenido_Seleccionar_Todos_los_Observatorios ?? false
                    ,Filtrar_Usuarios_por_Observatorio = m.Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio
                    ,Filtrar_Usuarios_por_Observatorio_Observatorio = new Core.Classes.Observatorio.Observatorio() { Clave = m.Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio.GetValueOrDefault(), Nombre = m.Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio_Nombre }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Registro_de_Contenido.Registro_de_Contenido> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Registro_de_ContenidoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Registro_de_Contenido.Registro_de_Contenido GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Registro_de_Contenido.Registro_de_Contenido>("sp_GetRegistro_de_Contenido", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Folio";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelRegistro_de_Contenido>("sp_DelRegistro_de_Contenido", padreKey).FirstOrDefault();
                if (padreResult != null)
                    rta = padreResult.Result.ToString() == "1";
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }

        public int Insert(Spartane.Core.Classes.Registro_de_Contenido.Registro_de_Contenido entity)
        {
            int rta;
            try
            {

		                var padreUsuario_que_Registra = _dataProvider.GetParameter();
                padreUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                padreUsuario_que_Registra.DbType = DbType.Int32;
                padreUsuario_que_Registra.Value = (object)entity.Usuario_que_Registra ?? DBNull.Value;

                var padreFecha_de_Registro = _dataProvider.GetParameter();
                padreFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                padreFecha_de_Registro.DbType = DbType.DateTime;
                padreFecha_de_Registro.Value = (object)entity.Fecha_de_Registro ?? DBNull.Value;

                var padreHora_de_Registro = _dataProvider.GetParameter();
                padreHora_de_Registro.ParameterName = "Hora_de_Registro";
                padreHora_de_Registro.DbType = DbType.String;
                padreHora_de_Registro.Value = (object)entity.Hora_de_Registro ?? DBNull.Value;
                var padreCategoria = _dataProvider.GetParameter();
                padreCategoria.ParameterName = "Categoria";
                padreCategoria.DbType = DbType.Int32;
                padreCategoria.Value = (object)entity.Categoria ?? DBNull.Value;

                var padreDescripcion_de_Solicitud = _dataProvider.GetParameter();
                padreDescripcion_de_Solicitud.ParameterName = "Descripcion_de_Solicitud";
                padreDescripcion_de_Solicitud.DbType = DbType.String;
                padreDescripcion_de_Solicitud.Value = (object)entity.Descripcion_de_Solicitud ?? DBNull.Value;
                var padreReportero_Asignado = _dataProvider.GetParameter();
                padreReportero_Asignado.ParameterName = "Reportero_Asignado";
                padreReportero_Asignado.DbType = DbType.Int32;
                padreReportero_Asignado.Value = (object)entity.Reportero_Asignado ?? DBNull.Value;

                var padreFecha_de_Compromiso = _dataProvider.GetParameter();
                padreFecha_de_Compromiso.ParameterName = "Fecha_de_Compromiso";
                padreFecha_de_Compromiso.DbType = DbType.DateTime;
                padreFecha_de_Compromiso.Value = (object)entity.Fecha_de_Compromiso ?? DBNull.Value;

                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

                var padreAdministrador_de_Observatorio = _dataProvider.GetParameter();
                padreAdministrador_de_Observatorio.ParameterName = "Administrador_de_Observatorio";
                padreAdministrador_de_Observatorio.DbType = DbType.Int32;
                padreAdministrador_de_Observatorio.Value = (object)entity.Administrador_de_Observatorio ?? DBNull.Value;

                var padreReportero = _dataProvider.GetParameter();
                padreReportero.ParameterName = "Reportero";
                padreReportero.DbType = DbType.Int32;
                padreReportero.Value = (object)entity.Reportero ?? DBNull.Value;

                var padreTitulo = _dataProvider.GetParameter();
                padreTitulo.ParameterName = "Titulo";
                padreTitulo.DbType = DbType.String;
                padreTitulo.Value = (object)entity.Titulo ?? DBNull.Value;
                var padreDescripcion = _dataProvider.GetParameter();
                padreDescripcion.ParameterName = "Descripcion";
                padreDescripcion.DbType = DbType.String;
                padreDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var padreContenido = _dataProvider.GetParameter();
                padreContenido.ParameterName = "Contenido";
                padreContenido.DbType = DbType.String;
                padreContenido.Value = (object)entity.Contenido ?? DBNull.Value;
                var padreImagen = _dataProvider.GetParameter();
                padreImagen.ParameterName = "Imagen";
                padreImagen.DbType = DbType.Int32;
                padreImagen.Value = (object)entity.Imagen ?? DBNull.Value;

                var padreImagen_Miniatura = _dataProvider.GetParameter();
                padreImagen_Miniatura.ParameterName = "Imagen_Miniatura";
                padreImagen_Miniatura.DbType = DbType.Int32;
                padreImagen_Miniatura.Value = (object)entity.Imagen_Miniatura ?? DBNull.Value;

                var padreEstilo = _dataProvider.GetParameter();
                padreEstilo.ParameterName = "Estilo";
                padreEstilo.DbType = DbType.Int32;
                padreEstilo.Value = (object)entity.Estilo ?? DBNull.Value;

                var padreAdjuntar_PDF = _dataProvider.GetParameter();
                padreAdjuntar_PDF.ParameterName = "Adjuntar_PDF";
                padreAdjuntar_PDF.DbType = DbType.Int32;
                padreAdjuntar_PDF.Value = (object)entity.Adjuntar_PDF ?? DBNull.Value;

                var padreCaptura_Terminada = _dataProvider.GetParameter();
                padreCaptura_Terminada.ParameterName = "Captura_Terminada";
                padreCaptura_Terminada.DbType = DbType.Boolean;
                padreCaptura_Terminada.Value = (object)entity.Captura_Terminada ?? DBNull.Value;
                var padreAutorizado_por = _dataProvider.GetParameter();
                padreAutorizado_por.ParameterName = "Autorizado_por";
                padreAutorizado_por.DbType = DbType.Int32;
                padreAutorizado_por.Value = (object)entity.Autorizado_por ?? DBNull.Value;

                var padreFecha_de_Revision = _dataProvider.GetParameter();
                padreFecha_de_Revision.ParameterName = "Fecha_de_Revision";
                padreFecha_de_Revision.DbType = DbType.DateTime;
                padreFecha_de_Revision.Value = (object)entity.Fecha_de_Revision ?? DBNull.Value;

                var padreHora_de_Revision = _dataProvider.GetParameter();
                padreHora_de_Revision.ParameterName = "Hora_de_Revision";
                padreHora_de_Revision.DbType = DbType.String;
                padreHora_de_Revision.Value = (object)entity.Hora_de_Revision ?? DBNull.Value;
                var padreAutorizacion = _dataProvider.GetParameter();
                padreAutorizacion.ParameterName = "Autorizacion";
                padreAutorizacion.DbType = DbType.Int32;
                padreAutorizacion.Value = (object)entity.Autorizacion ?? DBNull.Value;

                var padreMotivo_de_Rechazo = _dataProvider.GetParameter();
                padreMotivo_de_Rechazo.ParameterName = "Motivo_de_Rechazo";
                padreMotivo_de_Rechazo.DbType = DbType.String;
                padreMotivo_de_Rechazo.Value = (object)entity.Motivo_de_Rechazo ?? DBNull.Value;
                var padreFecha_de_Inicio_de_Publicacion = _dataProvider.GetParameter();
                padreFecha_de_Inicio_de_Publicacion.ParameterName = "Fecha_de_Inicio_de_Publicacion";
                padreFecha_de_Inicio_de_Publicacion.DbType = DbType.DateTime;
                padreFecha_de_Inicio_de_Publicacion.Value = (object)entity.Fecha_de_Inicio_de_Publicacion ?? DBNull.Value;

                var padreFecha_de_Termino = _dataProvider.GetParameter();
                padreFecha_de_Termino.ParameterName = "Fecha_de_Termino";
                padreFecha_de_Termino.DbType = DbType.DateTime;
                padreFecha_de_Termino.Value = (object)entity.Fecha_de_Termino ?? DBNull.Value;

                var padreSeleccionar_Todos_los_Observatorios = _dataProvider.GetParameter();
                padreSeleccionar_Todos_los_Observatorios.ParameterName = "Seleccionar_Todos_los_Observatorios";
                padreSeleccionar_Todos_los_Observatorios.DbType = DbType.Boolean;
                padreSeleccionar_Todos_los_Observatorios.Value = (object)entity.Seleccionar_Todos_los_Observatorios ?? DBNull.Value;
                var padreFiltrar_Usuarios_por_Observatorio = _dataProvider.GetParameter();
                padreFiltrar_Usuarios_por_Observatorio.ParameterName = "Filtrar_Usuarios_por_Observatorio";
                padreFiltrar_Usuarios_por_Observatorio.DbType = DbType.Int32;
                padreFiltrar_Usuarios_por_Observatorio.Value = (object)entity.Filtrar_Usuarios_por_Observatorio ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsRegistro_de_Contenido>("sp_InsRegistro_de_Contenido" , padreUsuario_que_Registra
, padreFecha_de_Registro
, padreHora_de_Registro
, padreCategoria
, padreDescripcion_de_Solicitud
, padreReportero_Asignado
, padreFecha_de_Compromiso
, padreEstatus
, padreAdministrador_de_Observatorio
, padreTitulo
, padreContenido
, padreImagen
, padreImagen_Miniatura
, padreEstilo
, padreAdjuntar_PDF
, padreCaptura_Terminada
, padreAutorizado_por
, padreFecha_de_Revision
, padreHora_de_Revision
, padreAutorizacion
, padreMotivo_de_Rechazo
, padreFecha_de_Inicio_de_Publicacion
, padreFecha_de_Termino
, padreSeleccionar_Todos_los_Observatorios
, padreFiltrar_Usuarios_por_Observatorio
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);

            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }

        public int Update(Spartane.Core.Classes.Registro_de_Contenido.Registro_de_Contenido entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)entity.Usuario_que_Registra ?? DBNull.Value;

                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)entity.Fecha_de_Registro ?? DBNull.Value;

                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)entity.Hora_de_Registro ?? DBNull.Value;
                var paramUpdCategoria = _dataProvider.GetParameter();
                paramUpdCategoria.ParameterName = "Categoria";
                paramUpdCategoria.DbType = DbType.Int32;
                paramUpdCategoria.Value = (object)entity.Categoria ?? DBNull.Value;

                var paramUpdDescripcion_de_Solicitud = _dataProvider.GetParameter();
                paramUpdDescripcion_de_Solicitud.ParameterName = "Descripcion_de_Solicitud";
                paramUpdDescripcion_de_Solicitud.DbType = DbType.String;
                paramUpdDescripcion_de_Solicitud.Value = (object)entity.Descripcion_de_Solicitud ?? DBNull.Value;
                var paramUpdReportero_Asignado = _dataProvider.GetParameter();
                paramUpdReportero_Asignado.ParameterName = "Reportero_Asignado";
                paramUpdReportero_Asignado.DbType = DbType.Int32;
                paramUpdReportero_Asignado.Value = (object)entity.Reportero_Asignado ?? DBNull.Value;

                var paramUpdFecha_de_Compromiso = _dataProvider.GetParameter();
                paramUpdFecha_de_Compromiso.ParameterName = "Fecha_de_Compromiso";
                paramUpdFecha_de_Compromiso.DbType = DbType.DateTime;
                paramUpdFecha_de_Compromiso.Value = (object)entity.Fecha_de_Compromiso ?? DBNull.Value;

                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

                var paramUpdAdministrador_de_Observatorio = _dataProvider.GetParameter();
                paramUpdAdministrador_de_Observatorio.ParameterName = "Administrador_de_Observatorio";
                paramUpdAdministrador_de_Observatorio.DbType = DbType.Int32;
                paramUpdAdministrador_de_Observatorio.Value = (object)entity.Administrador_de_Observatorio ?? DBNull.Value;

                var paramUpdReportero = _dataProvider.GetParameter();
                paramUpdReportero.ParameterName = "Reportero";
                paramUpdReportero.DbType = DbType.Int32;
                paramUpdReportero.Value = (object)entity.Reportero ?? DBNull.Value;

                var paramUpdTitulo = _dataProvider.GetParameter();
                paramUpdTitulo.ParameterName = "Titulo";
                paramUpdTitulo.DbType = DbType.String;
                paramUpdTitulo.Value = (object)entity.Titulo ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var paramUpdContenido = _dataProvider.GetParameter();
                paramUpdContenido.ParameterName = "Contenido";
                paramUpdContenido.DbType = DbType.String;
                paramUpdContenido.Value = (object)entity.Contenido ?? DBNull.Value;
                var paramUpdImagen = _dataProvider.GetParameter();
                paramUpdImagen.ParameterName = "Imagen";
                paramUpdImagen.DbType = DbType.Int32;
                paramUpdImagen.Value = (object)entity.Imagen ?? DBNull.Value;

                var paramUpdImagen_Miniatura = _dataProvider.GetParameter();
                paramUpdImagen_Miniatura.ParameterName = "Imagen_Miniatura";
                paramUpdImagen_Miniatura.DbType = DbType.Int32;
                paramUpdImagen_Miniatura.Value = (object)entity.Imagen_Miniatura ?? DBNull.Value;

                var paramUpdEstilo = _dataProvider.GetParameter();
                paramUpdEstilo.ParameterName = "Estilo";
                paramUpdEstilo.DbType = DbType.Int32;
                paramUpdEstilo.Value = (object)entity.Estilo ?? DBNull.Value;

                var paramUpdAdjuntar_PDF = _dataProvider.GetParameter();
                paramUpdAdjuntar_PDF.ParameterName = "Adjuntar_PDF";
                paramUpdAdjuntar_PDF.DbType = DbType.Int32;
                paramUpdAdjuntar_PDF.Value = (object)entity.Adjuntar_PDF ?? DBNull.Value;

                var paramUpdCaptura_Terminada = _dataProvider.GetParameter();
                paramUpdCaptura_Terminada.ParameterName = "Captura_Terminada";
                paramUpdCaptura_Terminada.DbType = DbType.Boolean;
                paramUpdCaptura_Terminada.Value = (object)entity.Captura_Terminada ?? DBNull.Value;
                var paramUpdAutorizado_por = _dataProvider.GetParameter();
                paramUpdAutorizado_por.ParameterName = "Autorizado_por";
                paramUpdAutorizado_por.DbType = DbType.Int32;
                paramUpdAutorizado_por.Value = (object)entity.Autorizado_por ?? DBNull.Value;

                var paramUpdFecha_de_Revision = _dataProvider.GetParameter();
                paramUpdFecha_de_Revision.ParameterName = "Fecha_de_Revision";
                paramUpdFecha_de_Revision.DbType = DbType.DateTime;
                paramUpdFecha_de_Revision.Value = (object)entity.Fecha_de_Revision ?? DBNull.Value;

                var paramUpdHora_de_Revision = _dataProvider.GetParameter();
                paramUpdHora_de_Revision.ParameterName = "Hora_de_Revision";
                paramUpdHora_de_Revision.DbType = DbType.String;
                paramUpdHora_de_Revision.Value = (object)entity.Hora_de_Revision ?? DBNull.Value;
                var paramUpdAutorizacion = _dataProvider.GetParameter();
                paramUpdAutorizacion.ParameterName = "Autorizacion";
                paramUpdAutorizacion.DbType = DbType.Int32;
                paramUpdAutorizacion.Value = (object)entity.Autorizacion ?? DBNull.Value;

                var paramUpdMotivo_de_Rechazo = _dataProvider.GetParameter();
                paramUpdMotivo_de_Rechazo.ParameterName = "Motivo_de_Rechazo";
                paramUpdMotivo_de_Rechazo.DbType = DbType.String;
                paramUpdMotivo_de_Rechazo.Value = (object)entity.Motivo_de_Rechazo ?? DBNull.Value;
                var paramUpdFecha_de_Inicio_de_Publicacion = _dataProvider.GetParameter();
                paramUpdFecha_de_Inicio_de_Publicacion.ParameterName = "Fecha_de_Inicio_de_Publicacion";
                paramUpdFecha_de_Inicio_de_Publicacion.DbType = DbType.DateTime;
                paramUpdFecha_de_Inicio_de_Publicacion.Value = (object)entity.Fecha_de_Inicio_de_Publicacion ?? DBNull.Value;

                var paramUpdFecha_de_Termino = _dataProvider.GetParameter();
                paramUpdFecha_de_Termino.ParameterName = "Fecha_de_Termino";
                paramUpdFecha_de_Termino.DbType = DbType.DateTime;
                paramUpdFecha_de_Termino.Value = (object)entity.Fecha_de_Termino ?? DBNull.Value;

                var paramUpdSeleccionar_Todos_los_Observatorios = _dataProvider.GetParameter();
                paramUpdSeleccionar_Todos_los_Observatorios.ParameterName = "Seleccionar_Todos_los_Observatorios";
                paramUpdSeleccionar_Todos_los_Observatorios.DbType = DbType.Boolean;
                paramUpdSeleccionar_Todos_los_Observatorios.Value = (object)entity.Seleccionar_Todos_los_Observatorios ?? DBNull.Value;
                var paramUpdFiltrar_Usuarios_por_Observatorio = _dataProvider.GetParameter();
                paramUpdFiltrar_Usuarios_por_Observatorio.ParameterName = "Filtrar_Usuarios_por_Observatorio";
                paramUpdFiltrar_Usuarios_por_Observatorio.DbType = DbType.Int32;
                paramUpdFiltrar_Usuarios_por_Observatorio.Value = (object)entity.Filtrar_Usuarios_por_Observatorio ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdRegistro_de_Contenido>("sp_UpdRegistro_de_Contenido" , paramUpdFolio , paramUpdUsuario_que_Registra , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdCategoria , paramUpdDescripcion_de_Solicitud , paramUpdReportero_Asignado , paramUpdFecha_de_Compromiso , paramUpdEstatus , paramUpdAdministrador_de_Observatorio , paramUpdTitulo , paramUpdContenido , paramUpdImagen , paramUpdImagen_Miniatura , paramUpdEstilo , paramUpdAdjuntar_PDF , paramUpdCaptura_Terminada , paramUpdAutorizado_por , paramUpdFecha_de_Revision , paramUpdHora_de_Revision , paramUpdAutorizacion , paramUpdMotivo_de_Rechazo , paramUpdFecha_de_Inicio_de_Publicacion , paramUpdFecha_de_Termino , paramUpdSeleccionar_Todos_los_Observatorios , paramUpdFiltrar_Usuarios_por_Observatorio ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }
        #endregion
    }
}
