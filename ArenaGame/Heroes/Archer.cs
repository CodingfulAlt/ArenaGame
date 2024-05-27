using System;
using ArenaGame;
using ArenaGame.Weapons;

namespace ArenaGame
{
    public class Archer : Hero
    {
        public Archer(string name, double armor, double strength, IWeapon weapon)
            : base(name, armor, strength, weapon)
        {
        }

        public override double Attack()
        {
            double damage = base.Attack();
            if (Weapon is Excalibow excalibow)
            {
                damage = excalibow.TripleArrow(damage);
            }

            Console.WriteLine($"{Name} attacks with {damage} damage.");
            return damage;
        }

        public override double Defend(double incomingDamage)
        {
            return base.Defend(incomingDamage);
        }
    }
}
