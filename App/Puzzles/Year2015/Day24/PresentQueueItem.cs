using System.Collections.Generic;

namespace App.Puzzles.Year2015.Day24;

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

public class PresentQueueItem2
{
    public PresentGroup Group { get; }
    public List<int> RemainingPresents { get; }

    public PresentQueueItem2(PresentGroup group, List<int> remainingPresents)
    {
        Group = @group;
        RemainingPresents = remainingPresents;
    }
}