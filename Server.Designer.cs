namespace OLL
{
    partial class Server
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            serverUrlLinkLabel = new LinkLabel();
            pictureBox2 = new PictureBox();
            label3 = new Label();
            label4 = new Label();
            serverSelectButton = new Button();
            favoriteButton = new Button();
            voteButton = new Button();
            viewButton = new Button();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(87, 79);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(96, 3);
            label1.Name = "label1";
            label1.Size = new Size(49, 21);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(96, 69);
            label2.Name = "label2";
            label2.Size = new Size(38, 13);
            label2.TabIndex = 2;
            label2.Text = "label2";
            // 
            // serverUrlLinkLabel
            // 
            serverUrlLinkLabel.AutoSize = true;
            serverUrlLinkLabel.Location = new Point(96, 53);
            serverUrlLinkLabel.Name = "serverUrlLinkLabel";
            serverUrlLinkLabel.Size = new Size(60, 15);
            serverUrlLinkLabel.TabIndex = 3;
            serverUrlLinkLabel.TabStop = true;
            serverUrlLinkLabel.Text = "linkLabel1";
            serverUrlLinkLabel.LinkClicked += serverUrlLinkLabel_LinkClicked;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.online;
            pictureBox2.Location = new Point(99, 25);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(14, 14);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(116, 25);
            label3.Name = "label3";
            label3.Size = new Size(38, 13);
            label3.TabIndex = 5;
            label3.Text = "label3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(96, 40);
            label4.Name = "label4";
            label4.Size = new Size(38, 13);
            label4.TabIndex = 6;
            label4.Text = "label4";
            // 
            // serverSelectButton
            // 
            serverSelectButton.BackgroundImageLayout = ImageLayout.None;
            serverSelectButton.Cursor = Cursors.Hand;
            serverSelectButton.FlatAppearance.BorderColor = Color.FromArgb(75, 72, 214);
            serverSelectButton.FlatStyle = FlatStyle.Flat;
            serverSelectButton.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            serverSelectButton.ForeColor = Color.FromArgb(75, 72, 214);
            serverSelectButton.Location = new Point(636, 3);
            serverSelectButton.Name = "serverSelectButton";
            serverSelectButton.Size = new Size(75, 36);
            serverSelectButton.TabIndex = 7;
            serverSelectButton.Text = "Select";
            serverSelectButton.UseVisualStyleBackColor = true;
            serverSelectButton.Click += serverSelectButton_Click;
            // 
            // favoriteButton
            // 
            favoriteButton.BackgroundImageLayout = ImageLayout.None;
            favoriteButton.Cursor = Cursors.Hand;
            favoriteButton.FlatAppearance.BorderColor = Color.FromArgb(75, 72, 214);
            favoriteButton.FlatStyle = FlatStyle.Flat;
            favoriteButton.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            favoriteButton.ForeColor = Color.FromArgb(75, 72, 214);
            favoriteButton.Location = new Point(636, 45);
            favoriteButton.Name = "favoriteButton";
            favoriteButton.Size = new Size(75, 37);
            favoriteButton.TabIndex = 8;
            favoriteButton.Text = "Favorite";
            favoriteButton.UseVisualStyleBackColor = true;
            favoriteButton.Click += favoriteButton_Click;
            // 
            // voteButton
            // 
            voteButton.BackgroundImageLayout = ImageLayout.None;
            voteButton.Cursor = Cursors.Hand;
            voteButton.FlatAppearance.BorderColor = Color.FromArgb(75, 72, 214);
            voteButton.FlatStyle = FlatStyle.Flat;
            voteButton.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            voteButton.ForeColor = Color.FromArgb(75, 72, 214);
            voteButton.Location = new Point(589, 58);
            voteButton.Name = "voteButton";
            voteButton.Size = new Size(41, 24);
            voteButton.TabIndex = 9;
            voteButton.Text = "Vote";
            voteButton.UseVisualStyleBackColor = true;
            voteButton.Click += voteButton_Click;
            // 
            // viewButton
            // 
            viewButton.BackgroundImageLayout = ImageLayout.None;
            viewButton.Cursor = Cursors.Hand;
            viewButton.FlatAppearance.BorderColor = Color.FromArgb(75, 72, 214);
            viewButton.FlatStyle = FlatStyle.Flat;
            viewButton.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            viewButton.ForeColor = Color.FromArgb(75, 72, 214);
            viewButton.Location = new Point(538, 58);
            viewButton.Name = "viewButton";
            viewButton.Size = new Size(45, 24);
            viewButton.TabIndex = 10;
            viewButton.Text = "View";
            viewButton.UseVisualStyleBackColor = true;
            viewButton.Click += viewButton_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(534, 42);
            label5.Name = "label5";
            label5.Size = new Size(79, 13);
            label5.TabIndex = 11;
            label5.Text = "osu-server-list";
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label5);
            Controls.Add(viewButton);
            Controls.Add(voteButton);
            Controls.Add(favoriteButton);
            Controls.Add(serverSelectButton);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(pictureBox2);
            Controls.Add(serverUrlLinkLabel);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "Server";
            Size = new Size(714, 85);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private LinkLabel serverUrlLinkLabel;
        private PictureBox pictureBox2;
        private Label label3;
        private Label label4;
        private Button serverSelectButton;
        private Button favoriteButton;
        private Button voteButton;
        private Button viewButton;
        private Label label5;
    }
}
