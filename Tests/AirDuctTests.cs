using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Core.Tools;
using NUnit.Framework;

namespace Tests
{
    public class AirDuctTests
    {
        [Test]
        public void FindsClosestRoute()
        {
            const string input = @"
###########
#0.1.....2#
#.#######.#
#4.......3#
###########";

            var robot = new AirDuctRobot(input);
        }
    }

    public class AirDuctRobot
    {
        private Matrix<char> _map;
        private List<MatrixAddress> _targets;

        public AirDuctRobot(string input)
        {
            Init(input);
            Console.WriteLine(_map.Print());
        }

        private void Init(string input)
        {
            var rows = PuzzleInputReader.Read(input);
            _map = new Matrix<char>();
            _targets = new List<MatrixAddress>();
            var x = 0;
            var y = 0;

            foreach (var row in rows)
            {
                foreach (var c in row)
                {
                    _map.MoveTo(x, y);
                    if (c != '#' && c != '.')
                    {
                        _targets.Add(_map.Address);
                        _map.WriteValue('.');
                    }
                    else
                    {
                        _map.WriteValue(c);
                    }
                        
                    x++;
                }

                y++;
                x = 0;
            }
        }
    }
}