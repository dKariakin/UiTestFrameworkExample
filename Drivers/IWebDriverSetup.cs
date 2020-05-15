using OpenQA.Selenium;

namespace Drivers
{
  public interface IWebDriverSetup
  {
    IWebDriver WebDriverInitialize();
    IWebDriver GetWebDriver();
  }
}
