using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Extensions.Pages.Base
{
  public abstract class BasePage : IBasePage
  {
    protected IWebDriver _webDriver;
    protected WebDriverWait _driverWaiter;
    protected Dictionary<string, IWebElement> _elements;
    protected Dictionary<string, IWebElement[]> _collections;
    protected string _pageUrl;
    protected string _pageObjectName;

    public BasePage(IWebDriver webDriver)
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
      _driverWaiter.Until(_ => _elements[elementName].Displayed);
    }

    /// <summary>
    /// Wait until web element in a collection is loaded
    /// </summary>
    /// <param name="collectionName">Name of a collection of elements</param>
    /// <param name="elementOrder">Order of an element we are interested in</param>
    public void ClickCollectionElement(string collectionName, int elementOrder = 0)
    {
      _driverWaiter.Until(_ => _collections[collectionName][elementOrder].Displayed);
      _collections[collectionName][elementOrder - 1].Click();
    }

    public void Click(string elementName)
    {
      Wait(elementName);
      _elements[elementName].Click();
    }

    public void SendText(string elementName, string text)
    {
      Wait(elementName);
      _elements[elementName].SendKeys(text);
    }

    public void OpenPage()
    {
      _webDriver.Navigate().GoToUrl(new Uri(_pageUrl));
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
