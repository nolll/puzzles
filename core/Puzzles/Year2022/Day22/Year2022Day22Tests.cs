using NUnit.Framework;

namespace Core.Puzzles.Year2022.Day22;

public class Year2022Day22Tests
{
    [Test]
    public void Part1()
    {
        var puzzle = new Year2022Day22();
        var result = puzzle.Part1(Input);

        Assert.That(result, Is.EqualTo(6032));
    }

    [Test]
    public void Part2()
    {
        var result = 0;

        Assert.That(result, Is.EqualTo(0));
    }

    private const string Input = """
        ...#    
        .#..    
        #...    
        ....    
...#.......#    
........#...    
..#....#....    
..........#.    
        ...#....
        .....#..
        .#......
        ......#.

10R5L5R10L4R5L5
""";
}