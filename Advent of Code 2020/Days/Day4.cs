using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2020.Days
{
    class Day4
    {
        static List<string> required = new List<string>
        {
            "byr",
            "iyr",
            "eyr",
            "hgt",
            "hcl",
            "ecl",
            "pid"
        };
        public static int PartOne(string[] input)
        {
            
            var validPass = 0;
            var lines = File.ReadAllText(@"C:\Users\Kyle Rinne\source\repos\Advent of Code 2020\Advent of Code 2020\Input\Day4.txt");
            var passports = lines.Split(new string[] { Environment.NewLine, Environment.NewLine }, StringSplitOptions.None).ToList();
            foreach(var pass in passports)
            {
                if(pass == "")
                {
                    if(required.Count == 0)
                    {
                        validPass++;
                    }
                    required = new List<string>
                    {
                        "byr",
                        "iyr",
                        "eyr",
                        "hgt",
                        "hcl",
                        "ecl",
                        "pid"
                    };
                    continue;
                }
                var fields = pass.Split(" ");
                var keys = fields.Select(f => f.Split(":")[0]);
                required = required.Except(keys.ToList()).ToList();
            }
            if(!required.Any())
            {
                validPass++;
            }
            return validPass;
        }

        public static int PartTwo(string[] input)
        {
            var lines = File.ReadAllText(@"C:\Users\Kyle Rinne\source\repos\Advent of Code 2020\Advent of Code 2020\Input\Day4.txt");
            var passports = lines.Split(new string[] { Environment.NewLine, Environment.NewLine }, StringSplitOptions.None).ToList();
            var valid = 0;
            var validPass = new List<bool>();
            foreach (var pass in passports)
            {
                if(pass == "")
                {
                    
                    if (validPass.All(b => b == true) && !required.Any())
                    {
                        valid++;
                    }
                    required = new List<string>
                    {
                        "byr",
                        "iyr",
                        "eyr",
                        "hgt",
                        "hcl",
                        "ecl",
                        "pid"
                    };
                    validPass.Clear();
                    continue;
                }
                var fields = pass.Split(" ");
                var keys = fields.Select(f => f.Split(":")).ToList();
                foreach (var key in keys)
                {
                    if (key[0] != "" && key[0] != "cid")
                    {
                        var validCurrent = Validate(key);
                        validPass.Add(validCurrent);
                    }
                }
            }
            return valid;
        }

        private static bool Validate(string[] key)
        {
            var k = key[0];
            var value = key[1];
            if (required.Contains(k))
            {
                required.Remove(k);
            }
            switch (k)
            {
                case "byr":
                    return int.Parse(value) >= 1920 && int.Parse(value) <= 2002;
                case "iyr":
                    return int.Parse(value) >= 2010 && int.Parse(value) <= 2020;
                case "eyr":
                    return int.Parse(value) >= 2010 && int.Parse(value) <= 2030;
                case "hgt":
                    if (value.Contains("cm"))
                    {
                        var cmHeight = int.Parse(value.Split("cm")[0]);
                        return cmHeight >= 150 && cmHeight <= 193;
                    }
                    else if (value.Contains("in"))
                    {
                        var inHeight = int.Parse(value.Split("in")[0]);
                        return inHeight >= 59 && inHeight <= 76;
                    }
                    else
                    {
                        return false;
                    }
                case "hcl":
                    var allowed = "abcdef0123456789";
                    return value.Length >= 1 && value.First() == '#' && value.Length == 7 && value.Skip(1).All(c => allowed.Contains(c));
                case "ecl":
                    var allowedEyes = new List<string>
                        {
                            "amb",
                            "blu",
                            "brn",
                            "gry",
                            "grn",
                            "hzl",
                            "oth"
                        };
                    return allowedEyes.Contains(value);
                case "pid":
                    return value.Length == 9 && long.TryParse(value, out var _);
            }
            return false;
        }
    }
}
