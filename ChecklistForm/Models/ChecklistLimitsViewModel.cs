using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DOL;
namespace ChecklistForm.Models
{
    public class ChecklistLimitsViewModel
    {
      
      public decimal LimitId { get; set; }


      [Required(ErrorMessage = "LowerLimit")]
      public decimal? LowerLimit { get; set; }

      [Required(ErrorMessage = "UpperLimit")]
      public decimal? UpperLimit { get; set; }

     
      [Required]
      public int ProjectId { get; set; }

     
      [Required]
      public int StationId { get; set; }
      
    
      [Required]
      public int SubStationId { get; set; }

     
      [Required]
      public int ParameterId { get; set; }
     
      public List<Project> Projects { get; set; }
      
      public List<Station> Stations { get; set; }
      
      public List<SubStation> SubStations { get; set; }
      
      public List<Parameters> Parameters { get; set; }
    }
}