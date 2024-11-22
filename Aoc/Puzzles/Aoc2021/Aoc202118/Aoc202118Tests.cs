using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202118;

public class Aoc202118Tests
{
    [Test]
    public void Parsing1()
    {
        var number = new SnailfishNumber("[1,2]");

        number.Left.LiteralValue.Should().Be(1);
        number.Right.LiteralValue.Should().Be(2);
    }

    [Test]
    public void Parsing2()
    {
        var number = new SnailfishNumber("[[1,2],3]");

        number.Left.Left.LiteralValue.Should().Be(1);
        number.Left.Right.LiteralValue.Should().Be(2);
        number.Right.LiteralValue.Should().Be(3);
    }

    [Test]
    public void Parsing3()
    {
        var number = new SnailfishNumber("[9,[8,7]]");

        number.Left.LiteralValue.Should().Be(9);
        number.Right.Left.LiteralValue.Should().Be(8);
        number.Right.Right.LiteralValue.Should().Be(7);
    }

    [Test]
    public void Parsing4()
    {
        var number = new SnailfishNumber("[[1,9],[8,5]]");

        number.Left.Left.LiteralValue.Should().Be(1);
        number.Left.Right.LiteralValue.Should().Be(9);
        number.Right.Left.LiteralValue.Should().Be(8);
        number.Right.Right.LiteralValue.Should().Be(5);
    }

    [Test]
    public void Parsing5()
    {
        var number = new SnailfishNumber("[[[[1,2],[3,4]],[[5,6],[7,8]]],9]");

        number.ToString().Should().Be("[[[[1,2],[3,4]],[[5,6],[7,8]]],9]");
        number.Left.Left.Left.Left.LiteralValue.Should().Be(1);
        number.Left.Left.Left.Right.LiteralValue.Should().Be(2);
        number.Left.Left.Right.Left.LiteralValue.Should().Be(3);
        number.Left.Left.Right.Right.LiteralValue.Should().Be(4);
        number.Left.Right.Left.Left.LiteralValue.Should().Be(5);
        number.Left.Right.Left.Right.LiteralValue.Should().Be(6);
        number.Left.Right.Right.Left.LiteralValue.Should().Be(7);
        number.Left.Right.Right.Right.LiteralValue.Should().Be(8);
        number.Right.LiteralValue.Should().Be(9);
    }

    [Test]
    public void Parsing6()
    {
        var number = new SnailfishNumber("[[[9,[3,8]],[[0,9],6]],[[[3,7],[4,9]],3]]");

        number.ToString().Should().Be("[[[9,[3,8]],[[0,9],6]],[[[3,7],[4,9]],3]]");
    }

    [Test]
    public void Parsing7()
    {
        var number = new SnailfishNumber("[[[[1,3],[5,3]],[[1,3],[8,7]]],[[[4,9],[6,9]],[[8,2],[7,3]]]]");

        number.ToString().Should().Be("[[[[1,3],[5,3]],[[1,3],[8,7]]],[[[4,9],[6,9]],[[8,2],[7,3]]]]");
    }

    [Test]
    public void Parsing8()
    {
        var number = new SnailfishNumber("[[[[0,7],4],[5,[0,3]]],[1,1]]");

        number.ToString().Should().Be("[[[[0,7],4],[5,[0,3]]],[1,1]]");
    }

    [Test]
    public void Exploding1()
    {
        var math = new SnailfishMath();
        var number = new SnailfishNumber("[[[[[9,8],1],2],3],4]");
        var result = math.Explode(number);

        result.ToString().Should().Be("[[[[0,9],2],3],4]");
    }

    [Test]
    public void Exploding2()
    {
        var math = new SnailfishMath();
        var number = new SnailfishNumber("[7,[6,[5,[4,[3,2]]]]]");
        var result = math.Explode(number);

        result.ToString().Should().Be("[7,[6,[5,[7,0]]]]");
    }

    [Test]
    public void Exploding3()
    {
        var math = new SnailfishMath();
        var number = new SnailfishNumber("[[3,[2,[1,[7,3]]]],[6,[5,[4,[3,2]]]]]");
        var result = math.Explode(number);

        result.ToString().Should().Be("[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]");
    }

