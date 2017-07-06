namespace Bulls_and_cows
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lRand = new System.Windows.Forms.Label();
            this.b1 = new System.Windows.Forms.Button();
            this.b2 = new System.Windows.Forms.Button();
            this.b3 = new System.Windows.Forms.Button();
            this.b4 = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.Score = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.newGame = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lRand
            // 
            this.lRand.AutoSize = true;
            this.lRand.Location = new System.Drawing.Point(137, 30);
            this.lRand.Name = "lRand";
            this.lRand.Size = new System.Drawing.Size(0, 13);
            this.lRand.TabIndex = 0;
            // 
            // b1
            // 
            this.b1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b1.Location = new System.Drawing.Point(12, 76);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(66, 75);
            this.b1.TabIndex = 1;
            this.b1.Text = "1";
            this.b1.UseVisualStyleBackColor = true;
            this.b1.Click += new System.EventHandler(this.ButtonClick);
            // 
            // b2
            // 
            this.b2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b2.Location = new System.Drawing.Point(84, 76);
            this.b2.Name = "b2";
            this.b2.Size = new System.Drawing.Size(66, 75);
            this.b2.TabIndex = 2;
            this.b2.Text = "0";
            this.b2.UseVisualStyleBackColor = true;
            this.b2.Click += new System.EventHandler(this.ButtonClick);
            // 
            // b3
            // 
            this.b3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b3.Location = new System.Drawing.Point(156, 76);
            this.b3.Name = "b3";
            this.b3.Size = new System.Drawing.Size(66, 75);
            this.b3.TabIndex = 3;
            this.b3.Text = "0";
            this.b3.UseVisualStyleBackColor = true;
            this.b3.Click += new System.EventHandler(this.ButtonClick);
            // 
            // b4
            // 
            this.b4.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b4.Location = new System.Drawing.Point(228, 76);
            this.b4.Name = "b4";
            this.b4.Size = new System.Drawing.Size(66, 75);
            this.b4.TabIndex = 4;
            this.b4.Text = "0";
            this.b4.UseVisualStyleBackColor = true;
            this.b4.Click += new System.EventHandler(this.ButtonClick);
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(94, 176);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(105, 23);
            this.ok.TabIndex = 5;
            this.ok.Text = "Готово";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // Score
            // 
            this.Score.AutoSize = true;
            this.Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Score.Location = new System.Drawing.Point(139, 257);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(45, 25);
            this.Score.TabIndex = 8;
            this.Score.Text = "0:0";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Bulls_and_cows.Properties.Resources.byk;
            this.pictureBox2.Location = new System.Drawing.Point(186, 205);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(120, 131);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Bulls_and_cows.Properties.Resources.Корова;
            this.pictureBox1.Location = new System.Drawing.Point(4, 205);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 131);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // newGame
            // 
            this.newGame.Location = new System.Drawing.Point(109, 30);
            this.newGame.Name = "newGame";
            this.newGame.Size = new System.Drawing.Size(90, 29);
            this.newGame.TabIndex = 9;
            this.newGame.Text = "Новая игра";
            this.newGame.UseVisualStyleBackColor = true;
            this.newGame.Click += new System.EventHandler(this.newGame_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 352);
            this.Controls.Add(this.newGame);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.b4);
            this.Controls.Add(this.b3);
            this.Controls.Add(this.b2);
            this.Controls.Add(this.b1);
            this.Controls.Add(this.lRand);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bulls and Cows";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lRand;
        private System.Windows.Forms.Button b1;
        private System.Windows.Forms.Button b2;
        private System.Windows.Forms.Button b3;
        private System.Windows.Forms.Button b4;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label Score;
        private System.Windows.Forms.Button newGame;
    }
}

