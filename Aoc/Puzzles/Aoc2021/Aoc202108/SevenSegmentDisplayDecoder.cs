using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202108;

public class SevenSegmentDisplayDecoder
{
    private readonly List<DigitDecoder> _decoders;

    public SevenSegmentDisplayDecoder(string input)
    {
        var lines = StringReader.ReadLines(input);
        _decoders = new List<DigitDecoder>();
        foreach (var line in lines)
        {
            _decoders.Add(new DigitDecoder(line));
        }
    }

    public int GetDecodedSum()
    {
        return _decoders.Sum(o => o.DecodedNumber);
    }

    public int GetEasyNumbers()
    {
        return _decoders.Sum(o => o.EasyNumberCount);
    }
}