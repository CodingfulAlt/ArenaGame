using System;
using ArenaGame;

namespace ArenaGame.Heroes
{
    public class JujutsuSorcerers : Hero
    {
        //Jujutsusorcerers and Domainexpansion are created with the help of chatgpt. vsishki komentari pokazvat za kakvo sum izpolzval gpt
        public int immobilizedEnemyTurns = 0;
        public int boostTurnsRemaining = 0;
        public double maxHealth;

        public JujutsuSorcerers(string name, double armor, double strength, IWeapon weapon, double initialHealth = 100)
            : base(name, armor, strength, weapon)
        {
            this.maxHealth = initialHealth;
        }

        public override double Attack()
        {
            double baseDamage = base.Attack();
            double additionalDamage = Weapon.TriggerSpecialAbility(this);
            return baseDamage + additionalDamage;
        }

        public override double Defend(double incomingDamage)
        {
            if (immobilizedEnemyTurns > 0)
            {
                immobilizedEnemyTurns--;
                Console.WriteLine($"{Name} is immune to attacks due to Infinity.");
                return 0;  
            }
            return base.Defend(incomingDamage);
        }
    }
}
