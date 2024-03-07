using EcommerceAutomation.Elements.Interfaces;

namespace EcommerceAutomation.Pages.Forms;

public class SearchForm : WebPage<SearchForm>
{
    private ITextBox SearchInput => ElementFactory.GetTextBox(By.XPath("//input[@name='search']"));

    public void SearchProduct(string searchText)
    {
        SearchInput.TypeText(searchText);
    }

    public void SelectProductFromAutocomplete(int? productId)
    {
        var autocompleteItemXPath =
            $"//ul[contains(@class, 'dropdown-menu autocomplete')]/li/div/h4/a[contains(@href, 'product_id={productId}')]";
        var autocompleteItem = ElementFactory.GetElement(By.XPath(autocompleteItemXPath));
        autocompleteItem.Click();
    }
}