using BAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Providers.Entities;


namespace ChecklistForm.Models
{
    public class MailsForQuality
    {
        //string ConStr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            EmployeeBAL empBAL = new EmployeeBAL();
            ReportBAL _objRpt = new ReportBAL();
            BAL.CheckListResults _checkResult = new BAL.CheckListResults();
            public void NotificationEmail(string Mail,int ResultId,string Type,int TaskId)
            {
                string name = string.Empty;
                string Body = string.Empty;
                string Subject = string.Empty;
                string MailTo = string.Empty;
                string WarehouseType = string.Empty;
                //Employee empBAL = new Employee();
                // empDAL.GetEmployee(Managerid);
                //name = ApproveName;
                //MailTo = type;
                //  WarehouseType = emp.Rows[0]["WareHouseType"].ToString();

                if (Type == "HBRejectFirst")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailHBContentRejectFirst(emailsdt, ResultId, TaskId);
                    Subject = "A246C HOT BAR VALIDATION NG ALERT";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "HBReject")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailHBContentReject(emailsdt, ResultId,TaskId);
                    Subject = "A246C HOT BAR APPROVE NG ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "HBFACA")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailContentHOTBARFACA(emailsdt, ResultId,TaskId);
                    Subject = "A246C HOT BAR FACA ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "HBApprove")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailContentHBApproval(emailsdt, ResultId,TaskId);
                    //  Body = GetEmailContent(name, Convert.ToString(PID));
                    Subject = "A246C HOT BAR VALIDATION ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "HBApproveLast")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailHBContentApproveLast(emailsdt, ResultId, TaskId);
                    //  Body = GetEmailContent(name, Convert.ToString(PID));
                    Subject = "A246C HOT BAR APPROVE ALERT!";
                    SendEmailByService2(Mail, name, Body, Subject);
                }
                
                else if (Type == "XBARFACA")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailContentXBAR(emailsdt, ResultId,TaskId);
                    Subject = "GLUE WEIGHING FACA ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "XBarApprove")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailContentXBarApproval(emailsdt, ResultId,TaskId);
                    //  Body = GetEmailContent(name, Convert.ToString(PID));
                    Subject = "GLUE WEIGHING VALIDATION ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "XBarReject")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailXBarContentReject(emailsdt, ResultId,TaskId);
                    Subject = "GLUE WEIGHING APPROVE NG  ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "XBarRejectFirst")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailXBarContentRejectFirst(emailsdt, ResultId,TaskId);
                    Subject = "GLUE WEIGHING VALIDATION NG ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "XBarApproveLast")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailXBarContentApproveLast(emailsdt, ResultId,TaskId);
                    Subject = "GLUE WEIGHING APPROVE ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "CTPFACA")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailContentCTP(emailsdt, ResultId, TaskId);
                    Subject = "A246C CTP PARAMETER LINE-1 FACA ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "CTPApproveLast")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailCTPContentApproveLast(emailsdt, ResultId, TaskId);
                    Subject = "A246C CTP PARAMETER LINE-1 APPROVE ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                
                else if (Type == "CTPApprove")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailContentCTPApproval(emailsdt, ResultId, TaskId);
                    //  Body = GetEmailContent(name, Convert.ToString(PID));
                    Subject = "A246C CTP PARAMETER LINE-1 VALIDATION ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "CTPReject")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailCTPContentReject(emailsdt, ResultId,TaskId);
                    Subject = "A246C CTP PARAMETER LINE-1 APPROVE NG  ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "CTPRejectFirst")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailCTPContentRejectFirst(emailsdt, ResultId,TaskId);
                    Subject = "A246C CTP PARAMETER LINE-1 VALIDATION NG ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "CTPFACALine2")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailContentCTPLine2(emailsdt, ResultId, TaskId);
                    Subject = "A246C CTP PARAMETER LINE-2 FACA ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "CTPLine2Approve")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailContentCTPLine2Approval(emailsdt, ResultId, TaskId);
                    //  Body = GetEmailContent(name, Convert.ToString(PID));
                    Subject = "A246C CTP PARAMETER LINE-2 VALIDATION ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                
                else if (Type == "CTPLine2ApproveLast")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailCTPLine2ContentApproveLast(emailsdt, ResultId, TaskId);
                    Subject = "A246C CTP PARAMETER LINE-2 APPROVE ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "CTPLine2Reject")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailCTPLIne2ContentReject(emailsdt, ResultId, TaskId);
                    Subject = "A246C CTP PARAMETER LINE-2 APPROVE NG  ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "CTPLine2RejectFirst")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailCTPLine2ContentRejectFirst(emailsdt, ResultId, TaskId);
                    Subject = "A246C CTP PARAMETER LINE-2 VALIDATION NG ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "AOIFACA")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailContentAOI(emailsdt, ResultId, TaskId);
                    Subject = "A246C AOI FACA ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "AOIApprove")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailContentAOIApproval(emailsdt, ResultId, TaskId);
                    //  Body = GetEmailContent(name, Convert.ToString(PID));
                    Subject = "A246C AOI VALIDATION ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }

                else if (Type == "AOIRejectFirst")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailAOIContentRejectFirst(emailsdt, ResultId, TaskId);
                    Subject = "A246C AOI VALIDATION NG ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }

                else if (Type == "AOIApproveLast")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailAOIContentApproveLast(emailsdt, ResultId, TaskId);
                    Subject = "A246C AOI APPROVE ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "AOIReject")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailAOIContentReject(emailsdt, ResultId, TaskId);
                    Subject = "A246C AOI APPROVE NG  ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "INNERMOLDFACA")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailContentInnnerMold(emailsdt, ResultId, TaskId);
                    Subject = "A246C INNER MOLD FACA ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "InnerMoldApprove")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailContentInnerMoldApproval(emailsdt, ResultId, TaskId);
                    //  Body = GetEmailContent(name, Convert.ToString(PID));
                    Subject = "A246C INNER MOLD VALIDATION ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "InnerMoldApproveLast")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailInnerMoldContentApproveLast(emailsdt, ResultId, TaskId);
                    Subject = "A246C INNER MOLD APPROVE ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }

                else if (Type == "InnerMoldRejectFirst")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailInnnerMoldContentRejectFirst(emailsdt, ResultId, TaskId);
                    Subject = "A246C INNER MOLD VALIDATION NG ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "InnerMoldReject")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailInnerMoldContentReject(emailsdt, ResultId, TaskId);
                    Subject = "A246C INNER MOLD APPROVE NG  ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }

                else if (Type == "HankingFACA")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailContentHanking(emailsdt, ResultId, TaskId);
                    Subject = "A246C HANKING FACA ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }

