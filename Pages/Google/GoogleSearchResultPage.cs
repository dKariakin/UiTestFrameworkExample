﻿using Extensions.Pages.Base;
using OpenQA.Selenium;

namespace Pages.Google
{
  public sealed class GoogleSearchResultPage : PagePrototype, IPagePrototype
  {
    public IWebElement searchResults => _webDriver.FindElement(By.XPath("//div[@id='res']//div[@class='r']//h3"));

    public GoogleSearchResultPage(IWebDriver webDriver) : base(webDriver, PageNames.GoogleSearchResultPage)
    {
      SetElements(new (string, IWebElement)[]
      {
        ("search result", searchResults)
      });
      SetPageTransitions(new (string, string)[]
      {
        ("search result", PageNames.SpecFlowMainPage)
      });
    }
  }
}
