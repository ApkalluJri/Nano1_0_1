using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_de_Notificacion_por_Observatorio;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_de_Notificacion_por_Observatorio
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_de_Notificacion_por_ObservatorioService : IDetalle_de_Notificacion_por_ObservatorioService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_de_Notificacion_por_Observatorio.Detalle_de_Notificacion_por_Observatorio> _Detalle_de_Notificacion_por_ObservatorioRepository;
        #endregion

        #region Ctor
        public Detalle_de_Notificacion_por_ObservatorioService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_de_Notificacion_por_Observatorio.Detalle_de_Notificacion_por_Observatorio> Detalle_de_Notificacion_por_ObservatorioRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_de_Notificacion_por_ObservatorioRepository = Detalle_de_Notificacion_por_ObservatorioRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_de_Notificacion_por_ObservatorioRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_de_Notificacion_por_Observatorio.Detalle_de_Notificacion_por_Observatorio> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_de_Notificacion_por_Observatorio.Detalle_de_Notificacion_por_Observatorio>("sp_SelAllDetalle_de_Notificacion_por_Observatorio");
        }

        public IList<Core.Classes.Detalle_de_Notificacion_por_Observatorio.Detalle_de_Notificacion_por_Observatorio> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_de_Notificacion_por_Observatorio_Complete>("sp_SelAllComplete_Detalle_de_Notificacion_por_Observatorio");
            return data.Select(m => new Core.Classes.Detalle_de_Notificacion_por_Observatorio.Detalle_de_Notificacion_por_Observatorio
            {
                Clave = m.Clave
                ,Contenido = m.Contenido
                ,Notificar = m.Notificar.GetValueOrDefault()
                ,Observatorio_Observatorio = new Core.Classes.Observatorio.Observatorio() { Clave = m.Observatorio.GetValueOrDefault(), Nombre = m.Observatorio_Nombre }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_de_Notificacion_por_Observatorio>("sp_ListSelCount_Detalle_de_Notificacion_por_Observatorio", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_de_Notificacion_por_Observatorio.Detalle_de_Notificacion_por_Observatorio> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_de_Notificacion_por_Observatorio>("sp_ListSelAll_Detalle_de_Notificacion_por_Observatorio", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_de_Notificacion_por_Observatorio.Detalle_de_Notificacion_por_Observatorio
                {
                    Clave = m.Detalle_de_Notificacion_por_Observatorio_Clave,
                    Contenido = m.Detalle_de_Notificacion_por_Observatorio_Contenido,
                    Notificar = m.Detalle_de_Notificacion_por_Observatorio_Notificar ?? false,
                    Observatorio = m.Detalle_de_Notificacion_por_Observatorio_Observatorio,

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

        public IList<Spartane.Core.Classes.Detalle_de_Notificacion_por_Observatorio.Detalle_de_Notificacion_por_Observatorio> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_de_Notificacion_por_ObservatorioRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_de_Notificacion_por_Observatorio.Detalle_de_Notificacion_por_Observatorio> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_de_Notificacion_por_ObservatorioRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_de_Notificacion_por_Observatorio.Detalle_de_Notificacion_por_ObservatorioPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_de_Notificacion_por_Observatorio>("sp_ListSelAll_Detalle_de_Notificacion_por_Observatorio", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_de_Notificacion_por_ObservatorioPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_de_Notificacion_por_ObservatorioPagingModel
                {
                    Detalle_de_Notificacion_por_Observatorios =
                        data.Select(m => new Spartane.Core.Classes.Detalle_de_Notificacion_por_Observatorio.Detalle_de_Notificacion_por_Observatorio
                {
                    Clave = m.Detalle_de_Notificacion_por_Observatorio_Clave
                    ,Contenido = m.Detalle_de_Notificacion_por_Observatorio_Contenido
                    ,Notificar = m.Detalle_de_Notificacion_por_Observatorio_Notificar ?? false
                    ,Observatorio = m.Detalle_de_Notificacion_por_Observatorio_Observatorio
                    ,Observatorio_Observatorio = new Core.Classes.Observatorio.Observatorio() { Clave = m.Detalle_de_Notificacion_por_Observatorio_Observatorio.GetValueOrDefault(), Nombre = m.Detalle_de_Notificacion_por_Observatorio_Observatorio_Nombre }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_de_Notificacion_por_Observatorio.Detalle_de_Notificacion_por_Observatorio> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_de_Notificacion_por_ObservatorioRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_de_Notificacion_por_Observatorio.Detalle_de_Notificacion_por_Observatorio GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_de_Notificacion_por_Observatorio.Detalle_de_Notificacion_por_Observatorio>("sp_GetDetalle_de_Notificacion_por_Observatorio", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_de_Notificacion_por_Observatorio>("sp_DelDetalle_de_Notificacion_por_Observatorio", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_de_Notificacion_por_Observatorio.Detalle_de_Notificacion_por_Observatorio entity)
        {
            int rta;
            try
            {

		                var padreContenido = _dataProvider.GetParameter();
                padreContenido.ParameterName = "Contenido";
                padreContenido.DbType = DbType.Int32;
                padreContenido.Value = (object)entity.Contenido ?? DBNull.Value;
                var padreNotificar = _dataProvider.GetParameter();
                padreNotificar.ParameterName = "Notificar";
                padreNotificar.DbType = DbType.Boolean;
                padreNotificar.Value = (object)entity.Notificar ?? DBNull.Value;
                var padreObservatorio = _dataProvider.GetParameter();
                padreObservatorio.ParameterName = "Observatorio";
                padreObservatorio.DbType = DbType.Int32;
                padreObservatorio.Value = (object)entity.Observatorio ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_de_Notificacion_por_Observatorio>("sp_InsDetalle_de_Notificacion_por_Observatorio" , padreContenido
, padreNotificar
, padreObservatorio
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

        public int Update(Spartane.Core.Classes.Detalle_de_Notificacion_por_Observatorio.Detalle_de_Notificacion_por_Observatorio entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdContenido = _dataProvider.GetParameter();
                paramUpdContenido.ParameterName = "Contenido";
                paramUpdContenido.DbType = DbType.Int32;
                paramUpdContenido.Value = (object)entity.Contenido ?? DBNull.Value;
                var paramUpdNotificar = _dataProvider.GetParameter();
                paramUpdNotificar.ParameterName = "Notificar";
                paramUpdNotificar.DbType = DbType.Boolean;
                paramUpdNotificar.Value = (object)entity.Notificar ?? DBNull.Value;
                var paramUpdObservatorio = _dataProvider.GetParameter();
                paramUpdObservatorio.ParameterName = "Observatorio";
                paramUpdObservatorio.DbType = DbType.Int32;
                paramUpdObservatorio.Value = (object)entity.Observatorio ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_de_Notificacion_por_Observatorio>("sp_UpdDetalle_de_Notificacion_por_Observatorio" , paramUpdClave , paramUpdContenido , paramUpdNotificar , paramUpdObservatorio ).FirstOrDefault();

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
