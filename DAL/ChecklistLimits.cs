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
    public class ChecklistLimits
    {
        DbClass _DbClass;

        public ChecklistLimits()
        {
            _DbClass = DbClass.GetInstance();
        }

        public DataSet GetUpperLimitDetails(string Actual, string Result, int ProjectId, string ProjectName, int StationId, string StationName, int SubStationId, string SubStationName)
        {
            List<DOL.ChecklistLimits> listEmp = new List<DOL.ChecklistLimits>();
            DataSet ds = new DataSet();

            try
            {
                SqlParameter[] sqlParams =  {
                                           new SqlParameter( "@Actual", Actual ),
                                           new SqlParameter( "@Result", Result ),
                                           new SqlParameter( "@ProjectId", ProjectId ),
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

        public int InsertChecklistLimits(DOL.ChecklistLimits u)
        {
            SqlParameter[] sqlParams = {             
                                               
                                               new SqlParameter("@LowerLimit", u.LowerLimit),
                                               new SqlParameter("@UpperLimit", u.UpperLimit),
                                               new SqlParameter("@ProjectId", u.ProjectId),
                                               new SqlParameter("@StationId", u.StationId),
                                               new SqlParameter("@SubStationId", u.SubStationId),
                                               new SqlParameter("@ParameterId", u.ParameterId),
                                               new SqlParameter("@CreatedBy", u.CreatedBy),                                                
                                               new SqlParameter("@action", "Insert")            
                                               
                                            };
            int result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetChecklistLimits", sqlParams);


            return result;
        }

        public DataTable SearchForUpperLimit(string Actual, string Result, int ProjectId, int StationId, int SubStationId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlParams = { 
                                               new SqlParameter( "@Actual", Actual ),
                                           new SqlParameter( "@Result", Result ),
                                           new SqlParameter( "@ProjectId", ProjectId ),
                                           new SqlParameter( "@StationId", StationId ),
                                           new SqlParameter( "@SubStationId", SubStationId)                                        
                                            };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("GetUpperLimitDetails", sqlParams);

            }
            catch (Exception ex)
            {
                throw;
            }

            return dt;
        }

        public List<DOL.ChecklistLimits> GetCheckListLimits()
        {
            List<DOL.ChecklistLimits> listCheckListLimits = new List<DOL.ChecklistLimits>();


            try
            {

                DataTable dt = _DbClass.ExecuteProcedureForDataTable("ipqc.GetChecklistLimits");
                foreach (DataRow dr in dt.Rows)
                {
                   listCheckListLimits.Add(new DOL.ChecklistLimits { LimitId = Convert.ToInt32(dr["LimitId"]), LowerLimit = Convert.ToDecimal (dr["LowerLimit"]) });
                   
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listCheckListLimits;
        }

        public List<DOL.ChecklistLimits> GetCheckListLimits2()
        {
            List<DOL.ChecklistLimits> listCheckListLimits = new List<DOL.ChecklistLimits>();


            try
            {

                DataTable dt = _DbClass.ExecuteProcedureForDataTable("ipqc.GetChecklistLimits");
                foreach (DataRow dr in dt.Rows)
                {
                    
                    listCheckListLimits.Add(new DOL.ChecklistLimits { LimitId = Convert.ToInt32(dr["LimitId"]), LowerLimit = Convert.ToDecimal(dr["UpperLimit"]) });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listCheckListLimits;
        }
    }
}
