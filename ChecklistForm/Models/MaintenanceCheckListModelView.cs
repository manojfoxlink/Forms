using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DOL;
using System.ComponentModel.DataAnnotations;
namespace ChecklistForm.Models
{
    public class MaintenanceCheckListModelView
    {
        public DataTable dtChecklist { get; set; }

        public CheckListMaintenanceResult[] CheckListMaintenanceResults { get; set; }

        public int LineId { get; set; }

        public List<Line> Lines { get; set; }

        public int ShiftId { get; set; }
        public List<Shift> Shifts { get; set; }

        public int MachineId { get; set; }

        public List<Machine> Machines { get; set; }

        public int ActivityId { get; set; }

        public List<Activityy> Activities { get; set; }

        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }

        public string DRILeader { get; set; }

        public string LineLeader { get; set; }

        public int FreqId { get; set; }

        public List<DOL.Freqq> Frequencies { get; set; }

    }

   public class CheckListMaintenanceResult
   {

       public int CatId { get; set; }

       public int ActivityId { get; set; }

       public int PartsId { get; set; }
       public bool Result { get; set; }

       public string CreatedBy { get; set; }

       public string Remarks { get; set; }
       
   }

    public class CheckListoutGoingInspectionResult
    {
        public int ItemId { get; set; }

        public int SpecId { get; set; }

        public int ContentId { get; set; }

        public int ShiftId { get; set; }

        public int LineId { get; set; }

        public int ApprovalId { get; set; }

        public string Result { get; set; }

        public int CreatedBy { get; set; }

    }

    public class OutGoingInspectionResultModelView
    {
        public DataTable dtChecklist { get; set; }

        public CheckListoutGoingInspectionResult[] CheckListoutGoingInspectionResults { get; set; }

        public int LineId { get; set; }

        public List<Line> Lines { get; set; }

        public int ShiftId { get; set; }
        public List<Shift> Shifts { get; set; }

        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }

        public string ProdLineLeader { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string CustomerPin { get; set; }

        public string LotSize { get; set; }

        public string FinishedProductNo { get; set; }

        public string SimToolPartNumber { get; set; }
        public string Rev { get; set; }

        public string PackingListNo { get; set; }

        public bool InspectResult { get; set; }

        public bool InspectResult1 { get; set; }

        public bool InspectResult2 { get; set; }
    }


    public class CheckListTrapTestResults
    {
        public int TestId { get; set; }

        public int InspectId { get; set; }

        public int InspecId { get; set; }

        public string InspectorName { get; set; }

        public int NoOfCables { get; set; }

        public int CheckedQty { get; set; }

        public int SkippedQty { get; set; }

        public string CheckResult { get; set; }

        public string InspectorId { get; set; }

       // public int InspecId { get; set; }

        public int categoryId { get; set; }
    }

    public class CheckListTrapTestResultViewModel
    {
        public List<Line> Lines { get; set; }

        //public int DetailsId { get; set; }
        public int LineId { get; set; }
        public int ShiftId { get; set; }
        public List<Shift> Shifts { get; set; }

        public int categoryId { get; set; }

        public int InspecId { get; set; }

        public List<InspectorCategory> Categories { get; set; }

        public List<InspectorSS> InspectorSS { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<PartNo> PartNos { get; set; }
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }

        public DataTable dtChecklist { get; set; }

        public string ProdLineLeader { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        public CheckListTrapTestResults[] CheckListTrapTestResults { get; set; }

    }
    public class CheckListAuditChecksResult
    {
        public int OperationId { get; set; }

        public int CheckId { get; set; }

        public int ApprovalId { get; set; }

        public string Status { get; set; }

        public string CreatedDateTime { get; set; }

        public string Image { get; set; }

    }

    public class CheckListAuditCheckPointsModelview
    {
        public int LineId { get; set; }

        //public int AuditId { get; set; }
        public List<Line> Lines { get; set; }

        public int ShiftId { get; set; }
        public List<Shift> Shifts { get; set; }


        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<PartNo> PartNos { get; set; }
        public string Image { get; set; }
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }

        public string ProdLineLeader { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        public DataTable dtChecklist { get; set; }
        public CheckListAuditChecksResult[] CheckListAuditChecksResults { get; set; }
    }
}