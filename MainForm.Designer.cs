namespace OLL
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panel1 = new Panel();
            settingsBox = new GroupBox();
            desktopShortcutButton = new Button();
            label4 = new Label();
            showOnStartBox = new ComboBox();
            autoStartCheckBox = new CheckBox();
            exePanel = new Panel();
            exeLabel = new Label();
            button8 = new Button();
            helpButton = new Button();
            button6 = new Button();
            button5 = new Button();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel2 = new Panel();
            selectedServerTracker = new CurrentServer();
            label3 = new Label();
            playButton = new Button();
            loaderImage = new PictureBox();
            voteSortButton = new Button();
            playerSortButton = new Button();
            favoriteSortButton = new Button();
            panel1.SuspendLayout();
            settingsBox.SuspendLayout();
            exePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)loaderImage).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel1.BackColor = Color.FromArgb(75, 72, 214);
            panel1.Controls.Add(settingsBox);
            panel1.Controls.Add(exePanel);
            panel1.Controls.Add(button8);
            panel1.Controls.Add(helpButton);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(-10, -5);
            panel1.Name = "panel1";
            panel1.Size = new Size(233, 590);
            panel1.TabIndex = 0;
            // 
            // settingsBox
            // 
            settingsBox.Controls.Add(desktopShortcutButton);
            settingsBox.Controls.Add(label4);
            settingsBox.Controls.Add(showOnStartBox);
            settingsBox.Controls.Add(autoStartCheckBox);
            settingsBox.ForeColor = Color.Gainsboro;
            settingsBox.Location = new Point(22, 279);
            settingsBox.Name = "settingsBox";
            settingsBox.Size = new Size(197, 188);
            settingsBox.TabIndex = 5;
            settingsBox.TabStop = false;
            settingsBox.Text = "Settings";
            settingsBox.Visible = false;
            // 
            // desktopShortcutButton
            // 
            desktopShortcutButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            desktopShortcutButton.BackgroundImageLayout = ImageLayout.None;
            desktopShortcutButton.Cursor = Cursors.Hand;
            desktopShortcutButton.FlatAppearance.BorderColor = Color.White;
            desktopShortcutButton.FlatStyle = FlatStyle.Flat;
            desktopShortcutButton.Location = new Point(10, 154);
            desktopShortcutButton.Name = "desktopShortcutButton";
            desktopShortcutButton.Size = new Size(179, 24);
            desktopShortcutButton.TabIndex = 6;
            desktopShortcutButton.Text = "Create Desktop Shortcut";
            desktopShortcutButton.UseVisualStyleBackColor = true;
            desktopShortcutButton.Click += desktopShortcutButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(6, 50);
            label4.Name = "label4";
            label4.Size = new Size(83, 15);
            label4.TabIndex = 6;
            label4.Text = "Show on Start:";
            // 
            // showOnStartBox
            // 
            showOnStartBox.FormattingEnabled = true;
            showOnStartBox.Items.AddRange(new object[] { "Votes", "Players", "Favorites" });
            showOnStartBox.Location = new Point(93, 47);
            showOnStartBox.Name = "showOnStartBox";
            showOnStartBox.Size = new Size(96, 23);
            showOnStartBox.TabIndex = 5;
            showOnStartBox.SelectedIndexChanged += showOnStartBox_SelectedIndexChanged;
            // 
            // autoStartCheckBox
            // 
            autoStartCheckBox.AutoSize = true;
            autoStartCheckBox.Location = new Point(10, 22);
            autoStartCheckBox.Name = "autoStartCheckBox";
            autoStartCheckBox.Size = new Size(76, 19);
            autoStartCheckBox.TabIndex = 4;
            autoStartCheckBox.Text = "AutoStart";
            autoStartCheckBox.UseVisualStyleBackColor = true;
            autoStartCheckBox.CheckedChanged += autoStartCheckBox_CheckedChanged;
            // 
            // exePanel
            // 
            exePanel.BackColor = Color.FromArgb(231, 76, 60);
            exePanel.Controls.Add(exeLabel);
            exePanel.Location = new Point(22, 253);
            exePanel.Name = "exePanel";
            exePanel.Size = new Size(197, 20);
            exePanel.TabIndex = 3;
            // 
            // exeLabel
            // 
            exeLabel.AutoSize = true;
            exeLabel.ForeColor = Color.White;
            exeLabel.Location = new Point(35, 2);
            exeLabel.Name = "exeLabel";
            exeLabel.Size = new Size(124, 15);
            exeLabel.TabIndex = 5;
            exeLabel.Text = "No Executeable found";
            exeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button8
            // 
            button8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button8.BackgroundImageLayout = ImageLayout.None;
            button8.Cursor = Cursors.Hand;
            button8.FlatAppearance.BorderColor = Color.White;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Location = new Point(22, 215);
            button8.Name = "button8";
            button8.Size = new Size(197, 32);
            button8.TabIndex = 4;
            button8.Text = "Settings";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // helpButton
            // 
            helpButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            helpButton.BackgroundImageLayout = ImageLayout.None;
            helpButton.Cursor = Cursors.Hand;
            helpButton.FlatAppearance.BorderColor = Color.White;
            helpButton.FlatStyle = FlatStyle.Flat;
            helpButton.Location = new Point(22, 177);
            helpButton.Name = "helpButton";
            helpButton.Size = new Size(197, 32);
            helpButton.TabIndex = 3;
            helpButton.Text = "Help";
            helpButton.UseVisualStyleBackColor = true;
            helpButton.Click += helpButton_Click;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button6.BackgroundImageLayout = ImageLayout.None;
            button6.Cursor = Cursors.Hand;
            button6.FlatAppearance.BorderColor = Color.White;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Location = new Point(22, 139);
            button6.Name = "button6";
            button6.Size = new Size(197, 32);
            button6.TabIndex = 2;
            button6.Text = "Discord";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button5.BackgroundImageLayout = ImageLayout.None;
            button5.Cursor = Cursors.Hand;
            button5.FlatAppearance.BorderColor = Color.White;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Location = new Point(22, 101);
            button5.Name = "button5";
            button5.Size = new Size(197, 32);
            button5.TabIndex = 1;
            button5.Text = "osu-server-list.com";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(100, 54);
            label2.Name = "label2";
            label2.Size = new Size(95, 15);
            label2.TabIndex = 0;
            label2.Text = "OsuListLauncher";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Variable Display", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(97, 17);
            label1.Name = "label1";
            label1.Size = new Size(64, 36);
            label1.TabIndex = 0;
            label1.Text = "OLL";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(22, 17);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(69, 67);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.White;
            flowLayoutPanel1.Location = new Point(229, 37);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(766, 442);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(75, 72, 214);
            panel2.Controls.Add(selectedServerTracker);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(playButton);
            panel2.Location = new Point(222, 485);
            panel2.Name = "panel2";
            panel2.Size = new Size(831, 107);
            panel2.TabIndex = 1;
            // 
            // selectedServerTracker
            // 
            selectedServerTracker.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            selectedServerTracker.Location = new Point(427, 29);
            selectedServerTracker.Name = "selectedServerTracker";
            selectedServerTracker.Size = new Size(265, 58);
            selectedServerTracker.TabIndex = 2;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(427, 8);
            label3.Name = "label3";
            label3.Size = new Size(89, 15);
            label3.TabIndex = 1;
            label3.Text = "Selected Server:";
            // 
            // playButton
            // 
            playButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            playButton.BackgroundImageLayout = ImageLayout.None;
            playButton.Cursor = Cursors.Hand;
            playButton.FlatAppearance.BorderColor = Color.White;
            playButton.FlatStyle = FlatStyle.Flat;
            playButton.Image = (Image)resources.GetObject("playButton.Image");
            playButton.Location = new Point(698, 8);
            playButton.Name = "playButton";
            playButton.Size = new Size(75, 79);
            playButton.TabIndex = 0;
            playButton.UseVisualStyleBackColor = true;
            playButton.Click += playButton_Click;
            // 
            // loaderImage
            // 
            loaderImage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            loaderImage.Image = Properties.Resources.loading;
            loaderImage.Location = new Point(550, 150);
            loaderImage.MaximumSize = new Size(100, 100);
            loaderImage.MinimumSize = new Size(100, 100);
            loaderImage.Name = "loaderImage";
            loaderImage.Size = new Size(100, 100);
            loaderImage.SizeMode = PictureBoxSizeMode.Zoom;
            loaderImage.TabIndex = 1;
            loaderImage.TabStop = false;
            // 
            // voteSortButton
            // 
            voteSortButton.BackgroundImageLayout = ImageLayout.None;
            voteSortButton.Cursor = Cursors.Hand;
            voteSortButton.FlatAppearance.BorderColor = Color.FromArgb(75, 72, 214);
            voteSortButton.FlatStyle = FlatStyle.Flat;
            voteSortButton.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            voteSortButton.ForeColor = Color.FromArgb(75, 72, 214);
            voteSortButton.Location = new Point(230, 5);
            voteSortButton.Name = "voteSortButton";
            voteSortButton.Size = new Size(75, 26);
            voteSortButton.TabIndex = 1;
            voteSortButton.Text = "Votes";
            voteSortButton.UseVisualStyleBackColor = true;
            voteSortButton.Click += voteSortButton_Click;
            // 
            // playerSortButton
            // 
            playerSortButton.BackgroundImageLayout = ImageLayout.None;
            playerSortButton.Cursor = Cursors.Hand;
            playerSortButton.FlatAppearance.BorderColor = Color.FromArgb(75, 72, 214);
            playerSortButton.FlatStyle = FlatStyle.Flat;
            playerSortButton.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            playerSortButton.ForeColor = Color.FromArgb(75, 72, 214);
            playerSortButton.Location = new Point(311, 5);
            playerSortButton.Name = "playerSortButton";
            playerSortButton.Size = new Size(75, 26);
            playerSortButton.TabIndex = 2;
            playerSortButton.Text = "Players";
            playerSortButton.UseVisualStyleBackColor = true;
            playerSortButton.Click += playerSortButton_Click;
            // 
            // favoriteSortButton
            // 
            favoriteSortButton.BackgroundImageLayout = ImageLayout.None;
            favoriteSortButton.Cursor = Cursors.Hand;
            favoriteSortButton.FlatAppearance.BorderColor = Color.FromArgb(75, 72, 214);
            favoriteSortButton.FlatStyle = FlatStyle.Flat;
            favoriteSortButton.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            favoriteSortButton.ForeColor = Color.FromArgb(75, 72, 214);
            favoriteSortButton.Location = new Point(392, 5);
            favoriteSortButton.Name = "favoriteSortButton";
            favoriteSortButton.Size = new Size(75, 26);
            favoriteSortButton.TabIndex = 3;
            favoriteSortButton.Text = "Favorites";
            favoriteSortButton.UseVisualStyleBackColor = true;
            favoriteSortButton.Click += favoriteSortButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1001, 579);
            Controls.Add(favoriteSortButton);
            Controls.Add(playerSortButton);
            Controls.Add(voteSortButton);
            Controls.Add(panel2);
            Controls.Add(loaderImage);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "OLL";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            settingsBox.ResumeLayout(false);
            settingsBox.PerformLayout();
            exePanel.ResumeLayout(false);
            exePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)loaderImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel2;
        private Label label2;
        private Button playButton;
        private PictureBox loaderImage;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button voteSortButton;
        private Button playerSortButton;
        private Button favoriteSortButton;
        private Label label3;
        private CurrentServer selectedServerTracker;
        private Button button8;
        private Button helpButton;
        private Button button6;
        private Button button5;
        private Panel exePanel;
        private Label exeLabel;
        private GroupBox settingsBox;
        private CheckBox autoStartCheckBox;
        private Label label4;
        private ComboBox showOnStartBox;
        private Button desktopShortcutButton;
    }
}