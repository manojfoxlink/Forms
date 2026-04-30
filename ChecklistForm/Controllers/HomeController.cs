using BAL;
using ChecklistForm.Models;
using DOL;
//using log4net;
using ChecklistForm.Filters;
//using Scrapbility.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace ChecklistForm.Controllers
{
    [AuthenticateUser]
    [CheckSessionOut]
    public class HomeController : Controller
    {
        //private static readonly ILog Log = LogManager.GetLogger(typeof(HomeController));
        EmployeeBAL _objBalEmployee = new EmployeeBAL();
        //ScrapBAL _scrap = new ScrapBAL();

        #region -->DashBoard Get Index
        public ActionResult Index()
        {
            //DashBoardViewModel objDash = new DashBoardViewModel();
            //objDash.DashBoard = _scrap.DashBoard();
            //return View(objDash);

            return View();
        }
        #endregion

        #region --> Registration Get Method

        [HttpGet]
        public ActionResult Register()
        {
            RegisterModel objRegiview = new RegisterModel();

            objRegiview.EmployeeList = new DataTable();



            return View(objRegiview);
        }

        #endregion

        #region --> Registration Post Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model, HttpPostedFileBase file)
        {

            try
            {

                model.EmployeeList = new DataTable();
                if (!ModelState.IsValid)
                    return View(model);

                Employee objEmp = new Employee();

                MemoryStream target = new MemoryStream();
                file.InputStream.CopyTo(target);
                byte[] data = target.ToArray();
                String profilePic = Convert.ToBase64String(data);
                profilePic = "data:image/jpeg;base64," + profilePic;

                objEmp.FilePath = profilePic;
                objEmp.EmployeeId = model.UserId;
                objEmp.EmployeeName = model.UserName;

                objEmp.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(Convert.ToString(model.Password), "MD5");

                objEmp.RoleName = model.RoleName;
                objEmp.Designation = model.Designation;

                objEmp.CreatedBy = Session["EmpNumber"].ToString();
              


                int ret = _objBalEmployee.UpsertEmployee(objEmp, "Insert");
                if (ret > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully User Created!!!";
                    return RedirectToAction("Register");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Exists This Employee !!!");
                }


            }
            catch (Exception ex)
            {
                //Log.Error("Error Level", ex);
                //Log.Fatal("Fatal Level", ex);
            }

            return View(model);

        }
        #endregion

        #region Menus Get Method
        public ActionResult Menus()
        {
            ViewBag.ResultMessage = "";

            if ((bool)Session["IsAdmin"])
            {
                ViewBag.IsAdmin = true;
                var menus = _objBalEmployee.GetMenus();
                return View(menus);
            }
            else
            {
                return RedirectToAction("Denied", "Account", new { area = "" });
            }

        }
        [HttpPost]
        public ActionResult AssignMenus(Menus menus, string search)
        {
            ViewBag.ResultMessage = "";
            if ((bool)Session["IsSearchAdmin"])
            {
                // We restricted that Admin can't able to change Menu's to another Admin.
                return RedirectToAction("Denied", "Account", new { area = "" });
            }
            else
            {
                string ret = _objBalEmployee.AssignMenus(menus, search);
                var menu = _objBalEmployee.GetMenus();
                ViewBag.ResultMessage = ret;
                return View("Menus", menu);
            }

        }
        public ActionResult SearchForEmp(string ID)
        {
            ViewBag.ResultMessage = "";
            Session["IsSearchAdmin"] = "";
            Employee Empacces = _objBalEmployee.SearchForEmpMenu(ID);
            if (Empacces != null)
            {
                if (Empacces.RoleName == "Admin")
                {
                    Session["IsSearchAdmin"] = true;
                }
                else
                {
                    Session["IsSearchAdmin"] = false;
                }
            }
            return Json(Empacces, JsonRequestBehavior.AllowGet);

        }

        #endregion

        #region --> EmployeeDetails
        public ActionResult SearchForEmployee(RegisterModel model)
        {
            DataTable emptyTable = _objBalEmployee.SearchForEmployee(model.UserId, model.UserName);
            model.EmployeeList = emptyTable;
            return View("Register", model);
        }

        [HttpPost]
        public ActionResult DeleteEmployee(string EmpNumber, string roleName)
        {
            Employee model = new Employee();
            string retStr = string.Empty;
            if (EmpNumber != null)
            {
                model.EmployeeId = EmpNumber;
                model.RoleName = roleName;
                model.IsActive = false;
                _objBalEmployee.UpsertEmployee(model, "Delete");
                retStr = "Deleted Succesfully";
            }
            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region -->User Profile Method
        public ActionResult UserProfile()
        {
            RegisterModel model = new RegisterModel();
            string EmpNumber = Session["EmpNumber"].ToString();
            DataTable empTable = _objBalEmployee.SearchForEmployee(EmpNumber, "");
            model.UserId = EmpNumber;
            if (empTable.Rows.Count > 0)
            {
                foreach (DataRow dr in empTable.Rows)
                {
                    model.UserName = dr["Name"].ToString();
                    model.RoleName = dr["RoleName"].ToString();
                    model.Designation = dr["Designation"].ToString();
                    model.ProfilePicture = dr["ProfilePicture"].ToString();
                }
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserProfile(RegisterModel empModel, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
                return View(empModel);

            Employee model = new Employee();
            if (file != null)
            {
                MemoryStream target = new MemoryStream();
                file.InputStream.CopyTo(target);

                byte[] data = target.ToArray();
                String profilePic = Convert.ToBase64String(data);
                profilePic = "data:image/jpeg;base64," + profilePic;
                empModel.ProfilePicture = profilePic;
            }
            model.EmployeeId = empModel.UserId;
            model.EmployeeName = empModel.UserName;
            model.Designation = empModel.Designation;
            model.RoleName = empModel.RoleName;
            model.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(Convert.ToString(empModel.Password), "MD5");
            model.FilePath = empModel.ProfilePicture;
            int i = _objBalEmployee.UpsertEmployee(model, "Update");
            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "Sucessfully User Created!!!";

            }
            DataTable empTable = _objBalEmployee.SearchForEmployee(empModel.UserId, "");
            model.EmployeeId = empModel.UserId;
            if (empTable.Rows.Count > 0)
            {
                foreach (DataRow dr in empTable.Rows)
                {
                    model.EmployeeName = dr["Name"].ToString();
                    model.Password = dr["Password"].ToString();
                    model.RoleName = dr["RoleName"].ToString();
                    model.Designation = dr["Designation"].ToString();
                    model.FilePath = dr["ProfilePicture"].ToString();
                }
            }

            return RedirectToAction("UserProfile");
        }
        #endregion

        //public ActionResult Menus()
        //{
        //    return View();
        //}
    }
}
