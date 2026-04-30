using DOL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CheckListCircuitRecord
    {
        DbClass _dbClass;

        public CheckListCircuitRecord()
        {
            _dbClass = DbClass.GetInstance();
        }

        public DataTable GetFormByRecord(int LineId, int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@LineId",LineId),
                                          new SqlParameter("@ProjectId",ProjectId)
                                     };
                dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByRecord",parms);
            }
            catch (Exception)
            {

                throw;
            }



            return dt;
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
            List<Shift> listLine = new List<Shift>();
            DataTable dt = new DataTable();
            try
            {
                dt = _dbClass.ExecuteProcedureForDataTable("ipqc.GetShift");
                foreach (DataRow dr in dt.Rows)
                {
                    listLine.Add(new Shift { ShiftId = Convert.ToInt16(dr[0]), ShiftName = dr[1].ToString() });
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listLine;
        }

        public int InsertCheckListRecordResult(DataTable dtChecklist, string userId, int LineId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy,int ModelId,int PartId)
        {
            int i = 0;
            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@Checklist",dtChecklist),
                                         new SqlParameter("@Createdby",userId),
                                         new SqlParameter("@LineId",LineId),
                                         new SqlParameter("@ProjectId",ProjectId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };

                i = _dbClass.ExecuteNonQueryWithParameter("ipqc.InsertCheckListCircuitRecResult", parmeters);
            }
            catch (Exception)
            {
                
                throw;
            }
          

            return i;
        }

        public List<DOL.Project> GetProject()
        {
            List<DOL.Project> listProject = new List<DOL.Project>();


            try
            {

                DataTable dt = _dbClass.ExecuteProcedureForDataTable("[ipqc].[GetProject]");
                foreach (DataRow dr in dt.Rows)
                {
                    listProject.Add(new DOL.Project { ProjectId = Convert.ToInt32(dr["ProjectId"]), ProjectName = dr["ProjectName"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listProject;
        }

        

        public List<DOL.A246CMachines> GetA246CMachines()
        {
            List<DOL.A246CMachines> listProject = new List<DOL.A246CMachines>();


            try
            {

                DataTable dt = _dbClass.ExecuteProcedureForDataTable("[ipqc].[GetA246CMachines]");
                foreach (DataRow dr in dt.Rows)
                {
                    listProject.Add(new DOL.A246CMachines { MachineId = Convert.ToInt32(dr["MachineId"]), Machine = dr["Machine"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listProject;
        }

        public List<DOL.SRS> GetSRS()
        {
            List<DOL.SRS> listProject = new List<DOL.SRS>();


            try
            {

                DataTable dt = _dbClass.ExecuteProcedureForDataTable("[ipqc].[GetSRS]");
                foreach (DataRow dr in dt.Rows)
                {
                    listProject.Add(new DOL.SRS { SRId = Convert.ToInt32(dr["SRId"]), SR = dr["SR"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listProject;
        }

        public List<DOL.BootC70> GetBootC70(int ProjectId)
        {
            List<DOL.BootC70> listProject = new List<DOL.BootC70>();


            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@ProjectId",ProjectId),
                                        
                                     };


                DataTable dt = _dbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetBootC70]",parmeters);
                foreach (DataRow dr in dt.Rows)
                {
                    listProject.Add(new DOL.BootC70 { BootId = Convert.ToInt32(dr["BootId"]), Boot = dr["Boot"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listProject;
        }

        public List<DOL.BootC91> GetBootC91(int ProjectId)
        {
            List<DOL.BootC91> listProject = new List<DOL.BootC91>();


            try
            {

                SqlParameter[] parmeters ={
                                         new SqlParameter("@ProjectId",ProjectId),
                                        
                                     };

                DataTable dt = _dbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetBootC91]",parmeters);
                foreach (DataRow dr in dt.Rows)
                {
                    listProject.Add(new DOL.BootC91 { BoottId = Convert.ToInt32(dr["BoottId"]), Boott = dr["Boott"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listProject;
        }

        public List<DOL.PlugShellC70> GetPlugShellC70(int ProjectId)
        {
            List<DOL.PlugShellC70> listProject = new List<DOL.PlugShellC70>();


            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@ProjectId",ProjectId),
                                        
                                     };

                DataTable dt = _dbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetPlugShellC70]", parmeters);
                foreach (DataRow dr in dt.Rows)
                {
                    listProject.Add(new DOL.PlugShellC70 { PlugId = Convert.ToInt32(dr["PlugId"]), PlugShell = dr["PlugShell"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listProject;
        }

        public List<DOL.PlugShellC91> GetPlugShellC91(int ProjectId)
        {
            List<DOL.PlugShellC91> listProject = new List<DOL.PlugShellC91>();


            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@ProjectId",ProjectId),
                                        
                                     };


                DataTable dt = _dbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetPlugShellC91]", parmeters);
                foreach (DataRow dr in dt.Rows)
                {
                    listProject.Add(new DOL.PlugShellC91 { PlugShellId = Convert.ToInt32(dr["PlugShellId"]), PlugShelll = dr["PlugShelll"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listProject;
        }

        public List<DOL.FacePlateC70> GetFacePlateC70(int ProjectId)
        {
            List<DOL.FacePlateC70> listProject = new List<DOL.FacePlateC70>();


            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@ProjectId",ProjectId),
                                        
                                     };

                DataTable dt = _dbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetFacePlateC70]", parmeters);
                foreach (DataRow dr in dt.Rows)
                {
                    listProject.Add(new DOL.FacePlateC70 { FacePlateId = Convert.ToInt32(dr["FacePlateId"]), FacePlate = dr["FacePlate"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listProject;
        }

        public List<DOL.FacePlateC91> GetFacePlateC91(int ProjectId)
        {
            List<DOL.FacePlateC91> listProject = new List<DOL.FacePlateC91>();


            try
            {

                SqlParameter[] parmeters ={
                                         new SqlParameter("@ProjectId",ProjectId),
                                        
                                     };
                DataTable dt = _dbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetFacePlateC91]", parmeters);
                foreach (DataRow dr in dt.Rows)
                {
                    listProject.Add(new DOL.FacePlateC91 { FaceePlateId = Convert.ToInt32(dr["FaceePlateId"]), FacePlate = dr["FacePlate"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listProject;
        }

        public List<DOL.Cable> GetCable(int ProjectId)
        {
            List<DOL.Cable> listProject = new List<DOL.Cable>();


            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@ProjectId",ProjectId),
                                        
                                     };


                DataTable dt = _dbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetCable]",parmeters);
                foreach (DataRow dr in dt.Rows)
                {
                    listProject.Add(new DOL.Cable { CableId = Convert.ToInt32(dr["CableId"]), Cablee = dr["Cablee"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listProject;
        }

        public List<DOL.PaperCollar> GetPaperCollar(int ProjectId)
        {
            List<DOL.PaperCollar> listProject = new List<DOL.PaperCollar>();


            try
            {

                SqlParameter[] parmeters ={
                                         new SqlParameter("@ProjectId",ProjectId),
                                        
                                     };

                DataTable dt = _dbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetPaperCollar]", parmeters);
                foreach (DataRow dr in dt.Rows)
                {
                    listProject.Add(new DOL.PaperCollar { CollarId = Convert.ToInt32(dr["CollarId"]), Collar = dr["Collar"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listProject;
        }

        public List<DOL.SRS> GetSR(int ProjectId)
        {
            List<DOL.SRS> listProject = new List<DOL.SRS>();


            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@ProjectId",ProjectId),
                                        
                                     };

                DataTable dt = _dbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetSR]", parmeters);
                foreach (DataRow dr in dt.Rows)
                {
                    listProject.Add(new DOL.SRS { SRId = Convert.ToInt32(dr["SRId"]), SR = dr["SR"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listProject;
        }



        public List<DOL.InspectorCategory> GetInspectorcategory()
        {
            List<DOL.InspectorCategory> listProject = new List<DOL.InspectorCategory>();


            try
            {

                DataTable dt = _dbClass.ExecuteProcedureForDataTable("[ipqc].[GetInspectorcategory]");
                foreach (DataRow dr in dt.Rows)
                {
                    listProject.Add(new DOL.InspectorCategory { categoryId = Convert.ToInt32(dr["categoryId"]), category = dr["category"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listProject;
        }

        public List<DOL.ModelNo> GetModelNo()
        {
            List<DOL.ModelNo> listProject = new List<DOL.ModelNo>();


            try
            {

                DataTable dt = _dbClass.ExecuteProcedureForDataTable("[ipqc].[GetModelNo]");
                foreach (DataRow dr in dt.Rows)
                {
                    listProject.Add(new DOL.ModelNo { ModelId = Convert.ToInt32(dr["ModelId"]), Model = dr["Model"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listProject;
        }





        public List<DOL.Exponent> GetExponent()
        {
            List<DOL.Exponent> listProject = new List<DOL.Exponent>();


            try
            {

                DataTable dt = _dbClass.ExecuteProcedureForDataTable("[ipqc].[GetExponent]");
                foreach (DataRow dr in dt.Rows)
                {
                    listProject.Add(new DOL.Exponent { ExpId = Convert.ToInt32(dr["ExpId"]), Exponents = dr["Exponents"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listProject;
        }

        public List<DOL.Result> GetResult()
        {
            List<DOL.Result> listProject = new List<DOL.Result>();


            try
            {

                DataTable dt = _dbClass.ExecuteProcedureForDataTable("[ipqc].[GetResult]");
                foreach (DataRow dr in dt.Rows)
                {
                    listProject.Add(new DOL.Result { StatusId = Convert.ToInt32(dr["StatusId"]), Status = dr["Status"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listProject;
        }


        public List<DOL.Adhesivee> GetAdhesive()
        {
            List<DOL.Adhesivee> listProject = new List<DOL.Adhesivee>();


            try
            {
                
                DataTable dt = _dbClass.ExecuteProcedureForDataTable("[ipqc].[GetAdhesive]");
                foreach (DataRow dr in dt.Rows)
                {
                    listProject.Add(new DOL.Adhesivee { AdhesiveId = Convert.ToInt32(dr["AdhesiveId"]), Adhesive = dr["Adhesive"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listProject;
        }

        public List<DOL.TempRange> GetTempRange()
        {
            List<DOL.TempRange> listProject = new List<DOL.TempRange>();


            try
            {

                DataTable dt = _dbClass.ExecuteProcedureForDataTable("[ipqc].[GetTemparatureCurve]");
                foreach (DataRow dr in dt.Rows)
                {
                    listProject.Add(new DOL.TempRange { TempId = Convert.ToInt32(dr["TempId"]), RangeName = dr["RangeName"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listProject;
        }


    }


    
    public class FirstArticleInspection
    {
        DbClass _dbClass;

        public FirstArticleInspection()
        {
            _dbClass = DbClass.GetInstance();
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



        public int InsertCheckListFirstArticleInspection(DataTable dtChecklist1, string userId, int LineId, int ProjectId,string ProdLineLeader,string CheckedBy,string ApprovedBy, int Modelid, int PartId, string ProductName, string WorkOrder, string DrawingVersion, string PackVersion, string SamplingQty)
        {
            int i = 0;
            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@Checklist1",dtChecklist1),
                                         new SqlParameter("@Createdby",userId),
                                         new SqlParameter("@LineId",LineId),
                                         new SqlParameter("@ProjectId",ProjectId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@Modelid",Modelid),
                                         new SqlParameter("@PartId",PartId),
                                         new SqlParameter("@ProductName",ProductName),
                                         new SqlParameter("@WorkOrder",WorkOrder),
                                         new SqlParameter("@DrawingVersion",DrawingVersion),
                                         new SqlParameter("@PackVersion",PackVersion),
                                         new SqlParameter("@SamplingQty",SamplingQty)
                                     };

                i = _dbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkFirstAirticleInspectionCheckList", parmeters);
            }
            catch (Exception)
            {

                throw;
            }


            return i;
        }

        public int InsertBulkFirstAirticleSpecCheckList2(DataTable dtChecklist1, string userId, int LineId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId, string ProductName, string WorkOrder, string DrawingVersion, string PackVersion, string SamplingQty)
        {
            int i = 0;
            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@Checklist2",dtChecklist1),
                                         new SqlParameter("@Createdby",userId),
                                         new SqlParameter("@LineId",LineId),
                                         new SqlParameter("@ProjectId",ProjectId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@Modelid",ModelId),
                                         new SqlParameter("@PartId",PartId),
                                         new SqlParameter("@ProductName",ProductName),
                                         new SqlParameter("@WorkOrder",WorkOrder),
                                         new SqlParameter("@DrawingVersion",DrawingVersion),
                                         new SqlParameter("@PackVersion",PackVersion),
                                         new SqlParameter("@SamplingQty",SamplingQty)
                                     };

                i = _dbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkFirstAirticleInspectionCheckList2New", parmeters);
            }
            catch (Exception)
            {

                throw;
            }


            return i;
        }

        public int InsertBulkFirstAirticleInspectionCheckList2(DataTable dtChecklist1, string userId, int LineId, int ProjectId, int ModelId, int PartId)
        {
            int i = 0;
            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@Checklist1",dtChecklist1),
                                         new SqlParameter("@Createdby",userId),
                                         new SqlParameter("@LineId",LineId),
                                         new SqlParameter("@ProjectId",ProjectId),
                                         new SqlParameter("@Modelid",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };

                i = _dbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkFirstAirticleInspectionCheckList2", parmeters);
            }
            catch (Exception)
            {

                throw;
            }


            return i;
        }

        public int InsertCheckListFirstArticleInspections(DataTable dtChecklist1, string userId, int LineId, int ProjectId)
        {
            int i = 0;
            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@Checklist1",dtChecklist1),
                                         new SqlParameter("@Createdby",userId),
                                         new SqlParameter("@LineId",LineId),
                                         new SqlParameter("@ProjectId",ProjectId)
                                     };

                i = _dbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkFirstAirticleInspectionCheckList2", parmeters);
            }
            catch (Exception)
            {

                throw;
            }


            return i;
        }

        public DataTable GetFormByFirstArticleInspection(int LineId, int ProjectId)
        {
            DataTable ds = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@LineId",LineId),
                                          new SqlParameter("@ProjectId",ProjectId)
                                     };
                ds = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByFirstAirticleInspec", parms);
            }
            catch (Exception)
            {

                throw;
            }



            return ds;
        }

        public DataTable GetFormByFirstAirticleInspec2(int LineId, int ProjectId)
        {
            DataTable ds = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@LineId",LineId),
                                          new SqlParameter("@ProjectId",ProjectId)
                                     };
                ds = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByFirstAirticleInspec2", parms);
            }
            catch (Exception)
            {

                throw;
            }



            return ds;
        }
    }
}
