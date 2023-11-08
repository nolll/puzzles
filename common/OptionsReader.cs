using Microsoft.Extensions.Configuration;

namespace Common;

public static class OptionsReader
{
    public static Options Read()
    {
        var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
        var configuration = configurationBuilder.Build();

        return new Options(
            configuration["hashSeed"],
            configuration["timeoutSeconds"],
            configuration["debugPuzzle"]);
    }
}