using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DOL;
namespace ChecklistForm.Models
{
    public class LaserViewModel
    {
        public string Locations { get; set; }

        public string Specification { get; set; }
        
        public decimal? Minimum { get; set; }
        
        public decimal? Maximum { get; set; }

        public string CreatedBy { get; set; }

        public int  ProjectId { get; set; }

        public List<DOL.Project> Projects { get; set; }
    }
}