using Drivers;
using Extensions;
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
    protected PageObjectManager _poManager = null;

    public Base()
    {
      _webDriver = new WebDriverSetup().GetWebDriver();
      _poManager = new PageObjectManager();
      _pages = CreatePages();
    }

    private PagesFactory CreatePages()
    {
      PagesFactory factory = new PagesFactory();
      factory.InitializePages(new IPagePrototype[]
      {
        new GoogleMainPage(_webDriver, _poManager),
        new GoogleSearchResultPage(_webDriver, _poManager),
        new SpecflowMainPage(_webDriver, _poManager)
      });

      return factory;
    }
  }
}
