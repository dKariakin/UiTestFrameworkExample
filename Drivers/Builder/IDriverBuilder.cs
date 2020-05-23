using OpenQA.Selenium;

namespace Drivers.Builder
{
  public interface IDriverBuilder
  {
    // add more settings
    void SetPageLoadStrategy(PageLoadStrategy strategy);
    void SetUnhandledPromptBehavior(UnhandledPromptBehavior behavior);
    void SetAcceptInsecureCertificates(bool isAccept);
    void SetProxy(Proxy proxy);
    void SetBinaryLocation(string location);
    void SetArguments(string[] arguments);

    IWebDriver GetWebDriver();
  }
}
