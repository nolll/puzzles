using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("The Tyranny of the Rocket Equation")]
public class Aoc201901 : AocPuzzle
{
    [Puzzle("863ba725f4b926c82a67e448dbacc8ca")]
    public int Part1(string input) => GetMasses(input).Sum(GetFuel);

    [Puzzle("9a6de12a9f00b9360ead07efc0249b8c")]
    public int Part2(string input) => GetMasses(input).Sum(GetTotalFuel);

    private static IEnumerable<int> GetMasses(string input) => input.Trim().Split(LineBreaks.Single).Select(int.Parse);
    private static int GetFuel(int mass) => (int)Math.Floor((double)mass / 3) - 2;

    private static int GetTotalFuel(int mass)
    {
        var totalFuel = 0;
        var fuel = GetFuel(mass);
            
        while (fuel > 0)
        {
            totalFuel += fuel;
            fuel = GetFuel(fuel);
        }

        return totalFuel;
    }
}