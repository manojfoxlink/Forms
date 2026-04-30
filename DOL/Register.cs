using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOL
{
    public class Register
    {
        public int userId { get; set; }

        public string UserName { get; set; }

        public string PassWord { get; set; }

        public string ConfirmPassWord { get; set; }

        public string Designation { get; set; }

        public string LineNumber { get; set; }
    }

    public class A246CMachines
    {
        public int MachineId { get; set; }

        public string Machine { get; set; }
    }
}
