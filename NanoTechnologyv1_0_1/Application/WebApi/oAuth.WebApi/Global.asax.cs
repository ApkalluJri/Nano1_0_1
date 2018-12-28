using Autofac;
using Autofac.Core;
using Autofac.Integration.WebApi;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Spartane.Data;
using Spartane.Data.EF;
using Spartane.Services.CustomAuthentication;
using Spartane.Services.TTUsuarios;
using Spartane.Services.TTArchivos;
using Spartane.Services.Registro_de_Usuario;
using Spartane.Services.Registro_de_Contenido;
using Spartane.Services.Categoria;
using Spartane.Services.Observatorio;
using Spartane.Services.Tipo_de_Observatorio;
using Spartane.Services.Detalle_de_Observatorio_Privado;
using Spartane.Services.Estilo_de_Articulo;
using Spartane.Services.Etiquetas;
using Spartane.Services.Detalle_de_Etiquetas;
using Spartane.Services.Solicitudes_Via_App;
using Spartane.Services.Opciones_de_Solicitud_via_App;
using Spartane.Services.Color;
using Spartane.Services.Fuentes;
using Spartane.Services.Detalle_de_Etiquetas_Contenido;
using Spartane.Services.Estatus_de_Contenido;
using Spartane.Services.SubCategoria;
using Spartane.Services.Seccion;
using Spartane.Services.Estatus_Codigo;
using Spartane.Services.Codigos_por_Cliente;
using Spartane.Services.Detalle_de_Codigo_Por_Cliente;
using Spartane.Services.Autorizacion;
using Spartane.Services.Estatus_de_Solicitud_Via_App;
using Spartane.Services.Usuarios_Registrados_en_Observatorios;
using Spartane.Services.Registro_de_Roles;
using Spartane.Services.Rol_de_Usuario;
using Spartane.Services.Detalle_de_Asistentes_de_Observatorio;
using Spartane.Services.Detalle_de_Notificacion_por_Observatorio;
using Spartane.Services.Detalle_de_Notificacion_por_Usuario;
using Spartane.Services.Tipo_de_Dispositivo;
using Spartane.Services.ttusuarios_token;
using Spartane.Services.Visitas;
using Spartane.Services.App;
//**@@INCLUDE_DECLARE@@**//


namespace oAuth.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            var builder = new ContainerBuilder();

            var dataSettigs = new DataSettings();
            dataSettigs.DataConnectionString = "name=DefaultConnection";//"data source=VM-SQL2012-01;initial catalog=spartane;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            dataSettigs.DataProvider = "sqlserver";

            builder.Register(x => new EFDataProviderManager(dataSettigs)).As<BaseDataProviderManager>().InstancePerLifetimeScope();
            builder.Register(x => x.Resolve<BaseDataProviderManager>().LoadDataProvider()).As<IDataProvider>().InstancePerLifetimeScope();
            builder.Register<IDbContext>(c => new TTObjectContext(dataSettigs.DataConnectionString)).InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(EFRepository<>)).As(typeof(IRepository<>));
            builder.RegisterType<TTUsuariosService>().As<ITTUsuariosService>().InstancePerLifetimeScope();
            builder.RegisterType<TTArchivosService>().As<ITTArchivosService>().InstancePerLifetimeScope();
builder.RegisterType<Registro_de_UsuarioService>().As<IRegistro_de_UsuarioService>().InstancePerLifetimeScope();
builder.RegisterType<Registro_de_ContenidoService>().As<IRegistro_de_ContenidoService>().InstancePerLifetimeScope();
builder.RegisterType<CategoriaService>().As<ICategoriaService>().InstancePerLifetimeScope();
builder.RegisterType<ObservatorioService>().As<IObservatorioService>().InstancePerLifetimeScope();
builder.RegisterType<Tipo_de_ObservatorioService>().As<ITipo_de_ObservatorioService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_de_Observatorio_PrivadoService>().As<IDetalle_de_Observatorio_PrivadoService>().InstancePerLifetimeScope();
builder.RegisterType<Estilo_de_ArticuloService>().As<IEstilo_de_ArticuloService>().InstancePerLifetimeScope();
builder.RegisterType<EtiquetasService>().As<IEtiquetasService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_de_EtiquetasService>().As<IDetalle_de_EtiquetasService>().InstancePerLifetimeScope();
builder.RegisterType<Solicitudes_Via_AppService>().As<ISolicitudes_Via_AppService>().InstancePerLifetimeScope();
builder.RegisterType<Opciones_de_Solicitud_via_AppService>().As<IOpciones_de_Solicitud_via_AppService>().InstancePerLifetimeScope();
builder.RegisterType<ColorService>().As<IColorService>().InstancePerLifetimeScope();
builder.RegisterType<FuentesService>().As<IFuentesService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_de_Etiquetas_ContenidoService>().As<IDetalle_de_Etiquetas_ContenidoService>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_de_ContenidoService>().As<IEstatus_de_ContenidoService>().InstancePerLifetimeScope();
builder.RegisterType<SubCategoriaService>().As<ISubCategoriaService>().InstancePerLifetimeScope();
builder.RegisterType<SeccionService>().As<ISeccionService>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_CodigoService>().As<IEstatus_CodigoService>().InstancePerLifetimeScope();
builder.RegisterType<Codigos_por_ClienteService>().As<ICodigos_por_ClienteService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_de_Codigo_Por_ClienteService>().As<IDetalle_de_Codigo_Por_ClienteService>().InstancePerLifetimeScope();
builder.RegisterType<AutorizacionService>().As<IAutorizacionService>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_de_Solicitud_Via_AppService>().As<IEstatus_de_Solicitud_Via_AppService>().InstancePerLifetimeScope();
builder.RegisterType<Usuarios_Registrados_en_ObservatoriosService>().As<IUsuarios_Registrados_en_ObservatoriosService>().InstancePerLifetimeScope();
builder.RegisterType<Registro_de_RolesService>().As<IRegistro_de_RolesService>().InstancePerLifetimeScope();
builder.RegisterType<Rol_de_UsuarioService>().As<IRol_de_UsuarioService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_de_Asistentes_de_ObservatorioService>().As<IDetalle_de_Asistentes_de_ObservatorioService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_de_Notificacion_por_ObservatorioService>().As<IDetalle_de_Notificacion_por_ObservatorioService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_de_Notificacion_por_UsuarioService>().As<IDetalle_de_Notificacion_por_UsuarioService>().InstancePerLifetimeScope();
builder.RegisterType<Tipo_de_DispositivoService>().As<ITipo_de_DispositivoService>().InstancePerLifetimeScope();
builder.RegisterType<ttusuarios_tokenService>().As<Ittusuarios_tokenService>().InstancePerLifetimeScope();
builder.RegisterType<VisitasService>().As<IVisitasService>().InstancePerLifetimeScope();
builder.RegisterType<AppService>().As<IAppService>().InstancePerLifetimeScope();
//**@@INCLUDE_EXPOSE@@**//
            builder.RegisterType<CustomAuthenticationService>().As<ICustomAuthenticationService>().InstancePerLifetimeScope();


            GlobalConfiguration.Configuration.EnsureInitialized();

            //// Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            //// Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //// OPTIONAL: Register the Autofac filter provider.
            //builder.RegisterWebApiFilterProvider(config);

            //// Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);


        }
    }
}
















































































































































































































