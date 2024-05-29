using ArenaGame.Weapons;

namespace ArenaGame.Heroes
{
    public class Goblin : Hero
    {
        public Goblin(string name, double armor, double strength, IWeapon weapon)
            : base(name, armor, strength, weapon)
        {
        }

        public override double Attack()
        {
            double baseDamage = base.Attack();
            double specialDamage = Weapon.TriggerSpecialAbility(this); 
            return baseDamage + specialDamage;
        }
    }
}
