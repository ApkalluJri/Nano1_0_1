using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
//using Autofac.Integration.WebApi;
using System.Web.Mvc;
using Spartane.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Core.Domain;
using Spartane.Services.Security;
using Spartane.Services.Authentication;
using Spartane.Services.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.SpartaneFile;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.SpartaneFunction;
using Spartane.Web.Areas.WebApiConsumer.SpartaneObject;
using Spartane.Web.Areas.WebApiConsumer.SpartaneUserRoleObjectFunction;
using Spartane.Web.Areas.WebApiConsumer.GeneratePDF;
using Spartane.Web.Controllers;
using Spartane.Core.Domain.Binnacle;
using Spartane.Core.Domain.User;
using Spartane.Services.Spartan_Format;
using Spartane.Core.Domain.Spartan_Format;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format;
using Spartane.Services.Spartan_Format_Type;
using Spartane.Core.Domain.Spartan_Format_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Type;
using Spartane.Services.Spartan_Metadata;
using Spartane.Core.Domain.Spartan_Metadata;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Metadata;
using Spartane.Services.Spartan_Format_Configuration;
using Spartane.Core.Domain.Spartan_Format_Configuration;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Configuration;
using Spartane.Services.Spartan_Format_Field;
using Spartane.Core.Domain.Spartan_Format_Field;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Field;
using Spartane.Services.Spartan_Format_Permission_Type;
using Spartane.Core.Domain.Spartan_Format_Permission_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Permission_Type;
using Spartane.Services.Spartan_Format_Permissions;
using Spartane.Core.Domain.Spartan_Format_Permissions;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Permissions;
using Spartane.Services.Spartan_Report;
using Spartane.Core.Domain.Spartan_Report;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report;
using Spartane.Services.Spartan_Report_Field_Type;
using Spartane.Core.Domain.Spartan_Report_Field_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Field_Type;
using Spartane.Services.Spartan_Report_Fields_Detail;
using Spartane.Core.Domain.Spartan_Report_Fields_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Fields_Detail;
using Spartane.Services.Spartan_Report_Format;
using Spartane.Core.Domain.Spartan_Report_Format;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Format;
using Spartane.Services.Spartan_Report_Function;
using Spartane.Core.Domain.Spartan_Report_Function;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Function;
using Spartane.Services.Spartan_Report_Order_Type;
using Spartane.Core.Domain.Spartan_Report_Order_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Order_Type;
using Spartane.Services.Spartan_Report_Permission_Type;
using Spartane.Core.Domain.Spartan_Report_Permission_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Permission_Type;
using Spartane.Services.Spartan_Report_Permissions;
using Spartane.Core.Domain.Spartan_Report_Permissions;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Permissions;
using Spartane.Services.Spartan_Report_Presentation_Type;
using Spartane.Core.Domain.Spartan_Report_Presentation_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Presentation_Type;
using Spartane.Services.Spartan_Report_Presentation_View;
using Spartane.Core.Domain.Spartan_Report_Presentation_View;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Presentation_View;
using Spartane.Services.Spartan_Report_Status;
using Spartane.Core.Domain.Spartan_Report_Status;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Status;

using Spartane.Services.Spartan_User;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Services.Spartan_User_Role;
using Spartane.Core.Domain.Spartan_User_Role;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User_Role;
using Spartane.Services.Spartan_User_Role_Status;
using Spartane.Core.Domain.Spartan_User_Role_Status;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User_Role_Status;
using Spartane.Services.Spartan_User_Status;
using Spartane.Core.Domain.Spartan_User_Status;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User_Status;


using Spartane.Services.Spartan_Traduction_Concept_Type;
using Spartane.Core.Domain.Spartan_Traduction_Concept_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Concept_Type;
using Spartane.Services.Spartan_Traduction_Detail;
using Spartane.Core.Domain.Spartan_Traduction_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Detail;
using Spartane.Services.Spartan_Traduction_Language;
using Spartane.Core.Domain.Spartan_Traduction_Language;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Language;
using Spartane.Services.Spartan_Traduction_Object;
using Spartane.Core.Domain.Spartan_Traduction_Object;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Object;
using Spartane.Services.Spartan_Traduction_Object_Type;
using Spartane.Core.Domain.Spartan_Traduction_Object_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Object_Type;
using Spartane.Services.Spartan_Traduction_Process;
using Spartane.Core.Domain.Spartan_Traduction_Process;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Process;
using Spartane.Services.SpartanObject;
using Spartane.Core.Domain.SpartanObject;
using Spartane.Web.Areas.WebApiConsumer.SpartanObject;

