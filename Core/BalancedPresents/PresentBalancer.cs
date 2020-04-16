using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.BalancedPresents
{
    public class PresentBalancer
    {
        private readonly int _partitionSum;
        public int QuantumEntanglementOfFirstGroup { get; }

        public PresentBalancer(string input)
        {
            var presents = PuzzleInputReader.Read(input).Select(int.Parse).ToList();
            presents.Reverse();
            var sum = presents.Sum();
            _partitionSum = sum / 3;
            
            var solutions = FindSolutions(presents);
            solutions = solutions.Select(o => o.OrderBy(g => g.Count).ThenBy(g => g.QuantumEntanglement).ToList()).ToList();
            solutions = solutions.OrderBy(o => o.First().Count).ThenBy(o => o.First().QuantumEntanglement).ToList();

            QuantumEntanglementOfFirstGroup = solutions.First().First().QuantumEntanglement;
        }

        private List<List<PresentGroup>> FindSolutions(List<int> allPresents)
        {
            var combinations = new List<List<PresentGroup>>();
            var initialList = new List<PresentGroup> { new PresentGroup() };
            var queue = new Queue<PresentQueueItem>();
            queue.Enqueue(new PresentQueueItem(initialList, allPresents));

            while (queue.Any())
            {
                var currentItem = queue.Dequeue();
                var currentGroup = currentItem.Groups.Last();
                foreach (var present in currentItem.RemainingPresents)
                {
                    var currentSum = currentGroup.Sum;
                    var newSum = currentSum + present;
                    if (newSum <= _partitionSum)
                    {
                        var groupList = currentItem.Groups.Select(o => o.Clone()).ToList();
                        var remainingPresents = currentItem.RemainingPresents.Where(o => o != present).ToList();
                        if (newSum == _partitionSum)
                        {
                            groupList.Last().Add(present);
                            if (remainingPresents.Any())
                            {
                                groupList.Add(new PresentGroup());
                                queue.Enqueue(new PresentQueueItem(groupList, remainingPresents));
                            }
                            else
                            {
                                combinations.Add(groupList);
                            }
                        }
                        else if (newSum < _partitionSum)
                        {
                            groupList.Last().Add(present);
                            queue.Enqueue(new PresentQueueItem(groupList, remainingPresents));
                        }
                    }
                }
            }

            return combinations;
        }
    }
}