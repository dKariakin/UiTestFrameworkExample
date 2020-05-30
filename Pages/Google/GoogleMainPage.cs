using System;
using System.Linq;
using Extensions.Pages.Base;
using OpenQA.Selenium;

namespace Pages.Google
{
  public sealed class GoogleMainPage : PagePrototype, IPagePrototype
  {
    public IWebElement SearchString => _webDriver.FindElement(By.Name("q"));

    public IWebElement SearchButton => _webDriver.FindElements(By.XPath("//form[@action='/search']/descendant::center/input[@name!='q' and @type='submit' and not(@jsaction)]"))
                                                 .First(element => element.Displayed);

    public GoogleMainPage(IWebDriver webDriver) : base(webDriver, PageNames.GoogleMainPage, "http://www.google.com")
    {
      SetElements(new (string, Func<IWebElement>)[]
      {
        ("search string", () => SearchString),
        ("search button", () => SearchButton)
      });
      SetPageTransitions(new (string, string)[]
      {
        ("search button", PageNames.GoogleSearchResultPage)
      });
    }
  }
}
