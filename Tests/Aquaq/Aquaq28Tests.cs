using Pzl.Aquaq.Puzzles;

namespace Tests.Aquaq;

public class Aquaq28Tests : PuzzleTest<Aquaq28>
{
    private const string Input = """
                                  ABCD
                                 A\  /A
                                 B /\ B
                                 C/ \ C
                                 D/ / D
                                  ABCD
                                 """;

    [Fact]
    public void MirrorEncrypt() => Aquaq28.Encrypt(Input, "DAD")
        .Should().Be("CCC");
}