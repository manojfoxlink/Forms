using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOL;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Parameters
    {
        DbClass _DbClass;
        public Parameters()
        {
            _DbClass = DbClass.GetInstance();
        }

        public DataSet GetParameterDetails(string ParameterName, int ProjectId,string ProjectName, int StationId, string StationName,int SubStationId, string SubStationName)
        {
            List<DOL.Parameters> listEmp = new List<DOL.Parameters>();
            DataSet ds = new DataSet();

            try
            {
                SqlParameter[] sqlParams =  {
                                           new SqlParameter( "@ParameterName", ParameterName ),
                                           new SqlParameter( "@ProjectId", ProjectId ),
                                           new SqlParameter( "@ProjectName", ProjectName ),
                                           new SqlParameter( "@StationId", StationId ),
                                           new SqlParameter( "@StationName", StationName ),
                                           new SqlParameter( "@SubStationId", SubStationId),
                                           new SqlParameter( "@SubStationName", SubStationName)
                                       };


            }
            catch (Exception)
            {

                throw;
            }

            return ds;
        }

        public List<DOL.Parameters> GetParameters()
        {
            List<DOL.Parameters> listParameters = new List<DOL.Parameters>();


            try
            {

                DataTable dt = _DbClass.ExecuteProcedureForDataTable("ipqc.GetParameters");
                foreach (DataRow dr in dt.Rows)
                {
                    listParameters.Add(new DOL.Parameters { ParameterId = Convert.ToInt32(dr["ParameterId"]), ParameterName = dr["ParameterName"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listParameters;
        }

        
        public int InsertParameter(DOL.Parameters p)
        {
            SqlParameter[] sqlParams = {             
                                               new SqlParameter("@ParameterName", p.ParameterName),
                                               new SqlParameter("@ProjectId", p.ProjectId),
                                               new SqlParameter("@StationId", p.StationId),
                                               new SqlParameter("@SubStationId", p.SubStationId),
                                               new SqlParameter("@CreatedBy", p.CreatedBy)  ,
                                               new SqlParameter("@action", "Insert")
                                                         
                                               
                                            };
            int result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetParameters", sqlParams);


            return result;
        }

        public int InsertProdModule(DOL.ProdModule p)
        {
            SqlParameter[] sqlParams = {             
                                               new SqlParameter("@ProjectId", p.ProjectId),
                                               new SqlParameter("@BatchId", p.BatchId),
                                               new SqlParameter("@ZoneId", p.ZoneId),
                                               new SqlParameter("@Module", p.Module),
                                               new SqlParameter("@CreatedBy", p.CreatedBy)  ,
                                               new SqlParameter("@action", "Insert")
                                                         
                                               
                                            };
            int result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetProdModule", sqlParams);


            return result;
        }

        public int InsertProductionLineLeader(DOL.ProductionLineLeader p)
        {
            SqlParameter[] sqlParams = {             
                                               new SqlParameter("@ProjectId", p.ProjectId),
                                               new SqlParameter("@BatchId", p.BatchId),
                                               new SqlParameter("@ZoneId", p.ZoneId),
                                               new SqlParameter("@EmpId", p.EmpId),
                                               new SqlParameter("@LineLeader", p.LineLeader),
                                               new SqlParameter("@Imagee", p.Imagee),
                                               new SqlParameter("@CreatedBy", p.CreatedBy)  ,
                                               new SqlParameter("@action", "Insert")
                                                         
                                               
                                            };
            int result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetProductionLineLeader", sqlParams);


            return result;
        }

        public int InsertProdRiskPoints(DOL.ProdRiskPoints p)
        {
            SqlParameter[] sqlParams = {             
                                               new SqlParameter("@ProjectId", p.ProjectId),
                                               new SqlParameter("@BatchId", p.BatchId),
                                               new SqlParameter("@ZoneId", p.ZoneId),
                                               new SqlParameter("@ModuleId", p.ModuleId),
                                               new SqlParameter("@Points", p.Points),
                                               new SqlParameter("@CreatedBy", p.CreatedBy)  ,
                                               new SqlParameter("@action", "Insert")
                                                         
                                               
                                            };
            int result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetProdRiskPoints", sqlParams);


            return result;
        }

        public int InsertProcessTourData(DOL.ProcessTourData p)
        {
            SqlParameter[] sqlParams = {             
                                               new SqlParameter("@ProjectId", p.ProjectId),
                                               new SqlParameter("@StationId", p.StationId),
                                               new SqlParameter("@VisualsId", p.VisualsId),
                                               new SqlParameter("@SNo", p.SNo),
                                               new SqlParameter("@InpectionProject", p.InpectionProject),
                                               new SqlParameter("@InspectionSpecifaction", p.InspectionSpecifaction),
                                               new SqlParameter("@SampleSize", p.SampleSize),
                                               new SqlParameter("@CreatedBy", p.CreatedBy)  ,
                                               new SqlParameter("@action", "Insert")
                                                         
                                               
                                            };
            int result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetProcessTourData", sqlParams);


            return result;
        }

        public int InsertA246CCTPMCStationsOne(DOL.A246CStationCTPOne p)
        {
            SqlParameter[] sqlParams = {             
                                               new SqlParameter("@StationNo", p.StationNo),
                                               new SqlParameter("@StationName", p.StationName),
                                               new SqlParameter("@MachineId", p.MachineId),
                                               new SqlParameter("@EquipmentName", p.EquipmentName),
                                               new SqlParameter("@CreatedBy", p.CreatedBy),
                                               new SqlParameter("@ProjectId", p.ProjectId),
                                               new SqlParameter("@action", "Insert")
                                                         
                                               
                                            };
            int result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetA246CStationCTPOne", sqlParams);


            return result;
        }

        public int InsertA246CCTPMCStations(DOL.A246CCTPMCStations p)
        {
            SqlParameter[] sqlParams = {             
                                               new SqlParameter("@StationNo", p.StationNo),
                                               new SqlParameter("@Station", p.Station),
                                               new SqlParameter("@MachineId", p.MachineId),
                                               new SqlParameter("@EquipmentModel", p.EquipmentModel),
                                               new SqlParameter("@CreatedBy", p.CreatedBy),
                                               new SqlParameter("@ProjectId", p.ProjectId),
                                               new SqlParameter("@action", "Insert")
                                                         
                                               
                                            };
            int result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetA246CCTPMCStations", sqlParams);


            return result;
        }

        public int InsertA246CParameterCTPOne(DOL.A246CParameterCTPOne p)
        {
            SqlParameter[] sqlParams = {             
                                               new SqlParameter("@StationId", p.StationId),
                                               new SqlParameter("@ParameterName", p.ParameterName),
                                               new SqlParameter("@Unit", p.Unit),
                                               new SqlParameter("@LSL", p.LSL),
                                               new SqlParameter("@USL", p.USL),
                                               new SqlParameter("@MachineId", p.MachineId),
                                               new SqlParameter("@CreatedBy", p.CreatedBy),
                                               new SqlParameter("@ProjectId", p.ProjectId),
                                               new SqlParameter("@action", "Insert")
                                                         
                                               
                                            };
            int result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetA246CParameterCTPOne", sqlParams);


            return result;
        }

        public int InsertA246CCTPMCParameter(DOL.A246CCTPMCParameter p)
        {
            SqlParameter[] sqlParams = {             
                                               new SqlParameter("@StationId", p.StationId),
                                               new SqlParameter("@Parameter", p.Parameter),
                                               //new SqlParameter("@Unit", p.Unit),
                                               //new SqlParameter("@LSL", p.LSL),
                                               //new SqlParameter("@USL", p.USL),
                                               new SqlParameter("@MachineId", p.MachineId),
                                               new SqlParameter("@CreatedBy", p.CreatedBy),
                                               new SqlParameter("@ProjectId", p.ProjectId),
                                               new SqlParameter("@action", "Insert")
                                                         
                                               
                                            };
            int result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetA246CCTPMCParameter", sqlParams);


            return result;
        }

        public int InsertA246CCTPMCParameterLimits(DOL.A246CCTPMCParameterLimits p)
        {
            SqlParameter[] sqlParams = {             
                                               new SqlParameter("@StationId", p.StationId),
                                               new SqlParameter("@ParameterId", p.ParameterId),
                                               new SqlParameter("@Unit", p.unit),
                                               new SqlParameter("@LSL", p.LSL),
                                               new SqlParameter("@USL", p.USL),
                                               new SqlParameter("@MachineId", p.MachineId),
                                               new SqlParameter("@CreatedBy", p.CreatedBy),
                                               new SqlParameter("@ProjectId", p.ProjectId),
                                               new SqlParameter("@action", "Insert")
                                                         
                                               
                                            };
            int result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetA246CCTPMCParameterLimits", sqlParams);


            return result;
        }

        public int InsertProcessTourForDashBoard(DOL.ProcessTourDashBoard p)
        {
            SqlParameter[] sqlParams = {             
                                               new SqlParameter("@Timee", p.Timee),
                                               new SqlParameter("@LineId", p.LineId),
                                               new SqlParameter("@CheckPoints", p.CheckPoints),
                                               new SqlParameter("@Pass", p.Pass),
                                               new SqlParameter("@Fail", p.Fail),
                                               //,
                                               //new SqlParameter("@USL", p.USL),
                                               //new SqlParameter("@MachineId", p.MachineId),
                                               new SqlParameter("@CreatedBy", p.CreatedBy)
                                               //new SqlParameter("@ProjectId", p.ProjectId),
                                               //new SqlParameter("@action", "Insert")
                                            };
            int result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetProcessTourForDashBoard", sqlParams);


            return result;
        }

        public int InsertNGApprovalFlow(DOL.NGApprovalFlow p)
        {
            SqlParameter[] sqlParams = {             
                                               new SqlParameter("@ApproveId", p.ApproveId),
                                               new SqlParameter("@ApproveName", p.ApproveName),
                                               new SqlParameter("@TaskId", p.TaskId),
                                               new SqlParameter("@Designation", p.Designation),
                                                new SqlParameter("@MenuId", p.MenuId),
                                                //SectionId
                                                new SqlParameter("@SectionId", p.SectionId),
                                               new SqlParameter("@CreatedBy", p.CreatedBy),
                                               new SqlParameter("@action", "Insert")
                                                         
                                               
                                            };
            int result = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertNGApprovalFlow", sqlParams);


            return result;
        }

        public int InsertBulkNGApprovalFlow(DataTable dtListAsset, string CreatedBy)
        {
            int result = 0;
            try
            {
                SqlParameter[] paras ={
                                         new SqlParameter("@NGApprovalFlow",dtListAsset),
                                         new SqlParameter("@CreatedBy",CreatedBy)
                                       };
                result = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkNGApprovalFlow", paras);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public int InsertBulkA191LaserNGApprovalFlow(DataTable dtListAsset, string CreatedBy)
        {
            int result = 0;
            try
            {
                SqlParameter[] paras ={
                                         new SqlParameter("@NGApprovalFlow",dtListAsset),
                                         new SqlParameter("@CreatedBy",CreatedBy)
                                       };
                result = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkA191LaserNGApprovalFlow", paras);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public int InsertBulkxBARNGApprovalFlow(DataTable dtListAsset, string CreatedBy)
        {
            int result = 0;
            try
            {
                SqlParameter[] paras ={
                                         new SqlParameter("@NGApprovalFlow",dtListAsset),
                                         new SqlParameter("@CreatedBy",CreatedBy)
                                       };
                result = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkxBARNGApprovalFlow", paras);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public int InsertBulkCTPNGApprovalFlow(DataTable dtListAsset, string CreatedBy)
        {
            int result = 0;
            try
            {
                SqlParameter[] paras ={
                                         new SqlParameter("@NGApprovalFlow",dtListAsset),
                                         new SqlParameter("@CreatedBy",CreatedBy)
                                       };
                result = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkCTPNGApprovalFlow", paras);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public DataTable SearchForParameter(string ParameterName, int ProjectId, int StationId, int SubStationId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlParams = { 
                                               new SqlParameter("@ParameterName", ParameterName), 
                                               new SqlParameter( "@ProjectId", ProjectId ),
                                               new SqlParameter("@StationId", StationId),
                                               new SqlParameter("@SubStationId", SubStationId)                                              
                                            };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("GetParameterDetails", sqlParams);

            }
            catch (Exception ex)
            {
                throw;
            }

            return dt;
        }

        public DataTable GetParametersBySubStation(int SubStationId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] SqlParam = {
                                              new SqlParameter("@SubStationId",SubStationId)
                                          };

             dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetParamtersBySubStation]",SqlParam);
            }
            catch (Exception)
            {
                
                throw;
            }

            return dt;
        }
    }
}
