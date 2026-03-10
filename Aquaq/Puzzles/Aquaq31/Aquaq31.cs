using Pzl.Common;

namespace Pzl.Aquaq.Puzzles.Aquaq31;

[Name("Brandless Combination Cubes")]
public class Aquaq31 : AquaqPuzzle
{
    [Puzzle("a5034749df5937c49bba3b06acc7119c")]
    public PuzzleResult Solve(string input)
    {
        var result = Rotate(input);

        return new PuzzleResult(result);
    }

    public static int Rotate(string input)
    {
        var cube = new RubiksCube.Cube();
        cube.Rotate(input);

        return cube.Front.Product;
    }
}