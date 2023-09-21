using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Aoc.Platform;

namespace Aoc.Puzzles;

public class PuzzleRepository
{
    private readonly List<PuzzleDay> _allDays;
        
    public PuzzleRepository()
    {
        _allDays = CreateDays();
    }

    public PuzzleDay GetDay(int? selectedYear, int? selectedDay) =>
        selectedYear != null && selectedDay != null
            ? _allDays.First(o => o.Year == selectedYear.Value &&  o.Day == selectedDay.Value)
            : _allDays.Last();

    public List<PuzzleDay> GetEventDays(int? selectedYear) =>
        selectedYear != null 
            ? _allDays.Where(o => o.Year == selectedYear).ToList() 
            : new List<PuzzleDay>();

    public List<PuzzleDay> GetAll() => _allDays;

    private static List<PuzzleDay> CreateDays() => 
        GetPuzzleClasses()
            .Select(CreateDay)
            .OrderBy(o => o.Year)
            .ThenBy(o => o.Day)
            .ToList();

    private static PuzzleDay CreateDay(Type t)
    {
        var (year, day) = PuzzleParser.GetYearAndDay(t);
        if (Activator.CreateInstance(t) is not AocPuzzle puzzleDay)
            throw new Exception($"Could not create Puzzle for day {day} {year} ");
            
        return new PuzzleDay(year, day, puzzleDay);
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