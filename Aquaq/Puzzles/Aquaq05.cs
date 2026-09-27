using Pzl.Common;

namespace Pzl.Aquaq.Puzzles;

[Name("Snake eyes")]
public class Aquaq05 : AquaqPuzzle
{
    [Puzzle("618a2293fcd6600e06eb2d002758bd97")]
    public int Solve(string input)
    {
        Dice[] dices = [new(1, 2, 3), new(1, 3, 2)];
        var rotations = input.ToCharArray();
        var sum = 0;

        for (var i = 0; i < rotations.Length; i++)
        {
            var rotation = rotations[i];
            
            switch (rotation)
            {
                case 'U':
                {
                    foreach (var dice in dices) 
                        dice.RotateUp();
                    break;
                }
                case 'R':
                {
                    foreach (var dice in dices) 
                        dice.RotateRight();
                    break;
                }
                case 'D':
                {
                    foreach (var dice in dices) 
                        dice.RotateDown();
                    break;
                }
                case 'L':
                {
                    foreach (var dice in dices) 
                        dice.RotateLeft();
                    break;
                }
            }

            if (dices[0].Front == dices[1].Front)
                sum += i;
        }

        return sum;
    }
    
    public class Dice
    {
        private const int Total = 6; 

        public int Front { get; private set; } 
        public int Back { get; private set; }
        public int Left { get; private set; }
        public int Right { get; private set; }
        public int Top { get; private set; }
        public int Bottom { get; private set; }

        public Dice(int front, int back, int left, int right, int top, int bottom)
        {
            Front = front;
            Back = back;
            Left = left;
            Right = right;
            Top = top;
            Bottom = bottom;
        }

        public Dice(int front, int left, int top)
            : this(front, Total - front, left, Total - left, top, Total - top)
        {
        }

        public void RotateLeft()
        {
            var front = Front;
            var back = Back;
            var left = Left;
            var right = Right;
            Front = right;
            Back = left;
            Left = front;
            Right = back;
        }

        public void RotateRight()
        {
            var front = Front;
            var back = Back;
            var left = Left;
            var right = Right;
            Front = left;
            Back = right;
            Left = back;
            Right = front;
        }

        public void RotateUp()
        {
            var front = Front;
            var back = Back;
            var top = Top;
            var bottom = Bottom;
            Front = bottom;
            Back = top;
            Top = front;
            Bottom = back;
        }

        public void RotateDown()
        {
            var front = Front;
            var back = Back;
            var top = Top;
            var bottom = Bottom;
            Front = top;
            Back = bottom;
            Top = back;
            Bottom = front;
        }
    }
}