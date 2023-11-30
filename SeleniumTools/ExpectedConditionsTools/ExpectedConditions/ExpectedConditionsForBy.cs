using OpenQA.Selenium;

using System;
using System.Collections.ObjectModel;

namespace SeleniumTools.ExpectedConditionsTools
{
    public class ExpectedConditionsForBy
    {

        public static Func<By, IWebElement> FindElement(ISearchContext context) => (by) => { return by.FindElement(context); };

        public static Func<By, ReadOnlyCollection<IWebElement>> FindElements(ISearchContext context) => (by) => { return by.FindElements(context); };     
    }
}