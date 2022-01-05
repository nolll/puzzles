using System.Collections.Generic;

namespace Core.Puzzles.Year2018.Day01;

public class FrequencyRepeatPuzzle
{
    public int? FirstRepeatedFrequency { get; }

    public FrequencyRepeatPuzzle(string input)
    {
        var changes = FrequencyChangeListReader.Read(input);
        FirstRepeatedFrequency = GetFirstRepeat(changes);
    }

    private static int? GetFirstRepeat(List<int> changes)
    {
        var sum = 0;
        var uniqueResults = new List<int> { sum };
        int? firstRepeat = null;
        while (firstRepeat == null)
        {
            foreach (var change in changes)
            {
                sum += change;
                if (uniqueResults.Contains(sum))
                {
                    firstRepeat = sum;
                    break;
                }
                uniqueResults.Add(sum);
            }
        }
        return firstRepeat;
    }
}