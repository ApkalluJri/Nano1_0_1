using System.Web.Mvc;

namespace Spartane.Web.Areas.Frontal.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Frontal/Accounts
        public ActionResult UnAuthorized(string controllerName, string actionName)
        {
            ViewBag.ControllerName = controllerName;
            ViewBag.ActionName = actionName;

            return View();
        }

        public ActionResult CollapseDesign()
        {
            return View();
        }
    }
}