using Pzl.Client;

EnvReader.Read();

var inputLocation = Environment.GetEnvironmentVariable("INPUT_LOCATION");
if (string.IsNullOrEmpty(inputLocation))
{
    Console.WriteLine("Error: INPUT_LOCATION is not set in .env");
    return;
}

var options = new Options(
    Environment.GetEnvironmentVariable("HASH_SEED"),
    Environment.GetEnvironmentVariable("TIMEOUT_SECONDS"),
    Environment.GetEnvironmentVariable("DEBUG_TAGS"),
    inputLocation);

new PuzzleProgram(options).Run(args);