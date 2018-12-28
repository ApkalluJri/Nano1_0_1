using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Estatus_de_Solicitud_Via_App;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Estatus_de_Solicitud_Via_App
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Estatus_de_Solicitud_Via_AppService : IEstatus_de_Solicitud_Via_AppService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Estatus_de_Solicitud_Via_App.Estatus_de_Solicitud_Via_App> _Estatus_de_Solicitud_Via_AppRepository;
        #endregion

        #region Ctor
        public Estatus_de_Solicitud_Via_AppService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Estatus_de_Solicitud_Via_App.Estatus_de_Solicitud_Via_App> Estatus_de_Solicitud_Via_AppRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Estatus_de_Solicitud_Via_AppRepository = Estatus_de_Solicitud_Via_AppRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Estatus_de_Solicitud_Via_AppRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Estatus_de_Solicitud_Via_App.Estatus_de_Solicitud_Via_App> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Estatus_de_Solicitud_Via_App.Estatus_de_Solicitud_Via_App>("sp_SelAllEstatus_de_Solicitud_Via_App");
        }

        public IList<Core.Classes.Estatus_de_Solicitud_Via_App.Estatus_de_Solicitud_Via_App> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallEstatus_de_Solicitud_Via_App_Complete>("sp_SelAllComplete_Estatus_de_Solicitud_Via_App");
            return data.Select(m => new Core.Classes.Estatus_de_Solicitud_Via_App.Estatus_de_Solicitud_Via_App
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Estatus_de_Solicitud_Via_App>("sp_ListSelCount_Estatus_de_Solicitud_Via_App", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Estatus_de_Solicitud_Via_App.Estatus_de_Solicitud_Via_App> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEstatus_de_Solicitud_Via_App>("sp_ListSelAll_Estatus_de_Solicitud_Via_App", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Estatus_de_Solicitud_Via_App.Estatus_de_Solicitud_Via_App
                {
                    Clave = m.Estatus_de_Solicitud_Via_App_Clave,
                    Descripcion = m.Estatus_de_Solicitud_Via_App_Descripcion,

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

        public IList<Spartane.Core.Classes.Estatus_de_Solicitud_Via_App.Estatus_de_Solicitud_Via_App> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Estatus_de_Solicitud_Via_AppRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Estatus_de_Solicitud_Via_App.Estatus_de_Solicitud_Via_App> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estatus_de_Solicitud_Via_AppRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Estatus_de_Solicitud_Via_App.Estatus_de_Solicitud_Via_AppPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEstatus_de_Solicitud_Via_App>("sp_ListSelAll_Estatus_de_Solicitud_Via_App", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Estatus_de_Solicitud_Via_AppPagingModel result = null;

            if (data != null)
            {
                result = new Estatus_de_Solicitud_Via_AppPagingModel
                {
                    Estatus_de_Solicitud_Via_Apps =
                        data.Select(m => new Spartane.Core.Classes.Estatus_de_Solicitud_Via_App.Estatus_de_Solicitud_Via_App
                {
                    Clave = m.Estatus_de_Solicitud_Via_App_Clave
                    ,Descripcion = m.Estatus_de_Solicitud_Via_App_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Estatus_de_Solicitud_Via_App.Estatus_de_Solicitud_Via_App> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Estatus_de_Solicitud_Via_AppRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Estatus_de_Solicitud_Via_App.Estatus_de_Solicitud_Via_App GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Estatus_de_Solicitud_Via_App.Estatus_de_Solicitud_Via_App>("sp_GetEstatus_de_Solicitud_Via_App", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelEstatus_de_Solicitud_Via_App>("sp_DelEstatus_de_Solicitud_Via_App", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Estatus_de_Solicitud_Via_App.Estatus_de_Solicitud_Via_App entity)
        {
            int rta;
            try
            {

		                var padreDescripcion = _dataProvider.GetParameter();
                padreDescripcion.ParameterName = "Descripcion";
                padreDescripcion.DbType = DbType.String;
                padreDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsEstatus_de_Solicitud_Via_App>("sp_InsEstatus_de_Solicitud_Via_App" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Estatus_de_Solicitud_Via_App.Estatus_de_Solicitud_Via_App entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEstatus_de_Solicitud_Via_App>("sp_UpdEstatus_de_Solicitud_Via_App" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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
