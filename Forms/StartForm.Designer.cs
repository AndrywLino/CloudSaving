namespace CloudSaving.Forms
{
    partial class StartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.label1 = new System.Windows.Forms.Label();
            this.btnSyncSaves = new System.Windows.Forms.Button();
            this.btnRemoveSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.LblGames = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(245, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 105);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // btnSyncSaves
            // 
            this.btnSyncSaves.Location = new System.Drawing.Point(245, 133);
            this.btnSyncSaves.Name = "btnSyncSaves";
            this.btnSyncSaves.Size = new System.Drawing.Size(136, 44);
            this.btnSyncSaves.TabIndex = 4;
            this.btnSyncSaves.Text = "Sincronizar saves";
            this.btnSyncSaves.UseVisualStyleBackColor = true;
            this.btnSyncSaves.Click += new System.EventHandler(this.SyncSaves_Click);
            // 
            // btnRemoveSave
            // 
            this.btnRemoveSave.Location = new System.Drawing.Point(414, 133);
            this.btnRemoveSave.Name = "btnRemoveSave";
            this.btnRemoveSave.Size = new System.Drawing.Size(136, 44);
            this.btnRemoveSave.TabIndex = 2;
            this.btnRemoveSave.Text = "Remover save da nuvem";
            this.btnRemoveSave.UseVisualStyleBackColor = true;
            this.btnRemoveSave.Click += new System.EventHandler(this.btnRemoveSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pastas em nuvem";
            // 
            // LblGames
            // 
            this.LblGames.AutoSize = true;
            this.LblGames.Location = new System.Drawing.Point(12, 24);
            this.LblGames.Name = "LblGames";
            this.LblGames.Size = new System.Drawing.Size(85, 60);
            this.LblGames.TabIndex = 1;
            this.LblGames.Text = "-> Elden Ring\r\n-> God Of War\r\n-> Pokemon\r\n-> Zelda";
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 298);
            this.Controls.Add(this.LblGames);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRemoveSave);
            this.Controls.Add(this.btnSyncSaves);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CloudSaving";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StartForm_FormClosed);
            this.Load += new System.EventHandler(this.StartForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button btnSyncSaves;
        private Button btnRemoveSave;
        private Label label2;
        private Label LblGames;
    }
}