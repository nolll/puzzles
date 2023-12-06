using Pzl.Tools.Combinatorics;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201907;

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