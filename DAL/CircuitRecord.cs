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
    public class CircuitRecord
    {
        DbClass _dbClass;

        public CircuitRecord()
        {
            _dbClass = DbClass.GetInstance();
        }

        public int InsertCircuitRecord(DOL.CircuitRecord cr)
        {
            SqlParameter[] sqlParams = { 
                                                           
                                               new SqlParameter("@Inspectionitem", cr.Inspectionitem),
                                               new SqlParameter("@ModelNumber", cr.ModelNumber),
                                               new SqlParameter("@InspecSpecification", cr.InspecSpecification),
                                               new SqlParameter("@CreatedBy", cr.CreatedBy),
                                               new SqlParameter("@ProjectId",cr.ProjectId),
                                               new SqlParameter("@action","Insert"),            
                                               
                                            };

            int result = _dbClass.ExecuteNonQueryWithParameter("ipqc.GetCircuitRecord", sqlParams);
            return result;
        }

        public List<DOL.Project> GetProject()
        {
            List<DOL.Project> listProject = new List<DOL.Project>();


            try
            {

                DataTable dt = _dbClass.ExecuteProcedureForDataTable("[ipqc].[GetProject]");
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
    }

    
}
