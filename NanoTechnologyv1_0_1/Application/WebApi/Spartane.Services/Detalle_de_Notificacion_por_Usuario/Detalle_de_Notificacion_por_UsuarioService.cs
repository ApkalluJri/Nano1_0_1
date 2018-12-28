using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_de_Notificacion_por_Usuario;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_de_Notificacion_por_Usuario
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_de_Notificacion_por_UsuarioService : IDetalle_de_Notificacion_por_UsuarioService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_de_Notificacion_por_Usuario.Detalle_de_Notificacion_por_Usuario> _Detalle_de_Notificacion_por_UsuarioRepository;
        #endregion

        #region Ctor
        public Detalle_de_Notificacion_por_UsuarioService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_de_Notificacion_por_Usuario.Detalle_de_Notificacion_por_Usuario> Detalle_de_Notificacion_por_UsuarioRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_de_Notificacion_por_UsuarioRepository = Detalle_de_Notificacion_por_UsuarioRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_de_Notificacion_por_UsuarioRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_de_Notificacion_por_Usuario.Detalle_de_Notificacion_por_Usuario> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_de_Notificacion_por_Usuario.Detalle_de_Notificacion_por_Usuario>("sp_SelAllDetalle_de_Notificacion_por_Usuario");
        }

        public IList<Core.Classes.Detalle_de_Notificacion_por_Usuario.Detalle_de_Notificacion_por_Usuario> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_de_Notificacion_por_Usuario_Complete>("sp_SelAllComplete_Detalle_de_Notificacion_por_Usuario");
            return data.Select(m => new Core.Classes.Detalle_de_Notificacion_por_Usuario.Detalle_de_Notificacion_por_Usuario
            {
                Clave = m.Clave
                ,Contenido = m.Contenido
                ,Notificar = m.Notificar.GetValueOrDefault()
                ,Observatorio_Observatorio = new Core.Classes.Observatorio.Observatorio() { Clave = m.Observatorio.GetValueOrDefault(), Nombre = m.Observatorio_Nombre }
                ,ID_del_Cliente = m.ID_del_Cliente
                ,Nombre = m.Nombre


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_de_Notificacion_por_Usuario>("sp_ListSelCount_Detalle_de_Notificacion_por_Usuario", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_de_Notificacion_por_Usuario.Detalle_de_Notificacion_por_Usuario> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_de_Notificacion_por_Usuario>("sp_ListSelAll_Detalle_de_Notificacion_por_Usuario", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_de_Notificacion_por_Usuario.Detalle_de_Notificacion_por_Usuario
                {
                    Clave = m.Detalle_de_Notificacion_por_Usuario_Clave,
                    Contenido = m.Detalle_de_Notificacion_por_Usuario_Contenido,
                    Notificar = m.Detalle_de_Notificacion_por_Usuario_Notificar ?? false,
                    Observatorio = m.Detalle_de_Notificacion_por_Usuario_Observatorio,
                    ID_del_Cliente = m.Detalle_de_Notificacion_por_Usuario_ID_del_Cliente,
                    Nombre = m.Detalle_de_Notificacion_por_Usuario_Nombre,

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

        public IList<Spartane.Core.Classes.Detalle_de_Notificacion_por_Usuario.Detalle_de_Notificacion_por_Usuario> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_de_Notificacion_por_UsuarioRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_de_Notificacion_por_Usuario.Detalle_de_Notificacion_por_Usuario> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_de_Notificacion_por_UsuarioRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_de_Notificacion_por_Usuario.Detalle_de_Notificacion_por_UsuarioPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_de_Notificacion_por_Usuario>("sp_ListSelAll_Detalle_de_Notificacion_por_Usuario", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_de_Notificacion_por_UsuarioPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_de_Notificacion_por_UsuarioPagingModel
                {
                    Detalle_de_Notificacion_por_Usuarios =
                        data.Select(m => new Spartane.Core.Classes.Detalle_de_Notificacion_por_Usuario.Detalle_de_Notificacion_por_Usuario
                {
                    Clave = m.Detalle_de_Notificacion_por_Usuario_Clave
                    ,Contenido = m.Detalle_de_Notificacion_por_Usuario_Contenido
                    ,Notificar = m.Detalle_de_Notificacion_por_Usuario_Notificar ?? false
                    ,Observatorio = m.Detalle_de_Notificacion_por_Usuario_Observatorio
                    ,Observatorio_Observatorio = new Core.Classes.Observatorio.Observatorio() { Clave = m.Detalle_de_Notificacion_por_Usuario_Observatorio.GetValueOrDefault(), Nombre = m.Detalle_de_Notificacion_por_Usuario_Observatorio_Nombre }
                    ,ID_del_Cliente = m.Detalle_de_Notificacion_por_Usuario_ID_del_Cliente
                    ,Nombre = m.Detalle_de_Notificacion_por_Usuario_Nombre

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_de_Notificacion_por_Usuario.Detalle_de_Notificacion_por_Usuario> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_de_Notificacion_por_UsuarioRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_de_Notificacion_por_Usuario.Detalle_de_Notificacion_por_Usuario GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_de_Notificacion_por_Usuario.Detalle_de_Notificacion_por_Usuario>("sp_GetDetalle_de_Notificacion_por_Usuario", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_de_Notificacion_por_Usuario>("sp_DelDetalle_de_Notificacion_por_Usuario", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_de_Notificacion_por_Usuario.Detalle_de_Notificacion_por_Usuario entity)
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

                var padreID_del_Cliente = _dataProvider.GetParameter();
                padreID_del_Cliente.ParameterName = "ID_del_Cliente";
                padreID_del_Cliente.DbType = DbType.Int32;
                padreID_del_Cliente.Value = (object)entity.ID_del_Cliente ?? DBNull.Value;

                var padreNombre = _dataProvider.GetParameter();
                padreNombre.ParameterName = "Nombre";
                padreNombre.DbType = DbType.String;
                padreNombre.Value = (object)entity.Nombre ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_de_Notificacion_por_Usuario>("sp_InsDetalle_de_Notificacion_por_Usuario" , padreContenido
, padreNotificar
, padreObservatorio
, padreID_del_Cliente
, padreNombre
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

        public int Update(Spartane.Core.Classes.Detalle_de_Notificacion_por_Usuario.Detalle_de_Notificacion_por_Usuario entity)
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

                var paramUpdID_del_Cliente = _dataProvider.GetParameter();
                paramUpdID_del_Cliente.ParameterName = "ID_del_Cliente";
                paramUpdID_del_Cliente.DbType = DbType.Int32;
                paramUpdID_del_Cliente.Value = (object)entity.ID_del_Cliente ?? DBNull.Value;

                var paramUpdNombre = _dataProvider.GetParameter();
                paramUpdNombre.ParameterName = "Nombre";
                paramUpdNombre.DbType = DbType.String;
                paramUpdNombre.Value = (object)entity.Nombre ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_de_Notificacion_por_Usuario>("sp_UpdDetalle_de_Notificacion_por_Usuario" , paramUpdClave , paramUpdContenido , paramUpdNotificar , paramUpdObservatorio , paramUpdID_del_Cliente , paramUpdNombre ).FirstOrDefault();

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
