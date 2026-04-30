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
    public class CheckPointResultViewModel
    {

        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int MachineId { get; set; }

        public int LineId { get; set; }

        public List<Line> Lines { get; set; }

        public int ShiftId { get; set; }

        public List<Shift> shifts { get; set; }

        public CheckPointResult[] CheckPointResults { get; set; }

        public List<Machine> Machines { get; set; }

        public DataTable dtChecklist { get; set; }

        public string DRILeader { get; set; }

        public string LineLeader { get; set; }
    }

    public class CheckPointResult
    {
        public int CheckId { get; set; }
        public int CreatedBy { get; set; }

        public bool Result { get; set; }

        public int ResultId { get; set; }
    }

    public class CheckListProcessTourData
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


    public class CheckListProcessTourDataModelView
    {
        public int ProjectId { get; set; }

        public int VisualsId { get; set; }
        public List<Project> Projects { get; set; }
        public int DataId { get; set; }

        public int LineId { get; set; }

        public List<Line> Lines { get; set; }

        public int ShiftId { get; set; }

        public List<Shift> Shifts { get; set; }

        public CheckListProcessTourData[] CheckListProcessTourDataResults { get; set; }
        public DataTable dtChecklist { get; set; }

        public string ProdLineLeader { get; set; }
        public string CheckedBy { get; set; }
        public string ApprovedBy { get; set; }

        public string Model { get; set; }

        public int ModelId { get; set; }

        public int PartId { get; set; }
    }


    public class CheckListProcessTourDataModelView1
    {
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }
        public int DataId { get; set; }

        public int LineId { get; set; }

        public List<Line> Lines { get; set; }

        public int ShiftId { get; set; }

        public List<Shift> Shifts { get; set; }

        public CheckListProcessTourData[] CheckListProcessTourDataResults { get; set; }
        public DataTable dtChecklist { get; set; }

        public string ProdLineLeader { get; set; }
        public string CheckedBy { get; set; }
        public string ApprovedBy { get; set; }

        public string Model { get; set; }
    }
}