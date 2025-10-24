namespace Pzl.Aquaq.Puzzles.Aquaq31.RubiksCube;

public static class CubeTestHelper
{
    public static Cube CreateScrambledCube()
    {
        var cube = new Cube();
        cube.Rotate("UL'RDBDU'FLF'");
        
        cube.Print().Should().Be("""
                                 orr rbb gww yoy owb oow
                                 yby rww wrr oog gyg ogb
                                 ygw gbb ryg orr wyg ybb
                                 """);

        return cube;
    }
}