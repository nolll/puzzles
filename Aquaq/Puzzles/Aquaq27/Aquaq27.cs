using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Aquaq.Puzzles.Aquaq27;

public class Aquaq27 : AquaqPuzzle
{
    private const char Empty = ' ';

    public override string Name => "Snake Eater";

    protected override PuzzleResult Run()
    {
        var result = CalculateSnakeScore(InputFile);

        return new PuzzleResult(result, "c803fdd834b45081e38679f19c527374");
    }

    public static int CalculateSnakeScore(string input)
    {
        var matrix = MatrixBuilder.BuildCharMatrixWithoutTrim(input, Empty);
        var coordsWithChars = matrix.Coords.Where(o => matrix.ReadValueAt(o) != Empty).ToHashSet();
        var adjacentDictionary = coordsWithChars
            .ToDictionary(k => k, v => matrix.PerpendicularAdjacentCoordsTo(v).Where(coordsWithChars.Contains).ToList());
        var ends = adjacentDictionary.Where(o => o.Value.Count == 1).Select(o => o.Key);
        var visited = new HashSet<MatrixAddress>();
        var words = new List<string>();

        foreach (var start in ends)
        {
            if (visited.Contains(start))
                continue;

            var word = "";
            var cur = start;
            while (true)
            {
                visited.Add(cur);
                var adjacent = adjacentDictionary[cur];
                var isEndOfWord = word.Length > 0 &&
                                  adjacent.Count == 2 &&
                                  adjacent.First().X != adjacent.Last().X
                                  && adjacent.First().Y != adjacent.Last().Y;
                var isEndOfSnake = adjacent.All(visited.Contains);
                word += matrix.ReadValueAt(cur);

                if (isEndOfSnake || isEndOfWord)
                {
                    words.Add(word);
                    word = "";
                }

                if (isEndOfSnake)
                    break;

                if (isEndOfWord)
                    continue;

                cur = adjacent.First(o => !visited.Contains(o));
            }
        }

        return words.Sum(GetWordScore);
    }

    private static int GetWordScore(string word) => word.Sum(GetCharScore) * word.Length;
    private static int GetCharScore(char c) => (int)(c - 'a') + 1;
}