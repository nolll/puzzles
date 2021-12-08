namespace App.Puzzles.Year2016.Day21
{
    public class RotateBasedOnPositionInstruction : RotateInstruction
    {
        private readonly char _letter;

        public RotateBasedOnPositionInstruction(char letter)
        {
            _letter = letter;
        }

        public override string Run(string s)
        {
            var steps = GetSteps(s);
            return RotateRight(s, steps);
        }

        public override string RunBackwards(string s)
        {
            for (var i = 1; i <= s.Length; i++)
            {
                var rotated = RotateLeft(s, i);
                var steps = GetSteps(rotated);
                var rotatedBack = RotateRight(rotated, steps);
                if (rotatedBack == s)
                    return rotated;
            }

            return s;
        }

        private int GetSteps(string s)
        {
            var steps = s.IndexOf(_letter);
            if (steps >= 4)
                steps++;
            return steps + 1;
        }
    }
}