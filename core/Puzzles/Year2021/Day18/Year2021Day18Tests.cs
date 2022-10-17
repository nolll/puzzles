using NUnit.Framework;

namespace Core.Puzzles.Year2021.Day18;

public class Year2021Day18Tests
{
    [Test]
    public void Parsing1()
    {
        var number = new SnailfishNumber("[1,2]");

        Assert.That(number.Left.LiteralValue, Is.EqualTo(1));
        Assert.That(number.Right.LiteralValue, Is.EqualTo(2));
    }

    [Test]
    public void Parsing2()
    {
        var number = new SnailfishNumber("[[1,2],3]");

        Assert.That(number.Left.Left.LiteralValue, Is.EqualTo(1));
        Assert.That(number.Left.Right.LiteralValue, Is.EqualTo(2));
        Assert.That(number.Right.LiteralValue, Is.EqualTo(3));
    }

    [Test]
    public void Parsing3()
    {
        var number = new SnailfishNumber("[9,[8,7]]");

        Assert.That(number.Left.LiteralValue, Is.EqualTo(9));
        Assert.That(number.Right.Left.LiteralValue, Is.EqualTo(8));
        Assert.That(number.Right.Right.LiteralValue, Is.EqualTo(7));
    }

    [Test]
    public void Parsing4()
    {
        var number = new SnailfishNumber("[[1,9],[8,5]]");

        Assert.That(number.Left.Left.LiteralValue, Is.EqualTo(1));
        Assert.That(number.Left.Right.LiteralValue, Is.EqualTo(9));
        Assert.That(number.Right.Left.LiteralValue, Is.EqualTo(8));
        Assert.That(number.Right.Right.LiteralValue, Is.EqualTo(5));
    }

    [Test]
    public void Parsing5()
    {
        var number = new SnailfishNumber("[[[[1,2],[3,4]],[[5,6],[7,8]]],9]");

        Assert.That(number.ToString(), Is.EqualTo("[[[[1,2],[3,4]],[[5,6],[7,8]]],9]"));
        Assert.That(number.Left.Left.Left.Left.LiteralValue, Is.EqualTo(1));
        Assert.That(number.Left.Left.Left.Right.LiteralValue, Is.EqualTo(2));
        Assert.That(number.Left.Left.Right.Left.LiteralValue, Is.EqualTo(3));
        Assert.That(number.Left.Left.Right.Right.LiteralValue, Is.EqualTo(4));
        Assert.That(number.Left.Right.Left.Left.LiteralValue, Is.EqualTo(5));
        Assert.That(number.Left.Right.Left.Right.LiteralValue, Is.EqualTo(6));
        Assert.That(number.Left.Right.Right.Left.LiteralValue, Is.EqualTo(7));
        Assert.That(number.Left.Right.Right.Right.LiteralValue, Is.EqualTo(8));
        Assert.That(number.Right.LiteralValue, Is.EqualTo(9));
    }

    [Test]
    public void Parsing6()
    {
        var number = new SnailfishNumber("[[[9,[3,8]],[[0,9],6]],[[[3,7],[4,9]],3]]");

        Assert.That(number.ToString(), Is.EqualTo("[[[9,[3,8]],[[0,9],6]],[[[3,7],[4,9]],3]]"));
    }

    [Test]
    public void Parsing7()
    {
        var number = new SnailfishNumber("[[[[1,3],[5,3]],[[1,3],[8,7]]],[[[4,9],[6,9]],[[8,2],[7,3]]]]");

        Assert.That(number.ToString(), Is.EqualTo("[[[[1,3],[5,3]],[[1,3],[8,7]]],[[[4,9],[6,9]],[[8,2],[7,3]]]]"));
    }

    [Test]
    public void Parsing8()
    {
        var number = new SnailfishNumber("[[[[0,7],4],[5,[0,3]]],[1,1]]");

        Assert.That(number.ToString(), Is.EqualTo("[[[[0,7],4],[5,[0,3]]],[1,1]]"));
    }

    [Test]
    public void Exploding1()
    {
        var math = new SnailfishMath();
        var number = new SnailfishNumber("[[[[[9,8],1],2],3],4]");
        var result = math.Explode(number);

        Assert.That(result.ToString(), Is.EqualTo("[[[[0,9],2],3],4]"));
    }

    [Test]
    public void Exploding2()
    {
        var math = new SnailfishMath();
        var number = new SnailfishNumber("[7,[6,[5,[4,[3,2]]]]]");
        var result = math.Explode(number);

        Assert.That(result.ToString(), Is.EqualTo("[7,[6,[5,[7,0]]]]"));
    }

