using Microsoft.Extensions.Configuration;

namespace Pzl.Client;

public class Program
{
    static void Main(string[] args)
    {
        var program = new PuzzleProgram(ReadOptions());

        program.Run(args);
    }

    private static Options ReadOptions()
    {
        var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, false);
        var configuration = configurationBuilder.Build();

        return new Options(
            configuration["hashSeed"],
            configuration["timeoutSeconds"],
            configuration["debugTags"]);
    }
}