using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOL
{
    public class SubStation
    {
        public int SubStationId { get; set; }

        public string SubStationName { get; set; }

        public int ProjectId { get; set; }

        
        public int StationId { get; set; }

        

        public string CreatedBy { get; set; }

        public DateTime createdTime { get; set; }
    }

    public class Inspectors
    {
        public int InspecId { get; set; }

        public string Inspector { get; set; }
    }

    public class EsdLuxStation
    {
        public int StationId { get; set; }

        public string StationNo { get; set; }

        public string StationName { get; set; }

        public int ProjectId { get; set; }

        public string CreatedBy { get; set; }
    }
}
