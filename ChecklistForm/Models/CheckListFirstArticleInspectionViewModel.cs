using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DOL;
using System.Data;
namespace ChecklistForm.Models
{
    public class CheckListFirstArticleInspectionViewModel
    {

       
        public int ItemId { get; set; }

        public int ContentId { get; set; }

        public string Content { get; set; }
        public string ItemName { get; set; }

        public int StationId { get; set; }

        public string StationName { get; set; }
        public int LineId { get; set; }


        public int ModelId { get; set; }

        public int PartId { get; set; }


        public List<ModelNo> ModelNos { get; set; }

        public List<PartNo> PartNos { get; set; }
        public int ProjectId { get; set; }


        public List<DOL.SRS> SRSS { get; set; }
        public List<DOL.Project> Projects { get; set; }

        public List<DOL.Shift> Shifts { get; set; }
        public List<Line> Lines {get; set; }

        //public DataSet dsChecklist { get; set; }


        public DataTable dtChecklist { get; set; }
        public string Result { get; set; }
        public string RejectDescribe { get; set; }

        public string LineNumber { get; set; }

        public string ProdLineLeader { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string ProductName { get; set; }

        public string WorkOrder { get; set; }

        public string DrawingVersion { get; set; }

        public string PackVersion { get; set; }

        public string SamplingQty { get; set; }

        //public int SRId { get; set; }
        
        public CheckListFirstArticleInspection[] CheckListFirstArticleInspections { get; set; }
    }


    public class CheckListFirstArticleInspectViewModel
    {

        public int SpecId { get; set; }

        public string Specification { get; set; }

        public int StationId { get; set; }

        public string StationName { get; set; }
        public int LineId { get; set; }


        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<PartNo> PartNos { get; set; }

        public int ProjectId { get; set; }


        public List<DOL.SRS> SRSS { get; set; }
        public List<DOL.Project> Projects { get; set; }

        public List<DOL.Shift> Shifts { get; set; }
        public List<Line> Lines { get; set; }

        //public DataSet dsChecklist { get; set; }


        public DataTable dtChecklist { get; set; }
       

        public string ProdLineLeader { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string ProductName { get; set; }

        public string WorkOrder { get; set; }

        public string DrawingVersion { get; set; }

        public string PackVersion { get; set; }

        public string SamplingQty { get; set; }

        public CheckListFirstArticleInspec[] CheckListFirstArticleInspecs { get; set; }
    }

    public class CheckListFirstArticleInspection
    {
  
        //public int SpecId { get; set; }

        //public int ItemId { get; set; }

        //public string ItemName { get; set; }
        public int ContentId { get; set; }

        public string Content { get; set; }

        //public int StationId { get; set; }

        //public string StationName { get; set; }

        public int SRId { get; set; }
        public string Result { get; set; }
        public string RejectDescribe { get; set; }
    }

    public class CheckListFirstArticleInspec
    {

        public int SpecId { get; set; }
        public int StationId { get; set; }
        public decimal Check1 { get; set; }

        public decimal Check2 { get; set; }

        public decimal Check3 { get; set; }

        public decimal Check4 { get; set; }

        public decimal Check5 { get; set; }

        public string SerialNo1 { get; set; }
        public string SerialNo2 { get; set; }
        public string SerialNo3 { get; set; }
        public string SerialNo4 { get; set; }
        public string SerialNo5 { get; set; }
    }
}