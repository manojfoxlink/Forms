using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOL;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    public class Machine
    {
        DbClass _DbClass;

        public Machine()
        {
            _DbClass = DbClass.GetInstance();
        }
        public int InsertMachine(DOL.Machine m)
        {
            int result = 0;

            try
            {
                SqlParameter[] sqlparam ={
                                             new SqlParameter("@MachineName",m.MachineName),
                                             new SqlParameter("@ProjectId",m.ProjectId),
                                             new SqlParameter("@CreatedBy",m.CreatedBy),
                                             new SqlParameter("@action","Insert")
                                         };
                result = _DbClass.ExecuteNonQueryWithParameter("epq.GetMachine",sqlparam);
            }
            catch (Exception)
            {
                
                throw;
            }


            return result;
        }
        public int UpdateMachine(DOL.Machine m)
        {
            int result = 0;
            try
            {
                SqlParameter[] sqlparam ={
                                             new SqlParameter("@MachineName",m.MachineName),
                                             new SqlParameter("@action","Update")
                                         };
                result = _DbClass.ExecuteNonQueryWithParameter("epq.GetMachine", sqlparam);
            }
            catch (Exception)
            {
                
                throw;
            }

            return result;
        }

        public List<DOL.Machine> GetMachine()
        {
            List<DOL.Machine> listMachine = new List<DOL.Machine>();


            try
            {

                DataTable dt = _DbClass.ExecuteProcedureForDataTable("epq.GetMachine");
                foreach (DataRow dr in dt.Rows)
                {
                    listMachine.Add(new DOL.Machine { MachineId = Convert.ToInt32(dr["MachineId"]), MachineName = dr["MachineName"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listMachine;
        }
    }

    public class Categoryy
    {
        DbClass _dbClass;

        public Categoryy()
        {
            _dbClass = DbClass.GetInstance();
        }

        public int InsertCategory(DOL.Categoryy c)
        {
            int result=0;

            try
            {
                SqlParameter[] sqlparam ={
                                             new SqlParameter("@Category",c.Category),
                                             new SqlParameter("@MachineId",c.MachineId),
                                             new SqlParameter("@ProjectId",c.ProjectId),
                                             new SqlParameter("@CreatedBy",c.CreatedBy),
                                             new SqlParameter("@action","insert")
                                         };
                result = _dbClass.ExecuteNonQueryWithParameter("[epq].[GetCategory]", sqlparam);
            }
            catch (Exception)
            {
                
                throw;
            }

            return result;
        }


        public List<DOL.Categoryy> GetCategory()
        {
            List<DOL.Categoryy> listCategory = new List<DOL.Categoryy>();


            try
            {

                DataTable dt = _dbClass.ExecuteProcedureForDataTable("[epq].[GetCategory]");
                foreach (DataRow dr in dt.Rows)
                {
                    listCategory.Add(new DOL.Categoryy { CatId = Convert.ToInt32(dr["CatId"]), Category = dr["Category"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listCategory;
        }

        public DataTable GetCategoryByMachine(int MachineId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlparams ={
                                              new SqlParameter("MachineId",@MachineId),
                                         };

                dt = _dbClass.ExecuteProcedureWithParameterForDataTable("epq.GetCategoryByMachine", sqlparams);
            }
            catch (Exception)
            {
                
                throw;
            }

            return dt;
        }

        public DataTable GetMachineByProject(int ProjectId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlparams ={
                                              new SqlParameter("ProjectId",@ProjectId),
                                         };

                dt = _dbClass.ExecuteProcedureWithParameterForDataTable("epq.GetMachineByProject", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }


    }

    public class Activityy
    {
        DbClass _dbClass;

        public Activityy()
        {
            _dbClass = DbClass.GetInstance();
        }

        public int InsertActivity(DOL.Activityy a)
        {
            int result = 0;
            try
            {
                SqlParameter[] SqlParam = {
                                          new SqlParameter("@Activity",a.Activity),
                                          new SqlParameter("@MachineId",a.MachineId),
                                          new SqlParameter("@ProjectId",a.ProjectId),
                                          new SqlParameter("@CatId",a.CatId),
                                          new SqlParameter("@CreatedBy",a.CreatedBy),
                                          new SqlParameter("@ACTION","INSERT")
                                      };
                result = _dbClass.ExecuteNonQueryWithParameter("[epq].[GetActivity]", SqlParam);
            }
            catch (Exception)
            {
                
                throw;
            }

            return result;
            
        }

        public List<DOL.Activityy> GetActivity()
        {
            List<DOL.Activityy> listActivity = new List<DOL.Activityy>();


            try
            {

                DataTable dt = _dbClass.ExecuteProcedureForDataTable("[epq].[GetActivity]");
                foreach (DataRow dr in dt.Rows)
                {
                    listActivity.Add(new DOL.Activityy { ActivityId = Convert.ToInt32(dr["ActivityId"]), Activity = dr["Activity"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listActivity;
        }

        public DataTable GetActivityByCategory(int CatId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlparams = 

                {
                  new SqlParameter("@CatId",CatId)
                };
                dt = _dbClass.ExecuteProcedureWithParameterForDataTable("[epq].[GetActivityByCategory]", sqlparams);
            }
            catch (Exception)
            {
                
                throw;
            }

            return dt;
        }
    }

    public class Parts
    {
        DbClass _dbClass;
        public Parts()
        {
            _dbClass = DbClass.GetInstance();
        }

        public int InsertParts(DOL.Parts p)
        {
            int result = 0;
            try
            {
                SqlParameter[] SqlParam = {
                                          new SqlParameter("@Sno",p.Sno),
                                          new SqlParameter("@PartOfInspection",p.PartOfInspection),
                                          new SqlParameter("@Freq",p.Freq),
                                          new SqlParameter("@StandardCondition",p.StandardCondition),
                                          new SqlParameter("@ProjectId",p.ProjectId),
                                          new SqlParameter("@MachineId",p.MachineId),
                                          new SqlParameter("@CatId",p.CatId),
                                          new SqlParameter("@ActivityId",p.ActivityId),
                                          new SqlParameter("@CreatedBy",p.CreatedBy),
                                          new SqlParameter("@ACTION","INSERT")
                                      };
                result = _dbClass.ExecuteNonQueryWithParameter("[epq].[GetParts]", SqlParam);
            }
            catch (Exception)
            {

                throw;
            }

            return result;

        }

        

        public List<DOL.Parts> GetParts()
        {
            List<DOL.Parts> listPart = new List<DOL.Parts>();


            try
            {

                DataTable dt = _dbClass.ExecuteProcedureForDataTable("[epq].[GetParts]");
                foreach (DataRow dr in dt.Rows)
                {
                    listPart.Add(new DOL.Parts { PartsId = Convert.ToInt32(dr["PartsId"]), PartOfInspection = dr["PartOfInspection"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listPart;
        }
    }

    public class CheckPoints
    {
        DbClass _dbClass;
        public CheckPoints()
        {
            _dbClass = DbClass.GetInstance();
        }

        public int InsertCheckPoint(DOL.CheckPoints c)
        {
            int result = 0;
            try
            {
                SqlParameter[] sqlparams ={
                                         new SqlParameter("@ChckPoint",c.ChckPoint),
                                         new SqlParameter("@MachineId",c.MachineId),
                                         new SqlParameter("@ProjectId",c.ProjectId),
                                         new SqlParameter("@CreatedBy",c.CreatedBy),
                                         new SqlParameter("@ACTION","INSERT")
                                     };
                result = _dbClass.ExecuteNonQueryWithParameter("[epq].[GetCheckPoint]", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public List<DOL.Machine> GetMachine()
        {
            List<DOL.Machine> listMachine = new List<DOL.Machine>();
            DataTable dt = new DataTable();
            try
            {
                dt = _dbClass.ExecuteProcedureForDataTable("epq.GetMachine");
                foreach (DataRow dr in dt.Rows)
                {
                    listMachine.Add(new DOL.Machine { MachineId = Convert.ToInt16(dr[0]), MachineName = dr[1].ToString() });
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listMachine;
        }
    }

    public class CheckPointsResult
    {
        DbClass _dbClass;

        public CheckPointsResult()
        {
            _dbClass = DbClass.GetInstance();
        }

        public List<DOL.Machine> GetMachine()
        {
            List<DOL.Machine> listMachine = new List<DOL.Machine>();
            DataTable dt = new DataTable();
            try
            {
                dt = _dbClass.ExecuteProcedureForDataTable("epq.GetMachine");
                foreach (DataRow dr in dt.Rows)
                {
                    listMachine.Add(new DOL.Machine { MachineId = Convert.ToInt16(dr[0]), MachineName = dr[1].ToString() });
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listMachine;
        }

        public List<Line> GetLine()
        {
            List<Line> listLine = new List<Line>();
            DataTable dt = new DataTable();
            try
            {
                dt = _dbClass.ExecuteProcedureForDataTable("ipqc.GetLine");
                foreach (DataRow dr in dt.Rows)
                {
                    listLine.Add(new Line { LineId = Convert.ToInt16(dr[0]), LineName = dr[1].ToString() });
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listLine;
        }

        public List<Shift> GetShift()
        {
            List<Shift> listShift = new List<Shift>();
            DataTable dt = new DataTable();
            try
            {
                dt = _dbClass.ExecuteProcedureForDataTable("[ipqc].[GetShift]");
                foreach (DataRow dr in dt.Rows)
                {
                    listShift.Add(new Shift { ShiftId = Convert.ToInt16(dr[0]), ShiftName = dr[1].ToString() });
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listShift;
        }

        public int InsertCheckListCheckPointResult(DataTable dtChecklist, string userId, int LineId, string DRILeader, string LineLeader)
        {
            int i = 0;
            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@Checklist",dtChecklist),
                                               new SqlParameter("@CreatedBy",userId),
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@DRILeader",DRILeader),
                                               new SqlParameter("@LineLeader",LineLeader)
                                           };
                i = _dbClass.ExecuteNonQueryWithParameter("epq.InsertBulkCheckPoints", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }
            return i;
        }

        public DataTable GetFormsByCheckPoints(int LineId, int MachineId,int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@MachineId",MachineId),
                                               new SqlParameter("@ProjectId",ProjectId)
                                           };
                dt = _dbClass.ExecuteProcedureWithParameterForDataTable("[epq].[GetFormsByCheckPoints]", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

    }
}
