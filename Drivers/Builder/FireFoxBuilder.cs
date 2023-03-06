using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Drivers.Builder
{
  public class FireFoxBuilder : IDriverBuilder
  {
    private readonly FirefoxOptions _options;
    private static FirefoxDriver _driver;

    public FireFoxBuilder()
    {
      string driverName = "FirefoxDriver";

      _options = new FirefoxOptions();

      SetArguments(WebDriverConfigManager.GetDriverArgument(driverName));
      SetBrowserVersion(WebDriverConfigManager.GetDriverConfiguration(driverName, WebDriverConfigParameters.BrowserVersion));
      SetPlatformName(WebDriverConfigManager.GetDriverConfiguration(driverName, WebDriverConfigParameters.PlatformName));
    }

    public IWebDriver GetWebDriver()
    {
      _driver ??= new FirefoxDriver(WebDriverConfigManager.GetDriverBinaryLocation(), _options);

      return _driver;
    }

    public void SetAcceptInsecureCertificates(bool isAccept)
    {
      _options.AcceptInsecureCertificates = isAccept;
    }

    public void SetBrowserVersion(string browserVersion)
    {
      _options.BrowserVersion = browserVersion;
    }

    public void SetPlatformName(string platformName)
    {
      _options.PlatformName = platformName;
    }

    public void SetArguments(string[] arguments)
    {
      _options.AddArguments(arguments);
    }

    public void SetPageLoadStrategy(PageLoadStrategy strategy)
    {
      _options.PageLoadStrategy = strategy;
    }

    public void SetProxy(Proxy proxy)
    {
      _options.Proxy = proxy;
    }

    public void SetUnhandledPromptBehavior(UnhandledPromptBehavior behavior)
    {
      _options.UnhandledPromptBehavior = behavior;
    }
  }
}
