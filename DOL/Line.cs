using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOL
{
    public class Line
    {
        public int LineId { get; set; }
        public string LineName { get; set; }
    }

    public class ShiftLeaders
    {
        public int ShiftLeaderId { get; set; }

        public string ShiftLeader { get; set; }

        public List<Batch> Batches { get; set; }
    }

    public class ApprovedBy
    {
        public int ApprovedId { get; set; }

        public string Approved { get; set; }
    }

    public class AuditBy
    {
        public int AuditId { get; set; }
        public string Auditor { get; set; }
    }

    public class VerifiedBy
    {
        public int VerifiedId { get; set; }

        public string Verified { get; set; }
    }

    public class ProcessTourss
    {
        public int ProcessTourId { get; set; }

        public string ProcessTours { get; set; }
    }
    public class A246COKNG
    {
        public int Id { get; set; }

        public string Valuee { get; set; }
    }

    public class LaserSize
    {
        public string Locations { get; set; }

        public string Specification { get; set; }

        public decimal Minimum { get; set; }

        public decimal Maximum { get; set; }

        public string CreatedBy { get; set; }

        public int ProjectId { get; set; }
    }

    public class Exponent
    {
        public int ExpId { get; set; }

        public string Exponents { get; set; }
    }


    
}
