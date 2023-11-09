using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2022.Aoc202205;

public class Aoc202205 : AocPuzzle
{
    public override string Name => "Supply Stacks";

    protected override PuzzleResult RunPart1()
    {
        var crane = new CargoCrane(InputFile);
        crane.Run1();
        return new PuzzleResult(crane.Message, "9828a1b1c82b8879448ee5d92f6245f8");
    }

    protected override PuzzleResult RunPart2()
    {
        var crane = new CargoCrane(InputFile);
        crane.Run2();
        return new PuzzleResult(crane.Message, "be487b7be9543b1de622347458714dcd");
    }
}