using EcommerceAutomation.Elements;
using EcommerceAutomation.Singletons;

namespace EcommerceAutomation.Pages;

public class WebPage<TPage> : ThreadSafeLazyBaseSingleton<TPage>
    where TPage : new()
{
    protected readonly ElementFactory ElementFactory = ElementFactory.Instance;
}