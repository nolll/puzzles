using System;
using Core.RoomValidation;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day04 : Day2016
    {
        public Day04() : base(4)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var validator = new RoomValidator(FileInput);
            var sum = validator.SumOfIds;
            Console.WriteLine($"Sum of valid room ids: {sum}");

            WritePartTitle();
            Console.WriteLine($"Northpole object storage room: {validator.NorthpoleObjectStorageId}");
        }
    }
}