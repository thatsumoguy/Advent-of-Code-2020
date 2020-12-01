using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advent_of_Code_2020.Days
{
    class Day1
    {
        public static int PartOne(string[] input)
        {
            var expense = input.Select(int.Parse).ToArray();
            var outcome = 0;
            var correct = 2020;
            foreach (var range in Enumerable.Range(0, expense.Length))
            {
                for (var r = range + 1; r < expense.Length; r++)
                {
                    if (expense[range] + expense[r] == correct)
                    {
                        outcome = expense[range] * expense[r];
                    }
                }
            }
            return outcome;
        }
        public static int PartTwo(string[] input)
        {
            var expense = input.Select(int.Parse).ToArray();
            var outcome = 0;
            var correct = 2020;
            foreach (var range in Enumerable.Range(0, expense.Length))
            {
                for (var r = range + 1; r < expense.Length; r++)
                {
                    for (var j = r + 1; j < expense.Length; j++)
                    {
                        if (expense[range] + expense[r] + expense[j] == correct)
                        {
                            outcome = expense[range] * expense[r] * expense[j];
                        }
                    }
                }
            }
            return outcome;
        }
    }
}
