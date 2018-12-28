using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Tipo_de_Dispositivo;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Tipo_de_Dispositivo
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Tipo_de_DispositivoService : ITipo_de_DispositivoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Tipo_de_Dispositivo.Tipo_de_Dispositivo> _Tipo_de_DispositivoRepository;
        #endregion

        #region Ctor
        public Tipo_de_DispositivoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Tipo_de_Dispositivo.Tipo_de_Dispositivo> Tipo_de_DispositivoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Tipo_de_DispositivoRepository = Tipo_de_DispositivoRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Tipo_de_DispositivoRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Tipo_de_Dispositivo.Tipo_de_Dispositivo> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Tipo_de_Dispositivo.Tipo_de_Dispositivo>("sp_SelAllTipo_de_Dispositivo");
        }

        public IList<Core.Classes.Tipo_de_Dispositivo.Tipo_de_Dispositivo> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallTipo_de_Dispositivo_Complete>("sp_SelAllComplete_Tipo_de_Dispositivo");
            return data.Select(m => new Core.Classes.Tipo_de_Dispositivo.Tipo_de_Dispositivo
            {
                Clave = m.Clave
                ,Tipo = m.Tipo


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Tipo_de_Dispositivo>("sp_ListSelCount_Tipo_de_Dispositivo", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Tipo_de_Dispositivo.Tipo_de_Dispositivo> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTipo_de_Dispositivo>("sp_ListSelAll_Tipo_de_Dispositivo", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Tipo_de_Dispositivo.Tipo_de_Dispositivo
                {
                    Clave = m.Tipo_de_Dispositivo_Clave,
                    Tipo = m.Tipo_de_Dispositivo_Tipo,

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

        public IList<Spartane.Core.Classes.Tipo_de_Dispositivo.Tipo_de_Dispositivo> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Tipo_de_DispositivoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Tipo_de_Dispositivo.Tipo_de_Dispositivo> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Tipo_de_DispositivoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Tipo_de_Dispositivo.Tipo_de_DispositivoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTipo_de_Dispositivo>("sp_ListSelAll_Tipo_de_Dispositivo", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Tipo_de_DispositivoPagingModel result = null;

            if (data != null)
            {
                result = new Tipo_de_DispositivoPagingModel
                {
                    Tipo_de_Dispositivos =
                        data.Select(m => new Spartane.Core.Classes.Tipo_de_Dispositivo.Tipo_de_Dispositivo
                {
                    Clave = m.Tipo_de_Dispositivo_Clave
                    ,Tipo = m.Tipo_de_Dispositivo_Tipo

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Tipo_de_Dispositivo.Tipo_de_Dispositivo> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Tipo_de_DispositivoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Tipo_de_Dispositivo.Tipo_de_Dispositivo GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Tipo_de_Dispositivo.Tipo_de_Dispositivo>("sp_GetTipo_de_Dispositivo", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelTipo_de_Dispositivo>("sp_DelTipo_de_Dispositivo", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Tipo_de_Dispositivo.Tipo_de_Dispositivo entity)
        {
            int rta;
            try
            {

		                var padreTipo = _dataProvider.GetParameter();
                padreTipo.ParameterName = "Tipo";
                padreTipo.DbType = DbType.String;
                padreTipo.Value = (object)entity.Tipo ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsTipo_de_Dispositivo>("sp_InsTipo_de_Dispositivo" , padreTipo
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

        public int Update(Spartane.Core.Classes.Tipo_de_Dispositivo.Tipo_de_Dispositivo entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdTipo = _dataProvider.GetParameter();
                paramUpdTipo.ParameterName = "Tipo";
                paramUpdTipo.DbType = DbType.String;
                paramUpdTipo.Value = (object)entity.Tipo ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdTipo_de_Dispositivo>("sp_UpdTipo_de_Dispositivo" , paramUpdClave , paramUpdTipo ).FirstOrDefault();

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
