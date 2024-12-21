using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202421;

public class Aoc202421Tests
{
    //[Test]
    //public void Part1_FirstLevel()
    //{
    //    const string input = "029A";
    //
    //    Sut.Part1(input).Answer.Length.Should().Be("<A^A>^^AvvvA".Length);
    //}
    
    [Test]
    public void Part1_ThirdLevel()
    {
        const string input = "029A";

        Sut.Part1(input).Answer.Length.Should().Be("<vA<AA>>^AvAA<^A>A<v<A>>^AvA^A<vA>^A<v<A>^A>AAvA^A<v<A>A>^AAAvA<^A>A".Length);
    }

    //[Test]
    //public void Part1_SecondLevel()
    //{
    //    const string input = "029A";
    //
    //    Sut.Part1(input).Answer.Length.Should().Be("v<<A>>^A<A>AvA<^AA>A<vAAA>^A".Length);
    //}

    [Test]
    public void Part2()
    {
        const string input = "";

        Sut.Part2(input).Answer.Should().Be("0");
    }

    private static Aoc202421 Sut => new();
}