using SeleniumTools.FindElementTools;

using OpenQA.Selenium;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroUsuariosStefanini.Pages
{
    public class GeneralAppElements
    {
        protected IWebDriver Driver;

        protected IWebElement DivRoot => Driver.FindElement(By.Id("root"), 5, name: "DivRoot");
        protected IWebElement DivGeneralApp => DivRoot.FindElement(By.ClassName("App"), 5, name: "DivGeneralApp");
        protected IWebElement DivPageInfo => DivGeneralApp.FindElement(By.ClassName("page-info"), 5, name: "DivPageInfo");
    }
}
