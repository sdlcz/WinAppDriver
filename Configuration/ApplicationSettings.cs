namespace TestProject1.Configuration
{
    public static class ApplicationSettings
    {
        
        public const string CalculatorPath = "C:\\Windows\\System32\\calc.exe";
        public const string NotepadPath = "C:\\Windows\\notepad.exe";
        
        public const string WinAppDriverUrl = "http://127.0.0.1:4723";
        public const string WinAppDriverHost = "127.0.0.1";
        public const int WinAppDriverPort = 4723;
        
        public const int DefaultTimeoutSeconds = 10;
        public const int LongTimeoutSeconds = 30;
        public const int ShortTimeoutSeconds = 5;
        
        // Driver Configuration
        public const string PlatformName = "Windows";
        public const string DeviceName = "WindowsPC";
        public const string AutomationName = "Windows";
        
        public const int MaxRetryAttempts = 3;
        public const int RetryDelayMilliseconds = 1000;
        
        // Test Execution Configuration
        public const bool TakeScreenshotOnFailure = true;
        public const string ScreenshotPath = "bin/Debug/net8.0/Screenshots";
        public const bool HighlightElements = false;
        
        public static string GetEnvironment()
        {
            return Environment.GetEnvironmentVariable("TEST_ENVIRONMENT") ?? "Local";
        }
        
        public static bool IsWindows11OrLater()
        {
            var osVersion = Environment.OSVersion.Version;
            return osVersion.Major >= 10 && osVersion.Build >= 22000;
        }
    }
}
