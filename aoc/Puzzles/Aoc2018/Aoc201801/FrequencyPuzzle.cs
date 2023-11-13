namespace Puzzles.aoc.Puzzles.Aoc2018.Aoc201801;

public class FrequencyPuzzle
{
    public int ResultingFrequency { get; }

    public FrequencyPuzzle(string input)
    {
        var changes = FrequencyChangeListReader.Read(input);
        ResultingFrequency = changes.Sum();
    }
}