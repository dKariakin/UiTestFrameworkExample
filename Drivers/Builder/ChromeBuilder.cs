using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Drivers.Builder
{
  public class ChromeBuilder : IDriverBuilder
  {
    private readonly ChromeOptions _options;
    private static ChromeDriver _driver;

    public ChromeBuilder()
    {
      string driverName = "ChromeDriver";

      _options = new ChromeOptions();

      SetArguments(WebDriverConfigManager.GetDriverArgument(driverName));
      SetBrowserVersion(WebDriverConfigManager.GetDriverConfiguration(driverName, WebDriverConfigParameters.BrowserVersion));
      SetPlatformName(WebDriverConfigManager.GetDriverConfiguration(driverName, WebDriverConfigParameters.PlatformName));
    }

    public IWebDriver GetWebDriver()
    {
      _driver ??= new ChromeDriver(WebDriverConfigManager.GetDriverBinaryLocation(), _options);
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
