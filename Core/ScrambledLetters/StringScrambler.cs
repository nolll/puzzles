using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.ScrambledLetters
{
    public class StringScrambler
    {
        private readonly IList<string> _instructions;

        public StringScrambler(string input)
        {
            _instructions = PuzzleInputReader.Read(input);
        }

        public string Scramble(string str)
        {
            IList<char> letters = str.ToList();
            foreach (var instruction in _instructions)
            {
                letters = RunInstruction(instruction, letters);
            }

            return string.Concat(letters);
        }

        private IList<char> RunInstruction(string instruction, IList<char> letters)
        {
            var parts = instruction.Split(' ');

            var command = parts[0];
            if (command == "swap")
            {
                if (parts[1] == "position")
                {
                    var posA = int.Parse(parts[2]);
                    var posB = int.Parse(parts[5]);
                    var letterA = letters[posA];
                    var letterB = letters[posB];
                    letters[posA] = letterB;
                    letters[posB] = letterA;
                    return letters;
                }
                else
                {
                    var letterA = parts[2].First();
                    var letterB = parts[5].First();
                    var letterAPos = letters.IndexOf(letterA);
                    var letterBPos = letters.IndexOf(letterB);
                    letters[letterAPos] = letterB;
                    letters[letterBPos] = letterA;
                    return letters;
                }
            }

            if (command == "rotate")
            {
                var type = parts[1];
                if (type == "left")
                {
                    var count = int.Parse(parts[2]);
                    while (count > 0)
                    {
                        var letterToMove = letters.First();
                        letters.RemoveAt(0);
                        letters.Add(letterToMove);
                        count--;
                    }

                    return letters;
                }

                if (type == "right")
                {
                    var count = int.Parse(parts[2]);
                    while (count > 0)
                    {
                        var letterToMove = letters.Last();
                        letters.RemoveAt(letters.Count - 1);
                        letters.Insert(0, letterToMove);
                        count--;
                    }

                    return letters;
                }
                
                if (type == "based")
                {
                    var letter = parts[6].First();
                    var count = letters.IndexOf(letter);
                    if (count >= 4)
                        count++;
                    count++;
                    while (count > 0)
                    {
                        var letterToMove = letters.Last();
                        letters.RemoveAt(letters.Count - 1);
                        letters.Insert(0, letterToMove);
                        count--;
                    }

                    return letters;
                }
            }

            if (command == "reverse")
            {
                var a = int.Parse(parts[2]);
                var b = int.Parse(parts[4]);
                var startRange = letters.Take(a);
                var endRange = letters.Skip(b + 1);
                var range = letters.Skip(a).Take(b + 1 - a);
                return startRange.Concat(range.Reverse()).Concat(endRange).ToList();
            }

            if (command == "move")
            {
                var a = int.Parse(parts[2]);
                var b = int.Parse(parts[5]);
                var letterToMove = letters.Skip(a).Take(1).First();
                letters.RemoveAt(a);
                letters.Insert(b, letterToMove);
                return letters;
            }

            return letters;
        }
    }
}