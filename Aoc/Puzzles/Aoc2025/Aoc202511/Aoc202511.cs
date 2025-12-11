using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2025.Aoc202511;

[Name("Reactor")]
public class Aoc202511 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var devices = new Dictionary<string, string[]>();
        foreach (var line in lines)
        {
            var parts = line.Split();
            var name = parts.First().TrimEnd(':');
            var connections = parts.Skip(1).ToArray();
            devices.Add(name, connections);
        }

        var paths = FindPathsPart1([], "you", "out", devices);
        
        return new PuzzleResult(paths.Count, "815a49e75c9abbb49de207da8a44c044");
    }

    public PuzzleResult Part2(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var devices = new Dictionary<string, string[]>();
        foreach (var line in lines)
        {
            var parts = line.Split();
            var name = parts.First().TrimEnd(':');
            var connections = parts.Skip(1).ToArray();
            devices.Add(name, connections);
        }
        
        devices.Add("out", []);
        
        var svrdac = CountPaths("svr", "dac", devices, []);
        var dacfft = CountPaths("dac", "fft", devices, []);
        var fftout = CountPaths("fft", "out", devices, []);
        
        var svrfft = CountPaths("svr", "fft", devices, []);
        var fftdac = CountPaths("fft", "dac", devices, []);
        var dacout = CountPaths("dac", "out", devices, []);

        var count = svrdac * dacfft * fftout + svrfft * fftdac * dacout;
        
        return new PuzzleResult(count);
    }
    
    private List<List<string>> FindPathsPart1(List<string> path, string current, string target, Dictionary<string, string[]> devices)
    {
        List<string> nextPath = [..path, current];
        if (current == target)
            return [nextPath];

        var list = new List<List<string>>();
        foreach (var connection in devices[current])
        {
            list.AddRange(FindPathsPart1(nextPath, connection, target, devices));
        }

        return list;
    }
    
    private long CountPaths(
        string current,
        string target,
        Dictionary<string, string[]> devices,
        Dictionary<string, long> seen)
    {
        if (seen.TryGetValue(current, out var count))
            return count;
        
        if (current == target)
            return 1;

        var sum = 0L;
        foreach (var connection in devices[current])
        {
            sum += CountPaths(connection, target, devices, seen);
        }

        seen[current] = sum;
        
        return sum;
    }
}