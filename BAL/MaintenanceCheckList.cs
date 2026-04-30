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
    public class MaintenanceCheckList
    {
        DAL.MaintenanceCheckList _objMaintenanceCheckList = new DAL.MaintenanceCheckList();

        public int InsertCheckListMaintenanceResult(DataTable dtChecklist, string UserId, int LineId, string DRILeader, string LineLeader)
        {
            try
            {
                return _objMaintenanceCheckList.InsertCheckListMaintenanceResult(dtChecklist, UserId, LineId, DRILeader, LineLeader);
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        public DataTable GetFormByMaintenance(int LineId, int MachineId, int ProjectId)
        {
            try
            {
                return _objMaintenanceCheckList.GetFormByMaintenance(LineId, MachineId, ProjectId);
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
                return _objMaintenanceCheckList.GetProject();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public List<DOL.Freqq> GetFrequency()
        {
            try
            {
                return _objMaintenanceCheckList.GetFrequency();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

         public List<Line> GetLine()
        {
            try
            {
                return _objMaintenanceCheckList.GetLine();
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
                 return _objMaintenanceCheckList.GetMachine();
             }
             catch (Exception)
             {
                 
                 throw;
             }
         }

        public List<DOL.Activityy> GetActivity()
        {
            try
            {
                return _objMaintenanceCheckList.GetActivity();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        
    }

    public class CheckListNativeValidation
    {
        DAL.CheckListNativeValidation obj = new DAL.CheckListNativeValidation();

          public List<Line> GetLine()
        {
            try
            {
                return obj.GetLine();
            }
            catch (Exception)
            {
                
                throw;
            }

        }

          public int InsertCheckListNativeValiadtion(DataTable dtChecklist, string userId, int LineId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy,int ModelId,int PartId)
          {
              try
              {
                  return obj.InsertCheckListNativeValiadtion(dtChecklist, userId, LineId, ProjectId, ProdLineLeader, CheckedBy, ApprovedBy, ModelId, PartId);
              }
              catch (Exception)
              {
                  
                  throw;
              }

          }
        public int InsertBulkA246CPartToInspectCheckList(DataTable dtChecklist, string userId, int LineId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
          {
              try
              {
                  return obj.InsertBulkA246CPartToInspectCheckList(dtChecklist, userId, LineId, ProjectId, ProdLineLeader, CheckedBy, ApprovedBy, ModelId, PartId);
              }
              catch (Exception)
              {
                  
                  throw;
              }
          }
        //public int InsertBulkProdQualityAuditCheckList(DataTable dtChecklist, string userId, int LineId, int ProjectId, int BatchId, string ProdLineLeader, string ShiftLeader, string VerifiedBy, string CheckedBy, string ApprovedBy, string AuditedBy, int ModelId, int ZoneId, int ProdId)
        //{
        //    try
        //    {
        //        return obj.InsertBulkProdQualityAuditCheckList(dtChecklist, userId, LineId, ProjectId,BatchId, ProdLineLeader,ShiftLeader,VerifiedBy, CheckedBy, ApprovedBy,AuditedBy, ModelId, ZoneId,ProdId);
        //    }
        //    catch (Exception)
        //    {
                
        //        throw;
        //    }
        //}

          public int InsertCheckListOutInspection(DataTable dtChecklist, string userId, int LineId, int ProjectId,string CheckedBy, string ApprovedBy, string CustomerPin, string LotSize, string FinishedProductNo, string Rev, string PackingListNo, bool InspectResult)
          {
              try
              {
                  return obj.InsertCheckListOutInspection(dtChecklist, userId, LineId, ProjectId,CheckedBy, ApprovedBy, CustomerPin, LotSize, FinishedProductNo, Rev, PackingListNo, InspectResult);
              }
              catch (Exception)
              {
                  
                  throw;
              }
          }
        public int InsertCheckListOutInspectionA246C(DataTable dtChecklist, string userId, int LineId, int ProjectId, string CheckedBy, string ApprovedBy, string CustomerPin, string LotSize, string FinishedProductNo, string Rev, string PackingListNo,string SimToolPartNumber, bool InspectResult)
          {
              try
              {
                  return obj.InsertCheckListOutInspectionA246C(dtChecklist, userId, LineId, ProjectId,CheckedBy, ApprovedBy, CustomerPin, LotSize, FinishedProductNo, Rev, PackingListNo,SimToolPartNumber, InspectResult);
              }
              catch (Exception)
              {
                  
                  throw;
              }
          }
        public int InsertBulkRACAProdQualityAuditCheckList(DataTable dtChecklist, string userId)
        {
            try
            {
                return obj.InsertBulkRACAProdQualityAuditCheckList(dtChecklist,userId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBulkFACAProdQualityAuditCheckList(DataTable dtChecklist, string userId)
        {
            try
            {
                return obj.InsertBulkFACAProdQualityAuditCheckList(dtChecklist, userId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable InsertBulkA246CMHB1FACACheckList(DataTable dtChecklist, string userId)
        {
            try
            {
                return obj.InsertBulkA246CMHB1FACACheckList(dtChecklist, userId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable InsertBulkA246CMHB2FACACheckList(DataTable dtChecklist, string userId)
        {
            try
            {
                return obj.InsertBulkA246CMHB2FACACheckList(dtChecklist, userId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable InsertBulkA191MLASERFACACheckList(DataTable dtChecklist, string userId)
        {
            try
            {
                return obj.InsertBulkA191MLASERFACACheckList(dtChecklist, userId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable InsertBulkXBARFACACheckList(DataTable dtChecklist, string userId)
        {
            try
            {
                return obj.InsertBulkXBARFACACheckList(dtChecklist, userId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable InsertBulkA246CCTPFACACheckList(DataTable dtChecklist, string userId)
        {
            try
            {
                return obj.InsertBulkA246CCTPFACACheckList(dtChecklist, userId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable InsertBulkA246CCTPFACACheckListForLine2(DataTable dtChecklist, string userId)
        {
            try
            {
                return obj.InsertBulkA246CCTPFACACheckListForLine2(dtChecklist, userId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable InsertBulkA246CAOIFACACheckList(DataTable dtChecklist, string userId)
        {
            try
            {
                return obj.InsertBulkA246CAOIFACACheckList(dtChecklist, userId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable InsertBulkA246CINNERMOLDFACACheckList(DataTable dtChecklist, string userId)
        {
            try
            {
                return obj.InsertBulkA246CINNERMOLDFACACheckList(dtChecklist, userId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable InsertBulkA246CHankingFACACheckList(DataTable dtChecklist, string userId)
        {
            try
            {
                return obj.InsertBulkA246CHankingFACACheckList(dtChecklist, userId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable InsertBulkA246CNewHankingFACACheckList(DataTable dtChecklist, string userId)
        {
            try
            {
                return obj.InsertBulkA246CNewHankingFACACheckList(dtChecklist, userId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable InsertBulkA246CWCMFACACheckList(DataTable dtChecklist, string userId)
        {
            try
            {
                return obj.InsertBulkA246CWCMFACACheckList(dtChecklist, userId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable InsertBulkA246CShellCrimpingFACACheckList(DataTable dtChecklist, string userId)
        {
            try
            {
                return obj.InsertBulkA246CShellCrimpingFACACheckList(dtChecklist, userId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable InsertBulkA246CCCMFACACheckList(DataTable dtChecklist, string userId)
        {
            try
            {
                return obj.InsertBulkA246CCCMFACACheckList(dtChecklist, userId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        //public int InsertBulkA246CMHB2FACACheckList(DataTable dtChecklist, string userId)
        //{
        //    try
        //    {
        //     return obj.InsertBulkA246CMHB2FACACheckList(dtChecklist, userId);
        //    }
        //    catch (Exception)
        //    {
                
        //        throw;
        //    }
        //}

        public int InsertCheckListLineAudit(DataTable dtChecklist, string userId, int LineId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy,int ModelId,int PartId)
          {
              try
              {
                  return obj.InsertCheckListLineAudit(dtChecklist, userId, LineId, ProjectId, ProdLineLeader, CheckedBy, ApprovedBy,ModelId,PartId);
              }
              catch (Exception)
              {
                  
                  throw;
              }
          }

        public int InsertCheckListCircuitRecord(DataTable dtChecklist, string userId, int LineId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy,int ModelId ,int PartId)
        {
            try
            {
                return obj.InsertCheckListCircuitRecord(dtChecklist, userId, LineId, ProjectId, ProdLineLeader, CheckedBy, ApprovedBy,ModelId,PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBulkCTQManPowerCheckList(DataTable dtChecklist, string userId, int LineId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy,int ModelId,int PartId)
        {
            try
            {
                return obj.InsertBulkCTQManPowerCheckList(dtChecklist, userId, LineId, ProjectId, ProdLineLeader, CheckedBy, ApprovedBy,ModelId,PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBulkAdhesiveCheckList(DataTable dtChecklist, string userId, int LineId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy,int ModelId,int PartId)
        {
            try
            {
                return obj.InsertBulkAdhesiveCheckList(dtChecklist, userId, LineId, ProjectId, ProdLineLeader, CheckedBy, ApprovedBy, ModelId,PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        //,model.EquipmentNo,model.TypeNo
        public int InsertBulkTemperatureRangeCheckList(DataTable dtChecklist, string userId, int LineId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy, string EquipmentNo, string TypeNo,int ModelId,int PartId)
        {
            try
            {
                return obj.InsertBulkTemperatureRangeCheckList(dtChecklist, userId, LineId, ProjectId, ProdLineLeader, CheckedBy, ApprovedBy, EquipmentNo, TypeNo, ModelId,PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBulkDestructive(DataTable dtChecklist, string userId, int LineId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy,int ModelId,int PartId)
        {
            try
            {
                return obj.InsertBulkDestructive(dtChecklist, userId, LineId, ProjectId, ProdLineLeader, CheckedBy, ApprovedBy,ModelId,PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertCheckListTrapTest(DataTable dtChecklist, string userId, int LineId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy,int ModelId,int PartId)
        {
            try
            {
                return obj.InsertCheckListTrapTest(dtChecklist, userId, LineId, ProjectId, ProdLineLeader, CheckedBy, ApprovedBy, ModelId, PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetFormByNativeValiadtion(int LineId, int ProjectId)
        {
            try
            {
                return obj.GetFormByNativeValiadtion(LineId, ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }

        }
        public DataTable GetFormByA246CPartToInspect(int LineId, int ProjectId)
        {
            try
            {
                return obj.GetFormByA246CPartToInspect(LineId, ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        //public DataTable GetFormByProdQualityAudit(int LineId, int ProjectId, int BatchId, int ZoneId, int ModuleId)
        //{
        //    try
        //    {
        //        return obj.GetFormByProdQualityAudit(LineId, ProjectId,BatchId,ZoneId,ModuleId);
        //    }
        //    catch (Exception)
        //    {
                
        //        throw;
        //    }
        //}

        public DataTable GetFormByOutInspection(int ProjectId)
        {
            try
            {
                return obj.GetFormByOutInspection(ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetMailParameterProdQualityAudit()
        {
            try
            {
                return obj.GetMailParameterProdQualityAudit();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetFormByAuditCheckPoints(int LineId, int ProjectId)
        {
            try
            {
                return obj.GetFormByAuditCheckPoints(LineId,ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetFormByCircuitBoardRecord(int LineId, int ProjectId, int ProcessTourId)
        {
            try
            {
                return obj.GetFormByCircuitBoardRecord(LineId, ProjectId,ProcessTourId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetFormByCTQManPower(int LineId, int ProjectId)
        {
            try
            {
                return obj.GetFormByCTQManPower(LineId,ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetFormByAdhesive(int LineId, int ProjectId, int AdhesiveId)
        {
            try
            {
                return obj.GetFormByAdhesive(LineId,ProjectId,AdhesiveId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetFormByTemparatureRange(int LineId, int ProjectId, int TempId)
        {
            try
            {
                return obj.GetFormByTemparatureRange(LineId,ProjectId,TempId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetFormByDestructiveTest(int LineId, int ProjectId)
        {
            try
            {
                return obj.GetFormByDestructiveTest(LineId, ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetFormByTrapTest(int LineId, int ProjectId)
        {
            try
            {
                return obj.GetFormByTrapTest(LineId,ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
