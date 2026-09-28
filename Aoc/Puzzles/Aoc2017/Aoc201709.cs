using System.Text;
using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("Stream Processing")]
public class Aoc201709 : AocPuzzle
{
    [Puzzle("bf1171e2cba9455c97359e9a72e8586f")]
    public int Part1(string input) => new StreamProcessor(input).Score;

    [Puzzle("ff9d742fc8ce537c4cc9bfc6414c7ed6")]
    public int Part2(string input) => new StreamProcessor(input).GarbageCount;

    public class StreamProcessor
    {
        public int GroupCount { get; }
        public string Cleaned { get; }
        public int Score { get; }
        public int GarbageCount { get; }

        public StreamProcessor(string input)
        {
            var removeResult = RemoveGarbage(input);
            Cleaned = removeResult.Cleaned;
            GarbageCount = removeResult.Removed;
            GroupCount = removeResult.Cleaned.Count(o => o == '}');
            Score = GetScore(removeResult.Cleaned);
        }

        private int GetScore(string cleaned)
        {
            var totalScore = 0;
            var currentScore = 0;
            foreach (var c in cleaned)
            {
                if (c == '{')
                {
                    currentScore += 1;
                }

                if (c == '}')
                {
                    totalScore += currentScore;
                    currentScore -= 1;
                }
            }

            return totalScore;
        }

        private RemoveResult RemoveGarbage(string input)
        {
            var removeCount = 0;
            var cleaned = new StringBuilder();
            var isInGarbage = false;
            var isInIgnored = false;
            for (var i = 0; i < input.Length; i++)
            {
                var c = input[i];

                if (isInGarbage)
                {
                    if (isInIgnored)
                        isInIgnored = false;
                    else if (c == '!')
                        isInIgnored = true;
                    else if (c == '>')
                        isInGarbage = false;
                    else
                        removeCount += 1;
                }
                else
                {
                    if (c == '<')
                        isInGarbage = true;
                    else
                        cleaned.Append(c);
                }
            }

            return new RemoveResult(cleaned.ToString(), removeCount);
        }

        private record RemoveResult(string Cleaned, int Removed);
    }
}