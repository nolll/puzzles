using Microsoft.Extensions.Configuration;
using Pzl.Client;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", true, false)
    .Build();

var inputLocation = configuration["inputLocation"];
if (string.IsNullOrEmpty(inputLocation))
{
    Console.WriteLine("Error: inputLocation is not set in appsettings.json");
    return;
}

var options = new Options(
    configuration["hashSeed"],
    configuration["timeoutSeconds"],
    configuration["debugTags"],
    inputLocation);

new PuzzleProgram(options).Run(args);
