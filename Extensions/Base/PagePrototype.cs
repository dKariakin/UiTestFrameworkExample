using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Extensions.Pages.Base
{
  public abstract class PagePrototype : IPagePrototype
  {
    protected IWebDriver _webDriver;
    protected WebDriverWait _driverWaiter;
    protected Dictionary<string, IWebElement> _elements;
    protected string _pageUrl;
    protected string _pageObjectName;

    public PagePrototype(IWebDriver webDriver)
    {
      _webDriver = webDriver;
      _driverWaiter = new WebDriverWait(_webDriver, new TimeSpan(0, 0, 3));
    }

    /// <summary>
    /// Wait until web element is loaded
    /// </summary>
    /// <param name="elementName">Element name in _elements</param>
    private void Wait(string elementName)
    {
      if (!_driverWaiter.Until(_ => GetElement(elementName).Displayed))
      {
        throw new ElementNotVisibleException($"Couldn't find {elementName} on {GetPageObjectName()}");
      }
    }

    private IWebElement GetElement(string elementName)
    {
      if (_elements.ContainsKey(elementName.ToLower()))
      {
        return _elements[elementName.ToLower()];
      }
      else
      {
        throw new NullReferenceException($"Element {elementName} on page {GetPageObjectName()} is undefined");
      }
    }

    public void Click(string elementName)
    {
      Wait(elementName);
      GetElement(elementName).Click();
    }

    public void SendText(string elementName, string text)
    {
      Wait(elementName);
      GetElement(elementName).SendKeys(text);
    }

    public Uri GetPageUrl()
    {
      try
      {
        return new Uri(_pageUrl);
      }
      catch (NullReferenceException)
      {
        throw new NullReferenceException($"{GetPageObjectName()} url is undefined");
      }
    }

    public void OpenPage()
    {
      _webDriver.Navigate().GoToUrl(GetPageUrl());
    }

    /// <summary>
    /// Get current page object name
    /// </summary>
    public string GetPageObjectName()
    {
      return _pageObjectName;
    }
  }
}
