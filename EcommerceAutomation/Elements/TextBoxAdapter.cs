using EcommerceAutomation.Elements.Interfaces;

namespace EcommerceAutomation.Elements;

public class TextBoxAdapter : ElementAdapter, ITextBox
{
    public TextBoxAdapter(IWebDriver? webDriver, IWebElement webElement, By by) : base(webDriver, webElement, by)
    {
    }

    public void TypeText(string text)
    {
        WebElement.Clear();
        WebElement.SendKeys(text);
    }
}