
namespace OOP_Laba_1
{
    partial class Form4
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
            this.checkedListBox_Chose = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label_Chose = new System.Windows.Forms.Label();
            this.button_Checking = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Delete = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // checkedListBox_Chose
            // 
            this.checkedListBox_Chose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkedListBox_Chose.FormattingEnabled = true;
            this.checkedListBox_Chose.Items.AddRange(new object[] {
            "Листок бумаги",
            "Ручка(нерабочая)",
            "шлепки",
            "Деньги на обед"});
            this.checkedListBox_Chose.Location = new System.Drawing.Point(42, 66);
            this.checkedListBox_Chose.Name = "checkedListBox_Chose";
            this.checkedListBox_Chose.Size = new System.Drawing.Size(298, 129);
            this.checkedListBox_Chose.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(37, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "1)Соберите студента на пары";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Библия",
            "Ноутбук",
            "Учебники",
            "Хорошее настроение"});
            this.comboBox1.Location = new System.Drawing.Point(448, 66);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(290, 33);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Text = "....";
            this.comboBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
            // 
            // label_Chose
            // 
            this.label_Chose.AutoSize = true;
            this.label_Chose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Chose.Location = new System.Drawing.Point(443, 133);
            this.label_Chose.Name = "label_Chose";
            this.label_Chose.Size = new System.Drawing.Size(0, 20);
            this.label_Chose.TabIndex = 3;
            // 
            // button_Checking
            // 
            this.button_Checking.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Checking.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Checking.Location = new System.Drawing.Point(42, 215);
            this.button_Checking.Name = "button_Checking";
            this.button_Checking.Size = new System.Drawing.Size(277, 56);
            this.button_Checking.TabIndex = 4;
            this.button_Checking.Text = "Студент берет все это на пары";
            this.button_Checking.UseVisualStyleBackColor = true;
            this.button_Checking.Click += new System.EventHandler(this.button_Checking_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker.Location = new System.Drawing.Point(42, 374);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 30);
            this.dateTimePicker.TabIndex = 5;
            this.dateTimePicker.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dateTimePicker_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(37, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(476, 58);
            this.label2.TabIndex = 6;
            this.label2.Text = "2)Проверка знаний истории\r\nКогда началась вторая мировая война?\r\n";
            // 
            // button_Delete
            // 
            this.button_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Delete.Location = new System.Drawing.Point(466, 215);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(234, 56);
            this.button_Delete.TabIndex = 7;
            this.button_Delete.Text = "Такого нам не надо";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(612, 361);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(55, 21);
            this.radioButton1.TabIndex = 8;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Мак";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(797, 361);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(74, 21);
            this.radioButton2.TabIndex = 9;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "За мак";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 520);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.button_Checking);
            this.Controls.Add(this.label_Chose);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListBox_Chose);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Resize += new System.EventHandler(this.Form4_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox_Chose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label_Chose;
        private System.Windows.Forms.Button button_Checking;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}