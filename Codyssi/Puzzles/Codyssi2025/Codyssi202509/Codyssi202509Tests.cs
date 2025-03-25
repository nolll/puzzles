using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202509;

public class Codyssi202509Tests
{
    private const string Input = """
                                 Alpha HAS 131
                                 Bravo HAS 804
                                 Charlie HAS 348
                                 Delta HAS 187
                                 Echo HAS 649
                                 Foxtrot HAS 739

                                 FROM Echo TO Foxtrot AMT 328
                                 FROM Charlie TO Bravo AMT 150
                                 FROM Charlie TO Delta AMT 255
                                 FROM Alpha TO Delta AMT 431
                                 FROM Foxtrot TO Alpha AMT 230
                                 FROM Echo TO Foxtrot AMT 359
                                 FROM Echo TO Alpha AMT 269
                                 FROM Delta TO Foxtrot AMT 430
                                 FROM Bravo TO Echo AMT 455
                                 FROM Charlie TO Delta AMT 302
                                 """;

    [Test]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("2870");

    [Test]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("2542");

    [Test]
    public void Part3() => Sut.Part3(Input).Answer.Should().Be("2511");

    private static Codyssi202509 Sut => new();
}