using Core.JumpInstructions;
using NUnit.Framework;

namespace Tests
{
    public class JumpInstructionTests
    {
        [Test]
        public void StepsUntilExit()
        {
            const string input = @"
0
3
0
1
-3";

            var jumper = new InstructionJumper(input);
            jumper.Start();

            Assert.That(jumper.StepCount, Is.EqualTo(5));
        }
    }
}