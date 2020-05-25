using Extensions.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Pages.Google
{
  public sealed class GoogleMainPage : PagePrototype, IPagePrototype
  {
    [FindsBy(How = How.Name, Using = "q")]
    [CacheLookup]
    public IWebElement SearchString;

    [FindsBy(How = How.XPath, Using = "(//input[contains(@value, 'Google')])[2]")]
    [CacheLookup]
    public IWebElement SearchButton;

    public GoogleMainPage(IWebDriver webDriver) : base(webDriver, PageNames.GoogleMainPage, "http://www.google.com")
    {
      PageFactory.InitElements(_webDriver, this);
      
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
