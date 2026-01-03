using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace TestProject1.Core
{
    public class DriverFactory
    {
        public static WindowsDriver<WindowsElement> CreateDriver(string applicationPath, string winAppDriverUrl)
        {
            var options = new AppiumOptions();
            options.AddAdditionalCapability("app", applicationPath);
            options.AddAdditionalCapability("platformName", "Windows");
            options.AddAdditionalCapability("deviceName", "WindowsPC");
            options.AddAdditionalCapability("automationName", "Windows");

            var driver = new WindowsDriver<WindowsElement>(new Uri(winAppDriverUrl), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return driver;
        }
    }
}
