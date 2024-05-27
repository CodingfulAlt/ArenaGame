using System;
using System.Xml.Linq;

namespace ArenaGame.Weapons
{
    public class CursedEnergy : IWeapon
    {
        public string Name { get; set; }
    public double AttackDamage { get; private set; }
    public double BlockingPower { get; private set; }
    public bool AbilityActivated { get; private set; }  

    public CursedEnergy(string name)
    {
            Name = name;
        AttackDamage = 20;  
        BlockingPower = 30;
        AbilityActivated = false;  
    }

    public void TriggerAbility(Hero hero)
    {
        if (!AbilityActivated && hero.Health < 50)
        {
            AbilityActivated = true;
            Console.WriteLine($"{hero.Name} activates Cursed Energy (boosts attack but looses health.)");
            AttackDamage *= 1.2;
            hero.AdjustHealth(-hero.Health * 0.25);
            }
    }

    }
}
