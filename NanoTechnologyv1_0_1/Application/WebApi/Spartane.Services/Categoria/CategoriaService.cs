using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Categoria;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Categoria
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class CategoriaService : ICategoriaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Categoria.Categoria> _CategoriaRepository;
        #endregion

        #region Ctor
        public CategoriaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Categoria.Categoria> CategoriaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._CategoriaRepository = CategoriaRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._CategoriaRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Categoria.Categoria> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Categoria.Categoria>("sp_SelAllCategoria");
        }

        public IList<Core.Classes.Categoria.Categoria> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallCategoria_Complete>("sp_SelAllComplete_Categoria");
            return data.Select(m => new Core.Classes.Categoria.Categoria
            {
                Clave = m.Clave
                ,Descripcion = m.Descripcion
                ,Icono_TTArchivos = new Core.Classes.TTArchivos.TTArchivos() { Folio = m.Icono.GetValueOrDefault(), Nombre = m.Icono_Nombre }
                ,Color_Franja_Color = new Core.Classes.Color.Color() { Clave = m.Color_Franja.GetValueOrDefault(), Descripcion = m.Color_Franja_Descripcion }
                ,Imagen_TTArchivos = new Core.Classes.TTArchivos.TTArchivos() { Folio = m.Imagen.GetValueOrDefault(), Nombre = m.Imagen_Nombre }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Categoria>("sp_ListSelCount_Categoria", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Categoria.Categoria> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllCategoria>("sp_ListSelAll_Categoria", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Categoria.Categoria
                {
                    Clave = m.Categoria_Clave,
                    Descripcion = m.Categoria_Descripcion,
                    Icono = m.Categoria_Icono,
                    Color_Franja = m.Categoria_Color_Franja,
                    Imagen = m.Categoria_Imagen,

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

        public IList<Spartane.Core.Classes.Categoria.Categoria> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._CategoriaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Categoria.Categoria> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._CategoriaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Categoria.CategoriaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllCategoria>("sp_ListSelAll_Categoria", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            CategoriaPagingModel result = null;

            if (data != null)
            {
                result = new CategoriaPagingModel
                {
                    Categorias =
                        data.Select(m => new Spartane.Core.Classes.Categoria.Categoria
                {
                    Clave = m.Categoria_Clave
                    ,Descripcion = m.Categoria_Descripcion
                    ,Icono = m.Categoria_Icono
                    ,Icono_TTArchivos = new Core.Classes.TTArchivos.TTArchivos() { Folio = m.Categoria_Icono.GetValueOrDefault(), Nombre = m.Categoria_Icono_Nombre }
                    ,Color_Franja = m.Categoria_Color_Franja
                    ,Color_Franja_Color = new Core.Classes.Color.Color() { Clave = m.Categoria_Color_Franja.GetValueOrDefault(), Descripcion = m.Categoria_Color_Franja_Descripcion }
                    ,Imagen = m.Categoria_Imagen
                    ,Imagen_TTArchivos = new Core.Classes.TTArchivos.TTArchivos() { Folio = m.Categoria_Imagen.GetValueOrDefault(), Nombre = m.Categoria_Imagen_Nombre }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Categoria.Categoria> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._CategoriaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Categoria.Categoria GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Categoria.Categoria>("sp_GetCategoria", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelCategoria>("sp_DelCategoria", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Categoria.Categoria entity)
        {
            int rta;
            try
            {

		                var padreDescripcion = _dataProvider.GetParameter();
                padreDescripcion.ParameterName = "Descripcion";
                padreDescripcion.DbType = DbType.String;
                padreDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var padreIcono = _dataProvider.GetParameter();
                padreIcono.ParameterName = "Icono";
                padreIcono.DbType = DbType.Int32;
                padreIcono.Value = (object)entity.Icono ?? DBNull.Value;

                var padreColor_Franja = _dataProvider.GetParameter();
                padreColor_Franja.ParameterName = "Color_Franja";
                padreColor_Franja.DbType = DbType.Int32;
                padreColor_Franja.Value = (object)entity.Color_Franja ?? DBNull.Value;

                var padreImagen = _dataProvider.GetParameter();
                padreImagen.ParameterName = "Imagen";
                padreImagen.DbType = DbType.Int32;
                padreImagen.Value = (object)entity.Imagen ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsCategoria>("sp_InsCategoria" , padreDescripcion
, padreIcono
, padreColor_Franja
, padreImagen
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

        public int Update(Spartane.Core.Classes.Categoria.Categoria entity)
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
                var paramUpdIcono = _dataProvider.GetParameter();
                paramUpdIcono.ParameterName = "Icono";
                paramUpdIcono.DbType = DbType.Int32;
                paramUpdIcono.Value = (object)entity.Icono ?? DBNull.Value;

                var paramUpdColor_Franja = _dataProvider.GetParameter();
                paramUpdColor_Franja.ParameterName = "Color_Franja";
                paramUpdColor_Franja.DbType = DbType.Int32;
                paramUpdColor_Franja.Value = (object)entity.Color_Franja ?? DBNull.Value;

                var paramUpdImagen = _dataProvider.GetParameter();
                paramUpdImagen.ParameterName = "Imagen";
                paramUpdImagen.DbType = DbType.Int32;
                paramUpdImagen.Value = (object)entity.Imagen ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdCategoria>("sp_UpdCategoria" , paramUpdClave , paramUpdDescripcion , paramUpdIcono , paramUpdColor_Franja , paramUpdImagen ).FirstOrDefault();

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
