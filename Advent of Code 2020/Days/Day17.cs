using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2020.Days
{
    class Day17
    {
        static List<(int, int, int)>neighbors = Enumerable.Range(-1, 3)
                                    .SelectMany(x => Enumerable.Range(-1, 3), (x, y) => (x, y))
                                    .SelectMany(y => Enumerable.Range(-1, 3), (a, b) => (a.x, a.y, b))
                                    .Where(a => a != (0, 0, 0)).ToList();
        static List<(int, int, int, int)> neighbors4d = Enumerable.Range(-1, 3)
                                    .SelectMany(x => Enumerable.Range(-1, 3), (x, y) => (x, y))
                                    .SelectMany(y => Enumerable.Range(-1, 3), (a, b) => (a.x, a.y, b))
                                    .SelectMany(z => Enumerable.Range(-1, 3), (c, d) => (c.x, c.y, c.b, d))
                                    .Where(a => a != (0, 0, 0, 0)).ToList();
        public static int PartOne(string[] input)
        {
            var start = new HashSet<(int, int, int)>();
            var y = 0;
            foreach(var line in input)
            {
                for(var x = 0; x < line.Trim().Length; x++)
                {
                    if(line[x] == '#')
                    {
                        start.Add((y, x, 0));
                    }
                }
                y++;
            }
            for(var i =0; i < 6; i++)
            {
                start = Iterate(start);
            }
            return start.Count;
        }

        public static int PartTwo(string[] input)
        {
            var start = new HashSet<(int, int, int, int)>();
            var y = 0;
            foreach (var line in input)
            {
                for (var x = 0; x < line.Trim().Length; x++)
                {
                    if (line[x] == '#')
                    {
                        start.Add((y, x, 0, 0));
                    }
                }
                y++;
            }
            for (var i = 0; i < 6; i++)
            {
                start = Iterate4d(start);
            }
            return start.Count;
        }

        private static HashSet<(int,int,int)> Iterate(HashSet<(int, int, int)> start)
        {
            var result = new HashSet<(int, int, int)>();
            for (var i = 0; i < 6; i++)
            {
                foreach (var current in start)
                {
                    var neighborCheck = FindNeighbors(current);
                    neighborCheck.Add(current);
                    foreach (var neighbor in neighborCheck)
                    {
                        var active = ActiveNeighbors(start, neighbor);
                        if (start.Contains(neighbor) && (active == 2 || active == 3))
                        {
                            result.Add(neighbor);
                        }
                        else if (!start.Contains(neighbor) && active == 3)
                        {
                            result.Add(neighbor);
                        }
                    }
                }
            }
            return result;
        }

        private static List<(int, int, int)> FindNeighbors((int,int,int) current)
        {
            return neighbors.Select(x => (x.Item1 + current.Item1, x.Item2 + current.Item2, x.Item3 + current.Item3)).ToList();
        }

        private static int ActiveNeighbors(HashSet<(int, int, int)> grid, (int, int, int) current)
        {
            return neighbors.Select(x => (x.Item1 + current.Item1, x.Item2 + current.Item2, x.Item3 + current.Item3)).Where(y => grid.Contains(y)).Count();
        }

        private static HashSet<(int, int, int, int)> Iterate4d(HashSet<(int, int, int, int)> start)
        {
            var result = new HashSet<(int, int, int, int)>();
            for (var i = 0; i < 6; i++)
            {
                foreach (var current in start)
                {
                    var neighborCheck = FindNeighbors4d(current);
                    neighborCheck.Add(current);
                    foreach (var neighbor in neighborCheck)
                    {
                        var active = ActiveNeighbors4d(start, neighbor);
                        if (start.Contains(neighbor) && (active == 2 || active == 3))
                        {
                            result.Add(neighbor);
                        }
                        else if (!start.Contains(neighbor) && active == 3)
                        {
                            result.Add(neighbor);
                        }
                    }
                }
            }
            return result;
        }

        private static List<(int, int, int, int)> FindNeighbors4d((int, int, int, int) current)
        {
            return neighbors4d.Select(x => (x.Item1 + current.Item1, x.Item2 + current.Item2, x.Item3 + current.Item3, x.Item4 + current.Item4)).ToList();
        }

        private static int ActiveNeighbors4d(HashSet<(int, int, int, int)> grid, (int, int, int, int) current)
        {
            return neighbors4d.Select(x => (x.Item1 + current.Item1, x.Item2 + current.Item2, x.Item3 + current.Item3, x.Item4 + current.Item4)).Where(y => grid.Contains(y)).Count();
        }
    }
}
