using Pzl.Common;

namespace Pzl.Euler.Puzzles.Euler061;

[Name("Cyclical Figurate Numbers")]
public class Euler061 : EulerPuzzle
{
    private const int Lowerbound = 1000;
    private const int UpperBound = 9999;
    
    public PuzzleResult Run()
    {
        var numbers = new List<CyclicalNumber>();
        numbers.AddRange(GenerateNumbers(GenerateTriangular).Select(o => new CyclicalNumber(o, 3)));
        numbers.AddRange(GenerateNumbers(GenerateSquare).Select(o => new CyclicalNumber(o, 4)));
        numbers.AddRange(GenerateNumbers(GeneratePentagonal).Select(o => new CyclicalNumber(o, 5)));
        numbers.AddRange(GenerateNumbers(GenerateHexagonal).Select(o => new CyclicalNumber(o, 6)));
        numbers.AddRange(GenerateNumbers(GenerateHeptagonal).Select(o => new CyclicalNumber(o, 7)));
        numbers.AddRange(GenerateNumbers(GenerateOctagona).Select(o => new CyclicalNumber(o, 8)));
        numbers = numbers.Where(o => o.Last > 9).ToList();
        
        foreach (var a in numbers)
        {
            foreach (var b in numbers)
            {
                if (a.Number == b.Number)
                    continue;

                if (a.Category == b.Category)
                    continue;
                
                if(b.First == a.Last)
                    a.Links.Add(b);
            }
        }

        var potentialCycles = new List<List<CyclicalNumber>>();
        foreach (var number in numbers)
        {
            potentialCycles.AddRange(FindCycle([number]));
        }

        var validCycles = potentialCycles.Where(o => o.Last().Last == o.First().First);
        var sum = validCycles.First().Sum(o => o.Number);
        
        return new PuzzleResult(sum, "2000cca1f4a265ef136355dac9daadd1");
    }

    private List<List<CyclicalNumber>> FindCycle(List<CyclicalNumber> sequence)
    {
        if (sequence.Count == 6)
            return [sequence];

        var list = new List<List<CyclicalNumber>>();
        foreach (var link in sequence.Last().Links)
        {
            if(sequence.All(o => o.Category != link.Category))
                list.AddRange(FindCycle([..sequence, link]));
        }

        return list;
    }

    private static IEnumerable<int> GenerateNumbers(Func<int, int> generator)
    {
        var i = 1;
        while (true)
        {
            var n = generator(i);
            
            if (n > UpperBound)
                yield break;
            
            if (n >= Lowerbound)
                yield return n;

            i++;
        }
    }

    private static int GenerateTriangular(int i) => i * (i + 1) / 2;
    private static int GenerateSquare(int i) => i * i;
    private static int GeneratePentagonal(int i) => i * (3 * i - 1) / 2;
    private static int GenerateHexagonal(int i) => i * (2 * i - 1);
    private static int GenerateHeptagonal(int i) => i * (5 * i - 3) / 2;
    private static int GenerateOctagona(int i) => i * (3 * i - 2);

    private class CyclicalNumber
    {
        public int Number { get; }
        public int First { get; }
        public int Last { get; }
        public int Category { get; }
        public List<CyclicalNumber> Links { get; } = [];

        public CyclicalNumber(int number, int category)
        {
            Number = number;
            Category = category;
            var s = number.ToString();
            First = int.Parse(s[..2]);
            var s2 = s[2..].TrimStart('0');
            Last = s2.Length == 2 ? int.Parse(s2.TrimStart('0')) : 0;
        }
    }
}