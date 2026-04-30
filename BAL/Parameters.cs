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
    public class Parameters
    {
        DAL.Parameters _ObjParameters = new DAL.Parameters();

        public DataSet GetParameterDetails(string ParameterName, int ProjectId, string ProjectName, int StationId, string StationName, int SubStationId, string SubStationName)
        {
            return _ObjParameters.GetParameterDetails(ParameterName, ProjectId, ProjectName, StationId, StationName, SubStationId, SubStationName);
        }

        public int InsertParameter(DOL.Parameters p)
        {
            return _ObjParameters.InsertParameter(p);
        }
        public int InsertProductionLineLeader(DOL.ProductionLineLeader p)
        {
            try
            {
                return _ObjParameters.InsertProductionLineLeader(p);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int InsertProdRiskPoints(DOL.ProdRiskPoints p)
        {
            try
            {
                return _ObjParameters.InsertProdRiskPoints(p);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int InsertProcessTourData(DOL.ProcessTourData p)
        {
            try
            {
                return _ObjParameters.InsertProcessTourData(p);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int InsertA246CCTPMCStationsOne(DOL.A246CStationCTPOne p)
        {
            try
            {
                return _ObjParameters.InsertA246CCTPMCStationsOne(p);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int InsertA246CCTPMCStations(DOL.A246CCTPMCStations p)
        {
            try
            {
                return _ObjParameters.InsertA246CCTPMCStations(p);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int InsertA246CCTPMCParameter(DOL.A246CCTPMCParameter p)
        {
            try
            {
                return _ObjParameters.InsertA246CCTPMCParameter(p);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int InsertA246CCTPMCParameterLimits(DOL.A246CCTPMCParameterLimits p)
        {
            try
            {
                return _ObjParameters.InsertA246CCTPMCParameterLimits(p);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int InsertProcessTourForDashBoard(DOL.ProcessTourDashBoard p)
        {
            try
            {
                return _ObjParameters.InsertProcessTourForDashBoard(p);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int InsertNGApprovalFlow(DOL.NGApprovalFlow p)
        {
            try
            {
                return _ObjParameters.InsertNGApprovalFlow(p);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int InsertBulkNGApprovalFlow(DataTable dtListAsset, string CreatedBy)
        {
            try
            {
                return _ObjParameters.InsertBulkNGApprovalFlow(dtListAsset,CreatedBy);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int InsertBulkA191LaserNGApprovalFlow(DataTable dtListAsset, string CreatedBy)
        {
            try
            {
                return _ObjParameters.InsertBulkA191LaserNGApprovalFlow(dtListAsset,CreatedBy);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int InsertBulkxBARNGApprovalFlow(DataTable dtListAsset, string CreatedBy)
        {
            try
            {
                return _ObjParameters.InsertBulkxBARNGApprovalFlow(dtListAsset,CreatedBy);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int InsertBulkCTPNGApprovalFlow(DataTable dtListAsset, string CreatedBy)
        {
            try
            {
                return _ObjParameters.InsertBulkCTPNGApprovalFlow(dtListAsset,CreatedBy);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int InsertA246CParameterCTPOne(DOL.A246CParameterCTPOne p)
        {
            try
            {
                return _ObjParameters.InsertA246CParameterCTPOne(p);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertProdModule(DOL.ProdModule p)
        {
            try
            {
                return _ObjParameters.InsertProdModule(p);
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        public DataTable SearchForParameter(string ParameterName, int ProjectId, int StationId, int SubStationId)
        {
            return _ObjParameters.SearchForParameter(ParameterName, ProjectId, StationId, SubStationId);
        }

        public List<DOL.Parameters> GetParameters()
        {
            return _ObjParameters.GetParameters();
        }

        public DataTable GetParametersBySubStation(int SubStationId)
        {
            return _ObjParameters.GetParametersBySubStation(SubStationId);
        }
    }
}
