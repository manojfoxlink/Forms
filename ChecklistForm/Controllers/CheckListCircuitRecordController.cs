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
    public class CheckListCircuitRecordController : Controller
    {
        DAL.Station _ObjStation = new DAL.Station();

        BAL.CheckListCircuitRecord _CheckListCircuitRecord = new BAL.CheckListCircuitRecord();

        CheckListRecordResult obj = new CheckListRecordResult();
        Converters _cont = new Converters();
        [HttpGet]
        public ActionResult Index()
       {
            CheckListCircuitRecordViewModel model = new CheckListCircuitRecordViewModel();
            model.dtChecklist = new DataTable();
            //model.dtChecklist = _CheckListCircuitRecord.GetFormByRecord(model.LineId);
            model.Lines = _CheckListCircuitRecord.GetLine();
            model.Shifts = _CheckListCircuitRecord.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Shifts"] = model.Shifts;
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            //model.Lines = (List<Line>)Session["Lines"];
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(CheckListCircuitRecordViewModel model)
        {

            if (!ModelState.IsValid)
                return View(model);

            

            //return View(model);

            model.dtChecklist = _CheckListCircuitRecord.GetFormByRecord(model.LineId,model.ProjectId);
            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            Session["Lines"] = model.Lines;
            Session["Shifts"] = model.Shifts;
            Session["ModelNos"] = model.ModelNos;
            Session["PartNos"] = model.PartNos;
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveCheckCiruit(CheckListCircuitRecordViewModel model)
        {
            DataTable dtChecklist = new DataTable("CheckListRecordResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("RecordId");
            //dtChecklist.Columns.Add("ProjectId");
            dtChecklist.Columns.Add("Result");
            dtChecklist.Columns.Add("AdverseNumber");

            try
            {
                int Uid = 1;

                foreach (var row in model.CheckListRecordResults)
                {




                    dtChecklist.Rows.Add(Uid, row.RecordId, row.Result, row.AdverseNumber);
                    Uid++;

                }


                int i = _CheckListCircuitRecord.InsertCheckListRecordResult(dtChecklist, Session["EmpNumber"].ToString(), model.LineId,model.ProjectId,model.ProdLineLeader,model.ApprovedBy,model.CheckedBy,model.ModelId,model.PartId);
                model.dtChecklist = _CheckListCircuitRecord.GetFormByRecord(model.LineId, model.ProjectId);
                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("Index");
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
            //model.dtChecklist = _CheckListCircuitRecord.GetFormByRecord(model.LineId, model.ProjectId);

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            return View("Index", model);
        }
        #region --> Post Method For PartNo
        [HttpPost]
        public ActionResult GetPartNoByModel(int ModelId)
        {
            string PlantCode = string.Empty;

            List<DOL.PartNo> PeriodList = new List<DOL.PartNo>();

            DataTable dt = _ObjStation.GetPartNoByModel(ModelId);

            PeriodList = dt.DataTableToList<DOL.PartNo>();

            string retStr = string.Empty;

            Session["PartNos"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region --> Post Method For PartNo
        [HttpPost]
        public ActionResult GetModelNoByProject(int ProjectId)
        {
            string PlantCode = string.Empty;

            List<DOL.ModelNo> PeriodList = new List<DOL.ModelNo>();

            DataTable dt = _ObjStation.GetModelNoByProject(ProjectId);

            PeriodList = dt.DataTableToList<DOL.ModelNo>();

            string retStr = string.Empty;

            Session["ModelNos"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion

        

    }
}
