using NUnit.Framework;

namespace Aquaq.Puzzles.Aquaq13;

public class Aquaq13Tests
{
    [TestCase("ABCABCABCABCABC", 5)]
    [TestCase("AAAAAAB", 6)]
    [TestCase("AAAAAABAAAAAAB", 12)]
    [TestCase("buhtbuhtbuhtbuhtbuhtbuhtbuhtkbzowxgrfyvmltjp", 8)]
    public void FindMaxRepeats(string input, int expected)
    {
        var result = Aquaq13.FindMaxRepeats(input);

        Assert.That(result, Is.EqualTo(expected));
    }
}