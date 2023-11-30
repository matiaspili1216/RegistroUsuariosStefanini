using OpenQA.Selenium;

namespace RegistroUsuariosStefanini.Pages
{
    public class GeneralAppPage : GeneralAppElements
    {
        public GeneralAppPage(IWebDriver driver) { Driver = driver; }

        public bool ExistsRootApp() => DivGeneralApp != null && DivGeneralApp.Displayed;

        public string GetPageinfo() => DivPageInfo?.Text;
    }
}
