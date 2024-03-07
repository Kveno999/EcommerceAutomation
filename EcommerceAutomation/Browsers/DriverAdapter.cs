using System.Collections.ObjectModel;
using EcommerceAutomation.Elements.Interfaces;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace EcommerceAutomation.Browsers;

public class DriverAdapter : IDriver
{
    private static readonly Lazy<DriverAdapter> _instance = new(() => new DriverAdapter());

    private IWebDriver? _webDriver;
    private WebDriverWait? _webDriverWait;
    public static DriverAdapter Instance => _instance.Value;
    public string? Url => _webDriver?.Url;

    public void Start(Browser browser)
    {
        switch (browser)
        {
            case Browser.Chrome:
                new DriverManager().SetUpDriver(new ChromeConfig());
                _webDriver = new ChromeDriver();
                break;
            case Browser.Firefox:
                new DriverManager().SetUpDriver(new FirefoxConfig());
                _webDriver = new FirefoxDriver();
                break;
            case Browser.Edge:
                new DriverManager().SetUpDriver(new EdgeConfig());
                _webDriver = new EdgeDriver();
                break;
            case Browser.Safari:
                _webDriver = new SafariDriver();
                break;
            case Browser.InternetExplorer:
                new DriverManager().SetUpDriver(new InternetExplorerConfig());
                _webDriver = new InternetExplorerDriver();
                break;
            case Browser.Opera:
            default:
                throw new ArgumentOutOfRangeException(nameof(browser), browser, null);
        }

        _webDriver.Manage().Window.Maximize();
        _webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
    }

    public void Quit()
    {
        _webDriver?.Quit();
    }

    public void GoToUrl(string? url)
    {
        _webDriver?.Navigate().GoToUrl(url);
    }

    public void Refresh()
    {
        _webDriver?.Navigate().Refresh();
    }

    public bool ComponentExists(IElement component)
    {
        try
        {
            _webDriver?.FindElement(component.By);

            return true;
        }
        catch
        {
            return false;
        }
    }

    public void DeleteAllCookies()
    {
        _webDriver?.Manage().Cookies.DeleteAllCookies();
    }

    public void ExecuteScript(string script, params object[] args)
    {
        ((IJavaScriptExecutor)_webDriver!)?.ExecuteScript(script, args);
    }

    public void WaitForAjax()
    {
        _webDriverWait?.Until(driver =>
        {
            const string script = "return window.jQuery != undefined && jQuery.active == 0";
            return (bool)((IJavaScriptExecutor)driver).ExecuteScript(script);
        });
    }

    public IWebDriver? GetNativeDriver()
    {
        return _webDriver;
    }

    public IWebElement? WaitForElement(By locator)
    {
        return _webDriverWait?.Until(ExpectedConditions.ElementExists(locator));
    }

    public ReadOnlyCollection<IWebElement>? WaitForElements(By locator)
    {
        return _webDriverWait?.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
    }

    public void ScrollIntoView(IElement element)
    {
        ExecuteScript("arguments[0].scrollIntoView(true);", element.WrappedElement);
    }

    public void HighlightElement(IElement element)
    {
        try
        {
            const string script = """
                                  
                                                  let defaultBG = arguments[0].style.backgroundColor;
                                                  let defaultOutline = arguments[0].style.outline;
                                                  arguments[0].style.backgroundColor = '#FDFF47';
                                                  arguments[0].style.outline = '#f00 solid 2px';
                                  
                                                  setTimeout(function()
                                                  {
                                                      arguments[0].style.backgroundColor = defaultBG;
                                                      arguments[0].style.outline = defaultOutline;
                                                  }, 500);
                                  """;

            ExecuteScript(script, element.WrappedElement);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}