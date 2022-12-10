using Core.Platform;

namespace Core.Puzzles.Year2022.Day10;

public class Year2022Day10 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var tube = new CathodeRayTube();
        var result = tube.Part1(FileInput);

        return new PuzzleResult(result, 14360);
    }

    public override PuzzleResult RunPart2()
    {
        var tube = new CathodeRayTube();
        var result = tube.Part2(FileInput);

        return new PuzzleResult(result, "BGKAEREZ");
    }
}