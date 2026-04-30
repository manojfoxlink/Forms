using ChecklistForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAL;
using DOL;
using DAL;
using System.Data;
using ChecklistForm.Utils;
using ChecklistForm.Filters;
namespace ChecklistForm.Controllers
{
    [AuthenticateUser]
    [CheckSessionOut]
    public class IpqcFromsController : Controller
    {
        //
        // GET: /IpqcFroms/

        BAL.Projects _objProject = new BAL.Projects();
        BAL.Machine _ObjMachine = new BAL.Machine();
        BAL.Category _objCategory = new BAL.Category();
        BAL.Activityy _obAcivity = new BAL.Activityy();
        Converters _cont = new Converters();
        BAL.Parts _ObjParts = new BAL.Parts();
        BAL.CheckPoints _ObjCheckPoints = new BAL.CheckPoints();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Project()
        {



            ProjectViewModel obj = new ProjectViewModel();
            obj.Projects = _objProject.GetProject();
            Session["Project"] = obj.Projects;


            return View(obj);
        }
        [HttpPost]
        public ActionResult Project(ProjectViewModel model)
        {


            if (!ModelState.IsValid)
                return View(model);



            DOL.Project obj = new DOL.Project();
            obj.ProjectName = model.ProjectName;

            obj.CreatedBy = Session["EmpNumber"].ToString();
            int i = _objProject.InsertProject(obj);
            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "Project Station Created!!!";
                return RedirectToAction("Project");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This Project !!!");
            }
            return View(model);



        }


        [HttpGet]
        public ActionResult Machine()
        {
            MachineViewModel obj = new MachineViewModel();
            obj.Projects = _objProject.GetProject();
            Session["Project"] = obj.Projects;
            return View(obj);
        }
        //[HttpGet]
        //public ActionResult getMachines(string Machine)
        //{
        //    //MachineViewModel Machine = new MachineViewModel();
        //    //var Machine = Machine.getMachines(Machine);
        //    //return Machine;
        //}
        [HttpPost]
        public ActionResult Machine(MachineViewModel model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];

            if (!ModelState.IsValid)
                return View(model);

            DOL.Machine obj = new DOL.Machine();
            obj.MachineName = model.MachineName;
            obj.ProjectId = model.ProjectId;
            obj.CreatedBy = Session["EmpNumber"].ToString();

