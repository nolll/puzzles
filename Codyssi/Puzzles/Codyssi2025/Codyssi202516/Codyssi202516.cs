using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;
using Pzl.Tools.Lists;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202516;

[Name("Leviathan Mindscape")]
public class Codyssi202516 : CodyssiPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var result = RunPart1(input, 80);
        return new PuzzleResult(result, "daf580450a171146930ce60cd7756da5");
    }

    public long RunPart1(string input, int gridSize)
    {
        var cube = new Cube(gridSize);

        var (t, r) = input.Split(LineBreaks.Double);
        var transformations = t.Split(LineBreaks.Single);
        var rotations = r.ToCharArray();

        for (var i = 0; i < transformations.Length; i++)
        {
            var parts = transformations[i].Split();
            var command = parts[0];
            var v = int.Parse(parts.Last());
            if (command == "ROW")
            {
                var row = int.Parse(parts[1]) - 1;
                var values = cube.Front.ReadRow(row).Select(o => (o + v) % 100).ToList();
                cube.Front.WriteRow(row, values);
                cube.Front.Absorbtion += v * values.Count;
            }
            else if (command == "COL")
            {
                var col = int.Parse(parts[1]) - 1;
                var values = cube.Front.ReadRow(col).Select(o => (o + v) % 100).ToList();
                cube.Front.WriteRow(col, values);
                cube.Front.Absorbtion += v * values.Count;
            }
            else
            {
                var values = cube.Front.ReadAll().Select(o => (o + v) % 100).ToList();
                cube.Front.WriteAll(values);
                cube.Front.Absorbtion += v * values.Count;
            }

            if (i >= rotations.Length)
                break;

            var rotation = rotations[i];
            cube.Rotate(rotation);
        }

        var top2 = cube.Faces.Select(o => (long)o.Absorbtion).OrderDescending().Take(2).ToArray();
        var p = top2.First() * top2.Last();

        return p;
    }

    private class Cube
    {
        public CubeFace Front { get; }
        public CubeFace Up { get; }
        public CubeFace Right { get; }
        public CubeFace Down { get; }
        public CubeFace Left { get; }
        public CubeFace Back { get; }

        public CubeFace[] Faces => [Front, Up, Right, Down, Left, Back];

        public Cube(int size)
        {
            Front = new CubeFace(1, size);
            Up = new CubeFace(1, size);
            Right = new CubeFace(1, size);
            Down = new CubeFace(1, size);
            Left = new CubeFace(1, size);
            Back = new CubeFace(1, size);
        }

        public void Rotate(char rotation) => GetRotateFunc(rotation)();

        public void RotateX()
        {
            Left.RotateLeft();
            Right.RotateRight();
            var front = Front.ReadAll();
            var frontAbsorbtion = Front.Absorbtion;
            var up = Up.ReadAll();
            var upAbsorbtion = Up.Absorbtion;
            var back = Back.ReadAll();
            var backAbsorbtion = Back.Absorbtion;
            var down = Down.ReadAll();
            var downAbsorbtion = Down.Absorbtion;
            Front.WriteAll(down);
            Front.Absorbtion = downAbsorbtion;
            Up.WriteAll(front);
            Up.Absorbtion = frontAbsorbtion;
            Down.WriteAll(back);
            Down.Absorbtion = backAbsorbtion;
            Down.RotateLeft();
            Down.RotateLeft();
            Back.WriteAll(up);
            Back.Absorbtion = upAbsorbtion;
            Back.RotateLeft();
            Back.RotateLeft();
        }

        public void RotateXPrime()
        {
            Left.RotateRight();
            Right.RotateLeft();
            var front = Front.ReadAll();
            var frontAbsorbtion = Front.Absorbtion;
            var up = Up.ReadAll();
            var upAbsorbtion = Up.Absorbtion;
            var back = Back.ReadAll();
            var backAbsorbtion = Back.Absorbtion;
            var down = Down.ReadAll();
            var downAbsorbtion = Down.Absorbtion;
            Front.WriteAll(up);
            Front.Absorbtion = upAbsorbtion;
            Up.WriteAll(back);
            Up.Absorbtion = backAbsorbtion;
            Up.RotateLeft();
            Up.RotateLeft();
            Down.WriteAll(front);
            Down.Absorbtion = frontAbsorbtion;
            Back.WriteAll(down);
            Back.Absorbtion = downAbsorbtion;
            Back.RotateLeft();
            Back.RotateLeft();
        }

        public void RotateY()
        {
            Up.RotateRight();
            Down.RotateLeft();
            var front = Front.ReadAll();
            var frontAbsorbtion = Front.Absorbtion;
            var left = Left.ReadAll();
            var leftAbsorbtion = Left.Absorbtion;
            var right = Right.ReadAll();
            var rightAbsorbtion = Right.Absorbtion;
            var back = Back.ReadAll();
            var backAbsorbtion = Back.Absorbtion;
            Front.WriteAll(right);
            Front.Absorbtion = rightAbsorbtion;
            Left.WriteAll(front);
            Left.Absorbtion = frontAbsorbtion;
            Right.WriteAll(back);
            Right.Absorbtion = backAbsorbtion;
            Back.WriteAll(left);
            Back.Absorbtion = leftAbsorbtion;
        }

        public void RotateYPrime()
        {
            Up.RotateLeft();
            Down.RotateRight();
            var front = Front.ReadAll();
            var frontAbsorbtion = Front.Absorbtion;
            var left = Left.ReadAll();
            var leftAbsorbtion = Left.Absorbtion;
            var right = Right.ReadAll();
            var rightAbsorbtion = Right.Absorbtion;
            var back = Back.ReadAll();
            var backAbsorbtion = Back.Absorbtion;
            Front.WriteAll(left);
            Front.Absorbtion = leftAbsorbtion;
            Left.WriteAll(back);
            Left.Absorbtion = backAbsorbtion;
            Right.WriteAll(front);
            Right.Absorbtion = frontAbsorbtion;
            Back.WriteAll(right);
            Back.Absorbtion = rightAbsorbtion;
        }

        // public void RotateZ()
        // {
        //     Back.RotateLeft();
        //     Front.RotateRight();
        //     var left = Left.ReadAll();
        //     var up = Up.ReadAll();
        //     var right = Right.ReadAll();
        //     var down = Down.ReadAll();
        //     Up.WriteAll(left);
        //     Up.RotateRight();
        //     Left.WriteAll(down);
        //     Left.RotateRight();
        //     Right.WriteAll(up);
        //     Right.RotateRight();
        //     Down.WriteAll(right);
        //     Down.RotateRight();
        // }
        //
        // public void RotateZPrime()
        // {
        //     Back.RotateRight();
        //     Front.RotateLeft();
        //     var left = Left.ReadAll();
        //     var up = Up.ReadAll();
        //     var right = Right.ReadAll();
        //     var down = Down.ReadAll();
        //     Up.WriteAll(right);
        //     Up.RotateLeft();
        //     Left.WriteAll(up);
        //     Left.RotateLeft();
        //     Right.WriteAll(down);
        //     Right.RotateLeft();
        //     Down.WriteAll(left);
        //     Down.RotateLeft();
        // }

        private Action GetRotateFunc(char rotation) => rotation switch
        {
            'U' => RotateYPrime,
            'R' => RotateX,
            'D' => RotateY,
            _ => RotateXPrime
        };
    }

    public class CubeFace
    {
        private readonly int _size;
        private Matrix<int> _matrix;
        
        public int Absorbtion { get; set; } 

        public CubeFace(int initial, int size)
        {
            _size = size;
            _matrix = new(_size, _size, initial);
        }

        //public int TopLeft => _matrix.ReadValueAt(0, 0);
        //public int Top => _matrix.ReadValueAt(1, 0);
        //public int TopRight => _matrix.ReadValueAt(2, 0);
        //public int Left => _matrix.ReadValueAt(1, 0);
        //public int Center => _matrix.ReadValueAt(1, 1);
        //public int Right => _matrix.ReadValueAt(1, 2);
        //public int BottomLeft => _matrix.ReadValueAt(0, 2);
        //public int Bottom => _matrix.ReadValueAt(1, 2);
        //public int BottomRight => _matrix.ReadValueAt(2, 2);

        public int[] ReadAll() => _matrix.Values.ToArray();
        public int[] ReadLeftColumn() => ReadColumn(0);
        public int[] ReadRightColumn() => ReadColumn(2);
        public int[] ReadColumn(int x) => Enumerable.Range(0, _size).Select(o => _matrix.ReadValueAt(x, o)).ToArray();

        public int[] ReadTopRow() => ReadRow(0);
        public int[] ReadBottomRow() => ReadRow(2);
        public int[] ReadRow(int y) => Enumerable.Range(0, _size).Select(o => _matrix.ReadValueAt(o, y)).ToArray();

        public Matrix<int> Matrix => _matrix.Clone();

        public void WriteAll(IEnumerable<int> values)
        {
            var charArray = values.ToArray();
            var coordsArray = _matrix.Coords.ToArray();
            for (var i = 0; i < coordsArray.Length; i++)
            {
                _matrix.WriteValueAt(coordsArray[i], charArray[i]);
            }
        }

        public void WriteTopRow(IEnumerable<int> values) => WriteRow(0, values);
        public void WriteBottomRow(IEnumerable<int> values) => WriteRow(2, values);

        public void WriteRow(int y, IEnumerable<int> values)
        {
            var x = 0;
            foreach (var value in values)
            {
                _matrix.WriteValueAt(x, y, value);
                x++;
            }
        }

        public void WriteLeftColumn(IEnumerable<char> values) => WriteColumn(0, values);
        public void WriteRightColumn(IEnumerable<char> values) => WriteColumn(2, values);

        public void WriteColumn(int x, IEnumerable<char> values)
        {
            var y = 0;
            foreach (var value in values)
            {
                _matrix.WriteValueAt(x, y, value);
                y++;
            }
        }

        public void RotateRight() => _matrix = _matrix.RotateRight();
        public void RotateLeft() => _matrix = _matrix.RotateLeft();
        public string PrintFlat() => string.Join("", _matrix.Values);
        public string Print() => _matrix.Print();
        //public int Product => _matrix.Values.Select(GetColorValue).Aggregate(1, (a, b) => a * b);

        //private static int GetColorValue(char c) => c switch
        //{
        //    CubeColors.Blue => 1,
        //    CubeColors.White => 2,
        //    CubeColors.Red => 3,
        //    CubeColors.Orange => 4,
        //    CubeColors.Yellow => 5,
        //    CubeColors.Green => 6,
        //    _ => throw new Exception("Unknown color")
        //};
    }

    public PuzzleResult Part2(string input)
    {
        return new PuzzleResult(0);
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }
}