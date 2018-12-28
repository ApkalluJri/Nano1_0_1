using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Registro_de_Usuario;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Registro_de_Usuario
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Registro_de_UsuarioService : IRegistro_de_UsuarioService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Registro_de_Usuario.Registro_de_Usuario> _Registro_de_UsuarioRepository;
        #endregion

        #region Ctor
        public Registro_de_UsuarioService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Registro_de_Usuario.Registro_de_Usuario> Registro_de_UsuarioRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Registro_de_UsuarioRepository = Registro_de_UsuarioRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Registro_de_UsuarioRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Registro_de_Usuario.Registro_de_Usuario> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Registro_de_Usuario.Registro_de_Usuario>("sp_SelAllRegistro_de_Usuario");
        }

        public IList<Core.Classes.Registro_de_Usuario.Registro_de_Usuario> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallRegistro_de_Usuario_Complete>("sp_SelAllComplete_Registro_de_Usuario");
            return data.Select(m => new Core.Classes.Registro_de_Usuario.Registro_de_Usuario
            {
                Folio = m.Folio
                ,Usuario_que_Registra_TTUsuarios = new Core.Classes.TTUsuarios.TTUsuarios() { IdUsuario = m.Usuario_que_Registra.GetValueOrDefault(), Nombre = m.Usuario_que_Registra_Nombre }
                ,Fecha_de_Registro = m.Fecha_de_Registro
                ,Hora_de_Registro = m.Hora_de_Registro
                ,Nombre = m.Nombre
                ,Apellido = m.Apellido
                ,Nombre_Completo = m.Nombre_Completo
                ,Correo = m.Correo
                ,Contrasena = m.Contrasena
                ,Confirmar_Contrasena = m.Confirmar_Contrasena
                ,Acepta_Terminos = m.Acepta_Terminos.GetValueOrDefault()
                ,Foto_de_Perfil_TTArchivos = new Core.Classes.TTArchivos.TTArchivos() { Folio = m.Foto_de_Perfil.GetValueOrDefault(), Nombre = m.Foto_de_Perfil_Nombre }
                ,Usuario_del_Sistema_TTUsuarios = new Core.Classes.TTUsuarios.TTUsuarios() { IdUsuario = m.Usuario_del_Sistema.GetValueOrDefault(), Nombre = m.Usuario_del_Sistema_Nombre }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Registro_de_Usuario>("sp_ListSelCount_Registro_de_Usuario", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Registro_de_Usuario.Registro_de_Usuario> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllRegistro_de_Usuario>("sp_ListSelAll_Registro_de_Usuario", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Registro_de_Usuario.Registro_de_Usuario
                {
                    Folio = m.Registro_de_Usuario_Folio,
                    Usuario_que_Registra = m.Registro_de_Usuario_Usuario_que_Registra,
                    Fecha_de_Registro = m.Registro_de_Usuario_Fecha_de_Registro,
                    Hora_de_Registro = m.Registro_de_Usuario_Hora_de_Registro,
                    Nombre = m.Registro_de_Usuario_Nombre,
                    Apellido = m.Registro_de_Usuario_Apellido,
                    Nombre_Completo = m.Registro_de_Usuario_Nombre_Completo,
                    Correo = m.Registro_de_Usuario_Correo,
                    Contrasena = m.Registro_de_Usuario_Contrasena,
                    Confirmar_Contrasena = m.Registro_de_Usuario_Confirmar_Contrasena,
                    Acepta_Terminos = m.Registro_de_Usuario_Acepta_Terminos ?? false,
                    Foto_de_Perfil = m.Registro_de_Usuario_Foto_de_Perfil,
                    Usuario_del_Sistema = m.Registro_de_Usuario_Usuario_del_Sistema,

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

        public IList<Spartane.Core.Classes.Registro_de_Usuario.Registro_de_Usuario> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Registro_de_UsuarioRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Registro_de_Usuario.Registro_de_Usuario> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Registro_de_UsuarioRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Registro_de_Usuario.Registro_de_UsuarioPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllRegistro_de_Usuario>("sp_ListSelAll_Registro_de_Usuario", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Registro_de_UsuarioPagingModel result = null;

            if (data != null)
            {
                result = new Registro_de_UsuarioPagingModel
                {
                    Registro_de_Usuarios =
                        data.Select(m => new Spartane.Core.Classes.Registro_de_Usuario.Registro_de_Usuario
                {
                    Folio = m.Registro_de_Usuario_Folio
                    ,Usuario_que_Registra = m.Registro_de_Usuario_Usuario_que_Registra
                    ,Usuario_que_Registra_TTUsuarios = new Core.Classes.TTUsuarios.TTUsuarios() { IdUsuario = m.Registro_de_Usuario_Usuario_que_Registra.GetValueOrDefault(), Nombre = m.Registro_de_Usuario_Usuario_que_Registra_Nombre }
                    ,Fecha_de_Registro = m.Registro_de_Usuario_Fecha_de_Registro
                    ,Hora_de_Registro = m.Registro_de_Usuario_Hora_de_Registro
                    ,Nombre = m.Registro_de_Usuario_Nombre
                    ,Apellido = m.Registro_de_Usuario_Apellido
                    ,Nombre_Completo = m.Registro_de_Usuario_Nombre_Completo
                    ,Correo = m.Registro_de_Usuario_Correo
                    ,Contrasena = m.Registro_de_Usuario_Contrasena
                    ,Confirmar_Contrasena = m.Registro_de_Usuario_Confirmar_Contrasena
                    ,Acepta_Terminos = m.Registro_de_Usuario_Acepta_Terminos ?? false
                    ,Foto_de_Perfil = m.Registro_de_Usuario_Foto_de_Perfil
                    ,Foto_de_Perfil_TTArchivos = new Core.Classes.TTArchivos.TTArchivos() { Folio = m.Registro_de_Usuario_Foto_de_Perfil.GetValueOrDefault(), Nombre = m.Registro_de_Usuario_Foto_de_Perfil_Nombre }
                    ,Usuario_del_Sistema = m.Registro_de_Usuario_Usuario_del_Sistema
                    ,Usuario_del_Sistema_TTUsuarios = new Core.Classes.TTUsuarios.TTUsuarios() { IdUsuario = m.Registro_de_Usuario_Usuario_del_Sistema.GetValueOrDefault(), Nombre = m.Registro_de_Usuario_Usuario_del_Sistema_Nombre }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Registro_de_Usuario.Registro_de_Usuario> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Registro_de_UsuarioRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Registro_de_Usuario.Registro_de_Usuario GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Registro_de_Usuario.Registro_de_Usuario>("sp_GetRegistro_de_Usuario", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelRegistro_de_Usuario>("sp_DelRegistro_de_Usuario", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Registro_de_Usuario.Registro_de_Usuario entity)
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
                var padreApellido = _dataProvider.GetParameter();
                padreApellido.ParameterName = "Apellido";
                padreApellido.DbType = DbType.String;
                padreApellido.Value = (object)entity.Apellido ?? DBNull.Value;
                var padreNombre_Completo = _dataProvider.GetParameter();
                padreNombre_Completo.ParameterName = "Nombre_Completo";
                padreNombre_Completo.DbType = DbType.String;
                padreNombre_Completo.Value = (object)entity.Nombre_Completo ?? DBNull.Value;
                var padreCorreo = _dataProvider.GetParameter();
                padreCorreo.ParameterName = "Correo";
                padreCorreo.DbType = DbType.String;
                padreCorreo.Value = (object)entity.Correo ?? DBNull.Value;
                var padreContrasena = _dataProvider.GetParameter();
                padreContrasena.ParameterName = "Contrasena";
                padreContrasena.DbType = DbType.String;
                padreContrasena.Value = (object)entity.Contrasena ?? DBNull.Value;
                var padreConfirmar_Contrasena = _dataProvider.GetParameter();
                padreConfirmar_Contrasena.ParameterName = "Confirmar_Contrasena";
                padreConfirmar_Contrasena.DbType = DbType.String;
                padreConfirmar_Contrasena.Value = (object)entity.Confirmar_Contrasena ?? DBNull.Value;
                var padreAcepta_Terminos = _dataProvider.GetParameter();
                padreAcepta_Terminos.ParameterName = "Acepta_Terminos";
                padreAcepta_Terminos.DbType = DbType.Boolean;
                padreAcepta_Terminos.Value = (object)entity.Acepta_Terminos ?? DBNull.Value;
                var padreFoto_de_Perfil = _dataProvider.GetParameter();
                padreFoto_de_Perfil.ParameterName = "Foto_de_Perfil";
                padreFoto_de_Perfil.DbType = DbType.Int32;
                padreFoto_de_Perfil.Value = (object)entity.Foto_de_Perfil ?? DBNull.Value;

                var padreUsuario_del_Sistema = _dataProvider.GetParameter();
                padreUsuario_del_Sistema.ParameterName = "Usuario_del_Sistema";
                padreUsuario_del_Sistema.DbType = DbType.Int32;
                padreUsuario_del_Sistema.Value = (object)entity.Usuario_del_Sistema ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsRegistro_de_Usuario>("sp_InsRegistro_de_Usuario" , padreUsuario_que_Registra
, padreFecha_de_Registro
, padreHora_de_Registro
, padreNombre
, padreApellido
, padreNombre_Completo
, padreCorreo
, padreContrasena
, padreConfirmar_Contrasena
, padreAcepta_Terminos
, padreFoto_de_Perfil
, padreUsuario_del_Sistema
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

        public int Update(Spartane.Core.Classes.Registro_de_Usuario.Registro_de_Usuario entity)
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
                var paramUpdApellido = _dataProvider.GetParameter();
                paramUpdApellido.ParameterName = "Apellido";
                paramUpdApellido.DbType = DbType.String;
                paramUpdApellido.Value = (object)entity.Apellido ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)entity.Nombre_Completo ?? DBNull.Value;
                var paramUpdCorreo = _dataProvider.GetParameter();
                paramUpdCorreo.ParameterName = "Correo";
                paramUpdCorreo.DbType = DbType.String;
                paramUpdCorreo.Value = (object)entity.Correo ?? DBNull.Value;
                var paramUpdContrasena = _dataProvider.GetParameter();
                paramUpdContrasena.ParameterName = "Contrasena";
                paramUpdContrasena.DbType = DbType.String;
                paramUpdContrasena.Value = (object)entity.Contrasena ?? DBNull.Value;
                var paramUpdConfirmar_Contrasena = _dataProvider.GetParameter();
                paramUpdConfirmar_Contrasena.ParameterName = "Confirmar_Contrasena";
                paramUpdConfirmar_Contrasena.DbType = DbType.String;
                paramUpdConfirmar_Contrasena.Value = (object)entity.Confirmar_Contrasena ?? DBNull.Value;
                var paramUpdAcepta_Terminos = _dataProvider.GetParameter();
                paramUpdAcepta_Terminos.ParameterName = "Acepta_Terminos";
                paramUpdAcepta_Terminos.DbType = DbType.Boolean;
                paramUpdAcepta_Terminos.Value = (object)entity.Acepta_Terminos ?? DBNull.Value;
                var paramUpdFoto_de_Perfil = _dataProvider.GetParameter();
                paramUpdFoto_de_Perfil.ParameterName = "Foto_de_Perfil";
                paramUpdFoto_de_Perfil.DbType = DbType.Int32;
                paramUpdFoto_de_Perfil.Value = (object)entity.Foto_de_Perfil ?? DBNull.Value;

                var paramUpdUsuario_del_Sistema = _dataProvider.GetParameter();
                paramUpdUsuario_del_Sistema.ParameterName = "Usuario_del_Sistema";
                paramUpdUsuario_del_Sistema.DbType = DbType.Int32;
                paramUpdUsuario_del_Sistema.Value = (object)entity.Usuario_del_Sistema ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdRegistro_de_Usuario>("sp_UpdRegistro_de_Usuario" , paramUpdFolio , paramUpdUsuario_que_Registra , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdNombre , paramUpdApellido , paramUpdNombre_Completo , paramUpdCorreo , paramUpdContrasena , paramUpdConfirmar_Contrasena , paramUpdAcepta_Terminos , paramUpdFoto_de_Perfil , paramUpdUsuario_del_Sistema ).FirstOrDefault();

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
