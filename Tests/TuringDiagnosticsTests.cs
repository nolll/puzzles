using System.Linq;
using Core.Tools;
using NUnit.Framework;

namespace Tests
{
    public class TuringDiagnosticsTests
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
            turingMachine.Run();

            Assert.That(turingMachine.Checksum, Is.EqualTo(3));
        }
    }

    public class TuringMachine
    {
        public int Checksum { get; private set; }

        public TuringMachine(string input)
        {
            var rows = PuzzleInputReader.Read(input);

            var beginRow = rows[0];
            var startState = beginRow.Split(' ')[3].First();

            var stepsRow = rows[1];
            var steps = int.Parse(stepsRow.Split(' ')[5]);

            var stateRows = rows.Skip(2);
        }

        public void Run()
        {
            Checksum = 0;
        }
    }
}