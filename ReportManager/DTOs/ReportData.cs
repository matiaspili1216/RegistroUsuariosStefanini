using System;

namespace RegistroUsuariosStefanini.ReportManager
{
    public class ReportData
    {
        public string FolderPath { get; set; } = AppDomain.CurrentDomain.BaseDirectory + @"\Reportes\" + DateTime.Now.ToString("dd-MM-yyyy") + @"\";
        public string FileName { get; set; } = "report.html";
    }
}