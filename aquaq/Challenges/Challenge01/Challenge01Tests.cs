using NUnit.Framework;

namespace AquaQ.Challenges.Challenge01;

public class Challenge01Tests
{
    [Test]
    public void Numpad()
    {
        var keyPresses = new List<(int key, int count)>
        {
            (0, 1),
            (2, 1),
            (2, 2),
            (2, 3),
            (3, 1),
            (3, 2),
            (3, 3),
            (4, 1),
            (4, 2),
            (4, 3),
            (5, 1),
            (5, 2),
            (5, 3),
            (6, 1),
            (6, 2),
            (6, 3),
            (7, 1),
            (7, 2),
            (7, 3),
            (7, 4),
            (8, 1),
            (8, 2),
            (8, 3),
            (9, 1),
            (9, 2),
            (9, 3),
            (9, 4)
        };

        var result = Challenge01.HandleKeyPresses(keyPresses);

        Assert.That(result, Is.EqualTo(" abcdefghijklmnopqrstuvwxyz"));
    }
}