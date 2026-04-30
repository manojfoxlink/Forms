<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>


<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>DashBoard</title>
         <script runat="server">
void Page_Load(object sender,EventArgs e)
    
{
     if(!IsPostBack)
     {

         
             
         //System.Data.DataSet ds = new System.Data.DataSet();
         //string connection = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ToString();
         //using ( System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection( connection ) )
         //{
         //    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand( "DHB_ScrapStatusBarChart", con );
         //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
            

         //    System.Data.SqlClient.SqlDataAdapter ad = new System.Data.SqlClient.SqlDataAdapter();
         //    ad.SelectCommand = cmd;
         //    ad.Fill( ds );

             System.Data.DataTable dt = new System.Data.DataTable();
             dt = (System.Data.DataTable)Session["Reports"];

             ReportViewer1.LocalReport.ReportPath = System.IO.Path.Combine(Server.MapPath("~/Reports"), "HumidityRecord.rdlc");
             ReportViewer1.LocalReport.DataSources.Clear();
             ReportDataSource rdc = new ReportDataSource("DataSet1", dt);
             //ReportDataSource rdc1 = new ReportDataSource("DataSet2", ds.Tables[1]);
             //ReportDataSource rdc2 = new ReportDataSource("DataSet3", ds.Tables[2]);

             //ReportViewer1.LocalReport.DataSources.Add(rdc2);
             //ReportViewer1.LocalReport.DataSources.Add(rdc1);
             ReportViewer1.LocalReport.DataSources.Add( rdc );
            
             ReportViewer1.LocalReport.Refresh();
         //}
          
          
     }
    }
</script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server"   AsyncRendering="false" SizeToReportContent="True" ShowBackButton="False" ShowDocumentMapButton="False" ShowExportControls="True" ShowFindControls="False" ShowPageNavigationControls="False" ShowPrintButton="True" ShowPromptAreaButton="False" ShowRefreshButton="False" ShowZoomControl="False" Width="966px" ></rsweb:ReportViewer>
</div>
        
        </form>
</body>
</html>
