using System;
using ArenaGame;
using ArenaGame.Weapons;

namespace ArenaGame
{   //Jujutsusorcerers and Domainexpansion are created with the help of chatgpt. vsishki komentari pokazvat za kakvo sum izpolzval gpt
    public class JujutsuSorcerers : Hero
    {
        private int immobilizedEnemyTurns = 0;
        private int boostTurnsRemaining = 0;
        private double maxHealth;

        public JujutsuSorcerers(string name, double armor, double strength, IWeapon weapon, double initialHealth = 100)
            : base(name, armor, strength, weapon)
        {
            this.maxHealth = initialHealth;
        }

        public override double Attack()
        {
            double damage = base.Attack();
            DomainExpansion weapon = Weapon as DomainExpansion;

            if (weapon != null)
            {
                if (string.Equals(Name, "Gojo", StringComparison.OrdinalIgnoreCase))  // Case-insensitive check for "Gojo"
                {
                    damage *= weapon.TriggerInfinity(Health, ref immobilizedEnemyTurns);

                    if (weapon.Purple())
                    {
                        return damage * 0.64; 
                    }
                }
                else if (string.Equals(Name, "Sukuna", StringComparison.OrdinalIgnoreCase))  // Case-insensitive check for "Sukuna"
                {
                    bool instantKill = false;
                    double additionalDamage = weapon.HandleSukunaAbilities(Health, maxHealth, ref instantKill);
                    if (instantKill)
                    {
                        Console.WriteLine("Sukuna instantly kills the enemy.");
                        return double.MaxValue;  // Represents instant kill
                    }
                    damage += additionalDamage;
                }
                else
                {
                    damage *= weapon.ApplyNonGojoBoost(Health, maxHealth, ref boostTurnsRemaining);
                }
            }

            return damage;
        }

        public override double Defend(double incomingDamage)
        {
            if (immobilizedEnemyTurns > 0)
            {
                immobilizedEnemyTurns--;
                Console.WriteLine($"{Name} is immune to attacks due to Infinity.");
                return 0;  // Enemy attack does no damage while immobilized by Infinity
            }
            return base.Defend(incomingDamage);
        }

        public void ApplyLimitless()
        {
            if (Weapon is DomainExpansion weapon && string.Equals(Name, "Gojo", StringComparison.OrdinalIgnoreCase))  // Case-insensitive check for "Gojo"
            {
                double healthRecovery = weapon.TriggerLimitless(Health, maxHealth);
                if (Health <= 0)
                {
                    AdjustHealth(maxHealth * healthRecovery);
                }
                else
                {
                    AdjustHealth(Health * healthRecovery);
                }
            }
        }

        public void ApplyRTC()
        {
            if (Weapon is DomainExpansion weapon && string.Equals(Name, "Sukuna", StringComparison.OrdinalIgnoreCase))  // Case-insensitive check for "Sukuna"
            {
                double healthRecovery = weapon.RTC(Health, maxHealth);
                AdjustHealth(maxHealth * healthRecovery);
            }
        }
    }
}
