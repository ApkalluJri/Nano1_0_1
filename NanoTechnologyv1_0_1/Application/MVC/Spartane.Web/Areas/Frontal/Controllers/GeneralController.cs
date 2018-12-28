using Newtonsoft.Json;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.SpartaneFile;
using Spartane.Web.Areas.WebApiConsumer.SpartaneQuery;
using Spartane.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Xml;

namespace Spartane.Web.Areas.Frontal.Controllers
{
    public class GeneralController : Controller
    {
        private ITokenManager _tokenManager = null;
        private ISpartaneQueryApiConsumer _ISpartaneQueryApiConsumer = null;
        private ISpartaneFileApiConsumer _ISpartaneFileApiConsumer = null;

        public GeneralController(ITokenManager tokenManager, ISpartaneQueryApiConsumer SpartaneQueryApiConsumer, ISpartaneFileApiConsumer SpartaneFileApiConsumer)
        {
            this._tokenManager = tokenManager;
            this._ISpartaneQueryApiConsumer = SpartaneQueryApiConsumer;
            this._ISpartaneFileApiConsumer = SpartaneFileApiConsumer;
        }

        [System.Web.Http.HttpPost]
        [ValidateInput(false)]
        public ActionResult ExecuteQuery(string query)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartaneQueryApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartaneQueryApiConsumer.ExecuteQuery(query);
                if (result.Success)
                {
                    if (result.Resource == null)
                        result.Resource = "";
                    return Json(result.Resource, JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(null, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetSessionVar(string name)
        {
            try
            {
                var result = Session[name];
                return Json(result ?? "", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult AddSessionVar(string name, string val)
        {
            try
            {
                Session[name] = val;
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetFileNameById(int id)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartaneFileApiConsumer.SetAuthHeader(_tokenManager.Token);
                var file = _ISpartaneFileApiConsumer.GetByKey(id);
                if (file != null)
                    return Json(file.Resource.Description, JsonRequestBehavior.AllowGet);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [System.Web.Mvc.HttpPost]
        public JsonResult SendEmail(string to, string subject, string body)
        {
            try
            {
                string[] separateEmails = to.Split(';');
                List<string> emails = new List<string>();
                foreach (string email in separateEmails)
                {
                    emails.Add(email);
                }
                if (Helper.SendEmail(emails, subject, body))
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [System.Web.Http.HttpPost]
        [ValidateInput(false)]
        public ActionResult ExecuteQueryTable(string query)
        {
            try
            {

                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartaneQueryApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartaneQueryApiConsumer.ExecuteRawQuery(query);

                if (result.Success)
                {
                    if (result.Resource == null)
                        result.Resource = "";
                    return Json(result.Resource, JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(null, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ExecuteQueryDictionary(string query)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartaneQueryApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartaneQueryApiConsumer.ExecuteQueryDictionary(query);
                if (result != null)
                    return Json(result.Resource, JsonRequestBehavior.AllowGet);
                else
                    return Json(null, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        
        public JsonResult GetSpartanFile(int id)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartaneFileApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartaneFileApiConsumer.GetByKey(id);
                if (result.Success)
                {
                    return Json(result.Resource, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(null, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

    }
}