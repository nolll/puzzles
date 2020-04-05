using Core.Tools;
using Core.Tools.Assembunny;
using NUnit.Framework;

namespace Tests
{
    public class AssembunnyComputerTests
    {
        [Test]
        public void RegisterAIsCorrect()
        {
            const string input = @"
cpy 41 a
inc a
inc a
dec a
jnz a 2
dec a";

            var control = new AssembunnyComputer(input);

            Assert.That(control.ValueA, Is.EqualTo(42));
        }

        [Test]
        public void RegisterAIsCorrectWithToggleInstruction()
        {
            const string input = @"
cpy 2 a
tgl a
tgl a
tgl a
cpy 1 a
dec a
dec a";

            var control = new AssembunnyComputer(input);

            Assert.That(control.ValueA, Is.EqualTo(3));
        }
    }
}