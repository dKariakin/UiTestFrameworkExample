using System.Collections.Generic;
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

    public GoogleMainPage(IWebDriver webDriver) : base(webDriver)
    {
      PageFactory.InitElements(_webDriver, this);
      _pageUrl = "http://www.google.com";
      _pageObjectName = PageNames.GoogleMainPage;
      _elements = new Dictionary<string, IWebElement>()
      {
        { "search string", SearchString },
        { "search button", SearchButton }
      };
    }
  }
}
