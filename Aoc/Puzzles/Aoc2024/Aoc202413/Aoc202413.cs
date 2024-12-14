using Pzl.Common;
using Pzl.Tools.Maths;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202413;

[Name("Claw Contraption")]
public class Aoc202413 : AocPuzzle
{
    public record ArcadeMachine((long x, long y) PrizeLocation, (long x, long y) A, (long x, long y) B);
    
    public PuzzleResult Part1(string input)
    {
        var groups = StringReader.ReadLineGroups(input);
        var machines = new List<ArcadeMachine>();
        foreach (var group in groups)
        {
            var aNums = Numbers.IntsFromString(group[0]);
            var bNums = Numbers.IntsFromString(group[1]);
            var pNums = Numbers.IntsFromString(group[2]);
            var a = (aNums[0], aNums[1]);
            var b = (bNums[0], bNums[1]);
            var p = (pNums[0], pNums[1]);
            machines.Add(new ArcadeMachine(p, a, b));
        }

        var totalCost = 0L;
        foreach (var machine in machines)
        {
            var best = long.MaxValue;
            for (var a = 0; a < 100; a++)
            {
                for (var b = 0; b < 100; b++)
                {
                    var x = a * machine.A.x + b * machine.B.x;
                    var y = a * machine.A.y + b * machine.B.y;
                    if (x == machine.PrizeLocation.x && y == machine.PrizeLocation.y)
                    {
                        var cost = 3 * a + b;
                        best = Math.Min(best, cost);
                    }
                }            
            }

            totalCost += best < long.MaxValue ? best : 0;
        }
        
        return new PuzzleResult(totalCost, "56660d12b57edc245008c03e719df0bf");
    }

    public PuzzleResult Part2(string input)
    {
        var extension = 10_000_000_000_000;
        var groups = StringReader.ReadLineGroups(input);
        var machines = new List<ArcadeMachine>();
        foreach (var group in groups)
        {
            var aNums = Numbers.IntsFromString(group[0]);
            var bNums = Numbers.IntsFromString(group[1]);
            var pNums = Numbers.IntsFromString(group[2]);
            var a = (aNums[0], aNums[1]);
            var b = (bNums[0], bNums[1]);
            var p = (pNums[0] + extension, pNums[1] + extension);
            machines.Add(new ArcadeMachine(p, a, b));
        }
        
        var bestDistance = 0L;
        foreach (var machine in machines)
        {
            var best = long.MaxValue;
            for (var a = 0; a < 100; a++)
            {
                for (var b = 0; b < 100; b++)
                {
                    var x = a * machine.A.x + b * machine.B.x;
                    var y = a * machine.A.y + b * machine.B.y;
                    if (x == machine.PrizeLocation.x && y == machine.PrizeLocation.y)
                    {
                        
                        var cost = 3 * a + b;
                        best = Math.Min(best, cost);
                    }
                }            
            }

            bestDistance += best < long.MaxValue ? best : 0;
        }
        
        // 7400000004096560 too high
        
        return new PuzzleResult(0);
    }

    public bool IsSolvable(string input)
    {
        return IsSolvable(input.Split(LineBreaks.Single));
    }
    
    public bool IsSolvable(string[] input)
    {
        var extension = 10_000_000_000_000;
        
        var aNums = Numbers.IntsFromString(input[0]);
        var bNums = Numbers.IntsFromString(input[1]);
        var pNums = Numbers.IntsFromString(input[2]);
        var a = (aNums[0], aNums[1]);
        var b = (bNums[0], bNums[1]);
        var p = (pNums[0], pNums[1]);
        var machine = new ArcadeMachine(p, a, b);

        var px = machine.PrizeLocation.x + extension;
        var py = machine.PrizeLocation.y + extension;

        var lcmx = MathTools.Lcm(machine.A.x, machine.B.x);
        var lcmy = MathTools.Lcm(machine.A.y, machine.B.y);

        return px % lcmx == 0 && py % lcmy == 0;
    }
}