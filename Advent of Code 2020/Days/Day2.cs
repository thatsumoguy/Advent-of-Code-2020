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
            var output = 0;
            foreach(var line in input)
            {
                var min = int.Parse(line.Substring(0, (line.IndexOf('-'))));
                var max = int.Parse(line.Substring((line.IndexOf('-') + 1), (line.IndexOf(' ') - line.IndexOf('-'))));
                var validChar = line[line.IndexOf(':') -1];
                var password = line.Substring(line.IndexOf(':') + 2, (line.Length - line.IndexOf(':') - 2));
                var count = password.Count(c => c == validChar);
                if(count >= min && count <= max)
                {
                    output++;
                }
            }

            return output;
        }
        public static int PartTwo(string[] input)
        {
            var output = 0;
            foreach (var line in input)
            {
                var min = int.Parse(line.Substring(0, (line.IndexOf('-'))));
                var max = int.Parse(line.Substring((line.IndexOf('-') + 1), (line.IndexOf(' ') - line.IndexOf('-'))));
                var validChar = line[line.IndexOf(':') - 1];
                var password = line.Substring(line.IndexOf(':') + 2, (line.Length - line.IndexOf(':') - 2));
                if(password[min -1] == validChar ^ password[max -1] == validChar)
                {
                    output++;
                }
            }

            return output;
        }
    }
}
