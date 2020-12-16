using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advent_of_Code_2020.Extensions;

namespace Advent_of_Code_2020.Days
{
    class Day16
    {
        static List<TicketInfo> UpperLowerLimits = new List<TicketInfo>();
        static List<string> tickets;
        static List<string> validTickets;
        public static long PartOne(string[] input)
        {
            //I tried to have a standard across all days, but this day makes it pain to do so, so I am just going to read in the input here instead
            var lines = File.ReadAllText(@"C:\Users\Kyle Rinne\source\repos\Advent of Code 2020\Advent of Code 2020\Input\Day16.txt").Split("\r\n\r\n");
            foreach (var line in lines[0].SplitLines())
            {
                var ticketInfo = new TicketInfo();
                var nameSplit = line.Split(":");
                ticketInfo.name = nameSplit[0];
                var values = nameSplit[1].Split("- or".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if(values.Length == 4)
                {
                    ticketInfo.MinLow = int.Parse(values[0]);
                    ticketInfo.MinHigh = int.Parse(values[1]);
                    ticketInfo.MaxLow = int.Parse(values[2]);
                    ticketInfo.MaxHigh = int.Parse(values[3]);
                }
                UpperLowerLimits.Add(ticketInfo);
            }
            tickets = new List<string>(lines[2].SplitLines());
            tickets.RemoveAt(0);
            validTickets = new List<string>(tickets);
            var errorRate = 0L;

            foreach(var ticket in tickets)
            {
                foreach(var info in ticket.Split(",").Select(int.Parse))
                {
                    var valid = false;
                    foreach(var upperLower in UpperLowerLimits)
                    {
                        if((upperLower.MinLow <= info && upperLower.MinHigh >= info)||(upperLower.MaxLow <= info && upperLower.MaxHigh >= info))
                        {
                            valid = true;
                            break;
                        }
                    }
                    if(!valid)
                    {
                        errorRate += info;
                        validTickets.Remove(ticket);
                    }
                }
            }
            return errorRate;
        }

        public static long PartTwo(string[] input)
        {
            //I tried to have a standard across all days, but this day makes it pain to do so, so I am just going to read in the input here instead
            var lines = File.ReadAllText(@"C:\Users\Kyle Rinne\source\repos\Advent of Code 2020\Advent of Code 2020\Input\Day16.txt").Split("\r\n\r\n");
            var correctFields = new Dictionary<int, string>();
            var matchedTickets = new Dictionary<(int ticketPosition, string ticketName), int>();
            var myTicket = lines[1].Split("\n")[1].Split(",").Select(int.Parse).ToArray();
            var depFields = 1L;
            foreach (var validTicket in validTickets)
            {
                var fields = validTicket.Split(",").Select(int.Parse).ToArray();
                var ticketPosition = 0;
                foreach(var field in fields)
                {
                    foreach(var upperLower in UpperLowerLimits)
                    {
                        if((upperLower.MinLow <= field && upperLower.MinHigh >= field) || (upperLower.MaxLow <= field && upperLower.MaxHigh >= field))
                        {
                            if(!matchedTickets.ContainsKey((ticketPosition, upperLower.name)))
                            {
                                matchedTickets[(ticketPosition, upperLower.name)] = 1;
                            }
                            else
                            {
                                matchedTickets[(ticketPosition, upperLower.name)]++;
                            }
                        }
                    }
                    ticketPosition++;
                }
            }
            while(correctFields.Count < UpperLowerLimits.Count)
            {
                for(var i =0; i < UpperLowerLimits.Count; i++)
                {
                    var validTicket = matchedTickets.Where(x => x.Key.ticketPosition == i).ToList();
                    if(validTicket.Count(x => x.Value == validTickets.Count) == 1)
                    {
                        var ticket = validTicket.First(x => x.Value == validTickets.Count);
                        correctFields[ticket.Key.ticketPosition] = ticket.Key.ticketName;
                        
                        foreach (var key in matchedTickets.Keys)
                        {
                            if(key.ticketName == ticket.Key.ticketName)
                            {
                                matchedTickets.Remove(key);
                            }
                        }
                    }
                }
            }
            foreach (var correct in correctFields)
            {
                if (correct.Value.Contains("departure"))
                {
                    depFields *= myTicket[correct.Key];
                }
            }
            return depFields;
        }
    }

    internal class TicketInfo
    {
        public string name;
        public int MinLow;
        public int MinHigh;
        public int MaxLow;
        public int MaxHigh;
    }
}
