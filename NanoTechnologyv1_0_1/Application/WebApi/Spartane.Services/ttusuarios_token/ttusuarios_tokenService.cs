using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.ttusuarios_token;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.ttusuarios_token
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class ttusuarios_tokenService : Ittusuarios_tokenService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.ttusuarios_token.ttusuarios_token> _ttusuarios_tokenRepository;
        #endregion

        #region Ctor
        public ttusuarios_tokenService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.ttusuarios_token.ttusuarios_token> ttusuarios_tokenRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._ttusuarios_tokenRepository = ttusuarios_tokenRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._ttusuarios_tokenRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.ttusuarios_token.ttusuarios_token> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.ttusuarios_token.ttusuarios_token>("sp_SelAllttusuarios_token");
        }

        public IList<Core.Classes.ttusuarios_token.ttusuarios_token> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_Selallttusuarios_token_Complete>("sp_SelAllComplete_ttusuarios_token");
            return data.Select(m => new Core.Classes.ttusuarios_token.ttusuarios_token
            {
                Folio = m.Folio
                ,Usuario_Token_Campo = m.Usuario_Token_Campo
                ,Id_Usuario = m.Id_Usuario
                ,Token = m.Token
                ,Identificador = m.Identificador
                ,Estado_Logico = m.Estado_Logico.GetValueOrDefault()
                ,TipoDispositivo = m.TipoDispositivo
                ,Id_Usuario_TTUsuarios_TTUsuarios = new Core.Classes.TTUsuarios.TTUsuarios() { IdUsuario = m.Id_Usuario_TTUsuarios.GetValueOrDefault(), Nombre = m.Id_Usuario_TTUsuarios_Nombre }
                ,Id = m.Id


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_ttusuarios_token>("sp_ListSelCount_ttusuarios_token", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.ttusuarios_token.ttusuarios_token> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllttusuarios_token>("sp_ListSelAll_ttusuarios_token", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.ttusuarios_token.ttusuarios_token
                {
                    Folio = m.ttusuarios_token_Folio,
                    Usuario_Token_Campo = m.ttusuarios_token_Usuario_Token_Campo,
                    Id_Usuario = m.ttusuarios_token_Id_Usuario,
                    Token = m.ttusuarios_token_Token,
                    Identificador = m.ttusuarios_token_Identificador,
                    Estado_Logico = m.ttusuarios_token_Estado_Logico ?? false,
                    TipoDispositivo = m.ttusuarios_token_TipoDispositivo,
                    Id_Usuario_TTUsuarios = m.ttusuarios_token_Id_Usuario_TTUsuarios,
                    Id = m.ttusuarios_token_Id,

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

        public IList<Spartane.Core.Classes.ttusuarios_token.ttusuarios_token> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._ttusuarios_tokenRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.ttusuarios_token.ttusuarios_token> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._ttusuarios_tokenRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.ttusuarios_token.ttusuarios_tokenPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllttusuarios_token>("sp_ListSelAll_ttusuarios_token", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            ttusuarios_tokenPagingModel result = null;

            if (data != null)
            {
                result = new ttusuarios_tokenPagingModel
                {
                    ttusuarios_tokens =
                        data.Select(m => new Spartane.Core.Classes.ttusuarios_token.ttusuarios_token
                {
                    Folio = m.ttusuarios_token_Folio
                    ,Usuario_Token_Campo = m.ttusuarios_token_Usuario_Token_Campo
                    ,Id_Usuario = m.ttusuarios_token_Id_Usuario
                    ,Token = m.ttusuarios_token_Token
                    ,Identificador = m.ttusuarios_token_Identificador
                    ,Estado_Logico = m.ttusuarios_token_Estado_Logico ?? false
                    ,TipoDispositivo = m.ttusuarios_token_TipoDispositivo
                    ,Id_Usuario_TTUsuarios = m.ttusuarios_token_Id_Usuario_TTUsuarios
                    ,Id_Usuario_TTUsuarios_TTUsuarios = new Core.Classes.TTUsuarios.TTUsuarios() { IdUsuario = m.ttusuarios_token_Id_Usuario_TTUsuarios.GetValueOrDefault(), Nombre = m.ttusuarios_token_Id_Usuario_TTUsuarios_Nombre }
                    ,Id = m.ttusuarios_token_Id

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.ttusuarios_token.ttusuarios_token> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._ttusuarios_tokenRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.ttusuarios_token.ttusuarios_token GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.ttusuarios_token.ttusuarios_token>("sp_Getttusuarios_token", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_Delttusuarios_token>("sp_Delttusuarios_token", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.ttusuarios_token.ttusuarios_token entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreUsuario_Token_Campo = _dataProvider.GetParameter();
                padreUsuario_Token_Campo.ParameterName = "Usuario_Token_Campo";
                padreUsuario_Token_Campo.DbType = DbType.Int32;
                padreUsuario_Token_Campo.Value = (object)entity.Usuario_Token_Campo ?? DBNull.Value;

                var padreId_Usuario = _dataProvider.GetParameter();
                padreId_Usuario.ParameterName = "Id_Usuario";
                padreId_Usuario.DbType = DbType.Int32;
                padreId_Usuario.Value = (object)entity.Id_Usuario ?? DBNull.Value;

                var padreToken = _dataProvider.GetParameter();
                padreToken.ParameterName = "Token";
                padreToken.DbType = DbType.String;
                padreToken.Value = (object)entity.Token ?? DBNull.Value;
                var padreIdentificador = _dataProvider.GetParameter();
                padreIdentificador.ParameterName = "Identificador";
                padreIdentificador.DbType = DbType.String;
                padreIdentificador.Value = (object)entity.Identificador ?? DBNull.Value;
                var padreEstado_Logico = _dataProvider.GetParameter();
                padreEstado_Logico.ParameterName = "Estado_Logico";
                padreEstado_Logico.DbType = DbType.Boolean;
                padreEstado_Logico.Value = (object)entity.Estado_Logico ?? DBNull.Value;
                var padreTipoDispositivo = _dataProvider.GetParameter();
                padreTipoDispositivo.ParameterName = "TipoDispositivo";
                padreTipoDispositivo.DbType = DbType.Int32;
                padreTipoDispositivo.Value = (object)entity.TipoDispositivo ?? DBNull.Value;

                var padreId_Usuario_TTUsuarios = _dataProvider.GetParameter();
                padreId_Usuario_TTUsuarios.ParameterName = "Id_Usuario_TTUsuarios";
                padreId_Usuario_TTUsuarios.DbType = DbType.Int32;
                padreId_Usuario_TTUsuarios.Value = (object)entity.Id_Usuario_TTUsuarios ?? DBNull.Value;

                var padreId = _dataProvider.GetParameter();
                padreId.ParameterName = "Id";
                padreId.DbType = DbType.Int32;
                padreId.Value = (object)entity.Id ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_Insttusuarios_token>("sp_Insttusuarios_token" , padreUsuario_Token_Campo
, padreId_Usuario
, padreToken
, padreIdentificador
, padreEstado_Logico
, padreTipoDispositivo
, padreId_Usuario_TTUsuarios
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

        public int Update(Spartane.Core.Classes.ttusuarios_token.ttusuarios_token entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdUsuario_Token_Campo = _dataProvider.GetParameter();
                paramUpdUsuario_Token_Campo.ParameterName = "Usuario_Token_Campo";
                paramUpdUsuario_Token_Campo.DbType = DbType.Int32;
                paramUpdUsuario_Token_Campo.Value = (object)entity.Usuario_Token_Campo ?? DBNull.Value;

                var paramUpdId_Usuario = _dataProvider.GetParameter();
                paramUpdId_Usuario.ParameterName = "Id_Usuario";
                paramUpdId_Usuario.DbType = DbType.Int32;
                paramUpdId_Usuario.Value = (object)entity.Id_Usuario ?? DBNull.Value;

                var paramUpdToken = _dataProvider.GetParameter();
                paramUpdToken.ParameterName = "Token";
                paramUpdToken.DbType = DbType.String;
                paramUpdToken.Value = (object)entity.Token ?? DBNull.Value;
                var paramUpdIdentificador = _dataProvider.GetParameter();
                paramUpdIdentificador.ParameterName = "Identificador";
                paramUpdIdentificador.DbType = DbType.String;
                paramUpdIdentificador.Value = (object)entity.Identificador ?? DBNull.Value;
                var paramUpdEstado_Logico = _dataProvider.GetParameter();
                paramUpdEstado_Logico.ParameterName = "Estado_Logico";
                paramUpdEstado_Logico.DbType = DbType.Boolean;
                paramUpdEstado_Logico.Value = (object)entity.Estado_Logico ?? DBNull.Value;
                var paramUpdTipoDispositivo = _dataProvider.GetParameter();
                paramUpdTipoDispositivo.ParameterName = "TipoDispositivo";
                paramUpdTipoDispositivo.DbType = DbType.Int32;
                paramUpdTipoDispositivo.Value = (object)entity.TipoDispositivo ?? DBNull.Value;

                var paramUpdId_Usuario_TTUsuarios = _dataProvider.GetParameter();
                paramUpdId_Usuario_TTUsuarios.ParameterName = "Id_Usuario_TTUsuarios";
                paramUpdId_Usuario_TTUsuarios.DbType = DbType.Int32;
                paramUpdId_Usuario_TTUsuarios.Value = (object)entity.Id_Usuario_TTUsuarios ?? DBNull.Value;

                var paramUpdId = _dataProvider.GetParameter();
                paramUpdId.ParameterName = "Id";
                paramUpdId.DbType = DbType.Int32;
                paramUpdId.Value = (object)entity.Id ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_Updttusuarios_token>("sp_Updttusuarios_token" , paramUpdFolio , paramUpdUsuario_Token_Campo , paramUpdId_Usuario , paramUpdToken , paramUpdIdentificador , paramUpdEstado_Logico , paramUpdTipoDispositivo , paramUpdId_Usuario_TTUsuarios ).FirstOrDefault();

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
