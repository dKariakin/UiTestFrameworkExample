using OpenQA.Selenium;

namespace Drivers.Builder
{
  public interface IDriverBuilder
  {
    void SetPageLoadStrategy(PageLoadStrategy strategy);
    void SetUnhandledPromptBehavior(UnhandledPromptBehavior behavior);
    void SetAcceptInsecureCertificates(bool isAccept);
    void SetProxy(Proxy proxy);
    void SetArguments(string[] arguments);
    void SetPlatformName(string platformName);
    void SetBrowserVersion(string browserVersion);

    IWebDriver GetWebDriver();
  }
}
