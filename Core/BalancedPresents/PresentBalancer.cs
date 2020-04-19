using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.BalancedPresents
{
    public class PresentBalancer
    {
        private readonly int _partitionSum;
        public long QuantumEntanglementOfFirstGroup { get; }

        public PresentBalancer(string input, int groupCount)
        {
            var presents = PuzzleInputReader.Read(input).Select(int.Parse).ToList();
            presents.Reverse();
            var sum = presents.Sum();
            _partitionSum = sum / groupCount;
            
            var groups = FindGroupsRecursive(new PresentGroup(), presents, 0).ToList();
            groups = groups.OrderBy(o => o.Count).ThenBy(o => o.QuantumEntanglement).ToList();
            QuantumEntanglementOfFirstGroup = groups.First().QuantumEntanglement;

            //var groups = FindGroups(presents);
            //groups = groups.OrderBy(o => o.Count()).ThenBy(GetQuantumEntanglement).ToList();
            //QuantumEntanglementOfFirstGroup = GetQuantumEntanglement(groups.First());
        }

        private IEnumerable<PresentGroup> FindGroupsRecursive(PresentGroup group, List<int> remainingPresents, int level)
        {
            if (level < 6)
            {
                foreach (var present in remainingPresents)
                {
                    var currentSum = group.Sum;
                    var newSum = currentSum + present;
                    if (newSum <= _partitionSum)
                    {
                        var newGroup = group.Clone();
                        var newRemainingPresents = remainingPresents.Where(o => o != present).ToList();
                        newGroup.Add(present);

                        if (newSum == _partitionSum)
                        {
                            yield return newGroup;
                        }

                        if (newSum < _partitionSum)
                        {
                            var subResults = FindGroupsRecursive(newGroup, newRemainingPresents, level + 1);
                            foreach (var result in subResults)
                            {
                                yield return result;
                            }
                        }
                    }
                }
            }
        }

        //private IList<IEnumerable<int>> FindGroups(List<int> presents)
        //{
        //    var groupSize = 2;
        //    while (true)
        //    {
        //        Console.WriteLine($"Group size: {groupSize}");
        //        var groups = PermutationGenerator.GetPermutations(presents, groupSize).ToList();
        //        if (groups.Any())
        //        {
        //            var matchingGroups = groups.Where(o => o.Sum() == _partitionSum).ToList();
        //            if (matchingGroups.Any())
        //                return matchingGroups;
        //        }
        //        groupSize++;
        //    }
        //}

        //private long GetQuantumEntanglement(IEnumerable<int> presents)
        //{
        //    return presents.Aggregate<int, long>(1, (current, present) => current * present);
        //}
    }
}