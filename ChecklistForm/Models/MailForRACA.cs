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
    public class MailForRACA
    {
       
            EmployeeBAL empBAL = new EmployeeBAL();
            ReportBAL _objRpt = new ReportBAL();
            BAL.CheckListResults _checkResult = new BAL.CheckListResults();
            public void NotificationEmail( string Mail)
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

                //if (type == "Reject")
                //{
                //    Body = GetRejectEmailContent(name);
                //    Subject = "Reject required for a New Requirement ";
                //}
                //else if (type == "Final")
                //{
                //    Body = GetEmailConfirmationRequirement(name, BodySubject);
                //    //  Body = GetEmailContent(name, Convert.ToString(PID));
                //    Subject = "Requirement Accomplished Document";
                //}


                Body = GetEmailContent(Mail);
                Subject = "RACA NG MAIL ALERT";

                SendEmailByService(Mail, name, Body, Subject);
            }
            private string GetEmailContent(string Mail)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                String Body1 = String.Empty;
                DataTable dt = _checkResult.GetParameterRACAProdCheckListQualityAudit();

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/RACAAlert.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Adhesive}", name);
                //Body1 = Body1.Replace("{ProjectName}", PID);
                //Body1 = Body1.Replace("{LineName}", Subject);
                //Body1 = Body1.Replace("{Email}", Mail);
                Body1 = Body1.Replace("{URL}", Url);
                string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=1 align=center cellpadding=1 cellspacing=3><tr style='background-color:lightgreen' ><th>CreatedDate</th><th>Project</th><th>Line</th><th>Batch</th><th>Zone</th><th>Station</th><th>Activity Description</th><th>ProductionLineLeader</th><th>Root Cause</th><th>Corrective Action</th><th>Preventive Action</th></tr>";
                // string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=0 align=center cellpadding=0 cellspacing=0><tr  ><th>IssueType</th><th>Project</th><th>Line</th><th>Adhesive Specification</th><th>Status</th><th>Submitted time</th><th>FeedBack</th></tr>";
                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    htmlString += "<tr><td>" + Convert.ToDateTime(dt.Rows[loopCount]["CreateDate"]).ToString("yyyy-MM-dd") + "</td><td>"
                                             + dt.Rows[loopCount]["ProjectName"] + "</td><td>"
                                             + dt.Rows[loopCount]["LineName"] + "</td><td>"
                                             + dt.Rows[loopCount]["BatchName"] + "</td><td>"
                                             + dt.Rows[loopCount]["ZoneName"] + "</td><td>"
                                             + dt.Rows[loopCount]["Module"] + "</td><td>"
                                             + dt.Rows[loopCount]["Points"] + "</td><td>"
                                             + dt.Rows[loopCount]["LineLeader"] + "</td><td>"
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
            private string GetEmailContentRecruitment(string name, string PID, string BodySubject)
            {
                string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

                //EmployeeBAL empBAL = new EmployeeBAL();
                //DataTable dt = new DataTable();
                // dt=empBAL.GetDetails(Convert.ToInt32(name));
                String Body1 = String.Empty;




                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/Confirm.html")))
                {

                    Body1 = reader.ReadToEnd();

                }
                //Body1 = Body1.Replace("{Name}", name);
                //Body1 = Body1.Replace("{PID}", PID);
                //Body1 = Body1.Replace("{URL}", Url);
                //Body1 = Body1.Replace("{Subject}", BodySubject);

                //string htmlString = " <table styple='border-collapse: collapse,width: 100%;'><tr ><th>Material</th><th>Description</th><th>MaterialType</th><th>Quantity</th><th>RecQty</th><th>FormateType</th><th>Status</th><th>PendingDays</th></tr>";

                //for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                //{
                //    htmlString += "<tr><td>" + dt.Rows[loopCount]["Employee"] + "</td><td>"
                //                             + dt.Rows[loopCount]["Department"] + "</td><td>"
                //                             + dt.Rows[loopCount]["Category"] + "</td><td>"
                //                             + dt.Rows[loopCount]["Department"] + "</td><td>"
                //                             + dt.Rows[loopCount]["Description"] + "</td><td>"
                //                             //+ dt.Rows[loopCount]["FormateType"] + "</td><td>"
                //                             //+ dt.Rows[loopCount]["Status"] + "</td><td>"
                //                             //+ dt.Rows[loopCount]["PendingDays"] + "</td>"
                //                             + "</tr>";
                //}
                //htmlString += "</table>";
                //Body1 = Body1.Replace("{Table}", htmlString);

                //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
                return Body1;
            }

            //private string GetEmailConfirmationRequirement(string name, string BodySubject)
            //{
            //    string Url = ConfigurationManager.AppSettings["ParentUrl"].ToString();

            //    String Body1 = String.Empty;
            //    DataTable dt = empBAL.GetDetails(Convert.ToInt32(name));

            //    using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/Confirm.html")))
            //    {

            //        Body1 = reader.ReadToEnd();

            //    }
            //    Body1 = Body1.Replace("{Name}", name);
            //    //Body1 = Body1.Replace("{PID}", PID);
            //    Body1 = Body1.Replace("{URL}", Url);
            //    Body1 = Body1.Replace("{Subject}", BodySubject);
            //    string htmlString = " <table style='border-collapse: collapse,width: 100%;'width='100%' border=1 align=center cellpadding=1 cellspacing=3><tr style='background-color:lightgreen' ><th>Employee</th><th>Department</th><th>Category</th><th>Description</th><th>CostEstimation</th><th>Budget</th><th>BudgetNo</th><th>PRPO</th><th>PRPOBudget</th></tr>";

            //    for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
            //    {
            //        htmlString += "<tr><td>" + dt.Rows[loopCount]["Employee"] + "</td><td>"
            //                                 + dt.Rows[loopCount]["Department"] + "</td><td>"
            //                                 + dt.Rows[loopCount]["Category"] + "</td><td>"
            //                                 + dt.Rows[loopCount]["Description"] + "</td><td>"
            //                                 + dt.Rows[loopCount]["CostEstimation"] + "</td><td>"
            //                                 + dt.Rows[loopCount]["Budget"] + "</td><td>"
            //                                 + dt.Rows[loopCount]["BudgetNo"] + "</td><td>"
            //                                 + dt.Rows[loopCount]["PRPO"] + "</td><td>"
            //                                 + dt.Rows[loopCount]["PRPOBudget"] + "</td><td>"
            //                                 + "</td></tr>";
            //    }
            //    htmlString += "</table>";
            //    Body1 = Body1.Replace("{RequestTable}", htmlString);
            //    //return ("<html><head><meta http-equiv='Content-Type' content='text/html'; charset='big5'><title> Document Control Center</title></head><body><font face='Arial'><table width='600px' border=0 align=center cellpadding=1 cellspacing=3><tr><td align='center' width='100%'><table><tr><td width='20%'>&nbsp;</td><td width='80%'><font size=4><a target='_blank' href='{%paramWebUr%}'>RSMIPL-DOCUMENT CONTROL CENTER APPROVAL REQUEST DOCUMENT</a></font></td></tr></table></td></tr><tr><td width='100%'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='20'>Dear " + name + ":</td></tr><tr><td height='20'>&nbsp;</td></tr><tr><td height='30'>DOCUMENT CONTROL CENTER Document iS Waiting for Approval PID NO:" + ParentId + "Please Click this link to approve the request mentioned in subject matter : <a target='_blank' href='" + Url + "'>Click here </a>. Please use your AD Account for login</td></tr></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>With Best Regards!</td></tr>  <tr><td width='100%'><hr size=1 width='100%'></td></tr><tr><td height='20'>To get support,contact:INDIT-SOFTWARE@MAIL.FOXCONN.COM</td></tr></table></font></body></html>");
            //    return Body1;
            //}
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

            private void SendEmailByService(string mailto, string name, string body, string Subject)
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
                    SendHtmlFormattedEmail(Subject, body, toMAilAdds);

                }
                catch (Exception ex)
                {

                }
            }

            #region Send Mail POST Method
            private void SendHtmlFormattedEmail(string subject, string body, List<string> toMAilAdds)
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
            #endregion
        }
    }
