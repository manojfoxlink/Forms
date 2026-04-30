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
using Syncfusion.XPS;
using ChecklistForm.Utils;

namespace ChecklistForm.Controllers
{
    [AuthenticateUser]
    [CheckSessionOut]
    public class CheckPointChecklIstController : Controller
    {
        BAL.CheckPointsResult _objResult = new BAL.CheckPointsResult();

        BAL.MaintenanceCheckList _CheckListCircuitRecord = new BAL.MaintenanceCheckList();

        CheckPointResult obj = new CheckPointResult();

        BAL.Category _objCategory = new BAL.Category();
        Converters _cont = new Converters();
        //
        // GET: /CheckPointChecklIst/
        [HttpGet]
        public ActionResult CheckPointResult()
        {
            CheckPointResultViewModel model = new CheckPointResultViewModel();
            model.dtChecklist = new DataTable();
            model.Lines = _objResult.GetLine();
            model.Machines = _objResult.GetMachine();
            model.shifts = _objResult.GetShift();
           model.Projects = _CheckListCircuitRecord.GetProject();
           model.Machines = new List<DOL.Machine>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            //Session["Machines"] = model.Machines;
            Session["Shifts"] = model.shifts;
            return View(model);
        }

        [HttpPost]
         public ActionResult CheckPointResult(CheckPointResultViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.dtChecklist = _objResult.GetFormsByCheckPoints(model.LineId, model.MachineId,model.ProjectId);
            model.Lines = (List<Line>)Session["Lines"];
            model.Machines = (List<DOL.Machine>)Session["Machines"];
            model.shifts = (List<DOL.Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveCheckPointsChecklist(CheckPointResultViewModel model)
        {
            DataTable dtChecklist = new DataTable("CheckPointResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("CheckId");
            dtChecklist.Columns.Add("Result");
            try
            {
                int Uid = 1;

                foreach (var row in model.CheckPointResults)
                {




                    dtChecklist.Rows.Add(Uid,  row.CheckId,row.Result);
                    Uid++;

                }
                int i = _objResult.InsertCheckListCheckPointResult(dtChecklist, Session["EmpNumber"].ToString(), model.LineId,model.DRILeader,model.LineLeader);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("CheckPointResult");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception)
            {
                
                throw;
            }


            model.dtChecklist = _objResult.GetFormsByCheckPoints(model.LineId, model.MachineId, model.ProjectId);
            model.Lines = (List<Line>)Session["Lines"];
            model.Machines = (List<DOL.Machine>)Session["Machines"];
            model.shifts = (List<DOL.Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            return View("CheckPointResult", model);
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
