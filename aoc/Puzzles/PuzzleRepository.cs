using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles;

public class PuzzleRepository
{
    private readonly List<PuzzleWrapper> _allDays;
        
    public PuzzleRepository()
    {
        _allDays = CreateDays();
    }

    public PuzzleWrapper GetDay(int? selectedYear, int? selectedDay) =>
        selectedYear != null && selectedDay != null
            ? _allDays.First(o => o.Id == $"{selectedYear.Value}{selectedDay.Value}")
            : _allDays.Last();

    public List<PuzzleWrapper> GetEventDays(int? selectedYear) =>
        selectedYear != null 
            ? _allDays.Where(o => o.Id.StartsWith(selectedYear.Value.ToString())).ToList() 
            : new List<PuzzleWrapper>();

    public List<PuzzleWrapper> GetAll() => _allDays;

    private static List<PuzzleWrapper> CreateDays() => 
        GetPuzzleClasses()
            .Select(CreateDay)
            .OrderBy(o => o.Id)
            .ToList();

    private static PuzzleWrapper CreateDay(Type t)
    {
        var (year, day) = AocPuzzleParser.GetYearAndDay(t);
        if (Activator.CreateInstance(t) is not AocPuzzle puzzleDay)
            throw new Exception($"Could not create Puzzle for day {day} {year} ");

        var id = $"{year}{day}";
        var dayStr = day.ToString().PadLeft(2, '0');
        var title = $"Day {day} {year}";
        var listTitle = $"Day {dayStr} {year}";
        return new PuzzleWrapper(id, title, listTitle, puzzleDay);
    }

    private static IEnumerable<Type> GetPuzzleClasses() => 
        GetConcreteSubclassesOf<AocPuzzle>().Where(IsPuzzle);

    private static bool IsPuzzle(Type type)
    {
        var ns = type.Namespace ?? string.Empty;
        return ns.Contains("Aoc.Puzzles");
    }

    private static IEnumerable<Type> GetConcreteSubclassesOf<T>() where T : class =>
        Assembly
            .GetAssembly(typeof(T))?
            .GetTypes()
            .Where(o => o.IsSubclassOf(typeof(T)) && o is
            {
                IsClass: true, IsAbstract: false
            }) 
        ?? new List<Type>();
}