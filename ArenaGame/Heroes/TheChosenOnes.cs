using System;
using ArenaGame;
using ArenaGame.Weapons;

namespace ArenaGame
{
    public class TheChosenOnes : Hero
    {
        public TheChosenOnes(string name, double armor, double strength, IWeapon weapon)
            : base(name, armor, strength, weapon)
        {
        }

        public override double Attack()
        {
            double Damage = base.Attack();
            if (Weapon != null && Weapon is Mjolnir && Health < 25)
            {
                Damage += ((Mjolnir)Weapon).TriggerAbility(Health);
            }
            else { 
            }
            return Damage;
        }


      
    }
}
