using Pzl.Aquaq.Puzzles;

namespace Tests.Aquaq;

public class Aquaq22Tests
{
    [Fact]
    public void CaesarCipher() => Aquaq22.ToCaesarCipherSum("IVXLCDM")
        .Should().Be(87);
}