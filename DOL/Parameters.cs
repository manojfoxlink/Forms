using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOL
{
    public class ProdVerifiedBy
    {
        public int VerifiedId { get; set; }

        public string Verified { get; set; }
    }
    public class ProdApprovedBy
    {
        public int ApprovedId { get; set; }

        public string Approved { get; set; }
    }

    public class ProdAuditBy
    {
        public int AuditId { get; set; }

        public string Auditor { get; set; }
    }

    public class prodCheckedBy
    {
        public int CheckedId { get; set; }

        public string Checked { get; set; }
    }

    public class Parameters
    {
        public int ParameterId { get; set; }

        public string ParameterName { get; set; }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int StationId { get; set; }

        public string StationName { get; set; }
        public int SubStationId { get; set; }

        public string SubStationName { get; set; }
        public string CreatedBy { get; set; }

        public DateTime createdTime { get; set; }
    }
}
