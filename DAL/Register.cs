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
    public class Register
    {
        DbClass _DbClass;

        public Register()
        {
            _DbClass = DbClass.GetInstance();
        }

        public DataSet GetRegisterDetails(string UserName, string PassWord, string ConfirmPassWord, string Designation, string LineNumber)
        {
            List<DOL.Register> listEmp = new List<DOL.Register>();
            DataSet ds = new DataSet();

            try
            {
                SqlParameter[] sqlParams =  {
                                           new SqlParameter( "@UserName", UserName),
                                           new SqlParameter( "@PassWord", PassWord ),
                                           new SqlParameter( "@PassWord", ConfirmPassWord ),
                                           new SqlParameter( "@Designation", Designation ),
                                           new SqlParameter( "@LineNumber", LineNumber)
                                       };


            }
            catch (Exception)
            {

                throw;
            }

            return ds;
        }

        public int InsertRegister(DOL.Register r)
        {
            SqlParameter[] sqlParams = {             
                                               
                                               new SqlParameter("@userId", r.userId),
                                               new SqlParameter("@UserName", r.UserName),
                                               new SqlParameter("@PassWord", r.PassWord),
                                               new SqlParameter("@ConfirmPassWord", r.ConfirmPassWord),
                                               new SqlParameter("@Designation", r.Designation)
                                            };
            int result = _DbClass.ExecuteNonQueryWithParameter("InsertLogIn", sqlParams);


            return result;
        }

        public DataTable SearchForRegister(string UserName, string PassWord, string ConfirmPassWord, string Designation)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlParams = { 
                                               new SqlParameter( "@UserName", UserName),
                                           new SqlParameter( "@PassWord", PassWord ),
                                           new SqlParameter( "@PassWord", ConfirmPassWord ),
                                           new SqlParameter( "@Designation", Designation )                                     
                                            };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("GetLogInDetails", sqlParams);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }
    }
}
