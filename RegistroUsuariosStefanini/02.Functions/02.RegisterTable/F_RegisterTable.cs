using OpenQA.Selenium;

using ReportManager;

namespace RegistroUsuariosStefanini.Functions
{
    public class F_RegisterTable : F_Base
    {
        private readonly Pages.RegisterTablePage Page;

        public F_RegisterTable(IWebDriver driver, ExtentTestManager extentTestManager = null) : base(driver, extentTestManager) { Page = new Pages.RegisterTablePage(Driver); }

        public bool ValidateRowData(int row, string expectedName, string expectedEmail, out string details)
        {
            string rowName = Page.GetTableRowName(row);
            string rowEmail = Page.GetTableRowEmail(row);

            if (string.IsNullOrEmpty(rowName) || string.IsNullOrEmpty(rowEmail)) { details = "No se muestran algunos datos"; return false; }
            else if (!expectedName.Equals(rowName)) { details = $"El valor de 'Name' no es el esperado. Actual: {rowName}. Esperado {expectedName}"; return false; }
            else if (!expectedEmail.Equals(rowEmail)) { details = $"El valor de 'Name' no es el esperado. Actual: {rowEmail}. Esperado {expectedEmail}"; return false; }
            else { details = ""; return true; }
        }
    }
}
