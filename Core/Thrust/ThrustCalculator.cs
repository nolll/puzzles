using System.Collections.Generic;
using System.Linq;

namespace Core.Thrust
{
    public class ThrustCalculator
    {
        private readonly string _computerMemory;
        private readonly List<Amplifier> _amplifiers;

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

            yield return amp1;
            yield return amp2;
            yield return amp3;
            yield return amp4;
            yield return amp5;
        }

        public int GetMaxThrust(int[] phases)
        {
            var sequences = new SequenceGenerator().GetSequences(phases);
            var highestThrust = 0;
            foreach (var sequence in sequences)
            {
                var thrust = GetThrust(sequence.ToArray());
                if (thrust > highestThrust)
                    highestThrust = thrust;
            }

            return highestThrust;
        }

        public int GetThrust(int[] sequence)
        {
            for (var i = 0; i < 5; i++)
            {
                _amplifiers[i].Phase = sequence[i];
            }

            return _amplifiers[0].GetOutput(0);
        }
    }
}
