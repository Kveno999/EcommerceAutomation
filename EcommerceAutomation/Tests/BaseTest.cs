using EcommerceAutomation.Browsers;
using EcommerceAutomation.models;
using EcommerceAutomation.utils.ParserUtils;

namespace EcommerceAutomation.tests;

public class BaseTest
{
    private readonly Config? _config = JsonParserUtils.DeserializeAsync<Config>("resources/config.json").Result;

    [SetUp]
    public void Setup()
    {
        DriverAdapter.Instance.Start(Browser.Chrome);
        DriverAdapter.Instance.GoToUrl(_config?.Url);
    }

    [TearDown]
    protected void TearDown()
    {
        DriverAdapter.Instance.Quit();
    }
}