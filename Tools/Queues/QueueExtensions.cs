namespace Pzl.Tools.Queues;

public static class QueueExtensions
{
    public static void Enqueue<T>(this Queue<T> queue, IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            queue.Enqueue(item);
        }
    }
}