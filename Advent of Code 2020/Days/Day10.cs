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
            var deviceJolt = joltages.Max() + 3;
            var steps = new Dictionary<int, long> { { deviceJolt, 1 } };
            foreach(var jolt in joltages.Reverse())
            {
                steps.TryGetValue(jolt + 1, out long j1);
                steps.TryGetValue(jolt + 2, out long j2);
                steps.TryGetValue(jolt + 3, out long j3);
                steps[jolt] = j1 + j2 + j3;
            }
            return steps[0];
        }
    }
}
