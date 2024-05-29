    using System;
    using ArenaGame;
using ArenaGame.Heroes;

namespace ArenaGame.Weapons
{
    //Jujutsusorcerers and Domainexpansion are created with the help of chatgpt. vsishki komentari pokazvat za kakvo sum izpolzval gpt
    public class DomainExpansion : IWeapon
    {
        public string Name { get; set; }
        public double AttackDamage { get; private set; } 
        public double BlockingPower { get; private set; } 

        public Random random = new Random();
        public bool infinityActivated = false;
        public bool limitlessActivated = false;
        public bool purpleActivated = false;
        public bool malevolentKitchenActivated = false;
        public bool malevolentShrineActivated = false;
        public bool rtcActivated = false;

        public DomainExpansion(string name)
        {
            Name = name;
            AttackDamage = 25;
            BlockingPower = 10;
        }

        public double TriggerSpecialAbility(Hero hero)
        {
            if (hero is JujutsuSorcerers jujutsuSorcerer)
            {
                double additionalDamage = 0;

                // Handle Gojo-specific abilities
                if (string.Equals(jujutsuSorcerer.Name, "Gojo", StringComparison.OrdinalIgnoreCase))
                {
                    additionalDamage += TriggerInfinity(jujutsuSorcerer.Health, ref jujutsuSorcerer.immobilizedEnemyTurns);
                    if (Purple())
                    {
                        return additionalDamage * 0.64;
                    }
                }
                // Handle Sukuna-specific abilities
                else if (string.Equals(jujutsuSorcerer.Name, "Sukuna", StringComparison.OrdinalIgnoreCase))
                {
                    bool instantKill = false;
                    additionalDamage += HandleSukunaAbilities(jujutsuSorcerer.Health, jujutsuSorcerer.maxHealth, ref instantKill);
                    if (instantKill)
                    {
                        Console.WriteLine("Sukuna instantly kills the enemy.");
                        return double.MaxValue;  // Represents instant kill
                    }
                }
                // Apply non-specific hero boost
                else
                {
                    additionalDamage += ApplyNonGojoBoost(jujutsuSorcerer.Health, jujutsuSorcerer.maxHealth, ref jujutsuSorcerer.boostTurnsRemaining);
                }

                return additionalDamage;
            }
            return 0;
        }

        private double TriggerInfinity(double health, ref int immobilizedTurns)
        {
            if (health <= 50 && !infinityActivated)
            {
                infinityActivated = true;
                immobilizedTurns = 3;
                Console.WriteLine("Gojo activates Infinity: Immobilizes enemy attacks for 3 turns but reduces his attack damage by 50%.");
                return 0.5;
            }
            return 1.0;
        }

        private bool Purple()
        {
            if (!purpleActivated)
            {
                bool isActivated = random.NextDouble() < 0.05;
                if (isActivated)
                {
                    purpleActivated = true;
                    Console.WriteLine("Gojo activates Purple: Delivers an attack at 65% of normal damage with additional effects.");
                }
                return isActivated;
            }
            return false;
        }

        private double ApplyNonGojoBoost(double currentHealth, double maxHealth, ref int boostTurnsRemaining)
        {
            if (currentHealth <= maxHealth * 0.6 && boostTurnsRemaining == 0)
            {
                boostTurnsRemaining = 4;
                Console.WriteLine("Non-Gojo hero activates boost: Gains 3% attack increase for 4 turns.");
                return 1.03;
            }
            else if (boostTurnsRemaining > 0)
            {
                boostTurnsRemaining--;
                return 1.03;
            }

            return 1.0;
        }

        private double HandleSukunaAbilities(double health, double maxHealth, ref bool instantKill)
        {
            double totalDamage = 0;
            if (MalevolentKitchen(health, maxHealth))
            {
                totalDamage += 50; // Deals 10 damage 5 times
            }
            totalDamage *= MalevolentShrine(health, maxHealth);

            if (TenFingerMod())
            {
                instantKill = true;
            }

            return totalDamage;
        }

        private bool MalevolentKitchen(double health, double maxHealth)
        {
            if (health <= maxHealth * 0.5 && !malevolentKitchenActivated)
            {
                malevolentKitchenActivated = true;
                Console.WriteLine("Sukuna activates Malevolent Kitchen: Deals 10 damage 5 times in a row.");
                return true;
            }
            return false;
        }

        private double MalevolentShrine(double health, double maxHealth)
        {
            if (health <= maxHealth * 0.25 && !malevolentShrineActivated)
            {
                malevolentShrineActivated = true;
                Console.WriteLine("Sukuna activates Malevolent Shrine: Attack +50% and resets all skills.");
                ResetSukunaSkills();
                return 1.5;
            }
            return 1.0;
        }

        private bool TenFingerMod()
        {
            if (random.NextDouble() < 0.03)  // 3% chance
            {
                Console.WriteLine("Sukuna activates Ten Finger Mod: Instantly kills the enemy.");
                return true;
            }
            return false;
        }

        private void ResetSukunaSkills()
        {
            malevolentKitchenActivated = false;
            malevolentShrineActivated = false;
            rtcActivated = false;
            Console.WriteLine("Sukuna's skills have been reset.");
        }
    }
}
    