using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.SubCategoria;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.SubCategoria
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class SubCategoriaService : ISubCategoriaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.SubCategoria.SubCategoria> _SubCategoriaRepository;
        #endregion

        #region Ctor
        public SubCategoriaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.SubCategoria.SubCategoria> SubCategoriaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._SubCategoriaRepository = SubCategoriaRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._SubCategoriaRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.SubCategoria.SubCategoria> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.SubCategoria.SubCategoria>("sp_SelAllSubCategoria");
        }

        public IList<Core.Classes.SubCategoria.SubCategoria> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSubCategoria_Complete>("sp_SelAllComplete_SubCategoria");
            return data.Select(m => new Core.Classes.SubCategoria.SubCategoria
            {
                Clave = m.Clave
                ,Descripcion = m.Descripcion
                ,Categoria_Categoria = new Core.Classes.Categoria.Categoria() { Clave = m.Categoria.GetValueOrDefault(), Descripcion = m.Categoria_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_SubCategoria>("sp_ListSelCount_SubCategoria", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.SubCategoria.SubCategoria> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSubCategoria>("sp_ListSelAll_SubCategoria", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.SubCategoria.SubCategoria
                {
                    Clave = m.SubCategoria_Clave,
                    Descripcion = m.SubCategoria_Descripcion,
                    Categoria = m.SubCategoria_Categoria,

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

        public IList<Spartane.Core.Classes.SubCategoria.SubCategoria> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._SubCategoriaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.SubCategoria.SubCategoria> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._SubCategoriaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.SubCategoria.SubCategoriaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSubCategoria>("sp_ListSelAll_SubCategoria", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            SubCategoriaPagingModel result = null;

            if (data != null)
            {
                result = new SubCategoriaPagingModel
                {
                    SubCategorias =
                        data.Select(m => new Spartane.Core.Classes.SubCategoria.SubCategoria
                {
                    Clave = m.SubCategoria_Clave
                    ,Descripcion = m.SubCategoria_Descripcion
                    ,Categoria = m.SubCategoria_Categoria
                    ,Categoria_Categoria = new Core.Classes.Categoria.Categoria() { Clave = m.SubCategoria_Categoria.GetValueOrDefault(), Descripcion = m.SubCategoria_Categoria_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.SubCategoria.SubCategoria> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._SubCategoriaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.SubCategoria.SubCategoria GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.SubCategoria.SubCategoria>("sp_GetSubCategoria", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSubCategoria>("sp_DelSubCategoria", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.SubCategoria.SubCategoria entity)
        {
            int rta;
            try
            {

		                var padreDescripcion = _dataProvider.GetParameter();
                padreDescripcion.ParameterName = "Descripcion";
                padreDescripcion.DbType = DbType.String;
                padreDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var padreCategoria = _dataProvider.GetParameter();
                padreCategoria.ParameterName = "Categoria";
                padreCategoria.DbType = DbType.Int32;
                padreCategoria.Value = (object)entity.Categoria ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSubCategoria>("sp_InsSubCategoria" , padreDescripcion
, padreCategoria
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

        public int Update(Spartane.Core.Classes.SubCategoria.SubCategoria entity)
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
                var paramUpdCategoria = _dataProvider.GetParameter();
                paramUpdCategoria.ParameterName = "Categoria";
                paramUpdCategoria.DbType = DbType.Int32;
                paramUpdCategoria.Value = (object)entity.Categoria ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSubCategoria>("sp_UpdSubCategoria" , paramUpdClave , paramUpdDescripcion , paramUpdCategoria ).FirstOrDefault();

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
