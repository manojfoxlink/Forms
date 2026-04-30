
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
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
namespace ChecklistForm.Controllers
{
    [AuthenticateUser]
    [CheckSessionOut]
    public class MasterController : Controller
    {
        string connectionString = @"Data Source=10.52.1.126;Initial Catalog=Forms;Persist Security Info=True;User ID=Foxlink;Password=India@123;";
        BAL.Project _objProject = new BAL.Project();
        BAL.Station _ObjStation = new BAL.Station();
        BAL.SubStation _ObjSubStation = new BAL.SubStation();
        BAL.Parameters _ObjParameters = new BAL.Parameters();
        BAL.ChecklistLimits _objChecklistLimits = new BAL.ChecklistLimits();
        BAL.CheckListResults _ObjChecklistresults = new BAL.CheckListResults();
        BAL.CircuitRecord _ObjCircuitrecord = new BAL.CircuitRecord();
        BAL.lasersizeBAL _objLsize = new lasersizeBAL();
        BAL.NativeValidation _ObjNative = new BAL.NativeValidation();
        BAL.Inspect _objInspect = new BAL.Inspect();
        BAL.Frequency _objFrequency = new BAL.Frequency();
        BAL.period _objPeriod = new BAL.period();
        DAL.Project _objProject2 = new DAL.Project();
        Converters _cont = new Converters();
        //BAL.
        //BAL.LowerLimit _objLowerLimit = new BAL.LowerLimit();
        // GET: /Master/

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
        public ActionResult Station()
        {
            StationViewModel obj = new StationViewModel();
            obj.Projects = _objProject.GetProject();
            Session["Project"] = obj.Projects;
            return View(obj);
        }
        [HttpPost]
        public ActionResult Station(StationViewModel model)
        {
            try
            {
                model.Projects = (List<DOL.Project>)Session["Project"];
                if (!ModelState.IsValid)
                    return View(model);

                DOL.Station obj = new DOL.Station();
                obj.StationName = model.StationName;
                obj.ProjectId = model.ProjectId;
                obj.CreatedBy = Session["EmpNumber"].ToString();
                int i = _ObjStation.InsertStation(obj);

                if(i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully Station Created!!!";
                    return RedirectToAction("Station");
                }   
                else
                {
                    ModelState.AddModelError("ERROR", "Already Exists This Station !!!");
                }
               
               
            }
            
            catch(Exception ex)
            {
               
                ModelState.AddModelError("ERROR",ex.Message);
               
            }


            return View(model);
            
           
        }

        [HttpGet]

        public ActionResult SubStation()
        {
            SubStationViewModel obj = new SubStationViewModel();
            obj.Projects = _objProject.GetProject();
            obj.Stations = new List<DOL.Station>();

            Session["Project"] = obj.Projects;
          
           return View(obj);
        }

        [HttpPost]

       public ActionResult SubStation(SubStationViewModel model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
            model.Stations = (List<DOL.Station>)Session["Station"];

            if (!ModelState.IsValid)
                return View(model);

            DOL.SubStation obj = new DOL.SubStation();
            obj.SubStationName = model.SubStationName;
            obj.ProjectId = model.ProjectId;
            obj.StationId = model.StationId;
            obj.CreatedBy = Session["EmpNumber"].ToString();

            int i = _ObjSubStation.InsertSubStation(obj);

            

            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "Sucessfully SubStation Created!!!";
                return RedirectToAction("SubStation");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This SubStation !!!");
            }

            return View(model);
        }

     
        //public ActionResult GetStationByProject(int StationId)
        //{
        //    List<DOL.Station> Stations = new List<DOL.Station>();

        //    DataTable StateDt = _ObjSubStation.GetSubStation();