//**@@INCLUDE_DECLARE@@**//
using Spartane.Services.Events;
using Spartane.Data.EF;
using System.Web.Http;
using System.Web;
using Autofac.Integration.WebApi;
using Spartane.Services.User.Mock;
using Spartane.Services.Security.Mock;
using Spartane.Core.Domain.Security;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.SpartanModule;
using Spartane.Web.Areas.WebApiConsumer.SpartanUserRoleModule;
using Spartane.Web.Areas.WebApiConsumer.SpartaneModuleObject;
using Spartane.Web.Areas.WebApiConsumer.SpartaneUserRoleModuleObject;
using Spartane.Services.TTArchivos;
using Spartane.Web.Areas.WebApiConsumer.SpartaneQuery;
/*Business Rules*/
using Spartane.Core.Domain.Spartan_BR_Action;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action;
using Spartane.Core.Domain.Spartan_BR_Attribute_Restrictions_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Attribute_Restrictions_Detail;
using Spartane.Core.Domain.Spartan_BR_Action_Classification;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action_Classification;
using Spartane.Core.Domain.Spartan_BR_Action_Configuration_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action_Configuration_Detail;
using Spartane.Core.Domain.Spartan_BR_Event_Restrictions_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Event_Restrictions_Detail;
using Spartane.Core.Domain.Spartan_BR_Actions_False_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Actions_False_Detail;
using Spartane.Core.Domain.Spartan_BR_Operation_Restrictions_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Operation_Restrictions_Detail;
using Spartane.Core.Domain.Spartan_BR_Action_Param_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action_Param_Type;
using Spartane.Core.Domain.Spartan_BR_Action_Result;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action_Result;
using Spartane.Core.Domain.Spartan_BR_Actions_True_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Actions_True_Detail;
using Spartane.Core.Domain.Spartan_BR_Condition;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Condition;
using Spartane.Core.Domain.Spartan_BR_Condition_Operator;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Condition_Operator;
using Spartane.Core.Domain.Spartan_BR_Conditions_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Conditions_Detail;
using Spartane.Core.Domain.Spartan_BR_Operation;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Operation;
using Spartane.Core.Domain.Spartan_BR_Operation_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Operation_Detail;
using Spartane.Core.Domain.Spartan_BR_Operator_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Operator_Type;
using Spartane.Core.Domain.Spartan_BR_Presentation_Control_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Presentation_Control_Type;
using Spartane.Core.Domain.Spartan_BR_Process_Event;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Process_Event;
using Spartane.Core.Domain.Spartan_BR_Process_Event_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Process_Event_Detail;
using Spartane.Core.Domain.Spartan_BR_Scope;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Scope;
using Spartane.Core.Domain.Spartan_BR_Scope_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Scope_Detail;
using Spartane.Core.Domain.Spartan_BR_Status;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Status;
using Spartane.Core.Domain.Spartan_BR_Modifications_Log;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Modifications_Log;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Business_Rule;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Attribute_Control_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Attribute_Type;
using Spartane.Services.Spartan_Attribute_Control_Type;
using Spartane.Services.Spartan_Attribute_Type;
using Spartane.Services.Spartan_Business_Rule;
using Spartane.Services.Spartan_BR_Action;
using Spartane.Services.Spartan_BR_Attribute_Restrictions_Detail;
using Spartane.Services.Spartan_BR_Action_Classification;
using Spartane.Services.Spartan_BR_Action_Configuration_Detail;
using Spartane.Services.Spartan_BR_Event_Restrictions_Detail;
using Spartane.Services.Spartan_BR_Actions_False_Detail;
using Spartane.Services.Spartan_BR_Operation_Restrictions_Detail;
using Spartane.Services.Spartan_BR_Action_Param_Type;
using Spartane.Services.Spartan_BR_Action_Result;
using Spartane.Services.Spartan_BR_Actions_True_Detail;
using Spartane.Services.Spartan_BR_Condition;
using Spartane.Services.Spartan_BR_Condition_Operator;
using Spartane.Services.Spartan_BR_Conditions_Detail;
using Spartane.Services.Spartan_BR_Operation;
using Spartane.Services.Spartan_BR_Operation_Detail;
using Spartane.Services.Spartan_BR_Operator_Type;
using Spartane.Services.Spartan_BR_Presentation_Control_Type;
using Spartane.Services.Spartan_BR_Process_Event;
using Spartane.Services.Spartan_BR_Process_Event_Detail;
using Spartane.Services.Spartan_BR_Scope;
using Spartane.Services.Spartan_BR_Scope_Detail;
using Spartane.Services.Spartan_BR_Status;
using Spartane.Services.Spartan_BR_Modifications_Log;


