using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202004;

[Name("Passport Processing")]
public class Aoc202004 : AocPuzzle
{
    [Puzzle("1e10a803d525ec160795a9bed9161106")]
    public int Part1(string input) => new PassportProcessor(input).GetNumberOfPassportsThatHasAllFields();

    [Puzzle("4648ca473c884f7676991b343c2db8e0")]
    public int Part2(string input) => new PassportProcessor(input).GetNumberOfValidPassports();
}