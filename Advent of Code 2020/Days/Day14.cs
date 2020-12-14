using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2020.Days
{
    class Day14
    {
        public static long PartOne(string[] input)
        {
            var mask = "";
            var mem = new Dictionary<long, string>();
            foreach(var line in input)
            {
                if(line.StartsWith("mask"))
                {
                    mask = line.Split("= ")[1];
                    continue;
                }
                var startBracket = line.IndexOf("[") + 1;
                var lastBracket = line.LastIndexOf("]");
                var index = int.Parse(line[startBracket..lastBracket]);
                var value = Convert.ToString(int.Parse(line.Split("= ")[1]), 2).PadLeft(36, '0').ToArray();
                for(var i = 0; i < mask.Length; i++)
                {
                    value[i] = mask[i] == 'X' ? value[i] : mask[i];
                }
                mem[index] = string.Join("", value);
            }
            return mem.Sum(x => Convert.ToInt64(x.Value, 2));
        }

        public static long PartTwo(string[] input)
        {
            var mask = "";
            var mem = new Dictionary<long, string>();
            foreach (var line in input)
            {
                if (line.StartsWith("mask"))
                {
                    mask = line.Split("= ")[1];
                    continue;
                }
                var startBracket = line.IndexOf("[") + 1;
                var lastBracket = line.LastIndexOf("]");
                var index = int.Parse(line[startBracket..lastBracket]);
                var value = Convert.ToString(int.Parse(line.Split("= ")[1]), 2).PadLeft(36, '0');
                var indexValue = Convert.ToString(index, 2).PadLeft(36, '0').ToArray();
                for (var i = 0; i < mask.Length; i++)
                {
                    indexValue[i] = mask[i] == '0' ? indexValue[i] : mask[i];
                }
                var addresses = GenerateAddresses(string.Join("", indexValue));
                foreach (var address in addresses)
                {
                    mem[Convert.ToInt64(address, 2)] = value;
                }
            }
            return mem.Sum(x => Convert.ToInt64(x.Value, 2));
        }
        private static IEnumerable<string> GenerateAddresses(string address)
        {
            if (!address.Any(c => c.Equals('X')))
            {
                return new List<string> { address };
            }
            else
            {
                var index = address.IndexOf("X");
                return GenerateAddresses(index < 0 ? address : address.Remove(index, 1).Insert(index, "0")).Concat(GenerateAddresses(index < 0 ? address : address.Remove(index, 1).Insert(index, "1")));
            }
        }
    }
}
