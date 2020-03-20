using System.Collections.Generic;
using Core.Tools;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Tests
{
    public class ScrambledLettersTests
    {
        [Test]
        public void CorrectScramble()
        {
            const string input = "abcde";

            var scrambler = new StringScrambler(input);
            var result = scrambler.Scramble(input);

            Assert.That(result, Is.EqualTo("decab"));
        }
    }

    public class StringScrambler
    {
        private readonly IList<string> _instructions;

        public StringScrambler(string input)
        {
            _instructions = PuzzleInputReader.Read(input);
        }

        public string Scramble(string str)
        {
            foreach (var instruction in _instructions)
            {
                str = RunInstruction(instruction, str);
            }

            return str;
        }

        private string RunInstruction(string instruction, string input)
        {
            var parts = instruction.Split(' ');
            var letters = input.ToCharArray();

            var command = parts[0];
            if (command == "swap")
            {
                if (parts[1] == "position")
                {
                    var posA = int.Parse(parts[2]);
                    var posB = int.Parse(parts[5]);
                    var letterA = letters[posA];
                    var letterB = letters[posB];
                    input = input.Remove(posA, 1);
                    input = input.Insert(posA, letterB.ToString());
                    input = input.Remove(posB, 1);
                    input = input.Insert(posB, letterA.ToString());
                    return input;
                }
                else
                {
                    var letterA = parts[2];
                    var letterB = parts[5];
                    input = input.Replace(letterA, "_");
                    input = input.Replace(letterB, letterA);
                    input = input.Replace("_", letterB);
                    return input;
                }
            }

            if (command == "rotate")
            {

            }

            if (command == "reverse")
            {

            }

            if (command == "move")
            {

            }
            /*
rotate left/right X steps
means that the whole string should be rotated; for example, one right rotation would turn abcd into dabc.

rotate based on position of letter X
means that the whole string should be rotated to the right based on the index of letter X (counting from 0) as determined before this instruction does any rotations. Once the index is determined, rotate the string to the right one time, plus a number of times equal to that index, plus one additional time if the index was at least 4.

reverse positions X through Y 
means that the span of letters at indexes X through Y (including the letters at X and Y) should be reversed in order.

move position X to position Y
means that the letter which is at index X should be removed from the string, then inserted such that it ends up at index Y.
             */

            return input;
        }
    }
}