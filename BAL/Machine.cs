using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DOL;
using System.Data;
namespace BAL
{
    public class Machine
    {
        DAL.Machine _ObjMachine = new DAL.Machine();

        public int InsertMachine(DOL.Machine m)
        {
            return _ObjMachine.InsertMachine(m);
        }

        public List<DOL.Machine> GetMachine()
        {
            return _ObjMachine.GetMachine();
        }

         public int UpdateMachine(DOL.Machine m)
        {
            return _ObjMachine.UpdateMachine(m);
        }
    }

    public class Category
    {
        DAL.Categoryy _ObjCategory = new DAL.Categoryy();

        public int InsertCategory(DOL.Categoryy c)
        {
            return _ObjCategory.InsertCategory(c);
        }

        public List<DOL.Categoryy> GetCategory()
        {
            return _ObjCategory.GetCategory();
        }

        public DataTable GetCategoryByMachine(int MachineId)
        {
            return _ObjCategory.GetCategoryByMachine(MachineId);
        }

        public DataTable GetMachineByProject(int ProjectId)
        {
            return _ObjCategory.GetMachineByProject(ProjectId);
        }
    }

    public class Activityy
    {
        DAL.Activityy _ObjAcivity = new DAL.Activityy();

        public int InsertActivity(DOL.Activityy a)
        {
            return _ObjAcivity.InsertActivity(a);
        }

        public List<DOL.Activityy> GetActivity()
        {
            return _ObjAcivity.GetActivity();
        }
        public DataTable GetActivityByCategory(int CatId)
        {
            return _ObjAcivity.GetActivityByCategory(CatId);
        }

    }

    public class Parts
    {
        DAL.Parts _ObjParts = new DAL.Parts();

        public int InsertParts(DOL.Parts p)
        {
            return _ObjParts.InsertParts(p);
        }
        public List<DOL.Parts> GetParts()
        {
            return _ObjParts.GetParts();
        }
    }

    public class CheckPoints
    {
        DAL.CheckPoints _ObjCheckPoint = new DAL.CheckPoints();

        public int InsertCheckPoint(DOL.CheckPoints c)
        {
            return _ObjCheckPoint.InsertCheckPoint(c);
        }

    }
}
