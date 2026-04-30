using System;
using System.Collections.Generic;
using System.Data;
//using System;
//using DOL;
//using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DOL;

namespace ChecklistForm.Models
{
    public class CheckListResultsViewModel
    {

        public DataTable dtChecklist { get; set; }

        public int ProjectId { get; set; }
        public CheckListResult[] CheckListResults { get; set; }

        public int LineId { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public List<Project> Projects { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<PartNo> PartNos { get; set; }
        public int ShiftId { get; set; }

        public int ApprovalId { get; set; }

        public string ProdLineLeader { get; set; }

        //public string ModelNo { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

    }
    public class CheckListResult
    {
        //public int ProjectId { get; set; }

        //public int StationId { get; set; }

        //public int SubStationId { get; set; }

         public int ParameterId { get; set; }
         public int ApprovalId { get; set; }
        public int LimitId { get; set; }

        //public decimal? LowerLimit { get; set; }

        //public decimal? UpperLimit { get; set; }
        public decimal Actual { get; set; }

        //public string Result { get; set; }

        public string CreatedBy { get; set; }

        public string ProdLineLeader { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }
    }

    public class A246CCMMC1CheckList
    {
        public int ResultId { get; set; }

        public string RootCause { get; set; }

        public string PreventiveAction { get; set; }

        public string CorrectiveAction { get; set; }
        public int ProjectId { get; set; }

        public int InspectionId { get; set; }

        public int SectionId { get; set; }

        public int LineId { get; set; }

        public int ShiftId { get; set; }


        public int ApprovalId { get; set; }

        public decimal Value1 { get; set; }
        public decimal Value2 { get; set; }
        public decimal Value3 { get; set; }
        public decimal Value4 { get; set; }
        public decimal Value5 { get; set; }

        public string InspectionResults { get; set; }

        public string MachineNo { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

    }

    public class A246CCMMC1CheckListModelView
    {
        public DataTable dtChecklist { get; set; }

        public int SectionId { get; set; }

        public int MachineId { get; set; }
        public A246CCMMC1CheckList[] A246CCMMC1CheckListResults { get; set; }

        public int LineId { get; set; }

        public int ProjectId { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public List<Project> Projects { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<A246CMachines> Machines { get; set; }

        public List<PartNo> PartNos { get; set; }
        public int ShiftId { get; set; }

        public int ApprovalId { get; set; }

        public string ProdLineLeader { get; set; }

        //public string ModelNo { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string MachineNo { get; set; }
    }



    ///

    public class A246CWCMMCCheckList
    {

        public int ResultId { get; set; }

        public string RootCause { get; set; }

        public string PreventiveAction { get; set; }

        public string CorrectiveAction { get; set; }
        public int ProjectId { get; set; }

        public int InspectionId { get; set; }

        public int SectionId { get; set; }

        public int LineId { get; set; }

        public int ShiftId { get; set; }


        public int ApprovalId { get; set; }

        public decimal Value1 { get; set; }
        public decimal Value2 { get; set; }
        public decimal Value3 { get; set; }
        public decimal Value4 { get; set; }
        public decimal Value5 { get; set; }

        public string InspectionResults { get; set; }

        public string CablesSerialNumber { get; set; }

        public string MachineNo { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

    }

    public class A246CWCMMCCheckListModelView
    {
        public DataTable dtChecklist { get; set; }

        public int SectionId { get; set; }

        public int MachineId { get; set; }
        public A246CWCMMCCheckList[] A246CWCMMCCheckListResults { get; set; }

        public int LineId { get; set; }

        public int ProjectId { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public List<Project> Projects { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<A246CMachines> Machines { get; set; }

        public List<PartNo> PartNos { get; set; }
        public int ShiftId { get; set; }

        public int ApprovalId { get; set; }

        public string ProdLineLeader { get; set; }

        //public string ModelNo { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string MachineNo { get; set; }
    }


    
    public class A246CShellCrimpMC1CheckList
    {
        public int ResultId { get; set; }

        public string RootCause { get; set; }
        public string PreventiveAction { get; set; }
        public string CorrectiveAction { get; set; }
        public int ProjectId { get; set; }

        public int InspectionId { get; set; }

        public int SectionId { get; set; }

        public int LineId { get; set; }

        public int ShiftId { get; set; }


        public int ApprovalId { get; set; }

        public decimal Value1 { get; set; }

        public decimal Value2 { get; set; }

        public decimal Value3 { get; set; }

        public decimal Value4 { get; set; }

        public decimal Value5 { get; set; }
        public string InspectionResults { get; set; }

        public string CablesSerialNumber { get; set; }

       // public string MachineNo { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

    }
    public class A246CShellCrimpMC1CheckListModelView
    {
        public DataTable dtChecklist { get; set; }

        public int SectionId { get; set; }

        public int MachineId { get; set; }
        public A246CShellCrimpMC1CheckList[] A246CShellCrimpMC1CheckListResults { get; set; }

        public int LineId { get; set; }

        public int ProjectId { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public List<Project> Projects { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<A246CMachines> Machines { get; set; }

        public List<PartNo> PartNos { get; set; }
        public int ShiftId { get; set; }

        public int ApprovalId { get; set; }

        public string ProdLineLeader { get; set; }

        //public string ModelNo { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string MachineNo { get; set; }
    }

    public class A246CInnerMoldMCDataCheckList
    {
        public int ResultId { get; set; }

        public string RootCause { get; set; }

        public string PreventiveAction { get; set; }

        public String CorrectiveAction { get; set; }


        public int ProjectId { get; set; }

        public int InspectionId { get; set; }

        public int SectionId { get; set; }

        public int LineId { get; set; }

        public int ShiftId { get; set; }


        public int ApprovalId { get; set; }

        public decimal Value1 { get; set; }

        //public decimal Value1 { get; set; }
        public decimal Value2 { get; set; }
        public decimal Value3 { get; set; }
        public decimal Value4 { get; set; }

        public decimal Value5 { get; set; }
        public string InspectionResults { get; set; }

        public string CablesSerialNumber { get; set; }

        // public string MachineNo { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

    }

    public class A246CInnerMoldMCDataCheckListModelView
    {
        public DataTable dtChecklist { get; set; }

        public int SectionId { get; set; }

        public int MachineId { get; set; }
        public A246CInnerMoldMCDataCheckList[] A246CInnerMoldMCDataCheckListResults { get; set; }

        public int LineId { get; set; }

        public int ProjectId { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public List<Project> Projects { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<A246CMachines> Machines { get; set; }

        public List<PartNo> PartNos { get; set; }
        public int ShiftId { get; set; }

        public int ApprovalId { get; set; }

        public string ProdLineLeader { get; set; }

        //public string ModelNo { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string MachineNo { get; set; }
    }


    
    public class A246CMHB1CheckList
    {
        public int ProjectId { get; set; }

        public int InspectionId { get; set; }

        public int SectionId { get; set; }


        public int ResultId { get; set; }

        public string RootCause { get; set; }

        public string PreventiveAction { get; set; }

        public string CorrectiveAction { get; set; }
        public int LineId { get; set; }

        public int ShiftId { get; set; }


        public int ApprovalId { get; set; }

        public decimal Value1 { get; set; }
        public decimal Value2 { get; set; }
        public decimal Value3 { get; set; }
        public decimal Value4 { get; set; }
        public decimal Value5 { get; set; }

        public string InspectionResults { get; set; }

        public string CablesSerialNumber { get; set; }

        public string MachineNo { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

    }

    public class A246CMHB1CheckListModelView
    {
        public DataTable dtChecklist { get; set; }

        public int SectionId { get; set; }

        public int MachineId { get; set; }
        public A246CMHB1CheckList[] A246CMHB1CheckListResults { get; set; }

        public int LineId { get; set; }

        public int ProjectId { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public List<Project> Projects { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<A246CMachines> Machines { get; set; }

        public List<PartNo> PartNos { get; set; }
        public int ShiftId { get; set; }

        public int ApprovalId { get; set; }

        public string ProdLineLeader { get; set; }

        //public string ModelNo { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string MachineNo { get; set; }
    }

    public class A246CMHB2CheckList
    {
        public int ProjectId { get; set; }

        public int InspectionId { get; set; }

        public int SectionId { get; set; }

        public int LineId { get; set; }

        public int ShiftId { get; set; }


        public int ApprovalId { get; set; }

        public decimal Value1 { get; set; }
        public decimal Value2 { get; set; }
        //public decimal Value3 { get; set; }
        //public decimal Value4 { get; set; }
        //public decimal Value5 { get; set; }

        public string InspectionResults { get; set; }

        //public string CablesSerialNumber { get; set; }

        public string MachineNo { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

    }

    public class A246CMHB2CheckListModelView
    {
        public DataTable dtChecklist { get; set; }

        public int SectionId { get; set; }

        public int MachineId { get; set; }
        public A246CMHB2CheckList[] A246CMHB2CheckListResults { get; set; }

        public int LineId { get; set; }

        public int ProjectId { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public List<Project> Projects { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<A246CMachines> Machines { get; set; }

        public List<PartNo> PartNos { get; set; }
        public int ShiftId { get; set; }

        public int ApprovalId { get; set; }

        public string ProdLineLeader { get; set; }

        //public string ModelNo { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string MachineNo { get; set; }
    }

    public class A246CBAndFDataCheckList
    {
        public int ProjectId { get; set; }

        public int InspectionId { get; set; }

        public int SectionId { get; set; }

        public int LineId { get; set; }

        public int ShiftId { get; set; }


        public int ApprovalId { get; set; }

        public decimal Value1 { get; set; }

  
        public string InspectionResults { get; set; }

   
        public int ModelId { get; set; }

        public int PartId { get; set; }

    }

    public class A246CBAndFDataCheckListModelView
    {
        public DataTable dtChecklist { get; set; }

        public int SectionId { get; set; }

        public int MachineId { get; set; }
        public A246CBAndFDataCheckList[] A246CBAndFDataCheckListResults { get; set; }

        public int LineId { get; set; }

        public int ProjectId { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public List<Project> Projects { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<A246CMachines> Machines { get; set; }

        public List<PartNo> PartNos { get; set; }
        public int ShiftId { get; set; }

        public int ApprovalId { get; set; }

        public string ProdLineLeader { get; set; }

        //public string ModelNo { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string MachineNo { get; set; }
    }

    public class A246CAOICheckList
    {
        public int ResultId { get; set; }

        public string RootCause { get; set; }

        public string PreventiveAction { get; set; }

        public string CorrectiveAction { get; set; }
        public int ProjectId { get; set; }

        public int InspectionId { get; set; }

        public int SectionId { get; set; }

        public int LineId { get; set; }

        public int ShiftId { get; set; }


        public int ApprovalId { get; set; }

        public decimal Value1 { get; set; }

        //public decimal Value1 { get; set; }
        public decimal Value2 { get; set; }
        public decimal Value3 { get; set; }
        public decimal Value4 { get; set; }

        public decimal Value5 { get; set; }
        public string InspectionResults { get; set; }

        public string CablesSerialNumber { get; set; }

        // public string MachineNo { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

    }

    public class A246CAOICheckListModelView
    {
        public DataTable dtChecklist { get; set; }

        public int SectionId { get; set; }

        public int MachineId { get; set; }
        public A246CAOICheckList[] A246CAOICheckListResults { get; set; }

        public int LineId { get; set; }

        public int ProjectId { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public List<Project> Projects { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<A246CMachines> Machines { get; set; }

        public List<PartNo> PartNos { get; set; }
        public int ShiftId { get; set; }

        public int ApprovalId { get; set; }

        public string ProdLineLeader { get; set; }

        //public string ModelNo { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string MachineNo { get; set; }
    }

    public class A246CHankingCheckList
    {
        public int ResultId { get; set; }
        public string RootCause { get; set; }

        public string PreventiveAction { get; set; }

        public string CorrectiveAction { get; set; }
        public DataTable dtChecklist { get; set; }
        public int ProjectId { get; set; }

        public int InspectionId { get; set; }

        public int SectionId { get; set; }

        public int LineId { get; set; }

        public int ShiftId { get; set; }


        public int ApprovalId { get; set; }

        public decimal Value1 { get; set; }

        //public decimal Value1 { get; set; }
        public decimal Value2 { get; set; }
        public decimal Value3 { get; set; }
        public decimal Value4 { get; set; }

        public decimal Value5 { get; set; }
        public string InspectionResults { get; set; }

        //public string CablesSerialNumber { get; set; }

        // public string MachineNo { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

    }

    public class A246CHankingCheckListModelView
    {
        public DataTable dtChecklist { get; set; }

        public int SectionId { get; set; }

        public int MachineId { get; set; }
        public A246CHankingCheckList[] A246CHankingCheckListResults { get; set; }

        public int LineId { get; set; }

        public int ProjectId { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public List<Project> Projects { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<A246CMachines> Machines { get; set; }

        public List<PartNo> PartNos { get; set; }
        public int ShiftId { get; set; }

        public int ApprovalId { get; set; }

        public string ProdLineLeader { get; set; }

        //public string ModelNo { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

       // public string MachineNo { get; set; }
    }

    public class A246CLaserEngravingCheckList
    {
        public int LocationId { get; set; }

       

        public int LineId { get; set; }

        public int ShiftId { get; set; }


        public int ApprovalId { get; set; }

        public decimal Value1 { get; set; }

        public string SerialNumber1 { get; set; }
        public decimal Value2 { get; set; }

        public string SerialNumber2 { get; set; }
        public decimal Value3 { get; set; }

        public string SerialNumber3 { get; set; }
        public decimal Value4 { get; set; }

        public string SerialNumber4 { get; set; }
        public decimal Value5 { get; set; }

        public string SerialNumber5 { get; set; }
        public int ModelId { get; set; }

        public int PartId { get; set; }

    }

    public class A246CLaserEngravingCheckListModelView
    {
        public DataTable dtChecklist { get; set; }

        public int LocationId { get; set; }

        
        public A246CLaserEngravingCheckList[] A246CLaserEngravingCheckListResults { get; set; }

        public int LineId { get; set; }

        public int ProjectId { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public List<Project> Projects { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<PartNo> PartNos { get; set; }
        public int ShiftId { get; set; }

        public int ApprovalId { get; set; }

        public string ProdLineLeader { get; set; }

        //public string ModelNo { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        // public string MachineNo { get; set; }
    }

    public class A246CCheckListWristStrap
    {
        public int StationId { get; set; }


        public string StationNo { get; set; }

        public string Station { get; set; }
        public int LineId { get; set; }

        public int ShiftId { get; set; }


        public int ApprovalId { get; set; }

        public decimal Value { get; set; }

        
        public int ModelId { get; set; }

        public int PartId { get; set; }

    }

    public class A246CCheckListWristStrapModelView
    {
        public DataTable dtChecklist { get; set; }

        public int StationId { get; set; }


        public A246CCheckListWristStrap[] A246CCheckListWristStrapResults { get; set; }

        public int LineId { get; set; }

        public int ProjectId { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public List<Project> Projects { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<PartNo> PartNos { get; set; }
        public int ShiftId { get; set; }

        public int ApprovalId { get; set; }

        public string ProdLineLeader { get; set; }

        //public string ModelNo { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        // public string MachineNo { get; set; }
    }

    public class A246CEquipmentCheckList
    {
        public int StationId { get; set; }


        public string StationNo { get; set; }

        public string Station { get; set; }
        public int LineId { get; set; }

        public int ShiftId { get; set; }


        public int ApprovalId { get; set; }

        public decimal Value { get; set; }


        public int ModelId { get; set; }

        public int PartId { get; set; }

    }

    public class A246CEquipmentCheckListModelView
    {
        public DataTable dtChecklist { get; set; }

        public int StationId { get; set; }


        public A246CEquipmentCheckList[] A246CEquipmentCheckListResults { get; set; }

        public int LineId { get; set; }

        public int ProjectId { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public List<Project> Projects { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<PartNo> PartNos { get; set; }
        public int ShiftId { get; set; }

        public int ApprovalId { get; set; }

        public string ProdLineLeader { get; set; }

        //public string ModelNo { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        // public string MachineNo { get; set; }
    }

    public class A246CDestructiveMachineCheckList
    {
        public int DestructiveId { get; set; }

        public int Id { get; set; }
        
        public int LineId { get; set; }

        public int ShiftId { get; set; }

        public int WeighingeId { get; set; }
        public int ApprovalId { get; set; }

        public string Value { get; set; }


        public int ModelId { get; set; }

        public int PartId { get; set; }

    }

    public class A246CDestructiveMachineCheckListModelView
    {
        public DataTable dtChecklist { get; set; }

        public int DestructiveId { get; set; }

        public int WeighingeId { get; set; }


        public A246CDestructiveMachineCheckList[] A246CDestructiveMachineCheckListResults { get; set; }


        public List<A246CMachines> Machines { get; set; }

        public int MachineId { get; set; }
        public int LineId { get; set; }

        public int ProjectId { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<Line> Lines { get; set; }

        public int Id { get; set; }
        public List<Shift> Shifts { get; set; }

        public List<A246COKNG> OKNG { get; set; }

        public List<Project> Projects { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<PartNo> PartNos { get; set; }
        public int ShiftId { get; set; }

        public int ApprovalId { get; set; }

        public string ProdLineLeader { get; set; }

        //public string ModelNo { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        // public string MachineNo { get; set; }
    }

    public class A246CNewHankingSheetCheckList
    {
        public int ResultId { get; set; }

        public string RootCause { get; set; }

        public string CorrectiveAction { get; set; }

        public string PreventiveAction { get; set; }
        public int InspectionId { get; set; }

        public int SectionId { get; set; }

        public int LineId { get; set; }

        public int ShiftId { get; set; }


        public int ApprovalId { get; set; }

        public decimal Value1 { get; set; }

        public decimal Value2 { get; set; }
        public decimal Value3 { get; set; }
        public decimal Value4 { get; set; }
        public decimal Value5 { get; set; }


        public int ModelId { get; set; }

        public int PartId { get; set; }

    }

    public class A246CNewHankingSheetCheckListModelView
    {
        public DataTable dtChecklist { get; set; }

        public int InspectionId { get; set; }

        public int SectionId { get; set; }


        public A246CNewHankingSheetCheckList[] A246CNewHankingSheetCheckListResults { get; set; }


        public List<A246CMachines> Machines { get; set; }

        public int MachineId { get; set; }
        public int LineId { get; set; }

        public int ProjectId { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public List<Project> Projects { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<PartNo> PartNos { get; set; }
        public int ShiftId { get; set; }

        public int ApprovalId { get; set; }

        public string ProdLineLeader { get; set; }

        //public string ModelNo { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        // public string MachineNo { get; set; }
    }

    public class A246CCTPaameterMCChecklist1
    {
        public int StationId { get; set; }

        public int ParameterId { get; set; }

        public int LineId { get; set; }

        public int ShiftId { get; set; }

        public string RootCause { get; set; }

        public int ResultId { get; set; }
        public string PreventiveAction { get; set; }

        public string CorrectiveAction { get; set; }

        public int ApprovalId { get; set; }

       public decimal Value { get; set; }

        public int LimitId { get; set; }


        public int ModelId { get; set; }

        public int PartId { get; set; }

    }

    public class AA246CCTPaameterMCChecklist1ModelView
    {
        public DataTable dtChecklist { get; set; }

        public int StationId { get; set; }

        public int ParameterId { get; set; }

        public int ApprovalId { get; set; }


        public A246CCTPaameterMCChecklist1[] A246CCTPaameterMCChecklist1Results { get; set; }


        public List<A246CMachines> Machines { get; set; }

        public int MachineId { get; set; }
        public int LineId { get; set; }

        public int ProjectId { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public List<Project> Projects { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<PartNo> PartNos { get; set; }
        public int ShiftId { get; set; }

        //public int ApprovalId { get; set; }

        public string ProdLineLeader { get; set; }

        //public string ModelNo { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        // public string MachineNo { get; set; }
    }

    public class ProdCheckListQualityAuditResult
    {


       // public string Image { get; set; }
        public int LineId { get; set; }

        public int ShiftId { get; set; }

        public string Namee { get; set; }

        public int ProjectId { get; set; }

        public int RiskId { get; set; }

        public int StatusId { get; set; }

        public int ModelId { get; set; }

        public int ModuleId { get; set; }

        public int PartId { get; set; }

        public int ApprovalId { get; set; }

        public string Image { get; set; }

        public int CreatedBy { get; set; }

        public int BatchId { get; set; }

        public int ZoneId { get; set; }

        public int ProdId { get; set; }

        public bool OneS { get; set; }

        public bool TwoS { get; set; }

        public bool ThreeS { get; set; }
        public bool FourS { get; set; }

        public bool FiveS { get; set; }

        public int ResultId { get; set; }


        public int FACAId { get; set; }

        public string RootCause { get; set; }

        public string CorrectiveAction { get; set; }

        public string PreventiveAction { get; set; }

        public string Descrription { get; set; }

        //public string Image { get; set; }

    }

    //public class A246CCTPaameterMCChecklist1
    //{
    //    public int StationId { get; set; }

    //    public int ParameterId { get; set; }

    //    public int LineId { get; set; }

    //    public int ShiftId { get; set; }


    //    public int ApprovalId { get; set; }

    //    public decimal Value { get; set; }

    //    public int LimitId { get; set; }


    //    public int ModelId { get; set; }

    //    public int PartId { get; set; }

    //}

    public class InsertBulkA246CCTParameterMCChecklistLine1ModelView
    {
        public DataTable dtChecklist { get; set; }

        public int StationId { get; set; }

        public int ParameterId { get; set; }

        public int ApprovalId { get; set; }


        public A246CCTPaameterMCChecklist1[] A246CCTParameterMCChecklistLine1 { get; set; }


        public List<A246CMachines> Machines { get; set; }

        public int MachineId { get; set; }
        public int LineId { get; set; }

        public int ProjectId { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<Line> Lines { get; set; }

        public List<Shift> Shifts { get; set; }

        public List<Project> Projects { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<PartNo> PartNos { get; set; }
        public int ShiftId { get; set; }

        //public int ApprovalId { get; set; }

        public string ProdLineLeader { get; set; }

        //public string ModelNo { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        // public string MachineNo { get; set; }

        //public int ResultId { get; set; }


        //public int FACAId { get; set; }

        //public string RootCause { get; set; }

        //public string CorrectiveAction { get; set; }

        //public string PreventiveAction { get; set; }

        //public string Descrription { get; set; }

        //public string Image { get; set; }
    }

    public class ProdVerifiedBy
    {
        public int VerifiedId { get; set; }

        public string Verified { get; set; }
    }
    public class ProdApprovedBy
    {
        public int ApprovedId { get; set; }

        public string Approved { get; set; }
    }

    public class ProdAuditBy
    {
        public int AuditId { get; set; }

        public string Auditor { get; set; }
    }

    public class prodCheckedBy
    {
        public int CheckedId { get; set; }

        public string Checked { get; set; }
    }
    public class ProdCheckListQualityAuditModelView
    {
        public List<DOL.ProdVerifiedBy> ProdVerifies { get; set; }

        public List<DOL.prodCheckedBy> prodChecks { get; set; }

        public List<DOL.ProdAuditBy> ProdAudits { get; set; }

        public List<DOL.ProdApprovedBy> ProdApproves { get; set; }

        public List<DOL.ProdShiftLeader> ProdShiftLeaders { get; set; }

        public int ShiftLeaderId { get; set; }


        //public int ShiftLeaderId { get; set; }

        //public int VerifiedId { get; set; }

       // public int ApprovedId { get; set; }

        //public int AuditId { get; set; }
        public string ShiftLeader { get; set; }

        public int VerifiedId { get; set; }

        public string Verified { get; set; }

        public int ApprovedId { get; set; }

        public string Approved { get; set; }

        public int AuditId { get; set; }

        public string Auditor { get; set; }

        //public List<DOL.Batch> Batches { get; set; }
        public ProdCheckListQualityAuditResult[] ProdCheckListQualityAuditResults { get; set; }

       // public List MyProperty { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }

        public int ProjectId { get; set; }


        public int LineId { get; set; }

        public List<Line> Lines { get; set; }

        public int ResultId { get; set; }


        public int FACAId { get; set; }

        public string RootCause { get; set; }

        public string CorrectiveAction { get; set; }

        public string PreventiveAction { get; set; }

        public string Descrription { get; set; }

        public string Image { get; set; }
        public int ShiftId { get; set; }

        public List<Shift> Shifts { get; set; }
        public DataTable dtChecklist { get; set; }
        public List<Project> Projects { get; set; }
        public int ModuleId { get; set; }


        public int StatusId { get; set; }

        //Status
        public List<Result> Statuses { get; set; }
        public List<ProdModule> ProdModules { get; set; }

        public int BatchId { get; set; }

        //public string ShiftLeader { get; set; }

        public string VerifiedBy { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }


        public int ModelId { get; set; }
        public string AuditedBy { get; set; }
        public string ProdLineLeader { get; set; }
        public List<Batch> Batches { get; set; }

        public int ZoneId { get; set; }

        public List<Zone> Zones { get; set; }
        public List<ProdModule> Modules { get; set; }

        public List<ProductionLineLeader> LineLeaders { get; set; }


        public int ProdId { get; set; }

        public List<ProductionLineLeader> ProductionLineLeaders { get; set; }
        
    }

    public class WorkFlowViewModel
    {
        //public string Applicant { get; set; }

        //public int MenuId { get; set; }

        public int LaserId { get; set; }
        public int ParameterId { get; set; }

        public int SectionId { get; set; }
        public int AdhesiveId { get; set; }
        public string ApproveId { get; set; }
        public List<MasterMenuss> Menuss { get; set; }
        public int FACAId { get; set; }

        public string Applicant { get; set; }

        public string ApprovedId { get; set; }

        public string ApproveId1 { get; set; }
        public int ResultId { get; set; }

        public int MenuId { get; set; }
        public int TaskId { get; set; }

        public string Reason { get; set; }
        public int Pid { get; set; }
        public string Status { get; set; }

        public string Remark { get; set; }
        public string Query { get; set; }

        public string EmployeeId { get; set; }

        public DataTable WorkFlowList { get; set; }

    }


}