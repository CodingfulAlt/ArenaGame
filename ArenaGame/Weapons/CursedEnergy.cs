using System;

namespace ArenaGame.Weapons
{
    public class CursedEnergy : IWeapon
    {
        public string Name { get; set; }
        public double AttackDamage { get; private set; }
        public double BlockingPower { get; private set; } 
        private bool abilityActivated = false;

        public CursedEnergy(string name)
        {
            Name = name;
            AttackDamage = 10;
            BlockingPower = 40;
        }

        public double TriggerSpecialAbility(Hero hero)
        {
           
            if (!abilityActivated && hero.Health < 50)
            {
                abilityActivated = true;
                Console.WriteLine($"{hero.Name} activates Cursed Energy: boosts attack but loses health.");
                hero.AdjustHealth(-hero.Health * 0.25); 
                return AttackDamage * 0.2; 
            }
            return 0;
        }
    }
}
