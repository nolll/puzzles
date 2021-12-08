using NUnit.Framework;

namespace App.Puzzles.Year2017.Day25
{
    public class Year2017Day25Tests
    {
        [Test]
        public void ChecksumIsCorrect()
        {
            const string input = @"
Begin in state A.
Perform a diagnostic checksum after 6 steps.

In state A:
  If the current value is 0:
    - Write the value 1.
    - Move one slot to the right.
    - Continue with state B.
  If the current value is 1:
    - Write the value 0.
    - Move one slot to the left.
    - Continue with state B.

In state B:
  If the current value is 0:
    - Write the value 1.
    - Move one slot to the left.
    - Continue with state A.
  If the current value is 1:
    - Write the value 1.
    - Move one slot to the right.
    - Continue with state A.";

            var turingMachine = new TuringMachine(input);
            var checksum = turingMachine.Run();

            Assert.That(checksum, Is.EqualTo(3));
        }
    }
}