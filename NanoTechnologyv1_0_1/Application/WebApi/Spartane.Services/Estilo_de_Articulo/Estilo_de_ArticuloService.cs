using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Estilo_de_Articulo;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Estilo_de_Articulo
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Estilo_de_ArticuloService : IEstilo_de_ArticuloService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Estilo_de_Articulo.Estilo_de_Articulo> _Estilo_de_ArticuloRepository;
        #endregion

        #region Ctor
        public Estilo_de_ArticuloService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Estilo_de_Articulo.Estilo_de_Articulo> Estilo_de_ArticuloRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Estilo_de_ArticuloRepository = Estilo_de_ArticuloRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Estilo_de_ArticuloRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Estilo_de_Articulo.Estilo_de_Articulo> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Estilo_de_Articulo.Estilo_de_Articulo>("sp_SelAllEstilo_de_Articulo");
        }

        public IList<Core.Classes.Estilo_de_Articulo.Estilo_de_Articulo> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallEstilo_de_Articulo_Complete>("sp_SelAllComplete_Estilo_de_Articulo");
            return data.Select(m => new Core.Classes.Estilo_de_Articulo.Estilo_de_Articulo
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Estilo_de_Articulo>("sp_ListSelCount_Estilo_de_Articulo", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Estilo_de_Articulo.Estilo_de_Articulo> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEstilo_de_Articulo>("sp_ListSelAll_Estilo_de_Articulo", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Estilo_de_Articulo.Estilo_de_Articulo
                {
                    Clave = m.Estilo_de_Articulo_Clave,
                    Descripcion = m.Estilo_de_Articulo_Descripcion,

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

        public IList<Spartane.Core.Classes.Estilo_de_Articulo.Estilo_de_Articulo> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Estilo_de_ArticuloRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Estilo_de_Articulo.Estilo_de_Articulo> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estilo_de_ArticuloRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Estilo_de_Articulo.Estilo_de_ArticuloPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEstilo_de_Articulo>("sp_ListSelAll_Estilo_de_Articulo", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Estilo_de_ArticuloPagingModel result = null;

            if (data != null)
            {
                result = new Estilo_de_ArticuloPagingModel
                {
                    Estilo_de_Articulos =
                        data.Select(m => new Spartane.Core.Classes.Estilo_de_Articulo.Estilo_de_Articulo
                {
                    Clave = m.Estilo_de_Articulo_Clave
                    ,Descripcion = m.Estilo_de_Articulo_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Estilo_de_Articulo.Estilo_de_Articulo> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Estilo_de_ArticuloRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Estilo_de_Articulo.Estilo_de_Articulo GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Estilo_de_Articulo.Estilo_de_Articulo>("sp_GetEstilo_de_Articulo", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelEstilo_de_Articulo>("sp_DelEstilo_de_Articulo", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Estilo_de_Articulo.Estilo_de_Articulo entity)
        {
            int rta;
            try
            {

		                var padreDescripcion = _dataProvider.GetParameter();
                padreDescripcion.ParameterName = "Descripcion";
                padreDescripcion.DbType = DbType.String;
                padreDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsEstilo_de_Articulo>("sp_InsEstilo_de_Articulo" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Estilo_de_Articulo.Estilo_de_Articulo entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEstilo_de_Articulo>("sp_UpdEstilo_de_Articulo" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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
