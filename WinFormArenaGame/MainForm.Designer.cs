namespace WinFormArenaGame
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            btnNewGame = new Button();
            tbKnight = new TextBox();
            tbAssassin = new TextBox();
            imgFight = new PictureBox();
            lbWinner = new Label();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)imgFight).BeginInit();
            SuspendLayout();
            // 
            // btnNewGame
            // 
            btnNewGame.Location = new Point(675, 63);
            btnNewGame.Name = "btnNewGame";
            btnNewGame.Size = new Size(94, 29);
            btnNewGame.TabIndex = 0;
            btnNewGame.Text = "New Game";
            btnNewGame.UseVisualStyleBackColor = true;
            btnNewGame.Click += btnNewGame_Click;
            // 
            // tbKnight
            // 
            tbKnight.Location = new Point(23, 35);
            tbKnight.Multiline = true;
            tbKnight.Name = "tbKnight";
            tbKnight.ScrollBars = ScrollBars.Vertical;
            tbKnight.Size = new Size(560, 437);
            tbKnight.TabIndex = 1;
            tbKnight.TextChanged += tbKnight_TextChanged_1;
            // 
            // tbAssassin
            // 
            tbAssassin.Location = new Point(879, 44);
            tbAssassin.Multiline = true;
            tbAssassin.Name = "tbAssassin";
            tbAssassin.ScrollBars = ScrollBars.Vertical;
            tbAssassin.Size = new Size(560, 437);
            tbAssassin.TabIndex = 2;
            // 
            // imgFight
            // 
            imgFight.Enabled = false;
            imgFight.Image = (Image)resources.GetObject("imgFight.Image");
            imgFight.Location = new Point(631, 252);
            imgFight.Name = "imgFight";
            imgFight.Size = new Size(206, 134);
            imgFight.TabIndex = 3;
            imgFight.TabStop = false;
            // 
            // lbWinner
            // 
            lbWinner.Location = new Point(631, 121);
            lbWinner.Name = "lbWinner";
            lbWinner.Size = new Size(206, 89);
            lbWinner.TabIndex = 4;
            lbWinner.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(879, 18);
            label1.Name = "label1";
            label1.Size = new Size(66, 20);
            label1.TabIndex = 5;
            label1.Text = "Assassin:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 9);
            label2.Name = "label2";
            label2.Size = new Size(55, 20);
            label2.TabIndex = 6;
            label2.Text = "Knight:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1464, 504);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lbWinner);
            Controls.Add(imgFight);
            Controls.Add(tbAssassin);
            Controls.Add(tbKnight);
            Controls.Add(btnNewGame);
            Name = "MainForm";
            Text = "Arena Game";
            ((System.ComponentModel.ISupportInitialize)imgFight).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnNewGame;
        private TextBox tbKnight;
        private TextBox tbAssassin;
        private PictureBox imgFight;
        private Label lbWinner;
        private Label label1;
        private Label label2;
    }
}
