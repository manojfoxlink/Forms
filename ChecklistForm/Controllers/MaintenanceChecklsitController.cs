using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAL;
using ChecklistForm.Models;
using System.Data;
using DOL;
using ChecklistForm.Filters;
using ChecklistForm.Utils;

namespace ChecklistForm.Controllers
{
    [AuthenticateUser]
    [CheckSessionOut]
    public class MaintenanceChecklsitController : Controller
    {
        //
        // GET: /MaintenanceChecklsit/

        BAL.MaintenanceCheckList _objMaintenanceCheckList = new BAL.MaintenanceCheckList();

        BAL.MaintenanceCheckList _CheckListCircuitRecord = new BAL.MaintenanceCheckList();

        BAL.Category _objCategory = new BAL.Category();
        Converters _cont = new Converters();

        CheckListMaintenanceResult obj =  new CheckListMaintenanceResult();

        [HttpGet]
        public ActionResult MaintenanceCheckList()
        {
            MaintenanceCheckListModelView model = new MaintenanceCheckListModelView();
            model.dtChecklist = new DataTable();
            model.Lines = _objMaintenanceCheckList.GetLine();
            //model.Machines = _objMaintenanceCheckList.GetMachine();

            model.Machines = new List<DOL.Machine>();
            model.Activities = _objMaintenanceCheckList.GetActivity();
            model.Projects = _CheckListCircuitRecord.GetProject();
            //model.Frequencies = _objMaintenanceCheckList.GetFrequency();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            //Session["Machines"] = model.Machines;
            Session["Activities"] = model.Activities;
            //Session["Frequencies"] = model.Frequencies;
            return View(model);
        }
        [HttpPost]
        public ActionResult MaintenanceCheckList(MaintenanceCheckListModelView model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.dtChecklist = _objMaintenanceCheckList.GetFormByMaintenance(model.LineId,model.MachineId,model.ProjectId);
            model.Lines = (List<Line>)Session["Lines"];
            model.Machines = (List<DOL.Machine>)Session["Machines"];
            model.Activities = (List<DOL.Activityy>)Session["Activities"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            //model.Frequencies = (List<DOL.Freqq>)Session["Frequencies"];
            return View(model);
        }

        [HttpPost]

        public ActionResult SaveMaintenanceChecklist(MaintenanceCheckListModelView model)
        {
            DataTable dtChecklist = new DataTable("CheckListMaintenanceResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("PartsId");
            dtChecklist.Columns.Add("Result");
            dtChecklist.Columns.Add("Remarks");
            try
            {
                int Uid = 1;

                foreach (var row in model.CheckListMaintenanceResults)
                {




                    dtChecklist.Rows.Add(Uid,  row.PartsId,row.Result,row.Remarks);
                    Uid++;

                }

                int i = _objMaintenanceCheckList.InsertCheckListMaintenanceResult(dtChecklist, Session["EmpNumber"].ToString(), model.LineId,model.DRILeader,model.LineLeader);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("MaintenanceCheckList");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);
            }


            model.dtChecklist = _objMaintenanceCheckList.GetFormByMaintenance(model.LineId,model.MachineId,model.ProjectId);
            model.Lines = (List<Line>)Session["Lines"];
            model.Machines = (List<DOL.Machine>)Session["Machines"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            //model.Frequencies = (List<DOL.Freqq>)Session["Frequencies"];
            return View("MaintenanceCheckList",model);
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


            Session["Machines"] = Machinelist;
            retStr = _cont.ConvertToJson(dt);


            return Json(retStr, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
