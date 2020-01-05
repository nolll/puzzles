﻿using System.Collections.Generic;

namespace ConsoleApp.Years.Year2017
{
    public class Event2017 : Event
    {
        public Event2017() : base(2017)
        {
        }

        protected override IList<Day> Days => new List<Day>
        {
            new Day01()
        };
    }
}