using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_de_Asistentes_de_Observatorio;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_de_Asistentes_de_Observatorio
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_de_Asistentes_de_ObservatorioService : IDetalle_de_Asistentes_de_ObservatorioService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_de_Asistentes_de_Observatorio.Detalle_de_Asistentes_de_Observatorio> _Detalle_de_Asistentes_de_ObservatorioRepository;
        #endregion

        #region Ctor
        public Detalle_de_Asistentes_de_ObservatorioService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_de_Asistentes_de_Observatorio.Detalle_de_Asistentes_de_Observatorio> Detalle_de_Asistentes_de_ObservatorioRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_de_Asistentes_de_ObservatorioRepository = Detalle_de_Asistentes_de_ObservatorioRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_de_Asistentes_de_ObservatorioRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_de_Asistentes_de_Observatorio.Detalle_de_Asistentes_de_Observatorio> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_de_Asistentes_de_Observatorio.Detalle_de_Asistentes_de_Observatorio>("sp_SelAllDetalle_de_Asistentes_de_Observatorio");
        }

        public IList<Core.Classes.Detalle_de_Asistentes_de_Observatorio.Detalle_de_Asistentes_de_Observatorio> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_de_Asistentes_de_Observatorio_Complete>("sp_SelAllComplete_Detalle_de_Asistentes_de_Observatorio");
            return data.Select(m => new Core.Classes.Detalle_de_Asistentes_de_Observatorio.Detalle_de_Asistentes_de_Observatorio
            {
                Clave = m.Clave
                ,Observatorio = m.Observatorio
                ,Nombre_Registro_de_Roles = new Core.Classes.Registro_de_Roles.Registro_de_Roles() { Folio = m.Nombre.GetValueOrDefault(), Nombre = m.Nombre_Nombre }
                ,Rol_Rol_de_Usuario = new Core.Classes.Rol_de_Usuario.Rol_de_Usuario() { Clave = m.Rol.GetValueOrDefault(), Descripcion = m.Rol_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_de_Asistentes_de_Observatorio>("sp_ListSelCount_Detalle_de_Asistentes_de_Observatorio", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_de_Asistentes_de_Observatorio.Detalle_de_Asistentes_de_Observatorio> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_de_Asistentes_de_Observatorio>("sp_ListSelAll_Detalle_de_Asistentes_de_Observatorio", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_de_Asistentes_de_Observatorio.Detalle_de_Asistentes_de_Observatorio
                {
                    Clave = m.Detalle_de_Asistentes_de_Observatorio_Clave,
                    Observatorio = m.Detalle_de_Asistentes_de_Observatorio_Observatorio,
                    Nombre = m.Detalle_de_Asistentes_de_Observatorio_Nombre,
                    Rol = m.Detalle_de_Asistentes_de_Observatorio_Rol,

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

        public IList<Spartane.Core.Classes.Detalle_de_Asistentes_de_Observatorio.Detalle_de_Asistentes_de_Observatorio> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_de_Asistentes_de_ObservatorioRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_de_Asistentes_de_Observatorio.Detalle_de_Asistentes_de_Observatorio> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_de_Asistentes_de_ObservatorioRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_de_Asistentes_de_Observatorio.Detalle_de_Asistentes_de_ObservatorioPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_de_Asistentes_de_Observatorio>("sp_ListSelAll_Detalle_de_Asistentes_de_Observatorio", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_de_Asistentes_de_ObservatorioPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_de_Asistentes_de_ObservatorioPagingModel
                {
                    Detalle_de_Asistentes_de_Observatorios =
                        data.Select(m => new Spartane.Core.Classes.Detalle_de_Asistentes_de_Observatorio.Detalle_de_Asistentes_de_Observatorio
                {
                    Clave = m.Detalle_de_Asistentes_de_Observatorio_Clave
                    ,Observatorio = m.Detalle_de_Asistentes_de_Observatorio_Observatorio
                    ,Nombre = m.Detalle_de_Asistentes_de_Observatorio_Nombre
                    ,Nombre_Registro_de_Roles = new Core.Classes.Registro_de_Roles.Registro_de_Roles() { Folio = m.Detalle_de_Asistentes_de_Observatorio_Nombre.GetValueOrDefault(), Nombre = m.Detalle_de_Asistentes_de_Observatorio_Nombre_Nombre }
                    ,Rol = m.Detalle_de_Asistentes_de_Observatorio_Rol
                    ,Rol_Rol_de_Usuario = new Core.Classes.Rol_de_Usuario.Rol_de_Usuario() { Clave = m.Detalle_de_Asistentes_de_Observatorio_Rol.GetValueOrDefault(), Descripcion = m.Detalle_de_Asistentes_de_Observatorio_Rol_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_de_Asistentes_de_Observatorio.Detalle_de_Asistentes_de_Observatorio> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_de_Asistentes_de_ObservatorioRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_de_Asistentes_de_Observatorio.Detalle_de_Asistentes_de_Observatorio GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_de_Asistentes_de_Observatorio.Detalle_de_Asistentes_de_Observatorio>("sp_GetDetalle_de_Asistentes_de_Observatorio", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_de_Asistentes_de_Observatorio>("sp_DelDetalle_de_Asistentes_de_Observatorio", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_de_Asistentes_de_Observatorio.Detalle_de_Asistentes_de_Observatorio entity)
        {
            int rta;
            try
            {

		                var padreObservatorio = _dataProvider.GetParameter();
                padreObservatorio.ParameterName = "Observatorio";
                padreObservatorio.DbType = DbType.Int32;
                padreObservatorio.Value = (object)entity.Observatorio ?? DBNull.Value;
                var padreNombre = _dataProvider.GetParameter();
                padreNombre.ParameterName = "Nombre";
                padreNombre.DbType = DbType.Int32;
                padreNombre.Value = (object)entity.Nombre ?? DBNull.Value;

                var padreRol = _dataProvider.GetParameter();
                padreRol.ParameterName = "Rol";
                padreRol.DbType = DbType.Int32;
                padreRol.Value = (object)entity.Rol ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_de_Asistentes_de_Observatorio>("sp_InsDetalle_de_Asistentes_de_Observatorio" , padreObservatorio
, padreNombre
, padreRol
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

        public int Update(Spartane.Core.Classes.Detalle_de_Asistentes_de_Observatorio.Detalle_de_Asistentes_de_Observatorio entity)
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
                var paramUpdNombre = _dataProvider.GetParameter();
                paramUpdNombre.ParameterName = "Nombre";
                paramUpdNombre.DbType = DbType.Int32;
                paramUpdNombre.Value = (object)entity.Nombre ?? DBNull.Value;

                var paramUpdRol = _dataProvider.GetParameter();
                paramUpdRol.ParameterName = "Rol";
                paramUpdRol.DbType = DbType.Int32;
                paramUpdRol.Value = (object)entity.Rol ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_de_Asistentes_de_Observatorio>("sp_UpdDetalle_de_Asistentes_de_Observatorio" , paramUpdClave , paramUpdObservatorio , paramUpdNombre , paramUpdRol ).FirstOrDefault();

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
