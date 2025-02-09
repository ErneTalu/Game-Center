namespace Game_Center
{
    partial class Window
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GamesPathTb = new System.Windows.Forms.TextBox();
            this.SelectFolderB = new System.Windows.Forms.Button();
            this.SetFolderB = new System.Windows.Forms.Button();
            this.AddGameB = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.panelGames = new System.Windows.Forms.FlowLayoutPanel();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.SearchTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.GamesPathTb);
            this.panel1.Controls.Add(this.SelectFolderB);
            this.panel1.Controls.Add(this.SetFolderB);
            this.panel1.Controls.Add(this.AddGameB);
            this.panel1.Controls.Add(this.Title);
            this.panel1.Controls.Add(this.Logo);
            this.panel1.Location = new System.Drawing.Point(-2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1094, 136);
            this.panel1.TabIndex = 2;
            // 
            // GamesPathTb
            // 
            this.GamesPathTb.Location = new System.Drawing.Point(943, 105);
            this.GamesPathTb.Name = "GamesPathTb";
            this.GamesPathTb.Size = new System.Drawing.Size(105, 20);
            this.GamesPathTb.TabIndex = 6;
            this.GamesPathTb.TextChanged += new System.EventHandler(this.GamesPathTb_TextChanged);
            // 
            // SelectFolderB
            // 
            this.SelectFolderB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SelectFolderB.Location = new System.Drawing.Point(936, 3);
            this.SelectFolderB.Name = "SelectFolderB";
            this.SelectFolderB.Size = new System.Drawing.Size(120, 28);
            this.SelectFolderB.TabIndex = 5;
            this.SelectFolderB.Text = "Select Folder";
            this.SelectFolderB.UseVisualStyleBackColor = false;
            this.SelectFolderB.Click += new System.EventHandler(this.SelectFolderB_Click);
            // 
            // SetFolderB
            // 
            this.SetFolderB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.SetFolderB.Location = new System.Drawing.Point(936, 32);
            this.SetFolderB.Name = "SetFolderB";
            this.SetFolderB.Size = new System.Drawing.Size(120, 64);
            this.SetFolderB.TabIndex = 4;
            this.SetFolderB.Text = "Set Folder";
            this.SetFolderB.UseVisualStyleBackColor = false;
            this.SetFolderB.Click += new System.EventHandler(this.SetFolderB_Click);
            // 
            // AddGameB
            // 
            this.AddGameB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.AddGameB.Location = new System.Drawing.Point(780, 32);
            this.AddGameB.Name = "AddGameB";
            this.AddGameB.Size = new System.Drawing.Size(120, 64);
            this.AddGameB.TabIndex = 3;
            this.AddGameB.Text = "Add Game";
            this.AddGameB.UseVisualStyleBackColor = false;
            this.AddGameB.Click += new System.EventHandler(this.AddGameB_Click);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Title.Font = new System.Drawing.Font("Sitka Small", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Title.ForeColor = System.Drawing.SystemColors.Control;
            this.Title.Location = new System.Drawing.Point(148, 25);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(343, 71);
            this.Title.TabIndex = 1;
            this.Title.Text = "Game Center";
            this.Title.Click += new System.EventHandler(this.Title_Click);
            // 
            // Logo
            // 
            this.Logo.Image = global::Game_Center.Properties.Resources.ControllerLogo;
            this.Logo.Location = new System.Drawing.Point(17, 5);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(125, 125);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Logo.TabIndex = 0;
            this.Logo.TabStop = false;
            this.Logo.Click += new System.EventHandler(this.Logo_Click);
            // 
            // panelGames
            // 
            this.panelGames.AutoScroll = true;
            this.panelGames.Location = new System.Drawing.Point(-2, 193);
            this.panelGames.Margin = new System.Windows.Forms.Padding(0);
            this.panelGames.Name = "panelGames";
            this.panelGames.Size = new System.Drawing.Size(1072, 496);
            this.panelGames.TabIndex = 3;
            this.panelGames.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGames_Paint);
            // 
            // SearchBox
            // 
            this.SearchBox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.SearchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SearchBox.Font = new System.Drawing.Font("Malgun Gothic", 12.2F);
            this.SearchBox.ForeColor = System.Drawing.SystemColors.Control;
            this.SearchBox.Location = new System.Drawing.Point(24, 151);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(1025, 29);
            this.SearchBox.TabIndex = 4;
            this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // SearchTimer
            // 
            this.SearchTimer.Tick += new System.EventHandler(this.SearchTimer_Tick);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1091, 698);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.panelGames);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Window";
            this.Text = "Game Center";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button AddGameB;
        private System.Windows.Forms.Button SetFolderB;
        private System.Windows.Forms.FlowLayoutPanel panelGames;
        private System.Windows.Forms.Button SelectFolderB;
        private System.Windows.Forms.TextBox GamesPathTb;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Timer SearchTimer;
    }
}

