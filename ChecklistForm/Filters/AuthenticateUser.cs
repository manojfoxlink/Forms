using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ChecklistForm.Filters
{
    public class AuthenticateUser : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            string TempSession =
                Convert.ToString(filterContext.HttpContext.Session["AuthenticationToken"]);
            string TempAuthCookie =
                Convert.ToString(filterContext.HttpContext.Request.Cookies["AuthenticationToken"].Value);

            if (TempSession != null && TempAuthCookie != null)
            {
                if (!TempSession.Equals(TempAuthCookie))
                {
                    string redirectTo = "~/Account/Login";


                    filterContext.Result = new RedirectResult(redirectTo);

                }
            }
            else
            {
                string redirectTo = "~/Account/Login";
                filterContext.Result = new RedirectResult(redirectTo);
            }
        }
    }
}