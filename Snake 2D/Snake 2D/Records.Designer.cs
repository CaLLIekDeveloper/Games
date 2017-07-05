namespace Snake_2D
{
    partial class Records
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Records));
            this.lol = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.tableOnce = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableOnce)).BeginInit();
            this.SuspendLayout();
            // 
            // lol
            // 
            this.lol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lol.Controls.Add(this.button1);
            this.lol.Controls.Add(this.tableOnce);
            this.lol.Controls.Add(this.lblTitle);
            this.lol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lol.Location = new System.Drawing.Point(0, 0);
            this.lol.Name = "lol";
            this.lol.Size = new System.Drawing.Size(604, 601);
            this.lol.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 44);
            this.button1.TabIndex = 2;
            this.button1.Text = "Вернуться в меню";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableOnce
            // 
            this.tableOnce.AllowUserToAddRows = false;
            this.tableOnce.AllowUserToDeleteRows = false;
            this.tableOnce.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.tableOnce.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableOnce.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.tableOnce.Location = new System.Drawing.Point(0, 122);
            this.tableOnce.Name = "tableOnce";
            this.tableOnce.ReadOnly = true;
            this.tableOnce.Size = new System.Drawing.Size(604, 479);
            this.tableOnce.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Lucida Calligraphy", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(183, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(281, 83);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Змейка";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Имя игрока";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Рекорд игрока";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Records
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 601);
            this.Controls.Add(this.lol);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Records";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Рекорды";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Records_FormClosing);
            this.lol.ResumeLayout(false);
            this.lol.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableOnce)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel lol;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView tableOnce;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}