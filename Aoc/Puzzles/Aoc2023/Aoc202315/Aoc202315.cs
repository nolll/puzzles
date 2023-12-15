using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202315;

[Name("Parabolic Reflector Dish")]
public class Aoc202315(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var result = input.Split(',').Sum(HashScore);

        return new PuzzleResult(result, "4c69a3b3d84dfabf7180d2d8541d7389");
    }

    protected override PuzzleResult RunPart2()
    {
        var instructions = input.Split(',').ToList();
        var boxes = Enumerable.Range(0, 256).Select((o, index) => new Box(index + 0)).ToArray();

        foreach (var instruction in instructions)
        {
            var operation = instruction.Contains('=') ? Operation.Equal : Operation.Subtract;
            var parts = operation == Operation.Equal
                ? instruction.Split('=')
                : instruction.Split('-');

            var label = parts.First();
            var focalLength = operation == Operation.Equal
                ? int.Parse(parts.Last())
                : 0;

            var boxId = HashScore(label);

            var box = boxes[boxId];

            if (operation == Operation.Subtract)
            {
                box.Lenses = box.Lenses.Where(o => o.Label != label).ToList();
            }
            else
            {
                var lens = box.Lenses.FirstOrDefault(o => o.Label == label);
                if (lens is not null)
                    lens.FocalLength = focalLength;
                else
                    box.Lenses.Add(new Lens(label, focalLength));
            }
        }

        var sum = boxes.Sum(o => o.FocusingPower);

        return new PuzzleResult(sum, "c596fa2656ce06bc3fb557ddd741c834");
    }

    public static int HashScore(string s)
    {
        var v = 0;
        foreach (var c in s)
        {
            v += c;
            v *= 17;
            v %= 256;
        }

        return v;
    }

    private enum Operation
    {
        Subtract,
        Equal
    }
}

public class Box(int id)
{
    public int Id { get; } = id;
    public List<Lens> Lenses { get; set; } = new();

    public int FocusingPower
    {
        get
        {
            var total = 0;
            for (var i = 0; i < Lenses.Count; i++)
            {
                var power = (Id + 1) * (i + 1) * Lenses[i].FocalLength;
                total += power;
            }

            return total;
        }
    }
}

public class Lens(string label, int focalLength)
{
    public string Label { get; set; } = label;
    public int FocalLength { get; set; } = focalLength;
}