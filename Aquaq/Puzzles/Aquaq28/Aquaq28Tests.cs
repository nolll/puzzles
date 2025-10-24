namespace Pzl.Aquaq.Puzzles.Aquaq28;

public class Aquaq28Tests
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