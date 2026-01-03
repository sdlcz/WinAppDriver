using OpenQA.Selenium;

namespace TestProject1.Pages
{
    public class CalculatorPage : BasePage
    {
        // Calculator UI Element Locators
        private By ClearButton = By.Name("Clear");
        private By ResultDisplay = By.Name("Display");
        
        // Number buttons (0-9)
        private By GetNumberButton(int number) => By.Name(number.ToString());
        
        // Operation buttons
        private By AddButton = By.Name("Plus");
        private By SubtractButton = By.Name("Minus");
        private By MultiplyButton = By.Name("Multiply");
        private By DivideButton = By.Name("Divide");
        private By EqualsButton = By.Name("Equals");
        private By DecimalButton = By.Name("Decimal separator");

        public CalculatorPage() : base()
        {
        }

        public string GetWindowTitle()
        {
            return Driver.Title;
        }

        public void ClickNumber(int number)
        {
            if (number < 0 || number > 9)
            {
                throw new ArgumentException("Number must be between 0 and 9");
            }
            Click(GetNumberButton(number));
        }

        public void ClickAdd()
        {
            Click(AddButton);
        }

        public void ClickSubtract()
        {
            Click(SubtractButton);
        }

        public void ClickMultiply()
        {
            Click(MultiplyButton);
        }

        public void ClickDivide()
        {
            Click(DivideButton);
        }

        public void ClickEquals()
        {
            Click(EqualsButton);
        }

        public void ClickDecimal()
        {
            Click(DecimalButton);
        }

        public void ClickClear()
        {
            Click(ClearButton);
        }

        public string GetDisplayValue()
        {
            return GetAttribute(ResultDisplay, "Value") ?? string.Empty;
        }

        public void PerformAddition(int firstNumber, int secondNumber)
        {
            ClickNumber(firstNumber);
            ClickAdd();
            ClickNumber(secondNumber);
            ClickEquals();
        }

        public void PerformSubtraction(int firstNumber, int secondNumber)
        {
            ClickNumber(firstNumber);
            ClickSubtract();
            ClickNumber(secondNumber);
            ClickEquals();
        }

        public void PerformMultiplication(int firstNumber, int secondNumber)
        {
            ClickNumber(firstNumber);
            ClickMultiply();
            ClickNumber(secondNumber);
            ClickEquals();
        }

        public void PerformDivision(int firstNumber, int secondNumber)
        {
            ClickNumber(firstNumber);
            ClickDivide();
            ClickNumber(secondNumber);
            ClickEquals();
        }
    }
}
