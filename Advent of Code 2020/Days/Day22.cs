using Advent_of_Code_2020.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2020.Days
{
    class Day22
    {
        public static int PartOne(string[] input)
        {
            var player1 = new Queue<int>(input.Skip(1).Take(25).Select(int.Parse));
            var player2 = new Queue<int>(input.Skip(28).Select(int.Parse));
            while(player1.Count != 0 && player2.Count != 0)
            {
                var player1Card = player1.Dequeue();
                var player2Card = player2.Dequeue();
                if(player1Card > player2Card)
                {
                    player1.Enqueue(player1Card);
                    player1.Enqueue(player2Card);
                }
                else
                {
                    player2.Enqueue(player2Card);
                    player2.Enqueue(player1Card);
                }
            }
            var winner = player1.Count > 0 ? player1.ToArray() : player2.ToArray();
            return winner.Zip(Enumerable.Range(1, winner.Length).Reverse(), (x, y) => x *y).Sum();
        }

        public static int PartTwo(string[] input)
        {
            var player1 = new Queue<int>(input.Skip(1).Take(25).Select(int.Parse));
            var player2 = new Queue<int>(input.Skip(28).Select(int.Parse));
            Play(player1, player2);
            var winner = player1.Count > 0 ? player1.ToArray() : player2.ToArray();
            return winner.Zip(Enumerable.Range(1, winner.Length).Reverse(), (x, y) => x * y).Sum();
        }
        private static void Play(Queue<int> player1, Queue<int> player2)
        {
            var seenHands = new HashSet<(int, int)>();
            while(player1.Count > 0 && player2.Count > 0)
            {
                PlayRecursive(player1, player2, seenHands);
            }
        }
        private static void PlayRecursive (Queue<int> player1, Queue<int> player2, HashSet<(int, int)> seenHands)
        {
            var hashCodePlayer1 = player1.ToList().GetSequenceHashCode();
            var hashCodePlayer2 = player2.ToList().GetSequenceHashCode();
            var item = (hashCodePlayer1, hashCodePlayer2);

            bool player1Win = seenHands.Contains(item);

            seenHands.Add((hashCodePlayer1, hashCodePlayer2));


            if (player1Win)
            {
                player2.Clear();
                return;
            }

            var card1 = player1.Dequeue();
            var card2 = player2.Dequeue();

            if (player1.Count >= card1 && player2.Count >= card2)
            {
                var player1Sub = new Queue<int>(player1.Take(card1));
                var player2Sub = new Queue<int>(player2.Take(card2));

                Play(player1Sub, player2Sub);
                if (player1Sub.Count > 1)
                {
                    player1.Enqueue(card1);
                    player1.Enqueue(card2);
                }
                else
                {
                    player2.Enqueue(card2);
                    player2.Enqueue(card1);
                }
            }
            else if (card1 > card2)
            {
                player1.Enqueue(card1);
                player1.Enqueue(card2);
            }
            else if (card2 > card1)
            {
                player2.Enqueue(card2);
                player2.Enqueue(card1);
            }
        }
    }
}
