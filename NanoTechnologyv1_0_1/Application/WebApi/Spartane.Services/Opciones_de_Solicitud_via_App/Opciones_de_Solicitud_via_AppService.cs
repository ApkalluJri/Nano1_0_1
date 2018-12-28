using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Opciones_de_Solicitud_via_App;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Opciones_de_Solicitud_via_App
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Opciones_de_Solicitud_via_AppService : IOpciones_de_Solicitud_via_AppService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Opciones_de_Solicitud_via_App.Opciones_de_Solicitud_via_App> _Opciones_de_Solicitud_via_AppRepository;
        #endregion

        #region Ctor
        public Opciones_de_Solicitud_via_AppService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Opciones_de_Solicitud_via_App.Opciones_de_Solicitud_via_App> Opciones_de_Solicitud_via_AppRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Opciones_de_Solicitud_via_AppRepository = Opciones_de_Solicitud_via_AppRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Opciones_de_Solicitud_via_AppRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Opciones_de_Solicitud_via_App.Opciones_de_Solicitud_via_App> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Opciones_de_Solicitud_via_App.Opciones_de_Solicitud_via_App>("sp_SelAllOpciones_de_Solicitud_via_App");
        }

        public IList<Core.Classes.Opciones_de_Solicitud_via_App.Opciones_de_Solicitud_via_App> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallOpciones_de_Solicitud_via_App_Complete>("sp_SelAllComplete_Opciones_de_Solicitud_via_App");
            return data.Select(m => new Core.Classes.Opciones_de_Solicitud_via_App.Opciones_de_Solicitud_via_App
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Opciones_de_Solicitud_via_App>("sp_ListSelCount_Opciones_de_Solicitud_via_App", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Opciones_de_Solicitud_via_App.Opciones_de_Solicitud_via_App> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllOpciones_de_Solicitud_via_App>("sp_ListSelAll_Opciones_de_Solicitud_via_App", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Opciones_de_Solicitud_via_App.Opciones_de_Solicitud_via_App
                {
                    Clave = m.Opciones_de_Solicitud_via_App_Clave,
                    Descripcion = m.Opciones_de_Solicitud_via_App_Descripcion,

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

        public IList<Spartane.Core.Classes.Opciones_de_Solicitud_via_App.Opciones_de_Solicitud_via_App> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Opciones_de_Solicitud_via_AppRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Opciones_de_Solicitud_via_App.Opciones_de_Solicitud_via_App> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Opciones_de_Solicitud_via_AppRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Opciones_de_Solicitud_via_App.Opciones_de_Solicitud_via_AppPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllOpciones_de_Solicitud_via_App>("sp_ListSelAll_Opciones_de_Solicitud_via_App", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Opciones_de_Solicitud_via_AppPagingModel result = null;

            if (data != null)
            {
                result = new Opciones_de_Solicitud_via_AppPagingModel
                {
                    Opciones_de_Solicitud_via_Apps =
                        data.Select(m => new Spartane.Core.Classes.Opciones_de_Solicitud_via_App.Opciones_de_Solicitud_via_App
                {
                    Clave = m.Opciones_de_Solicitud_via_App_Clave
                    ,Descripcion = m.Opciones_de_Solicitud_via_App_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Opciones_de_Solicitud_via_App.Opciones_de_Solicitud_via_App> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Opciones_de_Solicitud_via_AppRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Opciones_de_Solicitud_via_App.Opciones_de_Solicitud_via_App GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Opciones_de_Solicitud_via_App.Opciones_de_Solicitud_via_App>("sp_GetOpciones_de_Solicitud_via_App", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelOpciones_de_Solicitud_via_App>("sp_DelOpciones_de_Solicitud_via_App", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Opciones_de_Solicitud_via_App.Opciones_de_Solicitud_via_App entity)
        {
            int rta;
            try
            {

		                var padreDescripcion = _dataProvider.GetParameter();
                padreDescripcion.ParameterName = "Descripcion";
                padreDescripcion.DbType = DbType.String;
                padreDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsOpciones_de_Solicitud_via_App>("sp_InsOpciones_de_Solicitud_via_App" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Opciones_de_Solicitud_via_App.Opciones_de_Solicitud_via_App entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdOpciones_de_Solicitud_via_App>("sp_UpdOpciones_de_Solicitud_via_App" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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
