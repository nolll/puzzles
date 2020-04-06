using Core.TuringLock;
using NUnit.Framework;

namespace Tests
{
    public class TuringLockTests
    {
        [Test]
        public void RegisterAContains2()
        {
            const string input = @"
inc a
jio a, +2
tpl a
inc a";

            var computer = new ChristmasComputer();
            computer.Run(input);

            Assert.That(computer.RegisterA, Is.EqualTo(2));
        }
    }
}