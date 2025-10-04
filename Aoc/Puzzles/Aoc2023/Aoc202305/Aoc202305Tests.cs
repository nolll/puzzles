namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202305;

public class Aoc202305Tests
{
    private const string Input = """
                                  seeds: 79 14 55 13

                                  seed-to-soil map:
                                  50 98 2
                                  52 50 48

                                  soil-to-fertilizer map:
                                  0 15 37
                                  37 52 2
                                  39 0 15

                                  fertilizer-to-water map:
                                  49 53 8
                                  0 11 42
                                  42 0 7
                                  57 7 4

                                  water-to-light map:
                                  88 18 7
                                  18 25 70

                                  light-to-temperature map:
                                  45 77 23
                                  81 45 19
                                  68 64 13

                                  temperature-to-humidity map:
                                  0 69 1
                                  1 0 69

                                  humidity-to-location map:
                                  60 56 37
                                  56 93 4
                                  """;

    [Fact]
    public void Part1()
    {
        var result = Aoc202305.Part1(Input);

        result.Should().Be(35);
    }

    [Fact]
    public void Part2()
    {
        var result = Aoc202305.Part2(Input);

        result.Should().Be(46);
    }
}