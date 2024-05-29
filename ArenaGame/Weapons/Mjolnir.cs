using System;

namespace ArenaGame.Weapons
{
    public class Mjolnir : IWeapon
    {
        public string Name { get; set; }
        public double AttackDamage { get; private set; }
        public double BlockingPower { get; private set; }

        public Mjolnir(string name)
        {
            Name = name;
            AttackDamage = 20;
            BlockingPower = 30;
        }

        public double TriggerSpecialAbility(Hero hero)
        {
          
            if (hero.Health < 25)
            {
                Console.WriteLine($"{Name} summons lightning from the sky, causing massive damage!");
                return 30; 
            }
            return 0;
        }
    }
}
