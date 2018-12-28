using Spartane.WebApi.Infrastructure;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Spartane.Core.Classes.LDAP;
using Spartane.Core.Enums;
using System.Configuration;
using System.DirectoryServices.AccountManagement;


namespace Spartane.WebApi.Providers
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            var allowedOrigin = "*";

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

            ////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////
            //////// there is a problem, because the user and password are null   //////
            ////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////
            
            string username = "";
            string password = "";

            if (context.UserName == null || context.Password == null)
            {
                context.SetError("invalid_grant", "Debe proporcionar usuario y password.");
                return;
            }
            username = context.UserName;
            password = context.Password;

            bool result = true;
            string key = ConfigurationManager.AppSettings["ActiveDirectoryAuthorization"].ToString();
            //Si tiene configurado validar active directory entonces se debe validar primero con el active directory
            if (key == "1")
            {
                string domain = ConfigurationManager.AppSettings["DomainName"].ToString();
            
                ValidateUser objLDAP = new ValidateUser();
                objLDAP.Domain = domain;
                objLDAP.User = context.UserName;
                objLDAP.Password = context.Password;
                result = ValidateUsingLdap(objLDAP);
            }


            if (result)
            {
                ApplicationUser user = await userManager.FindAsync(username, password);

                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }

                if (user.FirstName == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }

                //if (!user.EmailConfirmed)
                //{
                //    context.SetError("invalid_grant", "User did not confirm email.");
                //    return;
                //}

                ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager, "JWT");
                //oAuthIdentity.AddClaims(ExtendedClaimsProvider.GetClaims(user));
                //oAuthIdentity.AddClaims(RolesFromClaims.CreateRolesBasedOnClaims(oAuthIdentity));

                var ticket = new AuthenticationTicket(oAuthIdentity, null);

                context.Validated(ticket);
            }
            else
            {
                context.SetError("invalid_grant", "User Name or Password not registered in Active Directory");
                return;
            }
           
        }

        public static bool ValidateUsingLdap(ValidateUser objLDAP)
        {
            bool result = false;

            try
            {
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, objLDAP.Domain))
                {
                    result = pc.ValidateCredentials(objLDAP.User, objLDAP.Password);
                }
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }
    }
}