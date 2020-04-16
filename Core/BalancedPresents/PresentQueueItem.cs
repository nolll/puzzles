using System.Collections.Generic;

namespace Core.BalancedPresents
{
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
}