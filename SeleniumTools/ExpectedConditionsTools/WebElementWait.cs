using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using System;

namespace SeleniumTools.ExpectedConditionsTools
{
    public class WebElementWait : DefaultWait<IWebElement>
    {
        public WebElementWait(IWebElement element, TimeSpan timeout) : base(element) => Timeout = timeout;
        public WebElementWait(IClock clock, IWebElement element, TimeSpan timeout, TimeSpan sleepInterval) : base(element, clock)
        {
            Timeout = timeout;
            PollingInterval = sleepInterval;
        }
    }
}