namespace Spartane.Web
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            //HTTP context and other related stuff
            builder.Register(c =>
                new HttpContextWrapper(HttpContext.Current) as HttpContextBase)
                .As<HttpContextBase>()
                .InstancePerLifetimeScope();
            
            // Register dependencies in controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Register dependencies in filter attributes
            builder.RegisterFilterProvider();

            // Register dependencies in custom views
            builder.RegisterSource(new ViewRegistrationSource());

            // Register our Data dependencies
            builder.RegisterControllers();
           
            //data layer
            var dataSettigs = new DataSettings();
            dataSettigs.DataConnectionString = "name=spartaneEntities";//"data source=VM-SQL2012-01;initial catalog=spartane;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            dataSettigs.DataProvider = "sqlserver";
            builder.Register(x => new EFDataProviderManager(dataSettigs)).As<BaseDataProviderManager>().InstancePerLifetimeScope();
            builder.Register(x => x.Resolve<BaseDataProviderManager>().LoadDataProvider()).As<IDataProvider>().InstancePerLifetimeScope();
            builder.Register<IDbContext>(c => new TTObjectContext(dataSettigs.DataConnectionString)).InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(EFRepository<>)).As(typeof(IRepository<>));
            
            builder.RegisterType<PermissionService>().As<IPermissionService>().InstancePerLifetimeScope();
            builder.RegisterType<ModulesData>().As<BaseEntity>().InstancePerLifetimeScope();

            builder.RegisterType<Spartane.Core.Domain.User.GlobalData>();
            builder.RegisterType<DataLayerFieldsBitacora>();

            builder.RegisterType<Spartan_Module>();
            
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<MockSpartanUserService>().As<ISpartanUserService>().InstancePerLifetimeScope();
            

            //New Addons
            builder.RegisterType<AuthenticationApiConsumer>().As<IAuthenticationApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<TokenManager>().As<ITokenManager>().InstancePerLifetimeScope();
            builder.RegisterType<SpartaneFileApiConsumer>().As<ISpartaneFileApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartane_FileApiConsumer>().As<ISpartane_FileApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_FormatService>().As<ISpartan_FormatService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_FormatApiConsumer>().As<ISpartan_FormatApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Format_TypeService>().As<ISpartan_Format_TypeService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Format_TypeApiConsumer>().As<ISpartan_Format_TypeApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_MetadataService>().As<ISpartan_MetadataService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_MetadataApiConsumer>().As<ISpartan_MetadataApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Format_ConfigurationService>().As<ISpartan_Format_ConfigurationService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Format_ConfigurationApiConsumer>().As<ISpartan_Format_ConfigurationApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Format_FieldService>().As<ISpartan_Format_FieldService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Format_FieldApiConsumer>().As<ISpartan_Format_FieldApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Format_Permission_TypeService>().As<ISpartan_Format_Permission_TypeService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Format_Permission_TypeApiConsumer>().As<ISpartan_Format_Permission_TypeApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Format_PermissionsService>().As<ISpartan_Format_PermissionsService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Format_PermissionsApiConsumer>().As<ISpartan_Format_PermissionsApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_ReportService>().As<ISpartan_ReportService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_ReportApiConsumer>().As<ISpartan_ReportApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Field_TypeService>().As<ISpartan_Report_Field_TypeService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Field_TypeApiConsumer>().As<ISpartan_Report_Field_TypeApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Fields_DetailService>().As<ISpartan_Report_Fields_DetailService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Fields_DetailApiConsumer>().As<ISpartan_Report_Fields_DetailApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_FormatService>().As<ISpartan_Report_FormatService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_FormatApiConsumer>().As<ISpartan_Report_FormatApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_FunctionService>().As<ISpartan_Report_FunctionService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_FunctionApiConsumer>().As<ISpartan_Report_FunctionApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Order_TypeService>().As<ISpartan_Report_Order_TypeService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Order_TypeApiConsumer>().As<ISpartan_Report_Order_TypeApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Permission_TypeService>().As<ISpartan_Report_Permission_TypeService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Permission_TypeApiConsumer>().As<ISpartan_Report_Permission_TypeApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_PermissionsService>().As<ISpartan_Report_PermissionsService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_PermissionsApiConsumer>().As<ISpartan_Report_PermissionsApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Presentation_TypeService>().As<ISpartan_Report_Presentation_TypeService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Presentation_TypeApiConsumer>().As<ISpartan_Report_Presentation_TypeApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Presentation_ViewService>().As<ISpartan_Report_Presentation_ViewService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Presentation_ViewApiConsumer>().As<ISpartan_Report_Presentation_ViewApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_StatusService>().As<ISpartan_Report_StatusService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_StatusApiConsumer>().As<ISpartan_Report_StatusApiConsumer>().InstancePerLifetimeScope();
