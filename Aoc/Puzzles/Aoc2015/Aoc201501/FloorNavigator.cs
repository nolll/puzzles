namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201501;

public class FloorNavigator
{
    public int DestinationFloor { get; }
    public int? FirstBasementInstruction { get; }

    public FloorNavigator(string input)
    {
        var instructions = input.ToCharArray();
        var index = 1;
        foreach (var c in instructions)
        {
            if (c == '(')
                DestinationFloor++;
            if (c == ')')
                DestinationFloor--;

            if (FirstBasementInstruction == null && DestinationFloor < 0)
                FirstBasementInstruction = index;

            index++;
        }
    }
}