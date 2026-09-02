using Microsoft.Extensions.Configuration;
using Pzl.Client;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", true, false)
    .Build();

var options = new Options(
    configuration["hashSeed"],
    configuration["timeoutSeconds"],
    configuration["debugTags"],
    configuration["inputLocation"]);

new PuzzleProgram(options).Run(args);
