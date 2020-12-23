using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advent_of_Code_2020.Extensions;
using System.Collections.Immutable;

namespace Advent_of_Code_2020.Days
{
    class Day23
    {
        public static long PartOne(string[] input)
        {
            var start = string.Join("", input).Select(x => int.Parse(x.ToString())).ToImmutableList();
            var cups = new LinkedList<int>(start);
            var output = Play(cups, 100);
            var sb = new StringBuilder();
            for (int i = 0; i < 8; ++i)
            {
                output = output.NextOrFirst();
                sb.Append(output.Value);
            }
            return long.Parse(sb.ToString());
        }

        public static ulong PartTwo(string[] input)
        {
            var start = string.Join("", input).Select(x => int.Parse(x.ToString())).ToImmutableList();
            start = start.AddRange(Enumerable.Range(10, 1000001 - 10));
            var cups = new LinkedList<int>(start);
            var output = Play(cups, 10000000);
            return (ulong)output.NextOrFirst().Value * (ulong)output.NextOrFirst().NextOrFirst().Value;
        }

        private static LinkedListNode<int> Play(LinkedList<int> cups, int rounds)
        {
            var index = new Dictionary<int, LinkedListNode<int>>();
            var start = cups.First;
            while(start != null)
            {
                index.Add(start.Value, start);
                start = start.Next;
            }
            var current = 0;
            var cup = cups.First;
            do
            {
                current++;
                var pickedUp = new List<LinkedListNode<int>>
                {
                    cup.NextOrFirst(), cup.NextOrFirst().NextOrFirst(), cup.NextOrFirst().NextOrFirst().NextOrFirst()
                };
                foreach(var p in pickedUp)
                {
                    cups.Remove(p);
                }

                var value = cup.Value - 1;
                while(value < 1 || pickedUp.Any(p => p.Value == value) || value == cup.Value)
                {
                    value--;
                    if(value < 1)
                    {
                        value = index.Count;
                    }
                }
                cup = cup.NextOrFirst();
                var target = index[value];
                foreach(var p in pickedUp)
                {
                    cups.AddAfter(target, p);
                    target = target.NextOrFirst();
                }
            } while (current < rounds);

            return index[1];
        }
    }
}
