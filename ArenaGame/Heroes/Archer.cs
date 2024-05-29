using ArenaGame.Weapons;

namespace ArenaGame.Heroes
{
    public class Archer : Hero
    {
        public Archer(string name, double armor, double strength, IWeapon weapon)
            : base(name, armor, strength, weapon)
        {
        }

        public override double Attack()
        {
            double baseDamage = base.Attack();
            double additionalDamage = Weapon.TriggerSpecialAbility(this); 
            return baseDamage + additionalDamage;
        }
    }
}
