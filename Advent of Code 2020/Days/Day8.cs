using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2020.Days
{
    class Day8
    {
        public static int PartOne(string[] input)
        {
            GameConsole.ReadInput(input);
            return GameConsole.RunInput().acc;
        }

        public static int PartTwo(string[] input)
        {
            var outcome = (infinite: false, acc: 0);
            string[] temp = new string[input.Length];
            while(true)
            {
                for (var i = 0; i < input.Length; i++)
                {
                    if (input[i].Split(" ")[0] == "nop")
                    {
                        Array.Copy(input, temp, input.Length);
                        temp[i] = temp[i].Replace("nop", "jmp");
                        GameConsole.ReadInput(temp);
                        outcome = GameConsole.RunInput();
                    }
                    if (input[i].Split(" ")[0] == "jmp")
                    {
                        Array.Copy(input, temp, input.Length);
                        temp[i] = temp[i].Replace("jmp", "nop");
                        GameConsole.ReadInput(temp);
                        outcome = GameConsole.RunInput();
                    }
                    if (!outcome.infinite)
                    {
                        return outcome.acc;
                    }
                }
            }
        }
    }
}
