using EcommerceAutomation.Browsers;
using EcommerceAutomation.Elements.Interfaces;

namespace EcommerceAutomation.Elements;

public class ElementFactory : IElementFactory
{
    private static readonly Lazy<ElementFactory> _instance = new(() => new ElementFactory());

    private readonly IWebDriver? _webDriver = DriverAdapter.Instance.GetNativeDriver();
    public static ElementFactory Instance => _instance.Value;

    public IElement GetElement(By locator)
    {
        var nativeWebElement = DriverAdapter.Instance.WaitForElement(locator);
        IElement element = new ElementAdapter(_webDriver, nativeWebElement!, locator);

        DriverAdapter.Instance.ScrollIntoView(element);
        DriverAdapter.Instance.HighlightElement(element);
        return element;
    }

    public List<IElement> GetElements(By locator)
    {
        var nativeWebElements = DriverAdapter.Instance.WaitForElements(locator);
        return nativeWebElements!.Select(nativeWebElement => new ElementAdapter(_webDriver, nativeWebElement, locator))
            .Cast<IElement>().ToList();
    }

    public ITextBox GetTextBox(By locator)
    {
        var nativeWebElement = DriverAdapter.Instance.WaitForElement(locator);
        ITextBox element = new TextBoxAdapter(_webDriver, nativeWebElement!, locator);

        DriverAdapter.Instance.ScrollIntoView(element);
        DriverAdapter.Instance.HighlightElement(element);
        return element;
    }
}