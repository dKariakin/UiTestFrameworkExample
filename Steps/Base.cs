using Drivers;
using Extensions.Pages.Base;
using Extensions.Pages.Factory;
using OpenQA.Selenium;
using Pages.Google;
using Pages.SpecFlow;

namespace Steps
{
  public abstract class Base
  {
    protected static IWebDriver _webDriver = null;
    protected PagesFactory _pages = null;

    public Base()
    {
      _webDriver = new WebDriverSetup().GetWebDriver();
      _pages = CreatePages();
    }

    private PagesFactory CreatePages()
    {
      return new PagesFactory(new IPagePrototype[]
      {
        new GoogleMainPage(_webDriver),
        new GoogleSearchResultPage(_webDriver),
        new SpecflowMainPage(_webDriver)
      });
    }
  }
}
