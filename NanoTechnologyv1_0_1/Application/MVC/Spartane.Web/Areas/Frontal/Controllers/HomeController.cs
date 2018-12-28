using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Controllers;
using Spartane.Web.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Spartane.Web.Areas.Frontal.Controllers
{
    public class HomeController : BaseController
    {
        #region "Variable Declaration"

        /// <summary>
        /// Declare User API Consumer
        /// </summary>
        private ISpartan_UserApiConsumer _IUseroApiConsumer;

        #endregion "Variable Declaration"

        #region "Cusontructor"

        /// <summary>
        /// Declare controller constructor
        /// </summary>
        /// <param name="UseroApiConsumer"></param>
        public HomeController(ISpartan_UserApiConsumer UseroApiConsumer)
        {
            // set User API Consumer instance using interface
            this._IUseroApiConsumer = UseroApiConsumer;
        }

        #endregion "Cusontructor"

        public ActionResult Default()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Modulos()
        {
            return View();
        }

        public ActionResult WriteResourceFile()
        {
            //XmlNode loRoot = loResource.SelectSingleNode("root/data[@name='RequiredFields']/value");
            //if (loRoot != null)
            //{
            //    loRoot.InnerText = "test";
            //    loResource.Save(Server.MapPath("/App_GlobalResources/TDLResources.de-DE.resx"));
            //}
            return View();
        }

        /// <summary>
        /// Load Change password view
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public ActionResult ChangePassword(string returnUrl)
        {
            ChangePasswordViewModel oChangePasswordViewModel = new ChangePasswordViewModel();
            // set Username , email and user id with change password model
            oChangePasswordViewModel.UserName = CurrentUser.CurrentUser.UserName;
            oChangePasswordViewModel.Id_User = CurrentUser.CurrentUser.Id_User;
            oChangePasswordViewModel.Email = CurrentUser.CurrentUser.Email;

            ViewBag.ReturnUrl = returnUrl;
            return View(oChangePasswordViewModel);
        }

        /// <summary>
        /// Post request to change user password
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Get User Details entity from Web API
                    Spartan_User_Core UserDetails = _IUseroApiConsumer.ValidateUser(1, 10, "Id_User = '" + model.Id_User + "'  COLLATE SQL_Latin1_General_CP1_CS_AS And Password = '" + model.OldPassword + "'  COLLATE SQL_Latin1_General_CP1_CS_AS" + " And UserName = '" + model.UserName + "'  COLLATE SQL_Latin1_General_CP1_CS_AS").Resource;

                    // check for user exist in database
                    if (UserDetails.Spartan_Users != null && UserDetails.Spartan_Users.Count() > 0)
                    {
                        // set Get user from webapi in local variable
                        SpartanUser oSpartanUser = UserDetails.Spartan_Users.Where(x => x.Id_User == model.Id_User).FirstOrDefault();
                        // set new password with user entity
                        oSpartanUser.Password = model.NewPassword;
                        // call api for update user password
                        Spartane.Core.Domain.Spartan_User.Spartan_User user = new Core.Domain.Spartan_User.Spartan_User();
                        

                        //_IUseroApiConsumer.Update(oSpartanUser, null, null);

                        model.IsSuccess = true;
                        model.OperationMessage = Resources.LoginResources.PasswordChanged;
                    }
                    else
                    { model.OperationMessage = Resources.LoginResources.EnteredPasswordInCorrect; }
                }
                catch (Exception)
                { model.OperationMessage = Resources.LoginResources.ErrorUpdatePassword; }
            }
            return View(model);
        }
    }
}