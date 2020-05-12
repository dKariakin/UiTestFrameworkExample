using System;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Drivers
{
    public class WebDriverSetup
    {
        private static readonly IWebDriver _webDriver = null;

        public static IWebDriver GetWebDriver(string driverName)
        {
            return _webDriver ?? WebDriverInitialize(driverName);
        }

        public static IWebDriver WebDriverInitialize(string driverName)
        {
            string driverPath = $"{Assembly.GetExecutingAssembly().CodeBase}/WebDriver/";
            switch (driverName)
            {
                case "chrome":
                    ChromeOptions options = new ChromeOptions()
                    {
                        AcceptInsecureCertificates = false
                    };
                    options.AddArgument("start-maximized");
                    return new ChromeDriver(driverPath, options);
                default:
                    throw new NotImplementedException($"{driverName} is an unknown web driver");
            }
        }
    }
}
