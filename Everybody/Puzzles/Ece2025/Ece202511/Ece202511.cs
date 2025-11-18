using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2025.Ece202511;

[Name("The Scout Duck Protocol")]
public class Ece202511 : EverybodyEventPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var cols = input.Split(LineBreaks.Single).Select(int.Parse).ToArray();
        var phase = 1;
        var roundsLeft = 10;
        
        while (roundsLeft > 0)
        {
            var moved = false;
            for (var i = 0; i < cols.Length - 1; i++)
            {
                if (phase == 1 && cols[i] > cols[i + 1])
                {
                    cols[i]--;
                    cols[i + 1]++;
                    moved = true;
                }
                else if (phase == 2 && cols[i] < cols[i + 1])
                {
                    cols[i]++;
                    cols[i + 1]--;
                    moved = true;
                }
            }

            if (moved)
            {
                roundsLeft--;
                continue;
            }

            if (phase != 1)
                break;
            
            phase = 2;
        }

        var checksum = cols.Select((t, i) => t * (i + 1)).Sum();

        return new PuzzleResult(checksum, "f8edf60eba791291edc0affdd3910b97");
    }

    public PuzzleResult Part2(string input)
    {
        var cols = input.Split(LineBreaks.Single).Select(int.Parse).ToArray();
        var rounds = 0;
        var phase = 1;
        
        while (cols.Distinct().Count() > 1)
        {
            var moved = false;
            for (var i = 0; i < cols.Length - 1; i++)
            {
                if (phase == 1 && cols[i] > cols[i + 1])
                {
                    cols[i]--;
                    cols[i + 1]++;
                    moved = true;
                }
                else if (phase == 2 && cols[i] < cols[i + 1])
                {
                    cols[i]++;
                    cols[i + 1]--;
                    moved = true;
                }
            }

            if (moved)
            {
                rounds++;
            }
            else
            {
                if (phase != 1)
                    break;
                
                phase = 2;
            }
        }
        
        return new PuzzleResult(rounds, "0190e3fea8360b204a353840cb82c001");
    }

    public PuzzleResult Part3(string input)
    {
        var cols = input.Split(LineBreaks.Single).Select(long.Parse).ToArray();
        var avg = cols.Sum() / cols.Length;
        var totalDistanceToAvg = cols.Where(o => o < avg).Select(o => avg - o).Sum();
        return new PuzzleResult(totalDistanceToAvg, "a6ce160669697ddf6f40132abe96f3a1");
    }
}