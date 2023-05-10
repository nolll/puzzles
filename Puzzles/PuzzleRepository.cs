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

    public PuzzleDay GetDay(int? selectedYear, int? selectedDay)
    {
        return selectedYear != null && selectedDay != null
            ? _allDays.FirstOrDefault(o => o.Year == selectedYear.Value &&  o.Day == selectedDay.Value)
            : _allDays.Last();
    }

    public List<PuzzleDay> GetEventDays(int? selectedYear)
    {
        if (selectedYear != null)
        {
            return _allDays.Where(o => o.Year == selectedYear).ToList();
        }

        var maxYear = _allDays.Select(o => o.Year).Max();
        return _allDays.Where(o => o.Year == maxYear).ToList();
    }
        
    public List<PuzzleDay> GetAll()
    {
        return _allDays;
    }

    private List<PuzzleDay> CreateDays()
    {
        var types = GetConcreteSubclassesOf<Puzzle>();
        return types.Select(CreateDay).OrderBy(o => o.Year).ThenBy(o => o.Day).ToList();
    }

    private PuzzleDay CreateDay(Type t)
    {
        var (year, day) = PuzzleParser.ParseType(t);
        var puzzleDay = (Puzzle)Activator.CreateInstance(t);
        if (puzzleDay == null)
            throw new Exception($"Could not create Puzzle for day {day} {year} ");
            
        return new PuzzleDay(year, day, puzzleDay);
    }

    private static IEnumerable<Type> GetConcreteSubclassesOf<T>() where T : class
    {
        var assembly = Assembly.GetAssembly(typeof(T));

        if (assembly == null)
            return new List<Type>();
            
        return assembly.GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T)));
    }
}