using AventStack.ExtentReports;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using RegistroUsuariosStefanini.Functions;

using System;

namespace RegistroUsuariosStefanini.Tests.GeneralApp
{
    [TestClass]
    public class GeneralApp_Test : Base_Test
    {
        [TestMethod]
        [TestProperty("TestExecutionName", "AccessApp"), TestProperty("TestExecutionCategory", "GeneralAppTest")]
        public void AccessApp()
        {

            try
            {
                F_GeneralApp f_GeneralApp = new F_GeneralApp(Driver, ExtentTestManager);

                Assert.IsTrue(f_GeneralApp.GetURLAndVerify(), "No se ingreso a la URL");

                ExtentTestManager.SetResultTestAndTakeCapture(Status.Pass, "La ejecución finalizó correctamente.", Driver);

            }
            catch (Exception e)
            {
                ExtentTestManager.SetResultTestAndTakeCapture(Status.Error, e.Message, Driver);

                throw;
            }

        }
    }
}
