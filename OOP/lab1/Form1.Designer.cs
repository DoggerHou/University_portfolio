
namespace OOP_Laba_1
{
    partial class Form_MainForm
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
            this.label_Chose = new System.Windows.Forms.Label();
            this.button_Form_Button_1 = new System.Windows.Forms.Button();
            this.button_Form_Button_2 = new System.Windows.Forms.Button();
            this.button_Form_Button_3 = new System.Windows.Forms.Button();
            this.button_Form_Button_4 = new System.Windows.Forms.Button();
            this.button_Form_Button_5 = new System.Windows.Forms.Button();
            this.pictureBox_BlackMetal = new System.Windows.Forms.PictureBox();
            this.label_MouseX = new System.Windows.Forms.Label();
            this.label_MouseY = new System.Windows.Forms.Label();
            this.pictureBox_Stalin = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_BlackMetal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Stalin)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Chose
            // 
            this.label_Chose.AutoSize = true;
            this.label_Chose.Font = new System.Drawing.Font("Arial Black", 14.15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Chose.Location = new System.Drawing.Point(348, 20);
            this.label_Chose.Name = "label_Chose";
            this.label_Chose.Size = new System.Drawing.Size(426, 33);
            this.label_Chose.TabIndex = 0;
            this.label_Chose.Text = "Нажмите на кнопку из списка";
            // 
            // button_Form_Button_1
            // 
            this.button_Form_Button_1.Location = new System.Drawing.Point(511, 110);
            this.button_Form_Button_1.Name = "button_Form_Button_1";
            this.button_Form_Button_1.Size = new System.Drawing.Size(112, 48);
            this.button_Form_Button_1.TabIndex = 1;
            this.button_Form_Button_1.Text = "Страница 1";
            this.button_Form_Button_1.UseVisualStyleBackColor = true;
            this.button_Form_Button_1.Click += new System.EventHandler(this.button_Form_Button_1_Click);
            // 
            // button_Form_Button_2
            // 
            this.button_Form_Button_2.Location = new System.Drawing.Point(511, 200);
            this.button_Form_Button_2.Name = "button_Form_Button_2";
            this.button_Form_Button_2.Size = new System.Drawing.Size(112, 48);
            this.button_Form_Button_2.TabIndex = 2;
            this.button_Form_Button_2.Text = "Страница 2";
            this.button_Form_Button_2.UseVisualStyleBackColor = true;
            this.button_Form_Button_2.Click += new System.EventHandler(this.button_Form_Button_2_Click);
            // 
            // button_Form_Button_3
            // 
            this.button_Form_Button_3.Location = new System.Drawing.Point(511, 290);
            this.button_Form_Button_3.Name = "button_Form_Button_3";
            this.button_Form_Button_3.Size = new System.Drawing.Size(112, 48);
            this.button_Form_Button_3.TabIndex = 3;
            this.button_Form_Button_3.Text = "Страница 3";
            this.button_Form_Button_3.UseVisualStyleBackColor = true;
            this.button_Form_Button_3.Click += new System.EventHandler(this.button_Form_Button_3_Click);
            // 
            // button_Form_Button_4
            // 
            this.button_Form_Button_4.Location = new System.Drawing.Point(511, 380);
            this.button_Form_Button_4.Name = "button_Form_Button_4";
            this.button_Form_Button_4.Size = new System.Drawing.Size(112, 48);
            this.button_Form_Button_4.TabIndex = 4;
            this.button_Form_Button_4.Text = "Страница 4";
            this.button_Form_Button_4.UseVisualStyleBackColor = true;
            this.button_Form_Button_4.Click += new System.EventHandler(this.button_Form_Button_4_Click);
            // 
            // button_Form_Button_5
            // 
            this.button_Form_Button_5.Location = new System.Drawing.Point(511, 470);
            this.button_Form_Button_5.Name = "button_Form_Button_5";
            this.button_Form_Button_5.Size = new System.Drawing.Size(112, 48);
            this.button_Form_Button_5.TabIndex = 5;
            this.button_Form_Button_5.Text = "Страница 5";
            this.button_Form_Button_5.UseVisualStyleBackColor = true;
            this.button_Form_Button_5.Click += new System.EventHandler(this.button_Form_Button_5_Click);
            // 
            // pictureBox_BlackMetal
            // 
            this.pictureBox_BlackMetal.BackgroundImage = global::OOP_Laba_1.Properties.Resources.c01c7c651994739976e496054808ab2c__black_metal_interview;
            this.pictureBox_BlackMetal.Location = new System.Drawing.Point(893, 392);
            this.pictureBox_BlackMetal.Name = "pictureBox_BlackMetal";
            this.pictureBox_BlackMetal.Size = new System.Drawing.Size(231, 242);
            this.pictureBox_BlackMetal.TabIndex = 6;
            this.pictureBox_BlackMetal.TabStop = false;
            this.pictureBox_BlackMetal.Click += new System.EventHandler(this.pictureBox_BlackMetal_Click);
            // 
            // label_MouseX
            // 
            this.label_MouseX.AutoSize = true;
            this.label_MouseX.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_MouseX.Location = new System.Drawing.Point(471, 575);
            this.label_MouseX.Name = "label_MouseX";
            this.label_MouseX.Size = new System.Drawing.Size(24, 27);
            this.label_MouseX.TabIndex = 7;
            this.label_MouseX.Text = "0";
            // 
            // label_MouseY
            // 
            this.label_MouseY.AutoSize = true;
            this.label_MouseY.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_MouseY.Location = new System.Drawing.Point(564, 575);
            this.label_MouseY.Name = "label_MouseY";
            this.label_MouseY.Size = new System.Drawing.Size(24, 27);
            this.label_MouseY.TabIndex = 8;
            this.label_MouseY.Text = "0";
            // 
            // pictureBox_Stalin
            // 
            this.pictureBox_Stalin.BackgroundImage = global::OOP_Laba_1.Properties.Resources._1379684604_135901560;
            this.pictureBox_Stalin.Location = new System.Drawing.Point(160, 0);
            this.pictureBox_Stalin.Name = "pictureBox_Stalin";
            this.pictureBox_Stalin.Size = new System.Drawing.Size(799, 672);
            this.pictureBox_Stalin.TabIndex = 9;
            this.pictureBox_Stalin.TabStop = false;
            this.pictureBox_Stalin.Visible = false;
            // 
            // Form_MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::OOP_Laba_1.Properties.Resources.pepe2;
            this.ClientSize = new System.Drawing.Size(1122, 633);
            this.Controls.Add(this.pictureBox_Stalin);
            this.Controls.Add(this.label_MouseY);
            this.Controls.Add(this.label_MouseX);
            this.Controls.Add(this.pictureBox_BlackMetal);
            this.Controls.Add(this.button_Form_Button_5);
            this.Controls.Add(this.button_Form_Button_4);
            this.Controls.Add(this.button_Form_Button_3);
            this.Controls.Add(this.button_Form_Button_2);
            this.Controls.Add(this.button_Form_Button_1);
            this.Controls.Add(this.label_Chose);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form_MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Лабораторная работа №1";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MainForm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_BlackMetal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Stalin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Chose;
        private System.Windows.Forms.Button button_Form_Button_1;
        private System.Windows.Forms.Button button_Form_Button_2;
        private System.Windows.Forms.Button button_Form_Button_3;
        private System.Windows.Forms.Button button_Form_Button_4;
        private System.Windows.Forms.Button button_Form_Button_5;
        private System.Windows.Forms.PictureBox pictureBox_BlackMetal;
        private System.Windows.Forms.Label label_MouseX;
        private System.Windows.Forms.Label label_MouseY;
        private System.Windows.Forms.PictureBox pictureBox_Stalin;
    }
}

