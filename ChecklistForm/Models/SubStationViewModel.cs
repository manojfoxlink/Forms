using DOL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChecklistForm.Models
{
    public class SubStationViewModel
    {
        [Display(Name = "SubStation Name")]
        [Required]
        public string SubStationName {get; set;}
        [Display(Name = "Project Name")]
        [Required]
        public int ProjectId { get; set; }
        
        public List<Project> Projects { get; set; }

        [Display(Name = "Station Name")]
        public int StationId { get; set; }
        
        public List<Station> Stations { get; set; }
    }

    public class PartToInspectViewModel
    {
        public int InspectId { get; set; }

        public string Sno { get; set; }

        public string parts { get; set; }

        public int ProjectId { get; set; }

        public string CreatedBy { get; set; }

        public List<Project> Projects { get; set; }
    }

    public class InspectorDetailsViewModel
    {
        public int DetailsId { get; set; }

        public int InspectId { get; set; }


        public int InspecId { get; set; }
        public string InspectorDetails { get; set; }

        public int ProjectId { get; set; }

        public string CreatedBy { get; set; }

        public List<Project> Projects { get; set; }

        public List<Inspectors> Inspector { get; set; }

        public List<DOL.PartToInspect> Inspects { get; set; }
    }
}