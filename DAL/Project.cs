using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOL;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    #region Employee Class Defined in the BAL
    public class Project
    {
        DbClass _DbClass;

        public Project()
        {
            _DbClass = DbClass.GetInstance();
        }

        public DataSet GetProjectDetails(string ProjectName)
        {
            List<DOL.Project> listEmp = new List<DOL.Project>();
            DataSet ds = new DataSet();

            try
            {
                SqlParameter[] sqlParams =  {
                                           new SqlParameter( "@ProjectName", ProjectName )                                           
                                       };


            }
            catch (Exception)
            {

                throw;
            }
            return ds;
        }
        public List<DOL.Project> GetProject()
        {
            List<DOL.Project> listProject = new List<DOL.Project>();


            try
            {

                DataTable dt = _DbClass.ExecuteProcedureForDataTable("[ipqc].[GetProject]");
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

        public List<DOL.ProdVerifiedBy> GetVerifiedBy()
        {
            List<DOL.ProdVerifiedBy> listProject = new List<DOL.ProdVerifiedBy>();


            try
            {

                DataTable dt = _DbClass.ExecuteProcedureForDataTable("[dbo].[GetverifedBy]");
                foreach (DataRow dr in dt.Rows)
                {
                    listProject.Add(new DOL.ProdVerifiedBy { VerifiedId = Convert.ToInt32(dr["VerifiedId"]), Verified = dr["Verified"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listProject;
        }

        public List<DOL.ProdApprovedBy> GetApprovedBy()
        {
            List<DOL.ProdApprovedBy> listProject = new List<DOL.ProdApprovedBy>();


            try
            {

                DataTable dt = _DbClass.ExecuteProcedureForDataTable("[dbo].[GetApprovedBy]");
                foreach (DataRow dr in dt.Rows)
                {
                    listProject.Add(new DOL.ProdApprovedBy { ApprovedId = Convert.ToInt32(dr["ApprovedId"]), Approved = dr["Approved"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listProject;
        }

        public List<DOL.ProdAuditBy> GetAuditBy()
        {
            List<DOL.ProdAuditBy> listProject = new List<DOL.ProdAuditBy>();


            try
            {

                DataTable dt = _DbClass.ExecuteProcedureForDataTable("[dbo].[GetVerifyApprovedAudit]");
                foreach (DataRow dr in dt.Rows)
                {
                    listProject.Add(new DOL.ProdAuditBy { AuditId = Convert.ToInt32(dr["AuditId"]), Auditor = dr["Auditor"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listProject;
        }

        public List<DOL.prodCheckedBy> GetCheckedBy()
        {
            List<DOL.prodCheckedBy> listProject = new List<DOL.prodCheckedBy>();


            try
            {

                DataTable dt = _DbClass.ExecuteProcedureForDataTable("[dbo].[GetCheckedBy]");
                foreach (DataRow dr in dt.Rows)
                {
                    listProject.Add(new DOL.prodCheckedBy { CheckedId = Convert.ToInt32(dr["CheckedId"]), Checked = dr["Checked"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listProject;
        }

        public List<DOL.MasterMenuss> GetMasterMenus()
        {
            List<DOL.MasterMenuss> listProject = new List<DOL.MasterMenuss>();


            try
            {

                DataTable dt = _DbClass.ExecuteProcedureForDataTable("[ipqc].[GetMasterMenus]");
                foreach (DataRow dr in dt.Rows)
                {
                    listProject.Add(new DOL.MasterMenuss { MenuId = Convert.ToInt32(dr["MenuId"]), Menu = dr["Menu"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listProject;
        }



        public List<DOL.DestructiveInspectionItem> GetDestructiveInspection()
        {
            List<DOL.DestructiveInspectionItem> listProject = new List<DOL.DestructiveInspectionItem>();


            try
            {

                DataTable dt = _DbClass.ExecuteProcedureForDataTable("[ipqc].[GetDestructiveInspection]");
                foreach (DataRow dr in dt.Rows)
                {
                    listProject.Add(new DOL.DestructiveInspectionItem { InspectionId = Convert.ToInt32(dr["InspectionId"]), Inspection = dr["Inspection"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listProject;
        }

        public List<DOL.Sections> GetSection()
        {
            List<DOL.Sections> listProject = new List<DOL.Sections>();


            try
            {

                DataTable dt = _DbClass.ExecuteProcedureForDataTable("[ipqc].[GetSection]");
                foreach (DataRow dr in dt.Rows)
                {
                    listProject.Add(new DOL.Sections { SectionId = Convert.ToInt32(dr["SectionId"]), Section = dr["Section"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listProject;
        }

        public List<DOL.Frequen> GetFreq()
        {
            List<DOL.Frequen> listProject = new List<DOL.Frequen>();


            try
            {

                DataTable dt = _DbClass.ExecuteProcedureForDataTable("[ipqc].[GetFreq]");
                foreach (DataRow dr in dt.Rows)
                {
                    listProject.Add(new DOL.Frequen { FreqId = Convert.ToInt32(dr["FreqId"]), Freq = dr["Freq"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listProject;
        }

        public List<DOL.DestructiveFrequency> GetDestructiveFrequency()
        {
            List<DOL.DestructiveFrequency> listProject = new List<DOL.DestructiveFrequency>();


            try
            {

                DataTable dt = _DbClass.ExecuteProcedureForDataTable("[ipqc].[GetDestructiveFrequency]");
                foreach (DataRow dr in dt.Rows)
                {
                    listProject.Add(new DOL.DestructiveFrequency { FrequencyId = Convert.ToInt32(dr["FrequencyId"]), Frequency = dr["Frequency"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listProject;
        }

        public List<DOL.Periodss> GetPeriodss()
        {
            List<DOL.Periodss> listProject = new List<DOL.Periodss>();


            try
            {

                DataTable dt = _DbClass.ExecuteProcedureForDataTable("[ipqc].[GetPeriods]");
                foreach (DataRow dr in dt.Rows)
                {
                    listProject.Add(new DOL.Periodss { PeriodId = Convert.ToInt32(dr["PeriodId"]), Period = dr["Period"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listProject;
        }

        public List<DOL.PartToInspect> GetPartToInspect()
        {
            List<DOL.PartToInspect> listProject = new List<DOL.PartToInspect>();


            try
            {

                DataTable dt = _DbClass.ExecuteProcedureForDataTable("[ipqc].[GetPartToInspect]");
                foreach (DataRow dr in dt.Rows)
                {
                    listProject.Add(new DOL.PartToInspect { InspectId = Convert.ToInt32(dr["InspectId"]), parts = dr["parts"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listProject;
        }

        public List<DOL.Inspectors> GetInspectors()
        {
            List<DOL.Inspectors> listProject = new List<DOL.Inspectors>();


            try
            {

                DataTable dt = _DbClass.ExecuteProcedureForDataTable("[ipqc].[GetInspectors]");
                foreach (DataRow dr in dt.Rows)
                {
                    listProject.Add(new DOL.Inspectors { InspecId = Convert.ToInt32(dr["InspecId"]), Inspector = dr["Inspector"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listProject;
        }
        public List<Operations> GetOperations()
        {
            List<DOL.Operations> listProject = new List<DOL.Operations>();


            try
            {

                DataTable dt = _DbClass.ExecuteProcedureForDataTable("[ipqc].[GetOperation]");
                foreach (DataRow dr in dt.Rows)
                {
                    listProject.Add(new DOL.Operations { OperationId = Convert.ToInt32(dr["OperationId"]), Operation = dr["Operation"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listProject;
        }

        public List<AuditCheckPoint> GetAuditCheckPoints()
        {
            List<DOL.AuditCheckPoint> listProject = new List<DOL.AuditCheckPoint>();


            try
            {

                DataTable dt = _DbClass.ExecuteProcedureForDataTable("[ipqc].[GetAuditCheckpoint]");
                foreach (DataRow dr in dt.Rows)
                {
                    listProject.Add(new DOL.AuditCheckPoint { CheckId = Convert.ToInt32(dr["CheckId"]), CheckPoints = dr["CheckPoints"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listProject;
        }

        public int InsertProject(DOL.Project pro)
        {
            int result = 0;
            try
            {
                SqlParameter[] sqlParams = { 
                                                           
                                               new SqlParameter("@ProjectName", pro.ProjectName),
                                               new SqlParameter("@CreatedBy", pro.CreatedBy),                                                
                                               new SqlParameter("@action","Insert"),            
                                               
                                            };
                //int result = _DbClass.ExecuteNonQueryWithParameter("InsertProject", sqlParams);

                result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetProject", sqlParams);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
        public int InsertOperations(DOL.Operations pro)
        {
            int result = 0;
            try
            {
                SqlParameter[] sqlParams = { 
                                                           
                                               new SqlParameter("@Process", pro.Process),
                                               new SqlParameter("@Operation", pro.Operation),
                                               new SqlParameter("@CreatedBy", pro.CreatedBy),
                                               new SqlParameter("@ProjectId", pro.projectId), 
                                               new SqlParameter("@action","Insert"),            
                                               
                                            };
                //int result = _DbClass.ExecuteNonQueryWithParameter("InsertProject", sqlParams);

                result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetOperation", sqlParams);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public int InsertPartToInspect(DOL.PartToInspect pro)
        {
            int result = 0;
            try
            {
                SqlParameter[] sqlParams = { 
                                                           
                                               new SqlParameter("@Sno", pro.Sno),
                                               new SqlParameter("@parts", pro.parts),
                                               new SqlParameter("@CreatedBy", pro.CreatedBy),
                                               new SqlParameter("@ProjectId", pro.ProjectId), 
                                               new SqlParameter("@action","Insert"),            
                                               
                                            };
                //int result = _DbClass.ExecuteNonQueryWithParameter("InsertProject", sqlParams);

                result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetPartToInspect", sqlParams);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public int InsertInspectorDetails(DOL.InspectorDetailss pro)
        {
            int result = 0;
            try
            {
                SqlParameter[] sqlParams = { 
                                                           
                                               new SqlParameter("@InspecId", pro.InspecId),
                                               new SqlParameter("@InspectId", pro.InspectId),
                                               new SqlParameter("@ProjectId", pro.ProjectId), 
                                               new SqlParameter("@CreatedBy", pro.CreatedBy),
                                               new SqlParameter("@action","Insert"),            
                                               
                                            };
                //int result = _DbClass.ExecuteNonQueryWithParameter("InsertProject", sqlParams);

                result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetInspectorDetails", sqlParams);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public int InsertCircuitInspectionItem(DOL.CircuitInspectionItem pro)
        {
            int result = 0;
            try
            {
                SqlParameter[] sqlParams = { 
                                                           
                                               new SqlParameter("@ProjectId", pro.ProjectId),
                                               new SqlParameter("@StationId", pro.StationId),
                                               new SqlParameter("@InspectionItem", pro.InspectionItem), 
                                               new SqlParameter("@CreatedBy", pro.CreatedBy),
                                               new SqlParameter("@action","Insert"),            
                                               
                                            };
                //int result = _DbClass.ExecuteNonQueryWithParameter("InsertProject", sqlParams);

                result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetCircuitInspectionItem", sqlParams);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public int InsertCircuitInspectionSpec(DOL.CircuitInspectionSpec pro)
        {
            int result = 0;
            try
            {
                SqlParameter[] sqlParams = { 
                                               new SqlParameter("@LowerLimit", pro.LowerLimit),
                                               new SqlParameter("@UpperLimit", pro.UpperLimit),
                                               new SqlParameter("@InspectionSpecification", pro.InspectionSpecification),
                                               new SqlParameter("@ProjectId", pro.ProjectId),
                                               new SqlParameter("@StationId", pro.StationId),
                                                  new SqlParameter("@ItemId", pro.ItemId),
                                                  new SqlParameter("@FreqId", pro.FreqId),
                                                  new SqlParameter("@PeriodId", pro.PeriodId),
                                               new SqlParameter("@CreatedBy", pro.CreatedBy),
                                               new SqlParameter("@action","Insert")            
                                               
                                            };
                //int result = _DbClass.ExecuteNonQueryWithParameter("InsertProject", sqlParams);

                result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetCircuitInspectionSpec", sqlParams);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public int InsertDestructiveSpec(DOL.DestructiveSpec pro)
        {
            int result = 0;
            try
            {
                SqlParameter[] sqlParams = { 
                                               new SqlParameter("@ProjectId", pro.ProjectId),
                                               new SqlParameter("@InspectionId", pro.InspectionId),
                                               new SqlParameter("@FrequencyId", pro.FrequencyId),
                                               new SqlParameter("@WireId", pro.WireId),
                                               new SqlParameter("@Spec", pro.Spec),
                                               new SqlParameter("@LSL", pro.LSL),
                                               new SqlParameter("@CreatedBy", pro.CreatedBy),
                                               new SqlParameter("@action","Insert")            
                                               
                                            };
                //int result = _DbClass.ExecuteNonQueryWithParameter("InsertProject", sqlParams);

                result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetDestructiveSpec", sqlParams);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }


        public int InsertCTQPartsToInspect(DOL.CTQPartsToInspect pro)
        {
            int result = 0;
            try
            {
                SqlParameter[] sqlParams = { 
                                               new SqlParameter("@ProjectId", pro.ProjectId),
                                               new SqlParameter("@SNo", pro.SNo),
                                               new SqlParameter("@SectionId", pro.SectionId),
                                               new SqlParameter("@PartToInspect", pro.PartToInspect),
                                               new SqlParameter("@CreatedBy", pro.CreatedBy),
                                               new SqlParameter("@action","Insert")            
                                               
                                            };
                //int result = _DbClass.ExecuteNonQueryWithParameter("InsertProject", sqlParams);

                result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetCTQPartsToInspect", sqlParams);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public int InsertDestructiveWire(DOL.DestructiveWire pro)
        {
            int result = 0;
            try
            {
                SqlParameter[] sqlParams = { 
                                               new SqlParameter("@ProjectId", pro.ProjectId),
                                               new SqlParameter("@InspectionId", pro.InspectionId),
                                               new SqlParameter("@Wire", pro.Wire),
                                               new SqlParameter("@CreatedBy", pro.CreatedBy),
                                               new SqlParameter("@action","Insert")            
                                               
                                            };
                //int result = _DbClass.ExecuteNonQueryWithParameter("InsertProject", sqlParams);

                result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetDestructiveWire", sqlParams);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public int InsertAdhesive(DOL.Adhesivee pro)
        {
            int result = 0;
            try
            {
                SqlParameter[] sqlParams = { 
                                               new SqlParameter("@ProjectId", pro.ProjectId),
                                               new SqlParameter("@Adhesive", pro.Adhesive),
                                               new SqlParameter("@LowerLimit", pro.LowerLimit),
                                               new SqlParameter("@CenterLimit", pro.CenterLimit),
                                               new SqlParameter("@UpperLimit", pro.UpperLimit),
                                               new SqlParameter("@CreatedBy", pro.CreatedBy),
                                               new SqlParameter("@action","Insert")            
                                               
                                            };
                //int result = _DbClass.ExecuteNonQueryWithParameter("InsertProject", sqlParams);

                result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetAdhesive", sqlParams);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public int InsertTemparatureRange(DOL.TempRange pro)
        {
            int result = 0;
            try
            {
                SqlParameter[] sqlParams = { 
                                               new SqlParameter("@ProjectId", pro.ProjectId),
                                               new SqlParameter("@RangeName", pro.RangeName),
                                               new SqlParameter("@Range", pro.Range),
                                               new SqlParameter("@LowerLimit", pro.LowerLimit),
                                               new SqlParameter("@CenterLimit", pro.CenterLimit),
                                               new SqlParameter("@UpperLimit", pro.UpperLimit),
                                               new SqlParameter("@CreatedBy", pro.CreatedBy),
                                               new SqlParameter("@action","Insert")            
                                               
                                            };
                //int result = _DbClass.ExecuteNonQueryWithParameter("InsertProject", sqlParams);

                result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetTemparatureCurve", sqlParams);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public int InsertDestructiveInspection(DOL.DestructiveInspectionItem pro)
        {
            int result = 0;
            try
            {
                SqlParameter[] sqlParams = { 
                                               new SqlParameter("@ProjectId", pro.ProjectId),
                                               new SqlParameter("@Inspection", pro.Inspection),
                                               new SqlParameter("@CreatedBy", pro.CreatedBy),
                                               new SqlParameter("@action","Insert")            
                                               
                                            };
                //int result = _DbClass.ExecuteNonQueryWithParameter("InsertProject", sqlParams);

                result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetDestructiveInspection", sqlParams);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        //public int InsertDestructiveInspection(DOL.DestructiveInspectionItem pro)
        //{
        //    int result = 0;
        //    try
        //    {
        //        SqlParameter[] sqlParams = { 
        //                                       new SqlParameter("@ProjectId", pro.ProjectId),
        //                                       new SqlParameter("@Inspection", pro.Inspection),
        //                                       new SqlParameter("@CreatedBy", pro.CreatedBy),
        //                                       new SqlParameter("@action","Insert")            

        //                                    };
        //        //int result = _DbClass.ExecuteNonQueryWithParameter("InsertProject", sqlParams);

        //        result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetDestructiveInspection", sqlParams);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //    return result;
        //}

        public int InsertPaperCollar(DOL.PaperCollar pro)
        {
            int result = 0;
            try
            {
                SqlParameter[] sqlParams = { 
                                               new SqlParameter("@LocationId", pro.LocationId),
                                               new SqlParameter("@ProjectId", pro.ProjectId),
                                               new SqlParameter("@Collar", pro.Collar),
                                               new SqlParameter("@CreatedBy", pro.CreatedBy),
                                               new SqlParameter("@action","Insert")            
                                               
                                            };
                //int result = _DbClass.ExecuteNonQueryWithParameter("InsertProject", sqlParams);

                result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetPaperCollar", sqlParams);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public int InsertFacePlateC70(DOL.FacePlateC70 pro)
        {
            int result = 0;
            try
            {
                SqlParameter[] sqlParams = { 
                                               new SqlParameter("@FacePlate", pro.FacePlate),
                                               new SqlParameter("@LocationId", pro.LocationId),
                                               new SqlParameter("@ProjectId", pro.ProjectId),
                                               new SqlParameter("@CreatedBy", pro.CreatedBy),
                                               new SqlParameter("@action","Insert")            
                                               
                                            };
                //int result = _DbClass.ExecuteNonQueryWithParameter("InsertProject", sqlParams);

                result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetFacePlateC70", sqlParams);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public int InsertFacePlateC91(DOL.FacePlateC91 pro)
        {
            int result = 0;
            try
            {
                SqlParameter[] sqlParams = { 
                                               new SqlParameter("@FacePlate", pro.FacePlate),
                                               new SqlParameter("@LocationId", pro.LocationId),
                                               new SqlParameter("@ProjectId", pro.ProjectId),
                                               new SqlParameter("@CreatedBy", pro.CreatedBy),
                                               new SqlParameter("@action","Insert")            
                                               
                                            };
                //int result = _DbClass.ExecuteNonQueryWithParameter("InsertProject", sqlParams);

                result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetFacePlateC91", sqlParams);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public int InsertDefects(DOL.Defects pro)
        {
            int result = 0;
            try
            {
                SqlParameter[] sqlParams = { 
                                               new SqlParameter("@Defect", pro.Defect),
                                               new SqlParameter("@LocationId", pro.LocationId),
                                               new SqlParameter("@ProjectId", pro.ProjectId),
                                               new SqlParameter("@CreatedBy", pro.CreatedBy),
                                               new SqlParameter("@action","Insert")            
                                               
                                            };
                //int result = _DbClass.ExecuteNonQueryWithParameter("InsertProject", sqlParams);

                result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetDefects", sqlParams);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public int InsertTeardown(DOL.TearDown pro)
        {
            int result = 0;
            try
            {
                SqlParameter[] sqlParams = { 
                                               new SqlParameter("@Sno", pro.Sno),
                                               new SqlParameter("@TeardownSteps", pro.TeardownSteps),
                                               new SqlParameter("@ProjectId", pro.ProjectId),
                                               new SqlParameter("@CreatedBy", pro.CreatedBy),
                                               new SqlParameter("@action","Insert")            
                                               
                                            };
                //int result = _DbClass.ExecuteNonQueryWithParameter("InsertProject", sqlParams);

                result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetTeardown", sqlParams);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public int InsertLocation(DOL.Location pro)
        {
            int result = 0;
            try
            {
                SqlParameter[] sqlParams = { 
                                               
                                               new SqlParameter("@Locations", pro.Locations),
                                               new SqlParameter("@ProjectId", pro.ProjectId),
                                               new SqlParameter("@CreatedBy", pro.CreatedBy),
                                               new SqlParameter("@action","Insert")            
                                               
                                            };
                //int result = _DbClass.ExecuteNonQueryWithParameter("InsertProject", sqlParams);

                result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetLocation", sqlParams);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public int InsertTeardownInspections(DOL.TeardownInspection pro)
        {
            int result = 0;
            try
            {
                SqlParameter[] sqlParams = { 
                                               
                                               new SqlParameter("@Inspection", pro.Inspection),
                                               new SqlParameter("@ProjectId", pro.ProjectId),
                                               new SqlParameter("@TearId", pro.TearId),
                                               new SqlParameter("@CreatedBy", pro.CreatedBy),
                                               new SqlParameter("@action","Insert")            
                                               
                                            };
                //int result = _DbClass.ExecuteNonQueryWithParameter("InsertProject", sqlParams);

                result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetTeardownInspections", sqlParams);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public int InsertPlugShellC91(DOL.PlugShellC91 pro)
        {
            int result = 0;
            try
            {
                SqlParameter[] sqlParams = { 
                                               new SqlParameter("@LocationId", pro.LocationId),
                                               new SqlParameter("@ProjectId", pro.ProjectId),
                                               new SqlParameter("@PlugShelll", pro.PlugShelll),
                                               new SqlParameter("@CreatedBy", pro.CreatedBy),
                                               new SqlParameter("@action","Insert")            
                                               
                                            };
                //int result = _DbClass.ExecuteNonQueryWithParameter("InsertProject", sqlParams);

                result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetPlugShellC91", sqlParams);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public int InsertPlugShellC70(DOL.PlugShellC70 pro)
        {
            int result = 0;
            try
            {
                SqlParameter[] sqlParams = { 
                                               
                                                new SqlParameter("@LocationId", pro.LocationId),
                                               new SqlParameter("@ProjectId", pro.ProjectId),
                                               new SqlParameter("@PlugShell", pro.PlugShell),
                                               new SqlParameter("@CreatedBy", pro.CreatedBy),
                                               new SqlParameter("@action","Insert")            
                                               
                                            };
                //int result = _DbClass.ExecuteNonQueryWithParameter("InsertProject", sqlParams);

                result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetPlugShellC70", sqlParams);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public int InsertBootC70(DOL.BootC70 pro)
        {
            int result = 0;
            try
            {
                SqlParameter[] sqlParams = { 
                                               new SqlParameter("@LocationId", pro.LocationId),
                                               new SqlParameter("@ProjectId", pro.ProjectId),
                                               new SqlParameter("@Boot", pro.Boot),
                                               new SqlParameter("@CreatedBy", pro.CreatedBy),
                                               new SqlParameter("@action","Insert")            
                                               
                                            };
                //int result = _DbClass.ExecuteNonQueryWithParameter("InsertProject", sqlParams);

                result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetBootC70", sqlParams);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public int InsertBootC91(DOL.BootC91 pro)
        {
            int result = 0;
            try
            {
                SqlParameter[] sqlParams = { 
                                               new SqlParameter("@LocationId", pro.LocationId),
                                               new SqlParameter("@ProjectId", pro.ProjectId),
                                               new SqlParameter("@Boott", pro.Boott),
                                               new SqlParameter("@CreatedBy", pro.CreatedBy),
                                               new SqlParameter("@action","Insert")            
                                               
                                            };
                //int result = _DbClass.ExecuteNonQueryWithParameter("InsertProject", sqlParams);

                result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetBootC91", sqlParams);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        //public int InsertFacePlate(DOL.face pro)
        //{
        //    int result = 0;
        //    try
        //    {
        //        SqlParameter[] sqlParams = { 
        //                                       new SqlParameter("@LocationId", pro.LocationId),
        //                                       new SqlParameter("@ProjectId", pro.ProjectId),
        //                                       new SqlParameter("@FacePlate", pro.FacePlate),
        //                                       new SqlParameter("@CreatedBy", pro.CreatedBy),
        //                                       new SqlParameter("@action","Insert")            

        //                                    };
        //        //int result = _DbClass.ExecuteNonQueryWithParameter("InsertProject", sqlParams);

        //        result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetFacePlate", sqlParams);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //    return result;
        //}

        public int InsertDestructiveFrequency(DOL.DestructiveFrequency pro)
        {
            int result = 0;
            try
            {
                SqlParameter[] sqlParams = { 
                                               new SqlParameter("@ProjectId", pro.ProjectId),
                                               new SqlParameter("@Frequency", pro.Frequency),
                                               new SqlParameter("@CreatedBy", pro.CreatedBy),
                                               new SqlParameter("@action","Insert")            
                                               
                                            };
                //int result = _DbClass.ExecuteNonQueryWithParameter("InsertProject", sqlParams);

                result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetDestructiveFrequency", sqlParams);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public int InsertCheckPoint(DOL.AuditCheckPoint pro)
        {
            int result = 0;
            try
            {
                SqlParameter[] sqlParams = { 
                                                           
                                               new SqlParameter("@CheckPoints", pro.CheckPoints),
                                               new SqlParameter("@Dept", pro.Dept),
                                               new SqlParameter("@OperationId",pro.OperationId),
                                               new SqlParameter("@CreatedBy", pro.CreatedBy), 
                                               new SqlParameter("@ProjectId", pro.projectId),
                                               new SqlParameter("@action","Insert")            
                                               
                                            };
                //int result = _DbClass.ExecuteNonQueryWithParameter("InsertProject", sqlParams);

                result = _DbClass.ExecuteNonQueryWithParameter("ipqc.GetAuditCheckpoint", sqlParams);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public DataTable GetOperationsByProject(int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@ProjectId",ProjectId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetOperationsByProject]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }
        public DataTable GetPartToInspectByProject(int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@ProjectId",ProjectId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetPartToInspectByProject]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }

        public DataTable GetCircuitInspectionItemByStation(int StationId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@StationId",StationId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetCircuitInspectionItemByStation]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }

        public DataTable GetSectionByProject(int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@ProjectId",ProjectId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetSectionByProject]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }

        public DataTable GetDestructiveInspectionByProject(int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@ProjectId",ProjectId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetDestructiveInspectionByProject]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }

        public DataTable GetDestructiveWireByDestructiveInspection(int InspectionId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@InspectionId",InspectionId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetDestructiveWireByDestructiveInspection]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }

        public DataTable GetLocation(int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@ProjectId",ProjectId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetLocation", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }

        public DataTable GetTearDrop(int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@ProjectId",ProjectId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetTeardown", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }

        public DataTable GetPartNoByModel(int ModelId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@ModelId",ModelId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetPartNoByModel]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }

        public DataTable GetModelNoByProject(int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@ProjectId",ProjectId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetModelNoByProject]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }

        public DataTable GetAdhesiveByProject(int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@ProjectId",ProjectId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetAdhesiveByProject]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }

        public DataTable GetTemparatureRangeByProject(int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@ProjectId",ProjectId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetTemparatureRangeByProject]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }

        public DataTable GetExponentsByProject(int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@ProjectId",ProjectId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetExponentsByProject]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }

        public DataTable GetInspectorcategoryByProject(int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@ProjectId",ProjectId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetInspectorcategoryByProject]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }

        public DataTable GetInspectorsByProject(int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@ProjectId",ProjectId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetInspectorsByProject]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }


        public DataTable GetFacePlateC70ByProject(int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@ProjectId",ProjectId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetFacePlateC70]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }


        public DataTable GetFacePlateC91ByProject(int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@ProjectId",ProjectId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetFacePlateC91]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }





        public DataTable GetBootC70ByProject(int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@ProjectId",ProjectId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetBootC70]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }

        public DataTable GetBootC91ByProject(int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@ProjectId",ProjectId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetBootC91]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }

        public DataTable GetPlugShellC70ByProject(int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@ProjectId",ProjectId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetPlugShellC70]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }


        public DataTable GetPlugShellC91ByProject(int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@ProjectId",ProjectId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetPlugShellC91]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }


        public DataTable GetPaperCollarByProject(int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@ProjectId",ProjectId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetPaperCollar]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }

        public DataTable GetSRByProject(int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@ProjectId",ProjectId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetSR]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }

        public DataTable GetCableByProject(int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@ProjectId",ProjectId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetCable]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }

        public DataTable GetBatchByProject(int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@ProjectId",ProjectId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetBatchByProject]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }

        public DataTable GetProdModuleByProject(int ZoneId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@ZoneId",ZoneId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetProdModuleByProject]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }
        public DataTable GetShiftLeaderByBatch(int BatchId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@BatchId",BatchId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[dbo].[GetShiftLeaderByBatch]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }

        public DataTable GetVisualsByproject(int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@ProjectId",ProjectId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetVisualsByproject]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }

        //public DataTable GetVisualsByproject(int ProjectId)
        //{
        //    DataTable dt = new DataTable();

        //    try
        //    {
        //        SqlParameter[] sqlparams = {
        //                                  new SqlParameter("@ProjectId",ProjectId)
        //                               };
        //        dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetVisualsByproject]", sqlparams);

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return dt;

        //}

        //public DataTable GetProdModuleByProject(int ZoneId)
        //{
        //    DataTable dt = new DataTable();

        //    try
        //    {
        //        SqlParameter[] sqlparams = {
        //                                  new SqlParameter("@ZoneId",ZoneId)
        //                               };
        //        dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetProdModuleByProject]", sqlparams);

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return dt;

        //}

        public DataTable GetProductionLineLeaderByBatch(int ZoneId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@ZoneId",ZoneId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetProductionLineLeaderByBatch]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }

        public DataTable GetZoneByBatch(int BatchId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@BatchId",BatchId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetZoneByBatch]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }

        public DataTable GetA246CMachinesByProject(int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@ProjectId",ProjectId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetA246CMachinesByProject]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }

        public DataTable GetAllData(int MenuId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@MenuId",MenuId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[dbo].[GetAllData]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }

        public DataTable A246CCTPMCStationsByMachine(int MachineId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@MachineId",MachineId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[A246CCTPMCStationsByMachine]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }

        public DataTable A246CCTPMCParameterByStation(int StationId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@StationId",StationId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[Get246CCTPMCParameterByStation]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }

        public DataTable A246CCTPMCStationsByMachineLine2(int MachineId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                          new SqlParameter("@MachineId",MachineId)
                                       };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[A246CCTPMCStationsByMachineLine2]", sqlparams);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }







        public DataTable SearchForProject(string ProjectName)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlParams = { 
                                               new SqlParameter("@ProjectName", ProjectName),            
                                               new SqlParameter("@action","Select"),                                             
                                            };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetProject", sqlParams);

            }
            catch (Exception ex)
            {

            }

            return dt;
        }



    }

    #endregion

    public class Projects
    {
        DbClass _DbClass;

        public Projects()
        {
            _DbClass = DbClass.GetInstance();
        }

        public int InsertProject(DOL.Project pro)
        {
            int result = 0;
            try
            {
                SqlParameter[] sqlParams = { 
                                                           
                                               new SqlParameter("@ProjectName", pro.ProjectName),
                                               new SqlParameter("@CreatedBy", pro.CreatedBy),                                                
                                               new SqlParameter("@action","Insert"),            
                                               
                                            };
                //int result = _DbClass.ExecuteNonQueryWithParameter("InsertProject", sqlParams);

                result = _DbClass.ExecuteNonQueryWithParameter("epq.GetProject", sqlParams);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }


        public List<DOL.Project> GetProject()
        {
            List<DOL.Project> listProject = new List<DOL.Project>();


            try
            {

                DataTable dt = _DbClass.ExecuteProcedureForDataTable("epq.GetProject");
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
    }
}
