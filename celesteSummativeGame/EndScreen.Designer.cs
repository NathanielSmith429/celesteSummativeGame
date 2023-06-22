namespace celesteSummativeGame
{
    partial class EndScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gameoverLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.outputLabel = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.errorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameoverLabel
            // 
            this.gameoverLabel.AutoSize = true;
            this.gameoverLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameoverLabel.Font = new System.Drawing.Font("Century Gothic", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameoverLabel.ForeColor = System.Drawing.Color.SkyBlue;
            this.gameoverLabel.Location = new System.Drawing.Point(359, 77);
            this.gameoverLabel.Name = "gameoverLabel";
            this.gameoverLabel.Size = new System.Drawing.Size(616, 112);
            this.gameoverLabel.TabIndex = 0;
            this.gameoverLabel.Text = "GAME OVER";
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Silver;
            this.exitButton.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(585, 923);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(198, 65);
            this.exitButton.TabIndex = 7;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.BackColor = System.Drawing.Color.Silver;
            this.quitButton.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitButton.Location = new System.Drawing.Point(585, 1011);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(198, 65);
            this.quitButton.TabIndex = 8;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = false;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.BackColor = System.Drawing.Color.Transparent;
            this.outputLabel.Font = new System.Drawing.Font("Century Gothic", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputLabel.ForeColor = System.Drawing.Color.SkyBlue;
            this.outputLabel.Location = new System.Drawing.Point(344, 819);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(288, 49);
            this.outputLabel.TabIndex = 9;
            this.outputLabel.Text = "GAME OVER!";
            this.outputLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameBox
            // 
            this.nameBox.Font = new System.Drawing.Font("Century Gothic", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameBox.Location = new System.Drawing.Point(754, 808);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(142, 60);
            this.nameBox.TabIndex = 10;
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.BackColor = System.Drawing.Color.Transparent;
            this.errorLabel.Font = new System.Drawing.Font("Century Gothic", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(485, 1152);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 49);
            this.errorLabel.TabIndex = 11;
            this.errorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EndScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::celesteSummativeGame.Properties.Resources.endBackground;
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.gameoverLabel);
            this.Name = "EndScreen";
            this.Size = new System.Drawing.Size(1400, 1400);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label gameoverLabel;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label errorLabel;
    }
}
