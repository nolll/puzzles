using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aquaq.Puzzles.Aquaq25;

public class Aquaq25Tests
{
    [Test]
    public void EncodeMorse() => Aquaq25.EncodeMorse("jam donut")
        .Should().Be(".--- .- --   -.. --- -. ..- -");

    [Test]
    public void DecodeMorse() => Aquaq25.DecodeMorse(".--- .- --   -.. --- -. ..- -")
        .Should().Be("jam donut");

    [Test]
    public void ClicksToMorse()
    {
        const string input = """
                             21:46:5.000
                             21:46:5.001
                             21:46:5.002
                             21:46:5.005
                             21:46:5.006
                             21:46:5.009
                             21:46:5.010
                             21:46:5.013
                             21:46:5.016
                             21:46:5.017
                             21:46:5.018
                             21:46:5.021
                                        
                             21:46:5.024
                             21:46:5.027
                             21:46:5.028
                             21:46:5.031
                             21:46:5.038
                             21:46:5.041
                             21:46:5.042
                             21:46:5.043
                             """;

        Aquaq25.ClicksToMorse(input)
            .Should().Be(".--- .- --   -.");
    }
}