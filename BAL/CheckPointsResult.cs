using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using DOL;
namespace BAL
{
    public class CheckPointsResult
    {
        DAL.CheckPointsResult _objCheckPointResult = new DAL.CheckPointsResult();

         public List<DOL.Line> GetLine()
         {
            try
            {
                return _objCheckPointResult.GetLine();
            }
            catch (Exception)
            {
                
                throw;
            }
         }

        public List<DOL.Machine> GetMachine()
         {
             try
             {
                 return _objCheckPointResult.GetMachine();
             }
             catch (Exception)
             {
                 
                 throw;
             }
         }
        public List<Shift> GetShift()
        {
            try
            {
                return _objCheckPointResult.GetShift();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertCheckListCheckPointResult(DataTable dtChecklist, string userId, int LineId, string DRILeader, string LineLeader)
        {
            try
            {
                return _objCheckPointResult.InsertCheckListCheckPointResult(dtChecklist, userId, LineId, DRILeader,LineLeader);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetFormsByCheckPoints(int LineId, int MachineId,int ProjectId)
        {
            try
            {
                return _objCheckPointResult.GetFormsByCheckPoints(LineId, MachineId, ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
