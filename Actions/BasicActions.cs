using Extensions.Pages.Base;
using OpenQA.Selenium;

namespace Actions
{
  public class BasicActions : PagePrototype, IPagePrototype, IBasicActions
  {
    protected static IWebDriver _webDriver;

    public BasicActions(IWebDriver webDriver) : base(webDriver)
    {
      _webDriver = webDriver;
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

    public void OpenPage()
    {
      _webDriver.Navigate().GoToUrl(GetPageUrl());
    }
  }
}
