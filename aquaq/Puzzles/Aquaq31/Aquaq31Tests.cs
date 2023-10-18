using FluentAssertions;
using NUnit.Framework;

namespace Aquaq.Puzzles.Aquaq31;

public class Aquaq31Tests
{
    [Test]
    public void RotateAll()
    {
        var result = Aquaq31.Rotate("U'LBRU");

        result.Should().Be(960);
    }

    [TestCase("F", "bbbbbbbbb", "wwwwwwrrr", "rryrryrry", "woowoowoo", "oooyyyyyy", "ggggggggg")]
    [TestCase("F'", "bbbbbbbbb", "wwwwwwooo", "rrwrrwrrw", "yooyooyoo", "rrryyyyyy", "ggggggggg")]
    [TestCase("U", "ooobbbbbb", "wwwwwwwww", "bbbrrrrrr", "gggoooooo", "yyyyyyyyy", "rrrgggggg")]
    [TestCase("U'", "rrrbbbbbb", "wwwwwwwww", "gggrrrrrr", "bbboooooo", "yyyyyyyyy", "ooogggggg")]
    [TestCase("L", "wbbwbbwbb", "gwwgwwgww", "rrrrrrrrr", "ooooooooo", "byybyybyy", "ggyggyggy")]
    [TestCase("L'", "ybbybbybb", "bwwbwwbww", "rrrrrrrrr", "ooooooooo", "gyygyygyy", "ggwggwggw")]
    [TestCase("R", "bbybbybby", "wwbwwbwwb", "rrrrrrrrr", "ooooooooo", "yygyygyyg", "wggwggwgg")]
    [TestCase("R'", "bbwbbwbbw", "wwgwwgwwg", "rrrrrrrrr", "ooooooooo", "yybyybyyb", "yggyggygg")]
    [TestCase("D", "bbbbbbrrr", "wwwwwwwww", "rrrrrrggg", "oooooobbb", "yyyyyyyyy", "ggggggooo")]
    [TestCase("D'", "bbbbbbooo", "wwwwwwwww", "rrrrrrbbb", "ooooooggg", "yyyyyyyyy", "ggggggrrr")]
    [TestCase("B", "bbbbbbbbb", "ooowwwwww", "wrrwrrwrr", "ooyooyooy", "yyyyyyrrr", "ggggggggg")]
    [TestCase("B'", "bbbbbbbbb", "rrrwwwwww", "yrryrryrr", "oowoowoow", "yyyyyyooo", "ggggggggg")]
    [TestCase("X", "yyyyyyyyy", "bbbbbbbbb", "rrrrrrrrr", "ooooooooo", "ggggggggg", "wwwwwwwww")]
    [TestCase("X'", "wwwwwwwww", "ggggggggg", "rrrrrrrrr", "ooooooooo", "bbbbbbbbb", "yyyyyyyyy")]
    [TestCase("Y", "ooooooooo", "wwwwwwwww", "bbbbbbbbb", "ggggggggg", "yyyyyyyyy", "rrrrrrrrr")]
    [TestCase("Y'", "rrrrrrrrr", "wwwwwwwww", "ggggggggg", "bbbbbbbbb", "yyyyyyyyy", "ooooooooo")]
    [TestCase("Z", "bbbbbbbbb", "rrrrrrrrr", "yyyyyyyyy", "wwwwwwwww", "ooooooooo", "ggggggggg")]
    [TestCase("Z'", "bbbbbbbbb", "ooooooooo", "wwwwwwwww", "yyyyyyyyy", "rrrrrrrrr", "ggggggggg")]
    public void RotateOne(
        string rotation, 
        string front, 
        string up, 
        string left,
        string right,
        string down,
        string back)
    {
        var cube = new RubiksCube();
        cube.Rotate(rotation);

        cube.Front.Print().Should().Be(front);
        cube.Up.Print().Should().Be(up);
        cube.Left.Print().Should().Be(left);
        cube.Right.Print().Should().Be(right);
        cube.Down.Print().Should().Be(down);
        cube.Back.Print().Should().Be(back);
    }
}