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
    public class Login
    {

        DbClass _DbClass;

        public Login()
        {
            _DbClass = DbClass.GetInstance();
        }

        public DataSet GetLogInDetails(string UserId, string Password)
        {
            List<DOL.Login> listEmp = new List<DOL.Login>();
            DataSet ds = new DataSet();

            try
            {
                SqlParameter[] sqlParams =  {
                                           new SqlParameter( "@UserId", UserId ),
                                           new SqlParameter( "@Password", Password )
                                       };


            }
            catch (Exception)
            {

                throw;
            }

            return ds;
        }

        public int InsertLogIn(DOL.Login l)
        {
            SqlParameter[] sqlParams = {             
                                               
                                               new SqlParameter("@UserId", l.UserId),
                                               new SqlParameter("@Password", l.Password),
                                               new SqlParameter("@CreatedBy", l.CreatedBy),
                                               new SqlParameter("@CreatedTime", l.CreatedTime)
                                               
                                            };
            int result = _DbClass.ExecuteNonQueryWithParameter("InsertLogIn", sqlParams);


            return result;
        }

        public DataTable SearchForLogIn(string UserId, string Password)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlParams = { 
                                               new SqlParameter( "@UserId", UserId ),
                                           new SqlParameter( "@Password", Password )                                      
                                            };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("GetLogInDetails", sqlParams);

            }
            catch (Exception ex)
            {
                throw;
            }

            return dt;
        }
    }
}
