using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChecklistForm.Models
{
    public class ResultsViewModel
    {
        [Required]
        public string Result { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public int StationId { get; set; }
        [Required]
        public int SubStationId { get; set; }
        [Required]
        public int ParameterId { get; set; }
        [Required]
        public int LimitId { get; set; }
    }
}