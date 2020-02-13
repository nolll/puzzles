using System.Collections.Generic;
using System.Linq;

namespace Core.LineDance
{
    public class DancingPrograms
    {
        private List<char> _programs;
        public string Programs => string.Concat(_programs);

        public DancingPrograms(string programs = "abcdefghijklmnop")
        {
            _programs = programs.ToList();
        }

        public void Dance(string input)
        {
            var moves = input.Split(',');
            foreach (var move in moves)
            {
                var command = move.First();
                if (command == 's')
                {
                    var toMove = int.Parse(move.Substring(1));
                    _programs = _programs.TakeLast(toMove).Concat(_programs.SkipLast(toMove)).ToList();

                }
                else if (command == 'x')
                {
                    var parts = move.Substring(1).Split('/');
                    var index1 = int.Parse(parts[0]);
                    var index2 = int.Parse(parts[1]);
                    var val1 = _programs[index1];
                    var val2 = _programs[index2];
                    _programs[index1] = val2;
                    _programs[index2] = val1;
                }
                else if (command == 'p')
                {
                    var parts = move.Substring(1).Split('/').Select(o => o.First()).ToList();
                    var val1 = parts[0];
                    var val2 = parts[1]; 
                    var index1 = _programs.IndexOf(val1);
                    var index2 = _programs.IndexOf(val2);
                    _programs[index1] = val2;
                    _programs[index2] = val1;
                }
            }
        }
    }
}