using EcommerceAutomation.Pages;

namespace EcommerceAutomation.tests;

public class ProductSearchTests : BaseTest
{
    [Test]
    public void Test1()
    {
        HomePage.Instance.SearchProduct("Pad");
    }
}