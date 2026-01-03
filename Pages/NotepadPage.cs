using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TestProject1.Pages
{
    public class NotepadPage : BasePage
    {
        // Notepad UI Element Locators
        private By TextEditorLocator = By.ClassName("Edit");
        private By CloseButtonLocator = By.Name("Close");
        private By DontSaveButtonLocator = By.Name("Don't Save");
        private By NotepadWindowLocator = By.ClassName("Notepad");

        public NotepadPage() : base()
        {
        }

        public string GetWindowTitle()
        {
            return Driver.Title;
        }

        public IWebElement GetTextBox()
        {
            return FindElement(TextEditorLocator);
        }

        public void TypeText(string text)
        {
            SendKeysWithoutClear(TextEditorLocator, text);
        }

        public void TypeTextWithClear(string text)
        {
            SendKeys(TextEditorLocator, text);
        }

        public string GetTextContent()
        {
            return GetText(TextEditorLocator);
        }

        public void PressEnter()
        {
            SendKeysWithoutClear(TextEditorLocator, Keys.Enter);
        }

        public void SelectAll()
        {
            var element = GetTextBox();
            var actions = new Actions(Driver);
            actions.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
        }

        public void Copy()
        {
            var actions = new Actions(Driver);
            actions.KeyDown(Keys.Control).SendKeys("c").KeyUp(Keys.Control).Perform();
        }

        public void Paste()
        {
            var actions = new Actions(Driver);
            actions.KeyDown(Keys.Control).SendKeys("v").KeyUp(Keys.Control).Perform();
        }

        public void Delete()
        {
            SendKeysWithoutClear(TextEditorLocator, Keys.Delete);
        }

        public void Undo()
        {
            var actions = new Actions(Driver);
            actions.KeyDown(Keys.Control).SendKeys("z").KeyUp(Keys.Control).Perform();
        }

        public void MoveToEnd()
        {
            var actions = new Actions(Driver);
            actions.KeyDown(Keys.Control).SendKeys(Keys.End).KeyUp(Keys.Control).Perform();
        }

        public void MoveToStart()
        {
            var actions = new Actions(Driver);
            actions.KeyDown(Keys.Control).SendKeys(Keys.Home).KeyUp(Keys.Control).Perform();
        }

        public void Close()
        {
            Click(CloseButtonLocator);
        }

        public void ClickDontSave()
        {
            Click(DontSaveButtonLocator);
        }

        public void CloseWithoutSaving()
        {
            Close();
            ClickDontSave();
        }

        public IWebElement GetNotepadWindow()
        {
            return FindElement(NotepadWindowLocator);
        }

        public string GetNotepadWindowName()
        {
            return GetAttribute(NotepadWindowLocator, "Name");
        }

        public bool IsWindowOpen()
        {
            try
            {
                var title = GetWindowTitle();
                return title.Contains("Notepad");
            }
            catch
            {
                return false;
            }
        }
    }
}
