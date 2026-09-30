using System.Text.Json;
using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015;

[Name("JSAbacusFramework.io")]
public class Aoc201512 : AocPuzzle
{
    [Puzzle("72e4a93f95510bb5f9d0b20360676111")]
    public int Part1(string input) => GetRecursiveSum(JsonDocument.Parse(input).RootElement, true);

    [Puzzle("c5934cc2e7d3cc9b1183329d8d2f1d82")]
    public int Part2(string input) => GetRecursiveSum(JsonDocument.Parse(input).RootElement, false);
    
    private int GetRecursiveSum(JsonElement jsonElement, bool includeRed) => jsonElement.ValueKind switch
    {
        JsonValueKind.String => 0,
        JsonValueKind.Number => jsonElement.TryGetInt32(out var num) ? num : 0,
        JsonValueKind.Array => jsonElement.EnumerateArray().Sum(jsonElement1 => GetRecursiveSum(jsonElement1, includeRed)),
        JsonValueKind.Object when !includeRed && jsonElement.EnumerateObject()
            .Any(o => o.Value.ValueKind == JsonValueKind.String && o.Value.ToString() == "red") => 0,
        JsonValueKind.Object => jsonElement.EnumerateObject().Sum(o => GetRecursiveSum(o.Value, includeRed)),
        _ => 0
    };
}