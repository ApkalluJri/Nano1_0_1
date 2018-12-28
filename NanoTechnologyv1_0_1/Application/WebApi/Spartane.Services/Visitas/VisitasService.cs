using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Visitas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Visitas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class VisitasService : IVisitasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Visitas.Visitas> _VisitasRepository;
        #endregion

        #region Ctor
        public VisitasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Visitas.Visitas> VisitasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._VisitasRepository = VisitasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._VisitasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Visitas.Visitas> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Visitas.Visitas>("sp_SelAllVisitas");
        }

        public IList<Core.Classes.Visitas.Visitas> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallVisitas_Complete>("sp_SelAllComplete_Visitas");
            return data.Select(m => new Core.Classes.Visitas.Visitas
            {
                Folio = m.Folio
                ,Fecha_de_visita = m.Fecha_de_visita
                ,Hora_de_visita = m.Hora_de_visita
                ,ContenidoId_Registro_de_Contenido = new Core.Classes.Registro_de_Contenido.Registro_de_Contenido() { Folio = m.ContenidoId.GetValueOrDefault(), Descripcion = m.ContenidoId_Descripcion }
                ,UsuarioId_Registro_de_Usuario = new Core.Classes.Registro_de_Usuario.Registro_de_Usuario() { Folio = m.UsuarioId.GetValueOrDefault(), Nombre_Completo = m.UsuarioId_Nombre_Completo }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Visitas>("sp_ListSelCount_Visitas", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Visitas.Visitas> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllVisitas>("sp_ListSelAll_Visitas", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Visitas.Visitas
                {
                    Folio = m.Visitas_Folio,
                    Fecha_de_visita = m.Visitas_Fecha_de_visita,
                    Hora_de_visita = m.Visitas_Hora_de_visita,
                    ContenidoId = m.Visitas_ContenidoId,
                    UsuarioId = m.Visitas_UsuarioId,

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

        public IList<Spartane.Core.Classes.Visitas.Visitas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._VisitasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Visitas.Visitas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._VisitasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Visitas.VisitasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllVisitas>("sp_ListSelAll_Visitas", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            VisitasPagingModel result = null;

            if (data != null)
            {
                result = new VisitasPagingModel
                {
                    Visitass =
                        data.Select(m => new Spartane.Core.Classes.Visitas.Visitas
                {
                    Folio = m.Visitas_Folio
                    ,Fecha_de_visita = m.Visitas_Fecha_de_visita
                    ,Hora_de_visita = m.Visitas_Hora_de_visita
                    ,ContenidoId = m.Visitas_ContenidoId
                    ,ContenidoId_Registro_de_Contenido = new Core.Classes.Registro_de_Contenido.Registro_de_Contenido() { Folio = m.Visitas_ContenidoId.GetValueOrDefault(), Descripcion = m.Visitas_ContenidoId_Descripcion }
                    ,UsuarioId = m.Visitas_UsuarioId
                    ,UsuarioId_Registro_de_Usuario = new Core.Classes.Registro_de_Usuario.Registro_de_Usuario() { Folio = m.Visitas_UsuarioId.GetValueOrDefault(), Nombre_Completo = m.Visitas_UsuarioId_Nombre_Completo }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Visitas.Visitas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._VisitasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Visitas.Visitas GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Visitas.Visitas>("sp_GetVisitas", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Folio";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelVisitas>("sp_DelVisitas", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Visitas.Visitas entity)
        {
            int rta;
            try
            {

		                var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = entity.Folio;
                var padreFecha_de_visita = _dataProvider.GetParameter();
                padreFecha_de_visita.ParameterName = "Fecha_de_visita";
                padreFecha_de_visita.DbType = DbType.DateTime;
                padreFecha_de_visita.Value = (object)entity.Fecha_de_visita ?? DBNull.Value;

                var padreHora_de_visita = _dataProvider.GetParameter();
                padreHora_de_visita.ParameterName = "Hora_de_visita";
                padreHora_de_visita.DbType = DbType.String;
                padreHora_de_visita.Value = (object)entity.Hora_de_visita ?? DBNull.Value;
                var padreContenidoId = _dataProvider.GetParameter();
                padreContenidoId.ParameterName = "ContenidoId";
                padreContenidoId.DbType = DbType.Int32;
                padreContenidoId.Value = (object)entity.ContenidoId ?? DBNull.Value;

                var padreUsuarioId = _dataProvider.GetParameter();
                padreUsuarioId.ParameterName = "UsuarioId";
                padreUsuarioId.DbType = DbType.Int32;
                padreUsuarioId.Value = (object)entity.UsuarioId ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsVisitas>("sp_InsVisitas" , padreFolio
, padreFecha_de_visita
, padreHora_de_visita
, padreContenidoId
, padreUsuarioId
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);

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

        public int Update(Spartane.Core.Classes.Visitas.Visitas entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFecha_de_visita = _dataProvider.GetParameter();
                paramUpdFecha_de_visita.ParameterName = "Fecha_de_visita";
                paramUpdFecha_de_visita.DbType = DbType.DateTime;
                paramUpdFecha_de_visita.Value = (object)entity.Fecha_de_visita ?? DBNull.Value;

                var paramUpdHora_de_visita = _dataProvider.GetParameter();
                paramUpdHora_de_visita.ParameterName = "Hora_de_visita";
                paramUpdHora_de_visita.DbType = DbType.String;
                paramUpdHora_de_visita.Value = (object)entity.Hora_de_visita ?? DBNull.Value;
                var paramUpdContenidoId = _dataProvider.GetParameter();
                paramUpdContenidoId.ParameterName = "ContenidoId";
                paramUpdContenidoId.DbType = DbType.Int32;
                paramUpdContenidoId.Value = (object)entity.ContenidoId ?? DBNull.Value;

                var paramUpdUsuarioId = _dataProvider.GetParameter();
                paramUpdUsuarioId.ParameterName = "UsuarioId";
                paramUpdUsuarioId.DbType = DbType.Int32;
                paramUpdUsuarioId.Value = (object)entity.UsuarioId ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdVisitas>("sp_UpdVisitas" , paramUpdFolio , paramUpdFecha_de_visita , paramUpdHora_de_visita , paramUpdContenidoId , paramUpdUsuarioId ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);
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
