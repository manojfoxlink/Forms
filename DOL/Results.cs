using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOL
{
   public  class Results
    {
        public string Result { get; set; }

        public int ProjectId { get; set; }

        public int StationId { get; set; }

        public int SubStationId { get; set; }

        public int ParameterId { get; set; }

        public int LimitId { get; set; }

        public string CreatedBy { get; set; }
    }
}
