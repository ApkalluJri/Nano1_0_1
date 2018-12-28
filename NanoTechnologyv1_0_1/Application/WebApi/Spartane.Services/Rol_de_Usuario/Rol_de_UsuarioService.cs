using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Rol_de_Usuario;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Rol_de_Usuario
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Rol_de_UsuarioService : IRol_de_UsuarioService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Rol_de_Usuario.Rol_de_Usuario> _Rol_de_UsuarioRepository;
        #endregion

        #region Ctor
        public Rol_de_UsuarioService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Rol_de_Usuario.Rol_de_Usuario> Rol_de_UsuarioRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Rol_de_UsuarioRepository = Rol_de_UsuarioRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Rol_de_UsuarioRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Rol_de_Usuario.Rol_de_Usuario> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Rol_de_Usuario.Rol_de_Usuario>("sp_SelAllRol_de_Usuario");
        }

        public IList<Core.Classes.Rol_de_Usuario.Rol_de_Usuario> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallRol_de_Usuario_Complete>("sp_SelAllComplete_Rol_de_Usuario");
            return data.Select(m => new Core.Classes.Rol_de_Usuario.Rol_de_Usuario
            {
                Clave = m.Clave
                ,Descripcion = m.Descripcion


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Rol_de_Usuario>("sp_ListSelCount_Rol_de_Usuario", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Rol_de_Usuario.Rol_de_Usuario> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllRol_de_Usuario>("sp_ListSelAll_Rol_de_Usuario", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Rol_de_Usuario.Rol_de_Usuario
                {
                    Clave = m.Rol_de_Usuario_Clave,
                    Descripcion = m.Rol_de_Usuario_Descripcion,

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

        public IList<Spartane.Core.Classes.Rol_de_Usuario.Rol_de_Usuario> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Rol_de_UsuarioRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Rol_de_Usuario.Rol_de_Usuario> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Rol_de_UsuarioRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Rol_de_Usuario.Rol_de_UsuarioPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllRol_de_Usuario>("sp_ListSelAll_Rol_de_Usuario", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Rol_de_UsuarioPagingModel result = null;

            if (data != null)
            {
                result = new Rol_de_UsuarioPagingModel
                {
                    Rol_de_Usuarios =
                        data.Select(m => new Spartane.Core.Classes.Rol_de_Usuario.Rol_de_Usuario
                {
                    Clave = m.Rol_de_Usuario_Clave
                    ,Descripcion = m.Rol_de_Usuario_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Rol_de_Usuario.Rol_de_Usuario> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Rol_de_UsuarioRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Rol_de_Usuario.Rol_de_Usuario GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Rol_de_Usuario.Rol_de_Usuario>("sp_GetRol_de_Usuario", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelRol_de_Usuario>("sp_DelRol_de_Usuario", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Rol_de_Usuario.Rol_de_Usuario entity)
        {
            int rta;
            try
            {

		                var padreClave = _dataProvider.GetParameter();
                padreClave.ParameterName = "Clave";
                padreClave.DbType = DbType.Int32;
                padreClave.Value = entity.Clave;
                var padreDescripcion = _dataProvider.GetParameter();
                padreDescripcion.ParameterName = "Descripcion";
                padreDescripcion.DbType = DbType.String;
                padreDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsRol_de_Usuario>("sp_InsRol_de_Usuario" , padreClave
, padreDescripcion
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

        public int Update(Spartane.Core.Classes.Rol_de_Usuario.Rol_de_Usuario entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdRol_de_Usuario>("sp_UpdRol_de_Usuario" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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
