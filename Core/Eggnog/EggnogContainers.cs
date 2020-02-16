using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.Eggnog
{
    public class EggnogContainers
    {
        private readonly List<EggnogContainer> _containers;

        public EggnogContainers(string input)
        {
            _containers = PuzzleInputReader.Read(input).Select((o, index) => new EggnogContainer(index, int.Parse((string) o))).ToList();
        }
        
        public IList<List<EggnogContainer>> GetCombinations(int targetVolume)
        {
            var combinations = CombinationGenerator.GetAllCombinations(_containers);
            return combinations.Where(o => o.Sum(c => c.Volume) == targetVolume).ToList();
        }

        public IList<List<EggnogContainer>> GetCombinationsWithLeastContainers(int targetVolume)
        {
            var combinations = GetCombinations(targetVolume).OrderBy(o => o.Count).ToList();
            var smallestCount = combinations.First().Count;
            return combinations.Where(o => o.Count == smallestCount).ToList();
        }
    }
}