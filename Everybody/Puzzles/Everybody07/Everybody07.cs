using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Everybody07;

[Name("Not Fast but Furious")]
public class Everybody07(string[] inputs) : EverybodyPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var result = Part1(inputs[0]);
        return new PuzzleResult(result, "05a999b2ab72fff505423f40ee4af56b");
    }

    protected override PuzzleResult RunPart2()
    {
        return PuzzleResult.Empty;
    }

    protected override PuzzleResult RunPart3()
    {
        return PuzzleResult.Empty;
    }

    public static string Part1(string input)
    {
        const int initialPower = 10;
        const int trackLength = 10;
        
        var lines = input.Split(LineBreaks.Single);
        var tracks = new List<Track>();
        foreach (var line in lines)
        {
            var parts = line.Split(':');
            var track = new Track
            {
                Name = parts[0]
            };
            var actions = parts[1].Split(',').ToArray();
            var actionCount = actions.Length;
            var power = initialPower;
            for (var i = 0; i < trackLength; i++)
            {
                var action = actions[i % actionCount];
                if (action == "+")
                    power++;
                else if (action == "-")
                    power = Math.Max(0, power - 1);
                
                track.Score += power;
            }
            
            tracks.Add(track);
        }

        return string.Join("", tracks.OrderByDescending(o => o.Score).Select(o => o.Name));
    }

    private class Track
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }
}