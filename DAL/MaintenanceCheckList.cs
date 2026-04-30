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
    public class MaintenanceCheckList
    {
        DbClass _dbClass;
        public MaintenanceCheckList()
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

        public int InsertCheckListMaintenanceResult(DataTable dtChecklist, string userId, int LineId, string DRILeader, string LineLeader)
        {
            int i = 0;
            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@Checklist",dtChecklist),
                                               new SqlParameter("@CreatedBy",userId),
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@DRILeader",DRILeader),
                                               new SqlParameter("@LineLeader",LineLeader),
                                           };
                i = _dbClass.ExecuteNonQueryWithParameter("epq.InsertBulkMaintenanceCheckList", sqlparams);
            }
            catch (Exception)
            {
                
                throw;
            }
            return i;
        }

        public DataTable GetFormByMaintenance(int LineId, int MachineId, int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@MachineId",MachineId),
                                               new SqlParameter("@ProjectId",ProjectId)
                                           };
                dt = _dbClass.ExecuteProcedureWithParameterForDataTable("[epq].[GetFromByMaintenance]",sqlparams);
            }
            catch (Exception)
            {
                
                throw;
            }

            return dt;
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

                DataTable dt = _dbClass.ExecuteProcedureForDataTable("[epq].[GetProject]");
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

        public List<DOL.Freqq> GetFrequency()
        {
            List<DOL.Freqq> listProject = new List<DOL.Freqq>();


            try
            {

                DataTable dt = _dbClass.ExecuteProcedureForDataTable("[epq].[GetFreq]");
                foreach (DataRow dr in dt.Rows)
                {
                    listProject.Add(new DOL.Freqq { FreqId = Convert.ToInt32(dr["FreqId"]), Freq = dr["Freq"].ToString() });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listProject;
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


    }

    public class CheckListNativeValidation
    {
        DbClass _dbClass;

        public CheckListNativeValidation()
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

        public int InsertCheckListNativeValiadtion(DataTable dtChecklist, string userId, int LineId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy,int ModelId,int PartId)
        {
            int i = 0;
            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@Checklist",dtChecklist),
                                               new SqlParameter("@CreatedBy",userId),
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                               new SqlParameter("@CheckedBy",CheckedBy),
                                               new SqlParameter("@ApprovedBy",ApprovedBy),
                                               new SqlParameter("@ModelId",ModelId),
                                               new SqlParameter("@PartId",PartId)
                                           };
                i = _dbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkNativeProduction", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }
            return i;
        }

        public int InsertBulkA246CPartToInspectCheckList(DataTable dtChecklist, string userId, int LineId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy, int ModelId, int PartId)
        {
            int i = 0;
            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@Checklist",dtChecklist),
                                               new SqlParameter("@CreatedBy",userId),
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                               new SqlParameter("@CheckedBy",CheckedBy),
                                               new SqlParameter("@ApprovedBy",ApprovedBy),
                                               new SqlParameter("@ModelId",ModelId),
                                               new SqlParameter("@PartId",PartId)
                                           };
                i = _dbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkA246CPartToInspectCheckList", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }
            return i;
        }

        public int InsertBulkProdQualityAuditCheckList(DataTable dtChecklist, string userId, int LineId, int ProjectId, int BatchId, string ProdLineLeader, string ShiftLeader, string VerifiedBy, string CheckedBy, string ApprovedBy, string AuditedBy, int ModelId, int ZoneId, int ProdId)
        {
            int i = 0;
            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@Checklist",dtChecklist),
                                               new SqlParameter("@CreatedBy",userId),
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ProjectId",ProjectId),
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
                i = _dbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkProdQualityAuditCheckList", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }
            return i;
        }

        public int InsertCheckListLineAudit(DataTable dtChecklist, string userId, int LineId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy,int ModelId,int PartId)
        {
            int i = 0;
            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@LaserChecklist",dtChecklist),
                                               new SqlParameter("@CreatedBy",userId),
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                               new SqlParameter("@CheckedBy",CheckedBy),
                                               new SqlParameter("@ApprovedBy",ApprovedBy),
                                               new SqlParameter("@ModelId",ModelId)
                                               ,new SqlParameter("@PartId",PartId)
                                           };
                i = _dbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkLineAuditCheckList", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }
            return i;
        }

        public int InsertCheckListCircuitRecord(DataTable dtChecklist, string userId, int LineId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy,int ModelId,int PartId)
        {
            int i = 0;
            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@Checklist",dtChecklist),
                                               new SqlParameter("@CreatedBy",userId),
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                               new SqlParameter("@CheckedBy",CheckedBy),
                                               new SqlParameter("@ApprovedBy",ApprovedBy),
                                               new SqlParameter("@ModelId",ModelId),
                                               new SqlParameter("@PartId",PartId),
                                           };
                i = _dbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkchecklistCircuitRecordResult", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }
            return i;
        }

        public int InsertBulkCTQManPowerCheckList(DataTable dtChecklist, string userId, int LineId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy,int ModelId,int PartId)
        {
            int i = 0;

            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@Checklist",dtChecklist),
                                               new SqlParameter("@CreatedBy",userId),
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                               new SqlParameter("@CheckedBy",CheckedBy),
                                               new SqlParameter("@ApprovedBy",ApprovedBy),
                                               new SqlParameter("@ModelId",ModelId),
                                               new SqlParameter("@PartId",PartId)
                                           };
                i = _dbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkCTQManPowerCheckList", sqlparams);
            }
            catch (Exception)
            {
                
                throw;
            }

            return i;
        }

        public int InsertBulkAdhesiveCheckList(DataTable dtChecklist, string userId, int LineId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy,int ModelId,int PartId)
        {
            int i = 0;

            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@LaserChecklist",dtChecklist),
                                               new SqlParameter("@CreatedBy",userId),
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                               new SqlParameter("@CheckedBy",CheckedBy),
                                               new SqlParameter("@ApprovedBy",ApprovedBy),
                                               new SqlParameter("@ModelId",ModelId),
                                               new SqlParameter("@PartId",PartId)
                                           };
                i = _dbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkAdhesiveCheckList", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }

            return i;
        }
        //,model.EquipmentNo,model.TypeNo
        public int InsertBulkTemperatureRangeCheckList(DataTable dtChecklist, string userId, int LineId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy, string EquipmentNo, string TypeNo,int ModelId,int PartId)
        {
            int i = 0;

            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@LaserChecklist",dtChecklist),
                                               new SqlParameter("@CreatedBy",userId),
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                               new SqlParameter("@CheckedBy",CheckedBy),
                                               new SqlParameter("@ApprovedBy",ApprovedBy),
                                               new SqlParameter("@EquipmentNo",EquipmentNo),
                                               new SqlParameter("@TypeNo",TypeNo),
                                               new SqlParameter("@ModelId",ModelId),
                                               new SqlParameter("@PartId",PartId)
                                           };
                i = _dbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkTemparatureRangeCheckList", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }

            return i;
        }

        public int InsertCheckListTrapTest(DataTable dtChecklist, string userId, int LineId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy,int ModelId,int PartId)
        {
            int i = 0;
            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@Checklist",dtChecklist),
                                               new SqlParameter("@CreatedBy",userId),
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                               new SqlParameter("@CheckedBy",CheckedBy),
                                               new SqlParameter("@ApprovedBy",ApprovedBy),
                                               new SqlParameter("@ModelId",ModelId),
                                               new SqlParameter("@PartId",PartId)
                                           };
                i = _dbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkTrapTest", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }
            return i;
        }

        public int InsertBulkDestructive(DataTable dtChecklist, string userId, int LineId, int ProjectId, string ProdLineLeader, string CheckedBy, string ApprovedBy,int ModelId,int PartId)
        {
            int i = 0;
            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@Checklist",dtChecklist),
                                               new SqlParameter("@CreatedBy",userId),
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                               new SqlParameter("@CheckedBy",CheckedBy),
                                               new SqlParameter("@ApprovedBy",ApprovedBy),
                                               new SqlParameter("@ModelId",ModelId),
                                               new SqlParameter("@PartId",PartId),
                                           };
                i = _dbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkDestructive", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }
            return i;
        }

        public int InsertBulkRACAProdQualityAuditCheckList(DataTable dtChecklist, string userId)
        {
            int i = 0;
            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@LaserChecklist",dtChecklist),
                                               new SqlParameter("@CreatedBy",userId)
                                           };
                i = _dbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkRACAProdQualityAuditCheckList", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }
            return i;
        }

        public int InsertBulkFACAProdQualityAuditCheckList(DataTable dtChecklist, string userId)
        {
            int i = 0;
            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@LaserChecklist",dtChecklist),
                                               new SqlParameter("@CreatedBy",userId)
                                           };
                i = _dbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkFACAProdQualityAuditCheckList", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }
            return i;
        }

        public DataTable InsertBulkA246CMHB2FACACheckList(DataTable dtChecklist, string userId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@Checklist",dtChecklist),
                                               new SqlParameter("@CreatedBy",userId)
                                           };
                dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.InsertBulkA246CMHB2FACACheckList", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public DataTable InsertBulkA191MLASERFACACheckList(DataTable dtChecklist, string userId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@Checklist",dtChecklist),
                                               new SqlParameter("@CreatedBy",userId)
                                           };
                dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.InsertBulkA191MLASERFACACheckList", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public DataTable InsertBulkXBARFACACheckList(DataTable dtChecklist, string userId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@Checklist",dtChecklist),
                                               new SqlParameter("@CreatedBy",userId)
                                           };
                dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.InsertBulkXBARFACACheckList", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public DataTable InsertBulkA246CCTPFACACheckList(DataTable dtChecklist, string userId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@Checklist",dtChecklist),
                                               new SqlParameter("@CreatedBy",userId)
                                           };
                dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.InsertBulkA246CCTPFACACheckList", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }
        public DataTable InsertBulkA246CCTPFACACheckListForLine2(DataTable dtChecklist, string userId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@Checklist",dtChecklist),
                                               new SqlParameter("@CreatedBy",userId)
                                           };
                dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.InsertBulkA246CCTPFACACheckListForLine2", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public DataTable InsertBulkA246CAOIFACACheckList(DataTable dtChecklist, string userId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@Checklist",dtChecklist),
                                               new SqlParameter("@CreatedBy",userId)
                                           };
                dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.InsertBulkA246CAOIFACACheckList", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public DataTable InsertBulkA246CINNERMOLDFACACheckList(DataTable dtChecklist, string userId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@Checklist",dtChecklist),
                                               new SqlParameter("@CreatedBy",userId)
                                           };
                dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.InsertBulkA246CINNERMOLDFACACheckList", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public DataTable InsertBulkA246CHankingFACACheckList(DataTable dtChecklist, string userId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@Checklist",dtChecklist),
                                               new SqlParameter("@CreatedBy",userId)
                                           };
                dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.InsertBulkA246CHankingFACACheckList", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public DataTable InsertBulkA246CNewHankingFACACheckList(DataTable dtChecklist, string userId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@Checklist",dtChecklist),
                                               new SqlParameter("@CreatedBy",userId)
                                           };
                dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.InsertBulkA246CNewHankingFACACheckList", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public DataTable InsertBulkA246CWCMFACACheckList(DataTable dtChecklist, string userId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@Checklist",dtChecklist),
                                               new SqlParameter("@CreatedBy",userId)
                                           };
                dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.InsertBulkA246CWCMFACACheckList", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public DataTable InsertBulkA246CShellCrimpingFACACheckList(DataTable dtChecklist, string userId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@Checklist",dtChecklist),
                                               new SqlParameter("@CreatedBy",userId)
                                           };
                dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.InsertBulkA246CShellCrimpingFACACheckList", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public DataTable InsertBulkA246CCCMFACACheckList(DataTable dtChecklist, string userId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@Checklist",dtChecklist),
                                               new SqlParameter("@CreatedBy",userId)
                                           };
                dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.InsertBulkA246CCCMFACACheckList", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public DataTable InsertBulkA246CMHB1FACACheckList(DataTable dtChecklist, string userId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@Checklist",dtChecklist),
                                               new SqlParameter("@CreatedBy",userId)
                                           };
                dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.InsertBulkA246CMHB1FACACheckList", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }



        public int InsertCheckListOutInspection(DataTable dtChecklist, string userId, int LineId, int ProjectId,  string CheckedBy, string ApprovedBy, string CustomerPin, string LotSize, string FinishedProductNo, string Rev, string PackingListNo, bool InspectResult)
        {
            int i = 0;
            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@Checklist",dtChecklist),
                                               new SqlParameter("@CreatedBy",userId),
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               //new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                               new SqlParameter("@CheckedBy",CheckedBy),
                                               new SqlParameter("@ApprovedBy",ApprovedBy),
                                               new SqlParameter("@CustomerPin",CustomerPin),
                                               new SqlParameter("@LotSize",LotSize),
                                               new SqlParameter("@FinishedProductNo",FinishedProductNo),
                                               new SqlParameter("@Rev",Rev),
                                               new SqlParameter("@PackingListNo",PackingListNo),
                                               new SqlParameter("@InspectResult",InspectResult)
                                           };
                i = _dbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkOutGoingInspection", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }
            return i;
        }

        public int InsertCheckListOutInspectionA246C(DataTable dtChecklist, string userId, int LineId, int ProjectId, string CheckedBy, string ApprovedBy, string CustomerPin, string LotSize, string FinishedProductNo, string Rev, string PackingListNo,string SimToolPartNumber, bool InspectResult)
        {
            int i = 0;
            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@Checklist",dtChecklist),
                                               new SqlParameter("@CreatedBy",userId),
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               //new SqlParameter("@ProdLineLeader",ProdLineLeader),
                                               new SqlParameter("@CheckedBy",CheckedBy),
                                               new SqlParameter("@ApprovedBy",ApprovedBy),
                                               new SqlParameter("@CustomerPin",CustomerPin),
                                               new SqlParameter("@LotSize",LotSize),
                                               new SqlParameter("@FinishedProductNo",FinishedProductNo),
                                               new SqlParameter("@Rev",Rev),
                                               new SqlParameter("@PackingListNo",PackingListNo),
                                               new SqlParameter("@SimToolPartNumber",SimToolPartNumber),
                                               new SqlParameter("@InspectResult",InspectResult)
                                           };
                i = _dbClass.ExecuteNonQueryWithParameter("ipqc.InsertBulkOutGoingInspectionA246C", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }
            return i;
        }

        public DataTable GetFormByNativeValiadtion(int LineId, int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ProjectId",ProjectId)
                                               
                                           };
                dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByNative", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetFormByA246CPartToInspect(int LineId, int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ProjectId",ProjectId)
                                               
                                           };
                dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByA246CPartToInspect", sqlparams);
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
                dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByProdQualityAudit", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetFormByOutInspection(int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@ProjectId",ProjectId)
                                               
                                           };
                dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByOutInspection", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetMailParameterProdQualityAudit()
        {
            DataTable dt = new DataTable();

            try
            {
                //SqlParameter[] sqlparams = {
                //                               new SqlParameter("@ProjectId",ProjectId)
                                               
                //                           };
                dt = _dbClass.ExecuteQueryForDataTable("ipqc.Rpt_getMailParameterProdQualityAudit");
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetFormByAuditCheckPoints(int LineId, int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ProjectId",ProjectId)
                                               
                                           };
                dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByAuditCheckPoints", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetFormByCircuitBoardRecord(int LineId, int ProjectId, int ProcessTourId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@ProcessTourId",ProcessTourId)
                                           };
                dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByCircuitBoardRecord", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetFormByCTQManPower(int LineId, int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ProjectId",ProjectId)
                                               
                                           };
                dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByCTQManPower", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetFormByAdhesive(int LineId, int ProjectId,int AdhesiveId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@AdhesiveId",AdhesiveId)
                                               
                                           };
                dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByAdhesive", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetFormByTemparatureRange(int LineId, int ProjectId, int TempId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ProjectId",ProjectId),
                                               new SqlParameter("@TempId",TempId)
                                               
                                           };
                dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByTemparatureRange", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetFormByDestructiveTest(int LineId, int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ProjectId",ProjectId)
                                               
                                           };
                dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByDestructiveTest", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }


        public DataTable GetFormByTrapTest(int LineId, int ProjectId)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] sqlparams = {
                                               new SqlParameter("@LineId",LineId),
                                               new SqlParameter("@ProjectId",ProjectId)
                                               
                                           };
                dt = _dbClass.ExecuteProcedureWithParameterForDataTable("ipqc.GetFormByTrapTest", sqlparams);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

    }
}
