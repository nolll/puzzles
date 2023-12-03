namespace Puzzles.Aquaq.Puzzles.Aquaq34;

public class WaitingTrainComparer : IComparer<Train>
{
    public int Compare(Train? a, Train? b)
    {
        if (a is null || b is null)
            return 0;

        if (a.LastStation is null || b.LastStation is null)
            return CompareOriginatingTrains(a, b);

        return CompareOtherTrains(a, b);
    }

    private static int CompareOriginatingTrains(Train a, Train b)
    {
        if (a.LastStation is null && b.LastStation is not null)
            return -1;

        if (a.LastStation is not null && b.LastStation is null)
            return 1;

        var startStationCompare = string.Compare(a.StartStation?.Name, b.StartStation?.Name, StringComparison.Ordinal);
        
        return startStationCompare != 0 
            ? startStationCompare 
            : a.RouteId.CompareTo(b.RouteId);
    }

    private static int CompareOtherTrains(Train a, Train b)
    {
        var lastStationCompare = string.Compare(a.LastStation?.Name, b.LastStation?.Name, StringComparison.Ordinal);
        
        return lastStationCompare != 0 
            ? lastStationCompare 
            : b.TimeWaited.CompareTo(a.TimeWaited);
    }
}