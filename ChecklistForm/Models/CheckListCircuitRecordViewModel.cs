using DOL;
using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DOL;

namespace ChecklistForm.Models
{
    public class CheckListCircuitRecordViewModel
    {
        public DataTable dtChecklist { get; set; }

        public CheckListRecordResult[] CheckListRecordResults { get; set; }
        public int LineId { get; set; }

        public List<Line> Lines { get; set; }

        public int ShiftId { get; set; }
        public List<Shift> Shifts { get; set; }

        public int ModelId{ get; set; }

        public int  PartId { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<PartNo> PartNos { get; set; }
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }

        public string ProdLineLeader { get; set; }
        public string CheckedBy { get; set; }
        public string ApprovedBy { get; set; }

        public string ModelNo { get; set; }

    }

    public class CheckListRecordResult
    {
        //[Required]
        //public int Id { get; set; }

       
        public int RecordId { get; set; }

       
        //public string Result { get; set; }

        public string Result { get; set; }

        
        public string AdverseNumber { get; set; }

       

       
    }

    public class CheckListCircuitBoardResult
    {
        public int ResultId { get; set; }

        public int SpecId { get; set; }

        public int ItemId { get; set; }

        public int FreqId { get; set; }

        public int PeriodId { get; set; }


        public int ApprovalId { get; set; }

        public int StationId { get; set; }

        public int ProjectId { get; set; }

        
        public decimal Value1 { get; set; }

        public decimal Value2 { get; set; }

        public decimal Value3 { get; set; }

        public decimal Value4 { get; set; }
        public decimal Value5 { get; set; }

        public string Result { get; set; } 


    }

    public class CheckListCTQManPowerResult
    {
        public int ResultId { get; set; }

        public int InspectionId { get; set; }

        public int ApprovalId { get; set; }

        public string InspectorName { get; set; }

        public string InspectorId { get; set; }

        public bool Result { get; set; }

        public int categoryId { get; set; }

        public string CreatedBy { get; set; }
    }

    public class CheckListCTQManPowerResultModelView
    {
        public DataTable dtChecklist { get; set; }

        public CheckListCTQManPowerResult[] CheckListCTQManPowerResults { get; set; }
        public int LineId { get; set; }

        public List<Line> Lines { get; set; }

        public int ShiftId { get; set; }
        public List<Shift> Shifts { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<PartNo> PartNos { get; set; }

        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }

        public List<InspectorCategory> Categories { get; set; }

        public string ProdLineLeader { get; set; }
        public string CheckedBy { get; set; }
        public string ApprovedBy { get; set; }

        public int categoryId { get; set; }

        
        //public int InspectionId { get; set; }

        //public int InspectorName { get; set; }

        //public int InspectorId { get; set; }

    }

    public class CheckListCircuitBoardResultModelView
    {
        public DataTable dtChecklist { get; set; }

        public CheckListCircuitBoardResult[] CheckListCircuitBoardResults { get; set; }
        public int LineId { get; set; }

        public List<Line> Lines { get; set; }

        public int ProcessTourId { get; set; }

        public List<ProcessTourss> ProcessTourss { get; set; }
        public int ShiftId { get; set; }
        public List<Shift> Shifts { get; set; }

        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<PartNo> PartNos { get; set; }
        public string ProdLineLeader { get; set; }
        public string CheckedBy { get; set; }
        public string ApprovedBy { get; set; }

        public int PeriodId { get; set; }

        public string Result { get; set; }

    }

    public class CheckListXBarResult
    {
        public string RootCausee { get; set; }

        public string PreventiveAction { get; set; }

        public string CorrectiveAction { get; set; }
        public int ResultId { get; set; }

        public int AdhesiveId { get; set; }

        public decimal DataValue { get; set; }

        public bool RootCause { get; set; }

        //public string FeedBack { get; set; }

        public int ProjectId { get; set; }

        public int LineId { get; set; }

        public int ShiftId { get; set; }

        public int ApprovalId { get; set; }

        public int CreatedBy { get; set; }
    }

    public class CheckListXBarResultModelView
    {
        public DataTable dtChecklist { get; set; }

        public CheckListXBarResult[] CheckListXBarResults { get; set; }
        public int LineId { get; set; }

        public int AdhesiveId { get; set; }
        public List<Line> Lines { get; set; }

        public int ShiftId { get; set; }
        public List<Shift> Shifts { get; set; }

        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }

        //public int AdhesiveId { get; set; }

        public List<Adhesivee> Adhesives { get; set; }

        public string ProdLineLeader { get; set; }
        public string CheckedBy { get; set; }
        public string ApprovedBy { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<PartNo> PartNos { get; set; }

     //   public decimal DataValue { get; set; }

      //  public bool RootCause { get; set; }
    }
    public class CheckListTemperature
    {
        public int ResultId { get; set; }

        public int TempId { get; set; }

        public decimal Value { get; set; }

        public bool Determine { get; set; }

        public int ProjectId { get; set; }

        public int LineId { get; set; }

        public int ShiftId { get; set; }

        public int ApprovalId { get; set; }

        public int CreatedBy { get; set; }

        
    }

    public class CheckListTemperatureResultModelView
    {
        public DataTable dtChecklist { get; set; }

        public CheckListTemperature[] CheckListTemperatures { get; set; }
        public int LineId { get; set; }

        public int AdhesiveId { get; set; }
        public List<Line> Lines { get; set; }

        public int ShiftId { get; set; }
        public List<Shift> Shifts { get; set; }

        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public List<TempRange> Ranges { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<PartNo> PartNos { get; set; }
        public int TempId { get; set; }
        public string ProdLineLeader { get; set; }
        public string CheckedBy { get; set; }
        public string ApprovedBy { get; set; }

        public string EquipmentNo { get; set; }

        public string TypeNo { get; set; }
    }

    public class CheckListDestructiveTestResult
    {
        public int ProjectId { get; set; }

        public int InspectionId { get; set; }

        public int WireId { get; set; }

        public int FrequencyId { get; set; }

        public int LineId { get; set; }

        public int ShiftId { get; set; }

        public int SpecId { get; set; }
        public decimal Value1 { get; set; }
        public decimal Value2 { get; set; }
        public decimal Value3 { get; set; }
        public decimal Value4 { get; set; }
        public decimal Value5 { get; set; }

        public string SNo1 { get; set; }

        public string SNo2 { get; set; }

        public string SNo3 { get; set; }

        public string SNo4 { get; set; }
        public int CreatedBy { get; set; }
    }

    public class CheckListDestructiveTestResultModelView
    {
        public DataTable dtChecklist { get; set; }

        public CheckListDestructiveTestResult[] CheckListDestructiveTestResults { get; set; }
        public int LineId { get; set; }

        public List<Line> Lines { get; set; }

        public int ShiftId { get; set; }
        public List<Shift> Shifts { get; set; }

        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<PartNo> PartNos { get; set; }
        public string ProdLineLeader { get; set; }
        public string CheckedBy { get; set; }
        public string ApprovedBy { get; set; }

        public int ApprovalId { get; set; }

        public int CreatedBy { get; set; }

        //public int SpecId { get; set; }

        
    }
}