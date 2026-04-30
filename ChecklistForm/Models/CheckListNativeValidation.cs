using DOL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ChecklistForm.Models
{
    public class CheckListNativeValidationModelView
    {
        public int LineId { get; set; }

        public List<Line> Lines { get; set; }

        public int ProjectId { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public int ShiftId { get; set; }

        public List<Shift> Shifts { get; set; }
        public List<Project> Projects { get; set; }

        public List<ModelNo> ModelNos { get; set; }
        public List<PartNo> PartNos { get; set; }
        public DataTable dtChecklist { get; set; }

        public CheckListNativeValidation[] CheckListNativeValidations {get;set;}

        public string LineNumber { get; set; }

        public string ProdLineLeader { get; set; }

        public string QualityLineLeader { get; set; }

        public string ProdShiftLeader { get; set; }

        public string QualityShiftLeader { get; set; }

        public string DocumentId { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string ModelNo { get; set; }
    }

    public class CheckListNativeValidation
    {
        public int ValidId { get; set; }

        public string GoodSample { get; set; }

        public string FailSample { get; set; }

        public string Result { get; set; }

       
    }

    public class A246CPartToInspectCheckList
    {
        public int InspectId { get; set; }

        public string InspectorName { get; set; }

        public string InspectorId { get; set; }

        public string ActualValue { get; set; }


    }

    public class CheckLisA246CPartToInspectModelView
    {
        public int LineId { get; set; }

        public List<Line> Lines { get; set; }

        public int ProjectId { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public int ShiftId { get; set; }

        public List<Shift> Shifts { get; set; }
        public List<Project> Projects { get; set; }

        public List<ModelNo> ModelNos { get; set; }
        public List<PartNo> PartNos { get; set; }
        public DataTable dtChecklist { get; set; }

        public A246CPartToInspectCheckList[] A246CPartToInspectCheckListResults { get; set; }

        public string LineNumber { get; set; }

        public string ProdLineLeader { get; set; }

        public string QualityLineLeader { get; set; }

        public string ProdShiftLeader { get; set; }

        public string QualityShiftLeader { get; set; }

        public string InspectId { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string ModelNo { get; set; }
    }

    public class CheckListWristStrapResult
    {
        public int StationId { get; set; }

        public string Spec { get; set; }

        public string Result { get; set; }

        public string EquipmentDescription { get; set; }

        public string EPA { get; set; }

        public string Environment { get; set; }

        public int ExpId { get; set; }

        public string Value { get; set; }
    }

    public class  CheckListWristStrapModelView
    {
        public int LineId { get; set; }

        public List<Line> Lines { get; set; }

        public int ProjectId { get; set; }
        public List<Project> Projects { get; set; }
        public DataTable dtChecklist { get; set; }

        public int ShiftId { get; set; }

        public List<Shift> Shifts { get; set; }



        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<PartNo> PartNos { get; set; }
        public int ExpId { get; set; }

        public List<Exponent> Exponents { get; set; }
        public CheckListWristStrapResult[] CheckListWristStrapResults { get; set; }

        public string LineNumber { get; set; }

        public string ProdLineLeader { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string CreatedBy { get; set; }
    }

    public class CheckListWorkSurfaceResult
    {
        public int StationId { get; set; }
        public string EquipmentDescription { get; set; }

        public string EPA { get; set; }

        public string Environment { get; set; }

        public decimal Value { get; set; }

        public int ExpId { get; set; }

        //public int ExpId { get; set; }
    }

    public class CheckListWorkSurfaceModelView
    {
        public int LineId { get; set; }

        public List<Line> Lines { get; set; }

        public int ProjectId { get; set; }
        public List<Project> Projects { get; set; }

        public int ExpId { get; set; }

        public List<Exponent> Exponents { get; set; }
        public DataTable dtChecklist { get; set; }

        public int ShiftId { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<PartNo> PartNos { get; set; }

        public CheckListWorkSurfaceResult[] CheckListWorkSurfaceResults { get; set; }

        public string LineNumber { get; set; }

        public string ProdLineLeader { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string ModelNo { get; set; }
        public string CreatedBy { get; set; }
    }

    public class CheckListEquipmentResult
    {
        public int StationId { get; set; }

        public decimal Spec { get; set; }

        public string Result { get; set; }

        public string EquipmentDescription { get; set; }
       
    }

    public class CheckListEquipmentModelView
    {
        public int LineId { get; set; }

        public List<Line> Lines { get; set; }

        public int ProjectId { get; set; }
        public List<Project> Projects { get; set; }
        public DataTable dtChecklist { get; set; }

        public int ShiftId { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ExpId { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<ModelNo> ModelNos { get; set; }
        public List<PartNo> PartNos { get; set; }
        public List<Exponent> Exponents { get; set; }
        public CheckListEquipmentResult[] CheckListEquipmentResults { get; set; }

        public string LineNumber { get; set; }

        public string ProdLineLeader { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string ModelNo { get; set; }

        public string CreatedBy { get; set; }
    }

    public class CheckListInspectionLightLuxResult
    {
        public int StationId { get; set; }

        public int Spec { get; set; }

        public string Result { get; set; }

        public string EquipmentDescription { get; set; }

        public string EPA { get; set; }

        public string Environment { get; set; }
    }
    public class CheckListInspectionLightLuxModelView
    {
        public int LineId { get; set; }

        public List<Line> Lines { get; set; }

        public int ProjectId { get; set; }
        public List<Project> Projects { get; set; }
        public DataTable dtChecklist { get; set; }

        public int ShiftId { get; set; }

        public List<Shift> Shifts { get; set; }

        public List<Exponent> Exponents { get; set; }

        public CheckListInspectionLightLuxResult[] CheckListInspectionLightLuxResults { get; set; }

        public string LineNumber { get; set; }

        public string ProdLineLeader { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string CreatedBy { get; set; }

        public string ModelNo { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<PartNo> PartNos { get; set; }
    }

    public class CheckListNonInspectionLightLuxResult
    {
        public int StationId { get; set; }

        public int Spec { get; set; }

        public string Result { get; set; }

        public string EquipmentDescription { get; set; }

        public string EPA { get; set; }

        public string Environment { get; set; }
    }

    public class CheckListNonInspectionLightLuxModelView
    {
        public int LineId { get; set; }

        public List<Line> Lines { get; set; }

        public int ProjectId { get; set; }
        public List<Project> Projects { get; set; }

        

        public List<Exponent> Exponents { get; set; }
        public DataTable dtChecklist { get; set; }

        public int ShiftId { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<PartNo> PartNos { get; set; }
        public CheckListNonInspectionLightLuxResult[] CheckListNonInspectionLightLuxResults { get; set; }

        public string LineNumber { get; set; }

        public string ProdLineLeader { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string CreatedBy { get; set; }

        public string ModelNo { get; set; }
    }

    public class CheckListQualityAuditResult
    {
        public int RiskId { get; set; }

        public int StatusId { get; set; }

        public string Sampling { get; set; }

        public string Namee { get; set; }

        public string Status { get; set; }

        public string Image { get; set; }

        //public string Environment { get; set; }

        //public int StatusId { get; set; }
    }

    public class CheckListQualityAuditModelView
    {
        public int RiskId { get; set; }
        public int LineId { get; set; }

        public List<Line> Lines { get; set; }

        public int StatusId { get; set; }
        public string Status { get; set; }

        public List<Result> Statuses { get; set; }
        public int ProjectId { get; set; }
        public List<Project> Projects { get; set; }
        public DataTable dtChecklist { get; set; }

        public int ShiftId { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<PartNo> PartNos { get; set; }
        public CheckListQualityAuditResult[] CheckListQualityAuditResults { get; set; }

        public string LineNumber { get; set; }

        public string ProdLineLeader { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string CreatedBy { get; set; }

        public string ModelNo { get; set; }
        public string Image { get; set; }
    }


    public class CheckListOBAResult
    {
        public int LocationId { get; set; }

        public int PlugId { get; set; }

        public int PlugShellId { get; set; }

        public int BootId { get; set; }

        public int BoottId { get; set; }

        public int FacePlateId { get; set; }

        public int FaceePlateId { get; set; }

        public int CollarId { get; set; }

        public string CableSerialNo { get; set; }

        public string BoxNo { get; set; }

        public string PalletNo { get; set; }

        public int CableId { get; set; }

        public int SRId { get; set; }

        public string Remark { get; set; }
    }

    public class CheckListOBAModelView
    {
        public int RiskId { get; set; }
        public int LineId { get; set; }


        public string BoxNo { get; set; }

        public string PalletNo { get; set; }
        public List<Line> Lines { get; set; }

        //public int StatusId { get; set; }
        //public string Status { get; set; }

        public List<DOL.SRS> SRes { get; set; }
        public int ProjectId { get; set; }
        public List<Project> Projects { get; set; }
        public DataTable dtChecklist { get; set; }

        public int ShiftId { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<PartNo> PartNos { get; set; }
        public CheckListOBAResult[] CheckListOBAResults { get; set; }

        public string LineNumber { get; set; }

        public string ProdLineLeader { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string CreatedBy { get; set; }

        public int LocationId { get; set; }

        public List<Location> Locations { get; set; }

        public int PlugId { get; set; }

        public List<PlugShellC70> PlugShelles { get; set; }

        public int PlugShellId { get; set; }

        public List<PlugShellC91> PlugShells { get; set; }

        public int BootId { get; set; }

        public List<BootC70> Boots { get; set; }

        public int BoottId { get; set; }

        public List<BootC91> Bootts { get; set; }

        public int FacePlateId { get; set; }

        public List<FacePlateC70> FacePlates { get; set; }

        public int FaceePlateId { get; set; }

        public List<FacePlateC91> FacePlatess { get; set; }

        public int CollarId { get; set; }

        public List<PaperCollar> PaperCollars { get; set; }


        public string Remark { get; set; }

        public int SRId { get; set; }

        public List<SRS> SRS { get; set; }

        public int CableId { get; set; }

        public List<Cable> Cables { get; set; }

        //public string Remark { get; set; }

        //public string ModelNo { get; set; }
        //public string Image { get; set; }
    }

    public class CheckListCosmeticResult
    {
        public int DefectId { get; set; }

        //public int LocationId { get; set; }

        public int Value { get; set; }

        //public string Result { get; set; }
    }

    public class CheckListCosmeticResultlView
    {
        public int DefectId { get; set; }

        public int LocationId { get; set; }

        public int LineId { get; set; }
        public List<Line> Lines { get; set; }

        public int ProjectId { get; set; }
        public List<Project> Projects { get; set; }
        public DataTable dtChecklist { get; set; }

        public int ShiftId { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<PartNo> PartNos { get; set; }
        public CheckListCosmeticResult[] CheckListCosmeticResults { get; set; }

        public string LineNumber { get; set; }

        public string ProdLineLeader { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string CreatedBy { get; set; }

        //public int LocationId { get; set; }

        public List<Location> Locations { get; set; }

        
    }


    public class CheckListCleanIssueResult
    {
        public int StageId { get; set; }

        //public int LocationId { get; set; }

        public int Value { get; set; }

        //public string Result { get; set; }
    }

    public class CheckListCleanIssueResultlView
    {
        public int DefectId { get; set; }

        public int LineId { get; set; }
        public List<Line> Lines { get; set; }

        public int ProjectId { get; set; }
        public List<Project> Projects { get; set; }
        public DataTable dtChecklist { get; set; }

        public int ShiftId { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<PartNo> PartNos { get; set; }
        public CheckListCleanIssueResult[] CheckListCleanIssueResults { get; set; }

        public string LineNumber { get; set; }

        public string ProdLineLeader { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string CreatedBy { get; set; }

        //public int LocationId { get; set; }

        


    }

    public class CheckListA191FinsihedProductResult
    {
        //public int TearId { get; set; }

        public int InspectId { get; set; }

        //public string MyProperty { get; set; }

        public string Result { get; set; }

        public string Remarks { get; set; }

        //public string Result { get; set; }
    }

    public class CheckListA191FinsihedProductResultlView
    {
        public int TearId { get; set; }

        public int InspectId { get; set; }

        public int LineId { get; set; }
        public List<Line> Lines { get; set; }

        public int ProjectId { get; set; }
        public List<Project> Projects { get; set; }
        public DataTable dtChecklist { get; set; }

        public int ShiftId { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<PartNo> PartNos { get; set; }
        public CheckListA191FinsihedProductResult[] CheckListA191FinsihedProductResults { get; set; }

        public string LineNumber { get; set; }

        public string ProdLineLeader { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string CreatedBy { get; set; }

        //public int LocationId { get; set; }




    }

    public class CheckListOQCBoxConformationResult
    {
        public string WorkOrder { get; set; }

        public string CartonBoxNumber { get; set; }

        public string NgQty { get; set; }

        public string DefectNg { get; set; }

        public string QcStatus { get; set; }

        public string Prodll { get; set; }

        public string qcll { get; set; }
    }

    public class CheckListOQCBoxConformationResultlView
    {
        public int LineId { get; set; }
        public List<Line> Lines { get; set; }

        public int ProjectId { get; set; }
        public List<Project> Projects { get; set; }
        public DataTable dtChecklist { get; set; }

        public int ShiftId { get; set; }

        public List<Shift> Shifts { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<PartNo> PartNos { get; set; }
        public CheckListOQCBoxConformationResult[] CheckListOQCBoxConformationResults { get; set; }

        public string LineNumber { get; set; }

        public string ProdLineLeader { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string CreatedBy { get; set; }

        //public int LocationId { get; set; }




    }

    public class CheckListFunctionalOOBTrackingResult
    {
        public string WorkOrder { get; set; }

        public string CartonBoxNumber { get; set; }


        public string Inpection { get; set; }
        public string DefectDescription { get; set; }

        public string NgQty { get; set; }

        public string CableSNo { get; set; }

        //public string QcStatus { get; set; }

        //public string Prodll { get; set; }

        //public string qcll { get; set; }
    }

    public class CheckListFunctionalOOBTrackingResultlView
    {
        public int LineId { get; set; }
        public List<Line> Lines { get; set; }

        public int ProjectId { get; set; }
        public List<Project> Projects { get; set; }
        public DataTable dtChecklist { get; set; }

        public int ShiftId { get; set; }

        public List<Shift> Shifts { get; set; }

        public List<InspectionType> Types { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<PartNo> PartNos { get; set; }
        public CheckListFunctionalOOBTrackingResult[] CheckListFunctionalOOBTrackingResults { get; set; }

        public string LineNumber { get; set; }

        public string ProdLineLeader { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string CreatedBy { get; set; }

        public string Prodll { get; set; }

        public string qcll { get; set; }
        //public int LocationId { get; set; }

        public string Inpection { get; set; }

    }


    public class CheckListAppTestFailureResult
    {
        public string Quantity { get; set; }

        public string DefectRate { get; set; }



        public string Reason { get; set; }

        public string Status { get; set; }

        public string Remark { get; set; }
    }

    public class CheckListAppTestFailureResultlModelView
    {
        public int LineId { get; set; }
        public List<Line> Lines { get; set; }

        //public int ProjectId { get; set; }
        //public List<Project> Projects { get; set; }
        public DataTable dtChecklist { get; set; }

        public int ShiftId { get; set; }

        public List<Shift> Shifts { get; set; }

        //public int ModelId { get; set; }

        //public int PartId { get; set; }

        //public List<ModelNo> ModelNos { get; set; }

        //public List<PartNo> PartNos { get; set; }
        public CheckListAppTestFailureResult[] CheckListAppTestFailureResults { get; set; }

        public string LineNumber { get; set; }

        public string ProdLineLeader { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string CreatedBy { get; set; }

        //public int LocationId { get; set; }




    }

    public class CheckListCartonBoxListResult
    {
        public string CartonNumber { get; set; }

        public string WorkOrder { get; set; }



        public string Status { get; set; }

        public string Remarks { get; set; }

        public string PackingSide { get; set; }
    }


    public class CheckListCartonBoxListResultModelView
    {
        public int LineId { get; set; }
        public List<Line> Lines { get; set; }

        //public int ProjectId { get; set; }
        //public List<Project> Projects { get; set; }
        public DataTable dtChecklist { get; set; }

        public int ShiftId { get; set; }

        public List<Shift> Shifts { get; set; }

        //public int ModelId { get; set; }

        //public int PartId { get; set; }

        //public List<ModelNo> ModelNos { get; set; }

        //public List<PartNo> PartNos { get; set; }
        public CheckListCartonBoxListResult[] CheckListCartonBoxListResults { get; set; }

        public string LineNumber { get; set; }

        public string ProdLineLeader { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string CreatedBy { get; set; }

        //public int LocationId { get; set; }




    }

    public class CheckListTemperatureRecordResult
    {
        public string TempId { get; set; }
        public decimal ActualValue { get; set; }
        
        
    }

    public class CheckListTemperatureRecordResulttModelView
    {

        public int ItemId { get; set; }
        public int LineId { get; set; }
        public List<Line> Lines { get; set; }

        //public int ProjectId { get; set; }
        //public List<Project> Projects { get; set; }
        public DataTable dtChecklist { get; set; }

        public int ShiftId { get; set; }

        public List<Shift> Shifts { get; set; }

        //public int ModelId { get; set; }

        //public int PartId { get; set; }

        //public List<ModelNo> ModelNos { get; set; }

        //public List<PartNo> PartNos { get; set; }
        public CheckListTemperatureRecordResult[] CheckListTemperatureRecordResults { get; set; }

        public string LineNumber { get; set; }

        public string ProdLineLeader { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string CreatedBy { get; set; }

        public string EquipmentSNo { get; set; }


        //public int LocationId { get; set; }




    }

    public class CheckListHumidityRecordResult
    {
        public string HumidityId { get; set; }
        public decimal ActualValue { get; set; }


    }

    public class CheckListHumidityRecordResultModelView
    {

        public int ItemId { get; set; }
        public int LineId { get; set; }
        public List<Line> Lines { get; set; }

        //public int ProjectId { get; set; }
        //public List<Project> Projects { get; set; }
        public DataTable dtChecklist { get; set; }

        public int ShiftId { get; set; }

        public List<Shift> Shifts { get; set; }

        //public int ModelId { get; set; }

        //public int PartId { get; set; }

        //public List<ModelNo> ModelNos { get; set; }

        //public List<PartNo> PartNos { get; set; }
        public CheckListHumidityRecordResult[] CheckListHumidityRecordResults { get; set; }

        public string LineNumber { get; set; }

        public string ProdLineLeader { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string CreatedBy { get; set; }

        public string EquipmentSNo { get; set; }

    }


    
}