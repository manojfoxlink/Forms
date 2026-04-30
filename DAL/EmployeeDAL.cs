using DOL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class EmployeeDAL
    {
        DbClass _DbClass;
        public EmployeeDAL()
        {
            _DbClass = DbClass.GetInstance();
        }
        public DataSet GetEmployeeDetails(string employeeId)
        {

            //List<Employee> listEmp = new List<Employee>();
            List<DOL.Employee> listEmp = new List<Employee>();
            DataSet ds = new DataSet();
            try
            {

                SqlParameter[] sqlParams =  {
                                    new SqlParameter( "@Employeeid", employeeId ),


                                };

                ds = _DbClass.ExecuteProcedureWithParameterForDataSet("ipqc.UserValidation", sqlParams);

                if (ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "Employees";
                    ds.Tables[1].TableName = "Roles";
                    ds.Tables[2].TableName = "Menus";

                }
            }
            catch (Exception e)
            {
                ds = null;
                throw new Exception(e.Message);
            }

            return ds;

        }
        public int UpsertEmployee(DOL.Employee emp, string type)
        {


            //try
            //{
            SqlParameter[] sqlParams = {
                                        new SqlParameter("@EmpNumber", emp.EmployeeId),
                                        new SqlParameter("@Name", emp.EmployeeName),
                                        new SqlParameter("@Password", emp.Password),
                                        new SqlParameter("@isActive", 1),
                                        new SqlParameter("@CreatedBy", emp.CreatedBy),
                                        new SqlParameter("@RoleName", emp.RoleName),
                                        new SqlParameter("@Action", type),
                                        new SqlParameter("@ProfilePicture", emp.FilePath),
                                        new SqlParameter("@Designation", emp.Designation),

                                     };
            int result = _DbClass.ExecuteNonQueryWithParameter("ipqc.UpsertEmployees", sqlParams);



            //}catch(Exception ex)
            //{
            //    throw new Exception( ex.Message );
            //}

            return result;
        }
        public DataTable GetWareHouseType()
        {
            DataTable dt = new DataTable();

            //try
            //{

            dt = _DbClass.ExecuteProcedureForDataTable("GetWH");



            //}catch(Exception ex)
            //{
            //    throw new Exception( ex.Message );
            //}

            return dt;
        }
        public List<DOL.Menus> GetMenus()
        {
            DataSet ds = new DataSet();

            ds = _DbClass.ExecuteProcedureForDataSet("ipqc.GetMenus");
            DOL.Menus objEmp = new DOL.Menus();
            List<DOL.Menus> MenuList = new List<DOL.Menus>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                MenuList.Add(new DOL.Menus { Menu = Convert.ToString(dr["Menu"]), MenuId = Convert.ToInt32(dr["MenuId"]), ParentMenuId = Convert.ToInt32(dr["ParentMenuId"]) });
            }

            return MenuList;


        }
        public bool AssignMenus(DOL.Menus menus, string empNumber)
        {
            bool ret = false;



            if (menus.SelectedGroups.Length > 0)
            {
                DataTable dtMenus = new DataTable("Menus");
                dtMenus.Columns.Add("Id");
                dtMenus.Columns.Add("MenuId");
                int Uid = 1;
                foreach (int mId in menus.SelectedGroups)
                {
                    dtMenus.Rows.Add(Uid, mId);
                    Uid++;
                }
                SqlParameter[] sqlParams =  {
                                    new SqlParameter( "@EmpNumber", empNumber ),
                                    new SqlParameter( "@MenuIdList", dtMenus ),


                                };
                _DbClass.ExecuteNonQueryWithParameter("ipqc.AssignMenusToEmployee", sqlParams);


                ret = true;
            }


            return ret;
        }
        public DOL.Employee SearchForEmpMenu(string username)
        {
            DataSet ds = new DataSet();
            DOL.Employee objempsearch;

            SqlParameter[] sqlParams =  {
                                    new SqlParameter( "@EmployeeNumber", username ),

                                };
            ds = _DbClass.ExecuteProcedureWithParameterForDataSet("ipqc.SearchEmployeeMenus", sqlParams);
            if (ds.Tables[0].Rows.Count > 0)
            {
                objempsearch = new DOL.Employee { EmployeeId = Convert.ToString(ds.Tables[0].Rows[0]["EmpNumber"]), EmployeeName = Convert.ToString(ds.Tables[0].Rows[0]["Name"]), RoleName = Convert.ToString(ds.Tables[0].Rows[0]["RoleName"]) };
                objempsearch.Menuss = new List<DOL.Menus>();
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        DOL.Menus menus = new DOL.Menus();
                        menus.MenuId = Convert.ToInt32(dr["MenuId"]);
                        menus.Menu = Convert.ToString(dr["Menu"]);
                        objempsearch.Menuss.Add(menus);
                    }
                }

                return objempsearch;
            }

            else
            {
                return null;
            }

        }
        public DataTable SearchForEmployee(string empNum, string empName)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlParams = {
                                        new SqlParameter("@EmployeeNumber", empNum),
                                        new SqlParameter("@EmpName", empName)
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetEmployees", sqlParams);

            }
            catch (Exception ex)
            {

            }

            return dt;
        }
        public DataTable GetMail(string Employeeid)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlParams = {

                                        new SqlParameter("@EmployeeId", Convert.ToInt32(Employeeid))
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("GetMail", sqlParams);

            }
            catch (Exception ex)
            {

            }

            return dt;
        }
        public DataTable GetAbnormal(int EmpId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlParams = {

                                        new SqlParameter("@EmpId", EmpId)
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("GetEmployeeAbsent", sqlParams);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }
        public DataTable GetInchare(int empId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlParameters =
                                     {
                                         new SqlParameter("@EmpId",empId)

                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("GetInchare", sqlParameters);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }
        public DataTable GetDeptHead(int empId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlParameters =
                                     {
                                         new SqlParameter("@EmpId",empId)

                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("GetDeptHead", sqlParameters);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetAdhesiveByResultId(int ResultId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlParameters =
                                     {
                                         new SqlParameter("@ResultId",ResultId)

                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetAdhesiveByResultId]", sqlParameters);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }
        public DataTable GetHRHead(int empId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlParameters =
                                     {
                                         new SqlParameter("@EmpId",empId)

                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("GetHRHead", sqlParameters);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }
        public int InsertBulkuploadApplyLeave(DataTable empleyeeLeavelist, string CreatedBy)
        {
            int result = 0;
            try
            {
                SqlParameter[] parms =
         {
             new SqlParameter("@TaskList",empleyeeLeavelist),
             new SqlParameter("@CreatedBy",CreatedBy)


         };
                DataTable dt = _DbClass.ExecuteProcedureWithParameterForDataTable("InsertBulkuploadApplyLeave", parms);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }
}
