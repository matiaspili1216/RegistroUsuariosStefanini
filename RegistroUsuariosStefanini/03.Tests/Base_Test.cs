using AventStack.ExtentReports;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium.Chrome;

using ReportManager;

using System;
using System.IO;
using System.Linq;

namespace RegistroUsuariosStefanini.Tests
{
    [TestClass]
    public class Base_Test
    {
        public ChromeDriver Driver;
        public static ExtentReports ExtentReport;
        public static ExtentReportManager ReportManager;
        public ExtentTestManager ExtentTestManager;

        public TestContext TestContext { get; set; }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext test)
        {

            string fileName = $"RegistroUsuariosStefanini - {DateTime.Now:dd-MM-yyyy HH.mm}.html";
            ReportManager = new ExtentReportManager(new ReportData
            {
                FileName = fileName
            });
            ExtentReport = ReportManager.CreateExtentReport(true);
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            ReportManager.FinishExtendReport();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            Driver = new ChromeDriver($"{Directory.GetCurrentDirectory()}\\00.Tools\\Files\\chromedriver.exe");

            var properties = GetType().GetMethod(TestContext.TestName).GetCustomAttributes(true).OfType<TestPropertyAttribute>();
            var TestExecutionName = properties.FirstOrDefault(Test => Test.Name == "TestExecutionName");
            var TestExecutionNameValue = TestExecutionName == null ? TestContext.TestName : TestExecutionName.Value;

            var TestExecutionCategory = properties.FirstOrDefault(Test => Test.Name == "TestExecutionCategory");
            string TestExecutionCategoryValue = TestExecutionCategory == null ? "Unknown" : TestExecutionCategory.Value;

            ExtentTestManager = new ExtentTestManager(ExtentReport);
            ExtentTestManager.StartTest(TestExecutionNameValue, TestExecutionCategoryValue); ;
            ExtentTestManager.SetResultTest(Status.Info, "Inicia el test en Chrome");
        }


        [TestCleanup]
        public void TestCleanup() {
            Driver.Close(); Driver.Quit(); Driver.Dispose();
        }
    }
}
