using AventStack.ExtentReports;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using RegistroUsuariosStefanini.Functions;

using ReportManager;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroUsuariosStefanini.Tests.RegisterTable
{
    [TestClass]
    public class RegisterTable_Test : Base_Test
    {
        [TestMethod]
        [TestProperty("TestExecutionName", "ValidateErrorName_Empty"), TestProperty("TestExecutionCategory", "RegisterTableTest")]
        public void ValidateErrorName_Empty()
        {
            try
            {
                Assert.IsTrue(new F_GeneralApp(Driver).GetURLAndVerify(), "No se ingreso a la URL");

                new F_RegisterForm(Driver, ExtentTestManager).AddNewUser("Matias Pili", "matiaspili@gmail.com", "12345678");

                ExtentTestManager.SetResultTest(Status.Info, $"Se agrega el usuario: Matias Pili - matiaspili@gmail.com");

                F_RegisterTable f_RegisterTable = new F_RegisterTable(Driver, ExtentTestManager);

                Assert.IsTrue(f_RegisterTable.ValidateRowData(1, "Matias Pili", "matiaspili@gmail.com", out string details), details);

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
