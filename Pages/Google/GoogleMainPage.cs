using System.Collections.Generic;
using Extensions.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Pages.Google
{
  public sealed class GoogleMainPage : BasePage
  {
    [FindsBy(How = How.Name, Using = "q")]
    public IWebElement SearchString;
    [FindsBy(How = How.XPath, Using = "(//input[@value='Google Search'])[2]")]
    public IWebElement SearchButton;

    public GoogleMainPage(IWebDriver webDriver) : base(webDriver)
    {
      PageFactory.InitElements(_webDriver, this);
      _pageUrl = "http://www.google.com";
      _pageObjectName = PageNames.GoogleMainPage;
      _elements = new Dictionary<string, IWebElement>()
      {
        { "Search string", SearchString },
        { "Search button", SearchButton }
      };
    }
  }
}
