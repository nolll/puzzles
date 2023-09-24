using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2020.Aoc202004;

public class Year2020Day04 : AocPuzzle
{
    public override string Name => "Passport Processing";

    protected override PuzzleResult RunPart1()
    {
        var processor = new PassportProcessor(InputFile);
        var passportCount = processor.GetNumberOfPassportsThatHasAllFields();
        return new PuzzleResult(passportCount, 210);
    }

    protected override PuzzleResult RunPart2()
    {
        var processor = new PassportProcessor(InputFile);
        var passportCount = processor.GetNumberOfValidPassports();
        return new PuzzleResult(passportCount, 131);
    }
}