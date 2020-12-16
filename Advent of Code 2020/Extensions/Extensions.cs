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
    }
}
