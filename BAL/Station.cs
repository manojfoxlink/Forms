using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOL;
using DAL;
using System.Data;
namespace BAL
{
    
    public class Station
    {
        DAL.Station _ObjStation = new DAL.Station();

        public DataSet GetstationDetails(string StationName, int ProjectId, string ProjectName)
        {
            return _ObjStation.GetstationDetails(StationName, ProjectId,ProjectName);
        }

        
        public int InsertStation(DOL.Station st)
        {
            return _ObjStation.InsertStation(st);
        }

        public int InsertEsdLuxStation(DOL.EsdLuxStation st)
        {
            try
            {
                return _ObjStation.InsertEsdLuxStation(st);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable SearchForProject(string ProjectName, int ProjectId)
        {
            return _ObjStation.SearchForProject(ProjectName, ProjectId);
        }

        public List<DOL.Station> GetStation()
        {
            return _ObjStation.GetStation();
        }

        public DataTable GetStationByProject(int ProjectId)
        {
            return _ObjStation.GetStationByProject(ProjectId);
        }
    }

    public class NativeValidation
    {
        DAL.NativeValidation Obj = new DAL.NativeValidation();

        public int InsertNativeValidation(DOL.NativeValidation st)
        {
            try
            {
                return Obj.InsertNativeValidation(st);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }

    public class Inspect
    {
        DAL.Inspect obj = new DAL.Inspect();

        public DataTable GetInspectionByStation(int StationId)
        {
            try
            {
                return obj.GetInspectionByStation(StationId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }

    public class Frequency
    {
        DAL.Frequency obj = new DAL.Frequency();

        public DataTable GetFrequencyByInspection(int InspectId)
        {
            try
            {
                return obj.GetFrequencyByInspection(InspectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }

    public class period
    {
        DAL.Period obj = new DAL.Period();

        public DataTable GetPeriodByFrequency(int FreqId)
        {

            try
            {
                return obj.GetPeriodByFrequency(FreqId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }

}
