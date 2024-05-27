using System;
using ArenaGame;

namespace ArenaGame.Weapons
{
    //Jujutsusorcerers and Domainexpansion are created with the help of chatgpt. vsishki komentari pokazvat za kakvo sum izpolzval gpt
    public class DomainExpansion : IWeapon
    {
        public string Name { get; set; }
        public double AttackDamage { get; private set; }
        public double BlockingPower { get; private set; }
        private Random random = new Random();

        // Flags to track if abilities have been used
        private bool infinityActivated = false;
        private bool limitlessActivated = false;
        private bool purpleActivated = false;
        private bool malevolentKitchenActivated = false;
        private bool malevolentShrineActivated = false;
        private bool rtcActivated = false;

        public DomainExpansion(string name)
        {
            Name = name;
            AttackDamage = 25;
            BlockingPower = 10;
        }

        public double TriggerInfinity(double health, ref int immobilizedTurns)
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

        // Handles "Limitless" ability for Gojo: Activates if health <= 10% of max health or if health drops to 0 or below
        public double TriggerLimitless(double health, double maxHealth)
        {
            if ((health <= maxHealth * 0.1 || health <= 0) && !limitlessActivated)
            {
                limitlessActivated = true;
                double recoveryOption = random.NextDouble() < 0.5 ? 0.30 : 0.20;
                Console.WriteLine($"Gojo activates Limitless: Recovers {(recoveryOption * 100)}% of max health.");
                return recoveryOption;
            }
            return 0;
        }

        public bool Purple()
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

        // Applies a 3% attack boost for non-Gojo characters
        public double ApplyNonGojoBoost(double currentHealth, double maxHealth, ref int boostTurnsRemaining)
        {
            if (currentHealth <= maxHealth * 0.6 && boostTurnsRemaining == 0)
            {
                boostTurnsRemaining = 4;
                Console.WriteLine("Non-Gojo hero activates boost: Gains 3% attack increase for 4 turns.");
            }

            if (boostTurnsRemaining > 0)
            {
                boostTurnsRemaining--;
                return 1.03;
            }

            return 1.0;
        }

    
        public bool MalevolentKitchen(double health, double maxHealth)
        {
            if (health <= maxHealth * 0.5 && !malevolentKitchenActivated)
            {
                malevolentKitchenActivated = true;
                Console.WriteLine("Sukuna activates Malevolent Kitchen: Deals 10 damage 5 times in a row.");
                return true;
            }
            return false;
        }

        public double MalevolentShrine(double health, double maxHealth)
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

        public double RTC(double health, double maxHealth)
        {
            if (health <= maxHealth * 0.1 && !rtcActivated)
            {
                rtcActivated = true;
                double recoveryChance = random.NextDouble();
                if (recoveryChance < 0.25)
                {
                    Console.WriteLine("Sukuna activates RTC: Heals for 41% of max health and resets all skills.");
                    ResetSukunaSkills();
                    return 0.41;
                }
                else
                {
                    Console.WriteLine("Sukuna activates RTC: Heals for 10% of max health.");
                    return 0.10;
                }
            }
            return 0;
        }

        public bool TenFingerMod()
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

        // Method to handle the activation of all Sukuna abilities
        public double HandleSukunaAbilities(double health, double maxHealth, ref bool instantKill)
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
    }
}
    