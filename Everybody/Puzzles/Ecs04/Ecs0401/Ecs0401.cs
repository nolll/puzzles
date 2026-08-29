using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ecs04.Ecs0401;

[Name("The Recamán Drapery")]
public class Ecs0401 : EverybodyStoryPuzzle
{
    [Puzzle("339bcc2d6d6b95ef1263cc2e85307fa0")]
    public int Part1(string input) => ParseSequences(input).Sum(RunSequencePart1);

    [Puzzle("1bb91caf03406808b2f281fbb1042c83")]
    public int Part2(string input) => ParseSequences(input).Sum(RunSequencePart2);

    [Puzzle("b1c354c60f70fb69d4a9c2558af031aa")]
    public int Part3(string input) => ParseSequences(input).Sum(RunSequencePart3);

    private static int RunSequencePart1(int[] sequence)
    {
        var n = 0;
        var numbers = new HashSet<int>([n]);

        foreach (var jump in sequence)
        {
            var back = n - jump;
            n = back >= 0 && !numbers.Contains(back) ? back : n + jump;
            numbers.Add(n);
        }

        return n;
    }
    
    private static int RunSequencePart2(int[] sequence)
    {
        var n = 0;
        var numbers = new HashSet<int>([n]);

        foreach (var jump in sequence)
        {
            var back = n - jump;
            n = back >= 0 && !numbers.Contains(back) ? back : n + jump;

            while (numbers.Contains(n))
                n++;
                
            numbers.Add(n);
        }

        return n;
    }
    
    private static int RunSequencePart3(int[] sequence)
    {
        var n = 0;
        var numbers = new HashSet<int>([n]);
        var arcs = new Dictionary<bool, List<(int, int)>>
        {
            { false, [] },
            { true, [] }
        };
        var selectedArcs = true;

        foreach (var jump in sequence)
        {
            var back = n - jump;
            if (back >= 0 && !numbers.Contains(back) && !IsCrossing(arcs[selectedArcs], back, n))
            {
                arcs[selectedArcs].Add((back, n));
                n = back;
                numbers.Add(n);
                selectedArcs = !selectedArcs;
                continue;
            }
                
            var forward = n + jump;
            var isPossible = true;
            
            while (numbers.Contains(forward) || IsCrossing(arcs[selectedArcs], n, forward))
            {
                if (forward > numbers.Max())
                {
                    isPossible = false;
                    break;
                }
                
                forward++;
            }
                
            if (!isPossible)
                continue;

            arcs[selectedArcs].Add((n, forward));
            n = forward;
            numbers.Add(n);
            selectedArcs = !selectedArcs;
        }

        return n;
    }

    public static bool IsCrossing(List<(int min, int max)> arcs, int start, int end)
    {
        foreach (var (min, max) in arcs)
        {
            if (start > max) continue;
            if (end < min) continue;
            if (start >= min && start <= max && end >= max) return true;
            if (end <= max && end >= min && start <= min) return true;
        }

        return false;
    }

    private static int[][] ParseSequences(string input) => input.Split(LineBreaks.Single).Select(ParseSequence).ToArray();
    private static int[] ParseSequence(string input) => input.Split(',').Select(int.Parse).ToArray();
}