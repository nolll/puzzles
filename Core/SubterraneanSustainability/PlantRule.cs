using System.Linq;

namespace Core.SubterraneanSustainability
{
    public class PlantRule
    {
        public string Pattern { get; }
        public char Result { get; }

        public PlantRule(string s)
        {
            var parts = s.Split(" => ");
            Pattern = parts[0];
            Result = parts[1].First();
        }
    }
}