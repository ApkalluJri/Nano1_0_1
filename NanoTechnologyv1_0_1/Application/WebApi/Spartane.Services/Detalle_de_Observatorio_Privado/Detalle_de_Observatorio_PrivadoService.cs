using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_de_Observatorio_Privado;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_de_Observatorio_Privado
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_de_Observatorio_PrivadoService : IDetalle_de_Observatorio_PrivadoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_de_Observatorio_Privado.Detalle_de_Observatorio_Privado> _Detalle_de_Observatorio_PrivadoRepository;
        #endregion

        #region Ctor
        public Detalle_de_Observatorio_PrivadoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_de_Observatorio_Privado.Detalle_de_Observatorio_Privado> Detalle_de_Observatorio_PrivadoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_de_Observatorio_PrivadoRepository = Detalle_de_Observatorio_PrivadoRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_de_Observatorio_PrivadoRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_de_Observatorio_Privado.Detalle_de_Observatorio_Privado> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_de_Observatorio_Privado.Detalle_de_Observatorio_Privado>("sp_SelAllDetalle_de_Observatorio_Privado");
        }

        public IList<Core.Classes.Detalle_de_Observatorio_Privado.Detalle_de_Observatorio_Privado> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_de_Observatorio_Privado_Complete>("sp_SelAllComplete_Detalle_de_Observatorio_Privado");
            return data.Select(m => new Core.Classes.Detalle_de_Observatorio_Privado.Detalle_de_Observatorio_Privado
            {
                Clave = m.Clave
                ,Observatorio = m.Observatorio
                ,Codigo = m.Codigo
                ,Estatus_Estatus_Codigo = new Core.Classes.Estatus_Codigo.Estatus_Codigo() { Clave = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }
                ,Expiracion = m.Expiracion
                ,Accesos = m.Accesos


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_de_Observatorio_Privado>("sp_ListSelCount_Detalle_de_Observatorio_Privado", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_de_Observatorio_Privado.Detalle_de_Observatorio_Privado> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_de_Observatorio_Privado>("sp_ListSelAll_Detalle_de_Observatorio_Privado", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_de_Observatorio_Privado.Detalle_de_Observatorio_Privado
                {
                    Clave = m.Detalle_de_Observatorio_Privado_Clave,
                    Observatorio = m.Detalle_de_Observatorio_Privado_Observatorio,
                    Codigo = m.Detalle_de_Observatorio_Privado_Codigo,
                    Estatus = m.Detalle_de_Observatorio_Privado_Estatus,
                    Expiracion = m.Detalle_de_Observatorio_Privado_Expiracion,
                    Accesos = m.Detalle_de_Observatorio_Privado_Accesos,

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

        public IList<Spartane.Core.Classes.Detalle_de_Observatorio_Privado.Detalle_de_Observatorio_Privado> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_de_Observatorio_PrivadoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_de_Observatorio_Privado.Detalle_de_Observatorio_Privado> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_de_Observatorio_PrivadoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_de_Observatorio_Privado.Detalle_de_Observatorio_PrivadoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_de_Observatorio_Privado>("sp_ListSelAll_Detalle_de_Observatorio_Privado", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_de_Observatorio_PrivadoPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_de_Observatorio_PrivadoPagingModel
                {
                    Detalle_de_Observatorio_Privados =
                        data.Select(m => new Spartane.Core.Classes.Detalle_de_Observatorio_Privado.Detalle_de_Observatorio_Privado
                {
                    Clave = m.Detalle_de_Observatorio_Privado_Clave
                    ,Observatorio = m.Detalle_de_Observatorio_Privado_Observatorio
                    ,Codigo = m.Detalle_de_Observatorio_Privado_Codigo
                    ,Estatus = m.Detalle_de_Observatorio_Privado_Estatus
                    ,Estatus_Estatus_Codigo = new Core.Classes.Estatus_Codigo.Estatus_Codigo() { Clave = m.Detalle_de_Observatorio_Privado_Estatus.GetValueOrDefault(), Descripcion = m.Detalle_de_Observatorio_Privado_Estatus_Descripcion }
                    ,Expiracion = m.Detalle_de_Observatorio_Privado_Expiracion
                    ,Accesos = m.Detalle_de_Observatorio_Privado_Accesos

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_de_Observatorio_Privado.Detalle_de_Observatorio_Privado> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_de_Observatorio_PrivadoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_de_Observatorio_Privado.Detalle_de_Observatorio_Privado GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_de_Observatorio_Privado.Detalle_de_Observatorio_Privado>("sp_GetDetalle_de_Observatorio_Privado", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_de_Observatorio_Privado>("sp_DelDetalle_de_Observatorio_Privado", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_de_Observatorio_Privado.Detalle_de_Observatorio_Privado entity)
        {
            int rta;
            try
            {

		                var padreObservatorio = _dataProvider.GetParameter();
                padreObservatorio.ParameterName = "Observatorio";
                padreObservatorio.DbType = DbType.Int32;
                padreObservatorio.Value = (object)entity.Observatorio ?? DBNull.Value;
                var padreCodigo = _dataProvider.GetParameter();
                padreCodigo.ParameterName = "Codigo";
                padreCodigo.DbType = DbType.String;
                padreCodigo.Value = (object)entity.Codigo ?? DBNull.Value;
                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

                var padreExpiracion = _dataProvider.GetParameter();
                padreExpiracion.ParameterName = "Expiracion";
                padreExpiracion.DbType = DbType.DateTime;
                padreExpiracion.Value = (object)entity.Expiracion ?? DBNull.Value;

                var padreAccesos = _dataProvider.GetParameter();
                padreAccesos.ParameterName = "Accesos";
                padreAccesos.DbType = DbType.Int32;
                padreAccesos.Value = (object)entity.Accesos ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_de_Observatorio_Privado>("sp_InsDetalle_de_Observatorio_Privado" , padreObservatorio
, padreCodigo
, padreEstatus
, padreExpiracion
, padreAccesos
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

        public int Update(Spartane.Core.Classes.Detalle_de_Observatorio_Privado.Detalle_de_Observatorio_Privado entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdObservatorio = _dataProvider.GetParameter();
                paramUpdObservatorio.ParameterName = "Observatorio";
                paramUpdObservatorio.DbType = DbType.Int32;
                paramUpdObservatorio.Value = (object)entity.Observatorio ?? DBNull.Value;
                var paramUpdCodigo = _dataProvider.GetParameter();
                paramUpdCodigo.ParameterName = "Codigo";
                paramUpdCodigo.DbType = DbType.String;
                paramUpdCodigo.Value = (object)entity.Codigo ?? DBNull.Value;
                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

                var paramUpdExpiracion = _dataProvider.GetParameter();
                paramUpdExpiracion.ParameterName = "Expiracion";
                paramUpdExpiracion.DbType = DbType.DateTime;
                paramUpdExpiracion.Value = (object)entity.Expiracion ?? DBNull.Value;

                var paramUpdAccesos = _dataProvider.GetParameter();
                paramUpdAccesos.ParameterName = "Accesos";
                paramUpdAccesos.DbType = DbType.Int32;
                paramUpdAccesos.Value = (object)entity.Accesos ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_de_Observatorio_Privado>("sp_UpdDetalle_de_Observatorio_Privado" , paramUpdClave , paramUpdObservatorio , paramUpdCodigo , paramUpdEstatus , paramUpdExpiracion , paramUpdAccesos ).FirstOrDefault();

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
