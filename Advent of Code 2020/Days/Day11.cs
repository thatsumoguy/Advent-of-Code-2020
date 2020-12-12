using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2020.Days
{
    class Day11
    {
        static Dictionary<(int, int), bool> Seats = new Dictionary<(int, int), bool>();
        private static readonly List<(int, int)> Neighbors = new List<(int x, int y)>()
        {
            (1,0),
            (1,1),
            (0,1),
            (-1,1),
            (-1,0),
            (-1,-1),
            (0,-1),
            (1,-1)
        };
        static int maxX = 0;
        static int maxY = 0;

        public static int PartOne(string[] input)
        {
            maxY = input.Length;
            for (int j = 0; j < input.Length; j++)
            {
                for (int i = 0; i < input[j].Length; i++)
                {
                    if (input[j][i] == 'L') Seats[(i, j)] = false;
                    else if (input[j][i] == '#') Seats[(i, j)] = false;
                    if (i > maxX) maxX = i;
                }
            }
            var seatsChanged = int.MaxValue;
            do
            {
                seatsChanged = 0;
                var nextSeats = new Dictionary<(int, int), bool>(Seats);
                foreach (var seat in Seats)
                {
                    bool nextVal = AliveNext(seat.Key);
                    if (nextVal != seat.Value) seatsChanged++;
                    nextSeats[seat.Key] = nextVal;
                }

                Seats = new Dictionary<(int, int), bool>(nextSeats);
            } while (seatsChanged != 0);


            return Seats.Count(x => x.Value);
        }

        public static int PartTwo(string[] input)
        {
            maxY = input.Length;
            for (int j = 0; j < input.Length; j++)
            {
                for (int i = 0; i < input[j].Length; i++)
                {
                    if (input[j][i] == 'L') Seats[(i, j)] = false;
                    else if (input[j][i] == '#') Seats[(i, j)] = false;
                    if (i > maxX) maxX = i;
                }
            }
            int seatsChanged = int.MaxValue;
            do
            {
                seatsChanged = 0;
                var nextSeats = new Dictionary<(int, int), bool>(Seats);
                foreach (var seat in Seats)
                {
                    bool nextVal = AliveNext(seat.Key, true);
                    if (nextVal != seat.Value) seatsChanged++;
                    nextSeats[seat.Key] = nextVal;
                }

                Seats = new Dictionary<(int, int), bool>(nextSeats);
            } while (seatsChanged != 0);


            return Seats.Count(x => x.Value);
        }

        private static bool AliveNext((int x, int y) c, bool part2 = false)
        {
            int livingNeighbors = 0;
            List<(int, int)> locNeighbors = new List<(int x, int y)>();
            List<(int, int)> extendedNeighbors = new List<(int x, int y)>();
            foreach (var n in Neighbors)
            {
                locNeighbors.Add(c.Add(n));

                var tmp = c.Add(n);
                while (!Seats.ContainsKey(tmp))
                {
                    if (tmp.Item1 < 0 || tmp.Item1 > maxX || tmp.Item2 < 0 || tmp.Item2 > maxY) break;
                    tmp = tmp.Add(n);
                }

                extendedNeighbors.Add(tmp);
            }

            if (part2)
            {
                foreach (var n in extendedNeighbors)
                {
                    if (!Seats.ContainsKey(n)) continue;
                    if (Seats[n]) livingNeighbors++;
                }
                if (Seats[c])
                {
                    if (livingNeighbors < 5) return true;
                }
                else
                {
                    if (livingNeighbors == 0) return true;
                }
            }
            else
            {
                foreach (var n in locNeighbors)
                {
                    if (!Seats.ContainsKey(n)) continue;
                    if (Seats[n]) livingNeighbors++;
                }

                if (Seats[c])
                {
                    if (livingNeighbors < 4) return true;
                }
                else
                {
                    if (livingNeighbors == 0) return true;
                }
            }



            return false;
        }
    }
    public static class Extensions
    {
        public static (int, int) Add(this (int x, int y) a, (int x, int y) b) => (a.x + b.x, a.y + b.y);
    }
}
