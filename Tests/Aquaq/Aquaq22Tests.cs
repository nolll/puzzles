using Pzl.Aquaq.Puzzles;

namespace Tests.Aquaq;

public class Aquaq22Tests : PuzzleTest<Aquaq22>
{
    [Fact]
    public void CaesarCipher() => Sut.ToCaesarCipherSum("IVXLCDM").Should().Be(87);
}