using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            return new PuzzleResult(result, 986179);
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
            return _decoders.Sum(o => o.DecodedNumber);
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
                var s = new Dictionary<int, string>
                {
                    {0, null},
                    {1, _signals.First(o => o.Length == 2)},
                    {2, null},
                    {3, null},
                    {4, _signals.First(o => o.Length == 4)},
                    {5, null},
                    {6, null},
                    {7, _signals.First(o => o.Length == 3)},
                    {8, _signals.First(o => o.Length == 7)},
                    {9, null},
                };

                var zerosSixesOrNines = _signals.Where(o => o.Length == 6).ToList();
                var twosThreesOrFives = _signals.Where(o => o.Length == 5).ToList();

                s[3] = twosThreesOrFives.FirstOrDefault(o =>
                {
                    var reduced = Reduce(s[7], o);
                    if (reduced != null && reduced.Length == 2)
                        return true;

                    return false;
                });
                var twosOrFives = twosThreesOrFives.Where(o => o != s[3]).ToList();

                s[6] = zerosSixesOrNines.First(o => Reduce(s[1], o) == null);
                
                var zerosOrNines = zerosSixesOrNines.Where(o => o != s[6]).ToList();
                s[9] = zerosSixesOrNines.First(o => Reduce(s[3], o) != null);
                s[0] = zerosOrNines.First(o => o != s[9]);
                s[5] = twosOrFives.First(o => Reduce(o, s[9]) != null);
                s[2] = twosOrFives.First(o => o != s[5]);
                var d = s.Keys.ToDictionary(key => s[key]);

                var digits = _output.Select(o => d[o].ToString());
                var str = string.Join("", digits);

                return int.Parse(str);
            }
        }

        public string Reduce(string sShort, string sLong)
        {
            if (!IsContainedIn(sShort, sLong))
                return null;
            
            var sb = new StringBuilder();
            foreach (var s in sLong)
            {
                if (sShort.IndexOf(s) == -1)
                    sb.Append(s);
            }

            return sb.ToString();
        }

        public bool IsContainedIn(string sShort, string sLong)
        {
            foreach (var s in sShort)
            {
                if (sLong.IndexOf(s) == -1)
                    return false;
            }

            return true;
        }
    }
}