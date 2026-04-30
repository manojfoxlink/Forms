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
  public class SubStation
  {
      DAL.SubStation _ObjSubStation = new DAL.SubStation();

      public DataSet GetSubstationDetails(string SubStationName, int ProjectId, string ProjectName, int StationId, string StationName)
      {
          return _ObjSubStation.GetSubstationDetails(SubStationName, ProjectId,ProjectName, StationId, StationName);
      }

      public int InsertSubStation(DOL.SubStation st)
      {
          return _ObjSubStation.InsertSubStation(st);
      }

      public DataTable SearchForSubStation(string ProjectName, int ProjectId, int StationId)
      {
          return SearchForSubStation(ProjectName, ProjectId, StationId);
      }

      public List<DOL.SubStation> GetSubStation()
      {
          return _ObjSubStation.GetSubStation();
      }

      public DataTable GetSubStationByStation(int StationId)
      {
          return _ObjSubStation.GetSubStationByStation(StationId);
      }
  }
}
