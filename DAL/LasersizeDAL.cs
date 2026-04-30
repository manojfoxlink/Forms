using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DOL;
using System.Data;
namespace DAL
{
    public class LasersizeDAL
    {
        DbClass _Dbclass;
 
        
            public LasersizeDAL()
         {
             _Dbclass = DbClass.GetInstance();

         }
             
              public int Laserengraving (DOL.LaserSize LS)
            {
                SqlParameter[] sqlparams ={
                                                new SqlParameter("@Locations",LS.Locations),
                                                new SqlParameter("@Specification",LS.Specification),
                                                new SqlParameter("@Minimum",LS.Minimum),
                                                new SqlParameter("@Maximum",LS.Maximum),
                                                new SqlParameter("@CreatedBy",LS.CreatedBy),
                                                new SqlParameter("@ProjectId",LS.ProjectId),
                                                new SqlParameter("@action","insert")
                                            };
                int result = _Dbclass.ExecuteNonQueryWithParameter("ipqc.GetLaserengravingsize", sqlparams);
                    return result;


            }

              public DataTable GetLaserSize(int LineId)
              {
                  DataTable dt = new DataTable();
                  try
                  {
                      SqlParameter[] param ={
                                          new SqlParameter("@LineId",LineId),
                                      };
                      dt = _Dbclass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormLaserbyLineId", param);
                  }
                  catch (Exception)
                  {

                      throw;
                  }
                  return dt;
              }


              
    }

    


}
