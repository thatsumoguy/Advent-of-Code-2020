using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2020.Days
{
    class Day13
    {
        public static double PartOne(string[] input)
        {
            var earliest = int.Parse(input[0]);
            var busIds = input[1].Split(',').Where(i => i != "x").Select(j => int.Parse(j)).ToList();
            var startTime = earliest;
            while (true)
            {
                startTime++;
                foreach (var bus in busIds)
                {
                    if (startTime % bus == 0)
                    {
                        return bus * (startTime - earliest);
                    }
                }
            }
        }

        public static long PartTwo(string[] input)
        {
            return ChineseRemainderTheorem.Solve(input[1].Split(',')
                .Select(x => long.TryParse(x, out var y) ? y : 0)
                .Where(x => x > 0).ToArray(), 
                input[1].Split(',')
                .Select(x => long.TryParse(x, out var y) ? y : 0)
                .Select((x, i) => new { i, x })
                .Where(x => x.x > 0).Select(x => (x.x - x.i) % x.x).ToArray());
        }
    }
    public static class ChineseRemainderTheorem
    {
        public static long Solve(long[] n, long[] a)
        {
            long prod = n.Aggregate(1, (long i, long j) => i * j);
            long p;
            long sm = 0;
            for (int i = 0; i < n.Length; i++)
            {
                p = prod / n[i];
                sm += a[i] * ModularMultiplicativeInverse(p, n[i]) * p;
            }
            return sm % prod;
        }

        private static long ModularMultiplicativeInverse(long a, long mod)
        {
            long b = a % mod;
            for (int x = 1; x < mod; x++)
            {
                if ((b * x) % mod == 1)
                {
                    return x;
                }
            }
            return 1;
        }
    }
}