using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2020.Days
{
    class Day7
    {
        public static long PartOne(string[] input)
        {
            var bags = Parse(input);
            var goldenBag = bags["shiny gold"];
            return goldenBag.ParentColors().ToHashSet().Count();
        }

        public static long PartTwo(string[] input)
        {
            var bags = Parse(input);
            var goldenBag = bags["shiny gold"];
            return goldenBag.CountBags();
        }
        private static Dictionary<string, Bag> Parse(string[] input)
        {
            var bags = new Dictionary<string, Bag>();
            foreach(var line in input)
            {
                var containLine = line.Split("bags contain");
                var color = containLine[0].Trim();
                var contents = containLine[1].Split(",").Select(x => x.Trim());

                var currentBag = bags.GetValueOrDefault(color) ?? new Bag { Color = color };
                if(!bags.ContainsKey(color))
                {
                    bags[color] = currentBag;
                }

                foreach(var content in contents)
                {
                    if(content == "no other bags.")
                    {
                        continue;
                    }
                    var amountString = content.Split()[0];
                    var amount = int.Parse(amountString);
                    var contentColor = content.Replace(amountString, "").Split("bag")[0].Trim();
                    var other = bags.GetValueOrDefault(contentColor) ?? new Bag { Color = contentColor };
                    if(!bags.ContainsKey(contentColor))
                    {
                        bags[contentColor] = other;
                    }
                    other.Parents.Add(currentBag);
                    currentBag.Children.Add((other, amount));
                }
            }
            return bags;
        }
        public class Bag
        {
            public string Color { get; set; }
            public IList<(Bag, int)> Children { get; set; } = new List<(Bag, int)>();
            public IList<Bag> Parents { get; set; } = new List<Bag>();

            public List<string> ParentColors() => Parents.SelectMany(p => p.ParentColors().Concat(new[] { p.Color })).ToList();

            public long CountBags() => Children.Sum(c => c.Item2) + Children.Sum(c => c.Item1.CountBags() * c.Item2);
        }
    }
}
