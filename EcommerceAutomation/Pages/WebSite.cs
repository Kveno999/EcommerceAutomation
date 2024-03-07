using EcommerceAutomation.Singletons;

namespace EcommerceAutomation.Pages;

public class WebSite : ThreadSafeLazyBaseSingleton<WebSite>
{
    public HomePage HomePage => HomePage.Instance;
}