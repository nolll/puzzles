using System.Collections.Generic;
using System.Linq;

namespace Aoc.Puzzles.Aoc2019.Aoc201901;

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
        var massStrings = input.Trim().Split('\n');
        return massStrings.Select(o => new Module(int.Parse(o.Trim()))).ToList();
    }
}