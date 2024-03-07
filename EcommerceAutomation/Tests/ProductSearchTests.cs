using EcommerceAutomation.models;
using EcommerceAutomation.Pages;
using EcommerceAutomation.utils.ParserUtils;

namespace EcommerceAutomation.tests;

public class ProductSearchTests : BaseTest
{
    private static readonly Product[]? Products = JsonParserUtils.DeserializeAsync<Product[]>("resources/Products.json").Result;
    
    [Test]
    public void TestProductShouldBeSearched()
    {
        var exceptedProduct = Products?[0];
        HomePage.Instance.SearchForm.SearchProduct(exceptedProduct?.Name!);
        HomePage.Instance.SearchForm.SelectProductFromAutocomplete(exceptedProduct?.Id);
        var isProductDisplayed = ProductPage.Instance.IsProductTitleVisible();

        Assert.That(isProductDisplayed, Is.True);
    }
}