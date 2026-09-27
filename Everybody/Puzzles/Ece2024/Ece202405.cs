using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2024;

[Name("Pseudo-Random Clap Dance")]
public class Ece202405 : EverybodyEventPuzzle
{
    [Puzzle("950b4825d76ba062befffe8cb9a0be2c")]
    public string Part1(string input) => SolvePart1(input, 10);
    
    [Puzzle("6b4db5dbf70faa6e08d4a645d6d2b4cc")]
    public long Part2(string input) => SolvePart2(input, 2024);
    
    [Puzzle("5789564a5b01f519e8eddcfc0f7aa6a2")]
    public long Part3(string input) => ParseDance(input).DanceForever();

    public string SolvePart1(string input, int rounds) => ParseDance(input).DanceRounds(rounds);
    public long SolvePart2(string input, int target) => ParseDance(input).DanceUntilRepeatCount(target);

    private static ClapDance ParseDance(string input)
    {
        var columns = new List<List<int>>();
        var rows = input.Split(LineBreaks.Single);
        foreach (var row in rows)
        {
            var nums = row.Split(' ').Select(int.Parse).ToList();
            for (var i = 0; i < nums.Count; i++)
            {
                if(columns.Count <= i)
                    columns.Add([]);
                columns[i].Add(nums[i]);
            }
        }

        return new ClapDance(columns);
    }

    public class ClapDance(List<List<int>> columns)
    {
        public string DanceRounds(int rounds)
        {
            var shout = "";

            for (var round = 1; round <= rounds; round++)
            {
                shout = Dance(round);
            }

            return shout;
        }

        public long DanceUntilRepeatCount(int target)
        {
            var counter = new Dictionary<string, int>();
            var round = 1;

            while (true)
            {
                var shout = Dance(round);
                if (!counter.TryAdd(shout, 1))
                    counter[shout]++;

                if (counter[shout] == target)
                {
                    return long.Parse(shout) * round;
                }

                round++;
            }
        }

        public long DanceForever()
        {
            var round = 1;

            var set = new HashSet<(int, string)>();
            var highest = 0L;
            while (true)
            {
                var shout = long.Parse(Dance(round));

                var state = (round % columns.Count, ToString());
                if (shout > highest)
                    highest = shout;

                if (set.Contains(state))
                    return highest;

                set.Add(state);

                round++;
            }
        }

        private string Dance(int round)
        {
            var clapperCol = (round - 1) % columns.Count;
            var danceCol = (clapperCol + 1) % columns.Count;
            var clapper = columns[clapperCol][0];
            columns[clapperCol].RemoveAt(0);
            var direction = 1;
            var dancerIndex = -1;
            for (var i = 0; i < clapper; i++)
            {
                dancerIndex += direction;

                if (dancerIndex >= columns[danceCol].Count || dancerIndex < 0)
                {
                    direction *= -1;
                    dancerIndex += direction;
                }
            }

            var insertIndex = direction > 0 ? dancerIndex : dancerIndex + 1;
            if (insertIndex > columns[danceCol].Count)
                columns[danceCol].Add(clapper);
            else
                columns[danceCol].Insert(insertIndex, clapper);

            return string.Join("", columns.Select(o => o.First()));
        }

        public override string ToString() => string.Join("|", columns.Select(o => string.Join(",", o)));
    }
}