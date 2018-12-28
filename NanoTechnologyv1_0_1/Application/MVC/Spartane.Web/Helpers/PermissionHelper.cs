using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Spartane.Core.Domain.Permission;
using Spartane.Core.Domain.SpartaneFunction;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.SpartaneFunction;
using Spartane.Web.Areas.WebApiConsumer.SpartaneUserRoleObjectFunction;

namespace Spartane.Web.Helpers
{

    public static class PermissionHelper
    {
        private static readonly ISpartaneUserRoleObjectFunctionApiConsumer _spartaneUserRoleObjectFunctionApiConsumer;
        private static readonly ISpartaneFunctionApiConsumer _spartaneFunctionApiConsumer;
        private static readonly ITokenManager _tokenManager;
        static PermissionHelper()
        {
            _tokenManager = DependencyResolver.Current.GetService<ITokenManager>();
            _spartaneUserRoleObjectFunctionApiConsumer = DependencyResolver.Current.GetService<ISpartaneUserRoleObjectFunctionApiConsumer>();
            _spartaneFunctionApiConsumer = DependencyResolver.Current.GetService<ISpartaneFunctionApiConsumer>();
        }

        /// <summary>
        /// Used to get the Permission for Role Object
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="objectId"></param>
        /// <returns></returns>
        public static Permission GetRoleObjectPermission(int roleId, int objectId, int moduleId = 0)
        {
            try
            {
                if (!_tokenManager.GenerateToken("admin", "admin"))
                    throw new ArgumentException("Unable to Authorize the application");

                _spartaneUserRoleObjectFunctionApiConsumer.SetAuthHeader(_tokenManager.Token);
                _spartaneFunctionApiConsumer.SetAuthHeader(_tokenManager.Token);
                string where = "spartan_user_rule_object_function.Object_Id=" + objectId +
                    " AND spartan_user_rule_object_function.Spartan_User_Rule=" + roleId;
                if (moduleId != 0)
                {
                    where += " AND spartan_user_rule_object_function.Module_Id=" + moduleId;
                }
                var userRoleObjectFunctions = _spartaneUserRoleObjectFunctionApiConsumer.ListaSelAll(1, int.MaxValue, where, "").Resource;

                if (userRoleObjectFunctions == null ||
                    userRoleObjectFunctions.Spartan_User_Rule_Object_Functions == null)
                    return new Permission();

                var spartaneFuctions = new List<SpartaneFunction>();

                foreach (var userRoleObjectFunction in userRoleObjectFunctions.Spartan_User_Rule_Object_Functions)
                {
                    spartaneFuctions.Add(_spartaneFunctionApiConsumer.GetByKey(userRoleObjectFunction.Fuction_Id, true).Resource);
                }

                return GetSpartanePermission(spartaneFuctions);

            }
            catch (ArgumentException)
            {
                return new Permission();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private static Permission GetSpartanePermission(IEnumerable<SpartaneFunction> spartaneFunctions)
        {
            var permission = new Permission();
            try
            {



                foreach (var spartaneFunction in spartaneFunctions)
                {
                    if (spartaneFunction.Status == 1)
                        switch (spartaneFunction.Description.ToUpper())
                        {
                            case "CONSULT": permission.Consult = true;
                                break;
                            case "NEW": permission.New = true;
                                break;
                            case "EDIT": permission.Edit = true;
                                break;
                            case "DELETE": permission.Delete = true;
                                break;
                            case "EXPORT": permission.Export = true;
                                break;
                            case "PRINT": permission.Print = true;
                                break;
                            case "CONFIGURE": permission.Configure = true;
                                break;

                        }
                }
                return permission;
            }
            catch (Exception)
            {
                return permission;
            }
        }
    }
}
