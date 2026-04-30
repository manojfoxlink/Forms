using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAL;
using ChecklistForm.Models;
using System.Data;
using DOL;
using ChecklistForm.Utils;
using ChecklistForm.Filters;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using PagedList;
using PagedList.Mvc;
namespace ChecklistForm.Controllers
{
    [AuthenticateUser]
    [CheckSessionOut]
    public class ReportController : Controller
    {
        //
        // GET: /Report/
        ReportBAL _objRpt = new ReportBAL();
        ExportTypesClass _expClass = new ExportTypesClass();

        //BAL.CheckListCircuitRecord _CheckListCircuitRecord = new BAL.CheckListCircuitRecord();

        DAL.Project _objProject = new DAL.Project();

        BAL.MaintenanceCheckList _CheckListCircuitRecord = new BAL.MaintenanceCheckList();

        BAL.Category _objCategory = new BAL.Category();

        BAL.CheckListCircuitRecord _CircuitRecord = new BAL.CheckListCircuitRecord();

        BAL.CheckListResults _checkResult = new BAL.CheckListResults();

        Converters _cont = new Converters();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ParameterCheckList()
        {
            ReportModelView model = new ReportModelView();
            model.dtReports = new DataTable();
            model.Lines = _objRpt.GetLine();
            model.Shifts = _objRpt.GetShift();
            model.Projects = _objRpt.GetProject();
            Session["Lines"] = model.Lines;
            Session["Shifts"] = model.Shifts;
            Session["Projects"] = model.Projects;
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);
        }

