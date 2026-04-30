using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BAL;
using DOL;
using DAL;
namespace BAL
{
    public class Forms
    {
        FormsDAL _checkForms = new FormsDAL();

        //public DataTable GetFromsLowers()
        //{
        //    return _checkForms.GetFromsLowers();
        //}
        public DataTable GetFromsParameters()
        {
            return _checkForms.GetFromsParameters();
        }
        public DataTable GetFromsProject()
        {
            return _checkForms.GetFromsProject();
        }
        //public DataTable GetFormSubStation()
        //{
        //    return _checkForms.GetFormSubStation();
        //}

        public DataTable GetFromsSubStation()
        {
            return _checkForms.GetFromsSubStation();
        }

        //public DataTable GetFromsUpper()
        //{
        //    return _checkForms.GetFromsUpper();
        //}
        //public int InsertCheckFromsResult(DataTable dtCheckListItem, string userId, int FormId)
        //{
        //    return _checkForms.InsertCheckFromsResult(dtCheckListItem, userId, FormId);
        //}
        //public int UpdateCheckFromsResult(DataTable dtCheckListItem, string userId, int FormId)
        //{
        //    return _checkForms.UpdateCheckFromsResult(dtCheckListItem, userId, FormId);
        //}
        //public int IQCandWHsentMail(int wareHouseid, string Type)
        //{
        //    return _checkForms.IQCandWHsentMail(wareHouseid, Type);
        //}

    }
    
}
