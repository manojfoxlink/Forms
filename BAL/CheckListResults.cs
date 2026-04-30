using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using System.Data.SqlClient;
using DOL;
namespace BAL
{
    public class CheckListResults
    {
        DAL.CheckListResults _objCheckListResults = new DAL.CheckListResults();
        public DataTable GetFormByProject(int lineId,int ProjectId)
        {
            try
            {
                return _objCheckListResults.GetFormByProject(lineId,ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
            

        }

        //public  List<Line> GetLine()
        //{
        //    try 
        //    {	        
        //     return _objCheckListResults.GetLine();
        //    }
        //    catch (Exception)
        //    {
		
        //        throw;
        //    }
        //}
        //public DataTable GetLaserSize(int LineId, int ProjectId)
        //{
        //    try 
        //    {	        
        //     return _objCheckListResults.GetLaserSize(LineId,ProjectId);
        //    }
        //    catch (Exception)
        //    {
		
        //        throw;
        //    }
        //}
        //public List<Shift> GetShift()
        //{
        //    try 
        //    {	        
        //     return _objCheckListResults.GetShift();
        //    }
        //    catch (Exception)
        //    {
		
        //        throw;
        //    }
        //}
        public int InsertCheckListResult(DataTable dtChecklist, string userId, int linId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            try
            {
                return _objCheckListResults.InsertCheckListResult(dtChecklist,userId,linId,ProdLineLeader,CheckedBy,ApprovedBy,ModelId,PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetFromByA246CCMMC1Dataa(int lineId, int ProjectId,int MachineId)
        {
            try
            {
                return _objCheckListResults.GetFromByA246CCMMC1Dataa(lineId,ProjectId,MachineId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetFromByA246CDestructiveMachineCheckList(int lineId, int ProjectId, int MachineId)
        {
            try
            {
                return _objCheckListResults.GetFromByA246CDestructiveMachineCheckList(lineId,ProjectId,MachineId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetFromByA246CDMachineCheckList(int lineId, int ProjectId, int MachineId)
        {
            try
            {
                return _objCheckListResults.GetFromByA246CDMachineCheckList(lineId,ProjectId,MachineId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetFromByA246CWeighingMachineCheckList(int lineId, int ProjectId, int MachineId)
        {
            try
            {
                return _objCheckListResults.GetFromByA246CWeighingMachineCheckList(lineId,ProjectId,MachineId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetFromByA246CNewHankingData(int ProjectId, int lineId, int MachineId, int PartId)
        {
            try
            {
                return _objCheckListResults.GetFromByA246CNewHankingData(ProjectId, lineId, MachineId,PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetFromByA246CWCMMC1Data(int ProjectId, int LineId, int MachineId)
        {
            try
            {
                return _objCheckListResults.GetFromByA246CWCMMC1Data(ProjectId,LineId,MachineId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetFromByA246CShellCrimpMC1Data(int ProjectId, int LineId, int MachineId)
        {
            try
            {
                return _objCheckListResults.GetFromByA246CShellCrimpMC1Data(ProjectId,LineId,MachineId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetFromByA246CInnerMoldMCData(int ProjectId, int LineId, int MachineId)
        {
            try
            {
                return _objCheckListResults.GetFromByA246CInnerMoldMCData(ProjectId,LineId,MachineId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetFromByA246CAOIData(int ProjectId, int LineId, int MachineId)
        {
            try
            {
                return _objCheckListResults.GetFromByA246CAOIData(ProjectId,LineId,MachineId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetFromByA246CCTPaameterMCChecklist(int ProjectId, int LineId, int MachineId)
        {
            try
            {
                return _objCheckListResults.GetFromByA246CCTPaameterMCChecklist(ProjectId,LineId,MachineId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        public DataTable GetFormByProdQualityAudit(int LineId, int ProjectId, int BatchId, int ZoneId, int ModuleId)
        {
            try
            {
                return _objCheckListResults.GetFormByProdQualityAudit(LineId, ProjectId, BatchId, ZoneId, ModuleId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable GetRpt_getParameterProdQualityAuditFORALL()
        {
            try
            {
                return _objCheckListResults.GetRpt_getParameterProdQualityAuditFORALL();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetMailsForForms()
        {
            try
            {
                return _objCheckListResults.GetMailsForForms();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetHotBarFACAByResultId(int ResultId)
        {
            try
            {
                return _objCheckListResults.GetHotBarFACAByResultId(ResultId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetXBarFACAByResultId(int ResultId)
        {
            try
            {
                return _objCheckListResults.GetXBarFACAByResultId(ResultId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetDataForHBFACA()
        {
            try
            {
                return _objCheckListResults.GetDataForHBFACA();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        
        
        public DataTable GetDataFromXBarFACA(int ResultId,int TaskId)
        {
            try
            {
                return _objCheckListResults.GetDataFromXBarFACA(ResultId,TaskId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetDataFromINNERMOLDFACA(int ResultId, int TaskId)
        {
            try
            {
                return _objCheckListResults.GetDataFromINNERMOLDFACA(ResultId,TaskId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetDataFromNewHankingFACA(int ResultId, int TaskId)
        {
            try
            {
                return _objCheckListResults.GetDataFromNewHankingFACA(ResultId,TaskId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetDataFromWCMFACA(int ResultId, int TaskId)
        {
            try
            {
                return _objCheckListResults.GetDataFromWCMFACA(ResultId,TaskId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetDataFromCCMFACA(int ResultId, int TaskId)
        {
            try
            {
                return _objCheckListResults.GetDataFromCCMFACA(ResultId,TaskId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetDataFromHB2FACA(int ResultId, int TaskId)
        {
            try
            {
                return _objCheckListResults.GetDataFromHB2FACA(ResultId,TaskId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetDataFromLaserEngravingFACA(int ResultId, int TaskId)
        {
            try
            {
                return _objCheckListResults.GetDataFromLaserEngravingFACA(ResultId,TaskId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetDataFromShellCrimpingFACA(int ResultId, int TaskId)
        {
            try
            {
                return _objCheckListResults.GetDataFromShellCrimpingFACA(ResultId,TaskId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetDataFromHankingFACA(int ResultId, int TaskId)
        {
            try
            {
                return _objCheckListResults.GetDataFromHankingFACA(ResultId,TaskId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        //public DataTable GetDataFromNewHankingFACA(int ResultId, int TaskId)
        //{
        //    try
        //    {
        //        return _objCheckListResults.GetDataFromNewHankingFACA(ResultId,TaskId);
        //    }
        //    catch (Exception)
        //    {
                
        //        throw;
        //    }
        //}
        public DataTable GetDataFromCTPFACAForLIne2(int ResultId,int TaskId)
        {
            try
            {
                return _objCheckListResults.GetDataFromCTPFACAForLIne2(ResultId, TaskId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetDataFromCTPFACA(int ResultId, int TaskId)
        {
            try
            {
                return _objCheckListResults.GetDataFromCTPFACA(ResultId,TaskId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetDataFromHBFACA(int ResultId, int TaskId)
        {
            try
            {
                return _objCheckListResults.GetDataFromHBFACA(ResultId,TaskId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetDataFromAOIFACA(int ResultId, int TaskId)
        {
            try
            {
                return _objCheckListResults.GetDataFromAOIFACA(ResultId,TaskId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetTaskStatus(string ApproveId)
        {
            try
            {
                return _objCheckListResults.GetTaskStatus(ApproveId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetFormByProdQualityAuditWith5S(int LineId, int ProjectId, int BatchId, int ZoneId, int ModuleId)
        {
            try
            {
                return _objCheckListResults.GetFormByProdQualityAuditWith5S(LineId, ProjectId, BatchId, ZoneId, ModuleId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable MailParameterProdQualityAudit(int BatchId)
        {
            try
            {
                return _objCheckListResults.MailParameterProdQualityAudit(BatchId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetFromByA246CFACAMHB1Data()
        {
            try
            {
                return _objCheckListResults.GetFromByA246CFACAMHB1Data();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        //public DataTable GetFromByA246CFACAMHB2Data()
        //{
        //    try
        //    {
        //        return _objCheckListResults.GetFromByA246CFACAMHB2Data();
        //    }
        //    catch (Exception)
        //    {
                
        //        throw;
        //    }
        //}
        public DataTable GetFromByA246CFACAXBARData()
        {
            try
            {
                return _objCheckListResults.GetFromByA246CFACAXBARData();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetFromByA246CFACACTPData()
        {
            try
            {
                return _objCheckListResults.GetFromByA246CFACACTPData();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetFromByA246CFACACTPDataForLine2()
        {
            try
            {
                return _objCheckListResults.GetFromByA246CFACACTPDataForLine2();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetFromByA246CFACAAOIData()
        {
            try
            {
                return _objCheckListResults.GetFromByA246CFACAAOIData();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetFromByA246CFACAInnerMoldData()
        {
            try
            {
                return _objCheckListResults.GetFromByA246CFACAInnerMoldData();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetFromByA246CFACAHankingCData()
        {
            try
            {
                return _objCheckListResults.GetFromByA246CFACAHankingCData();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetFromByA246CFACANewHankingCData()
        {
            try
            {
                return _objCheckListResults.GetFromByA246CFACANewHankingCData();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetFromByA246CFACAWCMCData()
        {
            try
            {
                return _objCheckListResults.GetFromByA246CFACAWCMCData();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetFromByA246CFACAShellcrimpingCData()
        {
            try
            {
                return _objCheckListResults.GetFromByA246CFACAShellcrimpingCData();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetFromByA246CFACACCMData()
        {
            try
            {
                return _objCheckListResults.GetFromByA246CFACACCMData();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetFromByA246CFACAMHB2Data()
        {
            try
            {
                return _objCheckListResults.GetFromByA246CFACAMHB2Data();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetFromByA191LaserData()
        {
            try
            {
                return _objCheckListResults.GetFromByA191LaserData();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetTodo(string EmployeeId)
        {
            return _objCheckListResults.GetTodo(EmployeeId);
        }
        public DataTable GetTodo2(string EmployeeId, int MenuId)
        {
            try
            {
                return _objCheckListResults.GetTodo2(EmployeeId,MenuId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetTaskStatusForCAOICheckList(string EmployeeId)
        {
            try
            {
                return _objCheckListResults.GetTaskStatusForCAOICheckList(EmployeeId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetTaskStatusForMHB1CheckList(string EmployeeId,int TaskId)
        {
            try
            {
                return _objCheckListResults.GetTaskStatusForMHB1CheckList(EmployeeId, TaskId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetTaskStatusForXBarCheckList(string EmployeeId,int TaskId)
        {
            try
            {
                return _objCheckListResults.GetTaskStatusForXBarCheckList(EmployeeId,TaskId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetTaskStatusForA246CCTPChecklist(string EmployeeId,int ResultId,int TaskId)
        {
            try
            {
                return _objCheckListResults.GetTaskStatusForA246CCTPChecklist(EmployeeId,ResultId, TaskId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetTaskStatusForA246CCTPChecklistForLine2(string EmployeeId, int ResultId, int TaskId)
        {
            try
            {
                return _objCheckListResults.GetTaskStatusForA246CCTPChecklistForLine2(EmployeeId,ResultId, TaskId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetTaskStatusForA246CAOIChecklist(string EmployeeId,int TaskId)
        {
            try
            {
                return _objCheckListResults.GetTaskStatusForA246CAOIChecklist(EmployeeId,TaskId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetTaskStatusForA246CINNERMOLDChecklist(string EmployeeId, int TaskId,int ResultId)
        {
            try
            {
                return _objCheckListResults.GetTaskStatusForA246CINNERMOLDChecklist(EmployeeId, TaskId, ResultId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetTaskStatusForA246CHankingChecklist(string EmployeeId, int TaskId, int ResultId)
        {
            try 
	        {	        
		        return _objCheckListResults.GetTaskStatusForA246CHankingChecklist(EmployeeId, TaskId, ResultId);
	        }
	        catch (Exception)
	        {
		
		        throw;
	        }
        }
        public DataTable GetTaskStatusForA246CNewHankingChecklist(string EmployeeId, int TaskId, int ResultId)
        {
            try
            {
                return _objCheckListResults.GetTaskStatusForA246CNewHankingChecklist(EmployeeId, TaskId, ResultId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetTaskStatusForA246CShellcrimpingchecklist(string EmployeeId, int TaskId, int ResultId)
        {
            try
            {
                return _objCheckListResults.GetTaskStatusForA246CShellcrimpingchecklist(EmployeeId, TaskId, ResultId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetTaskStatusForA246CCCMChecklist(string EmployeeId, int TaskId, int ResultId)
        {
            try
            {
                return _objCheckListResults.GetTaskStatusForA246CCCMChecklist(EmployeeId, TaskId, ResultId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetTaskStatusForMHB2CheckList(string EmployeeId, int TaskId, int ResultId)
        {
            try
            {
                return _objCheckListResults.GetTaskStatusForMHB2CheckList(EmployeeId, TaskId, ResultId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetTaskStatusForA191LaserEngraving(string EmployeeId, int TaskId, int ResultId)
        {
            try
            {
                return _objCheckListResults.GetTaskStatusForA191LaserEngraving(EmployeeId, TaskId, ResultId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetTaskStatusForA246WCMChecklist(string EmployeeId, int TaskId, int ResultId)
        {
            try
            {
                return _objCheckListResults.GetTaskStatusForA246WCMChecklist(EmployeeId, TaskId, ResultId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetCTPNGTASK(string EmployeeId)
        {
            try
            {
                return _objCheckListResults.GetCTPNGTASK(EmployeeId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetCTPLINE2NGTASK(string EmployeeId)
        {
            try
            {
                return _objCheckListResults.GetCTPLINE2NGTASK(EmployeeId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetNGTask(string EmployeeId)
        {
            try
            {
                return _objCheckListResults.GetNGTask(EmployeeId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetINNERMOLDTASK(string EmployeeId)
        {
            try
            {
                return _objCheckListResults.GetINNERMOLDTASK(EmployeeId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetHankingTASK(string EmployeeId)
        {
            try
            {
                return _objCheckListResults.GetHankingTASK(EmployeeId);
            }
            
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetNewHankingTASK(string EmployeeId)
        {
            try
            {
                return _objCheckListResults.GetNewHankingTASK(EmployeeId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetShellCrimpingTASK(string EmployeeId)
        {
            try
            {
                return _objCheckListResults.GetShellCrimpingTASK(EmployeeId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetCCMTASK(string EmployeeId)
        {
            try
            {
                return _objCheckListResults.GetCCMTASK(EmployeeId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetHB2TASK(string EmployeeId)
        {
            try
            {
                return _objCheckListResults.GetHB2TASK(EmployeeId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetWCMTASK(string EmployeeId)
        {
            try
            {
                return _objCheckListResults.GetWCMTASK(EmployeeId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetXBarTASK(string EmployeeId)
        {
            try
            {
                return _objCheckListResults.GetXBarTASK(EmployeeId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetA191LASERTASK(string EmployeeId)
        {
            try
            {
                return _objCheckListResults.GetA191LASERTASK(EmployeeId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        //public DataTable RejectTaskForA191LaserFinal(string EmployeeId)
        //{
        //    try
        //    {
        //        return _objCheckListResults.RejectTaskForA191LaserFinal(EmployeeId);
        //    }
        //    catch (Exception)
        //    {
                
        //        throw;
        //    }
        //}
        public DataTable GetHBTASK(string EmployeeId)
        {
            try
            {
                return _objCheckListResults.GetHBTASK(EmployeeId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetTaskStatusForA246CCTPChecklistForLine2(string EmployeeId)
        {
            try
            {
                return _objCheckListResults.GetTaskStatusForA246CCTPChecklistForLine2(EmployeeId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetTaskStatusForMHB1CheckList2(string EmployeeId)
        {
            try
            {
                return _objCheckListResults.GetTaskStatusForMHB1CheckList2(EmployeeId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable ApproveTask(DataTable dtTaskListItem)
        {
            return _objCheckListResults.ApproveTask(dtTaskListItem);
        }

        public DataTable AOIApproveTask(DataTable dtTaskListItem)
        {
            try
            {
                return _objCheckListResults.AOIApproveTask(dtTaskListItem);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable A191LaserRApproveTask(DataTable dtTaskListItem)
        {
            try
            {
                return _objCheckListResults.A191LaserRApproveTask(dtTaskListItem);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable RejectTaskForA191LaserFinal(DataTable dtTaskListItem)
        {
            try
            {
                return _objCheckListResults.RejectTaskForA191LaserFinal(dtTaskListItem);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable XBARApproveTask(DataTable dtTaskListItem)
        {
            try
            {
                return _objCheckListResults.XBARApproveTask(dtTaskListItem);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable CTPApproveTask(DataTable dtTaskListItem)
        {
            try
            {
                return _objCheckListResults.CTPApproveTask(dtTaskListItem);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable CTPRejectTask(DataTable dtTaskListItem)
        {
            try
            {
                return _objCheckListResults.CTPRejectTask(dtTaskListItem);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable XBARApproveTask2(DataTable dtTaskListItem)
        {
            try
            {
                return _objCheckListResults.XBARApproveTask2(dtTaskListItem);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable CTPApproveTaskFinal(DataTable dtTaskListItem)
        {
            try
            {
                return _objCheckListResults.CTPApproveTaskFinal(dtTaskListItem);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable ApproveTaskFinal(DataTable dtTaskListItem)
        {
            try
            {
                return _objCheckListResults.ApproveTaskFinal(dtTaskListItem);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable A191LaserBARApproveTask(DataTable dtTaskListItem)
        {
            try
            {
                return _objCheckListResults.A191LaserBARApproveTask(dtTaskListItem);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable CTPRejectTaskFinal(DataTable dtTaskListItem)
        {
            try
            {
                return _objCheckListResults.CTPRejectTaskFinal(dtTaskListItem);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int RejectApproval(DataTable dtTaskListItem)
        {
            return _objCheckListResults.RejectApproval(dtTaskListItem);
        }
        public int RejectApproval2(DataTable dtTaskListItem)
        {
            try
            {
                return _objCheckListResults.RejectApproval2(dtTaskListItem);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable RejectTaskForAOI(DataTable dtTaskListItem)
        {
            try
            {
                return _objCheckListResults.RejectTaskForAOI(dtTaskListItem);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable RejectTaskForA191Laser(DataTable dtTaskListItem)
        {
            try
            {
                return _objCheckListResults.RejectTaskForA191Laser(dtTaskListItem);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable RejectTaskFinal(DataTable dtTaskListItem)
        {
            try
            {
                return _objCheckListResults.RejectTaskFinal(dtTaskListItem);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable RejectTaskForXBAR(DataTable dtTaskListItem)
        {
            try
            {
                return _objCheckListResults.RejectTaskForXBAR(dtTaskListItem);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable RejectTaskForXBAR2(DataTable dtTaskListItem)
        {
            try
            {
                return _objCheckListResults.RejectTaskForXBAR2(dtTaskListItem);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetProdQualityAuditForRACA()
        {
            try
            {
                return _objCheckListResults.GetProdQualityAuditForRACA();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetFromByA246CParameterNameCheckListOne(int ProjectId, int LineId, int MachineId)
        {
            try
            {
                return _objCheckListResults.GetFromByA246CParameterNameCheckListOne(ProjectId, LineId, MachineId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetParameterFACAProdCheckListQualityAudit()
        {
            try
            {
                return _objCheckListResults.GetParameterFACAProdCheckListQualityAudit();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        //public DataTable GetParameterRACAProdCheckListQualityAudit()
        //{
        //    try
        //    {
        //        return _objCheckListResults.GetParameterRACAProdCheckListQualityAudit();
        //    }
        //    catch (Exception)
        //    {
                
        //        throw;
        //    }
        //}

        public DataTable GetParameterRACAProdCheckListQualityAudit()
        {
            try
            {
                return _objCheckListResults.GetParameterRACAProdCheckListQualityAudit();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetFromByA246CHankingData(int ProjectId, int LineId, int MachineId)
        {
            try
            {
                return _objCheckListResults.GetFromByA246CHankingData(ProjectId,LineId,MachineId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetFromByA246CLaserEngravingData(int ProjectId, int LineId)
        {
            try
            {
                return _objCheckListResults.GetFromByA246CLaserEngravingData(ProjectId,LineId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetFormByA246CWristStrap(int ProjectId, int LineId)
        {
            try
            {
                return _objCheckListResults.GetFormByA246CWristStrap(ProjectId,LineId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetA246CFormByEquipment(int ProjectId, int LineId)
        {
            try
            {
                return _objCheckListResults.GetA246CFormByEquipment(ProjectId,LineId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetFormByA246CCheckListLightLuxInspection(int ProjectId, int LineId)
        {
            try
            {
                return _objCheckListResults.GetFormByA246CCheckListLightLuxInspection(ProjectId,LineId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetFormByA246CCheckListLightLuxNonInspection(int ProjectId, int LineId)
        {
            try
            {
                return _objCheckListResults.GetFormByA246CCheckListLightLuxNonInspection(ProjectId,LineId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetFormByA246CCheckSurfaceImpedence(int ProjectId, int LineId)
        {
            try
            {
                return _objCheckListResults.GetFormByA246CCheckSurfaceImpedence(ProjectId,LineId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetFormByA246CCheckTableMatESD(int ProjectId, int LineId)
        {
            try
            {
                return _objCheckListResults.GetFormByA246CCheckTableMatESD(ProjectId,LineId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetFromByA246CBAndFData(int ProjectId, int LineId, int MachineId)
        {
            try
            {
                return _objCheckListResults.GetFromByA246CBAndFData(ProjectId,LineId,MachineId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetFromByA246CMHB1Data(int ProjectId, int LineId)
        {
            try
            {
                return _objCheckListResults.GetFromByA246CMHB1Data(ProjectId,LineId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetFromByA246CMHB2Data(int ProjectId, int LineId, int MachineId)
        {
            try
            {
                return _objCheckListResults.GetFromByA246CMHB2Data(ProjectId, LineId, MachineId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetFromByProcessTourData(int lineId, int ProjectId, int VisualsId)
        {
            try
            {
                return _objCheckListResults.GetFromByProcessTourData(lineId,ProjectId,VisualsId);
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
                return _objCheckListResults.GetLine();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public List<Batch> GetBatch()
        {
            try
            {
                return _objCheckListResults.GetBatch();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public List<ProcessTourss> GetProcessTours()
        {
            try
            {
                return _objCheckListResults.GetProcessTours();
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
                return _objCheckListResults.GetShift();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public List<InspectionType> GetInspectionType()
        {
            try
            {
                return _objCheckListResults.GetInspectionType();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //public List<Shift> GetShift()
        //{
        //    try
        //    {
        //        return _objCheckListResults.GetShift();
        //    }
        //    catch (Exception)
        //    {
                
        //        throw;
        //    }
        //}

        public int InsertCheckListResult(DataTable dtChecklist, string UserId, Int32 lineId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            try
            {
                return _objCheckListResults.InsertCheckListResult(dtChecklist, UserId, lineId, ProdLineLeader, CheckedBy, ApprovedBy, ModelId,PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        public int InsertBulkA246CCMMC1CheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            try
            {
                return _objCheckListResults.InsertBulkA246CCMMC1CheckList(dtChecklist,userId,  linId, ProdLineLeader,CheckedBy,  ApprovedBy, ModelId, PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int InsertBulkA246CDestructiveMachineCheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            try
            {
                return _objCheckListResults.InsertBulkA246CDestructiveMachineCheckList(dtChecklist,userId,  linId, ProdLineLeader,CheckedBy,  ApprovedBy, ModelId, PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int InsertBulkA246CDMachineCheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            try
            {
                return _objCheckListResults.InsertBulkA246CDMachineCheckList(dtChecklist,userId,  linId, ProdLineLeader,CheckedBy,  ApprovedBy, ModelId, PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int InsertBulkA246CWeighingMachineCheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            try
            {
                return _objCheckListResults.InsertBulkA246CWeighingMachineCheckList(dtChecklist,userId,  linId, ProdLineLeader,CheckedBy,  ApprovedBy, ModelId, PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int InsertBulkA246CNewHankingCheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            try
            {
                return _objCheckListResults.InsertBulkA246CNewHankingCheckList(dtChecklist,userId,  linId, ProdLineLeader,CheckedBy,  ApprovedBy, ModelId, PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int InsertBulkA246CWCMMC1CheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            try
            {
                return _objCheckListResults.InsertBulkA246CWCMMC1CheckList(dtChecklist,userId,  linId, ProdLineLeader,CheckedBy,  ApprovedBy, ModelId, PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBulkA246CShellCrimpMC1CheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            try
            {
                return _objCheckListResults.InsertBulkA246CShellCrimpMC1CheckList(dtChecklist,userId,  linId, ProdLineLeader,CheckedBy,  ApprovedBy, ModelId, PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBulkA246CInnerMoldMCCheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            try
            {
                return _objCheckListResults.InsertBulkA246CInnerMoldMCCheckList(dtChecklist,userId,  linId, ProdLineLeader,CheckedBy,  ApprovedBy, ModelId, PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBulkA246CAOICheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            try
            {
                return _objCheckListResults.InsertBulkA246CAOICheckList(dtChecklist,userId,  linId, ProdLineLeader,CheckedBy,  ApprovedBy, ModelId, PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBulkA246CHankingCheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            try
            {
                return _objCheckListResults.InsertBulkA246CHankingCheckList(dtChecklist,userId,  linId, ProdLineLeader,CheckedBy,  ApprovedBy, ModelId, PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int InsertBulkA246CCTPaameterMCChecklist(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            try
            {
                return _objCheckListResults.InsertBulkA246CCTPaameterMCChecklist(dtChecklist,userId,  linId, ProdLineLeader,CheckedBy,  ApprovedBy, ModelId, PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int InsertBulkA246CCTParameterMCChecklistLine1(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            try
            {
                return _objCheckListResults.InsertBulkA246CCTParameterMCChecklistLine1(dtChecklist,userId,  linId, ProdLineLeader,CheckedBy,  ApprovedBy, ModelId, PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBulkProdQualityAuditCheckList(DataTable dtChecklist, string userId, int LineId, int ProjectId, int BatchId, int ShiftLeaderId, int VerifiedId, string CheckedBy, int ApprovedId, int AuditId,  int ZoneId, int ProdId)
        {
            try
            {
                return _objCheckListResults.InsertBulkProdQualityAuditCheckList(dtChecklist, userId, LineId, ProjectId, BatchId, ShiftLeaderId, VerifiedId, CheckedBy, ApprovedId, AuditId, ZoneId, ProdId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int InsertBulkProdQualityAuditCheckListWith5S(DataTable dtChecklist, string userId, int LineId, int ProjectId, int BatchId, string ProdLineLeader, string ShiftLeader, string VerifiedBy, string CheckedBy, string ApprovedBy, string AuditedBy, int ModelId, int ZoneId, int ProdId)
        {
            try
            {
                return _objCheckListResults.InsertBulkProdQualityAuditCheckListWith5S(dtChecklist, userId, LineId, ProjectId, BatchId, ProdLineLeader, ShiftLeader, VerifiedBy, CheckedBy, ApprovedBy, AuditedBy, ModelId, ZoneId, ProdId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        public int InsertBulkA246CLaserEngravingCheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            try
            {
                return _objCheckListResults.InsertBulkA246CLaserEngravingCheckList(dtChecklist,userId,  linId, ProdLineLeader,CheckedBy,  ApprovedBy, ModelId, PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBulkA246CWristStrapCheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            try
            {
                return _objCheckListResults.InsertBulkA246CWristStrapCheckList(dtChecklist,userId,  linId, ProdLineLeader,CheckedBy,  ApprovedBy, ModelId, PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBulkA246CEquipmentCheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            try
            {
                return _objCheckListResults.InsertBulkA246CEquipmentCheckList(dtChecklist,userId,  linId, ProdLineLeader,CheckedBy,  ApprovedBy, ModelId, PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int InsertBulkA246CCheckListLightLuxInspection(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            try
            {
                return _objCheckListResults.InsertBulkA246CCheckListLightLuxInspection(dtChecklist,userId,  linId, ProdLineLeader,CheckedBy,  ApprovedBy, ModelId, PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBulkA246CCheckListLightLuxNonInspection(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            try
            {
                return _objCheckListResults.InsertBulkA246CCheckListLightLuxNonInspection(dtChecklist,userId,  linId, ProdLineLeader,CheckedBy,  ApprovedBy, ModelId, PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBulkA246CCheckSurfaceImpedence(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            try
            {
                return _objCheckListResults.InsertBulkA246CCheckSurfaceImpedence(dtChecklist,userId,  linId, ProdLineLeader,CheckedBy,  ApprovedBy, ModelId, PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBulkA246CCheckTableMatESD(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            try
            {
                return _objCheckListResults.InsertBulkA246CCheckTableMatESD(dtChecklist,userId,  linId, ProdLineLeader,CheckedBy,  ApprovedBy, ModelId, PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBulkA246CBAndFCheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            try
            {
                return _objCheckListResults.InsertBulkA246CBAndFCheckList(dtChecklist,userId,  linId, ProdLineLeader,CheckedBy,  ApprovedBy, ModelId, PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBulkA246CMHB1CheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            try
            {
                return _objCheckListResults.InsertBulkA246CMHB1CheckList(dtChecklist,userId,  linId, ProdLineLeader,CheckedBy,  ApprovedBy, ModelId, PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBulkA246CMHB2CheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            try
            {
                return _objCheckListResults.InsertBulkA246CMHB2CheckList(dtChecklist,userId,  linId, ProdLineLeader,CheckedBy,  ApprovedBy, ModelId, PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int UpdateCheckListResult(DataTable dtCheckListItem, int ParameterId, int LimitId, string Result, decimal Actual)
        {
            return _objCheckListResults.UpdateCheckListResult(dtCheckListItem, ParameterId, LimitId, Result, Actual);
        }

        public DataTable GetLaserSize(int LineId,int ProjectId)
        {
            try
            {
                return _objCheckListResults.GetLaserSize(LineId, ProjectId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable GetFormByWristStrap(int LineId, int ProjectId)
        {
            try
            {
                return _objCheckListResults.GetFormByWristStrap(LineId, ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetFormByWorkSurface(int LineId, int ProjectId)
        {
            try
            {
                return _objCheckListResults.GetFormByWorkSurface(LineId, ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetFormByInspectionLightLux(int LineId, int ProjectId)
        {
            try
            {
                return _objCheckListResults.GetFormByInspectionLightLux(LineId, ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetFormByNonInspectionLightLux(int LineId, int ProjectId)
        {
            try
            {
                return _objCheckListResults.GetFormByNonInspectionLightLux(LineId, ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetFormByQualityAudit(int LineId, int ProjectId)
        {
            try
            {
                return _objCheckListResults.GetFormByQualityAudit(LineId, ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetFormByCosmetic(int LineId, int ProjectId)
        {
            try
            {
                return _objCheckListResults.GetFormByCosmetic(LineId, ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetFormByCleaningIssue(int LineId, int ProjectId)
        {
            try
            {
                return _objCheckListResults.GetFormByCleaningIssue(LineId, ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetFormByA191FinsihedProduct(int LineId, int ProjectId)
        {
            try
            {
                return _objCheckListResults.GetFormByA191FinsihedProduct(LineId, ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetFormByTemperatureRecord(int LineId)
        {
            try
            {
                return _objCheckListResults.GetFormByTemperatureRecord(LineId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetFormByA246CTemperatureRecordData(int LineId)
        {
            try
            {
                return _objCheckListResults.GetFormByA246CTemperatureRecordData(LineId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetFormByHumidityRecord(int LineId)
        {
            try
            {
                return _objCheckListResults.GetFormByHumidityRecord(LineId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetFormByA246CHumidityRecord(int LineId)
        {
            try
            {
                return _objCheckListResults.GetFormByA246CHumidityRecord(LineId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetFormByEquipment(int LineId, int ProjectId)
        {
            try
            {
                return _objCheckListResults.GetFormByEquipment(LineId, ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertCheckListLaser(DataTable dtChecklist, string userId, int linId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy,int ModelId,int PartId)
        {
            try
            {
                return _objCheckListResults.InsertCheckListLaser(dtChecklist, userId, linId, ProjectId, ProdLineLeader, CheckedBy, ApprovedBy, ModelId, PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBulkA246CCMMC1CheckList(DataTable dtChecklist, string userId, int linId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            try
            {
                return _objCheckListResults.InsertBulkA246CCMMC1CheckList(dtChecklist, userId, linId, ProjectId, ProdLineLeader, CheckedBy, ApprovedBy, ModelId, PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertCheckListWristStrap(DataTable dtChecklist, string userId, int linId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy,int ModelId,int PartId)
        {
            try
            {
                return _objCheckListResults.InsertCheckListWristStrap(dtChecklist, userId, linId, ProjectId, ProdLineLeader, CheckedBy, ApprovedBy, ModelId,PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBulkWorkSurfaceCheckList(DataTable dtChecklist, string userId, int linId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy,int ModelId,int PartId)
        {
            try
            {
                return _objCheckListResults.InsertBulkWorkSurfaceCheckList(dtChecklist, userId, linId, ProjectId, ProdLineLeader, CheckedBy, ApprovedBy, ModelId,PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBulkNonInspectionLightLuxCheckList(DataTable dtChecklist, string userId, int linId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy,int ModelId,int PartId)
        {
            try
            {
                return _objCheckListResults.InsertBulkNonInspectionLightLuxCheckList(dtChecklist, userId, linId, ProjectId, ProdLineLeader, CheckedBy, ApprovedBy, ModelId,PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBulkQualityAuditCheckList(DataTable dtChecklist, string userId, int linId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            try
            {
                return _objCheckListResults.InsertBulkQualityAuditCheckList(dtChecklist, userId, linId, ProjectId, ProdLineLeader, CheckedBy, ApprovedBy, ModelId,PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBulkCosmeticCheckList(DataTable dtChecklist, string userId, int linId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            try
            {
                return _objCheckListResults.InsertBulkCosmeticCheckList(dtChecklist, userId, linId, ProjectId, ProdLineLeader, CheckedBy, ApprovedBy, ModelId,PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertCleanIssuechecklist(DataTable dtChecklist, string userId, int linId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            try
            {
                return _objCheckListResults.InsertCleanIssuechecklist(dtChecklist, userId, linId, ProjectId, ProdLineLeader, CheckedBy, ApprovedBy, ModelId, PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBulkCheckListA191FinsihedProduct(DataTable dtChecklist, string userId, int linId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            try
            {
                return _objCheckListResults.InsertBulkCheckListA191FinsihedProduct(dtChecklist, userId, linId, ProjectId, ProdLineLeader, CheckedBy, ApprovedBy, ModelId, PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBulkCheckListOQCBoxConformation(DataTable dtChecklist, string userId, int linId,string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            try
            {
                return _objCheckListResults.InsertBulkCheckListOQCBoxConformation(dtChecklist, userId, linId,ProdLineLeader, CheckedBy, ApprovedBy, ModelId, PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBulkCheckListFunctionalOOBTracking(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, string Prodll, string qcll)
        {
            try
            {
                return _objCheckListResults.InsertBulkCheckListFunctionalOOBTracking(dtChecklist, userId, linId, ProdLineLeader, CheckedBy, ApprovedBy, Prodll, qcll);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBulkCheckListAppTestFailure(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy)
        {
            try
            {
                return _objCheckListResults.InsertBulkCheckListAppTestFailure(dtChecklist, userId, linId,ProdLineLeader, CheckedBy, ApprovedBy);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBulkTemperatureRecordCheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, string EquipmentSNo)
        {
            try
            {
                return _objCheckListResults.InsertBulkTemperatureRecordCheckList(dtChecklist, userId, linId, ProdLineLeader, CheckedBy, ApprovedBy, EquipmentSNo);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBulkTA246CTemperatureRecordCheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, string EquipmentSNo)
        {
            try
            {
                return _objCheckListResults.InsertBulkTA246CTemperatureRecordCheckList(dtChecklist, userId, linId, ProdLineLeader, CheckedBy, ApprovedBy, EquipmentSNo);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBulkHumidityRecordCheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, string EquipmentSNo)
        {
            try
            {
                return _objCheckListResults.InsertBulkHumidityRecordCheckList(dtChecklist, userId, linId, ProdLineLeader, CheckedBy, ApprovedBy, EquipmentSNo);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int InsertBulkA246CHumidityRecordCheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, string EquipmentSNo)
        {
            try
            {
                return _objCheckListResults.InsertBulkA246CHumidityRecordCheckList(dtChecklist, userId, linId, ProdLineLeader, CheckedBy, ApprovedBy, EquipmentSNo);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBulkCheckListCartonBoxList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy)
        {
            try
            {
                return _objCheckListResults.InsertBulkCheckListCartonBoxList(dtChecklist, userId, linId,ProdLineLeader, CheckedBy, ApprovedBy);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBulkOBACheckList(DataTable dtChecklist, string userId, int LineId, int ProjectId,string BoxNo,string PalletNo, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            try
            {
                return _objCheckListResults.InsertBulkOBACheckList(dtChecklist, userId, LineId, ProjectId,BoxNo,PalletNo, ProdLineLeader, CheckedBy, ApprovedBy, ModelId, PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        public int InsertBulkInspectionLightLuxCheckList(DataTable dtChecklist, string userId, int linId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId,int PartId)
        {
            try
            {
                return _objCheckListResults.InsertBulkInspectionLightLuxCheckList(dtChecklist, userId, linId, ProjectId, ProdLineLeader, CheckedBy, ApprovedBy, ModelId, PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBulkEquipmentCheckList(DataTable dtChecklist, string userId, int linId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy,int ModelId,int PartId)
        {
            try
            {
                return _objCheckListResults.InsertBulkEquipmentCheckList(dtChecklist, userId, linId, ProjectId, ProdLineLeader, CheckedBy, ApprovedBy, ModelId, PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertBulkchecklistProcessTourData(DataTable dtChecklist, string userId, int LineId, int ProjectId, string Model, string ProdLineLeader, string CheckedBy, string ApprovedBy,int ModelId,int PartId)
        {
            try
            {
                return _objCheckListResults.InsertBulkchecklistProcessTourData(dtChecklist, userId, LineId, ProjectId, Model, ProdLineLeader, CheckedBy, ApprovedBy, ModelId, PartId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
