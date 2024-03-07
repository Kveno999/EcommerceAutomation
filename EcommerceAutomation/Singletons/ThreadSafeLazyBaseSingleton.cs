namespace EcommerceAutomation.Singletons;

public abstract class ThreadSafeLazyBaseSingleton<T>
    where T : new()
{
    private static readonly Lazy<T> Lazy = new(() => new T());
    public static T Instance => Lazy.Value;
}