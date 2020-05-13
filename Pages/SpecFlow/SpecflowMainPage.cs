using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Pages.SpecFlow
{
    public sealed class SpecflowMainPage : BasePage, IBasePage
    {
        // In our example no elements are needed here
        public SpecflowMainPage(IWebDriver webDriver) : base(webDriver)
        {
            PageFactory.InitElements(_webDriver, this);
        }
    }
}
