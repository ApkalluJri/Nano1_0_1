using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_de_Codigo_Por_Cliente;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_de_Codigo_Por_Cliente
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_de_Codigo_Por_ClienteService : IDetalle_de_Codigo_Por_ClienteService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_de_Codigo_Por_Cliente.Detalle_de_Codigo_Por_Cliente> _Detalle_de_Codigo_Por_ClienteRepository;
        #endregion

        #region Ctor
        public Detalle_de_Codigo_Por_ClienteService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_de_Codigo_Por_Cliente.Detalle_de_Codigo_Por_Cliente> Detalle_de_Codigo_Por_ClienteRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_de_Codigo_Por_ClienteRepository = Detalle_de_Codigo_Por_ClienteRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_de_Codigo_Por_ClienteRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_de_Codigo_Por_Cliente.Detalle_de_Codigo_Por_Cliente> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_de_Codigo_Por_Cliente.Detalle_de_Codigo_Por_Cliente>("sp_SelAllDetalle_de_Codigo_Por_Cliente");
        }

        public IList<Core.Classes.Detalle_de_Codigo_Por_Cliente.Detalle_de_Codigo_Por_Cliente> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_de_Codigo_Por_Cliente_Complete>("sp_SelAllComplete_Detalle_de_Codigo_Por_Cliente");
            return data.Select(m => new Core.Classes.Detalle_de_Codigo_Por_Cliente.Detalle_de_Codigo_Por_Cliente
            {
                Clave = m.Clave
                ,Cliente = m.Cliente
                ,Observatorio_Observatorio = new Core.Classes.Observatorio.Observatorio() { Clave = m.Observatorio.GetValueOrDefault(), Nombre = m.Observatorio_Nombre }
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_de_Codigo_Por_Cliente>("sp_ListSelCount_Detalle_de_Codigo_Por_Cliente", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_de_Codigo_Por_Cliente.Detalle_de_Codigo_Por_Cliente> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_de_Codigo_Por_Cliente>("sp_ListSelAll_Detalle_de_Codigo_Por_Cliente", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_de_Codigo_Por_Cliente.Detalle_de_Codigo_Por_Cliente
                {
                    Clave = m.Detalle_de_Codigo_Por_Cliente_Clave,
                    Cliente = m.Detalle_de_Codigo_Por_Cliente_Cliente,
                    Observatorio = m.Detalle_de_Codigo_Por_Cliente_Observatorio,
                    Codigo = m.Detalle_de_Codigo_Por_Cliente_Codigo,
                    Estatus = m.Detalle_de_Codigo_Por_Cliente_Estatus,
                    Expiracion = m.Detalle_de_Codigo_Por_Cliente_Expiracion,
                    Accesos = m.Detalle_de_Codigo_Por_Cliente_Accesos,

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

        public IList<Spartane.Core.Classes.Detalle_de_Codigo_Por_Cliente.Detalle_de_Codigo_Por_Cliente> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_de_Codigo_Por_ClienteRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_de_Codigo_Por_Cliente.Detalle_de_Codigo_Por_Cliente> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_de_Codigo_Por_ClienteRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_de_Codigo_Por_Cliente.Detalle_de_Codigo_Por_ClientePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_de_Codigo_Por_Cliente>("sp_ListSelAll_Detalle_de_Codigo_Por_Cliente", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_de_Codigo_Por_ClientePagingModel result = null;

            if (data != null)
            {
                result = new Detalle_de_Codigo_Por_ClientePagingModel
                {
                    Detalle_de_Codigo_Por_Clientes =
                        data.Select(m => new Spartane.Core.Classes.Detalle_de_Codigo_Por_Cliente.Detalle_de_Codigo_Por_Cliente
                {
                    Clave = m.Detalle_de_Codigo_Por_Cliente_Clave
                    ,Cliente = m.Detalle_de_Codigo_Por_Cliente_Cliente
                    ,Observatorio = m.Detalle_de_Codigo_Por_Cliente_Observatorio
                    ,Observatorio_Observatorio = new Core.Classes.Observatorio.Observatorio() { Clave = m.Detalle_de_Codigo_Por_Cliente_Observatorio.GetValueOrDefault(), Nombre = m.Detalle_de_Codigo_Por_Cliente_Observatorio_Nombre }
                    ,Codigo = m.Detalle_de_Codigo_Por_Cliente_Codigo
                    ,Estatus = m.Detalle_de_Codigo_Por_Cliente_Estatus
                    ,Estatus_Estatus_Codigo = new Core.Classes.Estatus_Codigo.Estatus_Codigo() { Clave = m.Detalle_de_Codigo_Por_Cliente_Estatus.GetValueOrDefault(), Descripcion = m.Detalle_de_Codigo_Por_Cliente_Estatus_Descripcion }
                    ,Expiracion = m.Detalle_de_Codigo_Por_Cliente_Expiracion
                    ,Accesos = m.Detalle_de_Codigo_Por_Cliente_Accesos

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_de_Codigo_Por_Cliente.Detalle_de_Codigo_Por_Cliente> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_de_Codigo_Por_ClienteRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_de_Codigo_Por_Cliente.Detalle_de_Codigo_Por_Cliente GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_de_Codigo_Por_Cliente.Detalle_de_Codigo_Por_Cliente>("sp_GetDetalle_de_Codigo_Por_Cliente", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_de_Codigo_Por_Cliente>("sp_DelDetalle_de_Codigo_Por_Cliente", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_de_Codigo_Por_Cliente.Detalle_de_Codigo_Por_Cliente entity)
        {
            int rta;
            try
            {

		                var padreCliente = _dataProvider.GetParameter();
                padreCliente.ParameterName = "Cliente";
                padreCliente.DbType = DbType.Int32;
                padreCliente.Value = (object)entity.Cliente ?? DBNull.Value;
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_de_Codigo_Por_Cliente>("sp_InsDetalle_de_Codigo_Por_Cliente" , padreCliente
, padreObservatorio
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

        public int Update(Spartane.Core.Classes.Detalle_de_Codigo_Por_Cliente.Detalle_de_Codigo_Por_Cliente entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdCliente = _dataProvider.GetParameter();
                paramUpdCliente.ParameterName = "Cliente";
                paramUpdCliente.DbType = DbType.Int32;
                paramUpdCliente.Value = (object)entity.Cliente ?? DBNull.Value;
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_de_Codigo_Por_Cliente>("sp_UpdDetalle_de_Codigo_Por_Cliente" , paramUpdClave , paramUpdCliente , paramUpdObservatorio , paramUpdCodigo , paramUpdEstatus , paramUpdExpiracion , paramUpdAccesos ).FirstOrDefault();

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
