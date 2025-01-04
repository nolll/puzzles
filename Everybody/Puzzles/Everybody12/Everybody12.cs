using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Everybody12;

[Name("Desert Shower")]
public class Everybody12 : EverybodyPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var result = Part1And2(input);
        return new PuzzleResult(result, "7266a18eef65c4745c844164ef32f61d");
    }

    public PuzzleResult Part2(string input)
    {
        var result = Part1And2(input);
        return new PuzzleResult(result, "e6468a990e5dfdb3b572e72c4c24ed5b");
    }

    private int Part1And2(string input)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input, '.');
        matrix.ExtendUp(15);
        matrix.ExtendRight(20);

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
                var range = Enumerable.Range(0, power).ToArray();
                
                // Move up
                foreach (var _ in range)
                {
                    matrix.MoveUp();
                    matrix.MoveRight();
                }
                
                // Move right
                foreach (var _ in range)
                {
                    matrix.MoveRight();
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
                    if (matrix.Address.Y == matrix.YMax)
                    {
                        break;
                    }
                    
                    if (matrix.ReadValue() != 'T' && matrix.ReadValue() != 'H')
                        continue;
                    
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
                
                power++;
            }
        }

        var sum = 0;
        foreach (var key in bestShots.Keys)
        {
            var shot = bestShots[key];
            var multiplier = shot.name switch
            {
                'C' => 3,
                'B' => 2,
                _ => 1
            };

            var shotsRequired = matrix.ReadValueAt(key) == 'H'
                ? 2
                : 1;

            sum += shot.power * multiplier * shotsRequired;
        }

        return sum;
    }

    public PuzzleResult Part3(string input)
    {
        const string board = """
                             .C.
                             .B.
                             .A.
                             ===
                             """;
        
        var matrix = MatrixBuilder.BuildCharMatrix(board, '.');
        var meteors = input.Split(LineBreaks.Single)
            .Select(Numbers.IntsFromString)
            .Select(o => new MatrixAddress(o[0], o[1]))
            .ToList();
        
        var xMax = meteors.Max(o => o.X);
        var yMax = meteors.Max(o => o.Y);
        
        matrix.ExtendUp(yMax);
        matrix.ExtendRight(xMax);

        var aCoord = matrix.FindAddresses('A').First();
        var bCoord = matrix.FindAddresses('B').First();
        var cCoord = matrix.FindAddresses('C').First();
        (char name, MatrixAddress coord)[] catapults = [('A', aCoord), ('B', bCoord), ('C', cCoord)];

        var meteorCoords = GetAllMeteorCoords(matrix, meteors, aCoord, catapults);

        var trajectories = SimulateTrajectories(matrix, catapults, meteorCoords)
            .GroupBy(o => o.coord)
            .ToDictionary(o => o.Key, v => v.OrderBy(o => o.coord.Y).ThenBy(o => o.power).ToList());
        
        var bestList = new List<(char catapult, int altitude, int power, int time)>();
        foreach (var t in meteors)
        {
            var best = (catapult: ' ', altitude: int.MaxValue, power: int.MaxValue, time: 0);
            var meteor = t;
            var coord = new MatrixAddress(aCoord.X + meteor.X, aCoord.Y - meteor.Y);
            var isDone = false;
            var time = 0;
            while (!isDone)
            {
                if (trajectories.TryGetValue(coord, out var hits))
                {
                    var validHits = hits.Where(o => o.time <= time).ToList();
                    if (validHits.Any())
                    {
                        var bestHit = validHits.OrderBy(o => o.time).First();
                        if (bestHit.coord.Y < best.altitude || bestHit.coord.Y == best.altitude && bestHit.power < best.power)
                            best = (bestHit.catapult, bestHit.coord.Y, bestHit.power, bestHit.time);
                    }
                }

                coord = new MatrixAddress(coord.X - 1, coord.Y + 1);
                isDone = coord.Y == matrix.YMax ||
                         coord.X == matrix.XMin ||
                         catapults.Any(o => o.coord.Equals(coord));
                time++;
            }

            bestList.Add(best);
        }

        var sum = bestList.Sum(o => o.power);

        return new PuzzleResult(sum, "10d32566118d059169a691eef70e6b1e");
    }

    private List<(char catapult, MatrixAddress coord, int time, int power)> SimulateTrajectories(
        Matrix<char> matrix,
        (char name, MatrixAddress coord)[] catapults, 
        HashSet<MatrixAddress> meteorCoords)
    {
        var list = new List<(char catapult, MatrixAddress coord, int time, int power)>();
        foreach (var catapult in catapults)
        {
            var power = 1;
            var outOfBounds = false;
            var multiplier = catapult.name switch
            {
                'C' => 3,
                'B' => 2,
                _ => 1
            };
            while (!outOfBounds)
            {
                var t = 0;
                matrix.MoveTo(catapult.coord);
                var range = Enumerable.Range(0, power).ToArray();
            
                // Move up
                foreach (var _ in range)
                {
                    matrix.MoveUp();
                    matrix.MoveRight();
                    t++;
                    if(meteorCoords.Contains(matrix.Address))
                        list.Add((catapult.name, matrix.Address, t, power * multiplier));
                }
            
                // Move right
                foreach (var _ in range)
                {
                    matrix.MoveRight();
                    t++;
                    if(meteorCoords.Contains(matrix.Address))
                        list.Add((catapult.name, matrix.Address, t, power * multiplier));
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
                    if (matrix.Address.Y == matrix.YMax)
                    {
                        break;
                    }

                    t++;
                    if(meteorCoords.Contains(matrix.Address))
                        list.Add((catapult.name, matrix.Address, t, power * multiplier));
                }
            
                power++;
            }
        }

        return list;
    }

    private static HashSet<MatrixAddress> GetAllMeteorCoords(Matrix<char> matrix,
        List<MatrixAddress> meteors,
        MatrixAddress aCoord, (char name, MatrixAddress coord)[] catapults)
    {
        var coords = new HashSet<MatrixAddress>();
        for (var meteorId = 0; meteorId < meteors.Count; meteorId++)
        {
            var meteor = meteors[meteorId];
            var coord = new MatrixAddress(aCoord.X + meteor.X, aCoord.Y - meteor.Y);
            var isDone = false;
            while (!isDone)
            {
                coord = new MatrixAddress(coord.X - 1, coord.Y + 1);
                coords.Add(coord);
                isDone = coord.Y == matrix.YMax ||
                         coord.X == matrix.XMin ||
                         catapults.Any(o => o.coord.Equals(coord));
            }
        }

        return coords;
    }
}