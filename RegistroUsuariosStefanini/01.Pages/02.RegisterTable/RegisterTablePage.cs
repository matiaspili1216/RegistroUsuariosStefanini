using OpenQA.Selenium;

namespace RegistroUsuariosStefanini.Pages
{
    public class RegisterTablePage : RegisterTableElements
    {
        public RegisterTablePage(IWebDriver driver) { Driver = driver; }

        public bool ExistsTableTitle() => TableTitle != null && TableTitle.Displayed;

        public string GetTableRowID(int row) => TableRowID(row).Text;
        public string GetTableRowName(int row) => TableRowName(row).Text;
        public string GetTableRowEmail(int row) => TableRowEmail(row).Text;
        public void ClicTableRowRemove(int row) => TableRowRemove(row).Click();

        public int GetTableRowsCount() => TableRows.Count;

    }
}