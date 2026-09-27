using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2016;

[Name("Scrambled Letters and Hash")]
public class Aoc201621 : AocPuzzle
{
    [Puzzle("d23262df6c0ae121dad862c4941b0e84")]
    public string Part1(string input) => new StringScrambler(input).Scramble("abcdefgh");

    [Puzzle("c7601768c42b9f9aa8cbb994da21b9fd")]
    public string Part2(string input) => new StringScrambler(input).Unscramble("fbgdceah");
    
    public interface IScrambleInstruction
    {
        string Run(string s);
        string RunBackwards(string s);
    }
    
    public class MoveInstruction(int from, int to) : IScrambleInstruction
    {
        public string Run(string s) => Move(s, from, to);
        public string RunBackwards(string s) => Move(s, to, from);

        private string Move(string s, int from, int to)
        {
            var letters = s.ToList();
            var letterToMove = s.Skip(from).Take(1).First();
            letters.RemoveAt(from);
            letters.Insert(to, letterToMove);
            return string.Concat(letters);
        }
    }
    
    public class ReverseInstruction(int from, int to) : IScrambleInstruction
    {
        public string Run(string s) => Reverse(s);
        public string RunBackwards(string s) => Reverse(s);

        private string Reverse(string s)
        {
            var letters = s.ToList();
            var startRange = letters.Take(from);
            var endRange = letters.Skip(to + 1);
            var range = letters.Skip(from).Take(to + 1 - from);
            return string.Concat(startRange.Concat(range.Reverse()).Concat(endRange).ToList());
        }
    }
    
    public class RotateBasedOnPositionInstruction(char letter) : RotateInstruction
    {
        public override string Run(string s)
        {
            var steps = GetSteps(s);
            return RotateRight(s, steps);
        }

        public override string RunBackwards(string s)
        {
            for (var i = 1; i <= s.Length; i++)
            {
                var rotated = RotateLeft(s, i);
                var steps = GetSteps(rotated);
                var rotatedBack = RotateRight(rotated, steps);
                if (rotatedBack == s)
                    return rotated;
            }

            return s;
        }

        private int GetSteps(string s)
        {
            var steps = s.IndexOf(letter);
            if (steps >= 4)
                steps++;
            return steps + 1;
        }
    }
    
    public abstract class RotateInstruction : IScrambleInstruction
    {
        public abstract string Run(string s);
        public abstract string RunBackwards(string s);

        protected string RotateRight(string s, int steps)
        {
            var letters = s.ToList();
            for (var i = 0; i < steps; i++)
            {
                var letterToMove = letters.Last();
                letters.RemoveAt(letters.Count - 1);
                letters.Insert(0, letterToMove);
            }

            return string.Concat(letters);
        }

        protected string RotateLeft(string s, int steps)
        {
            var letters = s.ToList();
            for (var i = 0; i < steps; i++)
            {
                var letterToMove = letters.First();
                letters.RemoveAt(0);
                letters.Add(letterToMove);
            }

            return string.Concat(letters);
        }
    }
    
    public class RotateLeftInstruction(int steps) : RotateInstruction
    {
        public override string Run(string s) => RotateLeft(s, steps);
        public override string RunBackwards(string s) => RotateRight(s, steps);
    }
    
    public class RotateRightInstruction(int steps) : RotateInstruction
    {
        public override string Run(string s) => RotateRight(s, steps);
        public override string RunBackwards(string s) => RotateLeft(s, steps);
    }
    
    public class StringScrambler(string input)
    {
        private readonly IList<IScrambleInstruction> _instructions = ParseInstructions(input);

        public string Scramble(string str)
        {
            foreach (var instruction in _instructions)
                str = instruction.Run(str);

            return str;
        }
    
        public string Unscramble(string str)
        {
            foreach (var instruction in _instructions.Reverse())
                str = instruction.RunBackwards(str);

            return str;
        }

        private static IList<IScrambleInstruction> ParseInstructions(string input) => 
            input.Split(LineBreaks.Single).Select(ParseInstruction).ToList();

        private static IScrambleInstruction ParseInstruction(string s)
        {
            var parts = s.Split(' ');
            var command = parts[0];
            if (command == "swap")
            {
                return parts[1] == "position"
                    ? new SwapPositionInstruction(int.Parse(parts[2]), int.Parse(parts[5]))
                    : new SwapLetterInstruction(parts[2].First(), parts[5].First());
            }

            if (command == "rotate")
            {
                var type = parts[1];
                if (type == "left")
                    return new RotateLeftInstruction(int.Parse(parts[2]));

                if (type == "right")
                    return new RotateRightInstruction(int.Parse(parts[2]));

                if (type == "based")
                    return new RotateBasedOnPositionInstruction(parts[6].First());
            }

            if (command == "reverse")
                return new ReverseInstruction(int.Parse(parts[2]), int.Parse(parts[4]));

            if (command == "move")
                return new MoveInstruction(int.Parse(parts[2]), int.Parse(parts[5]));

            throw new Exception($"Error parsing instruction: {s}");
        }
    }
    
    public class SwapLetterInstruction(char a, char b) : IScrambleInstruction
    {
        public string Run(string s) => Swap(s);
        public string RunBackwards(string s) => Swap(s);

        private string Swap(string s)
        {
            var letters = s.ToList();
            var letterAPos = letters.IndexOf(a);
            var letterBPos = letters.IndexOf(b);
            letters[letterAPos] = b;
            letters[letterBPos] = a;
            return string.Concat(letters);
        }
    }
    
    public class SwapPositionInstruction(int from, int to) : IScrambleInstruction
    {
        public string Run(string s) => Swap(s);
        public string RunBackwards(string s) => Swap(s);

        private string Swap(string s)
        {
            var letters = s.ToList();
            var letterA = letters[from];
            var letterB = letters[to];
            letters[from] = letterB;
            letters[to] = letterA;
            return string.Concat(letters);
        }
    }
}