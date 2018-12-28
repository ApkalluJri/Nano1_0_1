using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Fuentes;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Fuentes
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class FuentesService : IFuentesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Fuentes.Fuentes> _FuentesRepository;
        #endregion

        #region Ctor
        public FuentesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Fuentes.Fuentes> FuentesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._FuentesRepository = FuentesRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._FuentesRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Fuentes.Fuentes> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Fuentes.Fuentes>("sp_SelAllFuentes");
        }

        public IList<Core.Classes.Fuentes.Fuentes> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallFuentes_Complete>("sp_SelAllComplete_Fuentes");
            return data.Select(m => new Core.Classes.Fuentes.Fuentes
            {
                Clave = m.Clave
                ,Articulo = m.Articulo
                ,Fuente = m.Fuente


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Fuentes>("sp_ListSelCount_Fuentes", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Fuentes.Fuentes> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllFuentes>("sp_ListSelAll_Fuentes", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Fuentes.Fuentes
                {
                    Clave = m.Fuentes_Clave,
                    Articulo = m.Fuentes_Articulo,
                    Fuente = m.Fuentes_Fuente,

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

        public IList<Spartane.Core.Classes.Fuentes.Fuentes> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._FuentesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Fuentes.Fuentes> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._FuentesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Fuentes.FuentesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllFuentes>("sp_ListSelAll_Fuentes", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            FuentesPagingModel result = null;

            if (data != null)
            {
                result = new FuentesPagingModel
                {
                    Fuentess =
                        data.Select(m => new Spartane.Core.Classes.Fuentes.Fuentes
                {
                    Clave = m.Fuentes_Clave
                    ,Articulo = m.Fuentes_Articulo
                    ,Fuente = m.Fuentes_Fuente

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Fuentes.Fuentes> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._FuentesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Fuentes.Fuentes GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Fuentes.Fuentes>("sp_GetFuentes", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelFuentes>("sp_DelFuentes", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Fuentes.Fuentes entity)
        {
            int rta;
            try
            {

		                var padreArticulo = _dataProvider.GetParameter();
                padreArticulo.ParameterName = "Articulo";
                padreArticulo.DbType = DbType.Int32;
                padreArticulo.Value = (object)entity.Articulo ?? DBNull.Value;
                var padreFuente = _dataProvider.GetParameter();
                padreFuente.ParameterName = "Fuente";
                padreFuente.DbType = DbType.String;
                padreFuente.Value = (object)entity.Fuente ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsFuentes>("sp_InsFuentes" , padreArticulo
, padreFuente
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

        public int Update(Spartane.Core.Classes.Fuentes.Fuentes entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdArticulo = _dataProvider.GetParameter();
                paramUpdArticulo.ParameterName = "Articulo";
                paramUpdArticulo.DbType = DbType.Int32;
                paramUpdArticulo.Value = (object)entity.Articulo ?? DBNull.Value;
                var paramUpdFuente = _dataProvider.GetParameter();
                paramUpdFuente.ParameterName = "Fuente";
                paramUpdFuente.DbType = DbType.String;
                paramUpdFuente.Value = (object)entity.Fuente ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdFuentes>("sp_UpdFuentes" , paramUpdClave , paramUpdArticulo , paramUpdFuente ).FirstOrDefault();

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
