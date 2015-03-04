namespace Snakiris
{
    partial class LauncherForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelName = new System.Windows.Forms.Label();
            this.labelIPServer = new System.Windows.Forms.Label();
            this.buttonFindServer = new System.Windows.Forms.Button();
            this.buttonJoin = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxIPServer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(13, 13);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(43, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Pseudo";
            // 
            // labelIPServer
            // 
            this.labelIPServer.AutoSize = true;
            this.labelIPServer.Location = new System.Drawing.Point(13, 44);
            this.labelIPServer.Name = "labelIPServer";
            this.labelIPServer.Size = new System.Drawing.Size(98, 13);
            this.labelIPServer.TabIndex = 1;
            this.labelIPServer.Text = "Adresse du serveur";
            // 
            // buttonFindServer
            // 
            this.buttonFindServer.Location = new System.Drawing.Point(144, 72);
            this.buttonFindServer.Name = "buttonFindServer";
            this.buttonFindServer.Size = new System.Drawing.Size(75, 37);
            this.buttonFindServer.TabIndex = 2;
            this.buttonFindServer.Text = "Trouver un serveur";
            this.buttonFindServer.UseVisualStyleBackColor = true;
            this.buttonFindServer.Click += new System.EventHandler(this.buttonFindServer_Click);
            // 
            // buttonJoin
            // 
            this.buttonJoin.Location = new System.Drawing.Point(34, 73);
            this.buttonJoin.Name = "buttonJoin";
            this.buttonJoin.Size = new System.Drawing.Size(77, 36);
            this.buttonJoin.TabIndex = 3;
            this.buttonJoin.Text = "Rejoindre la partie";
            this.buttonJoin.UseVisualStyleBackColor = true;
            this.buttonJoin.Click += new System.EventHandler(this.buttonJoin_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(131, 12);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 20);
            this.textBoxName.TabIndex = 4;
            // 
            // textBoxIPServer
            // 
            this.textBoxIPServer.Location = new System.Drawing.Point(131, 37);
            this.textBoxIPServer.Name = "textBoxIPServer";
            this.textBoxIPServer.Size = new System.Drawing.Size(100, 20);
            this.textBoxIPServer.TabIndex = 5;
            this.textBoxIPServer.Text = "localhost";
            // 
            // LauncherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 126);
            this.Controls.Add(this.textBoxIPServer);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonJoin);
            this.Controls.Add(this.buttonFindServer);
            this.Controls.Add(this.labelIPServer);
            this.Controls.Add(this.labelName);
            this.Name = "LauncherForm";
            this.Text = "Snakiris - Launcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelIPServer;
        private System.Windows.Forms.Button buttonFindServer;
        private System.Windows.Forms.Button buttonJoin;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxIPServer;
    }
}

