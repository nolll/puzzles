using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aquaq.Puzzles.Aquaq22;

public class Aquaq22Tests
{
    [Test]
    public void CaesarCipher() => Aquaq22.ToCaesarCipherSum("IVXLCDM")
        .Should().Be(87);
}