namespace EcommerceAutomation.Elements.Interfaces;

public interface IElementFactory
{
    public IElement GetElement(By locator);
    public List<IElement> GetElements(By locator);
    public ITextBox GetTextBox(By locator);
}