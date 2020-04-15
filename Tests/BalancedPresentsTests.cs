using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class BalancedPresentsTests
    {
        [Test]
        public void QuantumEntanglementOfFirstGroupIsCorrect()
        {
            var weights = new[] { 1, 2, 3, 4, 5, 7, 8, 9, 10, 11 };

            var balancer = new PresentBalancer(weights.ToList());

            Assert.That(balancer.QuantumEntanglementOfFirstGroup, Is.EqualTo(99));
        }
    }

    public class PresentBalancer
    {
        private int _partitionSum;
        public int QuantumEntanglementOfFirstGroup { get; }

        public PresentBalancer(IList<int> presents)
        {
            var sum = presents.Sum();
            _partitionSum = sum / 3;

            var solutions = FindSolutions(presents);
        }

        private List<List<PresentGroup>> FindSolutions(IList<int> allPresents)
        {
            var initialList = new List<PresentGroup> { new PresentGroup() };
            var combinations = new List<List<PresentGroup>>();

            var queue = new Queue<PresentQueueItem>();

            while (queue.Any())
            {
                var currentItem = queue.Dequeue();
                foreach (var present in currentItem.RemainingPresents)
                {
                    var currentList = 
                    if()
                }
            }
        }

        private IList<PresentGroup> FindRecursive(IList<PresentGroup> groups, IList<int> remainingPresents)
        {
            
        }
    }

    public class PresentQueueItem
    {
        public List<PresentGroup> Groups { get; }
        public List<int> RemainingPresents { get; }

        public PresentQueueItem(List<PresentGroup> groups, List<int> remainingPresents)
        {
            Groups = groups;
            RemainingPresents = remainingPresents;
        }
    }

    public class PresentGroup
    {
        private List<int> _presents;

        public PresentGroup()
        {
            _presents = new List<int>();
        }

        public void Add(int i)
        {
            _presents.Add(i);
        }
    }
}