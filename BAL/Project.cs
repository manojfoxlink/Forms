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
   
    public class Project
    {
        DAL.Project _objProject = new DAL.Project();

        public DataSet GetProjectDetails( string ProjectName)
        {
            return _objProject.GetProjectDetails(ProjectName);
        }
        public int InsertProject(DOL.Project pro)
        {
            return _objProject.InsertProject(pro);
        }

        public int InsertOperations(DOL.Operations pro)
        {
            return _objProject.InsertOperations(pro);
        }
        public int InsertPartToInspect(DOL.PartToInspect pro)
        {
            return _objProject.InsertPartToInspect(pro);
        }
        public int InsertCheckPoint(DOL.AuditCheckPoint pro)
        {
            return _objProject.InsertCheckPoint(pro);
        }

        public int InsertInspectorDetails(DOL.InspectorDetailss pro)
        {
            return _objProject.InsertInspectorDetails(pro);
        }

        public int InsertCircuitInspectionItem(DOL.CircuitInspectionItem pro)
        {
            return _objProject.InsertCircuitInspectionItem(pro);
        }

        public int InsertCircuitInspectionSpec(DOL.CircuitInspectionSpec pro)
        {
            return _objProject.InsertCircuitInspectionSpec(pro);
        }

        public int InsertDestructiveSpec(DOL.DestructiveSpec pro)
        {
            try
            {
                return _objProject.InsertDestructiveSpec(pro);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertCTQPartsToInspect(DOL.CTQPartsToInspect pro)
        {
            return _objProject.InsertCTQPartsToInspect(pro);
        }
        public int InsertDestructiveWire(DOL.DestructiveWire pro)
        {
            try
            {
                return _objProject.InsertDestructiveWire(pro);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertAdhesive(DOL.Adhesivee pro)
        {
            try
            {
                return _objProject.InsertAdhesive(pro);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int InsertTemparatureRange(DOL.TempRange pro)
        {
            try
            {
                return _objProject.InsertTemparatureRange(pro);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int InsertDestructiveInspection(DOL.DestructiveInspectionItem pro)
        {
            try
            {
                return _objProject.InsertDestructiveInspection(pro);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertPaperCollar(DOL.PaperCollar pro)
        {
            try
            {
                return _objProject.InsertPaperCollar(pro);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

         public int InsertFacePlateC70(DOL.FacePlateC70 pro)
        {
            try
            {
                return _objProject.InsertFacePlateC70(pro);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertFacePlateC91(DOL.FacePlateC91 pro)
         {
             try
             {
                 return _objProject.InsertFacePlateC91(pro);
             }
             catch (Exception)
             {
                 
                 throw;
             }
         }

        public int InsertDefects(DOL.Defects pro)
        {
            try
            {
                return _objProject.InsertDefects(pro);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertTeardown(DOL.TearDown pro)
        {
            try
            {
                return _objProject.InsertTeardown(pro);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertLocation(DOL.Location pro)
        {
            try
            {
                return _objProject.InsertLocation(pro);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertTeardownInspections(DOL.TeardownInspection pro)
        {
            try
            {
                return _objProject.InsertTeardownInspections(pro);
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        public int InsertPlugShellC91(DOL.PlugShellC91 pro)
        {
            try
            {
                return _objProject.InsertPlugShellC91(pro);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int InsertPlugShellC70(DOL.PlugShellC70 pro)
        {
            try
            {
                return _objProject.InsertPlugShellC70(pro);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBootC70(DOL.BootC70 pro)
        {
            try
            {
                return _objProject.InsertBootC70(pro);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int InsertBootC91(DOL.BootC91 pro)
        {
            try
            {
                return _objProject.InsertBootC91(pro);
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        //public int InsertFacePlate(DOL.FacePlatee pro)
        //{
        //    try
        //    {
        //        return _objProject.InsertFacePlate(pro);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        public int InsertDestructiveFrequency(DOL.DestructiveFrequency pro)
        {
            try
            {
                return _objProject.InsertDestructiveFrequency(pro);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetOperationsByProject(int ProjectId)
        {
            return _objProject.GetOperationsByProject(ProjectId);
        }

        public DataTable GetPartToInspectByProject(int ProjectId)
        {
            try
            {
                return _objProject.GetPartToInspectByProject(ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetCircuitInspectionItemByStation(int StationId)
        {
            try
            {
                return _objProject.GetCircuitInspectionItemByStation(StationId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetSectionByProject(int ProjectId)
        {
            try
            {
                return _objProject.GetSectionByProject(ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetDestructiveInspectionByProject(int ProjectId)
        {
            try
            {
                return _objProject.GetDestructiveInspectionByProject(ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetDestructiveWireByDestructiveInspection(int InspectionId)
        {
            try
            {
                return _objProject.GetDestructiveWireByDestructiveInspection(InspectionId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetLocation(int ProjectId)
        {
            try
            {
                return _objProject.GetLocation(ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetTearDrop(int ProjectId)
        {
            try
            {
                return _objProject.GetTearDrop(ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable SearchForProject(string ProjectName)
        {
            return _objProject.SearchForProject(ProjectName);
        }
        public List<DOL.Project> GetProject()
        {
           return _objProject.GetProject();
        }

        public List<DOL.ProdApprovedBy> GetApprovedBy()
        {
            try
            {
                return _objProject.GetApprovedBy();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public List<DOL.ProdAuditBy> GetAuditBy()
        {
            try
            {
                return _objProject.GetAuditBy();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<DOL.prodCheckedBy> GetCheckedBy()
        {
            try
            {
                return _objProject.GetCheckedBy();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<DOL.ProdVerifiedBy> GetVerifiedBy()
        {
            try
            {
                return _objProject.GetVerifiedBy();
            }
            catch (Exception)
            {

                throw;
            }
        }

       

        public List<DOL.MasterMenuss> GetMasterMenus()
        {
            try
            {
                return _objProject.GetMasterMenus();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
       

        public List<DOL.DestructiveInspectionItem> GetDestructiveInspection()
        {
            try
            {
                return _objProject.GetDestructiveInspection();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public List<DOL.Sections> GetSection()
        {
            try
            {
                return _objProject.GetSection();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public List<DOL.Frequen> GetFreq()
        {
            try
            {
                return _objProject.GetFreq();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public List<DOL.DestructiveFrequency> GetDestructiveFrequency()
        {
            try
            {
                return _objProject.GetDestructiveFrequency();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public List<DOL.Periodss> GetPeriodss()
        {
            try
            {
                return _objProject.GetPeriodss();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public List<DOL.PartToInspect> GetPartToInspect()
        {
            try
            {
                return _objProject.GetPartToInspect();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public List<DOL.Inspectors> GetInspectors()
        {
            try
            {
                return _objProject.GetInspectors();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public List<Operations> GetOperations()
        {
            return _objProject.GetOperations();
        }

        public List<AuditCheckPoint> GetAuditCheckPoints()
        {
            return _objProject.GetAuditCheckPoints();
        }
        
    }

    public class Projects
    {
        DAL.Projects _objProject = new DAL.Projects();


        public int InsertProject(DOL.Project pro)
        {
            return _objProject.InsertProject(pro);
        }
        public List<DOL.Project> GetProject()
        {
            return _objProject.GetProject();
        }

    }



}