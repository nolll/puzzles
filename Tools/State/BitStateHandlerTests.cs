namespace Pzl.Tools.State;

public class BitStateHandlerTests
{
    [Fact]
    public void IsAllMarked()
    {
        var sut = new BitStateHandler("abcd");
        var state = 0L;
        state = sut.MarkValue(state, 'a');
        state = sut.MarkValue(state, 'b');
        state = sut.MarkValue(state, 'c');
        state = sut.MarkValue(state, 'd');
        sut.IsAllMarked(state).Should().BeTrue();
    }
    
    [Fact]
    public void MaxValue()
    {
        var sut = new BitStateHandler("abcd");
        sut.MaxValue.Should().Be(15);
    }

    [Fact]
    public void IsMarked()
    {
        var sut = new BitStateHandler("abcd");
        var state = 0L;
        state = sut.MarkValue(state, 'a');
        state = sut.MarkValue(state, 'c');
        sut.IsMarked(state, 'a').Should().BeTrue();
        sut.IsMarked(state, 'b').Should().BeFalse();
        sut.IsMarked(state, 'c').Should().BeTrue();
        sut.IsMarked(state, 'd').Should().BeFalse();
    }
}