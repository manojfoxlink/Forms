using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DOL;
using System.Data;
namespace ChecklistForm.Models
{
    public class LasersizeViewModel
    {
       
        public int LineId { get; set; }
        public List<Line> Lines { get; set; }

        public int ProjectId { get; set; }
        public List<Project> Projects { get; set; }
        public int ShiftId { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<Shift> Shifts { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<PartNo> PartNos { get; set; }
        //public List<LaserCheckListResult> LaserCheckListResults { get; set; }

        public LaserCheckListResult[] LaserCheckListResults { get; set; }

        public DataTable dtLaser { get; set; }

        //public int Id { get; set; }
        public int LaserId { get; set; }

        public string ProdLineLeader { get; set; }
        public string CheckedBy { get; set; }
        public string ApprovedBy { get; set; }

        public string ModelNo { get; set; }

    }
    public class LaserCheckListResult 
    {
        //public int Id { get; set; }
        public int ResultId { get; set; }

        public string RootCause { get; set; }

        public string PreventiveAction { get; set; }

        public string CorrectiveAction { get; set; }
        public int LaserId { get; set; }
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

        public string  Result  { get; set; }
    }

    public class ProcessTourDataa
    {
        public int DataId { get; set; }

        public int ProjectId { get; set; }

        public int ShiftId { get; set; }

        public int ApprovalId { get; set; }

        public int LineId { get; set; }

        public string Model { get; set; }

        public string Section1 { get; set; }

        public string Section2 { get; set; }

        public string Section3 { get; set; }

        public string Section4 { get; set; }

        public string Section5 { get; set; }

        public string DefectiveNumber { get; set; }

        public string CreatedBy { get; set; }

    }

    public class CheckListProcessTourDataaModelView
    {
        public int LineId { get; set; }
        public List<Line> Lines { get; set; }

        public int ProjectId { get; set; }
        public List<Project> Projects { get; set; }
        public int ShiftId { get; set; }

        public List<Shift> Shifts { get; set; }
        public string Model { get; set; }

        public ProcessTourDataa[] ProcessTourDataaResults { get; set; }
        public DataTable dtProcess { get; set; }

        public int DataId { get; set; }


        public int VisualsId { get; set; }
        public List<Visuals> Visualss { get; set; }
        public string ProdLineLeader { get; set; }
        public string CheckedBy { get; set; }
        public string ApprovedBy { get; set; }

        public string CreatedBy { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }

        public List<ModelNo> ModelNos { get; set; }

        public List<PartNo> PartNos { get; set; }
    }

      
}