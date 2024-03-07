using EcommerceAutomation.Elements.Interfaces;

namespace EcommerceAutomation.Elements;

public class ElementAdapter : IElement
{
    private readonly Actions _actions;
    private readonly IWebDriver? _webDriver;
    protected readonly IWebElement WebElement;

    public ElementAdapter(IWebDriver? webDriver, IWebElement webElement, By by)
    {
        _webDriver = webDriver;
        _actions = new Actions(_webDriver);
        WebElement = webElement;
        By = by;
        WrappedElement = webElement;
    }

    public By By { get; }

    public string? Text => WebElement?.Text;

    public bool? Enabled => WebElement?.Enabled;

    public bool? Displayed => WebElement?.Displayed;

    public IWebElement WrappedElement { get; }

    public void Click(bool waitToBeClickable = false)
    {
        if (waitToBeClickable) WaitToBeClickable(By);

        WebElement?.Click();
    }

    public string? GetAttribute(string attributeName)
    {
        return WebElement?.GetAttribute(attributeName);
    }


    public void Hover()
    {
        _actions.MoveToElement(WebElement).Perform();
    }

    public IElement FindComponent(By locator)
    {
        var element = _webDriver.FindElement(locator);
        return new ElementAdapter(_webDriver, element, locator);
    }

    public List<IElement> FindComponents(By locator)
    {
        var elements = _webDriver.FindElements(locator);

        return elements.Select(element => new ElementAdapter(_webDriver, element, locator)).Cast<IElement>().ToList();
    }

    private void WaitToBeClickable(By by)
    {
        var webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
        webDriverWait.Until(ExpectedConditions.ElementToBeClickable(by));
    }
}