using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Extensions.Pages.Base
{
  public abstract class PagePrototype : IPagePrototype
  {
    protected static IWebDriver _webDriver;
    protected static WebDriverWait _driverWaiter;
    private Dictionary<string, IWebElement> _elements;
    private Dictionary<string, string> _pageTransitions;
    private PageObjectManager _pageObjectManager;
    private string _pageUrl;
    private string _pageObjectName;

    protected PagePrototype(IWebDriver webDriver, PageObjectManager pageManager)
    {
      _webDriver = webDriver;
      _pageObjectManager = pageManager;
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

    protected virtual void SetPageUrl(string url)
    {
      _pageUrl = url;
    }

    protected void SetPageTransitions((string, string)[] transitions)
    {
      _pageTransitions = new Dictionary<string, string>();

      foreach((string, string) transition in transitions)
      {
        _pageTransitions.Add(transition.Item1, transition.Item2);
      }
    }

    /// <summary>
    /// Get a name of page according to specified transitions
    /// </summary>
    /// <param name="clickedElement">Name of element we click on</param>
    /// <returns>Name of new page object (or current if transition doesn't needed)</returns>
    public virtual string GetNextPageName(string clickedElement)
    {
      if (_pageTransitions.ContainsKey(clickedElement.ToLower()))
      {
        return _pageTransitions[clickedElement.ToLower()];
      }
      else
      {
        return GetPageObjectName();
      }
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

      if(isPageChanged)
      {
        _pageObjectManager.CurrentPageName = GetNextPageName(elementName);
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
      _pageObjectManager.CurrentPageName = GetPageObjectName();
    }
  }
}
