using Pzl.Aquaq.Puzzles;

namespace Tests.Aquaq;

public class Aquaq00Tests : PuzzleTest<Aquaq00>
{
    [Fact]
    public void Numpad() => Sut.HandleKeyPresses(_keyPresses).Should().Be(" abcdefghijklmnopqrstuvwxyz");

    private readonly List<(int key, int count)> _keyPresses =
    [
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
    ];
}