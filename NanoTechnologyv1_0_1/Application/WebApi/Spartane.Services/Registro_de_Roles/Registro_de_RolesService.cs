using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Registro_de_Roles;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Registro_de_Roles
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Registro_de_RolesService : IRegistro_de_RolesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Registro_de_Roles.Registro_de_Roles> _Registro_de_RolesRepository;
        #endregion

        #region Ctor
        public Registro_de_RolesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Registro_de_Roles.Registro_de_Roles> Registro_de_RolesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Registro_de_RolesRepository = Registro_de_RolesRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Registro_de_RolesRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Registro_de_Roles.Registro_de_Roles> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Registro_de_Roles.Registro_de_Roles>("sp_SelAllRegistro_de_Roles");
        }

        public IList<Core.Classes.Registro_de_Roles.Registro_de_Roles> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallRegistro_de_Roles_Complete>("sp_SelAllComplete_Registro_de_Roles");
            return data.Select(m => new Core.Classes.Registro_de_Roles.Registro_de_Roles
            {
                Folio = m.Folio
                ,Usuario_que_Registra_TTUsuarios = new Core.Classes.TTUsuarios.TTUsuarios() { IdUsuario = m.Usuario_que_Registra.GetValueOrDefault(), Nombre = m.Usuario_que_Registra_Nombre }
                ,Fecha_de_Registro = m.Fecha_de_Registro
                ,Hora_de_Registro = m.Hora_de_Registro
                ,Nombre = m.Nombre
                ,Clave_de_Acceso = m.Clave_de_Acceso
                ,Contrasena = m.Contrasena
                ,Correo = m.Correo
                ,Rol_Rol_de_Usuario = new Core.Classes.Rol_de_Usuario.Rol_de_Usuario() { Clave = m.Rol.GetValueOrDefault(), Descripcion = m.Rol_Descripcion }
                ,Usuario_de_Sistema_TTUsuarios = new Core.Classes.TTUsuarios.TTUsuarios() { IdUsuario = m.Usuario_de_Sistema.GetValueOrDefault(), Nombre = m.Usuario_de_Sistema_Nombre }
                ,Observatorios = m.Observatorios


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Registro_de_Roles>("sp_ListSelCount_Registro_de_Roles", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Registro_de_Roles.Registro_de_Roles> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllRegistro_de_Roles>("sp_ListSelAll_Registro_de_Roles", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Registro_de_Roles.Registro_de_Roles
                {
                    Folio = m.Registro_de_Roles_Folio,
                    Usuario_que_Registra = m.Registro_de_Roles_Usuario_que_Registra,
                    Fecha_de_Registro = m.Registro_de_Roles_Fecha_de_Registro,
                    Hora_de_Registro = m.Registro_de_Roles_Hora_de_Registro,
                    Nombre = m.Registro_de_Roles_Nombre,
                    Clave_de_Acceso = m.Registro_de_Roles_Clave_de_Acceso,
                    Contrasena = m.Registro_de_Roles_Contrasena,
                    Correo = m.Registro_de_Roles_Correo,
                    Rol = m.Registro_de_Roles_Rol,
                    Usuario_de_Sistema = m.Registro_de_Roles_Usuario_de_Sistema,
                    Observatorios = m.Registro_de_Roles_Observatorios,

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

        public IList<Spartane.Core.Classes.Registro_de_Roles.Registro_de_Roles> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Registro_de_RolesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Registro_de_Roles.Registro_de_Roles> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Registro_de_RolesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Registro_de_Roles.Registro_de_RolesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllRegistro_de_Roles>("sp_ListSelAll_Registro_de_Roles", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Registro_de_RolesPagingModel result = null;

            if (data != null)
            {
                result = new Registro_de_RolesPagingModel
                {
                    Registro_de_Roless =
                        data.Select(m => new Spartane.Core.Classes.Registro_de_Roles.Registro_de_Roles
                {
                    Folio = m.Registro_de_Roles_Folio
                    ,Usuario_que_Registra = m.Registro_de_Roles_Usuario_que_Registra
                    ,Usuario_que_Registra_TTUsuarios = new Core.Classes.TTUsuarios.TTUsuarios() { IdUsuario = m.Registro_de_Roles_Usuario_que_Registra.GetValueOrDefault(), Nombre = m.Registro_de_Roles_Usuario_que_Registra_Nombre }
                    ,Fecha_de_Registro = m.Registro_de_Roles_Fecha_de_Registro
                    ,Hora_de_Registro = m.Registro_de_Roles_Hora_de_Registro
                    ,Nombre = m.Registro_de_Roles_Nombre
                    ,Clave_de_Acceso = m.Registro_de_Roles_Clave_de_Acceso
                    ,Contrasena = m.Registro_de_Roles_Contrasena
                    ,Correo = m.Registro_de_Roles_Correo
                    ,Rol = m.Registro_de_Roles_Rol
                    ,Rol_Rol_de_Usuario = new Core.Classes.Rol_de_Usuario.Rol_de_Usuario() { Clave = m.Registro_de_Roles_Rol.GetValueOrDefault(), Descripcion = m.Registro_de_Roles_Rol_Descripcion }
                    ,Usuario_de_Sistema = m.Registro_de_Roles_Usuario_de_Sistema
                    ,Usuario_de_Sistema_TTUsuarios = new Core.Classes.TTUsuarios.TTUsuarios() { IdUsuario = m.Registro_de_Roles_Usuario_de_Sistema.GetValueOrDefault(), Nombre = m.Registro_de_Roles_Usuario_de_Sistema_Nombre }
                    ,Observatorios = m.Registro_de_Roles_Observatorios

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Registro_de_Roles.Registro_de_Roles> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Registro_de_RolesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Registro_de_Roles.Registro_de_Roles GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Registro_de_Roles.Registro_de_Roles>("sp_GetRegistro_de_Roles", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelRegistro_de_Roles>("sp_DelRegistro_de_Roles", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Registro_de_Roles.Registro_de_Roles entity)
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
                var padreClave_de_Acceso = _dataProvider.GetParameter();
                padreClave_de_Acceso.ParameterName = "Clave_de_Acceso";
                padreClave_de_Acceso.DbType = DbType.String;
                padreClave_de_Acceso.Value = (object)entity.Clave_de_Acceso ?? DBNull.Value;
                var padreContrasena = _dataProvider.GetParameter();
                padreContrasena.ParameterName = "Contrasena";
                padreContrasena.DbType = DbType.String;
                padreContrasena.Value = (object)entity.Contrasena ?? DBNull.Value;
                var padreCorreo = _dataProvider.GetParameter();
                padreCorreo.ParameterName = "Correo";
                padreCorreo.DbType = DbType.String;
                padreCorreo.Value = (object)entity.Correo ?? DBNull.Value;
                var padreRol = _dataProvider.GetParameter();
                padreRol.ParameterName = "Rol";
                padreRol.DbType = DbType.Int32;
                padreRol.Value = (object)entity.Rol ?? DBNull.Value;

                var padreUsuario_de_Sistema = _dataProvider.GetParameter();
                padreUsuario_de_Sistema.ParameterName = "Usuario_de_Sistema";
                padreUsuario_de_Sistema.DbType = DbType.Int32;
                padreUsuario_de_Sistema.Value = (object)entity.Usuario_de_Sistema ?? DBNull.Value;

                var padreObservatorios = _dataProvider.GetParameter();
                padreObservatorios.ParameterName = "Observatorios";
                padreObservatorios.DbType = DbType.String;
                padreObservatorios.Value = (object)entity.Observatorios ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsRegistro_de_Roles>("sp_InsRegistro_de_Roles" , padreUsuario_que_Registra
, padreFecha_de_Registro
, padreHora_de_Registro
, padreNombre
, padreClave_de_Acceso
, padreContrasena
, padreCorreo
, padreRol
, padreUsuario_de_Sistema
, padreObservatorios
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

        public int Update(Spartane.Core.Classes.Registro_de_Roles.Registro_de_Roles entity)
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
                var paramUpdClave_de_Acceso = _dataProvider.GetParameter();
                paramUpdClave_de_Acceso.ParameterName = "Clave_de_Acceso";
                paramUpdClave_de_Acceso.DbType = DbType.String;
                paramUpdClave_de_Acceso.Value = (object)entity.Clave_de_Acceso ?? DBNull.Value;
                var paramUpdContrasena = _dataProvider.GetParameter();
                paramUpdContrasena.ParameterName = "Contrasena";
                paramUpdContrasena.DbType = DbType.String;
                paramUpdContrasena.Value = (object)entity.Contrasena ?? DBNull.Value;
                var paramUpdCorreo = _dataProvider.GetParameter();
                paramUpdCorreo.ParameterName = "Correo";
                paramUpdCorreo.DbType = DbType.String;
                paramUpdCorreo.Value = (object)entity.Correo ?? DBNull.Value;
                var paramUpdRol = _dataProvider.GetParameter();
                paramUpdRol.ParameterName = "Rol";
                paramUpdRol.DbType = DbType.Int32;
                paramUpdRol.Value = (object)entity.Rol ?? DBNull.Value;

                var paramUpdUsuario_de_Sistema = _dataProvider.GetParameter();
                paramUpdUsuario_de_Sistema.ParameterName = "Usuario_de_Sistema";
                paramUpdUsuario_de_Sistema.DbType = DbType.Int32;
                paramUpdUsuario_de_Sistema.Value = (object)entity.Usuario_de_Sistema ?? DBNull.Value;

                var paramUpdObservatorios = _dataProvider.GetParameter();
                paramUpdObservatorios.ParameterName = "Observatorios";
                paramUpdObservatorios.DbType = DbType.String;
                paramUpdObservatorios.Value = (object)entity.Observatorios ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdRegistro_de_Roles>("sp_UpdRegistro_de_Roles" , paramUpdFolio , paramUpdUsuario_que_Registra , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdNombre , paramUpdClave_de_Acceso , paramUpdContrasena , paramUpdCorreo , paramUpdRol , paramUpdUsuario_de_Sistema , paramUpdObservatorios ).FirstOrDefault();

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
