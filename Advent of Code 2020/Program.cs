﻿using System;
using System.IO;
using System.Linq;

namespace Advent_of_Code_2020
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines(@"C:\Users\Kyle Rinne\source\repos\Advent of Code 2020\Advent of Code 2020\Input\Day24.txt");
            Console.WriteLine("Part One: " + Days.Day24.PartOne(input));
            Console.WriteLine("Part Two: " + Days.Day24.PartTwo(input));
            Console.ReadLine();
        }
    }
}
