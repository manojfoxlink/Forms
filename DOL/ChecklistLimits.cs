using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOL
{
    public class ChecklistLimits
    {
        public int LimitId { get; set; }
        public decimal LowerLimit { get; set; }

        public decimal UpperLimit { get; set; }

        public int ProjectId { get; set; }

        
        public int StationId { get; set; }

        
        public int SubStationId { get; set; }

        
        public int ParameterId { get; set; }

        public string CreatedBy { get; set; }

        
    }

    public class ProcessTourDashBoard
    {
        public int LineId { get; set; }
        public TimeSpan Timee { get; set; }

        public decimal? CheckPoints { get; set; }

        public decimal? Pass { get; set; }

        public decimal? Fail { get; set; }

        public string CreatedBy { get; set; }
    }
    

    public class ModelNo
    {
        public int ModelId { get; set; }

        public string Model { get; set; }

    }

    public class PartNo
    {
        public int PartId { get; set; }

        public string Part { get; set; }
    }
}
