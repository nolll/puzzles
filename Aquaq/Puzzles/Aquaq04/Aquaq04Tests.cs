using FluentAssertions;

namespace Pzl.Aquaq.Puzzles.Aquaq04;

public class Aquaq04Tests
{
    [Fact]
    public void FindCoPrimes()
    {
        var result = Aquaq04.FindCoPrimesFor(15).ToArray();

        result.Length.Should().Be(8);
        result[0].Should().Be(1);
        result[1].Should().Be(2);
        result[2].Should().Be(4);
        result[3].Should().Be(7);
        result[4].Should().Be(8);
        result[5].Should().Be(11);
        result[6].Should().Be(13);
        result[7].Should().Be(14);
    }
}