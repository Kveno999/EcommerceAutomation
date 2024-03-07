using EcommerceAutomation.Elements.Interfaces;

namespace EcommerceAutomation.Pages;

public class ProductPage : WebPage<ProductPage>
{
    private ITextBox ProductTitle =>
        ElementFactory.GetTextBox(By.XPath("//div[@class='entry-content content-title ']"));

    public bool? IsProductTitleVisible()
    {
        return ProductTitle.Displayed;
    }
}