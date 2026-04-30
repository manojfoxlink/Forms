using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOL
{
    public class Station
    {
        public int StationId { get; set; }

        public string StationName { get; set; }

        public int ProjectId { get; set; }

        
        public string CreatedBy { get; set; }

        public DateTime createdTime { get; set; }
    }

    public class Visuals
    {
        public int VisualsId { get; set; }

        public string Visual { get; set; }
    }
    public class Inspect
    {
        public int InspectId { get; set; }

        public string Inspection { get; set; }
    }
    public class Frequencyy
    {
        public int FreqId { get; set; }

        public string Frequency { get; set; }
    }

    public class Period
    {
        public int PeriodId { get; set; }

        public string Periods { get; set; }
    }

   public class NativeValidation
   {
       public int StationId { get; set; }

       public int InspectId { get; set; }

       public string PeriodId { get; set; }

       public string FreqId { get; set; }

       public string CreatedBy { get; set; }

       public int ValidId { get; set; }     
   }

}
