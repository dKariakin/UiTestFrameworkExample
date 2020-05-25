using System;
using System.Collections.Generic;
using Drivers;
using Extensions.PageManager;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Extensions.Pages.Base
{
  public abstract class PagePrototype : PageObjectManager, IPagePrototype
  {
    protected static IWebDriver _webDriver;
    protected static WebDriverWait _driverWaiter;
    private Dictionary<string, IWebElement> _elements;
    private string _pageUrl;

    protected PagePrototype(IWebDriver webDriver, string pageName)
    {
      SetPageObjectName(pageName);
      _webDriver = webDriver;
      _driverWaiter = new WebDriverWait(_webDriver, WebDriverConfigManager.GetTimeout());
    }

    protected PagePrototype(IWebDriver webDriver, string pageName, string pageUrl)
    {
      SetPageObjectName(pageName);
      SetPageUrl(pageUrl);
      _webDriver = webDriver;
      _driverWaiter = new WebDriverWait(_webDriver, WebDriverConfigManager.GetTimeout());
    }

    /// <summary>
    /// Wait until web element is loaded
    /// </summary>
    /// <param name="elementName">Element name in element dictionary</param>
    protected virtual void Wait(string elementName)
    {
      if (!_driverWaiter.Until(_ => GetElement(elementName).Displayed))
      {
        throw new ElementNotVisibleException($"Couldn't find {elementName} on {GetPageObjectName()}");
      }
    }

    /// <summary>
    /// Initialize dictionary of elements with collection of those
    /// </summary>
    /// <param name="elementCollection">Element name - element</param>
    protected void SetElements((string, IWebElement)[] elementCollection)
    {
      if (_elements == null)
      {
        _elements = new Dictionary<string, IWebElement>();
      }

      foreach ((string, IWebElement) element in elementCollection)
      {
        _elements.Add(element.Item1, element.Item2);
      }
    }

    protected IWebElement GetElement(string elementName)
    {
      if (_elements.ContainsKey(elementName.ToLower()))
      {
        return _elements[elementName.ToLower()];
      }
      else
      {
        throw new KeyNotFoundException($"Element {elementName} on page {GetPageObjectName()} is undefined");
      }
    }

    protected Uri GetPageUrl()
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

    protected virtual void SetPageUrl(string url)
    {
      _pageUrl = url;
    }

    /// <summary>
    /// Method just perform click on an element on a page
    /// </summary>
    /// <param name="elementName">Element name we are about to click</param>
    /// <param name="isPageChanged">Does page changes to other one?</param>
    public virtual void Click(string elementName, bool isPageChanged = true)
    {
      Wait(elementName);
      GetElement(elementName).Click();

      if (isPageChanged)
      {
        CurrentPageName = GetNextPageName(elementName);
      }
    }

    public virtual void SendText(string elementName, string text)
    {
      Wait(elementName);
      GetElement(elementName).SendKeys(text);
    }

    /// <summary>
    /// Open current page and initialize PageObjectManager with its name
    /// </summary>
    public virtual void OpenPage()
    {
      _webDriver.Navigate().GoToUrl(GetPageUrl());
      CurrentPageName = GetPageObjectName();
    }
  }
}
