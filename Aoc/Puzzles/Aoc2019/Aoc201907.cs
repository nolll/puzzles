using Pzl.Common;
using Pzl.Tools.Combinatorics;
using Pzl.Tools.Computers.IntCode;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("Amplification Circuit")]
public class Aoc201907 : AocPuzzle
{
    [Puzzle("2fbd6d244a35bf75a6d51c8962133afe")]
    public long Part1(string input) => new ThrustCalculator(input).GetMaxThrust([0, 1, 2, 3, 4]);

    [Puzzle("af273de2fc8e4b54d4d877645ded2d03")]
    public long Part2(string input) => new ThrustCalculator(input).GetMaxThrust([5, 6, 7, 8, 9]);
    
    public class ThrustCalculator
    {
        private readonly string _computerMemory;
        private List<Amplifier> _amplifiers;

        public ThrustCalculator(string computerMemory)
        {
            _computerMemory = computerMemory;
            _amplifiers = CreateAmplifiers().ToList();
        }

        private IEnumerable<Amplifier> CreateAmplifiers()
        {
            var amp1 = new Amplifier(_computerMemory);
            var amp2 = new Amplifier(_computerMemory);
            var amp3 = new Amplifier(_computerMemory);
            var amp4 = new Amplifier(_computerMemory);
            var amp5 = new Amplifier(_computerMemory);

            amp1.NextAmp = amp2;
            amp2.NextAmp = amp3;
            amp3.NextAmp = amp4;
            amp4.NextAmp = amp5;
            amp5.NextAmp = amp1;

            yield return amp1;
            yield return amp2;
            yield return amp3;
            yield return amp4;
            yield return amp5;
        }

        public long GetMaxThrust(int[] phases)
        {
            var sequences = PermutationGenerator.GetPermutations(phases);
            long highestThrust = 0;
            foreach (var sequence in sequences)
            {
                _amplifiers = CreateAmplifiers().ToList();
                var thrust = GetThrust(sequence.ToArray());
                if (thrust > highestThrust)
                    highestThrust = thrust;
            }

            return highestThrust;
        }

        public long GetThrust(int[] sequence)
        {
            for (var i = 0; i < 5; i++)
            {
                _amplifiers[i].Phase = sequence[i];
            }

            _amplifiers[0].Start(0);
            return _amplifiers[4].Output;
        }
    }
    
    public class Amplifier
    {
        private long _input;
        private bool _isStarted;
        private readonly IntCodeComputer _computer;

        public Amplifier? NextAmp { get; set; }
        public int Phase { get; set; }
        public long Output { get; private set; }

        public Amplifier(string memory)
        {
            _computer = new IntCodeComputer(memory, ComputerInput, ComputerOutput);
        }

        private long ComputerInput()
        {
            if (_isStarted)
                return _input;
            _isStarted = true;
            return Phase;
        }

        private bool ComputerOutput(long output)
        {
            Output = output;
            NextAmp?.Start(output);
            return true;
        }

        public void Start(long input)
        {
            _input = input;
            if(_isStarted)
                _computer.Resume();
            else
                _computer.Start();
        }
    }
}