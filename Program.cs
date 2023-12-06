namespace Pzl.Cli;

public class Program
{
    static void Main(string[] args)
    {
        var program = new PuzzleProgram(OptionsReader.Read());

        program.Run(args);
    }
}