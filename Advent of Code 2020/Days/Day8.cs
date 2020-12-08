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
            var outcome = (false,0);
            string[] cpyInput = new string[input.Length];
            while(!outcome.Item1)
            {
                for (var i = 0; i < input.Length; i++)
                {
                    if (input[i].Split(" ")[0] == "nop")
                    {
                        Array.Copy(input, cpyInput, input.Length);
                        cpyInput[i] = cpyInput[i].Replace("nop", "jmp");
                        GameConsole.ReadInput(cpyInput);
                        outcome = GameConsole.RunInput();
                    }
                    if (input[i].Split(" ")[0] == "jmp")
                    {
                        Array.Copy(input, cpyInput, input.Length);
                        cpyInput[i] = cpyInput[i].Replace("jmp", "nop");
                        GameConsole.ReadInput(cpyInput);
                        outcome = GameConsole.RunInput();
                    }
                    if (!outcome.Item1)
                    {
                        return outcome.Item2;
                    }
                }
            }
            return 0;
        }
    }
}
