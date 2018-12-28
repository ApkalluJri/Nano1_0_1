using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Spartan_Report;
using Spartane.Core.Domain.Spartan_Report_Presentation_Type;
using Spartane.Core.Domain.Spartan_Report_Presentation_View;
using Spartane.Core.Domain.Spartan_Report_Status;
using Spartane.Core.Domain.Spartan_Report_Fields_Detail;
using Spartane.Core.Domain.Spartan_Report_Function;
using Spartane.Core.Domain.Spartan_Report_Format;
using Spartane.Core.Domain.Spartan_Report_Order_Type;
using Spartane.Core.Domain.Spartan_Report_Field_Type;
using Spartane.Core.Domain.Spartan_Metadata;


using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Spartan_Report;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Presentation_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Presentation_View;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Status;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Fields_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Function;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Format;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Order_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Field_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Metadata;
using Spartane.Web.Areas.WebApiConsumer.SpartaneObject;

using Spartane.Web.AuthFilters;
using Spartane.Web.Helpers;
using Spartane.Web.Models;
using Spartane.Web.SqlModelMapper;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System.IO;
using Newtonsoft.Json;
using Spartane.Core.Domain.Spartan_Business_Rule;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Business_Rule;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Process_Event_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Permissions;

namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class Spartan_ReportController : Controller
    {
        #region "variable declaration"

        private ISpartan_ReportService service = null;
        private ISpartan_ReportApiConsumer _ISpartan_ReportApiConsumer;
        private ISpartan_Report_PermissionsApiConsumer _ISpartan_Report_PermissionsApiConsumer;
        private ISpartan_Report_Presentation_TypeApiConsumer _ISpartan_Report_Presentation_TypeApiConsumer;
        private ISpartan_Report_Presentation_ViewApiConsumer _ISpartan_Report_Presentation_ViewApiConsumer;
        private ISpartan_Report_StatusApiConsumer _ISpartan_Report_StatusApiConsumer;
        private ISpartan_Report_Fields_DetailApiConsumer _ISpartan_Report_Fields_DetailApiConsumer;
        private ISpartan_Report_FunctionApiConsumer _ISpartan_Report_FunctionApiConsumer;
        private ISpartan_Report_FormatApiConsumer _ISpartan_Report_FormatApiConsumer;
        private ISpartan_Report_Order_TypeApiConsumer _ISpartan_Report_Order_TypeApiConsumer;
        private ISpartan_Report_Field_TypeApiConsumer _ISpartan_Report_Field_TypeApiConsumer;
        private ISpartan_MetadataApiConsumer _ISpartan_MetadataApiConsumer;

        private ISpartaneObjectApiConsumer _ISpartaneObjectApiConsumer;
        private ISpartan_UserApiConsumer _IUserApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"


        public Spartan_ReportController(ISpartan_ReportService service, ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ISpartan_ReportApiConsumer Spartan_ReportApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_Report_Presentation_TypeApiConsumer Spartan_Report_Presentation_TypeApiConsumer, ISpartan_Report_Presentation_ViewApiConsumer Spartan_Report_Presentation_ViewApiConsumer, ISpartan_Report_StatusApiConsumer Spartan_Report_StatusApiConsumer, ISpartan_Report_Fields_DetailApiConsumer Spartan_Report_Fields_DetailApiConsumer, ISpartan_Report_FunctionApiConsumer Spartan_Report_FunctionApiConsumer, ISpartan_Report_FormatApiConsumer Spartan_Report_FormatApiConsumer, ISpartan_Report_Order_TypeApiConsumer Spartan_Report_Order_TypeApiConsumer, ISpartan_Report_Field_TypeApiConsumer Spartan_Report_Field_TypeApiConsumer, ISpartan_MetadataApiConsumer Spartan_MetadataApiConsumer, ISpartaneObjectApiConsumer SpartaneObjectApiConsumer, ISpartan_UserApiConsumer UserApiConsumer, ISpartan_Report_PermissionsApiConsumer Spartan_Report_PermissionsApiConsumer)
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._ISpartan_ReportApiConsumer = Spartan_ReportApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_Report_Presentation_TypeApiConsumer = Spartan_Report_Presentation_TypeApiConsumer;
            this._ISpartan_Report_Presentation_ViewApiConsumer = Spartan_Report_Presentation_ViewApiConsumer;
            this._ISpartan_Report_StatusApiConsumer = Spartan_Report_StatusApiConsumer;
            this._ISpartan_Report_Fields_DetailApiConsumer = Spartan_Report_Fields_DetailApiConsumer;
            this._ISpartan_Report_FunctionApiConsumer = Spartan_Report_FunctionApiConsumer;
            this._ISpartan_Report_FormatApiConsumer = Spartan_Report_FormatApiConsumer;
            this._ISpartan_Report_Order_TypeApiConsumer = Spartan_Report_Order_TypeApiConsumer;
            this._ISpartan_Report_Field_TypeApiConsumer = Spartan_Report_Field_TypeApiConsumer;
            this._ISpartan_MetadataApiConsumer = Spartan_MetadataApiConsumer;
            this._ISpartan_Report_PermissionsApiConsumer = Spartan_Report_PermissionsApiConsumer;

            this._ISpartan_MetadataApiConsumer = Spartan_MetadataApiConsumer;
            this._ISpartaneObjectApiConsumer = SpartaneObjectApiConsumer;
            this._IUserApiConsumer = UserApiConsumer;
        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Spartan_Report
        [ObjectAuth(ObjectId = (ModuleObjectId)31953, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 31953);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Spartan_Report/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)31953, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 31953);
            ViewBag.Permission = permission;
            var varSpartan_Report = new Spartan_ReportModel();
			
            ViewBag.ObjectId = "31953";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;

            var permissionSpartan_Report_Fields_Detail = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 32035);
            ViewBag.PermissionSpartan_Report_Fields_Detail = permissionSpartan_Report_Fields_Detail;

            varSpartan_Report.Registration_Date = DateTime.Today.ToShortDateString();
            varSpartan_Report.Registration_Hour = DateTime.Now.ToShortTimeString();
            varSpartan_Report.Registration_User = SessionHelper.Role;

            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || (Id.GetType() == typeof(int) && Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_ReportApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Spartan_ReportData = _ISpartan_ReportApiConsumer.GetByKeyComplete(Id).Resource.Spartan_Reports[0];
                if (Spartan_ReportData == null)
                    return HttpNotFound();

                varSpartan_Report = new Spartan_ReportModel
                {
                    ReportId = (int)Spartan_ReportData.ReportId
                    ,Registration_Date = (Spartan_ReportData.Registration_Date == null ? string.Empty : Convert.ToDateTime(Spartan_ReportData.Registration_Date).ToString(ConfigurationProperty.DateFormat))
                    ,Registration_Hour = Spartan_ReportData.Registration_Hour
                    ,Registration_User = Spartan_ReportData.Registration_User
                    ,Object = Spartan_ReportData.Object
                    ,Report_Name = Spartan_ReportData.Report_Name
                    ,Presentation_Type = Spartan_ReportData.Presentation_Type
                    ,Presentation_TypeDescription =  (string)Spartan_ReportData.Presentation_Type_Spartan_Report_Presentation_Type.Description
                    ,Presentation_View = Spartan_ReportData.Presentation_View
                    ,Presentation_ViewDescription =  (string)Spartan_ReportData.Presentation_View_Spartan_Report_Presentation_View.Description
                    ,Status = Spartan_ReportData.Status
                    ,StatusDescription =  (string)Spartan_ReportData.Status_Spartan_Report_Status.Description
                    ,Query = Spartan_ReportData.Query
                    ,Filters = Spartan_ReportData.Filters
                    ,Header = Spartan_ReportData.Header
                    ,Footer = Spartan_ReportData.Footer

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_Report_Presentation_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Presentation_Types = _ISpartan_Report_Presentation_TypeApiConsumer.SelAll(true);
            if (Spartan_Report_Presentation_Types != null && Spartan_Report_Presentation_Types.Resource != null)
                ViewBag.Spartan_Report_Presentation_Types = Spartan_Report_Presentation_Types.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.PresentationTypeId)
                }).ToList();
            _ISpartan_Report_Presentation_ViewApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Presentation_Views = _ISpartan_Report_Presentation_ViewApiConsumer.SelAll(true);
            if (Spartan_Report_Presentation_Views != null && Spartan_Report_Presentation_Views.Resource != null)
                ViewBag.Spartan_Report_Presentation_Views = Spartan_Report_Presentation_Views.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.PresentationViewId)
                }).ToList();
            _ISpartan_Report_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Statuss = _ISpartan_Report_StatusApiConsumer.SelAll(true);
            if (Spartan_Report_Statuss != null && Spartan_Report_Statuss.Resource != null)
                ViewBag.Spartan_Report_Statuss = Spartan_Report_Statuss.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.StatusId)
                }).ToList();

            _ISpartaneObjectApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Objects = _ISpartaneObjectApiConsumer.SelAll(true);
            if (Spartan_Objects != null && Spartan_Objects.Resource != null)
                ViewBag.Spartan_Objects = Spartan_Objects.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(),
                    Value = Convert.ToString(m.Object_Id)
                }).ToList();

            _IUserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Users = _IUserApiConsumer.SelAll(false);
            if (Users != null && Users.Resource != null)
            {
                ViewBag.Users = Users.Resource.Select(m => new SelectListItem
                {
                    Text = m.Name.ToString(),
                    Value = Convert.ToString(m.Id_User)
                }).ToList();

            }
            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varSpartan_Report);
        }


       
        [HttpGet]
        public ActionResult AddSpartan_Report(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 31953);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _ISpartan_ReportApiConsumer.SetAuthHeader(_tokenManager.Token);
			Spartan_ReportModel varSpartan_Report= new Spartan_ReportModel();
            var permissionSpartan_Report_Fields_Detail = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 32035);
            ViewBag.PermissionSpartan_Report_Fields_Detail = permissionSpartan_Report_Fields_Detail;


            if (id.ToString() != "0")
            {
                var Spartan_ReportsData = _ISpartan_ReportApiConsumer.ListaSelAll(0, 1000, "ReportId=" + id, "").Resource.Spartan_Reports;
				
				if (Spartan_ReportsData != null && Spartan_ReportsData.Count > 0)
                {
					var Spartan_ReportData = Spartan_ReportsData.First();
					varSpartan_Report= new Spartan_ReportModel
					{
						ReportId  = Spartan_ReportData.ReportId 
	                    ,Registration_Date = (Spartan_ReportData.Registration_Date == null ? string.Empty : Convert.ToDateTime(Spartan_ReportData.Registration_Date).ToString(ConfigurationProperty.DateFormat))
                    ,Registration_Hour = Spartan_ReportData.Registration_Hour
                    ,Registration_User = Spartan_ReportData.Registration_User
                    ,Object = Spartan_ReportData.Object
                    ,Report_Name = Spartan_ReportData.Report_Name
                    ,Presentation_Type = Spartan_ReportData.Presentation_Type
                    ,Presentation_TypeDescription =  (string)Spartan_ReportData.Presentation_Type_Spartan_Report_Presentation_Type.Description
                    ,Presentation_View = Spartan_ReportData.Presentation_View
                    ,Presentation_ViewDescription =  (string)Spartan_ReportData.Presentation_View_Spartan_Report_Presentation_View.Description
                    ,Status = Spartan_ReportData.Status
                    ,StatusDescription =  (string)Spartan_ReportData.Status_Spartan_Report_Status.Description
                    ,Query = Spartan_ReportData.Query
                    ,Filters = Spartan_ReportData.Filters
                    ,Header = Spartan_ReportData.Header
                    ,Footer = Spartan_ReportData.Footer

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_Report_Presentation_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Presentation_Types = _ISpartan_Report_Presentation_TypeApiConsumer.SelAll(true);
            if (Spartan_Report_Presentation_Types != null && Spartan_Report_Presentation_Types.Resource != null)
                ViewBag.Spartan_Report_Presentation_Types = Spartan_Report_Presentation_Types.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.PresentationTypeId)
                }).ToList();
            _ISpartan_Report_Presentation_ViewApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Presentation_Views = _ISpartan_Report_Presentation_ViewApiConsumer.SelAll(true);
            if (Spartan_Report_Presentation_Views != null && Spartan_Report_Presentation_Views.Resource != null)
                ViewBag.Spartan_Report_Presentation_Views = Spartan_Report_Presentation_Views.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.PresentationViewId)
                }).ToList();
            _ISpartan_Report_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Statuss = _ISpartan_Report_StatusApiConsumer.SelAll(true);
            if (Spartan_Report_Statuss != null && Spartan_Report_Statuss.Resource != null)
                ViewBag.Spartan_Report_Statuss = Spartan_Report_Statuss.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.StatusId)
                }).ToList();


            return PartialView("AddSpartan_Report", varSpartan_Report);
        }


        [HttpGet]
        public FileResult GetFile(int id)
        {

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var fileInfo = _ISpartane_FileApiConsumer.GetByKey(id).Resource;
            if (fileInfo == null)
                return null;
            return File(fileInfo.File, System.Net.Mime.MediaTypeNames.Application.Octet, fileInfo.Description);
        }

        [HttpGet]
        public ActionResult GetSpartan_Report_Presentation_TypeAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Report_Presentation_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_Report_Presentation_TypeApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartan_Report_Presentation_ViewAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Report_Presentation_ViewApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_Report_Presentation_ViewApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartan_Report_StatusAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Report_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_Report_StatusApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public JsonResult ClearAdvanceFilter()
        {
            Session["AdvanceSearch"] = null;
            return Json(new { result = Session["AdvanceSearch"] == null }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ShowAdvanceFilter(Spartan_ReportAdvanceSearchModel model)
        {
            if (ModelState.IsValid)
            {
                Session["AdvanceSearch"] = model;
                return RedirectToAction("Index");
            }
            ViewBag.Filter = new List<SelectListItem>
            {
                new SelectListItem() {Text = Resources.Resources.BeginWith, Value = "1"},
                new SelectListItem() {Text = Resources.Resources.EndWith, Value = "2"},
                new SelectListItem() {Text = Resources.Resources.Contains, Value = "4"},
                new SelectListItem() {Text = Resources.Resources.Exact, Value = "3"},
            };
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_Report_Presentation_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Presentation_Types = _ISpartan_Report_Presentation_TypeApiConsumer.SelAll(true);
            if (Spartan_Report_Presentation_Types != null && Spartan_Report_Presentation_Types.Resource != null)
                ViewBag.Spartan_Report_Presentation_Types = Spartan_Report_Presentation_Types.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.PresentationTypeId)
                }).ToList();
            _ISpartan_Report_Presentation_ViewApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Presentation_Views = _ISpartan_Report_Presentation_ViewApiConsumer.SelAll(true);
            if (Spartan_Report_Presentation_Views != null && Spartan_Report_Presentation_Views.Resource != null)
                ViewBag.Spartan_Report_Presentation_Views = Spartan_Report_Presentation_Views.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.PresentationViewId)
                }).ToList();
            _ISpartan_Report_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Statuss = _ISpartan_Report_StatusApiConsumer.SelAll(true);
            if (Spartan_Report_Statuss != null && Spartan_Report_Statuss.Resource != null)
                ViewBag.Spartan_Report_Statuss = Spartan_Report_Statuss.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.StatusId)
                }).ToList();


            return View(model);  
        }

        [HttpGet]
        public ActionResult ShowAdvanceFilter(string previousFilters = "")
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_Report_Presentation_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Presentation_Types = _ISpartan_Report_Presentation_TypeApiConsumer.SelAll(true);
            if (Spartan_Report_Presentation_Types != null && Spartan_Report_Presentation_Types.Resource != null)
                ViewBag.Spartan_Report_Presentation_Types = Spartan_Report_Presentation_Types.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.PresentationTypeId)
                }).ToList();
            _ISpartan_Report_Presentation_ViewApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Presentation_Views = _ISpartan_Report_Presentation_ViewApiConsumer.SelAll(true);
            if (Spartan_Report_Presentation_Views != null && Spartan_Report_Presentation_Views.Resource != null)
                ViewBag.Spartan_Report_Presentation_Views = Spartan_Report_Presentation_Views.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.PresentationViewId)
                }).ToList();
            _ISpartan_Report_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Statuss = _ISpartan_Report_StatusApiConsumer.SelAll(true);
            if (Spartan_Report_Statuss != null && Spartan_Report_Statuss.Resource != null)
                ViewBag.Spartan_Report_Statuss = Spartan_Report_Statuss.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.StatusId)
                }).ToList();


            var previousFiltersObj = new Spartan_ReportAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Spartan_ReportAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Spartan_ReportAdvanceSearchModel());
            }

            ViewBag.Filter = new List<SelectListItem>
            {
                new SelectListItem() {Text = Resources.Resources.BeginWith, Value = "1"},
                new SelectListItem() {Text = Resources.Resources.EndWith, Value = "2"},
                new SelectListItem() {Text = Resources.Resources.Contains, Value = "4"},
                new SelectListItem() {Text = Resources.Resources.Exact, Value = "3"},

            };

            return View(previousFiltersObj);
        }

        public ActionResult Get()
        {
            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_ReportPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _ISpartan_ReportApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Reports == null)
                result.Spartan_Reports = new List<Spartan_Report>();

            return Json(new
            {
                data = result.Spartan_Reports.Select(m => new Spartan_ReportGridModel
                    {
                    ReportId = m.ReportId
                        ,Registration_Date = (m.Registration_Date == null ? string.Empty : Convert.ToDateTime(m.Registration_Date).ToString(ConfigurationProperty.DateFormat))
			,Registration_Hour = m.Registration_Hour
			,Registration_User = m.Registration_User
			,Object = m.Object
			,Report_Name = m.Report_Name
                        ,Presentation_TypeDescription = (string)m.Presentation_Type_Spartan_Report_Presentation_Type.Description
                        ,Presentation_ViewDescription = (string)m.Presentation_View_Spartan_Report_Presentation_View.Description
                        ,StatusDescription = (string)m.Status_Spartan_Report_Status.Description
			,Query = m.Query
			,Filters = m.Filters
			,Header = m.Header
			,Footer = m.Footer

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get List of Spartan_Report from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Spartan_Report Entity</returns>
        public ActionResult GetSpartan_ReportList(int sEcho, int iDisplayStart, int iDisplayLength)
        {
            int sortColumn = -1;
            string sortDirection = "asc";
            if (iDisplayLength == -1)
            {
                //length = TOTAL_ROWS;
                iDisplayLength = int.MaxValue;
            }
            // note: we only sort one column at a time
            if (Request.QueryString["iSortCol_0"] != null)
            {
                sortColumn = int.Parse(Request.QueryString["iSortCol_0"]);
            }
            if (Request.QueryString["sSortDir_0"] != null)
            {
                sortDirection = Request.QueryString["sSortDir_0"];
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_ReportApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_ReportPropertyMapper());

            //Adding Advance Search
            if (!string.IsNullOrEmpty(Request.QueryString["AdvanceSearch"]) && Request.QueryString["AdvanceSearch"] == "True")
            {
                var advanceFilter =
                    (Spartan_ReportAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            Spartan_ReportPropertyMapper oSpartan_ReportPropertyMapper = new Spartan_ReportPropertyMapper();

            configuration.OrderByClause = oSpartan_ReportPropertyMapper.GetPropertyName(Convert.ToString(Request.QueryString["mDataProp_" + sortColumn])) + " " + sortDirection;

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _ISpartan_ReportApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Reports == null)
                result.Spartan_Reports = new List<Spartan_Report>();

            return Json(new
            {
                aaData = result.Spartan_Reports.Select(m => new Spartan_ReportGridModel
            {
                    ReportId = m.ReportId
                        ,Registration_Date = (m.Registration_Date == null ? string.Empty : Convert.ToDateTime(m.Registration_Date).ToString(ConfigurationProperty.DateFormat))
			,Registration_Hour = m.Registration_Hour
			,Registration_User = m.Registration_User
            ,Registration_UserName = m.User_Spartan_Report_User.Name
			,Object = m.Object
            ,ObjectName = m.Spartan_Object_Spartan_Report_Object.Name
            ,
                    Report_Name = m.Report_Name
                        ,Presentation_TypeDescription = (string)m.Presentation_Type_Spartan_Report_Presentation_Type.Description
                        ,Presentation_ViewDescription = (string)m.Presentation_View_Spartan_Report_Presentation_View.Description
                        ,StatusDescription = (string)m.Status_Spartan_Report_Status.Description
			,Query = m.Query
			,Filters = m.Filters
			,Header = m.Header
			,Footer = m.Footer

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }


//Grid GetAutoComplete

        [NonAction]
        public string GetAdvanceFilter(Spartan_ReportAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromReportId) || !string.IsNullOrEmpty(filter.ToReportId))
            {
                if (!string.IsNullOrEmpty(filter.FromReportId))
                    where += " AND Spartan_Report.ReportId >= " + filter.FromReportId;
                if (!string.IsNullOrEmpty(filter.ToReportId))
                    where += " AND Spartan_Report.ReportId <= " + filter.ToReportId;
            }

            if (!string.IsNullOrEmpty(filter.FromRegistration_Date) || !string.IsNullOrEmpty(filter.ToRegistration_Date))
            {
                var Registration_DateFrom = DateTime.ParseExact(filter.FromRegistration_Date, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Registration_DateTo = DateTime.ParseExact(filter.ToRegistration_Date, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromRegistration_Date))
                    where += " AND Spartan_Report.Registration_Date >= '" + Registration_DateFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToRegistration_Date))
                    where += " AND Spartan_Report.Registration_Date <= '" + Registration_DateTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromRegistration_Hour) || !string.IsNullOrEmpty(filter.ToRegistration_Hour))
            {
                if (!string.IsNullOrEmpty(filter.FromRegistration_Hour))
                    where += " AND Convert(TIME,Spartan_Report.Registration_Hour) >='" + filter.FromRegistration_Hour + "'";
                if (!string.IsNullOrEmpty(filter.ToRegistration_Hour))
                    where += " AND Convert(TIME,Spartan_Report.Registration_Hour) <='" + filter.ToRegistration_Hour + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromRegistration_User) || !string.IsNullOrEmpty(filter.ToRegistration_User))
            {
                if (!string.IsNullOrEmpty(filter.FromRegistration_User))
                    where += " AND Spartan_Report.Registration_User >= " + filter.FromRegistration_User;
                if (!string.IsNullOrEmpty(filter.ToRegistration_User))
                    where += " AND Spartan_Report.Registration_User <= " + filter.ToRegistration_User;
            }

            if (!string.IsNullOrEmpty(filter.FromObject) || !string.IsNullOrEmpty(filter.ToObject))
            {
                if (!string.IsNullOrEmpty(filter.FromObject))
                    where += " AND Spartan_Report.Object >= " + filter.FromObject;
                if (!string.IsNullOrEmpty(filter.ToObject))
                    where += " AND Spartan_Report.Object <= " + filter.ToObject;
            }

            if (!string.IsNullOrEmpty(filter.Report_Name))
            {
                switch (filter.Report_NameFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Report.Report_Name LIKE '" + filter.Report_Name + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Report.Report_Name LIKE '%" + filter.Report_Name + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Report.Report_Name = '" + filter.Report_Name + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Report.Report_Name LIKE '%" + filter.Report_Name + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvancePresentation_Type))
            {
                switch (filter.Presentation_TypeFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Report_Presentation_Type.Description LIKE '" + filter.AdvancePresentation_Type + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Report_Presentation_Type.Description LIKE '%" + filter.AdvancePresentation_Type + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Report_Presentation_Type.Description = '" + filter.AdvancePresentation_Type + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Report_Presentation_Type.Description LIKE '%" + filter.AdvancePresentation_Type + "%'";
                        break;
                }
            }
            else if (filter.AdvancePresentation_TypeMultiple != null && filter.AdvancePresentation_TypeMultiple.Count() > 0)
            {
                var Presentation_TypeIds = string.Join(",", filter.AdvancePresentation_TypeMultiple);

                where += " AND Spartan_Report.Presentation_Type In (" + Presentation_TypeIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvancePresentation_View))
            {
                switch (filter.Presentation_ViewFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Report_Presentation_View.Description LIKE '" + filter.AdvancePresentation_View + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Report_Presentation_View.Description LIKE '%" + filter.AdvancePresentation_View + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Report_Presentation_View.Description = '" + filter.AdvancePresentation_View + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Report_Presentation_View.Description LIKE '%" + filter.AdvancePresentation_View + "%'";
                        break;
                }
            }
            else if (filter.AdvancePresentation_ViewMultiple != null && filter.AdvancePresentation_ViewMultiple.Count() > 0)
            {
                var Presentation_ViewIds = string.Join(",", filter.AdvancePresentation_ViewMultiple);

                where += " AND Spartan_Report.Presentation_View In (" + Presentation_ViewIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceStatus))
            {
                switch (filter.StatusFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Report_Status.Description LIKE '" + filter.AdvanceStatus + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Report_Status.Description LIKE '%" + filter.AdvanceStatus + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Report_Status.Description = '" + filter.AdvanceStatus + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Report_Status.Description LIKE '%" + filter.AdvanceStatus + "%'";
                        break;
                }
            }
            else if (filter.AdvanceStatusMultiple != null && filter.AdvanceStatusMultiple.Count() > 0)
            {
                var StatusIds = string.Join(",", filter.AdvanceStatusMultiple);

                where += " AND Spartan_Report.Status In (" + StatusIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Query))
            {
                switch (filter.QueryFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Report.Query LIKE '" + filter.Query + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Report.Query LIKE '%" + filter.Query + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Report.Query = '" + filter.Query + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Report.Query LIKE '%" + filter.Query + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Filters))
            {
                switch (filter.FiltersFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Report.Filters LIKE '" + filter.Filters + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Report.Filters LIKE '%" + filter.Filters + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Report.Filters = '" + filter.Filters + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Report.Filters LIKE '%" + filter.Filters + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Header))
            {
                switch (filter.HeaderFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Report.Header LIKE '" + filter.Header + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Report.Header LIKE '%" + filter.Header + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Report.Header = '" + filter.Header + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Report.Header LIKE '%" + filter.Header + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Footer))
            {
                switch (filter.FooterFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Report.Footer LIKE '" + filter.Footer + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Report.Footer LIKE '%" + filter.Footer + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Report.Footer = '" + filter.Footer + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Report.Footer LIKE '%" + filter.Footer + "%'";
                        break;
                }
            }


            where = new Regex(Regex.Escape("AND ")).Replace(where, "", 1);
            return where;
        }

        [NonAction]
        public Grid_File ConvertSpartane_FileToGridFile(Spartane.Core.Domain.Spartane_File.Spartane_File file)
        {
            return file == null ? new Grid_File { FileId = 0, FileSize = 0, FileName = "" } : new Grid_File { FileId = file.File_Id, FileName = file.Description, FileSize = file.File_Size ?? 0, };
        }

        public ActionResult GetSpartan_Report_Fields_Detail(int draw, int start, int length, int RelationId = 0)
        {
            if (RelationId == 0)
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Spartan_Report_Fields_DetailGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_Report_Fields_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            var result = _ISpartan_Report_Fields_DetailApiConsumer.ListaSelAll(start, pageSize, "Spartan_Report_Fields_Detail.Report=" + RelationId,"").Resource;
            if (result.Spartan_Report_Fields_Details == null)
                result.Spartan_Report_Fields_Details = new List<Spartan_Report_Fields_Detail>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Spartan_Report_Fields_Details.Select(m => new Spartan_Report_Fields_DetailGridModel
                {
                    DesignDetailId = m.DesignDetailId
			,PathField = m.PathField
			,Physical_Name = m.Physical_Name
			,Title = m.Title
                        ,Function = m.Function
                        ,FunctionDescription = m.Function_Spartan_Report_Function.Description
                        ,Format = m.Format
                        ,FormatDescription = m.Format_Spartan_Report_Format.Description
                        ,Order_Type = m.Order_Type
                        ,Order_TypeDescription = m.Order_Type_Spartan_Report_Order_Type.Description
                        ,Field_Type = m.Field_Type
                        ,Field_TypeDescription = m.Field_Type_Spartan_Report_Field_Type.Description
			,Order_Number = m.Order_Number
                        ,AttributeId = m.AttributeId
                        ,AttributeIdPhysical_Name = m.AttributeId_Spartan_Metadata.Physical_Name

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }


        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_ReportApiConsumer.SetAuthHeader(_tokenManager.Token);

                //Spartan_Report varSpartan_Report = null;
                if (id.ToString() != "0")
                {
                    _ISpartan_Report_Fields_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                    var Spartan_Report_Fields_DetailInfo =
                        _ISpartan_Report_Fields_DetailApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_Report_Fields_Detail.Report=" + id, "").Resource;

                    if (Spartan_Report_Fields_DetailInfo.RowCount != 0)
                    {
                        var resultSpartan_Report_Fields_Detail = true;
                        //Removing associated job history with attachment
                        foreach (var Spartan_Report_Fields_DetailItem in Spartan_Report_Fields_DetailInfo.Spartan_Report_Fields_Details)
                            resultSpartan_Report_Fields_Detail = resultSpartan_Report_Fields_Detail
                                              && _ISpartan_Report_Fields_DetailApiConsumer.Delete(Spartan_Report_Fields_DetailItem.DesignDetailId, null, null).Resource;

                        if (!resultSpartan_Report_Fields_Detail)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                _ISpartan_Report_PermissionsApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Spartan_Report_Permissions_DetailInfo =
                    _ISpartan_Report_PermissionsApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_Report_Permissions.Report=" + id, "").Resource;
                if (Spartan_Report_Permissions_DetailInfo.RowCount != 0)
                {
                    foreach (var item in Spartan_Report_Permissions_DetailInfo.Spartan_Report_Permissionss)
                    {
                        _ISpartan_Report_PermissionsApiConsumer.Delete(item.ReportPermissionId, null, null);
                    }
                }


                var result = _ISpartan_ReportApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Spartan_ReportModel varSpartan_Report)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _ISpartan_ReportApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Spartan_ReportInfo = new Spartan_Report
                    {
                        ReportId = varSpartan_Report.ReportId
                        ,Registration_Date = DateTime.ParseExact(DateTime.Today.ToString("dd-MM-yyyy"), ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider)
                        ,Registration_Hour = DateTime.Now.ToShortTimeString()
                        ,Registration_User = SessionHelper.Role
                        ,Object = varSpartan_Report.Object
                        ,Report_Name = varSpartan_Report.Report_Name
                        ,Presentation_Type = varSpartan_Report.Presentation_Type
                        ,Presentation_View = varSpartan_Report.Presentation_View
                        ,Status = varSpartan_Report.Status
                        ,Query = varSpartan_Report.Query
                        ,Filters = varSpartan_Report.Filters
                        ,Header = varSpartan_Report.Header
                        ,Footer = varSpartan_Report.Footer

                    };

                    result = !IsNew ?
                        _ISpartan_ReportApiConsumer.Update(Spartan_ReportInfo, null, null).Resource.ToString() :
                         _ISpartan_ReportApiConsumer.Insert(Spartan_ReportInfo, null, null).Resource.ToString();

                    return Json(result, JsonRequestBehavior.AllowGet);
				}
				return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public bool CopySpartan_Report_Fields_Detail(int MasterId, int referenceId, List<Spartan_Report_Fields_DetailGridModelPost> Spartan_Report_Fields_DetailItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _ISpartan_Report_Fields_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Spartan_Report_Fields_DetailData = _ISpartan_Report_Fields_DetailApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_Report_Fields_Detail.Report=" + referenceId,"").Resource;
                if (Spartan_Report_Fields_DetailData == null || Spartan_Report_Fields_DetailData.Spartan_Report_Fields_Details.Count == 0)
                    return true;

                var result = true;

                Spartan_Report_Fields_DetailGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varSpartan_Report_Fields_Detail in Spartan_Report_Fields_DetailData.Spartan_Report_Fields_Details)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Spartan_Report_Fields_Detail Spartan_Report_Fields_Detail1 = varSpartan_Report_Fields_Detail;

                    if (Spartan_Report_Fields_DetailItems != null && Spartan_Report_Fields_DetailItems.Any(m => m.DesignDetailId == Spartan_Report_Fields_Detail1.DesignDetailId))
                    {
                        modelDataToChange = Spartan_Report_Fields_DetailItems.FirstOrDefault(m => m.DesignDetailId == Spartan_Report_Fields_Detail1.DesignDetailId);
                    }
                    //Chaning Id Value
                    varSpartan_Report_Fields_Detail.Report = MasterId;
                    var insertId = _ISpartan_Report_Fields_DetailApiConsumer.Insert(varSpartan_Report_Fields_Detail,null,null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.DesignDetailId = insertId;

                    result = insertId > 0;
                }
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        public ActionResult PostSpartan_Report_Fields_Detail(List<Spartan_Report_Fields_DetailGridModelPost> Spartan_Report_Fields_DetailItems, int MasterId, int referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopySpartan_Report_Fields_Detail(MasterId, referenceId, Spartan_Report_Fields_DetailItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Spartan_Report_Fields_DetailItems != null && Spartan_Report_Fields_DetailItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartan_Report_Fields_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Spartan_Report_Fields_DetailItem in Spartan_Report_Fields_DetailItems)
                    {

                        //Removal Request
                        if (Spartan_Report_Fields_DetailItem.Removed)
                        {
                            result = result && _ISpartan_Report_Fields_DetailApiConsumer.Delete(Spartan_Report_Fields_DetailItem.DesignDetailId, null,null).Resource;
                            continue;
                        }

                        var Spartan_Report_Fields_DetailData = new Spartan_Report_Fields_Detail
                        {
                            Report = MasterId
                            ,DesignDetailId = Spartan_Report_Fields_DetailItem.DesignDetailId
                            ,PathField = Spartan_Report_Fields_DetailItem.PathField
                            ,Physical_Name = Spartan_Report_Fields_DetailItem.Physical_Name
                            ,Title = Spartan_Report_Fields_DetailItem.Title
                            ,Function = (Convert.ToInt32(Spartan_Report_Fields_DetailItem.Function) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_Report_Fields_DetailItem.Function))
                            ,Format = (Convert.ToInt32(Spartan_Report_Fields_DetailItem.Format) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_Report_Fields_DetailItem.Format))
                            ,Order_Type = (Convert.ToInt32(Spartan_Report_Fields_DetailItem.Order_Type) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_Report_Fields_DetailItem.Order_Type))
                            ,Field_Type = (Convert.ToInt16(Spartan_Report_Fields_DetailItem.Field_Type) == 0 ? (Int16?)null : Convert.ToInt16(Spartan_Report_Fields_DetailItem.Field_Type))
                            ,Order_Number = Spartan_Report_Fields_DetailItem.Order_Number
                            ,AttributeId = (Convert.ToInt32(Spartan_Report_Fields_DetailItem.AttributeId) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_Report_Fields_DetailItem.AttributeId))

                        };

                        var resultId = Spartan_Report_Fields_DetailItem.DesignDetailId > 0
                           ? _ISpartan_Report_Fields_DetailApiConsumer.Update(Spartan_Report_Fields_DetailData,null,null).Resource
                           : _ISpartan_Report_Fields_DetailApiConsumer.Insert(Spartan_Report_Fields_DetailData,null,null).Resource;

                        result = result && resultId != -1;
                    }
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartan_Report_Fields_Detail_Spartan_Report_FunctionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Report_FunctionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_Report_FunctionApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSpartan_Report_Fields_Detail_Spartan_Report_FormatAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Report_FormatApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_Report_FormatApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSpartan_Report_Fields_Detail_Spartan_Report_Order_TypeAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Report_Order_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_Report_Order_TypeApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSpartan_Report_Fields_Detail_Spartan_Report_Field_TypeAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Report_Field_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_Report_Field_TypeApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSpartan_Report_Fields_Detail_Spartan_MetadataAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_MetadataApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }



        /// <summary>
        /// Write Element Array of Spartan_Report script
        /// </summary>
        /// <param name="oSpartan_ReportElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Spartan_ReportModuleAttributeList)
        {
            for (int i = 0; i < Spartan_ReportModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Spartan_ReportModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Spartan_ReportModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Spartan_ReportModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Spartan_ReportModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Spartan_ReportModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Spartan_ReportModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Spartan_ReportModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Spartan_ReportModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Spartan_ReportModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Spartan_ReportModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strSpartan_ReportScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_Report.js")))
            {
                strSpartan_ReportScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Spartan_Report element attributes
            string userChangeJson = jsSerialize.Serialize(Spartan_ReportModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strSpartan_ReportScript.IndexOf("inpuElementArray");
            string splittedString = strSpartan_ReportScript.Substring(indexOfArray, strSpartan_ReportScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Spartan_ReportModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Spartan_ReportModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strSpartan_ReportScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strSpartan_ReportScript.Substring(indexOfArrayHistory, strSpartan_ReportScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strSpartan_ReportScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strSpartan_ReportScript.Substring(endIndexOfMainElement + indexOfArray, strSpartan_ReportScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Spartan_ReportModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strSpartan_ReportScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strSpartan_ReportScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strSpartan_ReportScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strSpartan_ReportScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Spartan_Report.js")))
            {
                w.WriteLine(finalResponse);
            }
            
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        

        [HttpPost]
        public JsonResult ReadScriptSettings()
        {
            string strCustomScript = string.Empty;
            
            CustomElementAttribute oCustomElementAttribute = new CustomElementAttribute();

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Spartan_Report.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_Report.js")))
                {
                    strCustomScript = r.ReadToEnd();
                
                }

                int indexOfArray = strCustomScript.IndexOf("inpuElementArray");
                string splittedString = strCustomScript.Substring(indexOfArray, strCustomScript.Length - indexOfArray);                
                int indexOfMainElement = splittedString.IndexOf('[');                
                int endIndexOfMainElement = splittedString.IndexOf(']') + 1;                
                string mainJsonArray = splittedString.Substring(indexOfMainElement, endIndexOfMainElement - indexOfMainElement);

                int indexOfChildArray = strCustomScript.IndexOf("inpuElementChildArray");
				string childJsonArray = "";
                if (indexOfChildArray != -1)
                {
					string splittedChildString = strCustomScript.Substring(indexOfChildArray, strCustomScript.Length - indexOfChildArray);
					int indexOfChildElement = splittedChildString.IndexOf('[');
					int endIndexOfChildElement = splittedChildString.IndexOf(']') + 1;
					childJsonArray = splittedChildString.Substring(indexOfChildElement, endIndexOfChildElement - indexOfChildElement);
				}
                var MainElementList = JsonConvert.DeserializeObject(mainJsonArray);
                var ChildElementList = JsonConvert.DeserializeObject(childJsonArray);

                oCustomElementAttribute.MainElement = MainElementList.ToString();
				if (indexOfChildArray != -1)
                {
					oCustomElementAttribute.ChildElement = ChildElementList.ToString();
				}
            }
            else
            {
                oCustomElementAttribute.MainElement = string.Empty;
                oCustomElementAttribute.ChildElement = string.Empty;
            }        
            return Json(oCustomElementAttribute, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Spartan_ReportPropertyBag()
        {
            return PartialView("Spartan_ReportPropertyBag", "Spartan_Report");
        }
		
		public List<Spartan_Business_Rule> GetBusinessRules(int ObjectId, int Attribute)
        {
            if (!_tokenManager.GenerateToken())
                return null;
            List<Spartan_Business_Rule> result = new List<Spartan_Business_Rule>();
            _ISpartan_Business_RuleApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (Attribute != 0)
            {
                result = _ISpartan_Business_RuleApiConsumer.ListaSelAll(0, 1000, "Object = " + ObjectId + " AND Attribute = " + Attribute, "").Resource.Spartan_Business_Rules;
            }
            else
            {
                List<Spartan_Business_Rule> partialResult = _ISpartan_Business_RuleApiConsumer.ListaSelAll(0, 1000, "Object = " + ObjectId, "").Resource.Spartan_Business_Rules;
                foreach (var item in partialResult)
                {
                    if (item.Attribute == Attribute)
                    {
                        result.Add(item);
                    }
                    else//Busco las reglas con el event process en cuestion
                    {
                        _ISpartan_BR_Process_Event_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                        var eventProcess = _ISpartan_BR_Process_Event_DetailApiConsumer.ListaSelAll(0, 1000, "Business_Rule = " + item.BusinessRuleId, "").Resource;
                        if (Attribute == 0 && eventProcess.Spartan_BR_Process_Event_Details.Where(x => x.Process_Event == 1).Count() > 0)
                        {
                            result.Add(item);
                        }
                        if ((Attribute == 2) && eventProcess.Spartan_BR_Process_Event_Details.Where(x => x.Process_Event == 2 || x.Process_Event == 3).Count() > 0)
                        {
                            result.Add(item);
                        }
                        if ((Attribute == 3) && eventProcess.Spartan_BR_Process_Event_Details.Where(x => x.Process_Event == 4 || x.Process_Event == 5).Count() > 0)
                        {
                            result.Add(item);
                        }
                        //TODO Faltan en la base de datos cuando creas una row de grilla
                    }
                }
            }
            return result;
        }

        [HttpGet]
        public ActionResult AddSpartan_Report_Fields_Detail(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Spartan_Report_Fields_Detail/AddSpartan_Report_Fields_Detail");
        }



        #endregion "Controller Methods"

        #region "Custom methods"

        [HttpGet]
        public void Export(string format, int pageIndex, int pageSize)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

            if (!_tokenManager.GenerateToken())
                return;

            _ISpartan_ReportApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_ReportPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_ReportApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Reports == null)
                result.Spartan_Reports = new List<Spartan_Report>();

            var data = result.Spartan_Reports.Select(m => new Spartan_ReportGridModel
            {
                ReportId = m.ReportId
                ,Registration_Hour = m.Registration_Hour
                ,Registration_User = m.Registration_User
                ,Object = m.Object
                ,Report_Name = m.Report_Name
                ,Query = m.Query
                ,Filters = m.Filters
                ,Header = m.Header
                ,Footer = m.Footer

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Spartan_ReportList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Spartan_ReportList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(), "EmployeeList_" + DateTime.Now.ToString());
                    break;
            }
        }

        [HttpGet]
        //[ObjectAuth(ObjectId = ModuleObjectId.EMPLEADOS_OBJECT, PermissionType = PermissionTypes.Export)]
        public ActionResult Print(string format, int pageIndex, int pageSize)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

            if (!_tokenManager.GenerateToken())
                return null;

            _ISpartan_ReportApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_ReportPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_ReportApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Reports == null)
                result.Spartan_Reports = new List<Spartan_Report>();

            var data = result.Spartan_Reports.Select(m => new Spartan_ReportGridModel
            {
                ReportId = m.ReportId
                ,Registration_Hour = m.Registration_Hour
                ,Registration_User = m.Registration_User
                ,Object = m.Object
                ,Report_Name = m.Report_Name
                ,Query = m.Query
                ,Filters = m.Filters
                ,Header = m.Header
                ,Footer = m.Footer

            }).ToList();

            return PartialView("_Print", data);
        }

        #region jsTree
        /// <summary>
        /// FillComponentsTree (Action que se ejecuta cuando se asigna un valor al objectId)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult FillComponentsTree(int id)
        {
            try
            {
                IList<Spartan_Metadata> components = GetSpantan_Metadata(id);
                var data = RenderTreeView(null, components, new List<JsTreeNodeModel>());
                var jsonResult = Json(data, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { Saved = false, Message = ex.Message });

            }
        }


        /// <summary>
        ///  GetSpantan_Metadata (Este metodo busca los elementos de la tabla Spartan_Metadata para llenar el arbol)
        /// </summary>
        /// <param name="Object_Id">Id del objeto</param>
        /// <returns>Lista de elemntos Spartan_Metadata</returns>
        private IList<Spartan_Metadata> GetSpantan_Metadata(int Object_Id)
        {
            if (!_tokenManager.GenerateToken())
                return null;

            _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);
            var whereClause = "Spartan_Metadata.Object_Id=" + Object_Id + " AND (Spartan_Metadata.Related_Object_Id IS NULL OR Spartan_Metadata.Identifier_Type IS NULL ) ";
            var orderClause = "Spartan_Metadata.ScreenOrder";
            var Spartan_Metadatas = _ISpartan_MetadataApiConsumer.SelAll(true, whereClause, orderClause);
            if (Spartan_Metadatas != null && Spartan_Metadatas.Resource != null)
                return Spartan_Metadatas.Resource.ToList();

            return null;
        }

        /// <summary>
        /// RenderTreeView (Esta es la funcion que arma el arbol con sus hijos)
        /// </summary>
        /// <param name="components"></param>
        /// <returns></returns>
        private List<JsTreeNodeModel> RenderTreeView(JsTreeNodeModel parent, IList<Spartan_Metadata> components, List<JsTreeNodeModel> nodes)
        {

            foreach (Spartan_Metadata comp in components)
            {
                JsTreeNodeModel rootNode = new JsTreeNodeModel { objectId = Convert.ToInt32(comp.Object_Id), id = comp.AttributeId.ToString(), text = comp.Logical_Name.ToString(), children = new List<JsTreeNodeModel>(), li_attr = new JsTreeAttributeModel { draggable = true, className = comp.Class_Name, physicalName = comp.Physical_Name, logicalName = comp.Logical_Name, objectName = comp.Spartan_Object.Name, atributteId = comp.AttributeId.ToString(), classId = comp.Class_Id.ToString() } };

                if (parent != null)
                {
                    rootNode.li_attr.fieldPath = parent.li_attr.fieldPath + "." + rootNode.li_attr.atributteId;
                    parent.children.Add(rootNode);
                }
                else
                    rootNode.li_attr.fieldPath = comp.Class_Id.ToString();

                rootNode.state = new JsTreeNodeStateModel { opened = false, selected = false, disabled = false };
                if (comp.Related_Object_Id != null && (comp.Object_Id != comp.Related_Object_Id && nodes.Where(nod => nod.objectId == comp.Related_Object_Id).Count() == 0))
                    RenderTreeView(rootNode, GetSpantan_Metadata(Convert.ToInt32(comp.Related_Object_Id)), nodes);

                nodes.Add(rootNode);
            }
            return nodes;
        }

        #endregion
        #endregion "Custom methods"
    }
}
