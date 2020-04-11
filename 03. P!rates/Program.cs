using System;
using System.Linq;
using System.Collections.Generic;

namespace Problem_03
{
    class Program
    {
        public class TownStatus
        {
            public int Population { get; set; }
            public int Gold { get; set; }

            public TownStatus(int population, int gold)
            {
                this.Population = population;
                this.Gold = gold;
            }

        }
        static void Main()
        {
            Dictionary<string, TownStatus> townList = new Dictionary<string, TownStatus>();
            string townsInfo;
            while ((townsInfo = Console.ReadLine()) != "Sail")
            {
                string[] info = townsInfo.Split("||");

                string townName = info[0];
                int population = int.Parse(info[1]);
                int gold = int.Parse(info[2]);

                if (!townList.ContainsKey(townName))
                {
                    townList.Add(townName, new TownStatus(population, gold));
                }

                else
                {
                    townList[townName].Population += population;
                    townList[townName].Gold += gold;
                }
            }

            string events;
            while ((events = Console.ReadLine()) != "End")
            {
                string[] info = events.Split("=>");
                string command = info[0];

                if (command == "Plunder")
                {
                    string townName = info[1];
                    int people = int.Parse(info[2]);
                    int gold = int.Parse(info[3]);

                    if (townList.ContainsKey(townName))
                    {
                        townList[townName].Population -= people;
                        townList[townName].Gold -= gold;
                        Console.WriteLine($"{townName} plundered! {gold} gold stolen, {people} citizens killed.");
                        if (townList[townName].Gold == 0 || townList[townName].Population == 0)
                        {
                            townList.Remove(townName);
                            Console.WriteLine($"{townName} has been wiped off the map!");
                        }
                    }
                }
                else if (command == "Prosper")
                {
                    string townName = info[1];
                    int gold = int.Parse(info[2]);

                    if (townList.ContainsKey(townName))
                    {
                        if (gold < 0)
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                            continue;
                        }
                        else
                        {
                            townList[townName].Gold += gold;
                            Console.WriteLine($"{gold} gold added to the city treasury. {townName} now has {townList[townName].Gold} gold.");
                        }
                    }
                }
            }
            if (townList.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {townList.Count} wealthy settlements to go to:");
                foreach (var town in townList.OrderByDescending(x => x.Value.Gold).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{town.Key} -> Population: {town.Value.Population} citizens, Gold: {town.Value.Gold} kg");
                }
            }
        }
    }
}
