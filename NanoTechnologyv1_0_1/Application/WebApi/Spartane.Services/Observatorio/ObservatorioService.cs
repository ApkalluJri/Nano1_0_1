using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Observatorio;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Observatorio
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class ObservatorioService : IObservatorioService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Observatorio.Observatorio> _ObservatorioRepository;
        #endregion

        #region Ctor
        public ObservatorioService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Observatorio.Observatorio> ObservatorioRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._ObservatorioRepository = ObservatorioRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._ObservatorioRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Observatorio.Observatorio> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Observatorio.Observatorio>("sp_SelAllObservatorio");
        }

        public IList<Core.Classes.Observatorio.Observatorio> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallObservatorio_Complete>("sp_SelAllComplete_Observatorio");
            return data.Select(m => new Core.Classes.Observatorio.Observatorio
            {
                Clave = m.Clave
                ,Nombre = m.Nombre
                ,Icono_TTArchivos = new Core.Classes.TTArchivos.TTArchivos() { Folio = m.Icono.GetValueOrDefault(), Nombre = m.Icono_Nombre }
                ,Color_Color = new Core.Classes.Color.Color() { Clave = m.Color.GetValueOrDefault(), Descripcion = m.Color_Descripcion }
                ,Tipo_de_Observatorio_Tipo_de_Observatorio = new Core.Classes.Tipo_de_Observatorio.Tipo_de_Observatorio() { Clave = m.Tipo_de_Observatorio.GetValueOrDefault(), Descripcion = m.Tipo_de_Observatorio_Descripcion }
                ,Administrador_Registro_de_Roles = new Core.Classes.Registro_de_Roles.Registro_de_Roles() { Folio = m.Administrador.GetValueOrDefault(), Nombre = m.Administrador_Nombre }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Observatorio>("sp_ListSelCount_Observatorio", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Observatorio.Observatorio> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllObservatorio>("sp_ListSelAll_Observatorio", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Observatorio.Observatorio
                {
                    Clave = m.Observatorio_Clave,
                    Nombre = m.Observatorio_Nombre,
                    Icono = m.Observatorio_Icono,
                    Color = m.Observatorio_Color,
                    Tipo_de_Observatorio = m.Observatorio_Tipo_de_Observatorio,
                    Administrador = m.Observatorio_Administrador,

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

        public IList<Spartane.Core.Classes.Observatorio.Observatorio> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._ObservatorioRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Observatorio.Observatorio> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._ObservatorioRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Observatorio.ObservatorioPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllObservatorio>("sp_ListSelAll_Observatorio", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            ObservatorioPagingModel result = null;

            if (data != null)
            {
                result = new ObservatorioPagingModel
                {
                    Observatorios =
                        data.Select(m => new Spartane.Core.Classes.Observatorio.Observatorio
                {
                    Clave = m.Observatorio_Clave
                    ,Nombre = m.Observatorio_Nombre
                    ,Icono = m.Observatorio_Icono
                    ,Icono_TTArchivos = new Core.Classes.TTArchivos.TTArchivos() { Folio = m.Observatorio_Icono.GetValueOrDefault(), Nombre = m.Observatorio_Icono_Nombre }
                    ,Color = m.Observatorio_Color
                    ,Color_Color = new Core.Classes.Color.Color() { Clave = m.Observatorio_Color.GetValueOrDefault(), Descripcion = m.Observatorio_Color_Descripcion }
                    ,Tipo_de_Observatorio = m.Observatorio_Tipo_de_Observatorio
                    ,Tipo_de_Observatorio_Tipo_de_Observatorio = new Core.Classes.Tipo_de_Observatorio.Tipo_de_Observatorio() { Clave = m.Observatorio_Tipo_de_Observatorio.GetValueOrDefault(), Descripcion = m.Observatorio_Tipo_de_Observatorio_Descripcion }
                    ,Administrador = m.Observatorio_Administrador
                    ,Administrador_Registro_de_Roles = new Core.Classes.Registro_de_Roles.Registro_de_Roles() { Folio = m.Observatorio_Administrador.GetValueOrDefault(), Nombre = m.Observatorio_Administrador_Nombre }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Observatorio.Observatorio> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._ObservatorioRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Observatorio.Observatorio GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Observatorio.Observatorio>("sp_GetObservatorio", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelObservatorio>("sp_DelObservatorio", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Observatorio.Observatorio entity)
        {
            int rta;
            try
            {

		                var padreNombre = _dataProvider.GetParameter();
                padreNombre.ParameterName = "Nombre";
                padreNombre.DbType = DbType.String;
                padreNombre.Value = (object)entity.Nombre ?? DBNull.Value;
                var padreIcono = _dataProvider.GetParameter();
                padreIcono.ParameterName = "Icono";
                padreIcono.DbType = DbType.Int32;
                padreIcono.Value = (object)entity.Icono ?? DBNull.Value;

                var padreColor = _dataProvider.GetParameter();
                padreColor.ParameterName = "Color";
                padreColor.DbType = DbType.Int32;
                padreColor.Value = (object)entity.Color ?? DBNull.Value;

                var padreTipo_de_Observatorio = _dataProvider.GetParameter();
                padreTipo_de_Observatorio.ParameterName = "Tipo_de_Observatorio";
                padreTipo_de_Observatorio.DbType = DbType.Int32;
                padreTipo_de_Observatorio.Value = (object)entity.Tipo_de_Observatorio ?? DBNull.Value;

                var padreAdministrador = _dataProvider.GetParameter();
                padreAdministrador.ParameterName = "Administrador";
                padreAdministrador.DbType = DbType.Int32;
                padreAdministrador.Value = (object)entity.Administrador ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsObservatorio>("sp_InsObservatorio" , padreNombre
, padreIcono
, padreColor
, padreTipo_de_Observatorio
, padreAdministrador
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

        public int Update(Spartane.Core.Classes.Observatorio.Observatorio entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdNombre = _dataProvider.GetParameter();
                paramUpdNombre.ParameterName = "Nombre";
                paramUpdNombre.DbType = DbType.String;
                paramUpdNombre.Value = (object)entity.Nombre ?? DBNull.Value;
                var paramUpdIcono = _dataProvider.GetParameter();
                paramUpdIcono.ParameterName = "Icono";
                paramUpdIcono.DbType = DbType.Int32;
                paramUpdIcono.Value = (object)entity.Icono ?? DBNull.Value;

                var paramUpdColor = _dataProvider.GetParameter();
                paramUpdColor.ParameterName = "Color";
                paramUpdColor.DbType = DbType.Int32;
                paramUpdColor.Value = (object)entity.Color ?? DBNull.Value;

                var paramUpdTipo_de_Observatorio = _dataProvider.GetParameter();
                paramUpdTipo_de_Observatorio.ParameterName = "Tipo_de_Observatorio";
                paramUpdTipo_de_Observatorio.DbType = DbType.Int32;
                paramUpdTipo_de_Observatorio.Value = (object)entity.Tipo_de_Observatorio ?? DBNull.Value;

                var paramUpdAdministrador = _dataProvider.GetParameter();
                paramUpdAdministrador.ParameterName = "Administrador";
                paramUpdAdministrador.DbType = DbType.Int32;
                paramUpdAdministrador.Value = (object)entity.Administrador ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdObservatorio>("sp_UpdObservatorio" , paramUpdClave , paramUpdNombre , paramUpdIcono , paramUpdColor , paramUpdTipo_de_Observatorio , paramUpdAdministrador ).FirstOrDefault();

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
