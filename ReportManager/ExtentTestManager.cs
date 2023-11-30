using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.MarkupUtils;

using OpenQA.Selenium;

using System;
using System.Linq;

namespace ReportManager
{
    public class ExtentTestManager
    {
        private readonly ExtentReports ExtReport;
        private ExtentTest ExtTest;

        public ExtentTestManager(ExtentReports extReport) => ExtReport = extReport;

        public void StartTest(string testName, string testCategory = null, string testDescription = null)
        {
            ExtTest = ExtReport.CreateTest(testName, testDescription);
            if (!string.IsNullOrEmpty(testCategory)) ExtTest.AssignCategory(testCategory);
            ExtReport.Flush();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">IGherkinFormatterModel type: Given, And, When or Then</typeparam>
        /// <param name="featureName"></param>
        /// <param name="scenarioName"></param>
        /// <param name="testName"></param>
        /// <param name="testCategory"></param>
        /// <param name="testDescription"></param>
        public void StartTestGherkin<T>(string featureName, string scenarioName, string testName, string testCategory = null, string testDescription = "") where T : IGherkinFormatterModel
        {
            var testFeature = ExtReport.CreateTest<Feature>(featureName);
            var testScenario = testFeature.CreateNode<Scenario>(scenarioName);
            ExtTest = testScenario.CreateNode<T>(testName, testDescription);

            if (!string.IsNullOrEmpty(testCategory)) ExtTest.AssignCategory(testCategory);

            ExtReport.Flush();
        }

        public void SetResultTest(Status status, string testOutcomeDetails, string capturesInBase64 = null, string mimeType = "image/gif")
        {
            SetResultTest(status, testOutcomeDetails, string.IsNullOrEmpty(capturesInBase64) ? new string[] { } : new string[] { capturesInBase64 }, mimeType);
        }

        public void SetResultTest(Status status, string testOutcomeDetails, string[] capturesInBase64, string mimeType = "image/gif")
        {
            var markupTable = MarkupCreateTableImage(testOutcomeDetails ?? "Sin detalle", capturesInBase64, mimeType);

            switch (status)
            {
                case Status.Pass: ExtTest.Pass(markupTable); break;
                case Status.Error: ExtTest.Error(markupTable); break;
                case Status.Fail: ExtTest.Fail(markupTable); break;
                case Status.Fatal: ExtTest.Fatal(markupTable); break;
                case Status.Warning: ExtTest.Warning(markupTable); break;
                case Status.Info: ExtTest.Info(markupTable); break;
                case Status.Skip: ExtTest.Skip(markupTable); break;
                case Status.Debug: ExtTest.Debug(markupTable); break;
                default: ExtTest.Pass(markupTable); break;
            }

            ExtReport.Flush();
        }

        public void SetResultTestWithPDF(Status status, string testOutcomeDetails, string fileInBase64)
        {
            var markupTable = MarkupCreateTablePDF(testOutcomeDetails ?? "Sin detalle", fileInBase64);

            switch (status)
            {
                case Status.Pass: ExtTest.Pass(markupTable); break;
                case Status.Error: ExtTest.Error(markupTable); break;
                case Status.Fail: ExtTest.Fail(markupTable); break;
                case Status.Fatal: ExtTest.Fatal(markupTable); break;
                case Status.Warning: ExtTest.Warning(markupTable); break;
                case Status.Info: ExtTest.Info(markupTable); break;
                case Status.Skip: ExtTest.Skip(markupTable); break;
                case Status.Debug: ExtTest.Debug(markupTable); break;
                default: ExtTest.Pass(markupTable); break;
            }

            ExtReport.Flush();
        }

        public void SetResultTestAndTakeCapture(Status status, string testOutcomeDetails, IWebDriver iWebDriver)
        {
            var captureInBase64 = ((ITakesScreenshot)iWebDriver).GetScreenshot().AsBase64EncodedString;

            SetResultTest(status, testOutcomeDetails, captureInBase64);
        }

        private IMarkup MarkupCreateTableImage(string testOutcomeDetails, string[] captureFromBase64, string mimeType = "image/gif")
        {
            string baseImageHTML = "<a href='data:{0};base64,{1}'data-featherlight='image'><i class=\"material-icons\">panorama</i></a>";

            var listImageHTML = captureFromBase64.Select(x => string.Format(baseImageHTML, mimeType, x));

            var ImageHTML = listImageHTML.Any() ? new string(listImageHTML.SelectMany(x => x).ToArray()) : "";

            string[][] table = new string[][] { new string[] { testOutcomeDetails, ImageHTML } };

            return MarkupHelper.CreateTable(table);
        }

        private IMarkup MarkupCreateTablePDF(string testOutcomeDetails, string pdfsInBase64)
        {
            string[][] table = new string[][] { new string[] { testOutcomeDetails, $"<embed width=\'100%\' height=\'100%\' src=\"data:application/pdf;base64,{pdfsInBase64}\" type=\"application/pdf\" />" } };

            return MarkupHelper.CreateTable(table);
        }

        public Status GetStatusByOutcom(Microsoft.VisualStudio.TestTools.UnitTesting.UnitTestOutcome unitTestOutcome)
        {
            switch (unitTestOutcome)
            {
                case Microsoft.VisualStudio.TestTools.UnitTesting.UnitTestOutcome.Failed: return Status.Fail;
                case Microsoft.VisualStudio.TestTools.UnitTesting.UnitTestOutcome.Inconclusive: return Status.Skip;
                case Microsoft.VisualStudio.TestTools.UnitTesting.UnitTestOutcome.Passed: return Status.Pass;
                case Microsoft.VisualStudio.TestTools.UnitTesting.UnitTestOutcome.InProgress: return Status.Info;
                case Microsoft.VisualStudio.TestTools.UnitTesting.UnitTestOutcome.Error: return Status.Error;
                case Microsoft.VisualStudio.TestTools.UnitTesting.UnitTestOutcome.Timeout: return Status.Error;
                case Microsoft.VisualStudio.TestTools.UnitTesting.UnitTestOutcome.Aborted: return Status.Skip;
                case Microsoft.VisualStudio.TestTools.UnitTesting.UnitTestOutcome.Unknown: return Status.Info;
                case Microsoft.VisualStudio.TestTools.UnitTesting.UnitTestOutcome.NotRunnable: return Status.Info;
                default: return Status.Pass;
            }
        }
    }
}
