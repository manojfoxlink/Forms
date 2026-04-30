using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAL;
using DAL;
using ChecklistForm.Models;
using System.Data;
using DOL;
using ChecklistForm.Filters;
using System.IO;
using ChecklistForm.Utils;
namespace ChecklistForm.Controllers
{
    [AuthenticateUser]
    [CheckSessionOut]
    public class CheckListController : Controller
    {
        //MailsForQuality
        Models.MailsForQuality objmailForQuality = new Models.MailsForQuality();
        Models.MailForFACA objmail = new Models.MailForFACA();
        Models.MailForRACA objmail2 = new Models.MailForRACA();
        Models.Mails objmail3 = new Models.Mails();
        BAL.Project _objProject2 = new BAL.Project();
        Models.MailsForFinal objmail4 = new Models.MailsForFinal();
        BAL.CheckListResults _checkResult = new BAL.CheckListResults();
        BAL.CheckListNativeValidation _checkNative = new BAL.CheckListNativeValidation();
        BAL.FirstArticleInspection _checkFirstArticle = new BAL.FirstArticleInspection();
        BAL.CheckListCircuitRecord _CheckListCircuitRecord = new BAL.CheckListCircuitRecord();
        BAL.MaintenanceCheckList _CheckListMaintenance = new BAL.MaintenanceCheckList();
        ReportBAL _objRpt = new ReportBAL();

        LaserCheckListResult obj = new LaserCheckListResult();

        DAL.Project _objProject = new DAL.Project();
        DAL.Station _ObjStation = new DAL.Station();
        DAL.SubStation _ObjSubStation = new DAL.SubStation();
        DAL.Parameters _ObjParameters = new DAL.Parameters();
        DAL.ChecklistLimits _objChecklistLimits = new DAL.ChecklistLimits();
        Converters _cont = new Converters();

        //DOL.FirstInspectionArticle _ObjInspectionArticle = new DOL.FirstInspectionArticle();
        //
        // GET: /CheckList/

        [HttpGet]
        public ActionResult Index()
        {
            CheckListResultsViewModel model = new CheckListResultsViewModel();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            //Session["ModelNos"] = model.ModelNos;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(CheckListResultsViewModel model)
        {
            model.dtChecklist = _checkResult.GetFormByProject(model.LineId, model.ProjectId);
            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            Session["Lines"] = model.Lines;
            Session["Shifts"] = model.Shifts;
            Session["ModelNos"] = model.ModelNos;
            Session["PartNos"] = model.PartNos;
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                model.dtChecklist = _checkResult.GetFormByProject(model.LineId, model.ProjectId);
                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                model.Projects = (List<DOL.Project>)Session["Projects"];
                model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model);

            //return RedirectToAction("ChecklistResults");
        }


