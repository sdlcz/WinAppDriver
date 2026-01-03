using OpenQA.Selenium.Appium.Windows;

namespace TestProject1.Core
{
    public class DriverManager : IDisposable
    {
        private static WindowsDriver<WindowsElement>? _driver;

        public static WindowsDriver<WindowsElement> GetDriver()
        {
            if (_driver == null)
            {
                throw new InvalidOperationException("Driver has not been initialized. Call InitializeDriver() first.");
            }
            return _driver;
        }

        public static void InitializeDriver(string applicationPath, string winAppDriverUrl = "http://127.0.0.1:4723")
        {
            _driver = DriverFactory.CreateDriver(applicationPath, winAppDriverUrl);
        }

        public static void QuitDriver()
        {
            if (_driver != null)
            {
                try
                {
                    _driver.Quit();
                }
                catch (Exception)
                {
                    // Driver already closed
                }
                finally
                {
                    _driver?.Dispose();
                    _driver = null;
                }
            }
        }

        public void Dispose()
        {
            QuitDriver();
        }
    }
}
