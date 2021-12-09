using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using App.Platform;
using App.Puzzles.Year2015.Day01;

namespace App
{
    public class PuzzleRepository
    {
        private readonly List<PuzzleWrapper> _allDays;
        
        public PuzzleRepository()
        {
            _allDays = CreateDays();
        }

        public PuzzleWrapper GetDay(int? selectedYear, int? selectedDay)
        {
            return selectedYear != null && selectedDay != null
                ? _allDays.FirstOrDefault(o => o.Year == selectedYear.Value &&  o.Day == selectedDay.Value)
                : _allDays.Last();
        }

        public List<PuzzleWrapper> GetEventDays(int? selectedYear)
        {
            if (selectedYear != null)
            {
                return _allDays.Where(o => o.Year == selectedYear).ToList();
            }

            var maxYear = _allDays.Select(o => o.Year).Max();
            return _allDays.Where(o => o.Year == maxYear).ToList();
        }
        
        public List<PuzzleWrapper> GetAll()
        {
            return _allDays;
        }

        private List<PuzzleWrapper> CreateDays()
        {
            var types = GetConcreteSubclassesOf<PuzzleDay>();
            return types.Select(CreateDay).OrderBy(o => o.Year).ThenBy(o => o.Day).ToList();
        }

        private PuzzleWrapper CreateDay(Type t)
        {
            var (year, day) = PuzzleParser.ParseType(t);
            var puzzleDay = (PuzzleDay)Activator.CreateInstance(t);
            if (puzzleDay == null)
                throw new Exception($"Could not create Puzzle for day {day} {year} ");
            
            return new PuzzleWrapper(year, day, puzzleDay);
        }

        private static IEnumerable<Type> GetConcreteSubclassesOf<T>() where T : class
        {
            var assembly = Assembly.GetAssembly(typeof(T));

            if (assembly == null)
                return new List<Type>();
            
            return assembly.GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T)));
        }
    }
}