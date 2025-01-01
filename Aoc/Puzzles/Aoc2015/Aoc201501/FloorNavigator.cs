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
            DestinationFloor += FloorDelta(c);

            if (FirstBasementInstruction == null && DestinationFloor < 0)
                FirstBasementInstruction = index;

            index++;
        }
    }

    private int FloorDelta(char c) => c switch
    {
        '(' => 1,
        ')' => -1,
        _ => 0
    };
}