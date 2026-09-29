using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("The Tyranny of the Rocket Equation")]
public class Aoc201901 : AocPuzzle
{
    [Puzzle("863ba725f4b926c82a67e448dbacc8ca")]
    public int Part1(string input) => new MassCalculator(input).MassFuel;

    [Puzzle("9a6de12a9f00b9360ead07efc0249b8c")]
    public int Part2(string input) => new MassCalculator(input).TotalFuel;
    
    public class MassCalculator
    {
        public int MassFuel { get; }
        public int TotalFuel { get; }

        public MassCalculator(string input)
        {
            var modules = GetModules(input);
            MassFuel = modules.Sum(o => o.MassFuel);
            TotalFuel = modules.Sum(o => o.TotalFuel);
        }

        private IList<Module> GetModules(string input)
        {
            var massStrings = input.Trim().Split(LineBreaks.Single);
            return massStrings.Select(o => new Module(int.Parse(o.Trim()))).ToList();
        }
    }
    
    public class Module(int mass)
    {
        public int MassFuel { get; } = GetFuel(mass);
        public int TotalFuel { get; } = GetTotalFuel(mass);

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
}