using DAL;
using DOL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
   public class EmployeeBAL
    {
        EmployeeDAL _objEmployee = new EmployeeDAL();
        public DataSet GetEmployeeDetails(string employeeid)
        {

            return _objEmployee.GetEmployeeDetails(employeeid);

        }
        public int UpsertEmployee(DOL.Employee emp, string type)
        {

            return _objEmployee.UpsertEmployee(emp, type);

        }
        public DataTable SearchForEmployee(string empNumber, string empName)
        {
            return _objEmployee.SearchForEmployee(empNumber, empName);
        }

        public List<Menus> GetMenus()
        {
            return _objEmployee.GetMenus();
        }
        public DOL.Employee SearchForEmpMenu(string username)
        {
            return _objEmployee.SearchForEmpMenu(username);
        }


        public string AssignMenus(Menus menus, string empNumber)
        {
            string ret = string.Empty;
            try
            {
                if (_objEmployee.AssignMenus(menus, empNumber))
                {
                    ret = "Assigned Menus to Employee(" + empNumber + ") Succesfully. Please search again to check";
                }

            }
            catch (Exception ex)
            {
                ret = ex.Message;
            }
            return ret;
        }

        public DataTable GetMail(string EmployeeId)
        {
            return _objEmployee.GetMail(EmployeeId);
        }
        public DataTable GetAbnormal(int empId)
        {
            return _objEmployee.GetAbnormal(empId);
        }
        public DataTable GetIncharge(int empId)
        {
            return _objEmployee.GetInchare(empId);
        }
        public DataTable GetDeptHead(int empId)
        {
            return _objEmployee.GetDeptHead(empId);
        }
        public DataTable GetHrHead(int empId)
        {
            return _objEmployee.GetHRHead(empId);
        }
        public int InsertBulkuploadApplyLeave(DataTable employeeleave, string Createdby)
        {
            return _objEmployee.InsertBulkuploadApplyLeave(employeeleave, Createdby);
        }
       public DataTable GetAdhesiveByResultId(int ResultId)
        {
            try
            {
                return _objEmployee.GetAdhesiveByResultId(ResultId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
