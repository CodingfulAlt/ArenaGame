using System;
using System.Xml.Linq;

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
            AttackDamage = 25;
            BlockingPower = 5; 
        }

        public string SpecialAbility()
        {
            return "Lightning Strike - deals 50 extra damage when the wielder's health is below 25%.";
        }
        public double TriggerAbility(double userHealth)
        {
            if (userHealth < 25)
            {
                Console.WriteLine($"{Name} summons lighting from the sky..");
                return 25;
            }
            return 0;
        }
    }
}