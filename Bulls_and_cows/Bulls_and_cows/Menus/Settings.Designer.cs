namespace Bulls_and_cows.Menus
{
    partial class Settings
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
            this.rHuman = new System.Windows.Forms.RadioButton();
            this.rComputer = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbDifficult = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rHuman
            // 
            this.rHuman.AutoSize = true;
            this.rHuman.Location = new System.Drawing.Point(17, 53);
            this.rHuman.Name = "rHuman";
            this.rHuman.Size = new System.Drawing.Size(149, 17);
            this.rHuman.TabIndex = 1;
            this.rHuman.TabStop = true;
            this.rHuman.Text = "Играть против человека";
            this.rHuman.UseVisualStyleBackColor = true;
            // 
            // rComputer
            // 
            this.rComputer.AutoSize = true;
            this.rComputer.Location = new System.Drawing.Point(18, 19);
            this.rComputer.Name = "rComputer";
            this.rComputer.Size = new System.Drawing.Size(134, 17);
            this.rComputer.TabIndex = 2;
            this.rComputer.TabStop = true;
            this.rComputer.Text = "Играть против компа";
            this.rComputer.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rHuman);
            this.groupBox1.Controls.Add(this.rComputer);
            this.groupBox1.Location = new System.Drawing.Point(68, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // cbDifficult
            // 
            this.cbDifficult.FormattingEnabled = true;
            this.cbDifficult.Items.AddRange(new object[] {
            "Разминка(20)",
            "Ну не очень сложно(15)",
            "Включить мозг(10)",
            "Удачи(5)",
            ""});
            this.cbDifficult.Location = new System.Drawing.Point(17, 53);
            this.cbDifficult.Name = "cbDifficult";
            this.cbDifficult.Size = new System.Drawing.Size(161, 21);
            this.cbDifficult.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Сложность (Количесвто ходов)";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbDifficult);
            this.panel1.Location = new System.Drawing.Point(68, 136);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 86);
            this.panel1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(68, 338);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(172, 338);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(350, 400);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rHuman;
        private System.Windows.Forms.RadioButton rComputer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbDifficult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
