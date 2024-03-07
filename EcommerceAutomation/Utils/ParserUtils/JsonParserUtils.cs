using System.Text.Json;

namespace EcommerceAutomation.utils.ParserUtils;

public static class JsonParserUtils
{
    public static async Task<T?> DeserializeAsync<T>(string path)
    {
        var currentDirectory =
            Directory.GetParent(@"../../../")?.FullName + Path.DirectorySeparatorChar + path;
        await using var openSteam = File.OpenRead(currentDirectory);
        return await JsonSerializer.DeserializeAsync<T>(openSteam);
    }
}