using Pzl.Tools.Puzzles;
using Pzl.Tools.Strings;

namespace Pzl.Aquaq.Puzzles.Aquaq12;

public class Aquaq12 : AquaqPuzzle
{
    public override string Name => "A Day In The Lift";

    protected override PuzzleResult Run()
    {
        var result = RideLift(InputFile);

        return new PuzzleResult(result, "a6668fd005e7ebda4e124253eea1e56e");
    }

    public static int RideLift(string input)
    {
        var floors = StringReader.ReadLines(input)
            .Select(o => o.Split(' ').Select(int.Parse).ToArray())
            .Select(o => new Floor(o[0] == 0, o[1])).ToArray();

        var f = 0;
        var direction = 1;
        var count = 0;
        while (true)
        {
            count++;
            if (f > floors.Length)
                break;

            var floor = floors[f];
            if (floor.SwitchDirection)
                direction *= -1;

            f += direction * floor.Distance;
        }

        return count;
    }

    private record Floor(bool SwitchDirection, int Distance);
}