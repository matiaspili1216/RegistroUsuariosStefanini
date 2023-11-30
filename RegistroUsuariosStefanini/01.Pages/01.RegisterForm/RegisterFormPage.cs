using OpenQA.Selenium;

namespace RegistroUsuariosStefanini.Pages
{
    public class RegisterFormPage : RegisterFormElements
    {
        public RegisterFormPage(IWebDriver driver) { Driver = driver; }

        public bool ExistsRegisterForm() => DivRegisterForm != null && DivRegisterForm.Displayed;

        public RegisterFormPage SetName(string name)
        {
            RF_FormName.SendKeys(name);
            return this;
        }

        public RegisterFormPage SetEmail(string email)
        {
            RF_FormEmail.SendKeys(email);
            return this;
        }

        public RegisterFormPage SetPass(string pass)
        {
            RF_FormPass.SendKeys(pass);
            return this;
        }

        public RegisterFormPage ClicRegister()
        {
            RF_FormRegister.Click();
            return this;
        }

        public string GetFormNameErrors() => RF_FormNameErrors?.Text;
        public string GetFormEmailErrors() => RF_FormEmailErrors?.Text;
        public string GetFormPassErrors() => RF_FormPassErrors?.Text;    
    }
}