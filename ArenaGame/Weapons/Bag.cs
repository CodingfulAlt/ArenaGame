using System;

namespace ArenaGame.Weapons
{
    public class Bag : IWeapon
    {
        public string Name { get; set; }
        public double AttackDamage { get; private set; }
        public double BlockingPower { get; private set; }
        private int turnCounter = 0;

        public Bag(string name)
        {
            Name = name;
            AttackDamage = 15;
            BlockingPower = 15;
        }

        public double SpecialAbility()
        {
            turnCounter++;
            if (turnCounter > 2)
            {   
                Console.WriteLine($"in the {Name} a bomb was found HAAHAHAHA take this damage:");
                return 45;
            }
            return 0;
        }
    }
}
