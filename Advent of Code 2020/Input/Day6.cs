using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2020.Days
{
    class Day6
    {
        public static int PartOne(string[] input)
        {
            return string.Join("\n", input).Split("\n\n").Select(x => x.Replace("\n", "").ToCharArray().Distinct().Count()).Sum();
        }

        public static int PartTwo(string[] input)
        {
            return string.Join("\n", input).Split("\n\n").Select(x => x.Split("\n").Select(l => l.ToCharArray().Distinct()))
                .Select(g => g.Aggregate((prev, next) => prev.Intersect(next).ToList()).Count()).Sum();
        }
    }
}
