using Pzl.Common;
using Pzl.Tools.Combinatorics;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202421;

[Name("Keypad Conundrum")]
// Solved with a lot of help from HyperNeutrino. I was on the right track tho
public class Aoc202421 : AocPuzzle
{
    private static readonly List<List<string>> Numpad =
    [
        ["7", "8", "9"],
        ["4", "5", "6"],
        ["1", "2", "3"],
        ["", "0", "A"]
    ];
    
    private static readonly List<List<string>> Arrowpad =
    [
        ["", "^", "A"],
        ["<", "v", ">"]
    ];

    private static readonly Dictionary<(string, string), List<string>> NumSeqs = ComputeSequences(Numpad);
    private static readonly Dictionary<(string, string), List<string>> ArrowSeqs = ComputeSequences(Arrowpad);

    private static readonly Dictionary<(string, string), int> ArrowLengths =
        ArrowSeqs.ToDictionary(k => k.Key, v => v.Value.First().Length);

    public PuzzleResult Part1(string input)
    {
        var result = Run(input, 2);
        return new PuzzleResult(result, "0e39f69d96697459d6010612d45068b8");
    }
    
    public PuzzleResult Part2(string input)
    {
        var result = Run(input, 25);
        return new PuzzleResult(result, "11dc3947e6394cb17a12fc9fb6d874c7");
    }

    private long Run(string input, int robotCount) => 
        input.Split(LineBreaks.Single)
            .Sum(code => Solve(code, robotCount) * Numbers.IntsFromString(code).First());

    public long Solve(string code, int robotCount) =>
        Solve(code, NumSeqs).Select(o => ComputeLength([], o, robotCount)).Min();

    private List<string> Solve(string code, Dictionary<(string, string), List<string>> seqs)
    {
        var options = new List<List<string>>();
        foreach (var (x, y) in ("A" + code).Zip(code))
        {
            options.Add(seqs[(x.ToString(), y.ToString())]);
        }

        var results = CombinationGenerator.CartesianProduct(options);
        
        return results.Select(o => string.Join("", o)).ToList();
    }

    private static long ComputeLength(Dictionary<(string seq, int depth), long> cache, string seq, int depth)
    {
        if (depth == 1)
            return ("A" + seq).Zip(seq).Select(o => ArrowLengths[(o.First.ToString(), o.Second.ToString())]).Sum();
        
        var cachekey = (seq, depth);
        if (cache.TryGetValue(cachekey, out var cachedlength))
            return cachedlength;
        
        var length = 0L;
        foreach (var (x, y) in ("A" + seq).Zip(seq))
        {
            length += ArrowSeqs[(x.ToString(), y.ToString())].Select(o => ComputeLength(cache, o, depth - 1)).Min();
        }

        cache.TryAdd(cachekey, length);
        
        return length;
    }

    private static Dictionary<(string, string), List<string>> ComputeSequences(List<List<string>> keypad)
    {
        var pos = new Dictionary<string, (int r, int c)>();
        for (var r = 0; r < keypad.Count; r++)
        {
            for (var c = 0; c < keypad[0].Count; c++)
            {
                var key = keypad[r][c];
                if (key != "")
                    pos[key] = (r, c);
            }
        }

        var seqs = new Dictionary<(string, string), List<string>>();
        foreach (var x in pos.Keys)
        {
            foreach (var y in pos.Keys)
            {
                if (x == y)
                {
                    seqs[(x, y)] = ["A"];
                    continue;
                }

                var possibilities = new List<string>();
                var q = new Queue<((int r, int c), string sequence)>();
                q.Enqueue((pos[x], ""));
                var optimal = int.MaxValue;
                var foundOptimal = false;
                while (q.Count > 0)
                {
                    var ((r, c), moves) = q.Dequeue();
                    foreach (var (nr, nc, nm) in GetNextMoves(r, c))
                    {
                        if (nr < 0 || nc < 0 || nr >= keypad.Count || nc >= keypad[0].Count)
                            continue;

                        if (keypad[nr][nc] == "")
                            continue;
                        
                        if (keypad[nr][nc] == y)
                        {
                            if (optimal < moves.Length + 1)
                            {
                                foundOptimal = true;
                                break;
                            }

                            optimal = moves.Length + 1;
                            possibilities.Add(moves + nm + "A");
                        }
                        else
                        {
                            q.Enqueue(((nr, nc), moves + nm));
                        }
                    }

                    if (foundOptimal)
                        break;

                }
                
                seqs[(x, y)] = possibilities;
            }    
        }

        return seqs;
    }

    private static List<(int nr, int nc, string nm)> GetNextMoves(int r, int c) =>
    [
        (r - 1, c, "^"),
        (r, c + 1, ">"),
        (r + 1, c, "v"),
        (r, c - 1, "<")
    ];
}