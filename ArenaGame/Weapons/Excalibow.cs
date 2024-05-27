using System;
using ArenaGame;

namespace ArenaGame.Weapons
{
    public class Excalibow : IWeapon
    {
        public string Name { get; set; }
        public double AttackDamage { get; private set; }
        public double BlockingPower { get; private set; }

        private int turnCounter;

        public Excalibow(string name)
        {
            Name = name;
            AttackDamage = 25;
            BlockingPower = 5;
            turnCounter = 0;
        }

        public string SpecialAbility()
        {
            return "Triple arrow - shoots 3 arrows instead of 1 every 3 turns.";
        }
        public double TripleArrow(double baseDamage)
        {
            turnCounter++;
            if (turnCounter % 3 == 0)
            {
                Console.WriteLine("Ability activated: Shoots 2 arrows!");
                return baseDamage * 2; 
            }
            return baseDamage;  
        }
    }
}
