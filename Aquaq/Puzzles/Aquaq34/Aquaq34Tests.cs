using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aquaq.Puzzles.Aquaq34;

public class Aquaq34Tests
{
    [Test]
    public void TrainRoutes()
    {
        const string input = """
                             station,r1,r2,r3
                             a,00:01,,00:02
                             b,00:16,,00:17
                             c,,00:21,
                             d,00:46,00:51,00:47
                             """;

        var result = Aquaq34.LongestRouteTime(input);

        result.Should().Be(64);
    }
}