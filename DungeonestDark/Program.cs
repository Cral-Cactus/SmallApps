using System;

namespace DungeonestDark
{
    internal class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            int initialHealth = 100;
            int currentHealth = initialHealth;
            int coins = 0;
            int roomCount = 0;

            string[] logEntries = input.Split('|');

            foreach (string entry in logEntries)
            {
                string[] parts = entry.Split(' ');
                string action = parts[0];
                int value = int.Parse(parts[1]);

                roomCount++;

                switch (action)
                {
                    case "potion":
                        if (currentHealth + value > initialHealth)
                        {
                            value = initialHealth - currentHealth;
                        }
                        currentHealth += value;

                        Console.WriteLine($"You healed for {value} hp.");
                        break;
                    case "poison":
                        if (currentHealth - value <= 0)
                        {
                            Console.WriteLine($"Instead of a potion, you drank poison, which killed you!");
                            Console.WriteLine($"Best Room: {roomCount}");
                            return;
                        }
                        currentHealth -= value;

                        Console.WriteLine($"You go poisoned and lost {value} hp!");
                        break;
                    case "chest":
                        Console.WriteLine($"You found {value} coins.");
                        coins += value;

                        break;
                    default:
                        if (currentHealth - value <= 0)
                        {
                            Console.WriteLine($"You died! Killed by {action}.");
                            Console.WriteLine($"Best Room: {roomCount}");
                            return;
                        }

                        currentHealth -= value;

                        Console.WriteLine($"You slayed {action}.");
                        break;
                }
            }

            Console.WriteLine("You've made it!");
            Console.WriteLine($"Coins: {coins}");
            Console.WriteLine($"Health: {currentHealth}");
        }
    }
}