using Extensions.Pages.Base;
using OpenQA.Selenium;

namespace Pages.Google
{
  public sealed class GoogleMainPage : PagePrototype, IPagePrototype
  {
    public IWebElement SearchString => _webDriver.FindElement(By.Name("q"));

    public IWebElement SearchButton => _webDriver.FindElement(By.XPath("(//input[contains(@value, 'Google')])[2]"));

    public GoogleMainPage(IWebDriver webDriver) : base(webDriver, PageNames.GoogleMainPage, "http://www.google.com")
    {
      SetElements(new (string, IWebElement)[]
      {
        ("search string", SearchString),
        ("search button", SearchButton)
      });
      SetPageTransitions(new (string, string)[]
      {
        ("search button", PageNames.GoogleSearchResultPage)
      });
    }
  }
}
