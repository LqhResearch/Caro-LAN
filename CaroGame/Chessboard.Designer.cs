
namespace CaroGame
{
    partial class Chessboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chessboard));
            this.pnlAvatar = new System.Windows.Forms.Panel();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.btnLAN = new Guna.UI2.WinForms.Guna2Button();
            this.pgbTime = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.txtIP = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPlayerName = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlChessboard = new System.Windows.Forms.Panel();
            this.timerCountDown = new System.Windows.Forms.Timer(this.components);
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.msMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAvatar
            // 
            this.pnlAvatar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAvatar.BackgroundImage = global::CaroGame.Properties.Resources.avatar;
            this.pnlAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlAvatar.Location = new System.Drawing.Point(529, 27);
            this.pnlAvatar.Name = "pnlAvatar";
            this.pnlAvatar.Size = new System.Drawing.Size(300, 300);
            this.pnlAvatar.TabIndex = 1;
            // 
            // pnlInfo
            // 
            this.pnlInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInfo.Controls.Add(this.picIcon);
            this.pnlInfo.Controls.Add(this.btnLAN);
            this.pnlInfo.Controls.Add(this.pgbTime);
            this.pnlInfo.Controls.Add(this.txtIP);
            this.pnlInfo.Controls.Add(this.txtPlayerName);
            this.pnlInfo.Location = new System.Drawing.Point(529, 333);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(300, 204);
            this.pnlInfo.TabIndex = 1;
            // 
            // picIcon
            // 
            this.picIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picIcon.Location = new System.Drawing.Point(197, 3);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(100, 100);
            this.picIcon.TabIndex = 4;
            this.picIcon.TabStop = false;
            // 
            // btnLAN
            // 
            this.btnLAN.CheckedState.Parent = this.btnLAN;
            this.btnLAN.CustomImages.Parent = this.btnLAN;
            this.btnLAN.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLAN.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLAN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLAN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLAN.DisabledState.Parent = this.btnLAN;
            this.btnLAN.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLAN.ForeColor = System.Drawing.Color.White;
            this.btnLAN.HoverState.Parent = this.btnLAN;
            this.btnLAN.Location = new System.Drawing.Point(3, 123);
            this.btnLAN.Name = "btnLAN";
            this.btnLAN.ShadowDecoration.Parent = this.btnLAN;
            this.btnLAN.Size = new System.Drawing.Size(188, 45);
            this.btnLAN.TabIndex = 3;
            this.btnLAN.Text = "LAN";
            this.btnLAN.Click += new System.EventHandler(this.btnLAN_Click);
            // 
            // pgbTime
            // 
            this.pgbTime.Location = new System.Drawing.Point(3, 45);
            this.pgbTime.Maximum = 20;
            this.pgbTime.Name = "pgbTime";
            this.pgbTime.ShadowDecoration.Parent = this.pgbTime;
            this.pgbTime.Size = new System.Drawing.Size(188, 30);
            this.pgbTime.TabIndex = 2;
            this.pgbTime.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // txtIP
            // 
            this.txtIP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIP.DefaultText = "127.0.0.1";
            this.txtIP.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtIP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtIP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIP.DisabledState.Parent = this.txtIP;
            this.txtIP.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIP.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtIP.FocusedState.Parent = this.txtIP;
            this.txtIP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIP.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtIP.HoverState.Parent = this.txtIP;
            this.txtIP.Location = new System.Drawing.Point(3, 81);
            this.txtIP.Name = "txtIP";
            this.txtIP.PasswordChar = '\0';
            this.txtIP.PlaceholderText = "";
            this.txtIP.SelectedText = "";
            this.txtIP.SelectionStart = 9;
            this.txtIP.ShadowDecoration.Parent = this.txtIP;
            this.txtIP.Size = new System.Drawing.Size(188, 36);
            this.txtIP.TabIndex = 0;
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPlayerName.DefaultText = "";
            this.txtPlayerName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPlayerName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPlayerName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPlayerName.DisabledState.Parent = this.txtPlayerName;
            this.txtPlayerName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPlayerName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPlayerName.FocusedState.Parent = this.txtPlayerName;
            this.txtPlayerName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPlayerName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPlayerName.HoverState.Parent = this.txtPlayerName;
            this.txtPlayerName.Location = new System.Drawing.Point(3, 3);
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.PasswordChar = '\0';
            this.txtPlayerName.PlaceholderText = "";
            this.txtPlayerName.ReadOnly = true;
            this.txtPlayerName.SelectedText = "";
            this.txtPlayerName.ShadowDecoration.Parent = this.txtPlayerName;
            this.txtPlayerName.Size = new System.Drawing.Size(188, 36);
            this.txtPlayerName.TabIndex = 0;
            // 
            // pnlChessboard
            // 
            this.pnlChessboard.BackColor = System.Drawing.SystemColors.Control;
            this.pnlChessboard.Location = new System.Drawing.Point(12, 27);
            this.pnlChessboard.Name = "pnlChessboard";
            this.pnlChessboard.Size = new System.Drawing.Size(510, 510);
            this.pnlChessboard.TabIndex = 2;
            // 
            // timerCountDown
            // 
            this.timerCountDown.Tick += new System.EventHandler(this.timerCountDown_Tick);
            // 
            // msMenu
            // 
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(839, 24);
            this.msMenu.TabIndex = 3;
            this.msMenu.Text = "menuStrip1";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.newGameToolStripMenuItem.Text = "&New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.undoToolStripMenuItem.Text = "&Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.quitToolStripMenuItem.Text = "&Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // Chessboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(839, 546);
            this.Controls.Add(this.pnlChessboard);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlAvatar);
            this.Controls.Add(this.msMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMenu;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Chessboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Caro LAN";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Chessboard_FormClosing);
            this.Load += new System.EventHandler(this.Chessboard_Load);
            this.Shown += new System.EventHandler(this.Chessboard_Shown);
            this.pnlInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlAvatar;
        private System.Windows.Forms.Panel pnlInfo;
        private Guna.UI2.WinForms.Guna2Button btnLAN;
        private Guna.UI2.WinForms.Guna2ProgressBar pgbTime;
        private Guna.UI2.WinForms.Guna2TextBox txtIP;
        private Guna.UI2.WinForms.Guna2TextBox txtPlayerName;
        private System.Windows.Forms.Panel pnlChessboard;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Timer timerCountDown;
        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
    }
}

