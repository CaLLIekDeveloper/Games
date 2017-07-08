namespace Bulls_and_cows.Menus
{
    partial class GameMenu
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.bNewGame = new System.Windows.Forms.Button();
            this.Score = new System.Windows.Forms.Label();
            this.b4 = new System.Windows.Forms.Button();
            this.b3 = new System.Windows.Forms.Button();
            this.b2 = new System.Windows.Forms.Button();
            this.b1 = new System.Windows.Forms.Button();
            this.lRand = new System.Windows.Forms.Label();
            this.bOk = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Info = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // bNewGame
            // 
            this.bNewGame.Location = new System.Drawing.Point(120, 162);
            this.bNewGame.Name = "bNewGame";
            this.bNewGame.Size = new System.Drawing.Size(90, 29);
            this.bNewGame.TabIndex = 19;
            this.bNewGame.Text = "Новая игра";
            this.bNewGame.UseVisualStyleBackColor = true;
            this.bNewGame.Click += new System.EventHandler(this.bNewGame_Click);
            // 
            // Score
            // 
            this.Score.AutoSize = true;
            this.Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Score.Location = new System.Drawing.Point(156, 292);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(45, 25);
            this.Score.TabIndex = 18;
            this.Score.Text = "0:0";
            // 
            // b4
            // 
            this.b4.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b4.Location = new System.Drawing.Point(249, 28);
            this.b4.Name = "b4";
            this.b4.Size = new System.Drawing.Size(66, 75);
            this.b4.TabIndex = 14;
            this.b4.Text = "0";
            this.b4.UseVisualStyleBackColor = true;
            this.b4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b4_MouseDown);
            // 
            // b3
            // 
            this.b3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b3.Location = new System.Drawing.Point(177, 28);
            this.b3.Name = "b3";
            this.b3.Size = new System.Drawing.Size(66, 75);
            this.b3.TabIndex = 13;
            this.b3.Text = "0";
            this.b3.UseVisualStyleBackColor = true;
            this.b3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b4_MouseDown);
            // 
            // b2
            // 
            this.b2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b2.Location = new System.Drawing.Point(105, 28);
            this.b2.Name = "b2";
            this.b2.Size = new System.Drawing.Size(66, 75);
            this.b2.TabIndex = 12;
            this.b2.Text = "0";
            this.b2.UseVisualStyleBackColor = true;
            this.b2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b4_MouseDown);
            // 
            // b1
            // 
            this.b1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b1.Location = new System.Drawing.Point(33, 28);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(66, 75);
            this.b1.TabIndex = 11;
            this.b1.Text = "1";
            this.b1.UseVisualStyleBackColor = true;
            this.b1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b4_MouseDown);
            // 
            // lRand
            // 
            this.lRand.AutoSize = true;
            this.lRand.Location = new System.Drawing.Point(180, 48);
            this.lRand.Name = "lRand";
            this.lRand.Size = new System.Drawing.Size(0, 13);
            this.lRand.TabIndex = 10;
            // 
            // bOk
            // 
            this.bOk.Location = new System.Drawing.Point(120, 162);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(90, 29);
            this.bOk.TabIndex = 20;
            this.bOk.Text = "Готово";
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.bOk_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Bulls_and_cows.Properties.Resources.Корова;
            this.pictureBox1.Location = new System.Drawing.Point(10, 238);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(140, 140);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Bulls_and_cows.Properties.Resources.byk;
            this.pictureBox2.Location = new System.Drawing.Point(207, 238);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(140, 140);
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // Info
            // 
            this.Info.AutoSize = true;
            this.Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Info.Location = new System.Drawing.Point(36, 134);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(0, 16);
            this.Info.TabIndex = 21;
            // 
            // GameMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Info);
            this.Controls.Add(this.bNewGame);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.b4);
            this.Controls.Add(this.b3);
            this.Controls.Add(this.b2);
            this.Controls.Add(this.b1);
            this.Controls.Add(this.lRand);
            this.Controls.Add(this.bOk);
            this.Name = "GameMenu";
            this.Size = new System.Drawing.Size(350, 400);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bNewGame;
        private System.Windows.Forms.Label Score;
        private System.Windows.Forms.Button b4;
        private System.Windows.Forms.Button b3;
        private System.Windows.Forms.Button b2;
        private System.Windows.Forms.Button b1;
        private System.Windows.Forms.Label lRand;
        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label Info;
    }
}
