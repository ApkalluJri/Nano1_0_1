using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Usuarios_Registrados_en_Observatorios;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Usuarios_Registrados_en_Observatorios
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Usuarios_Registrados_en_ObservatoriosService : IUsuarios_Registrados_en_ObservatoriosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Usuarios_Registrados_en_Observatorios.Usuarios_Registrados_en_Observatorios> _Usuarios_Registrados_en_ObservatoriosRepository;
        #endregion

        #region Ctor
        public Usuarios_Registrados_en_ObservatoriosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Usuarios_Registrados_en_Observatorios.Usuarios_Registrados_en_Observatorios> Usuarios_Registrados_en_ObservatoriosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Usuarios_Registrados_en_ObservatoriosRepository = Usuarios_Registrados_en_ObservatoriosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Usuarios_Registrados_en_ObservatoriosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Usuarios_Registrados_en_Observatorios.Usuarios_Registrados_en_Observatorios> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Usuarios_Registrados_en_Observatorios.Usuarios_Registrados_en_Observatorios>("sp_SelAllUsuarios_Registrados_en_Observatorios");
        }

        public IList<Core.Classes.Usuarios_Registrados_en_Observatorios.Usuarios_Registrados_en_Observatorios> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallUsuarios_Registrados_en_Observatorios_Complete>("sp_SelAllComplete_Usuarios_Registrados_en_Observatorios");
            return data.Select(m => new Core.Classes.Usuarios_Registrados_en_Observatorios.Usuarios_Registrados_en_Observatorios
            {
                Clave = m.Clave
                ,Observatorio_Observatorio = new Core.Classes.Observatorio.Observatorio() { Clave = m.Observatorio.GetValueOrDefault(), Nombre = m.Observatorio_Nombre }
                ,Usuario_Registro_de_Usuario = new Core.Classes.Registro_de_Usuario.Registro_de_Usuario() { Folio = m.Usuario.GetValueOrDefault(), Nombre = m.Usuario_Nombre }
                ,Nombre = m.Nombre
                ,Correo = m.Correo
                ,Contrasena = m.Contrasena
                ,Fecha_de_Ingreso = m.Fecha_de_Ingreso
                ,Token = m.Token
                ,Identificador_Dispositivo = m.Identificador_Dispositivo
                ,Tipo_de_Dispositivo_Tipo_de_Dispositivo = new Core.Classes.Tipo_de_Dispositivo.Tipo_de_Dispositivo() { Clave = m.Tipo_de_Dispositivo.GetValueOrDefault(), Tipo = m.Tipo_de_Dispositivo_Tipo }
                ,Estado_Token = m.Estado_Token.GetValueOrDefault()


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Usuarios_Registrados_en_Observatorios>("sp_ListSelCount_Usuarios_Registrados_en_Observatorios", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Usuarios_Registrados_en_Observatorios.Usuarios_Registrados_en_Observatorios> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllUsuarios_Registrados_en_Observatorios>("sp_ListSelAll_Usuarios_Registrados_en_Observatorios", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Usuarios_Registrados_en_Observatorios.Usuarios_Registrados_en_Observatorios
                {
                    Clave = m.Usuarios_Registrados_en_Observatorios_Clave,
                    Observatorio = m.Usuarios_Registrados_en_Observatorios_Observatorio,
                    Usuario = m.Usuarios_Registrados_en_Observatorios_Usuario,
                    Nombre = m.Usuarios_Registrados_en_Observatorios_Nombre,
                    Correo = m.Usuarios_Registrados_en_Observatorios_Correo,
                    Contrasena = m.Usuarios_Registrados_en_Observatorios_Contrasena,
                    Fecha_de_Ingreso = m.Usuarios_Registrados_en_Observatorios_Fecha_de_Ingreso,
                    Token = m.Usuarios_Registrados_en_Observatorios_Token,
                    Identificador_Dispositivo = m.Usuarios_Registrados_en_Observatorios_Identificador_Dispositivo,
                    Tipo_de_Dispositivo = m.Usuarios_Registrados_en_Observatorios_Tipo_de_Dispositivo,
                    Estado_Token = m.Usuarios_Registrados_en_Observatorios_Estado_Token ?? false,

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

        public IList<Spartane.Core.Classes.Usuarios_Registrados_en_Observatorios.Usuarios_Registrados_en_Observatorios> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Usuarios_Registrados_en_ObservatoriosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Usuarios_Registrados_en_Observatorios.Usuarios_Registrados_en_Observatorios> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Usuarios_Registrados_en_ObservatoriosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Usuarios_Registrados_en_Observatorios.Usuarios_Registrados_en_ObservatoriosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllUsuarios_Registrados_en_Observatorios>("sp_ListSelAll_Usuarios_Registrados_en_Observatorios", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Usuarios_Registrados_en_ObservatoriosPagingModel result = null;

            if (data != null)
            {
                result = new Usuarios_Registrados_en_ObservatoriosPagingModel
                {
                    Usuarios_Registrados_en_Observatorioss =
                        data.Select(m => new Spartane.Core.Classes.Usuarios_Registrados_en_Observatorios.Usuarios_Registrados_en_Observatorios
                {
                    Clave = m.Usuarios_Registrados_en_Observatorios_Clave
                    ,Observatorio = m.Usuarios_Registrados_en_Observatorios_Observatorio
                    ,Observatorio_Observatorio = new Core.Classes.Observatorio.Observatorio() { Clave = m.Usuarios_Registrados_en_Observatorios_Observatorio.GetValueOrDefault(), Nombre = m.Usuarios_Registrados_en_Observatorios_Observatorio_Nombre }
                    ,Usuario = m.Usuarios_Registrados_en_Observatorios_Usuario
                    ,Usuario_Registro_de_Usuario = new Core.Classes.Registro_de_Usuario.Registro_de_Usuario() { Folio = m.Usuarios_Registrados_en_Observatorios_Usuario.GetValueOrDefault(), Nombre = m.Usuarios_Registrados_en_Observatorios_Usuario_Nombre }
                    ,Nombre = m.Usuarios_Registrados_en_Observatorios_Nombre
                    ,Correo = m.Usuarios_Registrados_en_Observatorios_Correo
                    ,Contrasena = m.Usuarios_Registrados_en_Observatorios_Contrasena
                    ,Fecha_de_Ingreso = m.Usuarios_Registrados_en_Observatorios_Fecha_de_Ingreso
                    ,Token = m.Usuarios_Registrados_en_Observatorios_Token
                    ,Identificador_Dispositivo = m.Usuarios_Registrados_en_Observatorios_Identificador_Dispositivo
                    ,Tipo_de_Dispositivo = m.Usuarios_Registrados_en_Observatorios_Tipo_de_Dispositivo
                    ,Tipo_de_Dispositivo_Tipo_de_Dispositivo = new Core.Classes.Tipo_de_Dispositivo.Tipo_de_Dispositivo() { Clave = m.Usuarios_Registrados_en_Observatorios_Tipo_de_Dispositivo.GetValueOrDefault(), Tipo = m.Usuarios_Registrados_en_Observatorios_Tipo_de_Dispositivo_Tipo }
                    ,Estado_Token = m.Usuarios_Registrados_en_Observatorios_Estado_Token ?? false

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Usuarios_Registrados_en_Observatorios.Usuarios_Registrados_en_Observatorios> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Usuarios_Registrados_en_ObservatoriosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Usuarios_Registrados_en_Observatorios.Usuarios_Registrados_en_Observatorios GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Usuarios_Registrados_en_Observatorios.Usuarios_Registrados_en_Observatorios>("sp_GetUsuarios_Registrados_en_Observatorios", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Clave";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelUsuarios_Registrados_en_Observatorios>("sp_DelUsuarios_Registrados_en_Observatorios", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Usuarios_Registrados_en_Observatorios.Usuarios_Registrados_en_Observatorios entity)
        {
            int rta;
            try
            {

		                var padreObservatorio = _dataProvider.GetParameter();
                padreObservatorio.ParameterName = "Observatorio";
                padreObservatorio.DbType = DbType.Int32;
                padreObservatorio.Value = (object)entity.Observatorio ?? DBNull.Value;

                var padreUsuario = _dataProvider.GetParameter();
                padreUsuario.ParameterName = "Usuario";
                padreUsuario.DbType = DbType.Int32;
                padreUsuario.Value = (object)entity.Usuario ?? DBNull.Value;

                var padreNombre = _dataProvider.GetParameter();
                padreNombre.ParameterName = "Nombre";
                padreNombre.DbType = DbType.String;
                padreNombre.Value = (object)entity.Nombre ?? DBNull.Value;
                var padreCorreo = _dataProvider.GetParameter();
                padreCorreo.ParameterName = "Correo";
                padreCorreo.DbType = DbType.String;
                padreCorreo.Value = (object)entity.Correo ?? DBNull.Value;
                var padreContrasena = _dataProvider.GetParameter();
                padreContrasena.ParameterName = "Contrasena";
                padreContrasena.DbType = DbType.String;
                padreContrasena.Value = (object)entity.Contrasena ?? DBNull.Value;
                var padreFecha_de_Ingreso = _dataProvider.GetParameter();
                padreFecha_de_Ingreso.ParameterName = "Fecha_de_Ingreso";
                padreFecha_de_Ingreso.DbType = DbType.DateTime;
                padreFecha_de_Ingreso.Value = (object)entity.Fecha_de_Ingreso ?? DBNull.Value;

                var padreToken = _dataProvider.GetParameter();
                padreToken.ParameterName = "Token";
                padreToken.DbType = DbType.String;
                padreToken.Value = (object)entity.Token ?? DBNull.Value;
                var padreIdentificador_Dispositivo = _dataProvider.GetParameter();
                padreIdentificador_Dispositivo.ParameterName = "Identificador_Dispositivo";
                padreIdentificador_Dispositivo.DbType = DbType.String;
                padreIdentificador_Dispositivo.Value = (object)entity.Identificador_Dispositivo ?? DBNull.Value;
                var padreTipo_de_Dispositivo = _dataProvider.GetParameter();
                padreTipo_de_Dispositivo.ParameterName = "Tipo_de_Dispositivo";
                padreTipo_de_Dispositivo.DbType = DbType.Int32;
                padreTipo_de_Dispositivo.Value = (object)entity.Tipo_de_Dispositivo ?? DBNull.Value;

                var padreEstado_Token = _dataProvider.GetParameter();
                padreEstado_Token.ParameterName = "Estado_Token";
                padreEstado_Token.DbType = DbType.Boolean;
                padreEstado_Token.Value = (object)entity.Estado_Token ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsUsuarios_Registrados_en_Observatorios>("sp_InsUsuarios_Registrados_en_Observatorios" , padreObservatorio
, padreUsuario
, padreNombre
, padreCorreo
, padreContrasena
, padreFecha_de_Ingreso
, padreToken
, padreIdentificador_Dispositivo
, padreTipo_de_Dispositivo
, padreEstado_Token
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Clave);

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

        public int Update(Spartane.Core.Classes.Usuarios_Registrados_en_Observatorios.Usuarios_Registrados_en_Observatorios entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdObservatorio = _dataProvider.GetParameter();
                paramUpdObservatorio.ParameterName = "Observatorio";
                paramUpdObservatorio.DbType = DbType.Int32;
                paramUpdObservatorio.Value = (object)entity.Observatorio ?? DBNull.Value;

                var paramUpdUsuario = _dataProvider.GetParameter();
                paramUpdUsuario.ParameterName = "Usuario";
                paramUpdUsuario.DbType = DbType.Int32;
                paramUpdUsuario.Value = (object)entity.Usuario ?? DBNull.Value;

                var paramUpdNombre = _dataProvider.GetParameter();
                paramUpdNombre.ParameterName = "Nombre";
                paramUpdNombre.DbType = DbType.String;
                paramUpdNombre.Value = (object)entity.Nombre ?? DBNull.Value;
                var paramUpdCorreo = _dataProvider.GetParameter();
                paramUpdCorreo.ParameterName = "Correo";
                paramUpdCorreo.DbType = DbType.String;
                paramUpdCorreo.Value = (object)entity.Correo ?? DBNull.Value;
                var paramUpdContrasena = _dataProvider.GetParameter();
                paramUpdContrasena.ParameterName = "Contrasena";
                paramUpdContrasena.DbType = DbType.String;
                paramUpdContrasena.Value = (object)entity.Contrasena ?? DBNull.Value;
                var paramUpdFecha_de_Ingreso = _dataProvider.GetParameter();
                paramUpdFecha_de_Ingreso.ParameterName = "Fecha_de_Ingreso";
                paramUpdFecha_de_Ingreso.DbType = DbType.DateTime;
                paramUpdFecha_de_Ingreso.Value = (object)entity.Fecha_de_Ingreso ?? DBNull.Value;

                var paramUpdToken = _dataProvider.GetParameter();
                paramUpdToken.ParameterName = "Token";
                paramUpdToken.DbType = DbType.String;
                paramUpdToken.Value = (object)entity.Token ?? DBNull.Value;
                var paramUpdIdentificador_Dispositivo = _dataProvider.GetParameter();
                paramUpdIdentificador_Dispositivo.ParameterName = "Identificador_Dispositivo";
                paramUpdIdentificador_Dispositivo.DbType = DbType.String;
                paramUpdIdentificador_Dispositivo.Value = (object)entity.Identificador_Dispositivo ?? DBNull.Value;
                var paramUpdTipo_de_Dispositivo = _dataProvider.GetParameter();
                paramUpdTipo_de_Dispositivo.ParameterName = "Tipo_de_Dispositivo";
                paramUpdTipo_de_Dispositivo.DbType = DbType.Int32;
                paramUpdTipo_de_Dispositivo.Value = (object)entity.Tipo_de_Dispositivo ?? DBNull.Value;

                var paramUpdEstado_Token = _dataProvider.GetParameter();
                paramUpdEstado_Token.ParameterName = "Estado_Token";
                paramUpdEstado_Token.DbType = DbType.Boolean;
                paramUpdEstado_Token.Value = (object)entity.Estado_Token ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdUsuarios_Registrados_en_Observatorios>("sp_UpdUsuarios_Registrados_en_Observatorios" , paramUpdClave , paramUpdObservatorio , paramUpdUsuario , paramUpdNombre , paramUpdCorreo , paramUpdContrasena , paramUpdFecha_de_Ingreso , paramUpdToken , paramUpdIdentificador_Dispositivo , paramUpdTipo_de_Dispositivo , paramUpdEstado_Token ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Clave);
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
