using Extensions;
using Extensions.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Pages.SpecFlow
{
  public sealed class SpecflowMainPage : PagePrototype, IPagePrototype
  {
    // In our example no elements are needed here
    public SpecflowMainPage(IWebDriver webDriver, PageObjectManager manager) : base(webDriver, manager)
    {
      PageFactory.InitElements(_webDriver, this);
      SetPageObjectName(PageNames.SpecFlowMainPage);
    }
  }
}
