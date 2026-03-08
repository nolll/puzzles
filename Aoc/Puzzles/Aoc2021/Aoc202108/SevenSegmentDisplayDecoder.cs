using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202108;

public class SevenSegmentDisplayDecoder
{
    private readonly List<DigitDecoder> _decoders;

    public SevenSegmentDisplayDecoder(string input)
    {
        _decoders = input.Split(LineBreaks.Single).Select(o => new DigitDecoder(o)).ToList();
    }

    public int GetDecodedSum() => _decoders.Sum(o => o.DecodedNumber);
    public int GetEasyNumbers() => _decoders.Sum(o => o.EasyNumberCount);
}