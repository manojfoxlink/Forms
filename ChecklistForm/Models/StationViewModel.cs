using DOL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChecklistForm.Models
{
    public class StationViewModel
    {
        [Display(Name = "Station Name")]
        [Required]
        public string StationName { get; set; }

       [Required]
       [Display(Name = "Project Name")]
        public int ProjectId { get; set; }

       
       
        public List<Project> Projects { get; set; }

    }

    public class NativeValidationViewModel
    {
        public int StationId { get; set; }

        public List<Station> Stations { get; set; }
        public int InspectId { get; set; }

        public List<Inspect> Inpections { get; set; }
        public string PeriodId { get; set; }

        public List<Frequencyy> Frequencies { get; set; }

        public List<Period> Periodss { get; set; }
        public string FreqId { get; set; }

        public string CreatedBy { get; set; }

        public int ValidId { get; set; }   
    }

    public class EsdLuxStationViewModel
    {
        public int StationId { get; set; }

        public string StationNo { get; set; }

        public string StationName { get; set; }

        public int ProjectId { get; set; }

        public string CreatedBy { get; set; }

        public List<Project> Projects { get; set; }
    }
}