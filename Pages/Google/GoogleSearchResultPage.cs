using System.Collections.Generic;
using Extensions.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Pages.Google
{
  public sealed class GoogleSearchResultPage : BasePage
  {
    // put element description here
    [FindsBy(How = How.XPath, Using = "//div[@id='rso']/div[@class='g']")]
    public IWebElement[] searchResults;

    public GoogleSearchResultPage(IWebDriver webDriver) : base(webDriver)
    {
      PageFactory.InitElements(_webDriver, this);
      _pageObjectName = PageNames.GoogleSearchResultPage;
      _collections = new Dictionary<string, IWebElement[]>()
      {
        { "Search results", searchResults }
      };
    }
  }
}
