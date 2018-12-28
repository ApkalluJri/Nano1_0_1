using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.TTArchivos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;
using System.Drawing;
using System.IO;

namespace Spartane.Services.TTArchivos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class TTArchivosService : ITTArchivosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private List<Spartane.Core.Classes.TTArchivos.TTArchivos> _TTArchivos;
        private readonly IRepository<Spartane.Core.Classes.TTArchivos.TTArchivos> _TTArchivosRepository;
        #endregion

        #region Ctor
        /// <summary>
        /// Constructor for service class
        /// </summary>
        /// <param name="dataProvider"></param>
        /// <param name="dbContext"></param>
        /// <param name="TTArchivosRepository"></param>
        public TTArchivosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.TTArchivos.TTArchivos> TTArchivosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._TTArchivosRepository = TTArchivosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._TTArchivosRepository.Table.Count();
        }

        /// <summary>
        /// Get list of Files and insert with Archivos. Return Archivos Entity listing
        /// </summary>
        /// <param name="FileList"></param>
        /// <returns></returns>
        public List<Spartane.Core.Classes.TTArchivos.TTArchivos> Insert(List<Spartane.Core.Classes.InputFile.InputFile> FileList)
        {
            List<Spartane.Core.Classes.TTArchivos.TTArchivos> ArchivosList = new List<Core.Classes.TTArchivos.TTArchivos>();

            try
            {                
                for (int i = 0; i < FileList.Count; i++)
                {
                    // Add Nombre Param
                    var NombreTT = _dataProvider.GetParameter();
                    NombreTT.ParameterName = "Nombre";
                    NombreTT.DbType = DbType.String;
                    if (FileList[i].FileName == null)
                        NombreTT.Value = DBNull.Value;
                    else
                        NombreTT.Value = FileList[i].FileName;

                    // Add Archivo Param
                    var ArchivoTT = _dataProvider.GetParameter();
                    ArchivoTT.ParameterName = "Archivo";
                    ArchivoTT.DbType = DbType.Binary;                    

                    if (FileList[i].FileArray == null)
                        ArchivoTT.Value = DBNull.Value;
                    else
                        ArchivoTT.Value = FileList[i].FileArray;

                    // Call stored procedure for Insert records
                    var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.usp_InsertTTArchivos>("usp_InsertTTArchivos", NombreTT, ArchivoTT).FirstOrDefault();

                    // Add response list of archivos
                    ArchivosList.Add(new Spartane.Core.Classes.TTArchivos.TTArchivos { Folio = empEntity.Folio, Nombre = empEntity.Nombre });
                 }
                
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return ArchivosList;
        }

        /// <summary>
        /// Get List of Archivos Record
        /// </summary>
        /// <param name="ConRelaciones"></param>
        /// <returns></returns>
        public IList<Spartane.Core.Classes.TTArchivos.GetTTArchivos> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.TTArchivos.GetTTArchivos>("usp_SelAllTTArchivos");
        }

        public IList<Spartane.Core.Classes.TTArchivos.GetTTArchivos> SelAll(bool ConRelaciones, string FolioId)
        {
            var FolioTT = _dataProvider.GetParameter();
            FolioTT.ParameterName = "Folio";
            FolioTT.DbType = DbType.String;
            if (string.IsNullOrEmpty(FolioId))
                FolioTT.Value = DBNull.Value;
            else
                FolioTT.Value = FolioId;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.TTArchivos.GetTTArchivos>("usp_SelAllTTArchivosById", FolioTT);
        }

        /// <summary>
        /// Update List of Archivos records
        /// </summary>
        /// <param name="ArchivosList"></param>
        /// <returns></returns>
        public List<Spartane.Core.Classes.TTArchivos.TTArchivos> Update(List<Spartane.Core.Classes.TTArchivos.TTArchivos> ArchivosList)
        {
            List<Spartane.Core.Classes.TTArchivos.TTArchivos> ArchivosOutputList = new List<Core.Classes.TTArchivos.TTArchivos>();

            try
            {
                for (int i = 0; i < ArchivosList.Count; i++)
                {
                    var NombreTT = _dataProvider.GetParameter();
                    NombreTT.ParameterName = "Nombre";
                    NombreTT.DbType = DbType.String;
                    if (ArchivosList[i].Nombre == null)
                        NombreTT.Value = DBNull.Value;
                    else
                        NombreTT.Value = ArchivosList[i].Nombre;

                    var ArchivoTT = _dataProvider.GetParameter();
                    ArchivoTT.ParameterName = "Archivo";
                    ArchivoTT.DbType = DbType.Binary;

                    if (ArchivosList[i].Archivo == null)
                        ArchivoTT.Value = DBNull.Value;
                    else
                        ArchivoTT.Value = ArchivosList[i].Archivo;

                    var FolioTT = _dataProvider.GetParameter();
                    FolioTT.ParameterName = "Folio";
                    FolioTT.DbType = DbType.Int32;

                    if (ArchivosList[i].Folio == null)
                        FolioTT.Value = DBNull.Value;
                    else
                        FolioTT.Value = ArchivosList[i].Folio;

                    var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.usp_InsertTTArchivos>("usp_UpdateTTArchivos", NombreTT, ArchivoTT, FolioTT).FirstOrDefault();

                    ArchivosOutputList.Add(new Spartane.Core.Classes.TTArchivos.TTArchivos { Folio = empEntity.Folio, Nombre = empEntity.Nombre });
                }

            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return ArchivosOutputList;
        }

        #endregion
    }
}

