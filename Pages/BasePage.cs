using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;

namespace TestProject1.Pages
{
    public abstract class BasePage
    {
        protected WindowsDriver<WindowsElement> Driver { get; private set; }
        private const int DefaultWaitTimeoutSeconds = 10;

        protected BasePage()
        {
            Driver = Core.DriverManager.GetDriver();
        }

        protected IWebElement FindElement(By locator)
        {
            return Driver.FindElement(locator);
        }

        protected IList<IWebElement> FindElements(By locator)
        {
            return Driver.FindElements(locator);
        }

        protected void Click(By locator)
        {
            FindElement(locator).Click();
        }

        protected void SendKeys(By locator, string text)
        {
            var element = FindElement(locator);
            element.Clear();
            element.SendKeys(text);
        }

        protected void SendKeysWithoutClear(By locator, string text)
        {
            FindElement(locator).SendKeys(text);
        }

        protected string GetText(By locator)
        {
            return FindElement(locator).Text;
        }

        protected string GetElementText(IWebElement element)
        {
            return element.Text;
        }

        protected string GetAttribute(By locator, string attributeName)
        {
            return FindElement(locator).GetAttribute(attributeName);
        }

        protected void WaitForElement(By locator, int timeoutSeconds = DefaultWaitTimeoutSeconds)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(driver => driver.FindElement(locator));
        }

        protected void WaitForElementToBeClickable(By locator, int timeoutSeconds = DefaultWaitTimeoutSeconds)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(driver => 
            {
                var element = driver.FindElement(locator);
                return element.Displayed && element.Enabled;
            });
        }

        protected string GetWindowTitle()
        {
            return Driver.Title;
        }
    }
}
