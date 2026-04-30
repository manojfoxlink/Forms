using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ChecklistForm.Filters
{
    public class CheckSessionOutAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext context = HttpContext.Current;
            if (context.Session != null)
            {
                if (context.Session.IsNewSession)
                {
                    string sessionCookie = context.Request.Headers["Cookie"];

                    if ((sessionCookie != null) && (sessionCookie.IndexOf("ASP.NET_SessionId") >= 0))
                    {
                        FormsAuthentication.SignOut();
                        string redirectTo = "~/Account/Login";
                        if (!string.IsNullOrEmpty(context.Request.RawUrl))
                        {
                            redirectTo = string.Format("~/Account/Login", HttpUtility.UrlEncode(context.Request.RawUrl));
                            filterContext.Result = new RedirectResult(redirectTo);
                            return;
                        }

                    }
                }
                if (context.Session["IsAdmin"] == null)
                {
                    FormsAuthentication.SignOut();
                    string redirectTo = "~/Account/Login";
                    redirectTo = string.Format("~/Account/Login", HttpUtility.UrlEncode(context.Request.RawUrl));
                    filterContext.Result = new RedirectResult(redirectTo);
                    return;
                }//else
                //{
                //    FormsAuthentication.SignOut();
                //    string redirectTo = "~/Home/Index";
                //    redirectTo = string.Format("~/Home/Index", HttpUtility.UrlEncode(context.Request.RawUrl));
                //    filterContext.Result = new RedirectResult(redirectTo);
                //    return;
                //}


            }

            base.OnActionExecuting(filterContext);
        }
    }
}