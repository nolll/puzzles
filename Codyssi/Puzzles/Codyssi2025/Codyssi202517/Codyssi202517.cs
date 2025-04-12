using System.Numerics;
using Pzl.Common;
using Pzl.Tools.Lists;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202517;

[Name("Spiralling Stairs")]
// Much too hard for me. Pretty much stole the whole solution from here:
// https://www.reddit.com/r/codyssi/comments/1jr576z/journey_to_atlantis_spiralling_stairs_solutions/
public class Codyssi202517 : CodyssiPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var (moves, stairById, nextStairs) = Parse(input);
        var cache = new Dictionary<string, BigInteger>();
        var comb = Dfs(cache, "S1", 0, true, moves, stairById, nextStairs);

        return new PuzzleResult(comb, "954b1dfc4c0c7b16d0de1201eebc2460");
    }

    private (int[] moves, Dictionary<string, Stair> stairById, Dictionary<string, List<string>> nextStairs)
        Parse(string input)
    {
        var (p1, p2) = input.Split(LineBreaks.Double);
        var stairs = p1.Split(LineBreaks.Single)
            .Select(o => o.Split(' '))
            .Select(o => new Stair(o[0], int.Parse(o[2]), int.Parse(o[4]), o[7], o[9]));
        var moves = Numbers.IntsFromString(p2).OrderDescending().ToArray();

        var nextStairs = new Dictionary<string, List<string>>();
        var stairById = new Dictionary<string, Stair>();
        foreach (var stair in stairs)
        {
            stairById[stair.Id] = stair;
            if (!nextStairs.ContainsKey(stair.StairFrom))
                nextStairs.Add(stair.StairFrom, []);
            nextStairs[stair.StairFrom].Add(stair.Id);
        }

        return (moves, stairById, nextStairs);
    }

    public PuzzleResult Part2(string input)
    {
        var (moves, stairById, nextStairs) = Parse(input);
        var cache = new Dictionary<string, BigInteger>();
        var comb = Dfs(cache, "S1", 0, false, moves, stairById, nextStairs);

        return new PuzzleResult(comb, "4125a5e00319f6235bfd4790450f0688");
    }

    public PuzzleResult Part3(string input)
    {
        var (moves, stairById, nextStairs) = Parse(input);
        var cache = new Dictionary<string, BigInteger>();
        var comb = Dfs(cache, "S1", 0, false, moves, stairById, nextStairs);
        var targetIndex = BigInteger.Parse("100000000000000000000000000000");
        if (targetIndex > cache["S1_0"])
        {
            targetIndex = cache["S1_0"];
        }

        var path = FindPathAtIndex(cache, "S1_0", targetIndex, "S1_" + stairById["S1"].FloorTo, "S1_0", moves,
            stairById, nextStairs);

        return new PuzzleResult(path, "96a73b4de344a21efaae671cdb265561");
    }

    private static BigInteger Dfs(
        Dictionary<string, BigInteger> cache,
        string stair,
        int floor,
        bool onlyMainStair,
        int[] moves,
        Dictionary<string, Stair> stairById,
        Dictionary<string, List<string>> nextStairs)
    {
        var state = stair + "_" + floor;
        if (cache.TryGetValue(state, out var dfs))
            return dfs;

        var config = stairById[stair];
        if (config.StairTo == "END" && config.FloorTo == floor)
        {
            cache[state] = new BigInteger(1);
            return new BigInteger(1);
        }

        if (config.StairTo == "END" && floor > config.FloorTo)
            return new BigInteger(0);

        var nextJumps = new HashSet<string>();
        foreach (var move in moves)
        {
            FindNextJumps(nextJumps, stair, floor, move, onlyMainStair, stairById, nextStairs);
        }

        var result = new BigInteger(0);
        foreach (var nextJump in nextJumps)
        {
            var (nextStair, nextFloor) = nextJump.Split("_");
            result += Dfs(cache, nextStair, int.Parse(nextFloor), onlyMainStair, moves, stairById, nextStairs);
        }

        cache[state] = result;
        return result;
    }

    private static void FindNextJumps(HashSet<string> jumps, string stair, int floor, int stepsLeft, bool onlyMainStair, Dictionary<string, Stair> stairById, Dictionary<string, List<string>> nextStairs)
    {
        while (true)
        {
            if (!stairById.TryGetValue(stair, out var config))
                return;

            if (stepsLeft == 0)
            {
                if (floor >= config.FloorFrom && floor <= config.FloorTo) 
                    jumps.Add(stair + "_" + floor);
            }
            else
            {
                if (onlyMainStair)
                {
                    floor += 1;
                    stepsLeft -= 1;
                    continue;
                }

                if (floor == config.FloorTo)
                {
                    stair = config.StairTo;
                    stepsLeft -= 1;
                    continue;
                }

                FindNextJumps(jumps, stair, floor + 1, stepsLeft - 1, onlyMainStair, stairById, nextStairs);
                if (nextStairs.TryGetValue(stair, out var stair1))
                {
                    foreach (var nextStair in stair1)
                    {
                        var nextStairConfig = stairById[nextStair];
                        if (nextStairConfig.FloorFrom == floor)
                        {
                            FindNextJumps(jumps, nextStair, floor, stepsLeft - 1, onlyMainStair, stairById, nextStairs);
                        }
                    }
                }
            }

            break;
        }
    }

    private static string FindPathAtIndex(Dictionary<string, BigInteger> cache,
        string current,
        BigInteger targetIndex,
        string targetNode,
        string path,
        int[] moves,
        Dictionary<string, Stair> stairById,
        Dictionary<string, List<string>> nextStairs)
    {
        if (current == targetNode)
            return path;

        var (stair, floor) = current.Split("_");
        var nextJumps = new HashSet<string>();
        foreach (var move in moves) 
            FindNextJumps(nextJumps, stair, int.Parse(floor), move, false, stairById, nextStairs);

        var nextJumpList = nextJumps.ToList();
        nextJumpList.Sort((a, b) =>
        {
            var (ass, ans) = Numbers.IntsFromString(a);
            var (bss, bns) = Numbers.IntsFromString(b);
            return ass != bss 
                ? ass - bss 
                : ans - bns;
        });

        foreach (var jump in nextJumpList)
        {
            var nextCount = cache[jump];
            if (targetIndex > nextCount)
                targetIndex -= nextCount;
            else
                return FindPathAtIndex(cache, jump, targetIndex, targetNode, path + "-" + jump, moves, stairById, nextStairs);
        }

        return "";
    }

    private record Stair(string Id, int FloorFrom, int FloorTo, string StairFrom, string StairTo);
}