using OpenQA.Selenium;

using ReportManager;

namespace RegistroUsuariosStefanini.Functions
{
    public class F_GeneralApp : F_Base
    {
        private readonly Pages.GeneralAppPage Page;

        public F_GeneralApp(IWebDriver driver, ExtentTestManager extentTestManager = null) : base(driver, extentTestManager) { Page = new Pages.GeneralAppPage(Driver); }

        public bool GetURLAndVerify()
        {
            GoToURLApp();
            return Page.ExistsRootApp();
        }
    }
}
