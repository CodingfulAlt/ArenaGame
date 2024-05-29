using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ArenaGame;
using ArenaGame.Heroes;
using ArenaGame.Weapons;

namespace WinFormArenaGame
{
    public partial class MainForm : Form
    {
        private int turnCounter = 1;
        private GameEngine gameEngine;
        private List<Hero> heroes;

        public MainForm()
        {
            InitializeComponent();
            InitializeHeroes();
            DisplayHeroList();
        }

        private void InitializeHeroes()
        {
            heroes = new List<Hero>
            {

               //chatgpt copilot and stackoverflow helped for creating mainform.cs and some parts in mainform.design
                new Knight("Crock", 10, 20, new Sword("Excalibur")),
                new Goblin("Kradec", 10, 20, new Bag("Magic Bag")),
                new Sorcerer("Oz", 10, 20, new CursedEnergy("Dark Orb")),
                new Assassin("Beast", 10, 20, new Dagger("Hidden Blade")),
                new Archer("Melodie", 10, 20, new Excalibow("Long Bow")),
                new TheChosenOnes("Thor", 10, 20, new Mjolnir("Thunder Hammer")),
                new JujutsuSorcerers("Gojo", 25, 35, new DomainExpansion("Infinite Void")),
                new JujutsuSorcerers("Sukuna", 25, 35, new DomainExpansion("Malevolent Shrine"))
            };
        }

        private void DisplayHeroList()
        {
            lbHeroList.Items.Clear();
            for (int i = 0; i < heroes.Count; i++)
            {
                lbHeroList.Items.Add($"{i + 1}. {heroes[i].GetType().Name} {heroes[i].Name} with weapon {heroes[i].Weapon.Name} (Armor: {heroes[i].Armor}, Strength: {heroes[i].Strenght})");
            }
        }

        private void gameNotification(GameEngine.NotificationArgs args)
        {
          
            TextBox tbCurrent = args.Attacker == gameEngine.HeroA ? tbKnight : tbAssassin;

            tbCurrent.AppendText($"Turn {turnCounter}:\r\n");
            tbCurrent.AppendText($"{args.Attacker.Name} attacked {args.Defender.Name} with {Math.Round(args.Attack, 2)} and caused {Math.Round(args.Damage, 2)} damage.\r\n");
            tbCurrent.AppendText($"Attacker: {args.Attacker.Name} with health {Math.Round(args.Attacker.Health, 2)}\r\n");
            tbCurrent.AppendText($"Defender: {args.Defender.Name} with health {Math.Round(args.Defender.Health, 2)}\r\n");
            tbCurrent.AppendText("----------------------------------------------------------------------\r\n");

           
            turnCounter++;
            Application.DoEvents();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            lbWinner.Text = "";
            tbAssassin.Text = "";
            tbKnight.Text = "";
            lbWinner.Visible = false;
            turnCounter = 1;  

            Hero heroA = ChooseHero("A");
            Hero heroB = ChooseHero("B");

            if (heroA != null && heroB != null)
            {
                gameEngine = new GameEngine()
                {
                    HeroA = heroA,
                    HeroB = heroB,
                    NotificationsCallBack = gameNotification
                };

                imgFight.Enabled = true;
                gameEngine.Fight();
                imgFight.Enabled = false;

                lbWinner.Text = $"And the winner is:\n{gameEngine.Winner.Name} with health {Math.Round(gameEngine.Winner.Health, 2)}";
                lbWinner.Visible = true;
            }
        }

        private Hero ChooseHero(string heroLabel)
        {
            while (true)
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox($"Choose Hero {heroLabel} (enter the number):", "Hero Selection", "");
                if (string.IsNullOrEmpty(input)) return null; 
                if (int.TryParse(input, out int choice) && choice >= 1 && choice <= heroes.Count)
                {
                    return heroes[choice - 1];
                }
                MessageBox.Show("Invalid choice, try again.");
            }
        }

        private void lbWinner_Click(object sender, EventArgs e)
        {
          
        }

        private void tbKnight_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tbAssassin_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tbKnight_TextChanged_1(object sender, EventArgs e)
        {
          
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
