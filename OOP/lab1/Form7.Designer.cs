
namespace OOP_Laba_1
{
    partial class Form7
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
            this.label_Question = new System.Windows.Forms.Label();
            this.button_Yes = new System.Windows.Forms.Button();
            this.button_No = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_Question
            // 
            this.label_Question.AutoSize = true;
            this.label_Question.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Question.Location = new System.Drawing.Point(302, 132);
            this.label_Question.Name = "label_Question";
            this.label_Question.Size = new System.Drawing.Size(306, 29);
            this.label_Question.TabIndex = 0;
            this.label_Question.Text = "Вы зачтете мне лабу?((";
            // 
            // button_Yes
            // 
            this.button_Yes.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Yes.Location = new System.Drawing.Point(529, 206);
            this.button_Yes.Name = "button_Yes";
            this.button_Yes.Size = new System.Drawing.Size(98, 51);
            this.button_Yes.TabIndex = 1;
            this.button_Yes.Text = "Да";
            this.button_Yes.UseVisualStyleBackColor = true;
            this.button_Yes.Click += new System.EventHandler(this.button_Yes_Click);
            // 
            // button_No
            // 
            this.button_No.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_No.Location = new System.Drawing.Point(307, 206);
            this.button_No.Name = "button_No";
            this.button_No.Size = new System.Drawing.Size(97, 51);
            this.button_No.TabIndex = 2;
            this.button_No.Text = "Нет";
            this.button_No.UseVisualStyleBackColor = true;
            this.button_No.Click += new System.EventHandler(this.button_No_Click);
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 569);
            this.Controls.Add(this.button_No);
            this.Controls.Add(this.button_Yes);
            this.Controls.Add(this.label_Question);
            this.Name = "Form7";
            this.Text = "Form7";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Question;
        private System.Windows.Forms.Button button_Yes;
        private System.Windows.Forms.Button button_No;
    }
}