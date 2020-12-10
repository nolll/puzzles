using System;
using Core.Tools;

namespace ConsoleApp.Years
{
    public static class Printer
    {
        private const string Divider = "--------------------------------------------------";

        public static void PrintTime(Timer timer)
        {
            var time = Formatter.FormatTimer(timer);
            Console.WriteLine(time.PadLeft(Divider.Length));
        }

        public static void PrintDivider()
        {
            Console.WriteLine(Divider);
        }

    }
}