using Pzl.Common;

namespace Pzl.Aquaq.Puzzles.Aquaq31;

[Name("Brandless Combination Cubes")]
public class Aquaq31(string input) : AquaqPuzzle
{
    protected override PuzzleResult Run()
    {
        var result = Rotate(input);

        return new PuzzleResult(result, "a5034749df5937c49bba3b06acc7119c");
    }

    public static int Rotate(string input)
    {
        var cube = new RubiksCube.Cube();
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