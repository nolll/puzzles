using Pzl.Common;
using Pzl.Tools.Combinatorics;
using Pzl.Tools.Computers.IntCode;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("Amplification Circuit")]
public class Aoc201907 : AocPuzzle
{
    [Puzzle("2fbd6d244a35bf75a6d51c8962133afe")]
    public long Part1(string input) => GetMaxThrust(input, [0, 1, 2, 3, 4]);

    [Puzzle("af273de2fc8e4b54d4d877645ded2d03")]
    public long Part2(string input) => GetMaxThrust(input, [5, 6, 7, 8, 9]);

    public IEnumerable<Amplifier> CreateAmplifiers(string memory)
    {
        var amp1 = new Amplifier(memory);
        var amp2 = new Amplifier(memory);
        var amp3 = new Amplifier(memory);
        var amp4 = new Amplifier(memory);
        var amp5 = new Amplifier(memory);

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

    private long GetMaxThrust(string memory, int[] phases)
    {
        var sequences = PermutationGenerator.GetPermutations(phases);
        long highestThrust = 0;
        foreach (var sequence in sequences)
        {
            var amplifiers = CreateAmplifiers(memory).ToList();
            var thrust = GetThrust(amplifiers, [.. sequence]);
            if (thrust > highestThrust)
                highestThrust = thrust;
        }

        return highestThrust;
    }

    public long GetThrust(List<Amplifier> amplifiers, int[] sequence)
    {
        for (var i = 0; i < 5; i++)
        {
            amplifiers[i].Phase = sequence[i];
        }

        amplifiers[0].Start(0);
        return amplifiers[4].Output;
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
            if (_isStarted)
                _computer.Resume();
            else
                _computer.Start();
        }
    }
}