using System;
using ArenaGame.Weapons;

namespace ArenaGame.Heroes
{
    public class Goblin : Hero
    {
        private int turnCounter = 0;

        public Goblin(string name, double armor, double strength, IWeapon weapon)
            : base(name, armor, strength, weapon)
        {
        }

        public override double Attack()
        {
            double damage = base.Attack();
            if (Weapon is Bag bag)
            {
                damage += bag.SpecialAbility();
            }
            turnCounter++;
            return damage;
        }
    }
}
