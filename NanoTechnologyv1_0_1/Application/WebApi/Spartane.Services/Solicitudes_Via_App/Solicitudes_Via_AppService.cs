using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Solicitudes_Via_App;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Solicitudes_Via_App
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Solicitudes_Via_AppService : ISolicitudes_Via_AppService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Solicitudes_Via_App.Solicitudes_Via_App> _Solicitudes_Via_AppRepository;
        #endregion

        #region Ctor
        public Solicitudes_Via_AppService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Solicitudes_Via_App.Solicitudes_Via_App> Solicitudes_Via_AppRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Solicitudes_Via_AppRepository = Solicitudes_Via_AppRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Solicitudes_Via_AppRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Solicitudes_Via_App.Solicitudes_Via_App> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Solicitudes_Via_App.Solicitudes_Via_App>("sp_SelAllSolicitudes_Via_App");
        }

        public IList<Core.Classes.Solicitudes_Via_App.Solicitudes_Via_App> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSolicitudes_Via_App_Complete>("sp_SelAllComplete_Solicitudes_Via_App");
            return data.Select(m => new Core.Classes.Solicitudes_Via_App.Solicitudes_Via_App
            {
                Folio = m.Folio
                ,Usuario_que_Registra_TTUsuarios = new Core.Classes.TTUsuarios.TTUsuarios() { IdUsuario = m.Usuario_que_Registra.GetValueOrDefault(), Nombre = m.Usuario_que_Registra_Nombre }
                ,Fecha_de_Registro = m.Fecha_de_Registro
                ,Hora_de_Registro = m.Hora_de_Registro
                ,Nombre = m.Nombre
                ,Correo = m.Correo
                ,Opcion_Opciones_de_Solicitud_via_App = new Core.Classes.Opciones_de_Solicitud_via_App.Opciones_de_Solicitud_via_App() { Clave = m.Opcion.GetValueOrDefault(), Descripcion = m.Opcion_Descripcion }
                ,Descripcion = m.Descripcion
                ,Lada = m.Lada
                ,Telefono = m.Telefono
                ,Estatus_Estatus_de_Solicitud_Via_App = new Core.Classes.Estatus_de_Solicitud_Via_App.Estatus_de_Solicitud_Via_App() { Clave = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }
                ,Observatorio_Observatorio = new Core.Classes.Observatorio.Observatorio() { Clave = m.Observatorio.GetValueOrDefault(), Nombre = m.Observatorio_Nombre }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Solicitudes_Via_App>("sp_ListSelCount_Solicitudes_Via_App", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Solicitudes_Via_App.Solicitudes_Via_App> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSolicitudes_Via_App>("sp_ListSelAll_Solicitudes_Via_App", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Solicitudes_Via_App.Solicitudes_Via_App
                {
                    Folio = m.Solicitudes_Via_App_Folio,
                    Usuario_que_Registra = m.Solicitudes_Via_App_Usuario_que_Registra,
                    Fecha_de_Registro = m.Solicitudes_Via_App_Fecha_de_Registro,
                    Hora_de_Registro = m.Solicitudes_Via_App_Hora_de_Registro,
                    Nombre = m.Solicitudes_Via_App_Nombre,
                    Correo = m.Solicitudes_Via_App_Correo,
                    Opcion = m.Solicitudes_Via_App_Opcion,
                    Descripcion = m.Solicitudes_Via_App_Descripcion,
                    Lada = m.Solicitudes_Via_App_Lada,
                    Telefono = m.Solicitudes_Via_App_Telefono,
                    Estatus = m.Solicitudes_Via_App_Estatus,
                    Observatorio = m.Solicitudes_Via_App_Observatorio,

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

        public IList<Spartane.Core.Classes.Solicitudes_Via_App.Solicitudes_Via_App> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Solicitudes_Via_AppRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Solicitudes_Via_App.Solicitudes_Via_App> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Solicitudes_Via_AppRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Solicitudes_Via_App.Solicitudes_Via_AppPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSolicitudes_Via_App>("sp_ListSelAll_Solicitudes_Via_App", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Solicitudes_Via_AppPagingModel result = null;

            if (data != null)
            {
                result = new Solicitudes_Via_AppPagingModel
                {
                    Solicitudes_Via_Apps =
                        data.Select(m => new Spartane.Core.Classes.Solicitudes_Via_App.Solicitudes_Via_App
                {
                    Folio = m.Solicitudes_Via_App_Folio
                    ,Usuario_que_Registra = m.Solicitudes_Via_App_Usuario_que_Registra
                    ,Usuario_que_Registra_TTUsuarios = new Core.Classes.TTUsuarios.TTUsuarios() { IdUsuario = m.Solicitudes_Via_App_Usuario_que_Registra.GetValueOrDefault(), Nombre = m.Solicitudes_Via_App_Usuario_que_Registra_Nombre }
                    ,Fecha_de_Registro = m.Solicitudes_Via_App_Fecha_de_Registro
                    ,Hora_de_Registro = m.Solicitudes_Via_App_Hora_de_Registro
                    ,Nombre = m.Solicitudes_Via_App_Nombre
                    ,Correo = m.Solicitudes_Via_App_Correo
                    ,Opcion = m.Solicitudes_Via_App_Opcion
                    ,Opcion_Opciones_de_Solicitud_via_App = new Core.Classes.Opciones_de_Solicitud_via_App.Opciones_de_Solicitud_via_App() { Clave = m.Solicitudes_Via_App_Opcion.GetValueOrDefault(), Descripcion = m.Solicitudes_Via_App_Opcion_Descripcion }
                    ,Descripcion = m.Solicitudes_Via_App_Descripcion
                    ,Lada = m.Solicitudes_Via_App_Lada
                    ,Telefono = m.Solicitudes_Via_App_Telefono
                    ,Estatus = m.Solicitudes_Via_App_Estatus
                    ,Estatus_Estatus_de_Solicitud_Via_App = new Core.Classes.Estatus_de_Solicitud_Via_App.Estatus_de_Solicitud_Via_App() { Clave = m.Solicitudes_Via_App_Estatus.GetValueOrDefault(), Descripcion = m.Solicitudes_Via_App_Estatus_Descripcion }
                    ,Observatorio = m.Solicitudes_Via_App_Observatorio
                    ,Observatorio_Observatorio = new Core.Classes.Observatorio.Observatorio() { Clave = m.Solicitudes_Via_App_Observatorio.GetValueOrDefault(), Nombre = m.Solicitudes_Via_App_Observatorio_Nombre }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Solicitudes_Via_App.Solicitudes_Via_App> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Solicitudes_Via_AppRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Solicitudes_Via_App.Solicitudes_Via_App GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Solicitudes_Via_App.Solicitudes_Via_App>("sp_GetSolicitudes_Via_App", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSolicitudes_Via_App>("sp_DelSolicitudes_Via_App", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Solicitudes_Via_App.Solicitudes_Via_App entity)
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
                var padreNombre = _dataProvider.GetParameter();
                padreNombre.ParameterName = "Nombre";
                padreNombre.DbType = DbType.String;
                padreNombre.Value = (object)entity.Nombre ?? DBNull.Value;
                var padreCorreo = _dataProvider.GetParameter();
                padreCorreo.ParameterName = "Correo";
                padreCorreo.DbType = DbType.String;
                padreCorreo.Value = (object)entity.Correo ?? DBNull.Value;
                var padreOpcion = _dataProvider.GetParameter();
                padreOpcion.ParameterName = "Opcion";
                padreOpcion.DbType = DbType.Int32;
                padreOpcion.Value = (object)entity.Opcion ?? DBNull.Value;

                var padreDescripcion = _dataProvider.GetParameter();
                padreDescripcion.ParameterName = "Descripcion";
                padreDescripcion.DbType = DbType.String;
                padreDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var padreLada = _dataProvider.GetParameter();
                padreLada.ParameterName = "Lada";
                padreLada.DbType = DbType.String;
                padreLada.Value = (object)entity.Lada ?? DBNull.Value;
                var padreTelefono = _dataProvider.GetParameter();
                padreTelefono.ParameterName = "Telefono";
                padreTelefono.DbType = DbType.String;
                padreTelefono.Value = (object)entity.Telefono ?? DBNull.Value;
                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

                var padreObservatorio = _dataProvider.GetParameter();
                padreObservatorio.ParameterName = "Observatorio";
                padreObservatorio.DbType = DbType.Int32;
                padreObservatorio.Value = (object)entity.Observatorio ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSolicitudes_Via_App>("sp_InsSolicitudes_Via_App" , padreUsuario_que_Registra
, padreFecha_de_Registro
, padreHora_de_Registro
, padreNombre
, padreCorreo
, padreOpcion
, padreDescripcion
, padreLada
, padreTelefono
, padreEstatus
, padreObservatorio
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

        public int Update(Spartane.Core.Classes.Solicitudes_Via_App.Solicitudes_Via_App entity)
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
                var paramUpdNombre = _dataProvider.GetParameter();
                paramUpdNombre.ParameterName = "Nombre";
                paramUpdNombre.DbType = DbType.String;
                paramUpdNombre.Value = (object)entity.Nombre ?? DBNull.Value;
                var paramUpdCorreo = _dataProvider.GetParameter();
                paramUpdCorreo.ParameterName = "Correo";
                paramUpdCorreo.DbType = DbType.String;
                paramUpdCorreo.Value = (object)entity.Correo ?? DBNull.Value;
                var paramUpdOpcion = _dataProvider.GetParameter();
                paramUpdOpcion.ParameterName = "Opcion";
                paramUpdOpcion.DbType = DbType.Int32;
                paramUpdOpcion.Value = (object)entity.Opcion ?? DBNull.Value;

                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var paramUpdLada = _dataProvider.GetParameter();
                paramUpdLada.ParameterName = "Lada";
                paramUpdLada.DbType = DbType.String;
                paramUpdLada.Value = (object)entity.Lada ?? DBNull.Value;
                var paramUpdTelefono = _dataProvider.GetParameter();
                paramUpdTelefono.ParameterName = "Telefono";
                paramUpdTelefono.DbType = DbType.String;
                paramUpdTelefono.Value = (object)entity.Telefono ?? DBNull.Value;
                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

                var paramUpdObservatorio = _dataProvider.GetParameter();
                paramUpdObservatorio.ParameterName = "Observatorio";
                paramUpdObservatorio.DbType = DbType.Int32;
                paramUpdObservatorio.Value = (object)entity.Observatorio ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSolicitudes_Via_App>("sp_UpdSolicitudes_Via_App" , paramUpdFolio , paramUpdUsuario_que_Registra , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdNombre , paramUpdCorreo , paramUpdOpcion , paramUpdDescripcion , paramUpdLada , paramUpdTelefono , paramUpdEstatus , paramUpdObservatorio ).FirstOrDefault();

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
