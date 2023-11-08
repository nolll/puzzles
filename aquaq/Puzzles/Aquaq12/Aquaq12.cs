using Common.Puzzles;

namespace Aquaq.Puzzles.Aquaq12;

public class Aquaq12 : AquaqPuzzle
{
    public override string Name => "A Day In The Lift";

    protected override PuzzleResult Run()
    {
        var result = RideLift(InputFile);

        return new PuzzleResult(result, "138bb0696595b338afbab333c555292a");
    }

    public static int RideLift(string input)
    {
        var floors = input.Split(Environment.NewLine)
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