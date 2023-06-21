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
            ? _allDays.FirstOrDefault(o => o.Year == selectedYear.Value &&  o.Day == selectedDay.Value)
            : _allDays.Last();

    public List<PuzzleDay> GetEventDays(int? selectedYear)
    {
        if (selectedYear != null)
            return _allDays.Where(o => o.Year == selectedYear).ToList();

        var maxYear = _allDays.Select(o => o.Year).Max();
        return _allDays.Where(o => o.Year == maxYear).ToList();
    }
        
    public List<PuzzleDay> GetAll() => _allDays;

    private List<PuzzleDay> CreateDays() => 
        GetPuzzleClasses()
            .Select(CreateDay)
            .OrderBy(o => o.Year)
            .ThenBy(o => o.Day)
            .ToList();

    private static PuzzleDay CreateDay(Type t)
    {
        var (year, day) = PuzzleParser.ParseType(t);
        var puzzleDay = (Puzzle)Activator.CreateInstance(t);
        if (puzzleDay == null)
            throw new Exception($"Could not create Puzzle for day {day} {year} ");
            
        return new PuzzleDay(year, day, puzzleDay);
    }

    private static IEnumerable<Type> GetPuzzleClasses() => 
        GetConcreteSubclassesOf<Puzzle>().Where(IsPuzzle);

    private static bool IsPuzzle(Type type)
    {
        var ns = type.Namespace ?? string.Empty;
        return ns.Contains("Aoc.Puzzles");
    }

    private static IEnumerable<Type> GetConcreteSubclassesOf<T>() where T : class
    {
        var assembly = Assembly.GetAssembly(typeof(T));

        return assembly != null
            ? assembly.GetTypes().Where(o => o.IsClass && !o.IsAbstract && o.IsSubclassOf(typeof(T))) 
            : new List<Type>();
    }
}