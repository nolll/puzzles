using NUnit.Framework;

namespace Aquaq.Puzzles.Aquaq19;

public class Aquaq19Tests
{
    [Test]
    public void GameOfLife()
    {
        var result = Aquaq19.RunGame("350 6 2 2 2 3");

        Assert.That(result, Is.EqualTo(8));
    }
}