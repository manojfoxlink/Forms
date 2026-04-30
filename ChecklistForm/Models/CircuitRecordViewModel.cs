using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DOL;
namespace ChecklistForm.Models
{
    public class CircuitRecordViewModel
    {
        [Display(Name = "Inspection item")]
        [Required]
        
        public string Inspectionitem { get; set; }

        [Display(Name = "Model Number")]
        [Required]
        public string  ModelNumber { get; set; }

        [Display(Name = "Inspection Specification")]
        [Required]
        public string InspecSpecification { get; set; }

        //[Display(Name = "Inspection Specification")]
        //[Required]
        public string CreatedBy { get; set; }

        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
    }

    public class CircuitInspectionItemViewModel
    {
        public int ItemId { get; set; }

        public string InspectionItem { get; set; }

        public int ProjectId { get; set; }

        public int StationId { get; set; }

        public string CreatedBy { get; set; }

        public List<Project> Projects { get; set; }

        public List<Station> Stations { get; set; }
    }

    public class DestructiveSpecViewModel
    {
        public int FrequencyId { get; set; }

        public string InspectionItem { get; set; }

        public int ProjectId { get; set; }

        public int InspectionId { get; set; }

        public Decimal? Spec { get; set; }

        public Decimal? LSL { get; set; }

        //public int WireId { get; set; }

        public int CreatedBy { get; set; }

        public List<Project> Projects { get; set; }

        public List<DestructiveInspectionItem> Inspections { get; set; }

        public List<DestructiveFrequency> Freqs { get; set; }

        public int WireId { get; set; }

        public List<DestructiveWire> Wires { get; set; }
    }

    public class CircuitInspectionSpecViewModel
    {
        public int SpecId { get; set; }

        //public string InspectionSpecification { get; set; }

        public Decimal? LowerLimit { get; set; }

        public Decimal? UpperLimit { get; set; }

        public string InspectionSpecification { get; set; }

        public int ProjectId { get; set; }

        public int StationId { get; set; }

        public int ItemId { get; set; }

        public int FreqId { get; set; }

        public int PeriodId { get; set; }

        public string CreatedBy { get; set; }

        public List<Project> Projects { get; set; }

        public List<Station> Stations { get; set; }

        public List<CircuitInspectionItem> InspectionItems { get; set; }

        public List<Frequen> Freqs { get; set; }

        public List<Periodss> Periods { get; set; }
    }
    public class CTQPartsToInspectModelView
    {
        public int InspectionId { get; set; }

        public int ProjectId { get; set; }

        public int SectionId { get; set; }

        public string SNo { get; set; }

        public string Section { get; set; }


        public string PartToInspect { get; set; }

        public string CreatedBy { get; set; }

        public List<Project> Projects { get; set; }

        public List<Sections> Sections { get; set; }
    }

    public class DestructiveWireModelView
    {
      public int InspectionId { get; set; }

        public int ProjectId { get; set; }

        public string Wire { get; set; }

        public string CreatedBy { get; set; }

        public List<Project> Projects { get; set; }

        public List<DestructiveInspectionItem> Inspections { get; set; }
    }

    public class DestructiveInspectionItemModelView
    {
        public int InspectionId { get; set; }

        public int ProjectId { get; set; }

        public string Inspection { get; set; }

        public List<Project> Projects { get; set; }

        
        public string CreatedBy { get; set; }
    }

    public class PaperCollarModelView
    {
        public int LocationId { get; set; }

        public int ProjectId { get; set; }

        public string Collar { get; set; }

        public List<Project> Projects { get; set; }

        public List<DOL.Location> Locations { get; set; }


        public string CreatedBy { get; set; }
    }

    public class FacePlateC70ModelView
    {
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public string FacePlate { get; set; }

        public int LocationId { get; set; }

        public List<DOL.Location> Locations { get; set; }
        public string CreatedBy { get; set; }
    }

    public class FacePlateC91ModelView
    {
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public string FacePlate { get; set; }

        public int LocationId { get; set; }

        public List<DOL.Location> Locations { get; set; }
        public string CreatedBy { get; set; }
    }

    public class ProdModuleViewModel
    {
        public int ModuleId { get; set; }

        public string Module { get; set; }

        public int ProjectId { get; set; }

        public List<DOL.Project> Projects { get; set; }
        public int CreatedBy { get; set; }

        public int BatchId { get; set; }

        public List<DOL.Batch> Batches { get; set; }

