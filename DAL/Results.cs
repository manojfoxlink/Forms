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
    public class Results
    {
        DbClass _DbClass;


        public Results()
        {
            _DbClass = DbClass.GetInstance();
        }
        public int InsertResult(DOL.Results st)
        {
            SqlParameter[] sqlParams = {             
                                               new SqlParameter("@Result", st.Result),
                                               new SqlParameter("@ProjectId", st.ProjectId),
                                               new SqlParameter("@StationId", st.StationId),
                                               new SqlParameter("@SubStationId", st.SubStationId),
                                               new SqlParameter("@ParameterId", st.ParameterId),
                                               new SqlParameter("@LimitId", st.LimitId),                                                
                                               new SqlParameter("@action","Insert"),           
                                               
                                            };
            int result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetResults", sqlParams);


            return result;
        }
    }
}
