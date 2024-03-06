using EcommerceAutomation.models;
using EcommerceAutomation.utils.parserutils;
using OpenQA.Selenium.Chrome;

namespace EcommerceAutomation.tests;

public class BaseTest
{
    private readonly Config? _config = JsonParserUtils.Deserialize<Config>("resources/config.json").Result;

    [SetUp]
    public void Setup()
    {
        var driver = new ChromeDriver();
        driver.Url = _config?.Url;
    }
    
}