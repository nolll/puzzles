using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2021;

[Name("Dive!")]
public class Aoc202102 : AocPuzzle
{
    [Puzzle("9d9dec9baf0fe61bbb7a9e95cc1ae2de")]
    public long Part1(string input) => new Submarine().Move(input);

    [Puzzle("6b29326368c507ef0dbbe41523850cd2")]
    public long Part2(string input) => new AimingSubmarine().Move(input);

    public class Submarine
    {
        protected long X;
        protected long Y;

        public long Move(string input)
        {
            var lines = input.Split(LineBreaks.Single);
            foreach (var line in lines)
            {
                var (action, stringValue) = line.Split(' ');
                var value = long.Parse(stringValue);
                Move(action, value);
            }

            return X * Y;
        }

        public virtual void Move(string action, long value)
        {
            if (action == "forward")
                X += value;

            if (action == "down")
                Y += value;

            if (action == "up")
                Y -= value;
        }
    }

    private class AimingSubmarine : Submarine
    {
        private long _aim;
        
        public override void Move(string action, long value)
        {
            if (action == "forward")
            {
                X += value;
                Y += _aim * value;
            }

            if (action == "down")
                _aim += value;

            if (action == "up")
                _aim -= value;
        }
    }
}