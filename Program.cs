using Microsoft.Extensions.Configuration;

namespace Pzl.Client;

public class Program
{
    static void Main(string[] args) => new PuzzleProgram(ReadOptions()).Run(args);

    private static Options ReadOptions()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, false)
            .Build();

        return new Options(
            configuration["hashSeed"],
            configuration["timeoutSeconds"],
            configuration["debugTags"]);
    }
}