        public int ZoneId { get; set; }

        public List<DOL.Zone> Zones { get; set; }
    }

    public class ProdRiskPointsViewModel
    {
        public int ProjectId { get; set; }

        public List<DOL.Project> Projects { get; set; }

        public int BatchId { get; set; }

        public List<DOL.Batch> Batches { get; set; }

        public int ZoneId { get; set; }

        public List<DOL.Zone> Zones { get; set; }

        public int ModuleId { get; set; }

        public List<ProdModule> ProdModules { get; set; }
        public string Points { get; set; }

        public string Dept { get; set; }


        public string CreatedBy { get; set; }

        public int RiskId { get; set; }
    }

    public class ProductionLineLeaderViewModel
    {
        public int ProjectId { get; set; }

        public List<DOL.Project> Projects { get; set; }

        public int BatchId { get; set; }

        public List<DOL.Batch> Batches { get; set; }

        public int ZoneId { get; set; }

        public List<DOL.Zone> Zones { get; set; }

        public string LineLeader { get; set; }

        public string CreatedBy { get; set; }

        public string Imagee { get; set; }

        public string EmpId { get; set; }
    }

    public class ProcessTourDataModelView
    {
        public int ProjectId { get; set; }
        public List<Project> Projects { get; set; }
        public int StationId { get; set; }

        public List<Station> Stations { get; set; }
        public List<Visuals> Visualss { get; set; }
        
        public int VisualsId { get; set; }

        public string SNo { get; set; }

        public string InpectionProject { get; set; }

        public string InspectionSpecifaction { get; set; }
        public string SampleSize { get; set; }

        public string CreatedBy { get; set; }
    }

    public class A246CStationCTPOneViewModel
    {
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }

        public int MachineId { get; set; }

        public List<A246CMachines> Machines { get; set; }

        public int StationNo { get; set; }

        public string StationName { get; set; }

        public string EquipmentName { get; set; }

