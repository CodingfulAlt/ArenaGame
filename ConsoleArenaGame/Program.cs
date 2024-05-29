using ArenaGame;
using ArenaGame.Heroes;
using ArenaGame.Weapons;
using System;
using System.Collections.Generic;

namespace ConsoleArenaGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var heroes = new List<Hero>
            {
                new Knight("Crock", 10, 20, new Sword("Excalibur")),
                new Goblin("Kradec", 10, 20, new Bag("Magic Bag")),
                new Sorcerer("Oz", 10, 20, new CursedEnergy("Dark Orb")),
                new Assassin("Beast", 10, 20, new Dagger("Hidden Blade")),
                new Archer("Melodie", 10, 20, new Excalibow("Long Bow")),
                new TheChosenOnes("Thor", 10, 20, new Mjolnir("Thunder Hammer")),
                new JujutsuSorcerers("Gojo", 25, 35, new DomainExpansion("Infinite Void")),
                new JujutsuSorcerers("Sukuna", 25, 35, new DomainExpansion("Malevolent Shrine")),
            };

            
            DisplayHeroList(heroes);

            Console.Write("\n");
            Console.Write("Choose Hero A: ");
            Hero heroA = ChooseHero(heroes);
            Console.Write("Choose Hero B: ");
            Hero heroB = ChooseHero(heroes);
            Console.Write("\n");


           
            GameEngine gameEngine = new GameEngine()
            {
                HeroA = heroA,
                HeroB = heroB,
                NotificationsCallBack = ConsoleNotification
            };

            
            gameEngine.Fight();
            Console.WriteLine();
            Console.WriteLine($"And the winner is {gameEngine.Winner.Name} with health {Math.Round(gameEngine.Winner.Health, 2)}");
        }

        static void DisplayHeroList(List<Hero> heroes) //i used help here from internet 
        {
            for (int i = 0; i < heroes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {heroes[i].GetType().Name} {heroes[i].Name} with weapon {heroes[i].Weapon.Name} (Armor: {heroes[i].Armor}, Strength: {heroes[i].Strenght})");
            }
        }

        static Hero ChooseHero(List<Hero> heroes) //here too
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= heroes.Count)
                {
                    return heroes[choice - 1];
                }
                Console.WriteLine("Invalid choice, try again.");
                Console.Write("Select a hero (number): ");
            }
        }

        static void ConsoleNotification(GameEngine.NotificationArgs args) //here no 
        {
            if (args.Defender.Health <= 0)
            {
                Console.WriteLine($"{args.Attacker.Name} attacked {args.Defender.Name} with {Math.Round(args.Attack, 2)} and caused {Math.Round(args.Damage, 2)} damage.");
            }
            else
            {
                Console.WriteLine($"{args.Attacker.Name} attacked {args.Defender.Name} with {Math.Round(args.Attack, 2)} and caused {Math.Round(args.Damage, 2)} damage.");
            }
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            Console.WriteLine($"Attacker: {args.Attacker.Name} with health {Math.Round(args.Attacker.Health, 2)}");
            Console.WriteLine($"Defender: {args.Defender.Name} with health {Math.Round(args.Defender.Health, 2)}");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
        }
    }
}
