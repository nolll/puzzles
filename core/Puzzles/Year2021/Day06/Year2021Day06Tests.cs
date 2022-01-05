using NUnit.Framework;

namespace Core.Puzzles.Year2021.Day06;

public class Year2021Day06Tests
{
    [TestCase(18, 26)]
    [TestCase(80, 5934)]
    [TestCase(256, 26_984_457_539)]
    public void Test(int days, long expected)
    {
        var fishCounter = new FishCounter(Input);
        var result = fishCounter.FishCountAfter(days);

        Assert.That(result, Is.EqualTo(expected));
    }
        
    private const string Input = "3,4,3,1,2";
}