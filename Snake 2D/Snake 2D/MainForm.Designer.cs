namespace Snake_2D
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainCanvas = new System.Windows.Forms.Panel();
            this.MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.sghToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tName = new System.Windows.Forms.TextBox();
            this.lblGO = new System.Windows.Forms.Label();
            this.lblGOScoreCount = new System.Windows.Forms.Label();
            this.lblGameOverScore = new System.Windows.Forms.Label();
            this.lblScoreCount = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblEnter = new System.Windows.Forms.Label();
            this.timerMove = new System.Windows.Forms.Timer(this.components);
            this.MainCanvas.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainCanvas
            // 
            this.MainCanvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.MainCanvas.ContextMenuStrip = this.MenuStrip;
            this.MainCanvas.Controls.Add(this.label1);
            this.MainCanvas.Controls.Add(this.button1);
            this.MainCanvas.Controls.Add(this.tName);
            this.MainCanvas.Controls.Add(this.lblGO);
            this.MainCanvas.Controls.Add(this.lblGOScoreCount);
            this.MainCanvas.Controls.Add(this.lblGameOverScore);
            this.MainCanvas.Controls.Add(this.lblScoreCount);
            this.MainCanvas.Controls.Add(this.lblScore);
            this.MainCanvas.Controls.Add(this.lblTitle);
            this.MainCanvas.Controls.Add(this.lblEnter);
            this.MainCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainCanvas.Location = new System.Drawing.Point(0, 0);
            this.MainCanvas.Name = "MainCanvas";
            this.MainCanvas.Size = new System.Drawing.Size(604, 601);
            this.MainCanvas.TabIndex = 0;
            this.MainCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.MainCanvas_Paint);
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.resumeToolStripMenuItem,
            this.gToolStripMenuItem,
            this.sghToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.MenuStrip.Name = "contextMenuStrip1";
            this.MenuStrip.Size = new System.Drawing.Size(172, 82);
            this.MenuStrip.Opened += new System.EventHandler(this.MenuStrip_Opened);
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.newGameToolStripMenuItem.Text = "Нова гра";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // resumeToolStripMenuItem
            // 
            this.resumeToolStripMenuItem.Name = "resumeToolStripMenuItem";
            this.resumeToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.resumeToolStripMenuItem.Text = "Продовжити    (P)";
            this.resumeToolStripMenuItem.Click += new System.EventHandler(this.resumeToolStripMenuItem_Click);
            // 
            // gToolStripMenuItem
            // 
            this.gToolStripMenuItem.Name = "gToolStripMenuItem";
            this.gToolStripMenuItem.Size = new System.Drawing.Size(168, 6);
            // 
            // sghToolStripMenuItem
            // 
            this.sghToolStripMenuItem.Name = "sghToolStripMenuItem";
            this.sghToolStripMenuItem.Size = new System.Drawing.Size(168, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.exitToolStripMenuItem.Text = "Вихід";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 479);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Введите ваше имя";
            this.label1.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(372, 473);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Ок";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tName
            // 
            this.tName.HideSelection = false;
            this.tName.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tName.Location = new System.Drawing.Point(235, 476);
            this.tName.Name = "tName";
            this.tName.Size = new System.Drawing.Size(117, 20);
            this.tName.TabIndex = 11;
            this.tName.Visible = false;
            // 
            // lblGO
            // 
            this.lblGO.AutoSize = true;
            this.lblGO.BackColor = System.Drawing.Color.Transparent;
            this.lblGO.Font = new System.Drawing.Font("Lucida Calligraphy", 40F, System.Drawing.FontStyle.Bold);
            this.lblGO.ForeColor = System.Drawing.Color.Black;
            this.lblGO.Location = new System.Drawing.Point(105, 200);
            this.lblGO.Name = "lblGO";
            this.lblGO.Size = new System.Drawing.Size(428, 70);
            this.lblGO.TabIndex = 6;
            this.lblGO.Text = "Игра окончена";
            this.lblGO.Visible = false;
            // 
            // lblGOScoreCount
            // 
            this.lblGOScoreCount.AutoSize = true;
            this.lblGOScoreCount.BackColor = System.Drawing.Color.Transparent;
            this.lblGOScoreCount.Font = new System.Drawing.Font("Minion Pro", 20.25F, System.Drawing.FontStyle.Italic);
            this.lblGOScoreCount.Location = new System.Drawing.Point(365, 307);
            this.lblGOScoreCount.Name = "lblGOScoreCount";
            this.lblGOScoreCount.Size = new System.Drawing.Size(30, 37);
            this.lblGOScoreCount.TabIndex = 5;
            this.lblGOScoreCount.Text = "0";
            this.lblGOScoreCount.Visible = false;
            // 
            // lblGameOverScore
            // 
            this.lblGameOverScore.AutoSize = true;
            this.lblGameOverScore.BackColor = System.Drawing.Color.Transparent;
            this.lblGameOverScore.Font = new System.Drawing.Font("Minion Pro", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameOverScore.Location = new System.Drawing.Point(203, 307);
            this.lblGameOverScore.Name = "lblGameOverScore";
            this.lblGameOverScore.Size = new System.Drawing.Size(135, 37);
            this.lblGameOverScore.TabIndex = 4;
            this.lblGameOverScore.Tag = "";
            this.lblGameOverScore.Text = "Ваш счет:";
            this.lblGameOverScore.Visible = false;
            // 
            // lblScoreCount
            // 
            this.lblScoreCount.AutoSize = true;
            this.lblScoreCount.BackColor = System.Drawing.Color.Transparent;
            this.lblScoreCount.Enabled = false;
            this.lblScoreCount.Font = new System.Drawing.Font("Lucida Calligraphy", 13F, System.Drawing.FontStyle.Bold);
            this.lblScoreCount.Location = new System.Drawing.Point(71, 9);
            this.lblScoreCount.Name = "lblScoreCount";
            this.lblScoreCount.Size = new System.Drawing.Size(23, 23);
            this.lblScoreCount.TabIndex = 3;
            this.lblScoreCount.Text = "0";
            this.lblScoreCount.Visible = false;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.Enabled = false;
            this.lblScore.Font = new System.Drawing.Font("Lucida Calligraphy", 13F, System.Drawing.FontStyle.Bold);
            this.lblScore.Location = new System.Drawing.Point(4, 9);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(61, 23);
            this.lblScore.TabIndex = 3;
            this.lblScore.Text = "Счет:";
            this.lblScore.Visible = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Lucida Calligraphy", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(179, 187);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(257, 83);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Змійка";
            // 
            // lblEnter
            // 
            this.lblEnter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEnter.AutoSize = true;
            this.lblEnter.BackColor = System.Drawing.Color.Transparent;
            this.lblEnter.Font = new System.Drawing.Font("Minion Pro", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblEnter.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEnter.Location = new System.Drawing.Point(55, 268);
            this.lblEnter.Name = "lblEnter";
            this.lblEnter.Size = new System.Drawing.Size(501, 39);
            this.lblEnter.TabIndex = 1;
            this.lblEnter.Text = "Нажмите Enter для начала новый игры";
            this.lblEnter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // timerMove
            // 
            this.timerMove.Interval = 200;
            this.timerMove.Tick += new System.EventHandler(this.timerMove_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(604, 601);
            this.Controls.Add(this.MainCanvas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Змейка";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.MainCanvas.ResumeLayout(false);
            this.MainCanvas.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainCanvas;
        private System.Windows.Forms.ContextMenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resumeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator gToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator sghToolStripMenuItem;
        private System.Windows.Forms.Label lblEnter;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Timer timerMove;
        private System.Windows.Forms.Label lblGOScoreCount;
        private System.Windows.Forms.Label lblGameOverScore;
        private System.Windows.Forms.Label lblScoreCount;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblGO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tName;
    }
}

