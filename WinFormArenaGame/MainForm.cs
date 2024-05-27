using System;
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

        public MainForm()
        {
            InitializeComponent();
        }

        private void gameNotification(GameEngine.NotificationArgs args)
        {
            // Determine text boxes based on turn
            TextBox tbLeft = tbKnight;
            TextBox tbRight = tbAssassin;

            if (args.Attacker == gameEngine.HeroA)
            {
                tbLeft.AppendText($"Turn {turnCounter}:\r\n");
                tbLeft.AppendText($"{args.Attacker.Name} attacked {args.Defender.Name} with {Math.Round(args.Attack, 2)} and caused {Math.Round(args.Damage, 2)} damage.\r\n");
                tbLeft.AppendText($"Attacker: {args.Attacker.Name} with health {Math.Round(args.Attacker.Health, 2)}\r\n");
                tbLeft.AppendText($"Defender: {args.Defender.Name} with health {Math.Round(args.Defender.Health, 2)}\r\n");
                tbLeft.AppendText("----------------------------------------------------------------------\r\n");
            }
            else if (args.Attacker == gameEngine.HeroB)
            {
                tbRight.AppendText($"Turn {turnCounter}:\r\n");
                tbRight.AppendText($"{args.Attacker.Name} attacked {args.Defender.Name} with {Math.Round(args.Attack, 2)} and caused {Math.Round(args.Damage, 2)} damage.\r\n");
                tbRight.AppendText($"Attacker: {args.Attacker.Name} with health {Math.Round(args.Attacker.Health, 2)}\r\n");
                tbRight.AppendText($"Defender: {args.Defender.Name} with health {Math.Round(args.Defender.Health, 2)}\r\n");
                tbRight.AppendText("----------------------------------------------------------------------\r\n");
            }

            // Increment the turn counter
            turnCounter++;

            // Ensure that the UI updates properly
            DateTime dt = DateTime.Now;
            while (DateTime.Now - dt < TimeSpan.FromMilliseconds(300))
            {
                Application.DoEvents();
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            lbWinner.Text = "";
            tbAssassin.Text = "";
            tbKnight.Text = "";
            lbWinner.Visible = false;
            turnCounter = 1;  // Reset the turn counter for a new game

            gameEngine = new GameEngine()
            {
                HeroA = new Sorcerer("Sorcerer", 10, 20, new CursedEnergy("CursedEnergy")),
                HeroB = new Archer("TheChosenOnes", 10, 5, new Excalibow("Excalibow")),
                NotificationsCallBack = gameNotification
            };

            imgFight.Enabled = true;
            gameEngine.Fight();
            imgFight.Enabled = false;

            lbWinner.Text = $"And the winner is:\n{gameEngine.Winner.Name}";
            lbWinner.Visible = true;
        }

        private void lbWinner_Click(object sender, EventArgs e)
        {
            // Handle label click if necessary
        }

        private void tbKnight_TextChanged(object sender, EventArgs e)
        {
            // Handle text changed event if necessary
        }

        private void tbAssassin_TextChanged(object sender, EventArgs e)
        {
            // Handle text changed event if necessary
        }

        private void tbKnight_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
