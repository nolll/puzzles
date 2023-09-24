namespace Aoc.Puzzles.Aoc2020.Aoc202008;

public class GameConsoleInstruction
{
    public string Name { get; }
    public int Value { get; }
    public int ExecutionCount { get; private set; }

    public GameConsoleInstruction(string name, int value)
    {
        Name = name;
        Value = value;
    }

    public static GameConsoleInstruction Parse(string s)
    {
        var parts = s.Split(' ');
        var name = parts[0];
        var value = int.Parse(parts[1]);
        return new GameConsoleInstruction(name, value);
    }

    public void IncreaseExecutionCount()
    {
        ExecutionCount += 1;
    }
}