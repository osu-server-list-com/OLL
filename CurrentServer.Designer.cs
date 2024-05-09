namespace OLL
{
    partial class CurrentServer
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
            serverImage = new PictureBox();
            noserver = new Label();
            serverName = new Label();
            serverOnlineIcon = new PictureBox();
            serverPlayercount = new Label();
            ((System.ComponentModel.ISupportInitialize)serverImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)serverOnlineIcon).BeginInit();
            SuspendLayout();
            // 
            // serverImage
            // 
            serverImage.Location = new Point(3, 3);
            serverImage.Name = "serverImage";
            serverImage.Size = new Size(54, 51);
            serverImage.SizeMode = PictureBoxSizeMode.Zoom;
            serverImage.TabIndex = 0;
            serverImage.TabStop = false;
            // 
            // noserver
            // 
            noserver.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            noserver.AutoSize = true;
            noserver.Location = new Point(88, 19);
            noserver.Name = "noserver";
            noserver.Size = new Size(103, 15);
            noserver.TabIndex = 1;
            noserver.Text = "No server selected";
            // 
            // serverName
            // 
            serverName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            serverName.AutoSize = true;
            serverName.Location = new Point(63, 4);
            serverName.Name = "serverName";
            serverName.Size = new Size(103, 15);
            serverName.TabIndex = 2;
            serverName.Text = "No server selected";
            serverName.Visible = false;
            // 
            // serverOnlineIcon
            // 
            serverOnlineIcon.Image = Properties.Resources.online;
            serverOnlineIcon.Location = new Point(66, 22);
            serverOnlineIcon.Name = "serverOnlineIcon";
            serverOnlineIcon.Size = new Size(14, 14);
            serverOnlineIcon.SizeMode = PictureBoxSizeMode.Zoom;
            serverOnlineIcon.TabIndex = 5;
            serverOnlineIcon.TabStop = false;
            serverOnlineIcon.Visible = false;
            // 
            // serverPlayercount
            // 
            serverPlayercount.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            serverPlayercount.AutoSize = true;
            serverPlayercount.Location = new Point(82, 21);
            serverPlayercount.Name = "serverPlayercount";
            serverPlayercount.Size = new Size(103, 15);
            serverPlayercount.TabIndex = 6;
            serverPlayercount.Text = "No server selected";
            serverPlayercount.Visible = false;
            // 
            // CurrentServer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(serverPlayercount);
            Controls.Add(serverOnlineIcon);
            Controls.Add(serverName);
            Controls.Add(noserver);
            Controls.Add(serverImage);
            Name = "CurrentServer";
            Size = new Size(265, 58);
            ((System.ComponentModel.ISupportInitialize)serverImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)serverOnlineIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox serverImage;
        private Label noserver;
        private Label serverName;
        private PictureBox serverOnlineIcon;
        private Label serverPlayercount;
    }
}
