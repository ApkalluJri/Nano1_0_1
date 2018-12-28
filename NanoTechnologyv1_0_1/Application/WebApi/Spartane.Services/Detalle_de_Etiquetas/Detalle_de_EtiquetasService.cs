using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_de_Etiquetas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_de_Etiquetas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_de_EtiquetasService : IDetalle_de_EtiquetasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_de_Etiquetas.Detalle_de_Etiquetas> _Detalle_de_EtiquetasRepository;
        #endregion

        #region Ctor
        public Detalle_de_EtiquetasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_de_Etiquetas.Detalle_de_Etiquetas> Detalle_de_EtiquetasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_de_EtiquetasRepository = Detalle_de_EtiquetasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_de_EtiquetasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_de_Etiquetas.Detalle_de_Etiquetas> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_de_Etiquetas.Detalle_de_Etiquetas>("sp_SelAllDetalle_de_Etiquetas");
        }

        public IList<Core.Classes.Detalle_de_Etiquetas.Detalle_de_Etiquetas> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_de_Etiquetas_Complete>("sp_SelAllComplete_Detalle_de_Etiquetas");
            return data.Select(m => new Core.Classes.Detalle_de_Etiquetas.Detalle_de_Etiquetas
            {
                Clave = m.Clave
                ,Articulo = m.Articulo
                ,Etiqueta_Etiquetas = new Core.Classes.Etiquetas.Etiquetas() { Clave = m.Etiqueta.GetValueOrDefault(), Descripcion = m.Etiqueta_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_de_Etiquetas>("sp_ListSelCount_Detalle_de_Etiquetas", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_de_Etiquetas.Detalle_de_Etiquetas> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_de_Etiquetas>("sp_ListSelAll_Detalle_de_Etiquetas", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_de_Etiquetas.Detalle_de_Etiquetas
                {
                    Clave = m.Detalle_de_Etiquetas_Clave,
                    Articulo = m.Detalle_de_Etiquetas_Articulo,
                    Etiqueta = m.Detalle_de_Etiquetas_Etiqueta,

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

        public IList<Spartane.Core.Classes.Detalle_de_Etiquetas.Detalle_de_Etiquetas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_de_EtiquetasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_de_Etiquetas.Detalle_de_Etiquetas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_de_EtiquetasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_de_Etiquetas.Detalle_de_EtiquetasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_de_Etiquetas>("sp_ListSelAll_Detalle_de_Etiquetas", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_de_EtiquetasPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_de_EtiquetasPagingModel
                {
                    Detalle_de_Etiquetass =
                        data.Select(m => new Spartane.Core.Classes.Detalle_de_Etiquetas.Detalle_de_Etiquetas
                {
                    Clave = m.Detalle_de_Etiquetas_Clave
                    ,Articulo = m.Detalle_de_Etiquetas_Articulo
                    ,Etiqueta = m.Detalle_de_Etiquetas_Etiqueta
                    ,Etiqueta_Etiquetas = new Core.Classes.Etiquetas.Etiquetas() { Clave = m.Detalle_de_Etiquetas_Etiqueta.GetValueOrDefault(), Descripcion = m.Detalle_de_Etiquetas_Etiqueta_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_de_Etiquetas.Detalle_de_Etiquetas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_de_EtiquetasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_de_Etiquetas.Detalle_de_Etiquetas GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_de_Etiquetas.Detalle_de_Etiquetas>("sp_GetDetalle_de_Etiquetas", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_de_Etiquetas>("sp_DelDetalle_de_Etiquetas", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_de_Etiquetas.Detalle_de_Etiquetas entity)
        {
            int rta;
            try
            {

		                var padreArticulo = _dataProvider.GetParameter();
                padreArticulo.ParameterName = "Articulo";
                padreArticulo.DbType = DbType.Int32;
                padreArticulo.Value = (object)entity.Articulo ?? DBNull.Value;
                var padreEtiqueta = _dataProvider.GetParameter();
                padreEtiqueta.ParameterName = "Etiqueta";
                padreEtiqueta.DbType = DbType.Int32;
                padreEtiqueta.Value = (object)entity.Etiqueta ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_de_Etiquetas>("sp_InsDetalle_de_Etiquetas" , padreArticulo
, padreEtiqueta
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

        public int Update(Spartane.Core.Classes.Detalle_de_Etiquetas.Detalle_de_Etiquetas entity)
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
                var paramUpdEtiqueta = _dataProvider.GetParameter();
                paramUpdEtiqueta.ParameterName = "Etiqueta";
                paramUpdEtiqueta.DbType = DbType.Int32;
                paramUpdEtiqueta.Value = (object)entity.Etiqueta ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_de_Etiquetas>("sp_UpdDetalle_de_Etiquetas" , paramUpdClave , paramUpdArticulo , paramUpdEtiqueta ).FirstOrDefault();

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
