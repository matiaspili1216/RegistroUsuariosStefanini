using OpenQA.Selenium;
using ReportManager;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroUsuariosStefanini.Functions
{
    public class F_RegisterForm : F_Base
    {
        private readonly Pages.RegisterFormPage Page;

        public F_RegisterForm(IWebDriver driver, ExtentTestManager extentTestManager = null) : base(driver, extentTestManager) { Page = new Pages.RegisterFormPage(Driver); }
                
        public bool ValidateErrorName(string name, string expectedError, out string details)
        {
           if(string.IsNullOrEmpty(name)) { Page.ClicRegister(); }
           else { Page.SetName(name).ClicRegister(); }

            string error = Page.GetFormNameErrors();

            if (string.IsNullOrEmpty(error)) { details = "No se muestra error"; return false; }
            else if(!expectedError.Equals(error)){ details = $"No se muestra el error esperado. Actual: {error}. Esperado {expectedError}"; return false; }
            else { details = ""; return true; }
        }

        public bool ValidateErrorEmail(string email, string expectedError, out string details)
        {
            if (string.IsNullOrEmpty(email)) { Page.ClicRegister(); }
            else { Page.SetEmail(email).ClicRegister(); }

            string error = Page.GetFormEmailErrors();

            if (string.IsNullOrEmpty(error)) { details = "No se muestra error"; return false; }
            else if (!expectedError.Equals(error)) { details = $"No se muestra el error esperado. Actual: {error}. Esperado {expectedError}"; return false; }
            else { details = ""; return true; }
        }

        public bool ValidateErrorPass(string pass, string expectedError, out string details)
        {
            if (string.IsNullOrEmpty(pass)) { Page.ClicRegister(); }
            else { Page.SetPass(pass).ClicRegister(); }

            string error = Page.GetFormPassErrors();

            if (string.IsNullOrEmpty(error)) { details = "No se muestra error"; return false; }
            else if (!expectedError.Equals(error)) { details = $"No se muestra el error esperado. Actual: {error}. Esperado {expectedError}"; return false; }
            else { details = ""; return true; }
        }

        public void AddNewUser(string name, string email, string pass)
        {
            Page
                .SetName(name)
                .SetEmail(email)
                .SetPass(pass)
                .ClicRegister();
        }
    }
}
