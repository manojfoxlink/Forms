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
    public class Station
    {
        DbClass _DbClass;

         public Station()
        {
            _DbClass = DbClass.GetInstance();
        }

         public List<DOL.Project> GetProjectsDetails()
         {
             List<DOL.Project> listProject = new List<DOL.Project>();


             try
             {

                 DataTable dt = _DbClass.ExecuteProcedureForDataTable("epq.GetProject");
                 foreach (DataRow dr in dt.Rows)
                 {
                     listProject.Add(new DOL.Project { ProjectId = Convert.ToInt32(dr["ProjectId"]), ProjectName = dr["ProjectName"].ToString() });
                 }

             }
             catch (Exception)
             {

                 throw;
             }
             return listProject;


         }
         public DataSet GetstationDetails(string StationName, int ProjectId, string ProjectName)
         {
             List<DOL.Station> listEmp = new List<DOL.Station>();
             DataSet ds = new DataSet();

             try
             {
                 SqlParameter[] sqlParams =  {
                                           new SqlParameter( "@StationName", StationName ),
                                           new SqlParameter( "@ProjectId", ProjectId ),
                                           new SqlParameter( "@ProjectName", ProjectName )
                                           
                                       };


             }
             catch (Exception)
             {

                 throw;
             }

             return ds;
         }
         public DataTable GetPartNoByModel(int ModelId)
         {
             DataTable dt = new DataTable();

             try
             {
                 SqlParameter[] sqlparams = {
                                          new SqlParameter("@ModelId",ModelId)
                                       };
                 dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetPartNoByModel]", sqlparams);

             }
             catch (Exception)
             {

                 throw;
             }
             return dt;

         }

         public DataTable GetModelNoByProject(int ProjectId)
         {
             DataTable dt = new DataTable();

             try
             {
                 SqlParameter[] sqlparams = {
                                          new SqlParameter("@ProjectId",ProjectId)
                                       };
                 dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetModelNoByProject]", sqlparams);

             }
             catch (Exception)
             {

                 throw;
             }
             return dt;

         }
         public List<DOL.Station> GetStation()
         {
             List<DOL.Station> listStation = new List<DOL.Station>();


             try
             {

                 DataTable dt = _DbClass.ExecuteProcedureForDataTable("[ipqc].[GetStation]");
                 foreach (DataRow dr in dt.Rows)
                 {
                     listStation.Add(new DOL.Station { StationId = Convert.ToInt32(dr["StationId"]), StationName = dr["StationName"].ToString() });
                 }

             }
             catch (Exception)
             {

                 throw;
             }
             return listStation;
         }

         public DataTable GetStationByProject(int ProjectId)
         {
            DataTable dt = new DataTable();


             try
             {
                 SqlParameter[] sqlparam = {
                                               new SqlParameter("@ProjectId",ProjectId)
                                           };

                 dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetStationByProject]", sqlparam);
                
             }
             catch (Exception)
             {

                 throw;
             }
             return dt;
         }

        
        public int InsertStation(DOL.Station st)
        {
            SqlParameter[] sqlParams = {             
                                               new SqlParameter("@StationName", st.StationName),
                                               new SqlParameter("@ProjectId", st.ProjectId),
                                               new SqlParameter("@CreatedBy", st.CreatedBy),                                                
                                               new SqlParameter("@action","Insert"),           
                                               
                                            };
            int result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetStation", sqlParams);


            return result;
        }

        public int InsertEsdLuxStation(DOL.EsdLuxStation st)
        {
            SqlParameter[] sqlParams = {       new SqlParameter("@StationNo", st.StationNo),      
                                               new SqlParameter("@StationName", st.StationName),
                                               new SqlParameter("@ProjectId", st.ProjectId),
                                               new SqlParameter("@CreatedBy", st.CreatedBy),                                                
                                               new SqlParameter("@action","Insert"),           
                                               
                                            };
            int result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetEsdLuxStation", sqlParams);


            return result;
        }

        public DataTable SearchForProject(string ProjectName, int ProjectId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlParams = { 
                                               new SqlParameter("@StationName", ProjectName), 
                                               new SqlParameter( "@ProjectId", ProjectId )
                                                                                             
                                            };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("GetstationDetails", sqlParams);

            }
            catch (Exception ex)
            {

            }

            return dt;
        }
    }
    public class NativeValidation
    {
        DbClass _dbClass;

        public NativeValidation()
        {
            _dbClass = DbClass.GetInstance();
        }

        public List<DOL.Station> GetStation()
        {
            List<DOL.Station> listStation = new List<DOL.Station>();


            try
            {

                DataTable dt = _dbClass.ExecuteProcedureForDataTable("[ipqc].[GetStation]");
                foreach (DataRow dr in dt.Rows)
                {
                    listStation.Add(new DOL.Station { StationId = Convert.ToInt32(dr["StationId"]), StationName = dr["StationName"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listStation;
        }

        public List<DOL.Inspect> GetInspect()
        {
            List<DOL.Inspect> listInspect = new List<DOL.Inspect>();


            try
            {

                DataTable dt = _dbClass.ExecuteProcedureForDataTable("[ipqc].[GetInpection]");
                foreach (DataRow dr in dt.Rows)
                {
                    listInspect.Add(new DOL.Inspect { InspectId = Convert.ToInt32(dr["InspectId"]), Inspection = dr["Inspection"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listInspect;
        }

        public List<DOL.Frequencyy> GetFrequency()
        {
            List<DOL.Frequencyy> listFrequency = new List<DOL.Frequencyy>();


            try
            {

                DataTable dt = _dbClass.ExecuteProcedureForDataTable("[ipqc].[GetFrequency]");
                foreach (DataRow dr in dt.Rows)
                {
                    listFrequency.Add(new DOL.Frequencyy { FreqId = Convert.ToInt32(dr["FreqId"]), Frequency = dr["Frequency"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listFrequency;
        }

        public List<DOL.Period> Getperiod()
        {
            List<DOL.Period> listPeriod = new List<DOL.Period>();


            try
            {

                DataTable dt = _dbClass.ExecuteProcedureForDataTable("[ipqc].[GetPeriod]");
                foreach (DataRow dr in dt.Rows)
                {
                    listPeriod.Add(new DOL.Period { PeriodId = Convert.ToInt32(dr["PeriodId"]), Periods = dr["Periods"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listPeriod;
        }

        public int InsertNativeValidation(DOL.NativeValidation st)
        {
            SqlParameter[] sqlParams = {             
                                               new SqlParameter("@StationId", st.StationId),
                                               new SqlParameter("@InspectId", st.InspectId),
                                               new SqlParameter("@FreqId", st.FreqId),
                                               new SqlParameter("@PeriodId", st.PeriodId),
                                               new SqlParameter("@CreatedBy",st.CreatedBy),
                                               new SqlParameter("@ACTION","INSERT"),           
                                               
                                            };
            int result = _dbClass.ExecuteNonQueryWithParameter("ipqc.GetNativeValidation", sqlParams);


            return result;
        }
    }

    public class Inspect
    {
        DbClass _dbClass;
        public Inspect()
        {
            _dbClass = DbClass.GetInstance();
        }

        public DataTable GetInspectionByStation(int StationId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@StationId",StationId)
                                       };
                dt = _dbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetInspectionByStation]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }
    }

    public class Frequency
    {
        DbClass _dbClass;

        public Frequency()
        {
            _dbClass = DbClass.GetInstance();
        }

        public DataTable GetFrequencyByInspection(int InspectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@InspectId",InspectId)
                                       };
                dt = _dbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetFrequencyByInspection]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }
    }

    public class Period
    {
        DbClass _dbClass;

        public Period()
        {
            _dbClass = DbClass.GetInstance();
        }

        public DataTable GetPeriodByFrequency(int FreqId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@FreqId",FreqId)
                                       };
                dt = _dbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetPeriodByFrequency]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }
    }
}
