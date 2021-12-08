using System.Collections.Generic;
using System.Linq;
using Core.Common.Strings;
using Core.Platform;
using NUnit.Framework.Constraints;

namespace Core.Puzzles.Year2021.Day08
{
    public class Year2021Day08 : Year2021Day
    {
        
        public override int Day => 8;

        public override PuzzleResult RunPart1()
        {
            var decoder = new SevenSegmentDisplayDecoder(FileInput);
            var result = decoder.GetEasyNumbers();
            return new PuzzleResult(result, 278);
        }

        public override PuzzleResult RunPart2()
        {
            var decoder = new SevenSegmentDisplayDecoder(FileInput);
            var result = decoder.GetDecodedSum();
            return new PuzzleResult(result);
        }
    }

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
            return 0;
        }

        public int GetEasyNumbers()
        {
            return _decoders.Sum(o => o.EasyNumberCount);
        }
    }

    public class DigitDecoder
    {
        private readonly List<string> _signals;
        private readonly List<string> _output;

        public DigitDecoder(string input)
        {
            var parts = input.Split('|');
            _signals = parts[0].Trim().Split(' ').Select(o => string.Concat(o.OrderBy(c => c))).Distinct().ToList();
            _output = parts[1].Trim().Split(' ').Select(o => string.Concat(o.OrderBy(c => c))).ToList();
        }

        public int EasyNumberCount
        {
            get
            {
                var c = 0;
                foreach (var i in _output)
                {
                    var length = i.Length;
                    if (length == 2 || length == 3 || length == 4 || length == 7)
                        c++;
                }

                return c;
            }
        }

        public int DecodedNumber
        {
            get
            {
                var segmentCount = new Dictionary<int, int>
                {
                    {0, 6},
                    {1, 2},
                    {2, 5},
                    {3, 5},
                    {4, 4},
                    {5, 5},
                    {6, 6},
                    {7, 3},
                    {8, 7},
                    {9, 6}
                };

                var s = new Dictionary<int, string>
                {
                    {1, _signals.First(o => o.Length == segmentCount[1])},
                    {4, _signals.First(o => o.Length == segmentCount[4])},
                    {7, _signals.First(o => o.Length == segmentCount[7])},
                    {8, _signals.First(o => o.Length == segmentCount[8])},
                };

                var zerosSixesOrNines = _signals.First(o => o.Length == 6);
                var twosThreesOrFives = _signals.First(o => o.Length == 5);

                var segmentChars = new Dictionary<int, string>
                {
                    {1, null},
                    {2, null},
                    {3, null},
                    {4, null},
                    {5, null},
                    {6, null},
                    {7, null}
                };

                if (s[1] != null && s[7] != null)
                {
                    var diff = s[7].Replace(s[1], "");
                    segmentChars[1] = diff;
                }
                
                
// Segements
//  1111 
// 2    3
// 2    3
//  4444 
// 5    6
// 5    6
//  7777 
//

                return 0;
            }
        }
    }
}