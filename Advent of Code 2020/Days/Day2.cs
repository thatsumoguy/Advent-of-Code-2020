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
            return input.Select(x => x.Split(new char[] { ' ', '-' })).Select(x => new Password(int.Parse(x[0]), int.Parse(x[1]), x[2][0], x[3]))
                .Where(x => x.Pass.Count(i => i == x.ValidChar) >= x.Min && x.Pass.Count(j => j == x.ValidChar) <= x.Max).Count(); ;
        }
        public static int PartTwo(string[] input)
        {
            return input.Select(x => x.Split(new char[] { ' ', '-' })).Select(x => new Password(int.Parse(x[0]), int.Parse(x[1]), x[2][0], x[3]))
                       .Where(x => x.Pass[x.Min -1] == x.ValidChar ^ x.Pass[x.Max -1] == x.ValidChar).Count();
        }
        record Password(int Min, int Max, char ValidChar, string Pass);
    }
}
