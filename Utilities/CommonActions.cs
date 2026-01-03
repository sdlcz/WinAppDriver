using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Appium.Windows;

namespace TestProject1.Utilities
{
    public static class CommonActions
    {
        public static void SelectAllText(WindowsDriver<WindowsElement> driver)
        {
            var actions = new Actions(driver);
            actions.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
        }

        public static void CopyText(WindowsDriver<WindowsElement> driver)
        {
            var actions = new Actions(driver);
            actions.KeyDown(Keys.Control).SendKeys("c").KeyUp(Keys.Control).Perform();
        }

        public static void PasteText(WindowsDriver<WindowsElement> driver)
        {
            var actions = new Actions(driver);
            actions.KeyDown(Keys.Control).SendKeys("v").KeyUp(Keys.Control).Perform();
        }

        public static void UndoAction(WindowsDriver<WindowsElement> driver)
        {
            var actions = new Actions(driver);
            actions.KeyDown(Keys.Control).SendKeys("z").KeyUp(Keys.Control).Perform();
        }

        public static void DeleteText(WindowsDriver<WindowsElement> driver)
        {
            var actions = new Actions(driver);
            actions.SendKeys(Keys.Delete).Perform();
        }

        public static void MoveToEndOfLine(WindowsDriver<WindowsElement> driver)
        {
            var actions = new Actions(driver);
            actions.KeyDown(Keys.Control).SendKeys(Keys.End).KeyUp(Keys.Control).Perform();
        }

        public static void WaitSeconds(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }
    }
}
