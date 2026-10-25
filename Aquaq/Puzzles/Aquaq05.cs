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

            foreach (var dice in dices)
                dice.Rotate(rotation);

            if (dices[0].Front == dices[1].Front)
                sum += i;
        }

        return sum;
    }

    public class Dice(int front, int back, int left, int right, int top, int bottom)
    {
        private const int Total = 6;

        public int Front { get; private set; } = front;
        public int Back { get; private set; } = back;
        public int Left { get; private set; } = left;
        public int Right { get; private set; } = right;
        public int Top { get; private set; } = top;
        public int Bottom { get; private set; } = bottom;

        public Dice(int front, int left, int top) : this(front, Total - front, left, Total - left, top, Total - top) {}

        public void Rotate(char direction) => GetRotationFunc(direction)();
        public void RotateLeft() => (Front, Back, Left, Right) = (Right, Left, Front, Back);
        public void RotateRight() => (Front, Back, Left, Right) = (Left, Right, Back, Front);
        public void RotateUp() => (Front, Back, Top, Bottom) = (Bottom, Top, Front, Back);
        public void RotateDown() => (Front, Back, Top, Bottom) = (Top, Bottom, Back, Front);
        
        private Action GetRotationFunc(char direction) => direction switch
        {
            'U' => RotateUp,
            'R' => RotateRight,
            'D' => RotateDown,
            _ => RotateLeft
        };
    }
}