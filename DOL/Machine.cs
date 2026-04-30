using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOL
{
    public class Machine
    {
        public int MachineId { get; set; }
        public string MachineName { get; set; }

        public string CreatedBy { get; set; }

        public int ProjectId { get; set; }
    }

    public class Categoryy
    {

        public int CatId { get; set; }
        public string Category { get; set; }

        public int ProjectId { get; set; }
        public int MachineId { get; set; }

        public string CreatedBy { get; set; }
    }

    public  class Activityy
    {
        public int ActivityId { get; set; }
        public string Activity { get; set; }

        public int MachineId { get; set; }

        public int ProjectId { get; set; }

        public int CatId { get; set; }

        public string CreatedBy { get; set; }

        public List<Machine> Machines { get; set; }

        public List<Categoryy> Categories { get; set; }
    }

    public class Parts
    {
        public int PartsId { get; set; }

        public string Sno { get; set; }

        public string PartOfInspection { get; set; }

        public string Freq { get; set; }

        public string StandardCondition { get; set; }

        public int MachineId { get; set; }

        public int CatId { get; set; }

        public int ProjectId { get; set; }

        public int ActivityId { get; set; }

        public string CreatedBy { get;  set; }

        public List<Machine> Machines { get; set; }

        public List<Categoryy> Categories { get; set; }

        public List<Activityy> Activities { get; set; }
    }

    public class CheckPoints
    {
        public int Id { get; set; }

        public string ChckPoint { get; set; }

        public int MachineId { get; set; }

        public List<Machine> Machines { get; set; }

        public int ProjectId { get; set; }
        public List<Project> Projects { get; set; }
        public string CreatedBy { get; set; }
    }

    public class Operations
    {
        public int OperationId { get; set; }


        public int projectId { get; set; }
        public string Process { get; set; }

        public string Operation { get; set; }

        public string CreatedBy { get; set; }

        public List<Project> Projects { get; set; }
    }

    public class AuditCheckPoint
    {
        public int CheckId { get; set; }

        public int projectId { get; set; }
        public List<Project> Projects { get; set; }

        public List<Operations> Operations { get; set; }

        public string CheckPoints { get; set; }

        public int OperationId { get; set; }

        public string Dept { get; set; }

        public string CreatedBy { get; set; }

        public string Image { get; set; }
    }
    //public class DestructiveFrequency
    //{
    //    public int ProjectId { get; set; }

    //    public string Frequency { get; set; }

    //    public string CreatedBy { get; set; }

    //    public string FrequencyId { get; set; }
    //}
}
