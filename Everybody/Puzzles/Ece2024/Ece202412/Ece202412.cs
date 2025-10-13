using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2024.Ece202412;

[Name("Desert Shower")]
public class Ece202412 : EverybodyEventPuzzle
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
                foreach (var _ in range) matrix.MoveRight();

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
                        break;
                    
                    if (matrix.ReadValue() != 'T' && matrix.ReadValue() != 'H')
                        continue;
                    
                    if (bestShots.TryGetValue(matrix.Address, out var bestShot))
                    {
                        if(power < bestShot.power)
                            bestShots[matrix.Address] = (catapult.name, power);
                    }
                    else
                        bestShots[matrix.Address] = (catapult.name, power);
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
        var meteors = input.Split(LineBreaks.Single)
            .Select(Numbers.IntsFromString)
            .Select(o => (x: o[0], y: o[1]))
            .ToList();

        var aCoord = (x: 0, y: 2);
        var bCoord = (x: 0, y: 1);
        var cCoord = (x: 0, y: 0);
        (char name, (int x, int y) coord)[] catapults = [('A', aCoord), ('B', bCoord), ('C', cCoord)];
        
        var limits = (xmin: 0, xmax: meteors.Max(o => o.x), ymax: aCoord.y + 1);
        var meteorCoords = GetAllMeteorCoords(limits, meteors, aCoord, catapults);

        var trajectories = SimulateTrajectories(limits, catapults, meteorCoords)
            .GroupBy(o => o.coord)
            .ToDictionary(o => o.Key, v => v.OrderBy(o => o.coord.y).ThenBy(o => o.power).ToList());
        
        var bestList = new List<(int altitude, int power, int time)>();
        foreach (var meteor in meteors)
        {
            var best = (altitude: int.MaxValue, power: int.MaxValue, time: 0);
            var coord = (x: aCoord.x + meteor.x, y: aCoord.y - meteor.y);
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
                        if (bestHit.coord.y < best.altitude || bestHit.coord.y == best.altitude && bestHit.power < best.power)
                            best = (bestHit.coord.y, bestHit.power, bestHit.time);
                    }
                }

                coord = (coord.x - 1, coord.y + 1);
                isDone = coord.y == limits.ymax ||
                         coord.x == limits.xmin ||
                         catapults.Any(o => o.coord.Equals(coord));
                time++;
            }

            bestList.Add(best);
        }

        var sum = bestList.Sum(o => o.power);

        return new PuzzleResult(sum, "10d32566118d059169a691eef70e6b1e");
    }

    private List<((int x, int y) coord, int time, int power)> SimulateTrajectories(
        (int xmin, int xmax, int ymax) limits,
        (char name, (int x, int y) coord)[] catapults,
        HashSet<(int x, int y)> meteorCoords)
    {
        var list = new List<((int x, int y) coord, int time, int power)>();
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
                var (x, y) = catapult.coord;
                var range = Enumerable.Range(0, power).ToArray();
            
                // Move up
                foreach (var _ in range)
                {
                    y--;
                    x++;
                    t++;
                    if(meteorCoords.Contains((x, y)))
                        list.Add(((x, y), t, power * multiplier));
                }
            
                // Move right
                foreach (var _ in range)
                {
                    x++;
                    t++;
                    if(meteorCoords.Contains((x, y)))
                        list.Add(((x, y), t, power * multiplier));
                }

                // Move down until bottom
                while (true)
                {
                    x++;
                    if (x > limits.xmax)
                    {
                        outOfBounds = true;
                        break;
                    }

                    y++;
                    if (y == limits.ymax)
                        break;

                    t++;
                    if(meteorCoords.Contains((x, y)))
                        list.Add(((x, y), t, power * multiplier));
                }
            
                power++;
            }
        }

        return list;
    }

    private static HashSet<(int x, int y)> GetAllMeteorCoords(
        (int xmin, int xmax, int ymax) limits,
        List<(int x, int y)> meteors,
        (int x, int y) aCoord,
        (char name, (int x, int y) coord)[] catapults)
    {
        var coords = new HashSet<(int x, int y)>();
        for (var meteorId = 0; meteorId < meteors.Count; meteorId++)
        {
            var meteor = meteors[meteorId];
            var coord = (x: aCoord.x + meteor.x, y: aCoord.y - meteor.y);
            var isDone = false;
            while (!isDone)
            {
                coord = (coord.x - 1, coord.y + 1);
                coords.Add(coord);
                isDone = coord.y == limits.ymax ||
                         coord.x == limits.xmin ||
                         catapults.Any(o => o.coord.Equals(coord));
            }
        }

        return coords;
    }
}