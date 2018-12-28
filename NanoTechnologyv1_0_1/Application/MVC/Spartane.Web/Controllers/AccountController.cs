using Spartane.Core.Domain.Binnacle;
using Spartane.Core.Domain.Language;
using Spartane.Core.Domain.User;
using Spartane.Core.Enums;
using Spartane.Services.Authentication;
using Spartane.Services.Security;
using Spartane.Services.User;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.AuthenticationExt;
using Spartane.Web.Helpers;
using Spartane.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Spartane.Web.Controllers
{
    [Authorize]
    public partial class AccountController : BaseController
    {
        #region "variable Declaration"

        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        private readonly IPermissionService _permissionService;

        private ILanguageApiConsumer _ILanguageoApiConsumer;
        private ISpartan_UserApiConsumer _IUseroApiConsumer;
        private ISpartanSecurityApiConsumer _ISpartanSecurityApiConsumer;
        private ISpartanSessionApiConsumer _ISpartanSessionApiConsumer;

        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable Declaration"

        #region "Constructor"

        public AccountController(IAuthenticationService authenticationService,
            IUserService userService, ISpartane_FileApiConsumer Spartane_FileApiConsumer, IPermissionService permissionService, ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ILanguageApiConsumer languageoApiConsumer, ISpartan_UserApiConsumer UseroApiConsumer, ISpartanSessionApiConsumer oSpartanSessionAPIConsumer, ISpartanSecurityApiConsumer oSpartanSecurityAPIConsumer)
        {
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._authenticationService = authenticationService;
            this._userService = userService;
            this._permissionService = permissionService;

            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;

            this._ILanguageoApiConsumer = languageoApiConsumer;
            this._IUseroApiConsumer = UseroApiConsumer;

            this._ISpartanSecurityApiConsumer = oSpartanSecurityAPIConsumer;
            this._ISpartanSessionApiConsumer = oSpartanSessionAPIConsumer;

        }

        #endregion "Constructor"

        #region Login / Logout

        /// <summary>
        /// Get Login View
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            LoginViewModel oLoginViewModel = new LoginViewModel();

            oLoginViewModel.LanguageList = GetLanguage();

            ViewBag.ReturnUrl = returnUrl;
            return View(oLoginViewModel);
        }

        /// <summary>
        /// Login Post method for check authorization and logged in with system
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {

            if (ModelState.ContainsKey("LanguageList"))
            { ModelState["LanguageList"].Errors.Clear(); }

            if (ModelState.IsValid)
            {
                if (!_tokenManager.GenerateToken(model.UserName, model.Password))
                {
                    ModelState.AddModelError("", Resources.LoginResources.InvalidUserPassword);
                }

                _IUseroApiConsumer.SetAuthHeader(_tokenManager.Token);

                Spartan_Security_Log oSecurityLog = new Spartan_Security_Log();

                // Call Validate User API for user Exists in application
                Spartan_User_Core UserDetails = _IUseroApiConsumer.ValidateUser(1, 10, "Username = '" + model.UserName + "'  COLLATE SQL_Latin1_General_CP1_CS_AS And Password = '" + model.Password + "'  COLLATE SQL_Latin1_General_CP1_CS_AS").Resource;
                if (UserDetails.Spartan_Users != null && UserDetails.Spartan_Users.Count() > 0)
                {
                    if (UserDetails.Spartan_Users[0].Status == 1)
                    {
                        TTUsuario user = new TTUsuario
                        {
                            IdUsuario = Convert.ToInt16(UserDetails.Spartan_Users[0].Id_User),
                            Nombre = Convert.ToString(UserDetails.Spartan_Users[0].Name),
                            Clave_de_Acceso = UserDetails.Spartan_Users[0].Username,
                            //Activo = UserDetails.Spartan_Users[0].Status
                        };

                        SetSecurityLogging(ref oSecurityLog, (short)Event_Type.Login, UserDetails.Spartan_Users[0].Id_User, UserDetails.Spartan_Users[0].Role, (short)Result_Type.Granted);
                        int SecurityLogId = _ISpartanSecurityApiConsumer.Insert(oSecurityLog).Resource;

                        SetAuthentication(UserDetails);
                        //_authenticationService.SignIn(user, model.RememberMe);

                        //Adding user Core entity Data
                        SessionHelper.UserEntity = UserDetails.Spartan_Users[0];

                        //Getting User Image
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        var userImage =
                            _ISpartane_FileApiConsumer.GetByKey(Convert.ToInt32(UserDetails.Spartan_Users[0].Image))
                                .Resource;
                        if (userImage != null && userImage.File != null)
                            SessionHelper.UserImage = userImage.File;
                        Response.Cookies["UserSettings"]["SecurityLogId"] = SecurityLogId.ToString();

                        Spartan_Session_Log oSessionLog = new Spartan_Session_Log();
                        SetSessionLogging(ref oSessionLog, (short)Event_Type.Login, (short)Event_Type.Login, SecurityLogId, UserDetails.Spartan_Users[0].Id_User, UserDetails.Spartan_Users[0].Role, (short)Result_Type.Granted);
                        _ISpartanSessionApiConsumer.Insert(oSessionLog);


                        //Saving Credentials
                        SessionHelper.UserCredential = new Spartane_Credential
                        {
                            Password = model.Password,
                            UserName = model.UserName,
                        };
                        // save role id in session
                        SessionHelper.Role = UserDetails.Spartan_Users[0].Role;
                        // save role object in session
                        SessionHelper.Sprtan_Role = new RoleSpartanUserRole
                        {
                            Id = UserDetails.Spartan_Users[0].Role_Spartan_User_Role.Id,
                            Description = UserDetails.Spartan_Users[0].Role_Spartan_User_Role.Description,
                            Status = UserDetails.Spartan_Users[0].Role_Spartan_User_Role.Status,
                            Status_Spartan_User_Role_Status = UserDetails.Spartan_Users[0].Role_Spartan_User_Role.Status_Spartan_User_Role_Status,
                            User_Role_Id = UserDetails.Spartan_Users[0].Role_Spartan_User_Role.User_Role_Id,
                        };
                        Session["USERID"] = user.IdUsuario;
                        Session["USERROLEID"] = UserDetails.Spartan_Users[0].Role_Spartan_User_Role.User_Role_Id;
                        Session.Timeout = Convert.ToInt32(ConfigurationManager.AppSettings["SessionTimeOut"]);
                        return RedirectToLocal("~/Frontal/Home/Index");
                    }
                    else
                    {
                        SetSecurityLogging(ref oSecurityLog, (short)Event_Type.Login, null, null, (short)Result_Type.Denied);
                        _ISpartanSecurityApiConsumer.Insert(oSecurityLog);

                        ModelState.AddModelError("", Resources.LoginResources.DeactivateAccount);
                    }
                }
                else
                {
                    SetSecurityLogging(ref oSecurityLog, (short)Event_Type.Login, null, null, (short)Result_Type.Denied);
                    _ISpartanSecurityApiConsumer.Insert(oSecurityLog);

                    ModelState.AddModelError("", Resources.LoginResources.InvalidUserPassword);
                }
            }
            model.LanguageList = GetLanguage();
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult ReLogin(LoginViewModel model, string returnUrl)
        {
            if (HttpContext.User != null && HttpContext.User.Identity != null && HttpContext.User.Identity.IsAuthenticated)
            {
                if (ModelState.ContainsKey("LanguageList"))
                { ModelState["LanguageList"].Errors.Clear(); }

                if (ModelState.IsValid)
                {
                    if (!_tokenManager.GenerateToken(model.UserName, model.Password))
                    {
                        ModelState.AddModelError("", Resources.LoginResources.InvalidUserPassword);
                    }

                    _IUseroApiConsumer.SetAuthHeader(_tokenManager.Token);

                    // Call Validate User API for user Exists in application
                    Spartan_User_Core UserDetails = _IUseroApiConsumer.ValidateUser(1, 10, "Username = '" + model.UserName + "'  COLLATE SQL_Latin1_General_CP1_CS_AS And Password = '" + model.Password + "'  COLLATE SQL_Latin1_General_CP1_CS_AS").Resource;
                    if (UserDetails.Spartan_Users != null && UserDetails.Spartan_Users.Count() > 0)
                    {
                        //return Json(string.Empty);
                        if (UserDetails.Spartan_Users[0].Status == 1)
                        {
                            TTUsuario user = new TTUsuario
                            {
                                IdUsuario = Convert.ToInt16(UserDetails.Spartan_Users[0].Id_User),
                                Nombre = Convert.ToString(UserDetails.Spartan_Users[0].Name),
                                Clave_de_Acceso = UserDetails.Spartan_Users[0].Username,
                                //Activo = UserDetails.Spartan_Users[0].Status
                            };


                            SetAuthentication(UserDetails);
                            //_authenticationService.SignIn(user, model.RememberMe);


                            //Saving Credentials
                            SessionHelper.UserCredential = new Spartane_Credential
                            {
                                Password = model.Password,
                                UserName = model.UserName,
                            };
                            // save role id in session
                            SessionHelper.Role = UserDetails.Spartan_Users[0].Role;
                            // save role object in session
                            SessionHelper.Sprtan_Role = new RoleSpartanUserRole
                            {
                                Id = UserDetails.Spartan_Users[0].Role_Spartan_User_Role.Id,
                                Description = UserDetails.Spartan_Users[0].Role_Spartan_User_Role.Description,
                                Status = UserDetails.Spartan_Users[0].Role_Spartan_User_Role.Status,
                                Status_Spartan_User_Role_Status = UserDetails.Spartan_Users[0].Role_Spartan_User_Role.Status_Spartan_User_Role_Status,
                                User_Role_Id = UserDetails.Spartan_Users[0].Role_Spartan_User_Role.User_Role_Id,
                            };
                            Session["USERID"] = user.IdUsuario;
                            Session["USERROLEID"] = UserDetails.Spartan_Users[0].Role_Spartan_User_Role.User_Role_Id;
                            Session.Timeout = Convert.ToInt32(ConfigurationManager.AppSettings["SessionTimeOut"]);
                            return Json(string.Empty);
                        }
                        else
                        {
                            ModelState.AddModelError("", Resources.LoginResources.DeactivateAccount);
                        }

                    }
                    else
                    {
                        ModelState.AddModelError("", Resources.LoginResources.InvalidPassword);
                    }
                }
            }
            else
                ModelState.AddModelError("", Resources.LoginResources.SessionExpired);
            return Json("SessionExpired");
        }

        // POST: /Account/LogOff
        [HttpPost]
        public ActionResult LogOff()
        {

            Spartan_Session_Log oSessionLog = new Spartan_Session_Log();
            SetSessionLogging(ref oSessionLog, (short)Event_Type.Login, (short)Event_Type.LogOut, Convert.ToInt32(Request.Cookies["UserSettings"]["SecurityLogId"]), CurrentUser.CurrentUser.Id_User, CurrentUser.CurrentUser.Role, (short)Result_Type.Granted);
            _ISpartanSessionApiConsumer.Insert(oSessionLog);

            FormsAuthentication.SignOut();

            // clear all session
            Session.Abandon();
            // Clear authentication cookie.
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);
            HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Response.Cache.SetNoServerCaching();
            HttpContext.Response.Cache.SetNoStore();

            return RedirectToAction("Login", "Account");
        }


        #endregion Login / Logout

        #region "Forgot password"

        [HttpPost]
        [AllowAnonymous]
        public JsonResult ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Spartan_User_Core UserDetails = _IUseroApiConsumer.ValidateUser(1, 10, "Username = '" + model.UserName + "'  COLLATE SQL_Latin1_General_CP1_CS_AS And Email = '" + model.Email + "'").Resource;
                    if (UserDetails.Spartan_Users != null && UserDetails.Spartan_Users.Count() > 0)
                    {
                        if (System.IO.File.Exists(Server.MapPath("~") + "HTMLTemplates\\ForgotPassword.html"))
                        {
                            // Get HTML Template for Forgot password
                            StreamReader sread = new StreamReader(Server.MapPath("~") + "HTMLTemplates\\ForgotPassword.html");
                            string strBodyTemplate = sread.ReadToEnd();
                            // Replace User Full Name
                            strBodyTemplate = strBodyTemplate.Replace("*|fullname|*", UserDetails.Spartan_Users[0].Name);
                            strBodyTemplate = strBodyTemplate.Replace("*|username|*", UserDetails.Spartan_Users[0].Username);
                            strBodyTemplate = strBodyTemplate.Replace("*|email|*", UserDetails.Spartan_Users[0].Email);
                            strBodyTemplate = strBodyTemplate.Replace("*|password|*", UserDetails.Spartan_Users[0].Password);
                            // Replace ForgotPassword Link with Token and Encrypted Email
                            List<string> emails = new List<string>();
                            emails.Add(model.Email);
                            if (Helper.SendEmail(emails, string.Format(Resources.LoginResources.ForgotPasswordEmailSubject, model.UserName), strBodyTemplate))
                            {
                                return Json(string.Format(Resources.LoginResources.ForgotPasswordSuccess, model.Email));
                            }
                            else
                                return Json(Resources.LoginResources.ForgotPasswordEmailError);
                        }
                        else { return Json(Resources.LoginResources.ForgotPasswordEmailError); }
                    }
                    else
                    {
                        return Json(Resources.LoginResources.InvalidEmailUserName);
                    }
                }
                catch (Exception)
                {
                    return Json(Resources.LoginResources.ForgotPasswordEmailError);
                }
            }
            else
            {
                return Json(Resources.LoginResources.InvalidEmailUserName);
            }
        }

        #endregion


        #region "Change Language"

        /// <summary>
        /// Language Drop down change event
        /// </summary>
        /// <param name="culture"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult ChangeLanguage(string culture)
        {
            // To Do : currently we are not getting culture from language api once we got language culture than comment below line
            culture = (culture == "1" ? "en-US" : "es-ES");
            //culture = "es-ES";

            // Validate input
            culture = CultureHelper.GetImplementedCulture(culture);

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            RouteData.Values["culture"] = culture;

            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;   // update cookie value
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);

            return RedirectToAction("Login");
        }

        /// <summary>
        /// Get List of language from API
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public IList<LanguageModel> GetLanguage()
        {
            IList<LanguageModel> LanguageList;

            // get language from API and cast from one entity to another entity list using generic reflection function
            LanguageList = Helper.ConvertToList<LanguageModel, SpartanLanguage>(_ILanguageoApiConsumer.GetAll().Resource);
            if (LanguageList == null)
            {
                LanguageList = new List<LanguageModel>();
            }


            return LanguageList;
        }

        #endregion "Change Language"

        #region Manage Information account

        // GET: /Account/Manage
        public ActionResult Manage()
        {
            InformationUser modelInformationUser = new InformationUser();

            var loginName = this.HttpContext.User.Identity.Name;
            var userGlobalData = _userService.GetGlobalDataByUserName(loginName);
            //var itemPerm = _permissionService.ModulesPermited(userGlobalData);
            //var dashboardsPermited = _permissionService.DashBoardsPermited(userGlobalData);
            //modelInformationUser.DashBoardsPermited = dashboardsPermited;
            modelInformationUser.GlobalData = userGlobalData;
            //modelInformationUser.ModulesPermited = itemPerm;
            modelInformationUser.OperationsPermited = new List<OperationPermited>();
            foreach (Operations operation in Enum.GetValues(typeof(Operations)))
            {
                OperationPermited operationPermited = new OperationPermited();
                operationPermited.Operation = operation;
                //operationPermited.Permited = _permissionService.isOperationPermited(6400, operation, userGlobalData);
                modelInformationUser.OperationsPermited.Add(operationPermited);
            }
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View(modelInformationUser);
        }

        #endregion Manage Information account

        #region Helpers

        /// <summary>
        /// Redirect to return URL
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private void SetAuthentication(Spartan_User_Core UserDetails)
        {
            // create instance of context view model
            ContextViewModel CM = new ContextViewModel();

            // set logged in values with context view model to store values with cookies
            CM.Email = UserDetails.Spartan_Users[0].Email;
            CM.Id = UserDetails.Spartan_Users[0].Id;
            CM.Id_User = UserDetails.Spartan_Users[0].Id_User;
            CM.Password = UserDetails.Spartan_Users[0].Password;
            CM.Role = UserDetails.Spartan_Users[0].Role;
            CM.Status = UserDetails.Spartan_Users[0].Status;
            CM.Name = UserDetails.Spartan_Users[0].Name;
            CM.UserName = UserDetails.Spartan_Users[0].Username;

            AuthenticationSerialize serialiseAuth = new AuthenticationSerialize();

            UserContextViewModel userContext = new UserContextViewModel();
            userContext.CurrentUser = CM;
            serialiseAuth.UserContext = userContext;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string userData = serializer.Serialize(serialiseAuth);

            // set login cookie time for user
            var tenDaysFromNow = DateTime.UtcNow.AddMinutes(Convert.ToInt32(ConfigurationManager.AppSettings["SessionTimeOut"]));

            // set form authentication ticket with logged int user values
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                            1,
                             serialiseAuth.UserContext.CurrentUser.UserName + " " + serialiseAuth.UserContext.CurrentUser.UserName,
                             DateTime.Now,
                             tenDaysFromNow,
                             false,
                            userData);

            string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);

            // Add values of user with browser cookie
            Response.Cookies.Add(faCookie);
        }

        private void SetSecurityLogging(ref Spartan_Security_Log oSecurityLog, short Event_Type, int? User_Id, int? User_Role_Id, short Result_Id)
        {
            oSecurityLog.Event_Type = Event_Type;
            oSecurityLog.Result_Id = Result_Id;
            oSecurityLog.Log_Date = DateTime.Now;
            oSecurityLog.User_Role_Id = User_Role_Id;
            oSecurityLog.User_Id = User_Id;
            oSecurityLog.IP_Address_Source = Helper.IPAddress();
            oSecurityLog.IP_Address_Target = Helper.IPAddress();
            oSecurityLog.Computer_Name = System.Environment.MachineName;
            oSecurityLog.Language_Id = 1;
            oSecurityLog.Security_Log_Id = 0;
            oSecurityLog.URL = HttpContext.Request.Url.ToString();
        }

        private void SetSessionLogging(ref Spartan_Session_Log oSessionLog, short Event_Type, short Event_Type2, int Security_Log_Id, int User_Id, int User_Role_Id, short Result_Id)
        {

            oSessionLog.Event_Type = Event_Type;
            oSessionLog.Result_Id = Result_Id;
            oSessionLog.Log_Date = DateTime.Now;
            oSessionLog.User_Role_Id = User_Role_Id;
            oSessionLog.User_Id = User_Id;
            oSessionLog.IP_Address_Source = Helper.IPAddress();
            oSessionLog.IP_Address_Target = Helper.IPAddress();
            oSessionLog.Computer_Name = System.Environment.MachineName;
            oSessionLog.Language_Id = 1;
            oSessionLog.URL = HttpContext.Request.Url.ToString();
            oSessionLog.Event_Type2 = Event_Type2;
            oSessionLog.Security_Log_Id = Security_Log_Id;
            oSessionLog.Session_Log_Id = 0;
        }

        #endregion Helpers

        //// GET: /Account/Register
        //[AllowAnonymous]
        //public ActionResult Register()
        //{
        //    return View();
        //}

        ////
        //// POST: /Account/Register
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Register(RegisterViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new ApplicationUser() { UserName = model.UserName };
        //        var result = await UserManager.CreateAsync(user, model.Password);
        //        if (result.Succeeded)
        //        {
        //            await SignInAsync(user, isPersistent: false);
        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            AddErrors(result);
        //        }
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}

        ////
        //// POST: /Account/Disassociate
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Disassociate(string loginProvider, string providerKey)
        //{
        //    ManageMessageId? message = null;
        //    IdentityResult result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
        //    if (result.Succeeded)
        //    {
        //        message = ManageMessageId.RemoveLoginSuccess;
        //    }
        //    else
        //    {
        //        message = ManageMessageId.Error;
        //    }
        //    return RedirectToAction("Manage", new { Message = message });
        //}

        ////
        //// GET: /Account/Manage
        //public ActionResult Manage(ManageMessageId? message)
        //{
        //    ViewBag.StatusMessage =
        //        message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
        //        : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
        //        : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
        //        : message == ManageMessageId.Error ? "An error has occurred."
        //        : "";
        //    ViewBag.HasLocalPassword = HasPassword();
        //    ViewBag.ReturnUrl = Url.Action("Manage");
        //    return View();
        //}

        ////
        //// POST: /Account/Manage
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Manage(ManageUserViewModel model)
        //{
        //    bool hasPassword = HasPassword();
        //    ViewBag.HasLocalPassword = hasPassword;
        //    ViewBag.ReturnUrl = Url.Action("Manage");
        //    if (hasPassword)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            IdentityResult result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
        //            if (result.Succeeded)
        //            {
        //                return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
        //            }
        //            else
        //            {
        //                AddErrors(result);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        // User does not have a password so remove any validation errors caused by a missing OldPassword field
        //        ModelState state = ModelState["OldPassword"];
        //        if (state != null)
        //        {
        //            state.Errors.Clear();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            IdentityResult result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
        //            if (result.Succeeded)
        //            {
        //                return RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
        //            }
        //            else
        //            {
        //                AddErrors(result);
        //            }
        //        }
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}

        ////
        //// POST: /Account/ExternalLogin
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public ActionResult ExternalLogin(string provider, string returnUrl)
        //{
        //    // Request a redirect to the external login provider
        //    return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        //}

        ////
        //// GET: /Account/ExternalLoginCallback
        //[AllowAnonymous]
        //public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        //{
        //    var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
        //    if (loginInfo == null)
        //    {
        //        return RedirectToAction("Login");
        //    }

        //    // Sign in the user with this external login provider if the user already has a login
        //    var user = await UserManager.FindAsync(loginInfo.Login);
        //    if (user != null)
        //    {
        //        await SignInAsync(user, isPersistent: false);
        //        return RedirectToLocal(returnUrl);
        //    }
        //    else
        //    {
        //        // If the user does not have an account, then prompt the user to create an account
        //        ViewBag.ReturnUrl = returnUrl;
        //        ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
        //        return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { UserName = loginInfo.DefaultUserName });
        //    }
        //}

        ////
        //// POST: /Account/LinkLogin
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult LinkLogin(string provider)
        //{
        //    // Request a redirect to the external login provider to link a login for the current user
        //    return new ChallengeResult(provider, Url.Action("LinkLoginCallback", "Account"), User.Identity.GetUserId());
        //}

        ////
        //// GET: /Account/LinkLoginCallback
        //public async Task<ActionResult> LinkLoginCallback()
        //{
        //    var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, User.Identity.GetUserId());
        //    if (loginInfo == null)
        //    {
        //        return RedirectToAction("Manage", new { Message = ManageMessageId.Error });
        //    }
        //    var result = await UserManager.AddLoginAsync(User.Identity.GetUserId(), loginInfo.Login);
        //    if (result.Succeeded)
        //    {
        //        return RedirectToAction("Manage");
        //    }
        //    return RedirectToAction("Manage", new { Message = ManageMessageId.Error });
        //}

        ////
        //// POST: /Account/ExternalLoginConfirmation
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        return RedirectToAction("Manage");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        // Get the information about the user from the external login provider
        //        var info = await AuthenticationManager.GetExternalLoginInfoAsync();
        //        if (info == null)
        //        {
        //            return View("ExternalLoginFailure");
        //        }
        //        var user = new ApplicationUser() { UserName = model.UserName };
        //        var result = await UserManager.CreateAsync(user);
        //        if (result.Succeeded)
        //        {
        //            result = await UserManager.AddLoginAsync(user.Id, info.Login);
        //            if (result.Succeeded)
        //            {
        //                await SignInAsync(user, isPersistent: false);
        //                return RedirectToLocal(returnUrl);
        //            }
        //        }
        //        AddErrors(result);
        //    }

        //    ViewBag.ReturnUrl = returnUrl;
        //    return View(model);
        //}

        ////
        //// POST: /Account/LogOff
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult LogOff()
        //{
        //    AuthenticationManager.SignOut();
        //    return RedirectToAction("Index", "Home");
        //}

        ////
        //// GET: /Account/ExternalLoginFailure
        //[AllowAnonymous]
        //public ActionResult ExternalLoginFailure()
        //{
        //    return View();
        //}

        //[ChildActionOnly]
        //public ActionResult RemoveAccountList()
        //{
        //    var linkedAccounts = UserManager.GetLogins(User.Identity.GetUserId());
        //    ViewBag.ShowRemoveButton = HasPassword() || linkedAccounts.Count > 1;
        //    return (ActionResult)PartialView("_RemoveAccountPartial", linkedAccounts);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && UserManager != null)
        //    {
        //        UserManager.Dispose();
        //        UserManager = null;
        //    }
        //    base.Dispose(disposing);
        //}

        //#region Helpers
        //// Used for XSRF protection when adding external logins
        //private const string XsrfKey = "XsrfId";

        //private IAuthenticationManager AuthenticationManager
        //{
        //    get
        //    {
        //        return HttpContext.GetOwinContext().Authentication;
        //    }
        //}

        //private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        //{
        //    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
        //    var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
        //    AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        //}

        //private void AddErrors(IdentityResult result)
        //{
        //    foreach (var error in result.Errors)
        //    {
        //        ModelState.AddModelError("", error);
        //    }
        //}

        //private bool HasPassword()
        //{
        //    var user = UserManager.FindById(User.Identity.GetUserId());
        //    if (user != null)
        //    {
        //        return user.PasswordHash != null;
        //    }
        //    return false;
        //}

        //public enum ManageMessageId
        //{
        //    ChangePasswordSuccess,
        //    SetPasswordSuccess,
        //    RemoveLoginSuccess,
        //    Error
        //}

        //private ActionResult RedirectToLocal(string returnUrl)
        //{
        //    if (Url.IsLocalUrl(returnUrl))
        //    {
        //        return Redirect(returnUrl);
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //}

        //private class ChallengeResult : HttpUnauthorizedResult
        //{
        //    public ChallengeResult(string provider, string redirectUri) : this(provider, redirectUri, null)
        //    {
        //    }

        //    public ChallengeResult(string provider, string redirectUri, string userId)
        //    {
        //        LoginProvider = provider;
        //        RedirectUri = redirectUri;
        //        UserId = userId;
        //    }

        //    public string LoginProvider { get; set; }
        //    public string RedirectUri { get; set; }
        //    public string UserId { get; set; }

        //    public override void ExecuteResult(ControllerContext context)
        //    {
        //        var properties = new AuthenticationProperties() { RedirectUri = RedirectUri };
        //        if (UserId != null)
        //        {
        //            properties.Dictionary[XsrfKey] = UserId;
        //        }
        //        context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
        //    }
        //}
        //#endregion
    }
}