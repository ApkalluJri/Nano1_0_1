using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Codigos_por_Cliente;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Codigos_por_Cliente
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Codigos_por_ClienteService : ICodigos_por_ClienteService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Codigos_por_Cliente.Codigos_por_Cliente> _Codigos_por_ClienteRepository;
        #endregion

        #region Ctor
        public Codigos_por_ClienteService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Codigos_por_Cliente.Codigos_por_Cliente> Codigos_por_ClienteRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Codigos_por_ClienteRepository = Codigos_por_ClienteRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Codigos_por_ClienteRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Codigos_por_Cliente.Codigos_por_Cliente> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Codigos_por_Cliente.Codigos_por_Cliente>("sp_SelAllCodigos_por_Cliente");
        }

        public IList<Core.Classes.Codigos_por_Cliente.Codigos_por_Cliente> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallCodigos_por_Cliente_Complete>("sp_SelAllComplete_Codigos_por_Cliente");
            return data.Select(m => new Core.Classes.Codigos_por_Cliente.Codigos_por_Cliente
            {
                Folio = m.Folio
                ,Usuario_que_Registra_TTUsuarios = new Core.Classes.TTUsuarios.TTUsuarios() { IdUsuario = m.Usuario_que_Registra.GetValueOrDefault(), Nombre = m.Usuario_que_Registra_Nombre }
                ,Fecha_de_Registro = m.Fecha_de_Registro
                ,Hora_de_Registro = m.Hora_de_Registro
                ,Cliente = m.Cliente
                ,Contacto = m.Contacto
                ,Correo = m.Correo


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Codigos_por_Cliente>("sp_ListSelCount_Codigos_por_Cliente", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Codigos_por_Cliente.Codigos_por_Cliente> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllCodigos_por_Cliente>("sp_ListSelAll_Codigos_por_Cliente", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Codigos_por_Cliente.Codigos_por_Cliente
                {
                    Folio = m.Codigos_por_Cliente_Folio,
                    Usuario_que_Registra = m.Codigos_por_Cliente_Usuario_que_Registra,
                    Fecha_de_Registro = m.Codigos_por_Cliente_Fecha_de_Registro,
                    Hora_de_Registro = m.Codigos_por_Cliente_Hora_de_Registro,
                    Cliente = m.Codigos_por_Cliente_Cliente,
                    Contacto = m.Codigos_por_Cliente_Contacto,
                    Correo = m.Codigos_por_Cliente_Correo,

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

        public IList<Spartane.Core.Classes.Codigos_por_Cliente.Codigos_por_Cliente> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Codigos_por_ClienteRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Codigos_por_Cliente.Codigos_por_Cliente> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Codigos_por_ClienteRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Codigos_por_Cliente.Codigos_por_ClientePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllCodigos_por_Cliente>("sp_ListSelAll_Codigos_por_Cliente", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Codigos_por_ClientePagingModel result = null;

            if (data != null)
            {
                result = new Codigos_por_ClientePagingModel
                {
                    Codigos_por_Clientes =
                        data.Select(m => new Spartane.Core.Classes.Codigos_por_Cliente.Codigos_por_Cliente
                {
                    Folio = m.Codigos_por_Cliente_Folio
                    ,Usuario_que_Registra = m.Codigos_por_Cliente_Usuario_que_Registra
                    ,Usuario_que_Registra_TTUsuarios = new Core.Classes.TTUsuarios.TTUsuarios() { IdUsuario = m.Codigos_por_Cliente_Usuario_que_Registra.GetValueOrDefault(), Nombre = m.Codigos_por_Cliente_Usuario_que_Registra_Nombre }
                    ,Fecha_de_Registro = m.Codigos_por_Cliente_Fecha_de_Registro
                    ,Hora_de_Registro = m.Codigos_por_Cliente_Hora_de_Registro
                    ,Cliente = m.Codigos_por_Cliente_Cliente
                    ,Contacto = m.Codigos_por_Cliente_Contacto
                    ,Correo = m.Codigos_por_Cliente_Correo

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Codigos_por_Cliente.Codigos_por_Cliente> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Codigos_por_ClienteRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Codigos_por_Cliente.Codigos_por_Cliente GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Codigos_por_Cliente.Codigos_por_Cliente>("sp_GetCodigos_por_Cliente", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelCodigos_por_Cliente>("sp_DelCodigos_por_Cliente", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Codigos_por_Cliente.Codigos_por_Cliente entity)
        {
            int rta;
            try
            {

		                var padreUsuario_que_Registra = _dataProvider.GetParameter();
                padreUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                padreUsuario_que_Registra.DbType = DbType.Int32;
                padreUsuario_que_Registra.Value = (object)entity.Usuario_que_Registra ?? DBNull.Value;

                var padreFecha_de_Registro = _dataProvider.GetParameter();
                padreFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                padreFecha_de_Registro.DbType = DbType.DateTime;
                padreFecha_de_Registro.Value = (object)entity.Fecha_de_Registro ?? DBNull.Value;

                var padreHora_de_Registro = _dataProvider.GetParameter();
                padreHora_de_Registro.ParameterName = "Hora_de_Registro";
                padreHora_de_Registro.DbType = DbType.String;
                padreHora_de_Registro.Value = (object)entity.Hora_de_Registro ?? DBNull.Value;
                var padreCliente = _dataProvider.GetParameter();
                padreCliente.ParameterName = "Cliente";
                padreCliente.DbType = DbType.String;
                padreCliente.Value = (object)entity.Cliente ?? DBNull.Value;
                var padreContacto = _dataProvider.GetParameter();
                padreContacto.ParameterName = "Contacto";
                padreContacto.DbType = DbType.String;
                padreContacto.Value = (object)entity.Contacto ?? DBNull.Value;
                var padreCorreo = _dataProvider.GetParameter();
                padreCorreo.ParameterName = "Correo";
                padreCorreo.DbType = DbType.String;
                padreCorreo.Value = (object)entity.Correo ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsCodigos_por_Cliente>("sp_InsCodigos_por_Cliente" , padreUsuario_que_Registra
, padreFecha_de_Registro
, padreHora_de_Registro
, padreCliente
, padreContacto
, padreCorreo
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

        public int Update(Spartane.Core.Classes.Codigos_por_Cliente.Codigos_por_Cliente entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)entity.Usuario_que_Registra ?? DBNull.Value;

                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)entity.Fecha_de_Registro ?? DBNull.Value;

                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)entity.Hora_de_Registro ?? DBNull.Value;
                var paramUpdCliente = _dataProvider.GetParameter();
                paramUpdCliente.ParameterName = "Cliente";
                paramUpdCliente.DbType = DbType.String;
                paramUpdCliente.Value = (object)entity.Cliente ?? DBNull.Value;
                var paramUpdContacto = _dataProvider.GetParameter();
                paramUpdContacto.ParameterName = "Contacto";
                paramUpdContacto.DbType = DbType.String;
                paramUpdContacto.Value = (object)entity.Contacto ?? DBNull.Value;
                var paramUpdCorreo = _dataProvider.GetParameter();
                paramUpdCorreo.ParameterName = "Correo";
                paramUpdCorreo.DbType = DbType.String;
                paramUpdCorreo.Value = (object)entity.Correo ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdCodigos_por_Cliente>("sp_UpdCodigos_por_Cliente" , paramUpdFolio , paramUpdUsuario_que_Registra , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdCliente , paramUpdContacto , paramUpdCorreo ).FirstOrDefault();

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
