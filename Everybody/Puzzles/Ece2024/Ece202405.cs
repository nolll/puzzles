using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2024;

[Name("Pseudo-Random Clap Dance")]
public class Ece202405 : EverybodyEventPuzzle
{
    [Puzzle("950b4825d76ba062befffe8cb9a0be2c")]
    public string Part1(string input, int rounds = 10) => DanceRounds(ParseDance(input), rounds);

    [Puzzle("6b4db5dbf70faa6e08d4a645d6d2b4cc")]
    public long Part2(string input) => DanceUntilRepeatCount(ParseDance(input));

    [Puzzle("5789564a5b01f519e8eddcfc0f7aa6a2")]
    public long Part3(string input) => DanceForever(ParseDance(input));

    private string DanceRounds(List<List<int>> list, int rounds)
    {
        var shout = "";

        for (var round = 1; round <= rounds; round++)
        {
            shout = Dance(list, round);
        }

        return shout;
    }

    private long DanceUntilRepeatCount(List<List<int>> list)
    {
        var counter = new Dictionary<string, int>();
        var round = 1;

        while (true)
        {
            var shout = Dance(list, round);
            if (!counter.TryAdd(shout, 1))
                counter[shout]++;

            if (counter[shout] == 2024)
            {
                return long.Parse(shout) * round;
            }

            round++;
        }
    }

    private long DanceForever(List<List<int>> list)
    {
        var round = 1;

        var set = new HashSet<(int, string)>();
        var highest = 0L;
        while (true)
        {
            var shout = long.Parse(Dance(list, round));

            var state = (round % list.Count, ToString(list));
            if (shout > highest)
                highest = shout;

            if (!set.Add(state))
                return highest;

            round++;
        }
    }

    private string Dance(List<List<int>> list, int round)
    {
        var clapperCol = (round - 1) % list.Count;
        var danceCol = (clapperCol + 1) % list.Count;
        var clapper = list[clapperCol][0];
        list[clapperCol].RemoveAt(0);
        var direction = 1;
        var dancerIndex = -1;
        for (var i = 0; i < clapper; i++)
        {
            dancerIndex += direction;

            if (dancerIndex >= list[danceCol].Count || dancerIndex < 0)
            {
                direction *= -1;
                dancerIndex += direction;
            }
        }

        var insertIndex = direction > 0 ? dancerIndex : dancerIndex + 1;
        if (insertIndex > list[danceCol].Count)
            list[danceCol].Add(clapper);
        else
            list[danceCol].Insert(insertIndex, clapper);

        return string.Concat(list.Select(o => o.First()));
    }

    private string ToString(List<List<int>> list) => string.Join("|", list.Select(o => string.Join(",", o)));

    private static List<List<int>> ParseDance(string input)
    {
        var columns = new List<List<int>>();
        var rows = input.Split(LineBreaks.Single);
        foreach (var row in rows)
        {
            var nums = row.Split(' ').Select(int.Parse).ToList();
            for (var i = 0; i < nums.Count; i++)
            {
                if (columns.Count <= i)
                    columns.Add([]);
                columns[i].Add(nums[i]);
            }
        }

        return columns;
    }
}