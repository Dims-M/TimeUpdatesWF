namespace TimeUpdatesWF.Forms
{
    partial class PoinWiFISetings
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
            this.buttonExit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.lMessageFormSetting = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelNamePoinWiFi = new System.Windows.Forms.Label();
            this.labellabelPasswordPoinWiFi = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(350, 280);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(107, 66);
            this.buttonExit.TabIndex = 0;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 285);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 57);
            this.button1.TabIndex = 1;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Настройки точки доступа Wi-Fi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "для Windows 8";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(94, 200);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(302, 40);
            this.button2.TabIndex = 4;
            this.button2.Text = "Создать точку доступа Wi-Fi";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // lMessageFormSetting
            // 
            this.lMessageFormSetting.AutoSize = true;
            this.lMessageFormSetting.Location = new System.Drawing.Point(23, 73);
            this.lMessageFormSetting.Name = "lMessageFormSetting";
            this.lMessageFormSetting.Size = new System.Drawing.Size(65, 13);
            this.lMessageFormSetting.TabIndex = 5;
            this.lMessageFormSetting.Text = "Сообщение";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Имя точки:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Пароль точки:";
            // 
            // labelNamePoinWiFi
            // 
            this.labelNamePoinWiFi.AutoSize = true;
            this.labelNamePoinWiFi.Location = new System.Drawing.Point(130, 111);
            this.labelNamePoinWiFi.Name = "labelNamePoinWiFi";
            this.labelNamePoinWiFi.Size = new System.Drawing.Size(35, 13);
            this.labelNamePoinWiFi.TabIndex = 8;
            this.labelNamePoinWiFi.Text = "label5";
            // 
            // labellabelPasswordPoinWiFi
            // 
            this.labellabelPasswordPoinWiFi.AutoSize = true;
            this.labellabelPasswordPoinWiFi.Location = new System.Drawing.Point(133, 144);
            this.labellabelPasswordPoinWiFi.Name = "labellabelPasswordPoinWiFi";
            this.labellabelPasswordPoinWiFi.Size = new System.Drawing.Size(35, 13);
            this.labellabelPasswordPoinWiFi.TabIndex = 9;
            this.labellabelPasswordPoinWiFi.Text = "label5";
            // 
            // PoinWiFISetings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 358);
            this.Controls.Add(this.labellabelPasswordPoinWiFi);
            this.Controls.Add(this.labelNamePoinWiFi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lMessageFormSetting);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonExit);
            this.Name = "PoinWiFISetings";
            this.Text = "PoinWiFISetings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lMessageFormSetting;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelNamePoinWiFi;
        private System.Windows.Forms.Label labellabelPasswordPoinWiFi;
    }
}