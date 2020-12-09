using System;
using Core.PresentDelivery;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day03 : Day2015
    {
        public Day03() : base(3)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var grid1 = new DeliveryGrid();
            grid1.DeliverBySanta(FileInput);
            Console.WriteLine($"Presents delivered to {grid1.SantaDeliveryCount} houses by Santa");

            WritePartTitle();
            var grid2 = new DeliveryGrid();
            grid2.DeliverBySantaAndRobot(FileInput);
            Console.WriteLine($"Presents delivered to {grid2.SantaDeliveryCount} houses by Santa and robot");
        }
    }
}