using OpenQA.Selenium;

using System;
using SeleniumTools.FindElementTools;


namespace SeleniumTools
{
    public static class IWebElementExtendMethods
    {
        /// <summary>
        /// A partir de un IWebElement debuelve el Padre inmediato del mismo
        /// </summary>
        /// <param name="child">IWebElement para realizar la busqueda del Padre</param>
        /// <param name="name">Nombre del IWebElement</param>
        /// <returns>IWebElement que contiene al IWebElement actual</returns>
        public static IWebElement Parent(this IWebElement child, string name = "")
        {
            return child == null
                ? throw new ArgumentNullException(nameof(child), $"In Parent method. The element {name} is null")
                : child.FindElement(By.XPath(".."), 5, name: "Parent");
        }
    }
}
