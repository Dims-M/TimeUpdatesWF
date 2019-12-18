namespace TimeUpdatesWF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btExit = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBoxAvtoStart = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btRelod = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(382, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(289, 295);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(91, 36);
            this.btExit.TabIndex = 2;
            this.btExit.Text = "Выход";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(16, 295);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(135, 36);
            this.btSave.TabIndex = 3;
            this.btSave.Text = "Сохранить настройки";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.tabPage1.Controls.Add(this.checkBoxAvtoStart);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.numericUpDown1);
            this.tabPage1.Controls.Add(this.btRelod);
            this.tabPage1.Controls.Add(this.btStop);
            this.tabPage1.Controls.Add(this.btStart);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(364, 217);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Автообновление времени";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // checkBoxAvtoStart
            // 
            this.checkBoxAvtoStart.AutoSize = true;
            this.checkBoxAvtoStart.Checked = true;
            this.checkBoxAvtoStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAvtoStart.Location = new System.Drawing.Point(16, 137);
            this.checkBoxAvtoStart.Name = "checkBoxAvtoStart";
            this.checkBoxAvtoStart.Size = new System.Drawing.Size(127, 17);
            this.checkBoxAvtoStart.TabIndex = 6;
            this.checkBoxAvtoStart.Text = "Автозапуск службы";
            this.checkBoxAvtoStart.UseVisualStyleBackColor = true;
            this.checkBoxAvtoStart.CheckedChanged += new System.EventHandler(this.checkBoxAvtoStart_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Время обновления (Мин.)";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(273, 137);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(48, 20);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btRelod
            // 
            this.btRelod.Location = new System.Drawing.Point(250, 62);
            this.btRelod.Name = "btRelod";
            this.btRelod.Size = new System.Drawing.Size(98, 39);
            this.btRelod.TabIndex = 3;
            this.btRelod.Text = "Перезапустить";
            this.btRelod.UseVisualStyleBackColor = true;
            this.btRelod.Click += new System.EventHandler(this.btRelod_Click);
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(135, 62);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(75, 39);
            this.btStop.TabIndex = 2;
            this.btStop.Text = "Остановить";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.button4_Click);
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(16, 62);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 39);
            this.btStart.TabIndex = 1;
            this.btStart.Text = "Запустить";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Синхронизация времени";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(372, 243);
            this.tabControl1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 341);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(398, 380);
            this.MinimumSize = new System.Drawing.Size(398, 380);
            this.Name = "Form1";
            this.Text = "Автообновление времени";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox checkBoxAvtoStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btRelod;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
    }
}

