using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

using System.IO;

namespace TD_FWK.ReportManager
{
    public class ExtentReportManager
    {
        private ReportData Data { get; set; } = new ReportData();
        private HtmlReportData HtmlReportData { get; set; } = new HtmlReportData();

        public ExtentReportManager(ReportData reportData = null, HtmlReportData htmlReportData = null)
        {
            if (reportData != null) Data = reportData;
            if (htmlReportData != null) HtmlReportData = htmlReportData;
        }

        public ExtentReports CreateExtentReport(bool htmlReporterV3 = true)
        {
            var ExtReport = new ExtentReports();
            if (htmlReporterV3)
            {
                ExtReport.AttachReporter(CreateHtmlReporterV3());
            }
            else
            {
                ExtReport.AttachReporter(CreateHtmlReporter());
            }
            return ExtReport;
        }

        [System.Obsolete("ExtentV3HtmlReporter has been deprecated and will be removed in a future release")]
        private ExtentV3HtmlReporter CreateHtmlReporterV3()
        {
            if (!Directory.Exists(Data.FolderPath)) { Directory.CreateDirectory(Data.FolderPath); }

            var htmlReporter = new ExtentV3HtmlReporter(Path.Combine(Data.FolderPath, Data.FileName));
            htmlReporter.Config.ReportName = Data.FileName;
            htmlReporter.Config.DocumentTitle = HtmlReportData.HtmlDocumentTitle;
            htmlReporter.Config.Theme = HtmlReportData.Theme;
            htmlReporter.Config.CSS = HtmlReportData.HtmlCssConfig;

            return htmlReporter;
        }

        private ExtentHtmlReporter CreateHtmlReporter()
        {
            if (!Directory.Exists(Data.FolderPath)) { Directory.CreateDirectory(Data.FolderPath); }

            var htmlReporter = new ExtentHtmlReporter(Path.Combine(Data.FolderPath, Data.FileName));
            htmlReporter.Config.ReportName = Data.FileName;
            htmlReporter.Config.DocumentTitle = HtmlReportData.HtmlDocumentTitle;
            htmlReporter.Config.Theme = HtmlReportData.Theme;
            htmlReporter.Config.CSS = HtmlReportData.HtmlCssConfig;

            return htmlReporter;
        }

        public void FinishExtendReport()
        {
            var file = Path.Combine(Data.FolderPath, Data.FileName);

            File.WriteAllText(file, System.Text.RegularExpressions.Regex.Replace(File.ReadAllText(file), "https://cdn.rawgit.com/extent-framework/extent-github-cdn/c23457b/v3html/js/extent.js", "https://www.extentreports.com/resx/v3html/js/extent.js"));
            File.WriteAllText(file, System.Text.RegularExpressions.Regex.Replace(File.ReadAllText(file), "https://cdn.rawgit.com/extent-framework/extent-github-cdn/8644a9c/v3html/css/extent.css", "https://www.extentreports.com/resx/v3html/css/extent.css"));

        }
    }
}