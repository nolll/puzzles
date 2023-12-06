namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201622;

public struct StorageNode
{
    public int Size { get; }
    public int Used { get; }
    public int Avail { get; }

    public StorageNode(int size, int used, int avail)
    {
        Size = size;
        Used = used;
        Avail = avail;
    }
}