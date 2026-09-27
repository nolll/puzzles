using System.Text.Json;
using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015;

[Name("JSAbacusFramework.io")]
public class Aoc201512 : AocPuzzle
{
    [Puzzle("72e4a93f95510bb5f9d0b20360676111")]
    public int Part1(string input) => new JsonDoc(input, true).Sum;

    [Puzzle("c5934cc2e7d3cc9b1183329d8d2f1d82")]
    public int Part2(string input) => new JsonDoc(input, false).Sum;
    
    public class JsonDoc
    {
        private readonly bool _includeRed;
        public int Sum { get; }

        public JsonDoc(string input, bool includeRed)
        {
            _includeRed = includeRed;
            var json = JsonDocument.Parse(input);

            Sum = GetRecursiveSum(json.RootElement);
        }

        private int GetRecursiveSum(JsonElement jsonElement) => jsonElement.ValueKind switch
        {
            JsonValueKind.String => 0,
            JsonValueKind.Number => jsonElement.TryGetInt32(out var num) ? num : 0,
            JsonValueKind.Array => jsonElement.EnumerateArray().Sum(GetRecursiveSum),
            JsonValueKind.Object when !_includeRed && jsonElement.EnumerateObject()
                .Any(o => o.Value.ValueKind == JsonValueKind.String && o.Value.ToString() == "red") => 0,
            JsonValueKind.Object => jsonElement.EnumerateObject().Sum(o => GetRecursiveSum(o.Value)),
            _ => 0
        };
    }
}