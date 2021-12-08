using System.Collections.Generic;
using System.Linq;
using App.Common.Strings;

namespace App.Puzzles.Year2021.Day08
{
    public class SevenSegmentDisplayDecoder
    {
        private readonly List<DigitDecoder> _decoders;

        public SevenSegmentDisplayDecoder(string input)
        {
            var lines = PuzzleInputReader.ReadLines(input);
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
}