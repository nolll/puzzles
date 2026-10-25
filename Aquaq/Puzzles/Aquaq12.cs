using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aquaq.Puzzles;

[Name("A Day In The Lift")]
public class Aquaq12 : AquaqPuzzle
{
    [Puzzle("a6668fd005e7ebda4e124253eea1e56e")]
    public int Solve(string input)
    {
        var f = 0;
        var direction = 1;
        var count = 0;
        var floors = input.Split(LineBreaks.Single).Select(Numbers.IntsFromString).Select(o => new Floor(o[0] == 0, o[1])).ToArray();
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