            int i = _ObjMachine.InsertMachine(obj);

            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "Machine Created!!!";
                return RedirectToAction("Machine");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This Machine !!!");
            }
            return View(model);
        }
        

        [HttpGet]
         public ActionResult Category()
        {
            CategoryViewModel obj = new CategoryViewModel();
            obj.Projects = _objProject.GetProject();

            obj.Machines = new List<DOL.Machine>();

            Session["Project"] = obj.Projects;

            return View(obj);
            
        }
        [HttpPost]
       public ActionResult Category(CategoryViewModel model)
      {
          model.Projects = (List<DOL.Project>)Session["Project"];
          model.Machines = (List<DOL.Machine>)Session["Machine"];
          
          if (!ModelState.IsValid)
              return View(model);

          DOL.Categoryy obj = new DOL.Categoryy();
          obj.Category = model.Category;
          obj.MachineId = model.MachineId;
          obj.ProjectId = model.ProjectId;
          obj.CreatedBy = Session["EmpNumber"].ToString();
          int i = _objCategory.InsertCategory(obj);

          if (i > 0)
          {
              TempData["mgs"] = "Sucess";
              TempData["Alert"] = "Category Created!!!";
              return RedirectToAction("Category");
          }
          else
          {
              ModelState.AddModelError("ERROR", "Already Exists This Category !!!");
          }

        
          return View(model);

      }
        [HttpGet]
        public ActionResult Activity()
        {
            ActivityViewModel obj = new ActivityViewModel();

            obj.Projects = _objProject.GetProject();
            obj.Machines = new List<DOL.Machine>();
            obj.Categories = new List<DOL.Categoryy>();
            

            Session["Project"]=obj.Projects;

            return View(obj);
        }
        [HttpPost]
       public ActionResult Activity(ActivityViewModel model)
       {
           model.Projects = (List<DOL.Project>)Session["Project"];
           model.Machines = (List<DOL.Machine>)Session["Machine"];
           model.Categories = (List<DOL.Categoryy>)Session["Category"];


           if (!ModelState.IsValid)
               return View(model);

           DOL.Activityy obj = new DOL.Activityy();
           obj.Activity = model.Activity;
           
           obj.MachineId = model.MachineId;
           obj.ProjectId = model.ProjectId;
           obj.CatId = model.CatId;
           obj.CreatedBy = Session["EmpNumber"].ToString();

           int i = _obAcivity.InsertActivity(obj);
           if (i > 0)
           {
               TempData["mgs"] = "Sucess";
               TempData["Alert"] = "Activity Created!!!";
               return RedirectToAction("Activity");
           }
           else
           {
               ModelState.AddModelError("ERROR", "Already Exists This Activity !!!");
           }


           return View(model);

       }
        [HttpGet]
        public ActionResult Parts()
        {
            PartsViewModel obj = new PartsViewModel();
            obj.Machines = new List<DOL.Machine>();

            obj.Categories = new List<DOL.Categoryy>();
            obj.Activities = new List<DOL.Activityy>();

            obj.Projects = _objProject.GetProject();

            Session["Project"] = obj.Projects;

           

            
            
            return View(obj);
        }
        [HttpPost]
        public ActionResult Parts(PartsViewModel model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
            model.Machines = (List<DOL.Machine>)Session["Machine"];
            model.Categories = (List<DOL.Categoryy>)Session["Category"];
            model.Activities = (List<DOL.Activityy>)Session["Activity"];

            if (!ModelState.IsValid)
                return View(model);

            DOL.Parts obj = new DOL.Parts();

            obj.Sno = model.Sno;
            obj.PartOfInspection = model.PartOfInspection;
            obj.Freq = model.Freq;
            obj.StandardCondition = model.StandardCondition;
            obj.ProjectId = model.ProjectId;
            obj.MachineId = model.MachineId;
            obj.CatId = model.CatId;
            obj.ActivityId = model.ActivityId;
            obj.CreatedBy = Session["EmpNumber"].ToString();

            int i = _ObjParts.InsertParts(obj);

            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "Parts Created!!!";
                return RedirectToAction("Parts");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This Parts !!!");
            }


            return View(model);
        }
        [HttpGet]
        public ActionResult CheckPoints()
        {
            CheckPointModelView obj = new CheckPointModelView();

            obj.Projects = _objProject.GetProject();
            Session["Project"] = obj.Projects;

            obj.Machines = new List<DOL.Machine>();
           // Session["Machine"] = obj.Machines;

            return View(obj);
        }
        [HttpPost]
        public ActionResult CheckPoints(CheckPointModelView model)
        {
            model.Machines = (List<DOL.Machine>)Session["Machine"];

            model.Projects = (List<DOL.Project>)Session["Project"];

            if (!ModelState.IsValid)
                return View(model);

            DOL.CheckPoints obj = new DOL.CheckPoints();

            obj.ChckPoint = model.ChckPoint;
            obj.MachineId = model.MachineId;
            obj.ProjectId = model.ProjectId;
            obj.CreatedBy = Session["EmpNumber"].ToString();

            int i = _ObjCheckPoints.InsertCheckPoint(obj);

            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "Sucessfully CheckPoints Details Created!!!";
                return RedirectToAction("CheckPoints");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This CheckPoints Details !!!");
            }

            return View(model);

        }


        #region -->Post Method For  Machine

        [HttpPost]
        public ActionResult GetMachineByProject(int ProjectId)
        {
            string PlantCode = string.Empty;
            List<DOL.Machine> Machinelist = new List<DOL.Machine>();

            DataTable dt = _objCategory.GetMachineByProject(ProjectId);


            Machinelist = dt.DataTableToList<DOL.Machine>();

            string retStr = string.Empty;


            Session["Machine"] = Machinelist;
            retStr = _cont.ConvertToJson(dt);


            return Json(retStr, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region -->Post Method For  Category

        [HttpPost]
        public ActionResult GetCategoryByMachine(int MachineId)
        {
            string PlantCode = string.Empty;
            List<DOL.Categoryy> categorylist = new List<DOL.Categoryy>();

            DataTable dt = _objCategory.GetCategoryByMachine(MachineId);


            categorylist = dt.DataTableToList<DOL.Categoryy>();

            string retStr = string.Empty;


            Session["Category"] = categorylist;
            retStr = _cont.ConvertToJson(dt);


            return Json(retStr, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region -->Post Method For  Activity

        [HttpPost]
        public ActionResult GetActivityByCategory(int CatId)
        {
            string PlantCode = string.Empty;
            List<DOL.Activityy> Activitylist = new List<DOL.Activityy>();

            DataTable dt = _obAcivity.GetActivityByCategory(CatId);


            Activitylist = dt.DataTableToList<DOL.Activityy>();

            string retStr = string.Empty;


            Session["Activity"] = Activitylist;
            retStr = _cont.ConvertToJson(dt);


            return Json(retStr, JsonRequestBehavior.AllowGet);
        }
        #endregion
       
    }
}
