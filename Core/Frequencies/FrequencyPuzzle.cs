using System.Linq;

namespace Core.Frequencies
{
    public class FrequencyPuzzle
    {
        public int ResultingFrequency { get; }

        public FrequencyPuzzle(string input)
        {
            var changes = FrequencyChangeListReader.Read(input);
            ResultingFrequency = changes.Sum();
        }
    }
}