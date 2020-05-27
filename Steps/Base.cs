using Drivers.Builder;
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
    protected static PagesFactory _pages = null;

    public Base()
    {
      _webDriver = InitializeWebDriver();
      _pages ??= CreatePages();
    }

    private IWebDriver InitializeWebDriver()
    {
      DriverCreator creator = new DriverCreator(new ChromeBuilder());

      creator.SetAcceptInsecureCertificates(true);
      creator.SetPageLoadStrategy(PageLoadStrategy.Eager);
      creator.SetUnhandledPromptBehavior(UnhandledPromptBehavior.Ignore);

      return creator.GetWebDriver();
    }

    private PagesFactory CreatePages()
    {
      PagesFactory factory = new PagesFactory();

      factory.InitializePages(new IPagePrototype[]
      {
        new GoogleMainPage(_webDriver),
        new GoogleSearchResultPage(_webDriver),
        new SpecflowMainPage(_webDriver)
      });

      return factory;
    }
  }
}
