using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_de_Etiquetas_Contenido;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_de_Etiquetas_Contenido
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_de_Etiquetas_ContenidoService : IDetalle_de_Etiquetas_ContenidoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_de_Etiquetas_Contenido.Detalle_de_Etiquetas_Contenido> _Detalle_de_Etiquetas_ContenidoRepository;
        #endregion

        #region Ctor
        public Detalle_de_Etiquetas_ContenidoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_de_Etiquetas_Contenido.Detalle_de_Etiquetas_Contenido> Detalle_de_Etiquetas_ContenidoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_de_Etiquetas_ContenidoRepository = Detalle_de_Etiquetas_ContenidoRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_de_Etiquetas_ContenidoRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_de_Etiquetas_Contenido.Detalle_de_Etiquetas_Contenido> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_de_Etiquetas_Contenido.Detalle_de_Etiquetas_Contenido>("sp_SelAllDetalle_de_Etiquetas_Contenido");
        }

        public IList<Core.Classes.Detalle_de_Etiquetas_Contenido.Detalle_de_Etiquetas_Contenido> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_de_Etiquetas_Contenido_Complete>("sp_SelAllComplete_Detalle_de_Etiquetas_Contenido");
            return data.Select(m => new Core.Classes.Detalle_de_Etiquetas_Contenido.Detalle_de_Etiquetas_Contenido
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_de_Etiquetas_Contenido>("sp_ListSelCount_Detalle_de_Etiquetas_Contenido", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_de_Etiquetas_Contenido.Detalle_de_Etiquetas_Contenido> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_de_Etiquetas_Contenido>("sp_ListSelAll_Detalle_de_Etiquetas_Contenido", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_de_Etiquetas_Contenido.Detalle_de_Etiquetas_Contenido
                {
                    Clave = m.Detalle_de_Etiquetas_Contenido_Clave,
                    Descripcion = m.Detalle_de_Etiquetas_Contenido_Descripcion,

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

        public IList<Spartane.Core.Classes.Detalle_de_Etiquetas_Contenido.Detalle_de_Etiquetas_Contenido> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_de_Etiquetas_ContenidoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_de_Etiquetas_Contenido.Detalle_de_Etiquetas_Contenido> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_de_Etiquetas_ContenidoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_de_Etiquetas_Contenido.Detalle_de_Etiquetas_ContenidoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_de_Etiquetas_Contenido>("sp_ListSelAll_Detalle_de_Etiquetas_Contenido", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_de_Etiquetas_ContenidoPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_de_Etiquetas_ContenidoPagingModel
                {
                    Detalle_de_Etiquetas_Contenidos =
                        data.Select(m => new Spartane.Core.Classes.Detalle_de_Etiquetas_Contenido.Detalle_de_Etiquetas_Contenido
                {
                    Clave = m.Detalle_de_Etiquetas_Contenido_Clave
                    ,Descripcion = m.Detalle_de_Etiquetas_Contenido_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_de_Etiquetas_Contenido.Detalle_de_Etiquetas_Contenido> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_de_Etiquetas_ContenidoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_de_Etiquetas_Contenido.Detalle_de_Etiquetas_Contenido GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_de_Etiquetas_Contenido.Detalle_de_Etiquetas_Contenido>("sp_GetDetalle_de_Etiquetas_Contenido", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_de_Etiquetas_Contenido>("sp_DelDetalle_de_Etiquetas_Contenido", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_de_Etiquetas_Contenido.Detalle_de_Etiquetas_Contenido entity)
        {
            int rta;
            try
            {

		                var padreDescripcion = _dataProvider.GetParameter();
                padreDescripcion.ParameterName = "Descripcion";
                padreDescripcion.DbType = DbType.String;
                padreDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_de_Etiquetas_Contenido>("sp_InsDetalle_de_Etiquetas_Contenido" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Detalle_de_Etiquetas_Contenido.Detalle_de_Etiquetas_Contenido entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_de_Etiquetas_Contenido>("sp_UpdDetalle_de_Etiquetas_Contenido" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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
