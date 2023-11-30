using System;

namespace TD_FWK.ReportManager
{
    public class ReportData
    {
        public string FolderPath { get; set; } = AppDomain.CurrentDomain.BaseDirectory + @"\Reportes\" + DateTime.Now.ToString("dd-MM-yyyy") + @"\";
        public string FileName { get; set; } = "report.html";
    }
}