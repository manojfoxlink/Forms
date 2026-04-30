using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BAL
{
    public class GetForms
    {
        DbClass _DbClass;
        public GetForms()
        {
            _DbClass = DbClass.GetInstance();
        }

        public DataTable GetFromsLowers(int FormId)
        {

            DataTable dt = new DataTable();
            SqlParameter[] parms ={
                                      new SqlParameter("@FormId",FormId)
                                 };

            dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetLower]", parms);

            return dt;
        }
        public DataTable GetFromsParameters(int FormId)
        {

            DataTable dt = new DataTable();
            SqlParameter[] parms ={
                                      new SqlParameter("@FormId",FormId)
                                 };

            dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetParameters]", parms);

            return dt;
        }
        public DataTable GetFromsProject(int FormId)
        {

            DataTable dt = new DataTable();
            SqlParameter[] parms ={
                                      new SqlParameter("@FormId",FormId)
                                 };

            dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetProject]", parms);

            return dt;
        }

        public DataTable GetFromsStation(int FormId)
        {

            DataTable dt = new DataTable();

            SqlParameter[] parms ={
                                      new SqlParameter("@FormId",FormId)
                                 };

            dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetStation]", parms);

            return dt;
        }

        public DataTable GetSubStation(int FormId)
        {

            DataTable dt = new DataTable();

            SqlParameter[] parms ={
                                      new SqlParameter("@FormId",FormId)
                                 };

            dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetSubStation]", parms);

            return dt;
        }

        public DataTable GetFromsSubStation(int FormId)
        {

            DataTable dt = new DataTable();

            SqlParameter[] parms ={
                                      new SqlParameter("@FormId",FormId)
                                 };

            dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetSubStation]", parms);

            return dt;
        }

        public DataTable GetFromsUpper(int FormId)
        {

            DataTable dt = new DataTable();

            SqlParameter[] parms ={
                                      new SqlParameter("@FormId",FormId)
                                 };

            dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetUpper]", parms);

            return dt;
        }
        public int InsertCheckFromsResult(DataTable dtCheckListItem, string userId, int FormId)
        {
            int i = 0;

            SqlParameter[] parmeters ={
                                         new SqlParameter("@CheckItemList",dtCheckListItem),
                                         new SqlParameter("@UserId",userId),
                                         new SqlParameter("@FormId",FormId)
                                     };

            i = _DbClass.ExecuteNonQueryWithParameter("InsertCheckListResult", parmeters);

            return i;
        }
        public int UpdateCheckFromsResult(DataTable dtCheckListItem, string userId, int FormId)
        {
            int i = 0;

            SqlParameter[] parmeters ={
                                         new SqlParameter("@CheckItemList",dtCheckListItem),
                                         new SqlParameter("@UserId",userId),
                                         new SqlParameter("@FormId",FormId)
                                     };

            i = _DbClass.ExecuteNonQueryWithParameter("UpdateCheckFromsResult", parmeters);

            return i;
        }
        //public int IQCandWHsentMail(int wareHouseid, string Type)
        //{
        //    int Result = 0;
        //    SqlParameter[] parmeters ={
                                         
        //                                 new SqlParameter("@type",Type),
        //                                 new SqlParameter("@FormId",FormId)
        //                             };

        //    Result = Convert.ToInt16(_DbClass.ExecuteProcedureWithParameter("IQCandWHsentMail", parmeters));
        //    return Result;
        //}


        public object FormId { get; set; }
    }
}
