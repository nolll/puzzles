using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Tools.State;

public class BitStateHandlerTests
{
    [Test]
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
    
    [Test]
    public void MaxValue()
    {
        var sut = new BitStateHandler("abcd");
        sut.MaxValue.Should().Be(15);
    }

    [Test]
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