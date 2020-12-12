using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Numerics;

namespace Advent_of_Code_2020.Days
{
    class Day12
    {
        public static double PartOne(string[] input)
        {
            var currentFacing = new Complex(0, 0);
            var movingDirection = new Complex(1, 0);
            foreach(var line in input)
            {
                var direction = line[0];
                var distance = int.Parse(line[1..]);
                switch (direction)
                {
                    case 'F':
                        currentFacing += distance * (movingDirection / Complex.Abs(movingDirection));
                        break;
                    case 'N':
                        currentFacing += distance * new Complex(0, 1);
                        break;
                    case 'S':
                        currentFacing -= distance * new Complex(0, 1);
                        break;
                    case 'E':
                        currentFacing += distance;
                        break;
                    case 'W':
                        currentFacing -= distance;
                        break;
                    case 'L':
                        movingDirection *= Complex.Pow(new Complex(0, 1), (distance / 90));
                        break;
                    case 'R':
                        movingDirection /= Complex.Pow(new Complex(0, 1), (distance / 90));
                        break;
                }
            }
            return Math.Abs(currentFacing.Real) + Math.Abs(currentFacing.Imaginary);
        }

        public static double PartTwo(string[] input)
        {
            var currentFacing = new Complex(0, 0);
            var waypoint = new Complex(10, 1);
            foreach (var line in input)
            {
                var direction = line[0];
                var distance = int.Parse(line[1..]);
                switch (direction)
                {
                    case 'F':
                        currentFacing += distance * waypoint;
                        break;
                    case 'N':
                        waypoint += new Complex(0, distance);
                        break;
                    case 'S':
                        waypoint += new Complex(0, -distance);
                        break;
                    case 'E':
                        waypoint += new Complex(distance, 0);
                        break;
                    case 'W':
                        waypoint += new Complex(-distance, 0);
                        break;
                    case 'L':
                        while (distance > 0)
                        {
                            waypoint *= new Complex(0, 1);
                            distance -= 90;
                        }
                        break;
                    case 'R':
                        while (distance > 0)
                        {
                            waypoint *= new Complex(0, -1);
                            distance -= 90;
                        }
                        break;
                }
            }
            return Math.Abs(currentFacing.Real) + Math.Abs(currentFacing.Imaginary);
        }
    }
}
