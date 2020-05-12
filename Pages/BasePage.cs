using System.Collections.Generic;
using OpenQA.Selenium;

namespace Pages
{
    public abstract class BasePage
    {
        protected IWebDriver _webDriver;
        protected Dictionary<string, IWebElement> _elements;
        protected Dictionary<string, IWebElement[]> _collections;

        public BasePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
    }
}