        //}
        [HttpGet]
        public ActionResult Parameters()
        {
            ParametersViewModel obj = new ParametersViewModel();
            obj.Projects = _objProject.GetProject();
            obj.Stations = new List<DOL.Station>();
            obj.SubStations = new List<DOL.SubStation>();

            Session["Project"] = obj.Projects;
           

            return View(obj);
        }
         [HttpPost]
        public ActionResult Parameters(ParametersViewModel model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
            model.Stations = (List<DOL.Station>)Session["Station"];
            model.SubStations = (List<DOL.SubStation>)Session["SubStation"];

            if (!ModelState.IsValid)
                return View(model);

            DOL.Parameters obj = new DOL.Parameters();
            obj.ParameterName = model.ParameterName;
            obj.ProjectId = model.ProjectId;
            obj.StationId = model.StationId;
            obj.SubStationId = model.SubStationId;
            obj.CreatedBy = Session["EmpNumber"].ToString();

            int i = _ObjParameters.InsertParameter(obj);
            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "Sucessfully Parameters Created!!!";
                return RedirectToAction("Parameters");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This Parameters !!!");
            }
            return View(model);
        }
        [HttpGet]
         public ActionResult ChecklistLimits()
        {
            

            ChecklistLimitsViewModel obj = new ChecklistLimitsViewModel();

            obj.Projects = _objProject.GetProject();
            obj.Stations = new List<DOL.Station>();
            obj.SubStations = new List<DOL.SubStation>();
            obj.Parameters = new List<DOL.Parameters>();

            Session["Project"] = obj.Projects;
          

            return View(obj);
        }
        [HttpPost]
        public ActionResult ChecklistLimits(ChecklistLimitsViewModel model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
            model.Stations = (List<DOL.Station>)Session["Station"];
            model.SubStations = (List<DOL.SubStation>)Session["SubStation"];
            model.Parameters = (List<DOL.Parameters>)Session["Parameters"];

            if (!ModelState.IsValid)
                return View(model);

            DOL.ChecklistLimits obj = new DOL.ChecklistLimits();
            obj.LowerLimit = Convert.ToDecimal (model.LowerLimit);
            obj.UpperLimit = Convert.ToDecimal (model.UpperLimit);
            obj.ProjectId = model.ProjectId;
            obj.StationId = model.StationId;
            obj.SubStationId = model.SubStationId;
            obj.ParameterId = model.ParameterId;
            obj.CreatedBy = Session["EmpNumber"].ToString();

            int i = _objChecklistLimits.InsertChecklistLimits(obj);
            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "Sucessfully Limits Created!!!";
                return RedirectToAction("ChecklistLimits");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This Limits !!!");
            }
            return View(model);
           
        }
       [HttpGet]
        public  ActionResult CheckListResults()
        {
            //CheckListResultsViewModel obj = new CheckListResultsViewModel();
            //obj.Projects = _objProject.GetProject();
            //obj.Stations = _ObjStation.GetStation();
            //obj.SubStations = _ObjSubStation.GetSubStation();
            //obj.Parameters = _ObjParameters.GetParameters();
            //obj.Limits = _objChecklistLimits.GetCheckListLimits();
            //obj.Limits2 = _objChecklistLimits.GetCheckListLimits2();
            return View();
        }
        [HttpPost]
        public ActionResult CheckListResults(CheckListResultsViewModel model)
        {

            if (!ModelState.IsValid)
                return View(model);

            //DOL.CheckListResults obj = new DOL.CheckListResults();
            //obj.Actual = model.Actual;
            //obj.Result = model.Result;
            //obj.ProjectId = model.ProjectId;
            //obj.StationId = model.StationId;
            //obj.SubStationId = model.SubStationId;
            //obj.ParameterId = model.ParameterId;
            //obj.LimitId = model.LimitId;
            //obj.CreatedBy = "";

            //int i = _ObjChecklistresults.InsertCheckListResults(obj);
            return RedirectToAction("ChecklistResults");
        }
        
        //public ActionResult Floating_Label()
        //{
        //    return View();
        //}
        [HttpGet]
        public ActionResult CircuitRecord()
        {
            CircuitRecordViewModel obj = new CircuitRecordViewModel();
            obj.Projects = _objProject.GetProject();

            Session["Project"] = obj.Projects;

            return View(obj);
        }

        [HttpPost]
        public ActionResult CircuitRecord(CircuitRecordViewModel model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];

            if (!ModelState.IsValid)
                return View(model);

            DOL.CircuitRecord obj = new DOL.CircuitRecord();

            obj.Inspectionitem = model.Inspectionitem;
            obj.ModelNumber = model.ModelNumber;
            obj.InspecSpecification = model.InspecSpecification;
            obj.ProjectId = model.ProjectId;
            obj.CreatedBy = Session["EmpNumber"].ToString();
            
            int i = _ObjCircuitrecord.InsertCircuitRecord(obj);
            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "Sucessfully CircuitRecord Details Created!!!";
                return RedirectToAction("CircuitRecord");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This CircuitRecord Details !!!");
            }

            return View(model);
        }

        [HttpGet]

        public ActionResult Lasersize()
        {
            LaserViewModel obj = new LaserViewModel();
            obj.Projects = _objProject.GetProject();
            Session["Project"] = obj.Projects;
            return View(obj);
        }


        [HttpPost]
        public ActionResult Lasersize(LaserViewModel model)
        {


            if (!ModelState.IsValid)
                return View(model);
            model.Projects = (List<DOL.Project>)Session["Project"];
            DOL.LaserSize obj = new DOL.LaserSize();
            obj.Locations = model.Locations;
            obj.Specification = model.Specification;
            obj.Minimum = Convert.ToDecimal(model.Minimum);
            obj.Maximum = Convert.ToDecimal(model.Maximum);
            obj.CreatedBy = Session["EmpNumber"].ToString();
            obj.ProjectId = model.ProjectId;
            int i = _objLsize.Laserengraving(obj);
            if (i > 0)
            {
                TempData["mgs"] = "sucess";
                TempData["Alert"] = "Sucessfully Lasersize Created !!!";
                return RedirectToAction("Lasersize");

            }
            else
            {
                ModelState.AddModelError("Error", "Already Exists This Laser !!!");

            }
            return View(model);
        }

        [HttpGet]
        public ActionResult NativeValidation()
        {
            NativeValidationViewModel obj = new NativeValidationViewModel();


            //obj.Stations = new List<DOL.Station>();

            obj.Stations = _ObjStation.GetStation();

            obj.Inpections = new List<DOL.Inspect>();
            obj.Frequencies = new List<DOL.Frequencyy>();
            obj.Periodss = new List<DOL.Period>();

            return View(obj);
        }
        [HttpPost]
        public ActionResult NativeValidation(NativeValidationViewModel model)
        {
            
            //model.Stations = (List<DOL.Station>)Session["Station"];
            model.Stations = _ObjStation.GetStation();
            model.Inpections = (List<DOL.Inspect>)Session["Inspects"];
            model.Frequencies = (List<DOL.Frequencyy>)Session["Frequencies"];
            model.Periodss = (List<DOL.Period>)Session["Periods"];

            if (!ModelState.IsValid)
                return View(model);

            DOL.NativeValidation obj = new  DOL.NativeValidation();

            obj.StationId = model.StationId;
            obj.InspectId = model.InspectId;
            obj.FreqId = model.FreqId;
            obj.PeriodId = model.PeriodId;

            obj.CreatedBy = Session["EmpNumber"].ToString();

            int i = _ObjNative.InsertNativeValidation(obj);

            if (i > 0)
            {
                TempData["mgs"] = "sucess";
                TempData["Alert"] = "Sucessfully Native Created !!!";
                return RedirectToAction("NativeValidation");

            }
            else
            {
                ModelState.AddModelError("Error", "Already Exists This Laser !!!");

            }

            return View(model);
        }
        [HttpGet]
        public ActionResult Operation()
        {
            OperationsViewModel obj = new OperationsViewModel();

            obj.Operations = _objProject.GetOperations();
            Session["Operations"] = obj.Operations;

            obj.Projects = _objProject.GetProject();
            Session["Project"] = obj.Projects;

            return View(obj);
        }
        [HttpPost]
        public ActionResult Operation(OperationsViewModel model)
        {

            model.Projects = (List<DOL.Project>)Session["Project"];
            if (!ModelState.IsValid)
                return View(model);


            DOL.Operations obj = new DOL.Operations();

            //obj.Projects = _objProject.GetProject();
            //Session["Project"] = obj.Projects;

            obj.projectId = model.ProjectId;
            obj.Process = model.Process;
            obj.Operation = model.Operation;
            obj.CreatedBy = Session["EmpNumber"].ToString();
            int i = _objProject.InsertOperations(obj);

            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "Operation Created!!!";
                return RedirectToAction("Operation");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This Operation !!!");
            }
            return View(model);



        }

        [HttpGet]
        public ActionResult AuditCheckPoints()
        {
            AuditCheckPointViewModel obj = new AuditCheckPointViewModel();
            //obj.Operationss = _objProject.GetOperations();
            //Session["Operations"] = obj.Operationss;
            obj.Projects = _objProject.GetProject();
            Session["Project"] = obj.Projects;

            obj.Operationss= new List<DOL.Operations>();

            

            return View(obj);
        }

        [HttpPost]
        public ActionResult AuditCheckPoints(AuditCheckPointViewModel model)
        {

            model.Projects = (List<DOL.Project>)Session["Project"];
            model.Operationss = (List<DOL.Operations>)Session["Operations"];
            model.AuditList= new DataTable();
            if (!ModelState.IsValid)
                return View(model);


            DOL.AuditCheckPoint obj = new DOL.AuditCheckPoint();
            obj.projectId = model.ProjectId;
            obj.OperationId = model.OperationId;
            obj.CheckPoints = model.CheckPoints;
            obj.Dept = model.Dept;

            // MemoryStream target = new MemoryStream();
            //    file.InputStream.CopyTo(target);
            //    byte[] data = target.ToArray();
            //    String profilePic = Convert.ToBase64String(data);
            //    profilePic = "data:image/jpeg;base64," + profilePic;

            //obj.Image = profilePic;


            obj.CreatedBy = Session["EmpNumber"].ToString();
            int i = _objProject.InsertCheckPoint(obj);
            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "Audit CheckPoint Created!!!";
                return RedirectToAction("AuditCheckPoints");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This AuditCheckPoint !!!");
            }
            return View(model);



        }

        [HttpGet]
        public ActionResult PartToInspect()
        {
            PartToInspectViewModel obj = new PartToInspectViewModel();

            obj.Projects = _objProject.GetProject();
            Session["Project"] = obj.Projects;

            return View(obj);
        }

        [HttpPost]
        public ActionResult PartToInspect(PartToInspectViewModel model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
            if (!ModelState.IsValid)
                return View(model);


            DOL.PartToInspect obj = new DOL.PartToInspect();

            obj.ProjectId = model.ProjectId;
            obj.Sno = model.Sno;
            obj.parts = model.parts;
            obj.CreatedBy = Session["EmpNumber"].ToString();
            int i = _objProject.InsertPartToInspect(obj);

            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "Part Created!!!";
                return RedirectToAction("PartToInspect");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This Part !!!");
            }
            return View(model);

        }

        [HttpGet]
        public ActionResult InspectorDetails()
        {
            InspectorDetailsViewModel obj = new InspectorDetailsViewModel();

            obj.Projects = _objProject.GetProject();
            Session["Project"] = obj.Projects;

            obj.Inspects = new List<DOL.PartToInspect>();
            Session["Inspects"] = obj.Inspects;

            obj.Inspector = _objProject.GetInspectors();
            Session["Inspector"] = obj.Inspector;

            return View(obj);
        }

        [HttpPost]
        public ActionResult InspectorDetails(InspectorDetailsViewModel model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
            model.Inspector = (List<DOL.Inspectors>)Session["Inspector"];
            model.Inspects = (List<DOL.PartToInspect>)Session["Inspects"];
            if (!ModelState.IsValid)
                return View(model);


            DOL.InspectorDetailss obj = new DOL.InspectorDetailss();
            obj.InspectId = model.InspectId;
            obj.ProjectId = model.ProjectId;
            obj.InspecId = model.InspecId;
            obj.CreatedBy = Session["EmpNumber"].ToString();
            int i = _objProject.InsertInspectorDetails(obj);

            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "InspectorDetails Created!!!";
                return RedirectToAction("InspectorDetails");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This InspectorDetails !!!");
            }
            return View(model);

        }
        [HttpGet]
        public ActionResult CircuitInspectionItem()
        {
            CircuitInspectionItemViewModel obj = new CircuitInspectionItemViewModel();

            obj.Projects = _objProject.GetProject();
            Session["Project"] = obj.Projects;

            obj.Stations = new List<DOL.Station>();

            return View(obj);

        }
        [HttpPost]
        public ActionResult CircuitInspectionItem(CircuitInspectionItemViewModel model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
            model.Stations = (List<DOL.Station>)Session["Station"];

            if (!ModelState.IsValid)
                return View(model);

            DOL.CircuitInspectionItem obj = new DOL.CircuitInspectionItem();

            obj.ProjectId = model.ProjectId;
            obj.StationId = model.StationId;
            obj.InspectionItem = model.InspectionItem;
            obj.CreatedBy = Session["EmpNumber"].ToString();
            int i = _objProject.InsertCircuitInspectionItem(obj);

            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "InspectionItem Created!!!";
                return RedirectToAction("CircuitInspectionItem");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This InspectionItem !!!");
            }
            return View(model);

        }

        [HttpGet]
        public ActionResult CircuitInspectionSpec()
        {
            CircuitInspectionSpecViewModel obj = new CircuitInspectionSpecViewModel();

            obj.Projects = _objProject.GetProject();
            Session["Project"] = obj.Projects;

            obj.Freqs = _objProject.GetFreq();
            Session["Freq"] = obj.Freqs;

            obj.Periods = _objProject.GetPeriodss();
            Session["Periods"] = obj.Periods;

            obj.Stations = new List<DOL.Station>();
            Session["Station"] = obj.Stations;

            obj.InspectionItems = new List<DOL.CircuitInspectionItem>();
            Session["InspectionItem"] = obj.InspectionItems;

            

            return View(obj);
        }

        [HttpPost]
        public ActionResult CircuitInspectionSpec(CircuitInspectionSpecViewModel model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
            model.Stations = (List<DOL.Station>)Session["Station"];
            model.InspectionItems = (List<DOL.CircuitInspectionItem>)Session["InspectionItem"];
            model.Freqs = (List<DOL.Frequen>)Session["Freq"];

            model.Periods = (List<DOL.Periodss>)Session["Periods"];

            if (!ModelState.IsValid)
                return View(model);

            CircuitInspectionSpec obj = new CircuitInspectionSpec();
            obj.LowerLimit = model.LowerLimit;
            obj.UpperLimit = model.UpperLimit;
            obj.InspectionSpecification = model.InspectionSpecification;
            obj.ProjectId = model.ProjectId;
            obj.StationId = model.StationId;
            obj.ItemId = model.ItemId;
            obj.FreqId = model.FreqId;
            obj.PeriodId = model.PeriodId;
            obj.CreatedBy = Session["EmpNumber"].ToString();
            int i = _objProject.InsertCircuitInspectionSpec(obj);

            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "InspectionSpecification Created!!!";
                return RedirectToAction("CircuitInspectionSpec");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This InspectionSpecification !!!");
            }
            return View(model);

        }

        [HttpGet]
        public ActionResult CTQPartsToInspect()
        {
            CTQPartsToInspectModelView obj = new CTQPartsToInspectModelView();

            obj.Projects = _objProject.GetProject();
            Session["Project"] = obj.Projects;

            obj.Sections = new List<DOL.Sections>();

            //obj.Sections = _objProject.GetSection();
            Session["Section"] = obj.Sections;

            return View(obj);
        }

        [HttpPost]
        public ActionResult CTQPartsToInspect(CTQPartsToInspectModelView model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
            model.Sections = (List<DOL.Sections>)Session["Section"];
            if (!ModelState.IsValid)
                return View(model);

            CTQPartsToInspect obj = new CTQPartsToInspect();
            obj.ProjectId = model.ProjectId;
            obj.SNo = model.SNo;
            obj.SectionId = model.SectionId;
            obj.PartToInspect = model.PartToInspect;
            obj.CreatedBy = Session["EmpNumber"].ToString();
            int i = _objProject.InsertCTQPartsToInspect(obj);

            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "PartsToInspection Created!!!";
                return RedirectToAction("CTQPartsToInspect");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This PartsToInspection !!!");
            }
            return View(model);

        }

        [HttpGet]
        public ActionResult DestructiveWire()
        {
            DestructiveWireModelView obj = new DestructiveWireModelView();

            obj.Projects = _objProject.GetProject();
            Session["Project"] = obj.Projects;

            obj.Inspections = new List<DOL.DestructiveInspectionItem>();

            //obj.Sections = _objProject.GetSection();
            Session["Inspections"] = obj.Inspections;

            return View(obj);
        }

        [HttpPost]
        public ActionResult DestructiveWire(DestructiveWireModelView model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
            model.Inspections = (List<DOL.DestructiveInspectionItem>)Session["Inspections"];
            if (!ModelState.IsValid)
                return View(model);

            DestructiveWire obj = new DestructiveWire();
            obj.ProjectId = model.ProjectId;
            obj.InspectionId = model.InspectionId;
            obj.Wire = model.Wire;
            obj.CreatedBy = Session["EmpNumber"].ToString();
            int i = _objProject.InsertDestructiveWire(obj);

            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "Destructive Wire Created!!!";
                return RedirectToAction("DestructiveWire");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This Destructive Wire !!!");
            }
            return View(model);

        }

        [HttpGet]
        public ActionResult AdhesiveCreation()
        {
            AdhesiveModelView obj = new AdhesiveModelView();

            obj.Projects = _objProject.GetProject();
            Session["Project"] = obj.Projects;

            return View(obj);
        }

        [HttpPost]
        public ActionResult AdhesiveCreation(AdhesiveModelView model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
            if (!ModelState.IsValid)
                return View(model);

            Adhesivee obj = new Adhesivee();
            obj.ProjectId = model.ProjectId;
            obj.Adhesive = model.Adhesive;
            obj.LowerLimit = model.LowerLimit;
            obj.CenterLimit = model.CenterLimit;
            obj.UpperLimit = model.UpperLimit;
            obj.CreatedBy = Session["EmpNumber"].ToString();
            int i = _objProject.InsertAdhesive(obj);

            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "Adhesive Created!!!";
                return RedirectToAction("AdhesiveCreation");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This Adhesive !!!");
            }
            return View(model);

        }

        [HttpGet]
        public ActionResult TemparatureRange()
        {
            TemparatureRangeModelView obj = new TemparatureRangeModelView();

            obj.Projects = _objProject.GetProject();
            Session["Project"] = obj.Projects;

            return View(obj);
        }

        [HttpPost]
        public ActionResult TemparatureRange(TemparatureRangeModelView model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
            if (!ModelState.IsValid)
                return View(model);

            TempRange obj = new TempRange();
            obj.ProjectId = model.ProjectId;
            obj.RangeName = model.RangeName;
            obj.Range = model.Range;
            obj.LowerLimit = model.LowerLimit;
            obj.CenterLimit = model.CenterLimit;
            obj.UpperLimit = model.UpperLimit;
            obj.CreatedBy = Session["EmpNumber"].ToString();
            int i = _objProject.InsertTemparatureRange(obj);

            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "TemparatureRange Created!!!";
                return RedirectToAction("TemparatureRange");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This TemparatureRange !!!");
            }
            return View(model);

        }

        [HttpGet]
        public ActionResult DestructiveInspectionItem()
        {
            DestructiveInspectionItemModelView obj = new DestructiveInspectionItemModelView();

            obj.Projects = _objProject.GetProject();
            Session["Project"] = obj.Projects;

            return View(obj);
        }

        [HttpPost]
        public ActionResult DestructiveInspectionItem(DestructiveInspectionItemModelView model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
            if (!ModelState.IsValid)
                return View(model);

            DestructiveInspectionItem obj = new DestructiveInspectionItem();
            obj.ProjectId = model.ProjectId;
            obj.Inspection = model.Inspection;
            
            obj.CreatedBy = Session["EmpNumber"].ToString();
            int i = _objProject.InsertDestructiveInspection(obj);

            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "Destructive InspectionItem Created!!!";
                return RedirectToAction("DestructiveInspectionItem");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This DestructiveInspectionItem !!!");
            }
            return View(model);

        }

        [HttpGet]
        public ActionResult DestructiveFrequency()
        {
            DestructiveFrequencyModelView obj = new DestructiveFrequencyModelView();

            obj.Projects = _objProject.GetProject();
            Session["Project"] = obj.Projects;

            return View(obj);
        }

        [HttpPost]
        public ActionResult DestructiveFrequency(DestructiveFrequencyModelView model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
            if (!ModelState.IsValid)
                return View(model);

            DestructiveFrequency obj = new DestructiveFrequency();
            obj.ProjectId = model.ProjectId;
            obj.Frequency = model.Frequency;

            obj.CreatedBy = Session["EmpNumber"].ToString();
            int i = _objProject.InsertDestructiveFrequency(obj);

            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "Destructive InspectionItem Created!!!";
                return RedirectToAction("DestructiveFrequency");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This Destructive Frequency !!!");
            }
            return View(model);

        }


        [HttpGet]
        public ActionResult GetDestructiveSpec()
        {
            DestructiveSpecViewModel obj = new DestructiveSpecViewModel();

            obj.Projects = _objProject.GetProject();
            Session["Project"] = obj.Projects;

            obj.Freqs = _objProject.GetDestructiveFrequency();
            Session["Freq"] = obj.Freqs;

            obj.Inspections = new List<DOL.DestructiveInspectionItem>();
            Session["Inspections"] = obj.Inspections;

            obj.Wires = new List<DOL.DestructiveWire>();
            Session["Wires"] = obj.Wires;

            

            return View(obj);
        }

        [HttpPost]
        public ActionResult GetDestructiveSpec(DestructiveSpecViewModel model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
            model.Inspections = (List<DOL.DestructiveInspectionItem>)Session["Inspections"];
            model.Freqs = (List<DOL.DestructiveFrequency>)Session["Freq"];
            model.Wires = (List<DOL.DestructiveWire>)Session["Wires"];
            if (!ModelState.IsValid)
                return View(model);

            DestructiveSpec obj = new DestructiveSpec();
            obj.ProjectId = model.ProjectId;
            obj.InspectionId = model.InspectionId;
            obj.FrequencyId = model.FrequencyId;
            obj.WireId = model.WireId;
            obj.Spec = model.Spec;
            obj.LSL = model.LSL;
            obj.CreatedBy = Session["EmpNumber"].ToString();
            int i = _objProject.InsertDestructiveSpec(obj);

            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "Destructive Specification Created!!!";
                return RedirectToAction("GetDestructiveSpec");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This Destructive Specification !!!");
            }
            return View(model);

        }

        [HttpGet]
        public ActionResult EsdLuxStation()
        {
            EsdLuxStationViewModel obj = new EsdLuxStationViewModel();
            obj.Projects = _objProject.GetProject();
            Session["Project"] = obj.Projects;
            return View(obj);
        }

        [HttpPost]
        public ActionResult EsdLuxStation(EsdLuxStationViewModel model)
        {
            try
            {
                model.Projects = (List<DOL.Project>)Session["Project"];
                if (!ModelState.IsValid)
                    return View(model);

                DOL.EsdLuxStation obj = new DOL.EsdLuxStation();
                obj.StationNo = model.StationNo;
                obj.StationName = model.StationName;
                obj.ProjectId = model.ProjectId;
                obj.CreatedBy = Session["EmpNumber"].ToString();
                int i = _ObjStation.InsertEsdLuxStation(obj);

                if (i > 0)
                {
                    TempData["mgs"] = "Sucess";
                    TempData["Alert"] = "Sucessfully tation Created!!!";
                    return RedirectToAction("EsdLuxStation");
                }
                else
                {
                    ModelState.AddModelError("ERROR", "Already Exists This Station !!!");
                }


            }

            catch (Exception ex)
            {

                ModelState.AddModelError("ERROR", ex.Message);

            }


            return View(model);


        }


        [HttpGet]
        public ActionResult BootC91Creation()
        {
            BootC91ModelView obj = new BootC91ModelView();

            obj.Projects = _objProject.GetProject();
            obj.Locations = new List<DOL.Location>();
            Session["Project"] = obj.Projects;

            return View(obj);
        }

        [HttpPost]
        public ActionResult BootC91Creation(BootC91ModelView model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
            model.Locations = (List<DOL.Location>)Session["Location"];
            if (!ModelState.IsValid)
                return View(model);

            BootC91 obj = new BootC91();
            obj.LocationId = model.LocationId;
            obj.ProjectId = model.ProjectId;
            obj.Boott = model.Boott;

            obj.CreatedBy = Session["EmpNumber"].ToString();
            int i = _objProject.InsertBootC91(obj);

            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "BootC91 Created!!!";
                return RedirectToAction("BootC91Creation");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This BootC91 !!!");
            }
            return View(model);

        }

        [HttpGet]
        public ActionResult BootC70Creation()
        {
            BootC70ModelView obj = new BootC70ModelView();

            obj.Projects = _objProject.GetProject();
            obj.Locations = new List<DOL.Location>();
            Session["Project"] = obj.Projects;

            return View(obj);
        }



        [HttpPost]
        public ActionResult BootC70Creation(BootC70ModelView model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
            model.Locations = (List<DOL.Location>)Session["Location"];
            if (!ModelState.IsValid)
                return View(model);

            BootC70 obj = new BootC70();
            obj.LocationId = model.LocationId;
            obj.ProjectId = model.ProjectId;
            obj.Boot = model.Boot;

            obj.CreatedBy = Session["EmpNumber"].ToString();
            int i = _objProject.InsertBootC70(obj);

            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "BootC70 Part Created!!!";
                return RedirectToAction("BootC70Creation");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This BootC70 !!!");
            }
            return View(model);

        }

        [HttpGet]
        public ActionResult PlugShellC70()
        {
            PlugShellC70ModelView obj = new PlugShellC70ModelView();

            obj.Projects = _objProject.GetProject();
            obj.Locations = new List<DOL.Location>();
            Session["Project"] = obj.Projects;

            return View(obj);
        }

        [HttpPost]
        public ActionResult PlugShellC70(PlugShellC70ModelView model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
            model.Locations = (List<DOL.Location>)Session["Location"];
            if (!ModelState.IsValid)
                return View(model);

            PlugShellC70 obj = new PlugShellC70();
            obj.LocationId = model.LocationId;
            obj.ProjectId = model.ProjectId;
            obj.PlugShell = model.PlugShell;

            obj.CreatedBy = Session["EmpNumber"].ToString();
            int i = _objProject.InsertPlugShellC70(obj);

            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "PlugShellC70 Part Created!!!";
                return RedirectToAction("PlugShellC70");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This PlugShellC70 !!!");
            }
            return View(model);

        }

        [HttpGet]
        public ActionResult PlugShellC91()
        {
            PlugShellC91ModelView obj = new PlugShellC91ModelView();

            obj.Projects = _objProject.GetProject();
            obj.Locations = new List<DOL.Location>();
            Session["Project"] = obj.Projects;

            return View(obj);
        }

        [HttpPost]
        public ActionResult PlugShellC91(PlugShellC91ModelView model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
            model.Locations = (List<DOL.Location>)Session["Location"];
            if (!ModelState.IsValid)
                return View(model);

            PlugShellC91 obj = new PlugShellC91();
            obj.LocationId = model.LocationId;
            obj.ProjectId = model.ProjectId;
            obj.PlugShelll = model.PlugShelll;

            obj.CreatedBy = Session["EmpNumber"].ToString();
            int i = _objProject.InsertPlugShellC91(obj);

            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "PlugShellC91 Part Created!!!";
                return RedirectToAction("PlugShellC91");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This PlugShellC91 !!!");
            }
            return View(model);

        }

        [HttpGet]
        public ActionResult PaperCollar()
        {
            PaperCollarModelView obj = new PaperCollarModelView();

            obj.Projects = _objProject.GetProject();
            obj.Locations = new List<DOL.Location>();
            Session["Project"] = obj.Projects;

            return View(obj);
        }

        [HttpPost]
        public ActionResult PaperCollar(PaperCollarModelView model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
            model.Locations = (List<DOL.Location>)Session["Location"];
            if (!ModelState.IsValid)
                return View(model);

            PaperCollar obj = new PaperCollar();
            obj.ProjectId = model.ProjectId;
            obj.LocationId = model.LocationId;
            obj.Collar = model.Collar;

            obj.CreatedBy = Session["EmpNumber"].ToString();
            int i = _objProject.InsertPaperCollar(obj);

            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "PaperCollar Created!!!";
                return RedirectToAction("PaperCollar");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This PaperCollar !!!");
            }
            return View(model);

        }

        [HttpGet]
        public ActionResult FacePlateC70()
        {
            FacePlateC70ModelView obj = new FacePlateC70ModelView();

            obj.Projects = _objProject.GetProject();
            obj.Locations = new List<DOL.Location>();
            Session["Project"] = obj.Projects;

            return View(obj);
        }

        [HttpPost]
        public ActionResult FacePlateC70(FacePlateC70ModelView model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
            model.Locations = (List<DOL.Location>)Session["Location"];
            if (!ModelState.IsValid)
                return View(model);

            FacePlateC70 obj = new FacePlateC70();
            obj.LocationId = model.LocationId;
            obj.ProjectId = model.ProjectId;
            obj.FacePlate = model.FacePlate;

            obj.CreatedBy = Session["EmpNumber"].ToString();
            int i = _objProject.InsertFacePlateC70(obj);

            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "FacePlateC70 Part Created!!!";
                return RedirectToAction("FacePlateC70");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This FacePlate !!!");
            }
            return View(model);

        }


        [HttpGet]
        public ActionResult FacePlateC91()
        {
            FacePlateC91ModelView obj = new FacePlateC91ModelView();

            obj.Projects = _objProject.GetProject();
            obj.Locations = new List<DOL.Location>();
            Session["Project"] = obj.Projects;

            return View(obj);
        }

        [HttpPost]
        public ActionResult FacePlateC91(FacePlateC91ModelView model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
            model.Locations = (List<DOL.Location>)Session["Location"];
            if (!ModelState.IsValid)
                return View(model);

            FacePlateC91 obj = new FacePlateC91();
            obj.LocationId = model.LocationId;
            obj.ProjectId = model.ProjectId;
            obj.FacePlate = model.FacePlate;

            obj.CreatedBy = Session["EmpNumber"].ToString();
            int i = _objProject.InsertFacePlateC91(obj);

            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "FacePlateC91 Part Created!!!";
                return RedirectToAction("FacePlateC91");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This FacePlate !!!");
            }
            return View(model);

        }

        [HttpGet]
        public ActionResult Location()
        {
            LocationModelView obj = new LocationModelView();

            obj.Projects = _objProject.GetProject();
            Session["Project"] = obj.Projects;

            return View(obj);
        }

        [HttpPost]
        public ActionResult Location(LocationModelView model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
            //model.Locations = (List<DOL.Location>)Session["Location"];
            if (!ModelState.IsValid)
                return View(model);

            Location obj = new Location();
            obj.LocationId = model.LocationId;
            obj.ProjectId = model.ProjectId;
            obj.Locations = model.Locations;

            obj.CreatedBy = Session["EmpNumber"].ToString();
            int i = _objProject.InsertLocation(obj);

            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "Location Created!!!";
                return RedirectToAction("Location");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This Location !!!");
            }
            return View(model);

        }


        [HttpGet]
        public ActionResult Defects()
        {
            DefectsModelView obj = new DefectsModelView();

            obj.Projects = _objProject.GetProject();
            obj.Locations = new List<DOL.Location>();
            Session["Project"] = obj.Projects;

            return View(obj);
        }

        [HttpPost]
        public ActionResult Defects(DefectsModelView model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
            model.Locations = (List<DOL.Location>)Session["Location"];
            if (!ModelState.IsValid)
                return View(model);

            Defects obj = new Defects();
            obj.LocationId = model.LocationId;
            obj.ProjectId = model.ProjectId;
            obj.Defect = model.Defect;

            obj.CreatedBy = Session["EmpNumber"].ToString();
            int i = _objProject.InsertDefects(obj);

            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "Defect Part Created!!!";
                return RedirectToAction("Defects");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This Defect !!!");
            }
            return View(model);

        }

        [HttpGet]
        public ActionResult Teardown()
        {
            TearDownModelView obj = new TearDownModelView();

            obj.Projects = _objProject.GetProject();
            Session["Project"] = obj.Projects;

            return View(obj);
        }

        [HttpPost]
        public ActionResult Teardown(TearDownModelView model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
           
            if (!ModelState.IsValid)
                return View(model);

            TearDown obj = new TearDown();
            obj.Sno = model.Sno;
            obj.ProjectId = model.ProjectId;
            obj.TeardownSteps = model.TeardownSteps;
            
            obj.CreatedBy = Session["EmpNumber"].ToString();
            int i = _objProject.InsertTeardown(obj);

            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "Teardown Part Created!!!";
                return RedirectToAction("Teardown");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This Teardown !!!");
            }
            return View(model);

        }
        [HttpGet]
        public ActionResult GetTeardownInspections()
        {
            TeardownInspectionsModelView obj = new TeardownInspectionsModelView();

            obj.Projects = _objProject.GetProject();
            obj.Tears = new List<DOL.TearDown>();
            Session["Project"] = obj.Projects;

            return View(obj);
        }

        [HttpPost]
        public ActionResult GetTeardownInspections(TeardownInspectionsModelView model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
            model.Tears = (List<DOL.TearDown>)Session["Tears"];
            if (!ModelState.IsValid)
                return View(model);

            TeardownInspection obj = new TeardownInspection();
            obj.Inspection = model.Inspection;
            obj.ProjectId = model.ProjectId;
            obj.TearId = model.TearId;

            obj.CreatedBy = Session["EmpNumber"].ToString();
            int i = _objProject.InsertTeardownInspections(obj);

            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "TeardownInspection Created!!!";
                return RedirectToAction("GetTeardownInspections");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This TeardownInspection !!!");
            }
            return View(model);

        }
        #region -->Post Method For  Station

        [HttpPost]
        public ActionResult GetStationByProject(int ProjectId)
        {
            string PlantCode = string.Empty;
            List<DOL.Station> Stationlist = new List<DOL.Station>();

            DataTable dt= _ObjStation.GetStationByProject(ProjectId);


          Stationlist =  dt.DataTableToList<DOL.Station>();
            
            string retStr = string.Empty;


            Session["Station"] = Stationlist;
            retStr = _cont.ConvertToJson(dt);


            return Json(retStr, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region -->Post Method For SubStation

        [HttpPost]
        public ActionResult GetSubStationByStation(int StationId)
        {
            string PlantCode = string.Empty;
            List<DOL.SubStation> SubStationList = new List<DOL.SubStation>();

            DataTable dt = _ObjSubStation.GetSubStationByStation(StationId);

            SubStationList = dt.DataTableToList<DOL.SubStation>();

            string retStr = string.Empty;

            Session["SubStation"] = SubStationList;
            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);

        }

        #endregion

        #region --> Post Method For Parameters

        [HttpPost]
        public ActionResult GetParametersBySubStation(int SubStationId)
        {
            string PlantCode = string.Empty;

            List<DOL.Parameters> ParametersList = new List<DOL.Parameters>();

            DataTable dt = _ObjParameters.GetParametersBySubStation(SubStationId);

            ParametersList = dt.DataTableToList<DOL.Parameters>();

            string retStr = string.Empty;

            Session["Parameters"] = ParametersList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region --> Post Method For Inspects
        [HttpPost]
        public ActionResult GetInspectionByStation(int StationId)
        {
            string PlantCode = string.Empty;

            List<DOL.Inspect> InspectsList = new List<DOL.Inspect>();

            DataTable dt = _objInspect.GetInspectionByStation(StationId);

            InspectsList = dt.DataTableToList<DOL.Inspect>();

            string retStr = string.Empty;

            Session["Inspects"] = InspectsList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region --> Post Method For Frequencies
        [HttpPost]
        public ActionResult GetFrequencyByInspection(int InspectId)
        {
            string PlantCode = string.Empty;

            List<DOL.Frequencyy> FrequencyList = new List<DOL.Frequencyy>();

            DataTable dt = _objFrequency.GetFrequencyByInspection(InspectId);

            FrequencyList = dt.DataTableToList<DOL.Frequencyy>();

            string retStr = string.Empty;

            Session["Frequencies"] = FrequencyList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region --> Post Method For Periods
        [HttpPost]
        public ActionResult GetPeriodByFrequency(int FreqId)
        {
            string PlantCode = string.Empty;

            List<DOL.Period> PeriodList = new List<DOL.Period>();

            DataTable dt = _objPeriod.GetPeriodByFrequency(FreqId);

            PeriodList = dt.DataTableToList<DOL.Period>();

            string retStr = string.Empty;

            Session["Periods"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region --> Post Method For Operations
        [HttpPost]
        public ActionResult GetOperationsByProject(int ProjectId)
        {
            string PlantCode = string.Empty;

            List<DOL.Operations> PeriodList = new List<DOL.Operations>();

            DataTable dt = _objProject.GetOperationsByProject(ProjectId);

            PeriodList = dt.DataTableToList<DOL.Operations>();

            string retStr = string.Empty;

            Session["Operations"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region --> Post Method For Operations
        [HttpPost]
        public ActionResult GetPartToInspectByProject(int ProjectId)
        {
            string PlantCode = string.Empty;

            List<DOL.Inspectors> PeriodList = new List<DOL.Inspectors>();

            DataTable dt = _objProject.GetPartToInspectByProject(ProjectId);

            PeriodList = dt.DataTableToList<DOL.Inspectors>();

            string retStr = string.Empty;

            Session["Inspector"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region --> Post Method For InspectionItems
        [HttpPost]
        public ActionResult GetCircuitInspectionItemByStation(int StationId)
        {
            string PlantCode = string.Empty;

            List<DOL.CircuitInspectionItem> PeriodList = new List<DOL.CircuitInspectionItem>();

            DataTable dt = _objProject.GetCircuitInspectionItemByStation(StationId);

            PeriodList = dt.DataTableToList<DOL.CircuitInspectionItem>();

            string retStr = string.Empty;

            Session["InspectionItem"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region --> Post Method For Sections
        [HttpPost]
        public ActionResult GetSectionByProject(int ProjectId)
        {
            string PlantCode = string.Empty;

            List<DOL.Sections> PeriodList = new List<DOL.Sections>();

            DataTable dt = _objProject.GetSectionByProject(ProjectId);

            PeriodList = dt.DataTableToList<DOL.Sections>();

            string retStr = string.Empty;

            Session["Section"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region --> Post Method For DestructiveInspection
        [HttpPost]
        public ActionResult GetDestructiveInspectionByProject(int ProjectId)
        {
            string PlantCode = string.Empty;

            List<DOL.DestructiveInspectionItem> PeriodList = new List<DOL.DestructiveInspectionItem>();

            DataTable dt = _objProject.GetDestructiveInspectionByProject(ProjectId);

            PeriodList = dt.DataTableToList<DOL.DestructiveInspectionItem>();

            string retStr = string.Empty;

            Session["Inspections"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region --> Post Method For DestructiveWire
        [HttpPost]
        public ActionResult GetDestructiveWireByDestructiveInspection(int InspectionId)
        {
            string PlantCode = string.Empty;

            List<DOL.DestructiveWire> PeriodList = new List<DOL.DestructiveWire>();

            DataTable dt = _objProject.GetDestructiveWireByDestructiveInspection(InspectionId);

            PeriodList = dt.DataTableToList<DOL.DestructiveWire>();

            string retStr = string.Empty;

            Session["Wires"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion

        [HttpPost]

        public ActionResult UploadDocument(AuditCheckPointViewModel model, HttpPostedFileBase file)
        {
            model.AuditList = new DataTable();
            if (!ModelState.IsValid)
                return View(model);

            DOL.AuditCheckPoint AuditObj = new DOL.AuditCheckPoint();

            MemoryStream target = new MemoryStream();
            file.InputStream.CopyTo(target);
            byte[] data = target.ToArray();
            String profilePic = Convert.ToBase64String(data);
            profilePic = "data:image/jpeg;base64," + profilePic;

            AuditObj.Image = profilePic;

            Session["Image"] = AuditObj.Image;

            return View(AuditObj);

        }

        [HttpGet]
        public ActionResult ProductionStation()
        {
            ProdModuleViewModel obj = new ProdModuleViewModel();
            obj.Projects = _objProject.GetProject();
            obj.Batches = new List<DOL.Batch>();
            obj.Zones = new List<DOL.Zone>();

            Session["Project"] = obj.Projects;


            return View(obj);
        }

        [HttpPost]
        public ActionResult ProductionStation(ProdModuleViewModel model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
            model.Batches = (List<DOL.Batch>)Session["Batches"];
            model.Zones = (List<DOL.Zone>)Session["Zones"];

            if (!ModelState.IsValid)
                return View(model);

            DOL.ProdModule obj = new DOL.ProdModule();
            obj.ProjectId = model.ProjectId;
            obj.BatchId = model.BatchId;
            obj.ZoneId = model.ZoneId;
            obj.Module = model.Module;
            obj.CreatedBy = Session["EmpNumber"].ToString();

            int i = _ObjParameters.InsertProdModule(obj);
            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "Sucessfully Parameters Created!!!";
                return RedirectToAction("ProductionStation");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This Production Station !!!");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult ProductionLineLeader()
        {
            ProductionLineLeaderViewModel obj = new ProductionLineLeaderViewModel();
            obj.Projects = _objProject.GetProject();
            //obj.Projects = _objProject.GetProject();
            obj.Batches = new List<DOL.Batch>();
            obj.Zones = new List<DOL.Zone>();

            Session["Project"] = obj.Projects;


            return View(obj);
        }

        [HttpPost]
        public ActionResult ProductionLineLeader(ProductionLineLeaderViewModel model, HttpPostedFileBase file)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
            model.Batches = (List<DOL.Batch>)Session["Batches"];
            model.Zones = (List<DOL.Zone>)Session["Zones"];

            if (!ModelState.IsValid)
                return View(model);

            DOL.ProductionLineLeader obj = new DOL.ProductionLineLeader();
            obj.ProjectId = model.ProjectId;
            obj.BatchId = model.BatchId;
            obj.ZoneId = model.ZoneId;
            obj.EmpId = model.EmpId;

            MemoryStream target = new MemoryStream();
            file.InputStream.CopyTo(target);
            byte[] data = target.ToArray();
            String profilePic = Convert.ToBase64String(data);
            profilePic = "data:image/jpeg;base64," + profilePic;
            obj.Imagee = profilePic;
            obj.LineLeader = model.LineLeader;
            obj.CreatedBy = Session["EmpNumber"].ToString();

            int i = _ObjParameters.InsertProductionLineLeader(obj);
            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "Sucessfully Parameters Created!!!";
                return RedirectToAction("ProductionLineLeader");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This ProductionLineLeader !!!");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult ProuctionActivity()
        {
            ProdRiskPointsViewModel obj = new ProdRiskPointsViewModel();
            obj.Projects = _objProject.GetProject();
            obj.Batches = new List<DOL.Batch>();
            obj.Zones = new List<DOL.Zone>();
            obj.ProdModules = new List<DOL.ProdModule>();
            Session["Project"] = obj.Projects;


            return View(obj);
        }

        [HttpPost]
        public ActionResult ProuctionActivity(ProdRiskPointsViewModel model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
            model.Batches = (List<DOL.Batch>)Session["Batches"];
            model.Zones = (List<DOL.Zone>)Session["Zones"];
            model.ProdModules = (List<DOL.ProdModule>)Session["ProdModules"];

            if (!ModelState.IsValid)
                return View(model);

            DOL.ProdRiskPoints obj = new DOL.ProdRiskPoints();
            obj.ProjectId = model.ProjectId;
            obj.BatchId = model.BatchId;
            obj.ZoneId = model.ZoneId;
            obj.ModuleId = model.ModuleId;
            obj.Points = model.Points;
            obj.CreatedBy = Session["EmpNumber"].ToString();

            int i = _ObjParameters.InsertProdRiskPoints(obj);
            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "Sucessfully Prouction Activity Created!!!";
                return RedirectToAction("ProuctionActivity");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This Prouction Activity !!!");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult A246CVisualInspection()
        {
            ProcessTourDataModelView obj = new ProcessTourDataModelView();
            obj.Projects = _objProject.GetProject();
            obj.Stations = new List<DOL.Station>();
            obj.Visualss = new List<DOL.Visuals>();
            //obj.ProdModules = new List<DOL.ProdModule>();
            Session["Project"] = obj.Projects;


            return View(obj);
        }

        [HttpPost]
        public ActionResult A246CVisualInspection(ProcessTourDataModelView model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
            model.Stations = (List<DOL.Station>)Session["Station"];
            model.Visualss = (List<DOL.Visuals>)Session["Visuals"];
            //model.ProdModules = (List<DOL.ProdModule>)Session["ProdModules"];

            if (!ModelState.IsValid)
                return View(model);

            DOL.ProcessTourData obj = new DOL.ProcessTourData();
            obj.ProjectId = model.ProjectId;
            obj.StationId = model.StationId;
            obj.VisualsId = model.VisualsId;
            obj.SNo = model.SNo;
            obj.InpectionProject = model.InpectionProject;
            obj.InspectionSpecifaction = model.InspectionSpecifaction;
            obj.SampleSize = model.SampleSize;
            obj.CreatedBy = Session["EmpNumber"].ToString();

            int i = _ObjParameters.InsertProcessTourData(obj);
            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "Sucessfully A246C Visual Inspection Created!!!";
                return RedirectToAction("A246CVisualInspection");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This A246C Visual Inspection !!!");
            }
            return View(model);
        }


        [HttpGet]
        public ActionResult A246CCTPMCStationsLine2()
        {
            A246CStationCTPOneViewModel obj = new A246CStationCTPOneViewModel();
            obj.Projects = _objProject.GetProject();
            obj.Machines = new List<DOL.A246CMachines>();
            //obj.Zones = new List<DOL.Zone>();
            //obj.ProdModules = new List<DOL.ProdModule>();
            Session["Project"] = obj.Projects;


            return View(obj);
        }

        [HttpPost]
        public ActionResult A246CCTPMCStationsLine2(A246CStationCTPOneViewModel model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
            model.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            //model.Zones = (List<DOL.Zone>)Session["Zones"];
            //model.ProdModules = (List<DOL.ProdModule>)Session["ProdModules"];

            if (!ModelState.IsValid)
                return View(model);

            DOL.A246CStationCTPOne obj = new DOL.A246CStationCTPOne();
            obj.ProjectId = model.ProjectId;
            obj.MachineId = model.MachineId;
            obj.StationNo = model.StationNo;
            obj.StationName = model.StationName;
            obj.EquipmentName = model.EquipmentName;
            obj.CreatedBy = Session["EmpNumber"].ToString();

            int i = _ObjParameters.InsertA246CCTPMCStationsOne(obj);
            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "Sucessfully Station Created!!!";
                return RedirectToAction("A246CCTPMCStationsLine2");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This Stations !!!");
            }
            return View(model);
        }


        [HttpGet]
        public ActionResult A246CParameterCTPLine2()
        {
            A246CParameterCTPOneViewModel obj = new A246CParameterCTPOneViewModel();
            obj.Projects = _objProject.GetProject();
            obj.Machines = new List<DOL.A246CMachines>();
            obj.Stations = new List<DOL.A246CStationCTPOne>();
           // obj.ProdModules = new List<DOL.ProdModule>();
            Session["Project"] = obj.Projects;


            return View(obj);
        }

        [HttpPost]
        public ActionResult A246CParameterCTPLine2(A246CParameterCTPOneViewModel model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
            model.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            model.Stations = (List<DOL.A246CStationCTPOne>)Session["StationCTPLine2"];
            //model.ProdModules = (List<DOL.ProdModule>)Session["ProdModules"];

            if (!ModelState.IsValid)
                return View(model);

            DOL.A246CParameterCTPOne obj = new DOL.A246CParameterCTPOne();
            obj.ProjectId = model.ProjectId;
            obj.MachineId = model.MachineId;
            obj.StationId = model.StationId;
            obj.ParameterName = model.ParameterName;
            obj.Unit = model.Unit;
            obj.LSL = model.LSL;
            obj.USL = model.USL;
            obj.CreatedBy = Session["EmpNumber"].ToString();

            int i = _ObjParameters.InsertA246CParameterCTPOne(obj);
            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "Sucessfully Parameter Created!!!";
                return RedirectToAction("A246CParameterCTPLine2");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This Parameter !!!");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult A246CCTPMCStations()
        {
            A246CCTPMCStationsViewModel obj = new A246CCTPMCStationsViewModel();
            obj.Projects = _objProject.GetProject();
            obj.Machines = new List<DOL.A246CMachines>();
            //obj.Zones = new List<DOL.Zone>();
            //obj.ProdModules = new List<DOL.ProdModule>();
            Session["Project"] = obj.Projects;


            return View(obj);
        }

        [HttpPost]
        public ActionResult A246CCTPMCStations(A246CCTPMCStationsViewModel model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
            model.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            //model.Zones = (List<DOL.Zone>)Session["Zones"];
            //model.ProdModules = (List<DOL.ProdModule>)Session["ProdModules"];

            if (!ModelState.IsValid)
                return View(model);

            DOL.A246CCTPMCStations obj = new DOL.A246CCTPMCStations();
            obj.ProjectId = model.ProjectId;
            obj.MachineId = model.MachineId;
            obj.StationNo = model.StationNo;
            obj.Station = model.Station;
            obj.EquipmentModel = model.EquipmentModel;
            obj.CreatedBy = Session["EmpNumber"].ToString();

            int i = _ObjParameters.InsertA246CCTPMCStations(obj);
            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "Sucessfully Station Created!!!";
                return RedirectToAction("A246CCTPMCStations");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This Stations !!!");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult A246CParameterCTP()
        {
            A246CCTPMCParameterViewModel obj = new A246CCTPMCParameterViewModel();
            obj.Projects = _objProject.GetProject();
            obj.Machines = new List<DOL.A246CMachines>();
            obj.Stations = new List<DOL.A246CCTPMCStations>();
            // obj.ProdModules = new List<DOL.ProdModule>();
            Session["Project"] = obj.Projects;


            return View(obj);
        }

        [HttpPost]
        public ActionResult A246CParameterCTP(A246CCTPMCParameterViewModel model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
            model.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            model.Stations = (List<DOL.A246CCTPMCStations>)Session["StationCTP"];
            //model.ProdModules = (List<DOL.ProdModule>)Session["ProdModules"];

            if (!ModelState.IsValid)
                return View(model);

            DOL.A246CCTPMCParameter obj = new DOL.A246CCTPMCParameter();
            obj.ProjectId = model.ProjectId;
            obj.MachineId = model.MachineId;
            obj.StationId = model.StationId;
            obj.Parameter = model.Parameter;
            //obj.Unit = model.Unit;
            //obj.LSL = model.LSL;
            //obj.USL = model.USL;
            obj.CreatedBy = Session["EmpNumber"].ToString();

            int i = _ObjParameters.InsertA246CCTPMCParameter(obj);
            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "Sucessfully Parameter Created!!!";
                return RedirectToAction("A246CParameterCTP");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This Parameter !!!");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult A246CParameterCTPLimits()
        {
            A246CCTPMCParameterLimitsViewModel obj = new A246CCTPMCParameterLimitsViewModel();
            obj.Projects = _objProject.GetProject();
            obj.Machines = new List<DOL.A246CMachines>();
            obj.Stations = new List<DOL.A246CCTPMCStations>();
            obj.Parameters = new List<DOL.A246CCTPMCParameter>();
            Session["Project"] = obj.Projects;


            return View(obj);
        }

        [HttpPost]
        public ActionResult A246CParameterCTPLimits(A246CCTPMCParameterLimitsViewModel model)
        {
            model.Projects = (List<DOL.Project>)Session["Project"];
            model.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            model.Stations = (List<DOL.A246CCTPMCStations>)Session["StationCTP"];
            model.Parameters = (List<DOL.A246CCTPMCParameter>)Session["StationCTPParameter"];

            if (!ModelState.IsValid)
                return View(model);

            DOL.A246CCTPMCParameterLimits obj = new DOL.A246CCTPMCParameterLimits();
            obj.ProjectId = model.ProjectId;
            obj.MachineId = model.MachineId;
            obj.StationId = model.StationId;
            obj.ParameterId = model.ParameterId;
            obj.unit = model.unit;
            obj.LSL = model.LSL;
            obj.USL = model.USL;
            obj.CreatedBy = Session["EmpNumber"].ToString();

            int i = _ObjParameters.InsertA246CCTPMCParameterLimits(obj);
            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "Sucessfully Parameter Limits Created!!!";
                return RedirectToAction("A246CParameterCTPLimits");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This Parameter Limits !!!");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult NGApprovalFlow()
        {
            NGApprovalFlowModelView obj = new NGApprovalFlowModelView();
            obj.Menuss = _objProject.GetMasterMenus();

            Session["Menuss"] = obj.Menuss;
            obj.Datas = new List<DOL.AllDataModlodelView>();
            //Session["Datas"] = obj.Datas;

            return View(obj);
        }

        [HttpPost]
        public ActionResult NGApprovalFlow(NGApprovalFlowModelView model)
        {
            // model.Menuss = (List<DOL.MasterMenuss>)Session["Menuss"];
            // model.Datas = (List<DOL.AllDataModlodelView>)Session["Datas"];
            ////model.Stations = (List<DOL.A246CCTPMCStations>)Session["StationCTP"];
            ////model.Parameters = (List<DOL.A246CCTPMCParameter>)Session["StationCTPParameter"];

            //if (!ModelState.IsValid)
            //    return View(model);

            //DOL.NGApprovalFlow obj = new DOL.NGApprovalFlow();
            //obj.ApproveId = model.ApproveId;
            //obj.ApproveName = model.ApproveName;
            //obj.TaskId = model.TaskId;
            //obj.Designation = model.Designation;
            //obj.MenuId = model.MenuId;
            //obj.SectionId = model.SectionId;
            ////obj.unit = model.unit;
            ////obj.LSL = model.LSL;
            ////obj.USL = model.USL;
            //obj.CreatedBy = Session["EmpNumber"].ToString();

            //int i = _ObjParameters.InsertNGApprovalFlow(obj);
            //if (i > 0)
            //{
            //    TempData["mgs"] = "Sucess";
            //    TempData["Alert"] = "Sucessfully Approval Flow Created!!!";
            //    return RedirectToAction("NGApprovalFlow");
            //}
            //else
            //{
            //    ModelState.AddModelError("ERROR", "Already Exists This in  Approval Flow !!!");
            //}
            //return View(model);

            string filepath = string.Empty;


            string EmpNumber = (string)Session["EmpNumber"];
            if (model.UploadFile != null)
            {
                string path = Server.MapPath("~/Upload_Files/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                filepath = path + "Temp";
                string extension = Path.GetExtension(model.UploadFile.FileName);
                model.UploadFile.SaveAs(filepath);

                string conString = string.Empty;
                //if (extension != ".xls")
                //{
                switch (extension)
                {
                    case ".xls": //Excel 97-03.
                        conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                        break;
                    case ".xlsx": //Excel 07 and above.
                        conString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                        break;
                }

                conString = string.Format(conString, filepath);

                using (OleDbConnection connExcel = new OleDbConnection(conString))
                {
                    using (OleDbCommand cmdExcel = new OleDbCommand())
                    {
                        using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                        {
                            DataTable dt = new DataTable();
                            cmdExcel.Connection = connExcel;

                            //Get the name of First Sheet.
                            connExcel.Open();
                            DataTable dtExcelSchema;
                            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                            string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                            connExcel.Close();

                            //Read Data from First Sheet.
                            connExcel.Open();
                            cmdExcel.CommandText = "SELECT * From [" + sheetName + "] WHERE Id IS NOT NULL";
                            odaExcel.SelectCommand = cmdExcel;
                            odaExcel.Fill(dt);
                            connExcel.Close();


                            //int j = 1;
                            int j = _ObjParameters.InsertBulkNGApprovalFlow(dt, EmpNumber);
                            if (j > 0)
                            {
                                TempData["mgs"] = "Sucess";
                                TempData["Alert"] = "Sucessfully NG Approval Flow Created!!!";

                                return RedirectToAction("NGApprovalFlow");
                            }
                            else
                            {
                                ModelState.AddModelError("ERROR", "NG Approval Flow  already Inserted");
                            }


                        }
                    }
                }
               
            }
            //NGApprovalFlowModelView obj = new NGApprovalFlowModelView();
            return View(model);
        }

        public ActionResult ApprovalFlowDelete(int Id)
        {


            using (SqlConnection mConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString))
            {
                using (SqlCommand mCommand = new SqlCommand("[ipqc].[InsertNGApprovalFlow]", mConnection))
                {

                    mCommand.CommandType = CommandType.StoredProcedure;
                    mCommand.Parameters.AddWithValue("@action", "Delete");
                    mCommand.Parameters.AddWithValue("@Id", Id);

                    try
                    {
                        mConnection.Open();
                        mCommand.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
            }

            return RedirectToAction("NGApprovalFlow");
        }

        [HttpGet]
        public ActionResult ControlChartNGApprovalFlow()
        {
            NGApprovalFlowModelView obj = new NGApprovalFlowModelView();
            obj.Menuss = _objProject.GetMasterMenus();

            Session["Menuss"] = obj.Menuss;
            obj.Datas = new List<DOL.AllDataModlodelView>();
            //Session["Datas"] = obj.Datas;

            return View(obj);
        }

        [HttpPost]
        public ActionResult ControlChartNGApprovalFlow(NGApprovalFlowModelView model)
        {
            string filepath = string.Empty;


            string EmpNumber = (string)Session["EmpNumber"];
            if (model.UploadFile != null)
            {
                string path = Server.MapPath("~/Upload_Files/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                filepath = path + "Temp";
                string extension = Path.GetExtension(model.UploadFile.FileName);
                model.UploadFile.SaveAs(filepath);

                string conString = string.Empty;
                //if (extension != ".xls")
                //{
                switch (extension)
                {
                    case ".xls": //Excel 97-03.
                        conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                        break;
                    case ".xlsx": //Excel 07 and above.
                        conString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                        break;
                }

                conString = string.Format(conString, filepath);

                using (OleDbConnection connExcel = new OleDbConnection(conString))
                {
                    using (OleDbCommand cmdExcel = new OleDbCommand())
                    {
                        using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                        {
                            DataTable dt = new DataTable();
                            cmdExcel.Connection = connExcel;

                            //Get the name of First Sheet.
                            connExcel.Open();
                            DataTable dtExcelSchema;
                            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                            string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                            connExcel.Close();

                            //Read Data from First Sheet.
                            connExcel.Open();
                            cmdExcel.CommandText = "SELECT * From [" + sheetName + "] WHERE Id IS NOT NULL";
                            odaExcel.SelectCommand = cmdExcel;
                            odaExcel.Fill(dt);
                            connExcel.Close();


                            //int j = 1;
                            int j = _ObjParameters.InsertBulkxBARNGApprovalFlow(dt, EmpNumber);
                            if (j > 0)
                            {
                                TempData["mgs"] = "Sucess";
                                TempData["Alert"] = "Sucessfully NG Approval Flow Created!!!";

                                return RedirectToAction("ControlChartNGApprovalFlow");
                            }
                            else
                            {
                                ModelState.AddModelError("ERROR", "NG Approval Flow  already Inserted");
                            }


                        }
                    }
                }

            }
            //NGApprovalFlowModelView obj = new NGApprovalFlowModelView();
            return View(model);
        }

        [HttpGet]
        public ActionResult CTPNGApprovalFlow()
        {
            NGApprovalFlowModelView obj = new NGApprovalFlowModelView();
            obj.Menuss = _objProject.GetMasterMenus();

            Session["Menuss"] = obj.Menuss;
            obj.Datas = new List<DOL.AllDataModlodelView>();
            //Session["Datas"] = obj.Datas;

            return View(obj);
        }

        [HttpPost]
        public ActionResult CTPNGApprovalFlow(NGApprovalFlowModelView model)
        {
            string filepath = string.Empty;


            string EmpNumber = (string)Session["EmpNumber"];
            if (model.UploadFile != null)
            {
                string path = Server.MapPath("~/Upload_Files/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                filepath = path + "Temp";
                string extension = Path.GetExtension(model.UploadFile.FileName);
                model.UploadFile.SaveAs(filepath);

                string conString = string.Empty;
                //if (extension != ".xls")
                //{
                switch (extension)
                {
                    case ".xls": //Excel 97-03.
                        conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                        break;
                    case ".xlsx": //Excel 07 and above.
                        conString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                        break;
                }

                conString = string.Format(conString, filepath);

                using (OleDbConnection connExcel = new OleDbConnection(conString))
                {
                    using (OleDbCommand cmdExcel = new OleDbCommand())
                    {
                        using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                        {
                            DataTable dt = new DataTable();
                            cmdExcel.Connection = connExcel;

                            //Get the name of First Sheet.
                            connExcel.Open();
                            DataTable dtExcelSchema;
                            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                            string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                            connExcel.Close();

                            //Read Data from First Sheet.
                            connExcel.Open();
                            cmdExcel.CommandText = "SELECT * From [" + sheetName + "] WHERE Id IS NOT NULL";
                            odaExcel.SelectCommand = cmdExcel;
                            odaExcel.Fill(dt);
                            connExcel.Close();


                            //int j = 1;
                            int j = _ObjParameters.InsertBulkCTPNGApprovalFlow(dt, EmpNumber);
                            if (j > 0)
                            {
                                TempData["mgs"] = "Sucess";
                                TempData["Alert"] = "Sucessfully NG Approval Flow Created!!!";

                                return RedirectToAction("CTPNGApprovalFlow");
                            }
                            else
                            {
                                ModelState.AddModelError("ERROR", "NG Approval Flow  already Inserted");
                            }


                        }
                    }
                }

            }
            //NGApprovalFlowModelView obj = new NGApprovalFlowModelView();
            return View(model);
        }

        [HttpGet]
        public ActionResult A191LaserNGApprovalFlow()
        {
            NGApprovalFlowModelView obj = new NGApprovalFlowModelView();
            obj.Menuss = _objProject.GetMasterMenus();

            Session["Menuss"] = obj.Menuss;
            obj.Datas = new List<DOL.AllDataModlodelView>();
            //Session["Datas"] = obj.Datas;

            return View(obj);
        }

        [HttpPost]
        public ActionResult A191LaserNGApprovalFlow(NGApprovalFlowModelView model)
        {
            string filepath = string.Empty;

            string EmpNumber = (string)Session["EmpNumber"];
            if (model.UploadFile != null)
            {
                string path = Server.MapPath("~/Upload_Files/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                filepath = path + "Temp";
                string extension = Path.GetExtension(model.UploadFile.FileName);
                model.UploadFile.SaveAs(filepath);

                string conString = string.Empty;
                //if (extension != ".xls")
                //{
                switch (extension)
                {
                    case ".xls": //Excel 97-03.
                        conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                        break;
                    case ".xlsx": //Excel 07 and above.
                        conString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                        break;
                }

                conString = string.Format(conString, filepath);

                using (OleDbConnection connExcel = new OleDbConnection(conString))
                {
                    using (OleDbCommand cmdExcel = new OleDbCommand())
                    {
                        using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                        {
                            DataTable dt = new DataTable();
                            cmdExcel.Connection = connExcel;

                            //Get the name of First Sheet.
                            connExcel.Open();
                            DataTable dtExcelSchema;
                            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                            string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                            connExcel.Close();

                            //Read Data from First Sheet.
                            connExcel.Open();
                            cmdExcel.CommandText = "SELECT * From [" + sheetName + "] WHERE Id IS NOT NULL";
                            odaExcel.SelectCommand = cmdExcel;
                            odaExcel.Fill(dt);
                            connExcel.Close();


                            //int j = 1;
                            int j = _ObjParameters.InsertBulkA191LaserNGApprovalFlow(dt, EmpNumber);
                            if (j > 0)
                            {
                                TempData["mgs"] = "Sucess";
                                TempData["Alert"] = "Sucessfully A191 Laser Engraving NG Approval Flow Created!!!";

                                return RedirectToAction("A191LaserNGApprovalFlow");
                            }
                            else
                            {
                                ModelState.AddModelError("ERROR", "NG Approval Flow  already Inserted");
                            }


                        }
                    }
                }

            }
            
            return View(model);
        }

        [HttpGet]
        public ActionResult ProcessTourDashBoard()
        {
            ProcessTourDashBoardModelView obj = new ProcessTourDashBoardModelView();
            obj.Lines = _ObjChecklistresults.GetLine();
            Session["Lines"] = obj.Lines;


            return View(obj);
        }

        [HttpPost]
        public ActionResult ProcessTourDashBoard(ProcessTourDashBoardModelView model)
        {
            model.Lines = (List<DOL.Line>)Session["Lines"];
            //model.Machines = (List<DOL.A246CMachines>)Session["Machines"];
            //model.Stations = (List<DOL.A246CCTPMCStations>)Session["StationCTP"];
            //model.Parameters = (List<DOL.A246CCTPMCParameter>)Session["StationCTPParameter"];

            if (!ModelState.IsValid)
                return View(model);

            DOL.ProcessTourDashBoard obj = new DOL.ProcessTourDashBoard();
           
            obj.Timee = model.Timee;
            obj.LineId = model.LineId;
            obj.CheckPoints = model.CheckPoints;
            obj.Pass = model.Pass;
            obj.Fail = model.Fail;
            //obj.unit = model.unit;
            //obj.LSL = model.LSL;
            //obj.USL = model.USL;
            obj.CreatedBy = Session["EmpNumber"].ToString();

            int i = _ObjParameters.InsertProcessTourForDashBoard(obj);
            if (i > 0)
            {
                TempData["mgs"] = "Sucess";
                TempData["Alert"] = "Sucessfully Process Tours Created!!!";
                return RedirectToAction("ProcessTourDashBoard");
            }
            else
            {
                ModelState.AddModelError("ERROR", "Already Exists This Parameter Limits !!!");
            }
            return View(model);
        }

        #region --> Post Method For A246CMachinesByProject

        [HttpPost]
        public ActionResult GetA246CMachinesByProject(int ProjectId)
        {
            string PlantCode = string.Empty;

            List<DOL.A246CMachines> PeriodList = new List<DOL.A246CMachines>();

            DataTable dt = _objProject2.GetA246CMachinesByProject(ProjectId);

            PeriodList = dt.DataTableToList<DOL.A246CMachines>();

            string retStr = string.Empty;

            Session["Machines"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region --> Post Method For A246CMachinesByProject

        [HttpPost]
        public ActionResult GetAllData(int MenuId)
        {
            string PlantCode = string.Empty;

            List<DOL.AllDataModlodelView> PeriodList = new List<DOL.AllDataModlodelView>();

            DataTable dt = _objProject2.GetAllData(MenuId);

            PeriodList = dt.DataTableToList<DOL.AllDataModlodelView>();

            string retStr = string.Empty;

            Session["Datas"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion



        #region --> Post Method For A246CCTPMCStationsByMachine

        [HttpPost]
        public ActionResult GetA246CCTPMCStationsByMachine(int MachineId)
        {
            string PlantCode = string.Empty;

            List<DOL.A246CCTPMCStations> PeriodList = new List<DOL.A246CCTPMCStations>();

            DataTable dt = _objProject2.A246CCTPMCStationsByMachine(MachineId);

            PeriodList = dt.DataTableToList<DOL.A246CCTPMCStations>();

            string retStr = string.Empty;

            Session["StationCTP"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region --> Post Method For A246CCTPMCParameterByStation

        [HttpPost]
        public ActionResult Get246CCTPMCParameterByStation(int StationId)
        {
            string PlantCode = string.Empty;

            List<DOL.A246CCTPMCParameter> PeriodList = new List<DOL.A246CCTPMCParameter>();

            DataTable dt = _objProject2.A246CCTPMCParameterByStation(StationId);

            PeriodList = dt.DataTableToList<DOL.A246CCTPMCParameter>();

            string retStr = string.Empty;

            Session["StationCTPParameter"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region --> Post Method For A246CCTPMCParameterByStationLine2

        [HttpPost]
        public ActionResult GetA246CCTPMCStationsByMachineLine2(int MachineId)
        {
            string PlantCode = string.Empty;

            List<DOL.A246CStationCTPOne> PeriodList = new List<DOL.A246CStationCTPOne>();

            DataTable dt = _objProject2.A246CCTPMCStationsByMachineLine2(MachineId);

            PeriodList = dt.DataTableToList<DOL.A246CStationCTPOne>();

            string retStr = string.Empty;

            Session["StationCTPLine2"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion



        #region --> Post Method For Location
        [HttpPost]
        public ActionResult GetLocation(int ProjectId)
        {
            string PlantCode = string.Empty;

            List<DOL.Location> PeriodList = new List<DOL.Location>();

            DataTable dt = _objProject.GetLocation(ProjectId);

            PeriodList = dt.DataTableToList<DOL.Location>();

            string retStr = string.Empty;

            Session["Location"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region --> Post Method For Tear Drop Inspection
        [HttpPost]
        public ActionResult GetTearDropInspection(int ProjectId)
        {
            string PlantCode = string.Empty;

            List<DOL.TearDown> PeriodList = new List<DOL.TearDown>();

            DataTable dt = _objProject.GetTearDrop(ProjectId);

            PeriodList = dt.DataTableToList<DOL.TearDown>();

            string retStr = string.Empty;

            Session["Tears"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion




        #region --> Post Method For Batches

        [HttpPost]
        public ActionResult GetBatchByProject(int ProjectId)
        {
            string PlantCode = string.Empty;

            List<DOL.Batch> PeriodList = new List<DOL.Batch>();

            DataTable dt = _objProject2.GetBatchByProject(ProjectId);

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

            DataTable dt = _objProject2.GetProductionLineLeaderByBatch(ZoneId);

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

            DataTable dt = _objProject2.GetZoneByBatch(BatchId);

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

            DataTable dt = _objProject2.GetProdModuleByProject(ZoneId);

            PeriodList = dt.DataTableToList<DOL.ProdModule>();

            string retStr = string.Empty;

            Session["ProdModules"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region --> Post Method For A246C Visual Inspection

        [HttpPost]
        public ActionResult GetA246CVisualsByProject(int ProjectId)
        {
            string PlantCode = string.Empty;

            List<DOL.Visuals> PeriodList = new List<DOL.Visuals>();

            DataTable dt = _objProject2.GetVisualsByproject(ProjectId);

            PeriodList = dt.DataTableToList<DOL.Visuals>();

            string retStr = string.Empty;

            Session["Visuals"] = PeriodList;

            retStr = _cont.ConvertToJson(dt);

            return Json(retStr, JsonRequestBehavior.AllowGet);
        }

        #endregion


    }

    
}
