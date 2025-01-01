using System.Text.Json;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201512;

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