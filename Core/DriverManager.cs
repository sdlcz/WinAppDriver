using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using TestProject1.Configuration;

namespace TestProject1.Core
{
    public static class DriverManager
    {
        private static WindowsDriver<WindowsElement>? _driver;

        public static WindowsDriver<WindowsElement> GetDriver()
        {
            if (_driver == null)
            {
                throw new InvalidOperationException(
                    "Driver has not been initialized. " +
                    "Call DriverManager.InitializeDriver(appPath) first.");
            }
            return _driver;
        }

        /// <param name="applicationPath">Full path to the application to test</param>
        /// <param name="winAppDriverUrl">WinAppDriver service URL (uses ApplicationSettings default if null)</param>
        public static void InitializeDriver(string applicationPath, string? winAppDriverUrl = null)
        {
            if (_driver != null)
            {
                Console.WriteLine("Driver already initialized. Quitting existing driver...");
                QuitDriver();
            }

            // Use ApplicationSettings default if not specified
            winAppDriverUrl ??= ApplicationSettings.WinAppDriverUrl;

            var appName = Path.GetFileName(applicationPath);
            Console.WriteLine($"Initializing driver for: {appName}");

            _driver = DriverFactory.CreateDriver(applicationPath, winAppDriverUrl);
            Console.WriteLine($"Driver initialized successfully for {appName}");
        }

        /// <summary>
        /// Quits the current driver instance and releases resources.
        /// Safe to call multiple times - idempotent operation.
        /// </summary>
        public static void QuitDriver()
        {
            if (_driver == null) return;

            try
            {
                Console.WriteLine("Quitting driver...");
                _driver.Quit();
                Console.WriteLine("Driver quit successfully");
            }
            catch (WebDriverException ex)
            {
                Console.WriteLine($"Driver quit warning (expected if already closed): {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error during driver cleanup: {ex.Message}");
                throw;
            }
            finally
            {
                _driver?.Dispose();
                _driver = null;
            }
        }

        public static bool IsDriverInitialized => _driver != null;

        public static void Reset()
        {
            QuitDriver();
            _driver = null;
            Console.WriteLine("↻ Driver state reset");
        }
    }
}
