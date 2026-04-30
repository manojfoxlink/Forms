using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOL;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace BAL
{
    public class ChecklistLimits
    {
        DAL.ChecklistLimits _ObjChecklistLimits = new DAL.ChecklistLimits();

        public DataSet GetUpperLimitDetails(string Actual, string Result, int ProjectId, string ProjectName, int StationId, string StationName, int SubStationId, string SubStationName)
        {
            return _ObjChecklistLimits.GetUpperLimitDetails(Actual, Result, ProjectId, ProjectName, StationId, StationName, SubStationId, SubStationName);
        }

        public int InsertChecklistLimits(DOL.ChecklistLimits u)
        {
            return _ObjChecklistLimits.InsertChecklistLimits(u);
        }

        public DataTable SearchForUpperLimit(string Actual, string Result, int ProjectId, int StationId, int SubStationId)
        {
            return SearchForUpperLimit(Actual, Result, ProjectId, StationId, SubStationId);
        }

        public List<DOL.ChecklistLimits> GetCheckListLimits()
        {
            return _ObjChecklistLimits.GetCheckListLimits();
        }

        public List<DOL.ChecklistLimits> GetCheckListLimits2()
        {
            return _ObjChecklistLimits.GetCheckListLimits2();
        }
    }
}
