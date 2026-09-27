namespace Tests.Aquaq;

public class Aquaq22Tests
{
    [Fact]
    public void CaesarCipher() => Pzl.Aquaq.Puzzles.Aquaq22.Aquaq22.ToCaesarCipherSum("IVXLCDM")
        .Should().Be(87);
}