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
            AttackDamage = 20;
            BlockingPower = 30;
        }

        public double TriggerSpecialAbility(Hero hero)
        {
            turnCounter++;
            if (turnCounter % 3 == 0)  
            {
                Console.WriteLine($"In the {Name}, a bomb .....BOOM  (causing massive damage!)");
                return 45;  
            }
            return 0;  
        }
    }
}
