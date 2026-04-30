using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using DOL;
namespace ChecklistForm.Models
{
    public class ProjectViewModel
    {
        //[Required]
        //public int ProjectId { get; set; }

        [Display(Name = "Project Name")]
        [Required]
        
        public string ProjectName { get; set; }

        public DataTable dtProject { get; set; }

        public List<Project> Projects { get; set; }
    }

    public class OperationsViewModel
    {
        public int OperationId { get; set; }


        public int ProjectId { get; set; }
        public string Process { get; set; }

        public string Operation { get; set; }

        public List<Operations> Operations { get; set; }

        public List<Project> Projects { get; set; }
    }

    public class AuditCheckPointViewModel
    {
        public int CheckId { get; set; }

        public string CheckPoints { get; set; }

        public int ProjectId { get; set; }
        public int OperationId { get; set; }

        public string Dept { get; set; }

        public List<Project> Projects { get; set; }
        public List<Operations> Operationss { get; set; }
        public List<AuditCheckPoint> CheckPointss { get; set; }

        
        [Display(Name = "Profile Picture")]
        public string Image { get; set; }

        public DataTable AuditList { get; set; }

    }
}