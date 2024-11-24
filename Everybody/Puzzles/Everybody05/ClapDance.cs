namespace Pzl.Everybody.Puzzles.Everybody05;

public class ClapDance(List<List<int>> columns)
{
    public string DanceRounds(int rounds)
    {
        var shout = "";
        
        //Console.WriteLine("Start");
        //Print();
        
        for (var round = 1; round <= rounds; round++)
        {
            shout = Dance(round);
        }
        
        return shout;
    }
    
    public long DanceUntilRepeatCount(int target)
    {
        var counter = new Dictionary<string, int>();
        var round = 1;
        
        //Console.WriteLine("Start");
        //Print();
        
        while (true)
        {
            var shout = Dance(round);
            if (!counter.TryAdd(shout, 1))
                counter[shout]++;

            if (counter[shout] == target)
            {
                return long.Parse(shout) * round;
            }

            round++;
        }

        throw new Exception("Never finished");
    }

    private string Dance(int round)
    {
        var clapperCol = (round - 1) % columns.Count;
        var danceCol = (clapperCol + 1) % columns.Count;
        var clapper = columns[clapperCol][0];
        columns[clapperCol].RemoveAt(0);
        var direction = 1;
        var dancerIndex = -1;
        for (var i = 0; i < clapper; i++)
        {
            dancerIndex += direction;
            
            if (dancerIndex >= columns[danceCol].Count || dancerIndex < 0)
            {
                direction *= -1;
                dancerIndex += direction;
            }
        }

        var insertIndex = direction > 0 ? dancerIndex : dancerIndex + 1;
        if (insertIndex > columns[danceCol].Count)
            columns[danceCol].Add(clapper);
        else
            columns[danceCol].Insert(insertIndex, clapper);

        //Console.WriteLine($"Round {round}");
        //Print();
        
        return string.Join("", columns.Select(o => o.First()));
    }

    private void Print()
    {
        var maxLength = columns.Max(o => o.Count);
        for (var i = 0; i < maxLength; i++)
        {
            foreach (var column in columns)
            {
                var v = column.Count > i
                    ? column[i].ToString()
                    : " ";
                Console.Write($"{v} ");
            }
            Console.WriteLine();
        }
    }
}