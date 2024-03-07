namespace EcommerceAutomation.Elements.Interfaces;

public interface IElement
{
    public By By { get; }
    public IWebElement WrappedElement { get; }
    public string? Text { get; }
    public bool? Enabled { get; }
    public bool? Displayed { get; }
    public void Click(bool waitToBeClickable = false);
    public string? GetAttribute(string attributeName);
    public void Hover();
    public IElement FindComponent(By locator);
    public List<IElement> FindComponents(By locator);
}