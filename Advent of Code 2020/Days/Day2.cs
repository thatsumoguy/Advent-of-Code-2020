using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Advent_of_Code_2020.Days
{
    class Day2
    {
        public static int PartOne(string[] input)
        {
            var line = input.Select(x => x.Split(new char[] { ' ', '-' })).Select(x => new Password(int.Parse(x[0]), int.Parse(x[1]), x[2][0], x[3]));
            return line.Where(x => x.pass.Count(i => i == x.validChar) >= x.min && x.pass.Count(j => j == x.validChar) <= x.max).Count();
        }
        public static int PartTwo(string[] input)
        {
            var line = input.Select(x => x.Split(new char[] { ' ', '-' })).Select(x => new Password(int.Parse(x[0]), int.Parse(x[1]), x[2][0], x[3]));
            return line.Where(x => x.pass.Count(i => i == x.validChar) >= x.min ^ x.pass.Count(j => j == x.validChar) <= x.max).Count();
        }
        record Password(int min, int max, char validChar, string pass);
    }
}
