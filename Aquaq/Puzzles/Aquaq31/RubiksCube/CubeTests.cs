using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aquaq.Puzzles.Aquaq31.RubiksCube;

public class CubeTests
{
    [Test]
    public void RotateFront()
    {
        var cube = new Cube();
        cube.RotateFront();

        cube.Print().Should().Be("""
                                 bbb www rry woo ooo ggg
                                 bbb www rry woo yyy ggg
                                 bbb rrr rry woo yyy ggg
                                 """);
    }

    [Test]
    public void RotateFrontPrime()
    {
        var cube = new Cube();
        cube.RotateFrontPrime();

        cube.Print().Should().Be("""
                                 bbb www rrw yoo rrr ggg
                                 bbb www rrw yoo yyy ggg
                                 bbb ooo rrw yoo yyy ggg
                                 """);
    }

    [Test]
    public void RotateUp()
    {
        var cube = new Cube();
        cube.RotateUp();

        cube.Print().Should().Be("""
                                 ooo www bbb ggg yyy rrr
                                 bbb www rrr ooo yyy ggg
                                 bbb www rrr ooo yyy ggg
                                 """);
    }

    [Test]
    public void RotateUpPrime()
    {
        var cube = new Cube();
        cube.RotateUpPrime();

        cube.Print().Should().Be("""
                                 rrr www ggg bbb yyy ooo
                                 bbb www rrr ooo yyy ggg
                                 bbb www rrr ooo yyy ggg
                                 """);
    }

    [Test]
    public void RotateLeft()
    {
        var cube = new Cube();
        cube.RotateLeft();

        cube.Print().Should().Be("""
                                 wbb gww rrr ooo byy ggy
                                 wbb gww rrr ooo byy ggy
                                 wbb gww rrr ooo byy ggy
                                 """);
    }

    [Test]
    public void RotateLeftPrime()
    {
        var cube = new Cube();
        cube.RotateLeftPrime();

        cube.Print().Should().Be("""
                                 ybb bww rrr ooo gyy ggw
                                 ybb bww rrr ooo gyy ggw
                                 ybb bww rrr ooo gyy ggw
                                 """);
    }

    [Test]
    public void RotateRight()
    {
        var cube = new Cube();
        cube.RotateRight();

        cube.Print().Should().Be("""
                                 bby wwb rrr ooo yyg wgg
                                 bby wwb rrr ooo yyg wgg
                                 bby wwb rrr ooo yyg wgg
                                 """);
    }

    [Test]
    public void RotateRightPrime()
    {
        var cube = new Cube();
        cube.RotateRightPrime();

        cube.Print().Should().Be("""
                                 bbw wwg rrr ooo yyb ygg
                                 bbw wwg rrr ooo yyb ygg
                                 bbw wwg rrr ooo yyb ygg
                                 """);
    }

    [Test]
    public void RotateDown()
    {
        var cube = new Cube();
        cube.RotateDown();

        cube.Print().Should().Be("""
                                 bbb www rrr ooo yyy ggg
                                 bbb www rrr ooo yyy ggg
                                 rrr www ggg bbb yyy ooo
                                 """);
    }

    [Test]
    public void RotateDownPrime()
    {
        var cube = new Cube();
        cube.RotateDownPrime();

        cube.Print().Should().Be("""
                                 bbb www rrr ooo yyy ggg
                                 bbb www rrr ooo yyy ggg
                                 ooo www bbb ggg yyy rrr
                                 """);
    }

    [Test]
    public void RotateBack()
    {
        var cube = new Cube();
        cube.RotateBack();

        cube.Print().Should().Be("""
                                 bbb ooo wrr ooy yyy ggg
                                 bbb www wrr ooy yyy ggg
                                 bbb www wrr ooy rrr ggg
                                 """);
    }

    [Test]
    public void RotateBackPrime()
    {
        var cube = new Cube();
        cube.RotateBackPrime();

        cube.Print().Should().Be("""
                                 bbb rrr yrr oow yyy ggg
                                 bbb www yrr oow yyy ggg
                                 bbb www yrr oow ooo ggg
                                 """);
    }

    [Test]
    public void RotateX()
    {
        var cube = CubeTestHelper.CreateScrambledCube();
        cube.RotateX();

        cube.Print().Should().Be("""
                                 owb orr wrg ooy bby bbg
                                 gyg yby wry roo bgo wwr
                                 wyg ygw gwr rgy woo bbr
                                 """);
    }

    [Test]
    public void RotateXPrime()
    {
        var cube = CubeTestHelper.CreateScrambledCube();
        cube.RotateXPrime();

        cube.Print().Should().Be("""
                                 rbb bby rwg ygr orr gyw
                                 rww bgo yrw oor yby gyg
                                 gbb woo grw yoo ygw bwo
                                 """);
    }

    [Test]
    public void RotateY()
    {
        var cube = CubeTestHelper.CreateScrambledCube();
        cube.RotateY();

        cube.Print().Should().Be("""
                                 yoy grr orr oow bgg gww
                                 oog bwb yby ogb wyy wrr
                                 orr bwb ygw ybb ogw ryg
                                 """);
    }

    [Test]
    public void RotateYPrime()
    {
        var cube = CubeTestHelper.CreateScrambledCube();
        cube.RotateYPrime();

        cube.Print().Should().Be("""
                                 gww bwb oow orr wgo yoy
                                 wrr bwb ogb yby yyw oog
                                 ryg rrg ybb ygw ggb orr
                                 """);
    }

    [Test]
    public void RotateZ()
    {
        var cube = CubeTestHelper.CreateScrambledCube();
        cube.RotateZ();

        cube.Print().Should().Be("""
                                 yyo rwg wgo grr ooy wbb
                                 gbr yrw yyw bwb roo ogb
                                 wyr grw ggb bwb rgy ooy
                                 """);
    }

    [Test]
    public void RotateZPrime()
    {
        var cube = CubeTestHelper.CreateScrambledCube();
        cube.RotateZPrime();

        cube.Print().Should().Be("""
                                 ryw ygr bwb bgg wrg yoo
                                 rbg oor bwb wyy wry bgo
                                 oyy yoo rrg ogw gwr bbw
                                 """);
    }

    [TestCase("XXXX")]
    [TestCase("X'X'X'X'")]
    [TestCase("YYYY")]
    [TestCase("Y'Y'Y'Y'")]
    [TestCase("ZZZZ")]
    [TestCase("Z'Z'Z'Z'")]
    [TestCase("XZXZXZ")]
    [TestCase("XYXYXY")]
    [TestCase("XZX'X'Z'YX'Z")]
    public void MultipleCubeRotations_BackToStart(string rotations)
    {
        var cube = CubeTestHelper.CreateScrambledCube();
        cube.Rotate(rotations);

        cube.Print().Should().Be("""
                                 orr rbb gww yoy owb oow
                                 yby rww wrr oog gyg ogb
                                 ygw gbb ryg orr wyg ybb
                                 """);
    }

    [Test]
    public void FindEdges()
    {
        var cube = new Cube();
        cube.Scramble();

        cube.BlueFace.Center.Should().Be(CubeColors.Blue);
        cube.WhiteFace.Center.Should().Be(CubeColors.White);
        cube.RedFace.Center.Should().Be(CubeColors.Red);
        cube.OrangeFace.Center.Should().Be(CubeColors.Orange);
        cube.YellowFace.Center.Should().Be(CubeColors.Yellow);
        cube.GreenFace.Center.Should().Be(CubeColors.Green);
    }
}