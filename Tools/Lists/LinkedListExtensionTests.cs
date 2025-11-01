namespace Pzl.Tools.Lists;

public class LinkedListExtensionTests
{
    [Fact]
    public void NextOrFirst()
    {
        var list = new LinkedList<int>();
        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);

        list.First!.NextOrFirst().Value.Should().Be(2);
        list.Last!.NextOrFirst().Value.Should().Be(1);
    }
    
    [Fact]
    public void PreviousOrLast()
    {
        var list = new LinkedList<int>();
        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);

        list.Last!.PreviousOrLast().Value.Should().Be(2);
        list.First!.PreviousOrLast().Value.Should().Be(3);
    }
}