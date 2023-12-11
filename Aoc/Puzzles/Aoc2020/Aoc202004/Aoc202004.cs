using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202004;

[Name("Passport Processing")]
public class Aoc202004(string input) : AocPuzzle(input)
{
    protected override PuzzleResult RunPart1()
    {
        var processor = new PassportProcessor(Input);
        var passportCount = processor.GetNumberOfPassportsThatHasAllFields();
        return new PuzzleResult(passportCount, "1e10a803d525ec160795a9bed9161106");
    }

    protected override PuzzleResult RunPart2()
    {
        var processor = new PassportProcessor(Input);
        var passportCount = processor.GetNumberOfValidPassports();
        return new PuzzleResult(passportCount, "4648ca473c884f7676991b343c2db8e0");
    }
}