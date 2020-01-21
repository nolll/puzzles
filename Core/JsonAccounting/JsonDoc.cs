using System.Linq;
using System.Text.Json;

namespace Core.JsonAccounting
{
    public class JsonDoc
    {
        public int Sum { get; }

        public JsonDoc(string input)
        {
            var json = JsonDocument.Parse(input);

            Sum = GetRecursiveSum(json.RootElement);
        }

        private int GetRecursiveSum(JsonElement jsonElement)
        {
            var type = jsonElement.ValueKind;

            if (type == JsonValueKind.String)
                return 0;

            if (type == JsonValueKind.Number)
            {
                if (jsonElement.TryGetInt32(out var num))
                    return num;
                return 0;
            }

            if (type == JsonValueKind.Array)
                return jsonElement.EnumerateArray().Sum(GetRecursiveSum);

            if (type == JsonValueKind.Object)
                return jsonElement.EnumerateObject().Sum(o => GetRecursiveSum(o.Value));

            return 0;
        }
    }
}