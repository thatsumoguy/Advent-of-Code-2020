using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2020.Days
{
    class Day3
    {
        public static long PartOne(string[] input)
        {
            var lines = input.Select(c => c.ToCharArray()).ToArray();
            var width = input[0].Length;
            return RunSlope(lines, width, 1, 3);
        }

        public static long PartTwo(string[] input)
        {
            var lines = input.Select(c => c.ToCharArray()).ToArray();
            var width = input[0].Length;
            return RunSlope(lines, width, 1, 3)*RunSlope(lines, width, 1, 1)*RunSlope(lines, width, 1, 5)*RunSlope(lines, width, 1, 7)*RunSlope(lines, width, 2, 1);
        }

        private static long RunSlope(char[][] lines, int width, int down, int right)
        {
            var trees = 0L;
            var x = 0;
            for (var y = 0; y < lines.Length; y += down)
            {
                if(lines[y][x] =='#')
                {
                    trees++;
                }
                x = (x + right) % width;
            }
            return trees;
        }
    }
}
