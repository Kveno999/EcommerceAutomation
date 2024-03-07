using EcommerceAutomation.Elements.Interfaces;

namespace EcommerceAutomation.Pages;

public class HomePage : WebPage<HomePage>
{
    private ITextBox SearchInput => ElementFactory.GetTextBox(By.XPath("//input[@name='search']"));

    public void SearchProduct(string searchText)
    {
        SearchInput.TypeText(searchText);
    }
}