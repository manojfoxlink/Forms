using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DOL;

namespace DAL
{
   public class ReportDAL
    {
       DbClass _dbClass;
       public ReportDAL()
       {
           _dbClass = DbClass.GetInstance();
       }

       public DataTable GetParamheCkhlistResult(int ProjectId, int StationId, int SubStationId, int ParameterId, int LimitId,decimal Actual,string Result, string FromDate, string ToDate,int LineId,int shiftId)
       {
           DataTable dt = new DataTable();

           try
           {
               SqlParameter[] sqlParams = { 
                                               new SqlParameter( "@ProjectId", ProjectId ),
                                               //new SqlParameter( "@StationId", StationId ),
                                               //new SqlParameter( "@SubStationId", SubStationId ),
                                               //new SqlParameter( "@ParameterId", ParameterId ),
                                               //new SqlParameter( "@LimitId", LimitId),
                                               //new SqlParameter( "@Actual", Actual),
                                               //new SqlParameter( "@Result", Result),
                                               //new SqlParameter( "@FromDate", FromDate),
                                               //new SqlParameter( "@ToDate", FromDate),
                                               new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId)

                                                };
               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_GetParameterChecklist", sqlParams);

           }
           catch (Exception ex)
           {
               throw;
           }

           return dt;

       }

