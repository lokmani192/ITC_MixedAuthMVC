using log4net;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MVC.Filters
{
    public class CheckAuthorization:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {

        }

        
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            logger.Info("User name IsAuthenticated " + httpContext.User.Identity.IsAuthenticated);
            logger.Info("User name " + httpContext.User.Identity.Name);
            if (httpContext.User.Identity.IsAuthenticated)
            {
                if (!string.IsNullOrEmpty(httpContext.User.Identity.Name))
                {
                    logger.Info("User name " + httpContext.User.Identity.Name);
                    string[] domainUser = httpContext.User.Identity.Name.Split('\\');
                    if (domainUser.Count() == 2)
                    {
                        if (domainUser[0].Equals("MyDomain", StringComparison.OrdinalIgnoreCase))
                        {
                            //LdapService ldap = new LdapService();
                            //return ldap.IsUserInAd(domainUser[1]);
                        }
                    }
                }
            }
            return base.AuthorizeCore(httpContext);
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
            filterContext.Result = new RedirectResult("~/Error/Unauthorized");
        }
    }
}