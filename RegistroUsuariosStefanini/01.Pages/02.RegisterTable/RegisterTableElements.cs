using SeleniumTools.FindElementTools;
using SeleniumTools;

using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace RegistroUsuariosStefanini.Pages
{
    public class RegisterTableElements
    {
        protected IWebDriver Driver;

        protected IWebElement TableTitle => Driver.FindElement(By.ClassName("table-title"), 5, name: "TableTitle");
        protected IWebElement Table => Driver.FindElement(By.TagName("table"), 5, name: "Table");

        protected IWebElement TableRowID(int row) => Table.FindElement(By.Id($"tdUserId{row}"), 5, name: "TableRowID");
        protected IWebElement TableRowName(int row) => Table.FindElement(By.Id($"tdUserName{row}"), 5, name: "TableRowName");
        protected IWebElement TableRowEmail(int row) => Table.FindElement(By.Id($"tdUserEmail{row}"), 5, name: "TableRowEmail");
        protected IWebElement TableRowRemove(int row) => Table.FindElement(By.Id($"removeUser{row}"), 5, name: "TableRowRemove");

        protected ReadOnlyCollection<IWebElement> TableRows => Table.FindElements(By.TagName("tr"), 5, name: "TableRows");
        protected ReadOnlyCollection<IWebElement> TableRowCell(int row) => TableRows[row].FindElements(By.TagName("td"), 5, name: "TableRows");

    }
}
