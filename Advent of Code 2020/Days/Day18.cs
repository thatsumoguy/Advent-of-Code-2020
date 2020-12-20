using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2020.Days
{
    class Day18
    {
        public static long PartOne(string[] input)
        {
            var operations = new Dictionary<char, int>() { ['+'] = 0, ['*'] = 0 };
            var output = 0L;
            foreach (var line in input)
            {
                output += Evaluate(new Queue<char>(line.ToCharArray().Where(c => c != ' ')), operations);
            }
            return output;
        }

        public static long PartTwo(string[] input)
        {
            var operations = new Dictionary<char, int>() { ['+'] = 0, ['*'] = 1 };
            var output = 0L;
            foreach (var line in input)
            {
                output += Evaluate(new Queue<char>(line.ToCharArray().Where(c => c != ' ')), operations);
            }
            return output;
        }

        private static long Evaluate(Queue<char> expression, Dictionary<char, int> precedence)
        {
            Stack<long> stash = new Stack<long>();
            Stack<char> ops = new Stack<char>();

            while (expression.Count > 0)
            {
                char c = expression.Dequeue();
                if (c >= '0' && c <= '9')
                    stash.Push((long)c - 48);
                else if (c == '(')
                    stash.Push(Evaluate(expression, precedence));
                else if (c == ')')
                    break;
                else if (ops.Count == 0 || precedence[c] < precedence[ops.Peek()])
                    ops.Push(c);
                else
                {
                    stash.Push(Operation(stash, ops.Pop()));
                    ops.Push(c);
                }
            }

            while (ops.Count > 0)
                stash.Push(Operation(stash, ops.Pop()));

            return stash.Peek();
        }

        private static long Operation(Stack<long> stash, char op)
        {
            if (op == '+')
                return stash.Pop() + stash.Pop();
            else
                return stash.Pop() * stash.Pop();
        }
    }
}
