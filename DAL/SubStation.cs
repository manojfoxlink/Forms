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
    public class SubStation
    {
        DbClass _DbClass;

        public SubStation()
        {
            _DbClass = DbClass.GetInstance();
        }

        public DataSet GetSubstationDetails(string SubStationName, int ProjectId,string ProjectName, int StationId, string StationName)
        {
            List<DOL.SubStation> listEmp = new List<DOL.SubStation>();
            DataSet ds = new DataSet();

            try
            {
                SqlParameter[] sqlParams =  {
                                           new SqlParameter( "@SubStationName", SubStationName ),
                                           new SqlParameter( "@ProjectId", ProjectId ),
                                           new SqlParameter( "@ProjectName", ProjectName ),
                                           new SqlParameter( "@StationId", StationId ),
                                           new SqlParameter( "@StationName", StationName )
                                       };


            }
            catch (Exception)
            {

                throw;
            }

            return ds;
        }

        //public List<DOL.SubStation> GetStationByProject()
        //{
        //    List<DOL.Project> listProject = new List<DOL.Project>();


        //    try
        //    {

        //        DataTable dt = _DbClass.ExecuteProcedureForDataTable("[ipqc].[GetProject]");
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            listProject.Add(new DOL.Project { ProjectId = Convert.ToInt32(dr["ProjectId"]), ProjectName = dr["ProjectName"].ToString() });
        //        }

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return listProject;
        //}

        public List<DOL.SubStation> GetSubStation()
        {
            List<DOL.SubStation> listSubStation = new List<DOL.SubStation>();


            try
            {

                DataTable dt = _DbClass.ExecuteProcedureForDataTable("ipqc.GetSubStation");
                foreach (DataRow dr in dt.Rows)
                {
                    listSubStation.Add(new DOL.SubStation { SubStationId = Convert.ToInt32(dr["SubStationId"]), SubStationName = dr["SubStationName"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listSubStation;
        }

        public int InsertSubStation(DOL.SubStation st)
        {
            SqlParameter[] sqlParams = {             
                                               new SqlParameter("@SubStationName", st.SubStationName),
                                               new SqlParameter("@ProjectId", st.ProjectId),
                                               new SqlParameter("@StationId", st.StationId),
                                               new SqlParameter("@CreatedBy", st.CreatedBy),                                                
                                               new SqlParameter("@action", "Insert")            
                                               
                                            };
            int result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetSubStation", sqlParams);


            return result;
        }

        public DataTable SearchForSubStation(string ProjectName, int ProjectId, int StationId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlParams = { 
                                               new SqlParameter("@StationName", ProjectName), 
                                               new SqlParameter( "@ProjectId", ProjectId ),
                                               new SqlParameter("@StationId", StationId)
                                                                                             
                                            };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("GetSubstationDetails", sqlParams);

            }
            catch (Exception ex)
            {

            }

            return dt;
        }

        public DataTable GetSubStationByStation(int StationId)
        {
            DataTable dt = new DataTable();

           try 
	     {
             SqlParameter[] sqlparams = {
                                          new SqlParameter("@StationId",StationId)
                                       };
             dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetSubStationByStation", sqlparams);

	     }
	    catch (Exception)
	    {
		
		throw;
	    }
           return dt;
            
        }
    }
}
