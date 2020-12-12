using System;
using Core.Tools;

namespace ConsoleApp.Years
{
    public static class Printer
    {
        private const string Divider = "--------------------------------------------------";

        public static void PrintTime(TimeSpan timeTaken)
        {
            var time = Formatter.FormatTime(timeTaken);
            Console.WriteLine(time.PadLeft(Divider.Length));
        }

        public static void PrintDivider()
        {
            Console.WriteLine(Divider);
        }

    }
}