using System;
using System.Collections.Generic;
using System.Linq;

namespace FeedTheAnimals
{
    class Program
    {
        static void Main(string[] args)
        {
            var limits = new Dictionary<string, int>();

            var areas = new Dictionary<string, List<string>>();

            var input = Console.ReadLine();

            while (input != "Last Info")
            {
                var command = input.Split(':');

                switch(command[0])
                {
                    case "Add":
                        if (!limits.ContainsKey(command[1]))
                        {
                            limits.Add(command[1], 0);
                        }
                        limits[command[1]] += int.Parse(command[2]);
                        if (!areas.ContainsKey(command[3]))
                        {
                            areas.Add(command[3], new List<string>());
                        }
                        if (!areas[command[3]].Contains(command[1]))
                        {
                            areas[command[3]].Add(command[1]);
                        }
                        break;
                    case "Feed":
                        if (limits.ContainsKey(command[1]))
                        {
                            limits[command[1]] -= int.Parse(command[2]);
                            if (limits[command[1]] <= 0)
                            {
                                limits.Remove(command[1]);
                                areas[command[3]].Remove(command[1]);
                                Console.WriteLine($"{command[1]} was successfully fed");
                            }
                        }
                        break;
                }

                input = Console.ReadLine();
            }
            limits = limits.OrderByDescending(a => a.Value).ThenBy(a => a.Key).ToDictionary(a => a.Key, a => a.Value);

            areas = areas.Where(a => a.Value.Count > 0).OrderByDescending(a => a.Value.Count).ToDictionary(a => a.Key, a => a.Value);

            Console.WriteLine("Animals:");

            foreach (var item in limits)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}g");
            }

            Console.WriteLine($"Areas with hungry animals:");

            foreach (var item in areas)
            {
                Console.WriteLine($"{item.Key} : {item.Value.Count}");
            }
        }
    }
}
