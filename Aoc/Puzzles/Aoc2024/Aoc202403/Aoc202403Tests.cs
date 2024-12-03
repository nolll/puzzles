using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202403;

public class Aoc202403Tests
{
    [Test]
    public void Part1()
    {
        const string input = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
        
        var result = Sut.Part1(input);
        result.Answer.Should().Be("161");
    }
    
    [Test]
    public void Part2()
    {
        const string input = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";
        
        var result = Sut.Part2(input);
        result.Answer.Should().Be("48");
    }

    private Aoc202403 Sut => new();
}