        [HttpPost]
        public ActionResult ParameterCheckList(ReportModelView model,string command)
        {
            try
            {
                switch(command)
                {
                    case "Search":
                        model.dtReports = _objRpt.GetParamheCkhlistResult(model.ProjectId, model.StationId, model.SubStationId, model.ParameterId, model.LimitId, model.Actual, model.Result, model.FromDate, model.ToDate,model.LineId,model.shiftId);
                        Session["Reports"] = model.dtReports;
                        model.Lines = (List<Line>)Session["Lines"];
                        model.Shifts = (List<Shift>)Session["Shifts"];
                        model.Projects = (List<DOL.Project>)Session["Projects"];
                        break;
                    case "Export":
                        DataTable exportData = (DataTable)Session["Reports"];
                      
                        byte[] rendered;
                        string mini = string.Empty;
                        string ReportName = "ParmeterChecklist.rdlc";
                        string ReportFormate = model.ExportTypes[0];
                        if ( exportData != null )
                        {
                            _objRpt.generateReports( exportData, out rendered, out mini, ReportName, ReportFormate );
                            return File( rendered, mini );
                        }
                        break;
                }
               
            }
            catch (Exception)
            {
                
                throw;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);
        }
        [HttpGet]
        public ActionResult ParameterCheckCircuitList()
        {
            CheckCircuitListRecordView Model = new CheckCircuitListRecordView();
            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();
            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;
           Model.ExportTypes = _expClass.GetExportTypes();
            return View(Model);
        }
        [HttpPost]
        public ActionResult ParameterCheckCircuitList(CheckCircuitListRecordView model,string command)
        {  
            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            try
            {
                switch (command)
                {
                    case "Search":
                        model.dtReports = _objRpt.GetParamCheckCircuitResult(model.FromDate, model.LineId, model.ShiftId, model.ProjectId);
                        Session["Reports"] = model.dtReports;
                        break;


                    case "Export":
                        //model.dtReports = (DataTable)Session["Reports"];
                        //var gv = new GridView();

                        //gv.DataSource = model.dtReports;
                        //gv.DataBind();

                        //Response.ClearContent();
                        //Response.Buffer = true;
                        //Response.AddHeader("content-disposition", "attachment; filename=" + command + "Calculation.xls");
                        //Response.ContentType = "application/ms-excel";

                        //Response.Charset = "";
                        //StringWriter objStringWriter = new StringWriter();
                        //HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);

                        //gv.RenderControl(objHtmlTextWriter);

                        //Response.Output.Write(objStringWriter.ToString());
                        //Response.Flush();
                        //Response.End();

                        DataTable exportData =_objRpt.RptCircuitBoard(model.FromDate, model.LineId, model.ShiftId, model.ProjectId); //(DataTable)Session["Reports"];
                      
                        byte[] rendered;
                        string mini = string.Empty;
                        string ReportName = "CircuteBoard2.rdlc";
                        string ReportFormate ="pdf";//model.ExportTypes[0];
                        if ( exportData != null )
                        {
                            _objRpt.generateReports( exportData, out rendered, out mini, ReportName, ReportFormate );
                            return File( rendered, mini );
                        }


                        break;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);
        }

        [HttpGet]
        public ActionResult ParameterCheckListMaintenanceResult()
        {
            CheckListMaintenanceModelView Model = new CheckListMaintenanceModelView();
            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            //Model.Machines = _objRpt.GetMachine();
            Model.Machines = new List<DOL.Machine>();
            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            //Session["Machines"] = Model.Machines;
            Model.Projects = _CheckListCircuitRecord.GetProject();
            Session["Projects"] = Model.Projects;
            return View(Model);
        }

        [HttpPost]
        public ActionResult ParameterCheckListMaintenanceResult(CheckListMaintenanceModelView model, string command)
        {
           
            
            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Machines = (List<DOL.Machine>)Session["Machine"];
            model.Projects = (List<DOL.Project>)Session["Projects"];

            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.GetParamCheckMaintenanceResult(model.FromDate, model.LineId, model.ShiftId, model.MachineId, model.ProjectId);
                    Session["Reports"] = model.dtReports;
                    break;


                case "Export":
                    //model.dtReports = (DataTable)Session["Reports"];
                    //var gv = new GridView();

                    //gv.DataSource = model.dtReports;
                    //gv.DataBind();

                    //Response.ClearContent();
                    //Response.Buffer = true;
                    //Response.AddHeader("content-disposition", "attachment; filename=" + command + "MaintenanceResult.xls");
                    ////Response.ContentType = "application/ms-excel";
                    //Response.ContentType = "application/";
                    //Response.Charset = "";
                    //StringWriter objStringWriter = new StringWriter();
                    //HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);

                    //gv.RenderControl(objHtmlTextWriter);

                    //Response.Output.Write(objStringWriter.ToString());
                    //Response.Flush();
                    //Response.End();

                    if(model.ToDate !=null)
                    {
                        DataTable exportData =_objRpt.GetParamCheckRDLCMaintenanceResult(model.FromDate,model.ToDate,model.LineId,model.ShiftId, model.ProjectId); //(DataTable)Session["Reports"];

                        Session["Reports"] = exportData;
                        byte[] rendered;
                        string mini = string.Empty;
                        string ReportName = "MaintenanceMain.rdlc";
                        string ReportFormate = model.ExportType;
                        if (exportData != null)
                        {
                            _objRpt.generateReports(exportData, out rendered, out mini, ReportName, ReportFormate);
                            return File(rendered, mini);
                        }

                        //model.dtReports = (DataTable)Session["Reports"];
                        //var gv = new GridView();

                        //gv.DataSource = model.dtReports;
                        //gv.DataBind();

                        //Response.ClearContent();
                        //Response.Buffer = true;
                        //Response.AddHeader("content-disposition", "attachment; filename=" + command + "MaintenanceResult.xls");
                        ////Response.ContentType = "application/ms-excel";
                        //Response.ContentType = "application/";
                        //Response.Charset = "";
                        //StringWriter objStringWriter = new StringWriter();
                        //HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);

                        //gv.RenderControl(objHtmlTextWriter);

                        //Response.Output.Write(objStringWriter.ToString());
                        //Response.Flush();
                        //Response.End();

                        //byte[] rendered;
                        //string mini = string.Empty;
                        //string ReportName = "Maintenance2.rdlc";
                        //string ReportFormate = "pdf";//model.ExportTypes[0];
                        if (exportData != null)
                        {
                            _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                            return File(rendered, mini);
                        }


                    break;
                    }
                    else
                    {
                        DataTable exportData = _objRpt.GetParamCheckRDLCMaintenanceResult2(model.FromDate, model.LineId, model.ShiftId, model.MachineId, model.ProjectId); //(DataTable)Session["Reports"];

                        //byte[] rendered;
                        //string mini = string.Empty;
                        //string ReportName = "Maintenance2.rdlc";
                        //string ReportFormate = "pdf";//model.ExportTypes[0];
                        //if (exportData != null)
                        //{
                        //    _objRpt.generateReports(exportData, out rendered, out mini, ReportName, ReportFormate);
                        //    return File(rendered, mini);
                        //}

                        //Session["Report2"] = exportData;
                        //model.dtReports = (DataTable)Session["Report2"];
                        //var gv = new GridView();

                        //gv.DataSource = model.dtReports;
                        //gv.DataBind();

                        //Response.ClearContent();
                        //Response.Buffer = true;
                        //Response.AddHeader("content-disposition", "attachment; filename=" + command + "MaintenanceResult2.xls");
                        ////Response.ContentType = "application/ms-excel";
                        //Response.ContentType = "application/";
                        //Response.Charset = "";
                        //StringWriter objStringWriter = new StringWriter();
                        //HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);

                        //gv.RenderControl(objHtmlTextWriter);

                        //Response.Output.Write(objStringWriter.ToString());
                        //Response.Flush();
                        //Response.End();

                        Session["Reports"] = exportData;
                        byte[] rendered;
                        string mini = string.Empty;
                        string ReportName = "Maintenance3.rdlc";
                        string ReportFormate = model.ExportType;
                        if (exportData != null)
                        {
                            _objRpt.generateReports(exportData, out rendered, out mini, ReportName, ReportFormate);
                            return File(rendered, mini);
                        }
                        

                       break;
                    }
                    
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);
        }
        [HttpGet]
        public ActionResult ParameterCheckPointsResult()
        {
            CheckPointsResultModelView Model = new CheckPointsResultModelView();
            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Machines = _objRpt.GetMachine();
            Model.Machines = new List<DOL.Machine>();
            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Machine"] = Model.Machines;
            Model.Projects = _CheckListCircuitRecord.GetProject();
            Session["Projects"] = Model.Projects;
            return View(Model);
        }
        [HttpPost]
        public ActionResult ParameterCheckPointsResult(CheckPointsResultModelView model, string command)
        {
            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Machines = (List<DOL.Machine>)Session["Machine"];
            model.Projects = (List<DOL.Project>)Session["Projects"];


            switch (command)
            {
                case "Search":
                    model.dtReports = _objRpt.GetParamCheckPointsResult(model.FromDate, model.LineId, model.ShiftId, model.MachineId,model.ProjectId);
                    Session["Reports"] = model.dtReports;
                    break;


                case "Export":
                    //model.dtReports = (DataTable)Session["Reports"];
                    //var gv = new GridView();

                    //gv.DataSource = model.dtReports;
                    //gv.DataBind();

                    //Response.ClearContent();
                    //Response.Buffer = true;
                    //Response.AddHeader("content-disposition", "attachment; filename=" + command + "CheckPointsResult.xls");
                    //Response.ContentType = "application/ms-excel";

                    //Response.Charset = "";
                    //StringWriter objStringWriter = new StringWriter();
                    //HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);

                    //gv.RenderControl(objHtmlTextWriter);

                    //Response.Output.Write(objStringWriter.ToString());
                    //Response.Flush();

                   // Response.End();

                    DataTable exportData =_objRpt.GetParamRDLCCheckPointsResult(model.FromDate, model.LineId, model.ShiftId, model.MachineId,model.ProjectId); //(DataTable)Session["Reports"];
                      
                        byte[] rendered;
                        string mini = string.Empty;
                        string ReportName = "CheckPoints.rdlc";
                        string ReportFormate ="pdf";//model.ExportTypes[0];
                        if ( exportData != null )
                        {
                            _objRpt.generateReports( exportData, out rendered, out mini, ReportName, ReportFormate );
                            return File( rendered, mini );
                        }
                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }
        [HttpGet]
        public ActionResult ParameterLaserEngraving()
        {
            CheckListLaserGravingModelView Model = new CheckListLaserGravingModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Projects = _objRpt.GetProject();
            Model.Shifts = _objRpt.GetShift();
            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;
            
            return View(Model);
        }

        [HttpPost]
        public ActionResult ParameterLaserEngraving(CheckListLaserGravingModelView model, string command)
        {
            
            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];

            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.GetParamLaserEngravingResult(model.FromDate, model.LineId, model.ShiftId,model.ProjectId);
                    Session["Reports"] = model.dtReports;
                    break;


                case "Export":
                    //model.dtReports = (DataTable)Session["Reports"];
                    //var gv = new GridView();

                    //gv.DataSource = model.dtReports;
                    //gv.DataBind();

                    //Response.ClearContent();
                    //Response.Buffer = true;
                    //Response.AddHeader("content-disposition", "attachment; filename=LaserEngraving.xls");
                    ////Response.ContentType = "application/ms-excel";
                    //Response.ContentType = "application/ms-excel";
                    //Response.Charset = "";
                    //StringWriter objStringWriter = new StringWriter();
                    //HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);

                    //gv.RenderControl(objHtmlTextWriter);

                    //Response.Output.Write(objStringWriter.ToString());
                    //Response.Flush();
                    //Response.End();
                    DataTable exportData =_objRpt.GetRDLCParamLaserEngravingResult(model.FromDate, model.LineId, model.ShiftId, model.ProjectId); //(DataTable)Session["Reports"];
                      
                        byte[] rendered;
                        string mini = string.Empty;
                        string ReportName = "LaserEngraving.rdlc";
                        string ReportFormate ="pdf";//model.ExportTypes[0];
                        if ( exportData != null )
                        {
                            _objRpt.generateReports( exportData, out rendered, out mini, ReportName, ReportFormate );
                            return File( rendered, mini );
                        }


                        break;
                    
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);
        }

        [HttpGet]
        public ActionResult ParameterNativeValidation()
        {
            CheckListParameterNativeValidModelView Model = new CheckListParameterNativeValidModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();
            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;


            return View(Model);

        }
        [HttpPost]
        public ActionResult ParameterNativeValidation(CheckListParameterNativeValidModelView model, string command)
        {
            
            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            switch (command)
            {
                case "Search":
                    
                    model.dtReports = _objRpt.GetParameterNativeValidation(model.FromDate, model.LineId, model.ShiftId,model.ProjectId);
                    Session["Reports"] = model.dtReports;
                    break;


                case "Export":
                    //model.dtReports = (DataTable)Session["Reports"];
                    //var gv = new GridView();

                    //gv.DataSource = model.dtReports;
                    //gv.DataBind();

                    //Response.ClearContent();
                    //Response.Buffer = true;
                    //Response.AddHeader("content-disposition", "attachment; filename=" + command + "NagativeValidation.xls");
                    ////Response.ContentType = "application/ms-excel";
                    //Response.ContentType = "application/";
                    //Response.Charset = "";
                    //StringWriter objStringWriter = new StringWriter();
                    //HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);

                    //gv.RenderControl(objHtmlTextWriter);

                    //Response.Output.Write(objStringWriter.ToString());
                    //Response.Flush();
                    //Response.End();

                    DataTable exportData =_objRpt.GetRDLCParameterNativeValidation(model.FromDate, model.LineId, model.ShiftId, model.ProjectId); //(DataTable)Session["Reports"];
                      
                        byte[] rendered;
                        string mini = string.Empty;
                        string ReportName = "NativeValidation.rdlc";
                        string ReportFormate ="pdf";//model.ExportTypes[0];
                        if ( exportData != null )
                        {
                            _objRpt.generateReports( exportData, out rendered, out mini, ReportName, ReportFormate );
                            return File( rendered, mini );
                        }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterOutGoingInspection()
        {
            CheckListParameterOutGoingInspectionModelView Model = new CheckListParameterOutGoingInspectionModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();
            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;


            return View(Model);

        }

        [HttpPost]
        public ActionResult ParameterOutGoingInspection(CheckListParameterOutGoingInspectionModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];

            if (model.FromDate == "" && model.ToDate == "")
            {
                model.FromDate = "";
                model.ToDate = "";
            }
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.GetParameterOutGoingInspection(model.FromDate,model.ToDate, model.TrackNumber);
                    Session["Reports"] = model.dtReports;
                    break;


                case "Export":
                    
                    DataTable exportData = _objRpt.GetRDLCParameterListOutGoingInspection(model.FromDate,model.ToDate, model.TrackNumber); //(DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "OutgoingInspectionRecord.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterLineAuditCheckPoints()
        {
            CheckListParameterLineAuditCheckPoints Model = new CheckListParameterLineAuditCheckPoints();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();
            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;


            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        
        public ActionResult ParameterLineAuditCheckPoints(CheckListParameterLineAuditCheckPoints model, string command)
         {
            
            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];

            if (model.FromDate == "" && model.ToDate == "")
            {
                model.FromDate = "";
                model.ToDate = "";
            }
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.GetParameterLineAuditCheckpoints(model.FromDate, model.LineId, model.ShiftId, model.ProjectId);
                    Session["Reports"] = model.dtReports;

                   
                    break;


                case "Export":

                    DataTable exportData = _objRpt.GetRDLCParameterCheckListLineAudit(model.FromDate, model.LineId, model.ShiftId, model.ProjectId); //(DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "LineAudit.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterTrapTestChecklIst()
        {
            CheckListParameterTrapTestModelView Model = new CheckListParameterTrapTestModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();
            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;


            return View(Model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ParameterTrapTestChecklIst(CheckListParameterTrapTestModelView model, string command)
         {
            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];

            if (model.FromDate == "" && model.ToDate == "")
            {
                model.FromDate = "";
                model.ToDate = "";
            }
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.GetParameterTrapTestChecklist(model.FromDate, model.LineId, model.ShiftId, model.ProjectId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = _objRpt.getRDLCParameterTrapTest(model.FromDate, model.LineId, model.ShiftId, model.ProjectId); //(DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "TrapTest.rdlc";
                    if(model.ProjectId ==1)
                    {
                        ReportName = "TrapTest.rdlc";
                    }
                    else
                    {
                        ReportName = "TrapTest2.rdlc";
                    }
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterCircuitBoardRecord()
        {
            CheckListParameterCircuitBoardRecord Model = new CheckListParameterCircuitBoardRecord();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.ProcessTourss = _checkResult.GetProcessTours();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();
            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;
            Session["ProcessTourss"] = Model.ProcessTourss;

            return View(Model);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ParameterCircuitBoardRecord(CheckListParameterCircuitBoardRecord model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.ProcessTourss = (List<DOL.ProcessTourss>)Session["ProcessTourss"];

            if (model.FromDate == "" && model.ToDate == "")
            {
                model.FromDate = "";
                model.ToDate = "";
            }
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.GetParameterCircuitRecordResult(model.FromDate, model.LineId, model.ShiftId, model.ProjectId,model.ProcessTourId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = _objRpt.Rpt_RDLCgetParameterCircuitRecordResult(model.FromDate, model.LineId, model.ShiftId, model.ProjectId,model.ProcessTourId); //(DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "CircuitBoard.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterCTQManPowerChecklist()
        {
            CheckListParameterCTQManPowerModelView Model = new CheckListParameterCTQManPowerModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();
            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;


            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ParameterCTQManPowerChecklist(CheckListParameterCTQManPowerModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];

            if (model.FromDate == "" && model.ToDate == "")
            {
                model.FromDate = "";
                model.ToDate = "";
            }
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.ParameterCTQManPowerCheckList(model.FromDate, model.LineId, model.ShiftId, model.ProjectId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = _objRpt.Rpt_RDLCgetParameterCTQManPowerCheckList(model.FromDate, model.LineId, model.ShiftId, model.ProjectId); //(DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "CTQManPower.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterXBarChart()
        {
            CheckListParameterXBarChart Model = new CheckListParameterXBarChart();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();
            //Model.Adhesives = _CircuitRecord.GetAdhesive();
            Model.Adhesives = new List<Adhesivee>();
            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;
            //Session["Adhesives"] = Model.Adhesives;

            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ParameterXBarChart(CheckListParameterXBarChart model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.Adhesives = (List<DOL.Adhesivee>)Session["Adhesives"];

            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    Session["FromDate"] = model.FromDate;
                    Session["LineId"] = model.LineId;
                    Session["ShiftId"] = model.ShiftId;
                    Session["ProjectId"] = model.ProjectId;
                    Session["AdhesiveId"] = model.AdhesiveId;

                    model.dtReports = _objRpt.ParameterAdhesive(model.FromDate, model.LineId, model.ShiftId, model.ProjectId,model.AdhesiveId);
                    Session["Reports"] = model.dtReports;


                    
                    
                    break;


                case "Export":

                    DataTable exportData = _objRpt.Rpt_RDLCgetParameterXBarChart(model.FromDate, model.LineId, model.ShiftId, model.ProjectId,model.AdhesiveId); //(DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "XbarChart2.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View("ParameterXBarChart",model);

            //return View(model);
        }
        [HttpPost]
        public ActionResult Submit(CheckListParameterXBarChart model,string FeedBack,int ResultId)
        {
            model.dtReports = _objRpt.ParameterAdhesive2(ResultId);
           // int ResultId = 0;
            //if (model.dtReports.Rows.Count > 0)
            //{

            //    DataRow firstRow = model.dtReports.Rows[0];
            //    if (firstRow != null)
            //    {
            //        ResultId = Convert.ToInt32 (firstRow["ResultId"]);
            //        Session["ResultId"] = ResultId;
            //    }
            //}
            
            int i = _objRpt.UpdateXBar(ResultId, FeedBack);
            
                if (i > 0)
                {
                    Mail mail = new Mail();
                    mail.NotificationEmail(model.dtReports.Rows[0]["Adhesive"].ToString(), model.dtReports.Rows[0]["ProjectName"].ToString(), model.dtReports.Rows[0]["LineName"].ToString(), model.dtReports.Rows[0]["Email"].ToString(), "", ResultId);

                }
            
            
            return RedirectToAction("ParameterXBarChart");
            

        }

        [HttpGet]
        public ActionResult ParameterTempratureRange()
        {
            CheckListParameterTempratureRange Model = new CheckListParameterTempratureRange();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();
            Model.Ranges = new List<TempRange>();
            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;
            //Session["Ranges"] = Model.Ranges;

            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ParameterTempratureRange(CheckListParameterTempratureRange model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.Ranges = (List<DOL.TempRange>)Session["Ranges"];

            if (model.FromDate == "" && model.ToDate == "")
            {
                model.FromDate = "";
                model.ToDate = "";
            }
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.ParameterTempratureRange(model.FromDate, model.LineId, model.ShiftId, model.ProjectId, model.TempId);
                    Session["Reports"] = model.dtReports;
                    Session["Reports2"] = model.dtReports;

                    break;


                case "Export":

                    DataTable exportData = _objRpt.Rpt_RDLCgetParameterTempratureRange(model.FromDate, model.LineId, model.ShiftId, model.ProjectId, model.TempId); //(DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "TemperatureRange2.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterDestructiveTestRecord()
        {
            CheckListDestructiveTestRecordModelView Model = new CheckListDestructiveTestRecordModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();
            
            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;
            


            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ParameterDestructiveTestRecord(CheckListDestructiveTestRecordModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];

            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    if (model.FromDate != "" && model.LineId != 0 && model.ProjectId != 0 )
                    {
                        model.dtReports = _objRpt.ParameterDestructiveTest(model.FromDate, model.LineId, model.ShiftId, model.ProjectId);
                        Session["Reports"] = model.dtReports;
                    }
                    else if (model.FromDate != "" && model.LineId == 0 && model.ProjectId == 0 )
                    {
                        Session["Reports"] = null;
                        model.dtReports = _objRpt.ParameterDestructiveTest2(model.FromDate,model.ShiftId);
                        Session["Reports2"] = model.dtReports;
                    }
                    


                    break;


                case "Export":

                    DataTable exportData = _objRpt.Rpt_RDLCgetParameterDestructiveTest(model.FromDate, model.LineId, model.ShiftId, model.ProjectId); //(DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "Destructive2.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterWristStrap()
        {
            ParameterWristStrapModelView Model = new ParameterWristStrapModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();

            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ParameterWristStrap(ParameterWristStrapModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];

            if (model.FromDate == "" && model.ToDate == "")
            {
                model.FromDate = "";
                model.ToDate = "";
            }
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.ParameterWristStrap(model.FromDate, model.LineId, model.ShiftId, model.ProjectId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = _objRpt.Rpt_RDLCgetParameterWristStrap(model.FromDate, model.LineId, model.ShiftId, model.ProjectId); //(DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "WristStrap.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }
        [HttpGet]
        public ActionResult ParameterWorkSurface()
        {
            ParameterWorkSurfaceModelView Model = new ParameterWorkSurfaceModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();

            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ParameterWorkSurface(ParameterWorkSurfaceModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];

            if (model.FromDate == "" && model.ToDate == "")
            {
                model.FromDate = "";
                model.ToDate = "";
            }
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.ParameterWorkSurface(model.FromDate, model.LineId, model.ShiftId, model.ProjectId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = _objRpt.Rpt_getRDLCParameterWorkSurface(model.FromDate, model.LineId, model.ShiftId, model.ProjectId); //(DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "WorkSurface.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }
        [HttpGet]
        public ActionResult ParameterEquipment()
        {
            ParameterEquipmentModelView Model = new ParameterEquipmentModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();

            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ParameterEquipment(ParameterEquipmentModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];

            if (model.FromDate == "" && model.ToDate == "")
            {
                model.FromDate = "";
                model.ToDate = "";
            }
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.ParameterEquipment(model.FromDate, model.LineId, model.ShiftId, model.ProjectId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = _objRpt.Rpt_RDLCgetParameterEquipment(model.FromDate, model.LineId, model.ShiftId, model.ProjectId); //(DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "Equipment.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterInspectionLightLux()
        {
            ParameterInspectionLightLuxModelView Model = new ParameterInspectionLightLuxModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();

            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ParameterInspectionLightLux(ParameterInspectionLightLuxModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];

            if (model.FromDate == "" && model.ToDate == "")
            {
                model.FromDate = "";
                model.ToDate = "";
            }
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.ParameterInspectionLightLux(model.FromDate, model.LineId, model.ShiftId, model.ProjectId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = _objRpt.Rpt_RDLCgetParameterInspectionLightLux(model.FromDate, model.LineId, model.ShiftId, model.ProjectId); //(DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "LightLux(Inspection).rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterNonInspectionLightLux()
        {
            ParameterNonInspectionLighModeltLuxView Model = new ParameterNonInspectionLighModeltLuxView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();

            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ParameterNonInspectionLightLux(ParameterNonInspectionLighModeltLuxView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];

            if (model.FromDate == "" && model.ToDate == "")
            {
                model.FromDate = "";
                model.ToDate = "";
            }
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.ParameterNonInspectionLightLux(model.FromDate, model.LineId, model.ShiftId, model.ProjectId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = _objRpt.Rpt_RDLCgetParameterNonInspectionLightLux(model.FromDate, model.LineId, model.ShiftId, model.ProjectId); //(DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "LightLux(NonInspection).rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterQualityAudit()
        {
            ParameterQualityAuditModelView Model = new ParameterQualityAuditModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();

            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ParameterQualityAudit(ParameterQualityAuditModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];

            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.ParameterQualityAudit(model.FromDate, model.LineId, model.ShiftId, model.ProjectId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = _objRpt.Rpt_getRDLCParameterQualityAudit(model.FromDate, model.LineId, model.ShiftId, model.ProjectId); //(DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "QualityAudit.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }


        [HttpGet]
        public ActionResult ParameterOBA()
        {
            ParameteOBAModelView Model = new ParameteOBAModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();

            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ParameterOBA(ParameteOBAModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];

            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.ParameterOBA(model.FromDate, model.LineId, model.ShiftId, model.ProjectId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = _objRpt.Rpt_getRDLCParameterOBA(model.FromDate, model.LineId, model.ShiftId, model.ProjectId); //(DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "OBA.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterCosemticStudy()
        {
            ParameteCosmeticStudyModelView Model = new ParameteCosmeticStudyModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();

            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ParameterCosemticStudy(ParameteCosmeticStudyModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];

            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.getParameterCosmetic(model.FromDate, model.LineId, model.ShiftId, model.ProjectId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = _objRpt.Rpt_RDLCgetParameterCosmetic(model.FromDate, model.LineId, model.ShiftId, model.ProjectId); //(DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "CosmeticStudy.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameteOQCBoxConformation()
        {
            ParameteOQCBoxConformationModelView Model = new ParameteOQCBoxConformationModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();

            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ParameteOQCBoxConformation(ParameteOQCBoxConformationModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];

            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.getParameterOQCBoxConformation(model.FromDate, model.LineId, model.ShiftId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = _objRpt.Rpt_RDLCgetParameterOQCBoxConformation(model.FromDate, model.LineId, model.ShiftId); //(DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "OQCBoxConformation.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterFunctionalOOBTracking()
        {
            ParameterFunctionalOOBTrackingModelView Model = new ParameterFunctionalOOBTrackingModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();

            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ParameterFunctionalOOBTracking(ParameterFunctionalOOBTrackingModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];

            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.Rpt_getParameterFunctionalOOBTracking(model.FromDate, model.LineId, model.ShiftId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = _objRpt.Rpt_RDLCgetParameterFunctionalOOBTracking(model.FromDate, model.LineId, model.ShiftId); //(DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "FunctionalOOBTracking.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterAppTestFailure()
        {
            ParameterAppTestFailureModelView Model = new ParameterAppTestFailureModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            //Model.Projects = _objRpt.GetProject();

            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            //Session["Projects"] = Model.Projects;



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ParameterAppTestFailure(ParameterAppTestFailureModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            //model.Projects = (List<DOL.Project>)Session["Projects"];

            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.Rpt_getParameterAppTestFailure(model.FromDate, model.LineId, model.ShiftId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = _objRpt.Rpt_RDLCgetParameterCheckListAppTestFailure(model.FromDate, model.LineId, model.ShiftId); //(DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "AppTestFailure.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterCartonBoxList()
        {
            ParameterCartonBoxListModelView Model = new ParameterCartonBoxListModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            //Model.Projects = _objRpt.GetProject();

            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            //Session["Projects"] = Model.Projects;



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ParameterCartonBoxList(ParameterCartonBoxListModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            //model.Projects = (List<DOL.Project>)Session["Projects"];

            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.Rpt_getParameterCartonBoxList(model.FromDate, model.LineId, model.ShiftId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = _objRpt.Rpt_RDLCgetParameterCartonBoxList(model.FromDate, model.LineId, model.ShiftId); //(DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "CartonBoxList.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterTempratureRecord()
        {
            ParameterTempratureRecordModelView Model = new ParameterTempratureRecordModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            //Model.Projects = _objRpt.GetProject();

            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            //Session["Projects"] = Model.Projects;



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ParameterTempratureRecord(ParameterTempratureRecordModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            //model.Projects = (List<DOL.Project>)Session["Projects"];

            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.Rpt_getParameterTempratureRecord(model.FromDate, model.LineId, model.ShiftId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = _objRpt.Rpt_RDLCgetParameterCartonBoxList(model.FromDate, model.LineId, model.ShiftId); //(DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "CartonBoxList.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterHumidityRecord()
        {
            ParameterHumidityRecordModelView Model = new ParameterHumidityRecordModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            //Model.Projects = _objRpt.GetProject();

            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            //Session["Projects"] = Model.Projects;



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ParameterHumidityRecord(ParameterHumidityRecordModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            //model.Projects = (List<DOL.Project>)Session["Projects"];

            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.Rpt_getParameterHumidityRecord(model.FromDate, model.LineId, model.ShiftId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = _objRpt.Rpt_RDLCgetParameterHumidityRecord(model.FromDate, model.LineId, model.ShiftId); //(DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "CartonBoxList.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterA191FinsihedProduct()
        {
            ParameterA191FinsihedProductModelView Model = new ParameterA191FinsihedProductModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();
            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;

            Model.ExportTypes = _expClass.GetExportTypes();



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ParameterA191FinsihedProduct(ParameterA191FinsihedProductModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];

            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.Rpt_getParameterA191FinsihedProduct(model.FromDate, model.LineId, model.ShiftId,model.ProjectId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = _objRpt.Rpt_RDLCParameterA191FinsihedProduct(model.FromDate, model.LineId, model.ShiftId,model.ProjectId); //(DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "A191FinsihedProduct.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterCleaningIssue()
        {
            ParameterCleaningIssueModelView Model = new ParameterCleaningIssueModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();
            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;

            Model.ExportTypes = _expClass.GetExportTypes();



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ParameterCleaningIssue(ParameterCleaningIssueModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];

            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.Rpt_getParameterCleaningIssue(model.FromDate, model.LineId, model.ShiftId, model.ProjectId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = _objRpt.Rpt_RDLCgetParameterCleaningIssue(model.FromDate, model.LineId, model.ShiftId, model.ProjectId); //(DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "CleanIssue.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterFirstAirticleInspection()
        {
            FirstAirticleInspectionModelView Model = new FirstAirticleInspectionModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();
            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;

            Model.ExportTypes = _expClass.GetExportTypes();



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ParameterFirstAirticleInspection(FirstAirticleInspectionModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];

            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.Rpt_getParameterFirstAirticleInspection(model.FromDate, model.LineId, model.ShiftId, model.ProjectId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = _objRpt.Rpt_RDLCgetParameterFirstAirticleInspection(model.FromDate, model.LineId, model.ShiftId, model.ProjectId); //(DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "FirstArticleInspection.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }


        [HttpGet]
        public ActionResult ParameterFirstAirticleInspect()
        {
            FirstAirticleInspecModelView Model = new FirstAirticleInspecModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();
            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;

            Model.ExportTypes = _expClass.GetExportTypes();



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ParameterFirstAirticleInspect(FirstAirticleInspecModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];

            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.Rpt_getParameterFirstAirticleInspec(model.FromDate, model.LineId, model.ShiftId, model.ProjectId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = _objRpt.Rpt_RDLCgetParameterFirstAirticleInspect(model.FromDate, model.LineId, model.ShiftId, model.ProjectId); //(DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "FirstArticleInspect.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }



        [HttpGet]
        public ActionResult ParameterProcessTourData()
        {
            CheckListParameterProcessTourDataModelView Model = new CheckListParameterProcessTourDataModelView();
            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Visualss = new List<DOL.Visuals>();
            //Model.Machines = _objRpt.GetMachine();
            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            //Session["Machines"] = Model.Machines;
            //Model.Projects = _CheckListCircuitRecord.GetProject();
            Model.Projects = _objRpt.GetProject();
            Session["Projects"] = Model.Projects;
            return View(Model);
            
        }

        [HttpPost]
        public ActionResult ParameterProcessTourData(CheckListParameterProcessTourDataModelView model, string command)
        {
            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            //model.Machines = (List<DOL.Machine>)Session["Machine"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.Visualss = (List<DOL.Visuals>)Session["Visuals"];

            switch (command)
            {
                case "Search":
                    model.dtReports = _objRpt.getParameterProcessTourDataa(model.FromDate, model.LineId, model.ShiftId, model.ProjectId, model.VisualsId);
                    Session["ReportsA"] = model.dtReports;
                    break;


                case "Export":
                    //model.dtReports = (DataTable)Session["Reports"];
                    //var gv = new GridView();

                    //gv.DataSource = model.dtReports;
                    //gv.DataBind();

                    //Response.ClearContent();
                    //Response.Buffer = true;
                    //Response.AddHeader("content-disposition", "attachment; filename=" + command + "CheckPointsResult.xls");
                    //Response.ContentType = "application/ms-excel";

                    //Response.Charset = "";
                    //StringWriter objStringWriter = new StringWriter();
                    //HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);

                    //gv.RenderControl(objHtmlTextWriter);

                    //Response.Output.Write(objStringWriter.ToString());
                    //Response.Flush();

                    // Response.End();

                    DataTable exportData = _objRpt.GetParamRDLCProcessTourData(model.FromDate, model.LineId, model.ShiftId, model.ProjectId, model.VisualsId); //(DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "A246CprocessTourData.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }
                    break;

                case "ALL":
                    DataTable exportData1 = (DataTable)Session["ReportsA"];
                    Session["Data"] = (DataTable)exportData1;
                    model.dtReports = (DataTable)Session["Data"];
                    var gv = new GridView();

                    gv.DataSource = exportData1;
                    gv.DataBind();

                    Response.ClearContent();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", "attachment; filename=" + command + "A246CVisualInspectionConsildated.xls");
                    Response.ContentType = "application/ms-excel";

                    Response.Charset = "";
                    StringWriter objStringWriter = new StringWriter();
                    HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);

                    gv.RenderControl(objHtmlTextWriter);

                    Response.Output.Write(objStringWriter.ToString());
                    Response.Flush();
                    Response.End();

                    //byte[] rendered;
                    //string mini = string.Empty;
                    //string ReportName = "";
                    //if (model.ToDate == null)
                    //{
                    //     ReportName = "OutWard.rdlc";
                    //}
                    //else
                    //{
                    //    //ReportName = "OutWard2.rdlc";ConsumalOutWardConsalidated
                    //    ReportName = "ConsumalOutWardConsalidated.rdlc";
                    //}
                    //string ReportFormate = model.ExportType[0];
                    //if (exportData != null)
                    //{
                    //    _objReport.generateReports(exportData, out rendered, out mini, ReportName, ReportFormate);
                    //    return File(rendered, mini);
                    //}
                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
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
        //#region -->Get File Download
        //[HttpGet]
        //public FileResult Download(int AuditId)
        //{
        //    DataTable dt = (DataTable)Session["Reports"];
        //    var results = from myRow in dt.AsEnumerable()
        //                  where myRow.Field<int>("AuditId") == AuditId
        //                  select myRow.Field<string>("Image");
        //    byte[] fileBytes = System.IO.File.ReadAllBytes(results.FirstOrDefault());
        //    //return File(fileBytes, "text/plain");
        //   return  File(Url.Content(results.FirstOrDefault()), "text/plain");
        //}
        //#endregion

        #region -->Get File Download
        [HttpGet]
        public FileResult Download(string Image)
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath("~/" + Image));
            return File(fileBytes, "text/plain");
            // return File(Url.Content("~/" + fileName), "text/plain");
        }
        #endregion

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

        #region -->Post Method For  Machine

        [HttpPost]
        public ActionResult GetMachineByProjectt(int ProjectId)
        {
            string PlantCode = string.Empty;
            List<DOL.Machine> Machinelist = new List<DOL.Machine>();

            DataTable dt = _objRpt.GetMachineByProject(ProjectId);


            Machinelist = dt.DataTableToList<DOL.Machine>();

            string retStr = string.Empty;


            Session["Machine"] = Machinelist;
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



        [HttpGet]
        public ActionResult ParameterA246CCMMC1CheckList()
        {
            RptA246CCMMC1CheckListModelView Model = new RptA246CCMMC1CheckListModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();
            Model.Machines = _objRpt.GetA246CMachines();
            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;
            Session["Machines"] = Model.Machines;
            Model.ExportTypes = _expClass.GetExportTypes();



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ParameterA246CCMMC1CheckList(RptA246CCMMC1CheckListModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.ParameterA246CCMMC1CheckList1(model.FromDate, model.LineId, model.ShiftId, model.ProjectId,model.MachineId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = (DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "CCM.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterA246CWCMMC1CheckList()
        {
            RptParameterA246CWCMMC1CheckList Model = new RptParameterA246CWCMMC1CheckList();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();
            Model.Machines = _objRpt.GetA246CMachines();
            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;
            Session["Machines"] = Model.Machines;
            Model.ExportTypes = _expClass.GetExportTypes();



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ParameterA246CWCMMC1CheckList(RptParameterA246CWCMMC1CheckList model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.ParameterA246CWCMMC1CheckList(model.FromDate, model.LineId, model.ShiftId, model.ProjectId, model.MachineId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = (DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "A246CWCM.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterA246CMHB1CheckList()
        {
            RptParameterA246CMHB1CheckList Model = new RptParameterA246CMHB1CheckList();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();
            Model.Machines = _objRpt.GetA246CMachines();
            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;
            Session["Machines"] = Model.Machines;
            Model.ExportTypes = _expClass.GetExportTypes();



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ParameterA246CMHB1CheckList(RptParameterA246CMHB1CheckList model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.ParameterA246CMHB1CheckList(model.FromDate, model.LineId, model.ShiftId, model.ProjectId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData =(DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "A246CHB1.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterA246CMHB2CheckList()
        {
            RptParameterA246CMHB2CheckList Model = new RptParameterA246CMHB2CheckList();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();
            Model.Machines = _objRpt.GetA246CMachines();
            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;
            Session["Machines"] = Model.Machines;
            Model.ExportTypes = _expClass.GetExportTypes();



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ParameterA246CMHB2CheckList(RptParameterA246CMHB2CheckList model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.ParameterA246CMHB2CheckList(model.FromDate, model.LineId, model.ShiftId, model.ProjectId,model.MachineId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = (DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "A246CHB2.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterA246CShellCrimpMC1CheckList()
        {
            RptParameterA246CShellCrimpMC1CheckList Model = new RptParameterA246CShellCrimpMC1CheckList();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();
            Model.Machines = _objRpt.GetA246CMachines();
            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;
            Session["Machines"] = Model.Machines;
            Model.ExportTypes = _expClass.GetExportTypes();



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ParameterA246CShellCrimpMC1CheckList(RptParameterA246CShellCrimpMC1CheckList model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.ParameterA246CShellCrimpMC1CheckList(model.FromDate, model.LineId, model.ShiftId, model.ProjectId, model.MachineId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = (DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "A246CShellCrimp.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }


        [HttpGet]
        public ActionResult ParameterA246CInnerMoldMCCheckList()
        {
            RptParameterA246CInnerMoldMCCheckList Model = new RptParameterA246CInnerMoldMCCheckList();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();
            Model.Machines = _objRpt.GetA246CMachines();
            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;
            Session["Machines"] = Model.Machines;
            Model.ExportTypes = _expClass.GetExportTypes();



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ParameterA246CInnerMoldMCCheckList(RptParameterA246CInnerMoldMCCheckList model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.ParameterA246CInnerMoldMCCheckList(model.FromDate, model.LineId, model.ShiftId, model.ProjectId, model.MachineId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = (DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "A246CInnerMolding.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }


        [HttpGet]
        public ActionResult ParameterA246CBAndFCheckList()
        {
            RptParameterA246CBAndFCheckList Model = new RptParameterA246CBAndFCheckList();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();
            Model.Machines = _objRpt.GetA246CMachines();
            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;
            Session["Machines"] = Model.Machines;
            Model.ExportTypes = _expClass.GetExportTypes();



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ParameterA246CBAndFCheckList(RptParameterA246CBAndFCheckList model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.ParameterA246CBAndFCheckList(model.FromDate, model.LineId, model.ShiftId, model.ProjectId, model.MachineId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = (DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "A246CBandF.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterA246CAOIDataCheckList()
        {
            RptParameterA246CAOIDataCheckList Model = new RptParameterA246CAOIDataCheckList();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();
            Model.Machines = _objRpt.GetA246CMachines();
            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;
            Session["Machines"] = Model.Machines;
            Model.ExportTypes = _expClass.GetExportTypes();



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ParameterA246CAOIDataCheckList(RptParameterA246CAOIDataCheckList model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.ParameterA246CAOICheckList(model.FromDate, model.LineId, model.ShiftId, model.ProjectId, model.MachineId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = (DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "A246CAOI.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        //[HttpGet]
        //public ActionResult ParameterA246CHankingCheckList()
        //{
        //    RptParameterA246CHankingCheckList Model = new RptParameterA246CHankingCheckList();

        //    Model.dtReports = new DataTable();
        //    Model.Lines = _objRpt.GetLine();
        //    Model.Shifts = _objRpt.GetShift();
        //    Model.Projects = _objRpt.GetProject();
        //    Model.Machines = _objRpt.GetA246CMachines();
        //    Session["Lines"] = Model.Lines;
        //    Session["Shifts"] = Model.Shifts;
        //    Session["Projects"] = Model.Projects;
        //    Session["Machines"] = Model.Machines;
        //    Model.ExportTypes = _expClass.GetExportTypes();



        //    return View(Model);

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult ParameterA246CHankingCheckList(RptParameterA246CHankingCheckList model, string command)
        //{

        //    model.Lines = (List<Line>)Session["Lines"];
        //    model.Shifts = (List<Shift>)Session["Shifts"];
        //    model.Projects = (List<DOL.Project>)Session["Projects"];
        //    model.Machines = (List<DOL.A246CMachines>)Session["Machines"];
        //    //if (model.FromDate == "" && model.ToDate == "")
        //    //{
        //    //    model.FromDate = "";
        //    //    model.ToDate = "";
        //    //}
        //    switch (command)
        //    {
        //        case "Search":

        //            model.dtReports = _objRpt.ParameterA246CHankingCheckList(model.FromDate, model.LineId, model.ShiftId, model.ProjectId, model.MachineId);
        //            Session["Reports"] = model.dtReports;


        //            break;


        //        //case "Export":

        //        //    DataTable exportData = _objRpt.Rpt_RDLCgetParameterFirstAirticleInspect(model.FromDate, model.LineId, model.ShiftId, model.ProjectId); //(DataTable)Session["Reports"];

        //        //    byte[] rendered;
        //        //    string mini = string.Empty;
        //        //    string ReportName = "FirstArticleInspect.rdlc";
        //        //    string ReportFormate = "pdf";//model.ExportTypes[0];
        //        //    if (exportData != null)
        //        //    {
        //        //        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
        //        //        return File(rendered, mini);
        //        //    }

        //        //    break;
        //    }
        //    model.ExportTypes = _expClass.GetExportTypes();
        //    return View(model);

        //    //return View(model);
        //}

        [HttpGet]
        public ActionResult ParameterA246CHankingCheckList()
        {
            RptParameterA246CHankingCheckList Model = new RptParameterA246CHankingCheckList();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();
            Model.Machines = _objRpt.GetA246CMachines();
            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;
            Session["Machines"] = Model.Machines;
            Model.ExportTypes = _expClass.GetExportTypes();



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ParameterA246CHankingCheckList(RptParameterA246CHankingCheckList model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.ParameterA246CHankingCheckList(model.FromDate, model.LineId, model.ShiftId, model.ProjectId, model.MachineId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = (DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "A246CHanking.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterA246CLaserEngravingCheckList()
        {
            RptParameterA246CLaserEngraving Model = new RptParameterA246CLaserEngraving();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();
           // Model.Machines = _objRpt.GetA246CMachines();
            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;
           // Session["Machines"] = Model.Machines;
            Model.ExportTypes = _expClass.GetExportTypes();



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ParameterA246CLaserEngravingCheckList(RptParameterA246CLaserEngraving model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            //model.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.Rpt_getParameterA246CLaserEngravingData(model.FromDate, model.LineId, model.ShiftId, model.ProjectId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = (DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "A246CLaserEngraving.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterA246CHumidityRecord()
        {
            ParameterHumidityRecordModelView Model = new ParameterHumidityRecordModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            //Model.Projects = _objRpt.GetProject();

            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            //Session["Projects"] = Model.Projects;



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ParameterA246CHumidityRecord(ParameterHumidityRecordModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            //model.Projects = (List<DOL.Project>)Session["Projects"];

            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.Rpt_getParameterA246CHumidityRecord(model.FromDate, model.LineId, model.ShiftId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = (DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "CartonBoxList.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterA246CTempratureRecord()
        {
            ParameterTempratureRecordModelView Model = new ParameterTempratureRecordModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            //Model.Projects = _objRpt.GetProject();

            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            //Session["Projects"] = Model.Projects;



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ParameterA246CTempratureRecord(ParameterTempratureRecordModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            //model.Projects = (List<DOL.Project>)Session["Projects"];

            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.Rpt_getParameterA246CTempratureRecord(model.FromDate, model.LineId, model.ShiftId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = (DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "A246CTemperature.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }


        [HttpGet]
        public ActionResult ParameterA246CWristStrap()
        {
            ParameterA246CWristStrapModelView Model = new ParameterA246CWristStrapModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();

            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ParameterA246CWristStrap(ParameterA246CWristStrapModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];

            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.A246CParameterWristStrap(model.FromDate, model.LineId, model.ShiftId,model.ProjectId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = (DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "A246CWristStrap.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterA246CCheckListEquipment()
        {
            ParameterCheckListEquipmentModelView Model = new ParameterCheckListEquipmentModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();

            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ParameterA246CCheckListEquipment(ParameterCheckListEquipmentModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];

            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.A246CParameterEquipment(model.FromDate, model.LineId, model.ShiftId, model.ProjectId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = (DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "A246CEquipment.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterA246CCheckListLightLuxInspection()
        {
            ParameterCheckListEquipmentModelView Model = new ParameterCheckListEquipmentModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();

            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ParameterA246CCheckListLightLuxInspection(ParameterCheckListEquipmentModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];

            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.Rpt_getA246CCheckListLightLuxInspection(model.FromDate, model.LineId, model.ShiftId, model.ProjectId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = (DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "A246CLightLux.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterA246CCheckListLightNonLuxInspection()
        {
            ParameterCheckListEquipmentModelView Model = new ParameterCheckListEquipmentModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();

            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ParameterA246CCheckListLightNonLuxInspection(ParameterCheckListEquipmentModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];

            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.Rpt_getA246CCheckListLightNonLuxInspection(model.FromDate, model.LineId, model.ShiftId, model.ProjectId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = (DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "A246CLightNonLux.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterA246CCheckTableMatESD()
        {
            ParameterCheckListEquipmentModelView Model = new ParameterCheckListEquipmentModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();

            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ParameterA246CCheckTableMatESD(ParameterCheckListEquipmentModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];

            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.Rpt_getA246CCheckTableMatESD(model.FromDate, model.LineId, model.ShiftId, model.ProjectId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = (DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "A246CCheckTableMatESD.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterA246CSurfaceImpedence()
        {
            ParameterCheckListEquipmentModelView Model = new ParameterCheckListEquipmentModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();

            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ParameterA246CSurfaceImpedence(ParameterCheckListEquipmentModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];

            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.Rpt_getA246CSurfaceImpedence(model.FromDate, model.LineId, model.ShiftId, model.ProjectId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = (DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "A246CSurfaceImpedence.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }



        [HttpGet]
        public ActionResult ParameterA246CDestructiveMachine()
        {
            RptParameterA246CDestructiveMachineModelView Model = new RptParameterA246CDestructiveMachineModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();
            Model.Machines = _objRpt.GetA246CMachines();
            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;
            Session["Machines"] = Model.Machines;



            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ParameterA246CDestructiveMachine(RptParameterA246CDestructiveMachineModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.Rpt_getParameterA246CDestructiveMachineCheckList(model.FromDate, model.ShiftId, model.ProjectId,model.MachineId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":
                    
                    DataTable exportData = (DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "A246CDestructiveMachine.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        public ActionResult ParameterA246CDMachine()
        {
            RptParameterA246CDestructiveMachineModelView Model = new RptParameterA246CDestructiveMachineModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();
            Model.Machines = _objRpt.GetA246CMachines();
            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;
            Session["Machines"] = Model.Machines;


            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ParameterA246CDMachine(RptParameterA246CDestructiveMachineModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.Machines = (List<DOL.A246CMachines>)Session["Machines"];

            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.Rpt_getParameterA246CDMachineCheckList(model.FromDate, model.LineId, model.ShiftId, model.ProjectId,model.MachineId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = (DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "A246CDMachine.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterA246CNewHankingCheckList()
        {
            RptParameterA246CMHB2CheckList Model = new RptParameterA246CMHB2CheckList();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();
            Model.Machines = _objRpt.GetA246CMachines();
            Model.ModelNos = new List<DOL.ModelNo>();
            Model.PartNos = new List<DOL.PartNo>();
            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;
            Session["Machines"] = Model.Machines;


            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ParameterA246CNewHankingCheckList(RptParameterA246CMHB2CheckList model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.Machines = (List<DOL.A246CMachines>)Session["Machines"];

            model.ModelNos = (List<DOL.ModelNo>)Session["ModelNos"];
            model.PartNos = (List<DOL.PartNo>)Session["PartNos"];

            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.Rpt_getParameterA246CNewHankingCheckList(model.FromDate, model.LineId, model.ShiftId, model.ProjectId, model.MachineId,model.PartId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = (DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "A246CNewHanking.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterA246CWeighingMachineCheckList()
        {
            RptParameterA246CDestructiveMachineModelView Model = new RptParameterA246CDestructiveMachineModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.OKNG = _objRpt.GETA246COKNG();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();
            Model.Machines = _objRpt.GetA246CMachines();
            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;
            Session["Machines"] = Model.Machines;

            Session["OKNG"] = Model.OKNG;
            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ParameterA246CWeighingMachineCheckList(RptParameterA246CDestructiveMachineModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];
            model.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            model.OKNG = (List<DOL.A246COKNG>)Session["OKNG"];
            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.Rpt_getParameterA246CWeighingMachineCheckList(model.FromDate, model.LineId, model.ShiftId, model.ProjectId, model.MachineId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = (DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "A246CWeighingMachine.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterA246CPartToInspect()
        {
            ParameterA246CPartToInspectCheckListModelView Model = new ParameterA246CPartToInspectCheckListModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();

            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;



            return View(Model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ParameterA246CPartToInspect(ParameterA246CPartToInspectCheckListModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];

            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.Rpt_getParameterA246CPartToInspectCheckList(model.FromDate, model.LineId, model.ShiftId, model.ProjectId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = (DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "A246CTrapTest.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [HttpGet]
        public ActionResult ParameterProdQualityAuditCheckList()
        {
            ParameterProdQualityAuditModelView Model = new ParameterProdQualityAuditModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();
            //model.Machines = _CheckListCircuitRecord.GetA246CMachines();
            Model.Batches = new List<DOL.Batch>();
            Model.Zones = new List<DOL.Zone>();
            Model.ProdModules = new List<ProdModule>();
            Model.ProductionLineLeaders = new List<ProductionLineLeader>();

            Session["Lines"] = Model.Lines;
            Session["Projects"] = Model.Projects;
            Session["Shifts"] = Model.Shifts;
            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ParameterProdQualityAuditCheckList(ParameterProdQualityAuditModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];

            model.Batches = (List<DOL.Batch>)Session["Batches"];
            model.Zones = (List<DOL.Zone>)Session["Zones"];
            model.ProdModules = (List<DOL.ProdModule>)Session["ProdModules"];
            model.ProductionLineLeaders = (List<DOL.ProductionLineLeader>)Session["ProductionLineLeaders"];
            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.Rpt_getParameterProdQualityAudit(model.FromDate, model.LineId, model.ShiftId, model.ProjectId, model.BatchId, model.ProdId, model.ZoneId, model.ModuleId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = (DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "ProdQualityAudit.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }


        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult ParameterA246CTPaameterMCChecklist(RptParameterA246CTPaameterMCChecklistModelView Model, string command)
        {
            //RptOutwardModelView model = new RptOutwardModelView();
            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();
            Model.Machines = _objRpt.GetA246CMachines();
            

            try
            {
                switch (command)
                {
                    case "Search":
                        Model.dtReports = Model.dtReports = _objRpt.Rpt_getParameterA246CCTPaameterMCChecklist(Model.FromDate, Model.LineId, Model.ShiftId, Model.ProjectId, Model.MachineId);
                        Session["Report"] = Model.dtReports;
                        //model.Lines = (List<Line>)Session["Line"];
                        //model.Shifts = (List<Shift>)Session["Shift"];
                        //model.Projects = (List<Project>)Session["Project"];


                        break;
                    case "Export":
                        DataTable exportData = (DataTable)Session["Report"];

                        byte[] rendered;
                        string mini = string.Empty;
                        string ReportName = "A246CTPMC.rdlc";
                        
                        string ReportFormate = "pdf";
                        if (exportData != null)
                        {
                            _objRpt.generateReports(exportData, out rendered, out mini, ReportName, ReportFormate);
                            return File(rendered, mini);
                        }
                        break;
                }

            }
            catch (Exception)
            {

                throw;
            }
            //model.ExportType = _expClass.GetExportTypes();
            Model.ExportTypes = _expClass.GetExportTypes();
            return View(Model);
        }



        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult ParameterA246CTPaameterMCChecklistLine1(RptParameterA246CTParameterMCChecklistLine1ModelView Model, string command)
        {
            //RptOutwardModelView model = new RptOutwardModelView();
            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();
            Model.Machines = _objRpt.GetA246CMachines();


            try
            {
                switch (command)
                {
                    case "Search":
                        Model.dtReports = Model.dtReports = _objRpt.Rpt_getParameterA246CCTParameterMCChecklistLine1(Model.FromDate, Model.LineId, Model.ShiftId, Model.ProjectId, Model.MachineId);
                        Session["Report"] = Model.dtReports;
                        //model.Lines = (List<Line>)Session["Line"];
                        //model.Shifts = (List<Shift>)Session["Shift"];
                        //model.Projects = (List<Project>)Session["Project"];


                        break;
                    case "Export":
                        DataTable exportData = (DataTable)Session["Report"];

                        byte[] rendered;
                        string mini = string.Empty;
                        string ReportName = "A246CTPMCLINE2.rdlc";
                        string ReportFormate = "pdf";
                        if (exportData != null)
                        {
                            _objRpt.generateReports(exportData, out rendered, out mini, ReportName, ReportFormate);
                            return File(rendered, mini);
                        }
                        break;
                }

            }
            catch (Exception)
            {

                throw;
            }
            //model.ExportType = _expClass.GetExportTypes();
            Model.ExportTypes = _expClass.GetExportTypes();
            return View(Model);
        }


        [HttpGet]
        public ActionResult ParameterOutGoingInspectionA246C()
        {
            CheckListParameterOutGoingInspectionModelView Model = new CheckListParameterOutGoingInspectionModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();
            Session["Lines"] = Model.Lines;
            Session["Shifts"] = Model.Shifts;
            Session["Projects"] = Model.Projects;


            return View(Model);

        }

        [HttpPost]
        public ActionResult ParameterOutGoingInspectionA246C(CheckListParameterOutGoingInspectionModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];

            if (model.FromDate == "" && model.ToDate == "")
            {
                model.FromDate = "";
                model.ToDate = "";
            }
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.Rpt_getParameterCheckListOutGoingInspectionA246C(model.FromDate, model.ToDate, model.TrackNumber);
                    Session["Reports"] = model.dtReports;
                    break;


                case "Export":

                    DataTable exportData = _objRpt.Rpt_RDLCgetParameterCheckListOutGoingInspectionA246C(model.FromDate, model.ToDate, model.TrackNumber); //(DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "OutgoingInspectionRecordA246C.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }


        [HttpGet]
        public ActionResult ParameterProdQualityAuditCheckListWith5S()
        {
            ParameterProdQualityAuditModelView Model = new ParameterProdQualityAuditModelView();

            Model.dtReports = new DataTable();
            Model.Lines = _objRpt.GetLine();
            Model.Shifts = _objRpt.GetShift();
            Model.Projects = _objRpt.GetProject();
            //model.Machines = _CheckListCircuitRecord.GetA246CMachines();
            Model.Batches = new List<DOL.Batch>();
            Model.Zones = new List<DOL.Zone>();
            Model.ProdModules = new List<ProdModule>();
            Model.ProductionLineLeaders = new List<ProductionLineLeader>();

            Session["Lines"] = Model.Lines;
            Session["Projects"] = Model.Projects;
            Session["Shifts"] = Model.Shifts;
            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ParameterProdQualityAuditCheckListWith5S(ParameterProdQualityAuditModelView model, string command)
        {

            model.Lines = (List<Line>)Session["Lines"];
            model.Shifts = (List<Shift>)Session["Shifts"];
            model.Projects = (List<DOL.Project>)Session["Projects"];

            model.Batches = (List<DOL.Batch>)Session["Batches"];
            model.Zones = (List<DOL.Zone>)Session["Zones"];
            model.ProdModules = (List<DOL.ProdModule>)Session["ProdModules"];
            model.ProductionLineLeaders = (List<DOL.ProductionLineLeader>)Session["ProductionLineLeaders"];
            //if (model.FromDate == "" && model.ToDate == "")
            //{
            //    model.FromDate = "";
            //    model.ToDate = "";
            //}
            switch (command)
            {
                case "Search":

                    model.dtReports = _objRpt.Rpt_getParameterProdQualityAuditWith5S(model.FromDate, model.LineId, model.ShiftId, model.ProjectId, model.BatchId, model.ProdId, model.ZoneId, model.ModuleId);
                    Session["Reports"] = model.dtReports;


                    break;


                case "Export":

                    DataTable exportData = (DataTable)Session["Reports"];

                    byte[] rendered;
                    string mini = string.Empty;
                    string ReportName = "ProdQualityAudit2.rdlc";
                    string ReportFormate = "pdf";//model.ExportTypes[0];
                    if (exportData != null)
                    {
                        _objRpt.generateReports1(exportData, out rendered, out mini, ReportName, ReportFormate);
                        return File(rendered, mini);
                    }

                    break;
            }
            model.ExportTypes = _expClass.GetExportTypes();
            return View(model);

            //return View(model);
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult A246CCTPaameterMCChecklistFACA(RptParameterA246CTPaameterMCChecklistModelView model, int? pageNumber, int? pageSize)
        {
            // Set default values if null
            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 10;

            int skip = (currentPage - 1) * currentPageSize;

            // Fetch data
            model.dtReports = _objRpt.GetFACADataForA246CCTPaameterMCChecklist();
            List<DataRow> data = model.dtReports.Rows.Cast<DataRow>().ToList();

            // Pagination
            List<RptParameterA246CTPaameterMCChecklistModelView> pagedReports = data.Skip(skip).Take(currentPageSize).Select(r => new RptParameterA246CTPaameterMCChecklistModelView
            {
                StationNo = r.Table.Columns.Contains("StationNo") ? Convert.ToInt32(r["StationNo"]) : 0,
                Station = r.Table.Columns.Contains("Station") ? r["Station"].ToString() : "",
                EquipmentModel = r.Table.Columns.Contains("EquipmentModel") ? r["EquipmentModel"].ToString() : "",
                Parameter = r.Table.Columns.Contains("Parameter") ? r["Parameter"].ToString() : "",
                unit = r.Table.Columns.Contains("Unit") ? r["Unit"].ToString() : "",
                LSL = r.Table.Columns.Contains("LSL") ? Convert.ToDecimal(r["LSL"]) : 0,
                USL = r.Table.Columns.Contains("USL") ? Convert.ToDecimal(r["USL"]) : 0,
                Value = r.Table.Columns.Contains("Value") ? Convert.ToDecimal(r["Value"]) : 0
            }).ToList();

            // Final Model
            var model2 = new PagedReportsViewModel
            {
                Reports = pagedReports,
                TotalRecords = model.dtReports.Rows.Count,
                PageNumber = currentPage,
                PageSize = currentPageSize
            };

            if (Request.IsAjaxRequest())
            {
                return Json(new
                {
                    data = model2.Reports,
                    totalRecords = model2.TotalRecords,
                    pageNumber = model2.PageNumber,
                    pageSize = model2.PageSize
                }, JsonRequestBehavior.AllowGet);
            }

            try
            {
                model.dtReports = _objRpt.GetFACADataForA246CCTPaameterMCChecklist();
                Session["Report"] = model.dtReports;
            }
            catch (Exception)
            {
                throw;
            }

            return View(model);
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

        #endregion


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

    }
}