//**@@INCLUDE_EXPOSE@@**//            

            builder.RegisterType<SpartanModuleApiConsumer>().As<ISpartanModuleApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<SpartanUserRoleModuleApiConsumer>().As<ISpartanUserRoleModuleApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<SpartaneModuleObjectApiConsumer>().As<ISpartaneModuleObjectApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<SpartaneUserRoleModuleObjectApiConsumer>().As<ISpartaneUserRoleModuleObjectApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<SpartaneObjectApiConsumer>().As<ISpartaneObjectApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<SpartaneUserRoleObjectFunctionApiConsumer>().As<ISpartaneUserRoleObjectFunctionApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<LanguageApiConsumer>().As<ILanguageApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<SpartanSecurityApiConsumer>().As<ISpartanSecurityApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<SpartanSessionApiConsumer>().As<ISpartanSessionApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<SpartaneUserRoleObjectFunctionApiConsumer>().As<ISpartaneUserRoleObjectFunctionApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<SpartaneFunctionApiConsumer>().As<ISpartaneFunctionApiConsumer>().InstancePerLifetimeScope();
            //Till Here
            builder.RegisterType<TTArchivosService>().As<ITTArchivosService>().InstancePerLifetimeScope();

            //builder.RegisterType<MockSpartanDepartamentoService>().As<ISpartanDepartamentoService>().InstancePerLifetimeScope();

            builder.RegisterType<MockSpartanModuleService>().As<ISpartanModuleService>().InstancePerLifetimeScope().PreserveExistingDefaults();

            builder.RegisterType<FormsAuthenticationService>().As<IAuthenticationService>().InstancePerLifetimeScope();
            builder.RegisterType<SpartaneQueryApiConsumer>().As<ISpartaneQueryApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Attribute_Control_TypeService>().As<ISpartan_Attribute_Control_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Attribute_Control_TypeApiConsumer>().As<ISpartan_Attribute_Control_TypeApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Attribute_TypeService>().As<ISpartan_Attribute_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Attribute_TypeApiConsumer>().As<ISpartan_Attribute_TypeApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Business_RuleService>().As<ISpartan_Business_RuleService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Business_RuleApiConsumer>().As<ISpartan_Business_RuleApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_ActionService>().As<ISpartan_BR_ActionService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_ActionApiConsumer>().As<ISpartan_BR_ActionApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Attribute_Restrictions_DetailService>().As<ISpartan_BR_Attribute_Restrictions_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Attribute_Restrictions_DetailApiConsumer>().As<ISpartan_BR_Attribute_Restrictions_DetailApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Action_ClassificationService>().As<ISpartan_BR_Action_ClassificationService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Action_ClassificationApiConsumer>().As<ISpartan_BR_Action_ClassificationApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Action_Configuration_DetailService>().As<ISpartan_BR_Action_Configuration_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Action_Configuration_DetailApiConsumer>().As<ISpartan_BR_Action_Configuration_DetailApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Event_Restrictions_DetailService>().As<ISpartan_BR_Event_Restrictions_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Event_Restrictions_DetailApiConsumer>().As<ISpartan_BR_Event_Restrictions_DetailApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Actions_False_DetailService>().As<ISpartan_BR_Actions_False_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Actions_False_DetailApiConsumer>().As<ISpartan_BR_Actions_False_DetailApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Operation_Restrictions_DetailService>().As<ISpartan_BR_Operation_Restrictions_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Operation_Restrictions_DetailApiConsumer>().As<ISpartan_BR_Operation_Restrictions_DetailApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Action_Param_TypeService>().As<ISpartan_BR_Action_Param_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Action_Param_TypeApiConsumer>().As<ISpartan_BR_Action_Param_TypeApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Action_ResultService>().As<ISpartan_BR_Action_ResultService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Action_ResultApiConsumer>().As<ISpartan_BR_Action_ResultApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Actions_True_DetailService>().As<ISpartan_BR_Actions_True_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Actions_True_DetailApiConsumer>().As<ISpartan_BR_Actions_True_DetailApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_ConditionService>().As<ISpartan_BR_ConditionService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_ConditionApiConsumer>().As<ISpartan_BR_ConditionApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Condition_OperatorService>().As<ISpartan_BR_Condition_OperatorService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Condition_OperatorApiConsumer>().As<ISpartan_BR_Condition_OperatorApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Conditions_DetailService>().As<ISpartan_BR_Conditions_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Conditions_DetailApiConsumer>().As<ISpartan_BR_Conditions_DetailApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_OperationService>().As<ISpartan_BR_OperationService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_OperationApiConsumer>().As<ISpartan_BR_OperationApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Operation_DetailService>().As<ISpartan_BR_Operation_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Operation_DetailApiConsumer>().As<ISpartan_BR_Operation_DetailApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Operator_TypeService>().As<ISpartan_BR_Operator_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Operator_TypeApiConsumer>().As<ISpartan_BR_Operator_TypeApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Presentation_Control_TypeService>().As<ISpartan_BR_Presentation_Control_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Presentation_Control_TypeApiConsumer>().As<ISpartan_BR_Presentation_Control_TypeApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Process_EventService>().As<ISpartan_BR_Process_EventService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Process_EventApiConsumer>().As<ISpartan_BR_Process_EventApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Process_Event_DetailService>().As<ISpartan_BR_Process_Event_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Process_Event_DetailApiConsumer>().As<ISpartan_BR_Process_Event_DetailApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_ScopeService>().As<ISpartan_BR_ScopeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_ScopeApiConsumer>().As<ISpartan_BR_ScopeApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Scope_DetailService>().As<ISpartan_BR_Scope_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Scope_DetailApiConsumer>().As<ISpartan_BR_Scope_DetailApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_StatusService>().As<ISpartan_BR_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_StatusApiConsumer>().As<ISpartan_BR_StatusApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Modifications_LogService>().As<ISpartan_BR_Modifications_LogService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Modifications_LogApiConsumer>().As<ISpartan_BR_Modifications_LogApiConsumer>().InstancePerLifetimeScope();


            builder.RegisterType<Spartan_ReportService>().As<ISpartan_ReportService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_ReportApiConsumer>().As<ISpartan_ReportApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Report_Presentation_TypeService>().As<ISpartan_Report_Presentation_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Report_Presentation_TypeApiConsumer>().As<ISpartan_Report_Presentation_TypeApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Report_Presentation_ViewService>().As<ISpartan_Report_Presentation_ViewService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Report_Permission_TypeService>().As<ISpartan_Report_Permission_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Report_Permission_TypeApiConsumer>().As<ISpartan_Report_Permission_TypeApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Report_PermissionsService>().As<ISpartan_Report_PermissionsService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Report_PermissionsApiConsumer>().As<ISpartan_Report_PermissionsApiConsumer>().InstancePerLifetimeScope();
			
			
			builder.RegisterType<Spartan_UserService>().As<ISpartan_UserService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_UserApiConsumer>().As<ISpartan_UserApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_RoleService>().As<ISpartan_User_RoleService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_RoleApiConsumer>().As<ISpartan_User_RoleApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_Role_StatusService>().As<ISpartan_User_Role_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_Role_StatusApiConsumer>().As<ISpartan_User_Role_StatusApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_StatusService>().As<ISpartan_User_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_StatusApiConsumer>().As<ISpartan_User_StatusApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<Spartan_Traduction_Concept_TypeService>().As<ISpartan_Traduction_Concept_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_Concept_TypeApiConsumer>().As<ISpartan_Traduction_Concept_TypeApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_DetailService>().As<ISpartan_Traduction_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_DetailApiConsumer>().As<ISpartan_Traduction_DetailApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_LanguageService>().As<ISpartan_Traduction_LanguageService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_LanguageApiConsumer>().As<ISpartan_Traduction_LanguageApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_ObjectService>().As<ISpartan_Traduction_ObjectService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_ObjectApiConsumer>().As<ISpartan_Traduction_ObjectApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_Object_TypeService>().As<ISpartan_Traduction_Object_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_Object_TypeApiConsumer>().As<ISpartan_Traduction_Object_TypeApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_ProcessService>().As<ISpartan_Traduction_ProcessService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_ProcessApiConsumer>().As<ISpartan_Traduction_ProcessApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<SpartanObjectService>().As<ISpartanObjectService>().InstancePerLifetimeScope();
            builder.RegisterType<SpartanObjectApiConsumer>().As<ISpartanObjectApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<FormsAuthenticationService>().As<IAuthenticationService>().InstancePerLifetimeScope();
            builder.RegisterType<GeneratePDFApiConsumer>().As<IGeneratePDFApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<HomeController>().As<Controller>();
            var container = builder.Build();

            // Set MVC DI resolver to use our Autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //var resolver = new AutofacWebApiDependencyResolver(container);
            //config.DependencyResolver = resolver; 
        }

    }
}
