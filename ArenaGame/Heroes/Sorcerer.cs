using System;
using ArenaGame.Weapons;

namespace ArenaGame.Heroes
{
    public class Sorcerer : Hero
    {
        public bool CurseActive { get; set; }
        public int CurseDuration { get; set; }

        public Sorcerer(string name, double armor, double strength, IWeapon weapon)
            : base(name, armor, strength, weapon)
        {
            CurseActive = false;
            CurseDuration = 0;
        }

        public override double Attack()
        {
            if (Weapon is CursedEnergy cursedEnergy)
            {
                cursedEnergy.TriggerAbility(this);  
            }
            return base.Attack() + Weapon.AttackDamage;
        }

        public override double Defend(double incomingDamage)
        {
            double damageAfterArmor = incomingDamage - Armor;
            AdjustHealth(-damageAfterArmor);
            return damageAfterArmor;
        }

    }
}
