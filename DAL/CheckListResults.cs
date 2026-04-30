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
    public class CheckListResults
    {
        DbClass _DbClass;

        public CheckListResults()
        {
            _DbClass = DbClass.GetInstance();
        }

        public DataTable GetFormByProject(int lineId,int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@LineId",lineId),
                                          new SqlParameter("@ProjectId",ProjectId)
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByProject",parms);
            }
            catch (Exception)
            {
                
                throw;
            }

           

            return dt;
        }

        public DataTable GetFromByA246CCMMC1Dataa(int lineId, int ProjectId,int MachineId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@LineId",lineId),
                                          new SqlParameter("@ProjectId",ProjectId),
                                          new SqlParameter("@MachineId",MachineId)
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFromByA246CCMMC1DataaNew", parms);
            }
            catch (Exception)
            {

                throw;
            }



            return dt;
        }

        public DataTable GetFromByA246CDestructiveMachineCheckList(int lineId, int ProjectId, int MachineId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@LineId",lineId),
                                          new SqlParameter("@ProjectId",ProjectId),
                                          new SqlParameter("@MachineId",MachineId)
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFromByA246CDestructiveMachineCheckList", parms);
            }
            catch (Exception)
            {

                throw;
            }



            return dt;
        }

        public DataTable GetFromByA246CDMachineCheckList(int lineId, int ProjectId, int MachineId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@LineId",lineId),
                                          new SqlParameter("@ProjectId",ProjectId),
                                          new SqlParameter("@MachineId",MachineId)
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFromByA246CDMachineCheckList", parms);
            }
            catch (Exception)
            {

                throw;
            }



            return dt;
        }
        public DataTable GetFromByA246CWeighingMachineCheckList(int lineId, int ProjectId, int MachineId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@LineId",lineId),
                                          new SqlParameter("@ProjectId",ProjectId),
                                          new SqlParameter("@MachineId",MachineId)
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFromByA246CWeighingMachineCheckList", parms);
            }
            catch (Exception)
            {

                throw;
            }



            return dt;
        }

        public DataTable GetFromByA246CNewHankingData(int ProjectId, int lineId, int MachineId, int PartId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@ProjectId",ProjectId),
                                          new SqlParameter("@lineId",lineId),
                                          new SqlParameter("@MachineId",MachineId),
                                           new SqlParameter("@PartId",PartId)
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFromByA246CNewHankingData", parms);
            }
            catch (Exception)
            {

                throw;
            }



            return dt;
        }

        public DataTable GetFromByA246CWCMMC1Data(int ProjectId, int LineId, int MachineId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@ProjectId",ProjectId),
                                          new SqlParameter("@LineId",LineId),
                                          new SqlParameter("@MachineId ",MachineId )
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFromByA246CWCMMC1Data", parms);
            }
            catch (Exception)
            {

                throw;
            }



            return dt;
        }

        public DataTable GetFromByA246CShellCrimpMC1Data(int ProjectId, int LineId, int MachineId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@ProjectId",ProjectId),
                                          new SqlParameter("@LineId",LineId),
                                          new SqlParameter("@MachineId ",MachineId )
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFromByA246CShellCrimpMC1Data", parms);
            }
            catch (Exception)
            {

                throw;
            }



            return dt;
        }

        public DataTable GetFromByA246CInnerMoldMCData(int ProjectId, int LineId, int MachineId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@ProjectId",ProjectId),
                                          new SqlParameter("@LineId",LineId),
                                          new SqlParameter("@MachineId ",MachineId )
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFromByA246CInnerMoldMCData", parms);
            }
            catch (Exception)
            {

                throw;
            }



            return dt;
        }

        public DataTable GetFromByA246CAOIData(int ProjectId, int LineId, int MachineId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@ProjectId",ProjectId),
                                          new SqlParameter("@LineId",LineId),
                                          new SqlParameter("@MachineId ",MachineId )
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFromByA246CAOIData", parms);
            }
            catch (Exception)
            {

                throw;
            }



            return dt;
        }

        public DataTable GetFromByA246CCTPaameterMCChecklist(int ProjectId, int LineId, int MachineId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@ProjectId",ProjectId),
                                          new SqlParameter("@LineId",LineId),
                                          new SqlParameter("@MachineId ",MachineId )
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFromByA246CCTPaameterMCChecklist", parms);
            }
            catch (Exception)
            {

                throw;
            }



            return dt;
        }

        public DataTable GetFormByProdQualityAudit(int LineId, int ProjectId, int BatchId, int ZoneId, int ModuleId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@BatchId",BatchId),
                                               new SqlParameter("@ZoneId",ZoneId),
                                               new SqlParameter("@ModuleId",ModuleId)
                                               
                                           };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByProdQualityAudit", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetFormByProdQualityAuditWith5S(int LineId, int ProjectId, int BatchId, int ZoneId, int ModuleId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@BatchId",BatchId),
                                               new SqlParameter("@ZoneId",ZoneId),
                                               new SqlParameter("@ModuleId",ModuleId)
                                               
                                           };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByProdQualityAuditWith5S", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetFromByA246CParameterNameCheckListOne(int ProjectId, int LineId, int MachineId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@ProjectId",ProjectId),
                                          new SqlParameter("@LineId",LineId),
                                          new SqlParameter("@MachineId ",MachineId )
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFromByA246CParameterNameCheckListOne", parms);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetParameterFACAProdCheckListQualityAudit()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = _DbClass.ExecuteProcedureForDataTable("ipqc.GetParameterFACAProdCheckListQualityAudit");
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetRpt_getParameterProdQualityAuditFORALL()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = _DbClass.ExecuteProcedureForDataTable("ipqc.Rpt_getParameterProdQualityAuditFORALL");
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetMailsForForms()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = _DbClass.ExecuteProcedureForDataTable("ipqc.GetMailsForForms");
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetHotBarFACAByResultId(int ResultId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@ResultId",ResultId)
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetHotBarFACAByResultId", parms);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetXBarFACAByResultId(int ResultId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@ResultId",ResultId)
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetXBarFACAByResultId", parms);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetDataForHBFACA()
        {
            DataTable dt = new DataTable();

            try
            {

                dt = _DbClass.ExecuteProcedureForDataTable("dbo.GetDataForHBFACA");
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        //public DataTable GetLine()
        //{
        //    DataTable dt = new DataTable();

        //    try
        //    {

        //        dt = _DbClass.ExecuteProcedureForDataTable("ipqc.GetLine");
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //    return dt;
        //}

        public DataTable GetDataFromXBarFACA(int ResultId,int TaskId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@ResultId",ResultId),
                                          new SqlParameter("@TaskId",TaskId)
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetDataFromXBarFACA", parms);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetDataFromINNERMOLDFACA(int ResultId, int TaskId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@ResultId",ResultId),
                                          new SqlParameter("@TaskId",TaskId)
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetDataFromINNERMOLDFACA", parms);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        //public DataTable GetDataFromNewHankingFACA(int ResultId, int TaskId)
        //{
        //    DataTable dt = new DataTable();

        //    try
        //    {
        //        SqlParameter[] parms ={
        //                                  new SqlParameter("@ResultId",ResultId),
        //                                  new SqlParameter("@TaskId",TaskId)
        //                             };
        //        dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetDataFromNewHankingFACA", parms);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //    return dt;
        //}

        public DataTable GetDataFromHankingFACA(int ResultId, int TaskId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@ResultId",ResultId),
                                          new SqlParameter("@TaskId",TaskId)
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetDataFromHankingFACA", parms);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }
        public DataTable GetDataFromNewHankingFACA(int ResultId, int TaskId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@ResultId",ResultId),
                                          new SqlParameter("@TaskId",TaskId)
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetDataFromNewHankingFACA", parms);
            }
            catch (Exception)
            {

                throw;
            }
            
            return dt;
        }

        //public DataTable GetDataFromWCMFACA(int ResultId, int TaskId)
        //{
        //    DataTable dt = new DataTable();

        //    try
        //    {
        //        SqlParameter[] parms ={
        //                                  new SqlParameter("@ResultId",ResultId),
        //                                  new SqlParameter("@TaskId",TaskId)
        //                             };
        //        dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetDataFromWCMFACA", parms);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //    return dt;
        //}

        public DataTable GetDataFromWCMFACA(int ResultId, int TaskId)
        {
            //GetDataFromShellCrimpingFACA
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@ResultId",ResultId),
                                          new SqlParameter("@TaskId",TaskId)
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetDataFromWCMFACA", parms);
            }
            catch (Exception)
            {

                throw;
            }
           
            return dt;
        }

        public DataTable GetDataFromCCMFACA(int ResultId, int TaskId)
        {
            //GetDataFromShellCrimpingFACA
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@ResultId",ResultId),
                                          new SqlParameter("@TaskId",TaskId)
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetDataFromCCMFACA", parms);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetDataFromHB2FACA(int ResultId, int TaskId)
        {
            //GetDataFromShellCrimpingFACA
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@ResultId",ResultId),
                                          new SqlParameter("@TaskId",TaskId)
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetDataFromHB2FACA", parms);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetDataFromLaserEngravingFACA(int ResultId, int TaskId)
        {
            //GetDataFromShellCrimpingFACA
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@ResultId",ResultId),
                                          new SqlParameter("@TaskId",TaskId)
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetDataFromLaserEngravingFACA", parms);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetDataFromShellCrimpingFACA(int ResultId, int TaskId)
        {
            //GetDataFromShellCrimpingFACA
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@ResultId",ResultId),
                                          new SqlParameter("@TaskId",TaskId)
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetDataFromShellCrimpingFACA", parms);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetDataFromCTPFACAForLIne2(int ResultId, int TaskId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@ResultId",ResultId),
                                          new SqlParameter("@TaskId",TaskId)
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetDataFromCTPFACAForLIne2", parms);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetDataFromCTPFACA(int ResultId,int TaskId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@ResultId",ResultId),
                                          new SqlParameter("@TaskId",TaskId)
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetDataFromCTPFACA", parms);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetDataFromHBFACA(int ResultId, int TaskId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@ResultId",ResultId),
                                          new SqlParameter("@TaskId",TaskId)
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("dbo.GetDataFromHBFACA", parms);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetDataFromAOIFACA(int ResultId, int TaskId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@ResultId",ResultId),
                                          new SqlParameter("@TaskId",TaskId)
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetDataFromAOIFACA", parms);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetTaskStatus(string ApproveId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@ApproveId",ApproveId)
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("dbo.GetTaskStatus", parms);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        //public DataTable GetParameterRACAProdCheckListQualityAudit()
        //{
        //    DataTable dt = new DataTable();

        //    try
        //    {
        //        dt = _DbClass.ExecuteProcedureForDataTable("ipqc.GetParameterRACAProdCheckListQualityAudit");
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //    return dt;
        //}

        public DataTable GetParameterRACAProdCheckListQualityAudit()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = _DbClass.ExecuteProcedureForDataTable("ipqc.GetParameterRACAProdCheckListQualityAudit");
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetFromByA246CFACAMHB1Data()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = _DbClass.ExecuteProcedureForDataTable("ipqc.GetFromByA246CFACAMHB1Data");
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        //public DataTable GetFromByA246CFACAMHB2Data()
        //{
        //    DataTable dt = new DataTable();

        //    try
        //    {
        //        dt = _DbClass.ExecuteProcedureForDataTable("ipqc.GetFromByA246CFACAMHB2Data");
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //    return dt;
        //}

        public DataTable GetFromByA246CFACAXBARData()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = _DbClass.ExecuteProcedureForDataTable("ipqc.GetFromByA246CFACAXBARData");
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetFromByA246CFACACTPData()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = _DbClass.ExecuteProcedureForDataTable("ipqc.GetFromByA246CFACACTPData");
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetFromByA246CFACACTPDataForLine2()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = _DbClass.ExecuteProcedureForDataTable("ipqc.GetFromByA246CFACACTPDataForLine2");
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetFromByA246CFACAAOIData()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = _DbClass.ExecuteProcedureForDataTable("ipqc.GetFromByA246CFACAAOIData");
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetFromByA246CFACAInnerMoldData()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = _DbClass.ExecuteProcedureForDataTable("ipqc.GetFromByA246CFACAInnerMoldData");
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetFromByA246CFACAHankingCData()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = _DbClass.ExecuteProcedureForDataTable("ipqc.GetFromByA246CFACAHankingCData");
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetFromByA246CFACANewHankingCData()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = _DbClass.ExecuteProcedureForDataTable("ipqc.GetFromByA246CFACANewHankingCData");
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetFromByA246CFACAWCMCData()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = _DbClass.ExecuteProcedureForDataTable("ipqc.GetFromByA246CFACAWCMCData");
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetFromByA246CFACAShellcrimpingCData()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = _DbClass.ExecuteProcedureForDataTable("ipqc.GetFromByA246CFACAShellcrimpingCData");
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetFromByA246CFACACCMData()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = _DbClass.ExecuteProcedureForDataTable("ipqc.GetFromByA246CFACACCMData");
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetFromByA246CFACAMHB2Data()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = _DbClass.ExecuteProcedureForDataTable("ipqc.GetFromByA246CFACAMHB2Data");
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetFromByA191LaserData()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = _DbClass.ExecuteProcedureForDataTable("ipqc.GetFormByFacLaser");
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable MailParameterProdQualityAudit(int BatchId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlParams = {
                                
                                new SqlParameter("@BatchId", BatchId)

                             };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.Rpt_getProdQualityAuditForFACA", sqlParams);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }
        public DataTable GetTodo(string EmployeeId)
        {

            SqlParameter[] sqlParams = {
                                
                                new SqlParameter("@ApproveId", EmployeeId)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[dbo].[GetToTask]", sqlParams);

            return result;
        }

        public DataTable GetTodo2(string EmployeeId, int MenuId)
        {

            SqlParameter[] sqlParams = {
                                
                                new SqlParameter("@ApproveId", EmployeeId),
                                new SqlParameter("@MenuId", MenuId)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetTaskStatusForCAOICheckList]", sqlParams);

            return result;
        }

        public DataTable GetTaskStatusForCAOICheckList(string EmployeeId)
        {

            SqlParameter[] sqlParams = {
                                
                                new SqlParameter("@ApproveId", EmployeeId)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetTaskStatusForCAOICheckList]", sqlParams);

            return result;
        }

        public DataTable GetTaskStatusForMHB1CheckList(string EmployeeId, int TaskId)
        {

            SqlParameter[] sqlParams = {
                                
                                new SqlParameter("@ApproveId", EmployeeId),
                                new SqlParameter("@TaskId", TaskId)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetTaskStatusForMHB1CheckList]", sqlParams);

            return result;
        }

        public DataTable GetTaskStatusForXBarCheckList(string EmployeeId, int TaskId)
        {

            SqlParameter[] sqlParams = {
                                
                                new SqlParameter("@ApproveId", EmployeeId),
                                new SqlParameter("@TaskId", TaskId)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetTaskStatusForXBarCheckList]", sqlParams);

            return result;
        }

        public DataTable GetTaskStatusForA246CCTPChecklist(string EmployeeId, int ResultId,int TaskId)
        {

            SqlParameter[] sqlParams = {
                                
                                new SqlParameter("@ApproveId", EmployeeId),
                                 new SqlParameter("@ResultId", ResultId),
                                  new SqlParameter("@TaskId", TaskId)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetTaskStatusForA246CCTPChecklist]", sqlParams);

            return result;
        }

        public DataTable GetTaskStatusForA246CCTPChecklistForLine2(string EmployeeId, int ResultId, int TaskId)
        {

            SqlParameter[] sqlParams = {
                                
                                new SqlParameter("@ApproveId", EmployeeId),
                                 new SqlParameter("@ResultId", ResultId),
                                  new SqlParameter("@TaskId", TaskId)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetTaskStatusForA246CCTPChecklistForLine2]", sqlParams);

            return result;
        }

        public DataTable GetTaskStatusForA246CAOIChecklist(string EmployeeId,int TaskId)
        {

            SqlParameter[] sqlParams = {
                                
                                new SqlParameter("@ApproveId", EmployeeId),
                                new SqlParameter("@TaskId", TaskId)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetTaskStatusForA246CAOIChecklist]", sqlParams);

            return result;
        }

        public DataTable GetTaskStatusForA246CINNERMOLDChecklist(string EmployeeId, int TaskId,int ResultId)
        {

            SqlParameter[] sqlParams = {
                                
                                new SqlParameter("@ApproveId", EmployeeId),
                                new SqlParameter("@TaskId", TaskId),
                                 new SqlParameter("@ResultId", ResultId)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetTaskStatusForA246CINNERMOLDChecklist]", sqlParams);

            return result;
        }

        public DataTable GetTaskStatusForA246CHankingChecklist(string EmployeeId, int TaskId, int ResultId)
        {

            SqlParameter[] sqlParams = {
                                
                                new SqlParameter("@ApproveId", EmployeeId),
                                new SqlParameter("@TaskId", TaskId),
                                 new SqlParameter("@ResultId", ResultId)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetTaskStatusForA246CHankingChecklist]", sqlParams);

            return result;
        }

        public DataTable GetTaskStatusForA246CNewHankingChecklist(string EmployeeId, int TaskId, int ResultId)
        {

            SqlParameter[] sqlParams = {
                                
                                new SqlParameter("@ApproveId", EmployeeId),
                                new SqlParameter("@TaskId", TaskId),
                                 new SqlParameter("@ResultId", ResultId)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetTaskStatusForA246CNewHankingChecklist]", sqlParams);

            return result;
        }

        public DataTable GetTaskStatusForA246CShellcrimpingchecklist(string EmployeeId, int TaskId, int ResultId)
        {

            SqlParameter[] sqlParams = {
                                
                                new SqlParameter("@ApproveId", EmployeeId),
                                new SqlParameter("@TaskId", TaskId),
                                 new SqlParameter("@ResultId", ResultId)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetTaskStatusForA246CShellcrimpingchecklist]", sqlParams);

            return result;
        }

        public DataTable GetTaskStatusForA246CCCMChecklist(string EmployeeId, int TaskId, int ResultId)
        {

            SqlParameter[] sqlParams = {
                                
                                new SqlParameter("@ApproveId", EmployeeId),
                                new SqlParameter("@TaskId", TaskId),
                                 new SqlParameter("@ResultId", ResultId)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetTaskStatusForA246CCCMChecklist]", sqlParams);

            return result;
        }

        public DataTable GetTaskStatusForMHB2CheckList(string EmployeeId, int TaskId, int ResultId)
        {

            SqlParameter[] sqlParams = {
                                
                                new SqlParameter("@ApproveId", EmployeeId),
                                new SqlParameter("@TaskId", TaskId),
                                 new SqlParameter("@ResultId", ResultId)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetTaskStatusForMHB2CheckList]", sqlParams);

            return result;
        }

        public DataTable GetTaskStatusForA191LaserEngraving(string EmployeeId, int TaskId, int ResultId)
        {

            SqlParameter[] sqlParams = {
                                
                                new SqlParameter("@ApproveId", EmployeeId),
                                new SqlParameter("@TaskId", TaskId),
                                 new SqlParameter("@ResultId", ResultId)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetTaskStatusForA191LaserEngraving]", sqlParams);

            return result;
        }

        public DataTable GetTaskStatusForA246WCMChecklist(string EmployeeId, int TaskId, int ResultId)
        {

            SqlParameter[] sqlParams = {
                                
                                new SqlParameter("@ApproveId", EmployeeId),
                                new SqlParameter("@TaskId", TaskId),
                                 new SqlParameter("@ResultId", ResultId)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetTaskStatusForA246WCMChecklist]", sqlParams);

            return result;
        }

        public DataTable GetCTPNGTASK(string EmployeeId)
        {

            SqlParameter[] sqlParams = {
                                
                                new SqlParameter("@ApproveId", EmployeeId)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetCTPNGTASK]", sqlParams);

            return result;
        }

        public DataTable GetCTPLINE2NGTASK(string EmployeeId)
        {

            SqlParameter[] sqlParams = {
                                
                                new SqlParameter("@ApproveId", EmployeeId)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetCTPLINE2NGTASK]", sqlParams);

            return result;
        }

        public DataTable GetNGTask(string EmployeeId)
        {

            SqlParameter[] sqlParams = {
                                
                                new SqlParameter("@ApproveId", EmployeeId)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetNGTASK]", sqlParams);

            return result;
        }

        public DataTable GetINNERMOLDTASK(string EmployeeId)
        {

            SqlParameter[] sqlParams = {
                                
                                new SqlParameter("@ApproveId", EmployeeId)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetINNERMOLDTASK]", sqlParams);

            return result;
        }

        public DataTable GetHankingTASK(string EmployeeId)
        {

            SqlParameter[] sqlParams = {
                                
                                new SqlParameter("@ApproveId", EmployeeId)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetHankingTASK]", sqlParams);

            return result;
        }
        public DataTable GetWCMTASK(string EmployeeId)
        {

            SqlParameter[] sqlParams = {
                                
                                new SqlParameter("@ApproveId", EmployeeId)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetWCMTASK]", sqlParams);

            return result;
        }

        public DataTable GetNewHankingTASK(string EmployeeId)
        {

            SqlParameter[] sqlParams = {
                                
                                new SqlParameter("@ApproveId", EmployeeId)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetNewHankingTASK]", sqlParams);
            return result;
        }

        public DataTable GetShellCrimpingTASK(string EmployeeId)
        {

            SqlParameter[] sqlParams = {
                                
                                new SqlParameter("@ApproveId", EmployeeId)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetShellCrimpingTASK]", sqlParams);
            return result;
        }

        public DataTable GetCCMTASK(string EmployeeId)
        {

            SqlParameter[] sqlParams = {
                                
                                new SqlParameter("@ApproveId", EmployeeId)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetCCMTASK]", sqlParams);
            return result;
        }

        public DataTable GetHB2TASK(string EmployeeId)
        {

            SqlParameter[] sqlParams = {
                                
                                new SqlParameter("@ApproveId", EmployeeId)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetHB2TASK]", sqlParams);
            return result;
        }

        public DataTable GetXBarTASK(string EmployeeId)
        {

            SqlParameter[] sqlParams = {
                                
                                new SqlParameter("@ApproveId", EmployeeId)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetXBarTASK]", sqlParams);

            return result;
        }

        public DataTable GetA191LASERTASK(string EmployeeId)
        {

            SqlParameter[] sqlParams = {
                                
                                new SqlParameter("@ApproveId", EmployeeId)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetA191LASERTASK]", sqlParams);

            return result;
        }

        //public DataTable RejectTaskForA191LaserFinal(string EmployeeId)
        //{

        //    SqlParameter[] sqlParams = {
                                
        //                        new SqlParameter("@ApproveId", EmployeeId)

        //                     };
        //    DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[RejectTaskForA191LaserFinal]", sqlParams);

        //    return result;
        //}

        public DataTable GetHBTASK(string EmployeeId)
        {

            SqlParameter[] sqlParams = {
                                
                                new SqlParameter("@ApproveId", EmployeeId)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetHBTASK]", sqlParams);

            return result;
        }

        public DataTable GetTaskStatusForA246CCTPChecklistForLine2(string EmployeeId)
        {

            SqlParameter[] sqlParams = {
                                
                                new SqlParameter("@ApproveId", EmployeeId)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetTaskStatusForA246CCTPChecklistForLine2]", sqlParams);

            return result;
        }

        public DataTable GetTaskStatusForMHB1CheckList2(string EmployeeId)
        {

            SqlParameter[] sqlParams = {
                                
                                new SqlParameter("@ApproveId", EmployeeId)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[GetTaskStatusForMHB1CheckList2]", sqlParams);

            return result;
        }

        public DataTable ApproveTask(DataTable dtTaskListItem)
        {

            SqlParameter[] sqlParams = {
                                new SqlParameter("@ApproveList",dtTaskListItem)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[dbo].[ApproveTask]", sqlParams);

            return result;
        }

        public DataTable AOIApproveTask(DataTable dtTaskListItem)
        {

            SqlParameter[] sqlParams = {
                                new SqlParameter("@ApproveList",dtTaskListItem)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[AOIApproveTask]", sqlParams);

            return result;
        }

        public DataTable RejectTaskForA191LaserFinal(DataTable dtTaskListItem)
        {

            SqlParameter[] sqlParams = {
                                new SqlParameter("@ApproveList",dtTaskListItem)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[RejectTaskForA191LaserFinal]", sqlParams);

            return result;
        }

        public DataTable A191LaserRApproveTask(DataTable dtTaskListItem)
        {

            SqlParameter[] sqlParams = {
                                new SqlParameter("@ApproveList",dtTaskListItem)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[A191LaserRApproveTask]", sqlParams);

            return result;
        }

        public DataTable XBARApproveTask(DataTable dtTaskListItem)
        {

            SqlParameter[] sqlParams = {
                                new SqlParameter("@ApproveList",dtTaskListItem)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[XBARApproveTask]", sqlParams);

            return result;
        }

        public DataTable CTPApproveTask(DataTable dtTaskListItem)
        {

            SqlParameter[] sqlParams = {
                                new SqlParameter("@ApproveList",dtTaskListItem)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[CTPApproveTask]", sqlParams);

            return result;
        }

        public DataTable CTPRejectTask(DataTable dtTaskListItem)
        {

            SqlParameter[] sqlParams = {
                                new SqlParameter("@ApproveList",dtTaskListItem)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[CTPRejectTask]", sqlParams);

            return result;
        }

        public DataTable XBARApproveTask2(DataTable dtTaskListItem)
        {

            SqlParameter[] sqlParams = {
                                new SqlParameter("@ApproveList",dtTaskListItem)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[XBARApproveTask2]", sqlParams);

            return result;
        }

        public DataTable CTPApproveTaskFinal(DataTable dtTaskListItem)
        {

            SqlParameter[] sqlParams = {
                                new SqlParameter("@ApproveList",dtTaskListItem)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[CTPApproveTaskFinal]", sqlParams);

            return result;
        }

        public DataTable ApproveTaskFinal(DataTable dtTaskListItem)
        {

            SqlParameter[] sqlParams = {
                                new SqlParameter("@ApproveList",dtTaskListItem)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[ApproveTaskFinal]", sqlParams);

            return result;
        }

        public DataTable A191LaserBARApproveTask(DataTable dtTaskListItem)
        {

            SqlParameter[] sqlParams = {
                                new SqlParameter("@ApproveList",dtTaskListItem)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[A191LaserBARApproveTask]", sqlParams);

            return result;
        }

        public DataTable CTPRejectTaskFinal(DataTable dtTaskListItem)
        {

            SqlParameter[] sqlParams = {
                                new SqlParameter("@ApproveList",dtTaskListItem)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[CTPRejectTaskFinal]", sqlParams);

            return result;
        }

        public int RejectApproval(DataTable dtTaskListItem)
        {
            SqlParameter[] sqlParams = {
                                new SqlParameter("@ApproveList",dtTaskListItem)

                             };
            int result = _DbClass.ExecuteNonQueryWithParameter("[dbo].[RejectTask]", sqlParams);

            return result;
        }

        public int RejectApproval2(DataTable dtTaskListItem)
        {
            SqlParameter[] sqlParams = {
                                new SqlParameter("@ApproveList",dtTaskListItem)

                             };
            int result = _DbClass.ExecuteNonQueryWithParameter("[dbo].[RejectTask2]", sqlParams);

            return result;
        }

        public DataTable RejectTaskForAOI(DataTable dtTaskListItem)
        {
            SqlParameter[] sqlParams = {
                                new SqlParameter("@ApproveList",dtTaskListItem)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[dbo].[RejectTaskForAOI]", sqlParams);

            return result;
        }

        public DataTable RejectTaskForA191Laser(DataTable dtTaskListItem)
        {
            SqlParameter[] sqlParams = {
                                new SqlParameter("@ApproveList",dtTaskListItem)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[RejectTaskForA191Laser]", sqlParams);

            return result;
        }

        public DataTable RejectTaskFinal(DataTable dtTaskListItem)
        {
            SqlParameter[] sqlParams = {
                                new SqlParameter("@ApproveList",dtTaskListItem)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[RejectTaskFinal]", sqlParams);

            return result;
        }

        public DataTable RejectTaskForXBAR(DataTable dtTaskListItem)
        {
            SqlParameter[] sqlParams = {
                                new SqlParameter("@ApproveList",dtTaskListItem)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[RejectTaskForXBAR]", sqlParams);

            return result;
        }
        public DataTable RejectTaskForXBAR2(DataTable dtTaskListItem)
        {
            SqlParameter[] sqlParams = {
                                new SqlParameter("@ApproveList",dtTaskListItem)

                             };
            DataTable result = _DbClass.ExecuteProcedureWithParameterForDataTable("[ipqc].[RejectTaskForXBAR2]", sqlParams);

            return result;
        }


        public DataTable GetProdQualityAuditForRACA()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = _DbClass.ExecuteProcedureForDataTable("[ipqc].[GetParameterFACAProdCheckListQualityAudit]");
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetFromByA246CHankingData(int ProjectId, int LineId, int MachineId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@ProjectId",ProjectId),
                                          new SqlParameter("@LineId",LineId),
                                          new SqlParameter("@MachineId ",MachineId )
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFromByA246CHankingData", parms);
            }
            catch (Exception)
            {

                throw;
            }



            return dt;
        }

        public DataTable GetFromByA246CLaserEngravingData(int ProjectId, int LineId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@ProjectId",ProjectId),
                                          new SqlParameter("@LineId",LineId)
                                          //new SqlParameter("@MachineId ",MachineId )
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFromByA246CLaserEngravingData", parms);
            }
            catch (Exception)
            {

                throw;
            }



            return dt;
        }

        public DataTable GetFormByA246CWristStrap(int ProjectId, int LineId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@ProjectId",ProjectId),
                                          new SqlParameter("@LineId",LineId)
                                          //new SqlParameter("@MachineId ",MachineId )
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByA246CWristStrap", parms);
            }
            catch (Exception)
            {

                throw;
            }



            return dt;
        }

        public DataTable GetA246CFormByEquipment(int ProjectId, int LineId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@ProjectId",ProjectId),
                                          new SqlParameter("@LineId",LineId)
                                          //new SqlParameter("@MachineId ",MachineId )
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetA246CFormByEquipment", parms);
            }
            catch (Exception)
            {

                throw;
            }



            return dt;
        }

        public DataTable GetFormByA246CCheckListLightLuxInspection(int ProjectId, int LineId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@ProjectId",ProjectId),
                                          new SqlParameter("@LineId",LineId)
                                          //new SqlParameter("@MachineId ",MachineId )
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByA246CCheckListLightLuxInspection", parms);
            }
            catch (Exception)
            {

                throw;
            }



            return dt;
        }

        public DataTable GetFormByA246CCheckListLightLuxNonInspection(int ProjectId, int LineId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@ProjectId",ProjectId),
                                          new SqlParameter("@LineId",LineId)
                                          //new SqlParameter("@MachineId ",MachineId )
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByA246CCheckListLightLuxNonInspection", parms);
            }
            catch (Exception)
            {

                throw;
            }



            return dt;
        }

        public DataTable GetFormByA246CCheckSurfaceImpedence(int ProjectId, int LineId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@ProjectId",ProjectId),
                                          new SqlParameter("@LineId",LineId)
                                          //new SqlParameter("@MachineId ",MachineId )
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByA246CCheckSurfaceImpedence", parms);
            }
            catch (Exception)
            {

                throw;
            }



            return dt;
        }

        public DataTable GetFormByA246CCheckTableMatESD(int ProjectId, int LineId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@ProjectId",ProjectId),
                                          new SqlParameter("@LineId",LineId)
                                          //new SqlParameter("@MachineId ",MachineId )
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByA246CCheckTableMatESD", parms);
            }
            catch (Exception)
            {

                throw;
            }



            return dt;
        }


        public DataTable GetFromByA246CBAndFData(int ProjectId, int LineId, int MachineId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@ProjectId",ProjectId),
                                          new SqlParameter("@LineId",LineId),
                                          new SqlParameter("@MachineId ",MachineId )
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFromByA246CBAndFData", parms);
            }
            catch (Exception)
            {

                throw;
            }



            return dt;
        }

        public DataTable GetFromByA246CMHB1Data(int ProjectId, int LineId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@ProjectId",ProjectId),
                                          new SqlParameter("@LineId",LineId)
                                          //new SqlParameter("@MachineId ",MachineId )
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFromByA246CMHB1Data", parms);
            }
            catch (Exception)
            {

                throw;
            }



            return dt;
        }

        public DataTable GetFromByA246CMHB2Data(int ProjectId, int LineId, int MachineId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@ProjectId",ProjectId),
                                          new SqlParameter("@LineId",LineId),
                                          new SqlParameter("@MachineId ",MachineId )
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFromByA246CMHB2Data", parms);
            }
            catch (Exception)
            {

                throw;
            }



            return dt;
        }

        //public DataTable GetFromByA246CMHB2Data(int ProjectId, int LineId)
        //{
        //    DataTable dt = new DataTable();

        //    try
        //    {
        //        SqlParameter[] parms ={
        //                                  new SqlParameter("@ProjectId",ProjectId),
        //                                  new SqlParameter("@LineId",LineId)
        //                                  //new SqlParameter("@MachineId ",MachineId )
        //                             };
        //        dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFromByA246CMHB1Data", parms);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }



        //    return dt;
        //}


        public DataTable GetFromByProcessTourData(int lineId, int ProjectId,int VisualsId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parms ={
                                          new SqlParameter("@LineId",lineId),
                                          new SqlParameter("@ProjectId",ProjectId),
                                          new SqlParameter("@VisualsId",VisualsId)
                                     };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFromByProcessTourData", parms);
            }
            catch (Exception)
            {

                throw;
            }



            return dt;
        }

        //public int InsertCheckListResult(DataTable dtCheckListItem, int ParameterId, int LimitId, string Result, decimal Actual)
        //{
        //    int i = 0;

        //    SqlParameter[] parmeters ={
        //                                 new SqlParameter("@dtCheckListItem ",dtCheckListItem ),
        //                                 new SqlParameter("@ParameterId",ParameterId),
        //                                 new SqlParameter("@LimitId",LimitId),
        //                                 new SqlParameter("@Actual",Actual)
        //                             };

        //    i = _DbClass.ExecuteNonQueryWithParameter("InsertCheckListResult", parmeters);

        //    return i;
        //}

        public int UpdateCheckListResult(DataTable dtChecklist, int ParameterId, int LimitId, string Result, decimal Actual)
        {
            int i = 0;

            SqlParameter[] parmeters ={
                                         new SqlParameter("@CheckListResults",dtChecklist),
                                         new SqlParameter("@ParameterId",ParameterId),
                                         new SqlParameter("@LimitId",LimitId),
                                         new SqlParameter("@Actual",Actual)
                                     };

            i = _DbClass.ExecuteNonQueryWithParameter("UpdateCheckListResult", parmeters);

            return i;
        }

        //public int InsertCheckListResult(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy,int ModelId,int PartId)
        //{
        //    int i = 0;

        //    try
        //    {
        //        SqlParameter[] parmeters ={
        //                                 new SqlParameter("@Checklist",dtChecklist),
        //                                 new SqlParameter("@Createdby",userId),
        //                                 new SqlParameter("@LineId",linId),
        //                                 new SqlParameter("@ProdLineLeader",ProdLineLeader),
        //                                 new SqlParameter("@CheckedBy",CheckedBy),
        //                                 new SqlParameter("@ApprovedBy",ApprovedBy),
        //                                 new SqlParameter("@ModelId",ModelId),
        //                                 new SqlParameter("@PartId",PartId)
        //                             };

        //        i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkchecklist", parmeters);
        //    }
        //    catch (Exception)
        //    {
                
        //        throw;
        //    }
            

        //    return i;
        //}

        public int InsertBulkA246CCMMC1CheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            int i = 0;

            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@Checklist",dtChecklist),
                                         new SqlParameter("@Createdby",userId),
                                         new SqlParameter("@LineId",linId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };

                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkA246CCMMC1CheckList", parmeters);
            }
            catch (Exception)
            {

                throw;
            }


            return i;
        }

        public int InsertBulkA246CDestructiveMachineCheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            int i = 0;

            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@Checklist",dtChecklist),
                                         new SqlParameter("@Createdby",userId),
                                         new SqlParameter("@LineId",linId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };

                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkA246CDestructiveMachineCheckList", parmeters);
            }
            catch (Exception)
            {

                throw;
            }


            return i;
        }

        public int InsertBulkA246CDMachineCheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            int i = 0;

            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@Checklist",dtChecklist),
                                         new SqlParameter("@Createdby",userId),
                                         new SqlParameter("@LineId",linId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };

                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkA246CDMachineCheckList", parmeters);
            }
            catch (Exception)
            {

                throw;
            }


            return i;
        }

        public int InsertBulkA246CWeighingMachineCheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            int i = 0;

            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@Checklist",dtChecklist),
                                         new SqlParameter("@Createdby",userId),
                                         new SqlParameter("@LineId",linId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };

                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkA246CWeighingMachineCheckList", parmeters);
            }
            catch (Exception)
            {

                throw;
            }


            return i;
        }

        public int InsertBulkA246CNewHankingCheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            int i = 0;

            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@Checklist",dtChecklist),
                                         new SqlParameter("@Createdby",userId),
                                         new SqlParameter("@LineId",linId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };

                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkA246CNewHankingCheckList", parmeters);
            }
            catch (Exception)
            {

                throw;
            }


            return i;
        }

        public int InsertBulkA246CWCMMC1CheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            int i = 0;

            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@Checklist",dtChecklist),
                                         new SqlParameter("@Createdby",userId),
                                         new SqlParameter("@LineId",linId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };

                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkA246CWCMMC1CheckList", parmeters);
            }
            catch (Exception)
            {

                throw;
            }


            return i;
        }

        public int InsertBulkA246CShellCrimpMC1CheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            int i = 0;

            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@Checklist",dtChecklist),
                                         new SqlParameter("@Createdby",userId),
                                         new SqlParameter("@LineId",linId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };

                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkA246CShellCrimpMC1CheckList", parmeters);
            }
            catch (Exception)
            {

                throw;
            }


            return i;
        }

        public int InsertBulkA246CInnerMoldMCCheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            int i = 0;

            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@Checklist",dtChecklist),
                                         new SqlParameter("@Createdby",userId),
                                         new SqlParameter("@LineId",linId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };

                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkA246CInnerMoldMCCheckList", parmeters);
            }
            catch (Exception)
            {

                throw;
            }


            return i;
        }

        public int InsertBulkA246CAOICheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            int i = 0;

            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@Checklist",dtChecklist),
                                         new SqlParameter("@Createdby",userId),
                                         new SqlParameter("@LineId",linId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };

                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkA246CAOICheckList", parmeters);
            }
            catch (Exception)
            {

                throw;
            }


            return i;
        }


        public int InsertBulkA246CHankingCheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            int i = 0;

            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@Checklist",dtChecklist),
                                         new SqlParameter("@Createdby",userId),
                                         new SqlParameter("@LineId",linId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };

                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkA246CHankingCheckList", parmeters);
            }
            catch (Exception)
            {

                throw;
            }


            return i;
        }

        public int InsertBulkA246CCTPaameterMCChecklist(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            int i = 0;

            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@Checklist",dtChecklist),
                                         new SqlParameter("@Createdby",userId),
                                         new SqlParameter("@LineId",linId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };

                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkA246CCTPaameterMCChecklist", parmeters);
            }
            catch (Exception)
            {

                throw;
            }


            return i;
        }

        public int InsertBulkA246CCTParameterMCChecklistLine1(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            int i = 0;

            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@Checklist",dtChecklist),
                                         new SqlParameter("@Createdby",userId),
                                         new SqlParameter("@LineId",linId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };

                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkA246CCTParameterMCChecklistLine1", parmeters);
            }
            catch (Exception)
            {

                throw;
            }


            return i;
        }

        public int InsertBulkProdQualityAuditCheckList(DataTable dtChecklist, string userId, int LineId, int ProjectId, int BatchId, int ShiftLeaderId, int VerifiedId, string CheckedBy, int ApprovedId, int AuditId,  int ZoneId, int ProdId)
        {
            int i = 0;
            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@LaserChecklist",dtChecklist),
                                               new SqlParameter("@CreatedBy",userId),
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@BatchId",BatchId),
                                               //new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                               new SqlParameter("@ShiftLeaderId",ShiftLeaderId),
                                               new SqlParameter("@VerifiedId",VerifiedId),
                                               new SqlParameter("@CheckedBy",CheckedBy),
                                               new SqlParameter("@ApprovedId",ApprovedId),
                                               new SqlParameter("@AuditId",AuditId),
                                               //new SqlParameter("@ModelId",ModelId),
                                               new SqlParameter("@ZoneId",ZoneId),
                                               new SqlParameter("@ProdId",ProdId)
                                           };
                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkProdQualityAuditCheckList", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }
            return i;
        }

        public int InsertBulkProdQualityAuditCheckListWith5S(DataTable dtChecklist, string userId, int LineId, int ProjectId, int BatchId, string ProdLineLeader, string ShiftLeader, string VerifiedBy, string CheckedBy, string ApprovedBy, string AuditedBy, int ModelId, int ZoneId, int ProdId)
        {
            int i = 0;
            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@LaserChecklist",dtChecklist),
                                               new SqlParameter("@CreatedBy",userId),
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@BatchId",BatchId),
                                               new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                               new SqlParameter("@ShiftLeader",ShiftLeader),
                                               new SqlParameter("@VerifiedBy",VerifiedBy),
                                               new SqlParameter("@CheckedBy",CheckedBy),
                                               new SqlParameter("@ApprovedBy",ApprovedBy),
                                               new SqlParameter("@AuditedBy",AuditedBy),
                                               new SqlParameter("@ModelId",ModelId),
                                               new SqlParameter("@ZoneId",ZoneId),
                                               new SqlParameter("@ProdId",ProdId)
                                           };
                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkProdQualityAuditCheckListWith5S", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }
            return i;
        }


        public int InsertBulkA246CLaserEngravingCheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            int i = 0;

            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@Checklist",dtChecklist),
                                         new SqlParameter("@Createdby",userId),
                                         new SqlParameter("@LineId",linId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };

                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkA246CLaserEngravingCheckList", parmeters);
            }
            catch (Exception)
            {

                throw;
            }


            return i;
        }

        public int InsertBulkA246CWristStrapCheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            int i = 0;

            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@LaserChecklist",dtChecklist),
                                         new SqlParameter("@Createdby",userId),
                                         new SqlParameter("@LineId",linId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };

                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkA246CWristStrapCheckList", parmeters);
            }
            catch (Exception)
            {

                throw;
            }


            return i;
        }

        public int InsertBulkA246CEquipmentCheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            int i = 0;

            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@LaserChecklist",dtChecklist),
                                         new SqlParameter("@Createdby",userId),
                                         new SqlParameter("@LineId",linId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };

                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkA246CEquipmentCheckList", parmeters);
            }
            catch (Exception)
            {

                throw;
            }


            return i;
        }

        public int InsertBulkA246CBAndFCheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            int i = 0;

            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@Checklist",dtChecklist),
                                         new SqlParameter("@Createdby",userId),
                                         new SqlParameter("@LineId",linId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };

                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkA246CBAndFCheckList", parmeters);
            }
            catch (Exception)
            {

                throw;
            }


            return i;
        }

        public int InsertBulkA246CCheckListLightLuxInspection(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            int i = 0;

            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@LaserChecklist",dtChecklist),
                                         new SqlParameter("@Createdby",userId),
                                         new SqlParameter("@LineId",linId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };

                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkA246CCheckListLightLuxInspection", parmeters);
            }
            catch (Exception)
            {

                throw;
            }


            return i;
        }

        public int InsertBulkA246CCheckListLightLuxNonInspection(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            int i = 0;

            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@LaserChecklist",dtChecklist),
                                         new SqlParameter("@Createdby",userId),
                                         new SqlParameter("@LineId",linId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };

                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkA246CCheckListLightLuxNonInspection", parmeters);
            }
            catch (Exception)
            {

                throw;
            }


            return i;
        }

        public int InsertBulkA246CCheckSurfaceImpedence(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            int i = 0;

            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@LaserChecklist",dtChecklist),
                                         new SqlParameter("@Createdby",userId),
                                         new SqlParameter("@LineId",linId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };

                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkA246CCheckSurfaceImpedence", parmeters);
            }
            catch (Exception)
            {

                throw;
            }


            return i;
        }

        public int InsertBulkA246CCheckTableMatESD(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            int i = 0;

            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@LaserChecklist",dtChecklist),
                                         new SqlParameter("@Createdby",userId),
                                         new SqlParameter("@LineId",linId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };

                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkA246CCheckTableMatESD", parmeters);
            }
            catch (Exception)
            {

                throw;
            }


            return i;
        }



        public int InsertBulkA246CMHB1CheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            int i = 0;

            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@Checklist",dtChecklist),
                                         new SqlParameter("@Createdby",userId),
                                         new SqlParameter("@LineId",linId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };

                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkA246CMHB1CheckList", parmeters);
            }
            catch (Exception)
            {

                throw;
            }


            return i;
        }

        public int InsertBulkA246CMHB2CheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            int i = 0;

            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@Checklist",dtChecklist),
                                         new SqlParameter("@Createdby",userId),
                                         new SqlParameter("@LineId",linId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };

                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkA246CMHB2CheckList", parmeters);
            }
            catch (Exception)
            {

                throw;
            }


            return i;
        }

        public int InsertCheckListLaser(DataTable dtChecklist, string userId, int linId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy,int ModelId,int PartId)
        {
            int i = 0;
            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@LaserChecklist",dtChecklist),
                                         new SqlParameter("@CreatedBy",userId),
                                         new SqlParameter("@LineId",linId),
                                         new SqlParameter("@ProjectId",ProjectId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId),
                                     };
                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertlaserResult", parmeters);

            }
            catch (Exception)
            {
                
                throw;
            }

            return i;
        }

        public int InsertBulkA246CCMMC1CheckList(DataTable dtChecklist, string userId, int linId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            int i = 0;
            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@Checklist",dtChecklist),
                                         new SqlParameter("@CreatedBy",userId),
                                         new SqlParameter("@LineId",linId),
                                         new SqlParameter("@ProjectId",ProjectId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId),
                                     };
                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkA246CCMMC1CheckList", parmeters);

            }
            catch (Exception)
            {

                throw;
            }

            return i;
        }


        public int InsertCheckListWristStrap(DataTable dtChecklist, string userId, int linId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy,int ModelId,int PartId)
        {
            int i = 0;
            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@LaserChecklist",dtChecklist),
                                         new SqlParameter("@CreatedBy",userId),
                                         new SqlParameter("@LineId",linId),
                                         new SqlParameter("@ProjectId",ProjectId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };
                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkWristStrapCheckList", parmeters);

            }
            catch (Exception)
            {

                throw;
            }

            return i;
        }

        public int InsertBulkWorkSurfaceCheckList(DataTable dtChecklist, string userId, int linId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy,int ModelId,int PartId)
        {
            int i = 0;
            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@WorkSurfaceChecklist",dtChecklist),
                                         new SqlParameter("@CreatedBy",userId),
                                         new SqlParameter("@LineId",linId),
                                         new SqlParameter("@ProjectId",ProjectId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };
                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkWorkSurfaceCheckList", parmeters);

            }
            catch (Exception)
            {

                throw;
            }

            return i;
        }

        public int InsertBulkNonInspectionLightLuxCheckList(DataTable dtChecklist, string userId, int linId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy,int ModelId,int PartId)
        {
            int i = 0;
            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@LaserChecklist",dtChecklist),
                                         new SqlParameter("@CreatedBy",userId),
                                         new SqlParameter("@LineId",linId),
                                         new SqlParameter("@ProjectId",ProjectId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };
                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkNonInspectionLightLuxCheckList", parmeters);

            }
            catch (Exception)
            {

                throw;
            }

            return i;
        }

        public int InsertBulkQualityAuditCheckList(DataTable dtChecklist, string userId, int linId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            int i = 0;
            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@LaserChecklist",dtChecklist),
                                         new SqlParameter("@CreatedBy",userId),
                                         new SqlParameter("@LineId",linId),
                                         new SqlParameter("@ProjectId",ProjectId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };
                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkQualityAuditCheckList", parmeters);

            }
            catch (Exception)
            {

                throw;
            }

            return i;
        }

        public int InsertBulkCosmeticCheckList(DataTable dtChecklist, string userId, int linId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            int i = 0;
            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@Checklist",dtChecklist),
                                         new SqlParameter("@CreatedBy",userId),
                                         new SqlParameter("@LineId",linId),
                                         new SqlParameter("@ProjectId",ProjectId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };
                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkCosmeticCheckList", parmeters);

            }
            catch (Exception)
            {

                throw;
            }

            return i;
        }

        public int InsertCleanIssuechecklist(DataTable dtChecklist, string userId, int linId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            int i = 0;
            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@Checklist",dtChecklist),
                                         new SqlParameter("@CreatedBy",userId),
                                         new SqlParameter("@LineId",linId),
                                         new SqlParameter("@ProjectId",ProjectId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };
                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertCleanIssuechecklist", parmeters);

            }
            catch (Exception)
            {

                throw;
            }

            return i;
        }

        public int InsertBulkCheckListA191FinsihedProduct(DataTable dtChecklist, string userId, int linId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            int i = 0;
            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@LaserChecklist",dtChecklist),
                                         new SqlParameter("@CreatedBy",userId),
                                         new SqlParameter("@LineId",linId),
                                         new SqlParameter("@ProjectId",ProjectId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };
                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkCheckListA191FinsihedProduct", parmeters);

            }
            catch (Exception)
            {

                throw;
            }

            return i;
        }

        public int InsertBulkCheckListOQCBoxConformation(DataTable dtChecklist, string userId, int linId,string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            int i = 0;
            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@LaserChecklist",dtChecklist),
                                         new SqlParameter("@CreatedBy",userId),
                                         new SqlParameter("@LineId",linId),
                                         //new SqlParameter("@ProjectId",ProjectId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };
                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkCheckListOQCBoxConformation", parmeters);

            }
            catch (Exception)
            {

                throw;
            }

            return i;
        }

        public int InsertBulkCheckListFunctionalOOBTracking(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, string Prodll, string qcll)
        {
            int i = 0;
            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@LaserChecklist",dtChecklist),
                                         new SqlParameter("@CreatedBy",userId),
                                         new SqlParameter("@LineId",linId),
                                         //new SqlParameter("@ProjectId",ProjectId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@Prodll",Prodll),
                                         new SqlParameter("@qcll",qcll)
                                        // new SqlParameter("@Inpection",Inpection),
                                         //new SqlParameter("@PartId",PartId)
                                     };
                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkCheckListFunctionalOOBTracking", parmeters);

            }
            catch (Exception)
            {

                throw;
            }

            return i;
        }

        public int InsertBulkCheckListAppTestFailure(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy)
        {
            int i = 0;
            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@LaserChecklist",dtChecklist),
                                         new SqlParameter("@CreatedBy",userId),
                                         new SqlParameter("@LineId",linId),
                                         //new SqlParameter("@ProjectId",ProjectId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         //new SqlParameter("@ModelId",ModelId),
                                         //new SqlParameter("@PartId",PartId)
                                     };
                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkCheckListAppTestFailure", parmeters);

            }
            catch (Exception)
            {

                throw;
            }

            return i;
        }


        public int InsertBulkTemperatureRecordCheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, string EquipmentSNo)
        {
            int i = 0;
            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@LaserChecklist",dtChecklist),
                                         new SqlParameter("@CreatedBy",userId),
                                         new SqlParameter("@LineId",linId),
                                         //new SqlParameter("@ProjectId",ProjectId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@EquipmentSNo",EquipmentSNo)
                                         //new SqlParameter("@ModelId",ModelId),
                                         //new SqlParameter("@PartId",PartId)
                                     };
                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkTemperatureRecordCheckList", parmeters);

            }
            catch (Exception)
            {

                throw;
            }

            return i;
        }

        public int InsertBulkTA246CTemperatureRecordCheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, string EquipmentSNo)
        {
            int i = 0;
            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@LaserChecklist",dtChecklist),
                                         new SqlParameter("@CreatedBy",userId),
                                         new SqlParameter("@LineId",linId),
                                         //new SqlParameter("@ProjectId",ProjectId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@EquipmentSNo",EquipmentSNo)
                                         //new SqlParameter("@ModelId",ModelId),
                                         //new SqlParameter("@PartId",PartId)
                                     };
                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkTA246CTemperatureRecordCheckList", parmeters);

            }
            catch (Exception)
            {

                throw;
            }

            return i;
        }

        public int InsertBulkHumidityRecordCheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, string EquipmentSNo)
        {
            int i = 0;
            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@LaserChecklist",dtChecklist),
                                         new SqlParameter("@CreatedBy",userId),
                                         new SqlParameter("@LineId",linId),
                                         //new SqlParameter("@ProjectId",ProjectId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@EquipmentSNo",EquipmentSNo)
                                         //new SqlParameter("@ModelId",ModelId),
                                         //new SqlParameter("@PartId",PartId)
                                     };
                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkHumidityRecordCheckList", parmeters);

            }
            catch (Exception)
            {

                throw;
            }

            return i;
        }

        public int InsertBulkA246CHumidityRecordCheckList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy, string EquipmentSNo)
        {
            int i = 0;
            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@LaserChecklist",dtChecklist),
                                         new SqlParameter("@CreatedBy",userId),
                                         new SqlParameter("@LineId",linId),
                                         //new SqlParameter("@ProjectId",ProjectId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@EquipmentSNo",EquipmentSNo)
                                         //new SqlParameter("@ModelId",ModelId),
                                         //new SqlParameter("@PartId",PartId)
                                     };
                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkA246CHumidityRecordCheckList", parmeters);

            }
            catch (Exception)
            {

                throw;
            }

            return i;
        }


        public int InsertBulkCheckListCartonBoxList(DataTable dtChecklist, string userId, int linId, string ProdLineLeader, string CheckedBy, string ApprovedBy)
        {
            int i = 0;
            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@LaserChecklist",dtChecklist),
                                         new SqlParameter("@CreatedBy",userId),
                                         new SqlParameter("@LineId",linId),
                                         //new SqlParameter("@ProjectId",ProjectId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         //new SqlParameter("@ModelId",ModelId),
                                         //new SqlParameter("@PartId",PartId)
                                     };
                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkCheckListCartonBoxList", parmeters);

            }
            catch (Exception)
            {

                throw;
            }

            return i;
        }

        public int InsertBulkOBACheckList(DataTable dtChecklist, string userId, int LineId, int ProjectId,string BoxNo,string PalletNo, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            int i = 0;
            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@LaserChecklist",dtChecklist),
                                         new SqlParameter("@CreatedBy",userId),
                                         new SqlParameter("@LineId",LineId),
                                         new SqlParameter("@BoxNo",BoxNo),
                                         new SqlParameter("@PalletNo",PalletNo),
                                         new SqlParameter("@ProjectId",ProjectId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };
                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkCheckListOBA", parmeters);

            }
            catch (Exception)
            {

                throw;
            }

            return i;
        }

        public int InsertBulkInspectionLightLuxCheckList(DataTable dtChecklist, string userId, int linId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId,int PartId)
        {
            int i = 0;
            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@LaserChecklist",dtChecklist),
                                         new SqlParameter("@CreatedBy",userId),
                                         new SqlParameter("@LineId",linId),
                                         new SqlParameter("@ProjectId",ProjectId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };
                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkInspectionLightLuxCheckList", parmeters);

            }
            catch (Exception)
            {

                throw;
            }

            return i;
        }

        public int InsertCheckListResult(DataTable dtChecklist, string userId, int linId,string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            int i = 0;
            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@Checklist",dtChecklist),
                                         new SqlParameter("@CreatedBy",userId),
                                         new SqlParameter("@LineId",linId),
                                         //new SqlParameter("@ProjectId",ProjectId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };
                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkchecklist", parmeters);

            }
            catch (Exception)
            {

                throw;
            }

            return i;
        }

        public int InsertBulkEquipmentCheckList(DataTable dtChecklist, string userId, int linId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy,int ModelId,int PartId)
        {
            int i = 0;
            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@LaserChecklist",dtChecklist),
                                         new SqlParameter("@CreatedBy",userId),
                                         new SqlParameter("@LineId",linId),
                                         new SqlParameter("@ProjectId",ProjectId),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId)
                                     };
                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkEquipmentCheckList", parmeters);

            }
            catch (Exception)
            {

                throw;
            }

            return i;
        }
        public  List<Line> GetLine()
        {
            List<Line> listLine = new List<Line>();
            DataTable dt = new DataTable();
            try
            {
                dt = _DbClass.ExecuteProcedureForDataTable("ipqc.GetLine");
                foreach(DataRow dr in dt.Rows)
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

        public List<Batch> GetBatch()
        {
            List<Batch> listLine = new List<Batch>();
            DataTable dt = new DataTable();
            try
            {
                dt = _DbClass.ExecuteProcedureForDataTable("dbo.GetBatch");
                foreach (DataRow dr in dt.Rows)
                {
                    listLine.Add(new Batch { BatchId = Convert.ToInt16(dr[0]), BatchName = dr[1].ToString() });
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listLine;
        }

        public List<ProcessTourss> GetProcessTours()
        {
            List<ProcessTourss> listLine = new List<ProcessTourss>();
            DataTable dt = new DataTable();
            try
            {
                dt = _DbClass.ExecuteProcedureForDataTable("ipqc.GetProcessTours");
                foreach (DataRow dr in dt.Rows)
                {
                    listLine.Add(new ProcessTourss { ProcessTourId = Convert.ToInt16(dr[0]), ProcessTours = dr[1].ToString() });
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
            List<Shift> ListShift = new List<Shift>();

            DataTable dt = new DataTable();

            try
            {
                dt = _DbClass.ExecuteProcedureForDataTable("ipqc.GetShift");

                foreach (DataRow dr in dt.Rows)
                {
                    ListShift.Add(new Shift { ShiftId = Convert.ToInt16(dr[0]), ShiftName = dr[1].ToString() });
                }


            }
            catch (Exception)
            {

                throw;
            }

            return ListShift;
        }

        public List<InspectionType> GetInspectionType()
        {
            List<InspectionType> ListShift = new List<InspectionType>();

            DataTable dt = new DataTable();

            try
            {
                dt = _DbClass.ExecuteProcedureForDataTable("ipqc.GetInspectionType");

                foreach (DataRow dr in dt.Rows)
                {
                    ListShift.Add(new InspectionType { InpectionId = Convert.ToInt16(dr[0]), Inpection = dr[1].ToString() });
                }


            }
            catch (Exception)
            {

                throw;
            }

            return ListShift;
        }

        //public List<Line> GetLine()
        //{
        //    List<Line> listLine = new List<Line>();
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        dt = _DbClass.ExecuteProcedureForDataTable("ipqc.GetLine");
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            listLine.Add(new Line { LineId = Convert.ToInt16(dr[0]), LineName = dr[1].ToString() });
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return listLine;
        //}

        public DataTable GetLaserSize(int LineId, int ProjectId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] param ={
                                          new SqlParameter("@LineId",LineId),
                                          new SqlParameter("@ProjectId",ProjectId)
                                      };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormLaserbyLineId", param);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public DataTable GetFormByWristStrap(int LineId, int ProjectId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] param ={
                                          new SqlParameter("@LineId",LineId),
                                          new SqlParameter("@ProjectId",ProjectId)
                                      };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByWristStrap", param);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public DataTable GetFormByWorkSurface(int LineId, int ProjectId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] param ={
                                          new SqlParameter("@LineId",LineId),
                                          new SqlParameter("@ProjectId",ProjectId)
                                      };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByWorkSurface", param);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public DataTable GetFormByInspectionLightLux(int LineId, int ProjectId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] param ={
                                          new SqlParameter("@LineId",LineId),
                                          new SqlParameter("@ProjectId",ProjectId)
                                      };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByInspectionLightLux", param);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public DataTable GetFormByNonInspectionLightLux(int LineId, int ProjectId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] param ={
                                          new SqlParameter("@LineId",LineId),
                                          new SqlParameter("@ProjectId",ProjectId)
                                      };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByNonInspectionLightLux", param);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public DataTable GetFormByQualityAudit(int LineId, int ProjectId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] param ={
                                          new SqlParameter("@LineId",LineId),
                                          new SqlParameter("@ProjectId",ProjectId)
                                      };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByQualityAudit", param);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public DataTable GetFormByCosmetic(int LineId, int ProjectId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] param ={
                                          new SqlParameter("@LineId",LineId),
                                          new SqlParameter("@ProjectId",ProjectId)
                                      };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByCosmetic", param);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public DataTable GetFormByCleaningIssue(int LineId, int ProjectId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] param ={
                                          new SqlParameter("@LineId",LineId),
                                          new SqlParameter("@ProjectId",ProjectId)
                                      };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByCleaningIssue", param);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public DataTable GetFormByA191FinsihedProduct(int LineId, int ProjectId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] param ={
                                          new SqlParameter("@LineId",LineId),
                                          new SqlParameter("@ProjectId",ProjectId)
                                      };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByA191FinsihedProduct", param);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public DataTable GetFormByTemperatureRecord(int LineId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] param ={
                                          new SqlParameter("@LineId",LineId)
                                          //new SqlParameter("@ProjectId",ProjectId)
                                      };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByTemperatureRecord", param);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public DataTable GetFormByA246CTemperatureRecordData(int LineId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] param ={
                                          new SqlParameter("@LineId",LineId)
                                          //new SqlParameter("@ProjectId",ProjectId)
                                      };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByA246CTemperatureRecordData", param);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public DataTable GetFormByHumidityRecord(int LineId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] param ={
                                          new SqlParameter("@LineId",LineId)
                                          //new SqlParameter("@ProjectId",ProjectId)
                                      };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByHumidityRecord", param);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }
        public DataTable GetFormByA246CHumidityRecord(int LineId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] param ={
                                          new SqlParameter("@LineId",LineId)
                                          //new SqlParameter("@ProjectId",ProjectId)
                                      };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByA246CHumidityRecordData", param);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }


        public DataTable GetFormByEquipment(int LineId, int ProjectId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] param ={
                                          new SqlParameter("@LineId",LineId),
                                          new SqlParameter("@ProjectId",ProjectId)
                                      };
                dt = _DbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByEquipment", param);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public int InsertBulkchecklistProcessTourData(DataTable dtChecklist, string userId, int LineId, int ProjectId, string Model, string ProdLineLeader, string CheckedBy, string ApprovedBy,int ModelId,int PartId)
        {
            int i = 0;
            try
            {
                SqlParameter[] parmeters ={
                                         new SqlParameter("@Checklist",dtChecklist),
                                         new SqlParameter("@CreatedBy",userId),
                                         new SqlParameter("@LineId",LineId),
                                         new SqlParameter("@ProjectId",ProjectId),
                                         new SqlParameter("@Model",Model),
                                         new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                         new SqlParameter("@CheckedBy",CheckedBy),
                                         new SqlParameter("@ApprovedBy",ApprovedBy),
                                         new SqlParameter("@ModelId",ModelId),
                                         new SqlParameter("@PartId",PartId),
                                     };
                i = _DbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkchecklistProcessTourData", parmeters);

            }
            catch (Exception)
            {

                throw;
            }

            return i;
        }


    }

}
