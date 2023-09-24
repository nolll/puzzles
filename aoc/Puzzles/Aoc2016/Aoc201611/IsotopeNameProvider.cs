using System.Collections.Generic;

namespace Aoc.Puzzles.Aoc2016.Day11;

public class IsotopeNameProvider
{
    private readonly Dictionary<char, string> _generatorCache = new();
    private readonly Dictionary<char, string> _microchipCache = new();

    public string GetGeneratorName(char name)
    {
        if (_generatorCache.TryGetValue(name, out var s))
            return s;
        
        s = string.Concat(name, 'G');
        _generatorCache.Add(name, s);

        return s;
    }

    public string GetMicrochipName(char name)
    {
        if (_microchipCache.TryGetValue(name, out var s)) 
            return s;
        
        s = string.Concat(name, 'M');
        _microchipCache.Add(name, s);

        return s;
    }
}