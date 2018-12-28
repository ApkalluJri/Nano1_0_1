using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.App;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;
using Spartane.Core.Classes.TTArchivos;
using Spartane.Services.TTArchivos;
using System.Configuration;
using System.Text;
using Spartane.Core.Classes.InputFile;
using System.IO;
using System.Drawing;
using System.Web;


namespace Spartane.Services.App
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class AppService : IAppService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.App.App> _AppRepository;
        #endregion

        #region Ctor
        public AppService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.App.App> AppRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._AppRepository = AppRepository;


        }
        #endregion

        private List<Spartane.Core.Classes.App.AppObservatorio> GetObservatorios(int Folio,string uri,string ArchivosFiles)
        {
            var varFolio = _dataProvider.GetParameter();
            varFolio.ParameterName = "Folio";
            varFolio.DbType = DbType.Int32;
            varFolio.Value = Folio;

            var data = new List<Spartane.Core.Classes.App.AppObservatorio>();
            var result = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpSelObservatorioContenido>("SpSelObservatorioContenido", varFolio);
                data = result.Select(m => new Spartane.Core.Classes.App.AppObservatorio
                {
                    Descripcion=m.Descripcion,
                    Color=m.Color,
                    Icono=GetFile(m.IconoFolio.ToString(),m.Icono,uri,ArchivosFiles)
                }).ToList();
            return data;            
        }

        private List<Spartane.Core.Classes.App.AppEtiqueta> GetEtiquetas(int Folio)
        {
            var varFolio = _dataProvider.GetParameter();
            varFolio.ParameterName = "Folio";
            varFolio.DbType = DbType.Int32;
            varFolio.Value = Folio;

            var data = new List<Spartane.Core.Classes.App.AppEtiqueta>();
            var result = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpSelEtiquetaContenido>("SpSelEtiquetaContenido", varFolio);
                data = result.Select(m => new Spartane.Core.Classes.App.AppEtiqueta
                {
                   Descripcion=m.Descripcion
                }).ToList();
            return data;            
        }

        private string GetFile(string FolioId,string NombreArchivo, string uri,string ArchivosFiles)
        {
            string url = "";
            if (FolioId != "")
            {
                if (!File.Exists(System.Web.Hosting.HostingEnvironment.MapPath("~" + ArchivosFiles + NombreArchivo)))//HttpContext.Current.Server.MapPath("~" + ArchivosFiles + NombreArchivo)))
                {
                    IList<GetTTArchivos> entity = new List<GetTTArchivos>();
                    var FolioTT = _dataProvider.GetParameter();
                    FolioTT.ParameterName = "Folio";
                    FolioTT.DbType = DbType.String;
                    FolioTT.Value = FolioId;
                    entity= _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.TTArchivos.GetTTArchivos>("usp_SelAllTTArchivosById", FolioTT);
                    for (int i = 0; i < entity.Count; i++)
                    {
                        entity[0].ArchivoURL = uri + ArchivosFiles + entity[0].Nombre;
                        url = entity[0].ArchivoURL;
                        if (!File.Exists(System.Web.Hosting.HostingEnvironment.MapPath("~" + ArchivosFiles + entity[0].Nombre)))//HttpContext.Current.Server.MapPath("~" + ArchivosFiles + entity[0].Nombre)))
                        {
                            using (FileStream o = new FileStream(System.Web.Hosting.HostingEnvironment.MapPath("~" + ArchivosFiles + entity[i].Nombre), FileMode.CreateNew))//HttpContext.Current.Server.MapPath("~" + ArchivosFiles + entity[i].Nombre), FileMode.CreateNew))
                            {
                                o.Write(entity[i].Archivo, 0, entity[i].Archivo.Length);
                            }
                        }

                    }
                }
                else
                {
                    url = uri + ArchivosFiles + NombreArchivo;

                }
            }
            return url;
        }

        public Spartane.Core.Classes.App.AppPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order, string uri, string ArchivosFiles)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllApp>("sp_ListSelAll_App", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            AppPagingModel result = null;

            if (data != null)
            {
                result = new AppPagingModel
                {
                    Apps =
                        data.Select(m => new Spartane.Core.Classes.App.App
                {
                    Folio =m.FolioContenido,
                    Titulo =m.titulo,
                    Descripcion=m.descripcion,
                    ImagenMiniatura = GetFile(m.ImagenMiniaturaFolio.ToString(), m.Imagen_Miniatura,uri, ArchivosFiles),
                    Estilo=m.estilo,
                    PDF = GetFile(m.PDFFolio.ToString(),m.PDF, uri,ArchivosFiles),
                    CategoriaDescripcion=m.CategoriaDescripcion,
                    CategoriaIcono = GetFile(m.CategoriaIconoFolio.ToString(), m.CategoriaIcono,uri, ArchivosFiles),
                    CategoriaColorIcono =m.CategoriaColorIcono,
                    CategoriaImagen = GetFile(m.CategoriaImagenFolio.ToString(), m.CategoriaImagen,uri, ArchivosFiles),
                    Observatorios =GetObservatorios(m.FolioContenido,uri,ArchivosFiles),
                    Etiquetas =GetEtiquetas(m.FolioContenido)
                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }




    }
}

