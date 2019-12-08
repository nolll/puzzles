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
            for (var i = 0; i < 5; i++)
                yield return new Amplifier(_computerMemory);
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
            var thrust = 0;
            for (var i = 0; i < 5; i++)
            {
                thrust = _amplifiers[i].GetOutput(sequence[i], thrust);
            }

            return thrust;
        }
    }
}
