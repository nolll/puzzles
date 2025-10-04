using FluentAssertions;

namespace Pzl.Aquaq.Puzzles.Aquaq22;

public class Aquaq22Tests
{
    [Fact]
    public void CaesarCipher() => Aquaq22.ToCaesarCipherSum("IVXLCDM")
        .Should().Be(87);
}