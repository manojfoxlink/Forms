using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
       public class lasersizeBAL
       {
           DAL.LasersizeDAL _objLaser = new DAL.LasersizeDAL();

           public int Laserengraving (DOL.LaserSize LE)
           {
               try
               {
                   return _objLaser.Laserengraving(LE);
               }
               catch (Exception)
               {
                   
                   throw;
               }
               
           }

           public DataTable GetLaserSize(int LineId)
           {
               try
               {
                   return _objLaser.GetLaserSize(LineId);
               }
               catch (Exception)
               {
                   
                   throw;
               }
           }

       }
}
