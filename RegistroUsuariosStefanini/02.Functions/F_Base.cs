using AventStack.ExtentReports;

using OpenQA.Selenium;

using RegistroUsuariosStefanini._00.Tools;

using ReportManager;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroUsuariosStefanini.Functions
{
    public class F_Base
    {
        public ExtentTestManager ExtentTestManager;
        protected IWebDriver Driver { get; set; }

        public F_Base(IWebDriver driver, ExtentTestManager extentTestManager = null)
        {
            Driver = driver;
            ExtentTestManager = extentTestManager;
        }

        public void GoToURLApp()
        {
            string uRLApp = EnvironmentVariablesManager.URLApp;
            Driver.Navigate().GoToUrl(uRLApp);
            ExtentTestManager?.SetResultTest(Status.Info, "Se ingreso a '" + uRLApp + "'.");
        }

        public void ClearWebDriver()
        {
            Driver.Close();
            Driver.Quit();
            Driver.Dispose();
            Driver = null;
        }
    }
}
