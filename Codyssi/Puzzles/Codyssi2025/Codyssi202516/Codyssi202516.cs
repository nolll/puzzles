using System.Numerics;
using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Lists;
using Pzl.Tools.Maths;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202516;

[Name("Leviathan Mindscape")]
public class Codyssi202516 : CodyssiPuzzle
{
    private const int GridSize = 80;

    public PuzzleResult Part1(string input, int gridSize = GridSize)
    {
        var cube = Execute(input, gridSize);
        var top2 = cube.Faces.Select(o => (long)o.Absorbtion).OrderDescending().Take(2).ToArray();
        var result = top2.First() * top2.Last();
        return new PuzzleResult(result, "daf580450a171146930ce60cd7756da5");
    }
    
    public PuzzleResult Part2(string input, int gridSize = GridSize)
    {
        var result = Execute(input, gridSize).Faces
            .Select(o => o.Grid)
            .Select(GetBestSum)
            .Aggregate(new BigInteger(1), (product, o) => product * o);
        return new PuzzleResult(result, "178f79ec48eeee9f4a62432ee8003d1e");
    }

    public PuzzleResult Part3(string input, int gridSize = GridSize)
    {
        var result = Execute(input, gridSize, true).Faces
            .Select(o => o.Grid)
            .Select(GetBestSum)
            .Aggregate(new BigInteger(1), (product, o) => product * o);
        return new PuzzleResult(result, "9215f7b88a764c37a7227b14051e4267");
    }

    private static Cube Execute(string input, int gridSize, bool wrapAround = false)
    {
        var cube = new Cube(gridSize);

        var (t, r) = input.Split(LineBreaks.Double);
        var transformations = t.Split(LineBreaks.Single);
        var rotations = r.ToCharArray();

        for (var i = 0; i < transformations.Length; i++)
        {
            var transformation = transformations[i];
            var parts = transformation.Split();
            var command = parts[0];
            var v = int.Parse(parts.Last());
            if (command == "ROW")
            {
                var row = int.Parse(parts[1]) - 1;
                CubeFace[] faces = wrapAround ? [cube.Front, cube.Right, cube.Back, cube.Left] : [cube.Front];
                foreach (var face in faces)
                {
                    var values = face.ReadRow(row).Select(o => Clamp(o + v)).ToList();
                    face.WriteRow(row, values);
                    face.Absorbtion += v * values.Count;
                }
            }
            else if (command == "COL")
            {
                var col = int.Parse(parts[1]) - 1;
                (CubeFace face, int col)[] faces = wrapAround ? [(cube.Front, col), (cube.Down, col), (cube.Back, cube.Back.Grid.XMax - col), (cube.Up, col)] : [(cube.Front, col)];
                foreach (var (face, c) in faces)
                {
                    var values = face.ReadColumn(c).Select(o => Clamp(o + v)).ToList();
                    face.WriteColumn(c, values);
                    face.Absorbtion += v * values.Count;
                }
            }
            else
            {
                var values = cube.Front.ReadAll().Select(o => Clamp(o + v)).ToList();
                cube.Front.WriteAll(values);
                cube.Front.Absorbtion += v * values.Count;
            }
            
            if (i >= rotations.Length)
                break;

            var rotation = rotations[i];
            cube.Rotate(rotation);
        }

        return cube;
    }

    private static int Clamp(int v) => MathTools.Clamp(v, 1, 100);

    private class Cube(int size)
    {
        private const int Initial = 1;
        
        public CubeFace Front { get; } = new(Initial, size);
        public CubeFace Up { get; } = new(Initial, size);
        public CubeFace Right { get; } = new(Initial, size);
        public CubeFace Down { get; } = new(Initial, size);
        public CubeFace Left { get; } = new(Initial, size);
        public CubeFace Back { get; } = new(Initial, size);

        public CubeFace[] Faces => [Front, Up, Right, Down, Left, Back];

        public void Rotate(char rotation) => GetRotateFunc(rotation)();

        private void RotateX()
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

        private void RotateXPrime()
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

        private void RotateY()
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

        private void RotateYPrime()
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
        
        private Action GetRotateFunc(char rotation) => rotation switch
        {
            'U' => RotateXPrime,
            'R' => RotateY,
            'D' => RotateX,
            _ => RotateYPrime
        };
    }

    private class CubeFace
    {
        private readonly int _size;
        private Grid<int> _grid;
        
        public int Absorbtion { get; set; } 

        public CubeFace(int initial, int size)
        {
            _size = size;
            _grid = new(_size, _size, initial);
        }

        public int[] ReadAll() => _grid.Values.ToArray();
        public int[] ReadColumn(int x) => Enumerable.Range(0, _size).Select(o => _grid.ReadValueAt(x, o)).ToArray();
        public int[] ReadRow(int y) => Enumerable.Range(0, _size).Select(o => _grid.ReadValueAt(o, y)).ToArray();

        public Grid<int> Grid => _grid.Clone();

        public void WriteAll(IEnumerable<int> values)
        {
            var charArray = values.ToArray();
            var coordsArray = _grid.Coords.ToArray();
            for (var i = 0; i < coordsArray.Length; i++)
            {
                _grid.WriteValueAt(coordsArray[i], charArray[i]);
            }
        }

        public void WriteRow(int y, IEnumerable<int> values)
        {
            var x = 0;
            foreach (var value in values)
            {
                _grid.WriteValueAt(x, y, value);
                x++;
            }
        }

        public void WriteColumn(int x, IEnumerable<int> values)
        {
            var y = 0;
            foreach (var value in values)
            {
                _grid.WriteValueAt(x, y, value);
                y++;
            }
        }

        public void RotateRight() => _grid = _grid.RotateRight();
        public void RotateLeft() => _grid = _grid.RotateLeft();
    }
    
    private static long GetBestSum(Grid<int> grid)
    {
        var best = 0L;
        for (var y = grid.YMin; y <= grid.YMax; y++)
        {
            best = Math.Max(best, grid.ReadRowValues(y).Sum());
        }
        
        for (var x = grid.XMin; x <= grid.XMax; x++)
        {
            best = Math.Max(best, grid.ReadColValues(x).Sum());
        }

        return best;
    }
}