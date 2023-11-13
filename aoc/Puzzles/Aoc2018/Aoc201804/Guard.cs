namespace Puzzles.aoc.Puzzles.Aoc2018.Aoc201804;

public class Guard
{
    public int GuardId { get; }
    public int[] MinuteSleepCounts { get; }

    public Guard(int guardId, List<GuardNight> nights)
    {
        GuardId = guardId;
        MinuteSleepCounts = new int[60];

        foreach (var night in nights)
        {
            for (var i = 0; i < night.MinuteStates.Length; i++)
            {
                if (night.MinuteStates[i] == GuardState.Asleep)
                    MinuteSleepCounts[i]++;
            }
        }
    }

    public int MostSleptMinuteCount => MinuteSleepCounts[MostSleptMinute];

    public int MostSleptMinute
    {
        get
        {
            var mostSleptMinuteCount = 0;
            var mostSleptMinute = 0;
            for (var i = 0; i < MinuteSleepCounts.Length; i++)
            {
                if (MinuteSleepCounts[i] > mostSleptMinuteCount)
                {
                    mostSleptMinuteCount = MinuteSleepCounts[i];
                    mostSleptMinute = i;
                }
            }

            return mostSleptMinute;
        }
    }
}