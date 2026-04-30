using DOL;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BAL
{
   public class ReportBAL
    {
        DAL.ReportDAL _ObjReport = new DAL.ReportDAL();

        public DataTable GetParamheCkhlistResult(int ProjectId, int StationId, int SubStationId, int ParameterId, int LimitId, decimal Actual, string Result, string FromDate, string ToDate,int LineId,int shiftId)
        {
            try
            {
                return _ObjReport.GetParamheCkhlistResult(ProjectId, StationId, SubStationId, ParameterId, LimitId, Actual, Result, FromDate, ToDate, LineId,shiftId);
            }
            catch(Exception ex)
            {
                throw;
            }
            
        }

       public DataTable GetParamCheckCircuitResult(string FromDate, int LineId, int shiftId,int ProjectId)
        {
            try
            {
                return _ObjReport.GetParamCheckCircuitResult(FromDate, LineId, shiftId, ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

       public DataTable RptCircuitBoard(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.RptCircuitBoard(FromDate, LineId, shiftId,ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable GetMachineByProject(int ProjectId)
       {
           try
           {
               return _ObjReport.GetMachineByProject(ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable GetParamCheckMaintenanceResult(string FromDate, int LineId, int shiftId, int MachineId, int Projectid)
       {
           try
           {
               return _ObjReport.GetParamCheckMaintenanceResult(FromDate, LineId, shiftId, MachineId,Projectid);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataTable GetParamCheckRDLCMaintenanceResult(string FromDate,string ToDate,int LineId,int ShiftId,int ProjectId)
       {
           try
           {
               return _ObjReport.GetParamCheckRDLCMaintenanceResult(FromDate,ToDate, LineId,ShiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataTable GetParamCheckRDLCMaintenanceResult2(string FromDate, int LineId, int shiftId, int MachineId, int ProjectId)
       {
           try
           {
               return _ObjReport.GetParamCheckRDLCMaintenanceResult2(FromDate, LineId, shiftId, MachineId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable GetParamRDLCCheckPointsResult(string FromDate, int LineId, int shiftId, int MachineId, int ProjectId)
       {
           try
           {
               return _ObjReport.GetParamRDLCCheckPointsResult(FromDate, LineId, shiftId, MachineId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable GetParamRDLCProcessTourData(string FromDate, int LineId, int shiftId, int ProjectId, int VisualsId)
       {
           try
           {
               return _ObjReport.GetParamRDLCProcessTourData(FromDate, LineId, shiftId, ProjectId, VisualsId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }


       public DataTable GetParamCheckPointsResult(string FromDate, int LineId, int shiftId, int MachineId, int ProjectId)
       {
           try
           {
               return _ObjReport.GetParamCheckPointsResult(FromDate, LineId, shiftId, MachineId,ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable GetParameterProcessTourData(string FromDate, int LineId, int shiftId, int ProjectId, int VisualsId)
       {
           try
           {
               return _ObjReport.GetParameterProcessTourData(FromDate, LineId, shiftId, ProjectId, VisualsId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataTable getParameterProcessTourDataa(string FromDate, int LineId, int shiftId, int ProjectId, int VisualsId)
       {
           try
           {
               return _ObjReport.getParameterProcessTourDataa(FromDate, LineId, shiftId, ProjectId, VisualsId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable GetParameterNativeValidation(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.GetParameterNativeValidation(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataTable GetParameterOutGoingInspection(string FromDate, string ToDate, string TrackNumber)
       {
           
           try
           {
               return _ObjReport.GetParameterOutGoingInspection(FromDate, ToDate, TrackNumber);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable Rpt_getParameterCheckListOutGoingInspectionA246C(string FromDate, string ToDate, string TrackNumber)
       {
           try
           {
               return _ObjReport.Rpt_getParameterCheckListOutGoingInspectionA246C(FromDate, ToDate, TrackNumber);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable GetParameterLineAuditCheckpoints(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.GetParameterLineAuditCheckpoints(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable GetParameterCircuitRecordResult(string FromDate, int LineId, int shiftId, int ProjectId, int ProcessTourId)
       {
           try
           {
               return _ObjReport.GetParameterCircuitRecordResult(FromDate, LineId, shiftId, ProjectId,ProcessTourId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable ParameterCTQManPowerCheckList(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.ParameterCTQManPowerCheckList(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataTable ParameterAdhesive(string FromDate, int LineId, int shiftId, int ProjectId, int AdhesiveId)
       {
           try
           {
               return _ObjReport.ParameterAdhesive(FromDate, LineId, shiftId, ProjectId, AdhesiveId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataTable ParameterAdhesive2(int ResultId)
       {
           try
           {
               return _ObjReport.ParameterAdhesive2(ResultId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataTable ParameterTempratureRange(string FromDate, int LineId, int shiftId, int ProjectId, int TempId)
       {
           try
           {
               return _ObjReport.ParameterTempratureRange(FromDate, LineId, shiftId, ProjectId, TempId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataTable ParameterDestructiveTest(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.ParameterDestructiveTest(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataTable ParameterDestructiveTest2(string FromDate,int shiftId)
       {
           try
           {
               return _ObjReport.ParameterDestructiveTest2(FromDate,shiftId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable ParameterNonInspectionLightLux(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.ParameterNonInspectionLightLux(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable ParameterQualityAudit(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.ParameterQualityAudit(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable ParameterOBA(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.ParameterOBA(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
        public DataTable getParameterCosmetic(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.getParameterCosmetic(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       //public DataTable Rpt_getParameterFunctionalOOBTracking(string FromDate, int LineId, int shiftId)
       // {
       //     try
       //     {
       //         return _ObjReport.Rpt_getParameterFunctionalOOBTracking(FromDate, LineId, shiftId);
       //     }
       //     catch (Exception)
       //     {
                
       //         throw;
       //     }
       // }

       public DataTable Rpt_getParameterFunctionalOOBTracking(string FromDate, int LineId, int shiftId)
        {
            try
            {
                return _ObjReport.Rpt_getParameterFunctionalOOBTracking(FromDate, LineId, shiftId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

       public DataTable Rpt_getParameterAppTestFailure(string FromDate, int LineId, int shiftId)
       {
           try
           {
               return _ObjReport.Rpt_getParameterAppTestFailure(FromDate, LineId, shiftId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable Rpt_getParameterCartonBoxList(string FromDate, int LineId, int shiftId)
       {
           try
           {
               return _ObjReport.Rpt_getParameterCartonBoxList(FromDate, LineId, shiftId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable Rpt_getParameterTempratureRecord(string FromDate, int LineId, int shiftId)
       {
           try
           {
               return _ObjReport.Rpt_getParameterTempratureRecord(FromDate, LineId, shiftId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable Rpt_getParameterA246CTempratureRecord(string FromDate, int LineId, int shiftId)
       {
           try
           {
               return _ObjReport.Rpt_getParameterA246CTempratureRecord(FromDate, LineId, shiftId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataTable A246CParameterWristStrap(string FromDate, int LineId, int shiftId,int ProjectId)
       {
           try
           {
               return _ObjReport.A246CParameterWristStrap(FromDate, LineId, shiftId,ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable A246CParameterEquipment(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.A246CParameterEquipment(FromDate, LineId, shiftId,ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable Rpt_getA246CCheckListLightLuxInspection(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.Rpt_getA246CCheckListLightLuxInspection(FromDate, LineId, shiftId,ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataTable Rpt_getA246CCheckListLightNonLuxInspection(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.Rpt_getA246CCheckListLightNonLuxInspection(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataTable Rpt_getA246CCheckTableMatESD(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.Rpt_getA246CCheckTableMatESD(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataTable Rpt_getA246CSurfaceImpedence(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.Rpt_getA246CSurfaceImpedence(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataTable Rpt_getParameterA246CDMachineCheckList(string FromDate, int LineId, int shiftId, int ProjectId,int MachineId)
       {
           try
           {
               return _ObjReport.Rpt_getParameterA246CDMachineCheckList(FromDate, LineId, shiftId, ProjectId, MachineId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataTable Rpt_getParameterProdQualityAudit(string FromDate, int LineId, int shiftId, int ProjectId, int BatchId, int ProdId, int ZoneId, int ModuleId)
       {
           try
           {
               return _ObjReport.Rpt_getParameterProdQualityAudit(FromDate, LineId, shiftId, ProjectId, BatchId,ProdId,ZoneId,ModuleId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataTable Rpt_getParameterProdQualityAuditWith5S(string FromDate, int LineId, int shiftId, int ProjectId, int BatchId, int ProdId, int ZoneId, int ModuleId)
       {
           try
           {
               return _ObjReport.Rpt_getParameterProdQualityAuditWith5S(FromDate, LineId, shiftId, ProjectId, BatchId, ProdId, ZoneId, ModuleId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataTable GetFACADataForA246CCTPaameterMCChecklist()
       {
           try
           {
               return _ObjReport.GetFACADataForA246CCTPaameterMCChecklist();
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataTable Rpt_getParameterA246CNewHankingCheckList(string FromDate, int LineId, int shiftId, int ProjectId, int MachineId, int PartId)
       {
           try
           {
               return _ObjReport.Rpt_getParameterA246CNewHankingCheckList(FromDate, LineId, shiftId, ProjectId, MachineId,PartId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataTable Rpt_getParameterA246CCTPaameterMCChecklist(string FromDate, int LineId, int shiftId, int ProjectId, int MachineId)
       {
           try
           {
               return _ObjReport.Rpt_getParameterA246CCTPaameterMCChecklist(FromDate, LineId, shiftId, ProjectId, MachineId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataTable Rpt_getParameterA246CCTParameterMCChecklistLine1(string FromDate, int LineId, int shiftId, int ProjectId, int MachineId)
       {
           try
           {
               return _ObjReport.Rpt_getParameterA246CCTParameterMCChecklistLine1(FromDate, LineId, shiftId, ProjectId, MachineId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataTable Rpt_getParameterA246CWeighingMachineCheckList(string FromDate, int LineId, int shiftId, int ProjectId, int MachineId)
       {
           try
           {
               return _ObjReport.Rpt_getParameterA246CWeighingMachineCheckList(FromDate, LineId, shiftId, ProjectId, MachineId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       //public DataTable Rpt_getParameterProdQualityAudit(string FromDate, int LineId, int shiftId, int ProjectId, int BatchId, int ProdId, int ZoneId, int ModuleId)
       //{
       //    try
       //    {
       //        return _ObjReport.Rpt_getParameterProdQualityAudit(FromDate, LineId, shiftId, ProjectId, BatchId,ProdId,ZoneId,ModuleId);
       //    }
       //    catch (Exception)
       //    {
               
       //        throw;
       //    }
       //}
       public DataTable Rpt_getParameterA246CDestructiveMachineCheckList(string FromDate, int shiftId, int ProjectId,int MachineId)
       {
           try
           {
               return _ObjReport.Rpt_getParameterA246CDestructiveMachineCheckList(FromDate, shiftId, ProjectId, MachineId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable Rpt_getParameterHumidityRecord(string FromDate, int LineId, int shiftId)
       {
           try
           {
               return _ObjReport.Rpt_getParameterHumidityRecord(FromDate, LineId, shiftId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataTable Rpt_getParameterA246CHumidityRecord(string FromDate, int LineId, int shiftId)
       {
           try
           {
               return _ObjReport.Rpt_getParameterA246CHumidityRecord(FromDate, LineId, shiftId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable Rpt_getParameterA191FinsihedProduct(string FromDate, int LineId, int shiftId,int ProjectId)
       {
           try
           {
               return _ObjReport.Rpt_getParameterA191FinsihedProduct(FromDate, LineId, shiftId,ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable Rpt_getParameterCleaningIssue(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.Rpt_getParameterCleaningIssue(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable Rpt_getParameterFirstAirticleInspection(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.Rpt_getParameterFirstAirticleInspection(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable Rpt_getParameterFirstAirticleInspec(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.Rpt_getParameterFirstAirticleInspec(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable ParameterA246CCMMC1CheckList1(string FromDate, int LineId, int shiftId, int ProjectId, int MachineId)
       {
           try
           {
               return _ObjReport.ParameterA246CCMMC1CheckList1(FromDate, LineId, shiftId, ProjectId,MachineId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable ParameterA246CWCMMC1CheckList(string FromDate, int LineId, int shiftId, int ProjectId, int MachineId)
       {
           try
           {
               return _ObjReport.ParameterA246CWCMMC1CheckList(FromDate, LineId, shiftId, ProjectId,MachineId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable ParameterA246CShellCrimpMC1CheckList(string FromDate, int LineId, int shiftId, int ProjectId, int MachineId)
       {
           try
           {
               return _ObjReport.ParameterA246CShellCrimpMC1CheckList(FromDate, LineId, shiftId, ProjectId,MachineId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable ParameterA246CInnerMoldMCCheckList(string FromDate, int LineId, int shiftId, int ProjectId, int MachineId)
       {
           try
           {
               return _ObjReport.ParameterA246CInnerMoldMCCheckList(FromDate, LineId, shiftId, ProjectId,MachineId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable ParameterA246CBAndFCheckList(string FromDate, int LineId, int shiftId, int ProjectId, int MachineId)
       {
           try
           {
               return _ObjReport.ParameterA246CBAndFCheckList(FromDate, LineId, shiftId, ProjectId,MachineId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
        public DataTable ParameterA246CAOICheckList(string FromDate, int LineId, int shiftId, int ProjectId, int MachineId)
       {
           try
           {
               return _ObjReport.ParameterA246CAOICheckList(FromDate, LineId, shiftId, ProjectId,MachineId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable ParameterA246CHankingCheckList(string FromDate, int LineId, int shiftId, int ProjectId, int MachineId)
        {
            try
            {
                return _ObjReport.ParameterA246CHankingCheckList(FromDate, LineId, shiftId, ProjectId,MachineId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

       public DataTable Rpt_getParameterA246CLaserEngravingData(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.Rpt_getParameterA246CLaserEngravingData(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataTable ParameterA246CMHB1CheckList(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.ParameterA246CMHB1CheckList(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable ParameterA246CMHB2CheckList(string FromDate, int LineId, int shiftId, int ProjectId,int MachineId)
       {
           try
           {
               return _ObjReport.ParameterA246CMHB2CheckList(FromDate, LineId, shiftId, ProjectId, MachineId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable getParameterOQCBoxConformation(string FromDate, int LineId, int shiftId)
        {
            try
            {
                return _ObjReport.getParameterOQCBoxConformation(FromDate, LineId, shiftId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
       public DataTable ParameterInspectionLightLux(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.ParameterInspectionLightLux(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable ParameterEquipment(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.ParameterEquipment(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable ParameterWorkSurface(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.ParameterWorkSurface(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable ParameterWristStrap(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.ParameterWristStrap(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable GetParameterTrapTestChecklist(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.GetParameterTrapTestChecklist(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

        public DataTable GetRDLCParameterNativeValidation(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.GetRDLCParameterNativeValidation(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

        public DataTable GetRDLCParameterListOutGoingInspection(string FromDate, string ToDate, string TrackNumber)
        {
            try
            {
                return _ObjReport.GetRDLCParameterListOutGoingInspection(FromDate, ToDate, TrackNumber);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
       public DataTable Rpt_RDLCgetParameterCheckListOutGoingInspectionA246C(string FromDate, string ToDate, string TrackNumber)
        {
            try
            {
                return _ObjReport.Rpt_RDLCgetParameterCheckListOutGoingInspectionA246C(FromDate, ToDate, TrackNumber);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
       public DataTable GetRDLCParameterCheckListLineAudit(string FromDate, int LineId, int shiftId, int ProjectId)
        {
            try
            {
                return _ObjReport.GetRDLCParameterCheckListLineAudit(FromDate, LineId,shiftId,ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

       public DataTable Rpt_RDLCgetParameterCircuitRecordResult(string FromDate, int LineId, int shiftId, int ProjectId, int ProcessTourId)
       {
           try
           {
               return _ObjReport.Rpt_RDLCgetParameterCircuitRecordResult(FromDate, LineId, shiftId, ProjectId, ProcessTourId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable Rpt_RDLCgetParameterCTQManPowerCheckList(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.Rpt_RDLCgetParameterCTQManPowerCheckList(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable Rpt_RDLCgetParameterXBarChart(string FromDate, int LineId, int shiftId, int ProjectId, int AdhesiveId)
       {
           try
           {
               return _ObjReport.Rpt_RDLCgetParameterXBarChart(FromDate, LineId, shiftId, ProjectId,AdhesiveId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public int UpdateXBar(int ResultId, String FeedBack)
       {
           try
           {
               return _ObjReport.UpdateXBar(ResultId, FeedBack);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataTable GetAdhesiveByResultId(int ResultId)
       {
           try
           {
               return _ObjReport.GetAdhesiveByResultId(ResultId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataTable Rpt_RDLCgetParameterTempratureRange(string FromDate, int LineId, int shiftId, int ProjectId, int TempId)
       {
           try
           {
               return _ObjReport.Rpt_RDLCgetParameterTempratureRange(FromDate, LineId, shiftId, ProjectId,TempId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataTable Rpt_RDLCgetParameterDestructiveTest(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.Rpt_RDLCgetParameterDestructiveTest(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataTable Rpt_RDLCgetParameterNonInspectionLightLux(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.Rpt_RDLCgetParameterNonInspectionLightLux(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataTable Rpt_getRDLCParameterQualityAudit(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.Rpt_getRDLCParameterQualityAudit(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable Rpt_getRDLCParameterOBA(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return  _ObjReport.Rpt_getRDLCParameterOBA(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable Rpt_RDLCgetParameterCosmetic(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return  _ObjReport.Rpt_RDLCgetParameterCosmetic(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable Rpt_RDLCgetParameterFunctionalOOBTracking(string FromDate, int LineId, int shiftId)
       {
           try
           {
               return  _ObjReport.Rpt_RDLCgetParameterFunctionalOOBTracking(FromDate, LineId, shiftId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable Rpt_RDLCgetParameterCheckListAppTestFailure(string FromDate, int LineId, int shiftId)
       {
           try
           {
               return  _ObjReport.Rpt_RDLCgetParameterCheckListAppTestFailure(FromDate, LineId, shiftId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable Rpt_RDLCgetParameterCartonBoxList(string FromDate, int LineId, int shiftId)
       {
           try
           {
               return  _ObjReport.Rpt_RDLCgetParameterCartonBoxList(FromDate, LineId, shiftId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable Rpt_RDLCgetParameterHumidityRecord(string FromDate, int LineId, int shiftId)
       {
           try
           {
               return  _ObjReport.Rpt_RDLCgetParameterHumidityRecord(FromDate, LineId, shiftId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable Rpt_RDLCParameterA191FinsihedProduct(string FromDate, int LineId, int shiftId,int ProjectId)
       {
           try
           {
               return _ObjReport.Rpt_RDLCParameterA191FinsihedProduct(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable Rpt_RDLCgetParameterCleaningIssue(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.Rpt_RDLCgetParameterCleaningIssue(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable Rpt_RDLCgetParameterFirstAirticleInspection(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.Rpt_RDLCgetParameterFirstAirticleInspection(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable Rpt_RDLCgetParameterFirstAirticleInspect(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.Rpt_RDLCgetParameterFirstAirticleInspect(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable Rpt_RDLCgetParameterOQCBoxConformation(string FromDate, int LineId, int shiftId)
       {
           try
           {
               return  _ObjReport.Rpt_RDLCgetParameterOQCBoxConformation(FromDate, LineId, shiftId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataTable Rpt_RDLCgetParameterInspectionLightLux(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.Rpt_RDLCgetParameterInspectionLightLux(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataTable Rpt_RDLCgetParameterEquipment(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.Rpt_RDLCgetParameterEquipment(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataTable Rpt_getRDLCParameterWorkSurface(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.Rpt_getRDLCParameterWorkSurface(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataTable Rpt_RDLCgetParameterWristStrap(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.Rpt_RDLCgetParameterWristStrap(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataTable getRDLCParameterTrapTest(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.getRDLCParameterTrapTest(FromDate, LineId,shiftId,ProjectId);
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
                return _ObjReport.GetLine();
            }
            catch (Exception)
            {

                throw;
            }
        }
       public List<A246COKNG> GETA246COKNG()
        {
            try
            {
                return _ObjReport.GETA246COKNG();
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
                return _ObjReport.GetShift();
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
                return _ObjReport.GetMachine();
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
                return _ObjReport.GetProject();
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
                return _ObjReport.GetA246CMachines();

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetParamLaserEngravingResult(string FromDate, int LineId, int shiftId,int ProjectId)
        {
            try
            {
                return _ObjReport.GetParamLaserEngravingResult(FromDate, LineId, shiftId, ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
       public DataTable Rpt_getParameterA246CPartToInspectCheckList(string FromDate, int LineId, int shiftId, int ProjectId)
        {
            try
            {
                return _ObjReport.Rpt_getParameterA246CPartToInspectCheckList(FromDate, LineId, shiftId, ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
       public DataTable Rpt_getParameterA246CCTPaameterMCChecklist(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           try
           {
               return _ObjReport.Rpt_getParameterA246CCTPaameterMCChecklist(FromDate, LineId, shiftId, ProjectId);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataTable Rpt_getParameterA246CCMMC1CheckList(string FromDate, int LineId, int shiftId, int ProjectId,int MachineId)
        {
            try
            {
                return _ObjReport.Rpt_getParameterA246CCMMC1CheckList(FromDate, LineId, shiftId, ProjectId,MachineId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }


       public DataTable GetRDLCParamLaserEngravingResult(string FromDate, int LineId, int shiftId, int ProjectId)
        {
            try
            {
                return _ObjReport.GetRDLCParamLaserEngravingResult(FromDate,LineId,shiftId,ProjectId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public void generateReports(DataTable rfcDetails, out byte[] rendered, out string mini, string ReportName, string ReportFormate)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(HttpContext.Current.Server.MapPath("~/Reports"), ReportName);
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }


            ReportDataSource rd = new ReportDataSource("DataSet1", rfcDetails);
            lr.DataSources.Add(rd);
            string reportType = ReportFormate;
            string mimeType;
            string encoding;
            string fileNameExtension;
            string deviceInfo = "<DeviceInfo>" +
                //+ "<OutputForma>" + ReportFormate + "</OutputForma>" +
                //"<PageWidth>11in</PageWidth>" +
                //"<PageHeight>11in</PageHeight>" +
                //"<MarginTop>0.5in</MarginTop>" +
                //"<MarginRight>0.1in</MarginRight>" +
                //"<MarginBottom>0.2in</MarginBottom>o.5in" +
                "</DeviceInfo>";
            Warning[] warning;
            string[] streams;
            byte[] renderedBytes;
            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,

                out warning
                );
            rendered = renderedBytes;
            mini = mimeType;

        }
        public void generateReports1(DataTable rfcDetails, out byte[] rendered, out string mini, string ReportName, string ReportFormate)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(HttpContext.Current.Server.MapPath("~/Reports"), ReportName);
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }


            ReportDataSource rd = new ReportDataSource("DataSet1", rfcDetails);
            lr.DataSources.Add(rd);
            string reportType = ReportFormate;
            string mimeType;
            string encoding;
            string fileNameExtension;
            string deviceInfo = "<DeviceInfo>" + "<OutputForma>" + ReportFormate + "</OutputForma>" +
                
                "</DeviceInfo>";
            Warning[] warning;
            string[] streams;
            byte[] renderedBytes;
            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,

                out warning
                );
            rendered = renderedBytes;
            mini = mimeType;

        }

        
    }
}
