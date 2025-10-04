using FluentAssertions;

namespace Pzl.Aquaq.Puzzles.Aquaq08;

public class Aquaq08Tests
{
    [Fact]
    public void DaySixState()
    {
        var result = Aquaq08.RunInternal(Input);

        result.milk.Should().Be(1600);
        result.cereal.Should().Be(600);
    }

    private const string Input = """
                                 date,milk,cereal
                                 2016-01-26,1000,1000
                                 2016-01-27,0,0
                                 2016-01-28,0,0
                                 2016-01-29,0,0
                                 2016-01-30,1000,0
                                 """;
}