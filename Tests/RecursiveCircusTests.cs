using Core.RecursiveCircus;
using NUnit.Framework;

namespace Tests
{
    public class RecursiveCircusTests
    {
        [Test]
        public void FindsNameOfBottomProgram()
        {
            const string input = @"
pbga (66)
xhth (57)
ebii (61)
havc (66)
ktlj (57)
fwft (72) -> ktlj, cntj, xhth
qoyq (66)
padx (45) -> pbga, havc, qoyq
tknk (41) -> ugml, padx, fwft
jptl (61)
ugml (68) -> gyxo, ebii, jptl
gyxo (61)
cntj (57)";

            var towers = new RecursiveTowers(input);
            var name = towers.BottomName;

            Assert.That(name, Is.EqualTo("tknk"));
        }
    }
}