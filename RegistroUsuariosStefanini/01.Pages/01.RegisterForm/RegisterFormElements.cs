using SeleniumTools.FindElementTools;
using SeleniumTools;

using OpenQA.Selenium;

namespace RegistroUsuariosStefanini.Pages
{
    public class RegisterFormElements
    {
        protected IWebDriver Driver;

        protected IWebElement DivRegisterForm => Driver.FindElement(By.ClassName("register-form"), 5, name: "DivRegisterForm");
        protected IWebElement RF_Form => DivRegisterForm.FindElement(By.TagName("form"), 5, name: "RF_Form");
        protected IWebElement RF_FormName => RF_Form.FindElement(By.Id("name"), 5, name: "RF_FormName");
        protected IWebElement RF_FormNameErrors => RF_FormName.Parent().FindElement(By.ClassName("error"), 5, name: "RF_FormNameErrors");
        protected IWebElement RF_FormEmail => RF_Form.FindElement(By.Id("email"), 5, name: "RF_FormEmail");
        protected IWebElement RF_FormEmailErrors => RF_FormEmail.Parent().FindElement(By.ClassName("error"), 5, name: "RF_FormEmailErrors");
        protected IWebElement RF_FormPass => RF_Form.FindElement(By.Id("password"), 5, name: "RF_FormPass");
        protected IWebElement RF_FormPassErrors => RF_FormPass.Parent().FindElement(By.ClassName("error"), 5, name: "RF_FormPassErrors");
        protected IWebElement RF_FormRegister => RF_Form.FindElement(By.Id("register"), 5, name: "RF_FormRegister");
    }
}
