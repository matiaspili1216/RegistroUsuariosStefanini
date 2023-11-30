using AventStack.ExtentReports;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using RegistroUsuariosStefanini.Functions;

using System;

namespace RegistroUsuariosStefanini.Tests.RegisterForm
{
    [TestClass]
    public class RegisterForm_Test : Base_Test
    {
        [TestMethod]
        [TestProperty("TestExecutionName", "ValidateErrorName_Empty"), TestProperty("TestExecutionCategory", "RegisterFormTest")]
        public void ValidateErrorName_Empty()
        {
            try
            {
                Assert.IsTrue(new F_GeneralApp(Driver).GetURLAndVerify(), "No se ingreso a la URL");

                F_RegisterForm f_RegisterForm = new F_RegisterForm(Driver, ExtentTestManager);

                ExtentTestManager.SetResultTest(Status.Info, $"Se valida el mensaje 'O campo Nome é obrigatório.', al no completar Nombre.");

                Assert.IsTrue(f_RegisterForm.ValidateErrorName(null, "O campo Nome é obrigatório.", out string details), details);

                ExtentTestManager.SetResultTestAndTakeCapture(Status.Pass, "La ejecución finalizó correctamente.", Driver);

            }
            catch (Exception e)
            {
                ExtentTestManager.SetResultTestAndTakeCapture(Status.Error, e.Message, Driver);

                throw;
            }
        }

        [TestMethod]
        [TestProperty("TestExecutionName", "ValidateErrorName_Empty"), TestProperty("TestExecutionCategory", "RegisterFormTest")]
        public void ValidateErrorName_Invalid()
        {
            try
            {
                Assert.IsTrue(new F_GeneralApp(Driver).GetURLAndVerify(), "No se ingreso a la URL");

                F_RegisterForm f_RegisterForm = new F_RegisterForm(Driver, ExtentTestManager);

                ExtentTestManager.SetResultTest(Status.Info, $"Se valida el mensaje 'Por favor, insira um nome completo.', al completar Nombre invalido.");

                Assert.IsTrue(f_RegisterForm.ValidateErrorName("Matias", "Por favor, insira um nome completo.", out string details), details);

                ExtentTestManager.SetResultTestAndTakeCapture(Status.Pass, "La ejecución finalizó correctamente.", Driver);

            }
            catch (Exception e)
            {
                ExtentTestManager.SetResultTestAndTakeCapture(Status.Error, e.Message, Driver);

                throw;
            }
        }

        [TestMethod]
        [TestProperty("TestExecutionName", "ValidateErrorEmail_Empty"), TestProperty("TestExecutionCategory", "RegisterFormTest")]
        public void ValidateErrorEmail_Empty()
        {
            try
            {
                Assert.IsTrue(new F_GeneralApp(Driver).GetURLAndVerify(), "No se ingreso a la URL");

                F_RegisterForm f_RegisterForm = new F_RegisterForm(Driver, ExtentTestManager);

                ExtentTestManager.SetResultTest(Status.Info, $"Se valida el mensaje 'O campo E-mail é obrigatório.', al no completar Email.");

                Assert.IsTrue(f_RegisterForm.ValidateErrorEmail(null, "O campo E-mail é obrigatório.", out string details), details);

                ExtentTestManager.SetResultTestAndTakeCapture(Status.Pass, "La ejecución finalizó correctamente.", Driver);

            }
            catch (Exception e)
            {
                ExtentTestManager.SetResultTestAndTakeCapture(Status.Error, e.Message, Driver);

                throw;
            }
        }


        [TestMethod]
        [TestProperty("TestExecutionName", "ValidateErrorEmail_Invalid"), TestProperty("TestExecutionCategory", "RegisterFormTest")]
        public void ValidateErrorEmail_Invalid()
        {
            try
            {
                Assert.IsTrue(new F_GeneralApp(Driver).GetURLAndVerify(), "No se ingreso a la URL");

                F_RegisterForm f_RegisterForm = new F_RegisterForm(Driver, ExtentTestManager);

                ExtentTestManager.SetResultTest(Status.Info, $"Se valida el mensaje 'Por favor, insira um e-mail válido.', al completar Email invalido.");

                Assert.IsTrue(f_RegisterForm.ValidateErrorEmail("asd", "Por favor, insira um e-mail válido.", out string details), details);

                ExtentTestManager.SetResultTestAndTakeCapture(Status.Pass, "La ejecución finalizó correctamente.", Driver);

            }
            catch (Exception e)
            {
                ExtentTestManager.SetResultTestAndTakeCapture(Status.Error, e.Message, Driver);

                throw;
            }
        }


        [TestMethod]
        [TestProperty("TestExecutionName", "ValidateErrorPass_Empty"), TestProperty("TestExecutionCategory", "RegisterFormTest")]
        public void ValidateErrorPass_Empty()
        {

            try
            {
                Assert.IsTrue(new F_GeneralApp(Driver).GetURLAndVerify(), "No se ingreso a la URL");

                F_RegisterForm f_RegisterForm = new F_RegisterForm(Driver, ExtentTestManager);

                ExtentTestManager.SetResultTest(Status.Info, $"Se valida el mensaje 'O campo Senha é obrigatório.', al no completar Contraseña.");

                Assert.IsTrue(f_RegisterForm.ValidateErrorPass(null, "O campo Senha é obrigatório.", out string details), details);

                ExtentTestManager.SetResultTestAndTakeCapture(Status.Pass, "La ejecución finalizó correctamente.", Driver);

            }
            catch (Exception e)
            {
                ExtentTestManager.SetResultTestAndTakeCapture(Status.Error, e.Message, Driver);

                throw;
            }
        }


        [TestMethod]
        [TestProperty("TestExecutionName", "ValidateErrorPass_Invalid"), TestProperty("TestExecutionCategory", "RegisterFormTest")]
        public void ValidateErrorPass_Invalid()
        {

            try
            {
                Assert.IsTrue(new F_GeneralApp(Driver).GetURLAndVerify(), "No se ingreso a la URL");

                F_RegisterForm f_RegisterForm = new F_RegisterForm(Driver, ExtentTestManager);

                ExtentTestManager.SetResultTest(Status.Info, $"Se valida el mensaje 'A senha deve conter ao menos 8 caracteres.', al completar Contraseña invalida.");

                Assert.IsTrue(f_RegisterForm.ValidateErrorPass("1234", "A senha deve conter ao menos 8 caracteres.", out string details), details);

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
