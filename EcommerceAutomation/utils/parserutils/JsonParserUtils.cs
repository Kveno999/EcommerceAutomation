using System.Text.Json;

namespace EcommerceAutomation.utils.parserutils;

public static class JsonParserUtils
{
    public static async Task<T?> Deserialize<T>(string path)
    {
        var currentDirectory =
            Directory.GetParent(@"../../../")?.FullName + Path.DirectorySeparatorChar + path;
        await using var openSteam = File.OpenRead(currentDirectory);
        return await JsonSerializer.DeserializeAsync<T>(openSteam);
    }
}