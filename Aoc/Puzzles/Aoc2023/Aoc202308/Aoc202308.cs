using Pzl.Common;
using Pzl.Tools.Maths;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202308;

[Name("Haunted Wasteland")]
public class Aoc202308(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        return new PuzzleResult(DesertPath1(input), "fc2f3ff0b243fed57135f9ca59507411");
    }

    protected override PuzzleResult RunPart2()
    {
        return new PuzzleResult(DesertPath2(input), "ea69e01b93e2a5ffbd263edd44ecc7e8");
    }

    public static long DesertPath1(string input)
    {
        var (directions, connections) = ParseInput(input);

        bool CompareFunc(string s) => s != "ZZZ";
        return GetStepCount(connections, directions, CompareFunc, "AAA");
    }

    public static long DesertPath2(string input)
    {
        var (directions, connections) = ParseInput(input);

        var startPositions = connections.Keys.Where(o => o.EndsWith('A')).ToList();

        bool CompareFunc(string s) => !s.EndsWith('Z');
        var pathLengths = startPositions.Select(
            startPosition => GetStepCount(connections, directions, CompareFunc, startPosition)).ToList();

        return MathTools.Lcm(pathLengths);
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

        var groups = StringReader.ReadLineGroups(input);
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