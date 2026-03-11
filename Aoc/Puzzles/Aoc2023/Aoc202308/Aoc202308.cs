using Pzl.Common;
using Pzl.Tools.Maths;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202308;

[Name("Haunted Wasteland")]
public class Aoc202308 : AocPuzzle
{
    [Puzzle("fc2f3ff0b243fed57135f9ca59507411")]
    public long Part1(string input)
    {
        var (directions, connections) = ParseInput(input);
        return GetStepCount(connections, directions, CompareFunc, "AAA");

        bool CompareFunc(string s) => s != "ZZZ";
    }

    [Puzzle("ea69e01b93e2a5ffbd263edd44ecc7e8")]
    public long Part2(string input)
    {
        var (directions, connections) = ParseInput(input);
        var startPositions = connections.Keys.Where(o => o.EndsWith('A')).ToList();
        var pathLengths = startPositions.Select(o => GetStepCount(connections, directions, CompareFunc, o));
        return MathTools.Lcm(pathLengths);

        bool CompareFunc(string s) => !s.EndsWith('Z');
    }
    
    private static long GetStepCount(
        IReadOnlyDictionary<string, (string Left, string Right)> connections,
        char[] directions,
        Func<string, bool> compareFunc,
        string startPos)
    {
        var stepCount = 0L;
        var pos = startPos;
        while (compareFunc(pos))
        {
            pos = directions[stepCount % directions.Length] == 'L' 
                ? connections[pos].Left 
                : connections[pos].Right;

            stepCount++;
        }

        return stepCount;
    }

    private static (char[] Directions, Dictionary<string, (string Left, string Right)> Connections)
        ParseInput(string input)
    {
        var connections = new Dictionary<string, (string Left, string Right)>();

        var groups = input
            .Split(LineBreaks.Double)
            .Select(o => o.Split(LineBreaks.Single))
            .ToList();
        var directions = groups.First().First().ToCharArray();

        foreach (var line in groups.Last())
        {
            var parts = line.Split(" = ");
            var key = parts.First();
            var destinations = parts.Last().TrimStart('(').TrimEnd(')').Split(", ").ToList();
            connections.Add(key, (destinations.First(), destinations.Last()));
        }

        return (directions, connections);
    }
}