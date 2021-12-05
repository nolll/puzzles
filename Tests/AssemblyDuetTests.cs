using ConsoleApp.Puzzles.Year2017.Day18;
using NUnit.Framework;

namespace Tests
{
    public class AssemblyDuetTests
    {
        [Test]
        public void SingleRunnerFindsFrequency()
        {
            const string input = @"
set a 1
add a 2
mul a a
mod a 5
snd a
set a 0
rcv a
jgz a -1
set a 1
jgz a -2";
            var single = new SingleRunner(input);
            single.Run();

            Assert.That(single.RecoveredFrequency, Is.EqualTo(4));
        }

        [Test]
        public void DuetRunnerSendCountIsCorrect()
        {
            const string input = @"
snd 1
snd 2
snd p
rcv a
rcv b
rcv c
rcv d";
            var duet = new DuetRunner(input);
            duet.Run();

            Assert.That(duet.Program1SendCount, Is.EqualTo(3));
        }
    }
}