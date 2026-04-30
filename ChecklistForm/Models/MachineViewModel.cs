using Syncfusion.XPS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DOL;
namespace ChecklistForm.Models
{
    public class MachineViewModel
    {

        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }

        public int MachineId { get; set; }

        public string MachineName { get; set; }

        public string CreatedBy { get; set; }

        public List<Machine> Machines { get; set; }
    }

    

    public class CategoryViewModel
    {
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }

        public int CatId { get; set; }

        public string Category { get; set; }

        public int MachineId { get; set; }

        public string CreatedBy { get; set; }

        public List<Categoryy> Categories { get; set; }

        public List<Machine> Machines { get; set; }
    }

    public class ActivityViewModel
    {
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }

        public string Activity { get; set; }

        public List<DOL.Activityy> Activities { get; set; }


        public int MachineId { get; set; }

        public int CatId { get; set; }

        public string CreatedBy { get; set; }

        public List<Machine> Machines { get; set; }

        public List<Categoryy> Categories { get; set; }
    }

    public class PartsViewModel
    {
        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }

        public int PartsId { get; set; }

        public string Sno { get; set; }

        public string PartOfInspection { get; set; }

        public string Freq { get; set; }

        public string StandardCondition { get; set; }

        public int MachineId { get; set; }

        public int CatId { get; set; }

        public int ActivityId { get; set; }

        public string CreatedBy { get; set; }

        public List<Machine> Machines { get; set; }

        public List<Categoryy> Categories { get; set; }

        public List<Activityy> Activities { get; set; }
    }

    
    }
