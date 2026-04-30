using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOL
{
    public class Login
    {
        public int Id {get;set;}

        public string UserId { get; set; }

        public string Password { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}
