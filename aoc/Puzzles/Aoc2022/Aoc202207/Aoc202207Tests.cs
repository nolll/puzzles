using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Aoc.Puzzles.Aoc2022.Aoc202207;

public class Aoc202207Tests
{
    [Test]
    public void Part1()
    {
        var fileSystem = new FileSystem(Input);
        var result = fileSystem.Part1();

        result.Should().Be(95437);
    }

    [Test]
    public void Part2()
    {
        var fileSystem = new FileSystem(Input);
        var result = fileSystem.Part2();

        result.Should().Be(24933642);
    }

    private const string Input = """
$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k
""";
}