       public DataTable GetParamCheckCircuitResult(string FromDate, int LineId, int shiftId,int ProjectId)
       {
           DataTable dt = new DataTable();

           try
           {
               SqlParameter[] sqlparam ={

                           new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_GetParameterCheckCircuitRecord", sqlparam);

           }
           catch (Exception)
           {
               
               throw;
           }

           return dt;

       }

       public DataTable RptCircuitBoard(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();

           try
           {
               SqlParameter[] parms ={  
                                          new SqlParameter("@Date",FromDate),
                                          new SqlParameter("@LineId",LineId),
                                          new SqlParameter("@ShiftId",shiftId),
                                          new SqlParameter("@ProjectId",ProjectId)
                                     };
               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_RDLCGetParameterCheckCircuitRecord", parms);
           }
           catch (Exception)
           {

               throw;
           }



           return dt;
       }

       public DataTable GetParamCheckMaintenanceResult(string FromDate, int LineId, int shiftId, int MachineId, int Projectid)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@MachineId",MachineId),
                                               new SqlParameter("@Projectid",Projectid)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("epq.Rpt_getParameterCheckListMaintenance", sqlparam);
           }
           catch (Exception)
           {
               
               throw;
           }
           return dt;
       }

       public DataTable GetParamCheckRDLCMaintenanceResult(string FromDate, string ToDate,int LineId,int shiftId,int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                       new SqlParameter( "@Date2", ToDate),
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("epq.Rpt_RDLCgetParameterCheckListMaintenance", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable GetParamCheckRDLCMaintenanceResult2(string FromDate, int LineId, int shiftId, int MachineId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                      new SqlParameter("@LineId",LineId),
                      new SqlParameter("@ShiftId",shiftId),
                      new SqlParameter("@MachineId",MachineId),
                      new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("epq.Rpt_RDLCgetParameterCheckListMaintenance2", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable GetParamLaserEngravingResult(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterCheckListLaserEngraving", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_getParameterA246CPartToInspectCheckList(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterA246CPartToInspectCheckList", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_getParameterA246CCTPaameterMCChecklist(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterA246CCTPaameterMCChecklist", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_getParameterA246CCMMC1CheckList(string FromDate, int LineId, int shiftId, int ProjectId,int MachineId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterA246CCMMC1CheckList", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable GetRDLCParamLaserEngravingResult(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_RDLCgetParameterCheckListLaserEngraving", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }
       public DataTable GetParamCheckPointsResult(string FromDate, int LineId, int shiftId, int MachineId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@MachineId",MachineId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("epq.Rpt_getParametersCheckPoints", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }


       public DataTable GetParameterProcessTourData(string FromDate, int LineId, int shiftId, int ProjectId, int VisualsId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@VisualsId",VisualsId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterProcessTourData", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable getParameterProcessTourDataa(string FromDate, int LineId, int shiftId, int ProjectId, int VisualsId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@VisualsId",VisualsId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterProcessTourDataa", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable GetParamRDLCCheckPointsResult(string FromDate, int LineId, int shiftId, int MachineId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@MachineId",MachineId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("epq.Rpt_RDLCgetParametersCheckPoints", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable GetParamRDLCProcessTourData(string FromDate, int LineId, int shiftId, int ProjectId, int VisualsId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               
                                               new SqlParameter("@ProjectId",ProjectId),
                                                new SqlParameter("@VisualsId",VisualsId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getRDLCProcessTourData", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable GetParameterNativeValidation(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterNativeValidation", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable GetParameterOutGoingInspection(string FromDate, string ToDate, string TrackNumber)
       {
           DataTable dt = new DataTable();

           try
           {
               SqlParameter[] sqlparam ={
                                               new SqlParameter( "@Date", FromDate),
                                               new SqlParameter( "@ToDate", ToDate),
                                               new SqlParameter("@TrackNumber",TrackNumber)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterCheckListOutGoingInspection", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_getParameterCheckListOutGoingInspectionA246C(string FromDate, string ToDate, string TrackNumber)
       {
           DataTable dt = new DataTable();

           try
           {
               SqlParameter[] sqlparam ={
                                               new SqlParameter( "@Date", FromDate),
                                               new SqlParameter( "@ToDate", ToDate),
                                               new SqlParameter("@TrackNumber",TrackNumber)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterCheckListOutGoingInspectionA246C", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable GetRDLCParameterNativeValidation(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_RDLCgetParameterNativeValidation", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable GetRDLCParameterCheckListLineAudit(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_RDLCgetParameterCheckListLineAudit", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_RDLCgetParameterCircuitRecordResult(string FromDate, int LineId, int shiftId, int ProjectId, int ProcessTourId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@ProcessTourId",ProcessTourId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_RDLCgetParameterCircuitRecordResult", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_RDLCgetParameterCTQManPowerCheckList(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_RDLCgetParameterCTQManPowerCheckList", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_RDLCgetParameterXBarChart(string FromDate, int LineId, int shiftId, int ProjectId, int AdhesiveId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                                new SqlParameter("@AdhesiveId",AdhesiveId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_RDLCgetParameterAdhesive", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_RDLCgetParameterTempratureRange(string FromDate, int LineId, int shiftId, int ProjectId, int TempId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                                new SqlParameter("@TempId",TempId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_RDLCgetParameterTempratureRange", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_RDLCgetParameterDestructiveTest(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                                
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_RDLCgetParameterDestructiveTest", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_RDLCgetParameterNonInspectionLightLux(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                                
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getRDLCParameterNonInspectionLightLux", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_getRDLCParameterQualityAudit(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                                
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getRDLCParameterQualityAudit", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_getRDLCParameterOBA(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                                
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getRDLCParameterOBA", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_RDLCgetParameterCosmetic(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                                
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_RDLCgetParameterCosmetic", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_RDLCgetParameterFunctionalOOBTracking(string FromDate, int LineId, int shiftId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId)
                                               //new SqlParameter("@ProjectId",ProjectId),
                                                
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_RDLCgetParameterFunctionalOOBTracking", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_RDLCgetParameterCheckListAppTestFailure(string FromDate, int LineId, int shiftId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId)
                                               //new SqlParameter("@ProjectId",ProjectId),
                                                
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_RDLCgetParameterCheckListAppTestFailure", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_RDLCgetParameterCartonBoxList(string FromDate, int LineId, int shiftId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId)
                                               //new SqlParameter("@ProjectId",ProjectId),
                                                
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_RDLCgetParameterCartonBoxList", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_RDLCgetParameterHumidityRecord(string FromDate, int LineId, int shiftId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId)
                                               //new SqlParameter("@ProjectId",ProjectId),
                                                
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_RDLCgetParameterHumidityRecord", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_RDLCParameterA191FinsihedProduct(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
                                                
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_RDLCParameterA191FinsihedProduct", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }


       public DataTable Rpt_RDLCgetParameterCleaningIssue(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
                                                
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_RDLCgetParameterCleaningIssue", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_RDLCgetParameterFirstAirticleInspection(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
                                                
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_RDLCgetParameterFirstAirticleInspection", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_RDLCgetParameterFirstAirticleInspect(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
                                                
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_RDLCgetParameterFirstAirticleInspec", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_RDLCgetParameterOQCBoxConformation(string FromDate, int LineId, int shiftId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               //new SqlParameter("@ProjectId",ProjectId),
                                                
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_RDLCgetParameterOQCBoxConformation", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }


       public DataTable Rpt_RDLCgetParameterInspectionLightLux(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                                
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getRDLCParameterInspectionLightLux", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_RDLCgetParameterEquipment(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                                
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getRDLCParameterEquipment", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_getRDLCParameterWorkSurface(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                                
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getRDLCParameterWorkSurface", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_RDLCgetParameterWristStrap(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                                
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getRDLCParameterWristStrap", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable getRDLCParameterTrapTest(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_RDLCgetParameterTrapTest", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable GetParameterLineAuditCheckpoints(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterCheckListLineAudit", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable GetParameterCircuitRecordResult(string FromDate, int LineId, int shiftId, int ProjectId, int ProcessTourId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@ProcessTourId",ProcessTourId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterCircuitRecordResult", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable ParameterCTQManPowerCheckList(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterCTQManPowerCheckList", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable ParameterAdhesive(string FromDate, int LineId, int shiftId, int ProjectId, int AdhesiveId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
                                               ,
                                               new SqlParameter("@AdhesiveId",AdhesiveId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[Rpt_RDLCgetParameterAdhesive]", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable ParameterAdhesive2(int ResultId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@ResultId", ResultId) 
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[Rpt_RDLCgetParameterAdhesiveByResultId]", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public int UpdateXBar(int ResultId, String FeedBack)
       {
           int i = 0; 

          // DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@ResultId", ResultId),
                      new SqlParameter("@FeedBack",FeedBack)
               };

               i = _dbClass.ExecuteNonQueryWithParameter("[ipqc].[UpdateXBar]", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return i;
       }

       public DataTable ParameterTempratureRange(string FromDate, int LineId, int shiftId, int ProjectId, int TempId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@TempId",TempId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterTempratureRange", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable GetAdhesiveByResultId(int ResultId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@ResultId", ResultId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetAdhesiveByResultId", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }


       public DataTable ParameterDestructiveTest(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterDestructiveTest", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable ParameterDestructiveTest2(string FromDate,int shiftId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               //new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId)
                                               //,
                                               //new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[Rpt_getParameterDestructiveTestByShift]", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable ParameterNonInspectionLightLux(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterNonInspectionLightLux", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable ParameterQualityAudit(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterQualityAudit", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable ParameterOBA(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterOBA", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }


       public DataTable getParameterCosmetic(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_GetParameterCheckListCosmetic", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       //public DataTable Rpt_getParameterFunctionalOOBTracking(string FromDate, int LineId, int shiftId)
       //{
       //    DataTable dt = new DataTable();
       //    try
       //    {
       //        SqlParameter[] sqlparam ={

       //               new SqlParameter( "@Date", FromDate),
       //                                        new SqlParameter("@lineId",LineId),
       //                                        new SqlParameter("@ShiftId",shiftId)
       //        };

       //        dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterFunctionalOOBTracking", sqlparam);
       //    }
       //    catch (Exception)
       //    {

       //        throw;
       //    }
       //    return dt;
       //}

       public DataTable getParameterOQCBoxConformation(string FromDate, int LineId, int shiftId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               //new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterOQCBoxConformation", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_getParameterFunctionalOOBTracking(string FromDate, int LineId, int shiftId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               //new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterFunctionalOOBTracking", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_getParameterAppTestFailure(string FromDate, int LineId, int shiftId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               //new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterAppTestFailure", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }


       public DataTable Rpt_getParameterCartonBoxList(string FromDate, int LineId, int shiftId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               //new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterCartonBoxList", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_getParameterTempratureRecord(string FromDate, int LineId, int shiftId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               //new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterTempratureRecord", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_getParameterA246CTempratureRecord(string FromDate, int LineId, int shiftId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId)
                                               //new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterA246CTempratureRecord", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable A246CParameterWristStrap(string FromDate, int LineId, int shiftId,int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getA246CParameterWristStrap", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable A246CParameterEquipment(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getA246CParameterEquipment", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_getA246CCheckListLightLuxInspection(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getA246CCheckListLightLuxInspection", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }
       public DataTable Rpt_getA246CCheckListLightNonLuxInspection(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getA246CCheckListLightNonLuxInspection", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_getA246CCheckTableMatESD(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getA246CCheckTableMatESD", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_getA246CSurfaceImpedence(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getA246CSurfaceImpedence", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_getParameterA246CDMachineCheckList(string FromDate, int LineId, int shiftId, int ProjectId,int MachineId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@MachineId",MachineId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterA246CDMachineCheckList", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_getParameterProdQualityAudit(string FromDate, int LineId, int shiftId, int ProjectId, int BatchId, int ProdId, int ZoneId, int ModuleId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                                               new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@BatchId",BatchId),
                                               new SqlParameter("@ProdId",ProdId),
                                               new SqlParameter("@ZoneId",ZoneId),
                                               new SqlParameter("@ModuleId",ModuleId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterProdQualityAudit", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_getParameterProdQualityAuditWith5S(string FromDate, int LineId, int shiftId, int ProjectId, int BatchId, int ProdId, int ZoneId, int ModuleId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@BatchId",BatchId),
                                               new SqlParameter("@ProdId",ProdId),
                                               new SqlParameter("@ZoneId",ZoneId),
                                               new SqlParameter("@ModuleId",ModuleId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterProdQualityAuditWith5S", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable GetFACADataForA246CCTPaameterMCChecklist()
       {
           DataTable dt = new DataTable();
           try
           {
               dt = _dbClass.ExecuteProcedureForDataTable("ipqc.GetFACADataForA246CCTPaameterMCChecklist");
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_getParameterA246CNewHankingCheckList(string FromDate, int LineId, int shiftId, int ProjectId, int MachineId, int PartId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@MachineId",MachineId),
                                               new SqlParameter("@PartId",PartId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterA246CNewHankingCheckList", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_getParameterA246CCTPaameterMCChecklist(string FromDate, int LineId, int shiftId, int ProjectId, int MachineId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@MachineId",MachineId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterA246CCTPaameterMCChecklist", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_getParameterA246CCTParameterMCChecklistLine1(string FromDate, int LineId, int shiftId, int ProjectId, int MachineId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@MachineId",MachineId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterA246CCTParameterMCChecklistLine1", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_getParameterA246CWeighingMachineCheckList(string FromDate, int LineId, int shiftId, int ProjectId, int MachineId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@MachineId",MachineId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterA246CWeighingMachineCheckList", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       //public DataTable Rpt_getParameterProdQualityAudit(string FromDate, int LineId, int shiftId, int ProjectId, int BatchId, int ProdId, int ZoneId, int ModuleId)
       //{
       //    DataTable dt = new DataTable();
       //    try
       //    {
       //        SqlParameter[] sqlparam ={

       //               new SqlParameter( "@Date", FromDate),
       //                                        new SqlParameter("@lineId",LineId),
       //                                        new SqlParameter("@ShiftId",shiftId),
       //                                        new SqlParameter("@ProjectId",ProjectId),
       //                                        new SqlParameter("@BatchId",BatchId),
       //                                        new SqlParameter("@ProdId",ProdId),
       //                                        new SqlParameter("@ZoneId",ZoneId),
       //                                        new SqlParameter("@ModuleId",ModuleId)
       //        };

       //        dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterProdQualityAudit", sqlparam);
       //    }
       //    catch (Exception)
       //    {

       //        throw;
       //    }
       //    return dt;
       //}

       public DataTable Rpt_getParameterA246CDestructiveMachineCheckList(string FromDate,  int shiftId, int ProjectId,int MachineId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@MachineId",MachineId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterA246CDestructiveMachineCheckList", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_getParameterHumidityRecord(string FromDate, int LineId, int shiftId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               //new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterHumidityRecord", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_getParameterA246CHumidityRecord(string FromDate, int LineId, int shiftId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               //new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterA246CHumidityRecord", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_getParameterA191FinsihedProduct(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterA191FinsihedProduct", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_getParameterCleaningIssue(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterCleaningIssue", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }


       public DataTable Rpt_getParameterFirstAirticleInspection(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterFirstAirticleInspection", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_getParameterFirstAirticleInspec(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterFirstAirticleInspec", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable ParameterA246CCMMC1CheckList1(string FromDate, int LineId, int shiftId, int ProjectId, int MachineId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@MachineId",MachineId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterA246CCMMC1CheckList", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable ParameterA246CWCMMC1CheckList(string FromDate, int LineId, int shiftId, int ProjectId, int MachineId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@MachineId",MachineId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterA246CWCMMC1CheckList", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable ParameterA246CShellCrimpMC1CheckList(string FromDate, int LineId, int shiftId, int ProjectId, int MachineId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@MachineId",MachineId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterA246CShellCrimpMC1CheckList", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable ParameterA246CInnerMoldMCCheckList(string FromDate, int LineId, int shiftId, int ProjectId, int MachineId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@MachineId",MachineId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterA246CInnerMoldMCCheckList", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable ParameterA246CBAndFCheckList(string FromDate, int LineId, int shiftId, int ProjectId, int MachineId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@MachineId",MachineId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterA246CBAndFCheckList", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable ParameterA246CAOICheckList(string FromDate, int LineId, int shiftId, int ProjectId, int MachineId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@MachineId",MachineId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterA246CAOICheckList", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable ParameterA246CHankingCheckList(string FromDate, int LineId, int shiftId, int ProjectId, int MachineId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@MachineId",MachineId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterA246CHankingCheckList", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable Rpt_getParameterA246CLaserEngravingData(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
                                               //new SqlParameter("@MachineId",MachineId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterA246CLaserEngravingData", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable ParameterA246CMHB1CheckList(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterA246CMHB1CheckList", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable ParameterA246CMHB2CheckList(string FromDate, int LineId, int shiftId, int ProjectId,int MachineId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@MachineId",MachineId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterA246CMHB2CheckList", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable ParameterInspectionLightLux(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterInspectionLightLux", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable ParameterEquipment(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterEquipment", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable ParameterWorkSurface(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterWorkSurface", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable ParameterWristStrap(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterWristStrap", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public DataTable GetParameterTrapTestChecklist(string FromDate, int LineId, int shiftId, int ProjectId)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                                               new SqlParameter("@lineId",LineId),
                                               new SqlParameter("@ShiftId",shiftId),
                                               new SqlParameter("@ProjectId",ProjectId)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getParameterTrapTest", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }


       public DataTable GetRDLCParameterListOutGoingInspection(string FromDate, string ToDate, string TrackNumber)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                      new SqlParameter( "@ToDate", ToDate),
                      new SqlParameter("@TrackNumber",TrackNumber)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_RDLCgetParameterCheckListOutGoingInspection", sqlparam);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }


       public DataTable Rpt_RDLCgetParameterCheckListOutGoingInspectionA246C(string FromDate, string ToDate, string TrackNumber)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlParameter[] sqlparam ={

                      new SqlParameter( "@Date", FromDate),
                      new SqlParameter( "@ToDate", ToDate),
                      new SqlParameter("@TrackNumber",TrackNumber)
               };

               dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_RDLCgetParameterCheckListOutGoingInspectionA246C", sqlparam);
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

       public List<A246COKNG> GETA246COKNG()
       {
           List<A246COKNG> listLine = new List<A246COKNG>();
           DataTable dt = new DataTable();
           try
           {
               dt = _dbClass.ExecuteProcedureForDataTable("ipqc.A246COKNGProd");
               foreach (DataRow dr in dt.Rows)
               {
                   listLine.Add(new A246COKNG { Id = Convert.ToInt16(dr[0]), Valuee = dr[1].ToString() });
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
               dt = _dbClass.ExecuteProcedureForDataTable("ipqc.GetShift");
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
    }

    

    
}
