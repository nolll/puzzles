﻿using System;
using Core.MineCarts;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day13 : Day2018
    {
        public Day13() : base(13)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var detector = new CollisionDetector(FileInput);

            var firstCollisionCoords = detector.LocationOfFirstCollision;
            var firstCollition = $"{firstCollisionCoords.X},{firstCollisionCoords.Y}";
            Console.WriteLine($"First crash location: {firstCollition}");

            WritePartTitle();

            var lastCartCoords = detector.LocationOfLastCart;
            var lastCart = $"{lastCartCoords.X},{lastCartCoords.Y}";
            Console.WriteLine($"Last cart location: {lastCart}");
        }
    }
}