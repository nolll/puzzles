using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace ConsoleApp.Puzzles.Year2019.Puzzles.Day07
{
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
            var amp1 = new Amplifier("Amp A", _computerMemory);
            var amp2 = new Amplifier("Amp B", _computerMemory);
            var amp3 = new Amplifier("Amp C", _computerMemory);
            var amp4 = new Amplifier("Amp D", _computerMemory);
            var amp5 = new Amplifier("Amp E", _computerMemory);

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
}
