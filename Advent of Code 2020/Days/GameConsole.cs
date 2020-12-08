using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2020.Days
{
    class GameConsole
    {
        public record Instruction(string operation, int value);
        public static List<Instruction> Instructions = new List<Instruction>();
        public static void ReadInput(string[] input)
        {
            Instructions.Clear();
            foreach(var i in input)
            {
                var split = i.Split(" ");
                Instructions.Add(new Instruction(split[0], int.Parse(split[1].Replace("+", ""))));
            }
        }

        public static (bool infinite, int acc) RunInput()
        {
            var accumulator = 0;
            var visted = new HashSet<int>();
            var ip = 0;
            while(true)
            {
                if(ip == Instructions.Count)
                {
                    return (false, accumulator);
                }
                if(visted.Contains(ip))
                {
                    return (true, accumulator);
                }
                else
                {
                    visted.Add(ip);
                }
                switch(Instructions[ip].operation)
                {
                    case "nop":
                        ip++;
                        break;
                    case "acc":
                        accumulator += Instructions[ip].value;
                        ip++;
                        break;
                    case "jmp":
                        ip += Instructions[ip].value;
                        break;
                }
            }
        }
    }
}
