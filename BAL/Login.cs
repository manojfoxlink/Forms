using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOL;
using DAL;
using System.Data;

namespace BAL
{
  public  class Login
    {
        DAL.Login _ObjLogin = new DAL.Login();

        public DataSet GetLogInDetails(string UserId, string Password)
        {
            return _ObjLogin.GetLogInDetails(UserId, Password);
        }

        public int InsertLogIn(DOL.Login l)
        {
            return _ObjLogin.InsertLogIn(l);
        }

        public DataTable SearchForLogIn(string UserId, string Password)
        {
            return _ObjLogin.SearchForLogIn(UserId, Password);
        }
    }
}
