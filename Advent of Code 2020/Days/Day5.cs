using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2020.Days
{
    class Day5
    {
        public static int PartOne(string[] input)
        {
            var rows = input.Select(l => Convert.ToByte(l.Substring(0, 7).Aggregate("0", (s, c) => s + c switch { 'F' => '0', 'B' => '1' }), 2)).ToArray();
            var cols = input.Select(l => Convert.ToByte(l.Substring(7).Aggregate("0", (s, c) =>s + c switch { 'L' => '0', 'R' => '1' }), 2)).ToArray();
            return rows.Zip(cols).Select(z => z.First * 8 + z.Second).OrderBy(id => id).ToArray().Max();
        }

        public static int PartTwo(string[] input)
        {
            var rows = input.Select(l => Convert.ToByte(l.Substring(0, 7).Aggregate("0", (s, c) => s + c switch { 'F' => '0', 'B' => '1' }), 2)).ToArray();
            var cols = input.Select(l => Convert.ToByte(l.Substring(7).Aggregate("0", (s, c) => s + c switch { 'L' => '0', 'R' => '1' }), 2)).ToArray();
            var ids = rows.Zip(cols).Select(z => z.First * 8 + z.Second).OrderBy(id => id).ToArray();
            var mine = ids.Zip(ids.Skip(1)).Where(z => z.Second - z.First > 1);
            return mine.First().First +1;
        }
    }
}