    [Test]
    public void Exploding3()
    {
        var math = new SnailfishMath();
        var number = new SnailfishNumber("[[3,[2,[1,[7,3]]]],[6,[5,[4,[3,2]]]]]");
        var result = math.Explode(number);

        Assert.That(result.ToString(), Is.EqualTo("[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]"));
    }

    [Test]
    public void Adding1()
    {
        var math = new SnailfishMath();
        var number1 = new SnailfishNumber("[[[[4,3],4],4],[7,[[8,4],9]]]");
        var number2 = new SnailfishNumber("[1,1]");
        var result = math.Sum(number1, number2);

        Assert.That(result.ToString(), Is.EqualTo("[[[[0,7],4],[[7,8],[6,0]]],[8,1]]"));
    }

    [Test]
    public void Sum1()
    {
        const string input = @"
[1,1]
[2,2]
[3,3]
[4,4]
[5,5]
[6,6]";

        var math = new SnailfishMath();
        var result = math.Sum(input.Trim());

        Assert.That(result.ToString(), Is.EqualTo("[[[[5,0],[7,4]],[5,5]],[6,6]]"));
    }

    [Test]
    public void Sum2()
    {
        const string input = @"
[[[0,[4,5]],[0,0]],[[[4,5],[2,6]],[9,5]]]
[7,[[[3,7],[4,3]],[[6,3],[8,8]]]]
[[2,[[0,8],[3,4]]],[[[6,7],1],[7,[1,6]]]]
[[[[2,4],7],[6,[0,5]]],[[[6,8],[2,8]],[[2,1],[4,5]]]]
[7,[5,[[3,8],[1,4]]]]
[[2,[2,2]],[8,[8,1]]]
[2,9]
[1,[[[9,3],9],[[9,0],[0,7]]]]
[[[5,[7,4]],7],1]
[[[[4,2],2],6],[8,7]]";

        var math = new SnailfishMath();
        var result = math.Sum(input.Trim());

        Assert.That(result.ToString(), Is.EqualTo("[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]"));
    }

    [Test]
    public void Magnitude1()
    {
        var math = new SnailfishMath();
        var number = new SnailfishNumber("[[1,2],[[3,4],5]]");

        Assert.That(number.Magnitude, Is.EqualTo(143));
    }

    [Test]
    public void Magnitude2()
    {
        var math = new SnailfishMath();
        var number = new SnailfishNumber("[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]");

        Assert.That(number.Magnitude, Is.EqualTo(3488));
    }

    [Test]
    public void Part1()
    {
        const string input = @"
[[[0,[5,8]],[[1,7],[9,6]]],[[4,[1,2]],[[1,4],2]]]
[[[5,[2,8]],4],[5,[[9,9],0]]]
[6,[[[6,2],[5,6]],[[7,6],[4,7]]]]
[[[6,[0,7]],[0,9]],[4,[9,[9,0]]]]
[[[7,[6,4]],[3,[1,3]]],[[[5,5],1],9]]
[[6,[[7,3],[3,2]]],[[[3,8],[5,7]],4]]
[[[[5,4],[7,7]],8],[[8,3],8]]
[[9,3],[[9,9],[6,[4,9]]]]
[[2,[[7,7],7]],[[5,8],[[9,3],[0,2]]]]
[[[[5,2],5],[8,[3,7]]],[[5,[7,5]],[4,4]]]";

        var math = new SnailfishMath();
        var result = math.Sum(input.Trim());

        Assert.That(result.ToString(), Is.EqualTo("[[[[6,6],[7,6]],[[7,7],[7,0]]],[[[7,7],[7,7]],[[7,8],[9,9]]]]"));
        Assert.That(result.Magnitude, Is.EqualTo(4140));
    }

    [Test]
    public void Part2()
    {
        const string input = @"
[[[0,[5,8]],[[1,7],[9,6]]],[[4,[1,2]],[[1,4],2]]]
[[[5,[2,8]],4],[5,[[9,9],0]]]
[6,[[[6,2],[5,6]],[[7,6],[4,7]]]]
[[[6,[0,7]],[0,9]],[4,[9,[9,0]]]]
[[[7,[6,4]],[3,[1,3]]],[[[5,5],1],9]]
[[6,[[7,3],[3,2]]],[[[3,8],[5,7]],4]]
[[[[5,4],[7,7]],8],[[8,3],8]]
[[9,3],[[9,9],[6,[4,9]]]]
[[2,[[7,7],7]],[[5,8],[[9,3],[0,2]]]]
[[[[5,2],5],[8,[3,7]]],[[5,[7,5]],[4,4]]]";

        var math = new SnailfishMath();
        var result = math.LargestMagnitude(input.Trim());

        Assert.That(result, Is.EqualTo(3993));
    }
}