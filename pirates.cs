using System.Text.RegularExpressions;

namespace softUniFund_FinalExamPrep2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<City> cities = new List<City>();

            string command = Console.ReadLine();
            while(command != "Sail")
            {
                string[] info = command.Split("||");

                bool cityExists = false;
                if(cities.Count > 0)
                {
                    foreach(City city in cities)
                    {
                        if(city.Name == info[0])
                        {
                            cityExists = true;
                            city.Population += int.Parse(info[1]);
                            city.Gold += int.Parse(info[2]);
                            break;
                        }
                    }
                }
                if(!cityExists)
                {
                    City newCity = new City(info[0], int.Parse(info[1]), int.Parse(info[2]));
                    cities.Add(newCity);
                }

                command = Console.ReadLine();
            }

            while(command != "End")
            {
                string[] commandParts = command.Split("=>");
                switch(commandParts[0])
                {
                    case "Plunder":
                        foreach(City city in cities)
                        {
                            if(city.Name == commandParts[1])
                            {
                                city.Population -= int.Parse(commandParts[2]);
                                city.Gold -= int.Parse(commandParts[3]);
                                Console.WriteLine($"{commandParts[1]} plundered! {int.Parse(commandParts[3])} gold stolen, " +
                                    $"{int.Parse(commandParts[2])} citizens killed.");
                                if(city.Population <= 0 || city.Gold <= 0)
                                {
                                    cities.Remove(city);
                                    Console.WriteLine($"{city.Name} has been wiped off the map!");
                                }
                                break;
                            }
                        }
                        break;
                    case "Prosper":
                        foreach(City city in cities)
                        {
                            if(city.Name == commandParts[1])
                            {
                                if(int.Parse(commandParts[2]) >= 0)
                                {
                                    city.Gold += int.Parse(commandParts[2]);
                                    Console.WriteLine($"{int.Parse(commandParts[2])} gold added to the city treasury. " +
                                        $"{city.Name} now has {city.Gold} gold.");
                                }
                                else Console.WriteLine("Gold added cannot be a negative number!");
                                break;
                            }
                        }
                        break;
                }
                command = Console.ReadLine();
            }

            if(cities.Count == 0) Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach(City city in cities) Console.WriteLine(city);
            }
        }
    }

    class City
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }

        public City(string name, int population, int gold)
        {
            Name = name;
            Population = population;
            Gold = gold;
        }

        public override string ToString()
        {
            return $"{Name} -> Population: {Population} citizens, Gold: {Gold} kg";
        }
    }
}