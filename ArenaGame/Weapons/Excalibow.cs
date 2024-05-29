using System;

namespace ArenaGame.Weapons
{
    public class Excalibow : IWeapon
    {
        public string Name { get; set; }
        public double AttackDamage { get; private set; }
        public double BlockingPower { get; private set; }
        private int turnCounter = 0;

        public Excalibow(string name)
        {
            Name = name;
            AttackDamage = 15;
            BlockingPower = 30;
        }

        public double TriggerSpecialAbility(Hero hero)
        {
            turnCounter++;
            
            if (turnCounter % 3 == 0)
            {
                Console.WriteLine($"Excalibow special ability activated: Triple Arrow!");
                return AttackDamage * 2;  
            }
            return 0;
        }
    }
}
