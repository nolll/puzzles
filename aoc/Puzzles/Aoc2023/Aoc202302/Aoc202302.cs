using Puzzles.Common.Puzzles;
using Puzzles.Common.Strings;

namespace Puzzles.Aoc.Puzzles.Aoc2023.Aoc202302;

public class Aoc202302 : AocPuzzle
{
    public override string Name => "Cube Conundrum";

    private static readonly Dictionary<string, int> ValidGameCubeCounts = new()
    {
        { "red", 12 },
        { "green", 13 },
        { "blue", 14 }
    };

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

    public static TotalResult PlayGames(string input)
    {
        var games = StringReader.ReadLines(input);
        var results = games.Select(PlayGame).ToList();
        var validGameSum = results.Where(o => o.IsValid).Sum(o => o.GameId);
        var totalPower = results.Sum(o => o.GamePower);

        return new TotalResult(validGameSum, totalPower);
    }

    private static GameResult PlayGame(string game)
    {
        var isValid = true;
        var gameParts = game.Split(':').ToList();
        var gameId = int.Parse(gameParts[0].Split(' ')[1]);
        var sets = gameParts[1].Trim().Split(';');

        var maxCubeCounts = new Dictionary<string, int>()
        {
            { "red", 0 },
            { "green", 0 },
            { "blue", 0 }
        };

        foreach (var set in sets)
        {
            var cubes = set.Trim().Split(',');
            foreach (var cube in cubes)
            {
                var parts = cube.Trim().Split(' ').ToList();
                var count = int.Parse(parts[0]);
                var color = parts[1];

                maxCubeCounts[color] = Math.Max(count, maxCubeCounts[color]);

                if (count > ValidGameCubeCounts[color])
                    isValid = false;
            }
        }

        var gamePower = maxCubeCounts.Values.Aggregate(1, (a, b) => a * b);
        return new GameResult(gameId, isValid, gamePower);
    }

    private record GameResult(int GameId, bool IsValid, int GamePower);
    public record TotalResult(int ValidGames, int GamePower);
}