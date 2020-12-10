using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2020.Days
{
    class Day10
    {
        public static int PartOne(string[] input)
        {
            var joltages = input.Select(x => int.Parse(x)).OrderBy(x => x).ToArray();
            var oneDifference = 0;
            var threeDifference = 1;
            var currentJolt = 0;
            foreach (var jolt in joltages)
            {
                var differences = jolt - currentJolt;
                if(differences == 3)
                {
                    threeDifference++;
                }
                if(differences == 1)
                {
                    oneDifference++;
                }
                currentJolt = jolt;
            }
            return oneDifference * threeDifference;
        }

        public static long PartTwo(string[] input)
        {
            var joltages = input.Select(x => int.Parse(x)).Append(0).OrderBy(x => x).ToArray();
            var steps = new long[joltages.Length];
            steps[0] = 1;
            foreach(var i in Enumerable.Range(1, joltages.Length - 1))
            {
                foreach(var j in Enumerable.Range(0, i))
                {
                    if(joltages[i] - joltages[j] <= 3)
                    {
                        steps[i] += steps[j];
                    }
                }
            }
            return steps.Last();
        }
    }
}
