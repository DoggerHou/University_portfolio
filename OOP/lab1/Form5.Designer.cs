
namespace OOP_Laba_1
{
    partial class Form5
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
            this.linkLabel_Anekdot = new System.Windows.Forms.LinkLabel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button_Activ = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // linkLabel_Anekdot
            // 
            this.linkLabel_Anekdot.AutoSize = true;
            this.linkLabel_Anekdot.Location = new System.Drawing.Point(835, 520);
            this.linkLabel_Anekdot.Name = "linkLabel_Anekdot";
            this.linkLabel_Anekdot.Size = new System.Drawing.Size(154, 17);
            this.linkLabel_Anekdot.TabIndex = 0;
            this.linkLabel_Anekdot.TabStop = true;
            this.linkLabel_Anekdot.Text = "https://www.anekdot.ru/";
            this.linkLabel_Anekdot.DoubleClick += new System.EventHandler(this.linkLabel_Anekdot_DoubleClick);
            // 
            // listBox1
            // 
            this.listBox1.Cursor = System.Windows.Forms.Cursors.No;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Items.AddRange(new object[] {
            "Нигер",
            "Уругвай",
            "Уганда",
            "Алжир",
            "Азербайджан",
            "Камелот",
            "Папуа-Новая Гвинея",
            "город Дейл",
            "Шир, Хоббиттон",
            "Хогвартс",
            "СУПЕрДУПЕРМЕГАВСЕЛЕННАЯ"});
            this.listBox1.Location = new System.Drawing.Point(12, 54);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(306, 254);
            this.listBox1.TabIndex = 1;
            this.listBox1.Tag = "";
            // 
            // button_Activ
            // 
            this.button_Activ.Location = new System.Drawing.Point(28, 328);
            this.button_Activ.Name = "button_Activ";
            this.button_Activ.Size = new System.Drawing.Size(75, 23);
            this.button_Activ.TabIndex = 2;
            this.button_Activ.Text = "Тык";
            this.button_Activ.UseVisualStyleBackColor = true;
            this.button_Activ.Click += new System.EventHandler(this.button_Activ_Click);
            // 
            // listBox2
            // 
            this.listBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 25;
            this.listBox2.Location = new System.Drawing.Point(496, 54);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(347, 254);
            this.listBox2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(464, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(421, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Страны мечты(просто добавьте)";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(383, 441);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(151, 57);
            this.progressBar1.TabIndex = 5;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(243, 361);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Цвет";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(415, 361);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Цвет";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(575, 361);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Цвет";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1001, 546);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.button_Activ);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.linkLabel_Anekdot);
            this.Name = "Form5";
            this.Tag = "";
            this.Text = "Form5";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel_Anekdot;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button_Activ;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}