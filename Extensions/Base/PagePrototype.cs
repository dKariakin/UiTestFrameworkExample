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
    private Dictionary<string, IWebElement> _elements;
    private string _pageUrl;
    private string _pageObjectName;

    protected PagePrototype(IWebDriver webDriver)
    {
      _webDriver = webDriver;
      _driverWaiter = new WebDriverWait(_webDriver, new TimeSpan(0, 0, 3));
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
        throw new NullReferenceException($"Element {elementName} on page {GetPageObjectName()} is undefined");
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

    /// <summary>
    /// Get current page object name
    /// </summary>
    public string GetPageObjectName()
    {
      return _pageObjectName;
    }

    protected void SetPageObjectName(string name)
    {
      _pageObjectName = name;
    }

    protected void SetPageUrl(string url)
    {
      _pageUrl = url;
    }
  }
}
