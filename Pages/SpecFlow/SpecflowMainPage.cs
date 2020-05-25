using Extensions.Pages.Base;
using OpenQA.Selenium;

namespace Pages.SpecFlow
{
  public sealed class SpecflowMainPage : PagePrototype, IPagePrototype
  {
    public SpecflowMainPage(IWebDriver webDriver) : base(webDriver, PageNames.SpecFlowMainPage)
    {
    }
  }
}
