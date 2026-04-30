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
    public class CheckListCircuitRecord
    {
        DAL.CheckListCircuitRecord _objCheckListCircuitRecord = new DAL.CheckListCircuitRecord();

        public DataTable GetFormByRecord(int LineId,int ProjectId)
        {
            try
            {
                return _objCheckListCircuitRecord.GetFormByRecord(LineId,ProjectId);
            }
            catch (Exception)
            {

                throw;
            }


        }

        public int InsertCheckListRecordResult(DataTable dtChecklist, string UserId, int LineId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy,int ModelId,int PartId)
        {
            return _objCheckListCircuitRecord.InsertCheckListRecordResult(dtChecklist, UserId, LineId, ProjectId, ProdLineLeader, CheckedBy, ApprovedBy, ModelId, PartId);
        }

        public List<Line> GetLine()
        {
            try
            {
                return _objCheckListCircuitRecord.GetLine();
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
                return _objCheckListCircuitRecord.GetShift();
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
                return _objCheckListCircuitRecord.GetProject();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        
        public List<DOL.A246CMachines> GetA246CMachines()
        {
            try
            {
                return _objCheckListCircuitRecord.GetA246CMachines();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public List<DOL.SRS> GetSRS()
        {
            try
            {
                return _objCheckListCircuitRecord.GetSRS();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public List<DOL.BootC70> GetBootC70(int ProjectId)
        {
            try
            {
                return _objCheckListCircuitRecord.GetBootC70(ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public List<DOL.BootC91> GetBootC91(int ProjectId)
        {
            try
            {
                return _objCheckListCircuitRecord.GetBootC91(ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public List<DOL.PlugShellC70> GetPlugShellC70(int ProjectId)
        {
            try
            {
                return _objCheckListCircuitRecord.GetPlugShellC70(ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public List<DOL.PlugShellC91> GetPlugShellC91(int ProjectId)
        {
            try
            {
                return _objCheckListCircuitRecord.GetPlugShellC91(ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public List<DOL.FacePlateC70> GetFacePlateC70(int ProjectId)
        {
            try
            {
                return _objCheckListCircuitRecord.GetFacePlateC70(ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public List<DOL.FacePlateC91> GetFacePlateC91(int ProjectId)
        {
            try
            {
                return _objCheckListCircuitRecord.GetFacePlateC91(ProjectId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<DOL.Cable> GetCable(int ProjectId)
        {
            try
            {
                return _objCheckListCircuitRecord.GetCable(ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public List<DOL.PaperCollar> GetPaperCollar(int ProjectId)
        {
            try
            {
                return _objCheckListCircuitRecord.GetPaperCollar(ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public List<DOL.SRS> GetSR(int projectId)
        {
            try
            {
                return _objCheckListCircuitRecord.GetSR(projectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public List<DOL.InspectorCategory> GetInspectorcategory()
        {
            try
            {
                return _objCheckListCircuitRecord.GetInspectorcategory();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public List<DOL.ModelNo> GetModelNo()
        {
            try
            {
                return _objCheckListCircuitRecord.GetModelNo();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public List<DOL.Exponent> GetExponent()
        {
            try
            {
                return _objCheckListCircuitRecord.GetExponent();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public List<DOL.Result> GetResult()
        {
            try
            {
                return _objCheckListCircuitRecord.GetResult();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public List<DOL.Adhesivee> GetAdhesive()
        {
            try
            {
                return _objCheckListCircuitRecord.GetAdhesive();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public List<DOL.TempRange> GetTempRange()
        {
            try
            {
                return _objCheckListCircuitRecord.GetTempRange();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }

    
    public class FirstArticleInspection
    {
        DAL.FirstArticleInspection _objArticleInspection = new DAL.FirstArticleInspection();

        public List<Line> GetLine()
        {
            try
            {
                return _objArticleInspection.GetLine();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int InsertCheckListFirstArticleInspection(DataTable dtChecklist1, string userId, int LineId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId, string ProductName, string WorkOrder, string DrawingVersion, string PackVersion, string SamplingQty)
        {
            try
            {
                return _objArticleInspection.InsertCheckListFirstArticleInspection(dtChecklist1, userId, LineId, ProjectId,ProdLineLeader,CheckedBy,ApprovedBy, ModelId, PartId, ProductName, WorkOrder, DrawingVersion, PackVersion, SamplingQty);
            }
            catch (Exception)
            {
                
                throw;
            }

        }

        public int InsertBulkFirstAirticleSpecCheckList2(DataTable dtChecklist1, string userId, int LineId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId, string ProductName, string WorkOrder, string DrawingVersion, string PackVersion, string SamplingQty)
        {
            try
            {
                return _objArticleInspection.InsertBulkFirstAirticleSpecCheckList2(dtChecklist1, userId, LineId, ProjectId,ProdLineLeader,CheckedBy,ApprovedBy, ModelId, PartId, ProductName, WorkOrder, DrawingVersion, PackVersion, SamplingQty);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBulkFirstAirticleInspectionCheckList2(DataTable dtChecklist1, string userId, int LineId, int ProjectId, int ModelId, int PartId)
        {
            try
            {
                return _objArticleInspection.InsertBulkFirstAirticleInspectionCheckList2(dtChecklist1, userId, LineId, ProjectId, ModelId, PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int InsertCheckListFirstArticleInspections(DataTable dtChecklist1, string userId, int LineId, int ProjectId)
        {
            try
            {
                return _objArticleInspection.InsertCheckListFirstArticleInspections(dtChecklist1, userId, LineId, ProjectId);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public DataTable GetFormByFirstArticleInspection(int LineId, int ProjectId)
        {
            try
            {
                return _objArticleInspection.GetFormByFirstArticleInspection(LineId, ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }

        }

        public DataTable GetFormByFirstAirticleInspec2(int LineId, int ProjectId)
        {
            try
            {
                return _objArticleInspection.GetFormByFirstAirticleInspec2(LineId, ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }


    }
}
