using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2020.Extensions
{
    public static class Extensions
    {
        public static string[] SplitLines(this string input)
        {
            return input.Split(new[] { "\r", "\n", "\r\n" }, StringSplitOptions.None).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
        }

        public static int GetSequenceHashCode<T>(this IList<T> sequence)
        {
            const int seed = 487;
            const int modifier = 31;

            unchecked
            {
                return sequence.Aggregate(seed, (current, item) =>
                    (current * modifier) + item.GetHashCode());
            }
        }
    }
}
