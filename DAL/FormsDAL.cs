using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace DAL
{
   public class FormsDAL
    {
       DbClass _dbClass;
       public FormsDAL()
       {
           _dbClass = DbClass.GetInstance();
       }
        // public DataTable GetFromsLowers()
        //{

        //    DataTable dt = new DataTable();

        //    dt = _dbClass.ExecuteProcedureForDataTable("[ipqc].[GetLower]");

        //    return dt;
        //}
        public DataTable GetFromsParameters()
        {

            DataTable dt = new DataTable();

            dt = _dbClass.ExecuteProcedureForDataTable("ipqc.GetParameters");

            return dt;
        }
        public DataTable GetFromsProject()
        {

            DataTable dt = new DataTable();

            dt = _dbClass.ExecuteProcedureForDataTable("ipqc.GetProject");

            return dt;
        }

        public DataTable GetFromsStation()
        {

            DataTable dt = new DataTable();

            dt = _dbClass.ExecuteProcedureForDataTable("ipqc.GetStation");

            return dt;
        }

        //public DataTable GetFormSubStation()
        //{

        //    DataTable dt = new DataTable();

        //    dt = _dbClass.ExecuteProcedureForDataTable("ipqc.GetSubStation");

        //    return dt;
        //}

        public DataTable GetFromsSubStation()
        {

            DataTable dt = new DataTable();

            dt = _dbClass.ExecuteProcedureForDataTable("[ipqc].[GetSubStation]");

            return dt;
        }

        public DataTable GetFromsChecklistLimits()
        {

            DataTable dt = new DataTable();

            dt = _dbClass.ExecuteProcedureForDataTable("ipqc.GetChecklistLimits");

            return dt;
        }

       public DataTable GetFormsCheckListResults()
        {
            DataTable dt = new DataTable();

            dt = _dbClass.ExecuteProcedureForDataTable("ipqc.GetCheckListResults");

            return dt;
        }

        public DataTable GetFromsLogin()
        {

            DataTable dt = new DataTable();

            dt = _dbClass.ExecuteProcedureForDataTable("[ipqc].[LogInId]");

            return dt;
        }

        public DataTable GetFromsRegister()
        {

            DataTable dt = new DataTable();

            dt = _dbClass.ExecuteProcedureForDataTable("[ipqc].[GetRegister]");

            return dt;
        }

        public DataTable GetFormByProject()
        {

            DataTable dt = new DataTable();

            dt = _dbClass.ExecuteProcedureForDataTable("ipqc.GetFormByProject");

            return dt;
        }


        public int InsertCheckListResult(DataTable dtCheckListItem, int ParameterId, int LimitId, string Result, decimal Actual)
        {
            int i = 0;

            SqlParameter[] parmeters ={
                                         new SqlParameter("@CheckListResult",dtCheckListItem),
                                         new SqlParameter("@ParameterId",ParameterId),
                                         new SqlParameter("@LimitId",LimitId),
                                         new SqlParameter("@Result",Result),
                                         new SqlParameter("@Actual",Actual),
                                         new SqlParameter("@action","")
                                     };

            i = _dbClass.ExecuteNonQueryWithParameter("ipqc.GetResults", parmeters);

            return i;
        }
        //public int UpdateCheckFromsResult(DataTable dtCheckListItem, string userId, int FormId)
        //{
        //    int i = 0;

        //    SqlParameter[] parmeters ={
        //                                 new SqlParameter("@CheckItemList",dtCheckListItem),
        //                                 new SqlParameter("@UserId",userId),
        //                                 new SqlParameter("@FormId",FormId)
        //                             };

        //    i = _dbClass.ExecuteNonQueryWithParameter("UpdateCheckFromsResult", parmeters);

        //    return i;
        //}
        //public int IQCandWHsentMail(int wareHouseid, string Type)
        //{
        //    int Result = 0;
        //    SqlParameter[] parmeters ={
                                         
        //                                 new SqlParameter("@type",Type),
        //                                 new SqlParameter("@FormId",FormId)
        //                             };

        //    Result = Convert.ToInt16(_dbClass.ExecuteProcedureWithParameter("IQCandWHsentMail", parmeters));
        //    return Result;
        //}


        //public object FormId { get; set; }
    }
    
}
