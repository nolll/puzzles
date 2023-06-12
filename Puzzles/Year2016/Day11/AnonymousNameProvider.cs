using System.Collections.Generic;

namespace Aoc.Puzzles.Year2016.Day11;

public class AnonymousNameProvider
{
    private readonly Dictionary<int, string> _generatorCache = new();
    private readonly Dictionary<int, string> _microchipCache = new();

    public string GetGeneratorName(int counter)
    {
        if (_generatorCache.TryGetValue(counter, out var s))
            return s;
        
        s = string.Concat(counter, 'X');
        _generatorCache.Add(counter, s);

        return s;
    }

    public string GetMicrochipName(int counter)
    {
        if (_microchipCache.TryGetValue(counter, out var s))
            return s;
        
        s = string.Concat(counter, 'Y');
        _microchipCache.Add(counter, s);

        return s;
    }
}