using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2020.Days
{
    class Day24
    {
        public static int PartOne(string[] input)
        {
            var tiles = new List<(int,int)>();
            foreach (var line in input)
            {
                var pos = (x: 0, y: 0);
                pos = FlipNeighbors(line, pos);
                if(tiles.Contains(pos))
                {
                    tiles.Remove(pos);
                }
                else
                {
                    tiles.Add(pos);
                }
            }
            return tiles.Count;
        }

        public static int PartTwo(string[] input)
        {
            var resultMap = new Dictionary<(int, int), bool>();
            foreach (var line in input)
            {
                var pos = (x: 0, y: 0);
                pos = FlipNeighbors(line, pos);
                resultMap.TryGetValue(pos, out var active);
                if(active)
                {
                    resultMap.Remove(pos);
                }
                else
                {
                    resultMap[pos] = true;
                }
            }
            var tiles = new Dictionary<(int, int), bool>();
            for(var i = 0; i < 100; i++)
            {
                var map = new List<(int x, int y)>(resultMap.Keys.ToList());
                foreach (var tile in map)
                {
                    foreach (var (x, y) in Neighbours(tile.x, tile.y, true))
                    {
                        var neighbours = Neighbours(x, y);
                        var active = neighbours.Count(x => resultMap.ContainsKey(x));
                        if (resultMap.TryGetValue((x, y), out var _) && active < 3 && active != 0)
                        {
                            tiles[(x, y)] = true;
                        }
                        else
                        {
                            if(active == 2)
                            {
                                tiles[(x, y)] = true;
                            }
                        }
                    }
                    
                }
                resultMap.Clear();
                (resultMap, tiles) = (tiles, resultMap);
            }
            return resultMap.Count(x => x.Value == true);
        }

        private static (int x, int y) FlipNeighbors(string line, (int x, int y) pos)
        {
            for (var i = 0; i < line.Length; i++)
            {
                var current = line[i];
                var next = i < line.Length - 1 ? line[i + 1] : 'x';

                switch (current)
                {
                    case 's':
                        {
                            switch (next)
                            {
                                case 'w':
                                    pos = (pos.x - 1, pos.y - 1);
                                    break;
                                case 'e':
                                    pos = (pos.x, pos.y - 1);
                                    break;
                            }
                            i++;
                            break;
                        }
                    case 'n':
                        {
                            switch (next)
                            {
                                case 'w':
                                    pos = (pos.x, pos.y + 1);
                                    break;
                                case 'e':
                                    pos = (pos.x + 1, pos.y + 1);
                                    break;
                            }
                            i++;
                            break;
                        }
                    case 'e':
                        {
                            pos = (pos.x + 1, pos.y);
                            break;
                        }
                    case 'w':
                        {
                            pos = (pos.x - 1, pos.y);
                            break;
                        }
                }
            }
            return pos;
        }

        private static IEnumerable<(int x, int y)> Neighbours(int X, int Y, bool self = false)
        {
            if (self) yield return (X, Y);
            yield return (X + 1, Y);
            yield return (X + 1, Y + 1);
            yield return (X, Y + 1);
            yield return (X - 1, Y);
            yield return (X - 1, Y - 1);
            yield return (X, Y - 1);
        }
    }
}
