using System;
using DOL;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChecklistForm.Models
{
    public class ParametersViewModel
    {
        [Display(Name = "Parameter Name")]
        [Required]
        public string ParameterName { get; set; }

       
        [Required]
        public int ProjectId { get; set; }
        
        
        public List<Project> Projects { get; set; }

        //[Display(Name = "Station Name")]
        [Required]
        public int StationId { get; set; }
        
        public List<Station> Stations { get; set; }

        //[Display(Name = "SubStation Name")]
        [Required]
        public int SubStationId { get; set; }

        public List<SubStation> SubStations { get; set; }



        
    }
}