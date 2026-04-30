using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DOL;
namespace ChecklistForm.Models
{
    public class CheckPointModelView
    {
       

        public int Id { get; set; }

        public string ChckPoint { get; set; }

        public int MachineId { get; set; }

        public List<Machine> Machines {get;set;}

        public int ProjectId { get; set; }

        public List<Project> Projects { get; set; }

        public string CreatedBy { get; set; }
    }
}