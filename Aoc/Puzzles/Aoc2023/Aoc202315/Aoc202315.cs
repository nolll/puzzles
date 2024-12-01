using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202315;

[Name("Lens Library")]
public class Aoc202315 : AocPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var result = input.Split(',').Sum(HashScore);

        return new PuzzleResult(result, "4c69a3b3d84dfabf7180d2d8541d7389");
    }

    protected override PuzzleResult RunPart2(string input)
    {
        var instructions = input.Split(',').ToList();
        var boxes = Enumerable.Range(0, 256).Select((_, index) => new Box(index + 0)).ToArray();

        foreach (var instruction in instructions)
        {
            var operation = instruction.Contains('=') ? Operation.Equal : Operation.Subtract;
            var parts = operation == Operation.Equal
                ? instruction.Split('=')
                : instruction.Split('-');

            var label = parts.First();
            var box = boxes[HashScore(label)];

            if (operation == Operation.Subtract)
            {
                box.Lenses = box.Lenses.Where(o => o.Label != label).ToList();
            }
            else
            {
                var focalLength = int.Parse(parts.Last());
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

    public static int HashScore(string s) => 
        s.Aggregate(0, (current, c) => (current + c) * 17 % 256);

    private enum Operation
    {
        Subtract,
        Equal
    }
}

public class Box(int id)
{
    public List<Lens> Lenses { get; set; } = new();
    public int FocusingPower => Lenses.Select((t, i) => (id + 1) * (i + 1) * t.FocalLength).Sum();
}

public class Lens(string label, int focalLength)
{
    public string Label { get; set; } = label;
    public int FocalLength { get; set; } = focalLength;
}