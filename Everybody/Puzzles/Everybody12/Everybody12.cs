using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Everybody.Puzzles.Everybody12;

[Name("Desert Shower")]
public class Everybody12 : EverybodyPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input, '.');
        matrix.ExtendUp(15);

        var aCoord = matrix.FindAddresses('A').First();
        var bCoord = matrix.FindAddresses('B').First();
        var cCoord = matrix.FindAddresses('C').First();
        (char name, MatrixAddress coord)[] catapults = [('A', aCoord), ('B', bCoord), ('C', cCoord)];

        var bestShots = new Dictionary<MatrixAddress, (char name, int power)>();
        foreach (var catapult in catapults)
        {
            var power = 1;
            var outOfBounds = false;
            while (!outOfBounds)
            {
                matrix.MoveTo(catapult.coord);
                var pmatrix = matrix.Clone();
                var range = Enumerable.Range(0, power).ToArray();
                
                // Move up
                foreach (var _ in range)
                {
                    matrix.MoveUp();
                    matrix.MoveRight();
                    pmatrix.WriteValueAt(matrix.Address, '*');
                }
                
                // Move right
                foreach (var _ in range)
                {
                    matrix.MoveRight();
                    pmatrix.WriteValueAt(matrix.Address, '*');
                }

                // Move down until bottom
                while (true)
                {
                    if (!matrix.TryMoveRight())
                    {
                        outOfBounds = true;
                        break;
                    }

                    matrix.MoveDown();
                    pmatrix.WriteValueAt(matrix.Address, '*');
                    if (matrix.ReadValue() == '=')
                    {
                        break;
                    }
                    
                    if (matrix.ReadValue() != 'T')
                        continue;
                    
                    pmatrix.WriteValueAt(matrix.Address, 'X');
                    
                    if (bestShots.TryGetValue(matrix.Address, out var bestShot))
                    {
                        if(power < bestShot.power)
                            bestShots[matrix.Address] = (catapult.name, power);
                    }
                    else
                    {
                        bestShots[matrix.Address] = (catapult.name, power);
                    }
                }

                var print = pmatrix.Print();
                //Console.WriteLine(print);
                
                power++;
            }
        }

        var sum = 0;
        foreach (var shot in bestShots.Values)
        {
            var multiplier = shot.name switch
            {
                'C' => 3,
                'B' => 2,
                _ => 1
            };

            sum += shot.power * multiplier;
        }
        
        return new PuzzleResult(sum, "7266a18eef65c4745c844164ef32f61d");
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