                else if (Type == "HankingApprove")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailContentHankingApproval(emailsdt, ResultId, TaskId);
                    //  Body = GetEmailContent(name, Convert.ToString(PID));
                    Subject = "A246C HANKING VALIDATION ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "HankingApproveLast")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailHankingContentApproveLast(emailsdt, ResultId, TaskId);
                    Subject = "A246C HANKING APPROVE ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "HankingRejectFirst")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailHankingContentRejectFirst(emailsdt, ResultId, TaskId);
                    Subject = "A246C HANKING VALIDATION NG ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "HankingReject")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailHankingContentReject(emailsdt, ResultId, TaskId);
                    Subject = "A246C HANKING APPROVE NG  ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "NewHankingFACA")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailContentNewHanking(emailsdt, ResultId, TaskId);
                    Subject = "A246C NEW HANKING FACA ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "NewHankingApprove")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailContentNewHankingApproval(emailsdt, ResultId, TaskId);
                    //  Body = GetEmailContent(name, Convert.ToString(PID));
                    Subject = "A246C NEW HANKING VALIDATION ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "NewHankingApproveLast")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailNewHankingContentApproveLast(emailsdt, ResultId, TaskId);
                    Subject = "A246C NEW HANKING APPROVE ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "NewHankingRejectFirst")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailNewHankingContentRejectFirst(emailsdt, ResultId, TaskId);
                    Subject = "A246C NEW HANKING VALIDATION NG ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "NewHankingReject")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailNewHankingContentReject(emailsdt, ResultId, TaskId);
                    Subject = "A246C NEW HANKING APPROVE NG  ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "WCMFACA")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailContentWCM(emailsdt, ResultId, TaskId);
                    Subject = "A246C WIRE COMB MOLDING FACA ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "WCMApprove")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailContentWCMApproval(emailsdt, ResultId, TaskId);
                    //  Body = GetEmailContent(name, Convert.ToString(PID));
                    Subject = "A246C  WIRE COMB MOLDING VALIDATION ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "WCMApproveLast")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailWCMContentApproveLast(emailsdt, ResultId, TaskId);
                    Subject = "A246C  WIRE COMB MOLDING APPROVE ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "WCMRejectFirst")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailWCMContentRejectFirst(emailsdt, ResultId, TaskId);
                    Subject = "A246C  WIRE COMB MOLDING VALIDATION NG ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "WCMReject")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailWCMContentReject(emailsdt, ResultId, TaskId);
                    Subject = "A246C  WIRE COMB MOLDING APPROVE NG  ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "A246CShellCrimpingFACA")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailContentA246CShellCrimping(emailsdt, ResultId, TaskId);
                    Subject = "A246C SHELL CRIMPING  FACA ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "A246CshellCrimpingApprove")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailContentA246CShellCrimpingApproval(emailsdt, ResultId, TaskId);
                    //  Body = GetEmailContent(name, Convert.ToString(PID));
                    Subject = "A246C  SHELL CRIMPING VALIDATION ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "A246CshellCrimpingApproveLast")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailA246CShellCrimpingContentApproveLast(emailsdt, ResultId, TaskId);
                    Subject = "A246C SHELL CRIMPING APPROVE ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "A246CShellCrimpingRejectFirst")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailA246CShellCrimpingContentRejectFirst(emailsdt, ResultId, TaskId);
                    Subject = "A246C SHELL CRIMPING VALIDATION NG ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "A246CShellCrimpingReject")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailA246CShellCrimpingContentReject(emailsdt, ResultId, TaskId);
                    Subject = "A246C SHELL CRIMPING APPROVE NG  ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "A246CCCMFACA")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailContentCCM(emailsdt, ResultId, TaskId);
                    Subject = "A246C CCM & CHI & 4SC FACA ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "A246CCCMApprove")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailContentA246CCCMApproval(emailsdt, ResultId, TaskId);
                    //  Body = GetEmailContent(name, Convert.ToString(PID));
                    Subject = "A246C CCM & CHI & 4SC VALIDATION ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "A246CCCMApproveLast")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailA246CCCMContentApproveLast(emailsdt, ResultId, TaskId);
                    Subject = "A246C CCM & CHI & 4SC APPROVE ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "A246CCCMRejectFirst")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailA246CCCMContentRejectFirst(emailsdt, ResultId, TaskId);
                    Subject = "A246C CCM & CHI & 4SC VALIDATION NG ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "A246CCCMReject")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailA246CCCMContentReject(emailsdt, ResultId, TaskId);
                    Subject = "A246C CCM & CHI & 4SC APPROVE NG  ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "A246CHB2FACA")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailContentA246CHB2FACA(emailsdt, ResultId, TaskId);
                    Subject = "A246C DESTRUCTIVE FACA ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "A246CDestructiveApprove")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailContentA246CDestructiveApproval(emailsdt, ResultId, TaskId);
                    //  Body = GetEmailContent(name, Convert.ToString(PID));
                    Subject = "A246C DESTRUCTIVE VALIDATION ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "A246CDestructiveApproveLast")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailA246CDestructiveContentApproveLast(emailsdt, ResultId, TaskId);
                    Subject = "A246C DESTRUCTIVE APPROVE ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "A246CDestructiveRejectFirst")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailA246CDestructiveContentRejectFirst(emailsdt, ResultId, TaskId);
                    Subject = "A246C DESTRUCTIVE VALIDATION NG ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "A246CDestructiveReject")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailA246CDestructiveContentReject(emailsdt, ResultId, TaskId);
                    Subject = "A246C DESTRUCTIVE APPROVE NG  ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "A191LaserFACA")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailContentA191LASERFACA(emailsdt, ResultId, TaskId);
                    Subject = "A191/A191M LASER ENGRAVING FACA ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "A191LaserApprove")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailContentA191LaserApproval(emailsdt, ResultId, TaskId);
                    //  Body = GetEmailContent(name, Convert.ToString(PID));
                    Subject = "A191/A191M LASER ENGRAVING VALIDATION ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "A191LaserApproveLast")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailA191LaserContentApproveLast(emailsdt, ResultId, TaskId);
                    Subject = "A191/A191M LASER ENGRAVING APPROVE ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "A191LaserRejectFirst")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailA191LaserContentRejectFirst(emailsdt, ResultId, TaskId);
                    Subject = "A191/A191M LASER ENGRAVING VALIDATION NG ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                else if (Type == "A191LaserReject")
                {
                    DataTable emailsdt = new DataTable();
                    emailsdt = _checkResult.GetMailsForForms();
                    Body = GetEmailA191LaserContentReject(emailsdt, ResultId, TaskId);
                    Subject = "A191/A191M LASER ENGRAVING APPROVE NG  ALERT!";
                    SendEmailByService(emailsdt, name, Body, Subject);
                }
                //else
                //{   DataTable emailsdt = new DataTable();
                //    emailsdt = _checkResult.GetMailsForForms();
                //    Body = GetEmailContent(Mail, ResultId);
                //    Subject = "HOT BAR NG ALERT";
                //    SendEmailByService(emailsdt, name, Body, Subject);
                //} 
            }
            private string GetEmailContentReject(DataTable Mail, int Resultd)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetHotBarFACAByResultId(Resultd);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/HotBarFACA.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=1 align=center cellpadding=1 cellspacing=3><tr style='background-color:lightgreen' ><th>Created Date</th><th>Line</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Inspection Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                             + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                             + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                             + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                             
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
            }

            private string GetEmailXBarContentReject(DataTable Mail, int Resultd,int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromXBarFACA(Resultd,TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/XBarFACARejectLast.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Project</th><th>Test Parameter</th><th>LSL</th><th>Mean Value</th><th>USL</th><th>Value</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th><th>Remarks</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                            + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["ProjectName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Adhesive"] + "</td><td>"
                                             + dt.Rows[loopCount]["LowerLimit"] + "</td><td>"
                                             + dt.Rows[loopCount]["CenterLimit"] + "</td><td>"
                                             + dt.Rows[loopCount]["UpperLimit"] + "</td><td>"
                                             + dt.Rows[loopCount]["DataValue"] + "</td><td>"
                                             + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                             + dt.Rows[loopCount]["RootCausee"] + "</td><td>"
                                             + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                             + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                             + dt.Rows[loopCount]["Queryy"] + "</td><td>"
                                             + dt.Rows[loopCount]["Remark"] 
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                //return Body1;
            }

            private string GetEmailHBContentReject(DataTable Mail, int Resultd,int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromHBFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/HBFACARejectLast.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;' ><th>Created Date</th><th>Line</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Inspection Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th><th>Remark</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                             + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                             + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                             + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                             + dt.Rows[loopCount]["Queryy"] + "</td><td>"
                                             + dt.Rows[loopCount]["Remark"]

                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                //return Body1;
            }

            private string GetEmailCTPContentReject(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromCTPFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/CTPFACARejectLast.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine Name</th><th>Station No</th><th>Station Name</th><th>Equipment Model</th><th>Parameter Name</th><th>Unit</th><th>LSL</th><th>USL</th><th>Value</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th><th>Remarks</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["StationNo"] + "</td><td>"
                                             + dt.Rows[loopCount]["Station"] + "</td><td>"
                                             + dt.Rows[loopCount]["EquipmentModel"] + "</td><td>"
                                             + dt.Rows[loopCount]["Parameter"] + "</td><td>"
                                             + dt.Rows[loopCount]["unit"] + "</td><td>"
                                             + dt.Rows[loopCount]["LSL"] + "</td><td>"
                                              + dt.Rows[loopCount]["USL"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value"] + "</td><td>"
                                              + dt.Rows[loopCount]["Result"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["Queryy"] + "</td><td>"
                                                //+ dt.Rows[loopCount]["Query"] + "</td><td>"
                                               + dt.Rows[loopCount]["Remark"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                //return Body1;
            }

            private string GetEmailCTPLIne2ContentReject(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromCTPFACAForLIne2(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/CTPLine2FACARejectLast.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine Name</th><th>Station No</th><th>Station Name</th><th>Equipment Model</th><th>Parameter Name</th><th>Unit</th><th>LSL</th><th>USL</th><th>Value</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th><th>Remarks</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["StationNo"] + "</td><td>"
                                             + dt.Rows[loopCount]["StationName"] + "</td><td>"
                                             + dt.Rows[loopCount]["EquipmentName"] + "</td><td>"
                                             + dt.Rows[loopCount]["ParameterName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Unit"] + "</td><td>"
                                             + dt.Rows[loopCount]["LSL"] + "</td><td>"
                                              + dt.Rows[loopCount]["USL"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value"] + "</td><td>"
                                              + dt.Rows[loopCount]["Result"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["Queryy"] + "</td><td>"
                        //+ dt.Rows[loopCount]["Query"] + "</td><td>"
                                               + dt.Rows[loopCount]["Remark"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                //return Body1;
            }

            private string GetEmailAOIContentReject(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromAOIFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/AOIFACARejectLast.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th><th>Remarks</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                               + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                                + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                                 + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                              + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["Queryy"] + "</td><td>"
                                               + dt.Rows[loopCount]["Remark"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                //return Body1;
            }

            private string GetEmailInnerMoldContentReject(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromINNERMOLDFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/INNERMOLDFACARejectLast.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th><th>Remarks</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                               + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                                + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                                 + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                              + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["Queryy"] + "</td><td>"
                                               + dt.Rows[loopCount]["Remark"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                //return Body1;
            }

            private string GetEmailHankingContentReject(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromHankingFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/HankingFACARejectLast.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th><th>Remarks</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                               + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                                + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                                 + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                              + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["Queryyy"] + "</td><td>"
                                               + dt.Rows[loopCount]["Remark"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                //return Body1;
            }

            private string GetEmailNewHankingContentReject(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromWCMFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/NewHankingFACARejectLast.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th><th>Remarks</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                               + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                                + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                                 + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                              + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["Queryyy"] + "</td><td>"
                                               + dt.Rows[loopCount]["Remark"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                //return Body1;
            }

            private string GetEmailWCMContentReject(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromWCMFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/WCMFACARejectLast.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th><th>Remarks</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                               + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                                + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                                 + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                              + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["Queryyy"] + "</td><td>"
                                               + dt.Rows[loopCount]["Remark"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                //return Body1;
            }

            private string GetEmailA246CShellCrimpingContentReject(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromShellCrimpingFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/A246CShellCrimpingFACARejectLast.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th><th>Remarks</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                               + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                                + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                                 + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                              + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["Queryyy"] + "</td><td>"
                                               + dt.Rows[loopCount]["Remark"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                //return Body1;
            }

            private string GetEmailA246CCCMContentReject(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromCCMFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/A246CCCMFACARejectLast.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th><th>Remarks</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                               + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                                + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                                 + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                              + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["Queryyy"] + "</td><td>"
                                               + dt.Rows[loopCount]["Remark"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                //return Body1;
            }

            private string GetEmailA246CDestructiveContentReject(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromHB2FACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/A246CDestructiveFACARejectLast.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th><th>Remarks</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                              + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["Queryyy"] + "</td><td>"
                                               + dt.Rows[loopCount]["Remark"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                //return Body1;
            }

            private string GetEmailA191LaserContentReject(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromLaserEngravingFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/A191LaserFACARejectLast.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Locations</th><th>Frequency</th><th>Specification</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Serial No</th><th>Value 2</th><th>Serial No</th><th>Value 3</th><th>Serial No</th><th>Value 4</th><th>Serial No</th><th>Value 5</th><th>Serial No</th><th>Value 6</th><th>Serial No</th><th>Result</th><th>RootCause</th><th>CorrectiveAction</th><th>PreventiveAction</th><th>Validation</th><th>Remark</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["Locations"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Specification"] + "</td><td>"
                                             + dt.Rows[loopCount]["Minimum"] + "</td><td>"
                                             + dt.Rows[loopCount]["Maximum"] + "</td><td>"
                                             + dt.Rows[loopCount]["Sno1"] + "</td><td>"
                                             + dt.Rows[loopCount]["SerialNo1"] + "</td><td>"
                                             + dt.Rows[loopCount]["Sno2"] + "</td><td>"
                                             + dt.Rows[loopCount]["SerialNo2"] + "</td><td>"
                                              + dt.Rows[loopCount]["Sno3"] + "</td><td>"
                                             + dt.Rows[loopCount]["SerialNo3"] + "</td><td>"
                                             + dt.Rows[loopCount]["Sno4"] + "</td><td>"
                                             + dt.Rows[loopCount]["SerialNo4"] + "</td><td>"
                                             + dt.Rows[loopCount]["Sno5"] + "</td><td>"
                                             + dt.Rows[loopCount]["SerialNo5"] + "</td><td>"
                                             + dt.Rows[loopCount]["Sno6"] + "</td><td>"
                                             + dt.Rows[loopCount]["SerialNo6"] + "</td><td>"
                                             + dt.Rows[loopCount]["Result"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["Queryyy"] + "</td><td>"
                                               + dt.Rows[loopCount]["Remark"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                //return Body1;
            }

            private string GetEmailXBarContentRejectFirst(DataTable Mail, int Resultd,int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromXBarFACA(Resultd,TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/XBarFACAValidNG.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Project</th><th>Test Parameter</th><th>LSL</th><th>Mean Value</th><th>USL</th><th>Value</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                            + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["ProjectName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Adhesive"] + "</td><td>"
                                             + dt.Rows[loopCount]["LowerLimit"] + "</td><td>"
                                             + dt.Rows[loopCount]["CenterLimit"] + "</td><td>"
                                             + dt.Rows[loopCount]["UpperLimit"] + "</td><td>"
                                             + dt.Rows[loopCount]["DataValue"] + "</td><td>"
                                             + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                             + dt.Rows[loopCount]["RootCausee"] + "</td><td>"
                                             + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                             + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                             + dt.Rows[loopCount]["Query"] 
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                //return Body1;
            }

            private string GetEmailHBContentRejectFirst(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromHBFACA(Resultd,TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/HBFACAValidNG.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;' ><th>Created Date</th><th>Line</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Inspection Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                             + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                             + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                             + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                             + dt.Rows[loopCount]["Query"]

                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                //return Body1;
            }

            private string GetEmailCTPContentRejectFirst(DataTable Mail, int Resultd,int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromCTPFACA(Resultd,TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/CTPFACAValidNG.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine Name</th><th>Station No</th><th>Station Name</th><th>Equipment Model</th><th>Parameter Name</th><th>Unit</th><th>LSL</th><th>USL</th><th>Value</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["StationNo"] + "</td><td>"
                                             + dt.Rows[loopCount]["Station"] + "</td><td>"
                                             + dt.Rows[loopCount]["EquipmentModel"] + "</td><td>"
                                             + dt.Rows[loopCount]["Parameter"] + "</td><td>"
                                             + dt.Rows[loopCount]["unit"] + "</td><td>"
                                             + dt.Rows[loopCount]["LSL"] + "</td><td>"
                                              + dt.Rows[loopCount]["USL"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value"] + "</td><td>"
                                              + dt.Rows[loopCount]["Result"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                               //+ dt.Rows[loopCount]["Queryy"] + "</td><td>"
                                               + dt.Rows[loopCount]["Query"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                //return Body1;
            }

            private string GetEmailCTPLine2ContentRejectFirst(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromCTPFACAForLIne2(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/CTPLIne2FACAValidNG.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine Name</th><th>Station No</th><th>Station Name</th><th>Equipment Model</th><th>Parameter Name</th><th>Unit</th><th>LSL</th><th>USL</th><th>Value</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["StationNo"] + "</td><td>"
                                             + dt.Rows[loopCount]["StationName"] + "</td><td>"
                                             + dt.Rows[loopCount]["EquipmentName"] + "</td><td>"
                                             + dt.Rows[loopCount]["ParameterName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Unit"] + "</td><td>"
                                             + dt.Rows[loopCount]["LSL"] + "</td><td>"
                                              + dt.Rows[loopCount]["USL"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value"] + "</td><td>"
                                              + dt.Rows[loopCount]["Result"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                               //+ dt.Rows[loopCount]["Queryy"] + "</td><td>"
                                               + dt.Rows[loopCount]["Query"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                //return Body1;
            }

            private string GetEmailAOIContentRejectFirst(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromAOIFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/AOIFACAValidNG.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                               + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                                + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                                 + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                              + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                               + dt.Rows[loopCount]["Query"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                //return Body1;
            }

            private string GetEmailInnnerMoldContentRejectFirst(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromINNERMOLDFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/InnerMoldFACAValidNG.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                               + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                                + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                                 + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                              + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                               + dt.Rows[loopCount]["Query"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                //return Body1;
            }

            private string GetEmailHankingContentRejectFirst(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromHankingFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/HankingFACAValidNG.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                               + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                                + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                                 + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                              + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                               + dt.Rows[loopCount]["Query"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                //return Body1;
            }

            private string GetEmailNewHankingContentRejectFirst(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromWCMFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/NewHankingFACAValidNG.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                               + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                                + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                                 + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                              + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                               + dt.Rows[loopCount]["Query"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                //return Body1;
            }

            private string GetEmailWCMContentRejectFirst(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromWCMFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/WCMFACAValidNG.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                               + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                                + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                                 + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                              + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                               + dt.Rows[loopCount]["Query"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                //return Body1;
            }

            private string GetEmailA246CShellCrimpingContentRejectFirst(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromShellCrimpingFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/A246CShellCrimpingFACAValidNG.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                               + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                                + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                                 + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                              + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                               + dt.Rows[loopCount]["Query"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                //return Body1;
            }

            private string GetEmailA246CCCMContentRejectFirst(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromCCMFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/A246CCCMFACAValidNG.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                               + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                                + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                                 + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                              + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                               + dt.Rows[loopCount]["Query"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                //return Body1;
            }

            private string GetEmailA246CDestructiveContentRejectFirst(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromHB2FACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/A246CDestructiveFACAValidNG.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                              + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                               + dt.Rows[loopCount]["Query"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                //return Body1;
            }

            private string GetEmailA191LaserContentRejectFirst(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromLaserEngravingFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/A191LaserFACAValidNG.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Locations</th><th>Frequency</th><th>Specification</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Serial No</th><th>Value 2</th><th>Serial No</th><th>Value 3</th><th>Serial No</th><th>Value 4</th><th>Serial No</th><th>Value 5</th><th>Serial No</th><th>Value 6</th><th>Serial No</th><th>Result</th><th>RootCause</th><th>CorrectiveAction</th><th>PreventiveAction</th><th>Validation</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["Locations"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Specification"] + "</td><td>"
                                             + dt.Rows[loopCount]["Minimum"] + "</td><td>"
                                             + dt.Rows[loopCount]["Maximum"] + "</td><td>"
                                             + dt.Rows[loopCount]["Sno1"] + "</td><td>"
                                             + dt.Rows[loopCount]["SerialNo1"] + "</td><td>"
                                             + dt.Rows[loopCount]["Sno2"] + "</td><td>"
                                             + dt.Rows[loopCount]["SerialNo2"] + "</td><td>"
                                              + dt.Rows[loopCount]["Sno3"] + "</td><td>"
                                             + dt.Rows[loopCount]["SerialNo3"] + "</td><td>"
                                             + dt.Rows[loopCount]["Sno4"] + "</td><td>"
                                             + dt.Rows[loopCount]["SerialNo4"] + "</td><td>"
                                             + dt.Rows[loopCount]["Sno5"] + "</td><td>"
                                             + dt.Rows[loopCount]["SerialNo5"] + "</td><td>"
                                             + dt.Rows[loopCount]["Sno6"] + "</td><td>"
                                             + dt.Rows[loopCount]["SerialNo6"] + "</td><td>"
                                             + dt.Rows[loopCount]["Result"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                               + dt.Rows[loopCount]["Query"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                //return Body1;
            }

            private string GetEmailXBarContentApproveLast(DataTable Mail, int Resultd,int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromXBarFACA(Resultd,TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/XBarFACAApproveLast.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Project</th><th>Test Parameter</th><th>LSL</th><th>Mean Value</th><th>USL</th><th>Value</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validaton</th><th>Remarks</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                            + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["ProjectName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Adhesive"] + "</td><td>"
                                             + dt.Rows[loopCount]["LowerLimit"] + "</td><td>"
                                             + dt.Rows[loopCount]["CenterLimit"] + "</td><td>"
                                             + dt.Rows[loopCount]["UpperLimit"] + "</td><td>"
                                             + dt.Rows[loopCount]["DataValue"] + "</td><td>"
                                             + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                             + dt.Rows[loopCount]["RootCausee"] + "</td><td>"
                                             + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                             + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                             + dt.Rows[loopCount]["Queryy"] + "</td><td>"
                                              + dt.Rows[loopCount]["Remark"] 
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                //return Body1;
            }

            private string GetEmailCTPContentApproveLast(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromCTPFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/ctpFACAApproveLast.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine Name</th><th>Station No</th><th>Station Name</th><th>Equipment Model</th><th>Parameter Name</th><th>Unit</th><th>LSL</th><th>USL</th><th>Value</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th><th>Remarks</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["StationNo"] + "</td><td>"
                                             + dt.Rows[loopCount]["Station"] + "</td><td>"
                                             + dt.Rows[loopCount]["EquipmentModel"] + "</td><td>"
                                             + dt.Rows[loopCount]["Parameter"] + "</td><td>"
                                             + dt.Rows[loopCount]["unit"] + "</td><td>"
                                             + dt.Rows[loopCount]["LSL"] + "</td><td>"
                                              + dt.Rows[loopCount]["USL"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value"] + "</td><td>"
                                              + dt.Rows[loopCount]["Result"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["Queryy"] + "</td><td>"
                                                //+ dt.Rows[loopCount]["Query"] + "</td><td>"
                                               + dt.Rows[loopCount]["Remark"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                //return Body1;
            }

            private string GetEmailHBContentApproveLast(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromHBFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/HBFACAApproveLast.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;' ><th>Created Date</th><th>Line</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Inspection Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th><th>Remark</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                             + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                             + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                             + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                             + dt.Rows[loopCount]["Queryy"] + "</td><td>"
                                             + dt.Rows[loopCount]["Remark"]

                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                //return Body1;
            }

            private string GetEmailCTPLine2ContentApproveLast(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromCTPFACAForLIne2(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/ctpLIne2FACAApproveLast.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine Name</th><th>Station No</th><th>Station Name</th><th>Equipment Model</th><th>Parameter Name</th><th>Unit</th><th>LSL</th><th>USL</th><th>Value</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th><th>Remarks</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["StationNo"] + "</td><td>"
                                             + dt.Rows[loopCount]["StationName"] + "</td><td>"
                                             + dt.Rows[loopCount]["EquipmentName"] + "</td><td>"
                                             + dt.Rows[loopCount]["ParameterName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Unit"] + "</td><td>"
                                             + dt.Rows[loopCount]["LSL"] + "</td><td>"
                                              + dt.Rows[loopCount]["USL"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value"] + "</td><td>"
                                              + dt.Rows[loopCount]["Result"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["Queryy"] + "</td><td>"
                        //+ dt.Rows[loopCount]["Query"] + "</td><td>"
                                               + dt.Rows[loopCount]["Remark"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                //return Body1;
            }

            private string GetEmailAOIContentApproveLast(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromAOIFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/AOIApproveLast.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th><th>Remarks</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                               + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                                + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                                 + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                              + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["Queryy"] + "</td><td>"
                                               + dt.Rows[loopCount]["Remark"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                //return Body1;
            }

            private string GetEmailInnerMoldContentApproveLast(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromINNERMOLDFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/InnerMoldApproveLast.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th><th>Remarks</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                               + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                                + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                                 + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                              + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["Queryy"] + "</td><td>"
                                               + dt.Rows[loopCount]["Remark"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                //return Body1;
            }

        private string GetEmailHankingContentApproveLast(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromHankingFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/HankingFACAApproveLast.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th><th>Remarks</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                               + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                                + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                                 + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                              + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["Queryy"] + "</td><td>"
                                               + dt.Rows[loopCount]["Remark"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                //return Body1;
            }

        private string GetEmailNewHankingContentApproveLast(DataTable Mail, int Resultd, int TaskId)
        {
            string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

            String Body1 = String.Empty;
            DataTable dt = _checkResult.GetDataFromNewHankingFACA(Resultd, TaskId);

            using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/NewHankingFACAApproveLast.html")))
            {

                Body1 = reader.ReadToEnd();

            }
            //Body1 = Body1.Replace("{Adhesive}", name);
            //Body1 = Body1.Replace("{ProjectName}", PID);
            //Body1 = Body1.Replace("{LineName}", Subject);
            //Body1 = Body1.Replace("{Email}", Mail);
            Body1 = Body1.Replace("{URL}", Url);
            string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th><th>Remarks</th></tr>";
            // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
            for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
            {
                htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                         + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                         + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                         + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                         + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                         + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                         + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                         + dt.Rows[loopCount]["Section"] + "</td><td>"
                                         + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                         + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                         + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                          + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                           + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                            + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                          + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                           + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                            + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                            + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                            + dt.Rows[loopCount]["Queryy"] + "</td><td>"
                                           + dt.Rows[loopCount]["Remark"]
                                         + "</td></tr>";
            }
            htmlString += "</table>";
            Body1 = Body1.Replace("{RequestTable}", htmlString);
            //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
            return Body1;
            //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
            //return Body1;
        }

        private string GetEmailWCMContentApproveLast(DataTable Mail, int Resultd, int TaskId)
        {
            string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

            String Body1 = String.Empty;
            DataTable dt = _checkResult.GetDataFromWCMFACA(Resultd, TaskId);

            using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/WCMFACAApproveLast.html")))
            {

                Body1 = reader.ReadToEnd();

            }
            //Body1 = Body1.Replace("{Adhesive}", name);
            //Body1 = Body1.Replace("{ProjectName}", PID);
            //Body1 = Body1.Replace("{LineName}", Subject);
            //Body1 = Body1.Replace("{Email}", Mail);
            Body1 = Body1.Replace("{URL}", Url);
            string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th><th>Remarks</th></tr>";
            // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
            for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
            {
                htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                         + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                         + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                         + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                         + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                         + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                         + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                         + dt.Rows[loopCount]["Section"] + "</td><td>"
                                         + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                         + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                         + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                          + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                           + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                            + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                          + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                           + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                            + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                            + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                            + dt.Rows[loopCount]["Queryy"] + "</td><td>"
                                           + dt.Rows[loopCount]["Remark"]
                                         + "</td></tr>";
            }
            htmlString += "</table>";
            Body1 = Body1.Replace("{RequestTable}", htmlString);
            //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
            return Body1;
            //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
            //return Body1;
        }

        private string GetEmailA246CShellCrimpingContentApproveLast(DataTable Mail, int Resultd, int TaskId)
        {
            string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

            String Body1 = String.Empty;
            DataTable dt = _checkResult.GetDataFromShellCrimpingFACA(Resultd, TaskId);

            using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/A246CShellCrimpingFACAApproveLast.html")))
            {

                Body1 = reader.ReadToEnd();

            }
            //Body1 = Body1.Replace("{Adhesive}", name);
            //Body1 = Body1.Replace("{ProjectName}", PID);
            //Body1 = Body1.Replace("{LineName}", Subject);
            //Body1 = Body1.Replace("{Email}", Mail);
            Body1 = Body1.Replace("{URL}", Url);
            string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th><th>Remarks</th></tr>";
            // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
            for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
            {
                htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                         + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                         + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                         + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                         + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                         + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                         + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                         + dt.Rows[loopCount]["Section"] + "</td><td>"
                                         + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                         + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                         + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                          + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                           + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                            + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                          + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                           + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                            + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                            + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                            + dt.Rows[loopCount]["Queryy"] + "</td><td>"
                                           + dt.Rows[loopCount]["Remark"]
                                         + "</td></tr>";
            }
            htmlString += "</table>";
            Body1 = Body1.Replace("{RequestTable}", htmlString);
            //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
            return Body1;
            //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
            //return Body1;
        }

        private string GetEmailA246CCCMContentApproveLast(DataTable Mail, int Resultd, int TaskId)
        {
            string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

            String Body1 = String.Empty;
            DataTable dt = _checkResult.GetDataFromCCMFACA(Resultd, TaskId);

            using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/A246CCCMFACAApproveLast.html")))
            {

                Body1 = reader.ReadToEnd();

            }
            //Body1 = Body1.Replace("{Adhesive}", name);
            //Body1 = Body1.Replace("{ProjectName}", PID);
            //Body1 = Body1.Replace("{LineName}", Subject);
            //Body1 = Body1.Replace("{Email}", Mail);
            Body1 = Body1.Replace("{URL}", Url);
            string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th><th>Remarks</th></tr>";
            // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
            for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
            {
                htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                         + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                         + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                         + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                         + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                         + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                         + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                         + dt.Rows[loopCount]["Section"] + "</td><td>"
                                         + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                         + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                         + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                          + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                           + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                            + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                          + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                           + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                            + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                            + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                            + dt.Rows[loopCount]["Queryy"] + "</td><td>"
                                           + dt.Rows[loopCount]["Remark"]
                                         + "</td></tr>";
            }
            htmlString += "</table>";
            Body1 = Body1.Replace("{RequestTable}", htmlString);
            //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
            return Body1;
            //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
            //return Body1;
        }

        private string GetEmailA246CDestructiveContentApproveLast(DataTable Mail, int Resultd, int TaskId)
        {
            string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

            String Body1 = String.Empty;
            DataTable dt = _checkResult.GetDataFromHB2FACA(Resultd, TaskId);

            using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/A246CDestructiveFACAApproveLast.html")))
            {

                Body1 = reader.ReadToEnd();

            }
            //Body1 = Body1.Replace("{Adhesive}", name);
            //Body1 = Body1.Replace("{ProjectName}", PID);
            //Body1 = Body1.Replace("{LineName}", Subject);
            //Body1 = Body1.Replace("{Email}", Mail);
            Body1 = Body1.Replace("{URL}", Url);
            string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th><th>Remarks</th></tr>";
            // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
            for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
            {
                htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                         + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                         + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                         + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                         + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                         + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                         + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                         + dt.Rows[loopCount]["Section"] + "</td><td>"
                                         + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                         + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                         + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                          + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                           + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                            + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                            + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                            + dt.Rows[loopCount]["Queryy"] + "</td><td>"
                                           + dt.Rows[loopCount]["Remark"]
                                         + "</td></tr>";
            }
            htmlString += "</table>";
            Body1 = Body1.Replace("{RequestTable}", htmlString);
            //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
            return Body1;
            //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
            //return Body1;
        }

        private string GetEmailA191LaserContentApproveLast(DataTable Mail, int Resultd, int TaskId)
        {
            string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

            String Body1 = String.Empty;
            DataTable dt = _checkResult.GetDataFromLaserEngravingFACA(Resultd, TaskId);

            using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/A191LaserFACAApproveLast.html")))
            {

                Body1 = reader.ReadToEnd();

            }
            //Body1 = Body1.Replace("{Adhesive}", name);
            //Body1 = Body1.Replace("{ProjectName}", PID);
            //Body1 = Body1.Replace("{LineName}", Subject);
            //Body1 = Body1.Replace("{Email}", Mail);
            Body1 = Body1.Replace("{URL}", Url);
            string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Locations</th><th>Frequency</th><th>Specification</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Serial No</th><th>Value 2</th><th>Serial No</th><th>Value 3</th><th>Serial No</th><th>Value 4</th><th>Serial No</th><th>Value 5</th><th>Serial No</th><th>Value 6</th><th>Serial No</th><th>Result</th><th>RootCause</th><th>CorrectiveAction</th><th>PreventiveAction</th><th>Validation</th><th>Remark</th></tr>";
            // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
            for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
            {
                htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                         + dt.Rows[loopCount]["Locations"] + "</td><td>"
                                         + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                         + dt.Rows[loopCount]["Specification"] + "</td><td>"
                                         + dt.Rows[loopCount]["Minimum"] + "</td><td>"
                                         + dt.Rows[loopCount]["Maximum"] + "</td><td>"
                                         + dt.Rows[loopCount]["Sno1"] + "</td><td>"
                                         + dt.Rows[loopCount]["SerialNo1"] + "</td><td>"
                                         + dt.Rows[loopCount]["Sno2"] + "</td><td>"
                                         + dt.Rows[loopCount]["SerialNo2"] + "</td><td>"
                                          + dt.Rows[loopCount]["Sno3"] + "</td><td>"
                                         + dt.Rows[loopCount]["SerialNo3"] + "</td><td>"
                                         + dt.Rows[loopCount]["Sno4"] + "</td><td>"
                                         + dt.Rows[loopCount]["SerialNo4"] + "</td><td>"
                                         + dt.Rows[loopCount]["Sno5"] + "</td><td>"
                                         + dt.Rows[loopCount]["SerialNo5"] + "</td><td>"
                                         + dt.Rows[loopCount]["Sno6"] + "</td><td>"
                                         + dt.Rows[loopCount]["SerialNo6"] + "</td><td>"
                                         + dt.Rows[loopCount]["Result"] + "</td><td>"
                                           + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                            + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                            + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                            + dt.Rows[loopCount]["Queryy"] + "</td><td>"
                                           + dt.Rows[loopCount]["Remark"]
                                         + "</td></tr>";
            }
            htmlString += "</table>";
            Body1 = Body1.Replace("{RequestTable}", htmlString);
            //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
            return Body1;
            //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
            //return Body1;
        }

            private string GetEmailContentHOTBARFACA(DataTable Mail, int Resultd,int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromHBFACA(Resultd,TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/HotBarFACAAlert.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;' ><th>Created Date</th><th>Line</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Inspection Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                             + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                             + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                             + dt.Rows[loopCount]["PreventiveAction"] 

                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
            }

            private string GetEmailContentXBarApproval(DataTable Mail, int Resultd,int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromXBarFACA(Resultd,TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/XBarFACAValid.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Project</th><th>Test Parameter</th><th>LSL</th><th>Mean Value</th><th>USL</th><th>Value</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                            + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["ProjectName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Adhesive"] + "</td><td>"
                                             + dt.Rows[loopCount]["LowerLimit"] + "</td><td>"
                                             + dt.Rows[loopCount]["CenterLimit"] + "</td><td>"
                                             + dt.Rows[loopCount]["UpperLimit"] + "</td><td>"
                                             + dt.Rows[loopCount]["DataValue"] + "</td><td>"
                                             + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                             + dt.Rows[loopCount]["RootCausee"] + "</td><td>"
                                             + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                             + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                             + dt.Rows[loopCount]["Query"] 
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
            }

            private string GetEmailContentHBApproval(DataTable Mail, int Resultd,int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromHBFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/HBFACAValid.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;' ><th>Created Date</th><th>Line</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Inspection Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                             + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                             + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                             + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                             + dt.Rows[loopCount]["Query"]

                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
            }

            private string GetEmailContentCTPApproval(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromCTPFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/CTPFACAValid.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine Name</th><th>Station No</th><th>Station Name</th><th>Equipment Model</th><th>Parameter Name</th><th>Unit</th><th>LSL</th><th>USL</th><th>Value</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["StationNo"] + "</td><td>"
                                             + dt.Rows[loopCount]["Station"] + "</td><td>"
                                             + dt.Rows[loopCount]["EquipmentModel"] + "</td><td>"
                                             + dt.Rows[loopCount]["Parameter"] + "</td><td>"
                                             + dt.Rows[loopCount]["unit"] + "</td><td>"
                                             + dt.Rows[loopCount]["LSL"] + "</td><td>"
                                              + dt.Rows[loopCount]["USL"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value"] + "</td><td>"
                                              + dt.Rows[loopCount]["Result"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                               //+ dt.Rows[loopCount]["Queryy"] + "</td><td>"
                                               + dt.Rows[loopCount]["Query"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
            }

            private string GetEmailContentCTPLine2Approval(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromCTPFACAForLIne2(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/CTPLine2FACAValid.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine Name</th><th>Station No</th><th>Station Name</th><th>Equipment Model</th><th>Parameter Name</th><th>Unit</th><th>LSL</th><th>USL</th><th>Value</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["StationNo"] + "</td><td>"
                                             + dt.Rows[loopCount]["StationName"] + "</td><td>"
                                             + dt.Rows[loopCount]["EquipmentName"] + "</td><td>"
                                             + dt.Rows[loopCount]["ParameterName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Unit"] + "</td><td>"
                                             + dt.Rows[loopCount]["LSL"] + "</td><td>"
                                              + dt.Rows[loopCount]["USL"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value"] + "</td><td>"
                                              + dt.Rows[loopCount]["Result"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                               //+ dt.Rows[loopCount]["Queryy"] + "</td><td>"
                                               + dt.Rows[loopCount]["Query"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
            }

            private string GetEmailContentAOIApproval(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromAOIFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/AOIFACAValid.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                               + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                                + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                                 + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                              + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                               + dt.Rows[loopCount]["Query"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
            }

            private string GetEmailContentInnerMoldApproval(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromINNERMOLDFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/INNERMOLDFACAValid.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                               + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                                + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                                 + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                              + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                               + dt.Rows[loopCount]["Query"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
            }

        private string GetEmailContentHankingApproval(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromHankingFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/HankingFACAValid.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                               + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                                + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                                 + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                              + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                                + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                               + dt.Rows[loopCount]["Query"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
            }

        private string GetEmailContentNewHankingApproval(DataTable Mail, int Resultd, int TaskId)
        {
            string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

            String Body1 = String.Empty;
            DataTable dt = _checkResult.GetDataFromNewHankingFACA(Resultd, TaskId);

            using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/NewHankingFACAValid.html")))
            {

                Body1 = reader.ReadToEnd();

            }
            //Body1 = Body1.Replace("{Adhesive}", name);
            //Body1 = Body1.Replace("{ProjectName}", PID);
            //Body1 = Body1.Replace("{LineName}", Subject);
            //Body1 = Body1.Replace("{Email}", Mail);
            Body1 = Body1.Replace("{URL}", Url);
            string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th></tr>";
            // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
            for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
            {
                htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                         + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                         + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                         + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                         + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                         + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                         + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                         + dt.Rows[loopCount]["Section"] + "</td><td>"
                                         + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                         + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                         + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                          + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                           + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                            + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                          + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                           + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                            + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                            + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                           + dt.Rows[loopCount]["Query"]
                                         + "</td></tr>";
            }
            htmlString += "</table>";
            Body1 = Body1.Replace("{RequestTable}", htmlString);
            //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
            return Body1;
        }

        private string GetEmailContentWCMApproval(DataTable Mail, int Resultd, int TaskId)
        {
            string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

            String Body1 = String.Empty;
            DataTable dt = _checkResult.GetDataFromWCMFACA(Resultd, TaskId);

            using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/WCMFACAValid.html")))
            {

                Body1 = reader.ReadToEnd();

            }
            //Body1 = Body1.Replace("{Adhesive}", name);
            //Body1 = Body1.Replace("{ProjectName}", PID);
            //Body1 = Body1.Replace("{LineName}", Subject);
            //Body1 = Body1.Replace("{Email}", Mail);
            Body1 = Body1.Replace("{URL}", Url);
            string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th></tr>";
            // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
            for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
            {
                htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                         + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                         + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                         + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                         + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                         + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                         + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                         + dt.Rows[loopCount]["Section"] + "</td><td>"
                                         + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                         + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                         + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                          + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                           + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                            + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                          + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                           + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                            + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                            + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                           + dt.Rows[loopCount]["Query"]
                                         + "</td></tr>";
            }
            htmlString += "</table>";
            Body1 = Body1.Replace("{RequestTable}", htmlString);
            //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
            return Body1;
        }

        private string GetEmailContentA246CShellCrimpingApproval(DataTable Mail, int Resultd, int TaskId)
        {
            string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

            String Body1 = String.Empty;
            DataTable dt = _checkResult.GetDataFromShellCrimpingFACA(Resultd, TaskId);

            using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/A246CSHELLCRIMPINGFACAValid.html")))
            {

                Body1 = reader.ReadToEnd();

            }
            //Body1 = Body1.Replace("{Adhesive}", name);
            //Body1 = Body1.Replace("{ProjectName}", PID);
            //Body1 = Body1.Replace("{LineName}", Subject);
            //Body1 = Body1.Replace("{Email}", Mail);
            Body1 = Body1.Replace("{URL}", Url);
            string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th></tr>";
            // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
            for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
            {
                htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                         + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                         + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                         + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                         + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                         + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                         + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                         + dt.Rows[loopCount]["Section"] + "</td><td>"
                                         + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                         + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                         + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                          + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                           + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                            + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                          + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                           + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                            + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                            + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                           + dt.Rows[loopCount]["Query"]
                                         + "</td></tr>";
            }
            htmlString += "</table>";
            Body1 = Body1.Replace("{RequestTable}", htmlString);
            //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
            return Body1;
        }

        private string GetEmailContentA246CCCMApproval(DataTable Mail, int Resultd, int TaskId)
        {
            string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

            String Body1 = String.Empty;
            DataTable dt = _checkResult.GetDataFromCCMFACA(Resultd, TaskId);

            using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/CCMFACAValid.html")))
            {

                Body1 = reader.ReadToEnd();

            }
            //Body1 = Body1.Replace("{Adhesive}", name);
            //Body1 = Body1.Replace("{ProjectName}", PID);
            //Body1 = Body1.Replace("{LineName}", Subject);
            //Body1 = Body1.Replace("{Email}", Mail);
            Body1 = Body1.Replace("{URL}", Url);
            string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th></tr>";
            // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
            for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
            {
                htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                         + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                         + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                         + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                         + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                         + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                         + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                         + dt.Rows[loopCount]["Section"] + "</td><td>"
                                         + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                         + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                         + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                          + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                           + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                            + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                          + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                           + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                            + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                            + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                           + dt.Rows[loopCount]["Query"]
                                         + "</td></tr>";
            }
            htmlString += "</table>";
            Body1 = Body1.Replace("{RequestTable}", htmlString);
            //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
            return Body1;
        }

        private string GetEmailContentA246CDestructiveApproval(DataTable Mail, int Resultd, int TaskId)
        {
            string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

            String Body1 = String.Empty;
            DataTable dt = _checkResult.GetDataFromHB2FACA(Resultd, TaskId);

            using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/A246CDestructiveFACAValid.html")))
            {

                Body1 = reader.ReadToEnd();

            }
            //Body1 = Body1.Replace("{Adhesive}", name);
            //Body1 = Body1.Replace("{ProjectName}", PID);
            //Body1 = Body1.Replace("{LineName}", Subject);
            //Body1 = Body1.Replace("{Email}", Mail);
            Body1 = Body1.Replace("{URL}", Url);
            string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th><th>Validation</th></tr>";
            // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
            for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
            {
                htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                         + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                         + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                         + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                         + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                         + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                         + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                         + dt.Rows[loopCount]["Section"] + "</td><td>"
                                         + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                         + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                         + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                          + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                           + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                            + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                            + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                           + dt.Rows[loopCount]["Query"]
                                         + "</td></tr>";
            }
            htmlString += "</table>";
            Body1 = Body1.Replace("{RequestTable}", htmlString);
            //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
            return Body1;
        }

        private string GetEmailContentA191LaserApproval(DataTable Mail, int Resultd, int TaskId)
        {
            string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

            String Body1 = String.Empty;
            DataTable dt = _checkResult.GetDataFromLaserEngravingFACA(Resultd, TaskId);

            using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/A191LaserFACAValid.html")))
            {

                Body1 = reader.ReadToEnd();

            }
            //Body1 = Body1.Replace("{Adhesive}", name);
            //Body1 = Body1.Replace("{ProjectName}", PID);
            //Body1 = Body1.Replace("{LineName}", Subject);
            //Body1 = Body1.Replace("{Email}", Mail);
            Body1 = Body1.Replace("{URL}", Url);
            string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Locations</th><th>Frequency</th><th>Specification</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Serial No</th><th>Value 2</th><th>Serial No</th><th>Value 3</th><th>Serial No</th><th>Value 4</th><th>Serial No</th><th>Value 5</th><th>Serial No</th><th>Value 6</th><th>Serial No</th><th>Result</th><th>RootCause</th><th>CorrectiveAction</th><th>PreventiveAction</th><th>Validation</th></tr>";
            // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
            for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
            {
                htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                         + dt.Rows[loopCount]["Locations"] + "</td><td>"
                                         + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                         + dt.Rows[loopCount]["Specification"] + "</td><td>"
                                         + dt.Rows[loopCount]["Minimum"] + "</td><td>"
                                         + dt.Rows[loopCount]["Maximum"] + "</td><td>"
                                         + dt.Rows[loopCount]["Sno1"] + "</td><td>"
                                         + dt.Rows[loopCount]["SerialNo1"] + "</td><td>"
                                         + dt.Rows[loopCount]["Sno2"] + "</td><td>"
                                         + dt.Rows[loopCount]["SerialNo2"] + "</td><td>"
                                          + dt.Rows[loopCount]["Sno3"] + "</td><td>"
                                         + dt.Rows[loopCount]["SerialNo3"] + "</td><td>"
                                         + dt.Rows[loopCount]["Sno4"] + "</td><td>"
                                         + dt.Rows[loopCount]["SerialNo4"] + "</td><td>"
                                         + dt.Rows[loopCount]["Sno5"] + "</td><td>"
                                         + dt.Rows[loopCount]["SerialNo5"] + "</td><td>"
                                         + dt.Rows[loopCount]["Sno6"] + "</td><td>"
                                         + dt.Rows[loopCount]["SerialNo6"] + "</td><td>"
                                         + dt.Rows[loopCount]["Result"] + "</td><td>"
                                           + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                            + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                            + dt.Rows[loopCount]["PreventiveAction"] + "</td><td>"
                                           + dt.Rows[loopCount]["Query"]
                                         + "</td></tr>";
            }
            htmlString += "</table>";
            Body1 = Body1.Replace("{RequestTable}", htmlString);
            //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
            return Body1;
        }


            private string GetEmailContent(string Mail, int Resultd)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataForHBFACA();

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/HotBarFACANG.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=1 align=center cellpadding=1 cellspacing=3><tr style='background-color:lightgreen' ><th>Created Date</th><th>Line</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Inspection Result</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
            }

            private string GetEmailContentXBAR(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromXBarFACA(Resultd,TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/XBarFACAAlert.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Project</th><th>Test Parameter</th><th>LSL</th><th>Mean Value</th><th>USL</th><th>Value</th><th>Result</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["ProjectName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Adhesive"] + "</td><td>"
                                             + dt.Rows[loopCount]["LowerLimit"] + "</td><td>"
                                             + dt.Rows[loopCount]["CenterLimit"] + "</td><td>"
                                             + dt.Rows[loopCount]["UpperLimit"] + "</td><td>"
                                             + dt.Rows[loopCount]["DataValue"] + "</td><td>"
                                             + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                              + dt.Rows[loopCount]["RootCausee"] + "</td><td>"
                                              + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                               + dt.Rows[loopCount]["PreventiveAction"] 
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
            }

            private string GetEmailContentCTP(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromCTPFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/CTPFACAAlert.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine Name</th><th>Station No</th><th>Station Name</th><th>Equipment Model</th><th>Parameter Name</th><th>Unit</th><th>LSL</th><th>USL</th><th>Value</th><th>Result</th><th>RootCause</th><th>CorrectiveAction</th><th>PreventiveAction</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["StationNo"] + "</td><td>"
                                             + dt.Rows[loopCount]["Station"] + "</td><td>"
                                             + dt.Rows[loopCount]["EquipmentModel"] + "</td><td>"
                                             + dt.Rows[loopCount]["Parameter"] + "</td><td>"
                                             + dt.Rows[loopCount]["Unit"] + "</td><td>"
                                             + dt.Rows[loopCount]["LSL"] + "</td><td>"
                                              + dt.Rows[loopCount]["USL"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value"] + "</td><td>"
                                              + dt.Rows[loopCount]["Result"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                               + dt.Rows[loopCount]["PreventiveAction"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
            }

            private string GetEmailContentInnnerMold(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromINNERMOLDFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/INNERMOLDFACAAlert.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>RootCause</th><th>CorrectiveAction</th><th>PreventiveAction</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                               + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                                + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                                 + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                              + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                               + dt.Rows[loopCount]["PreventiveAction"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
            }

            private string GetEmailContentHanking(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromHankingFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/HankingFACAAlert.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>RootCause</th><th>CorrectiveAction</th><th>PreventiveAction</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                               + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                                + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                                 + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                              + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                               + dt.Rows[loopCount]["PreventiveAction"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
            }

            private string GetEmailContentNewHanking(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromNewHankingFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/NewHankingFACAAlert.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>RootCause</th><th>CorrectiveAction</th><th>PreventiveAction</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                               + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                                + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                                 + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                              + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                               + dt.Rows[loopCount]["PreventiveAction"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
            }

            private string GetEmailContentWCM(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromWCMFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/WCMFACAAlert.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>RootCause</th><th>CorrectiveAction</th><th>PreventiveAction</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                               + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                                + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                                 + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                              + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                               + dt.Rows[loopCount]["PreventiveAction"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
            }

            private string GetEmailContentCCM(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromCCMFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/CCMFACAAlert.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>RootCause</th><th>CorrectiveAction</th><th>PreventiveAction</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                               + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                                + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                                 + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                              + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                               + dt.Rows[loopCount]["PreventiveAction"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
            }

            private string GetEmailContentA246CHB2FACA(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromHB2FACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/HB2FACAAlert.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Result</th><th>RootCause</th><th>CorrectiveAction</th><th>PreventiveAction</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                              + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                               + dt.Rows[loopCount]["PreventiveAction"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
            }

            private string GetEmailContentA191LASERFACA(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromLaserEngravingFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/A191LASERFACAAlert.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Locations</th><th>Frequency</th><th>Specification</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Serial No</th><th>Value 2</th><th>Serial No</th><th>Value 3</th><th>Serial No</th><th>Value 4</th><th>Serial No</th><th>Value 5</th><th>Serial No</th><th>Value 6</th><th>Serial No</th><th>Result</th><th>RootCause</th><th>CorrectiveAction</th><th>PreventiveAction</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["Locations"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Specification"] + "</td><td>"
                                             + dt.Rows[loopCount]["Minimum"] + "</td><td>"
                                             + dt.Rows[loopCount]["Maximum"] + "</td><td>"
                                             + dt.Rows[loopCount]["Sno1"] + "</td><td>"
                                             + dt.Rows[loopCount]["SerialNo1"] + "</td><td>"
                                             + dt.Rows[loopCount]["Sno2"] + "</td><td>"
                                             + dt.Rows[loopCount]["SerialNo2"] + "</td><td>"
                                              + dt.Rows[loopCount]["Sno3"] + "</td><td>"
                                             + dt.Rows[loopCount]["SerialNo3"] + "</td><td>"
                                             + dt.Rows[loopCount]["Sno4"] + "</td><td>"
                                             + dt.Rows[loopCount]["SerialNo4"] + "</td><td>"
                                             + dt.Rows[loopCount]["Sno5"] + "</td><td>"
                                             + dt.Rows[loopCount]["SerialNo5"] + "</td><td>"
                                             + dt.Rows[loopCount]["Sno6"] + "</td><td>"
                                             + dt.Rows[loopCount]["SerialNo6"] + "</td><td>"
                                             + dt.Rows[loopCount]["Result"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                               + dt.Rows[loopCount]["PreventiveAction"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
            }

            private string GetEmailContentA246CShellCrimping(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromShellCrimpingFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/A246CShellCrimpingFACAAlert.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>RootCause</th><th>CorrectiveAction</th><th>PreventiveAction</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                               + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                                + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                                 + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                              + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                               + dt.Rows[loopCount]["PreventiveAction"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
            }


            private string GetEmailContentCTPLine2(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromCTPFACAForLIne2(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/CTPFACAAlertLine2.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine Name</th><th>Station No</th><th>Station Name</th><th>Equipment Model</th><th>Parameter Name</th><th>Unit</th><th>LSL</th><th>USL</th><th>Value</th><th>Result</th><th>RootCause</th><th>CorrectiveAction</th><th>PreventiveAction</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["StationNo"] + "</td><td>"
                                             + dt.Rows[loopCount]["StationName"] + "</td><td>"
                                             + dt.Rows[loopCount]["EquipmentName"] + "</td><td>"
                                             + dt.Rows[loopCount]["ParameterName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Unit"] + "</td><td>"
                                             + dt.Rows[loopCount]["LSL"] + "</td><td>"
                                              + dt.Rows[loopCount]["USL"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value"] + "</td><td>"
                                              + dt.Rows[loopCount]["Result"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                               + dt.Rows[loopCount]["PreventiveAction"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
            }

            private string GetEmailContentAOI(DataTable Mail, int Resultd, int TaskId)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetDataFromAOIFACA(Resultd, TaskId);

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/CTPAOIAlert.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse;width: 100%;font-size:20px' border=2 cellpadding=1 cellspacing=3><tr style='text-align:center;background-color:#B2FFFC;'><th>Created Date</th><th>Line</th><th>Machine</th><th>Work Station</th><th>Inspection Project</th><th>Inspection Specifications</th><th>Frequency</th><th>Section</th><th>LSL</th><th>USL</th><th>Value 1</th><th>Value 2</th><th>Value 3</th><th>Value 4</th><th>Value 5</th><th>Result</th><th>RootCause</th><th>CorrectiveAction</th><th>PreventiveAction</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Machine"] + "</td><td>"
                                             + dt.Rows[loopCount]["WorkStation"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionProject"] + "</td><td>"
                                             + dt.Rows[loopCount]["InspectionSpecifications"] + "</td><td>"
                                             + dt.Rows[loopCount]["Frequency"] + "</td><td>"
                                             + dt.Rows[loopCount]["Section"] + "</td><td>"
                                             + dt.Rows[loopCount]["StartSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["EndSpec"] + "</td><td>"
                                             + dt.Rows[loopCount]["Value1"] + "</td><td>"
                                              + dt.Rows[loopCount]["Value2"] + "</td><td>"
                                               + dt.Rows[loopCount]["Value3"] + "</td><td>"
                                                + dt.Rows[loopCount]["Value4"] + "</td><td>"
                                                 + dt.Rows[loopCount]["Value5"] + "</td><td>"
                                              + dt.Rows[loopCount]["InspectionResults"] + "</td><td>"
                                               + dt.Rows[loopCount]["RootCause"] + "</td><td>"
                                                + dt.Rows[loopCount]["CorrectiveAction"] + "</td><td>"
                                               + dt.Rows[loopCount]["PreventiveAction"]
                                             + "</td></tr>";
                }
                htmlString += "</table>";
                Body1 = Body1.Replace("{RequestTable}", htmlString);
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
            }
            

            
            private string GetRejectEmailContent(string name)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();
                String Body1 = String.Empty;


                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/Reject.html")))
                {

                    Body1 = reader.ReadToEnd();
                }
                Body1 = Body1.Replace("{Name}", name);
                // Body1 = Body1.Replace( "{DocumentId}", docId );
                // Body1 = Body1.Replace( "{Query}", QUERY );
                Body1 = Body1.Replace("{URL}", Url);
                return Body1;
                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title>Document Control Center Rejected Document Request Pid No:" + docId + "</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Rejected Document Request PID NO:" + docId + " and Reason for Rejecting:" + QUERY + " To Know..Please Click this link to Check the Rejected Document: <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
            }

            private void SendEmailByService(DataTable mailto, string name, string body, string Subject)
            {
                //  MailServiceClient ms = new MailServiceClient();
                //string[] toMAilAdds = new string[1];

               // List<string> toMAilAdds = new List<string>();


                List<MailAddress> toMAilAdds = new List<MailAddress>();

                foreach (DataRow row in mailto.Rows)
                {
                    if (row["Email"] != DBNull.Value)
                    {
                        string email = row["Email"].ToString().Trim();

                        // Optional: Validate email format here if needed
                        if (!string.IsNullOrEmpty(email))
                        {
                            toMAilAdds.Add(new MailAddress(email));
                        }
                    }
                }

                try
                {
                    // string str = ms.SendEmail(toMAilAdds, ccMAilAdds, bccMAilAdds, Subject, body);
                    SendHtmlFormattedEmail(Subject, body, toMAilAdds);
                }
                catch (Exception ex)
                {

                }
            }

            private void SendEmailByService2(string mailto, string name, string body, string Subject)
            {
                //  MailServiceClient ms = new MailServiceClient();
                //string[] toMAilAdds = new string[1];

                List<string> toMAilAdds = new List<string>();


                DataTable dt = new DataTable();
                toMAilAdds.Add(mailto);

                //if (type == "Final")
                //{

                //    DataTable emp = empBAL.GetMails(Convert.ToInt32(name));
                //    foreach (DataRow dr in emp.Rows)
                //    {
                //        toMAilAdds.Add(dr[1].ToString());
                //    }
                //}
                //else
                //{
                //    toMAilAdds.Add(mailto);
                //}

                //string[] ccMAilAdds = new string[1];
                //string[] bccMAilAdds = new string[1];

                try
                {
                    // string str = ms.SendEmail(toMAilAdds, ccMAilAdds, bccMAilAdds, Subject, body);
                    SendHtmlFormattedEmail2(Subject, body, toMAilAdds);
                }
                catch (Exception ex)
                {

                }
            }

            #region Send Mail POST Method
            private void SendHtmlFormattedEmail2(string subject, string body, List<string> toMAilAdds)
            {
                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["FromAddress"]);
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = true;
                    //  mailMessage.To.Add(new MailAddress(recepientEmail));
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = ConfigurationManager.AppSettings["HostName"];
                    smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                    System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                    NetworkCred.UserName = ConfigurationManager.AppSettings["UserId"];
                    NetworkCred.Password = ConfigurationManager.AppSettings["Password"];
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = int.Parse(ConfigurationManager.AppSettings["PortNumber"]);

                    MailFactory.Mail ml = new MailFactory.Mail(NetworkCred.UserName, NetworkCred.Password, smtp.Host, smtp.Port);
                    ml.Subject = subject;
                    ml.Body = body;
                    // ml.Attachment.Add(Attachment);
                    ml.From = ConfigurationManager.AppSettings["FromAddress"];
                    ml.To = toMAilAdds;
                    ml.Send2();
                }
            }

            private void SendHtmlFormattedEmail(string subject, string body, List<MailAddress> toMailAdds)
            {
                using (MailMessage mailMessage = new MailMessage())
                {
                    // Prepare Smtp configuration
                    string fromAddress = ConfigurationManager.AppSettings["FromAddress"];
                    string host = ConfigurationManager.AppSettings["HostName"];
                    bool enableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                    string userId = ConfigurationManager.AppSettings["UserId"];
                    string password = ConfigurationManager.AppSettings["Password"];
                    int port = int.Parse(ConfigurationManager.AppSettings["PortNumber"]);

                    mailMessage.From = new MailAddress(fromAddress);
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = true;

                    // You can still use mailMessage.To.Add(...) if needed for logging or backup

                    SmtpClient smtp = new SmtpClient
                    {
                        Host = host,
                        EnableSsl = enableSsl,
                        UseDefaultCredentials = false,
                        Credentials = new System.Net.NetworkCredential(userId, password),
                        Port = port
                    };

                    // Using MailFactory.Mail (your custom class)
                    MailFactory.Mail ml = new MailFactory.Mail(userId, password, host, port)
                    {
                        Subject = subject,
                        Body = body,
                        From = fromAddress
                    };

                    // ✅ Convert MailAddress list to string list
                    foreach (var mailAddress in toMailAdds)
                    {
                        ml.To.Add(mailAddress.Address); // Assuming ml.To is a List<string>
                    }

                    ml.Send2();
                }
            }

            #endregion
        }
    }
