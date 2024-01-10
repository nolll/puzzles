using FluentAssertions;

namespace Pzl.Aquaq.Puzzles.Aquaq31.RubiksCube;

public static class CubeTestHelper
{
    public static Cube CreateScrambledCube()
    {
        string[] rotations = ["U", "L'", "R", "D", "B", "D", "U'", "F", "L", "F'"];

        var cube = new Cube();
        foreach (var rotation in rotations)
        {
            cube.Rotate(rotation);
        }

        cube.Print().Should().Be("""
                                 orr rbb gww yoy owb oow
                                 yby rww wrr oog gyg ogb
                                 ygw gbb ryg orr wyg ybb
                                 """);

        return cube;
    }
}