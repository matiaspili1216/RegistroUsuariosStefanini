namespace TD_FWK.ReportManager
{
    public class HtmlReportData
    {
        public AventStack.ExtentReports.Reporter.Configuration.Theme Theme { get; set; } = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
        public string HtmlDocumentTitle { get; set; } = "Automation report";
        public string HtmlCssConfig { get; set; } = ".runtime-table { width: 100% !important; border: none !important; } " +
                                     ".runtime-table a > i.material-icons { float: right !important} " +
                                     "ul.steps > .pass .runtime-table { background: none !important; } " +
                                     "ul.steps > .fail .runtime-table { background: #ff9a9a !important; } " +
                                     "ul.steps > .skip .runtime-table { background: #cbdefb !important; } " +
                                     "ul.steps > .warning .runtime-table { background: #fffbdd !important; } " +
                                     "ul.steps > .fatal .runtime-table { background: rgba(193, 66, 66, .7) !important; } " +
                                     "ul.steps > .error .runtime-table { background: rgba(227, 180, 208, .7) !important; } ";
    }
}