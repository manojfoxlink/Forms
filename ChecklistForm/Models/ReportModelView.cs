using DOL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ChecklistForm.Models
{
    public class ReportModelView
    {
        public int ProjectId { get; set; }

        public int shiftId { get; set; }


        public int StationId { get; set; }

        public int SubStationId { get; set; }

        public int ParameterId { get; set; }

        public int LimitId { get; set; }

        public DataTable dtReports { get; set; }

        public List<Project> Projects { get; set; }

        public List<SubStation> SubStations { get; set; }

        public List<Station> Stations { get; set; }

        public List<Parameters> Parameters { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public decimal Actual { get; set; }

        public string Result { get; set; }
        public List<string> ExportTypes { get; set; }
        public string ExportType { get; set; }

        public int LineId { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }





    }

    public class CheckCircuitListRecordView
    {
        public int RecordId { get; set; }

        public int LineId { get; set; }

        public int ShiftId { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public string Result { get; set; }

        public string AdverseNumber { get; set; }

        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Project> Projects { get; set; }
        public int ProjectId { get; set; }
    }

    public class CheckListMaintenanceModelView
    {

        public int ProjectId { get; set; }

        public List<DOL.Project> Projects { get; set; }
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public int CatId { get; set; }

        public int ActivityId { get; set; }

        public int PartsId { get; set; }

        //public bool Result { get; set; }

        public string Result { get; set; }

        public string Remarks { get; set; }
        public int LineId { get; set; }

        public int ShiftId { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int MachineId { get; set; }

        public List<DOL.Machine> Machines { get; set; }
    }

    public class CheckPointsResultModelView
    {

        public int ProjectId { get; set; }

        public List<DOL.Project> Projects { get; set; }
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }
        public bool Result { get; set; }

        public int LineId { get; set; }

        public int ShiftId { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int MachineId { get; set; }

        public List<DOL.Machine> Machines { get; set; }

        //public int CheckId { get; set; }
    }

    public class CheckListParameterProcessTourDataModelView
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public int ProjectId { get; set; }


        public int VisualsId { get; set; }

        public List<Visuals> Visualss { get; set; }

        public List<Project> Projects { get; set; }
        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int LineId { get; set; }

        public int ShiftId { get; set; }

        public string Section1 { get; set; }

        public string Section2 { get; set; }

        public string Section3 { get; set; }

        public string Section4 { get; set; }

        public string Section5 { get; set; }

        public string DefectiveNumber { get; set; }


    }

    public class CheckListLaserGravingModelView
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int LineId { get; set; }

        public int ShiftId { get; set; }

        public string Result { get; set; }

        public string Locations { get; set; }
        public string Specification { get; set; }
        public float Minimum { get; set; }
        public float Maximum { get; set; }
        //public int Id  { get; set; }
        public decimal Sno1 { get; set; }

        public decimal Sno2 { get; set; }

        public decimal Sno3 { get; set; }

        public decimal Sno4 { get; set; }
        public decimal Sno5 { get; set; }
        public decimal Sno6 { get; set; }

        public string SerialNo1 { get; set; }
        public string SerialNo2 { get; set; }
        public string SerialNo3 { get; set; }
        public string SerialNo4 { get; set; }
        public string SerialNo5 { get; set; }
        public string SerialNo6 { get; set; }

    }

    public class CheckListParameterNativeValidModelView
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }


        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }

        public int ShiftId { get; set; }

        public string Result { get; set; }

        public int ValidId { get; set; }

        public string GoodSample { get; set; }

        public string FailSample { get; set; }


    }

    public class CheckListParameterOutGoingInspectionModelView
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }


        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }

        public int ShiftId { get; set; }

        public string Result { get; set; }

        public string TrackNumber { get; set; }


    }

    public class CheckListParameterLineAuditCheckPoints
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }

        //public int ShiftId { get; set; }

        public int CheckId { get; set; }

        public string Status { get; set; }

        public string Image { get; set; }

        // public string MyProperty { get; set; }

    }

    public class CheckListParameterCircuitBoardRecord
    {

        public int ProcessTourId { get; set; }

        public List<DOL.ProcessTourss> ProcessTourss { get; set; }
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }

        //public int ShiftId { get; set; }

        public int SpecId { get; set; }

        public Decimal Value1 { get; set; }

        public Decimal Value2 { get; set; }

        public Decimal Value3 { get; set; }

        public Decimal Value4 { get; set; }

        public Decimal Value5 { get; set; }

        public string Image { get; set; }

        public string Result { get; set; }

        // public string MyProperty { get; set; }

    }

    public class CheckListParameterXBarChart
    {

        public string Email { get; set; }
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }

        //public int ShiftId { get; set; }

        public int AdhesiveId { get; set; }

        public List<Adhesivee> Adhesives { get; set; }

        public int SpecId { get; set; }

        public Decimal DataValue { get; set; }


        public string RootCause { get; set; }

        public string Adhesive { get; set; }

        public string CreatedBy { get; set; }

        public string FeedBack { get; set; }

        public int ResultId { get; set; }

    }

    public class CheckListParameterTempratureRange
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }

        //public int ShiftId { get; set; }

        public int TempId { get; set; }

        public List<TempRange> Ranges { get; set; }

        //public int SpecId { get; set; }

        public Decimal Value { get; set; }


        public string Determine { get; set; }

        // public string MyProperty { get; set; }

    }

    
    public class CheckListDestructiveTestRecordModelView
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }

        public decimal Min { get; set; }

        public decimal Max { get; set; }

        public decimal StandardDev { get; set; }
        public decimal Average { get; set; }
        public decimal CPK { get; set; }

        public string CreatedBy { get; set; }

        //public string CreatedBy { get; set; }

    }

    public class CheckListParameterCTQManPowerModelView
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }

        //public int ShiftId { get; set; }

        public int InspectionId { get; set; }

        public string InspectorName { get; set; }

        public string InspectorId { get; set; }

        public bool Result { get; set; }

        public string Results { get; set; }

    }

    public class CheckListParameterTrapTestModelView
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }
        public int ProjectId { get; set; }

        public int LineId { get; set; }
        public List<Project> Projects { get; set; }

        public int InspectId { get; set; }

        public int DetailsId { get; set; }

        public int InspecId { get; set; }

        public string InspectorName { get; set; }

        public string NoOfCables { get; set; }

        public string CheckResult { get; set; }

        public string InspectorId { get; set; }

        public string CheckResults { get; set; }


    }

    public class ParameterWristStrapModelView
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }

        public string Spec { get; set; }

        public string Result { get; set; }

        public string EquipmentDescription { get; set; }
        public string EPA { get; set; }
        public string Environment { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }

    }

    public class ParameterA246CWristStrapModelView
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }


        public string StationNo { get; set; }
        public string Result { get; set; }

        public string Description { get; set; }
       

        public string CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }

    }

    public class ParameterCheckListEquipmentModelView
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }


        public string StationNo { get; set; }
        public string Result { get; set; }

        public string Description { get; set; }


        public string CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }

    }

    public class ParameterA246CPartToInspectCheckListModelView
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }


        public string SNo { get; set; }
        public string PartToInspect { get; set; }

        public string InspectorName { get; set; }

        public string InspectorId { get; set; }

        public string ActualValue { get; set; }


        public string CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }

    }


    public class ParameterWorkSurfaceModelView
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }

        public string Spec { get; set; }

        public string Result { get; set; }

        public string EquipmentDescription { get; set; }
        public string EPA { get; set; }
        public string Environment { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }

    }

    public class ParameterEquipmentModelView
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }

        public string Spec { get; set; }

        public string Result { get; set; }

        public string EquipmentDescription { get; set; }
        public string EPA { get; set; }
        public string Environment { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }

    }

    public class ParameterInspectionLightLuxModelView
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }

        public string Spec { get; set; }

        public string Result { get; set; }

        public string EquipmentDescription { get; set; }
        public string EPA { get; set; }
        public string Environment { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }

    }

    public class ParameterNonInspectionLighModeltLuxView
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }

        public string Spec { get; set; }

        public string Result { get; set; }

        public string EquipmentDescription { get; set; }
        public string EPA { get; set; }
        public string Environment { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }

    }

    public class ParameterQualityAuditModelView
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }

        //public string Spec { get; set; }

        //public string Result { get; set; }
        public string ProcessNo { get; set; }
        public string Module { get; set; }
        public string Points { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }

    }

    public class ParameteOBAModelView
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }

        //public string Spec { get; set; }

        //public string Result { get; set; }
        public string Cablee { get; set; }
        public string SR { get; set; }
        public string PlugShelll { get; set; }

        public string PlugShell { get; set; }

        public string Boott { get; set; }

        public string Boot { get; set; }

        public string FacePlate { get; set; }

        public string Collar { get; set; }
        public string CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string Remark { get; set; }

    }


    public class ParameteCosmeticStudyModelView
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }


        public string Defect { get; set; }
        public string Locations { get; set; }
        public string Value { get; set; }


        public string CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }

    }


    public class ParameteOQCBoxConformationModelView
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }


        public string WorkOrder { get; set; }
        public string CartonBoxNumber { get; set; }
        public string NgQty { get; set; }

        public string DefectNg { get; set; }

        public string QcStatus { get; set; }

        public string Prodll { get; set; }

        public string qcll { get; set; }
        public string CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }

    }


    public class ParameterFunctionalOOBTrackingModelView
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }


        public string WorkOrder { get; set; }
        public string CartonBoxNumber { get; set; }

        public string CableSNo { get; set; }
        public string NgQty { get; set; }

        public string DefectDescription { get; set; }

        //public string QcStatus { get; set; }

        public string Prodll { get; set; }

        public string qcll { get; set; }
        public string CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }

    }


    public class ParameterAppTestFailureModelView
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }
        //public int ProjectId { get; set; }

        //public List<Project> Projects { get; set; }
        public int LineId { get; set; }


        public string Quantity { get; set; }
        public string DefectRate { get; set; }

        public string Reason { get; set; }
        public string Status { get; set; }

        public string Remark { get; set; }

        //public string QcStatus { get; set; }

        //public string Prodll { get; set; }

        //public string qcll { get; set; }
        public string CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }

    }


    public class ParameterCartonBoxListModelView
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }
        //public int ProjectId { get; set; }

        //public List<Project> Projects { get; set; }
        public int LineId { get; set; }


        public string CartonNumber { get; set; }
        public string WorkOrder { get; set; }

        public string Status { get; set; }
        public string Remarks { get; set; }

        public string PackingSide { get; set; }

        //public string QcStatus { get; set; }

        //public string Prodll { get; set; }

        //public string qcll { get; set; }
        public string CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }

    }


    public class ParameterTempratureRecordModelView
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }
        //public int ProjectId { get; set; }

        //public List<Project> Projects { get; set; }
        public int LineId { get; set; }


        public string Items { get; set; }
        public string Temperatures { get; set; }

        public decimal ActualValue { get; set; }

        //public string Status { get; set; }
        //public string Remarks { get; set; }

        //public string PackingSide { get; set; }

        //public string QcStatus { get; set; }

        //public string Prodll { get; set; }

        //public string qcll { get; set; }
        public string CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }

    }


    public class ParameterHumidityRecordModelView
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }
        //public int ProjectId { get; set; }

        //public List<Project> Projects { get; set; }
        public int LineId { get; set; }


        public string Items { get; set; }
        public string Humidities { get; set; }

        public decimal ActualValue { get; set; }

        //public string Status { get; set; }
        //public string Remarks { get; set; }

        //public string PackingSide { get; set; }

        //public string QcStatus { get; set; }

        //public string Prodll { get; set; }

        //public string qcll { get; set; }
        public string CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }

    }


    public class ParameterA191FinsihedProductModelView
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }
        //public int ProjectId { get; set; }

        //public List<Project> Projects { get; set; }
        public int LineId { get; set; }

        public string Inspection { get; set; }

        public string TeardownSteps { get; set; }

        public string Sno { get; set; }
        public string Items { get; set; }
        public string Result { get; set; }

        public string Remarks { get; set; }

        public int InspectId { get; set; }

        //public string Status { get; set; }
        //public string Remarks { get; set; }

        //public string PackingSide { get; set; }

        //public string QcStatus { get; set; }

        //public string Prodll { get; set; }

        //public string qcll { get; set; }
        public string CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }



    }


    public class ParameterCleaningIssueModelView
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }

        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }

        //public string Inspection { get; set; }

        //public string TeardownSteps { get; set; }
        public string Stagee { get; set; }


        public string CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }

        //public int ProjectId { get; set; }

        //public List<Project> Projects { get; set; }



    }

    public class FirstAirticleInspecModelView
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }

        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }

        //public string Inspection { get; set; }

        //public string TeardownSteps { get; set; }
        public string Specification { get; set; }

        public decimal Check1 { get; set; }

        public decimal Check2 { get; set; }
        public decimal Check3 { get; set; }
        public decimal Check4 { get; set; }
        public decimal Check5 { get; set; }
        public string CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }

        //public int ProjectId { get; set; }

        //public List<Project> Projects { get; set; }



    }

    public class FirstAirticleInspectionModelView
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }

        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }

        //public string Inspection { get; set; }

        //public string TeardownSteps { get; set; }
        public string Result { get; set; }

        public string RejectDescribe { get; set; }

        public string CreatedBy { get; set; }

        public string StationName { get; set; }

        public string ItemName { get; set; }


        public DateTime CreatedDateTime { get; set; }

        //public int ProjectId { get; set; }

        //public List<Project> Projects { get; set; }



    }

    public class RptA246CCMMC1CheckListModelView
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }

        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }

        public int MachineId { get; set; }

        public List<A246CMachines> Machines { get; set; }
        public decimal Value1 { get; set; }

        public decimal Value2 { get; set; }

        public decimal Value3 { get; set; }
        public decimal Value4 { get; set; }


        public decimal Value5 { get; set; }

        public string InspectionResults { get; set; }

        

       
    }

    public class RptParameterA246CWCMMC1CheckList
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }

        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }

        public int MachineId { get; set; }

        public List<A246CMachines> Machines { get; set; }
        public decimal Value1 { get; set; }

        public decimal Value2 { get; set; }

        public decimal Value3 { get; set; }
        public decimal Value4 { get; set; }


        public decimal Value5 { get; set; }

        public string InspectionResults { get; set; }

        public string CablesSerialNumber { get; set; }




    }
    /// <summary>
    /// 
    /// </summary>
    public class RptParameterA246CShellCrimpMC1CheckList
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }

        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }

        public int MachineId { get; set; }

        public List<A246CMachines> Machines { get; set; }
        public decimal Value1 { get; set; }

       

        public string InspectionResults { get; set; }

        public string CablesSerialNumber { get; set; }




    }

    public class RptParameterA246CInnerMoldMCCheckList
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }

        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }

        public int MachineId { get; set; }

        public List<A246CMachines> Machines { get; set; }
        public decimal Value1 { get; set; }



        public string InspectionResults { get; set; }

        public string CablesSerialNumber { get; set; }




    }

    public class RptParameterA246CBAndFCheckList
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }

        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }

        public int MachineId { get; set; }

        public List<A246CMachines> Machines { get; set; }
        public decimal Value1 { get; set; }



        public string InspectionResults { get; set; }

       // public string CablesSerialNumber { get; set; }




    }

    public class RptParameterA246CAOIDataCheckList
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }

        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }

        public int MachineId { get; set; }

        public List<A246CMachines> Machines { get; set; }
        public decimal Value1 { get; set; }

        public decimal Value2 { get; set; }
        public decimal Value3 { get; set; }
        public decimal Value4 { get; set; }
        public decimal Value5 { get; set; }




        public string InspectionResults { get; set; }

        // public string CablesSerialNumber { get; set; }




    }

    public class RptParameterA246CHankingCheckList
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }

        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }

        public int MachineId { get; set; }

        public List<A246CMachines> Machines { get; set; }
        public decimal Value1 { get; set; }

        public decimal Value2 { get; set; }
        public decimal Value3 { get; set; }
        public decimal Value4 { get; set; }
        public decimal Value5 { get; set; }




        public string InspectionResults { get; set; }

        // public string CablesSerialNumber { get; set; }




    }

    public class RptParameterA246CLaserEngraving
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }

        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }

       
        public decimal Value1 { get; set; }

        public decimal Value2 { get; set; }
        public decimal Value3 { get; set; }
        public decimal Value4 { get; set; }
        public decimal Value5 { get; set; }




        public string SerialNumber1 { get; set; }

        public string SerialNumber2 { get; set; }
        public string SerialNumber3 { get; set; }
        public string SerialNumber4 { get; set; }
        public string SerialNumber5 { get; set; }

        // public string CablesSerialNumber { get; set; }




    }

    public class RptParameterA246CMHB1CheckList
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }

        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }

        public int MachineId { get; set; }

        public List<A246CMachines> Machines { get; set; }
        public decimal Value1 { get; set; }

        public decimal Value2 { get; set; }

        public decimal Value3 { get; set; }
        public decimal Value4 { get; set; }


        public decimal Value5 { get; set; }

        public string InspectionResults { get; set; }

        public string CablesSerialNumber { get; set; }




    }

    public class RptParameterA246CMHB2CheckList
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }

        public int ProjectId { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<PartNo> PartNos { get; set; }

        public List<Project> Projects { get; set; }

        public int LineId { get; set; }

        public int MachineId { get; set; }

        public List<A246CMachines> Machines { get; set; }
        public decimal Value1 { get; set; }

        public decimal Value2 { get; set; }

        public decimal Value3 { get; set; }
        public decimal Value4 { get; set; }


        public decimal Value5 { get; set; }

        public string InspectionResults { get; set; }

        public string CablesSerialNumber { get; set; }




    }


    public class ParameterProdQualityAuditModelView
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

      //  public List<Shift> Shifts { get; set; }

        //public int ShiftId { get; set; }
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }

        public int ShiftId { get; set; }

        public List<Shift> Shifts { get; set; }
        public int BatchId { get; set; }

        public List<Batch> Batches { get; set; }

        public int ZoneId { get; set; }
        public List<Zone> Zones { get; set; }

        public int ModuleId { get; set; }

        public List<ProdModule> ProdModules { get; set; }

        public int ProdId { get; set; }

        public List<ProductionLineLeader> ProductionLineLeaders { get; set; }
        public string Module { get; set; }

        public string Status { get; set; }


        public string Namee { get; set; }

        public string Image { get; set; }


        public decimal total { get; set; }
        
    }

    public class RptParameterA246CTParameterMCChecklistLine1ModelView
    {
        public DataTable dtReports { get; set; }

        public string Station { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }

        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }

        public List<Line> Lines { get; set; }

        public int MachineId { get; set; }

        public List<A246CMachines> Machines { get; set; }

        public int StationNo { get; set; }

        public string EquipmentModel { get; set; }

        public string Parameter { get; set; }

        public string unit { get; set; }

        public decimal LSL { get; set; }
        public decimal USL { get; set; }

        public decimal Value { get; set; }

        public string Result { get; set; }

    }

    public class PagedReportsViewModel
    {
        public List<RptParameterA246CTPaameterMCChecklistModelView> Reports { get; set; } // The list of reports for the current page
        public int TotalRecords { get; set; } // Total records in the database
        public int PageNumber { get; set; } // Current page number
        public int PageSize { get; set; } // Number of records per page
    }

    public class Reports
    {
        public int StationNo { get; set; }
        public string Station { get; set; }
        public string EquipmentModel { get; set; }
        public string Parameter { get; set; }
        public string Unit { get; set; }
        public decimal LSL { get; set; }
        public decimal USL { get; set; }
        public decimal Value { get; set; }


    }

    public class RptParameterA246CTPaameterMCChecklistModelView
    {
        //public DataTable db { get; set; }

        public string Station { get; set; }

        //public string Unit { get; set; }
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }

        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }

        public List<Line> Lines { get; set; }

        public int MachineId { get; set; }

        public List<A246CMachines> Machines { get; set; }

        public int StationNo { get; set; }

        public string EquipmentModel { get; set; }

        public string Parameter { get; set; }

        public string unit { get; set; }

        public decimal LSL { get; set; }
        public decimal USL { get; set; }

        public decimal Value { get; set; }

        public string Result { get; set; }

    }

    public class RptParameterA246CDestructiveMachineModelView
    {
        public DataTable dtReports { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public List<string> ExportTypes { get; set; }

        public string ExportType { get; set; }

        public List<Line> Lines { get; set; }

        public List<A246COKNG> OKNG { get; set; }

        public int Id { get; set; }
        public List<Shift> Shifts { get; set; }

        public int ShiftId { get; set; }

        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int LineId { get; set; }

        public int MachineId { get; set; }

        public List<A246CMachines> Machines { get; set; }
        public decimal Value { get; set; }

        public decimal Value2 { get; set; }

        public decimal Value3 { get; set; }
        public decimal Value4 { get; set; }


        public decimal Value5 { get; set; }

        public string InspectionResults { get; set; }

        public string CablesSerialNumber { get; set; }




    }

}
