using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DOL;
namespace BAL
{
    public class CircuitRecord
    {
        DAL.CircuitRecord _ObjCircuitRecord = new DAL.CircuitRecord();

        public int InsertCircuitRecord(DOL.CircuitRecord cs)
        {
            try
            {
                return _ObjCircuitRecord.InsertCircuitRecord(cs);
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        public List<DOL.Project> GetProject()
        {
            try
            {
                return _ObjCircuitRecord.GetProject();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
