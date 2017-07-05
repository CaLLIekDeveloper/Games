namespace BackpackTask
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.solveButton = new System.Windows.Forms.Button();
            this.weightTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ShowConditionsButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.завантажитиНабірДаннихToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зберегтиНабірДаннихToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вихідToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.довідкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.інформаціяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.countItems = new System.Windows.Forms.TextBox();
            this.tableOnce = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.answerOnce = new System.Windows.Forms.Label();
            this.listOnce = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button3 = new System.Windows.Forms.Button();
            this.solution1 = new System.Windows.Forms.Button();
            this.lTime = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableOnce)).BeginInit();
            this.SuspendLayout();
            // 
            // solveButton
            // 
            this.solveButton.Location = new System.Drawing.Point(12, 208);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(286, 38);
            this.solveButton.TabIndex = 0;
            this.solveButton.Text = "Динамічнe програмування";
            this.solveButton.UseVisualStyleBackColor = true;
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
            // 
            // weightTextBox
            // 
            this.weightTextBox.Location = new System.Drawing.Point(137, 39);
            this.weightTextBox.Name = "weightTextBox";
            this.weightTextBox.Size = new System.Drawing.Size(45, 24);
            this.weightTextBox.TabIndex = 1;
            this.weightTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.weightTextBox.TextChanged += new System.EventHandler(this.weightTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Вага рюкзака:";
            // 
            // ShowConditionsButton
            // 
            this.ShowConditionsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowConditionsButton.Location = new System.Drawing.Point(319, 23);
            this.ShowConditionsButton.Name = "ShowConditionsButton";
            this.ShowConditionsButton.Size = new System.Drawing.Size(180, 37);
            this.ShowConditionsButton.TabIndex = 4;
            this.ShowConditionsButton.Text = "Показати таблицю";
            this.ShowConditionsButton.UseVisualStyleBackColor = true;
            this.ShowConditionsButton.Click += new System.EventHandler(this.ShowConditionsButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.довідкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(749, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.завантажитиНабірДаннихToolStripMenuItem,
            this.зберегтиНабірДаннихToolStripMenuItem,
            this.вихідToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // завантажитиНабірДаннихToolStripMenuItem
            // 
            this.завантажитиНабірДаннихToolStripMenuItem.Name = "завантажитиНабірДаннихToolStripMenuItem";
            this.завантажитиНабірДаннихToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.завантажитиНабірДаннихToolStripMenuItem.Text = "Завантажити набір данних";
            this.завантажитиНабірДаннихToolStripMenuItem.Click += new System.EventHandler(this.завантажитиНабірДаннихToolStripMenuItem_Click);
            // 
            // зберегтиНабірДаннихToolStripMenuItem
            // 
            this.зберегтиНабірДаннихToolStripMenuItem.Name = "зберегтиНабірДаннихToolStripMenuItem";
            this.зберегтиНабірДаннихToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.зберегтиНабірДаннихToolStripMenuItem.Text = "Зберегти набір данних";
            this.зберегтиНабірДаннихToolStripMenuItem.Click += new System.EventHandler(this.зберегтиНабірДаннихToolStripMenuItem_Click);
            // 
            // вихідToolStripMenuItem
            // 
            this.вихідToolStripMenuItem.Name = "вихідToolStripMenuItem";
            this.вихідToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.вихідToolStripMenuItem.Text = "Вихід";
            // 
            // довідкаToolStripMenuItem
            // 
            this.довідкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.інформаціяToolStripMenuItem});
            this.довідкаToolStripMenuItem.Name = "довідкаToolStripMenuItem";
            this.довідкаToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.довідкаToolStripMenuItem.Text = "Довідка";
            // 
            // інформаціяToolStripMenuItem
            // 
            this.інформаціяToolStripMenuItem.Name = "інформаціяToolStripMenuItem";
            this.інформаціяToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.інформаціяToolStripMenuItem.Text = "Інформація";
            this.інформаціяToolStripMenuItem.Click += new System.EventHandler(this.інформаціяToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Кількість речей:";
            // 
            // countItems
            // 
            this.countItems.Location = new System.Drawing.Point(137, 73);
            this.countItems.Name = "countItems";
            this.countItems.Size = new System.Drawing.Size(45, 24);
            this.countItems.TabIndex = 6;
            this.countItems.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.countItems.TextChanged += new System.EventHandler(this.countItems_TextChanged);
            // 
            // tableOnce
            // 
            this.tableOnce.AllowUserToAddRows = false;
            this.tableOnce.AllowUserToDeleteRows = false;
            this.tableOnce.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.tableOnce.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableOnce.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.tableOnce.Location = new System.Drawing.Point(319, 73);
            this.tableOnce.Name = "tableOnce";
            this.tableOnce.Size = new System.Drawing.Size(393, 279);
            this.tableOnce.TabIndex = 8;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Назва";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Вага";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Вартість";
            this.Column3.Name = "Column3";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Файлы txt|*.txt";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Файлы txt|*.txt";
            // 
            // answerOnce
            // 
            this.answerOnce.AutoSize = true;
            this.answerOnce.Location = new System.Drawing.Point(316, 368);
            this.answerOnce.Name = "answerOnce";
            this.answerOnce.Size = new System.Drawing.Size(0, 18);
            this.answerOnce.TabIndex = 9;
            // 
            // listOnce
            // 
            this.listOnce.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listOnce.Location = new System.Drawing.Point(319, 73);
            this.listOnce.Name = "listOnce";
            this.listOnce.Size = new System.Drawing.Size(393, 279);
            this.listOnce.TabIndex = 14;
            this.listOnce.UseCompatibleStateImageBehavior = false;
            this.listOnce.View = System.Windows.Forms.View.Details;
            this.listOnce.Visible = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Назва";
            this.columnHeader1.Width = 180;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Вага";
            this.columnHeader2.Width = 90;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Вартість";
            this.columnHeader3.Width = 90;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(532, 23);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(180, 37);
            this.button3.TabIndex = 15;
            this.button3.Text = "Заповнити таблицю";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // solution1
            // 
            this.solution1.Location = new System.Drawing.Point(12, 121);
            this.solution1.Name = "solution1";
            this.solution1.Size = new System.Drawing.Size(286, 38);
            this.solution1.TabIndex = 16;
            this.solution1.Text = "Повний перебір";
            this.solution1.UseVisualStyleBackColor = true;
            this.solution1.Click += new System.EventHandler(this.solution1_Click);
            // 
            // lTime
            // 
            this.lTime.AutoSize = true;
            this.lTime.Location = new System.Drawing.Point(316, 398);
            this.lTime.Name = "lTime";
            this.lTime.Size = new System.Drawing.Size(0, 18);
            this.lTime.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(286, 38);
            this.button1.TabIndex = 18;
            this.button1.Text = "Жадібний алгоритм";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 252);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(286, 38);
            this.button2.TabIndex = 19;
            this.button2.Text = "Метод гілок та границь";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 296);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(286, 38);
            this.button4.TabIndex = 20;
            this.button4.Text = "Генетичний алгоритм";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 430);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lTime);
            this.Controls.Add(this.solution1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.listOnce);
            this.Controls.Add(this.answerOnce);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.countItems);
            this.Controls.Add(this.ShowConditionsButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.weightTextBox);
            this.Controls.Add(this.solveButton);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tableOnce);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Задача о рюкзаке";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableOnce)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.TextBox weightTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ShowConditionsButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem завантажитиНабірДаннихToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зберегтиНабірДаннихToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вихідToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem довідкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem інформаціяToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox countItems;
        private System.Windows.Forms.DataGridView tableOnce;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label answerOnce;
        private System.Windows.Forms.ListView listOnce;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button solution1;
        private System.Windows.Forms.Label lTime;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Timer timer1;
    }
}

