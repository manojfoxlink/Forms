using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOL
{
    public class CircuitRecord
    {
        public int RecordId { get;set;}

        public string Inspectionitem { get; set; }

        public string  ModelNumber { get; set; }

        public string InspecSpecification { get; set; }

        //public string Oneperiod { get; set; }

        //public string TwoQuaters { get; set; }

        //public string ThreeQuaters { get; set; }

        //public string FourQuaters { get; set; }

        //public string FiveQuaters { get; set; }

        //public string AdverseNumber { get; set; }

        public string CreatedBy { get; set; }

        public int ProjectId { get; set; }
    }

    public class CircuitInspectionItem
    {
        public int ItemId { get; set; }

        public string InspectionItem { get; set; }

        public int ProjectId { get; set; }

        public int StationId { get; set; }

        public string CreatedBy { get; set; }
    }

    public class CircuitInspectionSpec
    {
        public int SpecId { get; set; }

        public Decimal? LowerLimit { get; set; }

        public Decimal? UpperLimit { get; set; }

        public string InspectionSpecification { get; set; }
        public int ProjectId { get; set; }

        public int StationId { get; set; }

        public int ItemId { get; set; }

        public int FreqId { get; set; }

        public int PeriodId { get; set; }

        public string CreatedBy { get; set; }

    }

    public class Frequen
    {
        public int ProjectId { get; set; }

        public int StationId { get; set; }

        public int ItemId { get; set; }

        public int FreqId { get; set; }

        public int SpecId { get; set; }

        public string Freq { get; set; }
    }

    public class Periodss
    {
        public int ProjectId { get; set; }

        public int StationId { get; set; }

        public int ItemId { get; set; }

        public int FreqId { get; set; }

        public int SpecId { get; set; }

        public int PeriodId { get; set; }

        public string Period { get; set; }
    }

    public class CTQPartsToInspect
    {
        public int InspectionId { get; set; }

        public int ProjectId { get; set; }

        public int SectionId { get; set; }


        public string SNo { get; set; }

        public string Section { get; set; }

        public string PartToInspect { get; set; }

        public string CreatedBy { get; set; }

        public List<Project> Projects { get; set; }


    }
    public class Adhesivee
    {
        public int AdhesiveId { get; set; }

        public int ProjectId { get; set; }

        public Decimal? LowerLimit { get; set; }

        public Decimal? CenterLimit { get; set; }

        public Decimal? UpperLimit { get; set; }

        public string Adhesive { get; set; }

        public string CreatedBy { get; set; }

        public List<Project> Projects { get; set; }
    }

    public class TempRange
    {
        public int TempId { get; set; }

        public int ProjectId { get; set; }

        public Decimal? LowerLimit { get; set; }

        public Decimal? CenterLimit { get; set; }

        public Decimal? UpperLimit { get; set; }

        public string RangeName { get; set; }

        public string CreatedBy { get; set; }

        public List<Project> Projects { get; set; }

        public string Range { get; set; }
    }

    public class DestructiveInspectionItem
    {
        public int InspectionId { get; set; }

        public int ProjectId { get; set; }

        public string Inspection { get; set; }

        public List<Project> Projects { get; set; }

        public string CreatedBy { get; set; }
    }

    public class PaperCollar
    {
        public string Collar { get; set; }

        public int CollarId { get; set; }
        public int ProjectId { get; set; }

        public string Inspection { get; set; }

        public List<Location> Locations { get; set; }

        public int LocationId { get; set; }

        public List<Project> Projects { get; set; }

        public string CreatedBy { get; set; }
    }

    public class FacePlateC70
    {
        public int FacePlateId { get; set; }
        public int ProjectId { get; set; }

        public string FacePlate { get; set; }

        public string CreatedBy { get; set; }

        public int LocationId { get; set; }
    }

    public class FacePlateC91
    {
        public int FaceePlateId { get; set; }
        public int ProjectId { get; set; }

        public string FacePlate { get; set; }

        public string CreatedBy { get; set; }

        public int LocationId { get; set; }
    }

    public class Defects
    {
        public int DefectId { get; set; }
        public int ProjectId { get; set; }

        public string Defect { get; set; }

        public string CreatedBy { get; set; }

        public int LocationId { get; set; }
    }

    public class TearDown
    {
        public int TearId { get; set; }

        public string Sno { get; set; }

        public int ProjectId { get; set; }
        public string TeardownSteps { get; set; }
        public string CreatedBy { get; set; }
    }

    public class BootC91
    {

        public int BoottId { get; set; }
        public int ProjectId { get; set; }

        public string Boott { get; set; }

        public string CreatedBy { get; set; }

        public int LocationId { get; set; }
    }

    public class BootC70
    {
        public int BootId { get; set; }
        public int ProjectId { get; set; }

        public string Boot { get; set; }

        public string CreatedBy { get; set; }

        public int LocationId { get; set; }
    }

    //public class BootC70
    //{
    //    public int ProjectId { get; set; }

    //    public string Boot { get; set; }

    //    public string CreatedBy { get; set; }
    //}

    public class PlugShellC70
    {
        public int PlugId { get; set; }
        public int ProjectId { get; set; }

        public string PlugShell { get; set; }

        public string CreatedBy { get; set; }

        public int LocationId { get; set; }
    }

    public class PlugShellC91
    {
        public int PlugShellId { get; set; }
        public int ProjectId { get; set; }

        public string PlugShelll { get; set; }

        public string CreatedBy { get; set; }

        public int LocationId { get; set; }
    }

    public class Result
    {
        public int StatusId { get; set; }

        public string Status { get; set; }
    }

    public class ProdShiftLeader
    {
        public int ShiftLeaderId { get; set; }

        public string ShiftLeader { get; set; }
    }
    public class CheckedApporved
    {

        public List<DOL.ProdShiftLeader> ShiftLeaders { get; set; }
        public List<DOL.Batch> Batches { get; set; }
        public int VerifiedId { get; set; }

        public string Verified { get; set; }

        public int ApprovedId { get; set; }

        public string Approved { get; set; }

        public int AuditId { get; set; }

        public string Auditor { get; set; }

        public int CheckedId { get; set; }

        public string Checked { get; set; }
    }

    public class SRS
    {
        public int SRId { get; set; }

        public string SR { get; set; }
    }

    public class Location
    {
        public int LocationId { get; set; }

        public string Locations { get; set; }

        public int ProjectId { get; set; }

        public string CreatedBy { get; set; }
    }

    public class ProductionLineLeader
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

        public int ProdId { get; set; }
    }

    public class ProdModule
    {
        public int ModuleId { get; set; }

        public string Module { get; set; }

        public int ProjectId { get; set; }

        public List<DOL.Project> Projects { get; set; }
        public string CreatedBy { get; set; }

        public int BatchId { get; set; }

        public List<DOL.Batch> Batches { get; set; }

        public int ZoneId { get; set; }

        public List<DOL.Zone> Zones { get; set; }
    }

    public class ProdRiskPoints
    {
        public int ProjectId { get; set; }

        public List<DOL.Project> Projects { get; set; }

        public int BatchId { get; set; }

        public List<DOL.Batch> Batches { get; set; }

        public int ZoneId { get; set; }

        public List<DOL.Zone> Zones { get; set; }


        public string Points { get; set; }

        public string Dept { get; set; }


        public string CreatedBy { get; set; }

        public int RiskId { get; set; }

        public int ModuleId { get; set; }

        public List<ProdModule> ProdModules { get; set; }
    }


    public class ProcessTourData
    {
        public int ProjectId { get; set; }
        public List<Project> Projects { get; set; }
        public int StationId { get; set; }

        public List<Station> Stations { get; set; }
        public List<Visuals> Visualss { get; set; }

        public string InpectionProject { get; set; }
        public int VisualsId { get; set; }

        public string SNo { get; set; }

        public string InspectionSpecifaction { get; set; }
        public string SampleSize { get; set; }

        public string CreatedBy { get; set; }
    }

    public class A246CCTPMCStations
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

    public class A246CCTPMCParameter
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

    public class MasterMenuss
    {
        public int MenuId { get; set; }
        public string Menu { get; set; }
    }

    public class AllDataModlodelView
    {
        public int SectionId { get; set; }

        public string InspectionProject { get; set; }

        public int Section { get; set; }

        public int InspectionId { get; set; }

        public int ParameterId { get; set; }

        public string ParameterName { get; set; }

        public string MyProperty { get; set; }
    }
    public class A246CCTPMCParameterLimits
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

    public class NGApprovalFlow
    {
        public int MenuId { get; set; }
        public string ApproveId { get; set; }

        public int SectionId { get; set; }
        public string ApproveName { get; set; }

        public int TaskId { get; set; }

        public string Designation { get; set; }

        public string CreatedBy { get; set; }
    }

    public class A246CStationCTPOne
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

    public class A246CParameterCTPOne
    {
        public int ProjectId { get; set; }


        public string Parameter { get; set; }
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
    public class TeardownInspection
    {
        public int TearId { get; set; }

        public string Inspection { get; set; }

        public int ProjectId { get; set; }

        public string CreatedBy { get; set; }
    }

    public class Cable
    {
        public int CableId { get; set; }

        public string Cablee { get; set; }
    }

    public class InspectionType
    {
        public int InpectionId { get; set; }

        public string Inpection { get; set; }
    }
}
