using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOL
{
    public class Employee
    {
        #region Properties
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Password { get; set; }
        public string CreatedBy { get; set; }
        public string Designation { get; set; }
        public string FilePath { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
        public List<Menus> Menuss { get; set; }



        #endregion
    }
}
