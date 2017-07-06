namespace Bulls_and_cows.Menus
{
    partial class MainMenu
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
            this.bSettings = new System.Windows.Forms.Button();
            this.bExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bNewGame
            // 
            this.bNewGame.Location = new System.Drawing.Point(125, 90);
            this.bNewGame.Name = "bNewGame";
            this.bNewGame.Size = new System.Drawing.Size(100, 40);
            this.bNewGame.TabIndex = 0;
            this.bNewGame.Text = "Новая игра";
            this.bNewGame.UseVisualStyleBackColor = true;
            this.bNewGame.Click += new System.EventHandler(this.bNewGame_Click);
            // 
            // bSettings
            // 
            this.bSettings.Location = new System.Drawing.Point(125, 160);
            this.bSettings.Name = "bSettings";
            this.bSettings.Size = new System.Drawing.Size(100, 40);
            this.bSettings.TabIndex = 1;
            this.bSettings.Text = "Настройки";
            this.bSettings.UseVisualStyleBackColor = true;
            this.bSettings.Click += new System.EventHandler(this.bSettings_Click);
            // 
            // bExit
            // 
            this.bExit.Location = new System.Drawing.Point(125, 230);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(100, 40);
            this.bExit.TabIndex = 2;
            this.bExit.Text = "Выход";
            this.bExit.UseVisualStyleBackColor = true;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.bSettings);
            this.Controls.Add(this.bNewGame);
            this.Name = "MainMenu";
            this.Size = new System.Drawing.Size(350, 400);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bNewGame;
        private System.Windows.Forms.Button bSettings;
        private System.Windows.Forms.Button bExit;
    }
}
