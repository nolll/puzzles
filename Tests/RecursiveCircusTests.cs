using System.Collections.Generic;
using Core.Tools;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Tests
{
    public class RecursiveCircusTests
    {
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

    public class RecursiveTowers
    {
        public string BottomName { private set; get; }

        public RecursiveTowers(string input)
        {
            var strings = PuzzleInputReader.Read(input);
            var discs = new Dictionary<string, Disc>();
            foreach (var disc in strings)
            {
                
            }
        }
    }

    public class Disc
    {

    }
}