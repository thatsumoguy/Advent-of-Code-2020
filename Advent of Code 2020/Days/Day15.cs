using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2020.Days
{
    class Day15
    {
        public static long PartOne(string[] input)
        {
            var spoken = string.Join("", input).Split(",").Select(int.Parse).ToArray();
            return Solve(spoken, 2020);
        }

        public static long PartTwo(string[] input)
        {
            var spoken = string.Join("", input).Split(",").Select(int.Parse).ToArray();
            return Solve(spoken, 30000000);
        }

        private static long Solve(int[] spoken, int turns)
        {
            var spokenNums = new int[turns];
            Array.Fill(spokenNums, -1);
            var i = 1;
            for (; i < spoken.Length + 1; i++)
            {
                spokenNums[spoken[i - 1]] = i;
            }
            var current = 0;
            for(; i < turns; i++)
            {
                var previous = spokenNums[current];
                spokenNums[current] = i;
                current = previous != -1 ? i - previous : 0;
            }
            return current;
        }
    }
}
