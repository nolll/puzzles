namespace Puzzles.common.Computers.IntCode;

public class ConsoleComputer : IntCodeComputer
{
    public ConsoleComputer(string input) : base(input, ReadInput, WriteOutput)
    {
    }

    private static long ReadInput()
    {
        Console.Write("Enter the ID of the system: ");
        var str = Console.ReadLine() ?? "";
        return int.Parse(str);
    }

    private static bool WriteOutput(long output)
    {
        Console.WriteLine(output);
        return true;
    }
}