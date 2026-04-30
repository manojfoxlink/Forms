using System;
using System.Collections.Generic;
using System.Linq;
//using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
//using DotNetOpenAuth.AspNet;
//using Microsoft.Web.WebPages.OAuth;
//using WebMatrix.WebData;
//using Scrapbility.Filters;
//using Scrapbility.Models;
//using System.Data;
//using log4net;
using ChecklistForm.Models;
using BAL;
using System.Data;


namespace ChecklistForm.Controllers
{
    //private static readonly ILog Log = log4net.LogManager.GetLogger(typeof(AccountController));
    public class AccountController : Controller
    {
        EmployeeBAL _objBalEmployee = new EmployeeBAL();
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }
        #region

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            try
            {
                EnsureLoggedOut();
                LoginViewModel objLogin = new LoginViewModel();
                Random objRandom = new Random();


                objLogin.hdrandomSeed = FormsAuthentication.HashPasswordForStoringInConfigFile(Convert.ToString(objRandom.Next()), "MD5");

                objLogin.ReturnUrl = returnUrl;

                return View(objLogin);


            }
            catch (Exception ex)
            {

                //   Log.Error("Hi I am log4net Error Level", ex);


            }
            return View();
        }
        #endregion

        #region --> Login POST Method
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]

        public ActionResult Login(LoginViewModel login)
        {

            try
            {
                if (!ModelState.IsValid)
                    return View(login);

                DataSet ds = ReturnEnmployeeDeteails(login.UserId);

                if (ds.Tables.Count > 0)
                {

                    DataTable dt1 = ds.Tables["Employees"];
                    DataTable dt2 = ds.Tables["Roles"];
                    Session["MenusList"] = ds.Tables["Menus"];
                    string storedpassword = (dt1.AsEnumerable().Where(p => p.Field<string>("EmpNumber") == login.UserId.ToUpper()).Select(p => p.Field<string>("Password"))).FirstOrDefault();


                    if (ReturnHash(storedpassword, login.hdrandomSeed) == login.Password)
                    {

                        int UserId = (dt1.AsEnumerable().Where(p => p.Field<string>("EmpNumber") == login.UserId.ToUpper()).Select(p => p.Field<Int32>("EmpId"))).FirstOrDefault();
                        int RactionEmpId = (dt1.AsEnumerable().Where(p => p.Field<string>("EmpNumber") == login.UserId.ToUpper()).Select(p => p.Field<Int32>("RactionEmpId"))).FirstOrDefault();
                        string Name = (dt1.AsEnumerable().Where(p => p.Field<string>("EmpNumber") == login.UserId.ToUpper()).Select(p => p.Field<string>("Name"))).FirstOrDefault();
                        string Picture = (dt1.AsEnumerable().Where(p => p.Field<string>("EmpNumber") == login.UserId.ToUpper()).Select(p => p.Field<string>("ProfilePicture"))).FirstOrDefault();

                        if (Picture != null && Picture != "")
                        {

                            Session["Picture"] = Picture;

                        }
                        else
                        {

                            Session["Picture"] = "";

                        }

                        Session["Name"] = Name;
                        Session["EmpNumber"] = login.UserId;


                        int RoleId = (dt2.AsEnumerable().Where(p => p.Field<string>("RoleName") == "Admin").Select(p => p.Field<int>("RoleId"))).FirstOrDefault();
                        //int WareHouseTypeId = (dt2.AsEnumerable().Select(p => p.Field<int>("WareHouseId"))).FirstOrDefault();

                        //Session["WareHouseTypeId"] = WareHouseTypeId;

                        if (RoleId > 0)
                        {
                            Session["IsAdmin"] = true;
                        }
                        else
                        {
                            Session["IsAdmin"] = false;
                        }


                        SignInRemember(login.UserId, login.IsRememberMe);
                        string strGuid = Convert.ToString(Guid.NewGuid());


                        Session["UserID"] = UserId;
                        Session["RactionEmpId"] = RactionEmpId;
                        Session["AuthenticationToken"] = strGuid;


                        Response.Cookies.Add(new HttpCookie("AuthenticationToken", strGuid));


                        return RedirectToLocal(login.ReturnUrl);

                    }
                    else
                    {
                        //Login Fail  

                        ModelState.AddModelError("ERROR", "The user name or password provided is incorrect.");


                    }

                }
                else
                {

                    ModelState.AddModelError("ERROR", "Access Denied! Invalid User");
                }
            }

            catch (Exception ex)
            {
                //Log.Error("Hi I am log4net Error Level", ex);
                //Log.Fatal("Hi I am log4net Fatal Level", ex);

            }
            return View(login);
        }

        #endregion

        #region --> Ensure Logged Out Get Method
        //GET: EnsureLoggedOut  
        private void EnsureLoggedOut()
        {

            if (Session["UserID"] != null)
                Logout();
        }
        #endregion

        #region --> Logout POST Method

        [HttpPost]

        public ActionResult Logout()
        {
            try
            {

                //Removing Session
                Session.Abandon();
                Session.Clear();
                Session.RemoveAll();
                FormsAuthentication.SignOut();
                //Removing ASP.NET_SessionId Cookie
                if (Request.Cookies["ASP.NET_SessionId"] != null)
                {
                    Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                    Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-10);
                }

                if (Request.Cookies["AuthenticationToken"] != null)
                {
                    Response.Cookies["AuthenticationToken"].Value = string.Empty;
                    Response.Cookies["AuthenticationToken"].Expires = DateTime.Now.AddMonths(-10);
                }

                return RedirectToAction("Login", "Account");
            }
            catch (Exception ex)
            {
                //Log.Error("Hi I am log4net Error Level", ex);
                //Log.Fatal("Hi I am log4net Fatal Level", ex);
                throw;
            }
        }
        #endregion

        #region --> Sing IN Async GET Method
        //GET: SignInAsync     
        private void SignInRemember(string userName, bool isPersistent = false)
        {

            FormsAuthentication.SignOut();


            FormsAuthentication.SetAuthCookie(userName, isPersistent);
        }

        #endregion

        #region --> RedirectToLocal GET Method
        //GET: RedirectToLocal  
        private ActionResult RedirectToLocal(string returnUrl)
        {
            try
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

            catch (Exception ex)
            {
                //Log.Error("Hi I am log4net Error Level", ex);
                //Log.Fatal("Hi I am log4net Fatal Level", ex);
                throw;
            }
        }
        #endregion

        #region --> Campare
        // ReturnHash
        [NonAction]
        public string ReturnHash(string strPassword, string token)
        {

            string strHash = null;
            string RandomNo = token;
#pragma warning disable 618
            return strHash = FormsAuthentication.HashPasswordForStoringInConfigFile((RandomNo + strPassword.ToUpper()), "MD5");
#pragma warning restore 618
        }
        #endregion

        public DataSet ReturnEnmployeeDeteails(string userName)
        {
            DataSet dsEmployeeDeatails = new DataSet();

            dsEmployeeDeatails = _objBalEmployee.GetEmployeeDetails(userName);

            return dsEmployeeDeatails;
        }


    }
}