        [HttpPost]
        public ActionResult SaveCheckList(CheckListResultsViewModel model)
        {
            DataTable dtChecklist = new DataTable("CheckListResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("ParameterId");
            dtChecklist.Columns.Add("LimitId");
            dtChecklist.Columns.Add("Actual");
            //  dtChecklist.Columns.Add("LineId");
            //dtChecklist.Columns.Add("Result");
            //dtCheckListItem.Columns.Add("SeveryId");



            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.CheckListResults)
                {




                    dtChecklist.Rows.Add(Uid, row.ParameterId, row.LimitId, row.Actual);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                int i = _checkResult.InsertCheckListResult(dtChecklist, Session["EmpNumber"].ToString(), model.LineId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.ModelId, model.PartId);

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
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            model.dtChecklist = _checkResult.GetFormByProject(model.LineId, model.ProjectId);
            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            return View("Index", model);
        }
        //public ActionResult SaveCheckListItem(CheckListResultsViewModel result)
        //{
        //    DataTable dtCheckListItem = new DataTable("CheckListIteam");
        //    //dtCheckListItem.Columns.Add("ParameterId");
        //    dtCheckListItem.Columns.Add("LimitId");
        //    dtCheckListItem.Columns.Add("Actual");
        //    dtCheckListItem.Columns.Add("Result");
        //    //dtCheckListItem.Columns.Add("SeveryId");



        //    try
        //    {
        //        //  HttpFileCollectionBase files = Request.Files;

        //        int Uid = 1;

        //        foreach (var row in result.CheckListResults)
        //        {




        //            dtCheckListItem.Rows.Add(Uid,  row.LimitId, row.Actual, row.Result);
        //            Uid++;

        //        }

        //        int i = _checkResult.InsertCheckListResult(dtCheckListItem,Convert.ToInt32(Session["LimitId"]), Session["Result"].ToString(), Convert.ToDecimal (Session["Actual"]));



        //        TempData["mgs"] = "Sucess";
        //        TempData["Alert"] = "Sucessfully User Created!!!";
        //        //    return RedirectToAction("Index");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //        //Log.Error("Error", ex);
        //    }

        //    return View("Index");
        //}

        [HttpGet]
        public ActionResult LaserSize()
        {
            LasersizeViewModel model = new LasersizeViewModel();
            model.dtLaser = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Shifts"] = model.Shifts;
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;


            //LasersizeViewModel model1 = Session["Model"] as LasersizeViewModel ?? new LasersizeViewModel();

            //if (Session["Model"] != null)
            //{
            //    return View(model1);
            //}
            
                return View(model);
            
            
            
        }

        [HttpPost]
        public ActionResult LaserSize(LasersizeViewModel mode)
        {
            if (!ModelState.IsValid)
                return View(mode);

            try
            {
                mode.dtLaser = _checkResult.GetLaserSize(mode.LineId, mode.ProjectId);
                mode.Lines = (List<Line>)Session["Lines"];
                mode.Shifts = (List<Shift>)Session["Shifts"];
                mode.Projects = (List<DOL.Project>)Session["Projects"];
                mode.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                mode.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                Session["Lines"] = mode.Lines;
                Session["Shifts"] = mode.Shifts;
                Session["ModelNos"] = mode.ModelNos;
                Session["PartNos"] = mode.PartNos;
                //Session["Model"] = mode;
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("LaserSize");
            return View(mode);
            //return View("SaveCheckListLaser", mode);
        }
        
        [HttpPost]
        public ActionResult SaveCheckListLaser(LasersizeViewModel model)
        {
            DataTable dtLaserlist = new DataTable("LaserCheckListResults");
            dtLaserlist.Columns.Add("Id");
            dtLaserlist.Columns.Add("LaserId");
            dtLaserlist.Columns.Add("sno1");
            dtLaserlist.Columns.Add("sno2");
            dtLaserlist.Columns.Add("sno3");
            dtLaserlist.Columns.Add("sno4");
            dtLaserlist.Columns.Add("sno5");
            dtLaserlist.Columns.Add("sno6");
            //  dtChecklist.Columns.Add("LineId");
            //dtLaserlist.Columns.Add("Result");
            //dtCheckListItem.Columns.Add("SeveryId");
            dtLaserlist.Columns.Add("SerialNo1");
            dtLaserlist.Columns.Add("SerialNo2");
            dtLaserlist.Columns.Add("SerialNo3");
            dtLaserlist.Columns.Add("SerialNo4");
            dtLaserlist.Columns.Add("SerialNo5");
            dtLaserlist.Columns.Add("SerialNo6");



            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.LaserCheckListResults)
                {
                    dtLaserlist.Rows.Add(Uid, row.LaserId, row.Sno1, row.Sno2, row.Sno3, row.Sno4, row.Sno5, row.Sno6, row.SerialNo1, row.SerialNo2, row.SerialNo3, row.SerialNo4, row.SerialNo5, row.SerialNo6);
                    Uid++;

                }

                int i = _checkResult.InsertCheckListLaser(dtLaserlist, Session["EmpNumber"].ToString(), model.LineId, model.ProjectId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.ModelId, model.PartId);

                model.dtLaser = _checkResult.GetLaserSize(model.LineId, model.ProjectId);



                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";

                    return RedirectToAction("LaserSize");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            //  model.dtLaser = _objchecklistResults.InsertLaserResults(model.LineId);

            //model.dtLaser = _checkResult.GetLaserSize(model.LineId,model.ProjectId);

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            return View("LaserSize", model);
        }

        [HttpGet]
        public ActionResult CheckListNativeProduction()
        {
            CheckListNativeValidationModelView model = new CheckListNativeValidationModelView();
            model.dtChecklist = new DataTable();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Shifts"] = model.Shifts;
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            //Session["ModelNos"] = model.ModelNos;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }
        [HttpPost]
        public ActionResult CheckListNativeProduction(CheckListNativeValidationModelView model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                model.dtChecklist = _checkNative.GetFormByNativeValiadtion(model.LineId, model.ProjectId);
                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                model.Projects = (List<DOL.Project>)Session["Projects"];
                model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                Session["Lines"] = model.Lines;
                Session["Shifts"] = model.Shifts;
                Session["ModelNos"] = model.ModelNos;
                Session["PartNos"] = model.PartNos;

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveNativeProduction(CheckListNativeValidationModelView model)
        {
            DataTable dtChecklist = new DataTable("CheckListNativeValidations");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("ValidId");
            dtChecklist.Columns.Add("GoodSample");
            dtChecklist.Columns.Add("FailSample");
            dtChecklist.Columns.Add("Result");
            //  dtChecklist.Columns.Add("LineId");
            //dtChecklist.Columns.Add("Result");
            //dtCheckListItem.Columns.Add("SeveryId");



            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.CheckListNativeValidations)
                {




                    dtChecklist.Rows.Add(Uid, row.ValidId, row.GoodSample, row.FailSample, row.Result);
                    Uid++;

                }

                int i = _checkNative.InsertCheckListNativeValiadtion(dtChecklist, Session["EmpNumber"].ToString(), model.LineId, model.ProjectId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.ModelId, model.PartId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("CheckListNativeProduction");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            model.dtChecklist = _checkNative.GetFormByNativeValiadtion(model.LineId, model.ProjectId);
            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            return View("CheckListNativeProduction", model);
        }

        [HttpGet]
        public ActionResult CheckListFirstArticleInspection()
        {
            CheckListFirstArticleInspectionViewModel model = new CheckListFirstArticleInspectionViewModel();

            model.dtChecklist = new DataTable();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.SRSS = new List<DOL.SRS>();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            //Session["Exponents"] = model.Exponents;
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Shifts"] = model.Shifts;
            Session["SRS"] = model.SRSS;
            return View(model);
        }

        [HttpPost]
        public ActionResult CheckListFirstArticleInspection(CheckListFirstArticleInspectionViewModel model)
        {
            model.dtChecklist = _checkFirstArticle.GetFormByFirstArticleInspection(model.LineId, model.ProjectId);

            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            //model.Exponents = _CheckListCircuitRecord.GetExponent();
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            model.SRSS = (List<SRS>)Session["SRes"];
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                model.dtChecklist = _checkFirstArticle.GetFormByFirstArticleInspection(model.LineId, model.ProjectId);

                model.Lines = (List<Line>)Session["Lines"];

                model.Projects = (List<DOL.Project>)Session["Projects"];
                model.SRSS = (List<SRS>)Session["SRes"];
                Session["Lines"] = model.Lines;
                Session["Projects"] = model.Projects;
                Session["ModelNos"] = model.ModelNos;
                Session["PartNos"] = model.PartNos;
                Session["SRes"] = model.SRSS;
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveFirstArticleInspection(CheckListFirstArticleInspectionViewModel model)
        {
            DataTable dtLaserlist = new DataTable("CheckListFirstArticleInspections");
            dtLaserlist.Columns.Add("Id");
            dtLaserlist.Columns.Add("ContentId");
            dtLaserlist.Columns.Add("SRId");
            //dtLaserlist.Columns.Add("StationId");
            dtLaserlist.Columns.Add("Result");
            dtLaserlist.Columns.Add("RejectDescribe");
            //dtLaserlist.Columns.Add("sno6");


            //DataTable dtLaserlist2 = new DataTable("CheckListFirstArticleInspecs");
            //dtLaserlist2.Columns.Add("Id");
            //dtLaserlist2.Columns.Add("SpecId");
            //dtLaserlist2.Columns.Add("Check1");
            //dtLaserlist2.Columns.Add("Check2");
            //dtLaserlist2.Columns.Add("Check3");
            //dtLaserlist2.Columns.Add("Check4");
            //dtLaserlist2.Columns.Add("Check5");

           

            try
            {

                int Uid = 1;

                foreach (var row in model.CheckListFirstArticleInspections)
                {




                    dtLaserlist.Rows.Add(Uid, row.ContentId, row.SRId, row.Result, row.RejectDescribe);
                    Uid++;

                }


                int i = _checkFirstArticle.InsertCheckListFirstArticleInspection(dtLaserlist, Session["EmpNumber"].ToString(), model.LineId, model.ProjectId, model.ProdLineLeader, model.ApprovedBy, model.CheckedBy, model.ModelId, model.PartId, model.ProductName, model.WorkOrder, model.DrawingVersion, model.PackVersion,model.SamplingQty);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("CheckListFirstArticleInspection");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }


            //try
            //{


            //    int i = _checkFirstArticle.InsertBulkFirstAirticleInspectionCheckList2(dtLaserlist2, Session["EmpNumber"].ToString(), model.LineId, model.ProjectId, model.ModelId, model.PartId);

            //    if (i > 0)
            //    {
            //        TempData["mgs"] = "Sucess";
            //        TempData["Alert"] = "Sucessfully Results Saved!!!";
            //        return RedirectToAction("CheckListFirstArticleInspection");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("ERROR", "Already Existed !!!");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ModelState.AddModelError("ERROR", ex.Message);
            //    //Log.Error("Error", ex);
            //}

            model.dtChecklist = _checkFirstArticle.GetFormByFirstArticleInspection(model.LineId, model.ProjectId);

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            model.SRSS = (List<DOL.SRS>)Session["SRes"];


            //model2.Lines = (List<Line>)Session["Lines"];
            //model2.Shifts = (List<Shift>)Session["Shifts"];
            //model2.Projects = (List<DOL.Project>)Session["Projects"];
            //model2.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            //model2.PartNos = (List<DOL.PartNo>)Session["PartNos"];

            return View("CheckListFirstArticleInspection", model);
        }

        

        [HttpGet]
        public ActionResult CheckListOutGoingInspection()
        {
            OutGoingInspectionResultModelView model = new OutGoingInspectionResultModelView();
            model.dtChecklist = new DataTable();
            model.Lines = _checkResult.GetLine();
            model.Projects = _CheckListCircuitRecord.GetProject();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }
        [HttpPost]
        public ActionResult CheckListOutGoingInspection(OutGoingInspectionResultModelView model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                model.dtChecklist = _checkNative.GetFormByOutInspection(model.ProjectId);
                model.Lines = (List<Line>)Session["Lines"];
                model.Projects = (List<DOL.Project>)Session["Projects"];

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model);
        }
        [HttpPost]
        public ActionResult SaveOutGoingInspection(OutGoingInspectionResultModelView model)
        {
            DataTable dtChecklist = new DataTable("CheckListoutGoingInspectionResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("ItemId");
            dtChecklist.Columns.Add("SpecId");
            dtChecklist.Columns.Add("ContentId");
            dtChecklist.Columns.Add("Result");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.CheckListoutGoingInspectionResults)
                {




                    dtChecklist.Rows.Add(Uid, row.ItemId, row.SpecId, row.ContentId, row.Result);
                    Uid++;

                }




                int i = _checkNative.InsertCheckListOutInspection(dtChecklist, Session["EmpNumber"].ToString(), model.LineId, model.ProjectId, model.CheckedBy, model.ApprovedBy, model.CustomerPin, model.LotSize, model.FinishedProductNo, model.Rev, model.PackingListNo, model.InspectResult);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("CheckListOutGoingInspection");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            model.dtChecklist = _checkNative.GetFormByOutInspection(model.ProjectId);
            model.Lines = (List<Line>)Session["Lines"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            return View("CheckListOutGoingInspection", model);
        }
        [HttpGet]
        public ActionResult CheckListAuditCheckPoints()
        {
            CheckListAuditCheckPointsModelview model = new CheckListAuditCheckPointsModelview();
            model.dtChecklist = new DataTable();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            //Session["Exponents"] = model.Exponents;
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Shifts"] = model.Shifts;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }
        [HttpPost]
        public ActionResult CheckListAuditCheckPoints(CheckListAuditCheckPointsModelview model)
        {
            model.dtChecklist = _checkNative.GetFormByAuditCheckPoints(model.LineId, model.ProjectId);
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            //model.Exponents = _CheckListCircuitRecord.GetExponent();
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];

            if (!ModelState.IsValid)
                return View(model);

            try
            {
                model.dtChecklist = _checkNative.GetFormByAuditCheckPoints(model.LineId, model.ProjectId);
                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                model.Projects = (List<DOL.Project>)Session["Projects"];
                model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model.PartNos = (List<DOL.PartNo>)Session["PartNos"];

                Session["Lines"] = model.Lines;
                Session["Shifts"] = model.Shifts;
                Session["ModelNos"] = model.ModelNos;
                Session["PartNos"] = model.PartNos;


            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model);
        }
        [HttpPost]
        public ActionResult SaveAuditCheckPoints(CheckListAuditCheckPointsModelview model)
        {

            DataTable dtChecklist = new DataTable("CheckListAuditChecksResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("CheckId");
            dtChecklist.Columns.Add("Status");
            dtChecklist.Columns.Add("Image");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.CheckListAuditChecksResults)
                {




                    dtChecklist.Rows.Add(Uid, row.CheckId, row.Status, row.Image);
                    Uid++;

                }




                int i = _checkNative.InsertCheckListLineAudit(dtChecklist, Session["EmpNumber"].ToString(), model.LineId, model.ProjectId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.ModelId, model.PartId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("CheckListAuditCheckPoints");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            model.dtChecklist = _checkNative.GetFormByAuditCheckPoints(model.LineId, model.ProjectId);
            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            return View("CheckListAuditCheckPoints", model);
        }

        [HttpPost]
        public ActionResult UploadDocument()
        {
            string dbrelativepath = string.Empty;
            string CheckedItempic = string.Empty;
            HttpFileCollectionBase files = Request.Files;
            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFileBase file = files[i];
                string OriginalName = file.FileName;
                string targetfolder = Server.MapPath("~/Images/");
                string uniquename = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(OriginalName);
                var path = Path.Combine(targetfolder, uniquename);

                file.SaveAs(path);
                dbrelativepath = Url.Content(Path.Combine("~/Images/", uniquename));

                //MemoryStream target = new MemoryStream();

                //file.InputStream.CopyTo( target );
                //byte[] data = target.ToArray();
                // CheckedItempic = Convert.ToBase64String( data );
                //CheckedItempic = "data:image/jpeg;base64," + CheckedItempic;

            }

            return Json(dbrelativepath, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult CheckListTrapTest()
        {
            CheckListTrapTestResultViewModel model = new CheckListTrapTestResultViewModel();
            model.dtChecklist = new DataTable();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.InspectorSS = new List<DOL.InspectorSS>();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Shifts"] = model.Shifts;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }
        [HttpPost]
        public ActionResult CheckListTrapTest(CheckListTrapTestResultViewModel model)
        {
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            model.InspectorSS = (List<DOL.InspectorSS>)Session["Inspectss"];
            model.dtChecklist = _checkNative.GetFormByTrapTest(model.LineId, model.ProjectId);
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                model.dtChecklist = _checkNative.GetFormByTrapTest(model.LineId, model.ProjectId);
                model.Lines = (List<Line>)Session["Lines"];
                model.Projects = (List<DOL.Project>)Session["Projects"];
                model.Shifts = _checkResult.GetShift();
                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                model.Projects = (List<DOL.Project>)Session["Projects"];
                model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                model.InspectorSS = (List<DOL.InspectorSS>)Session["Inspectss"];
                Session["Lines"] = model.Lines;
                Session["Shifts"] = model.Shifts;
                Session["ModelNos"] = model.ModelNos;
                Session["PartNos"] = model.PartNos;
                Session["Categories"] = model.Categories;

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveTrapTest(CheckListTrapTestResultViewModel model)
        {
            DataTable dtChecklist = new DataTable("CheckListTrapTestResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("InspectId");
            dtChecklist.Columns.Add("InspecId");
            dtChecklist.Columns.Add("InspectorName");
            dtChecklist.Columns.Add("InspectorId");
            dtChecklist.Columns.Add("NoOfCables");
            dtChecklist.Columns.Add("CheckResult");
            //dtChecklist.Columns.Add("categoryId");
            dtChecklist.Columns.Add("SkippedQty");
            dtChecklist.Columns.Add("CheckedQty");
            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.CheckListTrapTestResults)
                {




                    dtChecklist.Rows.Add(Uid, row.InspectId,row.InspecId, row.InspectorName, row.InspectorId, row.NoOfCables, row.CheckResult, row.SkippedQty, row.CheckedQty);
                    Uid++;

                }




                int i = _checkNative.InsertCheckListTrapTest(dtChecklist, Session["EmpNumber"].ToString(), model.LineId, model.ProjectId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.ModelId, model.PartId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("CheckListTrapTest");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            model.dtChecklist = _checkNative.GetFormByTrapTest(model.LineId, model.ProjectId);
            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            model.InspectorSS = (List<DOL.InspectorSS>)Session["Inspectss"];
            return View("CheckListTrapTest", model);
        }

        [HttpGet]
        public ActionResult CheckListCircuitBoard()
        {
            CheckListCircuitBoardResultModelView model = new CheckListCircuitBoardResultModelView();
            model.dtChecklist = new DataTable();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.ProcessTourss = _checkResult.GetProcessTours();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Shifts"] = model.Shifts;
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["ProcessTourss"] = model.ProcessTourss;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }
        [HttpPost]
        public ActionResult CheckListCircuitBoard(CheckListCircuitBoardResultModelView model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                model.dtChecklist = _checkNative.GetFormByCircuitBoardRecord(model.LineId, model.ProjectId,model.ProcessTourId);
                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                model.Projects = (List<DOL.Project>)Session["Projects"];
                model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                model.ProcessTourss = (List<DOL.ProcessTourss>)Session["ProcessTourss"];
               // model.ProcessTourss = Session["ProcessTourss"];
                Session["Lines"] = model.Lines;
                Session["Shifts"] = model.Shifts;
                Session["ModelNos"] = model.ModelNos;
                Session["PartNos"] = model.PartNos;

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveCircuitBoard(CheckListCircuitBoardResultModelView model)
        {

            DataTable dtChecklist = new DataTable("CheckListCircuitBoardResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("SpecId");
            dtChecklist.Columns.Add("Value1");
            dtChecklist.Columns.Add("Value2");
            dtChecklist.Columns.Add("Value3");
            dtChecklist.Columns.Add("Value4");
            dtChecklist.Columns.Add("Value5");
            // dtChecklist.Columns.Add("Result");
            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.CheckListCircuitBoardResults)
                {




                    dtChecklist.Rows.Add(Uid, row.SpecId, row.Value1, row.Value2, row.Value3, row.Value4, row.Value5);
                    Uid++;

                }




                int i = _checkNative.InsertCheckListCircuitRecord(dtChecklist, Session["EmpNumber"].ToString(), model.LineId, model.ProjectId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.ModelId, model.PartId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("CheckListCircuitBoard");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            model.dtChecklist = _checkNative.GetFormByAuditCheckPoints(model.LineId, model.ProjectId);
            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            model.ProcessTourss = (List<DOL.ProcessTourss>)Session["ProcessTourss"];

            return View("CheckListCircuitBoard", model);
        }

        [HttpGet]
        public ActionResult CheckListCTQManPower()
        {
            CheckListCTQManPowerResultModelView model = new CheckListCTQManPowerResultModelView();

            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            //model.Categories = _CheckListCircuitRecord.GetInspectorcategory();
            model.Categories = new List<DOL.InspectorCategory>();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            //Session["Exponents"] = model.Exponents;
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Shifts"] = model.Shifts;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult CheckListCTQManPower(CheckListCTQManPowerResultModelView model)
        {
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            model.Categories = (List<DOL.InspectorCategory>)Session["Categories"];
            model.dtChecklist = _checkNative.GetFormByCTQManPower(model.LineId, model.ProjectId);

            if (!ModelState.IsValid)
                return View(model);

            try
            {
                model.dtChecklist = _checkNative.GetFormByCTQManPower(model.LineId, model.ProjectId);
                model.Lines = _checkResult.GetLine();
                //model.Shifts = _checkResult.GetShift();

                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                model.Projects = (List<DOL.Project>)Session["Projects"];
                model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                model.Categories = (List<DOL.InspectorCategory>)Session["Categories"];
                Session["Lines"] = model.Lines;
                Session["Shifts"] = model.Shifts;
                Session["ModelNos"] = model.ModelNos;
                Session["PartNos"] = model.PartNos;
                Session["Categories"] = model.Categories;
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveCTQManPower(CheckListCTQManPowerResultModelView model)
        {

            DataTable dtChecklist = new DataTable("CheckListCTQManPowerResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("InspectionId");
            dtChecklist.Columns.Add("InspectorName");
            dtChecklist.Columns.Add("InspectorId");
            dtChecklist.Columns.Add("Result");
            dtChecklist.Columns.Add("categoryId");
            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.CheckListCTQManPowerResults)
                {




                    dtChecklist.Rows.Add(Uid, row.InspectionId, row.InspectorName, row.InspectorId, row.Result, row.categoryId);
                    Uid++;

                }




                int i = _checkNative.InsertBulkCTQManPowerCheckList(dtChecklist, Session["EmpNumber"].ToString(), model.LineId, model.ProjectId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.ModelId, model.PartId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("CheckListCTQManPower");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            model.dtChecklist = _checkNative.GetFormByCTQManPower(model.LineId, model.ProjectId);
            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            model.Categories = (List<DOL.InspectorCategory>)Session["Categories"];
            return View("CheckListCTQManPower", model);
        }

        [HttpGet]
        public ActionResult CheckListXBar()
        {
            CheckListXBarResultModelView model = new CheckListXBarResultModelView();
            model.dtChecklist = new DataTable();
            model.Lines = _checkResult.GetLine();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.Adhesives = new List<DOL.Adhesivee>();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            //Session["Adhesives"] = model.Adhesives;
            Session["ModelNos"] = model.ModelNos;
            Session["PartNos"] = model.PartNos;
            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult CheckListXBar(CheckListXBarResultModelView model)
        {
            model.Lines = (List<DOL.Line>)Session["Lines"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.Adhesives = (List<DOL.Adhesivee>)Session["Adhesives"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];

            if (!ModelState.IsValid)
            {
                model.dtChecklist = new DataTable();
                return View(model);
            }


            try
            {
                model.dtChecklist = _checkNative.GetFormByAdhesive(model.LineId, model.ProjectId, model.AdhesiveId);
                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                model.Projects = (List<DOL.Project>)Session["Projects"];
                model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                Session["Lines"] = model.Lines;
                Session["Shifts"] = model.Shifts;
                Session["Adhesives"] = model.Adhesives;
                Session["ModelNos"] = model.ModelNos;
                Session["PartNos"] = model.PartNos;
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveXBar(CheckListXBarResultModelView model)
        {

            DataTable dtChecklist = new DataTable("CheckListXBarResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("AdhesiveId");
            dtChecklist.Columns.Add("DataValue");
            dtChecklist.Columns.Add("RootCause");
            //dtChecklist.Columns.Add("FeedBack");
            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.CheckListXBarResults)
                {




                    dtChecklist.Rows.Add(Uid, row.AdhesiveId, row.DataValue, row.RootCause);
                    Uid++;

                }




                int i = _checkNative.InsertBulkAdhesiveCheckList(dtChecklist, Session["EmpNumber"].ToString(), model.LineId, model.ProjectId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.ModelId, model.PartId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("CheckListXBar");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            model.dtChecklist = _checkNative.GetFormByAdhesive(model.LineId, model.ProjectId, model.AdhesiveId);
            model.Lines = (List<Line>)Session["Lines"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.Adhesives = (List<DOL.Adhesivee>)Session["Adhesives"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            return View("CheckListXBar", model);
        }

        [HttpGet]
        public ActionResult CheckListTemperatureRange()
        {
            CheckListTemperatureResultModelView model = new CheckListTemperatureResultModelView();
            model.dtChecklist = new DataTable();
            model.Lines = _checkResult.GetLine();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.Shifts = _checkResult.GetShift();
            model.Ranges = new List<DOL.TempRange>();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Shifts"] = model.Shifts;
            //Session["Ranges"] = model.Ranges;
            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult CheckListTemperatureRange(CheckListTemperatureResultModelView model)
        {
            model.Lines = (List<DOL.Line>)Session["Lines"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Ranges = (List<DOL.TempRange>)Session["Ranges"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            Session["Lines"] = model.Lines;
            Session["Shifts"] = model.Shifts;
            Session["Ranges"] = model.Ranges;
            Session["ModelNos"] = model.ModelNos;
            Session["PartNos"] = model.PartNos;
            if (!ModelState.IsValid)
            {
                model.dtChecklist = new DataTable();
                return View(model);
            }


            try
            {
                model.dtChecklist = _checkNative.GetFormByTemparatureRange(model.LineId, model.ProjectId, model.TempId);

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveCheckListTemperatureRange(CheckListTemperatureResultModelView model)
        {

            DataTable dtChecklist = new DataTable("CheckListTemperatures");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("TempId");
            dtChecklist.Columns.Add("Value");
            dtChecklist.Columns.Add("Determine");
            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.CheckListTemperatures)
                {




                    dtChecklist.Rows.Add(Uid, row.TempId, row.Value, row.Determine);
                    Uid++;

                }




                int i = _checkNative.InsertBulkTemperatureRangeCheckList(dtChecklist, Session["EmpNumber"].ToString(), model.LineId, model.ProjectId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.EquipmentNo, model.TypeNo, model.ModelId, model.PartId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("CheckListTemperatureRange");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            model.dtChecklist = _checkNative.GetFormByTemparatureRange(model.LineId, model.ProjectId, model.TempId);
            model.Lines = (List<Line>)Session["Lines"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Ranges = (List<DOL.TempRange>)Session["Ranges"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            return View("CheckListTemperatureRange", model);
        }

        [HttpGet]
        public ActionResult CheckListDestructiveTest()
        {
            CheckListDestructiveTestResultModelView model = new CheckListDestructiveTestResultModelView();
            model.dtChecklist = new DataTable();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Shifts"] = model.Shifts;
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            return View(model);
        }

        [HttpPost]
        public ActionResult CheckListDestructiveTest(CheckListDestructiveTestResultModelView model)
        {
            model.dtChecklist = _checkNative.GetFormByDestructiveTest(model.LineId, model.ProjectId);
            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            Session["Lines"] = model.Lines;
            Session["Shifts"] = model.Shifts;
            Session["ModelNos"] = model.ModelNos;
            Session["PartNos"] = model.PartNos;

            if (!ModelState.IsValid)
            {
                model.dtChecklist = new DataTable();
                return View(model);
            }


            try
            {
                model.dtChecklist = _checkNative.GetFormByDestructiveTest(model.LineId, model.ProjectId);
                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                model.Projects = (List<DOL.Project>)Session["Projects"];
                model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                Session["Lines"] = model.Lines;
                Session["Shifts"] = model.Shifts;
                Session["ModelNos"] = model.ModelNos;
                Session["PartNos"] = model.PartNos;

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveCheckListDestructiveTest(CheckListDestructiveTestResultModelView model)
        {

            DataTable dtChecklist = new DataTable("CheckListDestructiveTestResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("SpecId");
            dtChecklist.Columns.Add("Value1");
            dtChecklist.Columns.Add("Value2");
            dtChecklist.Columns.Add("Value3");
            dtChecklist.Columns.Add("Value4");
            dtChecklist.Columns.Add("SNo1");
            dtChecklist.Columns.Add("SNo2");
            dtChecklist.Columns.Add("SNo3");
            dtChecklist.Columns.Add("SNo4");
            //dtChecklist.Columns.Add("Value5");
            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.CheckListDestructiveTestResults)
                {




                    dtChecklist.Rows.Add(Uid, row.SpecId, row.Value1, row.Value2, row.Value3, row.Value4, row.SNo1, row.SNo2, row.SNo3, row.SNo4);
                    Uid++;

                }




                int i = _checkNative.InsertBulkDestructive(dtChecklist, Session["EmpNumber"].ToString(), model.LineId, model.ProjectId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.ModelId, model.PartId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("CheckListDestructiveTest");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            model.dtChecklist = _checkNative.GetFormByDestructiveTest(model.LineId, model.ProjectId);
            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            return View("CheckListDestructiveTest", model);
        }

        [HttpGet]
        public ActionResult CheckListWristStrap()
        {
            CheckListWristStrapModelView model = new CheckListWristStrapModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            //model.Exponents = _CheckListCircuitRecord.GetExponent();
            model.Exponents = new List<DOL.Exponent>();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            //Session["Exponents"] = model.Exponents;
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Shifts"] = model.Shifts;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult CheckListWristStrap(CheckListWristStrapModelView model)
        {
            model.dtChecklist = _checkResult.GetFormByWristStrap(model.LineId, model.ProjectId);
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            //model.Exponents = _CheckListCircuitRecord.GetExponent();
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            model.Exponents = (List<DOL.Exponent>)Session["Exponents"];

            if (!ModelState.IsValid)
                return View(model);
            try
            {
                model.dtChecklist = _checkResult.GetFormByWristStrap(model.LineId, model.ProjectId);
                model.Lines = _checkResult.GetLine();
                //model.Shifts = _checkResult.GetShift();

                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                model.Projects = (List<DOL.Project>)Session["Projects"];
                model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                model.Exponents = (List<DOL.Exponent>)Session["Exponents"];
                //model.Exponents = _CheckListCircuitRecord.GetExponent();
                Session["Lines"] = model.Lines;
                Session["Shifts"] = model.Shifts;
                Session["ModelNos"] = model.ModelNos;
                Session["PartNos"] = model.PartNos;
                Session["Exponents"] = model.Exponents;
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveCheckListWristStrap(CheckListWristStrapModelView model)
        {
            DataTable dtLaserlist = new DataTable("CheckListWristStrapResults");
            dtLaserlist.Columns.Add("Id");
            dtLaserlist.Columns.Add("StationId");
            dtLaserlist.Columns.Add("Value");
            //dtLaserlist.Columns.Add("EquipmentDescription");
            //dtLaserlist.Columns.Add("EPA");
            //dtLaserlist.Columns.Add("Environment");
            dtLaserlist.Columns.Add("ExpId");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.CheckListWristStrapResults)
                {
                    dtLaserlist.Rows.Add(Uid, row.StationId, row.Value, row.ExpId);
                    Uid++;

                }

                int i = _checkResult.InsertCheckListWristStrap(dtLaserlist, Session["EmpNumber"].ToString(), model.LineId, model.ProjectId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.ModelId, model.PartId);

                model.dtChecklist = _checkResult.GetFormByWristStrap(model.LineId, model.ProjectId);



                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("CheckListWristStrap");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            //  model.dtLaser = _objchecklistResults.InsertLaserResults(model.LineId);

            //model.dtLaser = _checkResult.GetLaserSize(model.LineId,model.ProjectId);

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.Exponents = (List<DOL.Exponent>)Session["Exponents"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            return View("CheckListWristStrap", model);
        }

        [HttpGet]
        public ActionResult CheckListWorkSurface()
        {
            CheckListWorkSurfaceModelView model = new CheckListWorkSurfaceModelView();
            model.dtChecklist = new DataTable();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            //model.Exponents = _CheckListCircuitRecord.GetExponent();
            model.Exponents = new List<DOL.Exponent>();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            //Session["Exponents"] = model.Exponents;
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Shifts"] = model.Shifts;

            return View(model);
        }

        [HttpPost]
        public ActionResult CheckListWorkSurface(CheckListWorkSurfaceModelView model)
        {
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            //model.Exponents = _CheckListCircuitRecord.GetExponent();
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            model.Exponents = (List<DOL.Exponent>)Session["Exponents"];
            model.dtChecklist = _checkResult.GetFormByWorkSurface(model.LineId, model.ProjectId);

            if (!ModelState.IsValid)
                return View(model);
            try
            {
                model.dtChecklist = _checkResult.GetFormByWorkSurface(model.LineId, model.ProjectId);
                //model.Lines = _checkResult.GetLine();
                //model.Shifts = _checkResult.GetShift();

                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                model.Projects = (List<DOL.Project>)Session["Projects"];
                model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                model.Exponents = (List<DOL.Exponent>)Session["Exponents"];
                //model.Exponents = _CheckListCircuitRecord.GetExponent();
                Session["Lines"] = model.Lines;
                Session["Shifts"] = model.Shifts;
                Session["ModelNos"] = model.ModelNos;
                Session["PartNos"] = model.PartNos;
                Session["Exponents"] = model.Exponents;
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveCheckListWorkSurface(CheckListWorkSurfaceModelView model)
        {
            DataTable dtLaserlist = new DataTable("CheckListWorkSurfaceResults");
            dtLaserlist.Columns.Add("Id");
            dtLaserlist.Columns.Add("StationId");
            dtLaserlist.Columns.Add("Value");
            //dtLaserlist.Columns.Add("EquipmentDescription");
            //dtLaserlist.Columns.Add("EPA");
            //dtLaserlist.Columns.Add("Environment");
            dtLaserlist.Columns.Add("ExpId");

            //dtLaserlist.Columns.Add("ExpId");
            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.CheckListWorkSurfaceResults)
                {
                    dtLaserlist.Rows.Add(Uid, row.StationId, row.Value, row.ExpId);
                    Uid++;

                }

                int i = _checkResult.InsertBulkWorkSurfaceCheckList(dtLaserlist, Session["EmpNumber"].ToString(), model.LineId, model.ProjectId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.ModelId, model.PartId);





                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("CheckListWorkSurface");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            //  model.dtLaser = _objchecklistResults.InsertLaserResults(model.LineId);

            //model.dtLaser = _checkResult.GetLaserSize(model.LineId,model.ProjectId);

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.Exponents = (List<DOL.Exponent>)Session["Exponents"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            model.dtChecklist = _checkResult.GetFormByWorkSurface(model.LineId, model.ProjectId);
            //model.Exponents = _CheckListCircuitRecord.GetExponent();
            return View("CheckListWorkSurface", model);
        }

        [HttpGet]
        public ActionResult CheckListEquipment()
        {
            CheckListEquipmentModelView model = new CheckListEquipmentModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Shifts"] = model.Shifts;

            model.Exponents = _CheckListCircuitRecord.GetExponent();
            Session["Exponents"] = model.Exponents;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult CheckListEquipment(CheckListEquipmentModelView model)
        {
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.Exponents = _CheckListCircuitRecord.GetExponent();
            model.dtChecklist = _checkResult.GetFormByEquipment(model.LineId, model.ProjectId);

            if (!ModelState.IsValid)
                return View(model);
            //return RedirectToAction("CheckListEquipment");

            try
            {
                model.dtChecklist = _checkResult.GetFormByEquipment(model.LineId, model.ProjectId);
                //model.Lines = _checkResult.GetLine();
                //model.Shifts = _checkResult.GetShift();
                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                model.Projects = (List<DOL.Project>)Session["Projects"];
                //model.Exponents = (List<DOL.Exponent>)Session["Exponents"];
                model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                model.Exponents = _CheckListCircuitRecord.GetExponent();
                Session["Lines"] = model.Lines;
                Session["Shifts"] = model.Shifts;
                Session["ModelNos"] = model.ModelNos;
                Session["PartNos"] = model.PartNos;
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveCheckListEquipment(CheckListEquipmentModelView model)
        {
            DataTable dtLaserlist = new DataTable("CheckListEquipmentResults");
            dtLaserlist.Columns.Add("Id");
            dtLaserlist.Columns.Add("StationId");
            dtLaserlist.Columns.Add("Spec");
            //dtLaserlist.Columns.Add("EquipmentDescription");
            //dtLaserlist.Columns.Add("EPA");
            //dtLaserlist.Columns.Add("Environment");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.CheckListEquipmentResults)
                {
                    dtLaserlist.Rows.Add(Uid, row.StationId, row.Spec);
                    Uid++;

                }

                int i = _checkResult.InsertBulkEquipmentCheckList(dtLaserlist, Session["EmpNumber"].ToString(), model.LineId, model.ProjectId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.ModelId, model.PartId);

                model.dtChecklist = _checkResult.GetFormByEquipment(model.LineId, model.ProjectId);



                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("CheckListEquipment");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            //  model.dtLaser = _objchecklistResults.InsertLaserResults(model.LineId);

            //model.dtLaser = _checkResult.GetLaserSize(model.LineId,model.ProjectId);

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.Exponents = (List<DOL.Exponent>)Session["Exponents"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            return View("CheckListEquipment", model);
        }

        [HttpGet]
        public ActionResult CheckListInspectionLightLux()
        {
            CheckListInspectionLightLuxModelView model = new CheckListInspectionLightLuxModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Shifts"] = model.Shifts;
            //model.Exponents = _CheckListCircuitRecord.GetExponent();
            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult CheckListInspectionLightLux(CheckListInspectionLightLuxModelView model)
        {
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            //model.Exponents = _CheckListCircuitRecord.GetExponent();
            model.dtChecklist = _checkResult.GetFormByInspectionLightLux(model.LineId, model.ProjectId);

            if (!ModelState.IsValid)
                return View(model);
            try
            {
                model.dtChecklist = _checkResult.GetFormByInspectionLightLux(model.LineId, model.ProjectId);
                model.Exponents = _CheckListCircuitRecord.GetExponent();
                //model.Lines = _checkResult.GetLine();
                //model.Shifts = _checkResult.GetShift();
                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                model.Projects = (List<DOL.Project>)Session["Projects"];
                model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                Session["Lines"] = model.Lines;
                Session["Shifts"] = model.Shifts;


            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveCheckInspectionLightLux(CheckListInspectionLightLuxModelView model)
        {
            DataTable dtLaserlist = new DataTable("CheckListInspectionLightLuxResults");
            dtLaserlist.Columns.Add("Id");
            dtLaserlist.Columns.Add("StationId");
            dtLaserlist.Columns.Add("Spec");
            //dtLaserlist.Columns.Add("EquipmentDescription");
            //dtLaserlist.Columns.Add("EPA");
            //dtLaserlist.Columns.Add("Environment");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.CheckListInspectionLightLuxResults)
                {
                    dtLaserlist.Rows.Add(Uid, row.StationId, row.Spec);
                    Uid++;

                }

                int i = _checkResult.InsertBulkInspectionLightLuxCheckList(dtLaserlist, Session["EmpNumber"].ToString(), model.LineId, model.ProjectId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.ModelId, model.PartId);

                model.dtChecklist = _checkResult.GetFormByInspectionLightLux(model.LineId, model.ProjectId);

                model.Exponents = _CheckListCircuitRecord.GetExponent();

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("CheckListInspectionLightLux");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            //  model.dtLaser = _objchecklistResults.InsertLaserResults(model.LineId);

            //model.dtLaser = _checkResult.GetLaserSize(model.LineId,model.ProjectId);

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            //model.Exponents = _CheckListCircuitRecord.GetExponent();
            return View("CheckListInspectionLightLux", model);
        }

        [HttpGet]
        public ActionResult CheckListNonInspectionLightLux()
        {
            CheckListNonInspectionLightLuxModelView model = new CheckListNonInspectionLightLuxModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Shifts"] = model.Shifts;

            model.Exponents = _CheckListCircuitRecord.GetExponent();
            //Session["Exponents"] = model.Exponents;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult CheckListNonInspectionLightLux(CheckListNonInspectionLightLuxModelView model)
        {
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();

            model.Exponents = _CheckListCircuitRecord.GetExponent();
            model.dtChecklist = _checkResult.GetFormByNonInspectionLightLux(model.LineId, model.ProjectId);

            if (!ModelState.IsValid)
                return View(model);
            try
            {
                model.dtChecklist = _checkResult.GetFormByNonInspectionLightLux(model.LineId, model.ProjectId);
                //model.Lines = _checkResult.GetLine();
                //model.Shifts = _checkResult.GetShift();
                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                model.Projects = (List<DOL.Project>)Session["Projects"];
                model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                //model.Exponents = (List<DOL.Exponent>)Session["Exponents"];
                model.Exponents = _CheckListCircuitRecord.GetExponent();
                Session["Lines"] = model.Lines;
                Session["Shifts"] = model.Shifts;
                Session["ModelNos"] = model.ModelNos;
                Session["PartNos"] = model.PartNos;
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveCheckNonInspectionLightLux(CheckListNonInspectionLightLuxModelView model)
        {
            DataTable dtLaserlist = new DataTable("CheckListNonInspectionLightLuxResults");
            dtLaserlist.Columns.Add("Id");
            dtLaserlist.Columns.Add("StationId");
            dtLaserlist.Columns.Add("Spec");
            //dtLaserlist.Columns.Add("EquipmentDescription");
            //dtLaserlist.Columns.Add("EPA");
            //dtLaserlist.Columns.Add("Environment");
            //dtLaserlist.Columns.Add("ExpId");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.CheckListNonInspectionLightLuxResults)
                {
                    dtLaserlist.Rows.Add(Uid, row.StationId, row.Spec);
                    Uid++;

                }

                int i = _checkResult.InsertBulkNonInspectionLightLuxCheckList(dtLaserlist, Session["EmpNumber"].ToString(), model.LineId, model.ProjectId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.ModelId, model.PartId);

                model.dtChecklist = _checkResult.GetFormByNonInspectionLightLux(model.LineId, model.ProjectId);

                model.Exponents = _CheckListCircuitRecord.GetExponent();

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("CheckListInspectionLightLux");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            //  model.dtLaser = _objchecklistResults.InsertLaserResults(model.LineId);

            //model.dtLaser = _checkResult.GetLaserSize(model.LineId,model.ProjectId);

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            //model.Exponents = (List<DOL.Exponent>)Session["Exponents"];

            model.Exponents = _CheckListCircuitRecord.GetExponent();

            return View("CheckListInspectionLightLux", model);
        }

        [HttpGet]
        public ActionResult CheckListQualityAudit()
        {
            CheckListQualityAuditModelView model = new CheckListQualityAuditModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Shifts"] = model.Shifts;

            model.Statuses = _CheckListCircuitRecord.GetResult();
            //Session["Exponents"] = model.Exponents;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult CheckListQualityAudit(CheckListQualityAuditModelView model)
        {
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();

            model.Statuses = _CheckListCircuitRecord.GetResult();

            //model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];

            model.dtChecklist = _checkResult.GetFormByQualityAudit(model.LineId, model.ProjectId);

            if (!ModelState.IsValid)
                return View(model);
            try
            {
                model.dtChecklist = _checkResult.GetFormByQualityAudit(model.LineId, model.ProjectId);
                //model.Lines = _checkResult.GetLine();
                //model.Shifts = _checkResult.GetShift();
                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                model.Projects = (List<DOL.Project>)Session["Projects"];
                model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                //model.Exponents = (List<DOL.Exponent>)Session["Exponents"];
                model.Statuses = _CheckListCircuitRecord.GetResult();
                Session["Lines"] = model.Lines;
                Session["Shifts"] = model.Shifts;
                Session["ModelNos"] = model.ModelNos;
                Session["PartNos"] = model.PartNos;
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveCheckQualityAudit(CheckListQualityAuditModelView model)
        {
            DataTable dtLaserlist = new DataTable("CheckListQualityAuditResults");
            dtLaserlist.Columns.Add("Id");
            dtLaserlist.Columns.Add("RiskId");
            dtLaserlist.Columns.Add("StatusId");
            //dtLaserlist.Columns.Add("Status");
            //dtLaserlist.Columns.Add("Sampling");
            //dtLaserlist.Columns.Add("Environment");
            dtLaserlist.Columns.Add("Namee");
            dtLaserlist.Columns.Add("Image");
            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.CheckListQualityAuditResults)
                {
                    dtLaserlist.Rows.Add(Uid, row.RiskId, row.StatusId, row.Namee, row.Image);
                    Uid++;

                }

                int i = _checkResult.InsertBulkQualityAuditCheckList(dtLaserlist, Session["EmpNumber"].ToString(), model.LineId, model.ProjectId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.ModelId, model.PartId);

                model.dtChecklist = _checkResult.GetFormByQualityAudit(model.LineId, model.ProjectId);

                model.Statuses = _CheckListCircuitRecord.GetResult();

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("CheckListQualityAudit");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            //  model.dtLaser = _objchecklistResults.InsertLaserResults(model.LineId);

            //model.dtLaser = _checkResult.GetLaserSize(model.LineId,model.ProjectId);

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            //model.Exponents = (List<DOL.Exponent>)Session["Exponents"];

            model.Statuses = _CheckListCircuitRecord.GetResult();

            return View("CheckListQualityAudit", model);
        }

        [HttpGet]
        public ActionResult CheckListOBA()
        {
            CheckListOBAModelView model = new CheckListOBAModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            model.Cables = new List<DOL.Cable>();
            model.SRes = new List<DOL.SRS>();
            model.PlugShelles = new List<DOL.PlugShellC70>();
            model.PlugShells = new List<DOL.PlugShellC91>();
            model.Boots = new List<DOL.BootC70>();
            model.Bootts = new List<DOL.BootC91>();
            model.FacePlates = new List<DOL.FacePlateC70>();
            model.FacePlatess = new List<DOL.FacePlateC91>();
            model.PaperCollars = new List<DOL.PaperCollar>();
            
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Shifts"] = model.Shifts;
            Session["Cables"] = model.Cables;
            Session["SRes"] = model.SRes;
            Session["PlugShelles"] = model.PlugShelles;
            Session["PlugShells"] = model.PlugShells;
            Session["FacePlates"] = model.FacePlates;
            Session["FacePlatess"] = model.FacePlatess;
            Session["PaperCollars"] = model.PaperCollars;
            Session["Boots"] = model.Boots;
            Session["Bootts"] = model.Bootts;

            //model.Statuses = _CheckListCircuitRecord.GetResult();
            //Session["Exponents"] = model.Exponents;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult CheckListOBA(CheckListOBAModelView model)
        {
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            //model.Cables = _CheckListCircuitRecord.GetCable(model.ProjectId);

            model.Cables = (List<Cable>)Session["Cables"];
            model.SRes = (List<SRS>)Session["SRes"];
            model.PlugShelles = (List<PlugShellC70>)Session["PlugShelles"];
            model.PlugShells = (List<PlugShellC91>)Session["PlugShells"];
            model.FacePlates = (List<FacePlateC70>)Session["FacePlates"];
            model.FacePlatess = (List<FacePlateC91>)Session["FacePlatess"];
            model.PaperCollars = (List<PaperCollar>)Session["PaperCollars"];
            model.Boots = (List<BootC70>)Session["Boots"];
            model.Bootts = (List<BootC91>)Session["Bootts"];
            //model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];

            Session["Cables"] = model.Cables;
            Session["SRes"] = model.SRes;
            Session["PlugShelles"] = model.PlugShelles;
            Session["PlugShells"] = model.PlugShells;
            Session["Boots"] = model.Boots;
            Session["Bootts"] = model.Bootts;
            Session["FacePlates"] = model.FacePlates;
            Session["FacePlatess"] = model.FacePlatess;
            Session["PaperCollars"] = model.PaperCollars;
            

            //model.dtChecklist = _checkResult.GetFormByQualityAudit(model.LineId, model.ProjectId);

            if (!ModelState.IsValid)
                return View(model);
            try
            {
                //model.dtChecklist = _checkResult.GetFormByQualityAudit(model.LineId, model.ProjectId);
                //model.Lines = _checkResult.GetLine();
                //model.Shifts = _checkResult.GetShift();

                model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
                model.Lines = _checkResult.GetLine();
                model.Shifts = _checkResult.GetShift();
                model.Projects = _CheckListCircuitRecord.GetProject();

                model.Cables = (List<Cable>)Session["Cables"];
                model.SRes = (List<SRS>)Session["SRes"];
                model.PlugShelles = (List<PlugShellC70>)Session["PlugShelles"];
                model.PlugShells = (List<PlugShellC91>)Session["PlugShells"];
                model.FacePlates = (List<FacePlateC70>)Session["FacePlates"];
                model.FacePlatess = (List<FacePlateC91>)Session["FacePlatess"];
                model.PaperCollars = (List<PaperCollar>)Session["PaperCollars"];
                model.Boots = (List<BootC70>)Session["Boots"];
                model.Bootts = (List<BootC91>)Session["Bootts"];

                //model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                model.Projects = (List<DOL.Project>)Session["Projects"];
                model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model.PartNos = (List<DOL.PartNo>)Session["PartNos"];

                Session["Cables"] = model.Cables;
                Session["SRes"] = model.SRes;
                Session["PlugShelles"] = model.PlugShelles;
                Session["PlugShells"] = model.PlugShells;
                Session["Boots"] = model.Boots;
                Session["Bootts"] = model.Bootts;
                Session["FacePlates"] = model.FacePlates;
                Session["FacePlatess"] = model.FacePlatess;
                Session["PaperCollars"] = model.PaperCollars;
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveCheckOBA(CheckListOBAModelView model)
        {
            DataTable dtLaserlist = new DataTable("CheckListOBAResults");
            dtLaserlist.Columns.Add("Id");
            dtLaserlist.Columns.Add("SRId");
            dtLaserlist.Columns.Add("CableId");
            dtLaserlist.Columns.Add("PlugId");
            dtLaserlist.Columns.Add("PlugShellId");
            dtLaserlist.Columns.Add("BootId");
            dtLaserlist.Columns.Add("BoottId");
            dtLaserlist.Columns.Add("FacePlateId");
            dtLaserlist.Columns.Add("FaceePlateId");
            dtLaserlist.Columns.Add("CollarId");
            dtLaserlist.Columns.Add("CableSerialNo");
            dtLaserlist.Columns.Add("Remark");
            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.CheckListOBAResults)
                {
                    dtLaserlist.Rows.Add(Uid, row.SRId, row.CableId, row.PlugId, row.PlugShellId, row.BootId, row.BoottId, row.FacePlateId, row.FaceePlateId, row.CollarId,row.CableSerialNo,row.Remark);
                    Uid++;

                }


                //int i = _checkResult.InsertBulkOBACheckList(dtLaserlist, Session["EmpNumber"], model.LineId, model.BoxNo, model.PalletNo, model.ProjectId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.ModelId, model.PartId);
                int i = _checkResult.InsertBulkOBACheckList(dtLaserlist, Session["EmpNumber"].ToString(), model.LineId, model.ProjectId,model.BoxNo, model.PalletNo, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.ModelId, model.PartId);
                    

                //model.dtChecklist = _checkResult.GetFormByQualityAudit(model.LineId, model.ProjectId);

                //model.Statuses = _CheckListCircuitRecord.GetResult();

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("CheckListOBA");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            //  model.dtLaser = _objchecklistResults.InsertLaserResults(model.LineId);

            //model.dtLaser = _checkResult.GetLaserSize(model.LineId,model.ProjectId);

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];

            model.Cables = (List<DOL.Cable>)Session["Cables"];
            model.SRes = (List<DOL.SRS>)Session["SRes"];
            model.PlugShelles = (List<DOL.PlugShellC70>)Session["PlugShelles"];
            model.PlugShells = (List<DOL.PlugShellC91>)Session["PlugShells"];

            model.Boots = (List<DOL.BootC70>)Session["Boots"];
            model.Bootts = (List<DOL.BootC91>)Session["Bootts"];

            model.FacePlates = (List<DOL.FacePlateC70>)Session["FacePlates"];
            model.FacePlatess = (List<DOL.FacePlateC91>)Session["FacePlatess"];
            model.PaperCollars = (List<DOL.PaperCollar>)Session["PaperCollars"];
            
            return View("CheckListOBA", model);
        }

        [HttpGet]
        public ActionResult CheckListCosmetic()
        {
            CheckListCosmeticResultlView model = new CheckListCosmeticResultlView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Shifts"] = model.Shifts;
            return View(model);
        }

        [HttpPost]
        public ActionResult CheckListCosmetic(CheckListCosmeticResultlView model)
        {
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();

            //model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];

            model.dtChecklist = _checkResult.GetFormByCosmetic(model.LineId, model.ProjectId);

            if (!ModelState.IsValid)
                return View(model);
            try
            {
                model.dtChecklist = _checkResult.GetFormByCosmetic(model.LineId, model.ProjectId);
                //model.Lines = _checkResult.GetLine();
                //model.Shifts = _checkResult.GetShift();
                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                model.Projects = (List<DOL.Project>)Session["Projects"];
                model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                //model.Exponents = (List<DOL.Exponent>)Session["Exponents"];
                //model.Statuses = _CheckListCircuitRecord.GetResult();
                Session["Lines"] = model.Lines;
                Session["Shifts"] = model.Shifts;
                Session["ModelNos"] = model.ModelNos;
                Session["PartNos"] = model.PartNos;
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveCheckListCosmetic(CheckListCosmeticResultlView model)
        {
            DataTable dtLaserlist = new DataTable("CheckListCosmeticResults");
            dtLaserlist.Columns.Add("Id");
            dtLaserlist.Columns.Add("DefectId");
            //dtLaserlist.Columns.Add("LocationId");
            //dtLaserlist.Columns.Add("Status");
            //dtLaserlist.Columns.Add("Sampling");
            //dtLaserlist.Columns.Add("Environment");
            //dtLaserlist.Columns.Add("Result");
            dtLaserlist.Columns.Add("Value");
            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.CheckListCosmeticResults)
                {
                    dtLaserlist.Rows.Add(Uid, row.DefectId, row.Value);
                    Uid++;

                }

                int i = _checkResult.InsertBulkCosmeticCheckList(dtLaserlist, Session["EmpNumber"].ToString(), model.LineId, model.ProjectId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.ModelId, model.PartId);

                model.dtChecklist = _checkResult.GetFormByCosmetic(model.LineId, model.ProjectId);

               

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("CheckListCosmetic");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            //  model.dtLaser = _objchecklistResults.InsertLaserResults(model.LineId);

            //model.dtLaser = _checkResult.GetLaserSize(model.LineId,model.ProjectId);

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            //model.Exponents = (List<DOL.Exponent>)Session["Exponents"];

            //model.Statuses = _CheckListCircuitRecord.GetResult();

            return View("CheckListCosmetic", model);
        }

        [HttpGet]
        public ActionResult CheckListCleanIssue()
        {
            CheckListCleanIssueResultlView model = new CheckListCleanIssueResultlView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Shifts"] = model.Shifts;
            return View(model);
        }

        [HttpPost]
        public ActionResult CheckListCleanIssue(CheckListCleanIssueResultlView model)
        {
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();

            //model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];

            model.dtChecklist = _checkResult.GetFormByCleaningIssue(model.LineId, model.ProjectId);

            if (!ModelState.IsValid)
                return View(model);
            try
            {
                model.dtChecklist = _checkResult.GetFormByCleaningIssue(model.LineId, model.ProjectId);
                //model.Lines = _checkResult.GetLine();
                //model.Shifts = _checkResult.GetShift();
                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                model.Projects = (List<DOL.Project>)Session["Projects"];
                model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                //model.Exponents = (List<DOL.Exponent>)Session["Exponents"];
                //model.Statuses = _CheckListCircuitRecord.GetResult();
                Session["Lines"] = model.Lines;
                Session["Shifts"] = model.Shifts;
                Session["ModelNos"] = model.ModelNos;
                Session["PartNos"] = model.PartNos;
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveCheckListCleanIssue(CheckListCleanIssueResultlView model)
        {
            DataTable dtLaserlist = new DataTable("CheckListCleanIssueResults");
            dtLaserlist.Columns.Add("Id");
            dtLaserlist.Columns.Add("StageId");
            dtLaserlist.Columns.Add("Value");
            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.CheckListCleanIssueResults)
                {
                    dtLaserlist.Rows.Add(Uid, row.StageId, row.Value);
                    Uid++;

                }

                int i = _checkResult.InsertCleanIssuechecklist(dtLaserlist, Session["EmpNumber"].ToString(), model.LineId, model.ProjectId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.ModelId, model.PartId);

                model.dtChecklist = _checkResult.GetFormByCleaningIssue(model.LineId, model.ProjectId);



                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("CheckListCleanIssue");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            //  model.dtLaser = _objchecklistResults.InsertLaserResults(model.LineId);

            //model.dtLaser = _checkResult.GetLaserSize(model.LineId,model.ProjectId);

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            //model.Exponents = (List<DOL.Exponent>)Session["Exponents"];

            //model.Statuses = _CheckListCircuitRecord.GetResult();

            return View("CheckListCleanIssue", model);
        }

        [HttpGet]
        public ActionResult CheckListA191FinsihedProduct()
        {
            CheckListA191FinsihedProductResultlView model = new CheckListA191FinsihedProductResultlView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Shifts"] = model.Shifts;
            return View(model);
        }

        [HttpPost]
        public ActionResult CheckListA191FinsihedProduct(CheckListA191FinsihedProductResultlView model)
        {
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();

            //model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];

            model.dtChecklist = _checkResult.GetFormByA191FinsihedProduct(model.LineId, model.ProjectId);

            if (!ModelState.IsValid)
                return View(model);
            try
            {
                model.dtChecklist = _checkResult.GetFormByA191FinsihedProduct(model.LineId, model.ProjectId);
                //model.Lines = _checkResult.GetLine();
                //model.Shifts = _checkResult.GetShift();
                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                model.Projects = (List<DOL.Project>)Session["Projects"];
                model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                //model.Exponents = (List<DOL.Exponent>)Session["Exponents"];
                //model.Statuses = _CheckListCircuitRecord.GetResult();
                Session["Lines"] = model.Lines;
                Session["Shifts"] = model.Shifts;
                Session["ModelNos"] = model.ModelNos;
                Session["PartNos"] = model.PartNos;
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveCheckListA191FinsihedProduct(CheckListA191FinsihedProductResultlView model)
        {
            DataTable dtLaserlist = new DataTable("CheckListA191FinsihedProductResults");
            dtLaserlist.Columns.Add("Id");
            dtLaserlist.Columns.Add("InspectId");
            dtLaserlist.Columns.Add("Result");
            dtLaserlist.Columns.Add("Remarks");
            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.CheckListA191FinsihedProductResults)
                {
                    dtLaserlist.Rows.Add(Uid, row.InspectId, row.Result, row.Remarks);
                    Uid++;

                }

                int i = _checkResult.InsertBulkCheckListA191FinsihedProduct(dtLaserlist, Session["EmpNumber"].ToString(), model.LineId, model.ProjectId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.ModelId, model.PartId);

                model.dtChecklist = _checkResult.GetFormByA191FinsihedProduct(model.LineId, model.ProjectId);



                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("CheckListA191FinsihedProduct");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            //  model.dtLaser = _objchecklistResults.InsertLaserResults(model.LineId);

            //model.dtLaser = _checkResult.GetLaserSize(model.LineId,model.ProjectId);

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            //model.Exponents = (List<DOL.Exponent>)Session["Exponents"];

            //model.Statuses = _CheckListCircuitRecord.GetResult();

            return View("CheckListA191FinsihedProduct", model);
        }
        [HttpGet]
        public ActionResult CheckListOQCBoxConformation()
        {
            CheckListOQCBoxConformationResultlView model = new CheckListOQCBoxConformationResultlView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            //model.Projects = _CheckListCircuitRecord.GetProject();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            //Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Shifts"] = model.Shifts;
            return View(model);
        }

        [HttpPost]
        public ActionResult CheckListOQCBoxConformation(CheckListOQCBoxConformationResultlView model)
        {
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            //model.Projects = _CheckListCircuitRecord.GetProject();

            //model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            //model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];

            //model.dtChecklist = _checkResult.GetFormByA191FinsihedProduct(model.LineId, model.ProjectId);

            if (!ModelState.IsValid)
                return View(model);
            try
            {
                //model.dtChecklist = _checkResult.GetFormByA191FinsihedProduct(model.LineId, model.ProjectId);
                //model.Lines = _checkResult.GetLine();
                //model.Shifts = _checkResult.GetShift();
                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                //model.Projects = (List<DOL.Project>)Session["Projects"];
                model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                //model.Exponents = (List<DOL.Exponent>)Session["Exponents"];
                //model.Statuses = _CheckListCircuitRecord.GetResult();
                Session["Lines"] = model.Lines;
                Session["Shifts"] = model.Shifts;
                Session["ModelNos"] = model.ModelNos;
                Session["PartNos"] = model.PartNos;
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveCheckListOQCBoxConformation(CheckListOQCBoxConformationResultlView model)
        {
            DataTable dtLaserlist = new DataTable("CheckListOQCBoxConformationResults");
            dtLaserlist.Columns.Add("Id");
            dtLaserlist.Columns.Add("WorkOrder");
            dtLaserlist.Columns.Add("CartonBoxNumber");
            dtLaserlist.Columns.Add("NgQty");
            dtLaserlist.Columns.Add("DefectNg");
            dtLaserlist.Columns.Add("QcStatus");
            //dtLaserlist.Columns.Add("NgQty");
            dtLaserlist.Columns.Add("Prodll");
            dtLaserlist.Columns.Add("qcll");
            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.CheckListOQCBoxConformationResults)
                {
                    dtLaserlist.Rows.Add(Uid, row.WorkOrder, row.CartonBoxNumber, row.NgQty, row.DefectNg, row.QcStatus, row.Prodll, row.qcll);
                    Uid++;

                }

                int i = _checkResult.InsertBulkCheckListOQCBoxConformation(dtLaserlist, Session["EmpNumber"].ToString(), model.LineId,model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.ModelId, model.PartId);

                //model.dtChecklist = _checkResult.GetFormByA191FinsihedProduct(model.LineId, model.ProjectId);



                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("CheckListOQCBoxConformation");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            //  model.dtLaser = _objchecklistResults.InsertLaserResults(model.LineId);

            //model.dtLaser = _checkResult.GetLaserSize(model.LineId,model.ProjectId);

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            //model.Exponents = (List<DOL.Exponent>)Session["Exponents"];

            //model.Statuses = _CheckListCircuitRecord.GetResult();

            return View("CheckListOQCBoxConformation", model);
        }

        [HttpGet]
        public ActionResult CheckListFunctionalOOBTracking()
        
{
            CheckListFunctionalOOBTrackingResultlView model = new CheckListFunctionalOOBTrackingResultlView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            //model.Types =_checkResult.GetInspectionType();
            //model.Projects = _CheckListCircuitRecord.GetProject();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            //Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Shifts"] = model.Shifts;
            //Session["Types"]=model.Types;
            return View(model);
        }

        [HttpPost]
        public ActionResult CheckListFunctionalOOBTracking(CheckListFunctionalOOBTrackingResultlView model)
        {
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
           model.Types =_checkResult.GetInspectionType();
            //model.Projects = _CheckListCircuitRecord.GetProject();

            //model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
             //model.Types = (List<InspectionType>)Session["Types"];
            //model.Projects = (List<DOL.Project>)Session["Projects"];
            //model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            //model.PartNos = (List<DOL.PartNo>)Session["PartNos"];

            //model.dtChecklist = _checkResult.GetFormByA191FinsihedProduct(model.LineId, model.ProjectId);

            if (!ModelState.IsValid)
                return View(model);
            try
            {
                //model.dtChecklist = _checkResult.GetFormByA191FinsihedProduct(model.LineId, model.ProjectId);
                //model.Lines = _checkResult.GetLine();
                //model.Shifts = _checkResult.GetShift();
                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                //model.Types =_checkResult.GetInspectionType();
                //model.Projects = (List<DOL.Project>)Session["Projects"];
                //model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                //model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                //model.Exponents = (List<DOL.Exponent>)Session["Exponents"];
                //model.Statuses = _CheckListCircuitRecord.GetResult();
                Session["Lines"] = model.Lines;
                Session["Shifts"] = model.Shifts;
                //Session["ModelNos"] = model.ModelNos;
                //Session["PartNos"] = model.PartNos;
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveCheckListFunctionalOOBTracking(CheckListFunctionalOOBTrackingResultlView model)
        {
            DataTable dtLaserlist = new DataTable("CheckListFunctionalOOBTrackingResults");
            dtLaserlist.Columns.Add("Id");
            dtLaserlist.Columns.Add("WorkOrder");
            dtLaserlist.Columns.Add("CableSNo");
            dtLaserlist.Columns.Add("CartonBoxNumber");
            dtLaserlist.Columns.Add("NgQty");
            dtLaserlist.Columns.Add("DefectDescription");
            dtLaserlist.Columns.Add("Inpection");
            //dtLaserlist.Columns.Add("qcll");
            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.CheckListFunctionalOOBTrackingResults)
                {
                    dtLaserlist.Rows.Add(Uid, row.WorkOrder, row.CableSNo, row.CartonBoxNumber, row.NgQty, row.DefectDescription, row.Inpection);
                    Uid++;

                }

                int i = _checkResult.InsertBulkCheckListFunctionalOOBTracking(dtLaserlist, Session["EmpNumber"].ToString(), model.LineId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.Prodll, model.qcll);

                //model.dtChecklist = _checkResult.GetFormByA191FinsihedProduct(model.LineId, model.ProjectId);



                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("CheckListFunctionalOOBTracking");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            //  model.dtLaser = _objchecklistResults.InsertLaserResults(model.LineId);

            //model.dtLaser = _checkResult.GetLaserSize(model.LineId,model.ProjectId);

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            //model.Types = (List<DOL.InspectionType>)Session["Types"];
            //model.Exponents = (List<DOL.Exponent>)Session["Exponents"];

            //model.Statuses = _CheckListCircuitRecord.GetResult();

            return View("CheckListFunctionalOOBTracking", model);
        }

        [HttpGet]
        public ActionResult CheckListAppTestFailure()
        {
            CheckListAppTestFailureResultlModelView model = new CheckListAppTestFailureResultlModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            //model.Projects = _CheckListCircuitRecord.GetProject();
            //model.ModelNos = new List<DOL.ModelNo>();
            //model.PartNos = new List<DOL.PartNo>();
            //Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Shifts"] = model.Shifts;
            return View(model);
        }

        [HttpPost]
        public ActionResult CheckListAppTestFailure(CheckListAppTestFailureResultlModelView model)
        {
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            //model.Projects = _CheckListCircuitRecord.GetProject();

            //model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            //model.Projects = (List<DOL.Project>)Session["Projects"];
            //model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            //model.PartNos = (List<DOL.PartNo>)Session["PartNos"];

            //model.dtChecklist = _checkResult.GetFormByA191FinsihedProduct(model.LineId, model.ProjectId);

            if (!ModelState.IsValid)
                return View(model);
            try
            {
                //model.dtChecklist = _checkResult.GetFormByA191FinsihedProduct(model.LineId, model.ProjectId);
                //model.Lines = _checkResult.GetLine();
                //model.Shifts = _checkResult.GetShift();
                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                //model.Projects = (List<DOL.Project>)Session["Projects"];
                //model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                //model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                //model.Exponents = (List<DOL.Exponent>)Session["Exponents"];
                //model.Statuses = _CheckListCircuitRecord.GetResult();
                Session["Lines"] = model.Lines;
                Session["Shifts"] = model.Shifts;
                //Session["ModelNos"] = model.ModelNos;
                //Session["PartNos"] = model.PartNos;
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveCheckListAppTestFailure(CheckListAppTestFailureResultlModelView model)
        {
            DataTable dtLaserlist = new DataTable("CheckListAppTestFailureResults");
            dtLaserlist.Columns.Add("Id");
            dtLaserlist.Columns.Add("Quantity");
            dtLaserlist.Columns.Add("DefectRate");
            dtLaserlist.Columns.Add("Reason");
            dtLaserlist.Columns.Add("Status");
            dtLaserlist.Columns.Add("Remark");
            //dtLaserlist.Columns.Add("Prodll");
            //dtLaserlist.Columns.Add("qcll");
            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.CheckListAppTestFailureResults)
                {
                    dtLaserlist.Rows.Add(Uid, row.Quantity, row.DefectRate, row.Reason, row.Status, row.Remark);
                    Uid++;

                }

                int i = _checkResult.InsertBulkCheckListAppTestFailure(dtLaserlist, Session["EmpNumber"].ToString(), model.LineId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy);

                //model.dtChecklist = _checkResult.GetFormByA191FinsihedProduct(model.LineId, model.ProjectId);



                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("CheckListAppTestFailure");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            //  model.dtLaser = _objchecklistResults.InsertLaserResults(model.LineId);

            //model.dtLaser = _checkResult.GetLaserSize(model.LineId,model.ProjectId);

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            //model.Projects = (List<DOL.Project>)Session["Projects"];
            //model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            //model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            //model.Exponents = (List<DOL.Exponent>)Session["Exponents"];

            //model.Statuses = _CheckListCircuitRecord.GetResult();

            return View("CheckListAppTestFailure", model);
        }


        [HttpGet]
        public ActionResult CheckListCartonBoxList()
        {
            CheckListCartonBoxListResultModelView model = new CheckListCartonBoxListResultModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            //model.Projects = _CheckListCircuitRecord.GetProject();
            //model.ModelNos = new List<DOL.ModelNo>();
            //model.PartNos = new List<DOL.PartNo>();
            //Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Shifts"] = model.Shifts;
            return View(model);
        }

        [HttpPost]
        public ActionResult CheckListCartonBoxList(CheckListCartonBoxListResultModelView model)
        {
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            //model.Projects = _CheckListCircuitRecord.GetProject();

            //model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            //model.Projects = (List<DOL.Project>)Session["Projects"];
            //model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            //model.PartNos = (List<DOL.PartNo>)Session["PartNos"];

            //model.dtChecklist = _checkResult.GetFormByA191FinsihedProduct(model.LineId, model.ProjectId);

            if (!ModelState.IsValid)
                return View(model);
            try
            {
                //model.dtChecklist = _checkResult.GetFormByA191FinsihedProduct(model.LineId, model.ProjectId);
                //model.Lines = _checkResult.GetLine();
                //model.Shifts = _checkResult.GetShift();
                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                //model.Projects = (List<DOL.Project>)Session["Projects"];
                //model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                //model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                //model.Exponents = (List<DOL.Exponent>)Session["Exponents"];
                //model.Statuses = _CheckListCircuitRecord.GetResult();
                Session["Lines"] = model.Lines;
                Session["Shifts"] = model.Shifts;
                //Session["ModelNos"] = model.ModelNos;
                //Session["PartNos"] = model.PartNos;
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveCheckListCartonBoxList(CheckListCartonBoxListResultModelView model)
        {
            DataTable dtLaserlist = new DataTable("CheckListCartonBoxListResults");
            dtLaserlist.Columns.Add("Id");
            dtLaserlist.Columns.Add("CartonNumber");
            dtLaserlist.Columns.Add("WorkOrder");
            dtLaserlist.Columns.Add("Status");
            dtLaserlist.Columns.Add("Remarks");
            dtLaserlist.Columns.Add("PackingSide");
            //dtLaserlist.Columns.Add("Prodll");
            //dtLaserlist.Columns.Add("qcll");
            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.CheckListCartonBoxListResults)
                {
                    dtLaserlist.Rows.Add(Uid, row.CartonNumber, row.WorkOrder, row.Status, row.Remarks, row.PackingSide);
                    Uid++;

                }

                int i = _checkResult.InsertBulkCheckListCartonBoxList(dtLaserlist, Session["EmpNumber"].ToString(), model.LineId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy);

                //model.dtChecklist = _checkResult.GetFormByA191FinsihedProduct(model.LineId, model.ProjectId);



                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("CheckListCartonBoxList");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            //  model.dtLaser = _objchecklistResults.InsertLaserResults(model.LineId);

            //model.dtLaser = _checkResult.GetLaserSize(model.LineId,model.ProjectId);

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            //model.Projects = (List<DOL.Project>)Session["Projects"];
            //model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            //model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            //model.Exponents = (List<DOL.Exponent>)Session["Exponents"];

            //model.Statuses = _CheckListCircuitRecord.GetResult();

            return View("CheckListCartonBoxList", model);
        }


        [HttpGet]
        public ActionResult CheckListTempratureRecord()
        {
            CheckListTemperatureRecordResulttModelView model = new CheckListTemperatureRecordResulttModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            //model.Projects = _CheckListCircuitRecord.GetProject();
            //model.ModelNos = new List<DOL.ModelNo>();
            //model.PartNos = new List<DOL.PartNo>();
            //Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Shifts"] = model.Shifts;
            return View(model);
        }

        [HttpPost]
        public ActionResult CheckListTempratureRecord(CheckListTemperatureRecordResulttModelView model)
        {
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            //model.Projects = _CheckListCircuitRecord.GetProject();

            //model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            //model.Projects = (List<DOL.Project>)Session["Projects"];
            //model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            //model.PartNos = (List<DOL.PartNo>)Session["PartNos"];

            model.dtChecklist = _checkResult.GetFormByTemperatureRecord(model.LineId);

            if (!ModelState.IsValid)
                return View(model);
            try
            {
                //model.dtChecklist = _checkResult.GetFormByA191FinsihedProduct(model.LineId, model.ProjectId);
                model.dtChecklist = _checkResult.GetFormByTemperatureRecord(model.LineId);
                //model.Lines = _checkResult.GetLine();
                //model.Shifts = _checkResult.GetShift();
                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                //model.Projects = (List<DOL.Project>)Session["Projects"];
                //model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                //model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                //model.Exponents = (List<DOL.Exponent>)Session["Exponents"];
                //model.Statuses = _CheckListCircuitRecord.GetResult();
                Session["Lines"] = model.Lines;
                Session["Shifts"] = model.Shifts;
                //Session["ModelNos"] = model.ModelNos;
                //Session["PartNos"] = model.PartNos;
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveCheckListTempratureRecord(CheckListTemperatureRecordResulttModelView model)
        {
            DataTable dtLaserlist = new DataTable("CheckListTemperatureRecordResults");
            dtLaserlist.Columns.Add("Id");
            dtLaserlist.Columns.Add("TempId");
            dtLaserlist.Columns.Add("ActualValue");
            //dtLaserlist.Columns.Add("Reason");
            //dtLaserlist.Columns.Add("Status");
            //dtLaserlist.Columns.Add("Remark");
            //dtLaserlist.Columns.Add("Prodll");
            //dtLaserlist.Columns.Add("qcll");
            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.CheckListTemperatureRecordResults)
                {
                    dtLaserlist.Rows.Add(Uid, row.TempId, row.ActualValue);
                    Uid++;

                }

                int i = _checkResult.InsertBulkTemperatureRecordCheckList(dtLaserlist, Session["EmpNumber"].ToString(), model.LineId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.EquipmentSNo);

                //model.dtChecklist = _checkResult.GetFormByA191FinsihedProduct(model.LineId, model.ProjectId);



                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("CheckListTempratureRecord");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            //  model.dtLaser = _objchecklistResults.InsertLaserResults(model.LineId);

            model.dtChecklist = _checkResult.GetFormByTemperatureRecord(model.LineId);

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            //model.Projects = (List<DOL.Project>)Session["Projects"];
            //model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            //model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            //model.Exponents = (List<DOL.Exponent>)Session["Exponents"];

            //model.Statuses = _CheckListCircuitRecord.GetResult();

            return View("CheckListTempratureRecord", model);
        }


        [HttpGet]
        public ActionResult CheckListHumidityRecord()
        {
            CheckListHumidityRecordResultModelView model = new CheckListHumidityRecordResultModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            //model.Projects = _CheckListCircuitRecord.GetProject();
            //model.ModelNos = new List<DOL.ModelNo>();
            //model.PartNos = new List<DOL.PartNo>();
            //Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Shifts"] = model.Shifts;
            return View(model);
        }

        [HttpPost]
        public ActionResult CheckListHumidityRecord(CheckListHumidityRecordResultModelView model)
        {
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            //model.Projects = _CheckListCircuitRecord.GetProject();

            //model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            //model.Projects = (List<DOL.Project>)Session["Projects"];
            //model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            //model.PartNos = (List<DOL.PartNo>)Session["PartNos"];

            model.dtChecklist = _checkResult.GetFormByHumidityRecord(model.LineId);

            if (!ModelState.IsValid)
                return View(model);
            try
            {
                //model.dtChecklist = _checkResult.GetFormByA191FinsihedProduct(model.LineId, model.ProjectId);
                model.dtChecklist = _checkResult.GetFormByHumidityRecord(model.LineId);
                //model.Lines = _checkResult.GetLine();
                //model.Shifts = _checkResult.GetShift();
                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                //model.Projects = (List<DOL.Project>)Session["Projects"];
                //model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                //model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                //model.Exponents = (List<DOL.Exponent>)Session["Exponents"];
                //model.Statuses = _CheckListCircuitRecord.GetResult();
                Session["Lines"] = model.Lines;
                Session["Shifts"] = model.Shifts;
                //Session["ModelNos"] = model.ModelNos;
                //Session["PartNos"] = model.PartNos;
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveCheckListHumidityRecord(CheckListHumidityRecordResultModelView model)
        {
            DataTable dtLaserlist = new DataTable("CheckListHumidityRecordResults");
            dtLaserlist.Columns.Add("Id");
            dtLaserlist.Columns.Add("HumidityId");
            dtLaserlist.Columns.Add("ActualValue");
            //dtLaserlist.Columns.Add("Reason");
            //dtLaserlist.Columns.Add("Status");
            //dtLaserlist.Columns.Add("Remark");
            //dtLaserlist.Columns.Add("Prodll");
            //dtLaserlist.Columns.Add("qcll");
            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.CheckListHumidityRecordResults)
                {
                    dtLaserlist.Rows.Add(Uid, row.HumidityId, row.ActualValue);
                    Uid++;

                }

                int i = _checkResult.InsertBulkHumidityRecordCheckList(dtLaserlist, Session["EmpNumber"].ToString(), model.LineId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.EquipmentSNo);

                //model.dtChecklist = _checkResult.GetFormByA191FinsihedProduct(model.LineId, model.ProjectId);



                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("CheckListHumidityRecord");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            //  model.dtLaser = _objchecklistResults.InsertLaserResults(model.LineId);

            model.dtChecklist = _checkResult.GetFormByHumidityRecord(model.LineId);

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            //model.Projects = (List<DOL.Project>)Session["Projects"];
            //model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            //model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            //model.Exponents = (List<DOL.Exponent>)Session["Exponents"];

            //model.Statuses = _CheckListCircuitRecord.GetResult();

            return View("CheckListHumidityRecord", model);
        }

        [HttpGet]
        public ActionResult CheckListFirstArticleInspec()
        {
            CheckListFirstArticleInspectViewModel model = new CheckListFirstArticleInspectViewModel();

            model.dtChecklist = new DataTable();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            //model.SRSS = new List<DOL.SRS>();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            //Session["Exponents"] = model.Exponents;
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Shifts"] = model.Shifts;
            //Session["SRS"] = model.SRSS;
            return View(model);
        }

        [HttpPost]
        public ActionResult CheckListFirstArticleInspec(CheckListFirstArticleInspectViewModel model)
        {
            model.dtChecklist = _checkFirstArticle.GetFormByFirstAirticleInspec2(model.LineId, model.ProjectId);

            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            //model.Exponents = _CheckListCircuitRecord.GetExponent();
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            //model.SRSS = (List<SRS>)Session["SRes"];
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                model.dtChecklist = _checkFirstArticle.GetFormByFirstAirticleInspec2(model.LineId, model.ProjectId);

                model.Lines = (List<Line>)Session["Lines"];

                model.Projects = (List<DOL.Project>)Session["Projects"];
                //model.SRSS = (List<SRS>)Session["SRes"];
                Session["Lines"] = model.Lines;
                Session["Projects"] = model.Projects;
                Session["ModelNos"] = model.ModelNos;
                Session["PartNos"] = model.PartNos;
                //Session["SRes"] = model.SRSS;
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveFirstArticleInspec(CheckListFirstArticleInspectViewModel model)
        {
            DataTable dtLaserlist = new DataTable("CheckListFirstArticleInspecs");
            dtLaserlist.Columns.Add("Id");
            dtLaserlist.Columns.Add("SpecId");
            dtLaserlist.Columns.Add("Check1");
            dtLaserlist.Columns.Add("Check2");
            dtLaserlist.Columns.Add("Check3");
            dtLaserlist.Columns.Add("Check4");
            dtLaserlist.Columns.Add("Check5");
            dtLaserlist.Columns.Add("SerialNo1");
            dtLaserlist.Columns.Add("SerialNo2");
            dtLaserlist.Columns.Add("SerialNo3");
            dtLaserlist.Columns.Add("SerialNo4");
            dtLaserlist.Columns.Add("SerialNo5");
            try
            {

                int Uid = 1;

                foreach (var row in model.CheckListFirstArticleInspecs)
                {

                    //dtLaserlist.Rows.Add(Uid, row.SpecId, row.Check1, row.Check2, row.Check3, row.Check4, row.Check5);


                    dtLaserlist.Rows.Add(Uid, row.SpecId, row.Check1, row.Check2, row.Check3, row.Check4, row.Check5,row.SerialNo1,row.SerialNo2,row.SerialNo3,row.SerialNo4,row.SerialNo5);
                    Uid++;

                }


                int i = _checkFirstArticle.InsertBulkFirstAirticleSpecCheckList2(dtLaserlist, Session["EmpNumber"].ToString(), model.LineId, model.ProjectId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.ModelId, model.PartId, model.ProductName, model.WorkOrder, model.DrawingVersion, model.PackVersion, model.SamplingQty);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("CheckListFirstArticleInspec");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }


            //try
            //{


            //    int i = _checkFirstArticle.InsertBulkFirstAirticleInspectionCheckList2(dtLaserlist2, Session["EmpNumber"].ToString(), model.LineId, model.ProjectId, model.ModelId, model.PartId);

            //    if (i > 0)
            //    {
            //        TempData["mgs"] = "Sucess";
            //        TempData["Alert"] = "Sucessfully Results Saved!!!";
            //        return RedirectToAction("CheckListFirstArticleInspection");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("ERROR", "Already Existed !!!");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ModelState.AddModelError("ERROR", ex.Message);
            //    //Log.Error("Error", ex);
            //}

            model.dtChecklist = _checkFirstArticle.GetFormByFirstArticleInspection(model.LineId, model.ProjectId);

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            model.SRSS = (List<DOL.SRS>)Session["SRes"];


            //model2.Lines = (List<Line>)Session["Lines"];
            //model2.Shifts = (List<Shift>)Session["Shifts"];
            //model2.Projects = (List<DOL.Project>)Session["Projects"];
            //model2.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            //model2.PartNos = (List<DOL.PartNo>)Session["PartNos"];

            return View("CheckListFirstArticleInspec", model);
        }


        //[HttpPost]

        //public ActionResult UploadDocument(CheckListAuditCheckPointsModelview model, HttpPostedFileBase file)
        //{
        //    model.dtChecklist = new DataTable();
        //    if (!ModelState.IsValid)
        //        return View(model);

        //    //DOL.AuditCheckPoint AuditObj = new DOL.AuditCheckPoint();

        //    MemoryStream target = new MemoryStream();
        //    file.InputStream.CopyTo(target);
        //    byte[] data = target.ToArray();
        //    String profilePic = Convert.ToBase64String(data);
        //    profilePic = "data:image/jpeg;base64," + profilePic;

        //    model.Image = profilePic;

        //    Session["Image"] = model.Image;

        //    return View(model);

        //}

        //[HttpPost]

        //public ActionResult UploadDocument(CheckListQualityAuditModelView model, HttpPostedFileBase file)
        //{
        //    model.dtChecklist = new DataTable();
        //    if (!ModelState.IsValid)
        //        return View(model);

        //    //DOL.AuditCheckPoint AuditObj = new DOL.AuditCheckPoint();

        //    MemoryStream target = new MemoryStream();
        //    file.InputStream.CopyTo(target);
        //    byte[] data = target.ToArray();
        //    String profilePic = Convert.ToBase64String(data);
        //    profilePic = "data:image/jpeg;base64," + profilePic;

        //    model.Image = profilePic;

        //    Session["Image"] = model.Image;

        //    return View(model);

        //}

        #region --> Post Method For PartNo
        [HttpPost]
        public ActionResult GetPartNoByModel(int ModelId)
        {
            string PlantCode = string.Empty;

            List<DOL.PartNo> PeriodList = new List<DOL.PartNo>();

            DataTable dt = _objProject.GetPartNoByModel(ModelId);

            PeriodList = dt.DataTableToList<DOL.PartNo>();

            string retStr = string.Empty;

            Session["PartNos"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region --> Post Method For ModelNo
        [HttpPost]
        public ActionResult GetModelNoByProject(int ProjectId)
        {
            string PlantCode = string.Empty;

            List<DOL.ModelNo> PeriodList = new List<DOL.ModelNo>();

            DataTable dt = _objProject.GetModelNoByProject(ProjectId);

            PeriodList = dt.DataTableToList<DOL.ModelNo>();

            string retStr = string.Empty;

            Session["ModelNos"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region --> Post Method For Adhesive
        [HttpPost]
        public ActionResult GetAdhesiveByProject(int ProjectId)
        {
            string PlantCode = string.Empty;

            List<DOL.Adhesivee> PeriodList = new List<DOL.Adhesivee>();

            DataTable dt = _objProject.GetAdhesiveByProject(ProjectId);

            PeriodList = dt.DataTableToList<DOL.Adhesivee>();

            string retStr = string.Empty;

            Session["Adhesives"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region --> Post Method For Temperature Range
        [HttpPost]
        public ActionResult GetTemparatureRangeByProject(int ProjectId)
        {
            string PlantCode = string.Empty;

            List<DOL.TempRange> PeriodList = new List<DOL.TempRange>();

            DataTable dt = _objProject.GetTemparatureRangeByProject(ProjectId);

            PeriodList = dt.DataTableToList<DOL.TempRange>();

            string retStr = string.Empty;

            Session["Ranges"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region --> Post Method For Exponents
        [HttpPost]
        public ActionResult GetExponentsByProject(int ProjectId)
        {
            string PlantCode = string.Empty;

            List<DOL.Exponent> PeriodList = new List<DOL.Exponent>();

            DataTable dt = _objProject.GetExponentsByProject(ProjectId);

            PeriodList = dt.DataTableToList<DOL.Exponent>();

            string retStr = string.Empty;

            Session["Exponents"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region --> Post Method For InspectorCategory
        [HttpPost]
        public ActionResult GetInspectorcategoryByProject(int ProjectId)
        {
            string PlantCode = string.Empty;

            List<DOL.InspectorCategory> PeriodList = new List<DOL.InspectorCategory>();

            DataTable dt = _objProject.GetInspectorcategoryByProject(ProjectId);

            PeriodList = dt.DataTableToList<DOL.InspectorCategory>();

            string retStr = string.Empty;

            Session["Categories"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region --> Post Method For InspectorCategory2
        [HttpPost]
        public ActionResult GetInspectorsByProject(int ProjectId)
        {
            string PlantCode = string.Empty;

            List<DOL.InspectorSS> PeriodList = new List<DOL.InspectorSS>();

            DataTable dt = _objProject.GetInspectorsByProject(ProjectId);

            PeriodList = dt.DataTableToList<DOL.InspectorSS>();

            string retStr = string.Empty;

            Session["Inspectss"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion


        #region --> Post Method For PaperCollar

        [HttpPost]
        public ActionResult GetPaperCollarByProject(int ProjectId)
        {
            string PlantCode = string.Empty;

            List<DOL.PaperCollar> PeriodList = new List<DOL.PaperCollar>();

            DataTable dt = _objProject.GetPaperCollarByProject(ProjectId);

            PeriodList = dt.DataTableToList<DOL.PaperCollar>();

            string retStr = string.Empty;

            Session["PaperCollars"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion


        

        #region --> Post Method For FacePlateC70

        [HttpPost]
        public ActionResult GetFacePlateC70ByProject(int ProjectId)
        {
            string PlantCode = string.Empty;

            List<DOL.FacePlateC70> PeriodList = new List<DOL.FacePlateC70>();

            DataTable dt = _objProject.GetFacePlateC70ByProject(ProjectId);

            PeriodList = dt.DataTableToList<DOL.FacePlateC70>();

            string retStr = string.Empty;

            Session["FacePlates"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion


        #region --> Post Method For FacePlateC91

        [HttpPost]
        public ActionResult GetFacePlateC91ByProject(int ProjectId)
        {
            string PlantCode = string.Empty;

            List<DOL.FacePlateC91> PeriodList = new List<DOL.FacePlateC91>();

            DataTable dt = _objProject.GetFacePlateC91ByProject(ProjectId);

            PeriodList = dt.DataTableToList<DOL.FacePlateC91>();

            string retStr = string.Empty;

            Session["FacePlatess"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region --> Post Method For BootC70

        [HttpPost]
        public ActionResult GetBootC70ByProject(int ProjectId)
        {
            string PlantCode = string.Empty;

            List<DOL.BootC70> PeriodList = new List<DOL.BootC70>();

            DataTable dt = _objProject.GetBootC70ByProject(ProjectId);

            PeriodList = dt.DataTableToList<DOL.BootC70>();

            string retStr = string.Empty;

            Session["Boots"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion


        #region --> Post Method For BootC91

        [HttpPost]
        public ActionResult GetBootC91ByProject(int ProjectId)
        {
            string PlantCode = string.Empty;

            List<DOL.BootC91> PeriodList = new List<DOL.BootC91>();

            DataTable dt = _objProject.GetBootC91ByProject(ProjectId);

            PeriodList = dt.DataTableToList<DOL.BootC91>();

            string retStr = string.Empty;

            Session["Bootts"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region --> Post Method For PlugShellC70

        [HttpPost]
        public ActionResult GetPlugShellC70ByProject(int ProjectId)
        {
            string PlantCode = string.Empty;

            List<DOL.PlugShellC70> PeriodList = new List<DOL.PlugShellC70>();

            DataTable dt = _objProject.GetPlugShellC70ByProject(ProjectId);

            PeriodList = dt.DataTableToList<DOL.PlugShellC70>();

            string retStr = string.Empty;

            Session["PlugShelles"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion


        #region --> Post Method For PlugShellC91

        [HttpPost]
        public ActionResult GetPlugShellC91ByProject(int ProjectId)
        {
            string PlantCode = string.Empty;

            List<DOL.PlugShellC91> PeriodList = new List<DOL.PlugShellC91>();

            DataTable dt = _objProject.GetPlugShellC91ByProject(ProjectId);

            PeriodList = dt.DataTableToList<DOL.PlugShellC91>();

            string retStr = string.Empty;

            Session["PlugShells"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion


        //#region --> Post Method For SR

        //[HttpPost]
        //public ActionResult GetSRByProject(int ProjectId)
        //{
        //    string PlantCode = string.Empty;

        //    List<DOL.SRS> PeriodList = new List<DOL.SRS>();

        //    DataTable dt = _objProject.GetPlugShellC91ByProject(ProjectId);

        //    PeriodList = dt.DataTableToList<DOL.SRS>();

        //    string retStr = string.Empty;

        //    Session["Plugss"] = PeriodList;

        //    retStr = _cont.ConvertToJson(dt);

        //    return Json(retStr, JsonRequestBehavior.AllowGet);
        //}

        //#endregion

        #region --> Post Method For SR

        [HttpPost]
        public ActionResult GetSRByProject(int ProjectId)
        {
            string PlantCode = string.Empty;

            List<DOL.SRS> PeriodList = new List<DOL.SRS>();

            DataTable dt = _objProject.GetSRByProject(ProjectId);

            PeriodList = dt.DataTableToList<DOL.SRS>();

            string retStr = string.Empty;

            Session["SRes"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion


        #region --> Post Method For Cables

        [HttpPost]
        public ActionResult GetCableByProject(int ProjectId)
        {
            string PlantCode = string.Empty;

            List<DOL.Cable> PeriodList = new List<DOL.Cable>();

            DataTable dt = _objProject.GetCableByProject(ProjectId);

            PeriodList = dt.DataTableToList<DOL.Cable>();

            string retStr = string.Empty;

            Session["Cables"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion


        //#region --> Post Method For FacePlateC91

        //[HttpPost]
        //public ActionResult GetFacePlateC91ByProject(int ProjectId)
        //{
        //    string PlantCode = string.Empty;

        //    List<DOL.FacePlateC91> PeriodList = new List<DOL.FacePlateC91>();

        //    DataTable dt = _objProject.GetFacePlateC91ByProject(ProjectId);

        //    PeriodList = dt.DataTableToList<DOL.FacePlateC91>();

        //    string retStr = string.Empty;

        //    Session["Plugss"] = PeriodList;

        //    retStr = _cont.ConvertToJson(dt);

        //    return Json(retStr, JsonRequestBehavior.AllowGet);
        //}

        //#endregion


        //#region --> Post Method For FacePlateC70

        //[HttpPost]
        //public ActionResult GetFacePlateC70ByProject(int ProjectId)
        //{
        //    string PlantCode = string.Empty;

        //    List<DOL.FacePlateC70> PeriodList = new List<DOL.FacePlateC70>();

        //    DataTable dt = _objProject.GetFacePlateC70ByProject(ProjectId);

        //    PeriodList = dt.DataTableToList<DOL.FacePlateC70>();

        //    string retStr = string.Empty;

        //    Session["Plates"] = PeriodList;

        //    retStr = _cont.ConvertToJson(dt);

        //    return Json(retStr, JsonRequestBehavior.AllowGet);
        //}

        //#endregion

        //#region --> Post Method For FacePlateC70
        //[HttpPost]
        //public ActionResult GetFacePlateC70ByProject(int ProjectId)
        //{
        //    string PlantCode = string.Empty;

        //    List<DOL.FacePlateC70> PeriodList = new List<DOL.FacePlateC70>();

        //    DataTable dt = _objProject.GetInspectorcategoryByProject(ProjectId);

        //    PeriodList = dt.DataTableToList<DOL.FacePlateC70>();

        //    string retStr = string.Empty;

        //    Session["Plates"] = PeriodList;

        //    retStr = _cont.ConvertToJson(dt);

        //    return Json(retStr, JsonRequestBehavior.AllowGet);
        //}

        //#endregion


        [HttpGet]
        public ActionResult ChecklistProcessTourData()
        {
            CheckListProcessTourDataModelView model = new CheckListProcessTourDataModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            
            return View(model);
        }

        [HttpPost]
        public ActionResult ChecklistProcessTourData(CheckListProcessTourDataModelView model)
        {
            model.dtChecklist = _checkResult.GetFromByProcessTourData(model.LineId, model.ProjectId,model.VisualsId);
            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            Session["Lines"] = model.Lines;
            Session["Shifts"] = model.Shifts;
            
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                model.dtChecklist = _checkResult.GetFromByProcessTourData(model.LineId, model.ProjectId, model.VisualsId);
                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                model.Projects = (List<DOL.Project>)Session["Projects"];
                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model);

            //return RedirectToAction("ChecklistResults");
        }

        [HttpPost]
        public ActionResult SaveChecklistProcessTourData(CheckListProcessTourDataModelView model)
        {
            DataTable dtChecklist = new DataTable("CheckListProcessTourDataResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("DataId");
            dtChecklist.Columns.Add("Section1");
            dtChecklist.Columns.Add("Section2");
            dtChecklist.Columns.Add("Section3");
            dtChecklist.Columns.Add("Section4");
            dtChecklist.Columns.Add("Section5");
            dtChecklist.Columns.Add("DefectiveNumber");
            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.CheckListProcessTourDataResults)
                {




                    dtChecklist.Rows.Add(Uid, row.DataId, row.Section1, row.Section2, row.Section3, row.Section3, row.Section4, row.Section5, row.DefectiveNumber);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                int i = _checkResult.InsertBulkchecklistProcessTourData(dtChecklist, Session["EmpNumber"].ToString(), model.LineId, model.ProjectId, model.Model, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.ModelId, model.PartId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("ChecklistProcessTourData");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            model.dtChecklist = _checkResult.GetFromByProcessTourData(model.LineId, model.ProjectId, model.VisualsId);
            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];

            return View("ChecklistProcessTourData", model);
        }


        [HttpGet]
        public ActionResult ChecklistProcessTourDataa()
        {
            CheckListProcessTourDataaModelView model = new CheckListProcessTourDataaModelView();
            model.dtProcess = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            model.Visualss = new List<DOL.Visuals>();
            Session["Shifts"] = model.Shifts;
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            return View(model);
        }


        [HttpPost]
        public ActionResult ChecklistProcessTourDataa(CheckListProcessTourDataaModelView m)
        {
           // CheckListProcessTourDataaModelView model = new CheckListProcessTourDataaModelView();

           
                m.dtProcess = _checkResult.GetFromByProcessTourData(m.LineId, m.ProjectId,m.VisualsId);

           

            //m.Lines = (List<Line>)Session["Lines"];
            //m.Shifts = (List<Shift>)Session["Shifts"];
            //m.Projects = (List<DOL.Project>)Session["Projects"];
            //Session["Lines"] = m.Lines;
            //Session["Shifts"] = m.Shifts;
            //Session["ModelNos"] = m.ModelNos;
            //Session["PartNos"] = m.PartNos;
            //m.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            //m.PartNos = (List<DOL.PartNo>)Session["PartNos"];
           

            if (!ModelState.IsValid)
                return View(m);

            try
            {
                m.dtProcess = _checkResult.GetFromByProcessTourData(m.LineId, m.ProjectId,m.VisualsId);
                //m.Lines = (List<Line>)Session["Lines"];
                //m.Shifts = (List<Shift>)Session["Shifts"];
                //m.Projects = (List<DOL.Project>)Session["Projects"];
                
                //Session["Lines"] = m.Lines;
                //Session["Shifts"] = m.Shifts;
                //Session["ModelNos"] = m.ModelNos;
                //Session["PartNos"] = m.PartNos;
                //m.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                //m.PartNos = (List<DOL.PartNo>)Session["PartNos"];

                m.Lines = (List<Line>)Session["Lines"];
                m.Shifts = (List<Shift>)Session["Shifts"];
                m.Projects = (List<DOL.Project>)Session["Projects"];
                m.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                m.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                m.Visualss = (List<DOL.Visuals>)Session["Visuals"];
                Session["Lines"] = m.Lines;
                Session["Shifts"] = m.Shifts;
                Session["ModelNos"] = m.ModelNos;
                Session["PartNos"] = m.PartNos;
                
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);
            }

            return View(m);
        }

        [HttpPost]
        public ActionResult SaveChecklistProcessTourDataa(CheckListProcessTourDataaModelView model)
        {
            DataTable dtChecklist = new DataTable("ProcessTourDataaResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("DataId");
            dtChecklist.Columns.Add("Section1");
            //dtChecklist.Columns.Add("Section2");
            //dtChecklist.Columns.Add("Section3");
            //dtChecklist.Columns.Add("Section4");
            //dtChecklist.Columns.Add("Section5");
            dtChecklist.Columns.Add("DefectiveNumber");
            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.ProcessTourDataaResults)
                {




                    dtChecklist.Rows.Add(Uid, row.DataId, row.Section1, row.DefectiveNumber);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                int i = _checkResult.InsertBulkchecklistProcessTourData(dtChecklist, Session["EmpNumber"].ToString(), model.LineId, model.ProjectId, model.Model, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.ModelId, model.PartId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("ChecklistProcessTourDataa");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            model.dtProcess = _checkResult.GetFromByProcessTourData(model.LineId, model.ProjectId,model.VisualsId);
            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];

            return View("ChecklistProcessTourDataa", model);
        }


        #region --> Post Method For A246CVisualsByProject

        [HttpPost]
        public ActionResult GetA246CVisualsByProject(int ProjectId)
        {
            string PlantCode = string.Empty;

            List<DOL.Visuals> PeriodList = new List<DOL.Visuals>();

            DataTable dt = _objProject.GetVisualsByproject(ProjectId);

            PeriodList = dt.DataTableToList<DOL.Visuals>();

            string retStr = string.Empty;

            Session["Visuals"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion


        [HttpGet]
        public ActionResult A246CCMMCCheckList()
        {
            A246CCMMC1CheckListModelView model = new A246CCMMC1CheckListModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.Machines = _CheckListCircuitRecord.GetA246CMachines();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Machines"] = model.Machines;
            //Session["ModelNos"] = model.ModelNos;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult A246CCMMCCheckList(A246CCMMC1CheckListModelView model1)
        {
            //model1.dtChecklist = _checkResult.GetFromByA246CCMMC1Dataa(model1.LineId, model1.ProjectId, model1.MachineId);
            //model1.Lines = (List<Line>)Session["Lines"];
            //model1.Shifts = (List<Shift>)Session["Shifts"];
            //model1.Projects = (List<DOL.Project>)Session["Projects"];
            //model1.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            //model1.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            //model1.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            //Session["Lines"] = model1.Lines;
            //Session["Shifts"] = model1.Shifts;
            //Session["ModelNos"] = model1.ModelNos;
            //Session["PartNos"] = model1.PartNos;
            if (!ModelState.IsValid)
                return View(model1);

            try
            {
                model1.dtChecklist = _checkResult.GetFromByA246CCMMC1Dataa(model1.LineId, model1.ProjectId, model1.MachineId);
                model1.Lines = (List<Line>)Session["Lines"];
                model1.Shifts = (List<Shift>)Session["Shifts"];
                model1.Projects = (List<DOL.Project>)Session["Projects"];
                model1.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model1.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                model1.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model1);

            //return RedirectToAction("ChecklistResults");
        }


        [HttpPost]
        public ActionResult SaveA246CCMMCCheckList(A246CCMMC1CheckListModelView model2)
        {
            DataTable dtChecklist = new DataTable("A246CCMMC1CheckListResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("SectionId");
            dtChecklist.Columns.Add("Value1");
            dtChecklist.Columns.Add("Value2");
            dtChecklist.Columns.Add("Value3");
            dtChecklist.Columns.Add("Value4");
            dtChecklist.Columns.Add("Value5");
            dtChecklist.Columns.Add("InspectionResults");


            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model2.A246CCMMC1CheckListResults)
                {




                    dtChecklist.Rows.Add(Uid, row.SectionId, row.Value1, row.Value2,row.Value3,row.Value4,row.Value5,row.InspectionResults);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                int i = _checkResult.InsertBulkA246CCMMC1CheckList(dtChecklist, Session["EmpNumber"].ToString(), model2.LineId, model2.ProdLineLeader, model2.CheckedBy, model2.ApprovedBy, model2.ModelId, model2.PartId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("A246CCMMCCheckList");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            model2.dtChecklist = _checkResult.GetFromByA246CCMMC1Dataa(model2.LineId, model2.ProjectId, model2.MachineId);
            model2.Lines = (List<Line>)Session["Lines"];
            model2.Shifts = (List<Shift>)Session["Shifts"];
            model2.Projects = (List<DOL.Project>)Session["Projects"];
            model2.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model2.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            model2.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            return View("A246CCMMCCheckList", model2);
        }



        [HttpGet]
        public ActionResult A246CCMMCCheckList1()
        {
            A246CCMMC1CheckListModelView model = new A246CCMMC1CheckListModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.Machines = _CheckListCircuitRecord.GetA246CMachines();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Machines"] = model.Machines;
            //Session["ModelNos"] = model.ModelNos;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult A246CCMMCCheckList1(A246CCMMC1CheckListModelView model)
        {
            //model1.dtChecklist = _checkResult.GetFromByA246CCMMC1Dataa(model1.LineId, model1.ProjectId, model1.MachineId);
            //model1.Lines = (List<Line>)Session["Lines"];
            //model1.Shifts = (List<Shift>)Session["Shifts"];
            //model1.Projects = (List<DOL.Project>)Session["Projects"];
            //model1.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            //model1.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            //model1.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            //Session["Lines"] = model1.Lines;
            //Session["Shifts"] = model1.Shifts;
            //Session["ModelNos"] = model1.ModelNos;
            //Session["PartNos"] = model1.PartNos;
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                model.dtChecklist = _checkResult.GetFromByA246CCMMC1Dataa(model.LineId, model.ProjectId, model.MachineId);
                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                model.Projects = (List<DOL.Project>)Session["Projects"];
                model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                model.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model);

            //return RedirectToAction("ChecklistResults");
        }


        [HttpPost]
        public ActionResult SaveA246CCMMCCheckList1(A246CCMMC1CheckListModelView model)
        {
            DataTable dtChecklist = new DataTable("A246CCMMC1CheckListResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("SectionId");
            dtChecklist.Columns.Add("Value1");
            dtChecklist.Columns.Add("Value2");
            dtChecklist.Columns.Add("Value3");
            dtChecklist.Columns.Add("Value4");
            dtChecklist.Columns.Add("Value5");
            dtChecklist.Columns.Add("InspectionResults");


            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.A246CCMMC1CheckListResults)
                {




                    dtChecklist.Rows.Add(Uid, row.SectionId, row.Value1, row.Value2, row.Value3, row.Value4, row.Value5, row.InspectionResults);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                int i = _checkResult.InsertBulkA246CCMMC1CheckList(dtChecklist, Session["EmpNumber"].ToString(), model.LineId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.ModelId, model.PartId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("A246CCMMCCheckList1");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            model.dtChecklist = _checkResult.GetFromByA246CCMMC1Dataa(model.LineId, model.ProjectId, model.MachineId);
            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            model.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            return View("A246CCMMCCheckList1", model);
        }

        [HttpGet]
        public ActionResult A246CWCMMCCheckList()
        {
            A246CWCMMCCheckListModelView model = new A246CWCMMCCheckListModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.Machines = _CheckListCircuitRecord.GetA246CMachines();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Machines"] = model.Machines;
            //Session["ModelNos"] = model.ModelNos;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult A246CWCMMCCheckList(A246CWCMMCCheckListModelView model1)
        {
            //model1.dtChecklist = _checkResult.GetFromByA246CCMMC1Dataa(model1.LineId, model1.ProjectId, model1.MachineId);
            //model1.Lines = (List<Line>)Session["Lines"];
            //model1.Shifts = (List<Shift>)Session["Shifts"];
            //model1.Projects = (List<DOL.Project>)Session["Projects"];
            //model1.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            //model1.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            //model1.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            //Session["Lines"] = model1.Lines;
            //Session["Shifts"] = model1.Shifts;
            //Session["ModelNos"] = model1.ModelNos;
            //Session["PartNos"] = model1.PartNos;
            if (!ModelState.IsValid)
                return View(model1);

            try
            {
                model1.dtChecklist = _checkResult.GetFromByA246CWCMMC1Data(model1.ProjectId, model1.LineId, model1.MachineId);
                model1.Lines = (List<Line>)Session["Lines"];
                model1.Shifts = (List<Shift>)Session["Shifts"];
                model1.Projects = (List<DOL.Project>)Session["Projects"];
                model1.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model1.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                model1.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model1);

            //return RedirectToAction("ChecklistResults");
        }

        [HttpPost]
        public ActionResult SaveA246CWCMMCCheckList(A246CWCMMCCheckListModelView model2)
        {
            DataTable dtChecklist = new DataTable("A246CWCMMCCheckListResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("SectionId");
            dtChecklist.Columns.Add("Value1");
            dtChecklist.Columns.Add("Value2");
            dtChecklist.Columns.Add("Value3");
            dtChecklist.Columns.Add("Value4");
            dtChecklist.Columns.Add("Value5");
            dtChecklist.Columns.Add("InspectionResults");
            dtChecklist.Columns.Add("CablesSerialNumber");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model2.A246CWCMMCCheckListResults)
                {




                    dtChecklist.Rows.Add(Uid, row.SectionId, row.Value1, row.Value2, row.Value3, row.Value4, row.Value5, row.InspectionResults,row.CablesSerialNumber);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                int i = _checkResult.InsertBulkA246CWCMMC1CheckList(dtChecklist, Session["EmpNumber"].ToString(), model2.LineId, model2.ProdLineLeader, model2.CheckedBy, model2.ApprovedBy, model2.ModelId, model2.PartId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("A246CWCMMCCheckList");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            model2.dtChecklist = _checkResult.GetFromByA246CWCMMC1Data(model2.ProjectId, model2.LineId, model2.MachineId);
            model2.Lines = (List<Line>)Session["Lines"];
            model2.Shifts = (List<Shift>)Session["Shifts"];
            model2.Projects = (List<DOL.Project>)Session["Projects"];
            model2.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model2.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            model2.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            return View("A246CWCMMCCheckList", model2);
        }


        [HttpGet]
        public ActionResult A246CMHB1CheckList()
        {
            A246CMHB1CheckListModelView model = new A246CMHB1CheckListModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.Machines = _CheckListCircuitRecord.GetA246CMachines();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Machines"] = model.Machines;
            //Session["ModelNos"] = model.ModelNos;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult A246CMHB1CheckList(A246CMHB1CheckListModelView model1)
        {
            //model1.dtChecklist = _checkResult.GetFromByA246CCMMC1Dataa(model1.LineId, model1.ProjectId, model1.MachineId);
            //model1.Lines = (List<Line>)Session["Lines"];
            //model1.Shifts = (List<Shift>)Session["Shifts"];
            //model1.Projects = (List<DOL.Project>)Session["Projects"];
            //model1.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            //model1.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            //model1.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            //Session["Lines"] = model1.Lines;
            //Session["Shifts"] = model1.Shifts;
            //Session["ModelNos"] = model1.ModelNos;
            //Session["PartNos"] = model1.PartNos;
            if (!ModelState.IsValid)
                return View(model1);

            try
            {
                model1.dtChecklist = _checkResult.GetFromByA246CMHB1Data(model1.ProjectId, model1.LineId);
                model1.Lines = (List<Line>)Session["Lines"];
                model1.Shifts = (List<Shift>)Session["Shifts"];
                model1.Projects = (List<DOL.Project>)Session["Projects"];
                model1.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model1.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                model1.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model1);

            //return RedirectToAction("ChecklistResults");
        }

        [HttpPost]
        public ActionResult SaveA246CMHB1CheckList(A246CMHB1CheckListModelView model2)
        {
            DataTable dtChecklist = new DataTable("A246CMHB1CheckListResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("SectionId");
            dtChecklist.Columns.Add("Value1");
            dtChecklist.Columns.Add("Value2");
            dtChecklist.Columns.Add("Value3");
            dtChecklist.Columns.Add("Value4");
            dtChecklist.Columns.Add("Value5");
            dtChecklist.Columns.Add("InspectionResults");
            dtChecklist.Columns.Add("CablesSerialNumber");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model2.A246CMHB1CheckListResults)
                {




                    dtChecklist.Rows.Add(Uid, row.SectionId, row.Value1, row.Value2, row.Value3, row.Value4, row.Value5, row.InspectionResults, row.CablesSerialNumber);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                int i = _checkResult.InsertBulkA246CMHB1CheckList(dtChecklist, Session["EmpNumber"].ToString(), model2.LineId, model2.ProdLineLeader, model2.CheckedBy, model2.ApprovedBy, model2.ModelId, model2.PartId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("A246CMHB1CheckList");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            model2.dtChecklist = _checkResult.GetFromByA246CMHB1Data(model2.ProjectId, model2.LineId);
            model2.Lines = (List<Line>)Session["Lines"];
            model2.Shifts = (List<Shift>)Session["Shifts"];
            model2.Projects = (List<DOL.Project>)Session["Projects"];
            model2.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model2.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            model2.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            return View("A246CMHB1CheckList", model2);
        }


        [HttpGet]
        public ActionResult A246CMHB2CheckList()
        {
            A246CMHB2CheckListModelView model = new A246CMHB2CheckListModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.Machines = _CheckListCircuitRecord.GetA246CMachines();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Machines"] = model.Machines;
            //Session["ModelNos"] = model.ModelNos;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult A246CMHB2CheckList(A246CMHB2CheckListModelView model1)
        {
            model1.dtChecklist = _checkResult.GetFromByA246CMHB2Data(model1.ProjectId, model1.LineId, model1.MachineId);
            model1.Lines = (List<Line>)Session["Lines"];
            model1.Shifts = (List<Shift>)Session["Shifts"];
            model1.Projects = (List<DOL.Project>)Session["Projects"];
            model1.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model1.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            model1.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            Session["Lines"] = model1.Lines;
            Session["Shifts"] = model1.Shifts;
            Session["ModelNos"] = model1.ModelNos;
            Session["PartNos"] = model1.PartNos;
            if (!ModelState.IsValid)
                return View(model1);

            try
            {
                model1.dtChecklist = _checkResult.GetFromByA246CMHB2Data(model1.ProjectId, model1.LineId,model1.MachineId);
                model1.Lines = (List<Line>)Session["Lines"];
                model1.Shifts = (List<Shift>)Session["Shifts"];
                model1.Projects = (List<DOL.Project>)Session["Projects"];
                model1.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model1.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                model1.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model1);

            //return RedirectToAction("ChecklistResults");
        }

        [HttpPost]
        public ActionResult SaveA246CMHB2CheckList(A246CMHB2CheckListModelView model2)
        {
            DataTable dtChecklist = new DataTable("A246CMHB2CheckListResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("SectionId");
            dtChecklist.Columns.Add("Value1");
            dtChecklist.Columns.Add("Value2");
            //dtChecklist.Columns.Add("Value3");
            //dtChecklist.Columns.Add("Value4");
            //dtChecklist.Columns.Add("Value5");
            dtChecklist.Columns.Add("InspectionResults");
            //dtChecklist.Columns.Add("CablesSerialNumber");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model2.A246CMHB2CheckListResults)
                {




                    dtChecklist.Rows.Add(Uid, row.SectionId, row.Value1, row.Value2, row.InspectionResults);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                int i = _checkResult.InsertBulkA246CMHB2CheckList(dtChecklist, Session["EmpNumber"].ToString(), model2.LineId, model2.ProdLineLeader, model2.CheckedBy, model2.ApprovedBy, model2.ModelId, model2.PartId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("A246CMHB2CheckList");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            model2.dtChecklist = _checkResult.GetFromByA246CMHB2Data(model2.ProjectId, model2.LineId,model2.MachineId);
            model2.Lines = (List<Line>)Session["Lines"];
            model2.Shifts = (List<Shift>)Session["Shifts"];
            model2.Projects = (List<DOL.Project>)Session["Projects"];
            model2.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model2.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            model2.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            return View("A246CMHB2CheckList", model2);
        }


        [HttpGet]
        public ActionResult A246CCShellCrimpMC1CheckList()
        {
            A246CShellCrimpMC1CheckListModelView model = new A246CShellCrimpMC1CheckListModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.Machines = _CheckListCircuitRecord.GetA246CMachines();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Machines"] = model.Machines;
            //Session["ModelNos"] = model.ModelNos;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult A246CCShellCrimpMC1CheckList(A246CShellCrimpMC1CheckListModelView model1)
        {
            //model1.dtChecklist = _checkResult.GetFromByA246CCMMC1Dataa(model1.LineId, model1.ProjectId, model1.MachineId);
            //model1.Lines = (List<Line>)Session["Lines"];
            //model1.Shifts = (List<Shift>)Session["Shifts"];
            //model1.Projects = (List<DOL.Project>)Session["Projects"];
            //model1.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            //model1.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            //model1.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            //Session["Lines"] = model1.Lines;
            //Session["Shifts"] = model1.Shifts;
            //Session["ModelNos"] = model1.ModelNos;
            //Session["PartNos"] = model1.PartNos;
            if (!ModelState.IsValid)
                return View(model1);

            try
            {
                model1.dtChecklist = _checkResult.GetFromByA246CShellCrimpMC1Data(model1.ProjectId, model1.LineId, model1.MachineId);
                model1.Lines = (List<Line>)Session["Lines"];
                model1.Shifts = (List<Shift>)Session["Shifts"];
                model1.Projects = (List<DOL.Project>)Session["Projects"];
                model1.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model1.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                model1.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model1);

            //return RedirectToAction("ChecklistResults");
        }

        [HttpPost]
        public ActionResult SaveA246CCShellCrimpMC1CheckList(A246CShellCrimpMC1CheckListModelView model2)
        {
            DataTable dtChecklist = new DataTable("A246CShellCrimpMC1CheckListResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("SectionId");
            dtChecklist.Columns.Add("Value1");
            dtChecklist.Columns.Add("Value2");
            dtChecklist.Columns.Add("Value3");
            dtChecklist.Columns.Add("Value4");
            dtChecklist.Columns.Add("Value5");
            dtChecklist.Columns.Add("InspectionResults");
            dtChecklist.Columns.Add("CablesSerialNumber");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model2.A246CShellCrimpMC1CheckListResults)
                {




                    dtChecklist.Rows.Add(Uid, row.SectionId, row.Value1, row.Value2,row.Value3,row.Value4,row.Value5, row.InspectionResults, row.CablesSerialNumber);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                int i = _checkResult.InsertBulkA246CShellCrimpMC1CheckList(dtChecklist, Session["EmpNumber"].ToString(), model2.LineId, model2.ProdLineLeader, model2.CheckedBy, model2.ApprovedBy, model2.ModelId, model2.PartId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("A246CCShellCrimpMC1CheckList");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            model2.dtChecklist = _checkResult.GetFromByA246CWCMMC1Data(model2.ProjectId, model2.LineId, model2.MachineId);
            model2.Lines = (List<Line>)Session["Lines"];
            model2.Shifts = (List<Shift>)Session["Shifts"];
            model2.Projects = (List<DOL.Project>)Session["Projects"];
            model2.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model2.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            model2.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            return View("A246CCShellCrimpMC1CheckList", model2);
        }

        [HttpGet]
        public ActionResult A246CInnerMoldMCDataCheckList()
        {
            A246CInnerMoldMCDataCheckListModelView model = new A246CInnerMoldMCDataCheckListModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.Machines = _CheckListCircuitRecord.GetA246CMachines();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Machines"] = model.Machines;
            //Session["ModelNos"] = model.ModelNos;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult A246CInnerMoldMCDataCheckList(A246CInnerMoldMCDataCheckListModelView model1)
        {
            //model1.dtChecklist = _checkResult.GetFromByA246CCMMC1Dataa(model1.LineId, model1.ProjectId, model1.MachineId);
            //model1.Lines = (List<Line>)Session["Lines"];
            //model1.Shifts = (List<Shift>)Session["Shifts"];
            //model1.Projects = (List<DOL.Project>)Session["Projects"];
            //model1.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            //model1.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            //model1.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            //Session["Lines"] = model1.Lines;
            //Session["Shifts"] = model1.Shifts;
            //Session["ModelNos"] = model1.ModelNos;
            //Session["PartNos"] = model1.PartNos;
            if (!ModelState.IsValid)
                return View(model1);

            try
            {
                model1.dtChecklist = _checkResult.GetFromByA246CInnerMoldMCData(model1.ProjectId, model1.LineId, model1.MachineId);
                model1.Lines = (List<Line>)Session["Lines"];
                model1.Shifts = (List<Shift>)Session["Shifts"];
                model1.Projects = (List<DOL.Project>)Session["Projects"];
                model1.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model1.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                model1.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model1);

            //return RedirectToAction("ChecklistResults");
        }

        [HttpPost]
        public ActionResult SaveA246CInnerMoldMCDataCheckList(A246CInnerMoldMCDataCheckListModelView model2)
        {
            DataTable dtChecklist = new DataTable("A246CInnerMoldMCDataCheckListResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("SectionId");
            dtChecklist.Columns.Add("Value1");
            dtChecklist.Columns.Add("Value2");
            dtChecklist.Columns.Add("Value3");
            dtChecklist.Columns.Add("Value4");
            dtChecklist.Columns.Add("Value5");
            dtChecklist.Columns.Add("InspectionResults");
            dtChecklist.Columns.Add("CablesSerialNumber");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model2.A246CInnerMoldMCDataCheckListResults)
                {




                    dtChecklist.Rows.Add(Uid, row.SectionId, row.Value1,row.Value2,row.Value3,row.Value4,row.Value5, row.InspectionResults, row.CablesSerialNumber);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                int i = _checkResult.InsertBulkA246CInnerMoldMCCheckList(dtChecklist, Session["EmpNumber"].ToString(), model2.LineId, model2.ProdLineLeader, model2.CheckedBy, model2.ApprovedBy, model2.ModelId, model2.PartId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("A246CInnerMoldMCDataCheckList");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            model2.dtChecklist = _checkResult.GetFromByA246CInnerMoldMCData(model2.ProjectId, model2.LineId, model2.MachineId);
            model2.Lines = (List<Line>)Session["Lines"];
            model2.Shifts = (List<Shift>)Session["Shifts"];
            model2.Projects = (List<DOL.Project>)Session["Projects"];
            model2.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model2.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            model2.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            return View("A246CInnerMoldMCDataCheckList", model2);
        }

        [HttpGet]
        public ActionResult A246CBAndFDataCheckList()
        {
            A246CBAndFDataCheckListModelView model = new A246CBAndFDataCheckListModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.Machines = _CheckListCircuitRecord.GetA246CMachines();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Machines"] = model.Machines;
            //Session["ModelNos"] = model.ModelNos;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult A246CBAndFDataCheckList(A246CBAndFDataCheckListModelView model1)
        {
            
            if (!ModelState.IsValid)
                return View(model1);

            try
            {
                model1.dtChecklist = _checkResult.GetFromByA246CBAndFData(model1.ProjectId, model1.LineId, model1.MachineId);
                model1.Lines = (List<Line>)Session["Lines"];
                model1.Shifts = (List<Shift>)Session["Shifts"];
                model1.Projects = (List<DOL.Project>)Session["Projects"];
                model1.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model1.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                model1.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model1);

            //return RedirectToAction("ChecklistResults");
        }

        [HttpPost]
        public ActionResult SaveA246CBAndFDataCheckList(A246CBAndFDataCheckListModelView model2)
        {
            DataTable dtChecklist = new DataTable("A246CBAndFDataCheckListResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("SectionId");
            dtChecklist.Columns.Add("Value1");
            //dtChecklist.Columns.Add("Value2");
            //dtChecklist.Columns.Add("Value3");
            //dtChecklist.Columns.Add("Value4");
            //dtChecklist.Columns.Add("Value5");
            dtChecklist.Columns.Add("InspectionResults");
            //dtChecklist.Columns.Add("CablesSerialNumber");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model2.A246CBAndFDataCheckListResults)
                {




                    dtChecklist.Rows.Add(Uid, row.SectionId, row.Value1, row.InspectionResults);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                int i = _checkResult.InsertBulkA246CBAndFCheckList(dtChecklist, Session["EmpNumber"].ToString(), model2.LineId, model2.ProdLineLeader, model2.CheckedBy, model2.ApprovedBy, model2.ModelId, model2.PartId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("A246CBAndFDataCheckList");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            model2.dtChecklist = _checkResult.GetFromByA246CBAndFData(model2.ProjectId, model2.LineId, model2.MachineId);
            model2.Lines = (List<Line>)Session["Lines"];
            model2.Shifts = (List<Shift>)Session["Shifts"];
            model2.Projects = (List<DOL.Project>)Session["Projects"];
            model2.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model2.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            model2.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            return View("A246CBAndFDataCheckList", model2);
        }

        [HttpGet]
        public ActionResult A246CAOICheckList()
        {
            A246CAOICheckListModelView model = new A246CAOICheckListModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.Machines = _CheckListCircuitRecord.GetA246CMachines();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Machines"] = model.Machines;
            //Session["ModelNos"] = model.ModelNos;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult A246CAOICheckList(A246CAOICheckListModelView model1)
        {
            
            if (!ModelState.IsValid)
                return View(model1);

            try
            {
                model1.dtChecklist = _checkResult.GetFromByA246CAOIData(model1.ProjectId, model1.LineId, model1.MachineId);
                model1.Lines = (List<Line>)Session["Lines"];
                model1.Shifts = (List<Shift>)Session["Shifts"];
                model1.Projects = (List<DOL.Project>)Session["Projects"];
                model1.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model1.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                model1.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model1);

            //return RedirectToAction("ChecklistResults");
        }

        [HttpPost]
        public ActionResult SaveA246CAOICheckList(A246CAOICheckListModelView model2)
        {
            DataTable dtChecklist = new DataTable("A246CAOICheckListResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("SectionId");
            dtChecklist.Columns.Add("Value1");
            dtChecklist.Columns.Add("Value2");
            dtChecklist.Columns.Add("Value3");
            dtChecklist.Columns.Add("Value4");
            dtChecklist.Columns.Add("Value5");
            dtChecklist.Columns.Add("InspectionResults");
            //dtChecklist.Columns.Add("CablesSerialNumber");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model2.A246CAOICheckListResults)
                {




                    dtChecklist.Rows.Add(Uid, row.SectionId, row.Value1, row.Value2, row.Value3, row.Value4, row.Value5, row.InspectionResults);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                int i = _checkResult.InsertBulkA246CAOICheckList(dtChecklist, Session["EmpNumber"].ToString(), model2.LineId, model2.ProdLineLeader, model2.CheckedBy, model2.ApprovedBy, model2.ModelId, model2.PartId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("A246CAOICheckList");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            model2.dtChecklist = _checkResult.GetFromByA246CAOIData(model2.ProjectId, model2.LineId, model2.MachineId);
            model2.Lines = (List<Line>)Session["Lines"];
            model2.Shifts = (List<Shift>)Session["Shifts"];
            model2.Projects = (List<DOL.Project>)Session["Projects"];
            model2.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model2.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            model2.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            return View("A246CAOICheckList", model2);
        }


        [HttpGet]
        public ActionResult A246CHankingCheckList()
        {
            A246CHankingCheckListModelView model = new A246CHankingCheckListModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.Machines = _CheckListCircuitRecord.GetA246CMachines();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Machines"] = model.Machines;
            //Session["ModelNos"] = model.ModelNos;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult A246CHankingCheckList(A246CHankingCheckListModelView model1)
        {

            if (!ModelState.IsValid)
                return View(model1);

            try
            {
                model1.dtChecklist = _checkResult.GetFromByA246CHankingData(model1.ProjectId, model1.LineId, model1.MachineId);
                model1.Lines = (List<Line>)Session["Lines"];
                model1.Shifts = (List<Shift>)Session["Shifts"];
                model1.Projects = (List<DOL.Project>)Session["Projects"];
                model1.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model1.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                model1.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model1);

            //return RedirectToAction("ChecklistResults");
        }

        [HttpPost]
        public ActionResult SaveA246CHankingCheckList(A246CHankingCheckListModelView model2)
        {
            DataTable dtChecklist = new DataTable("A246CHankingCheckListResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("SectionId");
            dtChecklist.Columns.Add("Value1");
            dtChecklist.Columns.Add("Value2");
            dtChecklist.Columns.Add("Value3");
            dtChecklist.Columns.Add("Value4");
            dtChecklist.Columns.Add("Value5");
            dtChecklist.Columns.Add("InspectionResults");
            //dtChecklist.Columns.Add("CablesSerialNumber");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model2.A246CHankingCheckListResults)
                {




                    dtChecklist.Rows.Add(Uid, row.SectionId, row.Value1, row.Value2, row.Value3, row.Value4, row.Value5, row.InspectionResults);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                int i = _checkResult.InsertBulkA246CHankingCheckList(dtChecklist, Session["EmpNumber"].ToString(), model2.LineId, model2.ProdLineLeader, model2.CheckedBy, model2.ApprovedBy, model2.ModelId, model2.PartId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("A246CHankingCheckList");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            model2.dtChecklist = _checkResult.GetFromByA246CHankingData(model2.ProjectId, model2.LineId, model2.MachineId);
            model2.Lines = (List<Line>)Session["Lines"];
            model2.Shifts = (List<Shift>)Session["Shifts"];
            model2.Projects = (List<DOL.Project>)Session["Projects"];
            model2.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model2.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            model2.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            return View("A246CHankingCheckList", model2);
        }

        [HttpGet]
        public ActionResult A246CLaserEngravingCheckList()
        {
            A246CLaserEngravingCheckListModelView model = new A246CLaserEngravingCheckListModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            //model.Machines = _CheckListCircuitRecord.GetA246CMachines();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            //Session["Machines"] = model.Machines;
            //Session["ModelNos"] = model.ModelNos;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult A246CLaserEngravingCheckList(A246CLaserEngravingCheckListModelView model1)
        {

            if (!ModelState.IsValid)
                return View(model1);

            try
            {
                model1.dtChecklist = _checkResult.GetFromByA246CLaserEngravingData(model1.ProjectId, model1.LineId);
                model1.Lines = (List<Line>)Session["Lines"];
                model1.Shifts = (List<Shift>)Session["Shifts"];
                model1.Projects = (List<DOL.Project>)Session["Projects"];
                model1.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model1.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                //model1.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model1);

            //return RedirectToAction("ChecklistResults");
        }

        [HttpPost]
        public ActionResult SaveA246CLaserEngravingCheckList(A246CLaserEngravingCheckListModelView model2)
        {
            DataTable dtChecklist = new DataTable("A246CLaserEngravingCheckListResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("LocationId");
            dtChecklist.Columns.Add("Value1");
            dtChecklist.Columns.Add("SerialNumber1");
            dtChecklist.Columns.Add("Value2");
            dtChecklist.Columns.Add("SerialNumber2");
            dtChecklist.Columns.Add("Value3");
            dtChecklist.Columns.Add("SerialNumber3");
            dtChecklist.Columns.Add("Value4");
            dtChecklist.Columns.Add("SerialNumber4");
            dtChecklist.Columns.Add("Value5");
            dtChecklist.Columns.Add("SerialNumber5");
            //dtChecklist.Columns.Add("InspectionResults");
            //dtChecklist.Columns.Add("CablesSerialNumber");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model2.A246CLaserEngravingCheckListResults)
                {




                    dtChecklist.Rows.Add(Uid, row.LocationId, row.Value1,row.SerialNumber1, row.Value2,row.SerialNumber2, row.Value3,row.SerialNumber3, row.Value4,row.SerialNumber4, row.Value5, row.SerialNumber5);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                int i = _checkResult.InsertBulkA246CLaserEngravingCheckList(dtChecklist, Session["EmpNumber"].ToString(), model2.LineId, model2.ProdLineLeader, model2.CheckedBy, model2.ApprovedBy, model2.ModelId, model2.PartId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("A246CLaserEngravingCheckList");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            model2.dtChecklist = _checkResult.GetFromByA246CLaserEngravingData(model2.ProjectId, model2.LineId);
            model2.Lines = (List<Line>)Session["Lines"];
            model2.Shifts = (List<Shift>)Session["Shifts"];
            model2.Projects = (List<DOL.Project>)Session["Projects"];
            model2.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model2.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            //model2.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            return View("A246CLaserEngravingCheckList", model2);
        }

        [HttpGet]
        public ActionResult A246CHumidityRecordCheckList()
        {
            CheckListHumidityRecordResultModelView model = new CheckListHumidityRecordResultModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            //model.Projects = _CheckListCircuitRecord.GetProject();
            //model.ModelNos = new List<DOL.ModelNo>();
            //model.PartNos = new List<DOL.PartNo>();
            //Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Shifts"] = model.Shifts;
            return View(model);
        }

        [HttpPost]
        public ActionResult A246CHumidityRecordCheckList(CheckListHumidityRecordResultModelView model)
        {
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            //model.Projects = _CheckListCircuitRecord.GetProject();

            //model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            //model.Projects = (List<DOL.Project>)Session["Projects"];
            //model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            //model.PartNos = (List<DOL.PartNo>)Session["PartNos"];

            model.dtChecklist = _checkResult.GetFormByA246CHumidityRecord(model.LineId);

            if (!ModelState.IsValid)
                return View(model);
            try
            {
                //model.dtChecklist = _checkResult.GetFormByA191FinsihedProduct(model.LineId, model.ProjectId);
                model.dtChecklist = _checkResult.GetFormByA246CHumidityRecord(model.LineId);
                //model.Lines = _checkResult.GetLine();
                //model.Shifts = _checkResult.GetShift();
                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                //model.Projects = (List<DOL.Project>)Session["Projects"];
                //model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                //model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                //model.Exponents = (List<DOL.Exponent>)Session["Exponents"];
                //model.Statuses = _CheckListCircuitRecord.GetResult();
                Session["Lines"] = model.Lines;
                Session["Shifts"] = model.Shifts;
                //Session["ModelNos"] = model.ModelNos;
                //Session["PartNos"] = model.PartNos;
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveA246CCheckListHumidityRecord(CheckListHumidityRecordResultModelView model)
        {
            DataTable dtLaserlist = new DataTable("CheckListHumidityRecordResults");
            dtLaserlist.Columns.Add("Id");
            dtLaserlist.Columns.Add("HumidityId");
            dtLaserlist.Columns.Add("ActualValue");
            //dtLaserlist.Columns.Add("Reason");
            //dtLaserlist.Columns.Add("Status");
            //dtLaserlist.Columns.Add("Remark");
            //dtLaserlist.Columns.Add("Prodll");
            //dtLaserlist.Columns.Add("qcll");
            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.CheckListHumidityRecordResults)
                {
                    dtLaserlist.Rows.Add(Uid, row.HumidityId, row.ActualValue);
                    Uid++;

                }

                int i = _checkResult.InsertBulkA246CHumidityRecordCheckList(dtLaserlist, Session["EmpNumber"].ToString(), model.LineId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.EquipmentSNo);

                //model.dtChecklist = _checkResult.GetFormByA191FinsihedProduct(model.LineId, model.ProjectId);



                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("A246CHumidityRecordCheckList");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            //  model.dtLaser = _objchecklistResults.InsertLaserResults(model.LineId);

            model.dtChecklist = _checkResult.GetFormByA246CHumidityRecord(model.LineId);

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            //model.Projects = (List<DOL.Project>)Session["Projects"];
            //model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            //model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            //model.Exponents = (List<DOL.Exponent>)Session["Exponents"];

            //model.Statuses = _CheckListCircuitRecord.GetResult();

            return View("A246CHumidityRecordCheckList", model);
        }

        [HttpGet]
        public ActionResult A246CTempratureRecordCheckList()
        {
            CheckListTemperatureRecordResulttModelView model = new CheckListTemperatureRecordResulttModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            //model.Projects = _CheckListCircuitRecord.GetProject();
            //model.ModelNos = new List<DOL.ModelNo>();
            //model.PartNos = new List<DOL.PartNo>();
            //Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Shifts"] = model.Shifts;
            return View(model);
        }

        [HttpPost]
        public ActionResult A246CTempratureRecordCheckList(CheckListTemperatureRecordResulttModelView model)
        {
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            //model.Projects = _CheckListCircuitRecord.GetProject();

            //model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            //model.Projects = (List<DOL.Project>)Session["Projects"];
            //model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            //model.PartNos = (List<DOL.PartNo>)Session["PartNos"];

            model.dtChecklist = _checkResult.GetFormByA246CTemperatureRecordData(model.LineId);

            if (!ModelState.IsValid)
                return View(model);
            try
            {
                //model.dtChecklist = _checkResult.GetFormByA191FinsihedProduct(model.LineId, model.ProjectId);
                model.dtChecklist = _checkResult.GetFormByA246CTemperatureRecordData(model.LineId);
                //model.Lines = _checkResult.GetLine();
                //model.Shifts = _checkResult.GetShift();
                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                //model.Projects = (List<DOL.Project>)Session["Projects"];
                //model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                //model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                //model.Exponents = (List<DOL.Exponent>)Session["Exponents"];
                //model.Statuses = _CheckListCircuitRecord.GetResult();
                Session["Lines"] = model.Lines;
                Session["Shifts"] = model.Shifts;
                //Session["ModelNos"] = model.ModelNos;
                //Session["PartNos"] = model.PartNos;
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveA246CCheckListTempratureRecord(CheckListTemperatureRecordResulttModelView model)
        {
            DataTable dtLaserlist = new DataTable("CheckListTemperatureRecordResults");
            dtLaserlist.Columns.Add("Id");
            dtLaserlist.Columns.Add("TempId");
            dtLaserlist.Columns.Add("ActualValue");
            //dtLaserlist.Columns.Add("Reason");
            //dtLaserlist.Columns.Add("Status");
            //dtLaserlist.Columns.Add("Remark");
            //dtLaserlist.Columns.Add("Prodll");
            //dtLaserlist.Columns.Add("qcll");
            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.CheckListTemperatureRecordResults)
                {
                    dtLaserlist.Rows.Add(Uid, row.TempId, row.ActualValue);
                    Uid++;

                }

                int i = _checkResult.InsertBulkTA246CTemperatureRecordCheckList(dtLaserlist, Session["EmpNumber"].ToString(), model.LineId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.EquipmentSNo);

                //model.dtChecklist = _checkResult.GetFormByA191FinsihedProduct(model.LineId, model.ProjectId);



                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("A246CTempratureRecordCheckList");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            //  model.dtLaser = _objchecklistResults.InsertLaserResults(model.LineId);

            model.dtChecklist = _checkResult.GetFormByA246CTemperatureRecordData(model.LineId);

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            //model.Projects = (List<DOL.Project>)Session["Projects"];
            //model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            //model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            //model.Exponents = (List<DOL.Exponent>)Session["Exponents"];

            //model.Statuses = _CheckListCircuitRecord.GetResult();

            return View("A246CTempratureRecordCheckList", model);
        }


        [HttpGet]
        public ActionResult A246CWristStrapCheckList()
        {
            A246CCheckListWristStrapModelView model = new A246CCheckListWristStrapModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            //model.Machines = _CheckListCircuitRecord.GetA246CMachines();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            //Session["Machines"] = model.Machines;
            //Session["ModelNos"] = model.ModelNos;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult A246CWristStrapCheckList(A246CCheckListWristStrapModelView model1)
        
{

            if (!ModelState.IsValid)
                return View(model1);

            try
            {
                model1.dtChecklist = _checkResult.GetFormByA246CWristStrap(model1.ProjectId, model1.LineId);
                model1.Lines = (List<Line>)Session["Lines"];
                model1.Shifts = (List<Shift>)Session["Shifts"];
                model1.Projects = (List<DOL.Project>)Session["Projects"];
                model1.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model1.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                //model1.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model1);

            //return RedirectToAction("ChecklistResults");
        }

        [HttpPost]
        public ActionResult SaveA246CWristStrapCheckList(A246CCheckListWristStrapModelView model2)
        {
            DataTable dtChecklist = new DataTable("A246CCheckListWristStrapResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("StationId");
            dtChecklist.Columns.Add("Value");
            
            //dtChecklist.Columns.Add("InspectionResults");
            //dtChecklist.Columns.Add("CablesSerialNumber");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model2.A246CCheckListWristStrapResults)
                {




                    dtChecklist.Rows.Add(Uid, row.StationId, row.Value);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                int i = _checkResult.InsertBulkA246CWristStrapCheckList(dtChecklist, Session["EmpNumber"].ToString(), model2.LineId, model2.ProdLineLeader, model2.CheckedBy, model2.ApprovedBy, model2.ModelId, model2.PartId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("A246CWristStrapCheckList");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            model2.dtChecklist = _checkResult.GetFormByA246CWristStrap(model2.ProjectId, model2.LineId);
            model2.Lines = (List<Line>)Session["Lines"];
            model2.Shifts = (List<Shift>)Session["Shifts"];
            model2.Projects = (List<DOL.Project>)Session["Projects"];
            model2.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model2.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            //model2.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            return View("A246CWristStrapCheckList", model2);
        }

        [HttpGet]
        public ActionResult A246CEquipmentCheckList()
        {
            A246CEquipmentCheckListModelView model = new A246CEquipmentCheckListModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            //model.Machines = _CheckListCircuitRecord.GetA246CMachines();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            //Session["Machines"] = model.Machines;
            //Session["ModelNos"] = model.ModelNos;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult A246CEquipmentCheckList(A246CEquipmentCheckListModelView model1)
        {

            if (!ModelState.IsValid)
                return View(model1);

            try
            {
                model1.dtChecklist = _checkResult.GetA246CFormByEquipment(model1.ProjectId, model1.LineId);
                model1.Lines = (List<Line>)Session["Lines"];
                model1.Shifts = (List<Shift>)Session["Shifts"];
                model1.Projects = (List<DOL.Project>)Session["Projects"];
                model1.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model1.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                //model1.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model1);

            //return RedirectToAction("ChecklistResults");
        }

        [HttpPost]
        public ActionResult SaveA246CEquipmentCheckList(A246CEquipmentCheckListModelView model2)
        {
            DataTable dtChecklist = new DataTable("A246CEquipmentCheckListResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("StationId");
            dtChecklist.Columns.Add("Value");

            //dtChecklist.Columns.Add("InspectionResults");
            //dtChecklist.Columns.Add("CablesSerialNumber");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model2.A246CEquipmentCheckListResults)
                {




                    dtChecklist.Rows.Add(Uid, row.StationId, row.Value);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                int i = _checkResult.InsertBulkA246CEquipmentCheckList(dtChecklist, Session["EmpNumber"].ToString(), model2.LineId, model2.ProdLineLeader, model2.CheckedBy, model2.ApprovedBy, model2.ModelId, model2.PartId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("A246CEquipmentCheckList");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            model2.dtChecklist = _checkResult.GetA246CFormByEquipment(model2.ProjectId, model2.LineId);
            model2.Lines = (List<Line>)Session["Lines"];
            model2.Shifts = (List<Shift>)Session["Shifts"];
            model2.Projects = (List<DOL.Project>)Session["Projects"];
            model2.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model2.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            //model2.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            return View("A246CEquipmentCheckList", model2);
        }

        [HttpGet]
        public ActionResult A246CCheckListLightLuxInspection()
        {
            A246CEquipmentCheckListModelView model = new A246CEquipmentCheckListModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            //model.Machines = _CheckListCircuitRecord.GetA246CMachines();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            //Session["Machines"] = model.Machines;
            //Session["ModelNos"] = model.ModelNos;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult A246CCheckListLightLuxInspection(A246CEquipmentCheckListModelView model1)
        {

            if (!ModelState.IsValid)
                return View(model1);

            try
            {
                model1.dtChecklist = _checkResult.GetFormByA246CCheckListLightLuxInspection(model1.ProjectId, model1.LineId);
                model1.Lines = (List<Line>)Session["Lines"];
                model1.Shifts = (List<Shift>)Session["Shifts"];
                model1.Projects = (List<DOL.Project>)Session["Projects"];
                model1.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model1.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                //model1.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model1);

            //return RedirectToAction("ChecklistResults");
        }

        [HttpPost]
        public ActionResult SaveA246CCheckListLightLuxInspection(A246CEquipmentCheckListModelView model2)
        {
            DataTable dtChecklist = new DataTable("A246CEquipmentCheckListResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("StationId");
            dtChecklist.Columns.Add("Value");

            //dtChecklist.Columns.Add("InspectionResults");
            //dtChecklist.Columns.Add("CablesSerialNumber");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model2.A246CEquipmentCheckListResults)
                {




                    dtChecklist.Rows.Add(Uid, row.StationId, row.Value);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                int i = _checkResult.InsertBulkA246CCheckListLightLuxInspection(dtChecklist, Session["EmpNumber"].ToString(), model2.LineId, model2.ProdLineLeader, model2.CheckedBy, model2.ApprovedBy, model2.ModelId, model2.PartId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("A246CCheckListLightLuxInspection");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            model2.dtChecklist = _checkResult.GetFormByA246CCheckListLightLuxInspection(model2.ProjectId, model2.LineId);
            model2.Lines = (List<Line>)Session["Lines"];
            model2.Shifts = (List<Shift>)Session["Shifts"];
            model2.Projects = (List<DOL.Project>)Session["Projects"];
            model2.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model2.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            //model2.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            return View("A246CCheckListLightLuxInspection", model2);
        }

        [HttpGet]
        public ActionResult A246CCheckListLightLuxNonInspection()
        {
            A246CEquipmentCheckListModelView model = new A246CEquipmentCheckListModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            //model.Machines = _CheckListCircuitRecord.GetA246CMachines();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            //Session["Machines"] = model.Machines;
            //Session["ModelNos"] = model.ModelNos;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult A246CCheckListLightLuxNonInspection(A246CEquipmentCheckListModelView model1)
        {

            if (!ModelState.IsValid)
                return View(model1);

            try
            {
                model1.dtChecklist = _checkResult.GetFormByA246CCheckListLightLuxNonInspection(model1.ProjectId, model1.LineId);
                model1.Lines = (List<Line>)Session["Lines"];
                model1.Shifts = (List<Shift>)Session["Shifts"];
                model1.Projects = (List<DOL.Project>)Session["Projects"];
                model1.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model1.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                //model1.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model1);

            //return RedirectToAction("ChecklistResults");
        }
        [HttpPost]
        public ActionResult SaveA246CCheckListLightLuxNonInspection(A246CEquipmentCheckListModelView model2)
        {
            DataTable dtChecklist = new DataTable("A246CEquipmentCheckListResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("StationId");
            dtChecklist.Columns.Add("Value");

            //dtChecklist.Columns.Add("InspectionResults");
            //dtChecklist.Columns.Add("CablesSerialNumber");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model2.A246CEquipmentCheckListResults)
                {




                    dtChecklist.Rows.Add(Uid, row.StationId, row.Value);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                int i = _checkResult.InsertBulkA246CCheckListLightLuxNonInspection(dtChecklist, Session["EmpNumber"].ToString(), model2.LineId, model2.ProdLineLeader, model2.CheckedBy, model2.ApprovedBy, model2.ModelId, model2.PartId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("A246CCheckListLightLuxNonInspection");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            model2.dtChecklist = _checkResult.GetFormByA246CCheckListLightLuxNonInspection(model2.ProjectId, model2.LineId);
            model2.Lines = (List<Line>)Session["Lines"];
            model2.Shifts = (List<Shift>)Session["Shifts"];
            model2.Projects = (List<DOL.Project>)Session["Projects"];
            model2.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model2.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            //model2.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            return View("A246CCheckListLightLuxNonInspection", model2);
        }

        [HttpGet]
        public ActionResult A246CCheckSurfaceImpedence()
        {
            A246CEquipmentCheckListModelView model = new A246CEquipmentCheckListModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            //model.Machines = _CheckListCircuitRecord.GetA246CMachines();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            //Session["Machines"] = model.Machines;
            //Session["ModelNos"] = model.ModelNos;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult A246CCheckSurfaceImpedence(A246CEquipmentCheckListModelView model1)
        {

            if (!ModelState.IsValid)
                return View(model1);

            try
            {
                model1.dtChecklist = _checkResult.GetFormByA246CCheckSurfaceImpedence(model1.ProjectId, model1.LineId);
                model1.Lines = (List<Line>)Session["Lines"];
                model1.Shifts = (List<Shift>)Session["Shifts"];
                model1.Projects = (List<DOL.Project>)Session["Projects"];
                model1.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model1.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                //model1.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model1);

            //return RedirectToAction("ChecklistResults");
        }

        [HttpPost]
        public ActionResult SaveA246CCheckSurfaceImpedence(A246CEquipmentCheckListModelView model2)
        {
            DataTable dtChecklist = new DataTable("A246CEquipmentCheckListResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("StationId");
            dtChecklist.Columns.Add("Value");

            //dtChecklist.Columns.Add("InspectionResults");
            //dtChecklist.Columns.Add("CablesSerialNumber");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model2.A246CEquipmentCheckListResults)
                {




                    dtChecklist.Rows.Add(Uid, row.StationId, row.Value);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                int i = _checkResult.InsertBulkA246CCheckSurfaceImpedence(dtChecklist, Session["EmpNumber"].ToString(), model2.LineId, model2.ProdLineLeader, model2.CheckedBy, model2.ApprovedBy, model2.ModelId, model2.PartId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("A246CCheckSurfaceImpedence");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            model2.dtChecklist = _checkResult.GetFormByA246CCheckSurfaceImpedence(model2.ProjectId, model2.LineId);
            model2.Lines = (List<Line>)Session["Lines"];
            model2.Shifts = (List<Shift>)Session["Shifts"];
            model2.Projects = (List<DOL.Project>)Session["Projects"];
            model2.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model2.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            //model2.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            return View("A246CCheckSurfaceImpedence", model2);
        }

        [HttpGet]
        public ActionResult A246CCheckTableMatESD()
        {
            A246CEquipmentCheckListModelView model = new A246CEquipmentCheckListModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            //model.Machines = _CheckListCircuitRecord.GetA246CMachines();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            //Session["Machines"] = model.Machines;
            //Session["ModelNos"] = model.ModelNos;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult A246CCheckTableMatESD(A246CEquipmentCheckListModelView model1)
        {

            if (!ModelState.IsValid)
                return View(model1);

            try
            {
                model1.dtChecklist = _checkResult.GetFormByA246CCheckTableMatESD(model1.ProjectId, model1.LineId);
                model1.Lines = (List<Line>)Session["Lines"];
                model1.Shifts = (List<Shift>)Session["Shifts"];
                model1.Projects = (List<DOL.Project>)Session["Projects"];
                model1.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model1.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                //model1.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model1);

            //return RedirectToAction("ChecklistResults");
        }

        [HttpPost]
        public ActionResult SaveA246CCheckTableMatESD(A246CEquipmentCheckListModelView model2)
        {
            DataTable dtChecklist = new DataTable("A246CEquipmentCheckListResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("StationId");
            dtChecklist.Columns.Add("Value");

            //dtChecklist.Columns.Add("InspectionResults");
            //dtChecklist.Columns.Add("CablesSerialNumber");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model2.A246CEquipmentCheckListResults)
                {




                    dtChecklist.Rows.Add(Uid, row.StationId, row.Value);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                int i = _checkResult.InsertBulkA246CCheckTableMatESD(dtChecklist, Session["EmpNumber"].ToString(), model2.LineId, model2.ProdLineLeader, model2.CheckedBy, model2.ApprovedBy, model2.ModelId, model2.PartId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("A246CCheckTableMatESD");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            model2.dtChecklist = _checkResult.GetFormByA246CCheckTableMatESD(model2.ProjectId, model2.LineId);
            model2.Lines = (List<Line>)Session["Lines"];
            model2.Shifts = (List<Shift>)Session["Shifts"];
            model2.Projects = (List<DOL.Project>)Session["Projects"];
            model2.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model2.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            //model2.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            return View("A246CCheckTableMatESD", model2);
        }


        [HttpGet]
        public ActionResult A246CDestructiveMachineCheckList()
        {
            A246CDestructiveMachineCheckListModelView model = new A246CDestructiveMachineCheckListModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.Machines = _CheckListCircuitRecord.GetA246CMachines();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Machines"] = model.Machines;
            //Session["ModelNos"] = model.ModelNos;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult A246CDestructiveMachineCheckList(A246CDestructiveMachineCheckListModelView model)
        {
            //model1.dtChecklist = _checkResult.GetFromByA246CCMMC1Dataa(model1.LineId, model1.ProjectId, model1.MachineId);
            //model1.Lines = (List<Line>)Session["Lines"];
            //model1.Shifts = (List<Shift>)Session["Shifts"];
            //model1.Projects = (List<DOL.Project>)Session["Projects"];
            //model1.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            //model1.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            //model1.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            //Session["Lines"] = model1.Lines;
            //Session["Shifts"] = model1.Shifts;
            //Session["ModelNos"] = model1.ModelNos;
            //Session["PartNos"] = model1.PartNos;
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                model.dtChecklist = _checkResult.GetFromByA246CDestructiveMachineCheckList(model.LineId, model.ProjectId, model.MachineId);
                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                model.Projects = (List<DOL.Project>)Session["Projects"];
                model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                model.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model);

            //return RedirectToAction("ChecklistResults");
        }

        [HttpPost]
        public ActionResult SaveA246CDestructiveMachineCheckList(A246CDestructiveMachineCheckListModelView model)
        {
            DataTable dtChecklist = new DataTable("A246CDestructiveMachineCheckListResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("DestructiveId");
            dtChecklist.Columns.Add("Value");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.A246CDestructiveMachineCheckListResults)
                {




                    dtChecklist.Rows.Add(Uid, row.DestructiveId, row.Value);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                int i = _checkResult.InsertBulkA246CDestructiveMachineCheckList(dtChecklist, Session["EmpNumber"].ToString(), model.LineId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.ModelId, model.PartId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("A246CDestructiveMachineCheckList");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            model.dtChecklist = _checkResult.GetFromByA246CDestructiveMachineCheckList(model.LineId, model.ProjectId, model.MachineId);
            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            model.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            return View("A246CDestructiveMachineCheckList", model);
        }

        [HttpGet]
        public ActionResult A246CDMachineCheckList()
        {
            A246CDestructiveMachineCheckListModelView model = new A246CDestructiveMachineCheckListModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.Machines = _CheckListCircuitRecord.GetA246CMachines();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Machines"] = model.Machines;
            //Session["ModelNos"] = model.ModelNos;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult A246CDMachineCheckList(A246CDestructiveMachineCheckListModelView model)
        {
            //model1.dtChecklist = _checkResult.GetFromByA246CCMMC1Dataa(model1.LineId, model1.ProjectId, model1.MachineId);
            //model1.Lines = (List<Line>)Session["Lines"];
            //model1.Shifts = (List<Shift>)Session["Shifts"];
            //model1.Projects = (List<DOL.Project>)Session["Projects"];
            //model1.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            //model1.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            //model1.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            //Session["Lines"] = model1.Lines;
            //Session["Shifts"] = model1.Shifts;
            //Session["ModelNos"] = model1.ModelNos;
            //Session["PartNos"] = model1.PartNos;
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                model.dtChecklist = _checkResult.GetFromByA246CDMachineCheckList(model.LineId, model.ProjectId, model.MachineId);
                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                model.Projects = (List<DOL.Project>)Session["Projects"];
                model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                model.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model);

            //return RedirectToAction("ChecklistResults");
        }

        [HttpPost]
        public ActionResult SaveA246CDMachineCheckList(A246CDestructiveMachineCheckListModelView model)
        {
            DataTable dtChecklist = new DataTable("A246CDestructiveMachineCheckListResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("DestructiveId");
            dtChecklist.Columns.Add("Value");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.A246CDestructiveMachineCheckListResults)
                {




                    dtChecklist.Rows.Add(Uid, row.DestructiveId, row.Value);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                int i = _checkResult.InsertBulkA246CDMachineCheckList(dtChecklist, Session["EmpNumber"].ToString(), model.LineId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.ModelId, model.PartId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("A246CDMachineCheckList");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            model.dtChecklist = _checkResult.GetFromByA246CDMachineCheckList(model.LineId, model.ProjectId, model.MachineId);
            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            model.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            return View("A246CDMachineCheckList", model);
        }

        [HttpGet]
        public ActionResult A246CNewHankingSheet()
        {
            A246CNewHankingSheetCheckListModelView model = new A246CNewHankingSheetCheckListModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.Machines = _CheckListCircuitRecord.GetA246CMachines();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Machines"] = model.Machines;
            //Session["ModelNos"] = model.ModelNos;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult A246CNewHankingSheet(A246CNewHankingSheetCheckListModelView model1)
        {
            //model1.dtChecklist = _checkResult.GetFromByA246CCMMC1Dataa(model1.LineId, model1.ProjectId, model1.MachineId);
            //model1.Lines = (List<Line>)Session["Lines"];
            //model1.Shifts = (List<Shift>)Session["Shifts"];
            //model1.Projects = (List<DOL.Project>)Session["Projects"];
            //model1.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            //model1.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            //model1.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            //Session["Lines"] = model1.Lines;
            //Session["Shifts"] = model1.Shifts;
            //Session["ModelNos"] = model1.ModelNos;
            //Session["PartNos"] = model1.PartNos;
            if (!ModelState.IsValid)
                return View(model1);

            try
            {
                model1.dtChecklist = _checkResult.GetFromByA246CNewHankingData(model1.ProjectId, model1.LineId,model1.MachineId,model1.PartId);
                model1.Lines = (List<Line>)Session["Lines"];
                model1.Shifts = (List<Shift>)Session["Shifts"];
                model1.Projects = (List<DOL.Project>)Session["Projects"];
                model1.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model1.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                model1.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model1);

            //return RedirectToAction("ChecklistResults");
        }
        [HttpPost]
        public ActionResult SaveA246CNewHankingSheet(A246CNewHankingSheetCheckListModelView model2)
        {
            DataTable dtChecklist = new DataTable("A246CNewHankingSheetCheckListResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("SectionId");
            dtChecklist.Columns.Add("Value1");
            dtChecklist.Columns.Add("Value2");
            dtChecklist.Columns.Add("Value3");
            dtChecklist.Columns.Add("Value4");
            dtChecklist.Columns.Add("Value5");
            dtChecklist.Columns.Add("InspectionResults");
            //Columns.Add("CablesSerialNumber");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model2.A246CNewHankingSheetCheckListResults)
                {




                    dtChecklist.Rows.Add(Uid, row.SectionId, row.Value1, row.Value2, row.Value3, row.Value4, row.Value5);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                int i = _checkResult.InsertBulkA246CNewHankingCheckList(dtChecklist, Session["EmpNumber"].ToString(), model2.LineId, model2.ProdLineLeader, model2.CheckedBy, model2.ApprovedBy, model2.ModelId, model2.PartId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("A246CNewHankingSheet");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            model2.dtChecklist = _checkResult.GetFromByA246CNewHankingData(model2.ProjectId, model2.LineId, model2.MachineId, model2.PartId);
            model2.Lines = (List<Line>)Session["Lines"];
            model2.Shifts = (List<Shift>)Session["Shifts"];
            model2.Projects = (List<DOL.Project>)Session["Projects"];
            model2.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model2.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            model2.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            return View("A246CNewHankingSheet", model2);
        }

        [HttpGet]
        public ActionResult A246CWeighingMachineCheckList()
        {
            A246CDestructiveMachineCheckListModelView model = new A246CDestructiveMachineCheckListModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.Machines = _CheckListCircuitRecord.GetA246CMachines();
            model.OKNG = _objRpt.GETA246COKNG();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Machines"] = model.Machines;
            Session["OKNG"] = model.OKNG;
            //Session["ModelNos"] = model.ModelNos;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult A246CWeighingMachineCheckList(A246CDestructiveMachineCheckListModelView model)
        {
            //model1.dtChecklist = _checkResult.GetFromByA246CCMMC1Dataa(model1.LineId, model1.ProjectId, model1.MachineId);
            //model1.Lines = (List<Line>)Session["Lines"];
            //model1.Shifts = (List<Shift>)Session["Shifts"];
            //model1.Projects = (List<DOL.Project>)Session["Projects"];
            //model1.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            //model1.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            //model1.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            //Session["Lines"] = model1.Lines;
            //Session["Shifts"] = model1.Shifts;
            //Session["ModelNos"] = model1.ModelNos;
            //Session["PartNos"] = model1.PartNos;
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                model.dtChecklist = _checkResult.GetFromByA246CWeighingMachineCheckList(model.LineId, model.ProjectId, model.MachineId);
                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                model.Projects = (List<DOL.Project>)Session["Projects"];
                model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                model.Machines = (List<DOL.A246CMachines>)Session["Machines"];
                model.OKNG = (List<DOL.A246COKNG>)Session["OKNG"];
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model);

            //return RedirectToAction("ChecklistResults");
        }
        [HttpPost]
        public ActionResult SaveA246CWeighingMachineCheckList(A246CDestructiveMachineCheckListModelView model)
        {
            DataTable dtChecklist = new DataTable("A246CDestructiveMachineCheckListResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("WeighingeId");
            dtChecklist.Columns.Add("Value");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.A246CDestructiveMachineCheckListResults)
                {




                    dtChecklist.Rows.Add(Uid, row.WeighingeId, row.Value);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                int i = _checkResult.InsertBulkA246CWeighingMachineCheckList(dtChecklist, Session["EmpNumber"].ToString(), model.LineId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.ModelId, model.PartId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("A246CWeighingMachineCheckList");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            model.dtChecklist = _checkResult.GetFromByA246CWeighingMachineCheckList(model.LineId, model.ProjectId, model.MachineId);
            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            model.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            return View("A246CWeighingMachineCheckList", model);
        }

        [HttpGet]
        public ActionResult CheckListA246CPartToInspect()
        {
            CheckLisA246CPartToInspectModelView model = new CheckLisA246CPartToInspectModelView();
            model.dtChecklist = new DataTable();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Shifts"] = model.Shifts;
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            //Session["ModelNos"] = model.ModelNos;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult CheckListA246CPartToInspect(CheckLisA246CPartToInspectModelView model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                model.dtChecklist = _checkNative.GetFormByA246CPartToInspect(model.LineId, model.ProjectId);
                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                model.Projects = (List<DOL.Project>)Session["Projects"];
                model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                Session["Lines"] = model.Lines;
                Session["Shifts"] = model.Shifts;
                Session["ModelNos"] = model.ModelNos;
                Session["PartNos"] = model.PartNos;

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveA246CPartToInspect(CheckLisA246CPartToInspectModelView model)
        {
            DataTable dtChecklist = new DataTable("A246CPartToInspectCheckListResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("InspectId");
            dtChecklist.Columns.Add("InspectorName");
            dtChecklist.Columns.Add("InspectorId");
            dtChecklist.Columns.Add("ActualValue");
            //  dtChecklist.Columns.Add("LineId");
            //dtChecklist.Columns.Add("Result");
            //dtCheckListItem.Columns.Add("SeveryId");



            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.A246CPartToInspectCheckListResults)
                {




                    dtChecklist.Rows.Add(Uid, row.InspectId, row.InspectorName, row.InspectorId, row.ActualValue);
                    Uid++;

                }

                int i = _checkNative.InsertBulkA246CPartToInspectCheckList(dtChecklist, Session["EmpNumber"].ToString(), model.LineId, model.ProjectId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.ModelId, model.PartId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("CheckListA246CPartToInspect");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            model.dtChecklist = _checkNative.GetFormByA246CPartToInspect(model.LineId, model.ProjectId);
            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            return View("CheckListA246CPartToInspect", model);
        }


        

        [HttpGet]
        public ActionResult A246CCTPaameterMCChecklist()
        {
            AA246CCTPaameterMCChecklist1ModelView model = new AA246CCTPaameterMCChecklist1ModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.Machines = _CheckListCircuitRecord.GetA246CMachines();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Machines"] = model.Machines;
            //Session["ModelNos"] = model.ModelNos;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult A246CCTPaameterMCChecklist(AA246CCTPaameterMCChecklist1ModelView model)
        {
            //model1.dtChecklist = _checkResult.GetFromByA246CCMMC1Dataa(model1.LineId, model1.ProjectId, model1.MachineId);
            //model1.Lines = (List<Line>)Session["Lines"];
            //model1.Shifts = (List<Shift>)Session["Shifts"];
            //model1.Projects = (List<DOL.Project>)Session["Projects"];
            //model1.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            //model1.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            //model1.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            //Session["Lines"] = model1.Lines;
            //Session["Shifts"] = model1.Shifts;
            //Session["ModelNos"] = model1.ModelNos;
            //Session["PartNos"] = model1.PartNos;
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                model.dtChecklist = _checkResult.GetFromByA246CCTPaameterMCChecklist(model.ProjectId, model.LineId, model.MachineId);
                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                model.Projects = (List<DOL.Project>)Session["Projects"];
                model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                model.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model);

            //return RedirectToAction("ChecklistResults");
        }

        [HttpPost]
        public ActionResult SaveA246CCTPaameterMCChecklist(AA246CCTPaameterMCChecklist1ModelView model)
        {
            DataTable dtChecklist = new DataTable("A246CCTPaameterMCChecklist1Results");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("LimitId");
            dtChecklist.Columns.Add("Value");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.A246CCTPaameterMCChecklist1Results)
                {




                    dtChecklist.Rows.Add(Uid, row.LimitId, row.Value);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                int i = _checkResult.InsertBulkA246CCTPaameterMCChecklist(dtChecklist, Session["EmpNumber"].ToString(), model.LineId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.ModelId, model.PartId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("A246CCTPaameterMCChecklist");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            model.dtChecklist = _checkResult.GetFromByA246CCTPaameterMCChecklist(model.LineId, model.ProjectId, model.MachineId);
            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            model.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            return View("A246CCTPaameterMCChecklist", model);
        }


        [HttpGet]
        public ActionResult ProdQualityAuditChecklist()
        {
            ProdCheckListQualityAuditModelView model = new ProdCheckListQualityAuditModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.ProdVerifies = _objProject2.GetVerifiedBy();
            model.ProdApproves = _objProject2.GetApprovedBy();
            model.ProdAudits = _objProject2.GetAuditBy();
            model.prodChecks = _objProject2.GetCheckedBy();
            //model.Machines = _CheckListCircuitRecord.GetA246CMachines();
            model.ProdShiftLeaders = new List<DOL.ProdShiftLeader>();
            model.Batches = new List<DOL.Batch>();
            model.Zones = new List<DOL.Zone>();
            model.Modules = new List<ProdModule>();
            model.LineLeaders = new List<ProductionLineLeader>();
            model.Statuses = _CheckListCircuitRecord.GetResult();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;

            Session["ProdVerifies"] = model.ProdVerifies;
            Session["ProdApproves"] = model.ProdApproves;
            Session["ProdAudits"] = model.ProdAudits;
            Session["prodChecks"] = model.prodChecks;
            
            return View(model);
        }

        [HttpPost]
        public ActionResult ProdQualityAuditChecklist(ProdCheckListQualityAuditModelView model)
        {

            model.dtChecklist = _checkResult.GetFormByProdQualityAudit(model.LineId, model.ProjectId, model.BatchId, model.ZoneId, model.ModuleId);
            model.Statuses = _CheckListCircuitRecord.GetResult();
            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.Batches = (List<DOL.Batch>)Session["Batches"];
            model.Zones = (List<DOL.Zone>)Session["Zones"];
            model.Modules = (List<DOL.ProdModule>)Session["ProdModules"];
            model.LineLeaders = (List<DOL.ProductionLineLeader>)Session["ProductionLineLeaders"];

            model.ProdVerifies = (List<DOL.ProdVerifiedBy>)Session["ProdVerifies"];

            model.ProdApproves = (List<DOL.ProdApprovedBy>)Session["ProdApproves"];

            model.ProdAudits = (List<DOL.ProdAuditBy>)Session["ProdAudits"];

            model.prodChecks = (List<DOL.prodCheckedBy>)Session["prodChecks"];

            model.ProdShiftLeaders = (List<DOL.ProdShiftLeader>)Session["ProdShiftLeaders"];

            if (!ModelState.IsValid)
                return View(model);

            

            try
            {
                model.dtChecklist = _checkResult.GetFormByProdQualityAudit(model.LineId, model.ProjectId, model.BatchId, model.ZoneId, model.ModuleId);
                model.Statuses = _CheckListCircuitRecord.GetResult();
                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                model.Projects = (List<DOL.Project>)Session["Projects"];
                model.Batches = (List<DOL.Batch>)Session["Batches"];
                model.Zones = (List<DOL.Zone>)Session["Zones"];
                model.Modules = (List<DOL.ProdModule>)Session["ProdModules"];
                model.ProductionLineLeaders = (List<DOL.ProductionLineLeader>)Session["ProductionLineLeaders"];

                model.LineLeaders = (List<DOL.ProductionLineLeader>)Session["ProductionLineLeaders"];

                model.ProdVerifies = (List<DOL.ProdVerifiedBy>)Session["ProdVerifies"];

                model.ProdApproves = (List<DOL.ProdApprovedBy>)Session["ProdApproves"];

                model.ProdAudits = (List<DOL.ProdAuditBy>)Session["ProdAudits"];

                model.prodChecks = (List<DOL.prodCheckedBy>)Session["prodChecks"];
                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model);

            //return RedirectToAction("ChecklistResults");
        }


        [HttpPost]
        public ActionResult SaveProdQualityAuditChecklist(ProdCheckListQualityAuditModelView model)
        {
            DataTable dtChecklist = new DataTable("ProdCheckListQualityAuditResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("RiskId");
            dtChecklist.Columns.Add("StatusId");
            dtChecklist.Columns.Add("Namee");
            dtChecklist.Columns.Add("Image");
            //dtChecklist.Columns.Add("OneS");
            //dtChecklist.Columns.Add("TwoS");
            //dtChecklist.Columns.Add("ThreeS");
            //dtChecklist.Columns.Add("FourS");
            //dtChecklist.Columns.Add("FiveS");
            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.ProdCheckListQualityAuditResults)
                {




                    dtChecklist.Rows.Add(Uid, row.RiskId, row.StatusId, row.Namee, row.Image);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                int i = _checkResult.InsertBulkProdQualityAuditCheckList(dtChecklist, Session["EmpNumber"].ToString(), model.LineId, model.ProjectId, model.BatchId, model.ShiftLeaderId, model.VerifiedId, model.CheckedBy, model.ApprovedId, model.AuditId,model.ZoneId, model.ProdId);

                DataTable dt = _checkResult.GetRpt_getParameterProdQualityAuditFORALL();
                if (i > 0)
                {
                    //DataTable dt = new DataTable();
                    if (dt.Rows.Count > 0 && dt.Rows[0]["Status"].ToString() == "NG")
                    {
                        objmail3.NotificationEmail(0, "Production_Tpt@foxlink.com");
                    }
                    

                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("ProdQualityAuditChecklist");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            model.dtChecklist = _checkResult.GetFormByProdQualityAudit(model.LineId, model.ProjectId, model.BatchId, model.ZoneId, model.ModuleId);
            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.Batches = (List<DOL.Batch>)Session["Batches"];
            model.Zones = (List<DOL.Zone>)Session["Zones"];
            model.Modules = (List<DOL.ProdModule>)Session["ProdModules"];
            model.ProductionLineLeaders = (List<DOL.ProductionLineLeader>)Session["ProductionLineLeaders"];
            model.Statuses = _CheckListCircuitRecord.GetResult();

            model.LineLeaders = (List<DOL.ProductionLineLeader>)Session["ProductionLineLeaders"];

            model.ProdVerifies = (List<DOL.ProdVerifiedBy>)Session["ProdVerifies"];

            model.ProdApproves = (List<DOL.ProdApprovedBy>)Session["ProdApproves"];

            model.ProdAudits = (List<DOL.ProdAuditBy>)Session["ProdAudits"];

            model.prodChecks = (List<DOL.prodCheckedBy>)Session["prodChecks"];

            model.ProdShiftLeaders = (List<DOL.ProdShiftLeader>)Session["ProdShiftLeaders"];

            return View("ProdQualityAuditChecklist", model);
        }


        [HttpGet]
        public ActionResult A246CCTParameterMCChecklistLine1()
        {
            InsertBulkA246CCTParameterMCChecklistLine1ModelView model = new InsertBulkA246CCTParameterMCChecklistLine1ModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            model.Machines = _CheckListCircuitRecord.GetA246CMachines();
            model.ModelNos = new List<DOL.ModelNo>();
            model.PartNos = new List<DOL.PartNo>();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;
            Session["Machines"] = model.Machines;
            //Session["ModelNos"] = model.ModelNos;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult A246CCTParameterMCChecklistLine1(InsertBulkA246CCTParameterMCChecklistLine1ModelView model)
        {
            //model1.dtChecklist = _checkResult.GetFromByA246CCMMC1Dataa(model1.LineId, model1.ProjectId, model1.MachineId);
            //model1.Lines = (List<Line>)Session["Lines"];
            //model1.Shifts = (List<Shift>)Session["Shifts"];
            //model1.Projects = (List<DOL.Project>)Session["Projects"];
            //model1.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            //model1.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            //model1.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            //Session["Lines"] = model1.Lines;
            //Session["Shifts"] = model1.Shifts;
            //Session["ModelNos"] = model1.ModelNos;
            //Session["PartNos"] = model1.PartNos;
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                model.dtChecklist = _checkResult.GetFromByA246CParameterNameCheckListOne(model.ProjectId, model.LineId, model.MachineId);
                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                model.Projects = (List<DOL.Project>)Session["Projects"];
                model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
                model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
                model.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model);

            //return RedirectToAction("ChecklistResults");
        }

        [HttpPost]
        public ActionResult SaveA246CCTParameterMCChecklistLine1(InsertBulkA246CCTParameterMCChecklistLine1ModelView model)
        {
            DataTable dtChecklist = new DataTable("A246CCTParameterMCChecklistLine1");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("ParameterId");
            dtChecklist.Columns.Add("Value");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.A246CCTParameterMCChecklistLine1)
                {




                    dtChecklist.Rows.Add(Uid, row.ParameterId, row.Value);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                int i = _checkResult.InsertBulkA246CCTParameterMCChecklistLine1(dtChecklist, Session["EmpNumber"].ToString(), model.LineId, model.ProdLineLeader, model.CheckedBy, model.ApprovedBy, model.ModelId, model.PartId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("A246CCTParameterMCChecklistLine1");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            model.dtChecklist = _checkResult.GetFromByA246CParameterNameCheckListOne(model.LineId, model.ProjectId, model.MachineId);
            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];
            model.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            return View("A246CCTParameterMCChecklistLine1", model);
        }

        [HttpGet]
        public ActionResult CheckListOutGoingInspectionA246C()
        {
            OutGoingInspectionResultModelView model = new OutGoingInspectionResultModelView();
            model.dtChecklist = new DataTable();
            model.Lines = _checkResult.GetLine();
            model.Projects = _CheckListCircuitRecord.GetProject();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;

            //Session["Getproject"] = model.dtChecklist;
            return View(model);
        }

        [HttpPost]
        public ActionResult CheckListOutGoingInspectionA246C(OutGoingInspectionResultModelView model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                model.dtChecklist = _checkNative.GetFormByOutInspection(model.ProjectId);
                model.Lines = (List<Line>)Session["Lines"];
                model.Projects = (List<DOL.Project>)Session["Projects"];

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveOutGoingInspectionA246C(OutGoingInspectionResultModelView model)
        {
            DataTable dtChecklist = new DataTable("CheckListoutGoingInspectionResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("ItemId");
            dtChecklist.Columns.Add("SpecId");
            dtChecklist.Columns.Add("ContentId");
            dtChecklist.Columns.Add("Result");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.CheckListoutGoingInspectionResults)
                {




                    dtChecklist.Rows.Add(Uid, row.ItemId, row.SpecId, row.ContentId, row.Result);
                    Uid++;

                }




                int i = _checkNative.InsertCheckListOutInspectionA246C(dtChecklist, Session["EmpNumber"].ToString(), model.LineId, model.ProjectId, model.CheckedBy, model.ApprovedBy, model.CustomerPin, model.LotSize, model.FinishedProductNo, model.Rev, model.PackingListNo,model.SimToolPartNumber, model.InspectResult);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("CheckListOutGoingInspection");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            model.dtChecklist = _checkNative.GetFormByOutInspection(model.ProjectId);
            model.Lines = (List<Line>)Session["Lines"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            return View("CheckListOutGoingInspection", model);
        }

        [HttpGet]
        public ActionResult ProdQualityAuditChecklistWith5S()
        {
            ProdCheckListQualityAuditModelView model = new ProdCheckListQualityAuditModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject();
            model.Lines = _checkResult.GetLine();
            model.Shifts = _checkResult.GetShift();
            model.Projects = _CheckListCircuitRecord.GetProject();
            //model.Machines = _CheckListCircuitRecord.GetA246CMachines();
            model.Batches = new List<DOL.Batch>();
            model.Zones = new List<DOL.Zone>();
            model.Modules = new List<ProdModule>();
            model.LineLeaders = new List<ProductionLineLeader>();
            model.Statuses = _CheckListCircuitRecord.GetResult();
            Session["Projects"] = model.Projects;
            Session["Lines"] = model.Lines;

            return View(model);
        }

        [HttpPost]
        public ActionResult ProdQualityAuditChecklistWith5S(ProdCheckListQualityAuditModelView model)
        {

            model.dtChecklist = _checkResult.GetFormByProdQualityAuditWith5S(model.LineId, model.ProjectId, model.BatchId, model.ZoneId, model.ModuleId);
            model.Statuses = _CheckListCircuitRecord.GetResult();
            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.Batches = (List<DOL.Batch>)Session["Batches"];
            model.Zones = (List<DOL.Zone>)Session["Zones"];
            model.Modules = (List<DOL.ProdModule>)Session["ProdModules"];
            model.LineLeaders = (List<DOL.ProductionLineLeader>)Session["ProductionLineLeaders"];
            if (!ModelState.IsValid)
                return View(model);



            try
            {
                model.dtChecklist = _checkResult.GetFormByProdQualityAuditWith5S(model.LineId, model.ProjectId, model.BatchId, model.ZoneId, model.ModuleId);
                model.Statuses = _CheckListCircuitRecord.GetResult();
                model.Lines = (List<Line>)Session["Lines"];
                model.Shifts = (List<Shift>)Session["Shifts"];
                model.Projects = (List<DOL.Project>)Session["Projects"];
                model.Batches = (List<DOL.Batch>)Session["Batches"];
                model.Zones = (List<DOL.Zone>)Session["Zones"];
                model.Modules = (List<DOL.ProdModule>)Session["ProdModules"];
                model.ProductionLineLeaders = (List<DOL.ProductionLineLeader>)Session["ProductionLineLeaders"];

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model);

            //return RedirectToAction("ChecklistResults");
        }

        [HttpPost]
        public ActionResult SaveProdQualityAuditChecklistWith5S(ProdCheckListQualityAuditModelView model)
        {
            DataTable dtChecklist = new DataTable("ProdCheckListQualityAuditResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("RiskId");
            //dtChecklist.Columns.Add("StatusId");
            dtChecklist.Columns.Add("Namee");
            dtChecklist.Columns.Add("Image");
            dtChecklist.Columns.Add("OneS");
            dtChecklist.Columns.Add("TwoS");
            dtChecklist.Columns.Add("ThreeS");
            dtChecklist.Columns.Add("FourS");
            dtChecklist.Columns.Add("FiveS");
            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.ProdCheckListQualityAuditResults)
                {




                    dtChecklist.Rows.Add(Uid, row.RiskId, row.Namee, row.Image, row.OneS, row.TwoS, row.ThreeS, row.FourS, row.FiveS);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                int i = _checkResult.InsertBulkProdQualityAuditCheckListWith5S(dtChecklist, Session["EmpNumber"].ToString(), model.LineId, model.ProjectId, model.BatchId, model.ProdLineLeader, model.ShiftLeader, model.VerifiedBy, model.CheckedBy, model.ApprovedBy, model.AuditedBy, model.ModelId, model.ZoneId, model.ProdId);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("ProdQualityAuditChecklistWith5S");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            model.dtChecklist = _checkResult.GetFormByProdQualityAuditWith5S(model.LineId, model.ProjectId, model.BatchId, model.ZoneId, model.ModuleId);
            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.Batches = (List<DOL.Batch>)Session["Batches"];
            model.Zones = (List<DOL.Zone>)Session["Zones"];
            model.Modules = (List<DOL.ProdModule>)Session["ProdModules"];
            model.ProductionLineLeaders = (List<DOL.ProductionLineLeader>)Session["ProductionLineLeaders"];
            model.Statuses = _CheckListCircuitRecord.GetResult();

            return View("ProdQualityAuditChecklistWith5S", model);
        }

        [HttpGet]
        public ActionResult FACAProdQualityAuditChecklist()
        {
            ProdCheckListQualityAuditModelView model = new ProdCheckListQualityAuditModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject(); 
            model.Batches = _checkResult.GetBatch();
            Session["Batches"] = model.Batches;
            return View(model);
        }

        [HttpPost]
        public ActionResult FACAProdQualityAuditChecklist(ProdCheckListQualityAuditModelView model)
        {

            model.dtChecklist = _checkResult.MailParameterProdQualityAudit(model.BatchId);

            model.Batches = (List<Batch>)Session["Batches"];
            
            if (!ModelState.IsValid)
                return View(model);



            try
            {
                model.Batches = (List<Batch>)Session["Batches"];
                model.dtChecklist = _checkResult.MailParameterProdQualityAudit(model.BatchId);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model);

            //return RedirectToAction("ChecklistResults");
        }

        [HttpPost]
        public ActionResult SaveFACAProdQualityAuditChecklist(ProdCheckListQualityAuditModelView model)
        {
            DataTable dtChecklist = new DataTable("ProdCheckListQualityAuditResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("ResultId");
            dtChecklist.Columns.Add("Descrription");
            dtChecklist.Columns.Add("RootCause");
            dtChecklist.Columns.Add("CorrectiveAction");
            dtChecklist.Columns.Add("PreventiveAction");
            dtChecklist.Columns.Add("Image");
            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.ProdCheckListQualityAuditResults)
                {




                    dtChecklist.Rows.Add(Uid, row.ResultId, row.Descrription,row.RootCause,row.CorrectiveAction,row.PreventiveAction,row.Image);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                int i = _checkNative.InsertBulkFACAProdQualityAuditCheckList(dtChecklist, Session["EmpNumber"].ToString());

                if (i > 0)
                {
                    objmail.NotificationEmail("Rokeshkumar_D@foxlink.com");
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("FACAProdQualityAuditChecklist");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            model.dtChecklist = _checkResult.MailParameterProdQualityAudit(model.BatchId);

            model.Batches = (List<Batch>)Session["Batches"];
            return View("FACAProdQualityAuditChecklist", model);
        }

        

        [HttpGet]
        public ActionResult RACAProdQualityAuditChecklist()
        {
            ProdCheckListQualityAuditModelView model = new ProdCheckListQualityAuditModelView();
            model.dtChecklist = new DataTable(); // _checkResult.GetFormByProject(); 

            return View(model);
        }

        [HttpPost]
        public ActionResult RACAProdQualityAuditChecklist(ProdCheckListQualityAuditModelView model)
        {

            model.dtChecklist = _checkResult.GetProdQualityAuditForRACA();

            if (!ModelState.IsValid)
                return View(model);



            try
            {
                model.dtChecklist = _checkResult.GetProdQualityAuditForRACA();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }


            //return RedirectToAction("Index");
            return View(model);

            //return RedirectToAction("ChecklistResults");
        }


        [HttpPost]
        public ActionResult SaveRACAProdQualityAuditChecklist(ProdCheckListQualityAuditModelView model)
        {
            DataTable dtChecklist = new DataTable("ProdCheckListQualityAuditResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("FACAId");
            dtChecklist.Columns.Add("RootCause");
            dtChecklist.Columns.Add("CorrectiveAction");
            dtChecklist.Columns.Add("PreventiveAction");
            dtChecklist.Columns.Add("Image");
            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.ProdCheckListQualityAuditResults)
                {




                    dtChecklist.Rows.Add(Uid, row.FACAId, row.RootCause,row.CorrectiveAction,row.PreventiveAction, row.Image);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                int i = _checkNative.InsertBulkRACAProdQualityAuditCheckList(dtChecklist, Session["EmpNumber"].ToString());

                if (i > 0)
                {
                    objmail2.NotificationEmail("Manojkumar_K@foxlink.com");
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("RACAProdQualityAuditChecklist");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            model.dtChecklist = _checkResult.GetProdQualityAuditForRACA();

            return View("RACAProdQualityAuditChecklist", model);
        }

        [HttpGet]
        public ActionResult TodoTask()
        {
            WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
            workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
            workFlowViewModel.WorkFlowList = _checkResult.GetTodo(workFlowViewModel.EmployeeId);
            return View(workFlowViewModel);
        }

        [HttpPost]
        public ActionResult Approve(List<WorkFlowViewModel> viewModelsResult)
        {
            DataTable dtTaskListItem = new DataTable("TaskList");
            dtTaskListItem.Columns.Add("Id");
            dtTaskListItem.Columns.Add("Pid");
            dtTaskListItem.Columns.Add("FACAId");
            dtTaskListItem.Columns.Add("Applicant");
            dtTaskListItem.Columns.Add("TaskId");
            dtTaskListItem.Columns.Add("Reason");
            
            
            WorkFlowViewModel obj = new WorkFlowViewModel();

            try
            {
                int Uid = 1;
                string employeeId = Session["EmpNumber"].ToString();

                foreach (var item in viewModelsResult)
                {
                    dtTaskListItem.Rows.Add(Uid, item.Pid, item.FACAId, item.Applicant, item.TaskId, item.Reason);
                    Uid++;
                }

                DataTable dt = _checkResult.ApproveTask(dtTaskListItem);


                if (dt.Rows.Count > 0)
                {
                    //Mail mail = new Mail();



                    //if (dt.Rows[0][0].ToString() == "Final")
                    //{
                    //    Session["ResultId"] = viewModelsResult.Select(p => p.ResultId).FirstOrDefault();
                    //    mail.NotificationEmail("", Session["ResultId"].ToString(), "", 0, "Final", "");
                    //}
                    //else
                    //{
                    //    mail.NotificationEmail(dt.Rows[0]["ApproveId"].ToString(), dt.Rows[0]["Name"].ToString(), dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["Pid"]), "Approve", "");
                    //}


                  //  mail.NotificationEmail(dt.Rows[0]["ApproveId"].ToString(), dt.Rows[0]["Name"].ToString(), dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["Pid"]), "Approve", "");


                    objmail4.NotificationEmail(dt.Rows[0]["Email"].ToString(),dt.Rows[0]["ApproveId"].ToString());
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully User Created!!!";

                    return RedirectToAction("TodoTask");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                }
            }
            catch (Exception)
            {

                throw;

            }
            return RedirectToAction("TodoTask");
        }

        public ActionResult Reject(List<WorkFlowViewModel> viewModelsResult)
        {
            if (viewModelsResult.All(v => v.ApprovedId != null))
            {

                if (viewModelsResult.All(v => v.ApprovedId == "2062944"))
                {
                    DataTable dtTaskListItem1 = new DataTable("TaskList");
                    dtTaskListItem1.Columns.Add("Id");
                    dtTaskListItem1.Columns.Add("Pid");
                    dtTaskListItem1.Columns.Add("FACAId");
                    dtTaskListItem1.Columns.Add("Applicant");
                    dtTaskListItem1.Columns.Add("TaskId");
                    dtTaskListItem1.Columns.Add("Reason");
                    try
                    {
                        int Uid = 1;
                        string employeeId = Session["EmpNumber"].ToString();
                        foreach (var item in viewModelsResult)
                        {
                            dtTaskListItem1.Rows.Add(Uid, item.Pid, item.FACAId, item.Applicant, item.TaskId, item.Reason);
                            Uid++;
                        }
                        int Result = _checkResult.RejectApproval(dtTaskListItem1);
                        if (Result > 0)
                        {
                            TempData["mgs"] = "Sucess";
                            TempData["Alert"] = "Sucessfully User Created!!!";

                            return RedirectToAction("TodoTask");
                        }
                        else
                        {
                            ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                else
                {
                    DataTable dtTaskListItem = new DataTable("TaskList");
                    dtTaskListItem.Columns.Add("Id");
                    dtTaskListItem.Columns.Add("Pid");
                    dtTaskListItem.Columns.Add("FACAId");
                    dtTaskListItem.Columns.Add("Applicant");
                    dtTaskListItem.Columns.Add("ApprovedId");
                    dtTaskListItem.Columns.Add("TaskId");
                    dtTaskListItem.Columns.Add("Reason");
                    try
                    {
                        int Uid = 1;
                        string employeeId = Session["EmpNumber"].ToString();
                        foreach (var item in viewModelsResult)
                        {
                            dtTaskListItem.Rows.Add(Uid, item.Pid, item.FACAId, item.Applicant, item.ApprovedId, item.TaskId, item.Reason);
                            Uid++;
                        }

                        int Result = _checkResult.RejectApproval2(dtTaskListItem);
                        if (Result > 0)
                        {
                            TempData["mgs"] = "Sucess";
                            TempData["Alert"] = "Sucessfully User Created!!!";

                            return RedirectToAction("TodoTask");
                        }
                        else
                        {
                            ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }

             }
                
            }
            
            
            return RedirectToAction("TodoTask");
        }

        //[HttpGet]
        //public ActionResult AOITodoTask()
        //{

        //    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
        //    //WorkFlowViewModel.Menuss = _objProject.GetMasterMenus();
        //    workFlowViewModel.Menuss = _objProject.GetMasterMenus() as List<MasterMenuss>;
        //    Session["Menuss"] = workFlowViewModel.Menuss;
        //    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
        //    workFlowViewModel.WorkFlowList = _checkResult.GetTaskStatusForCAOICheckList(workFlowViewModel.EmployeeId);
        //    return View(workFlowViewModel);
        //}

        //[HttpPost]
        //public ActionResult AOIApprove(List<WorkFlowViewModel> viewModelsResult)
        //{
        //    //viewModelsResult.Menuss = (List<DOL.MasterMenuss>)Session["Menuss"];
        //    WorkFlowViewModel viewModelResult = new WorkFlowViewModel();
        //    viewModelResult.Menuss = Session["Menuss"] as List<DOL.MasterMenuss> ?? new List<DOL.MasterMenuss>();


        //    DataTable dtTaskListItem = new DataTable("TaskList");
        //    dtTaskListItem.Columns.Add("Id");
        //    dtTaskListItem.Columns.Add("Pid");
        //    dtTaskListItem.Columns.Add("ResultId");
        //    dtTaskListItem.Columns.Add("MenuId");
        //    dtTaskListItem.Columns.Add("Applicant");
        //    dtTaskListItem.Columns.Add("TaskId");
        //    dtTaskListItem.Columns.Add("Reason");


        //    WorkFlowViewModel obj = new WorkFlowViewModel();

        //    try
        //    {
        //        int Uid = 1;
        //        string employeeId = Session["EmpNumber"].ToString();

        //        foreach (var item in viewModelsResult)
        //        {
        //            dtTaskListItem.Rows.Add(Uid, item.Pid, item.ResultId,item.MenuId, item.Applicant, item.TaskId, item.Reason);
        //            Uid++;
        //        }

        //        DataTable dt = _checkResult.AOIApproveTask(dtTaskListItem);


        //        if (dt.Rows.Count > 0)
        //        {
        //            //Mail mail = new Mail();



        //            //if (dt.Rows[0][0].ToString() == "Final")
        //            //{
        //            //    Session["ResultId"] = viewModelsResult.Select(p => p.ResultId).FirstOrDefault();
        //            //    mail.NotificationEmail("", Session["ResultId"].ToString(), "", 0, "Final", "");
        //            //}
        //            //else
        //            //{
        //            //    mail.NotificationEmail(dt.Rows[0]["ApproveId"].ToString(), dt.Rows[0]["Name"].ToString(), dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["Pid"]), "Approve", "");
        //            //}


        //            //  mail.NotificationEmail(dt.Rows[0]["ApproveId"].ToString(), dt.Rows[0]["Name"].ToString(), dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["Pid"]), "Approve", "");


        //            //objmail4.NotificationEmail(dt.Rows[0]["Email"].ToString(), dt.Rows[0]["ApproveId"].ToString(), Convert.ToInt32 (dt.Rows[0]["ResultId"]));
        //            TempData["mgs"] = "Sucess";
        //            TempData["Alert"] = "Sucessfully User Created!!!";

        //            return RedirectToAction("AOITodoTask");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;

        //    }
        //    return RedirectToAction("AOITodoTask");
        //}

        //public ActionResult AOIReject(List<WorkFlowViewModel> viewModelsResult)
        //{
        //    WorkFlowViewModel viewModelResult = new WorkFlowViewModel();
        //    viewModelResult.Menuss = Session["Menuss"] as List<DOL.MasterMenuss> ?? new List<DOL.MasterMenuss>();

        //    DataTable dtTaskListItem = new DataTable("TaskList");
        //    dtTaskListItem.Columns.Add("Id");
        //    dtTaskListItem.Columns.Add("Pid");
        //    dtTaskListItem.Columns.Add("ResultId");
        //    dtTaskListItem.Columns.Add("MenuId");
        //    dtTaskListItem.Columns.Add("Applicant");
        //    dtTaskListItem.Columns.Add("TaskId");
        //    dtTaskListItem.Columns.Add("Reason");
        //    try
        //    {
        //        int Uid = 1;
        //        string employeeId = Session["EmpNumber"].ToString();
        //        foreach (var item in viewModelsResult)
        //        {
        //            dtTaskListItem.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.Applicant, item.TaskId, item.Reason);
        //            Uid++;
        //        }
        //        int Result = _checkResult.RejectTaskForAOI(dtTaskListItem);
        //        if (Result > 0)
        //        {
        //            TempData["mgs"] = "Sucess";
        //            TempData["Alert"] = "Sucessfully User Created!!!";

        //            return RedirectToAction("AOITodoTask");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return RedirectToAction("AOITodoTask");
        //}


        [HttpGet]
        public ActionResult HotBarTodoTask()
        {

            WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
            //WorkFlowViewModel.Menuss = _objProject.GetMasterMenus();
            //workFlowViewModel.Menuss = _objProject.GetMasterMenus() as List<MasterMenuss>;
            //Session["Menuss"] = workFlowViewModel.Menuss;
            workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];

            DataTable dt = _checkResult.GetHBTASK(workFlowViewModel.EmployeeId);

            int TaskId = 0;
            int ResultId = 0;
            if (dt.Rows.Count > 0)
            {
                ResultId = Convert.ToInt32(dt.Rows[0]["ResultId"]);
                TaskId = Convert.ToInt32(dt.Rows[0]["TaskId"]);

            }
            workFlowViewModel.WorkFlowList = _checkResult.GetTaskStatusForMHB1CheckList(workFlowViewModel.EmployeeId,TaskId);
            return View(workFlowViewModel);
        }

        [HttpPost]
        public ActionResult HotBarApprove(List<WorkFlowViewModel> viewModelsResult)
        {
            //viewModelsResult.Menuss = (List<DOL.MasterMenuss>)Session["Menuss"];
            WorkFlowViewModel viewModelResult = new WorkFlowViewModel();
            //viewModelResult.Menuss = Session["Menuss"] as List<DOL.MasterMenuss> ?? new List<DOL.MasterMenuss>();

            if (viewModelsResult.All(v => v.TaskId == 40))
            {
                DataTable dtTaskListItem = new DataTable("TaskList");
                dtTaskListItem.Columns.Add("Id");
                dtTaskListItem.Columns.Add("Pid");
                dtTaskListItem.Columns.Add("ResultId");
                dtTaskListItem.Columns.Add("MenuId");
                dtTaskListItem.Columns.Add("Sectionid");
                dtTaskListItem.Columns.Add("ApproveId");
                dtTaskListItem.Columns.Add("TaskId");
                dtTaskListItem.Columns.Add("Remark");


                WorkFlowViewModel obj = new WorkFlowViewModel();

                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();

                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId,item.SectionId, item.ApproveId, item.TaskId, item.Remark);
                        Uid++;
                    }

                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();

                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetHBTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }


                    DataTable dt = _checkResult.ApproveTaskFinal(dtTaskListItem);


                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Status"].ToString() == "Completed")
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "HBApproveLast", TaskId);
                        }
                        else
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "HBApprove", TaskId);
                        }


                        //objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "Approve", 0);
                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("HotBarTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;

                }
            }
            else
            {
                DataTable dtTaskListItem = new DataTable("TaskList");
                dtTaskListItem.Columns.Add("Id");
                dtTaskListItem.Columns.Add("Pid");
                dtTaskListItem.Columns.Add("ResultId");
                dtTaskListItem.Columns.Add("MenuId");
                dtTaskListItem.Columns.Add("Sectionid");
                dtTaskListItem.Columns.Add("ApproveId");
                dtTaskListItem.Columns.Add("TaskId");
                dtTaskListItem.Columns.Add("Reason");


                WorkFlowViewModel obj = new WorkFlowViewModel();

                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();

                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId,item.SectionId, item.ApproveId, item.TaskId, item.Reason);
                        Uid++;
                    }

                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();

                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];

                    DataTable dt2 = _checkResult.GetHBTASK(workFlowViewModel.EmployeeId);

                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }

                    DataTable dt = _checkResult.AOIApproveTask(dtTaskListItem);


                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Status"].ToString() == "Completed")
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "HBApproveLast", TaskId);
                        }
                        else
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "HBApprove", TaskId);
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("HotBarTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;

                }
            }
            
            return RedirectToAction("HotBarTodoTask");
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult HotBarReject(List<WorkFlowViewModel> viewModelsResult)
        {
            WorkFlowViewModel viewModelResult = new WorkFlowViewModel();
            //viewModelResult.Menuss = Session["Menuss"] as List<DOL.MasterMenuss> ?? new List<DOL.MasterMenuss>();

            if (viewModelsResult.All(v => v.TaskId == 40))
            {
                DataTable dtTaskListItem = new DataTable("TaskList");
                dtTaskListItem.Columns.Add("Id");
                dtTaskListItem.Columns.Add("Pid");
                dtTaskListItem.Columns.Add("ResultId");
                dtTaskListItem.Columns.Add("MenuId");
                dtTaskListItem.Columns.Add("Sectionid");
                dtTaskListItem.Columns.Add("ApproveId");
                dtTaskListItem.Columns.Add("TaskId");
                dtTaskListItem.Columns.Add("Remark");

                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();
                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId,item.SectionId, item.ApproveId, item.TaskId, item.Remark);
                        Uid++;
                    }


                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();

                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];

                    DataTable dt2 = _checkResult.GetHBTASK(workFlowViewModel.EmployeeId);

                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }

                    DataTable dt = _checkResult.RejectTaskFinal(dtTaskListItem);
                    //DataTable dt = _checkResult.RejectTaskForAOI(dtTaskListItem);

                    

                    if (dt.Rows.Count > 0)
                    {
                        try
                        {
                            //objmailForQuality.NotificationEmail(Convert.ToInt32(dt.Rows[0]["ResultId"]));
                            objmailForQuality.NotificationEmail("", Convert.ToInt32(dt.Rows[0]["ResultId"]), "HBReject", TaskId);
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("HotBarTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                DataTable dtTaskListItem = new DataTable("TaskList");
                dtTaskListItem.Columns.Add("Id");
                dtTaskListItem.Columns.Add("Pid");
                dtTaskListItem.Columns.Add("ResultId");
                dtTaskListItem.Columns.Add("MenuId");
                dtTaskListItem.Columns.Add("Sectionid");
                dtTaskListItem.Columns.Add("ApproveId");
                dtTaskListItem.Columns.Add("TaskId");
                dtTaskListItem.Columns.Add("Reason");

                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();
                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId,item.SectionId, item.ApproveId, item.TaskId, item.Reason);
                        Uid++;
                    }
                    DataTable dt = _checkResult.RejectTaskForAOI(dtTaskListItem);
                    //DataTable dt = _checkResult.RejectTaskForAOI(dtTaskListItem);

                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();

                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];

                    DataTable dt2 = _checkResult.GetHBTASK(workFlowViewModel.EmployeeId);

                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }

                    if (dt.Rows.Count > 0)
                    {
                        try
                        {
                            //objmailForQuality.NotificationEmail(Convert.ToInt32(dt.Rows[0]["ResultId"]));
                            objmailForQuality.NotificationEmail("", Convert.ToInt32(dt.Rows[0]["ResultId"]), "HBRejectFirst", TaskId);
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("HotBarTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }

            
            return RedirectToAction("HotBarTodoTask");
        }

        [HttpGet]
        public ActionResult FACAHotBarAuditChecklist()
        {
            A246CMHB1CheckListModelView model = new A246CMHB1CheckListModelView();
            model.dtChecklist = new DataTable(); 
            return View(model);
        }

        [HttpPost]
        public ActionResult FACAHotBarAuditChecklist(A246CMHB1CheckListModelView model)
        {

            model.dtChecklist = _checkResult.GetFromByA246CFACAMHB1Data();

            if (!ModelState.IsValid)
                return View(model);



            try
            {
                model.dtChecklist = _checkResult.GetFromByA246CFACAMHB1Data();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }
            return View(model);

           
        }

        [HttpPost]
        public ActionResult SaveFACAHotBarAuditChecklist(A246CMHB1CheckListModelView model)
        {
            DataTable dtChecklist = new DataTable("A246CMHB1CheckListResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("ResultId");
            dtChecklist.Columns.Add("RootCause");
            dtChecklist.Columns.Add("PreventiveAction");
            dtChecklist.Columns.Add("CorrectiveAction");
           
            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.A246CMHB1CheckListResults)
                {
                    dtChecklist.Rows.Add(Uid, row.ResultId,row.RootCause,row.PreventiveAction,row.CorrectiveAction);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                DataTable dt = _checkNative.InsertBulkA246CMHB1FACACheckList(dtChecklist, Session["EmpNumber"].ToString());

                if (dt.Rows.Count > 0)
                {
                    objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(),Convert.ToInt32(dt.Rows[0]["ResultId"]), "HBFACA",0);
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("FACAHotBarAuditChecklist");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            //model.dtChecklist = _checkResult.MailParameterProdQualityAudit(model.BatchId);
            model.dtChecklist = _checkResult.GetFromByA246CFACAMHB1Data();
            //model.Batches = (List<Batch>)Session["Batches"];
            return View("FACAHotBarAuditChecklist", model);
        }


        //[HttpGet]
        //public ActionResult FACAA246CDestructiveAuditChecklist()
        //{
        //    A246CMHB1CheckListModelView model = new A246CMHB1CheckListModelView();
        //    model.dtChecklist = new DataTable();
        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult FACAA246CDestructiveAuditChecklist(A246CMHB1CheckListModelView model)
        //{

        //    model.dtChecklist = _checkResult.GetFromByA246CFACAMHB2Data();

        //    if (!ModelState.IsValid)
        //        return View(model);



        //    try
        //    {
        //        model.dtChecklist = _checkResult.GetFromByA246CFACAMHB2Data();

        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError("ERROR", ex.Message);
        //    }
        //    return View(model);


        //}

        //[HttpPost]
        //public ActionResult SaveFACAA246CDestructiveAuditChecklist(A246CMHB1CheckListModelView model)
        //{
        //    DataTable dtChecklist = new DataTable("A246CMHB1CheckListResults");
        //    dtChecklist.Columns.Add("Id");
        //    dtChecklist.Columns.Add("ResultId");
        //    dtChecklist.Columns.Add("RootCause");
        //    dtChecklist.Columns.Add("PreventiveAction");
        //    dtChecklist.Columns.Add("CorrectiveAction");

        //    try
        //    {
        //        //  HttpFileCollectionBase files = Request.Files;

        //        int Uid = 1;

        //        foreach (var row in model.A246CMHB1CheckListResults)
        //        {
        //            dtChecklist.Rows.Add(Uid, row.ResultId, row.RootCause, row.PreventiveAction, row.CorrectiveAction);
        //            Uid++;

        //        }

        //        //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

        //        Datatable dt = _checkNative.InsertBulkA246CMHB2FACACheckList(dtChecklist, Session["EmpNumber"].ToString());

        //        if (i > 0)
        //        {
        //            //objmail.NotificationEmail("Rokeshkumar_D@foxlink.com");
        //            TempData["mgs"] = "Sucess";
        //            TempData["Alert"] = "Sucessfully Results Saved!!!";
        //            return RedirectToAction("FACAA246CDestructiveAuditChecklist");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("ERROR", "Already Existed !!!");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError("ERROR", ex.Message);
        //        //Log.Error("Error", ex);
        //    }

        //    //return RedirectToAction("Index");
        //    //model.dtChecklist = _checkResult.MailParameterProdQualityAudit(model.BatchId);
        //    model.dtChecklist = _checkResult.GetFromByA246CFACAMHB2Data();
        //    //model.Batches = (List<Batch>)Session["Batches"];
        //    return View("FACAA246CDestructiveAuditChecklist", model);
        //}

        [HttpGet]
        public ActionResult FACAXBarChecklist()
        {
            CheckListXBarResultModelView model = new CheckListXBarResultModelView();
            model.dtChecklist = new DataTable();
            return View(model);
        }

        [HttpPost]
        public ActionResult FACAXBarChecklist(CheckListXBarResultModelView model)
        {

            model.dtChecklist = _checkResult.GetFromByA246CFACAXBARData();

            if (!ModelState.IsValid)
                return View(model);



            try
            {
                model.dtChecklist = _checkResult.GetFromByA246CFACAXBARData();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }
            return View(model);


        }

        [HttpPost]
        public ActionResult SaveFACAXBarChecklist(CheckListXBarResultModelView model)
        {
            DataTable dtChecklist = new DataTable("CheckListXBarResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("ResultId");
            dtChecklist.Columns.Add("RootCausee");
            dtChecklist.Columns.Add("PreventiveAction");
            dtChecklist.Columns.Add("CorrectiveAction");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.CheckListXBarResults)
                {
                    dtChecklist.Rows.Add(Uid, row.ResultId, row.RootCausee, row.PreventiveAction, row.CorrectiveAction);
                    Uid++;

                }

                WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
                workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                DataTable dt2 = _checkResult.GetXBarTASK(workFlowViewModel.EmployeeId);

                int TaskId = 0;
                int ResultId = 0;
                if (dt2.Rows.Count > 0)
                {
                    ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                    TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                }
                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                DataTable dt = _checkNative.InsertBulkXBARFACACheckList(dtChecklist, Session["EmpNumber"].ToString());

                if (dt.Rows.Count > 0)
                {
                    //objmail.NotificationEmail("Rokeshkumar_D@foxlink.com");
                    objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "XBARFACA",0);
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("FACAXBarChecklist");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            //model.dtChecklist = _checkResult.MailParameterProdQualityAudit(model.BatchId);
            model.dtChecklist = _checkResult.GetFromByA246CFACAXBARData();
            //model.Batches = (List<Batch>)Session["Batches"];
            return View("FACAXBarChecklist", model);
        }


        [HttpGet]
        public ActionResult XBarTodoTask()
        {

            WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
            //WorkFlowViewModel.Menuss = _objProject.GetMasterMenus();
            //workFlowViewModel.Menuss = _objProject.GetMasterMenus() as List<MasterMenuss>;
            //Session["Menuss"] = workFlowViewModel.Menuss;

            workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
            DataTable dt2 = _checkResult.GetXBarTASK(workFlowViewModel.EmployeeId);
            int TaskId = 0;
            int ResultId = 0;
            if (dt2.Rows.Count > 0)
            {
                ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

            }

            workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
            workFlowViewModel.WorkFlowList = _checkResult.GetTaskStatusForXBarCheckList(workFlowViewModel.EmployeeId,TaskId);
            return View(workFlowViewModel);
        }


        [HttpPost]
        public ActionResult XBarApprove(List<WorkFlowViewModel> viewModelsResult)
        {
            //viewModelsResult.Menuss = (List<DOL.MasterMenuss>)Session["Menuss"];
            WorkFlowViewModel viewModelResult = new WorkFlowViewModel();
            //viewModelResult.Menuss = Session["Menuss"] as List<DOL.MasterMenuss> ?? new List<DOL.MasterMenuss>();

            if (viewModelsResult.All(v => v.TaskId == 20))
            {
                DataTable dtTaskListItem1 = new DataTable("TaskList");
                dtTaskListItem1.Columns.Add("Id");
                dtTaskListItem1.Columns.Add("Pid");
                dtTaskListItem1.Columns.Add("ResultId");
                dtTaskListItem1.Columns.Add("AdhesiveId");
                dtTaskListItem1.Columns.Add("ApproveId");
                dtTaskListItem1.Columns.Add("TaskId");
                dtTaskListItem1.Columns.Add("Remark");
                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();
                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem1.Rows.Add(Uid, item.Pid, item.ResultId, item.AdhesiveId, item.ApproveId, item.TaskId, item.Remark);
                        Uid++;
                    }

                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();

                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetXBarTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }

                    DataTable dt  = _checkResult.XBARApproveTask2(dtTaskListItem1);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Status"].ToString() == "Completed")
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "XBarApproveLast",TaskId);
                        }
                        else
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "XBarApprove",TaskId);
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("XBarTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                DataTable dtTaskListItem = new DataTable("TaskList");
                dtTaskListItem.Columns.Add("Id");
                dtTaskListItem.Columns.Add("Pid");
                dtTaskListItem.Columns.Add("ResultId");
                dtTaskListItem.Columns.Add("AdhesiveId");
                dtTaskListItem.Columns.Add("ApproveId");
                dtTaskListItem.Columns.Add("TaskId");
                dtTaskListItem.Columns.Add("Reason");


                WorkFlowViewModel obj = new WorkFlowViewModel();

                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();

                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem.Rows.Add(Uid, item.Pid, item.ResultId, item.AdhesiveId, item.ApproveId, item.TaskId, item.Reason);
                        Uid++;
                    }

                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();

                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetXBarTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }

                    DataTable dt = _checkResult.XBARApproveTask(dtTaskListItem);


                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Status"].ToString() == "Completed")
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "XBarApproveLast",TaskId);
                        }
                        else
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "XBarApprove",TaskId);
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("XBarTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;

                }
                
            }
            return RedirectToAction("XBarTodoTask");
        }


        public ActionResult XBarReject(List<WorkFlowViewModel> viewModelsResult)
        {
            WorkFlowViewModel viewModelResult = new WorkFlowViewModel();
            //viewModelResult.Menuss = Session["Menuss"] as List<DOL.MasterMenuss> ?? new List<DOL.MasterMenuss>();

            if (viewModelsResult.All(v => v.TaskId == 20))
            {
                DataTable dtTaskListItem1 = new DataTable("TaskList");
                dtTaskListItem1.Columns.Add("Id");
                dtTaskListItem1.Columns.Add("Pid");
                dtTaskListItem1.Columns.Add("ResultId");
                dtTaskListItem1.Columns.Add("AdhesiveId");
                dtTaskListItem1.Columns.Add("ApproveId");
                dtTaskListItem1.Columns.Add("TaskId");
                dtTaskListItem1.Columns.Add("Remark");
                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();
                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem1.Rows.Add(Uid, item.Pid, item.ResultId, item.AdhesiveId, item.ApproveId, item.TaskId, item.Remark);
                        Uid++;
                    }

                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();

                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetXBarTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }

                    DataTable dt = _checkResult.RejectTaskForXBAR2(dtTaskListItem1);
                    if (dt.Rows.Count > 0)
                    {
                        try
                        {
                            objmailForQuality.NotificationEmail("", Convert.ToInt32(dt.Rows[0]["ResultId"]), "XBarReject", TaskId);
                        }
                        catch (Exception)
                        {
                            
                            throw;
                        }
                        
                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("XBarTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                DataTable dtTaskListItem = new DataTable("TaskList");
                dtTaskListItem.Columns.Add("Id");
                dtTaskListItem.Columns.Add("Pid");
                dtTaskListItem.Columns.Add("ResultId");
                dtTaskListItem.Columns.Add("AdhesiveId");
                dtTaskListItem.Columns.Add("ApproveId");
                dtTaskListItem.Columns.Add("TaskId");
                dtTaskListItem.Columns.Add("Reason");

                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();
                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem.Rows.Add(Uid, item.Pid, item.ResultId, item.AdhesiveId, item.ApproveId, item.TaskId, item.Reason);
                        Uid++;
                    }

                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();

                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetXBarTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }

                    DataTable dt = _checkResult.RejectTaskForXBAR(dtTaskListItem);
                    //DataTable dt = _checkResult.RejectTaskForAOI(dtTaskListItem);
                    if (dt.Rows.Count > 0)
                    {
                        try
                        {
                            //objmailForQuality.NotificationEmail(Convert.ToInt32(dt.Rows[0]["ResultId"]));
                            objmailForQuality.NotificationEmail("", Convert.ToInt32(dt.Rows[0]["ResultId"]), "XBarRejectFirst",TaskId);
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("XBarTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }

            
            return RedirectToAction("XBarTodoTask");
        }

        [HttpGet]
        public ActionResult CTPFACAChecklist()
        {
            InsertBulkA246CCTParameterMCChecklistLine1ModelView model = new InsertBulkA246CCTParameterMCChecklistLine1ModelView();
            model.dtChecklist = new DataTable();
            return View(model);
        }

        [HttpPost]
        public ActionResult CTPFACAChecklist(InsertBulkA246CCTParameterMCChecklistLine1ModelView model)
        {

            model.dtChecklist = _checkResult.GetFromByA246CFACACTPData();

            if (!ModelState.IsValid)
                return View(model);



            try
            {
                model.dtChecklist = _checkResult.GetFromByA246CFACACTPData();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }
            return View(model);


        }

        [HttpPost]
        public ActionResult SaveCTPFACAChecklist(InsertBulkA246CCTParameterMCChecklistLine1ModelView model)
        {
            DataTable dtChecklist = new DataTable("A246CCTParameterMCChecklistLine1");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("ResultId");
            dtChecklist.Columns.Add("RootCause");
            dtChecklist.Columns.Add("PreventiveAction");
            dtChecklist.Columns.Add("CorrectiveAction");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.A246CCTParameterMCChecklistLine1)
                {
                    dtChecklist.Rows.Add(Uid, row.ResultId, row.RootCause, row.PreventiveAction, row.CorrectiveAction);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                DataTable dt = _checkNative.InsertBulkA246CCTPFACACheckList(dtChecklist, Session["EmpNumber"].ToString());

                if (dt.Rows.Count > 0)
                {
                    //objmail.NotificationEmail("Rokeshkumar_D@foxlink.com");
                    objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "CTPFACA",0);
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("CTPFACAChecklist");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            //model.dtChecklist = _checkResult.MailParameterProdQualityAudit(model.BatchId);
            model.dtChecklist = _checkResult.GetFromByA246CFACACTPData();
            //model.Batches = (List<Batch>)Session["Batches"];
            return View("CTPFACAChecklist", model);
        }

        [HttpGet]
        public ActionResult CTPTodoTask()
        
        {

            WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
            //WorkFlowViewModel.Menuss = _objProject.GetMasterMenus();
            //workFlowViewModel.Menuss = _objProject.GetMasterMenus() as List<MasterMenuss>;
            //Session["Menuss"] = workFlowViewModel.Menuss;
            workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
            DataTable dt = _checkResult.GetCTPNGTASK(workFlowViewModel.EmployeeId);
            int TaskId=0;
            int ResultId = 0;
            if (dt.Rows.Count > 0)
            {
                ResultId = Convert.ToInt32(dt.Rows[0]["ResultId"]);
                TaskId = Convert.ToInt32(dt.Rows[0]["TaskId"]);
               
            }

            workFlowViewModel.WorkFlowList = _checkResult.GetTaskStatusForA246CCTPChecklist(workFlowViewModel.EmployeeId, ResultId,TaskId);
            return View(workFlowViewModel);
        }

        [HttpPost]
        public ActionResult CTPApprove(List<WorkFlowViewModel> viewModelsResult)
        {
            //viewModelsResult.Menuss = (List<DOL.MasterMenuss>)Session["Menuss"];
            WorkFlowViewModel viewModelResult = new WorkFlowViewModel();
            //viewModelResult.Menuss = Session["Menuss"] as List<DOL.MasterMenuss> ?? new List<DOL.MasterMenuss>();

            if (viewModelsResult.All(v => v.TaskId == 20))
            {
                DataTable dtTaskListItem1 = new DataTable("TaskList");
                dtTaskListItem1.Columns.Add("Id");
                dtTaskListItem1.Columns.Add("Pid");
                dtTaskListItem1.Columns.Add("ResultId");
                dtTaskListItem1.Columns.Add("MenuId");
                dtTaskListItem1.Columns.Add("ParameterId");
                dtTaskListItem1.Columns.Add("ApproveId");
                dtTaskListItem1.Columns.Add("TaskId");
                dtTaskListItem1.Columns.Add("Remark");
                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();
                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem1.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId,item.ParameterId, item.ApproveId, item.TaskId, item.Remark);
                        Uid++;
                    }
                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();

                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetCTPNGTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }

                    DataTable dt = _checkResult.CTPApproveTaskFinal(dtTaskListItem1);
                    

                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Status"].ToString() == "Completed")
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "CTPApproveLast", TaskId);
                        }
                        else
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "CTPApprove",TaskId);
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("CTPTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                DataTable dtTaskListItem = new DataTable("TaskList");
                dtTaskListItem.Columns.Add("Id");
                dtTaskListItem.Columns.Add("Pid");
                dtTaskListItem.Columns.Add("ResultId");
                dtTaskListItem.Columns.Add("MenuId");
                dtTaskListItem.Columns.Add("ParameterId");
                dtTaskListItem.Columns.Add("ApproveId");
                dtTaskListItem.Columns.Add("TaskId");
                dtTaskListItem.Columns.Add("Reason");


                WorkFlowViewModel obj = new WorkFlowViewModel();

                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();

                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.ParameterId, item.ApproveId, item.TaskId, item.Reason);
                        Uid++;
                    }

                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetCTPNGTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }
                    DataTable dt = _checkResult.CTPApproveTask(dtTaskListItem);


                    

                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Status"].ToString() == "Completed")
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "CTPApproveLast", TaskId);
                        }
                        else
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "CTPApprove", TaskId);
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("CTPTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;

                }

            }
            return RedirectToAction("CTPTodoTask");
        }

        public ActionResult CTPReject(List<WorkFlowViewModel> viewModelsResult)
        {
            WorkFlowViewModel viewModelResult = new WorkFlowViewModel();
            //viewModelResult.Menuss = Session["Menuss"] as List<DOL.MasterMenuss> ?? new List<DOL.MasterMenuss>();

            if (viewModelsResult.All(v => v.TaskId==20))
            {
                DataTable dtTaskListItem1 = new DataTable("TaskList");
                dtTaskListItem1.Columns.Add("Id");
                dtTaskListItem1.Columns.Add("Pid");
                dtTaskListItem1.Columns.Add("ResultId");
                dtTaskListItem1.Columns.Add("MenuId");
                dtTaskListItem1.Columns.Add("ParameterId");
                dtTaskListItem1.Columns.Add("ApproveId");
                dtTaskListItem1.Columns.Add("TaskId");
                dtTaskListItem1.Columns.Add("Remark");
                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();
                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem1.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.ParameterId, item.ApproveId, item.TaskId, item.Remark);
                        Uid++;
                    }

                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetCTPNGTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }

                    DataTable dt = _checkResult.CTPRejectTaskFinal(dtTaskListItem1);

                    
                    if (dt.Rows.Count > 0)
                    {
                        try
                        {
                            objmailForQuality.NotificationEmail("", Convert.ToInt32(dt.Rows[0]["ResultId"]), "CTPReject", TaskId);
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("CTPTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                DataTable dtTaskListItem = new DataTable("TaskList");
                dtTaskListItem.Columns.Add("Id");
                dtTaskListItem.Columns.Add("Pid");
                dtTaskListItem.Columns.Add("ResultId");
                dtTaskListItem.Columns.Add("MenuId");
                dtTaskListItem.Columns.Add("ParameterId");
                dtTaskListItem.Columns.Add("ApproveId");
                dtTaskListItem.Columns.Add("TaskId");
                dtTaskListItem.Columns.Add("Reason");

                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();
                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.ParameterId, item.ApproveId, item.TaskId, item.Reason);
                        Uid++;
                    }
                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetCTPNGTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }
                    DataTable dt = _checkResult.CTPRejectTask(dtTaskListItem);
                    //DataTable dt = _checkResult.RejectTaskForAOI(dtTaskListItem);

                    
                    if (dt.Rows.Count > 0)
                    {
                        try
                        {
                            //objmailForQuality.NotificationEmail(Convert.ToInt32(dt.Rows[0]["ResultId"]));
                            objmailForQuality.NotificationEmail("", Convert.ToInt32(dt.Rows[0]["ResultId"]), "CTPRejectFirst", TaskId);
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("CTPTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }


            return RedirectToAction("CTPTodoTask");
        }

        [HttpGet]
        public ActionResult CTPFACAChecklistLine2()
        {
            AA246CCTPaameterMCChecklist1ModelView model = new AA246CCTPaameterMCChecklist1ModelView();
            model.dtChecklist = new DataTable();
            return View(model);
        }

        [HttpPost]
        public ActionResult CTPFACAChecklistLine2(AA246CCTPaameterMCChecklist1ModelView model)
        {

            model.dtChecklist = _checkResult.GetFromByA246CFACACTPDataForLine2();

            if (!ModelState.IsValid)
                return View(model);



            try
            {
                model.dtChecklist = _checkResult.GetFromByA246CFACACTPDataForLine2();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }
            return View(model);


        }

        [HttpPost]
        public ActionResult SaveCTPFACAChecklistLine2(AA246CCTPaameterMCChecklist1ModelView model)
        {
            DataTable dtChecklist = new DataTable("A246CCTPaameterMCChecklist1");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("ResultId");
            dtChecklist.Columns.Add("RootCause");
            dtChecklist.Columns.Add("PreventiveAction");
            dtChecklist.Columns.Add("CorrectiveAction");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.A246CCTPaameterMCChecklist1Results)
                {
                    dtChecklist.Rows.Add(Uid, row.ResultId, row.RootCause, row.PreventiveAction, row.CorrectiveAction);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                DataTable dt = _checkNative.InsertBulkA246CCTPFACACheckListForLine2(dtChecklist, Session["EmpNumber"].ToString());

                if (dt.Rows.Count > 0)
                {
                    //objmail.NotificationEmail("Rokeshkumar_D@foxlink.com");
                    objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "CTPFACALine2", 0);
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("CTPFACAChecklistLine2");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            //model.dtChecklist = _checkResult.MailParameterProdQualityAudit(model.BatchId);
            model.dtChecklist = _checkResult.GetFromByA246CFACACTPDataForLine2();
            //model.Batches = (List<Batch>)Session["Batches"];
            return View("CTPFACAChecklistLine2", model);
        }

        [HttpGet]
        public ActionResult CTPTodoTaskLine2()
        {

            WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
            //WorkFlowViewModel.Menuss = _objProject.GetMasterMenus();
            //workFlowViewModel.Menuss = _objProject.GetMasterMenus() as List<MasterMenuss>;
            //Session["Menuss"] = workFlowViewModel.Menuss;
            workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
            DataTable dt = _checkResult.GetCTPLINE2NGTASK(workFlowViewModel.EmployeeId);
            int TaskId = 0;
            int ResultId = 0;
            if (dt.Rows.Count > 0)
            {
                ResultId = Convert.ToInt32(dt.Rows[0]["ResultId"]);
                TaskId = Convert.ToInt32(dt.Rows[0]["TaskId"]);

            }

            workFlowViewModel.WorkFlowList = _checkResult.GetTaskStatusForA246CCTPChecklistForLine2(workFlowViewModel.EmployeeId, ResultId, TaskId);
            return View(workFlowViewModel);
        }

        [HttpPost]
        public ActionResult CTPApproveLine2(List<WorkFlowViewModel> viewModelsResult)
        {
            //viewModelsResult.Menuss = (List<DOL.MasterMenuss>)Session["Menuss"];
            WorkFlowViewModel viewModelResult = new WorkFlowViewModel();
            //viewModelResult.Menuss = Session["Menuss"] as List<DOL.MasterMenuss> ?? new List<DOL.MasterMenuss>();

            if (viewModelsResult.All(v => v.TaskId == 20))
            {
                DataTable dtTaskListItem1 = new DataTable("TaskList");
                dtTaskListItem1.Columns.Add("Id");
                dtTaskListItem1.Columns.Add("Pid");
                dtTaskListItem1.Columns.Add("ResultId");
                dtTaskListItem1.Columns.Add("MenuId");
                dtTaskListItem1.Columns.Add("ParameterId");
                dtTaskListItem1.Columns.Add("ApproveId");
                dtTaskListItem1.Columns.Add("TaskId");
                dtTaskListItem1.Columns.Add("Remark");
                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();
                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem1.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.ParameterId, item.ApproveId, item.TaskId, item.Remark);
                        Uid++;
                    }
                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();

                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetCTPLINE2NGTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }

                    DataTable dt = _checkResult.CTPApproveTaskFinal(dtTaskListItem1);


                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Status"].ToString() == "Completed")
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "CTPLine2ApproveLast", TaskId);
                        }
                        else
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "CTPLine2Approve", TaskId);
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("CTPTodoTaskLine2");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                DataTable dtTaskListItem = new DataTable("TaskList");
                dtTaskListItem.Columns.Add("Id");
                dtTaskListItem.Columns.Add("Pid");
                dtTaskListItem.Columns.Add("ResultId");
                dtTaskListItem.Columns.Add("MenuId");
                dtTaskListItem.Columns.Add("ParameterId");
                dtTaskListItem.Columns.Add("ApproveId");
                dtTaskListItem.Columns.Add("TaskId");
                dtTaskListItem.Columns.Add("Reason");


                WorkFlowViewModel obj = new WorkFlowViewModel();

                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();

                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.ParameterId, item.ApproveId, item.TaskId, item.Reason);
                        Uid++;
                    }

                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetCTPLINE2NGTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }
                    DataTable dt = _checkResult.CTPApproveTask(dtTaskListItem);




                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Status"].ToString() == "Completed")
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "CTPLine2ApproveLast", TaskId);
                        }
                        else
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "CTPLine2Approve", TaskId);
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("CTPTodoTaskLine2");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;

                }

            }
            return RedirectToAction("CTPTodoTaskLine2");
        }

        public ActionResult CTPRejectLine2(List<WorkFlowViewModel> viewModelsResult)
        {
            WorkFlowViewModel viewModelResult = new WorkFlowViewModel();
            //viewModelResult.Menuss = Session["Menuss"] as List<DOL.MasterMenuss> ?? new List<DOL.MasterMenuss>();

            if (viewModelsResult.All(v => v.TaskId == 20))
            {
                DataTable dtTaskListItem1 = new DataTable("TaskList");
                dtTaskListItem1.Columns.Add("Id");
                dtTaskListItem1.Columns.Add("Pid");
                dtTaskListItem1.Columns.Add("ResultId");
                dtTaskListItem1.Columns.Add("MenuId");
                dtTaskListItem1.Columns.Add("ParameterId");
                dtTaskListItem1.Columns.Add("ApproveId");
                dtTaskListItem1.Columns.Add("TaskId");
                dtTaskListItem1.Columns.Add("Remark");
                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();
                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem1.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.ParameterId, item.ApproveId, item.TaskId, item.Remark);
                        Uid++;
                    }

                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetCTPLINE2NGTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }

                    DataTable dt = _checkResult.CTPRejectTaskFinal(dtTaskListItem1);


                    if (dt.Rows.Count > 0)
                    {
                        try
                        {
                            objmailForQuality.NotificationEmail("", Convert.ToInt32(dt.Rows[0]["ResultId"]), "CTPLine2Reject", TaskId);
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("CTPTodoTaskLine2");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                DataTable dtTaskListItem = new DataTable("TaskList");
                dtTaskListItem.Columns.Add("Id");
                dtTaskListItem.Columns.Add("Pid");
                dtTaskListItem.Columns.Add("ResultId");
                dtTaskListItem.Columns.Add("MenuId");
                dtTaskListItem.Columns.Add("ParameterId");
                dtTaskListItem.Columns.Add("ApproveId");
                dtTaskListItem.Columns.Add("TaskId");
                dtTaskListItem.Columns.Add("Reason");

                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();
                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.ParameterId, item.ApproveId, item.TaskId, item.Reason);
                        Uid++;
                    }
                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetCTPLINE2NGTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }
                    DataTable dt = _checkResult.CTPRejectTask(dtTaskListItem);
                    //DataTable dt = _checkResult.RejectTaskForAOI(dtTaskListItem);


                    if (dt.Rows.Count > 0)
                    {
                        try
                        {
                            //objmailForQuality.NotificationEmail(Convert.ToInt32(dt.Rows[0]["ResultId"]));
                            objmailForQuality.NotificationEmail("", Convert.ToInt32(dt.Rows[0]["ResultId"]), "CTPLine2RejectFirst", TaskId);
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("CTPTodoTaskLine2");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }


            return RedirectToAction("CTPTodoTaskLine2");
        }

        [HttpGet]
        public ActionResult AOIFACAChecklist()
        {
            A246CAOICheckListModelView model = new A246CAOICheckListModelView();
            model.dtChecklist = new DataTable();
            return View(model);
        }

        [HttpPost]
        public ActionResult AOIFACAChecklist(A246CAOICheckListModelView model)
        {

            model.dtChecklist = _checkResult.GetFromByA246CFACAAOIData();

            if (!ModelState.IsValid)
                return View(model);



            try
            {
                model.dtChecklist = _checkResult.GetFromByA246CFACAAOIData();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }
            return View(model);


        }

        [HttpPost]
        public ActionResult SaveAOIFACAChecklist(A246CAOICheckListModelView model)
        {
            DataTable dtChecklist = new DataTable("A246CAOICheckListResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("ResultId");
            dtChecklist.Columns.Add("RootCause");
            dtChecklist.Columns.Add("PreventiveAction");
            dtChecklist.Columns.Add("CorrectiveAction");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.A246CAOICheckListResults)
                {
                    dtChecklist.Rows.Add(Uid, row.ResultId, row.RootCause, row.PreventiveAction, row.CorrectiveAction);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                DataTable dt = _checkNative.InsertBulkA246CAOIFACACheckList(dtChecklist, Session["EmpNumber"].ToString());

                if (dt.Rows.Count > 0)
                {
                    //objmail.NotificationEmail("Rokeshkumar_D@foxlink.com");
                    objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "AOIFACA", 0);
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("AOIFACAChecklist");
                }
                else
                {
                    //objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "AOIFACA", 0);
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            //model.dtChecklist = _checkResult.MailParameterProdQualityAudit(model.BatchId);
            model.dtChecklist = _checkResult.GetFromByA246CFACAAOIData();
            //model.Batches = (List<Batch>)Session["Batches"];
            return View("AOIFACAChecklist", model);
        }


        [HttpGet]
        public ActionResult AOITodoTask()
        {

            WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
            //WorkFlowViewModel.Menuss = _objProject.GetMasterMenus();
            //workFlowViewModel.Menuss = _objProject.GetMasterMenus() as List<MasterMenuss>;
            //Session["Menuss"] = workFlowViewModel.Menuss;
            workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
            DataTable dt = _checkResult.GetNGTask(workFlowViewModel.EmployeeId);
            int TaskId = 0;
            int ResultId = 0;
            if (dt.Rows.Count > 0)
            {
                ResultId = Convert.ToInt32(dt.Rows[0]["ResultId"]);
                TaskId = Convert.ToInt32(dt.Rows[0]["TaskId"]);

            }

            workFlowViewModel.WorkFlowList = _checkResult.GetTaskStatusForA246CAOIChecklist(workFlowViewModel.EmployeeId,TaskId);
            return View(workFlowViewModel);
        }

        [HttpPost]
        public ActionResult AOIApprove(List<WorkFlowViewModel> viewModelsResult)
        {
            //viewModelsResult.Menuss = (List<DOL.MasterMenuss>)Session["Menuss"];
            WorkFlowViewModel viewModelResult = new WorkFlowViewModel();
            //viewModelResult.Menuss = Session["Menuss"] as List<DOL.MasterMenuss> ?? new List<DOL.MasterMenuss>();

            if (viewModelsResult.All(v => v.TaskId == 20))
            {
                DataTable dtTaskListItem1 = new DataTable("TaskList");
                dtTaskListItem1.Columns.Add("Id");
                dtTaskListItem1.Columns.Add("Pid");
                dtTaskListItem1.Columns.Add("ResultId");
                dtTaskListItem1.Columns.Add("MenuId");
                dtTaskListItem1.Columns.Add("SectionId");
                dtTaskListItem1.Columns.Add("ApproveId");
                dtTaskListItem1.Columns.Add("TaskId");
                dtTaskListItem1.Columns.Add("Remark");
                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();
                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem1.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.SectionId, item.ApproveId, item.TaskId, item.Remark);
                        Uid++;
                    }
                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();

                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetNGTask(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }

                    DataTable dt = _checkResult.ApproveTaskFinal(dtTaskListItem1);


                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Status"].ToString() == "Completed")
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "AOIApproveLast", TaskId);
                        }
                        else
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "AOIApprove", TaskId);
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("AOITodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                DataTable dtTaskListItem = new DataTable("TaskList");
                dtTaskListItem.Columns.Add("Id");
                dtTaskListItem.Columns.Add("Pid");
                dtTaskListItem.Columns.Add("ResultId");
                dtTaskListItem.Columns.Add("MenuId");
                dtTaskListItem.Columns.Add("SectionId");
                dtTaskListItem.Columns.Add("ApproveId");
                dtTaskListItem.Columns.Add("TaskId");
                dtTaskListItem.Columns.Add("Reason");


                WorkFlowViewModel obj = new WorkFlowViewModel();

                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();

                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.SectionId, item.ApproveId, item.TaskId, item.Reason);
                        Uid++;
                    }

                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetNGTask(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }
                    DataTable dt = _checkResult.AOIApproveTask(dtTaskListItem);




                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Status"].ToString() == "Completed")
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "AOIApproveLast", TaskId);
                        }
                        else
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "AOIApprove", TaskId);
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("AOITodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;

                }

            }
            return RedirectToAction("AOITodoTask");
        }

        public ActionResult AOIReject(List<WorkFlowViewModel> viewModelsResult)
        {
            WorkFlowViewModel viewModelResult = new WorkFlowViewModel();
            //viewModelResult.Menuss = Session["Menuss"] as List<DOL.MasterMenuss> ?? new List<DOL.MasterMenuss>();

            if (viewModelsResult.All(v => v.TaskId == 20))
            {
                DataTable dtTaskListItem1 = new DataTable("TaskList");
                dtTaskListItem1.Columns.Add("Id");
                dtTaskListItem1.Columns.Add("Pid");
                dtTaskListItem1.Columns.Add("ResultId");
                dtTaskListItem1.Columns.Add("MenuId");
                dtTaskListItem1.Columns.Add("SectionId");
                dtTaskListItem1.Columns.Add("ApproveId");
                dtTaskListItem1.Columns.Add("TaskId");
                dtTaskListItem1.Columns.Add("Remark");
                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();

                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem1.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.SectionId, item.ApproveId, item.TaskId, item.Remark);
                        Uid++;
                    }

                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetNGTask(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if(dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }

                    DataTable dt = _checkResult.RejectTaskFinal(dtTaskListItem1);


                    if (dt.Rows.Count > 0)
                    {
                        try
                        {
                            objmailForQuality.NotificationEmail("", Convert.ToInt32(dt.Rows[0]["ResultId"]), "AOIReject", TaskId);
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("AOITodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                DataTable dtTaskListItem = new DataTable("TaskList");
                dtTaskListItem.Columns.Add("Id");
                dtTaskListItem.Columns.Add("Pid");
                dtTaskListItem.Columns.Add("ResultId");
                dtTaskListItem.Columns.Add("MenuId");
                dtTaskListItem.Columns.Add("SectionId");
                dtTaskListItem.Columns.Add("ApproveId");
                dtTaskListItem.Columns.Add("TaskId");
                dtTaskListItem.Columns.Add("Reason");

                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();
                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.SectionId, item.ApproveId, item.TaskId, item.Reason);
                        Uid++;
                    }
                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetNGTask(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }
                    DataTable dt = _checkResult.RejectTaskForAOI(dtTaskListItem);
                    //DataTable dt = _checkResult.RejectTaskForAOI(dtTaskListItem);


                    if (dt.Rows.Count > 0)
                    {
                        try
                        {
                            //objmailForQuality.NotificationEmail(Convert.ToInt32(dt.Rows[0]["ResultId"]));
                            objmailForQuality.NotificationEmail("", Convert.ToInt32(dt.Rows[0]["ResultId"]), "AOIRejectFirst", TaskId);
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("AOITodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }


            return RedirectToAction("AOITodoTask");
        }

        [HttpGet]
        public ActionResult InnerMoldFACAChecklist()
        {
            A246CInnerMoldMCDataCheckListModelView model = new A246CInnerMoldMCDataCheckListModelView();
            model.dtChecklist = new DataTable();
            return View(model);
        }

        [HttpPost]
        public ActionResult InnerMoldFACAChecklist(A246CInnerMoldMCDataCheckListModelView model)
        {

            model.dtChecklist = _checkResult.GetFromByA246CFACAInnerMoldData();

            if (!ModelState.IsValid)
                return View(model);



            try
            {
                model.dtChecklist = _checkResult.GetFromByA246CFACAInnerMoldData();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }
            return View(model);


        }

        [HttpPost]
        public ActionResult SaveInnerMoldFACAChecklist(A246CInnerMoldMCDataCheckListModelView model)
        {
            DataTable dtChecklist = new DataTable("A246CInnerMoldMCDataCheckListResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("ResultId");
            dtChecklist.Columns.Add("RootCause");
            dtChecklist.Columns.Add("PreventiveAction");
            dtChecklist.Columns.Add("CorrectiveAction");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.A246CInnerMoldMCDataCheckListResults)
                {
                    dtChecklist.Rows.Add(Uid, row.ResultId, row.RootCause, row.PreventiveAction, row.CorrectiveAction);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                DataTable dt = _checkNative.InsertBulkA246CINNERMOLDFACACheckList(dtChecklist, Session["EmpNumber"].ToString());

                if (dt.Rows.Count > 0)
                {
                    //objmail.NotificationEmail("Rokeshkumar_D@foxlink.com");
                    objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "INNERMOLDFACA", 0);
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("InnerMoldFACAChecklist");
                }
                else
                {
                    //objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "AOIFACA", 0);
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            //model.dtChecklist = _checkResult.MailParameterProdQualityAudit(model.BatchId);
            model.dtChecklist = _checkResult.GetFromByA246CFACAInnerMoldData();
            //model.Batches = (List<Batch>)Session["Batches"];
            return View("InnerMoldFACAChecklist", model);
        }


        [HttpGet]
        public ActionResult InnerMoldTodoTask()
        {

            WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
            //WorkFlowViewModel.Menuss = _objProject.GetMasterMenus();
            //workFlowViewModel.Menuss = _objProject.GetMasterMenus() as List<MasterMenuss>;
            //Session["Menuss"] = workFlowViewModel.Menuss;
            workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
            DataTable dt = _checkResult.GetINNERMOLDTASK(workFlowViewModel.EmployeeId);
            int TaskId = 0;
            int ResultId = 0;
            if (dt.Rows.Count > 0)
            {
                ResultId = Convert.ToInt32(dt.Rows[0]["ResultId"]);
                TaskId = Convert.ToInt32(dt.Rows[0]["TaskId"]);

            }

            workFlowViewModel.WorkFlowList = _checkResult.GetTaskStatusForA246CINNERMOLDChecklist(workFlowViewModel.EmployeeId, TaskId, ResultId);
            return View(workFlowViewModel);
        }

        [HttpPost]
        public ActionResult InnerMoldApprove(List<WorkFlowViewModel> viewModelsResult)
        {
            //viewModelsResult.Menuss = (List<DOL.MasterMenuss>)Session["Menuss"];
            WorkFlowViewModel viewModelResult = new WorkFlowViewModel();
            //viewModelResult.Menuss = Session["Menuss"] as List<DOL.MasterMenuss> ?? new List<DOL.MasterMenuss>();

            if (viewModelsResult.All(v => v.TaskId == 40))
            {
                DataTable dtTaskListItem1 = new DataTable("TaskList");
                dtTaskListItem1.Columns.Add("Id");
                dtTaskListItem1.Columns.Add("Pid");
                dtTaskListItem1.Columns.Add("ResultId");
                dtTaskListItem1.Columns.Add("MenuId");
                dtTaskListItem1.Columns.Add("SectionId");
                dtTaskListItem1.Columns.Add("ApproveId");
                dtTaskListItem1.Columns.Add("TaskId");
                dtTaskListItem1.Columns.Add("Remark");
                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();
                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem1.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.SectionId, item.ApproveId, item.TaskId, item.Remark);
                        Uid++;
                    }
                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();

                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetINNERMOLDTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }

                    DataTable dt = _checkResult.ApproveTaskFinal(dtTaskListItem1);


                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Status"].ToString() == "Completed")
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "InnerMoldApproveLast", TaskId);
                        }
                        else
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "InnerMoldApprove", TaskId);
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("InnerMoldTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                DataTable dtTaskListItem = new DataTable("TaskList");
                dtTaskListItem.Columns.Add("Id");
                dtTaskListItem.Columns.Add("Pid");
                dtTaskListItem.Columns.Add("ResultId");
                dtTaskListItem.Columns.Add("MenuId");
                dtTaskListItem.Columns.Add("SectionId");
                dtTaskListItem.Columns.Add("ApproveId");
                dtTaskListItem.Columns.Add("TaskId");
                dtTaskListItem.Columns.Add("Reason");


                WorkFlowViewModel obj = new WorkFlowViewModel();

                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();

                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.SectionId, item.ApproveId, item.TaskId, item.Reason);
                        Uid++;
                    }

                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetINNERMOLDTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }
                    DataTable dt = _checkResult.AOIApproveTask(dtTaskListItem);




                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Status"].ToString() == "Completed")
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "InnerMoldApproveLast", TaskId);
                        }
                        else
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "InnerMoldApprove", TaskId);
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("InnerMoldTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;

                }

            }
            return RedirectToAction("InnerMoldTodoTask");
        }

        public ActionResult InnerMoldReject(List<WorkFlowViewModel> viewModelsResult)
        {
            WorkFlowViewModel viewModelResult = new WorkFlowViewModel();
            //viewModelResult.Menuss = Session["Menuss"] as List<DOL.MasterMenuss> ?? new List<DOL.MasterMenuss>();

            if (viewModelsResult.All(v => v.TaskId == 40))
            {
                DataTable dtTaskListItem1 = new DataTable("TaskList");
                dtTaskListItem1.Columns.Add("Id");
                dtTaskListItem1.Columns.Add("Pid");
                dtTaskListItem1.Columns.Add("ResultId");
                dtTaskListItem1.Columns.Add("MenuId");
                dtTaskListItem1.Columns.Add("SectionId");
                dtTaskListItem1.Columns.Add("ApproveId");
                dtTaskListItem1.Columns.Add("TaskId");
                dtTaskListItem1.Columns.Add("Remark");
                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();

                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem1.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.SectionId, item.ApproveId, item.TaskId, item.Remark);
                        Uid++;
                    }

                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetINNERMOLDTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }

                    DataTable dt = _checkResult.RejectTaskFinal(dtTaskListItem1);


                    if (dt.Rows.Count > 0)
                    {
                        try
                        {
                            objmailForQuality.NotificationEmail("", Convert.ToInt32(dt.Rows[0]["ResultId"]), "InnerMoldReject", TaskId);
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("InnerMoldTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                DataTable dtTaskListItem = new DataTable("TaskList");
                dtTaskListItem.Columns.Add("Id");
                dtTaskListItem.Columns.Add("Pid");
                dtTaskListItem.Columns.Add("ResultId");
                dtTaskListItem.Columns.Add("MenuId");
                dtTaskListItem.Columns.Add("SectionId");
                dtTaskListItem.Columns.Add("ApproveId");
                dtTaskListItem.Columns.Add("TaskId");
                dtTaskListItem.Columns.Add("Reason");

                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();
                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.SectionId, item.ApproveId, item.TaskId, item.Reason);
                        Uid++;
                    }
                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetINNERMOLDTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }
                    DataTable dt = _checkResult.RejectTaskForAOI(dtTaskListItem);
                    //DataTable dt = _checkResult.RejectTaskForAOI(dtTaskListItem);


                    if (dt.Rows.Count > 0)
                    {
                        try
                        {
                            //objmailForQuality.NotificationEmail(Convert.ToInt32(dt.Rows[0]["ResultId"]));
                            objmailForQuality.NotificationEmail("", Convert.ToInt32(dt.Rows[0]["ResultId"]), "InnerMoldRejectFirst", TaskId);
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("InnerMoldTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }


            return RedirectToAction("InnerMoldTodoTask");
        }


        [HttpGet]
        public ActionResult HankingFACAChecklist()
        {
            A246CHankingCheckListModelView model = new A246CHankingCheckListModelView();
            model.dtChecklist = new DataTable();
            return View(model);
        }

        [HttpPost]
        public ActionResult HankingFACAChecklist(A246CHankingCheckListModelView model)
        {

            model.dtChecklist = _checkResult.GetFromByA246CFACAHankingCData();

            if (!ModelState.IsValid)
                return View(model);



            try
            {
                model.dtChecklist = _checkResult.GetFromByA246CFACAHankingCData();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }
            return View(model);


        }

        [HttpPost]
        public ActionResult SaveHankingFACAChecklist(A246CHankingCheckListModelView model)
        {
            DataTable dtChecklist = new DataTable("A246CHankingCheckListResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("ResultId");
            dtChecklist.Columns.Add("RootCause");
            dtChecklist.Columns.Add("PreventiveAction");
            dtChecklist.Columns.Add("CorrectiveAction");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.A246CHankingCheckListResults)
                {
                    dtChecklist.Rows.Add(Uid, row.ResultId, row.RootCause, row.PreventiveAction, row.CorrectiveAction);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                DataTable dt = _checkNative.InsertBulkA246CHankingFACACheckList(dtChecklist, Session["EmpNumber"].ToString());

                if (dt.Rows.Count > 0)
                {
                    //objmail.NotificationEmail("Rokeshkumar_D@foxlink.com");
                    objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "HankingFACA", 0);
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("HankingFACAChecklist");
                }
                else
                {
                    //objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "AOIFACA", 0);
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            //model.dtChecklist = _checkResult.MailParameterProdQualityAudit(model.BatchId);
            model.dtChecklist = _checkResult.GetFromByA246CFACAHankingCData();
            //model.Batches = (List<Batch>)Session["Batches"];
            return View("HankingFACAChecklist", model);
        }

        [HttpGet]
        public ActionResult HankingTodoTask()
        {

            WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
            //WorkFlowViewModel.Menuss = _objProject.GetMasterMenus();
            //workFlowViewModel.Menuss = _objProject.GetMasterMenus() as List<MasterMenuss>;
            //Session["Menuss"] = workFlowViewModel.Menuss;
            workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
            DataTable dt = _checkResult.GetHankingTASK(workFlowViewModel.EmployeeId);
            int TaskId = 0;
            int ResultId = 0;
            if (dt.Rows.Count > 0)
            {
                ResultId = Convert.ToInt32(dt.Rows[0]["ResultId"]);
                TaskId = Convert.ToInt32(dt.Rows[0]["TaskId"]);

            }

            workFlowViewModel.WorkFlowList = _checkResult.GetTaskStatusForA246CHankingChecklist(workFlowViewModel.EmployeeId, TaskId, ResultId);
            return View(workFlowViewModel);
        }

        [HttpPost]
        public ActionResult HankingApprove(List<WorkFlowViewModel> viewModelsResult)
        {
            //viewModelsResult.Menuss = (List<DOL.MasterMenuss>)Session["Menuss"];
            WorkFlowViewModel viewModelResult = new WorkFlowViewModel();
            //viewModelResult.Menuss = Session["Menuss"] as List<DOL.MasterMenuss> ?? new List<DOL.MasterMenuss>();

            if (viewModelsResult.All(v => v.TaskId == 20))
            {
                DataTable dtTaskListItem1 = new DataTable("TaskList");
                dtTaskListItem1.Columns.Add("Id");
                dtTaskListItem1.Columns.Add("Pid");
                dtTaskListItem1.Columns.Add("ResultId");
                dtTaskListItem1.Columns.Add("MenuId");
                dtTaskListItem1.Columns.Add("SectionId");
                dtTaskListItem1.Columns.Add("ApproveId");
                dtTaskListItem1.Columns.Add("TaskId");
                dtTaskListItem1.Columns.Add("Remark");
                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();
                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem1.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.SectionId, item.ApproveId, item.TaskId, item.Remark);
                        Uid++;
                    }
                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();

                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetHankingTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }

                    DataTable dt = _checkResult.ApproveTaskFinal(dtTaskListItem1);


                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Status"].ToString() == "Completed")
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "HankingApproveLast", TaskId);
                        }
                        else
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "HankingApprove", TaskId);
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("HankingTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                DataTable dtTaskListItem = new DataTable("TaskList");
                dtTaskListItem.Columns.Add("Id");
                dtTaskListItem.Columns.Add("Pid");
                dtTaskListItem.Columns.Add("ResultId");
                dtTaskListItem.Columns.Add("MenuId");
                dtTaskListItem.Columns.Add("SectionId");
                dtTaskListItem.Columns.Add("ApproveId");
                dtTaskListItem.Columns.Add("TaskId");
                dtTaskListItem.Columns.Add("Reason");


                WorkFlowViewModel obj = new WorkFlowViewModel();

                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();

                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.SectionId, item.ApproveId, item.TaskId, item.Reason);
                        Uid++;
                    }

                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetHankingTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }
                    DataTable dt = _checkResult.AOIApproveTask(dtTaskListItem);




                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Status"].ToString() == "Completed")
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "HankingApproveLast", TaskId);
                        }
                        else
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "HankingApprove", TaskId);
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("HankingTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;

                }

            }
            return RedirectToAction("HankingTodoTask");
        }

        public ActionResult HankingReject(List<WorkFlowViewModel> viewModelsResult)
        {
            WorkFlowViewModel viewModelResult = new WorkFlowViewModel();
            //viewModelResult.Menuss = Session["Menuss"] as List<DOL.MasterMenuss> ?? new List<DOL.MasterMenuss>();

            if (viewModelsResult.All(v => v.TaskId == 20))
            {
                DataTable dtTaskListItem1 = new DataTable("TaskList");
                dtTaskListItem1.Columns.Add("Id");
                dtTaskListItem1.Columns.Add("Pid");
                dtTaskListItem1.Columns.Add("ResultId");
                dtTaskListItem1.Columns.Add("MenuId");
                dtTaskListItem1.Columns.Add("SectionId");
                dtTaskListItem1.Columns.Add("ApproveId");
                dtTaskListItem1.Columns.Add("TaskId");
                dtTaskListItem1.Columns.Add("Remark");
                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();

                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem1.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.SectionId, item.ApproveId, item.TaskId, item.Remark);
                        Uid++;
                    }

                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetHankingTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }

                    DataTable dt = _checkResult.RejectTaskFinal(dtTaskListItem1);


                    if (dt.Rows.Count > 0)
                    {
                        try
                        {
                            objmailForQuality.NotificationEmail("", Convert.ToInt32(dt.Rows[0]["ResultId"]), "HankingReject", TaskId);
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("HankingTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                DataTable dtTaskListItem = new DataTable("TaskList");
                dtTaskListItem.Columns.Add("Id");
                dtTaskListItem.Columns.Add("Pid");
                dtTaskListItem.Columns.Add("ResultId");
                dtTaskListItem.Columns.Add("MenuId");
                dtTaskListItem.Columns.Add("SectionId");
                dtTaskListItem.Columns.Add("ApproveId");
                dtTaskListItem.Columns.Add("TaskId");
                dtTaskListItem.Columns.Add("Reason");

                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();
                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.SectionId, item.ApproveId, item.TaskId, item.Reason);
                        Uid++;
                    }
                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetHankingTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }
                    DataTable dt = _checkResult.RejectTaskForAOI(dtTaskListItem);
                    //DataTable dt = _checkResult.RejectTaskForAOI(dtTaskListItem);


                    if (dt.Rows.Count > 0)
                    {
                        try
                        {
                            //objmailForQuality.NotificationEmail(Convert.ToInt32(dt.Rows[0]["ResultId"]));
                            objmailForQuality.NotificationEmail("", Convert.ToInt32(dt.Rows[0]["ResultId"]), "HankingRejectFirst", TaskId);
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("HankingTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }


            return RedirectToAction("HankingTodoTask");
        }


        [HttpGet]
        public ActionResult NewHankingFACAChecklist()
        {
            A246CNewHankingSheetCheckListModelView model = new A246CNewHankingSheetCheckListModelView();
            model.dtChecklist = new DataTable();
            return View(model);
        }

        [HttpPost]
        public ActionResult NewHankingFACAChecklist(A246CNewHankingSheetCheckListModelView model)
        {

            model.dtChecklist = _checkResult.GetFromByA246CFACANewHankingCData();

            if (!ModelState.IsValid)
                return View(model);



            try
            {
                model.dtChecklist = _checkResult.GetFromByA246CFACANewHankingCData();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }
            return View(model);


        }

        [HttpPost]
        public ActionResult SaveNewHankingFACAChecklist(A246CNewHankingSheetCheckListModelView model)
        {
            DataTable dtChecklist = new DataTable("A246CNewHankingSheetCheckListResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("ResultId");
            dtChecklist.Columns.Add("RootCause");
            dtChecklist.Columns.Add("PreventiveAction");
            dtChecklist.Columns.Add("CorrectiveAction");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.A246CNewHankingSheetCheckListResults)
                {
                    dtChecklist.Rows.Add(Uid, row.ResultId, row.RootCause, row.PreventiveAction, row.CorrectiveAction);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                DataTable dt = _checkNative.InsertBulkA246CNewHankingFACACheckList(dtChecklist, Session["EmpNumber"].ToString());

                if (dt.Rows.Count > 0)
                {
                    //objmail.NotificationEmail("Rokeshkumar_D@foxlink.com");
                    objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "NewHankingFACA", 0);
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("NewHankingFACAChecklist");
                }
                else
                {
                    //objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "AOIFACA", 0);
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            //model.dtChecklist = _checkResult.MailParameterProdQualityAudit(model.BatchId);
            model.dtChecklist = _checkResult.GetFromByA246CFACANewHankingCData();
            //model.Batches = (List<Batch>)Session["Batches"];
            return View("NewHankingFACAChecklist", model);
        }

        [HttpGet]
        public ActionResult NewHankingTodoTask()
        {

            WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
            //WorkFlowViewModel.Menuss = _objProject.GetMasterMenus();
            //workFlowViewModel.Menuss = _objProject.GetMasterMenus() as List<MasterMenuss>;
            //Session["Menuss"] = workFlowViewModel.Menuss;
            workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
            DataTable dt = _checkResult.GetNewHankingTASK(workFlowViewModel.EmployeeId);
            int TaskId = 0;
            int ResultId = 0;
            if (dt.Rows.Count > 0)
            {
                ResultId = Convert.ToInt32(dt.Rows[0]["ResultId"]);
                TaskId = Convert.ToInt32(dt.Rows[0]["TaskId"]);

            }

            workFlowViewModel.WorkFlowList = _checkResult.GetTaskStatusForA246CNewHankingChecklist(workFlowViewModel.EmployeeId, TaskId, ResultId);
            return View(workFlowViewModel);
        }

        [HttpPost]
        public ActionResult NewHankingApprove(List<WorkFlowViewModel> viewModelsResult)
        {
            //viewModelsResult.Menuss = (List<DOL.MasterMenuss>)Session["Menuss"];
            WorkFlowViewModel viewModelResult = new WorkFlowViewModel();
            //viewModelResult.Menuss = Session["Menuss"] as List<DOL.MasterMenuss> ?? new List<DOL.MasterMenuss>();

            if (viewModelsResult.All(v => v.TaskId == 20))
            {
                DataTable dtTaskListItem1 = new DataTable("TaskList");
                dtTaskListItem1.Columns.Add("Id");
                dtTaskListItem1.Columns.Add("Pid");
                dtTaskListItem1.Columns.Add("ResultId");
                dtTaskListItem1.Columns.Add("MenuId");
                dtTaskListItem1.Columns.Add("SectionId");
                dtTaskListItem1.Columns.Add("ApproveId");
                dtTaskListItem1.Columns.Add("TaskId");
                dtTaskListItem1.Columns.Add("Remark");
                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();
                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem1.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.SectionId, item.ApproveId, item.TaskId, item.Remark);
                        Uid++;
                    }
                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();

                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetNewHankingTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }

                    DataTable dt = _checkResult.ApproveTaskFinal(dtTaskListItem1);


                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Status"].ToString() == "Completed")
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "NewHankingApproveLast", TaskId);
                        }
                        else
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "NewHankingApprove", TaskId);
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("NewHankingTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                DataTable dtTaskListItem = new DataTable("TaskList");
                dtTaskListItem.Columns.Add("Id");
                dtTaskListItem.Columns.Add("Pid");
                dtTaskListItem.Columns.Add("ResultId");
                dtTaskListItem.Columns.Add("MenuId");
                dtTaskListItem.Columns.Add("SectionId");
                dtTaskListItem.Columns.Add("ApproveId");
                dtTaskListItem.Columns.Add("TaskId");
                dtTaskListItem.Columns.Add("Reason");


                WorkFlowViewModel obj = new WorkFlowViewModel();

                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();

                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.SectionId, item.ApproveId, item.TaskId, item.Reason);
                        Uid++;
                    }

                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetNewHankingTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }
                    DataTable dt = _checkResult.AOIApproveTask(dtTaskListItem);




                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Status"].ToString() == "Completed")
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "NewHankingApproveLast", TaskId);
                        }
                        else
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "NewHankingApprove", TaskId);
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("NewHankingTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;

                }

            }
            return RedirectToAction("NewHankingTodoTask");
        }
        public ActionResult NewHankingReject(List<WorkFlowViewModel> viewModelsResult)
        {
            WorkFlowViewModel viewModelResult = new WorkFlowViewModel();
            //viewModelResult.Menuss = Session["Menuss"] as List<DOL.MasterMenuss> ?? new List<DOL.MasterMenuss>();

            if (viewModelsResult.All(v => v.TaskId == 20))
            {
                DataTable dtTaskListItem1 = new DataTable("TaskList");
                dtTaskListItem1.Columns.Add("Id");
                dtTaskListItem1.Columns.Add("Pid");
                dtTaskListItem1.Columns.Add("ResultId");
                dtTaskListItem1.Columns.Add("MenuId");
                dtTaskListItem1.Columns.Add("SectionId");
                dtTaskListItem1.Columns.Add("ApproveId");
                dtTaskListItem1.Columns.Add("TaskId");
                dtTaskListItem1.Columns.Add("Remark");
                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();

                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem1.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.SectionId, item.ApproveId, item.TaskId, item.Remark);
                        Uid++;
                    }

                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetNewHankingTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }

                    DataTable dt = _checkResult.RejectTaskFinal(dtTaskListItem1);


                    if (dt.Rows.Count > 0)
                    {
                        try
                        {
                            objmailForQuality.NotificationEmail("", Convert.ToInt32(dt.Rows[0]["ResultId"]), "NewHankingReject", TaskId);
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("NewHankingTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                DataTable dtTaskListItem = new DataTable("TaskList");
                dtTaskListItem.Columns.Add("Id");
                dtTaskListItem.Columns.Add("Pid");
                dtTaskListItem.Columns.Add("ResultId");
                dtTaskListItem.Columns.Add("MenuId");
                dtTaskListItem.Columns.Add("SectionId");
                dtTaskListItem.Columns.Add("ApproveId");
                dtTaskListItem.Columns.Add("TaskId");
                dtTaskListItem.Columns.Add("Reason");

                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();
                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.SectionId, item.ApproveId, item.TaskId, item.Reason);
                        Uid++;
                    }
                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetNewHankingTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }
                    DataTable dt = _checkResult.RejectTaskForAOI(dtTaskListItem);
                    //DataTable dt = _checkResult.RejectTaskForAOI(dtTaskListItem);


                    if (dt.Rows.Count > 0)
                    {
                        try
                        {
                            //objmailForQuality.NotificationEmail(Convert.ToInt32(dt.Rows[0]["ResultId"]));
                            objmailForQuality.NotificationEmail("", Convert.ToInt32(dt.Rows[0]["ResultId"]), "NewHankingRejectFirst", TaskId);
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("NewHankingTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }


            return RedirectToAction("NewHankingTodoTask");
        }

        [HttpGet]
        public ActionResult WCMFACAChecklist()
        {
            A246CWCMMCCheckListModelView model = new A246CWCMMCCheckListModelView();
            model.dtChecklist = new DataTable();
            return View(model);
        }

        [HttpPost]
        public ActionResult WCMFACAChecklist(A246CWCMMCCheckListModelView model)
        {

            model.dtChecklist = _checkResult.GetFromByA246CFACAWCMCData();

            if (!ModelState.IsValid)
                return View(model);



            try
            {
                model.dtChecklist = _checkResult.GetFromByA246CFACAWCMCData();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }
            return View(model);


        }

        [HttpPost]
        public ActionResult SaveWCMFACAChecklist(A246CWCMMCCheckListModelView model)
        {
            DataTable dtChecklist = new DataTable("A246CWCMMCCheckListResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("ResultId");
            dtChecklist.Columns.Add("RootCause");
            dtChecklist.Columns.Add("PreventiveAction");
            dtChecklist.Columns.Add("CorrectiveAction");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.A246CWCMMCCheckListResults)
                {
                    dtChecklist.Rows.Add(Uid, row.ResultId, row.RootCause, row.PreventiveAction, row.CorrectiveAction);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                DataTable dt = _checkNative.InsertBulkA246CWCMFACACheckList(dtChecklist, Session["EmpNumber"].ToString());

                if (dt.Rows.Count > 0)
                {
                    //objmail.NotificationEmail("Rokeshkumar_D@foxlink.com");
                    objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "WCMFACA", 0);
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("WCMFACAChecklist");
                }
                else
                {
                    //objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "AOIFACA", 0);
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            //model.dtChecklist = _checkResult.MailParameterProdQualityAudit(model.BatchId);
            model.dtChecklist = _checkResult.GetFromByA246CFACAWCMCData();
            //model.Batches = (List<Batch>)Session["Batches"];
            return View("WCMFACAChecklist", model);
        }


        [HttpGet]
        public ActionResult WCMTodoTask()
        {

            WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
            //WorkFlowViewModel.Menuss = _objProject.GetMasterMenus();
            //workFlowViewModel.Menuss = _objProject.GetMasterMenus() as List<MasterMenuss>;
            //Session["Menuss"] = workFlowViewModel.Menuss;
            workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
            DataTable dt = _checkResult.GetWCMTASK(workFlowViewModel.EmployeeId);
            int TaskId = 0;
            int ResultId = 0;
            if (dt.Rows.Count > 0)
            {
                ResultId = Convert.ToInt32(dt.Rows[0]["ResultId"]);
                TaskId = Convert.ToInt32(dt.Rows[0]["TaskId"]);

            }

            workFlowViewModel.WorkFlowList = _checkResult.GetTaskStatusForA246WCMChecklist(workFlowViewModel.EmployeeId, TaskId, ResultId);
            return View(workFlowViewModel);
        }

        [HttpPost]
        public ActionResult WCMApprove(List<WorkFlowViewModel> viewModelsResult)
        {
            //viewModelsResult.Menuss = (List<DOL.MasterMenuss>)Session["Menuss"];
            WorkFlowViewModel viewModelResult = new WorkFlowViewModel();
            //viewModelResult.Menuss = Session["Menuss"] as List<DOL.MasterMenuss> ?? new List<DOL.MasterMenuss>();

            if (viewModelsResult.All(v => v.TaskId == 20))
            {
                DataTable dtTaskListItem1 = new DataTable("TaskList");
                dtTaskListItem1.Columns.Add("Id");
                dtTaskListItem1.Columns.Add("Pid");
                dtTaskListItem1.Columns.Add("ResultId");
                dtTaskListItem1.Columns.Add("MenuId");
                dtTaskListItem1.Columns.Add("SectionId");
                dtTaskListItem1.Columns.Add("ApproveId");
                dtTaskListItem1.Columns.Add("TaskId");
                dtTaskListItem1.Columns.Add("Remark");
                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();
                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem1.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.SectionId, item.ApproveId, item.TaskId, item.Remark);
                        Uid++;
                    }
                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();

                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetWCMTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }

                    DataTable dt = _checkResult.ApproveTaskFinal(dtTaskListItem1);


                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Status"].ToString() == "Completed")
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "WCMApproveLast", TaskId);
                        }
                        else
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "WCMApprove", TaskId);
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("WCMTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                DataTable dtTaskListItem = new DataTable("TaskList");
                dtTaskListItem.Columns.Add("Id");
                dtTaskListItem.Columns.Add("Pid");
                dtTaskListItem.Columns.Add("ResultId");
                dtTaskListItem.Columns.Add("MenuId");
                dtTaskListItem.Columns.Add("SectionId");
                dtTaskListItem.Columns.Add("ApproveId");
                dtTaskListItem.Columns.Add("TaskId");
                dtTaskListItem.Columns.Add("Reason");


                WorkFlowViewModel obj = new WorkFlowViewModel();

                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();

                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.SectionId, item.ApproveId, item.TaskId, item.Reason);
                        Uid++;
                    }

                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetWCMTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }
                    DataTable dt = _checkResult.AOIApproveTask(dtTaskListItem);




                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Status"].ToString() == "Completed")
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "WCMApproveLast", TaskId);
                        }
                        else
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "WCMApprove", TaskId);
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("WCMTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;

                }

            }
            return RedirectToAction("WCMTodoTask");
        }


        public ActionResult WCMReject(List<WorkFlowViewModel> viewModelsResult)
        {
            WorkFlowViewModel viewModelResult = new WorkFlowViewModel();
            //viewModelResult.Menuss = Session["Menuss"] as List<DOL.MasterMenuss> ?? new List<DOL.MasterMenuss>();

            if (viewModelsResult.All(v => v.TaskId == 20))
            {
                DataTable dtTaskListItem1 = new DataTable("TaskList");
                dtTaskListItem1.Columns.Add("Id");
                dtTaskListItem1.Columns.Add("Pid");
                dtTaskListItem1.Columns.Add("ResultId");
                dtTaskListItem1.Columns.Add("MenuId");
                dtTaskListItem1.Columns.Add("SectionId");
                dtTaskListItem1.Columns.Add("ApproveId");
                dtTaskListItem1.Columns.Add("TaskId");
                dtTaskListItem1.Columns.Add("Remark");
                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();

                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem1.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.SectionId, item.ApproveId, item.TaskId, item.Remark);
                        Uid++;
                    }

                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetWCMTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }

                    DataTable dt = _checkResult.RejectTaskFinal(dtTaskListItem1);


                    if (dt.Rows.Count > 0)
                    {
                        try
                        {
                            objmailForQuality.NotificationEmail("", Convert.ToInt32(dt.Rows[0]["ResultId"]), "NewHankingReject", TaskId);
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("WCMTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                DataTable dtTaskListItem = new DataTable("TaskList");
                dtTaskListItem.Columns.Add("Id");
                dtTaskListItem.Columns.Add("Pid");
                dtTaskListItem.Columns.Add("ResultId");
                dtTaskListItem.Columns.Add("MenuId");
                dtTaskListItem.Columns.Add("SectionId");
                dtTaskListItem.Columns.Add("ApproveId");
                dtTaskListItem.Columns.Add("TaskId");
                dtTaskListItem.Columns.Add("Reason");

                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();
                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.SectionId, item.ApproveId, item.TaskId, item.Reason);
                        Uid++;
                    }
                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetWCMTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }
                    DataTable dt = _checkResult.RejectTaskForAOI(dtTaskListItem);
                    //DataTable dt = _checkResult.RejectTaskForAOI(dtTaskListItem);


                    if (dt.Rows.Count > 0)
                    {
                        try
                        {
                            //objmailForQuality.NotificationEmail(Convert.ToInt32(dt.Rows[0]["ResultId"]));
                            objmailForQuality.NotificationEmail("", Convert.ToInt32(dt.Rows[0]["ResultId"]), "NewHankingRejectFirst", TaskId);
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("WCMTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }


            return RedirectToAction("WCMTodoTask");
        }

        [HttpGet]
        public ActionResult A246CShellCrimpingFACAChecklist()
        {
            A246CShellCrimpMC1CheckListModelView model = new A246CShellCrimpMC1CheckListModelView();
            model.dtChecklist = new DataTable();
            return View(model);
        }

        [HttpPost]
        public ActionResult A246CShellCrimpingFACAChecklist(A246CShellCrimpMC1CheckListModelView model)
        {

            model.dtChecklist = _checkResult.GetFromByA246CFACAShellcrimpingCData();

            if (!ModelState.IsValid)
                return View(model);



            try
            {
                model.dtChecklist = _checkResult.GetFromByA246CFACAShellcrimpingCData();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }
            return View(model);


        }

        [HttpPost]
        public ActionResult SaveA246CShellCrimpingFACAChecklist(A246CShellCrimpMC1CheckListModelView model)
        {
            DataTable dtChecklist = new DataTable("A246CShellCrimpMC1CheckListResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("ResultId");
            dtChecklist.Columns.Add("RootCause");
            dtChecklist.Columns.Add("PreventiveAction");
            dtChecklist.Columns.Add("CorrectiveAction");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.A246CShellCrimpMC1CheckListResults)
                {
                    dtChecklist.Rows.Add(Uid, row.ResultId, row.RootCause, row.PreventiveAction, row.CorrectiveAction);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                DataTable dt = _checkNative.InsertBulkA246CShellCrimpingFACACheckList(dtChecklist, Session["EmpNumber"].ToString());

                if (dt.Rows.Count > 0)
                {
                    //objmail.NotificationEmail("Rokeshkumar_D@foxlink.com");
                    objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "A246CShellCrimpingFACA", 0);
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("A246CShellCrimpingFACAChecklist");
                }
                else
                {
                    //objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "AOIFACA", 0);
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            //model.dtChecklist = _checkResult.MailParameterProdQualityAudit(model.BatchId);
            model.dtChecklist = _checkResult.GetFromByA246CFACAShellcrimpingCData();
            //model.Batches = (List<Batch>)Session["Batches"];
            return View("A246CShellCrimpingFACAChecklist", model);
        }

        [HttpGet]
        public ActionResult A246CshellCrimpingTodoTask()
        {

            WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
            //WorkFlowViewModel.Menuss = _objProject.GetMasterMenus();
            //workFlowViewModel.Menuss = _objProject.GetMasterMenus() as List<MasterMenuss>;
            //Session["Menuss"] = workFlowViewModel.Menuss;
            workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
            DataTable dt = _checkResult.GetShellCrimpingTASK(workFlowViewModel.EmployeeId);
            int TaskId = 0;
            int ResultId = 0;
            if (dt.Rows.Count > 0)
            {
                ResultId = Convert.ToInt32(dt.Rows[0]["ResultId"]);
                TaskId = Convert.ToInt32(dt.Rows[0]["TaskId"]);

            }

            workFlowViewModel.WorkFlowList = _checkResult.GetTaskStatusForA246CShellcrimpingchecklist(workFlowViewModel.EmployeeId, TaskId, ResultId);
            return View(workFlowViewModel);
        }

        [HttpPost]
        public ActionResult A246CshellCrimpingApprove(List<WorkFlowViewModel> viewModelsResult)
        {
            //viewModelsResult.Menuss = (List<DOL.MasterMenuss>)Session["Menuss"];
            WorkFlowViewModel viewModelResult = new WorkFlowViewModel();
            //viewModelResult.Menuss = Session["Menuss"] as List<DOL.MasterMenuss> ?? new List<DOL.MasterMenuss>();

            if (viewModelsResult.All(v => v.TaskId == 20))
            {
                DataTable dtTaskListItem1 = new DataTable("TaskList");
                dtTaskListItem1.Columns.Add("Id");
                dtTaskListItem1.Columns.Add("Pid");
                dtTaskListItem1.Columns.Add("ResultId");
                dtTaskListItem1.Columns.Add("MenuId");
                dtTaskListItem1.Columns.Add("SectionId");
                dtTaskListItem1.Columns.Add("ApproveId");
                dtTaskListItem1.Columns.Add("TaskId");
                dtTaskListItem1.Columns.Add("Remark");
                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();
                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem1.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.SectionId, item.ApproveId, item.TaskId, item.Remark);
                        Uid++;
                    }
                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();

                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetShellCrimpingTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }

                    DataTable dt = _checkResult.ApproveTaskFinal(dtTaskListItem1);


                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Status"].ToString() == "Completed")
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "A246CshellCrimpingApproveLast", TaskId);
                        }
                        else
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "A246CshellCrimpingApprove", TaskId);
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("A246CshellCrimpingTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                DataTable dtTaskListItem = new DataTable("TaskList");
                dtTaskListItem.Columns.Add("Id");
                dtTaskListItem.Columns.Add("Pid");
                dtTaskListItem.Columns.Add("ResultId");
                dtTaskListItem.Columns.Add("MenuId");
                dtTaskListItem.Columns.Add("SectionId");
                dtTaskListItem.Columns.Add("ApproveId");
                dtTaskListItem.Columns.Add("TaskId");
                dtTaskListItem.Columns.Add("Reason");


                WorkFlowViewModel obj = new WorkFlowViewModel();

                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();

                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.SectionId, item.ApproveId, item.TaskId, item.Reason);
                        Uid++;
                    }

                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetShellCrimpingTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }
                    DataTable dt = _checkResult.AOIApproveTask(dtTaskListItem);




                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Status"].ToString() == "Completed")
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "A246CshellCrimpingApproveLast", TaskId);
                        }
                        else
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "A246CshellCrimpingApprove", TaskId);
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("A246CshellCrimpingTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;

                }

            }
            return RedirectToAction("A246CshellCrimpingTodoTask");
        }

        public ActionResult A246CshellCrimpingReject(List<WorkFlowViewModel> viewModelsResult)
        {
            WorkFlowViewModel viewModelResult = new WorkFlowViewModel();
            //viewModelResult.Menuss = Session["Menuss"] as List<DOL.MasterMenuss> ?? new List<DOL.MasterMenuss>();

            if (viewModelsResult.All(v => v.TaskId == 20))
            {
                DataTable dtTaskListItem1 = new DataTable("TaskList");
                dtTaskListItem1.Columns.Add("Id");
                dtTaskListItem1.Columns.Add("Pid");
                dtTaskListItem1.Columns.Add("ResultId");
                dtTaskListItem1.Columns.Add("MenuId");
                dtTaskListItem1.Columns.Add("SectionId");
                dtTaskListItem1.Columns.Add("ApproveId");
                dtTaskListItem1.Columns.Add("TaskId");
                dtTaskListItem1.Columns.Add("Remark");
                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();

                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem1.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.SectionId, item.ApproveId, item.TaskId, item.Remark);
                        Uid++;
                    }

                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetShellCrimpingTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }

                    DataTable dt = _checkResult.RejectTaskFinal(dtTaskListItem1);


                    if (dt.Rows.Count > 0)
                    {
                        try
                        {
                            objmailForQuality.NotificationEmail("", Convert.ToInt32(dt.Rows[0]["ResultId"]), "A246CShellCrimpingReject", TaskId);
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("NewHankingTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                DataTable dtTaskListItem = new DataTable("TaskList");
                dtTaskListItem.Columns.Add("Id");
                dtTaskListItem.Columns.Add("Pid");
                dtTaskListItem.Columns.Add("ResultId");
                dtTaskListItem.Columns.Add("MenuId");
                dtTaskListItem.Columns.Add("SectionId");
                dtTaskListItem.Columns.Add("ApproveId");
                dtTaskListItem.Columns.Add("TaskId");
                dtTaskListItem.Columns.Add("Reason");

                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();
                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.SectionId, item.ApproveId, item.TaskId, item.Reason);
                        Uid++;
                    }
                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetShellCrimpingTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }
                    DataTable dt = _checkResult.RejectTaskForAOI(dtTaskListItem);
                    //DataTable dt = _checkResult.RejectTaskForAOI(dtTaskListItem);


                    if (dt.Rows.Count > 0)
                    {
                        try
                        {
                            //objmailForQuality.NotificationEmail(Convert.ToInt32(dt.Rows[0]["ResultId"]));
                            objmailForQuality.NotificationEmail("", Convert.ToInt32(dt.Rows[0]["ResultId"]), "A246CShellCrimpingRejectFirst", TaskId);
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("A246CshellCrimpingTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }


            return RedirectToAction("A246CshellCrimpingTodoTask");
        }

        [HttpGet]
        public ActionResult A246CCCMFACAChecklist()
        {
            A246CCMMC1CheckListModelView model = new A246CCMMC1CheckListModelView();
            model.dtChecklist = new DataTable();
            return View(model);
        }

        [HttpPost]
        public ActionResult A246CCCMFACAChecklist(A246CCMMC1CheckListModelView model)
        {

            model.dtChecklist = _checkResult.GetFromByA246CFACACCMData();

            if (!ModelState.IsValid)
                return View(model);



            try
            {
                model.dtChecklist = _checkResult.GetFromByA246CFACACCMData();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }
            return View(model);


        }

        [HttpPost]
        public ActionResult SaveA246CCCMFACAChecklist(A246CCMMC1CheckListModelView model)
        {
            DataTable dtChecklist = new DataTable("A246CCMMC1CheckListResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("ResultId");
            dtChecklist.Columns.Add("RootCause");
            dtChecklist.Columns.Add("PreventiveAction");
            dtChecklist.Columns.Add("CorrectiveAction");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.A246CCMMC1CheckListResults)
                {
                    dtChecklist.Rows.Add(Uid, row.ResultId, row.RootCause, row.PreventiveAction, row.CorrectiveAction);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                DataTable dt = _checkNative.InsertBulkA246CCCMFACACheckList(dtChecklist, Session["EmpNumber"].ToString());

                if (dt.Rows.Count > 0)
                {
                    //objmail.NotificationEmail("Rokeshkumar_D@foxlink.com");
                    objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "A246CCCMFACA", 0);
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("A246CCCMFACAChecklist");
                }
                else
                {
                    //objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "AOIFACA", 0);
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            //model.dtChecklist = _checkResult.MailParameterProdQualityAudit(model.BatchId);
            model.dtChecklist = _checkResult.GetFromByA246CFACACCMData();
            //model.Batches = (List<Batch>)Session["Batches"];
            return View("A246CCCMFACAChecklist", model);
        }

        [HttpGet]
        public ActionResult A246CCCMTodoTask()
        {

            WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
            //WorkFlowViewModel.Menuss = _objProject.GetMasterMenus();
            //workFlowViewModel.Menuss = _objProject.GetMasterMenus() as List<MasterMenuss>;
            //Session["Menuss"] = workFlowViewModel.Menuss;
            workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
            DataTable dt = _checkResult.GetCCMTASK(workFlowViewModel.EmployeeId);
            int TaskId = 0;
            int ResultId = 0;
            if (dt.Rows.Count > 0)
            {
                ResultId = Convert.ToInt32(dt.Rows[0]["ResultId"]);
                TaskId = Convert.ToInt32(dt.Rows[0]["TaskId"]);

            }

            workFlowViewModel.WorkFlowList = _checkResult.GetTaskStatusForA246CCCMChecklist(workFlowViewModel.EmployeeId, TaskId, ResultId);
            return View(workFlowViewModel);
        }

        [HttpPost]
        public ActionResult A246CCCMApprove(List<WorkFlowViewModel> viewModelsResult)
        {
            //viewModelsResult.Menuss = (List<DOL.MasterMenuss>)Session["Menuss"];
            WorkFlowViewModel viewModelResult = new WorkFlowViewModel();
            //viewModelResult.Menuss = Session["Menuss"] as List<DOL.MasterMenuss> ?? new List<DOL.MasterMenuss>();

            if (viewModelsResult.All(v => v.TaskId == 20))
            {
                DataTable dtTaskListItem1 = new DataTable("TaskList");
                dtTaskListItem1.Columns.Add("Id");
                dtTaskListItem1.Columns.Add("Pid");
                dtTaskListItem1.Columns.Add("ResultId");
                dtTaskListItem1.Columns.Add("MenuId");
                dtTaskListItem1.Columns.Add("SectionId");
                dtTaskListItem1.Columns.Add("ApproveId");
                dtTaskListItem1.Columns.Add("TaskId");
                dtTaskListItem1.Columns.Add("Remark");
                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();
                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem1.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.SectionId, item.ApproveId, item.TaskId, item.Remark);
                        Uid++;
                    }
                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();

                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetCCMTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }

                    DataTable dt = _checkResult.ApproveTaskFinal(dtTaskListItem1);


                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Status"].ToString() == "Completed")
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "A246CCCMApproveLast", TaskId);
                        }
                        else
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "A246CCCMApprove", TaskId);
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("A246CCCMTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                DataTable dtTaskListItem = new DataTable("TaskList");
                dtTaskListItem.Columns.Add("Id");
                dtTaskListItem.Columns.Add("Pid");
                dtTaskListItem.Columns.Add("ResultId");
                dtTaskListItem.Columns.Add("MenuId");
                dtTaskListItem.Columns.Add("SectionId");
                dtTaskListItem.Columns.Add("ApproveId");
                dtTaskListItem.Columns.Add("TaskId");
                dtTaskListItem.Columns.Add("Reason");


                WorkFlowViewModel obj = new WorkFlowViewModel();

                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();

                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.SectionId, item.ApproveId, item.TaskId, item.Reason);
                        Uid++;
                    }

                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetCCMTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }
                    DataTable dt = _checkResult.AOIApproveTask(dtTaskListItem);




                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Status"].ToString() == "Completed")
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "A246CCCMApproveLast", TaskId);
                        }
                        else
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "A246CCCMApprove", TaskId);
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("A246CCCMTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;

                }

            }
            return RedirectToAction("A246CCCMTodoTask");
        }

        public ActionResult A246CCCMReject(List<WorkFlowViewModel> viewModelsResult)
        {
            WorkFlowViewModel viewModelResult = new WorkFlowViewModel();
            //viewModelResult.Menuss = Session["Menuss"] as List<DOL.MasterMenuss> ?? new List<DOL.MasterMenuss>();

            if (viewModelsResult.All(v => v.TaskId == 20))
            {
                DataTable dtTaskListItem1 = new DataTable("TaskList");
                dtTaskListItem1.Columns.Add("Id");
                dtTaskListItem1.Columns.Add("Pid");
                dtTaskListItem1.Columns.Add("ResultId");
                dtTaskListItem1.Columns.Add("MenuId");
                dtTaskListItem1.Columns.Add("SectionId");
                dtTaskListItem1.Columns.Add("ApproveId");
                dtTaskListItem1.Columns.Add("TaskId");
                dtTaskListItem1.Columns.Add("Remark");
                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();

                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem1.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.SectionId, item.ApproveId, item.TaskId, item.Remark);
                        Uid++;
                    }

                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetCCMTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }

                    DataTable dt = _checkResult.RejectTaskFinal(dtTaskListItem1);


                    if (dt.Rows.Count > 0)
                    {
                        try
                        {
                            objmailForQuality.NotificationEmail("", Convert.ToInt32(dt.Rows[0]["ResultId"]), "A246CCCMReject", TaskId);
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("A246CCCMTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                DataTable dtTaskListItem = new DataTable("TaskList");
                dtTaskListItem.Columns.Add("Id");
                dtTaskListItem.Columns.Add("Pid");
                dtTaskListItem.Columns.Add("ResultId");
                dtTaskListItem.Columns.Add("MenuId");
                dtTaskListItem.Columns.Add("SectionId");
                dtTaskListItem.Columns.Add("ApproveId");
                dtTaskListItem.Columns.Add("TaskId");
                dtTaskListItem.Columns.Add("Reason");

                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();
                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.SectionId, item.ApproveId, item.TaskId, item.Reason);
                        Uid++;
                    }
                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetCCMTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }
                    DataTable dt = _checkResult.RejectTaskForAOI(dtTaskListItem);
                    //DataTable dt = _checkResult.RejectTaskForAOI(dtTaskListItem);


                    if (dt.Rows.Count > 0)
                    {
                        try
                        {
                            //objmailForQuality.NotificationEmail(Convert.ToInt32(dt.Rows[0]["ResultId"]));
                            objmailForQuality.NotificationEmail("", Convert.ToInt32(dt.Rows[0]["ResultId"]), "A246CCCMRejectFirst", TaskId);
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("A246CCCMTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }


            return RedirectToAction("A246CCCMTodoTask");
        }

        [HttpGet]
        public ActionResult A246CDestructiveFACAChecklist()
        {
            A246CAOICheckListModelView model = new A246CAOICheckListModelView();
            model.dtChecklist = new DataTable();
            return View(model);
        }

        [HttpPost]
        public ActionResult A246CDestructiveFACAChecklist(A246CAOICheckListModelView model)
        {

            model.dtChecklist = _checkResult.GetFromByA246CFACAMHB2Data();

            if (!ModelState.IsValid)
                return View(model);



            try
            {
                model.dtChecklist = _checkResult.GetFromByA246CFACAMHB2Data();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }
            return View(model);


        }

        [HttpPost]
        public ActionResult SaveA246CDestructiveFACAChecklist(A246CAOICheckListModelView model)
        {
            DataTable dtChecklist = new DataTable("A246CAOICheckListResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("ResultId");
            dtChecklist.Columns.Add("RootCause");
            dtChecklist.Columns.Add("PreventiveAction");
            dtChecklist.Columns.Add("CorrectiveAction");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.A246CAOICheckListResults)
                {
                    dtChecklist.Rows.Add(Uid, row.ResultId, row.RootCause, row.PreventiveAction, row.CorrectiveAction);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                DataTable dt = _checkNative.InsertBulkA246CMHB2FACACheckList(dtChecklist, Session["EmpNumber"].ToString());

                if (dt.Rows.Count > 0)
                {
                    //objmail.NotificationEmail("Rokeshkumar_D@foxlink.com");
                    objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "A246CHB2FACA", 0);
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("A246CDestructiveFACAChecklist");
                }
                else
                {
                    //objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "AOIFACA", 0);
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            //model.dtChecklist = _checkResult.MailParameterProdQualityAudit(model.BatchId);
            model.dtChecklist = _checkResult.GetFromByA246CFACAMHB2Data();
            //model.Batches = (List<Batch>)Session["Batches"];
            return View("A246CDestructiveFACAChecklist", model);
        }

        [HttpGet]
        public ActionResult A246CDestructiveTodoTask()
        {

            WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
            //WorkFlowViewModel.Menuss = _objProject.GetMasterMenus();
            //workFlowViewModel.Menuss = _objProject.GetMasterMenus() as List<MasterMenuss>;
            //Session["Menuss"] = workFlowViewModel.Menuss;
            workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
            DataTable dt = _checkResult.GetHB2TASK(workFlowViewModel.EmployeeId);
            int TaskId = 0;
            int ResultId = 0;
            if (dt.Rows.Count > 0)
            {
                ResultId = Convert.ToInt32(dt.Rows[0]["ResultId"]);
                TaskId = Convert.ToInt32(dt.Rows[0]["TaskId"]);

            }

            workFlowViewModel.WorkFlowList = _checkResult.GetTaskStatusForMHB2CheckList(workFlowViewModel.EmployeeId, TaskId, ResultId);
            return View(workFlowViewModel);
        }

        [HttpPost]
        public ActionResult A246CDestructiveApprove(List<WorkFlowViewModel> viewModelsResult)
        {
            //viewModelsResult.Menuss = (List<DOL.MasterMenuss>)Session["Menuss"];
            WorkFlowViewModel viewModelResult = new WorkFlowViewModel();
            //viewModelResult.Menuss = Session["Menuss"] as List<DOL.MasterMenuss> ?? new List<DOL.MasterMenuss>();

            if (viewModelsResult.All(v => v.TaskId == 20))
            {
                DataTable dtTaskListItem1 = new DataTable("TaskList");
                dtTaskListItem1.Columns.Add("Id");
                dtTaskListItem1.Columns.Add("Pid");
                dtTaskListItem1.Columns.Add("ResultId");
                dtTaskListItem1.Columns.Add("MenuId");
                dtTaskListItem1.Columns.Add("SectionId");
                dtTaskListItem1.Columns.Add("ApproveId");
                dtTaskListItem1.Columns.Add("TaskId");
                dtTaskListItem1.Columns.Add("Remark");
                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();
                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem1.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.SectionId, item.ApproveId, item.TaskId, item.Remark);
                        Uid++;
                    }
                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();

                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetHB2TASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }

                    DataTable dt = _checkResult.ApproveTaskFinal(dtTaskListItem1);


                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Status"].ToString() == "Completed")
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "A246CDestructiveApproveLast", TaskId);
                        }
                        else
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "A246CDestructiveApprove", TaskId);
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("A246CDestructiveTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                DataTable dtTaskListItem = new DataTable("TaskList");
                dtTaskListItem.Columns.Add("Id");
                dtTaskListItem.Columns.Add("Pid");
                dtTaskListItem.Columns.Add("ResultId");
                dtTaskListItem.Columns.Add("MenuId");
                dtTaskListItem.Columns.Add("SectionId");
                dtTaskListItem.Columns.Add("ApproveId");
                dtTaskListItem.Columns.Add("TaskId");
                dtTaskListItem.Columns.Add("Reason");


                WorkFlowViewModel obj = new WorkFlowViewModel();

                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();

                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.SectionId, item.ApproveId, item.TaskId, item.Reason);
                        Uid++;
                    }

                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetHB2TASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }
                    DataTable dt = _checkResult.AOIApproveTask(dtTaskListItem);




                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Status"].ToString() == "Completed")
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "A246CDestructiveApproveLast", TaskId);
                        }
                        else
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "A246CDestructiveApprove", TaskId);
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("A246CDestructiveTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;

                }

            }
            return RedirectToAction("A246CDestructiveTodoTask");
        }


        public ActionResult A246CDestructiveReject(List<WorkFlowViewModel> viewModelsResult)
        {
            WorkFlowViewModel viewModelResult = new WorkFlowViewModel();
            //viewModelResult.Menuss = Session["Menuss"] as List<DOL.MasterMenuss> ?? new List<DOL.MasterMenuss>();

            if (viewModelsResult.All(v => v.TaskId == 20))
            {
                DataTable dtTaskListItem1 = new DataTable("TaskList");
                dtTaskListItem1.Columns.Add("Id");
                dtTaskListItem1.Columns.Add("Pid");
                dtTaskListItem1.Columns.Add("ResultId");
                dtTaskListItem1.Columns.Add("MenuId");
                dtTaskListItem1.Columns.Add("SectionId");
                dtTaskListItem1.Columns.Add("ApproveId");
                dtTaskListItem1.Columns.Add("TaskId");
                dtTaskListItem1.Columns.Add("Remark");
                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();

                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem1.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.SectionId, item.ApproveId, item.TaskId, item.Remark);
                        Uid++;
                    }

                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetHB2TASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }

                    DataTable dt = _checkResult.RejectTaskFinal(dtTaskListItem1);


                    if (dt.Rows.Count > 0)
                    {
                        try
                        {
                            objmailForQuality.NotificationEmail("", Convert.ToInt32(dt.Rows[0]["ResultId"]), "A246CDestructiveReject", TaskId);
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("A246CDestructiveTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                DataTable dtTaskListItem = new DataTable("TaskList");
                dtTaskListItem.Columns.Add("Id");
                dtTaskListItem.Columns.Add("Pid");
                dtTaskListItem.Columns.Add("ResultId");
                dtTaskListItem.Columns.Add("MenuId");
                dtTaskListItem.Columns.Add("SectionId");
                dtTaskListItem.Columns.Add("ApproveId");
                dtTaskListItem.Columns.Add("TaskId");
                dtTaskListItem.Columns.Add("Reason");

                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();
                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem.Rows.Add(Uid, item.Pid, item.ResultId, item.MenuId, item.SectionId, item.ApproveId, item.TaskId, item.Reason);
                        Uid++;
                    }
                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetHB2TASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }
                    DataTable dt = _checkResult.RejectTaskForAOI(dtTaskListItem);
                    //DataTable dt = _checkResult.RejectTaskForAOI(dtTaskListItem);


                    if (dt.Rows.Count > 0)
                    {
                        try
                        {
                            //objmailForQuality.NotificationEmail(Convert.ToInt32(dt.Rows[0]["ResultId"]));
                            objmailForQuality.NotificationEmail("", Convert.ToInt32(dt.Rows[0]["ResultId"]), "A246CDestructiveRejectFirst", TaskId);
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("A246CDestructiveTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }


            return RedirectToAction("A246CDestructiveTodoTask");
        }

        [HttpGet]
        public ActionResult A191MLaserEngravingFACAChecklist()
        {
            LasersizeViewModel model = new LasersizeViewModel();
            model.dtLaser = new DataTable();
            return View(model);
        }

        [HttpPost]
        public ActionResult A191MLaserEngravingFACAChecklist(LasersizeViewModel model)
        {

            model.dtLaser = _checkResult.GetFromByA191LaserData();

            if (!ModelState.IsValid)
                return View(model);



            try
            {
                model.dtLaser = _checkResult.GetFromByA191LaserData();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }
            return View(model);


        }

        [HttpPost]
        public ActionResult SaveA191MLaserEngravingFACAChecklist(LasersizeViewModel model)
        {
            DataTable dtChecklist = new DataTable("LaserCheckListResults");
            dtChecklist.Columns.Add("Id");
            dtChecklist.Columns.Add("ResultId");
            dtChecklist.Columns.Add("RootCause");
            dtChecklist.Columns.Add("PreventiveAction");
            dtChecklist.Columns.Add("CorrectiveAction");

            try
            {
                //  HttpFileCollectionBase files = Request.Files;

                int Uid = 1;

                foreach (var row in model.LaserCheckListResults)
                {
                    dtChecklist.Rows.Add(Uid, row.ResultId, row.RootCause, row.PreventiveAction, row.CorrectiveAction);
                    Uid++;

                }

                //int i = _checkResult.InsertCheckListResult(dtChecklist,Session["EmpNumber"].ToString());

                DataTable dt = _checkNative.InsertBulkA191MLASERFACACheckList(dtChecklist, Session["EmpNumber"].ToString());

                if (dt.Rows.Count > 0)
                {
                    //objmail.NotificationEmail("Rokeshkumar_D@foxlink.com");
                    objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "A191LaserFACA", 0);
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Results Saved!!!";
                    return RedirectToAction("A191MLaserEngravingFACAChecklist");
                }
                else
                {
                    //objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "AOIFACA", 0);
                    ModelState.AddModelError("ERROR", "Already Existed !!!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
                //Log.Error("Error", ex);
            }

            //return RedirectToAction("Index");
            //model.dtChecklist = _checkResult.MailParameterProdQualityAudit(model.BatchId);
            model.dtLaser = _checkResult.GetFromByA191LaserData();
            //model.Batches = (List<Batch>)Session["Batches"];
            return View("A191MLaserEngravingFACAChecklist", model);
        }

        [HttpGet]
        public ActionResult A191LaserTodoTask()
        {

            WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
            //WorkFlowViewModel.Menuss = _objProject.GetMasterMenus();
            //workFlowViewModel.Menuss = _objProject.GetMasterMenus() as List<MasterMenuss>;
            //Session["Menuss"] = workFlowViewModel.Menuss;
            workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
            DataTable dt = _checkResult.GetA191LASERTASK(workFlowViewModel.EmployeeId);
            int TaskId = 0;
            int ResultId = 0;
            if (dt.Rows.Count > 0)
            {
                ResultId = Convert.ToInt32(dt.Rows[0]["ResultId"]);
                TaskId = Convert.ToInt32(dt.Rows[0]["TaskId"]);

            }

            workFlowViewModel.WorkFlowList = _checkResult.GetTaskStatusForA191LaserEngraving(workFlowViewModel.EmployeeId, TaskId, ResultId);
            return View(workFlowViewModel);
        }

        [HttpPost]
        public ActionResult A191LaserApprove(List<WorkFlowViewModel> viewModelsResult)
        {
            //viewModelsResult.Menuss = (List<DOL.MasterMenuss>)Session["Menuss"];
            WorkFlowViewModel viewModelResult = new WorkFlowViewModel();
            //viewModelResult.Menuss = Session["Menuss"] as List<DOL.MasterMenuss> ?? new List<DOL.MasterMenuss>();

            if (viewModelsResult.All(v => v.TaskId == 20))
            {
                DataTable dtTaskListItem1 = new DataTable("TaskList");
                dtTaskListItem1.Columns.Add("Id");
                dtTaskListItem1.Columns.Add("Pid");
                dtTaskListItem1.Columns.Add("ResultId");
                //dtTaskListItem1.Columns.Add("MenuId");
                dtTaskListItem1.Columns.Add("LaserId");
                dtTaskListItem1.Columns.Add("ApproveId");
                dtTaskListItem1.Columns.Add("TaskId");
                dtTaskListItem1.Columns.Add("Remark");
                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();
                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem1.Rows.Add(Uid, item.Pid, item.ResultId, item.LaserId, item.ApproveId, item.TaskId, item.Remark);
                        Uid++;
                    }
                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();

                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetA191LASERTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }

                    DataTable dt = _checkResult.A191LaserBARApproveTask(dtTaskListItem1);


                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Status"].ToString() == "Completed")
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "A191LaserApproveLast", TaskId);
                        }
                        else
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "A191LaserApprove", TaskId);
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("A191LaserTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                DataTable dtTaskListItem = new DataTable("TaskList");
                dtTaskListItem.Columns.Add("Id");
                dtTaskListItem.Columns.Add("Pid");
                dtTaskListItem.Columns.Add("ResultId");
                //dtTaskListItem.Columns.Add("MenuId");
                dtTaskListItem.Columns.Add("LaserId");
                dtTaskListItem.Columns.Add("ApproveId");
                dtTaskListItem.Columns.Add("TaskId");
                dtTaskListItem.Columns.Add("Reason");


                WorkFlowViewModel obj = new WorkFlowViewModel();

                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();

                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem.Rows.Add(Uid, item.Pid, item.ResultId,item.LaserId, item.ApproveId, item.TaskId, item.Reason);
                        Uid++;
                    }

                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetA191LASERTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }
                    DataTable dt = _checkResult.A191LaserRApproveTask(dtTaskListItem);




                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Status"].ToString() == "Completed")
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "A191LaserApproveLast", TaskId);
                        }
                        else
                        {
                            objmailForQuality.NotificationEmail(dt.Rows[0]["Email"].ToString(), Convert.ToInt32(dt.Rows[0]["ResultId"]), "A191LaserApprove", TaskId);
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("A191LaserTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;

                }

            }
            return RedirectToAction("A191LaserTodoTask");
        }

        public ActionResult A191LaserReject(List<WorkFlowViewModel> viewModelsResult)
        {
            WorkFlowViewModel viewModelResult = new WorkFlowViewModel();
            //viewModelResult.Menuss = Session["Menuss"] as List<DOL.MasterMenuss> ?? new List<DOL.MasterMenuss>();

            if (viewModelsResult.All(v => v.TaskId == 20))
            {
                DataTable dtTaskListItem1 = new DataTable("TaskList");
                dtTaskListItem1.Columns.Add("Id");
                dtTaskListItem1.Columns.Add("Pid");
                dtTaskListItem1.Columns.Add("ResultId");
                //dtTaskListItem1.Columns.Add("MenuId");
                dtTaskListItem1.Columns.Add("LaserId");
                dtTaskListItem1.Columns.Add("ApproveId");
                dtTaskListItem1.Columns.Add("TaskId");
                dtTaskListItem1.Columns.Add("Remark");
                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();

                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem1.Rows.Add(Uid, item.Pid, item.ResultId, item.LaserId, item.ApproveId, item.TaskId, item.Remark);
                        Uid++;
                    }

                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetA191LASERTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }

                    DataTable dt = _checkResult.RejectTaskForA191LaserFinal(dtTaskListItem1);


                    if (dt.Rows.Count > 0)
                    {
                        try
                        {
                            objmailForQuality.NotificationEmail("", Convert.ToInt32(dt.Rows[0]["ResultId"]), "A191LaserReject", TaskId);
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("A191LaserTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                DataTable dtTaskListItem = new DataTable("TaskList");
                dtTaskListItem.Columns.Add("Id");
                dtTaskListItem.Columns.Add("Pid");
                dtTaskListItem.Columns.Add("ResultId");
                //dtTaskListItem.Columns.Add("MenuId");
                dtTaskListItem.Columns.Add("LaserId");
                dtTaskListItem.Columns.Add("ApproveId");
                dtTaskListItem.Columns.Add("TaskId");
                dtTaskListItem.Columns.Add("Reason");

                try
                {
                    int Uid = 1;
                    string employeeId = Session["EmpNumber"].ToString();
                    foreach (var item in viewModelsResult)
                    {
                        dtTaskListItem.Rows.Add(Uid, item.Pid, item.ResultId,  item.LaserId, item.ApproveId, item.TaskId, item.Reason);
                        Uid++;
                    }
                    WorkFlowViewModel workFlowViewModel = new WorkFlowViewModel();
                    workFlowViewModel.EmployeeId = (string)Session["EmpNumber"];
                    DataTable dt2 = _checkResult.GetA191LASERTASK(workFlowViewModel.EmployeeId);
                    int TaskId = 0;
                    int ResultId = 0;
                    if (dt2.Rows.Count > 0)
                    {
                        ResultId = Convert.ToInt32(dt2.Rows[0]["ResultId"]);
                        TaskId = Convert.ToInt32(dt2.Rows[0]["TaskId"]);

                    }
                    DataTable dt = _checkResult.RejectTaskForA191Laser(dtTaskListItem);
                    //DataTable dt = _checkResult.RejectTaskForAOI(dtTaskListItem);


                    if (dt.Rows.Count > 0)
                    {
                        try
                        {
                            //objmailForQuality.NotificationEmail(Convert.ToInt32(dt.Rows[0]["ResultId"]));
                            objmailForQuality.NotificationEmail("", Convert.ToInt32(dt.Rows[0]["ResultId"]), "A191LaserRejectFirst", TaskId);
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                        TempData["mgs"] = "Sucess";
                        TempData["Alert"] = "Sucessfully User Created!!!";

                        return RedirectToAction("A191LaserTodoTask");
                    }
                    else
                    {
                        ModelState.AddModelError("ERROR", "your leave is not apply some issue connect IT Administrator");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }


            return RedirectToAction("A191LaserTodoTask");
        }



        #region --> Post Method For Batches

        [HttpPost]
        public ActionResult GetBatchByProject(int ProjectId)
        {
            string PlantCode = string.Empty;

            List<DOL.Batch> PeriodList = new List<DOL.Batch>();

            DataTable dt = _objProject.GetBatchByProject(ProjectId);

            PeriodList = dt.DataTableToList<DOL.Batch>();

            string retStr = string.Empty;

            Session["Batches"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region --> Post Method For ProductionLineLeader

        [HttpPost]
        public ActionResult GetProductionLineLeaderByBatch(int ZoneId)
        {
            string PlantCode = string.Empty;

            List<DOL.ProductionLineLeader> PeriodList = new List<DOL.ProductionLineLeader>();

            DataTable dt = _objProject.GetProductionLineLeaderByBatch(ZoneId);

            PeriodList = dt.DataTableToList<DOL.ProductionLineLeader>();

            string retStr = string.Empty;

            Session["ProductionLineLeaders"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region --> Post Method For Zones

        [HttpPost]
        public ActionResult GetZoneByBatch(int BatchId)
        {
            string PlantCode = string.Empty;

            List<DOL.Zone> PeriodList = new List<DOL.Zone>();

            DataTable dt = _objProject.GetZoneByBatch(BatchId);

            PeriodList = dt.DataTableToList<DOL.Zone>();

            string retStr = string.Empty;

            Session["Zones"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region --> Post Method For ProdModules

        [HttpPost]
        public ActionResult GetProdModuleByProject(int ZoneId)
        {
            string PlantCode = string.Empty;

            List<DOL.ProdModule> PeriodList = new List<DOL.ProdModule>();

            DataTable dt = _objProject.GetProdModuleByProject(ZoneId);

            PeriodList = dt.DataTableToList<DOL.ProdModule>();

            string retStr = string.Empty;

            Session["ProdModules"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetShiftLeaderByBatch(int BatchId)
        {
            string PlantCode = string.Empty;

            List<DOL.ProdShiftLeader> PeriodList = new List<DOL.ProdShiftLeader>();

            DataTable dt = _objProject.GetShiftLeaderByBatch(BatchId);

            PeriodList = dt.DataTableToList<DOL.ProdShiftLeader>();

            string retStr = string.Empty;

            Session["ProdShiftLeaders"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region -->Get File Download
        [HttpGet]
        public FileResult Download(string Image)
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath("~/" + Image));
            return File(fileBytes, "text/plain");
            // return File(Url.Content("~/" + fileName), "text/plain");
        }
        #endregion

    }  
}
