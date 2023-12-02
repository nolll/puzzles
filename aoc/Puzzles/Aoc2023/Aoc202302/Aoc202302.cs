using Puzzles.common.Puzzles;

namespace Puzzles.aoc.Puzzles.Aoc2023.Aoc202302;

public class Aoc202302 : AocPuzzle
{
    public override string Name => "Cube Conundrum";

    protected override PuzzleResult RunPart1()
    {
        var result = PlayGames(InputFile);
        return new PuzzleResult(result.ValidGames, "70e2be8af168fc9534f8384b244c60f7");
    }

    protected override PuzzleResult RunPart2()
    {
        var result = PlayGames(InputFile);
        return new PuzzleResult(result.GamePower, "45825cd43460cbc76a940d6eb06ebc6b");
    }

    public static GameResult PlayGames(string input)
    {
        var cubeCounts = new Dictionary<string, int>
        {
            { "red", 12 },
            { "green", 13 },
            { "blue", 14 }
        };

        var gamePowers = new List<int>();
        var validGames = new List<int>();
        var games = input.Split(Environment.NewLine);
        foreach (var line in games)
        {
            var isValid = true;
            var gameParts = line.Split(':').Select(o => o.Trim()).ToList();
            var gameId = int.Parse(gameParts[0].Split(' ')[1]);
            var sets = gameParts[1].Trim().Split(';').Select(o => o.Trim());

            var maxCubeCounts = new Dictionary<string, int>()
            {
                { "red", 0 },
                { "green", 0 },
                { "blue", 0 }
            };

            foreach (var set in sets)
            {
                var cubes = set.Split(',').Select(o => o.Trim());
                foreach (var cube in cubes)
                {
                    var parts = cube.Split(' ').Select(o => o.Trim()).ToList();
                    var count = int.Parse(parts[0]);
                    var color = parts[1];

                    maxCubeCounts[color] = Math.Max(count, maxCubeCounts[color]);

                    if (count > cubeCounts[color])
                        isValid = false;
                }
            }

            var gamePower = maxCubeCounts.Values.Aggregate(1, (a, b) => a * b);
            gamePowers.Add(gamePower);

            if (isValid)
                validGames.Add(gameId);
        }

        return new GameResult(validGames.Sum(), gamePowers.Sum());
    }

    public static int GamePower(string input)
    {
        var gamePowers = new List<int>();
        var games = input.Split(Environment.NewLine);
        foreach (var line in games)
        {
            var gameParts = line.Split(':').Select(o => o.Trim()).ToList();
            var sets = gameParts[1].Trim().Split(';').Select(o => o.Trim());

            var maxCubeCounts = new Dictionary<string, int>()
            {
                { "red", 0 },
                { "green", 0 },
                { "blue", 0 }
            };

            foreach (var set in sets)
            {
                var cubes = set.Split(',').Select(o => o.Trim());
                foreach (var cube in cubes)
                {
                    var parts = cube.Split(' ').Select(o => o.Trim()).ToList();
                    var count = int.Parse(parts[0]);
                    var color = parts[1];

                    maxCubeCounts[color] = Math.Max(count, maxCubeCounts[color]);
                }
            }

            var gamePower = maxCubeCounts.Values.Aggregate(1, (a, b) => a * b);
            gamePowers.Add(gamePower);
        }

        return gamePowers.Sum();
    }

    public record GameResult(int ValidGames, int GamePower);
}