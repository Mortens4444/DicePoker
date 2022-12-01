namespace DiePoker
{
    partial class MainForm
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
            this.pMain = new System.Windows.Forms.Panel();
            this.pControls = new System.Windows.Forms.Panel();
            this.lvRolls = new System.Windows.Forms.ListView();
            this.columnHeader0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pRolls = new System.Windows.Forms.Panel();
            this.pController = new System.Windows.Forms.Panel();
            this.lblCurrentPlayer = new System.Windows.Forms.Label();
            this.cbPokerHands = new System.Windows.Forms.ComboBox();
            this.btnPokerHand = new System.Windows.Forms.Button();
            this.chkKeep1 = new System.Windows.Forms.CheckBox();
            this.btnRoll = new System.Windows.Forms.Button();
            this.chkKeep5 = new System.Windows.Forms.CheckBox();
            this.chkKeep2 = new System.Windows.Forms.CheckBox();
            this.chkKeep4 = new System.Windows.Forms.CheckBox();
            this.chkKeep3 = new System.Windows.Forms.CheckBox();
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.tsmiGame = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiChangePlayers = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.pMain.SuspendLayout();
            this.pControls.SuspendLayout();
            this.pRolls.SuspendLayout();
            this.pController.SuspendLayout();
            this.msMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pMain
            // 
            this.pMain.Controls.Add(this.pControls);
            this.pMain.Controls.Add(this.pRolls);
            this.pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMain.Location = new System.Drawing.Point(0, 0);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(674, 558);
            this.pMain.TabIndex = 0;
            // 
            // pControls
            // 
            this.pControls.Controls.Add(this.lvRolls);
            this.pControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pControls.Location = new System.Drawing.Point(0, 112);
            this.pControls.Name = "pControls";
            this.pControls.Size = new System.Drawing.Size(674, 446);
            this.pControls.TabIndex = 2;
            // 
            // lvRolls
            // 
            this.lvRolls.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader0,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lvRolls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRolls.FullRowSelect = true;
            this.lvRolls.HideSelection = false;
            this.lvRolls.Location = new System.Drawing.Point(0, 0);
            this.lvRolls.Name = "lvRolls";
            this.lvRolls.Size = new System.Drawing.Size(674, 446);
            this.lvRolls.TabIndex = 0;
            this.lvRolls.UseCompatibleStateImageBehavior = false;
            this.lvRolls.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader0
            // 
            this.columnHeader0.Text = "Player name";
            this.columnHeader0.Width = 156;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Die #1";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Die #2";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Die #3";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Die #4";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Die #5";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Type";
            this.columnHeader6.Width = 153;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Points";
            // 
            // pRolls
            // 
            this.pRolls.Controls.Add(this.pController);
            this.pRolls.Controls.Add(this.msMenu);
            this.pRolls.Dock = System.Windows.Forms.DockStyle.Top;
            this.pRolls.Location = new System.Drawing.Point(0, 0);
            this.pRolls.Name = "pRolls";
            this.pRolls.Size = new System.Drawing.Size(674, 112);
            this.pRolls.TabIndex = 1;
            // 
            // pController
            // 
            this.pController.Controls.Add(this.lblCurrentPlayer);
            this.pController.Controls.Add(this.cbPokerHands);
            this.pController.Controls.Add(this.btnPokerHand);
            this.pController.Controls.Add(this.chkKeep1);
            this.pController.Controls.Add(this.btnRoll);
            this.pController.Controls.Add(this.chkKeep5);
            this.pController.Controls.Add(this.chkKeep2);
            this.pController.Controls.Add(this.chkKeep4);
            this.pController.Controls.Add(this.chkKeep3);
            this.pController.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pController.Location = new System.Drawing.Point(0, 24);
            this.pController.Name = "pController";
            this.pController.Size = new System.Drawing.Size(674, 88);
            this.pController.TabIndex = 10;
            // 
            // lblCurrentPlayer
            // 
            this.lblCurrentPlayer.AutoSize = true;
            this.lblCurrentPlayer.Location = new System.Drawing.Point(12, 17);
            this.lblCurrentPlayer.Name = "lblCurrentPlayer";
            this.lblCurrentPlayer.Size = new System.Drawing.Size(0, 13);
            this.lblCurrentPlayer.TabIndex = 9;
            // 
            // cbPokerHands
            // 
            this.cbPokerHands.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPokerHands.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPokerHands.FormattingEnabled = true;
            this.cbPokerHands.Location = new System.Drawing.Point(454, 61);
            this.cbPokerHands.Name = "cbPokerHands";
            this.cbPokerHands.Size = new System.Drawing.Size(136, 21);
            this.cbPokerHands.TabIndex = 8;
            // 
            // btnPokerHand
            // 
            this.btnPokerHand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPokerHand.Enabled = false;
            this.btnPokerHand.Location = new System.Drawing.Point(596, 59);
            this.btnPokerHand.Name = "btnPokerHand";
            this.btnPokerHand.Size = new System.Drawing.Size(75, 23);
            this.btnPokerHand.TabIndex = 7;
            this.btnPokerHand.Text = "Poker hand";
            this.btnPokerHand.UseVisualStyleBackColor = true;
            this.btnPokerHand.Click += new System.EventHandler(this.BtnPokerHand_Click);
            // 
            // chkKeep1
            // 
            this.chkKeep1.AutoSize = true;
            this.chkKeep1.Location = new System.Drawing.Point(159, 65);
            this.chkKeep1.Name = "chkKeep1";
            this.chkKeep1.Size = new System.Drawing.Size(51, 17);
            this.chkKeep1.TabIndex = 2;
            this.chkKeep1.Text = "Keep";
            this.chkKeep1.UseVisualStyleBackColor = true;
            // 
            // btnRoll
            // 
            this.btnRoll.Location = new System.Drawing.Point(12, 33);
            this.btnRoll.Name = "btnRoll";
            this.btnRoll.Size = new System.Drawing.Size(75, 23);
            this.btnRoll.TabIndex = 0;
            this.btnRoll.Text = "Roll";
            this.btnRoll.UseVisualStyleBackColor = true;
            this.btnRoll.Click += new System.EventHandler(this.BtnRoll_Click);
            // 
            // chkKeep5
            // 
            this.chkKeep5.AutoSize = true;
            this.chkKeep5.Location = new System.Drawing.Point(397, 65);
            this.chkKeep5.Name = "chkKeep5";
            this.chkKeep5.Size = new System.Drawing.Size(51, 17);
            this.chkKeep5.TabIndex = 6;
            this.chkKeep5.Text = "Keep";
            this.chkKeep5.UseVisualStyleBackColor = true;
            // 
            // chkKeep2
            // 
            this.chkKeep2.AutoSize = true;
            this.chkKeep2.Location = new System.Drawing.Point(216, 65);
            this.chkKeep2.Name = "chkKeep2";
            this.chkKeep2.Size = new System.Drawing.Size(51, 17);
            this.chkKeep2.TabIndex = 3;
            this.chkKeep2.Text = "Keep";
            this.chkKeep2.UseVisualStyleBackColor = true;
            // 
            // chkKeep4
            // 
            this.chkKeep4.AutoSize = true;
            this.chkKeep4.Location = new System.Drawing.Point(340, 65);
            this.chkKeep4.Name = "chkKeep4";
            this.chkKeep4.Size = new System.Drawing.Size(51, 17);
            this.chkKeep4.TabIndex = 5;
            this.chkKeep4.Text = "Keep";
            this.chkKeep4.UseVisualStyleBackColor = true;
            // 
            // chkKeep3
            // 
            this.chkKeep3.AutoSize = true;
            this.chkKeep3.Location = new System.Drawing.Point(273, 65);
            this.chkKeep3.Name = "chkKeep3";
            this.chkKeep3.Size = new System.Drawing.Size(51, 17);
            this.chkKeep3.TabIndex = 4;
            this.chkKeep3.Text = "Keep";
            this.chkKeep3.UseVisualStyleBackColor = true;
            // 
            // msMenu
            // 
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGame});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(674, 24);
            this.msMenu.TabIndex = 9;
            this.msMenu.Text = "menuStrip1";
            // 
            // tsmiGame
            // 
            this.tsmiGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewGame,
            this.toolStripSeparator1,
            this.tsmiChangePlayers,
            this.toolStripSeparator2,
            this.tsmiExit});
            this.tsmiGame.Name = "tsmiGame";
            this.tsmiGame.Size = new System.Drawing.Size(50, 20);
            this.tsmiGame.Text = "Game";
            // 
            // tsmiNewGame
            // 
            this.tsmiNewGame.Name = "tsmiNewGame";
            this.tsmiNewGame.Size = new System.Drawing.Size(155, 22);
            this.tsmiNewGame.Text = "New game";
            this.tsmiNewGame.Click += new System.EventHandler(this.TsmiNewGame_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // tsmiChangePlayers
            // 
            this.tsmiChangePlayers.Name = "tsmiChangePlayers";
            this.tsmiChangePlayers.Size = new System.Drawing.Size(155, 22);
            this.tsmiChangePlayers.Text = "Change players";
            this.tsmiChangePlayers.Click += new System.EventHandler(this.TsmiChangePlayers_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(152, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(155, 22);
            this.tsmiExit.Text = "Exit";
            this.tsmiExit.Click += new System.EventHandler(this.TsmiExit_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnRoll;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 558);
            this.Controls.Add(this.pMain);
            this.MainMenuStrip = this.msMenu;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.pMain.ResumeLayout(false);
            this.pControls.ResumeLayout(false);
            this.pRolls.ResumeLayout(false);
            this.pRolls.PerformLayout();
            this.pController.ResumeLayout(false);
            this.pController.PerformLayout();
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.Panel pControls;
        private System.Windows.Forms.ListView lvRolls;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Panel pRolls;
        private System.Windows.Forms.Button btnRoll;
        private System.Windows.Forms.CheckBox chkKeep5;
        private System.Windows.Forms.CheckBox chkKeep4;
        private System.Windows.Forms.CheckBox chkKeep3;
        private System.Windows.Forms.CheckBox chkKeep2;
        private System.Windows.Forms.CheckBox chkKeep1;
        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiGame;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewGame;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.Panel pController;
        private System.Windows.Forms.Button btnPokerHand;
        private System.Windows.Forms.ColumnHeader columnHeader0;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ComboBox cbPokerHands;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangePlayers;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label lblCurrentPlayer;
        private System.Windows.Forms.ColumnHeader columnHeader7;
    }
}

