using Actions;
using Extensions.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Pages.Google
{
  public sealed class GoogleMainPage : BasicActions, IPagePrototype, IBasicActions
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
      SetPageUrl("http://www.google.com");
      SetPageObjectName(PageNames.GoogleMainPage);
      
      SetElements(new (string, IWebElement)[]
      {
        ("search string", SearchString),
        ("search button", SearchButton)
      });
    }
  }
}
