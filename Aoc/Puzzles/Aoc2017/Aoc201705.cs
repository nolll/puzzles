using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("A Maze of Twisty Trampolines, All Alike")]
public class Aoc201705 : AocPuzzle
{
    [Puzzle("3893f5208a5bb1ed3716ffb10c7074d1")]
    public int Part1(string input)
    {
        var jumper1 = new InstructionJumper(input);
        jumper1.Start1();
        return jumper1.StepCount;
    }

    [Puzzle("e9b390d2f610956da9f592bc52c789cc")]
    public int Part2(string input)
    {
        var jumper2 = new InstructionJumper(input);
        jumper2.Start2();
        return jumper2.StepCount;
    }
    
    public class InstructionJumper
    {
        private int _index;
        private readonly List<int> _numbers;
        private bool IsInRange => _index >= 0 && _index < _numbers.Count;

        public int StepCount { get; private set; }

        public InstructionJumper(string input)
        {
            StepCount = 0;
            _numbers = input.Trim().Split('\n').Select(o => int.Parse((string) o.Trim())).ToList();
        }

        public void Start1()
        {
            while (IsInRange)
            {
                var val = _numbers[_index];
                _numbers[_index] = val + 1;
                _index += val;
                StepCount += 1;
            }
        }

        public void Start2()
        {
            while (IsInRange)
            {
                var val = _numbers[_index];
                var change = val >= 3 ? -1 : 1;
                _numbers[_index] = val + change;
                _index += val;
                StepCount += 1;
            }
        }
    }
}