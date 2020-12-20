using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MoreLinq;

namespace Advent_of_Code_2020.Days
{
    class Day19
    {
        public static int PartOne(string[] input)
        {
            var lines = input.Segment(string.IsNullOrWhiteSpace).ToArray();
            var rules = lines[0].Select(x => x.Split(':', StringSplitOptions.TrimEntries)).ToDictionary(x => x[0], x => x[1]);
            var processed = new Dictionary<string, string>();

            string BuildRegRules(string input)
            {
                if (processed.TryGetValue(input, out var s))
                {
                    return s;
                }

                var original = rules[input];
                if (original.StartsWith('\"'))
                {
                    return processed[input] = original.Replace("\"", "");
                }
                if (!original.Contains("|"))
                {
                    return processed[input] = string.Join("", original.Split().Select(BuildRegRules));
                }
                return processed[input] =
                        "(" +
                        string.Join("", original.Split().Select(x => x == "|" ? x : BuildRegRules(x))) +
                        ")";
            }
            var regex = new Regex("^" + BuildRegRules("0") + "$");
            return lines[1].Count(regex.IsMatch);
        }

        public static int PartTwo(string[] input)
        {
            var lines = input.Segment(string.IsNullOrWhiteSpace).ToArray();
            var rules = lines[0].Select(x => x.Split(':', StringSplitOptions.TrimEntries)).ToDictionary(x => x[0], x => x[1]);
            var processed = new Dictionary<string, string>();

            string BuildRegRules(string input)
            {
                if (processed.TryGetValue(input, out var s))
                {
                    return s;
                }

                var original = rules[input];
                if (original.StartsWith('\"'))
                {
                    return processed[input] = original.Replace("\"", "");
                }
                if (!original.Contains("|"))
                {
                    return processed[input] = string.Join("", original.Split().Select(BuildRegRules));
                }
                return processed[input] =
                        "(" +
                        string.Join("", original.Split().Select(x => x == "|" ? x : BuildRegRules(x))) +
                        ")";
            }
            var regex = new Regex($@"^({BuildRegRules("42")})+(?<open>{BuildRegRules("42")})+(?<close-open>{BuildRegRules("31")})+(?(open)(?!))$");
            return lines[1].Count(regex.IsMatch);
        }
    }
}
