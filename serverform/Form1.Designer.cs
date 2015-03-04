namespace Snakiris
{
    partial class ServerForm
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
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelPlayerCount = new System.Windows.Forms.Label();
            this.labelBotCount = new System.Windows.Forms.Label();
            this.labelFruitCount = new System.Windows.Forms.Label();
            this.labelMaps = new System.Windows.Forms.Label();
            this.numericUpDownPlayerCount = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBotCount = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownFruitCount = new System.Windows.Forms.NumericUpDown();
            this.comboBoxMaps = new System.Windows.Forms.ComboBox();
            this.labelInitialSize = new System.Windows.Forms.Label();
            this.numericUpDownInitialSize = new System.Windows.Forms.NumericUpDown();
            this.buttonStartServer = new System.Windows.Forms.Button();
            this.buttonStopServer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlayerCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBotCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFruitCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInitialSize)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(114, 8);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(120, 20);
            this.textBoxName.TabIndex = 0;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 11);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(43, 13);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Pseudo";
            // 
            // labelPlayerCount
            // 
            this.labelPlayerCount.AutoSize = true;
            this.labelPlayerCount.Location = new System.Drawing.Point(12, 36);
            this.labelPlayerCount.Name = "labelPlayerCount";
            this.labelPlayerCount.Size = new System.Drawing.Size(96, 13);
            this.labelPlayerCount.TabIndex = 2;
            this.labelPlayerCount.Text = "Nombre de joueurs\r\n";
            // 
            // labelBotCount
            // 
            this.labelBotCount.AutoSize = true;
            this.labelBotCount.Location = new System.Drawing.Point(12, 62);
            this.labelBotCount.Name = "labelBotCount";
            this.labelBotCount.Size = new System.Drawing.Size(82, 13);
            this.labelBotCount.TabIndex = 3;
            this.labelBotCount.Text = "Nombre de bots";
            // 
            // labelFruitCount
            // 
            this.labelFruitCount.AutoSize = true;
            this.labelFruitCount.Location = new System.Drawing.Point(12, 88);
            this.labelFruitCount.Name = "labelFruitCount";
            this.labelFruitCount.Size = new System.Drawing.Size(84, 13);
            this.labelFruitCount.TabIndex = 4;
            this.labelFruitCount.Text = "Nombre de fruits";
            // 
            // labelMaps
            // 
            this.labelMaps.AutoSize = true;
            this.labelMaps.Location = new System.Drawing.Point(12, 141);
            this.labelMaps.Name = "labelMaps";
            this.labelMaps.Size = new System.Drawing.Size(33, 13);
            this.labelMaps.TabIndex = 5;
            this.labelMaps.Text = "Maps";
            // 
            // numericUpDownPlayerCount
            // 
            this.numericUpDownPlayerCount.Location = new System.Drawing.Point(114, 34);
            this.numericUpDownPlayerCount.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownPlayerCount.Name = "numericUpDownPlayerCount";
            this.numericUpDownPlayerCount.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownPlayerCount.TabIndex = 6;
            this.numericUpDownPlayerCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownBotCount
            // 
            this.numericUpDownBotCount.Location = new System.Drawing.Point(114, 60);
            this.numericUpDownBotCount.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownBotCount.Name = "numericUpDownBotCount";
            this.numericUpDownBotCount.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownBotCount.TabIndex = 7;
            // 
            // numericUpDownFruitCount
            // 
            this.numericUpDownFruitCount.Location = new System.Drawing.Point(114, 86);
            this.numericUpDownFruitCount.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownFruitCount.Name = "numericUpDownFruitCount";
            this.numericUpDownFruitCount.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownFruitCount.TabIndex = 8;
            this.numericUpDownFruitCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // comboBoxMaps
            // 
            this.comboBoxMaps.FormattingEnabled = true;
            this.comboBoxMaps.Location = new System.Drawing.Point(113, 138);
            this.comboBoxMaps.Name = "comboBoxMaps";
            this.comboBoxMaps.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMaps.TabIndex = 9;
            // 
            // labelInitialSize
            // 
            this.labelInitialSize.AutoSize = true;
            this.labelInitialSize.Location = new System.Drawing.Point(12, 114);
            this.labelInitialSize.Name = "labelInitialSize";
            this.labelInitialSize.Size = new System.Drawing.Size(64, 13);
            this.labelInitialSize.TabIndex = 10;
            this.labelInitialSize.Text = "Taille initiale";
            // 
            // numericUpDownInitialSize
            // 
            this.numericUpDownInitialSize.Location = new System.Drawing.Point(114, 112);
            this.numericUpDownInitialSize.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownInitialSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownInitialSize.Name = "numericUpDownInitialSize";
            this.numericUpDownInitialSize.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownInitialSize.TabIndex = 11;
            this.numericUpDownInitialSize.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // buttonStartServer
            // 
            this.buttonStartServer.Location = new System.Drawing.Point(136, 165);
            this.buttonStartServer.Name = "buttonStartServer";
            this.buttonStartServer.Size = new System.Drawing.Size(98, 44);
            this.buttonStartServer.TabIndex = 12;
            this.buttonStartServer.Text = "Lancer le serveur";
            this.buttonStartServer.UseVisualStyleBackColor = true;
            this.buttonStartServer.Click += new System.EventHandler(this.buttonStartServer_Click);
            // 
            // buttonStopServer
            // 
            this.buttonStopServer.Enabled = false;
            this.buttonStopServer.Location = new System.Drawing.Point(15, 165);
            this.buttonStopServer.Name = "buttonStopServer";
            this.buttonStopServer.Size = new System.Drawing.Size(98, 44);
            this.buttonStopServer.TabIndex = 13;
            this.buttonStopServer.Text = "Arreter le serveur";
            this.buttonStopServer.UseVisualStyleBackColor = true;
            this.buttonStopServer.Click += new System.EventHandler(this.buttonStopServer_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 219);
            this.Controls.Add(this.buttonStopServer);
            this.Controls.Add(this.buttonStartServer);
            this.Controls.Add(this.numericUpDownInitialSize);
            this.Controls.Add(this.labelInitialSize);
            this.Controls.Add(this.comboBoxMaps);
            this.Controls.Add(this.numericUpDownFruitCount);
            this.Controls.Add(this.numericUpDownBotCount);
            this.Controls.Add(this.numericUpDownPlayerCount);
            this.Controls.Add(this.labelMaps);
            this.Controls.Add(this.labelFruitCount);
            this.Controls.Add(this.labelBotCount);
            this.Controls.Add(this.labelPlayerCount);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxName);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(260, 257);
            this.MinimumSize = new System.Drawing.Size(260, 257);
            this.Name = "ServerForm";
            this.Text = "Snakiris - Serveur";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlayerCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBotCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFruitCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInitialSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelPlayerCount;
        private System.Windows.Forms.Label labelBotCount;
        private System.Windows.Forms.Label labelFruitCount;
        private System.Windows.Forms.Label labelMaps;
        private System.Windows.Forms.NumericUpDown numericUpDownPlayerCount;
        private System.Windows.Forms.NumericUpDown numericUpDownBotCount;
        private System.Windows.Forms.NumericUpDown numericUpDownFruitCount;
        private System.Windows.Forms.ComboBox comboBoxMaps;
        private System.Windows.Forms.Label labelInitialSize;
        private System.Windows.Forms.NumericUpDown numericUpDownInitialSize;
        private System.Windows.Forms.Button buttonStartServer;
        private System.Windows.Forms.Button buttonStopServer;


    }
}

