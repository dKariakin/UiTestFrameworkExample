using System;
using Extensions.Pages.Base;
using OpenQA.Selenium;

namespace Pages.Google
{
  public sealed class GoogleSearchResultPage : PagePrototype, IPagePrototype
  {
    public IWebElement SearchResults => _webDriver.FindElement(By.CssSelector("#rso h3:first-of-type"));

    public GoogleSearchResultPage(IWebDriver webDriver) : base(webDriver, PageNames.GoogleSearchResultPage)
    {
      SetElements(new (string, Func<IWebElement>)[]
      {
        ("search result", () => SearchResults)
      });
      SetPageTransitions(new (string, string)[]
      {
        ("search result", PageNames.SpecFlowMainPage)
      });
    }
  }
}
