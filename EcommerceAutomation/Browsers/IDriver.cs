using EcommerceAutomation.Elements.Interfaces;

namespace EcommerceAutomation.Browsers;

public interface IDriver
{
    public string? Url { get; }
    public void Start(Browser browser);
    public void Refresh();
    public void Quit();
    public void GoToUrl(string? url);
    public bool ComponentExists(IElement component);
    public void ExecuteScript(string script, params object[] args);
    public void DeleteAllCookies();
    public void WaitForAjax();
}