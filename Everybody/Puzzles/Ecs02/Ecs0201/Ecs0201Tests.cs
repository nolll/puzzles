using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Ecs02.Ecs0201;

public class Ecs0201Tests
{
    [Test]
    public void Part1()
    {
        const string input = """
                             *.*.*.*.*.*.*.*.*
                             .*.*.*.*.*.*.*.*.
                             *.*.*...*.*...*..
                             .*.*.*.*.*...*.*.
                             *.*.....*...*.*.*
                             .*.*.*.*.*.*.*.*.
                             *...*...*.*.*.*.*
                             .*.*.*.*.*.*.*.*.
                             *.*.*...*.*.*.*.*
                             .*...*...*.*.*.*.
                             *.*.*.*.*.*.*.*.*
                             .*.*.*.*.*.*.*.*.
                             
                             RRRLRLRRRRRL
                             LLLLRLRRRRRR
                             RLLLLLRLRLRL
                             LRLLLRRRLRLR
                             LLRLLRLLLRRL
                             LRLRLLLRRRRL
                             LRLLLLLLRLLL
                             RRLLLRLLRLRR
                             RLLLLLRLLLRL
                             """;

        Sut.Part1(input).Answer.Should().Be("26");
    }

    [Test]
    public void Part2()
    {
        const string input = """
                             *.*.*.*.*.*.*.*.*.*.*.*.*
                             .*.*.*.*.*.*.*.*.*.*.*.*.
                             ..*.*.*.*...*.*...*.*.*..
                             .*...*.*.*.*.*.*.....*.*.
                             *.*...*.*.*.*.*.*...*.*.*
                             .*.*.*.*.*.*.*.*.......*.
                             *.*.*.*.*.*.*.*.*.*...*..
                             .*.*.*.*.*.*.*.*.....*.*.
                             *.*...*.*.*.*.*.*.*.*....
                             .*.*.*.*.*.*.*.*.*.*.*.*.
                             *.*.*.*.*.*.*.*.*.*.*.*.*
                             .*.*.*.*.*.*.*.*.*...*.*.
                             *.*.*.*.*.*.*.*.*...*.*.*
                             .*.*.*.*.*.*.*.*.....*.*.
                             *.*.*.*.*.*.*.*...*...*.*
                             .*.*.*.*.*.*.*.*.*.*.*.*.
                             *.*.*...*.*.*.*.*.*.*.*.*
                             .*...*.*.*.*...*.*.*...*.
                             *.*.*.*.*.*.*.*.*.*.*.*.*
                             .*.*.*.*.*.*.*.*.*.*.*.*.

                             RRRLLRRRLLRLRRLLLRLR
                             RRRRRRRRRRLRRRRRLLRR
                             LLLLLLLLRLRRLLRRLRLL
                             RRRLLRRRLLRLLRLLLRRL
                             RLRLLLRRLRRRLRRLRRRL
                             LLLLLLLLRLLRRLLRLLLL
                             LRLLRRLRLLLLLLLRLRRL
                             LRLLRRLLLRRRRRLRRLRR
                             LRLLRRLRLLRLRRLLLRLL
                             RLLRRRRLRLRLRLRLLRRL
                             """;

        Sut.Part2(input).Answer.Should().Be("115");
    }

    [Test]
    public void Part3()
    {
        const string input = """
                             *.*.*.*.*.*.*.*.*
                             .*.*.*.*.*.*.*.*.
                             *.*.*...*.*...*..
                             .*.*.*.*.*...*.*.
                             *.*.....*...*.*.*
                             .*.*.*.*.*.*.*.*.
                             *...*...*.*.*.*.*
                             .*.*.*.*.*.*.*.*.
                             *.*.*...*.*.*.*.*
                             .*...*...*.*.*.*.
                             *.*.*.*.*.*.*.*.*
                             .*.*.*.*.*.*.*.*.
                             
                             RRRLRLRRRRRL
                             LLLLRLRRRRRR
                             RLLLLLRLRLRL
                             LRLLLRRRLRLR
                             LLRLLRLLLRRL
                             LRLRLLLRRRRL
                             """;

        Sut.Part3(input).Answer.Should().Be("13 43");
    }
    
    private static Ecs0201 Sut => new();
}