using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2020.Days
{
    class Day9
    {
        public static long PartOne(string[] input)
        {
            var xmas = input.Select(x => long.Parse(x)).ToArray();
            foreach(var r in Enumerable.Range(25, input.Length))
            {
                var matched = false;
                foreach(var i in Enumerable.Range(r - 25, r))
                {
                    foreach(var j  in Enumerable.Range(r - 25, r))
                    {
                        if(xmas[i] != xmas[j] && xmas[i] + xmas[j] == xmas[r])
                        {
                            matched = true;
                        }
                    }
                }
                if(!matched)
                {
                    return xmas[r];
                }
            }
            return 0;
        }

        public static long PartTwo(string[] input)
        {
            var xmas = input.Select(x => long.Parse(x)).ToArray();
            var invalidNum = 0L;
            foreach (var r in Enumerable.Range(25, input.Length))
            {
                var matched = false;
                foreach (var i in Enumerable.Range(r - 25, r))
                {
                    foreach (var j in Enumerable.Range(r - 25, r))
                    {
                        if (xmas[i] != xmas[j] && xmas[i] + xmas[j] == xmas[r])
                        {
                            matched = true;
                        }
                    }
                }
                if (!matched)
                {
                    invalidNum = xmas[r];
                    break;
                }
            }
            foreach(var i in Enumerable.Range(0, xmas.Length))
            {
                foreach(var j  in Enumerable.Range(i + 2, i))
                {
                    var current = xmas[i..j];
                    var sum = current.Sum();
                    if(sum == invalidNum)
                    {
                        return current.Min() + current.Max();
                    }
                }
            }
            return 0;
        }
    }
}
