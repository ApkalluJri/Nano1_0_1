using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Spartan_Report;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;


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
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Permissions;
using Spartane.Web.Areas.WebApiConsumer.SpartaneQuery;
using System.Data;
using Newtonsoft.Json.Linq;
using Spartane.Web.Areas.WebApiConsumer.SpartaneObject;

namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class ReportController : Controller
    {
        #region "variable declaration"

        private ISpartan_ReportService service = null;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;
        private ISpartan_ReportApiConsumer _ISpartanReportApiConsumer;
        private ISpartan_Report_PermissionsApiConsumer _ISpartanReportPermissionsApiConsumer;
        private ISpartaneQueryApiConsumer _ISpartanQueryApiConsumer;
        private ISpartaneObjectApiConsumer _ISpartaneObjectApiConsumer;
        enum GrantAccessTypes
        {
            NotFound = -1,
            Denied = 0,
            Disabled = 1,
            Allow = 2
        };
        #endregion "variable declaration"

        #region "Constructor Declaration"


        public ReportController(ISpartan_ReportService service, ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_ReportApiConsumer SpartanReportApiConsumer, ISpartan_Report_PermissionsApiConsumer SpartanReportPermissionsApiConsumer, ISpartaneQueryApiConsumer SpartanQueryApiConsumer, ISpartaneObjectApiConsumer SpartaneObjectApiConsumer)
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartanReportApiConsumer = SpartanReportApiConsumer;
            this._ISpartanReportPermissionsApiConsumer = SpartanReportPermissionsApiConsumer;
            this._ISpartanQueryApiConsumer = SpartanQueryApiConsumer;
            this._ISpartaneObjectApiConsumer = SpartaneObjectApiConsumer;
        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Report
        //[ObjectAuth(ObjectId = (ModuleObjectId)31960, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index(int? id)
        {
            //var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 31960);
            //ViewBag.Permission = permission;
            //ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;

            if (!id.HasValue)
            {
                return RedirectToAction("Index", new { area = "Frontal", controller = "Home" });

            }

            Core.Domain.Spartan_Report.Spartan_Report report = new Core.Domain.Spartan_Report.Spartan_Report();
            var grantType = GetGrantAccessType(id.Value, SessionHelper.Role, ref report);

            ViewBag.DeniedReport = false;
            ViewBag.DeniedType = 0;
            if (grantType == GrantAccessTypes.Denied || grantType == GrantAccessTypes.NotFound)
            {
                ViewBag.DeniedReport = true;
                ViewBag.DeniedType = 1;
            }

            if(grantType == GrantAccessTypes.Disabled)
            {
                ViewBag.DeniedReport = true;
                ViewBag.DeniedType = 2;
            }
            // Detailed Report
            if (report.Presentation_View == 1) return RedirectToAction("DetailedReport", "Report", new { id = id.Value });
            if (report.Presentation_View == 2) return RedirectToAction("CrossTable", "Report", new { id = id.Value });
            if (report.Presentation_View == 3) return RedirectToAction("BarsGraphic", "Report", new { id = id.Value });
            if (report.Presentation_View == 4) return RedirectToAction("LinesGraphic", "Report", new { id = id.Value });
            if (report.Presentation_View == 5) return RedirectToAction("PieGraphic", "Report", new { id = id.Value });

            return View();
        }

        public ActionResult DetailedReport(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Index", new { area = "Frontal", controller = "Home" });

            var report = GetReport(id.Value);

            if(report == null) return RedirectToAction("Index", new { area = "Frontal", controller = "Home" });

            if(report.Presentation_View != 1) return RedirectToAction("Index", new { area = "Frontal", controller = "Home" });

            var response = GetDataReport(report.Query);

            ViewBag.dataReport = response.Resource;
            if (report.Object.HasValue)
                ViewBag.Object = GetObject(report.Object.Value);
            ViewBag.IdReport = id.Value;

            return View();
        }

        public ActionResult CrossTable(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Index", new { area = "Frontal", controller = "Home" });

            var report = GetReport(id.Value);

            if (report == null) return RedirectToAction("Index", new { area = "Frontal", controller = "Home" });

            if (report.Presentation_View != 2) return RedirectToAction("Index", new { area = "Frontal", controller = "Home" });

            var response = GetDataReport(report.Query);

            ViewBag.dataReport = response.Resource;
            if (report.Object.HasValue)
                ViewBag.Object = GetObject(report.Object.Value);
            ViewBag.IdReport = id.Value;

            return View();
        }

        public ActionResult BarsGraphic(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Index", new { area = "Frontal", controller = "Home" });

            var report = GetReport(id.Value);

            if (report == null) return RedirectToAction("Index", new { area = "Frontal", controller = "Home" });

            if (report.Presentation_View != 3) return RedirectToAction("Index", new { area = "Frontal", controller = "Home" });

            var response = GetDataReport(report.Query);

            ViewBag.dataReport = response.Resource;
            if (report.Object.HasValue)
                ViewBag.Object = GetObject(report.Object.Value);
            ViewBag.IdReport = id.Value;

            return View();
        }

        public ActionResult LinesGraphic(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Index", new { area = "Frontal", controller = "Home" });

            var report = GetReport(id.Value);

            if (report == null) return RedirectToAction("Index", new { area = "Frontal", controller = "Home" });

            if (report.Presentation_View != 4) return RedirectToAction("Index", new { area = "Frontal", controller = "Home" });

            var response = GetDataReport(report.Query);

            ViewBag.dataReport = response.Resource;
            if (report.Object.HasValue)
                ViewBag.Object = GetObject(report.Object.Value);
            ViewBag.IdReport = id.Value;

            return View();
        }
        public ActionResult PieGraphic(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Index", new { area = "Frontal", controller = "Home" });

            var report = GetReport(id.Value);

            if (report == null) return RedirectToAction("Index", new { area = "Frontal", controller = "Home" });

            if (report.Presentation_View != 5) return RedirectToAction("Index", new { area = "Frontal", controller = "Home" });

            var response = GetDataReport(report.Query);

            ViewBag.dataReport = response.Resource;
            if (report.Object.HasValue)
                ViewBag.Object = GetObject(report.Object.Value);
            ViewBag.IdReport = id.Value;

            return View();
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
        public ActionResult ClearFilter(int id)
        {
            Session["AdvanceReportFilter"] = null;
            return RedirectToAction("Index", new { id = id });
        }

        #endregion "Controller Methods"

        #region "Custom methods"
        private GrantAccessTypes GetGrantAccessType(int reportId, int userRole, ref Core.Domain.Spartan_Report.Spartan_Report report)
        {
            if (!_tokenManager.GenerateToken())
                return GrantAccessTypes.NotFound;

            _ISpartanReportPermissionsApiConsumer.SetAuthHeader(_tokenManager.Token);

            string sqlWhere = String.Format("User_Role = {0} AND Report = {1}", userRole, reportId);
            var reportPermissions = _ISpartanReportPermissionsApiConsumer.ListaSelAll(0, 3, sqlWhere, null);

            if (reportPermissions.Resource.RowCount == 0)
            {
                return GrantAccessTypes.Denied;
            }

            _ISpartanReportApiConsumer.SetAuthHeader(_tokenManager.Token);
            var response = _ISpartanReportApiConsumer.GetByKey(reportId, false);

            if (response.Success == false || response.Resource == null) return GrantAccessTypes.Denied;

            if (response.Resource.Status == 2) return GrantAccessTypes.Disabled;

            report = response.Resource;

            return GrantAccessTypes.Allow;
        }

        private Core.Domain.Spartan_Report.Spartan_Report GetReport(int reportId)
        {
            if (!_tokenManager.GenerateToken())
                return null;

            _ISpartanReportApiConsumer.SetAuthHeader(_tokenManager.Token);
            var response = _ISpartanReportApiConsumer.GetByKey(reportId, false);

            if (response.Success == false || response.Resource == null) return null;

            if (response.Resource.Status == 2) return null;

            var report = response.Resource;

            return report;
        }

        private Core.Domain.SpartaneObject.SpartaneObject GetObject(int objectId)
        {
            if (!_tokenManager.GenerateToken())
                return null;

            _ISpartaneObjectApiConsumer.SetAuthHeader(_tokenManager.Token);
            var response = _ISpartaneObjectApiConsumer.GetByKey(objectId, false);

            if (response.Success == false || response.Resource == null) return null;

            var obj = response.Resource;

            return obj;
        }

        private WebApiConsumer.ResponseHelpers.ApiResponse<string> GetDataReport(string query)
        {
            string where = "";
            bool ret = false;
            if (Session["AdvanceReportFilter"] != null)
            {
                where = Session["AdvanceReportFilter"].ToString();
                if (!ret && query.ToLower().Contains("where") && query.ToLower().Contains("group by"))
                {
                    query = query.ToLower().Replace("group by", " " + where + " group by");
                    ret = true;
                }
                if (!ret && query.ToLower().Contains("where") && !query.ToLower().Contains("group by"))
                {
                    query = query + " AND (" + where + ")";
                    ret = true;
                }
                if (!ret && !query.ToLower().Contains("where") && query.ToLower().Contains("group by"))
                {
                    query = query.ToLower().Replace("group by", " where " + where + " group by");
                    ret = true;
                }
                if (!ret && !query.ToLower().Contains("where") && !query.ToLower().Contains("group by"))
                {
                    query = query + " where " + where;
                    ret = true;
                }
            }
            if (!_tokenManager.GenerateToken()) return null;
            _ISpartanQueryApiConsumer.SetAuthHeader(_tokenManager.Token);
            var resultQuery = _ISpartanQueryApiConsumer.ExecuteRawQuery(query);

            return resultQuery;
        }
        #endregion "Custom methods"
    }
}