    [Test]
    public void Adding1()
    {
        var math = new SnailfishMath();
        var number1 = new SnailfishNumber("[[[[4,3],4],4],[7,[[8,4],9]]]");
        var number2 = new SnailfishNumber("[1,1]");
        var result = math.Sum(number1, number2);

        result.ToString().Should().Be("[[[[0,7],4],[[7,8],[6,0]]],[8,1]]");
    }

    [Test]
    public void Sum1()
    {
        const string input = """
                             [1,1]
                             [2,2]
                             [3,3]
                             [4,4]
                             [5,5]
                             [6,6]
                             """;

        var math = new SnailfishMath();
        var result = math.Sum(input.Trim());

        result.ToString().Should().Be("[[[[5,0],[7,4]],[5,5]],[6,6]]");
    }

    [Test]
    public void Sum2()
    {
        const string input = """
                             [[[0,[4,5]],[0,0]],[[[4,5],[2,6]],[9,5]]]
                             [7,[[[3,7],[4,3]],[[6,3],[8,8]]]]
                             [[2,[[0,8],[3,4]]],[[[6,7],1],[7,[1,6]]]]
                             [[[[2,4],7],[6,[0,5]]],[[[6,8],[2,8]],[[2,1],[4,5]]]]
                             [7,[5,[[3,8],[1,4]]]]
                             [[2,[2,2]],[8,[8,1]]]
                             [2,9]
                             [1,[[[9,3],9],[[9,0],[0,7]]]]
                             [[[5,[7,4]],7],1]
                             [[[[4,2],2],6],[8,7]]
                             """;

        var math = new SnailfishMath();
        var result = math.Sum(input.Trim());

        result.ToString().Should().Be("[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]");
    }

    [Test]
    public void Magnitude1()
    {
        var math = new SnailfishMath();
        var number = new SnailfishNumber("[[1,2],[[3,4],5]]");

        number.Magnitude.Should().Be(143);
    }

    [Test]
    public void Magnitude2()
    {
        var math = new SnailfishMath();
        var number = new SnailfishNumber("[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]");

        number.Magnitude.Should().Be(3488);
    }

    [Test]
    public void Part1()
    {
        const string input = """
                             [[[0,[5,8]],[[1,7],[9,6]]],[[4,[1,2]],[[1,4],2]]]
                             [[[5,[2,8]],4],[5,[[9,9],0]]]
                             [6,[[[6,2],[5,6]],[[7,6],[4,7]]]]
                             [[[6,[0,7]],[0,9]],[4,[9,[9,0]]]]
                             [[[7,[6,4]],[3,[1,3]]],[[[5,5],1],9]]
                             [[6,[[7,3],[3,2]]],[[[3,8],[5,7]],4]]
                             [[[[5,4],[7,7]],8],[[8,3],8]]
                             [[9,3],[[9,9],[6,[4,9]]]]
                             [[2,[[7,7],7]],[[5,8],[[9,3],[0,2]]]]
                             [[[[5,2],5],[8,[3,7]]],[[5,[7,5]],[4,4]]]
                             """;

        var math = new SnailfishMath();
        var result = math.Sum(input.Trim());

        result.ToString().Should().Be("[[[[6,6],[7,6]],[[7,7],[7,0]]],[[[7,7],[7,7]],[[7,8],[9,9]]]]");
        result.Magnitude.Should().Be(4140);
    }

    [Test]
    public void Part2()
    {
        const string input = """
                             [[[0,[5,8]],[[1,7],[9,6]]],[[4,[1,2]],[[1,4],2]]]
                             [[[5,[2,8]],4],[5,[[9,9],0]]]
                             [6,[[[6,2],[5,6]],[[7,6],[4,7]]]]
                             [[[6,[0,7]],[0,9]],[4,[9,[9,0]]]]
                             [[[7,[6,4]],[3,[1,3]]],[[[5,5],1],9]]
                             [[6,[[7,3],[3,2]]],[[[3,8],[5,7]],4]]
                             [[[[5,4],[7,7]],8],[[8,3],8]]
                             [[9,3],[[9,9],[6,[4,9]]]]
                             [[2,[[7,7],7]],[[5,8],[[9,3],[0,2]]]]
                             [[[[5,2],5],[8,[3,7]]],[[5,[7,5]],[4,4]]]
                             """;

        var math = new SnailfishMath();
        var result = math.LargestMagnitude(input.Trim());

        result.Should().Be(3993);
    }
}