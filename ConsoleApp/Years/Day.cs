using System;
using System.IO;
using System.Text;

namespace ConsoleApp.Years
{
    public abstract class Day
    {
        public abstract int Year { get; }
        public int Id { get; }
        public virtual string Comment => "";
        public virtual bool IsSlow => false;
        public virtual bool NeedsRewrite => false;

        protected Day(int day)
        {
            Id = day;
        }

        public virtual PuzzleResult RunPart1()
        {
            return null;
        }

        public virtual PuzzleResult RunPart2()
        {
            return null;
        }

        protected string FileInput
        {
            get
            {
                var filePath = FilePath;
                if(!File.Exists(filePath))
                    throw new FileNotFoundException("File not found", filePath);

                return File.ReadAllText(filePath, Encoding.UTF8);
            }
        }

        private string FilePath => Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Years",
                $"Year{Year}",
                "Inputs",
                $"{PaddedDay}.txt");

        private string PaddedDay => Id.ToString().PadLeft(2, '0');
    }
}