        public string CreatedBy { get; set; }

    }

    public class A246CCTPMCStationsViewModel
    {
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }

        public int MachineId { get; set; }

        public List<A246CMachines> Machines { get; set; }

        public int StationNo { get; set; }

        public string Station { get; set; }

        public string EquipmentModel { get; set; }

        public string CreatedBy { get; set; }
    }

    public class A246CParameterCTPOneViewModel
    {

        public string Parameter { get; set; }
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }

        public int MachineId { get; set; }

        public List<A246CMachines> Machines { get; set; }

        public int StationId { get; set; }

        public List<A246CStationCTPOne> Stations { get; set; }

        public string ParameterName { get; set; }

        public string Unit { get; set; }

        public decimal? LSL { get; set; }

        public decimal? USL { get; set; }

        public string CreatedBy { get; set; }
    }

    public class A246CCTPMCParameterViewModel
    {
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }

        public int MachineId { get; set; }

        public List<A246CMachines> Machines { get; set; }

        public int StationId { get; set; }

        public List<A246CCTPMCStations> Stations { get; set; }

        public string Parameter { get; set; }

        //public string Unit { get; set; }

        //public decimal? LSL { get; set; }

        //public decimal? LSL { get; set; }

        public string CreatedBy { get; set; }
    }

    public class ProcessTourDashBoardModelView
    {
        public List<Line> Lines { get; set; }
        public int LineId { get; set; }
        public TimeSpan Timee { get; set; }

        public decimal? CheckPoints { get; set; }

        public decimal? Pass { get; set; }

        public decimal? Fail { get; set; }

        public string CreatedBy { get; set; }
    }
    public class A246CCTPMCParameterLimitsViewModel
    {
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }

        public int MachineId { get; set; }

        public List<A246CMachines> Machines { get; set; }

        public int StationId { get; set; }

        public List<A246CCTPMCStations> Stations { get; set; }

        public int ParameterId { get; set; }

        public List<A246CCTPMCParameter> Parameters { get; set; }

        public string unit { get; set; }

        public decimal? LSL { get; set; }

        public decimal? USL { get; set; }

        public string CreatedBy { get; set; }
    }

    public class NGApprovalFlowModelView
    {
        public int LaserId { get; set; }
        public int ParameterId { get; set; }
        public HttpPostedFileBase UploadFile { get; set; }
        public int SectionId { get; set; }

        public int AdhesiveId { get; set; }

        public string InspectionProject { get; set; }

        public int Section { get; set; }

        public int InspectionId { get; set; }

        public int MenuId { get; set; }
        public string ApproveId { get; set; }

        public List<MasterMenuss> Menuss { get; set; }

        public List<AllDataModlodelView> Datas { get; set; }

        public string ApproveName { get; set; }

        public int TaskId { get; set; }

        public string Designation { get; set; }

        public string CreatedBy { get; set; }
    }
    public class DefectsModelView
    {
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public string Defect { get; set; }

        public int LocationId { get; set; }

        public List<DOL.Location> Locations { get; set; }
        public string CreatedBy { get; set; }
    }

    public class TearDownModelView
    {
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }

        public string Sno { get; set; }
        public string TeardownSteps { get; set; }
        public string CreatedBy { get; set; }
    }

    public class LocationModelView
    {
        public int LocationId { get; set; }

        public string Locations { get; set; }

        public string CreatedBy { get; set; }

        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
    }

    public class TeardownInspectionsModelView
    {
        public int TearId { get; set; }

        public List<TearDown> Tears { get; set; }

        public string Inspection { get; set; }

        public string CreatedBy { get; set; }

        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
    }



    public class BootC91ModelView
    {
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public string Boott { get; set; }

        public int LocationId { get; set; }
        public List<DOL.Location> Locations { get; set; }

        public string CreatedBy { get; set; }
    }
    public class BootC70ModelView
    {
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public string Boot { get; set; }

        public List<DOL.Location> Locations { get; set; }

        public int LocationId { get; set; }
        public string CreatedBy { get; set; }
    }

    public class PlugShellC70ModelView
    {
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public string PlugShell { get; set; }

        public List<DOL.Location> Locations { get; set; }

        public int LocationId { get; set; }
        public string CreatedBy { get; set; }
    }

    public class PlugShellC91ModelView
    {
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public string PlugShelll { get; set; }

        public List<DOL.Location> Locations { get; set; }

        public int LocationId { get; set; }
        public string CreatedBy { get; set; }
    }

    public class DestructiveFrequencyModelView
    {
        public int ProjectId { get; set; }

        public string Frequency { get; set; }

        public string CreatedBy { get; set; }

        public string FrequencyId { get; set; }


        public List<Project> Projects { get; set; }
    }

    public class AdhesiveModelView
    {
        public int AdhesiveId { get; set; }

        public int ProjectId { get; set; }

        [Required]
        [Display(Name = "Lower Limit")]
        public Decimal? LowerLimit { get; set; }

        [Required]
        [Display(Name = "Center Limit")]
        public Decimal? CenterLimit { get; set; }

        [Required]
        [Display(Name = "Upper Limit")]
        public Decimal? UpperLimit { get; set; }

        public string Adhesive { get; set; }

        public string CreatedBy { get; set; }

        public List<Project> Projects { get; set; }
    }

    public class TemparatureRangeModelView
    {
        public int TempId { get; set; }

        public int ProjectId { get; set; }

        [Required]
        [Display(Name = "Lower Limit")]
        public Decimal? LowerLimit { get; set; }

        [Required]
        [Display(Name = "Center Limit")]
        public Decimal? CenterLimit { get; set; }

        [Required]
        [Display(Name = "Upper Limit")]
        public Decimal? UpperLimit { get; set; }

        public string RangeName { get; set; }

        public string CreatedBy { get; set; }

        public List<Project> Projects { get; set; }

        public string Range { get; set; }
    }

    public class FrequenModelView
    {
        public int ProjectId { get; set; }

        public int StationId { get; set; }

        public int ItemId { get; set; }

        public int FreqId { get; set; }

        public int SpecId { get; set; }

        public string Freq { get; set; }

        public List<Project> projects { get; set; }

        //public List<Station> projects { get; set; }

        public List<DOL.CircuitInspectionItem> Items { get; set; }

        public List<DOL.CircuitInspectionSpec> Specs { get; set; }


    }

    public class PeriodssModelView
    {
        public int ProjectId { get; set; }

        public int StationId { get; set; }

        public int ItemId { get; set; }

        public int FreqId { get; set; }

        public int SpecId { get; set; }

        public int PeriodId { get; set; }

        public string Period { get; set; }

        public List<Project> projects { get; set; }

        //public List<Station> projects { get; set; }

        public List<DOL.CircuitInspectionItem> Items { get; set; }

        public List<DOL.CircuitInspectionSpec> Specs { get; set; }

        public List<DOL.Frequen> Frequencies { get; set; }
    }

    
}