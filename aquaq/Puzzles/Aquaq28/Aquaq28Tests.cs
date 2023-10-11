using NUnit.Framework;

namespace Aquaq.Puzzles.Aquaq28;

public class Aquaq28Tests
{
    private const string Input = 
"""
 ABCD
A\  /A
B /\ B
C/ \ C
D/ / D
 ABCD 
""";

    [Test]
    public void MirrorEncrypt()
    {
        var result = Aquaq28.Encrypt(Input, "DAD");

        Assert.That(result, Is.EqualTo("CCC"));
    }
}