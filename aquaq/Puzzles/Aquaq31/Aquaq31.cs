using Common.Puzzles;

namespace Aquaq.Puzzles.Aquaq31;

public class Aquaq31 : AquaqPuzzle
{
    public override string Name => "Brandless Combination Cubes";

    protected override PuzzleResult Run()
    {
        var result = Rotate(InputFile);

        return new PuzzleResult(result, "2354c276f1c9156f4b97a11a7aa41254");
    }

    public static int Rotate(string input)
    {
        var cube = new RubiksCube();
        var instructions = ParseInstructions(input);

        foreach (var instruction in instructions)
        {
            cube.Rotate(instruction);
        }

        return cube.Front.Product;
    }

    private static IEnumerable<string> ParseInstructions(string input)
    {
        var instructions = new List<string>();
        foreach (var c in input)
        {
            if (c == '\'')
                instructions[^1] += c;
            else
                instructions.Add(c.ToString());
        }

        return instructions;
    }
}